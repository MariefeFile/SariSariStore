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
using static System.Net.Mime.MediaTypeNames;

namespace store
{
    public partial class CostumerName : Form
    {
        OleDbConnection myConn;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;
        int indexRow;
        public CostumerName()
        {
            InitializeComponent();
            myConn = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=C:\\Users\\ll\\Desktop\\oop2week8\\store.mdb");

        }

        private void Exit55_Click(object sender, EventArgs e)
        {
            Homepage hm = new Homepage();
            hm.Show();
            this.Hide();
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CostumerName_Load(object sender, EventArgs e)
        {
            try
            {
                myConn.Open();
                // MessageBox.Show("Connected Successfully!");
                LoadDataIntoDataGridView();
                this.Hide();
                myConn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ERROR: " + ex.Message);
            }
        }
        private void LoadDataIntoDataGridView()
        {
            string query = "SELECT * FROM QryCostumerDetails";
            OleDbDataAdapter da = new OleDbDataAdapter(query, myConn);
            DataTable dt = new DataTable();

            // Fill the DataTable with data from the database
            da.Fill(dt);

            // Bind the DataTable to the DataGridView
            dataGridView4.DataSource = dt;

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView4.Rows[e.RowIndex];

            // Display employee details in textboxes
            txtCostum.Text = row.Cells["CostumerID"].Value.ToString();
            txtCostumName.Text = row.Cells["CostumerName"].Value.ToString();
            txtEmpName.Text = row.Cells["EmpName"].Value.ToString();
            txtpayment.Text = row.Cells["TotalPayment"].Value.ToString();
            txtdate.Text = row.Cells["Date"].Value.ToString();
          
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView4.CurrentRow != null)
                {
                    string query = "DELETE FROM QryCostumerDetails WHERE CostumerID = @CostumeID";
                    cmd = new OleDbCommand(query, myConn);
                    cmd.Parameters.AddWithValue("@CostumeID", dataGridView4.CurrentRow.Cells["Item"].Value);

                    myConn.Open();
                    cmd.ExecuteNonQuery();
                    myConn.Close();

                    // Remove the selected row from the DataGridView
                    dataGridView4.Rows.Remove(dataGridView4.CurrentRow);
                }
                else
                {
                    MessageBox.Show("Please select a row to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            txtCostum.Text = String.Empty;
            txtCostumName.Text = String.Empty;
            txtEmpName.Text = String.Empty;
            txtpayment.Text = String.Empty;
            txtdate.Text = String.Empty;
        }
    }
}

