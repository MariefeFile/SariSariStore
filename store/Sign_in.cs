using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.OleDb;
using store.Models;
using store.Repositories;

namespace store
{
    
    
    public partial class Sign_in : Form
    {
        public Sign_in()
        {
            InitializeComponent();
        }

        private void Exit2_Click(object sender, EventArgs e)
        {
           
            StartingPoint back2 = new StartingPoint();
            back2.Show();
            this.Close();
        }

        private void btnAd_Click(object sender, EventArgs e)
        {
            string usernanme = textUser.Text;
            string password = textPass.Text;
            string usertype = comboType.Text;
           
            User user = new User(usernanme, password, usertype);

            UserRepository userRepository = new UserRepository();

            if (userRepository.IsUserExist(user))
            {
                MessageBox.Show("Successfully logged in.", "Log in Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new Billings(textUser.Text).Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("User does not exist. Please try again.", "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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