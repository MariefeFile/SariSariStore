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
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }

        public Product(int productID, string productName, decimal unitPrice, int unitsInStock)
        {
            ProductID = productID;
            ProductName = productName;
            UnitPrice = unitPrice;
            UnitsInStock = unitsInStock;
        }

        public int GetProductID()
        {
            return ProductID;
        }

        public void SetProductID(int productID)
        {
            ProductID = productID;
        }

        public string GetProductName()
        {
            return ProductName;
        }

        public void SetProductName(string productName)
        {
            ProductName = productName;
        }

        public decimal GetUnitPrice()
        {
            return UnitPrice;
        }

        public void SetUnitPrice(decimal unitPrice)
        {
            UnitPrice = unitPrice;
        }

        public int GetUnitsInStock()
        {
            return UnitsInStock;
        }

        public void SetUnitsInStock(int unitsInStock)
        {
            UnitsInStock = unitsInStock;
        }
    }
}
