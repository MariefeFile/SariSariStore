using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;

namespace store
{
    public partial class Costumer : Form
    {
        OleDbConnection myConn;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;
        int indexRow;
        public Costumer()
        {
            InitializeComponent();
            myConn = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=C:\\Users\\ll\\Desktop\\oop2week8\\store.mdb");
        }
        private void Costumer_Load(object sender, EventArgs e)
        {

            panel1.Visible = true;
            panel4.Visible = false;
            try
            {
                myConn.Open();
                // System.Windows.Forms.MessageBox.Show("Connected Succsfully!");
                this.Hide();
                myConn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ERROR!");
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
            string connectionString = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=C:\\Users\\ll\\Desktop\\oop2week8\\store.mdb";
            string query = "INSERT INTO AddCostumer (CostumName, CostumPhone) VALUES (@Name, @Phone)";

            using (OleDbConnection myConn = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, myConn))
                {
                    cmd.Parameters.AddWithValue("@Name", textUserName.Text);
                    cmd.Parameters.AddWithValue("@Phone", textphone.Text);


                   
                    myConn.Open();
                    cmd.ExecuteNonQuery();
                }
                
            }
            MessageBox.Show("Data inserted successfully.");
            Productss prod = new Productss(textUserName.Text);
            prod.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Exit65_Click(object sender, EventArgs e)
        {
           StartingPoint streeee = new StartingPoint();
            streeee.Show();
            this.Hide();
        }
    }
}
