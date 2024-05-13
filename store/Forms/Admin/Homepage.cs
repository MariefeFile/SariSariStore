using store.Models;
using store.Repositories;
using store.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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
            List<Sales> salesData = FetchSalesData();

            // Populate DataGridView with daily sales
            DisplayDailySales(salesData);

            // Populate DataGridView with monthly sales
            DisplayMonthlySales(salesData);

            // Populate DataGridView with yearly sales
            DisplayYearlySales(salesData);

        }
        private List<Sales> FetchSalesData()
        {
            // Your code to fetch sales data from the database or any other source
            // Example:
            List<Sales> salesData = new List<Sales>();
            // Populate salesData with actual sales data
            return salesData;
        }

        private void DisplayDailySales(List<Sales> salesData)
        {
            // Your code to filter sales data for daily sales
            // Example:
            List<Sales> dailySales = FilterSalesForToday(salesData);
            dataGridView1.DataSource = dailySales;
        }

        private void DisplayMonthlySales(List<Sales> salesData)
        {
            // Your code to filter sales data for monthly sales
            // Example:
            List<Sales> monthlySales = FilterSalesForThisMonth(salesData);
            dataGridView1.DataSource = monthlySales;
        }

        private void DisplayYearlySales(List<Sales> salesData)
        {
            // Your code to filter sales data for yearly sales
            // Example:
            List<Sales> yearlySales = FilterSalesForThisYear(salesData);
            dataGridView1.DataSource = yearlySales;
        }

        // Methods to filter sales data based on date (replace with your actual filtering logic)
        private List<Sales> FilterSalesForToday(List<Sales> salesData)
        {
            // Example: Filter sales data for today
            return salesData;
        }

        private List<Sales> FilterSalesForThisMonth(List<Sales> salesData)
        {
            // Example: Filter sales data for this month
            return salesData;
        }

        private List<Sales> FilterSalesForThisYear(List<Sales> salesData)
        {
            // Example: Filter sales data for this year
            return salesData;
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
