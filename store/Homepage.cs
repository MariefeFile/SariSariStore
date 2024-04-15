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

        private void btnBack3_Click(object sender, EventArgs e)
        {
            this.Close();
            Sign_in back2 = new Sign_in();
            back2.Show();
        }
    }
}
