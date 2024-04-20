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
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }
        private void Homepage_Load(object sender, EventArgs e)
        {
            panel8.Visible = false ;
        }
       
        private void Exit3_Click(object sender, EventArgs e)
        {
            this.Close();
            Sign_in back2 = new Sign_in();
            back2.Show();
        }

        private void lbEmp_Click(object sender, EventArgs e)
        {
            EmployeeViews emp = new EmployeeViews();
            emp.Show();
            this.Close();
        }

        private void lbProd_Click(object sender, EventArgs e)
        {
            AllProd all = new AllProd();
            all.Show();
            this.Close();
        }

        private void plProd_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            CostumerName co = new CostumerName();
            co.Show();
            this.Hide();
        }

        private void lbdash_Click(object sender, EventArgs e)
        {
            panel8.Visible = true;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
