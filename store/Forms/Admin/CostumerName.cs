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
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView4.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView4.SelectedRows[0];

                int customerID = Convert.ToInt32(selectedRow.Cells["CustomerID"].Value);
                
                bool deleted = customerRepository.DeleteCustomerByID(customerID);

                if (deleted)
                {
                    PopulateDataGridView();
                    MessageBox.Show("Customer deleted successfully.");
                }
                else
                {
                    MessageBox.Show("Error deleting customer.");
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }


        private void buttonClear_Click(object sender, EventArgs e)
        {
            if (customerRepository.EmptyCustomersTable())
            {
                MessageBox.Show("All customers deleted successfully.");
                PopulateDataGridView();
            }
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


        private void Exit55_Click(object sender, EventArgs e)
        {
            Homepage hm = new Homepage();
            hm.Show();
            this.Hide();
        }
    }
}

