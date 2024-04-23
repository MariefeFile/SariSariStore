using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace store
{
    public partial class AllProd : Form
    {
        OleDbConnection myConn;
        OleDbCommand cmd;
        

        public AllProd()
        {
            InitializeComponent();
            myConn = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=C:\\Users\\ll\\Desktop\\oop2week8\\store.mdb");
            
        }

        private void AllProd_Load(object sender, EventArgs e)
        {
           
            try
            {
                myConn.Open();
                // System.Windows.Forms.MessageBox.Show("Connected Succsfully!");
                LoadDataIntoDataGridView();
                this.Hide();
                myConn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void Exit4_Click(object sender, EventArgs e)
        {
           
            Homepage hp = new Homepage();
            hp.Show();
            this.Hide();
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView5.Rows[e.RowIndex];

            // Display employee details in textboxes
            txtSaleID.Text = row.Cells["ProductID"].Value.ToString();
            txtSaleName.Text = row.Cells["Item"].Value.ToString();
            txtSaleUnit.Text = row.Cells["Unit"].Value.ToString();
            txtSaleQnty.Text = row.Cells["Qnty"].Value.ToString();
            txtSaleOrg.Text = row.Cells["Org_Price"].Value.ToString();
            txtSaleSelling.Text = row.Cells["SellingPrice"].Value.ToString();
            txtSaleStock.Text = row.Cells["Stock"].Value.ToString();
            comboSaleCat.Text = row.Cells["Categories"].Value.ToString();
            txtSold.Text = row.Cells["ItemSold"].Value.ToString();
            txtMarkUp.Text = row.Cells["MarkUp"].Value.ToString();
        }
        private void LoadDataIntoDataGridView()
        {
            string query = "SELECT * FROM tblProducts";
            OleDbDataAdapter da = new OleDbDataAdapter(query, myConn);
            DataTable dt = new DataTable();

            // Fill the DataTable with data from the database
            da.Fill(dt);

            // Bind the DataTable to the DataGridView
            dataGridView5.DataSource = dt;


        }
        private void RefreshDataGridView1()
        {
            dataGridView5.DataSource = null;

            // Rebind the DataGridView to your data source
            string query = "SELECT * FROM tblProducts"; // Assuming tblEmp is your table name
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, myConn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView5.DataSource = dt;

        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                double sold = 0;
                double markup = 0;

                // Parse string inputs to double
                double stock = double.Parse(txtSaleStock.Text);
                double qnty = double.Parse(txtSaleQnty.Text);
                double sellingPrice = double.Parse(txtSaleSelling.Text);
                double orgPrice = double.Parse(txtSaleOrg.Text);

                // Calculate sold and markup
                sold = stock - qnty;
                markup = sellingPrice - orgPrice;

                string connectionString = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=C:\\Users\\ll\\Desktop\\oop2week8\\store.mdb";
                string query = "INSERT INTO tblProducts (Item, Unit, Qnty, Org_Price, SellingPrice, Stock, Categories, ItemSold, MarkUp) " +
                               "VALUES (@Item, @Unit, @Qnty, @Org_Price, @SellingPrice, @Stock, @Categories, @ItemSold, @MarkUp)";

                using (OleDbConnection myConn = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand cmd = new OleDbCommand(query, myConn))
                    {
                        cmd.Parameters.AddWithValue("@Item", txtSaleName.Text);
                        cmd.Parameters.AddWithValue("@Unit", txtSaleUnit.Text);
                        cmd.Parameters.AddWithValue("@Qnty", txtSaleQnty.Text);
                        cmd.Parameters.AddWithValue("@Org_Price", txtSaleOrg.Text);
                        cmd.Parameters.AddWithValue("@SellingPrice", txtSaleSelling.Text);
                        cmd.Parameters.AddWithValue("@Stock", txtSaleStock.Text);
                        cmd.Parameters.AddWithValue("@Categories", comboSaleCat.Text);
                        cmd.Parameters.AddWithValue("@ItemSold", sold);
                        cmd.Parameters.AddWithValue("@MarkUp", markup);

                        myConn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Data inserted successfully.");

                // Refresh the DataGridView with the updated data
                RefreshDataGridView1();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btnUpDate_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=C:\\Users\\ll\\Desktop\\oop2week8\\store.mdb";

                using (OleDbConnection myConn = new OleDbConnection(connectionString))
                {
                    string query = "UPDATE tblProducts SET Item=@Item, Unit=@Unit, Qnty=@Qnty, Org_Price=@Org_Price, SellingPrice=@SellingPrice,Stock=@Stock, Categories=@Categories,ItemSold=@ItemSold,MarkUp=@MarkUp WHERE ProductID=@ID";
                    using (OleDbCommand cmd = new OleDbCommand(query, myConn))
                    {
                        cmd.Parameters.AddWithValue("@Item", txtSaleName.Text);
                        cmd.Parameters.AddWithValue("@Unit", txtSaleUnit.Text);
                        cmd.Parameters.AddWithValue("@Qnty", txtSaleQnty.Text);
                        cmd.Parameters.AddWithValue("@Org_Price", txtSaleOrg.Text);
                        cmd.Parameters.AddWithValue("@SellingPrice", txtSaleSelling.Text);
                        cmd.Parameters.AddWithValue("@Stock", txtSaleStock.Text);
                        cmd.Parameters.AddWithValue("@Categories", comboSaleCat.Text);
                        cmd.Parameters.AddWithValue("@ItemSold", txtSold.Text);
                        cmd.Parameters.AddWithValue("@MarkUp", txtMarkUp.Text);
                        cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtSaleID.Text));

                        myConn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        MessageBox.Show(rowsAffected + " row(s) updated.");
                    }
                }

                // Refresh the DataGridView with the updated data after updating
                RefreshDataGridView1();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        private int index;
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string query = "Delete From tblProducts Where ProductID = @ProdID";
            cmd = new OleDbCommand(query, myConn);
            cmd.Parameters.AddWithValue("@ProdID", dataGridView5.CurrentRow.Cells[0].Value);
            myConn.Open();
            cmd.ExecuteNonQuery();
            myConn.Close();
            index = dataGridView5.CurrentCell.RowIndex;
            dataGridView5.Rows.RemoveAt(index);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {

            txtSaleID.Text = String.Empty;
            txtSaleName.Text = String.Empty;
            txtSaleUnit.Text = String.Empty;
            txtSaleQnty.Text = String.Empty;
            txtSaleOrg.Text = String.Empty;
            txtSaleSelling.Text = String.Empty;
            txtSaleStock.Text = String.Empty;
            comboSaleCat.Text = String.Empty;
            txtSold.Text = String.Empty;
            txtMarkUp.Text = String.Empty;
            

        }
        private void txtSaleID_Enter(object sender, EventArgs e)
        {

            if (txtSaleID.Text == "ProductID")
            {
                txtSaleID.Text = "";

                txtSaleID.ForeColor = Color.Black;
            }
        }
        private void txtSaleID_Leave(object sender, EventArgs e)
        {
            if (txtSaleID.Text == "")
            {
                txtSaleID.Text = "ProductID";

                txtSaleID.ForeColor = Color.Black;
            }
        }
        private void txtSaleName_Enter(object sender, EventArgs e)
        {
            if (txtSaleName.Text == "Name")
            {
                txtSaleName.Text = "";

                txtSaleName.ForeColor = Color.Black;
            }
        }
        private void txtSaleName_Leave(object sender, EventArgs e)
        {
            if (txtSaleName.Text == "")
            {
                txtSaleName.Text = "Name";

                txtSaleName.ForeColor = Color.Black;
            }
        }
        private void txtSaleUnit_Enter(object sender, EventArgs e)
        {

            if (txtSaleUnit.Text == "Unit")
            {
                txtSaleUnit.Text = "";

                txtSaleUnit.ForeColor = Color.Black;
            }
        }
        private void txtSaleUnit_Leave(object sender, EventArgs e)
        {

            if (txtSaleUnit.Text == "")
            {
                txtSaleUnit.Text = "Unit";

                txtSaleUnit.ForeColor = Color.Black;
            }
        }
        private void txtSaleQnty_Enter(object sender, EventArgs e)
        {

            if (txtSaleQnty.Text == "Qnty")
            {
                txtSaleQnty.Text = "";

                txtSaleQnty.ForeColor = Color.Black;
            }
        }
        private void txtSaleQnty_Leave(object sender, EventArgs e)
        {
            if (txtSaleQnty.Text == "")
            {
                txtSaleQnty.Text = "Qnty";

                txtSaleQnty.ForeColor = Color.Black;
            }
        }
        private void txtSaleOrg_Enter(object sender, EventArgs e)
        {
            if (txtSaleOrg.Text == "Org_Price")
            {
                txtSaleOrg.Text = "";

                txtSaleOrg.ForeColor = Color.Black;
            }
        }
        private void txtSaleOrg_Leave(object sender, EventArgs e)
        {
            if (txtSaleOrg.Text == "")
            {
                txtSaleOrg.Text = "Org_Price";

                txtSaleOrg.ForeColor = Color.Black;
            }
        }
        private void txtSaleSelling_Enter(object sender, EventArgs e)
        {
            if (txtSaleSelling.Text == "SellingPrice")
            {
                txtSaleSelling.Text = "";

                txtSaleSelling.ForeColor = Color.Black;
            }
        }
        private void txtSaleSelling_Leave(object sender, EventArgs e)
        {
            if (txtSaleSelling.Text == "")
            {
                txtSaleSelling.Text = "SellingPrice";

                txtSaleSelling.ForeColor = Color.Black;
            }
        }
        private void txtSaleStock_Enter(object sender, EventArgs e)
        {

            if (txtSaleStock.Text == "Stock")
            {
                txtSaleStock.Text = "";

                txtSaleStock.ForeColor = Color.Black;
            }
        }
        private void txtSaleStock_Leave(object sender, EventArgs e)
        {
            if (txtSaleStock.Text == "")
            {
                txtSaleStock.Text = "Stock";

                txtSaleStock.ForeColor = Color.Black;
            }
        }
        private void comboSaleCat_Enter(object sender, EventArgs e)
        {
            if (comboSaleCat.Text == "Categories")
            {
                comboSaleCat.Text = "";

                comboSaleCat.ForeColor = Color.Black;
            }
        }
        private void comboSaleCat_Leave(object sender, EventArgs e)
        {
            if (comboSaleCat.Text == "")
            {
                comboSaleCat.Text = "Categories";

                comboSaleCat.ForeColor = Color.Black;
            }
        }
        private void txtSold_Enter(object sender, EventArgs e)
        {
            if (txtSold.Text == "ItemSold")
            {
                txtSold.Text = "";

                txtSold.ForeColor = Color.Black;
            }
        }
        private void txtSold_Leave(object sender, EventArgs e)
        {
            if (txtSold.Text == "")
            {
                txtSold.Text = "ItemSold";

                txtSold.ForeColor = Color.Black;
            }
        }
        private void txtMarkUp_Enter(object sender, EventArgs e)
        {
            if (txtMarkUp.Text == "MarkUp")
            {
                txtMarkUp.Text = "";

                txtMarkUp.ForeColor = Color.Black;
            }
        }
        private void txtMarkUp_Leave(object sender, EventArgs e)
        {
            if (txtMarkUp.Text == "")
            {
                txtMarkUp.Text = "MarkUp";

                txtMarkUp.ForeColor = Color.Black;
            }
        }

       
    }
}
