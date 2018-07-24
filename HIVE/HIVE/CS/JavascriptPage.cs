using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace HIVE.CS
{
	public class JavascriptPage : ContentPage
	{
		public JavascriptPage ()
		{
			Content = new StackLayout {
				Children = {
					new Label { Text = "JavaScript Pages",
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.CenterAndExpand}
				}
			};
		}
	}
}