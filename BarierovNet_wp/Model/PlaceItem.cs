using BarierovNet_wp.ViewModel;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BarierovNet_wp.Model
{
    public class PlaceItem: ViewModelBase
    {
        public PlaceItem()
        {
        }

        private string _id;
        /// <summary>
        /// Идентификатор объекта
        /// </summary>
        public string Id
        {
            get { return _id; }
            set { 
                _id = value;
                RaisePropertyChanged("Id");
            }
        }

        private string _title;
        /// <summary>
        /// Название места
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { 
                _title = value.Replace("&quot;","\"");
            }
        }

        private int _city_id;
        /// <summary>
        /// Идентификатор города
        /// </summary>
        public int City_id
        {
            get { return _city_id; }
            set { 
                _city_id = value;
                RaisePropertyChanged("City_id");
            }
        }

        private string _full_title;
        /// <summary>
        /// Полный заголовок
        /// </summary>
        public string Full_title
        {
            get { return _full_title; }
            set { 
                _full_title = value;
                RaisePropertyChanged("Full_title");
            }
        }

        private string _address;
        /// <summary>
        /// Адрес места
        /// </summary>
        public string Address
        {
            get { return _address; }
            set { 
                _address = value;
                RaisePropertyChanged("Address");
            }
        }

        private string _phone;
        /// <summary>
        /// Телефон места
        /// </summary>
        public string Phone
        {
            get { return _phone; }
            set { 
                _phone = value;
                RaisePropertyChanged("Phone");
            }
        }

        private string _site;
        /// <summary>
        /// Сайт места
        /// </summary>
        public string Site
        {
            get { return _site; }
            set { 
                _site = value;
                RaisePropertyChanged("Site");
            }
        }

        private string _email;
        /// <summary>
        /// email места
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { 
                _email = value;
                RaisePropertyChanged("Email");
            }
        }

        private string _description;
        /// <summary>
        /// Описание места
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { 
                _description = value;
                RaisePropertyChanged("Description");
            }
        }

        private string _work_time;
        /// <summary>
        /// рабочее место
        /// </summary>
        public string Work_time
        {
            get { return _work_time; }
            set { _work_time = value; }
        }

        private string _levelId;
        /// <summary>
        /// 
        /// </summary>
        public string LevelId
        {
            get { return _levelId; }
            set { _levelId = value; }
        }

        private string _user_id;
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public string User_id
        {
            get { return _user_id; }
            set { _user_id = value; }
        }

        private string _activation;
        /// <summary>
        /// 
        /// </summary>
        public string Activation
        {
            get { return _activation; }
            set { 
                _activation = value;
                RaisePropertyChanged("Activation");
            }
        }

        private string _delete;
        /// <summary>
        /// 
        /// </summary>
        public string Delete
        {
            get { return _delete; }
            set { 
                _delete = value;
                RaisePropertyChanged("Delete");
            }
        }

        private double _latitude;
        /// <summary>
        /// Широта
        /// </summary>
        public double Latitude
        {
            get { return _latitude; }
            set { 
                _latitude = value;
                RaisePropertyChanged("Latitude");
                RaisePropertyChanged("Position");
            }
        }

        private double _longitude;
        /// <summary>
        /// Долгота
        /// </summary>
        public double Longitude
        {
            get { return _longitude; }
            set { 
                _longitude = value;
                RaisePropertyChanged("Longitude");
                RaisePropertyChanged("Position");
            }

        }

        private GeoCoordinate _position;
        /// <summary>
        /// 
        /// </summary>
        public GeoCoordinate Position
        {
            get {
                _position = new GeoCoordinate(Latitude, Longitude);
                return _position; }
            set { 
                _position = value;
                RaisePropertyChanged("Position");
            }
        }
        

        private string _create_date;
        /// <summary>
        /// Дата создания
        /// </summary>
        public string Create_date
        {
            get { return _create_date; }
            set { 
                _create_date = value;
                RaisePropertyChanged("ApprovalDate");
            }
        }

        private string _ApprovalDate;
        /// <summary>
        /// 
        /// </summary>
        public string ApprovalDate
        {
            get { return _ApprovalDate; }
            set { 
                _ApprovalDate = value;
                RaisePropertyChanged("ApprovalDate");
            }
        }

        private string _Stairs;
        /// <summary>
        /// 
        /// </summary>
        public string Stairs
        {
            get { return _Stairs; }
            set { 
                _Stairs = value;
                RaisePropertyChanged("Stairs");
            }
        }

        private string _DoorsWidth;
        /// <summary>
        /// Ширина дверей
        /// </summary>
        public string DoorsWidth
        {
            get { return _DoorsWidth; }
            set { 
                _DoorsWidth = value;
                RaisePropertyChanged("DoorsWidth");
            }
        }

        private string _GroundEntrance;
        /// <summary>
        /// 
        /// </summary>
        public string GroundEntrance
        {
            get { return _GroundEntrance; }
            set { 
                _GroundEntrance = value;
                RaisePropertyChanged("_GroundEntrance");
            }
        }

        private string _pandus;
        /// <summary>
        /// 
        /// </summary>
        public string Pandus
        {
            get { return _pandus; }
            set { 
                _pandus = value;
                RaisePropertyChanged("Pandus");
            }
        }

        private string _elevator;
        /// <summary>
        /// 
        /// </summary>
        public string Elevator
        {
            get { return _elevator; }
            set { 
                _elevator = value;
                RaisePropertyChanged("Elevator");
            }
        }

        private string _toilet_equipment;
        /// <summary>
        /// 
        /// </summary>
        public string Toilet_equipment
        {
            get { return _toilet_equipment; }
            set { 
                _toilet_equipment = value;
                RaisePropertyChanged("Toilet_equipment");
            }
        }

        private string _spec_elevator;
        /// <summary>
        /// 
        /// </summary>
        public string Spec_elevator
        {
            get { return _spec_elevator; }
            set { 
                _spec_elevator = value;
                RaisePropertyChanged("Spec_elevator");
            }
        }

        private string _ElevatorButton;
        /// <summary>
        /// 
        /// </summary>
        public string ElevatorButton
        {
            get { return _ElevatorButton; }
            set { 
                _ElevatorButton = value;
                RaisePropertyChanged("ElevatorButton");
            }
        }

        private string _HelpAccess;
        /// <summary>
        /// 
        /// </summary>
        public string HelpAccess
        {
            get { return _HelpAccess; }
            set {
                _HelpAccess = value;
                RaisePropertyChanged("HelpAccess");
            }
        }

        private string _SwaddlePlace;
        /// <summary>
        /// 
        /// </summary>
        public string SwaddlePlace
        {
            get { return _SwaddlePlace; }
            set { 
                _SwaddlePlace = value;
                RaisePropertyChanged("SwaddlePlace");
            }
        }

        private string _stage;
        /// <summary>
        /// 
        /// </summary>
        public string Stage
        {
            get { return _stage; }
            set { 
                _stage = value;
                RaisePropertyChanged("Stage");
            }
        }

        private string _entrance_to_the_ground;
        /// <summary>
        /// 
        /// </summary>
        public string Entrance_to_the_ground
        {
            get { return _entrance_to_the_ground; }
            set { 
                _entrance_to_the_ground = value;
                RaisePropertyChanged("Entrance_to_the_ground");
            }
        }

        private string _help_staff;
        /// <summary>
        /// 
        /// </summary>
        public string Help_staff
        {
            get { return _help_staff; }
            set { 
                _help_staff = value;
                RaisePropertyChanged("Help_staff");
            }
        }

        private string _plase_for_swaddling;
        /// <summary>
        /// 
        /// </summary>
        public string Plase_for_swaddling
        {
            get { return _plase_for_swaddling; }
            set { 
                _plase_for_swaddling = value;
                RaisePropertyChanged("Plase_for_swaddling"); 
            }
        }

        private string _availability;
        /// <summary>
        /// 
        /// </summary>
        public string Availability
        {
            get { return _availability; }
            set { 
                _availability = value;
                RaisePropertyChanged("Availability"); 
            }
        }

        private string _sort;
        /// <summary>
        /// 
        /// </summary>
        public string Sort
        {
            get { return _sort; }
            set { 
                _sort = value;
                RaisePropertyChanged("Sort"); 
            }
        }

        private string _nickname;
        /// <summary>
        /// 
        /// </summary>
        public string Nickname
        {
            get { return _nickname; }
            set { 
                _nickname = value;
                RaisePropertyChanged("Nickname");
            }
        }

        private List<string> _images = new List<string>();
        /// <summary>
        /// Изображения места
        /// </summary>
        public List<string> Images
        {
            get { return _images; }
            set { 
                _images = value;
                RaisePropertyChanged("Images");
                RaisePropertyChanged("OutImage");
                RaisePropertyChanged("MainImage");                
            }
        }

        private List<string> _outImages = new List<string>();
        /// <summary>
        /// 
        /// </summary>
        public List<string> OutImages
        {
            get {
                _outImages = new List<string>();
                foreach (var item in Images)
                {
                    _outImages.Add("http://barierov.net/uploads/objects/"+item);
                };
                return _outImages;
            }
            private set { 
                _outImages = value; 
            }
        }
        

        /// <summary>
        /// 
        /// </summary>
        public string MainImage
        {
            private set { }
            get
            {
                if (this.Images.Count() > 0)
                {
                    return "http://barierov.net/uploads/objects/"+this.Images.FirstOrDefault();
                }
                else
                {
                    try
                    {
                        string catId = this.Parent_categories.FirstOrDefault();
                        var catImage = ViewModelLocator.MainStatic.Categories.FirstOrDefault(c => c.Id.ToString() == catId).Image;
                        return catImage;
                    }
                    catch {
                        return "";
                    };

                };
                
            }
        }

        private List<string> _categories = new List<string>();
        /// <summary>
        /// Категории места
        /// </summary>
        public List<string> Categories
        {
            get { return _categories; }
            set { 
                _categories = value;
                RaisePropertyChanged("Categories");
            }
        }

        private List<string> _parent_categories = new List<string>();
        /// <summary>
        /// Родительская категория
        /// </summary>
        public List<string> Parent_categories
        {
            get { return _parent_categories; }
            set { 
                _parent_categories = value;
                RaisePropertyChanged("Parent_categories");
            }
        }

        /*var sCoord = new GeoCoordinate(sLatitude, sLongitude);
        var eCoord = new GeoCoordinate(eLatitude, eLongitude);
        return sCoord.DistanceTo(eCoord);*/

        /// <summary>
        /// 
        /// </summary>
        public double DistanceInMeters
        {
            private set { }
            get
            {
                //try
                //{
                    return Position.GetDistanceTo(ViewModelLocator.MainStatic.MyCoordinate);
                //}
                //catch {
                //    return 10000000;
                //};
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double DistanceInKm
        {
            private set { }
            get
            {
                //try
                //{
                    return Math.Round(DistanceInMeters / 1000);
                //}
                //catch {
                //    return 10000;
                //};
            }
        }
        

    }
}
