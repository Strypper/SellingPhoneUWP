using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Quobject.SocketIoClientDotNet.Client;
using SocketIO.Layouts;
using SocketIO.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SocketIO
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;
        }


        private void StartUp(object sender, RoutedEventArgs e)
        {
            //IUShop.IsSelected = true;
            MainFrameNavigation.Visibility = Visibility.Collapsed;
        }

        private void NavView_Navigate(NavigationViewItem item)
        {
            switch (item.Name)
            {
                case "IUShop":
                    TheMainFrame.Navigate(typeof(IUShopping));
                    break;
            }

            switch (item.Name)
            {
                case "News":
                    TheMainFrame.Navigate(typeof(Test));
                    break;
            }

            //switch (item.Name)
            //{
            //    case "SchoolResources":
            //        TheMainFrame.Navigate(typeof(StuffDetail));
            //        break;
            //}
        }

        private void MainFrameNavigation_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                TheMainFrame.Navigate(typeof(SettingsPage));
            }
            else
            {
                NavigationViewItem item = args.SelectedItem as NavigationViewItem;
                NavView_Navigate(item);
            }
        }





        private void SwitchAccess(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch != null)
            {
                if (toggleSwitch.IsOn == true)
                {
                    MailStack.Visibility = Visibility.Collapsed;
                    MailText.Visibility = Visibility.Collapsed;
                    AgeStack.Visibility = Visibility.Collapsed;
                    PhoneNumber.Visibility = Visibility.Collapsed;
                    SignUpButton.Visibility = Visibility.Collapsed;
                    LoginButton.Visibility = Visibility.Visible;
                }
                else
                {
                    MailStack.Visibility = Visibility.Visible;
                    MailText.Visibility = Visibility.Visible;
                    AgeStack.Visibility = Visibility.Visible;
                    PhoneNumber.Visibility = Visibility.Visible;
                    SignUpButton.Visibility = Visibility.Visible;
                    LoginButton.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GuessLog(object sender, RoutedEventArgs e)
        {
            MainFrameNavigation.Visibility = Visibility.Visible;
            IUShop.IsSelected = true;
            LoginGrid.Visibility = Visibility.Collapsed;
        }

        private void TheMainFrame_Navigated(object sender, NavigationEventArgs e)
        {
           SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = TheMainFrame.CanGoBack ?
           AppViewBackButtonVisibility.Visible :
           AppViewBackButtonVisibility.Collapsed;
        }

        private void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            if (TheMainFrame.CanGoBack)
            {
                e.Handled = true;
                TheMainFrame.GoBack();
            }
        }
    }
}
