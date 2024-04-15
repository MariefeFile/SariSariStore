using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.TextFormatting;

namespace store
{
    public partial class Productss : Form
    {
        OleDbConnection myConn;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;
        int indexRow;
        public Productss()
        {
            InitializeComponent();
            myConn = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=C:\\Users\\ll\\Desktop\\oop2week8\\LOG_in.mdb");
            dataGridView1.CellClick += dataGridView1_CellContentClick;
        }
        private void Productss_Load(object sender, EventArgs e)
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
            string query = "SELECT * FROM Sold";
            OleDbDataAdapter da = new OleDbDataAdapter(query, myConn);
            DataTable dt = new DataTable();

            // Fill the DataTable with data from the database
            da.Fill(dt);

            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = dt;
            

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {/*
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                    // Populate controls with data from the selected row
                    if (selectedRow.Cells["Item"].Value != null)
                        comboRice1.Text = Convert.ToString(selectedRow.Cells["Item"].Value);
                    if (selectedRow.Cells["Type"].Value != null)
                        comboRice2.Text = Convert.ToString(selectedRow.Cells["Type"].Value);
                    if (selectedRow.Cells["Unit"].Value != null)
                        comboRice3.Text = Convert.ToString(selectedRow.Cells["Unit"].Value);
                    if (selectedRow.Cells["Quantity"].Value != null)
                        numericUpDown22.Value = Convert.ToDecimal(selectedRow.Cells["Quantity"].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }*/
            
            
             if (e.RowIndex >= 0)
             {
                 DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                 // Populate controls with data from the selected row
                 comboRice1.Text = Convert.ToString(selectedRow.Cells["Item"].Value);
                 comboRice3.Text = Convert.ToString(selectedRow.Cells["Unit"].Value);
                 numericUpDown22.Value = Convert.ToDecimal(selectedRow.Cells["Quantity"].Value);
             }

        }

        private void btnBackk_Click(object sender, EventArgs e)
        {
            this.Close();
            StartingPoint backk = new StartingPoint();
            backk.Show();
        }

