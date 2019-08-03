using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;
//using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using System.Diagnostics;


namespace HIVE

{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UnlockPage : ContentPage
    {
        public int messageSequence = 0;
        //static ForeignersDevice republicDevice;
        ZXingScannerPage scanPage;
        public UnlockPage()
        {
            InitializeComponent();
            //add a method when the button clicked.
            ButtonRent.Clicked += ButtonRent_Clicked;
            ButtonReturn.Clicked += ButtonReturn_Clicked;

            //connect to device
           // republicDevice = new ForeignersDevice("ForeignersDevice");
           // ReceiveC2dAsync();

           // republicDevice.SendDevicetoCloudMessageAsync("Android Connected");
        }


        private async void ButtonRent_Clicked(object sender, EventArgs e)
        {
            scanPage = new ZXingScannerPage();
            scanPage.OnScanResult += (result) =>
            {
                scanPage.IsScanning = false;
                scanPage.DefaultOverlayTopText = "Return your item by scanning the QR code on the lock!";

                //Do something with result
                Device.BeginInvokeOnMainThread(() =>
                {
                   /* 
                    string targetDevice = "{\"device\":\"webapp\",\"command\":\"1\",\"mn\":\"writeLine\",\"targetDevice\":\"" + result.Text + "\"}";
                    republicDevice.SendDevicetoCloudMessageAsync(targetDevice);
                    */
                    //republicDevice.SendDevicetoCloudMessageAsync($"{{'device':'webapp','command':'1','mn':'writeLine', 'targetDevice':'{result.Text}'}}");
                    Navigation.PopModalAsync();
                    DisplayAlert("Item status", result.Text, "OK");
                });
            };

            await Navigation.PushModalAsync(scanPage);
        }
        private async void ButtonReturn_Clicked(object sender, EventArgs e)
        {
            scanPage = new ZXingScannerPage();
            scanPage.OnScanResult += (result) =>
            {
                scanPage.IsScanning = false;
                scanPage.DefaultOverlayTopText = "Check the price by scanning the QR code!";

                //Do something with result
                Device.BeginInvokeOnMainThread(() =>
                {
                   /* string targetDevice = "{\"device\":\"webapp\",\"command\":\"0\",\"mn\":\"writeLine\",\"targetDevice\":\"" + result.Text + "\"}";
                    republicDevice.SendDevicetoCloudMessageAsync(targetDevice);
                    */
                    // republicDevice.SendDevicetoCloudMessageAsync($"{{'device':'webapp','command':'0','mn':'writeLine', 'targetDevice':'{result.Text}'}}");
                    Navigation.PopModalAsync();
                    DisplayAlert("Item Detail", result.Text, "OK");
                });
            };

            await Navigation.PushModalAsync(scanPage);
        }

        private class TelemetryData
        {
            public int messageId { get; set; }
            public string deviceId { get; set; }
            public int state { get; set; }
        }

        //public async void ReceiveC2dAsync()
        //{
        //    var deviceClient = DeviceClient.CreateFromConnectionString("HostName=ForeignersCloud.azure-devices.net;DeviceId=ForeignersDevice;SharedAccessKey=2bioLY1acuVjqGvYK9Qo4IpkPpWDUXaKMvjaKCbw408=", TransportType.Http1);
        //    Debug.WriteLine("\nReceiving cloud to device messages from service");
        //    while (true)
        //    {
        //        Message receivedMessage = await deviceClient.ReceiveAsync();
        //        if (receivedMessage == null) continue;
        //        byte[] data = receivedMessage.GetBytes();
        //        Debug.WriteLine("Received message: {0}", Encoding.UTF8.GetString(data, 0, data.Length));



        //        await deviceClient.CompleteAsync(receivedMessage);
        //    }


        //}
        //private static async Task<string> ReceiveC2dAsync(DeviceClient deviceClient)
        //{
        //    await Task.Delay(1000);
        //    Message receivedMessage = await deviceClient.ReceiveAsync(TimeSpan.FromSeconds(1));
        //    byte[] data = receivedMessage.GetBytes();
        //    string a = String.Format("Received message: {0}", Encoding.UTF8.GetString(data, 0, data.Length));
        //    await deviceClient.CompleteAsync(receivedMessage);
        //    return a;
        //}

    }
}