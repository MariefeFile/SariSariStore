using store.Models;
using store.Repositories;
using store.Services;
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
    public partial class Homepage : Form
    {
        private List<Order> completedOrders = null;
        private OrderRepository orderRepository = new OrderRepository();
        private CustomerRepository customerRepository = new CustomerRepository();
        public Homepage()
        {
            InitializeComponent();

            completedOrders = orderRepository.GetOrdersCompleted();

            InitLabels();
        }

        private void InitLabels()
        {
            itemSold.Text = Calculations.CountOverallItems(completedOrders).ToString();
            totalSales.Text = Calculations.CountTotalSales(completedOrders).ToString();
            totalCustomers.Text = customerRepository.GetTotalCustomers().ToString();

        }
        private void Homepage_Load(object sender, EventArgs e)
        {
            panel8.Visible = false;
        }
       
        private void Exit3_Click(object sender, EventArgs e)
        {
            this.Close();
            Sign_in back2 = new Sign_in();
            back2.Show();
        }

        private void lbEmp_Click(object sender, EventArgs e)
        {
            EmployeeViews emp = new EmployeeViews();
            emp.Show();
            this.Close();
        }

        private void lbProd_Click(object sender, EventArgs e)
        {
            AllProd all = new AllProd();
            all.Show();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            CostumerName co = new CostumerName();
            co.Show();
            this.Hide();
        }

        private void lbdash_Click(object sender, EventArgs e)
        {
            panel8.Visible = true;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
