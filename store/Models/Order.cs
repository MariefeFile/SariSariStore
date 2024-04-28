﻿using System;
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
        public double TotalPrice { get; set; }
        public Order()
        {
            OrderID = 0;
            OrderDate = DateTime.Today;
            CustomerName = "";
            CustomerID = 0;
            OrderItems = new List<OrderItem>();
            TotalPrice = 0.0;
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
