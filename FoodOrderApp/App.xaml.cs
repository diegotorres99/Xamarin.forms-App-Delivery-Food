using System;
using FoodOrderApp.Repositories;
using FoodOrderApp.Services;
using FoodOrderApp.Views;
using Plugin.SharedTransitions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderApp
{
    public partial class App : Application
    {
        public App()
        {
            Device.SetFlags(new string[] {
                "AppTheme_Experimental",
                "MediaElement_Experimental"
                });

            InitializeComponent();



            //MainPage = new MainPage();
            //MainPage = new NavigationPage(new LoginView());
            //MainPage = new NavigationPage(new SettingsPage());


            string uname = Preferences.Get("Username", String.Empty);
            if (String.IsNullOrEmpty(uname))
            {
                MainPage = new LoginView();
            }
            else
            {
                MainPage = new ProductsView();
            }
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {

        }
    }
}
