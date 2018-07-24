using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace HIVE.CS
{
	public class CameraPageCS : ContentPage
	{
		public CameraPageCS ()
		{
            Title = "Camera Page";

            Content = new StackLayout {
				Children = {
					new Label { Text = "Camera goes here!" }
				}
			};
		}
	}
}