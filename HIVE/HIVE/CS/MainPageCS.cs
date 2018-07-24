using System;
using Xamarin.Forms;
using HIVE.CS;
using System.Diagnostics;

namespace HIVE
{
    public class MainPageCS : MasterDetailPage
    {
        MasterPageCS masterPage;
        
        public MainPageCS()
        {
            Title = "HIVE";
            Icon = "hive_menu_backward.gif";
            try
            {
                masterPage = new MasterPageCS();
                Master = masterPage;
                Detail = new NavigationPage(new ContactsPageCS());

                masterPage.ListView.ItemSelected += OnItemSelected;


                if (Device.RuntimePlatform == Device.UWP)
                {
                    MasterBehavior = MasterBehavior.Popover;
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
            
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
               
                masterPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
             

        }
        
    }
}
