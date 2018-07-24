using Xamarin.Forms;
using System;

namespace HIVE
{
	public class ContactsPageCS : ContentPage
	{
		public ContactsPageCS ()
		{
            Title = "Hive Home";

            Content = new StackLayout { 
				Children = {
					new Label {
						Text = "Contacts data goes here",
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.CenterAndExpand
					}
				}
			};
		}
        async void OnBackToHomeButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}
