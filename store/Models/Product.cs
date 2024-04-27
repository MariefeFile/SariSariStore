using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.Models
{
    internal class Product
    {
        public int ProductID { get; set; }
        public string Item { get; set; }
        public string Unit { get; set; }
        public double OrigPrice { get; set; }
        public double SellingPrice { get; set; }
        public int Stock { get; set; }
        public string Categories { get; set; }
        public int ItemSold { get; set; }
        public double MarkUp { get; set; }

        public Product(int productID, string item, string unit, double origPrice, double sellingPrice, int stock, string categories, int itemSold, double markUp)
        {
            ProductID = productID;
            Item = item;
            Unit = unit;
            OrigPrice = origPrice;
            SellingPrice = sellingPrice;
            Stock = stock;
            Categories = categories;
            ItemSold = itemSold;
            MarkUp = markUp;
        }

    }
}