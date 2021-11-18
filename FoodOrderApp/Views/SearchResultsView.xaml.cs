using System;
using System.Collections.Generic;
using System.Linq;
using FoodOrderApp.Model;
using FoodOrderApp.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FoodOrderApp.Views
{
    public partial class SearchResultsView : ContentPage
    {
        SearchResultsViewModel srvm;
        public SearchResultsView(string searchText)
        {
            InitializeComponent();
            srvm = new SearchResultsViewModel(searchText);
            this.BindingContext = srvm;
            LabelName.Text = $"Welcome {Preferences.Get("Username", "Guest")}";
        }

        async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        async void CollectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            var selectedProduct = e.CurrentSelection.FirstOrDefault() as FoodItem;
            if (selectedProduct == null)
                return;
            await Navigation.PushModalAsync(new ProductDetailsView(selectedProduct));
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}
