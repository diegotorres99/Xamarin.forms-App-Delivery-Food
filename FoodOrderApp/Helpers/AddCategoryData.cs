using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using FoodOrderApp.Model;
using Xamarin.Forms;

namespace FoodOrderApp.Helpers
{
    public class AddCategoryData
    {
        public List<Category> Categories { get; set; }

        FirebaseClient client;

        public AddCategoryData()
        {
            client = new FirebaseClient("https://foodorderingapp-f8cdb.firebaseio.com/");
            Categories = new List<Category>()
            {
                new Category(){
                    CategoryID = 1,
                    CategoryName = "Burger",
                    CategoryPoster = "MainBurger",
                    ImageUrl = "Burger.png"
                },
                new Category(){
                    CategoryID = 2,
                    CategoryName = "Pizza",
                    CategoryPoster = "MainPizza",
                    ImageUrl = "Pizza.png"
                },
                new Category(){
                    CategoryID = 3,
                    CategoryName = "Desserts",
                    CategoryPoster = "MainDessert.png",
                    ImageUrl = "Dessert.png"
                },
                new Category(){
                    CategoryID = 4,
                    CategoryName = "Veg Burger",
                    CategoryPoster = "MainBurger",
                    ImageUrl = "Burger.png"
                },
                new Category(){
                    CategoryID = 5,
                    CategoryName = "Veg Pizza",
                    CategoryPoster = "MainPizza.png",
                    ImageUrl = "Pizza.png"
                },
                new Category(){
                    CategoryID = 6,
                    CategoryName = "Cakes",
                    CategoryPoster = "MainDessert.png",
                    ImageUrl = "Dessert.png"
                }
            };
        }

        public async Task AddCategoriesAsync()
        {
            try
            {
                foreach (var category in Categories)
                {
                    await client.Child("Categories").PostAsync(new Category()
                    {
                        CategoryID = category.CategoryID,
                        CategoryName = category.CategoryName,
                        CategoryPoster = category.CategoryPoster,
                        ImageUrl = category.ImageUrl
                    });
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
