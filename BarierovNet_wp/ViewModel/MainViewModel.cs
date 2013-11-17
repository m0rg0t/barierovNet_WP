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
using Windows.Storage;
using System.IO;
using Microsoft.Phone.Maps.Services;
using System.Collections.Generic;
using System.Windows;

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

        private Collection<string> _nearestImages;
        /// <summary>
        /// Коллекция картинок ближайших объектов
        /// </summary>
        public Collection<string> NearestImages
        {
            get { return _nearestImages; }
            set
            {
                _nearestImages = value;
                RaisePropertyChanged("NearestImages");
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
                string citiesOut = await MakeWebRequest("http://barierov.net/api/cities/");
                Cities = JsonConvert.DeserializeObject<ObservableCollection<CityItem>>(citiesOut);
            }
            catch { };

            try
            {
                await GetCurrentCoordinate();
            }
            catch { };

            /*try
            {
                Uri dataUri = new Uri("ms-appx:///Data/moscow_places.json");
                StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
                //string jsonText = await ReadFileContentsAsync(file.Path);
                var itemStream = file.OpenReadAsync();

                //var isoFileReader = new System.IO.StreamReader(itemStream);
                //string jsonText = isoFileReader.ReadLine();

                //string jsonText = itemStream.ToString();
                    //FileIO.ReadTextAsync(file);
                string jsonText = "";
                Places = JsonConvert.DeserializeObject<ObservableCollection<PlaceItem>>(jsonText);

                var nearItems = Places.OrderBy(c => c.DistanceInMeters).Take(60);
                this.NearestPlaces = new ObservableCollection<PlaceItem>(nearItems);

                this.NearestImages = new Collection<string>();
                foreach (var item in NearestPlaces)
                {
                    NearestImages.Add(item.MainImage);
                };
                RaisePropertyChanged("NearestImages");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            };*/

            this.Loading = false;

            return true;
        }

        private int _cityId = 1;
        /// <summary>
        /// Идентификатор города
        /// </summary>
        public int CityId
        {
            get { return _cityId; }
            set { 
                _cityId = value;
                RaisePropertyChanged("CityId");
            }
        }

        private string _cityName = "";
        /// <summary>
        /// Название города
        /// </summary>
        public string CityName
        {
            get { return _cityName; }
            set { 
                _cityName = value;
                RaisePropertyChanged("CityName");
            }
        }
        
        

        /// <summary>
        /// Get nearest to the current location items
        /// </summary>
        private void GetNearestItems()
        {
            var nearItems = Places.OrderBy(c => c.DistanceInMeters).Take(60);
            this.NearestPlaces = new ObservableCollection<PlaceItem>(nearItems);

            this.NearestImages = new Collection<string>();
            foreach (var item in NearestPlaces)
            {
                NearestImages.Add(item.MainImage);
            };
            RaisePropertyChanged("NearestImages");
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

        private bool _geolocationState = true;
        /// <summary>
        /// 
        /// </summary>
        public bool GeolocationState
        {
            get { return _geolocationState; }
            set { 
                _geolocationState = value;
                RaisePropertyChanged("GeolocationState");
            }
        }

        public void ToggleGeolocationState()
        {
            if (GeolocationState)
            {
                GeolocationState = false;
                this.CityId = 1;
                this.CityName = "Москва";
                LoadPlaces();
                MessageBox.Show("Геолокация отключена.");
            }
            else
            {
                GeolocationState = true;
                MessageBox.Show("Геолокация включена.");
                GetCurrentCoordinate();
            };
        }

        public long UnixTimeNow()
        {
            TimeSpan _TimeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            return (long)_TimeSpan.TotalSeconds;
        }

        private GeoCoordinate _MyCoordinate = new GeoCoordinate(55.756845, 37.616984);
        /// <summary>
        /// Текущие координаты пользователя
        /// </summary>
        public GeoCoordinate MyCoordinate
        {
            get { return _MyCoordinate; }
            set {
                if (_MyCoordinate != value)
                {
                    _MyCoordinate = value;
                    GetNearestItems();
                    RaisePropertyChanged("MyCoordinate");
                };
            }
        }
        

        private double _accuracy = 0.0;

        /// <summary>
        /// 
        /// </summary>
        private async Task<bool> GetCurrentCoordinate()
        {
            Geolocator geolocator = new Geolocator();
            geolocator.DesiredAccuracy = PositionAccuracy.Default;

            try
            {
                if (GeolocationState == true)
                {
                    Geoposition currentPosition = await geolocator.GetGeopositionAsync();
                    _accuracy = currentPosition.Coordinate.Accuracy;

                    MyCoordinate = new GeoCoordinate(currentPosition.Coordinate.Latitude, currentPosition.Coordinate.Longitude);
                };
                //Dispatcher.BeginInvoke(() =>
                //{
                
                //});

                if (this.Places.Count() < 1)
                {
                    ReverseGeocodeQuery MyReverseGeocodeQuery = new ReverseGeocodeQuery();
                    MyReverseGeocodeQuery.GeoCoordinate = new GeoCoordinate(MyCoordinate.Latitude, MyCoordinate.Longitude);
                    MyReverseGeocodeQuery.QueryCompleted += ReverseGeocodeQuery_QueryCompleted;
                    MyReverseGeocodeQuery.QueryAsync();
                };
            }
            catch (Exception ex)
            {
                // Couldn't get current location - location might be disabled in settings
                //MessageBox.Show("Current location cannot be obtained. Check that location service is turned on in phone settings.");
            }
            return true;
        }

        private async void ReverseGeocodeQuery_QueryCompleted(object sender, QueryCompletedEventArgs<IList<MapLocation>> e)
        {
            if (e.Error == null)
            {
                if (e.Result.Count > 0)
                {
                    MapAddress address = e.Result[0].Information.Address;

                    if (this.Cities.FirstOrDefault(c => c.Title == address.City) != null)
                    {
                        this.CityName = this.Cities.FirstOrDefault(c => c.Title == address.City).Title;
                        this.CityId = this.Cities.FirstOrDefault(c => c.Title == address.City).Id;
                    }
                    else
                    {
                        if (this.Cities.FirstOrDefault(c => c.Title == address.District) != null)
                        {
                            this.CityName = this.Cities.FirstOrDefault(c => c.Title == address.District).Title;
                            this.CityId = this.Cities.FirstOrDefault(c => c.Title == address.District).Id;
                        };
                    };

                    //await LoadPlaces();
                }
            };

            await LoadPlaces();
        }

        private async Task<bool> LoadPlaces()
        {
            this.Loading = true;
            try
            {
                string placesOut = await MakeWebRequest("http://barierov.net/api/business/list/?city=" + this.CityId);
                Places = JsonConvert.DeserializeObject<ObservableCollection<PlaceItem>>(placesOut);

                GetNearestItems();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            };
            this.Loading = false;
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