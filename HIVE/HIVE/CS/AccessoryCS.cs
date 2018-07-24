using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace HIVE.CS
{
	public class AccessoryCS : ContentPage
	{
		public AccessoryCS ()
		{
            Title = "Accessory Page";

            Content = new StackLayout {
				Children = {
					new Label { Text = "Accessory goes here!" }
				}
			};
		}
	}
}