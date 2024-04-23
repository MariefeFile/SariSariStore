using store.Services;
using System;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace store
{
    public partial class Costumer : Form
    {
        private readonly CustomerService customerRepository;
        private readonly DatabaseService databaseService;

        public Costumer()
        {
            InitializeComponent();
            databaseService = new DatabaseService();
            customerRepository = new CustomerService();
        }

        private void Costumer_Load(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel4.Visible = false;

            if (databaseService.IsDatabaseConnected())
            {
                MessageBox.Show("Database connected successfully!");
            }
            else
            {
                MessageBox.Show("Database not found or connection failed.");
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            
            panel4.Visible = true;
            panel1.Visible = false;

        }

        private void Ex1_Click(object sender, EventArgs e)
        {
            StartingPoint st = new StartingPoint();
            st.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
           Costumer st = new Costumer();
            st.Show();
            this.Hide();
        }

        private void btnlog_Click(object sender, EventArgs e)
        {
            Productss prod = new Productss("");
            prod.Show();
            this.Hide();
        }

        private void textUserName_Enter(object sender, EventArgs e)
        {
            if (textUserName.Text == "UserName")
            {
                textUserName.Text = "";

                textUserName.ForeColor = Color.Black;
            }
        }

        private void textUserName_Leave(object sender, EventArgs e)
        {
            if (textUserName.Text == "")
            {
                textUserName.Text = "UserName";

                textUserName.ForeColor = Color.Black;
            }
        }

        private void textphone_Enter(object sender, EventArgs e)
        {
            if (textphone.Text == "Phone")
            {
                textphone.Text = "";

                textphone.ForeColor = Color.Black;
            }
        }

        private void textphone_Leave(object sender, EventArgs e)
        {
            if (textphone.Text == "")
            {
                textphone.Text = "Phone";

                textphone.ForeColor = Color.Black;
            }
        }

        

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string name = textUserName.Text;
            string phone = textphone.Text;

            if (customerRepository.InsertCustomer(name, phone, "sample_email@gmail.com"))
            {
                MessageBox.Show("Data inserted successfully.");
                Productss prod1 = new Productss(name);
                prod1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Failed to insert data.");
            }
        }

        private void Exit65_Click(object sender, EventArgs e)
        {
           StartingPoint streeee = new StartingPoint();
            streeee.Show();
            this.Hide();
        }
        
    }
}
