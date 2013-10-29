using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using BarierovNet_wp.ViewModel;
using System.Device.Location;
using Microsoft.Phone.Maps.Controls;
using System.Windows.Shapes;
using System.Windows.Input;
using BarierovNet_wp.Model;

namespace BarierovNet_wp.Pages
{
    public partial class MapPage : PhoneApplicationPage
    {
        // Constructor
        public MapPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void PlaceMap_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                DrawMapMarkers();
            }
            catch { };
        }

        private void DrawMapMarkers()
        {
            PlaceMap.Layers.Clear();
            MapLayer mapLayer = new MapLayer();

            // Draw marker for current position
            if (ViewModelLocator.MainStatic.CurrentPlace.Position != null)
            {
                try
                {
                    //DrawAccuracyRadius(mapLayer);
                    foreach (var item in ViewModelLocator.MainStatic.NearestPlaces) {
                        DrawMapMarker(item, Colors.Red, mapLayer);
                    };
                }
                catch { };
                

            }
            PlaceMap.Layers.Add(mapLayer);
        }


        private void DrawMapMarker(PlaceItem item, Color color, MapLayer mapLayer)
        {
            // Create a map marker
            //var item = new MapItemControl();
            Polygon polygon = new Polygon();
            polygon.Points.Add(new Point(0, 0));
            polygon.Points.Add(new Point(0, 75));
            polygon.Points.Add(new Point(25, 0));
            polygon.Fill = new SolidColorBrush(color);

            // Enable marker to be tapped for location information
            polygon.Tag = new GeoCoordinate(item.Latitude, item.Longitude);
            polygon.MouseLeftButtonUp += new MouseButtonEventHandler(Marker_Click);

            // Create a MapOverlay and add marker
            MapOverlay overlay = new MapOverlay();
            overlay.Content = polygon; //polygon;
            overlay.GeoCoordinate = new GeoCoordinate(item.Latitude, item.Longitude);
            overlay.PositionOrigin = new Point(0.5, 1.0);
            mapLayer.Add(overlay);
        }


        private void Marker_Click(object sender, EventArgs e)
        {
            Polygon p = (Polygon)sender;
            GeoCoordinate geoCoordinate = (GeoCoordinate)p.Tag;
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}