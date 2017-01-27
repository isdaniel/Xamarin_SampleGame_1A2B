using GameModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace _1A2BGame
{
    public partial class RecordList : ContentPage
    {
        public RecordList(List<Record> Recordlist)
        {
            //Prism.Mvvm.ViewModelLocator.GetAutowireViewModel();
            InitializeComponent();
            RecordViewModel mv = new RecordViewModel(Recordlist);
            RList.ItemsSource = mv.RecordList;
            RList.SelectedItem = mv.RecordListSelected;
            #region

            //RList.ItemsSource = Recordlist;
            //RList.ItemTemplate = new DataTemplate(() =>
            //{
            //    // Create views with bindings for displaying each property.
            //    Label UserNumber = new Label() {
            //        FontSize =24,
            //    };
            //    UserNumber.SetBinding(Label.TextProperty, "UserNumber");

            //    Label AB = new Label() {
            //         FontSize = 24,
            //    };
            //    AB.SetBinding(Label.TextProperty, "AB");
            //    Label Point = new Label() { Text="-----------------------------------------", FontSize = 24};
            //    BoxView boxView = new BoxView();
            //    boxView.SetBinding(BoxView.ColorProperty, "FavoriteColor");
            //    // Return an assembled ViewCell.
            //    return new ViewCell
            //    {
            //        View = new StackLayout
            //        {
            //            Padding = new Thickness(0, 5),
            //            Orientation = StackOrientation.Vertical,
            //            Children =
            //                    {
            //                        boxView,
            //                        new StackLayout
            //                        {
            //                            HorizontalOptions=LayoutOptions.Center,
            //                            VerticalOptions = LayoutOptions.Center,
            //                            Spacing = 0,
            //                            Children =
            //                            {
            //                                UserNumber,
            //                                AB,
            //                                Point
            //                            }
            //                            }
            //                    }
            //        }
            //    };
            //});
            #endregion
        }
    }
}
