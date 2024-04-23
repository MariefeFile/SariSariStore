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
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        // Constructor
        public Customer(int customerId, string name, string phone, string email)
        {
            CustomerId = customerId;
            Name = name;
            Phone = phone;
            Email = email;
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
            return Name;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public string GetPhone()
        {
            return Phone;
        }

        public void SetPhone(string phone)
        {
            Phone = phone;
        }

        public string GetEmail()
        {
            return Email;
        }

        public void SetEmail(string email)
        {
            Email = email;
        }
    }
}
