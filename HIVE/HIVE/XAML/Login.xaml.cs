using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http.Headers;
using System.Net;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Security.Cryptography;
using HIVE.Model;
using Acr.UserDialogs;

namespace HIVE.XAML
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage, INotifyPropertyChanged


    {
        public string username;
        public string email;
        public string password; 
		public Login ()
		{
            
            //var vm = new LoginViewModel();
            //this.BindingContext = vm;
            //vm.DisplayInvalidLoginPrompt += () => DisplayAlert("Error", "Invalid Login, try again", "OK");
            
            InitializeComponent();
            //BindingContext = this;


            Email.Completed += (object sender, EventArgs e) =>
            {
                Password.Focus();
            };
            Password.Completed += (object sender, EventArgs e) =>
            {
                email = Email.Text;
                password = Password.Text;
            };



        }
        
        async void OnRegisterButtonClicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new RegisterPage());
        }
        public async void OnLoginButtonClicked(object sender, EventArgs e)
        {

            CheckAppUser(Email.Text, Password.Text);

        }
        public async void CheckAppUser(String email, String password)
        {
            using (UserDialogs.Instance.Loading("Loading",null,null,true,MaskType.Black))
            {
                HttpClient client = new HttpClient();
                String JsonResponse = await client.GetStringAsync(HIVE.Constants.Web_Url_Server + "/" + email + "/" + password);

                if (JsonResponse.Equals("error"))
                {
                    await DisplayAlert("Error", "Invalid Login, try again", "OK");
                    Password.Text = string.Empty;
                }
                else
                {
                    await Navigation.PushModalAsync(new MainPage());
                }


                var objects = JObject.Parse(JsonResponse);
                email = objects.Value<String>("email");
                username = objects.Value<String>("username");


                GoogleUser googleUser = new GoogleUser
                {
                    Email = email,
                    Name = username,
                };

            }
            /*
            HttpClient client = new HttpClient();
            String JsonResponse = await client.GetStringAsync(HIVE.Constants.Web_Url_Server+ "/"+email+"/"+password);
            
            if (JsonResponse.Equals("error"))
                {
                    await DisplayAlert("Error", "Invalid Login, try again", "OK");
                    Password.Text = string.Empty;
                }
                else
                {
                    await Navigation.PushModalAsync(new MainPage());
                }

            
            var objects = JObject.Parse(JsonResponse);
            email = objects.Value<String>("email");
            username = objects.Value<String>("username");
            

            GoogleUser googleUser = new GoogleUser
            {
                Email = email,
                Name = username,
            };
            */



        }
        /*
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
            bool AreCredentialsCorrect(User user)
    {
        return user.Email == Constant.Email && user.Password == Constant.Password;
    }
        }
        */


    }
}