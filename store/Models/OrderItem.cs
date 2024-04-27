using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.Models
{
    internal class OrderItem
    {
        public int ProductID { get; set; }
        public string Item {  get; set; }
        public string Categories { get; set; }
        public string Unit {  get; set; }
        public int Quantity { get; set; }
        public double SellingPrice { get; set; }
        public double TotalPrice {  get; set; }

        public OrderItem(int productID, string item, string categories, string unit, int quantity, double sellingPrice, double totalPrice)
        {
            ProductID = productID;
            Item = item;
            Categories = categories;
            Unit = unit;
            Quantity = quantity;
            SellingPrice = sellingPrice;
            TotalPrice = totalPrice;
        }
    }
}
