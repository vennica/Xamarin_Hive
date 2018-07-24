using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIVE.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HIVE.XAML
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage, INotifyPropertyChanged
    {
		public Login ()
		{
            /*
            var vm = new LoginViewModel();
            this.BindingContext = vm;
            vm.DisplayInvalidLoginPrompt += () => DisplayAlert("Error", "Invalid Login, try again", "OK");
            */
            InitializeComponent();
            BindingContext = this;
            /*
            Email.Completed += (object sender, EventArgs e) =>
            {
                Password.Focus();
            };

            Password.Completed += (object sender, EventArgs e) =>
            {
                vm.SubmitCommand.Execute(null);
            };
            */
        }
        
        async void OnRegisterButtonClicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new RegisterPage());
        }
        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var user = new User
            {
                Email = Email.Text,
                Password = Password.Text
            };

            var isValid = AreCredentialsCorrect(user);
            if (isValid)
            {
                
                await Navigation.PushModalAsync(new MainPage());
                //Navigation.InsertPageBefore(new MainPage(), this);
                //await Navigation.PopAsync();
            }
            else
            {
               await DisplayAlert("Error", "Invalid Login, try again", "OK");
                Password.Text = string.Empty;
            }
        }
        bool AreCredentialsCorrect(User user)
        {
            return user.Email == Constant.Email && user.Password == Constant.Password;
        }
        
    }
}