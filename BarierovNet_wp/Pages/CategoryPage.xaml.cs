using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using BarierovNet_wp.Model;
using BarierovNet_wp.ViewModel;

namespace BarierovNet_wp.Pages
{
    public partial class CategoryPage : PhoneApplicationPage
    {
        public CategoryPage()
        {
            InitializeComponent();
        }

        private void PlacesList_ItemTap(object sender, Telerik.Windows.Controls.ListBoxItemTapEventArgs e)
        {
            try
            {
                ViewModelLocator.MainStatic.CurrentPlace = (PlaceItem)this.PlacesList.SelectedItem;
                NavigationService.Navigate(new Uri("/Pages/PlacePage.xaml", UriKind.Relative));
            }
            catch { };
        }

        private void CategoriesList_ItemTap(object sender, Telerik.Windows.Controls.ListBoxItemTapEventArgs e)
        {
            ViewModelLocator.MainStatic.CurrentCategory = (CategoryItem)this.CategoriesList.SelectedItem;
            NavigationService.Navigate(new Uri("/Pages/CategoryPage.xaml", UriKind.Relative));
        }
    }
}