using store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.Services
{
    internal class Calculations
    {
        public static double CalculateTotalPrice(List<OrderItem> orderItems)
        {
            double totalPrice = 0;
            foreach(OrderItem orderItem in orderItems)
            {
                totalPrice += orderItem.TotalPrice;
            }
            return totalPrice;
        }

        public static int CountTotalItems(List<OrderItem> orderItems)
        {
            int totalItem = 0;
            foreach(OrderItem item in orderItems)
            {
                totalItem += item.Quantity;
            }
            return totalItem;
        }

        public static int CountOverallItems(List<Order> orders)
        {
            int totalItem = 0;
            foreach(Order order in orders)
            {
                totalItem += order.TotalItems;
            }
            return totalItem;
        }

        public static double CountTotalSales(List<Order> orders)
        {
            double totalSales = 0.0;
            foreach(Order order in orders)
            {
                totalSales += order.TotalPrice;
            }
            return totalSales;
        }

        public static double CalculateItemTotalPrice(OrderItem item)
        {
            return item.SellingPrice * item.Quantity;
        }
        public static double CalculateItemTotalPrice(double sellingPrice, int quantity)
        {
            return sellingPrice * quantity;
        }
        public static int NewTotalQuantity(int origQuantity, int toAddQuantity)
        {
            return origQuantity + toAddQuantity;
        }
        public static double ComputeChange(double totalPrice, double cash)
        {
            return cash - totalPrice;
        }
        
        public static int ComputeDecStock(int oldStock, int soldStock)
        {
            return oldStock - soldStock;
        }
        public static int ComputeIncStock(int oldStock, int newStock)
        {
            return oldStock - newStock;
        }
    }
}
