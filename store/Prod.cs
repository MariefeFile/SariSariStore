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
        private string name;
        private DataTable dataTable;
        private const string ConnectionPath = "C:\\Users\\Nivanz Aricayos\\Documents\\Codes\\Projects\\SariSariStore\\store.mdb";
        public Productss(string name)
        {

            InitializeComponent();
            myConn = new OleDbConnection($"Provider=Microsoft.JET.OLEDB.4.0;Data Source={ConnectionPath}");
            dataGridView1.CellClick += dataGridView1_CellContentClick;
            dataTable = new DataTable();
            DataRow newRow = dataTable.NewRow();
            dataTable.Rows.Add(newRow);
            dataGridView1.DataSource = dataTable;
            this.name = name;
            

        }
        private void Productss_Load(object sender, EventArgs e)
        {
            groupRice.Visible = false;
            groupWater.Visible = false;
            groupSoftdrinks.Visible = false;
            groupAlcoholDrinks.Visible = false;
            groupGoods.Visible = false;
            CostumerName.Text = name;
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
            string query = "SELECT * FROM QryOrder";
            OleDbDataAdapter da = new OleDbDataAdapter(query, myConn);
            DataTable dt = new DataTable();

            // Fill the DataTable with data from the database
            da.Fill(dt);

            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = dt;

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                string category = Convert.ToString(selectedRow.Cells["Categories"].Value);

                switch (category)
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
                        // Handle other categories or do nothing
                        break;
                }
            }

        }
        private void PopulateRiceControls(DataGridViewRow row)
        {
            comboRice1.Text = Convert.ToString(row.Cells["Item"].Value);
            comboBox1.Text = Convert.ToString(row.Cells["Categories"].Value);
            comboRice3.Text = Convert.ToString(row.Cells["Unit"].Value);
            numericUpDown22.Value = Convert.ToDecimal(row.Cells["Qnty"].Value);
        }
        private void PopulateWaterControls(DataGridViewRow row)
        {
            comboWatr1.Text = Convert.ToString(row.Cells["Item"].Value);
            comboBox2.Text = Convert.ToString(row.Cells["Categories"].Value);
            comboWatr3.Text = Convert.ToString(row.Cells["Unit"].Value);
            numericUpDown1.Value = Convert.ToDecimal(row.Cells["Qnty"].Value);
        }
        private void PopulateSoftdrinkControls(DataGridViewRow row)
        {
            comboDrinks1.Text = Convert.ToString(row.Cells["Item"].Value);
            comboRice.Text = Convert.ToString(row.Cells["Categories"].Value);
            comboDrinks3.Text = Convert.ToString(row.Cells["Unit"].Value);
            numericUpDown2.Value = Convert.ToDecimal(row.Cells["Qnty"].Value);
        }
        private void PopulateAlcoholControls(DataGridViewRow row)
        {
            cmbEmpe1.Text = Convert.ToString(row.Cells["Item"].Value);
            comboEmpe.Text = Convert.ToString(row.Cells["Categories"].Value);
            cmbEmpe3.Text = Convert.ToString(row.Cells["Unit"].Value);
            numericUpDown3.Value = Convert.ToDecimal(row.Cells["Qnty"].Value);
        }
        private void PopulateCanGoodsControls(DataGridViewRow row)
        {
            cmbGoods1.Text = Convert.ToString(row.Cells["Item"].Value);
            comboBox3.Text = Convert.ToString(row.Cells["Categories"].Value);
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
        private void comboBox1_Enter(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Categories")
            {
                comboBox1.Text = "";

                comboBox1.ForeColor = Color.Black;
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
        private void comboBox2_Enter(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Categories")
            {
                comboBox2.Text = "";

                comboBox2.ForeColor = Color.Black;
            }
        }
        private void comboBox2_Leave(object sender, EventArgs e)
        {
            if (comboBox2.Text == "")
            {
                comboBox2.Text = "Categories";

                comboBox2.ForeColor = Color.Black;
            }
        }

        private void comboDrinks1_Enter(object sender, EventArgs e)
        {
            if (comboDrinks1.Text == "Item")
            {
                comboDrinks1.Text = "";

                comboDrinks1.ForeColor = Color.Black;
            }
        }//---SorftDrinks
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
        private void comboRice_Enter(object sender, EventArgs e)
        {
            if (comboRice.Text == "Categories")
            {
                comboRice.Text = "";

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
        private void comboEmpe_Enter(object sender, EventArgs e)
        {
            if (comboEmpe.Text == "Categories")
            {
                comboEmpe.Text = "";

                comboEmpe.ForeColor = Color.Black;
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
        private void comboBox3_Enter(object sender, EventArgs e)
        {
            if (comboBox3.Text == "Categories")
            {
                comboBox3.Text = "";

                comboBox3.ForeColor = Color.Black;
            }
        }
        private void comboBox3_Leave(object sender, EventArgs e)
        {
            if (comboBox3.Text == "")
            {
                comboBox3.Text = "Categories";

                comboBox3.ForeColor = Color.Black;
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
            try
            {
                double TotalPayment = 0;
                double TotalPrice = 0;
                string selectedItem = comboRice1.Text;
                string selectedCategories = comboBox1.Text;
                double sellingPrice = 0; // Initialize sellingPrice
                double quantity = Convert.ToDouble(numericUpDown22.Value); // Convert quantity to double

                // Fetch the selling price from tblProducts
                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=C:\\Users\\ll\\Desktop\\oop2week8\\store.mdb"))
                {
                    connection.Open();
                    OleDbCommand cmdFetchPrice = new OleDbCommand("SELECT SellingPrice FROM tblProducts WHERE Item = @Item", connection);
                    cmdFetchPrice.Parameters.AddWithValue("@Item", selectedItem);
                    object result = cmdFetchPrice.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        sellingPrice = Convert.ToDouble(result);
                    }
                    else
                    {
                        // Handle the case where the selling price is not found
                        System.Windows.Forms.MessageBox.Show("Selling price for the selected item not found.");
                        return;
                    }
                }

                TotalPrice = sellingPrice * quantity;
                TotalPayment += TotalPrice;
                User.Text = TotalPayment.ToString();

                string query = "INSERT INTO QryOrder (Item, Unit, Qnty, Categories, SellingPrice, TotalPrice) VALUES (@Item, @Unit, @Qnty, @Categories, @SellingPrice, @TotalPrice)";
                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=C:\\Users\\ll\\Desktop\\oop2week8\\store.mdb"))
                {
                    connection.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, connection))
                    {
                        // Set parameters for inserting into QryOrder table
                        cmd.Parameters.AddWithValue("@Item", selectedItem);
                        cmd.Parameters.AddWithValue("@Unit", comboRice3.Text);
                        cmd.Parameters.AddWithValue("@Qnty", numericUpDown22.Value);
                        cmd.Parameters.AddWithValue("@Categories", selectedCategories);
                        cmd.Parameters.AddWithValue("@SellingPrice", sellingPrice);
                        cmd.Parameters.AddWithValue("@TotalPrice", TotalPrice);

                        // Execute the query
                        cmd.ExecuteNonQuery();
                    }
                }

                if (selectedItem == "Ganador" || selectedItem == "Lion Ivory")
                {
                    if (selectedCategories == "Water" || selectedCategories == "SoftDrinks" || selectedCategories == "AlcoholDrinks" || selectedCategories == "CanGoods" || selectedCategories == "Biscuits")
                    {
                        System.Windows.Forms.MessageBox.Show("Invalid input!");
                        return;
                    }
                }


                // Assuming dataGridView1 is bound to a DataTable named "dataTable"
                if (dataTable != null)
                {
                    DataRow newRow = dataTable.NewRow();
                    // Create a new row for the DataTable
                    if (!dataTable.Columns.Contains("Item"))
                    {
                        dataTable.Columns.Add("Item", typeof(string));
                    }
                    newRow["Item"] = selectedItem;
                    if (!dataTable.Columns.Contains("Unit"))
                    {
                        dataTable.Columns.Add("Unit", typeof(string));
                    }
                    newRow["Unit"] = comboRice3.Text;
                    if (!dataTable.Columns.Contains("Qnty"))
                    {
                        dataTable.Columns.Add("Qnty", typeof(string));
                    }
                    newRow["Qnty"] = numericUpDown22.Value;
                    if (!dataTable.Columns.Contains("Categories"))
                    {
                        dataTable.Columns.Add("Categories", typeof(string));
                    }
                    newRow["Categories"] = selectedCategories;
                    // Fix the column name here
                    if (!dataTable.Columns.Contains("SellingPrice"))
                    {
                        dataTable.Columns.Add("SellingPrice", typeof(string));
                    }
                    newRow["SellingPrice"] = sellingPrice;
                    if (!dataTable.Columns.Contains("TotalPrice"))
                    {
                        dataTable.Columns.Add("TotalPrice", typeof(string));
                    }
                    newRow["TotalPrice"] = TotalPrice;
                    dataTable.Rows.Add(newRow);
                }
                RefreshDataGridView();
        
                    System.Windows.Forms.MessageBox.Show("Product added to cart successfully.");
            }
            catch (OleDbException ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + ex.Message);
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
            try
            {
                double Totalpayment = 0;
                double Totalprice = 0;
                string selectedIt = comboWatr1.Text;
                string selectedCat = comboBox1.Text;
                double sellingprice = 0; // Initialize sellingPrice
                double qnty = Convert.ToDouble(numericUpDown1.Value); // Convert quantity to double

                // Fetch the selling price from tblProducts
                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=C:\\Users\\ll\\Desktop\\oop2week8\\store.mdb"))
                {
                    connection.Open();
                    OleDbCommand cmdFetchPrice = new OleDbCommand("SELECT SellingPrice FROM tblProducts WHERE Item = @Item", connection);
                    cmdFetchPrice.Parameters.AddWithValue("@Item", selectedIt);
                    object result = cmdFetchPrice.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        sellingprice = Convert.ToDouble(result);
                    }
                    else
                    {
                        // Handle the case where the selling price is not found
                        System.Windows.Forms.MessageBox.Show($"Selling price for the selected item '{selectedIt}' not found.");
                        return;
                    }
                }

                Totalprice = sellingprice * qnty;
                Totalpayment += Totalprice;
                User.Text = Totalpayment.ToString();

                string query = "INSERT INTO QryOrder (Item, Unit, Qnty, Categories, SellingPrice, TotalPrice) VALUES (@Item, @Unit, @Qnty, @Categories, @SellingPrice, @TotalPrice)";
                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=C:\\Users\\ll\\Desktop\\oop2week8\\store.mdb"))
                {
                    connection.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, connection))
                    {
                        // Set parameters for inserting into QryOrder table
                        cmd.Parameters.AddWithValue("@Item", selectedIt);
                        cmd.Parameters.AddWithValue("@Unit", comboWatr3.Text);
                        cmd.Parameters.AddWithValue("@Qnty", numericUpDown1.Value);
                        cmd.Parameters.AddWithValue("@Categories", selectedCat);
                        cmd.Parameters.AddWithValue("@SellingPrice", sellingprice);
                        cmd.Parameters.AddWithValue("@TotalPrice", Totalprice);

                        // Execute the query
                        cmd.ExecuteNonQuery();
                    }
                }

                if (selectedIt == "Mineral Water(litters)" || selectedIt == "Bottled Water(ml)")
                {
                    if (selectedCat == "Rice" || selectedCat == "SoftDrinks" || selectedCat == "AlcoholDrinks" || selectedCat == "CanGoods" || selectedCat == "Biscuits")
                    {
                        System.Windows.Forms.MessageBox.Show("Invalid input!");
                        return;
                    }
                }
                if (dataTable != null)
                {
                    DataRow newRow = dataTable.NewRow();
                    // Create a new row for the DataTable
                    if (!dataTable.Columns.Contains("Item"))
                    {
                        dataTable.Columns.Add("Item", typeof(string));
                    }
                    newRow["Item"] = selectedIt;
                    if (!dataTable.Columns.Contains("Unit"))
                    {
                        dataTable.Columns.Add("Unit", typeof(string));
                    }
                    newRow["Unit"] = comboWatr3.Text;
                    if (!dataTable.Columns.Contains("Qnty"))
                    {
                        dataTable.Columns.Add("Qnty", typeof(string));
                    }
                    newRow["Qnty"] = numericUpDown1.Value;
                    if (!dataTable.Columns.Contains("Categories"))
                    {
                        dataTable.Columns.Add("Categories", typeof(string));
                    }
                    newRow["Categories"] = selectedCat;
                    // Fix the column name here
                    if (!dataTable.Columns.Contains("SellingPrice"))
                    {
                        dataTable.Columns.Add("SellingPrice", typeof(string));
                    }
                    newRow["SellingPrice"] = sellingprice;
                    if (!dataTable.Columns.Contains("TotalPrice"))
                    {
                        dataTable.Columns.Add("TotalPrice", typeof(string));
                    }
                    newRow["TotalPrice"] = Totalprice;
                    dataTable.Rows.Add(newRow);
                }
                // Refresh the DataGridView after adding the item
                Refresh1DataGridView();
                System.Windows.Forms.MessageBox.Show("Product added to cart successfully.");
            }
            catch (OleDbException ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void btnAdd3_Click(object sender, EventArgs e)
        {
            try
            {
                double TotalPayment = 0;
                double TotalPrice = 0;
                string selectedItem = comboDrinks1.Text;
                string selectedCategories = comboRice.Text;
                double sellingPrice = 0; // Initialize sellingPrice
                double quantity = Convert.ToDouble(numericUpDown2.Value); // Convert quantity to double

                // Fetch the selling price from tblProducts
                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=C:\\Users\\ll\\Desktop\\oop2week8\\store.mdb"))
                {
                    connection.Open();
                    OleDbCommand cmdFetchPrice = new OleDbCommand("SELECT SellingPrice FROM tblProducts WHERE Item = @Item", connection);
                    cmdFetchPrice.Parameters.AddWithValue("@Item", selectedItem);
                    object result = cmdFetchPrice.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        sellingPrice = Convert.ToDouble(result);
                    }
                    else
                    {
                        // Handle the case where the selling price is not found
                        System.Windows.Forms.MessageBox.Show("Selling price for the selected item not found.");
                        return;
                    }
                }

                TotalPrice = sellingPrice * quantity;
                TotalPayment += TotalPrice;
                User.Text = TotalPayment.ToString();

                string query = "INSERT INTO QryOrder (Item, Unit, Qnty, Categories, SellingPrice, TotalPrice) VALUES (@Item, @Unit, @Qnty, @Categories, @SellingPrice, @TotalPrice)";
                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=C:\\Users\\ll\\Desktop\\oop2week8\\store.mdb"))
                {
                    connection.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, connection))
                    {
                        // Set parameters for inserting into QryOrder table
                        cmd.Parameters.AddWithValue("@Item", selectedItem);
                        cmd.Parameters.AddWithValue("@Unit", comboDrinks3.Text);
                        cmd.Parameters.AddWithValue("@Qnty", numericUpDown2.Value);
                        cmd.Parameters.AddWithValue("@Categories", selectedCategories);
                        cmd.Parameters.AddWithValue("@SellingPrice", sellingPrice);
                        cmd.Parameters.AddWithValue("@TotalPrice", TotalPrice);

                        // Execute the query
                        cmd.ExecuteNonQuery();
                    }
                }

                if (selectedItem == "Coke" || selectedItem == "Sprite")
                {
                    if (selectedCategories == "Rice" || selectedCategories == "Water" || selectedCategories == "AlcoholDrinks" || selectedCategories == "CanGoods" || selectedCategories == "Biscuits")
                    {
                        System.Windows.Forms.MessageBox.Show("Invalid input!");
                        return;
                    }
                }


                // Assuming dataGridView1 is bound to a DataTable named "dataTable"
                if (dataTable != null)
                {
                    DataRow newRow = dataTable.NewRow();
                    // Create a new row for the DataTable
                    if (!dataTable.Columns.Contains("Item"))
                    {
                        dataTable.Columns.Add("Item", typeof(string));
                    }
                    newRow["Item"] = selectedItem;
                    if (!dataTable.Columns.Contains("Unit"))
                    {
                        dataTable.Columns.Add("Unit", typeof(string));
                    }
                    newRow["Unit"] = comboDrinks3.Text;
                    if (!dataTable.Columns.Contains("Qnty"))
                    {
                        dataTable.Columns.Add("Qnty", typeof(string));
                    }
                    newRow["Qnty"] = numericUpDown2.Value;
                    if (!dataTable.Columns.Contains("Categories"))
                    {
                        dataTable.Columns.Add("Categories", typeof(string));
                    }
                    newRow["Categories"] = selectedCategories;
                    // Fix the column name here
                    if (!dataTable.Columns.Contains("SellingPrice"))
                    {
                        dataTable.Columns.Add("SellingPrice", typeof(string));
                    }
                    newRow["SellingPrice"] = sellingPrice;
                    if (!dataTable.Columns.Contains("TotalPrice"))
                    {
                        dataTable.Columns.Add("TotalPrice", typeof(string));
                    }
                    newRow["TotalPrice"] = TotalPrice;
                    dataTable.Rows.Add(newRow);
                }
                RefreshDataGridView();

                System.Windows.Forms.MessageBox.Show("Product added to cart successfully.");
            }
            catch (OleDbException ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void btnAdd4_Click(object sender, EventArgs e)
        {
            try
            {
                double TotalPayment = 0;
                double TotalPrice = 0;
                string selectedItem = cmbEmpe1.Text;
                string selectedCategories = comboEmpe.Text;
                double sellingPrice = 0; // Initialize sellingPrice
                double quantity = Convert.ToDouble(numericUpDown3.Value); // Convert quantity to double

                // Fetch the selling price from tblProducts
                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=C:\\Users\\ll\\Desktop\\oop2week8\\store.mdb"))
                {
                    connection.Open();
                    OleDbCommand cmdFetchPrice = new OleDbCommand("SELECT SellingPrice FROM tblProducts WHERE Item = @Item", connection);
                    cmdFetchPrice.Parameters.AddWithValue("@Item", selectedItem);
                    object result = cmdFetchPrice.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        sellingPrice = Convert.ToDouble(result);
                    }
                    else
                    {
                        // Handle the case where the selling price is not found
                        System.Windows.Forms.MessageBox.Show("Selling price for the selected item not found.");
                        return;
                    }
                }

                TotalPrice = sellingPrice * quantity;
                TotalPayment += TotalPrice;
                User.Text = TotalPayment.ToString();

                string query = "INSERT INTO QryOrder (Item, Unit, Qnty, Categories, SellingPrice, TotalPrice) VALUES (@Item, @Unit, @Qnty, @Categories, @SellingPrice, @TotalPrice)";
                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=C:\\Users\\ll\\Desktop\\oop2week8\\store.mdb"))
                {
                    connection.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, connection))
                    {
                        // Set parameters for inserting into QryOrder table
                        cmd.Parameters.AddWithValue("@Item", selectedItem);
                        cmd.Parameters.AddWithValue("@Unit", cmbEmpe3.Text);
                        cmd.Parameters.AddWithValue("@Qnty", numericUpDown3.Value);
                        cmd.Parameters.AddWithValue("@Categories", selectedCategories);
                        cmd.Parameters.AddWithValue("@SellingPrice", sellingPrice);
                        cmd.Parameters.AddWithValue("@TotalPrice", TotalPrice);

                        // Execute the query
                        cmd.ExecuteNonQuery();
                    }
                }

                if (selectedItem == "Emperador Light" || selectedItem == "Emperador Deluxe") 
                {
                    if (selectedCategories == "Rice" || selectedCategories == "Water" || selectedCategories == "SoftDrinks" || selectedCategories == "CanGoods" || selectedCategories == "Biscuits")
                    {
                        System.Windows.Forms.MessageBox.Show("Invalid input!");
                        return;
                    }
                }


                // Assuming dataGridView1 is bound to a DataTable named "dataTable"
                if (dataTable != null)
                {
                    DataRow newRow = dataTable.NewRow();
                    // Create a new row for the DataTable
                    if (!dataTable.Columns.Contains("Item"))
                    {
                        dataTable.Columns.Add("Item", typeof(string));
                    }
                    newRow["Item"] = selectedItem;
                    if (!dataTable.Columns.Contains("Unit"))
                    {
                        dataTable.Columns.Add("Unit", typeof(string));
                    }
                    newRow["Unit"] = cmbEmpe3.Text;
                    if (!dataTable.Columns.Contains("Qnty"))
                    {
                        dataTable.Columns.Add("Qnty", typeof(string));
                    }
                    newRow["Qnty"] = numericUpDown3.Value;
                    if (!dataTable.Columns.Contains("Categories"))
                    {
                        dataTable.Columns.Add("Categories", typeof(string));
                    }
                    newRow["Categories"] = selectedCategories;
                    // Fix the column name here
                    if (!dataTable.Columns.Contains("SellingPrice"))
                    {
                        dataTable.Columns.Add("SellingPrice", typeof(string));
                    }
                    newRow["SellingPrice"] = sellingPrice;
                    if (!dataTable.Columns.Contains("TotalPrice"))
                    {
                        dataTable.Columns.Add("TotalPrice", typeof(string));
                    }
                    newRow["TotalPrice"] = TotalPrice;
                    dataTable.Rows.Add(newRow);
                }
                RefreshDataGridView();

                System.Windows.Forms.MessageBox.Show("Product added to cart successfully.");
            }
            catch (OleDbException ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void btnAdd6_Click(object sender, EventArgs e)
        {
            try
            {
                double TotalPayment = 0;
                double TotalPrice = 0;
                string selectedItem = cmbGoods1.Text;
                string selectedCategories = comboBox3.Text;
                double sellingPrice = 0; // Initialize sellingPrice
                double quantity = Convert.ToDouble(numericUpDown3.Value); // Convert quantity to double

                // Fetch the selling price from tblProducts
                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=C:\\Users\\ll\\Desktop\\oop2week8\\store.mdb"))
                {
                    connection.Open();
                    OleDbCommand cmdFetchPrice = new OleDbCommand("SELECT SellingPrice FROM tblProducts WHERE Item = @Item", connection);
                    cmdFetchPrice.Parameters.AddWithValue("@Item", selectedItem);
                    object result = cmdFetchPrice.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        sellingPrice = Convert.ToDouble(result);
                    }
                    else
                    {
                        // Handle the case where the selling price is not found
                        System.Windows.Forms.MessageBox.Show("Selling price for the selected item not found.");
                        return;
                    }
                }

                TotalPrice = sellingPrice * quantity;
                TotalPayment += TotalPrice;
                User.Text = TotalPayment.ToString();

                string query = "INSERT INTO QryOrder (Item, Unit, Qnty, Categories, SellingPrice, TotalPrice) VALUES (@Item, @Unit, @Qnty, @Categories, @SellingPrice, @TotalPrice)";
                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=C:\\Users\\ll\\Desktop\\oop2week8\\store.mdb"))
                {
                    connection.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, connection))
                    {
                        // Set parameters for inserting into QryOrder table
                        cmd.Parameters.AddWithValue("@Item", selectedItem);
                        cmd.Parameters.AddWithValue("@Unit", cmbGoods3.Text);
                        cmd.Parameters.AddWithValue("@Qnty", numericUpDown7.Value);
                        cmd.Parameters.AddWithValue("@Categories", selectedCategories);
                        cmd.Parameters.AddWithValue("@SellingPrice", sellingPrice);
                        cmd.Parameters.AddWithValue("@TotalPrice", TotalPrice);

                        // Execute the query
                        cmd.ExecuteNonQuery();
                    }
                }

                if (selectedItem == "Emperador Light" || selectedItem == "Emperador Deluxe")
                {
                    if (selectedCategories == "Rice" || selectedCategories == "Water" || selectedCategories == "SoftDrinks" || selectedCategories == "CanGoods" || selectedCategories == "Biscuits")
                    {
                        System.Windows.Forms.MessageBox.Show("Invalid input!");
                        return;
                    }
                }


                // Assuming dataGridView1 is bound to a DataTable named "dataTable"
                if (dataTable != null)
                {
                    DataRow newRow = dataTable.NewRow();
                    // Create a new row for the DataTable
                    if (!dataTable.Columns.Contains("Item"))
                    {
                        dataTable.Columns.Add("Item", typeof(string));
                    }
                    newRow["Item"] = selectedItem;
                    if (!dataTable.Columns.Contains("Unit"))
                    {
                        dataTable.Columns.Add("Unit", typeof(string));
                    }
                    newRow["Unit"] = cmbGoods3.Text;
                    if (!dataTable.Columns.Contains("Qnty"))
                    {
                        dataTable.Columns.Add("Qnty", typeof(string));
                    }
                    newRow["Qnty"] = numericUpDown7.Value;
                    if (!dataTable.Columns.Contains("Categories"))
                    {
                        dataTable.Columns.Add("Categories", typeof(string));
                    }
                    newRow["Categories"] = selectedCategories;
                    // Fix the column name here
                    if (!dataTable.Columns.Contains("SellingPrice"))
                    {
                        dataTable.Columns.Add("SellingPrice", typeof(string));
                    }
                    newRow["SellingPrice"] = sellingPrice;
                    if (!dataTable.Columns.Contains("TotalPrice"))
                    {
                        dataTable.Columns.Add("TotalPrice", typeof(string));
                    }
                    newRow["TotalPrice"] = TotalPrice;
                    dataTable.Rows.Add(newRow);
                }
                RefreshDataGridView();

                System.Windows.Forms.MessageBox.Show("Product added to cart successfully.");
            }
            catch (OleDbException ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void groupRice_Enter(object sender, EventArgs e)
        {

        }


        private int index;
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    string query = "DELETE FROM QryOrder WHERE Item = @Item";
                    cmd = new OleDbCommand(query, myConn);
                    cmd.Parameters.AddWithValue("@Item", dataGridView1.CurrentRow.Cells["Item"].Value);

                    myConn.Open();
                    cmd.ExecuteNonQuery();
                    myConn.Close();

                    // Remove the selected row from the DataGridView
                    dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
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
                        cmd.Parameters.AddWithValue("@Categories", comboBox1);
                        cmd.Parameters.AddWithValue("@SellingPrice", sellingPrice);
                        cmd.Parameters.AddWithValue("@TotalPrice", TotalPrice);

                        cmd.Parameters.AddWithValue("@Item", comboWatr1.Text);
                        cmd.Parameters.AddWithValue("@Unit", comboWatr3.Text);
                        cmd.Parameters.AddWithValue("@Qnty", numericUpDown1.Value);
                        cmd.Parameters.AddWithValue("@Categories", comboBox2.Text);
                        cmd.Parameters.AddWithValue("@SellingPrice", sellingPrice);
                        cmd.Parameters.AddWithValue("@TotalPrice", TotalPrice);

                        cmd.Parameters.AddWithValue("@Item", comboDrinks1.Text);
                        cmd.Parameters.AddWithValue("@Unit", comboDrinks3.Text);
                        cmd.Parameters.AddWithValue("@Qnty", numericUpDown2.Value);
                        cmd.Parameters.AddWithValue("@Categories", comboRice.Text);
                        cmd.Parameters.AddWithValue("@SellingPrice", sellingPrice);
                        cmd.Parameters.AddWithValue("@TotalPrice", TotalPrice);

                        cmd.Parameters.AddWithValue("@Item", cmbEmpe1.Text);
                        cmd.Parameters.AddWithValue("@Unit", cmbEmpe3.Text);
                        cmd.Parameters.AddWithValue("@Qnty", numericUpDown3.Value);
                        cmd.Parameters.AddWithValue("@Categories", comboEmpe.Text);
                        cmd.Parameters.AddWithValue("@SellingPrice", sellingPrice);
                        cmd.Parameters.AddWithValue("@TotalPrice", TotalPrice);

                        cmd.Parameters.AddWithValue("@Item", cmbGoods1.Text);
                        cmd.Parameters.AddWithValue("@Unit", cmbGoods3.Text);
                        cmd.Parameters.AddWithValue("@Qnty", numericUpDown7.Value);
                        cmd.Parameters.AddWithValue("@Categories", comboBox3.Text);
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
