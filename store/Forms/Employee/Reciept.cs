using store.Models;
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
    public partial class Reciept : Form
    {
        Payment payment = null;
        public Reciept(Payment payment)
        {
            this.payment = payment;
            InitializeComponent();
            PopulateLabelValues();
            PopulateDataGridView();
        }

        private void PopulateLabelValues()
        {
            OrderID.Text = payment.Order.OrderID.ToString();
            Total.Text = payment.Order.TotalPrice.ToString("C");
            Cash.Text= payment.TotalCash.ToString("C");
            Change.Text = payment.TotalChange.ToString("C");
        }
        private void PopulateDataGridView()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Item");
            table.Columns.Add("Quantity");
            table.Columns.Add("SellingPrice");
            table.Columns.Add("TotalPrice");

            foreach (OrderItem item in payment.Items)
            {
                table.Rows.Add(item.Item, item.Quantity, item.SellingPrice.ToString("C"), item.TotalPrice.ToString("C"));
            }

            dataGridView1.DataSource = table;
        }

        private void btnBack5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Reciept_Load(object sender, EventArgs e)
        {

        }
    }
}
