using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public String CustomerName { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public double TotalPrice { get; set; }
        public string Status { get; set; }
        public int PriorityNumber { get; set; }
        public Order()
        {
            OrderID = 0;
            OrderDate = DateTime.Today;
            CustomerName = "";
            OrderItems = new List<OrderItem>();
            TotalPrice = 0.0;
            PriorityNumber = 0;
        }

        public Order(int orderID, DateTime orderDate, List<OrderItem> orderItems, string customerName)
        {
            OrderID = orderID;
            OrderDate = orderDate;
            OrderItems = orderItems;
            CustomerName = customerName;
        }

        public Order(DateTime orderDate, int customerID, List<OrderItem> orderItems)
        {
            OrderDate = orderDate;
            OrderItems = orderItems;
        }
    }
}
