using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace HIVE.CS
{
	public class TopUpPageCS : ContentPage
	{
		public TopUpPageCS ()
		{
			Content = new StackLayout {
				Children = {
					new Label { Text = "Top Up Here!" }
				}
			};
		}
	}
}