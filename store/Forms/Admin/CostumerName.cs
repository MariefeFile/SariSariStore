using store.Models;
using store.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace store
{
    public partial class CostumerName : Form
    {
        private List<Customer> customerList = null;
        private CustomerRepository customerRepository = new CustomerRepository();
        public CostumerName()
        {
            InitializeComponent();

            InitializeDataGridView();
            PopulateDataGridView();
        }

        private void PopulateDataGridView()
        {
            customerList = customerRepository.GetAllCustomers();
            dataGridView4.Rows.Clear();

            foreach (Customer customer in customerList)
            {
                dataGridView4.Rows.Add(
                    customer.CustomerID,
                    customer.CustomerName,
                    customer.CustomerPhone,
                    customer.CustomerEmail,
                    customer.TotalPayment.ToString("C"),
                    customer.DateRecorded.ToString("yyyy-MM-dd")
                );
            }
        }



        private void InitializeDataGridView()
        {

            dataGridView4.Columns.Add("CustomerID", "Customer ID");
            dataGridView4.Columns.Add("CustomerName", "Name");
            dataGridView4.Columns.Add("CustomerPhone", "Phone");
            dataGridView4.Columns.Add("CustomerEmail", "Email");
            dataGridView4.Columns.Add("TotalPayment", "TotalPayment");
            dataGridView4.Columns.Add("DateRecorded", "Date Recorded");
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            DataGridViewRow row = dataGridView4.Rows[e.RowIndex];

            // Display employee details in textboxes
            txtCostum.Text = row.Cells["CostumerID"].Value.ToString();
            txtCostumName.Text = row.Cells["CostumerName"].Value.ToString();
            txtEmpName.Text = row.Cells["EmpName"].Value.ToString();
            txtpayment.Text = row.Cells["TotalPayment"].Value.ToString();
            txtdate.Text = row.Cells["Date"].Value.ToString();
            */
          
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            txtCostum.Text = String.Empty;
            txtCostumName.Text = String.Empty;
            txtEmpName.Text = String.Empty;
            txtpayment.Text = String.Empty;
            txtdate.Text = String.Empty;
        }

        private void Exit55_Click(object sender, EventArgs e)
        {
            Homepage hm = new Homepage();
            hm.Show();
            this.Hide();
        }
    }
}

