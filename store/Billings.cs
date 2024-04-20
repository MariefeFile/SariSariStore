using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace store
{
    public partial class Billings : Form
    {
        OleDbConnection myConn;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;
        int indexRow;
        string employeeName;
        private DataTable dataTable;
        public Billings(string employeeName)
        {
            InitializeComponent();
            this.employeeName = employeeName;
            myConn = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=C:\\Users\\ll\\Desktop\\oop2week8\\store.mdb");
            EmpDisplay.Text = this.employeeName;

        }

        private void Billings_Load(object sender, EventArgs e)
        {
           
            
        }
       

        private void EmpDisplay_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1213_Click(object sender, EventArgs e)
        {
            Sign_in swww = new Sign_in();
            swww.Show();
            this.Hide();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }
    }
}
