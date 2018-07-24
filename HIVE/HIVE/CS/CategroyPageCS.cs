using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIVE;
using Xamarin.Forms;

namespace HIVE.CS
{
	public class CategroyPageCS : ContentPage
	{
        public ListView ListView { get { return listView; } }

        ListView listView;

        public CategroyPageCS ()
		{
            Title = "Hive Home";
            var categoryItemCS = new List<CategoryItemCS>();
            categoryItemCS.Add(new CategoryItemCS
            {
                Title = "Clothes",
                ImageSource = "clothes.jpg",
                TargetType = typeof(ClothesCS)
            });
            categoryItemCS.Add(new CategoryItemCS
            {
                Title = "Camera",
                ImageSource = "camera.jpg",
                TargetType = typeof(CameraPageCS)
            });
            categoryItemCS.Add(new CategoryItemCS
            {
                Title = "Accessory",
                ImageSource = "accessories.jpg",
                TargetType = typeof(AccessoryCS)
            });
            
            listView = new ListView
            {
                
                ItemsSource = categoryItemCS,
                ItemTemplate = new DataTemplate(() =>
                {
                    
                    var grid = new Grid { RowSpacing = 10};
                    
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(600) });
                    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(300) });
                    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(300) });
                    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(300) });




                    var image = new Image();
                    image.SetBinding(Image.SourceProperty, "ImageSource");
                    var label = new Label { TextColor = Color.White ,VerticalOptions = LayoutOptions.Center };
                    label.SetBinding(Label.TextProperty, "Title");

                  
                    grid.Children.Add(image);
                    grid.Children.Add(label);

                    return new ViewCell { View = grid };
                }),
                SeparatorVisibility = SeparatorVisibility.None
            };
            listView.RowHeight = 350;
            Content = new StackLayout
            {
                Children = { listView }
            };

            //categoryPage = new CategroyPageCS();

            //categoryPage.ListView.ItemTapped += OncategorySelected;
            /*
			Content = new StackLayout {
				Children = {
					new Label { Text = "Welcome to Xamarin.Forms!" }
				}
			};
            */
        }

    }
}