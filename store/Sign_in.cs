using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Runtime.Remoting.Contexts;
using System.Xml.Linq;
using System.Data.OleDb;
using  System.Data.SqlClient;
namespace store
{
    
    
    public partial class Sign_in : Form
    {
        OleDbConnection myConn;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;
        int indexRow;
        public Sign_in()
        {
            InitializeComponent();
            myConn = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=C:\\Users\\ll\\Desktop\\oop2week8\\LOG_in.mdb");

        }

        private void Sign_in_Load(object sender, EventArgs e)
        {
          
            try
            {
                myConn.Open();
               // System.Windows.Forms.MessageBox.Show("Connected Succsfully!");
                this.Hide();
                myConn.Close();
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ERROR!");
            }
        }

        private void btnBack1_Click(object sender, EventArgs e)
        {
            this.Close();
            StartingPoint back2 = new StartingPoint();
            back2.Show();
        }

        private void btnEmp_Click(object sender, EventArgs e)
        {
            myConn.Open();
            cmd = new OleDbCommand();
            cmd.Connection = myConn;
            cmd.CommandText = "SELECT * FROM Employee WHERE EmpName = @UserName AND EmpPassword = @Password";
            cmd.Parameters.AddWithValue("@UserName", User.Text);
            cmd.Parameters.AddWithValue("@Password", pass.Text);
            OleDbDataReader reader = cmd.ExecuteReader();
            int cnt = 0;
            while (reader.Read())
            {
                cnt = cnt + 1;
            }
            if (cnt == 1)
            {
                
                string selectedUserType = usertype.SelectedItem.ToString().Trim();
                if (selectedUserType == "Employee")
                {
                    MessageBox.Show("Username and Password are correct!");
                    new EmployeeViews().Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid user type!");
                }
            }
            else if (cnt > 1)
            {
                MessageBox.Show("Duplicate Username and Password!");
            }
            else
            {
                MessageBox.Show("Username and Password are invalid!");
            }
            myConn.Close();

        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            myConn.Open();
            cmd = new OleDbCommand();
            cmd.Connection = myConn;
            cmd.CommandText = "SELECT * FROM Admin WHERE AdminName = @UserName AND AdminPass= @Password";
            cmd.Parameters.AddWithValue("@UserName", User.Text);
            cmd.Parameters.AddWithValue("@Password", pass.Text);
            OleDbDataReader reader = cmd.ExecuteReader();
            int cnt = 0;
            while (reader.Read())
            {
                cnt = cnt + 1;
            }
            if (cnt == 1)
            {
               
                string selectedUserType = usertype.SelectedItem.ToString().Trim();
                if (selectedUserType == "Admin")
                {
                    MessageBox.Show("Username and Password are correct!");
                    new Homepage().Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid user type!");
                }
            }
            else if (cnt > 1)
            {
                MessageBox.Show("Duplicate Username and Password!");
            }
            else
            {
                MessageBox.Show("Username and Password are invalid!");
            }
            myConn.Close();


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                pass.UseSystemPasswordChar = false;
            }
            else
            {
                pass.UseSystemPasswordChar = true;
            }
        }

        private void usertype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}