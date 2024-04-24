using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.Models
{
    internal class FinancialMetrics
    {
        private decimal revenue;
        private decimal profits;

        public decimal Revenue
        {
            get { return revenue; }
            set { revenue = value; }
        }

        public decimal Profits
        {
            get { return profits; }
            set { profits = value; }
        }

        public FinancialMetrics(decimal revenue, decimal profits)
        {
            Revenue = revenue;
            Profits = profits;
        }
    }
}
