using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using BarierovNet_wp.Resources;
using BarierovNet_wp.ViewModel;
using BarierovNet_wp.Model;
using Microsoft.Phone.Tasks;
using Coding4Fun.Toolkit.Controls;

namespace BarierovNet_wp
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
            ViewModelLocator.MainStatic.LoadData();
        }

        private void MapTile_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            try
            {
                NavigationService.Navigate(new Uri("/Pages/MapPage.xaml", UriKind.Relative));
            }
            catch { };
        }

        private void List_ItemTap(object sender, Telerik.Windows.Controls.ListBoxItemTapEventArgs e)
        {
            try
            {
                ViewModelLocator.MainStatic.CurrentPlace = (PlaceItem)this.NearestPlaces.SelectedItem;
                NavigationService.Navigate(new Uri("/Pages/PlacePage.xaml", UriKind.Relative));
            }
            catch { };
        }

        private void CategoriesList_ItemTap(object sender, Telerik.Windows.Controls.ListBoxItemTapEventArgs e)
        {
            try
            {
                ViewModelLocator.MainStatic.CurrentCategory = (CategoryItem)this.CategoriesList.SelectedItem;
                NavigationService.Navigate(new Uri("/Pages/CategoryPage.xaml", UriKind.Relative));
            }
            catch { };
        }

        private void NearestTile_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            try
            {
                MainPanorama.DefaultItem = MainPanorama.Items[2];
            }
            catch { };
        }

        private void CategoriesTile_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            try
            {
                MainPanorama.DefaultItem = MainPanorama.Items[1];
            }
            catch { };
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var messagePrompt = new MessagePrompt
                {
                    Title = "Политика конфиденциальности",
                    Body = new TextBlock
                    {
                        Text = "Приложение не собирает никаких данных без вашего ведома.\nПриложение не собирает и не хранит информацию, которая связана с определенным именем. Мы также делаем все возможное, чтобы обезопасить хранимые данные.\nПринимая условия, которые включают эту политику вы соглашаетесь с данной политикой конфиденциальности.\nКонтакты m0rg0t.Anton@gmail.com",
                        MaxHeight = 500,
                        TextWrapping = TextWrapping.Wrap
                    },
                    IsAppBarVisible = false,
                    IsCancelVisible = false
                };
                messagePrompt.Show();
            }
            catch { };
        }

        private void ApplicationBarMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                var marketplaceReviewTask = new MarketplaceReviewTask();
                marketplaceReviewTask.Show();
            }
            catch
            {
            };
        }

        private void ApplicationBarMenuItem_Click_2(object sender, EventArgs e)
        {
            try
            {
                ViewModelLocator.MainStatic.ToggleGeolocationState();
            }
            catch { };
        }

        private void ApplicationBarMenuItem_Click_3(object sender, EventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.Uri = new Uri("http://barierov.net/", UriKind.Absolute);
            webBrowserTask.Show();
        }

        private void SearchTile_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            try
            {
                //NavigationService.Navigate(new Uri("/SearchPage.xaml", UriKind.Relative));
                InputPrompt input = new InputPrompt();
                input.Completed += input_Completed;
                input.Title = "Поиск";
                input.Message = "ВВедите текст для поиска:";
                input.Show();
            }
            catch { };
        }

        private void input_Completed(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            try
            {
                ViewModelLocator.MainStatic.SearchQuery = e.Result.ToString();
                MainPanorama.DefaultItem = MainPanorama.Items[2];
            }
            catch { };
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