using store.Constants;
using store.Constants.Products;
using store.Models;
using store.Services;
using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace store
{
    public partial class Productss : Form
    {
        private OleDbConnection myConn;
        private OleDbCommand cmd;
        private DataTable dataTable;
        private ProductService productService;

        private DataTable productsTable;

        public Productss(string name)
        {

            InitializeComponent();

            // Objects
            productService = new ProductService(Data.ConnectionPath);


            // intitializing table headers
            dataGridView1.Columns.Add("Item", "Item");
            dataGridView1.Columns.Add("Categories", "Categories");
            dataGridView1.Columns.Add("Unit", "Unit");
            dataGridView1.Columns.Add("Qnty", "Quantity");
            dataGridView1.Columns.Add("SellingPrice", "Selling Price");
            dataGridView1.Columns.Add("TotalPrice", "Total Price");


            // querying products items
            try
            {
                productsTable = productService.GetAllProducts();

                if (productsTable.Rows.Count > 0)
                {
                    foreach (DataRow row in productsTable.Rows)
                    {
                        string item = row["Item"].ToString();
                        double sellingPrice = Convert.ToDouble(row["SellingPrice"]);


                        if (item.Equals(ProductItems.Ganador))
                        {
                            label2.Text = String.Format("{0} (Php{1:N2})", item, sellingPrice);
                        }

                        if (item.Equals(ProductItems.Mineral_Water))
                        {
                            label12.Text = String.Format("{0} (Php{1:N2})", item, sellingPrice);
                        }

                        if (item.Equals(ProductItems.Coke))
                        {
                            label10.Text = String.Format("{0} (Php{1:N2})", item, sellingPrice);
                        }

                        if (item.Equals(ProductItems.Emperador_Light))
                        {
                            label8.Text = String.Format("{0} (Php{1:N2})", item, sellingPrice);
                        }
                        if (item.Equals(ProductItems.Carne_Norte))
                        {
                            label6.Text = String.Format("{0} (Php{1:N2})", item, sellingPrice);
                        }
                        if (item.Equals(ProductItems.Lion_Ivory))
                        {
                            label3.Text = String.Format("{0} (Php{1:N2})", item, sellingPrice);
                        }

                        if (item.Equals(ProductItems.Bottled_Water))
                        {
                            label13.Text = String.Format("{0} (Php{1:N2})", item, sellingPrice);
                        }
                        if (item.Equals(ProductItems.Sprite))
                        {
                            label11.Text = String.Format("{0} (Php{1:N2})", item, sellingPrice);
                        }
                        if (item.Equals(ProductItems.Emperador_Deluxe))
                        {
                            label9.Text = String.Format("{0} (Php{1:N2})", item, sellingPrice);
                        }
                        if (item.Equals(ProductItems.Beef_Loaf))
                        {
                            label7.Text = String.Format("{0} (Php{1:N2})", item, sellingPrice);
                        }

                    }

                }
                else
                {
                    MessageBox.Show("No data found in the products table.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                string currentCategory = Convert.ToString(selectedRow.Cells["Categories"].Value);

                switch (currentCategory)
                {
                    case "Rice":
                        PopulateRiceControls(selectedRow);
                        break;
                    case "Water":
                        PopulateWaterControls(selectedRow);
                        break;
                    case "Softdrinks":
                        PopulateSoftdrinkControls(selectedRow);
                        break;
                    case "AlcoholDrinks":
                        PopulateAlcoholControls(selectedRow);
                        break;
                    case "Can Goods":
                        PopulateCanGoodsControls(selectedRow);
                        break;
                    default:
                        break;
                }

               
            }

        }
        private void PopulateRiceControls(DataGridViewRow row)
        {
            comboRice1.Text = Convert.ToString(row.Cells["Item"].Value);
            comboRice3.Text = Convert.ToString(row.Cells["Unit"].Value);
            numericUpDown22.Value = Convert.ToDecimal(row.Cells["Qnty"].Value);
        }
        private void PopulateWaterControls(DataGridViewRow row)
        {
            comboWatr1.Text = Convert.ToString(row.Cells["Item"].Value);
            comboWatr3.Text = Convert.ToString(row.Cells["Unit"].Value);
            numericUpDown1.Value = Convert.ToDecimal(row.Cells["Qnty"].Value);
        }
        private void PopulateSoftdrinkControls(DataGridViewRow row)
        {
            comboDrinks1.Text = Convert.ToString(row.Cells["Item"].Value);
            comboDrinks3.Text = Convert.ToString(row.Cells["Unit"].Value);
            numericUpDown2.Value = Convert.ToDecimal(row.Cells["Qnty"].Value);
        }
        private void PopulateAlcoholControls(DataGridViewRow row)
        {
            cmbEmpe1.Text = Convert.ToString(row.Cells["Item"].Value);
            cmbEmpe3.Text = Convert.ToString(row.Cells["Unit"].Value);
            numericUpDown3.Value = Convert.ToDecimal(row.Cells["Qnty"].Value);
        }
        private void PopulateCanGoodsControls(DataGridViewRow row)
        {
            cmbGoods1.Text = Convert.ToString(row.Cells["Item"].Value);
            cmbGoods3.Text = Convert.ToString(row.Cells["Unit"].Value);
            numericUpDown7.Value = Convert.ToDecimal(row.Cells["Qnty"].Value);
        }
        //----GroupBox per Product----//
        private void btnAll_Click(object sender, EventArgs e)
        {
            groupRice.Location = groupRice.Location;
            groupWater.Location = groupWater.Location;
            groupSoftdrinks.Location = groupSoftdrinks.Location;
            groupAlcoholDrinks.Location = groupAlcoholDrinks.Location;
            groupGoods.Location = groupGoods.Location;
            groupRice.Visible = true;
            groupWater.Visible = true;
            groupSoftdrinks.Visible = true;
            groupAlcoholDrinks.Visible = true;
            groupGoods.Visible = true;

        }
        private void btnrice_Click(object sender, EventArgs e)
        {
            groupRice.Visible = true;
            groupWater.Visible = false;
            groupSoftdrinks.Visible = false;
            groupAlcoholDrinks.Visible = false;
            groupGoods.Visible = false;

        }
        private void btnWater_Click(object sender, EventArgs e)
        {
            groupWater.Location = groupRice.Location;
            groupRice.Visible = false;
            groupWater.Visible = true;
            groupSoftdrinks.Visible = false;
            groupAlcoholDrinks.Visible = false;
            groupGoods.Visible = false;

        }
        private void btnSoftD_Click(object sender, EventArgs e)
        {
            groupSoftdrinks.Location = groupRice.Location;
            groupRice.Visible = false;
            groupWater.Visible = false;
            groupSoftdrinks.Visible = true;
            groupAlcoholDrinks.Visible = false;
            groupGoods.Visible = false;

        }
        private void btnAlcoholDrinks_Click(object sender, EventArgs e)
        {
            groupAlcoholDrinks.Location = groupRice.Location;
            groupRice.Visible = false;
            groupWater.Visible = false;
            groupSoftdrinks.Visible = false;
            groupAlcoholDrinks.Visible = true;
            groupGoods.Visible = false;

        }
        private void btnCanGoods_Click(object sender, EventArgs e)
        {
            groupGoods.Location = groupRice.Location;
            groupRice.Visible = false;
            groupWater.Visible = false;
            groupSoftdrinks.Visible = false;
            groupAlcoholDrinks.Visible = false;
            groupGoods.Visible = true;


        }
        //----------ComboBox----------//
        private void comboRice1_Enter(object sender, EventArgs e)
        {
            if (comboRice1.Text == "Item")
            {
                comboRice1.Text = "";

                comboRice1.ForeColor = Color.Black;
            }
        }//-------RICE
        private void comboRice1_Leave(object sender, EventArgs e)
        {
            if (comboRice1.Text == "")
            {
                comboRice1.Text = "Item";

                comboRice1.ForeColor = Color.Black;
            }
        }
        private void comboRice3_Enter(object sender, EventArgs e)
        {
            if (comboRice3.Text == "Unit")
            {
                comboRice3.Text = "";

                comboRice3.ForeColor = Color.Black;
            }
        }
        private void comboRice3_Leave(object sender, EventArgs e)
        {
            if (comboRice3.Text == "")
            {
                comboRice3.Text = "Unit";

                comboRice3.ForeColor = Color.Black;
            }
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if (comboRice3.Text == "")
            {
                comboRice3.Text = "Categories";

                comboRice3.ForeColor = Color.Black;
            }
        }


        private void comboWatr1_Enter(object sender, EventArgs e)
        {
            if (comboWatr1.Text == "Item")
            {
                comboWatr1.Text = "";

                comboWatr1.ForeColor = Color.Black;
            }
        }//------Water
        private void comboWatr1_Leave(object sender, EventArgs e)
        {
            if (comboWatr1.Text == "")
            {
                comboWatr1.Text = "Item";

                comboWatr1.ForeColor = Color.Black;
            }
        }
        private void comboWatr3_Enter(object sender, EventArgs e)
        {
            if (comboWatr3.Text == "Unit")
            {
                comboWatr3.Text = "";

                comboWatr3.ForeColor = Color.Black;
            }
        }
        private void comboWatr3_Leave(object sender, EventArgs e)
        {
            if (comboWatr3.Text == "")
            {
                comboWatr3.Text = "Unit";

                comboWatr3.ForeColor = Color.Black;
            }
        }

        private void comboDrinks1_Enter(object sender, EventArgs e)
        {
            if (comboDrinks1.Text == "Item")
            {
                comboDrinks1.Text = "";

                comboDrinks1.ForeColor = Color.Black;
            }
        }

        private void comboDrinks1_Leave(object sender, EventArgs e)
        {
            if (comboDrinks1.Text == "")
            {
                comboDrinks1.Text = "Item";

                comboDrinks1.ForeColor = Color.Black;
            }
        }
        private void comboDrinks3_Enter(object sender, EventArgs e)
        {
            if (comboDrinks3.Text == "Unit")
            {
                comboDrinks3.Text = "";

                comboDrinks3.ForeColor = Color.Black;
            }
        }
        private void comboDrinks3_Leave(object sender, EventArgs e)
        {
            if (comboDrinks3.Text == "")
            {
                comboDrinks3.Text = "Unit";

                comboDrinks3.ForeColor = Color.Black;
            }
        }
        
        private void comboRice_Leave(object sender, EventArgs e)
        {
            if (comboDrinks3.Text == "")
            {
                comboDrinks3.Text = "Categories";

                comboDrinks3.ForeColor = Color.Black;
            }
        }

        private void cmbEmpe1_Enter(object sender, EventArgs e)
        {
            if (cmbEmpe1.Text == "Item")
            {
                cmbEmpe1.Text = "";

                cmbEmpe1.ForeColor = Color.Black;
            }
        }//--------Emperador
        private void cmbEmpe1_Leave(object sender, EventArgs e)
        {
            if (cmbEmpe1.Text == "")
            {
                cmbEmpe1.Text = "Item";

                cmbEmpe1.ForeColor = Color.Black;
            }
        }
        private void cmbEmpe3_Enter(object sender, EventArgs e)
        {
            if (cmbEmpe3.Text == "Unit")
            {
                cmbEmpe3.Text = "";

                cmbEmpe3.ForeColor = Color.Black;
            }
        }
        private void cmbEmpe3_Leave(object sender, EventArgs e)
        {
            if (cmbEmpe3.Text == "")
            {
                cmbEmpe3.Text = "Unit";

                cmbEmpe3.ForeColor = Color.Black;
            }
        }

        private void comboEmpe_Leave(object sender, EventArgs e)
        {
            if (cmbEmpe3.Text == "")
            {
                cmbEmpe3.Text = "Categories";

                cmbEmpe3.ForeColor = Color.Black;
            }
        }

        private void cmbGoods1_Enter(object sender, EventArgs e)
        {
            if (cmbGoods1.Text == "Item")
            {
                cmbGoods1.Text = "";

                cmbGoods1.ForeColor = Color.Black;
            }
        }//-------Goodss
        private void cmbGoods1_Leave(object sender, EventArgs e)
        {
            if (cmbGoods1.Text == "")
            {
                cmbGoods1.Text = "Item";

                cmbGoods1.ForeColor = Color.Black;
            }
        }
        private void cmbGoods3_Enter(object sender, EventArgs e)
        {
            if (cmbGoods3.Text == "Unit")
            {
                cmbGoods3.Text = "";

                cmbGoods3.ForeColor = Color.Black;
            }
        }
        private void cmbGoods3_Leave(object sender, EventArgs e)
        {
            if (cmbGoods3.Text == "")
            {
                cmbGoods3.Text = "Unit";

                cmbGoods3.ForeColor = Color.Black;
            }
        }
        

        private void RefreshDataGridView()
        {
            dataGridView1.DataSource = null;

            // Rebind the DataGridView to your data source
            string query = "SELECT * FROM QryOrder"; // Assuming tblEmp is your table name
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, myConn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void btnAdd1_Click(object sender, EventArgs e)
        {
            string selectedItem = comboRice1.Text.Trim();
            string selectedUnit = comboRice3.Text.Trim();
            string category = ProductCategory.Rice;

            // Check if the quantity value is valid
            if (double.TryParse(numericUpDown22.Text, out double quantity))
            {
                // Add the row only if all required fields are not empty
                if (!string.IsNullOrWhiteSpace(selectedItem) &&
                    !string.IsNullOrWhiteSpace(selectedUnit) &&
                    !selectedItem.Equals("Item") &&
                    !selectedUnit.Equals("Unit") && quantity != 0
                    )
                {
                    double sellingPrice = 0.0;
                    double totalPrice = 0.0;

                    foreach (DataRow row in productsTable.Rows)
                    {
                        string item = row["Item"].ToString();


                        if (item.Equals(selectedItem))
                        {
                            sellingPrice = Convert.ToDouble(row[ProductFields.SellingPrice]);
                            totalPrice = sellingPrice * quantity;
                        }

                    }

                    dataGridView1.Rows.Add(selectedItem, category, selectedUnit, quantity, sellingPrice, totalPrice);
                }
                else
                {
                    MessageBox.Show("Please fill in all required fields (Item, Categories, Unit, and Quantity).", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid quantity.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Refresh1DataGridView()
        {
            dataGridView1.DataSource = null;

            // Rebind the DataGridView to your data source
            string query = "SELECT * FROM QryOrder"; // Assuming tblEmp is your table name
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, myConn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void btnAdd2_Click(object sender, EventArgs e)
        {
            
        }
        private void btnAdd3_Click(object sender, EventArgs e)
        {
        
        }
        private void btnAdd4_Click(object sender, EventArgs e)
        {
            
        }
        private void btnAdd6_Click(object sender, EventArgs e)
        {
        
        }
        private void groupRice_Enter(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                    // Check if the row is new and uncommitted
                    if (!selectedRow.IsNewRow)
                    {
                        // Remove the selected row
                        dataGridView1.Rows.Remove(selectedRow);
                    }
                    else
                    {
                        MessageBox.Show("Cannot delete an uncommitted row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a row to delete.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void Exit11_Click(object sender, EventArgs e)
        {
            this.Close();
            StartingPoint backk = new StartingPoint();
            backk.Show();
        }
        private void RefreshDataGridView1()
        {
            dataGridView1.DataSource = null;

            // Rebind the DataGridView to your data source
            string query = "SELECT * FROM QryOrder"; // Assuming tblEmp is your table name
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, myConn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                double TotalPrice = 0;
                double quantity = Convert.ToDouble(numericUpDown22.Value);
                double sellingPrice = 0;
                TotalPrice = sellingPrice * quantity;
                string connectionString = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=C:\\Users\\ll\\Desktop\\oop2week8\\store.mdb";

                using (OleDbConnection myConn = new OleDbConnection(connectionString))
                {
                    string query = "UPDATE QryOrder SET Item=@Item, Unit=@Unit, Qnty=@Qnty,Categories=@Categories, SellingPrice=@SellingPrice,TotalPrice=@TotalPrice WHERE ProductID=@ID";
                    using (OleDbCommand cmd = new OleDbCommand(query, myConn))
                    {
                        cmd.Parameters.AddWithValue("@Item", comboRice1.Text);
                        cmd.Parameters.AddWithValue("@Unit", comboRice3.Text);
                        cmd.Parameters.AddWithValue("@Qnty", numericUpDown22.Value);
                        cmd.Parameters.AddWithValue("@SellingPrice", sellingPrice);
                        cmd.Parameters.AddWithValue("@TotalPrice", TotalPrice);

                        cmd.Parameters.AddWithValue("@Item", comboWatr1.Text);
                        cmd.Parameters.AddWithValue("@Unit", comboWatr3.Text);
                        cmd.Parameters.AddWithValue("@Qnty", numericUpDown1.Value);
                        cmd.Parameters.AddWithValue("@SellingPrice", sellingPrice);
                        cmd.Parameters.AddWithValue("@TotalPrice", TotalPrice);

                        cmd.Parameters.AddWithValue("@Item", comboDrinks1.Text);
                        cmd.Parameters.AddWithValue("@Unit", comboDrinks3.Text);
                        cmd.Parameters.AddWithValue("@Qnty", numericUpDown2.Value);
                        cmd.Parameters.AddWithValue("@SellingPrice", sellingPrice);
                        cmd.Parameters.AddWithValue("@TotalPrice", TotalPrice);

                        cmd.Parameters.AddWithValue("@Item", cmbEmpe1.Text);
                        cmd.Parameters.AddWithValue("@Unit", cmbEmpe3.Text);
                        cmd.Parameters.AddWithValue("@Qnty", numericUpDown3.Value);
                        cmd.Parameters.AddWithValue("@SellingPrice", sellingPrice);
                        cmd.Parameters.AddWithValue("@TotalPrice", TotalPrice);

                        cmd.Parameters.AddWithValue("@Item", cmbGoods1.Text);
                        cmd.Parameters.AddWithValue("@Unit", cmbGoods3.Text);
                        cmd.Parameters.AddWithValue("@Qnty", numericUpDown7.Value);
                        cmd.Parameters.AddWithValue("@SellingPrice", sellingPrice);
                        cmd.Parameters.AddWithValue("@TotalPrice", TotalPrice);

                        int saleID = 123; // Replace 123 with the actual ID value you want to use
                        cmd.Parameters.AddWithValue("@ID", saleID);


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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PriorityNum num = new PriorityNum();
            num.Show();
            this.Hide();
        }
    }
}
