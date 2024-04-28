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
    public partial class StartingPoint : Form
    {
        DatabaseRepository databaseRepository;
        public StartingPoint()
        {
            InitializeComponent();
            
            databaseRepository = new DatabaseRepository();

            if (databaseRepository.IsDatabaseConnected())
            {
                MessageBox.Show("Database connected successfully!");
            }
            else
            {
                MessageBox.Show("Database not found or connection failed.");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Sign_in fill = new Sign_in();
            fill.Show();
            this.Hide();
        }

        private void StartingPoint_Load(object sender, EventArgs e)
        {

        }

        private void btnStartHere_Click(object sender, EventArgs e)
        {
            Costumer startHere = new Costumer();
            startHere.Show();
            this.Hide();
            
        }

        private void Exit1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
