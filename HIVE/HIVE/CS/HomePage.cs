using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace HIVE.CS
{
	public class HomePage : ContentPage
	{
		public HomePage ()
		{
			Content = new StackLayout {
				Children = {
					new Label { Text = "This is home page!",HorizontalOptions =LayoutOptions.Center, VerticalOptions = LayoutOptions.CenterAndExpand }
				}
			};
		}
	}
}