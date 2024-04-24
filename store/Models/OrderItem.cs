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
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public OrderItem(int productID, int quantity, decimal unitPrice)
        {
            ProductID = productID;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
    }
}
