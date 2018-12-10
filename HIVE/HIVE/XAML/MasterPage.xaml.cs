using Xamarin.Forms;
using System;
using System.Net.Http;
using HIVE.XAML;
using System.Security.Cryptography;
using HIVE.Model;
using Newtonsoft.Json.Linq;


namespace HIVE
{
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listView; } }

        private GoogleUser _googleUser { get { return _googleUser; } }

        

        //public string username;
        //public string  email;
        public MasterPage()
        {
            InitializeComponent();
            //Text.Text = "Hi" + _googleUser.Name;
            //Email.Text = _googleUser.Email;

        }
        /*
        public async void GetAppUser(String email, String password)
        {

            HttpClient client = new HttpClient();
            String JsonResponse = await client.GetStringAsync(HIVE.Constants.Web_Url_Server + "/" + email + "/" + password);
            
        }
        */
    }
}
