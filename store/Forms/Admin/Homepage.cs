using store.Constants.Orders;
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
        private string currentTable = SelectedSales.DAILY;
        private Timer dashboardTimer;

        public Homepage()
        {
            InitializeComponent();

            //* Get all the orders/sales that is completed
            completedOrders = orderRepository.GetOrdersCompleted();

            InitLabels();

            panel11.Click += new EventHandler(panel11_Click);
            panel12.Click += new EventHandler(panel12_Click);
            panel10.Click += new EventHandler(panel10_Click);
            panel9.Click += new EventHandler(panel9_Click);

            // Initialize and start the dashboard timer
            dashboardTimer = new Timer();
            dashboardTimer.Interval = 30000; // 30 seconds interval
            dashboardTimer.Tick += DashboardTimer_Tick;
            dashboardTimer.Start();
        }

        private void UpdateDashboard()
        {
            try
            {
                // Calculate daily, weekly, monthly, and yearly sales
                int dailySales = (int)Calculations.ComputeDailyIncome(completedOrders);
                int weeklySales = (int)Calculations.ComputeWeeklySales(completedOrders);
                int monthlySales = (int)Calculations.ComputeMonthlySales(completedOrders);
                int yearlySales = (int)Calculations.ComputeYearlySales(completedOrders);

                // Update labels with the calculated values
                itemSold.Text = Calculations.CountOverallItems(completedOrders).ToString();
                totalSales.Text = Calculations.CountTotalSales(completedOrders).ToString();
                totalCustomers.Text = customerRepository.GetTotalCustomers().ToString();
                lblDay.Text = dailySales.ToString();
                lblWeek.Text = weeklySales.ToString();
                lblMonth.Text = monthlySales.ToString();
                lblYear.Text = yearlySales.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateDashboard: {ex.Message}");
                // Handle the error appropriately, such as displaying an error message to the user
            }
        }

        //* Will refresh the dashboard in every 30 seconds interval
        private void DashboardTimer_Tick(object sender, EventArgs e)
        {
            InitLabels();
            RefreshTable();

            Console.WriteLine("Refreshed Dashboard");
        }

        private void RefreshTable()
        {
            List<Order> orders = null;
            if (currentTable.Equals(SelectedSales.DAILY))
            {
                orders = orderRepository.GetOrdersCompletedToday();
            } else if(currentTable.Equals(SelectedSales.WEEKLY))
            {
                orders = orderRepository.GetOrdersCompletedThisWeek();
            } else if (currentTable.Equals(SelectedSales.MONTHLY))
            {
                orders = orderRepository.GetOrdersCompletedThisMonth();
            } else if(currentTable.Equals(SelectedSales.YEARLY))
            {
                orders = orderRepository.GetOrdersCompletedThisYear();
            }
            
            fillUpTheTable(orders);
        }

        private void InitLabels()
        {
            try
            {
                // Calculate daily, weekly, monthly, and yearly sales (by filtering the dates)
                int dailySales = (int)Calculations.ComputeDailyIncome(completedOrders);
                int weeklySales = (int)Calculations.ComputeWeeklySales(completedOrders);
                int monthlySales = (int)Calculations.ComputeMonthlySales(completedOrders);
                int yearlySales = (int)Calculations.ComputeYearlySales(completedOrders);

                // Update labels with the calculated values
                itemSold.Text = Calculations.CountOverallItems(completedOrders).ToString();
                totalSales.Text = Calculations.CountTotalSales(completedOrders).ToString();
                totalCustomers.Text = customerRepository.GetTotalCustomers().ToString();
                lblDay.Text = dailySales.ToString();
                lblWeek.Text = weeklySales.ToString();
                lblMonth.Text = monthlySales.ToString();
                lblYear.Text = yearlySales.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in InitLabels: {ex.Message}");
                // Handle the error appropriately, such as displaying an error message to the user
            }
        }

        private void fillUpTheTable(List<Order> orders)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("OrderDate", "Order Date");
            dataGridView1.Columns.Add("TotalPrice", "Total Price");

            foreach (Order order in orders)
            {
                dataGridView1.Rows.Add(order.OrderDate.ToString("MM/dd/yyyy"), order.TotalPrice.ToString("C"));
            }
        }

        private void panel11_Click(object sender, EventArgs e)
        {
            currentTable = SelectedSales.MONTHLY;
            List<Order> monthlyOrder = orderRepository.GetOrdersCompletedThisMonth();
            fillUpTheTable(monthlyOrder);
        }

        private void panel12_Click(object sender, EventArgs e)
        {
            currentTable = SelectedSales.YEARLY;
            List<Order> yearlyOrder = orderRepository.GetOrdersCompletedThisYear();
            fillUpTheTable(yearlyOrder);
        }

        private void panel10_Click(object sender, EventArgs e)
        {
            currentTable = SelectedSales.WEEKLY;
            List<Order> weeklyOrder = orderRepository.GetOrdersCompletedThisWeek();
            fillUpTheTable(weeklyOrder);
        }

        private void panel9_Click(object sender, EventArgs e)
        {
            currentTable = SelectedSales.DAILY;
            List<Order> dailyOrders = orderRepository.GetOrdersCompletedToday();
            fillUpTheTable(dailyOrders);
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
