using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIVE.CS;
using HIVE.XAML;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace HIVE
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WalletPage : ContentPage
	{
        public int messageSequence = 0;
        private static ForeignersDevice republicDevice;
        ZXingScannerPage scanPage;
        public WalletPage ()
		{
            var menuItems = new List<MenuItems>();

            InitializeComponent();
            ListView listView = new ListView();

            listView.ItemsSource = menuItems;
            menuItems.Add(new MenuItems()
            {
                Title = "History",

                TargetType = typeof(HistoryPageCS)
            });
            /*
            menuItems.Add(new MenuItems()
            {
                Title = "Top Up",

                TargetType = typeof(TopUpPageCS)
            });
            menuItems.Add(new MenuItems()
            {
                Title = "Withdraw",

                TargetType = typeof(WithdrawPageCS)
            });
            */
        }
        async void OnBackToHomeButtonClicked(object sender, EventArgs e)
        {
            //Navigation.InsertPageBefore(new MainPage(), this);
            await Navigation.PushModalAsync(new MainPage());
        }

        async void OnScanCliked(object sender, EventArgs e)
        {
            scanPage = new ZXingScannerPage();
            scanPage.OnScanResult += (result) =>
            {
                scanPage.IsScanning = false;
                scanPage.DefaultOverlayTopText = "Return your item by scanning the QR code on the lock!";

                //Do something with result
                Device.BeginInvokeOnMainThread(() =>
                {
                    string targetDevice = "{\"device\":\"webapp\",\"command\":\"1\",\"mn\":\"writeLine\",\"targetDevice\":\"" + result.Text + "\"}";
                    republicDevice.SendDevicetoCloudMessageAsync(targetDevice);
                    //republicDevice.SendDevicetoCloudMessageAsync($"{{'device':'webapp','command':'1','mn':'writeLine', 'targetDevice':'{result.Text}'}}");
                    Navigation.PopModalAsync();
                    DisplayAlert("Item status", result.Text, "OK");
                });
            };

            await Navigation.PushModalAsync(scanPage);
        }
        async void OnTopUpCliked(object sender, EventArgs e)
        {
            //Navigation.InsertPageBefore(new MainPage(), this);
            await Navigation.PushAsync(new TopUpPage("https://www.dbs.com/sandbox/api/sg/v1/oauth/authorize?client_id=7c605289-387b-4550-b6bc-62a606e754f6&redirect_uri=http%3A%2F%2Fonekeyhive.com%2Fredirected&scope=Read&response_type=code&state=0399"));
        }
        async void OnCardCliked(object sender, EventArgs e)
        {
            //Navigation.InsertPageBefore(new MainPage(), this);
            await Navigation.PushAsync(new CardPage());
        }

        async void OncategorySelected(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as MenuItems;
            if (item != null)
            {

                ((ListView)sender).SelectedItem = null;

                if (item.Title == "History Transaction")
                {
                    await Navigation.PushAsync(new HistoryPage());
                }
                
            }
            /*
                else if (item.Title.Equals("Top Up"))
                {
                    await Navigation.PushAsync(new TopUpPage());

                }

            }
            */
            else
            {
                await DisplayAlert("Error", "item not found!", "ok");
            }
        }
    }
}