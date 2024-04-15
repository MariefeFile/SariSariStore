using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace store
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            timer1.Start();
        }
        private int startpoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint += 1;
            progressBar1.Value = startpoint;
            percentage.Text = "" + startpoint + "%";
            if (progressBar1.Value == 100)
            {
                progressBar1.Value = 0;
                startpoint = 0;
                timer1.Stop();
                StartingPoint log = new StartingPoint();
                log.Show();
                this.Hide();

            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
