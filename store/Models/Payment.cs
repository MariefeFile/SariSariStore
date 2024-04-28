using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.Models
{
    public class Payment
    {
        public Order order { get; set; }
        public List<OrderItem> items { get; set; }
        public double TotalChange { get; set; }
        public double TotalCash { get; set; }
        public string EmployeeName { get; set; }
        public Payment()
        {

        }
    }
}
