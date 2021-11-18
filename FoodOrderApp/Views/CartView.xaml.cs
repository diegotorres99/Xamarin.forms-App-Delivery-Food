using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FoodOrderApp.Views
{
    public partial class CartView : ContentPage
    {
        public CartView()
        {
            InitializeComponent();
            LabelName.Text = "Welcome " + Preferences.Get("Username", "Guest") + ",";
        }

        async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
