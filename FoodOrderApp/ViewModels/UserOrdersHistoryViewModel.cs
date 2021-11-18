using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FoodOrderApp.Model;
using FoodOrderApp.Services;
using Xamarin.Forms;

namespace FoodOrderApp.ViewModels
{
    public class UserOrdersHistoryViewModel : BaseViewModel
    {
        public ObservableCollection<UserOrdersHistory> OrderDetails { get; set; }

        private bool _IsBusy;
        public bool IsBusy
        {
            set
            {
                _IsBusy = value;
                OnPropertyChanged();
            }

            get
            {
                return _IsBusy;
            }
        }

        public UserOrdersHistoryViewModel()
        {
            OrderDetails = new ObservableCollection<UserOrdersHistory>();
            LoadUserOrders();
        }

        private async void LoadUserOrders()
        {
            try
            {
                IsBusy = true;
                OrderDetails.Clear();
                var service = new UserOrderHistoryService();
                var details = await service.GetOrderDetailsAsync();
                foreach (var order in details)
                {
                    OrderDetails.Add(order);
                }
            }
            catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
