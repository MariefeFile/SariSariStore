using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.Models
{
    internal class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerID { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        public Order(int orderID, DateTime orderDate, int customerID, List<OrderItem> orderItems)
        {
            OrderID = orderID;
            OrderDate = orderDate;
            CustomerID = customerID;
            OrderItems = orderItems;
        }

        public int GetOrderID()
        {
            return OrderID;
        }

        public void SetOrderID(int orderID)
        {
            OrderID = orderID;
        }

        public DateTime GetOrderDate()
        {
            return OrderDate;
        }

        public void SetOrderDate(DateTime orderDate)
        {
            OrderDate = orderDate;
        }

        public int GetCustomerID()
        {
            return CustomerID;
        }

        public void SetCustomerID(int customerID)
        {
            CustomerID = customerID;
        }

        public List<OrderItem> GetOrderItems()
        {
            return OrderItems;
        }

        public void SetOrderItems(List<OrderItem> orderItems)
        {
            OrderItems = orderItems;
        }
    }
}
