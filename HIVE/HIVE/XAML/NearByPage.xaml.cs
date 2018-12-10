using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using HIVE;

namespace HIVE
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NearByPage : ContentPage
	{
		public NearByPage ()
		{
			InitializeComponent ();
            
            var map = new Map(
            MapSpan.FromCenterAndRadius(
                    new Position(1.3039937, 103.8297814), Distance.FromMiles(0.3)))
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(map);
            Content = stack;

            var position = new Position(1.304342, 103.831777);
            var pin = new CustomPin
            {
                Type = PinType.Place,
                Position = position,
                Label = "ION Orchard",
                Address = "2 Orchard Turn, Singapore 238801",
                Id = "Xamarin",
                Url = "http://xamarin.com/about/"

            };
            map.Pins.Add(pin);
            pin.Clicked += OnPinClicked;

            async void OnPinClicked(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new UnlockPage());

            }

        }
    }
}