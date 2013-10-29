using GalaSoft.MvvmLight;
using BarierovNet_wp.Model;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using Windows.Devices.Geolocation;
using System.Device.Location;
using System.Linq;

namespace BarierovNet_wp.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private string _welcomeTitle = string.Empty;

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }

            set
            {
                if (_welcomeTitle == value)
                {
                    return;
                }

                _welcomeTitle = value;
                RaisePropertyChanged(WelcomeTitlePropertyName);
            }
        }

        private ObservableCollection<CategoryItem> _categories = new ObservableCollection<CategoryItem>();
        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<CategoryItem> Categories
        {
            get { return _categories; }
            set { 
                _categories = value;
                RaisePropertyChanged("Categories");
            }
        }

        private ObservableCollection<CityItem> _cities = new ObservableCollection<CityItem>();
        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<CityItem> Cities
        {
            get { return _cities; }
            set { 
                _cities = value;
                RaisePropertyChanged("Cities");
            }
        }

        private Collection<string> _categoriesImages;
        /// <summary>
        /// Коллекция картинок категории
        /// </summary>
        public Collection<string> CategoriesImages
        {
            get { return _categoriesImages; }
            set { 
                _categoriesImages = value;
                RaisePropertyChanged("CategoriesImages");
            }
        }

        private ObservableCollection<PlaceItem> _places = new ObservableCollection<PlaceItem>();
        /// <summary>
        /// Список мест города
        /// </summary>
        public ObservableCollection<PlaceItem> Places
        {
            get { return _places; }
            set { 
                _places = value;
                RaisePropertyChanged("Places");
            }
        }

        private ObservableCollection<PlaceItem> _NearestPlaces = new ObservableCollection<PlaceItem>();
        /// <summary>
        /// Список ближайших мест города
        /// </summary>
        public ObservableCollection<PlaceItem> NearestPlaces
        {
            get { return _NearestPlaces; }
            set
            {
                _NearestPlaces = value;
                RaisePropertyChanged("NearestPlaces");
            }
        }       
        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<string> MakeWebRequest(string url = "")
        {
            try
            {
                HttpClient http = new System.Net.Http.HttpClient();
                HttpResponseMessage response = await http.GetAsync(url);
                return await response.Content.ReadAsStringAsync();
            }
            catch
            {
                return "";
            };
        }

        public async Task<bool> LoadData()
        {
            this.Loading = true;
            try
            {
                CategoriesImages = new Collection<string>();
                string categoriesOut = await MakeWebRequest("http://barierov.net/api/categories/");
                Categories = JsonConvert.DeserializeObject<ObservableCollection<CategoryItem>>(categoriesOut);
                foreach (var item in Categories) {
                    CategoriesImages.Add(item.Image);
                };
            }
            catch { };

            try
            {
                await GetCurrentCoordinate();
            }
            catch { };

            try
            {
                string citiesOut = await MakeWebRequest("http://barierov.net/api/cities/");
                Cities = JsonConvert.DeserializeObject<ObservableCollection<CityItem>>(citiesOut);
            }
            catch { };

            try
            {
                string placesOut = await MakeWebRequest("http://barierov.net/api/business/list/?city=1");
                Places = JsonConvert.DeserializeObject<ObservableCollection<PlaceItem>>(placesOut);

                var nearItems = Places.OrderBy(c => c.DistanceInMeters).Take(60);
                this.NearestPlaces = new ObservableCollection<PlaceItem>(nearItems);
            }
            catch(Exception ex) {
                Debug.WriteLine(ex.ToString());
            };

            this.Loading = false;

            return true;
        }

        private PlaceItem _currentPlace = new PlaceItem();
        /// <summary>
        /// Текущее место
        /// </summary>
        public PlaceItem CurrentPlace
        {
            get { return _currentPlace; }
            set {
                _currentPlace = value;
                RaisePropertyChanged("CurrentPlace");
            }
        }

        private CategoryItem _currentCategory = new CategoryItem();
        /// <summary>
        /// Текущая категория
        /// </summary>
        public CategoryItem CurrentCategory
        {
            get { return _currentCategory; }
            set { 
                _currentCategory = value;
                RaisePropertyChanged("CurrentCategory");
            }
        }

        private string _searchQuery = "";
        /// <summary>
        /// 
        /// </summary>
        public string SearchQuery
        {
            get { return _searchQuery; }
            set
            {
                _searchQuery = value;
                RaisePropertyChanged("SearchQuery");
            }
        }

        public long UnixTimeNow()
        {
            TimeSpan _TimeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            return (long)_TimeSpan.TotalSeconds;
        }

        /// <summary>
        /// 
        /// </summary>
        public GeoCoordinate MyCoordinate
        {
            get;
            set;
        }

        private double _accuracy = 0.0;

        /// <summary>
        /// 
        /// </summary>
        private async Task<bool> GetCurrentCoordinate()
        {
            Geolocator geolocator = new Geolocator();
            geolocator.DesiredAccuracy = PositionAccuracy.High;

            try
            {
                Geoposition currentPosition = await geolocator.GetGeopositionAsync(TimeSpan.FromMinutes(1),
                                                                                   TimeSpan.FromSeconds(10));
                _accuracy = currentPosition.Coordinate.Accuracy;
                //Dispatcher.BeginInvoke(() =>
                //{
                MyCoordinate = new GeoCoordinate(currentPosition.Coordinate.Latitude, currentPosition.Coordinate.Longitude);
                //});
            }
            catch (Exception ex)
            {
                // Couldn't get current location - location might be disabled in settings
                //MessageBox.Show("Current location cannot be obtained. Check that location service is turned on in phone settings.");
            }
            return true;
        }

        private bool _loading = false;
        /// <summary>
        /// 
        /// </summary>
        public bool Loading
        {
            get { return _loading; }
            set
            {
                _loading = value;
                RaisePropertyChanged("Loading");
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /*public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    WelcomeTitle = item.Title;
                });
        }*/

        public MainViewModel()
        {
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}