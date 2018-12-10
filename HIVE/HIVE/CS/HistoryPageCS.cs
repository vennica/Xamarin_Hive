using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace HIVE.CS
{
	public class HistoryPageCS : ContentPage
	{
		public HistoryPageCS ()
		{
			Content = new StackLayout {
				Children = {
					new Label { Text = "Transaction History!" }
				}
			};
		}
	}
}