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
	public partial class CategoryPage : ContentPage
	{
        //List<CarouselData> MyDataSource;
        ZXingScannerPage scanPage;
        public CategoryPage ()
		{

			InitializeComponent ();
            /*
            ButtonScanDefault.Clicked += ButtonScanDefault_Clicked;


            MyDataSource = new List<CarouselData>() { new CarouselData() { Name = "Title1" },
                                                      new CarouselData() { Name = "Title2" },
                                                      new CarouselData() { Name = "Title3" },
                                                      new CarouselData() { Name = "Title4" }};

            BindingContext = this;
            */
           

        }
        //Must have default value or be set before the BindingContext is set.

        private int _position;
        public int Position { get { return _position; } set { _position = 0; OnPropertyChanged(); } }
        async void OncategorySelected(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as CategoryItemCS;
            if (item != null)
            {
               
                ((ListView)sender).SelectedItem = null;
               
                if (item.Title == "Clothes")
                {
                    await Navigation.PushAsync(new ClothesPage());
                    
                    
                }

                else if (item.Title.Equals("Camera"))
                {
                    await Navigation.PushAsync(new CameraPage());

                }

                else 
                {
                    await Navigation.PushAsync(new AccessoryPage());

                }

            }
            else
            {
                await DisplayAlert("Error", "item not found!", "ok");
            }


        }
        private async void ButtonScanDefault_Clicked(object sender, EventArgs e)
        {
            scanPage = new ZXingScannerPage();
            scanPage.OnScanResult += (result) => {
                scanPage.IsScanning = false;

                //Do something with result
                Device.BeginInvokeOnMainThread(() => {
                    Navigation.PopModalAsync();
                    DisplayAlert("Scanned Barcode", result.Text, "OK");
                });
            };

            await Navigation.PushModalAsync(scanPage);
        }
    }
}