using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using HIVE.XAML;

namespace HIVE.ViewModels
{
    /*
    class LoginViewModel
    {
    }
    */
    public class LoginViewModel : INotifyPropertyChanged
    {
        INavigation navigation;
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
            if (email != "vennica0521@gmail.com" || password != "password")
            {
                DisplayInvalidLoginPrompt();
            }
            else
            {
                navigation.PushAsync(new MainPage());
                
            }
        }
       
    }
}
