using store.Constants.Orders;
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
            priorityNumber.Text = order.PriorityNumber.ToString();
            customerName.Text = order.CustomerName;
            totalPayment.Text = order.TotalPrice.ToString();
            dateOfOrder.Text = order.OrderDate.ToString();   
        }

        public PriorityNum(Order order)
        {
            InitializeComponent();

            PriorityNumberRepository pnRepo = new PriorityNumberRepository();
            OrderRepository orderRepository = new OrderRepository();
            OrderItemRepository orderItemRepository = new OrderItemRepository();

            order.OrderDate = DateTime.Now;
            order.PriorityNumber = pnRepo.GetLatestPriorityNumber();
            order.Status = OrderStatus.Pending;

            inititalizePrioritySlip(order);

            int orderID = orderRepository.AddOrder(order);
            orderItemRepository.AddOrderItems(orderID, order.OrderItems);
            pnRepo.AddLatestPriorityNumber();

        }

        private void Exit4_Click(object sender, EventArgs e)
        {
            new StartingPoint().Show();
            this.Hide();

        }

    }
}
