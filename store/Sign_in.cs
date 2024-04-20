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
            myConn = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=C:\\Users\\ll\\Desktop\\oop2week8\\store.mdb");

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
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ERROR!");
            }
        }

        private void Exit2_Click(object sender, EventArgs e)
        {
           
            StartingPoint back2 = new StartingPoint();
            back2.Show();
            this.Close();
        }

        private void btnEmp_Click_1(object sender, EventArgs e)
        {
            myConn.Open();
            cmd = new OleDbCommand();
            cmd.Connection = myConn;
            cmd.CommandText = "SELECT * FROM tblEmp WHERE EmpName = @EmpName AND EmpPass = @EmpPass";
            cmd.Parameters.AddWithValue("@EmpName", textUser.Text);
            cmd.Parameters.AddWithValue("@EmpPass", textPass.Text);
            OleDbDataReader reader = cmd.ExecuteReader();
            int cnt = 0;
            while (reader.Read())
            {
                cnt = cnt + 1;
            }
            if (cnt == 1)
            {

                string selectedUserType = comboType.SelectedItem.ToString().Trim();
                if (selectedUserType == "Employee")
                {
                    // MessageBox.Show("Username and Password are correct!");
                    new Billings(textUser.Text).Show();
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

        private void btnAd_Click(object sender, EventArgs e)
        {
            myConn.Open();
            cmd = new OleDbCommand();
            cmd.Connection = myConn;
            cmd.CommandText = "SELECT * FROM tblAdmin WHERE AdminName = @AddName AND AdminPass= @AddPass";
            cmd.Parameters.AddWithValue("@AddName", textUser.Text);
            cmd.Parameters.AddWithValue("@AddPass", textPass.Text);
            OleDbDataReader reader = cmd.ExecuteReader();
            int cnt = 0;
            while (reader.Read())
            {
                cnt = cnt + 1;
            }
            if (cnt == 1)
            {

                string selectedUserType = comboType.SelectedItem.ToString().Trim();
                if (selectedUserType == "Admin")
                {
                    // MessageBox.Show("Username and Password are correct!");
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

        private void textUser_Enter(object sender, EventArgs e)
        {
            if (textUser.Text == "UserName")
            {
                textUser.Text = "";

                textUser.ForeColor = Color.Black;
            }
        }

        private void textUser_Leave(object sender, EventArgs e)
        {
            if (textUser.Text == "")
            {
                textUser.Text = "UserName";

                textUser.ForeColor = Color.Black;
            }
        }

        private void textPass_Enter(object sender, EventArgs e)
        {
            if (textPass.Text == "Password")
            {
                textPass.Text = "";

                textPass.ForeColor = Color.Black;
            }
        }

        private void textPass_Leave(object sender, EventArgs e)
        {
            if (textPass.Text == "")
            {
                textPass.Text = "Password";

                textPass.ForeColor = Color.Black;
            }
        }

        private void comboType_Enter(object sender, EventArgs e)
        {
            if (comboType.Text == "UserType")
            {
                comboType.Text = "";

                comboType.ForeColor = Color.Black;
            }
        }

        private void comboType_Leave(object sender, EventArgs e)
        {
            if (comboType.Text == "")
            {
                comboType.Text = "UesrType";

                comboType.ForeColor = Color.Black;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textPass.UseSystemPasswordChar = false;
            }
            else
            {
                textPass.UseSystemPasswordChar = true;
            }
        }
    }
}