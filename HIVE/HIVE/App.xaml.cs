﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIVE.XAML;
using Xamarin.Forms;

namespace HIVE
{
	public partial class App : Application
	{
        public static bool IsUserLoggedIn { get; set; }
        public App ()
		{
            
			InitializeComponent();
            //MainPage = new NavigationPage(new Login());
            MainPage = new MainPage();

            /*
            if (!IsUserLoggedIn)
            {
                MainPage = new NavigationPage(new Login());
            }
            else
            {
                MainPage = new NavigationPage(new HIVE.MainPage());
            }
            */








        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