        //----GroupBox per Product----//
        private void btnAll_Click(object sender, EventArgs e)
        {
            groupRice.Visible = true;
            groupWater.Visible = true;
            groupSoftdrinks.Visible = true;
            groupAlcoholDrinks.Visible = true;
            groupGoods.Visible = true;
            groupBiscuits.Visible = true;
        }
        private void btnrice_Click(object sender, EventArgs e)
        {
            groupRice.Visible = true;
            groupWater.Visible = false;
            groupSoftdrinks.Visible = false;
            groupAlcoholDrinks.Visible = false;
            groupGoods.Visible = false;
            groupBiscuits.Visible = false;
        }
        private void btnWater_Click(object sender, EventArgs e)
        {
            groupWater.Location = groupRice.Location;
            groupRice.Visible = false;
            groupWater.Visible = true;
            groupSoftdrinks.Visible = false;
            groupAlcoholDrinks.Visible = false;
            groupGoods.Visible = false;
            groupBiscuits.Visible = false;
        }
        private void btnSoftD_Click(object sender, EventArgs e)
        {
            groupSoftdrinks.Location = groupRice.Location;
            groupRice.Visible = false;
            groupWater.Visible = false;
            groupSoftdrinks.Visible = true;
            groupAlcoholDrinks.Visible = false;
            groupGoods.Visible = false;
            groupBiscuits.Visible = false;
        }
        private void btnAlcoholDrinks_Click(object sender, EventArgs e)
        {
            groupAlcoholDrinks.Location = groupRice.Location;
            groupRice.Visible = false;
            groupWater.Visible = false;
            groupSoftdrinks.Visible = false;
            groupAlcoholDrinks.Visible = true;
            groupGoods.Visible = false;
            groupBiscuits.Visible = false;
        }
        private void btnCanGoods_Click(object sender, EventArgs e)
        {
            groupGoods.Location = groupRice.Location;
            groupRice.Visible = false;
            groupWater.Visible = false;
            groupSoftdrinks.Visible = false;
            groupAlcoholDrinks.Visible = false;
            groupGoods.Visible = true;
            groupBiscuits.Visible = false;

        }
        private void btnBiscuits_Click(object sender, EventArgs e)
        {
            groupBiscuits.Location = groupRice.Location;
            groupRice.Visible = false;
            groupWater.Visible = false;
            groupSoftdrinks.Visible = false;
            groupAlcoholDrinks.Visible = false;
            groupGoods.Visible = false;
            groupBiscuits.Visible = true;
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
        private void comboWatr2_Enter(object sender, EventArgs e)
        {
            if (comboWatr2.Text == "Type")
            {
                comboWatr2.Text = "";

                comboWatr2.ForeColor = Color.Black;
            }
        }
        private void comboWatr2_Leave(object sender, EventArgs e)
        {
            if (comboWatr2.Text == "")
            {
                comboWatr2.Text = "Type";

                comboWatr2.ForeColor = Color.Black;
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
        }//---SorftDrinks
        private void comboDrinks1_Leave(object sender, EventArgs e)
        {
            if (comboDrinks1.Text == "")
            {
                comboDrinks1.Text = "Item";

                comboDrinks1.ForeColor = Color.Black;
            }
        }
        private void comboDrinks2_Enter(object sender, EventArgs e)
        {
            if (comboDrinks2.Text == "Type")
            {
                comboDrinks2.Text = "";

                comboDrinks2.ForeColor = Color.Black;
            }
        }
        private void comboDrinks2_Leave(object sender, EventArgs e)
        {
            if (comboDrinks2.Text == "")
            {
                comboDrinks2.Text = "Type";

                comboDrinks2.ForeColor = Color.Black;
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
        private void cmbEmpe2_Enter(object sender, EventArgs e)
        {
            if (cmbEmpe2.Text == "Type")
            {
                cmbEmpe2.Text = "";

                cmbEmpe2.ForeColor = Color.Black;
            }
        }
        private void cmbEmpe2_Leave(object sender, EventArgs e)
        {
            if (cmbEmpe2.Text == "")
            {
                cmbEmpe2.Text = "Type";

                cmbEmpe2.ForeColor = Color.Black;
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

        private void cmbRedHorse1_Enter(object sender, EventArgs e)
        {
            if (cmbRedHorse1.Text == "Item")
            {
                cmbRedHorse1.Text = "";

                cmbRedHorse1.ForeColor = Color.Black;
            }
        }//-----RedHorse
        private void cmbRedHorse1_Leave(object sender, EventArgs e)
        {
            if (cmbRedHorse1.Text == "")
            {
                cmbRedHorse1.Text = "Item";

                cmbRedHorse1.ForeColor = Color.Black;
            }
        }
        private void cmbRedHorse2_Enter(object sender, EventArgs e)
        {
            if (cmbRedHorse2.Text == "Type")
            {
                cmbRedHorse2.Text = "";

                cmbRedHorse2.ForeColor = Color.Black;
            }
        }
        private void cmbRedHorse2_Leave(object sender, EventArgs e)
        {
            if (cmbRedHorse2.Text == "")
            {
                cmbRedHorse2.Text = "Type";

                cmbRedHorse2.ForeColor = Color.Black;
            }
        }
        private void cmbRedHorse3_Enter(object sender, EventArgs e)
        {
            if (cmbRedHorse3.Text == "Unit")
            {
                cmbRedHorse3.Text = "";

                cmbRedHorse3.ForeColor = Color.Black;
            }
        }
        private void cmbRedHorse3_Leave(object sender, EventArgs e)
        {
            if (cmbRedHorse3.Text == "")
            {
                cmbRedHorse3.Text = "Unit";

                cmbRedHorse3.ForeColor = Color.Black;
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
        private void cmbGoods2_Enter(object sender, EventArgs e)
        {
            if (cmbGoods2.Text == "Type")
            {
                cmbGoods2.Text = "";

                cmbGoods2.ForeColor = Color.Black;
            }
        }
        private void cmbGoods2_Leave(object sender, EventArgs e)
        {
            if (cmbGoods2.Text == "")
            {
                cmbGoods2.Text = "Type";

                cmbGoods2.ForeColor = Color.Black;
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

        private void cmbBiscuits1_Enter(object sender, EventArgs e)
        {
            if (cmbBiscuits1.Text == "Item")
            {
                cmbBiscuits1.Text = "";

                cmbBiscuits1.ForeColor = Color.Black;
            }
        }//-----Biscuits
        private void cmbBiscuits1_Leave(object sender, EventArgs e)
        {
            if (cmbBiscuits1.Text == "")
            {
                cmbBiscuits1.Text = "Item";

                cmbBiscuits1.ForeColor = Color.Black;
            }
        }
        private void cmbBiscuits2_Enter(object sender, EventArgs e)
        {
            if (cmbBiscuits2.Text == "Type")
            {
                cmbBiscuits2.Text = "";

                cmbBiscuits2.ForeColor = Color.Black;
            }
        }
        private void cmbBiscuits2_Leave(object sender, EventArgs e)
        {
            if (cmbBiscuits2.Text == "")
            {
                cmbBiscuits2.Text = "Type";

                cmbBiscuits2.ForeColor = Color.Black;
            }
        }
        private void cmbBiscuits3_Enter(object sender, EventArgs e)
        {
            if (cmbBiscuits3.Text == "Unit")
            {
                cmbBiscuits3.Text = "";

                cmbBiscuits3.ForeColor = Color.Black;
            }
        }
        private void cmbBiscuits3_Leave(object sender, EventArgs e)
        {
            if (cmbBiscuits3.Text == "")
            {
                cmbBiscuits3.Text = "Unit";

                cmbBiscuits3.ForeColor = Color.Black;
            }
        }


        //---------Add Buttons--------////
        private double CalculateSellingPrice(string item, string unit /*, string type, int quantity*/)
        {

            decimal price = 0.00m;

            // Fetch selling price from the database based on item and unit
            string query = "SELECT SellingPrice FROM Sold WHERE Item = @Item AND Unit = @Unit";

            //decimal sellingPrice = CalculateSellingPrice(selectedItem, selectedType);

            using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=C:\\Users\\ll\\Desktop\\oop2week8\\LOG_in.mdb"))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Item", item);
                    cmd.Parameters.AddWithValue("@Unit", unit);
                    // cmd.Parameters.AddWithValue("@Type", type);
                    //  cmd.Parameters.AddWithValue("@Quantity", quantity);

                    try
                    {
                        connection.Open();
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                price = reader.GetDecimal(0); // Assuming price is stored in the first column
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions here
                        Console.WriteLine("Error fetching price from database: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close(); // Ensure connection is closed regardless of success or failure
                    }
                }
            }

            return (double) price;


        }
        
        private void RefreshDataGridView()
        {
            
            try
            {
                dataTable.Clear();

                // Construct the base query
                string query = "SELECT * FROM Sold";

                // Execute the query and populate the DataTable
                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=C:\\Users\\ll\\Desktop\\oop2week8\\LOG_in.mdb"))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
                    {
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (OleDbException ex)
            {
                System.Windows.Forms.MessageBox.Show("Error fetching data from the database: " + ex.Message);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + ex.Message);
            }
            

        }

         private DataTable dataTable = new DataTable();
        // private DataTable dataTable;
        private double calculatedMarkUp(string selectedItem, string unit, double sellingPrice, decimal quantity)
        {
            double markup = 0;
            if( selectedItem.Equals("Ganador"))
            {
                if(unit.Equals("Sack"))
                {
                  markup = sellingPrice - 330;
                }
                else if(unit.Equals("Kilo"))
                {
                    markup = sellingPrice - 69;
                }
            }
            return markup;
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            
            try
            {
                string selectedItem = comboRice1.Text;
                string unit = comboRice3.Text;
                decimal quantity = numericUpDown22.Value;


                Console.WriteLine("Selected Item: " + selectedItem);
                Console.WriteLine("Quantity: " + quantity);

                // Calculate the original price based on selectedItem
                double sellingPrice = CalculateSellingPrice(selectedItem, comboRice3.Text);

                Console.WriteLine("SellingPrice: " + sellingPrice);
                double markup = calculatedMarkUp(selectedItem, unit,sellingPrice, quantity);



                // Calculate total cost
                double totalCost = sellingPrice * (int)quantity;
                Console.WriteLine("TotalPrice: " + totalCost);
                if (selectedItem == "Ganador" || selectedItem == "Lion Ivory" )
                {
                    // Check if the selected type in comboBox4 is "Corn"
                    
                }

                // Continue with adding the product to the cart
                string query = "INSERT INTO Sold (Item, Type, Unit, Quantity, SellingPrice, MarkUp, ItemSold) VALUES (@Item, @Type, @Unit, @Quantity, @SellingPrice,@MarkUp, @ItemSold)";
                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=C:\\Users\\ll\\Desktop\\oop2week8\\LOG_in.mdb"))
                {
                    using (OleDbCommand cmd = new OleDbCommand(query, connection))
                    {
                        // TODO
                        connection.Open();

                        Console.WriteLine("Connection open.");

                        // Set parameters
                        Console.WriteLine("Selected Item:" + selectedItem);

                        cmd.Parameters.AddWithValue("@Item", selectedItem);
                        Console.WriteLine("Selected Item:" + selectedItem);

                        cmd.Parameters.AddWithValue("@Unit", comboRice3.Text);
                        Console.WriteLine("Selected Unit:" + comboRice3.Text);

                        cmd.Parameters.AddWithValue("@Quantity", quantity);
                        Console.WriteLine("Selected Quantity:" + quantity);
                        cmd.Parameters.AddWithValue("@SellingPrice", sellingPrice);
                        Console.WriteLine("Selected SellingPrice:" + sellingPrice);// Use correct parameter name
                        cmd.Parameters.AddWithValue("@OrigPrice", 0);
                        cmd.Parameters.AddWithValue("@MarkUp", markup);
                       
                        
                        // Execute the query
                        cmd.ExecuteNonQuery();
                    }
                }

                // Refresh DataGridView after adding the product
                //RefreshDataGridView();
            }
            catch (OleDbException ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + ex.Message);
            }
            
            /*
            try
            {
                string selectedItem = comboRice1.Text;
                string selectedType = comboRice2.Text;
                string selectedUnit = comboRice3.Text; // Added selected unit
                decimal quantity = numericUpDown22.Value;

                // Calculate the original price based on selectedItem
                decimal sellingPrice = CalculateSellingPrice(selectedItem, selectedUnit);

                // Calculate total cost
                decimal totalCost = sellingPrice * quantity;

                // Add a new row directly to the DataTable
                DataRow newRow = dataTable.NewRow();
                newRow["Item"] = selectedItem;
                newRow["Type"] = selectedType;
                newRow["Quantity"] = quantity;
                newRow["Unit"] = selectedUnit; // Assign the selected unit
                newRow["SellingPrice"] = sellingPrice;
                newRow["TotalPrice"] = totalCost;
                dataTable.Rows.Add(newRow);

                // Refresh the DataGridView to reflect the changes
                dataGridView1.DataSource = null; // Clear the DataSource

                dataGridView1.DataSource = dataTable; // Rebind the DataTable to DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }*/


            /*
            try
            {
                string selectedItem = comboRice1.Text;
                string selectedType = comboRice2.Text;
                decimal quantity = numericUpDown22.Value;

                // Calculate the original price based on selectedItem
                decimal sellingPrice = CalculateSellingPrice(selectedItem, comboRice3.Text);

                // Calculate total cost
                decimal totalCost = sellingPrice * quantity;

                // Check if the columns are present in the DataTable, if not, add them
                if (!dataTable.Columns.Contains("Item"))
                    dataTable.Columns.Add("Item", typeof(string));

                if (!dataTable.Columns.Contains("Type"))
                    dataTable.Columns.Add("Type", typeof(string));

                if (!dataTable.Columns.Contains("Quantity"))
                    dataTable.Columns.Add("Quantity", typeof(decimal));

                if (!dataTable.Columns.Contains("Unit"))
                    dataTable.Columns.Add("Unit", typeof(string));

                if (!dataTable.Columns.Contains("SellingPrice"))
                    dataTable.Columns.Add("SellingPrice", typeof(decimal));

                if (!dataTable.Columns.Contains("TotalPrice"))
                    dataTable.Columns.Add("TotalPrice", typeof(decimal));

                // Your other conditional checks and operations...

                // Add a new row directly to the DataTable
                DataRow newRow = dataTable.NewRow();
                newRow["Item"] = selectedItem;
                newRow["Type"] = selectedType;
                newRow["Quantity"] = quantity;
                newRow["Unit"] = comboRice3.Text;
                newRow["SellingPrice"] = sellingPrice;
                newRow["TotalPrice"] = totalCost;
                dataTable.Rows.Add(newRow);

                // Refresh the DataGridView to reflect the changes
                dataGridView1.Refresh();

                // Clear input controls
                comboRice1.Text = "";
                comboRice2.Text = "";
                comboRice3.Text = "";
                numericUpDown22.Value = 0;
                RefreshDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            */
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

        private void btnAdd5_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd6_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd7_Click(object sender, EventArgs e)
        {

        }

      
    }
}
