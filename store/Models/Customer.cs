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

        // Constructor
        public Customer(int customerId, string name, string phone, string email)
        {
            CustomerId = customerId;
            CustomerName = name;
            CustomerPhone = phone;
            CustomerEmail = email;
        }

        public int GetCustomerId()
        {
            return CustomerId;
        }

        public void SetCustomerId(int customerId)
        {
            CustomerId = customerId;
        }

        public string GetName()
        {
            return CustomerName;
        }

        public void SetName(string name)
        {
            CustomerName = name;
        }

        public string GetPhone()
        {
            return CustomerPhone;
        }

        public void SetPhone(string phone)
        {
            CustomerPhone = phone;
        }

        public string GetEmail()
        {
            return CustomerEmail;
        }

        public void SetEmail(string email)
        {
            CustomerEmail = email;
        }
    }
}
