using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BarierovNet_wp.Model
{
    public class CategoryItem: ViewModelBase
    {
        public CategoryItem()
        {
        }

        private int _id;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { 
                _id = value;
                RaisePropertyChanged("Id");
            }
        }

        private int _parent;
        /// <summary>
        /// 
        /// </summary>
        public int Parent
        {
            get { return _parent; }
            set { 
                _parent = value;
                RaisePropertyChanged("Parent");
            }
        }

        private string _title;
        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { 
                _title = value;
                RaisePropertyChanged("Title");
            }
        }
        
        private string _modifyurl;
        /// <summary>
        /// 
        /// </summary>
	    public string Modifyurl
	    {
		    get { return _modifyurl;}
            set { _modifyurl = value; RaisePropertyChanged("Modifyurl"); }
	    }

        private string _image;
        /// <summary>
        /// 
        /// </summary>
	    public string Image
	    {
		    get { 
                return "http://barierov.net/uploads/category/"+_image;
            }
            set { _image = value; RaisePropertyChanged("Image"); }
	    }

        private ImageSource CreateImageSource(object uri)
        {
            return new BitmapImage(new Uri(uri.ToString(), UriKind.RelativeOrAbsolute));
        }

        private string _image_flag;
        /// <summary>
        /// 
        /// </summary>
	    public string Image_flag
	    {
		    get { 
                return "http://barierov.net/uploads/category/"+_image_flag;
            }
            set { _image_flag = value; RaisePropertyChanged("Image_flag"); }
	    }

        private int _sort;
        /// <summary>
        /// 
        /// </summary>
        public int Sort
        {
            get { return _sort; }
            set { _sort = value; RaisePropertyChanged("Sort"); }
        }

        private int _activation;
        /// <summary>
        /// 
        /// </summary>
        public int Activation
        {
            get { return _activation; }
            set { _activation = value; RaisePropertyChanged("Activation"); }
        }

        private ObservableCollection<CategoryItem> _sub_cat;
        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<CategoryItem> Sub_cat
        {
            get { return _sub_cat; }
            set { _sub_cat = value; RaisePropertyChanged("Sub_cat"); }
        }
        

        private string _about;
        /// <summary>
        /// 
        /// </summary>
	    public string About
	    {
		    get { return _about;}
		    set { _about = value;}
	    }	
        
         
    }
}
