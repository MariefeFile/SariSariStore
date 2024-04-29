using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.Models
{
    internal class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string TotalPayment { get; set; }

        // Constructor
        public Customer(int customerId, string name, string phone, string email)
        {
            CustomerId = customerId;
            CustomerName = name;
            CustomerPhone = phone;
            CustomerEmail = email;
        }

        public Customer(string name, string phone, string email)
        {
            CustomerName = name;
            CustomerPhone = phone;
            CustomerEmail = email;
        }
    }
}
