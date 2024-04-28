using store.Constants.Orders;
using store.Constants.Products;
using store.Models;
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

namespace store
{
    public partial class Billings : Form
    {
        private List<Order> orderList;
        public Billings(User user)
        {
            InitializeComponent();
            InitOrderItemsTable();
        }


        private void FetchOrders()
        {

        }

        private void FetchOrderItems()
        {

        }

        private void InitOrderItemsTable()
        {
            dataGridView2.Columns.Add(ProductFields.ProductID, "Product ID");
            dataGridView2.Columns.Add(ProductFields.Item, "Item");
            dataGridView2.Columns.Add(ProductFields.Categories, "Categories");
            dataGridView2.Columns.Add(ProductFields.Unit, "Unit");
            dataGridView2.Columns.Add(ProductFields.Quantity, "Quantity");
            dataGridView2.Columns.Add(ProductFields.SellingPrice, "Selling Price");
            dataGridView2.Columns.Add(ProductFields.TotalPrice, "Total Price");
        }

        private void InitOrdersTable()
        {
            dataGrid11.Columns.Add(OrderFields.OrderDate, "OrderDate");
            dataGrid11.Columns.Add(OrderFields.CustomerName, "CustomerName");
            dataGrid11.Columns.Add(OrderFields.TotalPrice, "Total Price");
            dataGrid11.Columns.Add(OrderFields.Status, "Status");
            dataGrid11.Columns.Add(OrderFields.PriorityNumber, "Priority Number");
        }

        private void pictureBox1213_Click(object sender, EventArgs e)
        {
            Sign_in swww = new Sign_in();
            swww.Show();
            this.Hide();
        }
    }
}
