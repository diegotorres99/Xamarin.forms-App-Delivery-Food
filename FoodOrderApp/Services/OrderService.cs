using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using FoodOrderApp.Model;
using FoodOrderApp.Views;
using JudoDotNetXamarin;
using JudoPayDotNet.Enums;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FoodOrderApp.Services
{
    public class OrderService
    {
        FirebaseClient client;

        public string OrderId { get; set; }

        public decimal TotalCost { get; set; }

        public List<CartItem> Data { get; set; }

        public OrderService()
        {
            client = new FirebaseClient("https://foodorderingapp-f8cdb.firebaseio.com/");

            OrderId = Guid.NewGuid().ToString();
            var cn = DependencyService.Get<ISQLite>().GetConnection();
            Data = cn.Table<CartItem>().ToList();
            TotalCost = Data.Sum(d => d.Quantity * d.Price);
        }

        public async Task ProcessPayment()
        {
            var judo = new Judo()
            {
                JudoId = "100401-330",
                Token = "dFANe1isNADPftvM",
                Secret = "83302bcbc9c1941b5d0591acd46a4e4e2eb6dba272f63d3884c27d5d363cfbd8",
                Environment = JudoEnvironment.Sandbox,
                Amount = TotalCost,
                Currency = "USD",
                ConsumerReference = OrderId
            };

            var theme = new Theme
            {
                PageTitle = "Enter Card Details",
                ButtonLabel = "Pay Now",
                ButtonTextColor = Color.White,
                ButtonBackgroundColor = Color.Purple,
                ShowSecurityMessage = true
            };

            judo.Theme = theme;

            var paymentPage = new PaymentPage(judo);
            await Application.Current.MainPage.Navigation.PushModalAsync(paymentPage);
            paymentPage.ResultHandler += async (object sender, JudoPayDotNet.Models.IResult<JudoPayDotNet.Models.ITransactionResult> e) =>
            {
                if ("Success".Equals(e.Response.Result))
                {
                    var receiptId = e.Response.ReceiptId.ToString();
                    await ProcessOrderAsync(receiptId);
                    RemoveItemsFromCart();
                    await Application.Current.MainPage.Navigation.PushModalAsync(
                        new OrdersView(OrderId));
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Error While Processing the Payment", "OK");
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                }
            };
        }

        public async Task ProcessOrderAsync(string recieptId)
        {
            var uname = Preferences.Get("Username", "Guest");

            foreach (var item in Data)
            {
                OrderDetails od = new OrderDetails()
                {
                    OrderId = OrderId,
                    OrderDetailId = Guid.NewGuid().ToString(),
                    ProductID = item.ProductId,
                    ProductName = item.ProductName,
                    Price = item.Price,
                    Quantity = item.Quantity
                };
                await client.Child("OrderDetails").PostAsync(od);
            }

            await client.Child("Orders").PostAsync(
                new Order()
                {
                    OrderId = OrderId,
                    Username = uname,
                    TotalCost = TotalCost,
                    ReceiptId = recieptId
                });
        }

        private void RemoveItemsFromCart()
        {
            var cis = new CartItemService();
            cis.RemoveItemsFromCart();
        }

        public async Task PlaceOrderAsync()
        {
            await ProcessPayment();
        }
    }
}
