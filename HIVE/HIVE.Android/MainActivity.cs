using System;
using System.Diagnostics;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using HIVE.Droid;
using Acr.UserDialogs;

namespace HIVE.Droid
{
    [Activity(Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        MappingPermissionsHelper permissionHelper;

        Task<bool> getLocationPermissionsAsync;
        protected override void OnCreate(Bundle bundle)
        {
            
            TabLayoutResource = Resource.Layout.Tabbar;
                ToolbarResource = Resource.Layout.Toolbar;
                base.OnCreate(bundle);
                ZXing.Net.Mobile.Forms.Android.Platform.Init();
                global::Xamarin.Forms.Forms.Init(this, bundle);
                Xamarin.FormsMaps.Init(this, bundle);
            UserDialogs.Init(this);

            LoadApplication(new App());
            permissionHelper = new MappingPermissionsHelper(this);
            getLocationPermissionsAsync = permissionHelper.CheckAndRequestPermissions();

        }
        
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
global::ZXing.Net.Mobile.Forms.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            permissionHelper.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        
        
    }
}

