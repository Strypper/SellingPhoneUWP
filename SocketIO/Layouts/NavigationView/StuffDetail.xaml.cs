using Newtonsoft.Json;
using Quobject.SocketIoClientDotNet.Client;
using SocketIO.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SocketIO.Layouts
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StuffDetail : Page
    {
        string FirstImageString;
        string SecondImageString;
        string ThirdImageString;
        Socket socket = IO.Socket("ws://localhost:8888");
        ObservableCollection<SocketMessage> InCommingData { get; set; } = new ObservableCollection<SocketMessage>();
        public StuffDetail()
        {
            

            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
            //DisconnectState();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var parameter = (Stuff)e.Parameter;
            FirstImageString = parameter.CoverImagePath;
            SecondImageString = parameter.SecondImagePath;
            ThirdImageString = parameter.ThirdImagePath;

            Uri imageUri = new Uri(FirstImageString, UriKind.RelativeOrAbsolute);
            BitmapImage bitmap = new BitmapImage(new Uri(this.BaseUri, imageUri));

            Uri imageUri1 = new Uri(SecondImageString, UriKind.RelativeOrAbsolute);
            BitmapImage bitmap1 = new BitmapImage(new Uri(this.BaseUri, imageUri1));

            Uri imageUri2 = new Uri(ThirdImageString, UriKind.RelativeOrAbsolute);
            BitmapImage bitmap2 = new BitmapImage(new Uri(this.BaseUri, imageUri2));

            CoverImage.Source = bitmap;
            SecondaryImage.Source = bitmap1;
            ThirdImage.Source = bitmap2;

            CompanyName.Text = parameter.Brand;
            PhoneName.Text = parameter.Model;
            Ram.Text = parameter.Ram.ToString();
            Storage.Text = parameter.Storage.ToString();
            Battery.Text = parameter.BatteryMah;
            Usage.Text = parameter.Usage.ToString();
            DeviceColor.Text = parameter.Color;
            Processor.Text = parameter.Processor;
            Para.Text = parameter.SellDescription;
        }


        private void DisconnectState()
        {
            //ReceivedText.Text = "Not Connect";
        }



        private void SetSocket()
        {
            socket.Connect();
            //ReceivedText.Text = "Connect Completed";

            socket.On("chat", async (data) =>
            {

                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    var IncomeMess = JsonConvert.DeserializeObject<SocketMessage>(data.ToString());
                    InCommingData.Add(IncomeMess);

                    //socket.Disconnect();
                });
            });
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            var message = new SocketMessage()
            {
                message = MessTextBox.Text,
                handle = "From Beta User UWP"
            };
            socket.Emit("chat", JsonConvert.SerializeObject(message));
        }


        //Connect Click
        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            SetSocket();
            ChatWindow.ItemsSource = InCommingData;
            Color ConnectButonColor = new Color();
            Color TextColor = new Color();
            ConnectButonColor.A = 150;
            ConnectButonColor.R = 204;
            ConnectButonColor.G = 255;
            ConnectButonColor.B = 153;
            TextColor.A = 255;
            TextColor.R = 0;
            TextColor.G = 255;
            TextColor.B = 0;
            ConnectBTN.Background = new SolidColorBrush(ConnectButonColor);
            ConnectBTN.Foreground = new SolidColorBrush(TextColor);
            ConnectState.Text = "Connected";
            ConnectState.Foreground = new SolidColorBrush(TextColor);
            Signal.Foreground = new SolidColorBrush(TextColor);
        }

        //Page StartUp
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
