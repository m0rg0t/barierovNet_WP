using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarierovNet_wp.Model
{
    public class CityItem: ViewModelBase
    {
        /*
        id
        title
        sort
        activation
        latitude
        longitude
        country_id
        */

        public CityItem() 
        {
        }

        private double _longitude;
        /// <summary>
        /// 
        /// </summary>
        public double longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }
        

        private double _latitude;
        /// <summary>
        /// 
        /// </summary>
        public double Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }
        

        private int _activation;
        /// <summary>
        /// 
        /// </summary>
        public int Activation
        {
            get { return _activation; }
            set { _activation = value; }
        }        

        private int _sort;
        /// <summary>
        /// 
        /// </summary>
        public int Sort
        {
            get { return _sort; }
            set { _sort = value; }
        }
        

        private string _title;
        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        

        private int _id;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            get { return _id; }          
            set { _id = value; }
        }               

    }
}
