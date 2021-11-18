using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FoodOrderApp.Views
{
    public partial class OrdersView : ContentPage
    {
        public OrdersView(string id)
        {
            InitializeComponent();
            LabelName.Text = "Welcome " + Preferences.Get("Username", "Guest") + ",";
            LabelOrderID.Text = id;
        }

        async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new ProductsView());
        }
    }
}
