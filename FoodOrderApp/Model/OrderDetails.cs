using System;
namespace FoodOrderApp.Model
{
    public class OrderDetails
    {
        public string OrderDetailId { get; set; }
        public string OrderId { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
