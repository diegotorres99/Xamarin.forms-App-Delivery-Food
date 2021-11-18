using System;
namespace FoodOrderApp.ViewModels
{
    public class OrdersViewModel : BaseViewModel
    {
        private string _OrderID;
        public string OrderID
        {
            set
            {
                _OrderID = value;
                OnPropertyChanged();
            }

            get
            {
                return _OrderID;
            }
        }

        public OrdersViewModel(string id)
        {
            OrderID = id;
        }
    }
}
