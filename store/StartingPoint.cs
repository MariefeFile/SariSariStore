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
        public StartingPoint()
        {
            InitializeComponent();
        }

       

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Sign_in fill = new Sign_in();
            fill.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void StartingPoint_Load(object sender, EventArgs e)
        {

        }

        private void btnStartHere_Click(object sender, EventArgs e)
        {
            Productss startHere = new Productss();
            startHere.Show();
            this.Hide();
        }
    }
}
