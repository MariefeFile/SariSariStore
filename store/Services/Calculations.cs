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
    }
}
