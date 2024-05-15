using store.Models;
using store.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.Services
{
    public class Calculations
    {
        public static int CountDailySales(List<Order> orders)
        {
            try
            {
                DateTime today = DateTime.Today;
                int dailySales = orders.Count(order => order.OrderDate.Date == today.Date);
                Console.WriteLine($"Daily sales: {dailySales}");
                return dailySales;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CountDailySales: {ex.Message}");
                return 0; // or handle the error appropriately
            }
        }

        public static int CountWeeklySales(List<Order> orders)
        {
            try
            {
                DateTime today = DateTime.Today;
                int dayOfWeek = (int)today.DayOfWeek;
                DateTime startOfWeek = today.AddDays(-dayOfWeek); // Start of the current week (Sunday)
                DateTime endOfWeek = startOfWeek.AddDays(6); // End of the current week (Saturday)

                // Count orders within the current week
                int weeklySales = orders.Count(order => order.OrderDate.Date >= startOfWeek.Date && order.OrderDate.Date <= endOfWeek.Date);
                Console.WriteLine($"Weekly sales: {weeklySales}");
                return weeklySales;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CountWeeklySales: {ex.Message}");
                return 0; // or handle the error appropriately
            }
        }

        public static int CountMonthlySales(List<Order> orders)
        {
            try
            {
                DateTime today = DateTime.Today;
                DateTime startOfMonth = new DateTime(today.Year, today.Month, 1); // Start of the current month
                DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1); // End of the current month

                // Count orders within the current month
                int monthlySales = orders.Count(order => order.OrderDate.Date >= startOfMonth.Date && order.OrderDate.Date <= endOfMonth.Date);
                Console.WriteLine($"Monthly sales: {monthlySales}");
                return monthlySales;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CountMonthlySales: {ex.Message}");
                return 0; // or handle the error appropriately
            }
        }

        public static int CountYearlySales(List<Order> orders)
        {
            try
            {
                DateTime today = DateTime.Today;
                DateTime startOfYear = new DateTime(today.Year, 1, 1); // Start of the current year
                DateTime endOfYear = new DateTime(today.Year, 12, 31); // End of the current year

                // Count orders within the current year
                int yearlySales = orders.Count(order => order.OrderDate.Date >= startOfYear.Date && order.OrderDate.Date <= endOfYear.Date);
                Console.WriteLine($"Yearly sales: {yearlySales}");
                return yearlySales;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CountYearlySales: {ex.Message}");
                return 0; // or handle the error appropriately
            }
        }

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

        public static bool IsOrderItemStockValid(int stock, int orderedQuantity)
        {
            int result = stock - orderedQuantity;
            return result >= 0;
        }
        public static int CountTotalQuantity(string itemName, List<OrderItem> items)
        {
            int total = 0;
            foreach(OrderItem item in items)
            {
                
                if (item.Item.Equals(itemName))
                {
                    total += item.Quantity;
                }
            }
            return total;
        }
        public static double ComputeDailyIncome(List<Order> orders)
        {
            double totalDailySale = 0;
            foreach(Order order in orders)
            {
                if(order.OrderDate.Date == DateTime.Today)
                {
                    totalDailySale += order.TotalPrice;
                }
            }
            return totalDailySale;
        }

        public static double ComputeWeeklySales(List<Order> orders)
        {
            double total = 0;
            DateTime startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
            DateTime endOfWeek = startOfWeek.AddDays(7);

            foreach (Order order in orders)
            {
                if(order.OrderDate >= startOfWeek && order.OrderDate < endOfWeek)
                {
                    total += order.TotalPrice;
                }
            }

            return total;
        }
        
        public static double ComputeMonthlySales(List<Order> orders)
        {
            double total = 0;
            DateTime startOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime endOfMonth = startOfMonth.AddMonths(1);

            foreach (Order order in orders)
            {
                if (order.OrderDate >= startOfMonth && order.OrderDate < endOfMonth)
                {
                    total += order.TotalPrice;
                }
            }

            return total;

        }
        public static double ComputeYearlySales(List<Order> orders)
        {
            double total = 0;
            DateTime startOfYear = new DateTime(DateTime.Today.Year, 1, 1);
            DateTime endOfYear = startOfYear.AddYears(1);

            foreach (Order order in orders)
            {
                if (order.OrderDate >= startOfYear && order.OrderDate < endOfYear)
                {
                    total += order.TotalPrice;
                }
            }

            return total;

        }

    }
}
