using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HIVE.XAML
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }
        async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            var user = new User()
            {
                Email = Email.Text,
                Password = Password.Text

            };
            var signUpSucceeded = AreDetailsValid(user);
            if (signUpSucceeded)
            {
                var rootPage = Navigation.NavigationStack.FirstOrDefault();
                if (rootPage != null)
                {
                    await DisplayAlert("Register", "Register successfully!", "OK");
                    App.IsUserLoggedIn = true;
                    await Navigation.PushModalAsync(new Login());

                    //Navigation.InsertPageBefore(new MainPage(), Navigation.NavigationStack.First());
                    //await Navigation.PopToRootAsync();
                }
            }
            else
            {
                // await DisplayAlert("Error", "Invalid Login, try again", "OK");
            }
        }
        bool AreDetailsValid(User user)
        {
            return (!string.IsNullOrWhiteSpace(user.Email) && !string.IsNullOrWhiteSpace(user.Password) && user.Email.Contains("@"));
        }

    }
}