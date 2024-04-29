using store.Constants.Orders;
using store.Constants.Products;
using store.Models;
using store.Repositories;
using store.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace store
{
    public partial class Billings : Form
    {
        private List<Order> orderList;
        private OrderRepository orderRepository = new OrderRepository();
        private OrderItemRepository orderItemRepository = new OrderItemRepository();
        private PaymentRepository paymentRepository = new PaymentRepository();
        private Payment payment = new Payment();

        public Billings(User user)
        {
            InitializeComponent();
            InitOrderItemsTable();
            InitOrdersTable();
            PopulateOrderTable();

            payment.EmployeeName = EmpDisplay.Text = user.UserName;
            dataGrid11.SelectionChanged += DataGrid11_SelectionChanged;
            textBox2.TextChanged += textBox2_TextChanged;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox2.Text, out double result))
            {
                payment.TotalCash = result;
                payment.TotalChange = Calculations.ComputeChange(payment.Order.TotalPrice, result);
                textBox3.Text = payment.TotalChange.ToString("C");
            }
            else
            {

                if (!textBox2.Text.Equals(""))
                {
                    textBox2.Text = "";
                    MessageBox.Show("Invalid input. Please enter a valid numeric value.");
                }
            }
        }



        private void PopulateOrderTable()
        {
            try
            {
                orderList = orderRepository.GetOrdersPending();

                dataGrid11.Rows.Clear();

                foreach (Order order in orderList)
                {
                    dataGrid11.Rows.Add(
                        order.OrderID,
                        order.CustomerName,
                        order.TotalPrice.ToString("C"),
                        order.Status,
                        order.PriorityNumber,
                        order.OrderDate.ToString("MM/dd/yyyy")
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error populating order table: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void PopulateOrderItems(int orderID)
        {
            try
            {
                payment.Items = orderItemRepository.GetOrderItemsByOrderID(orderID);

                dataGridView2.Rows.Clear();

                foreach (OrderItem item in payment.Items)
                {
                    dataGridView2.Rows.Add(
                        item.ProductID,
                        item.Item,
                        item.Categories,
                        item.Unit,
                        item.Quantity,
                        item.SellingPrice.ToString("C"),
                        item.TotalPrice.ToString("C")
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error populating ordered items table: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            dataGrid11.Columns.Add(OrderFields.OrderID, "Order ID");
            dataGrid11.Columns.Add(OrderFields.CustomerName, "Customer Name");
            dataGrid11.Columns.Add(OrderFields.TotalPrice, "Total Price");
            dataGrid11.Columns.Add(OrderFields.Status, "Status");
            dataGrid11.Columns.Add(OrderFields.PriorityNumber, "Priority Number");
            dataGrid11.Columns.Add(OrderFields.OrderDate, "OrderDate");
        }

        private void pictureBox1213_Click(object sender, EventArgs e)
        {
            Sign_in swww = new Sign_in();
            swww.Show();
            this.Hide();
        }

        private void DataGrid11_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGrid11.SelectedRows.Count == 1)
                {
                    DataGridViewRow selectedRow = dataGrid11.SelectedRows[0];
                    int orderID = Convert.ToInt32(selectedRow.Cells[OrderFields.OrderID].Value);
                    string orderDateText = selectedRow.Cells[OrderFields.OrderDate].Value.ToString();
                    string customerName = selectedRow.Cells[OrderFields.CustomerName].Value.ToString();
                    double totalPrice = 0;
                    string totalPriceText = selectedRow.Cells[OrderFields.TotalPrice].Value.ToString();
                    if (decimal.TryParse(totalPriceText, System.Globalization.NumberStyles.Currency, System.Globalization.CultureInfo.CurrentCulture, out decimal totalPriceValue))
                    {
                        totalPrice = Convert.ToDouble(totalPriceValue);
                    }
                    string status = selectedRow.Cells[OrderFields.Status].Value.ToString();
                    int priorityNumber = Convert.ToInt32(selectedRow.Cells[OrderFields.PriorityNumber].Value);


                    payment.Order = new Order
                    {
                        OrderID = orderID,
                        OrderDate = DateTime.ParseExact(orderDateText, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                        CustomerName = customerName,
                        TotalPrice = totalPrice,
                        Status = status,
                        PriorityNumber = priorityNumber
                    };

                    PopulateOrderItems(orderID);
                    textBox1.Text = totalPrice.ToString("C");
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting Order details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            CustomerRepository customerRepository = new CustomerRepository();

            payment.PaymentDate = DateTime.Now;
            
            paymentRepository.InsertPayment(payment);
            orderRepository.UpdateOrderStatus(payment.Order.OrderID);

            
            customerRepository.UpdateTotalPayment(payment.Order.CustomerName, payment.Order.TotalPrice);
            new Reciept(payment).Show();

            dataGridView2.Rows.Clear();
            PopulateOrderTable();

            textBox1.Text = "";
            textBox3.Text = "";
        }
    }
}
