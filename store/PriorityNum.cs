using store.Models;
using store.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace store
{
    public partial class PriorityNum : Form
    {
        private void inititalizePrioritySlip(Order order)
        {
            PriorityNumberRepository pnRepo = new PriorityNumberRepository();

            priorityNumber.Text = pnRepo.GetLatestPriorityNumber().ToString();
            customerName.Text = order.CustomerName;
            totalPayment.Text = order.TotalPrice.ToString();
            dateOfOrder.Text = order.OrderDate.ToString();

            pnRepo.AddLatestPriorityNumber();
        }

        public PriorityNum(Order order)
        {
            InitializeComponent();

            order.OrderDate = DateTime.Now;


            inititalizePrioritySlip(order);
        }

        private void Exit4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
