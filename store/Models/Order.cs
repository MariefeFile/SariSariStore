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
        public String CustomerName { get; set; }
        public int CustomerID { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public string CustomerName { get; set; }
        public Order()
        {

        }

        public Order(int orderID, DateTime orderDate, int customerID, List<OrderItem> orderItems, string customerName)
        {
            OrderID = orderID;
            OrderDate = orderDate;
            CustomerID = customerID;
            OrderItems = orderItems;
        }

        public Order(DateTime orderDate, int customerID, List<OrderItem> orderItems)
        {
            OrderDate = orderDate;
            CustomerID = customerID;
            OrderItems = orderItems;
        }
    }
}
