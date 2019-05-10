using Newtonsoft.Json;
using SocketIO.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SocketIO.Layouts
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class IUShopping : Page
    {
        private static readonly HttpClient client = new HttpClient();
        Compositor _compositor = Window.Current.Compositor;
        SpringVector3NaturalMotionAnimation _springAnimation;
        public IUShopping()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
            GetStuffsAsync();
        }


        //GET STUFFS
        public async System.Threading.Tasks.Task GetStuffsAsync()
        {
            var response = await client.GetAsync("http://localhost:3000/api/Stuffs");
            var result = await response.Content.ReadAsStringAsync();
            ObservableCollection<Stuff> stuffslist = JsonConvert.DeserializeObject<ObservableCollection<Stuff>>(result);
            StuffsView.ItemsSource = stuffslist;
        }


        //POST REQUEST
        public async void PostRequest(string model, string brand, int storage, int ram,
            double battery, Color color, string chip, string owner, double price,
            DateTime dateupload,int usage, string Coverimage, string Location)
        {
            Uri ServerUrl = new Uri("http://localhost:3000/api/AddStuff");
            var values = new Dictionary<string, string>
            {
               { "model" , model},
               { "brand" , brand},
               { "storage" , storage.ToString()},
               { "ram" , ram.ToString()},
               { "battery" , battery.ToString()},
               { "color" , color.ToString()},
               { "chip" , chip},
               { "owner" , owner},
               { "price" , price.ToString()},
               { "dateupload" , dateupload.ToShortDateString()},
               { "timeupload" , dateupload.ToLongTimeString()},
               { "Location" , Location},
               { "usage" , usage.ToString()},
               { "Coverimage" , Coverimage},
               { "StuffImage1" , Coverimage},
               { "StuffImage2" , Coverimage}
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("http://localhost:3000/api/AddStuff", content);
            var responseString = await response.Content.ReadAsStringAsync();
        }

        //ADD INFO USING POST REQUEST
        private void PostButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime CurrentDateTime = DateTime.Now;
            
            int PostStorage = Int16.Parse(Storage.Text);
            int PostRam = Int16.Parse(Ram.Text);
            int PostBattery = Int16.Parse(Battery.Text);
            double PostPrice = Convert.ToDouble(Price.Text);
            int PostUsage = Int16.Parse(Usage.Text);
            PostRequest(Model.Text, Brand.Text, PostStorage, PostRam, PostBattery, DeviceColor.Color, Processor.Text, "Strypper", PostPrice, CurrentDateTime, PostUsage, PhotoPath.Text, Location.Text);
        }

        private void PopUpClick(object sender, RoutedEventArgs e)
        {
            AddStuffsPopUp.IsOpen = true;
        }

        private void StuffViewRefresh_RefreshRequested(RefreshContainer sender, RefreshRequestedEventArgs args)
        {
            GetStuffsAsync();       
        }






        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Stuff clicked_item = (Stuff)((sender as FrameworkElement).DataContext);
            await(new MessageDialog(clicked_item.Model + " Button is clicked ")).ShowAsync();
        }








        //PopUp button Animation

        private void Button_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            // Scale up to 1.5
            CreateOrUpdateSpringAnimation(1.5f);

            (sender as UIElement).StartAnimation(_springAnimation);
        }

        private void CreateOrUpdateSpringAnimation(float finalValue)
        {
            if (_springAnimation == null)
            {
                _springAnimation = _compositor.CreateSpringVector3Animation();
                _springAnimation.Target = "Scale";
            }

            _springAnimation.FinalValue = new Vector3(finalValue);
        }

        private void Button_PointerExited(object sender, PointerRoutedEventArgs e)
        {

            // Scale back down to 1.0
            CreateOrUpdateSpringAnimation(1.0f);

            (sender as UIElement).StartAnimation(_springAnimation);
        }



        //Drag and Drop
        private void Button_DragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Copy;
        }

        private async void Button_Drop(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.StorageItems))
            {
                var items = await e.DataView.GetStorageItemsAsync();
                if (items.Count > 0)
                {
                    var storageFile = items[0] as StorageFile;
                    var bitmapImage = new BitmapImage();
                    bitmapImage.SetSource(await storageFile.OpenAsync(FileAccessMode.Read));
                    
                    // Set the image on the main page to the dropped image
                    //Image.Source = bitmapImage;
                }
            }
        }


        //Navigation to Detail
        private async void StuffsView_ItemClick(object sender, ItemClickEventArgs e)
        {
            NavigationProgress.IsActive = true;
            await Task.Delay(1000);
            //new Thread0(() =>
            //{
            //    var item = (Stuff)e.ClickedItem;
            //    var ImageContainer = item.CoverImagePath;
            //    var parameter = new Stuff();
            //    parameter.CoverImagePath = item.CoverImagePath;
            //    parameter.SecondImagePath = item.SecondImagePath;
            //    parameter.ThirdImagePath = item.ThirdImagePath;
            //    parameter.Brand = item.Brand;
            //    parameter.Model = item.Model;
            //    parameter.Ram = item.Ram;
            //    parameter.Storage = item.Storage;
            //    parameter.Battery = item.Battery;
            //    parameter.Usage = item.Usage;
            //    parameter.Color = item.Color;
            //    parameter.Processor = item.Processor;
            //    parameter.Price = item.Price;
            //    parameter.SellDescription = item.SellDescription;

            //    NavigationProgress.IsActive = false;
            //    Frame.Navigate(typeof(StuffDetail), parameter);
            //}).Start();


            var item = (Stuff)e.ClickedItem;
            var ImageContainer = item.CoverImagePath;
            var parameter = new Stuff();
            parameter.CoverImagePath = item.CoverImagePath;
            parameter.SecondImagePath = item.SecondImagePath;
            parameter.ThirdImagePath = item.ThirdImagePath;
            parameter.Brand = item.Brand;
            parameter.Model = item.Model;
            parameter.Ram = item.Ram;
            parameter.Storage = item.Storage;
            parameter.Battery = item.Battery;
            parameter.Usage = item.Usage;
            parameter.Color = item.Color;
            parameter.Processor = item.Processor;
            parameter.Price = item.Price;
            parameter.SellDescription = item.SellDescription;

            NavigationProgress.IsActive = false;
            Frame.Navigate(typeof(StuffDetail), parameter);
        }
    }
}
