using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Security.Cryptography;
using HIVE.Model;


namespace HIVE.ViewModels
{
    /*
    class LoginViewModel
    {
    }
    */
    public class LoginViewModel: INotifyPropertyChanged
    {
        public static LoginViewModel Current = new LoginViewModel ();
        /*
        private readonly ApiServices _apiServices = new ApiServices();

        public string Email { get; set; }
        public string Password { get; set; }
        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var accesstoken = await _apiServices.LoginAsync(Email, Password);

                    Settings.AccessToken = accesstoken;
                });
            }
        }

        public LoginViewModel()
        {
            Email = Settings.Email;
            Password = Settings.Password;
        }

        */

        //INavigation navigation;
        public Action DisplayInvalidLoginPrompt;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public ICommand SubmitCommand { protected set; get; }
        public LoginViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }
        public void OnSubmit()
        {
            /*
            if (email != "vennica0521@gmail.com" || password != "password")
            {
                DisplayInvalidLoginPrompt();
            }
            else
            {
                navigation.PushAsync(new MainPage());

            }
            */
            
        }

        
    }

}

