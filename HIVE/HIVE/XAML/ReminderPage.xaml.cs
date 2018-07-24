using Xamarin.Forms;
using System;

namespace HIVE
{
	public partial class ReminderPage : ContentPage
	{
		public ReminderPage ()
		{
			InitializeComponent ();
		}
        async void OnBackToHomeButtonClicked(object sender, EventArgs e)
        {
            //Navigation.InsertPageBefore(new MainPage(), this);
            await Navigation.PushModalAsync(new MainPage());


        }
    }
}

