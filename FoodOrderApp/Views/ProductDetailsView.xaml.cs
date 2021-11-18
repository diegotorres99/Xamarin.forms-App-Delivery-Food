using System;
using System.Collections.Generic;
using FoodOrderApp.Model;
using FoodOrderApp.ViewModels;
using Xamarin.Forms;

namespace FoodOrderApp.Views
{
    public partial class ProductDetailsView : ContentPage
    {
        ProductDetailsViewModel pvm;
        public ProductDetailsView(FoodItem foodItem)
        {
            InitializeComponent();
            pvm = new ProductDetailsViewModel(foodItem);
            this.BindingContext = pvm;
        }

        async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
