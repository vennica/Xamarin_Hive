using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace HIVE.CS
{
	public class ClothesCS : ContentPage
	{
		public ClothesCS ()
		{
            Title = "Clothes Page";

            Content = new StackLayout {
				Children = {
					new Label { Text = "Welcome to Xamarin.Forms!" }
				}
			};
		}
	}
}