using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Maps.Controls;
using System.Windows.Shapes;
using System.Device.Location;
using System.Windows.Input;
using BarierovNet_wp.ViewModel;
using System.Windows.Media;
using System.Windows.Data;

namespace BarierovNet_wp.Pages
{
    public partial class PlacePage : PhoneApplicationPage
    {
        public PlacePage()
        {
            InitializeComponent();
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
                }
                catch { };
                DrawMapMarker(ViewModelLocator.MainStatic.CurrentPlace.Position, Colors.Red, mapLayer);
            }
            PlaceMap.Layers.Add(mapLayer);
        }

        
        private void DrawMapMarker(GeoCoordinate coordinate, Color color, MapLayer mapLayer)
        {
            // Create a map marker
            //var item = new MapItemControl();
            Polygon polygon = new Polygon();
            polygon.Points.Add(new Point(0, 0));
            polygon.Points.Add(new Point(0, 75));
            polygon.Points.Add(new Point(25, 0));
            polygon.Fill = new SolidColorBrush(color);

            // Enable marker to be tapped for location information
            polygon.Tag = new GeoCoordinate(coordinate.Latitude, coordinate.Longitude);
            polygon.MouseLeftButtonUp += new MouseButtonEventHandler(Marker_Click);

            // Create a MapOverlay and add marker
            MapOverlay overlay = new MapOverlay();
            overlay.Content = polygon; //polygon;
            overlay.GeoCoordinate = new GeoCoordinate(coordinate.Latitude, coordinate.Longitude);
            overlay.PositionOrigin = new Point(0.5, 1.0);
            mapLayer.Add(overlay);
        }

        
        private void Marker_Click(object sender, EventArgs e)
        {
            Polygon p = (Polygon)sender;
            GeoCoordinate geoCoordinate = (GeoCoordinate)p.Tag;
        }

    }
}