using store.Constants;
using store.Constants.Products;
using store.Models;
using store.Repositories;
using store.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace store
{
    public partial class Productss : Form
    {
        private ProductRepository productRepository = new ProductRepository();
        private List<Product> productList;
        private Order order;

        public Productss(string currentCustomerName)
        {
            InitializeComponent();

            order = new Order
            {
                CustomerName = CostumerName.Text = currentCustomerName
            };

            initTableHeaders();

            initPriceProductLabels();

        }

        private void initTableHeaders()
        {
            //! Initializing table headers
            dataGridView1.Columns.Add(ProductFields.ProductID, "Product ID");
            dataGridView1.Columns.Add(ProductFields.Item, "Item");
            dataGridView1.Columns.Add(ProductFields.Categories, "Categories");
            dataGridView1.Columns.Add(ProductFields.Unit, "Unit");
            dataGridView1.Columns.Add(ProductFields.Quantity, "Quantity");
            dataGridView1.Columns.Add(ProductFields.SellingPrice, "Selling Price");
            dataGridView1.Columns.Add(ProductFields.TotalPrice, "Total Price");
        }

        private void initPriceProductLabels()
        {
            // Dictionary to map items to labels
            Dictionary<string, Label> labelMap = new Dictionary<string, Label>
            {
                { ProductItems.Ganador, label2 },
                { ProductItems.Mineral_Water, label12 },
                { ProductItems.Coke, label10 },
                { ProductItems.Emperador_Light, label8 },
                { ProductItems.Carne_Norte, label6 },
                { ProductItems.Lion_Ivory, label3 },
                { ProductItems.Bottled_Water, label13 },
                { ProductItems.Sprite, label11 },
                { ProductItems.Emperador_Deluxe, label9 },
                { ProductItems.Beef_Loaf, label7 }
            };

            try
            {
                productList = productRepository.GetAllProducts();

                if (productList.Count > 0)
                {
                    foreach (Product p in productList)
                    {
                        string item = p.Item;
                        double sellingPrice = p.SellingPrice;

                        if (labelMap.ContainsKey(item))
                        {
                            Label label = labelMap[item];
                            label.Text = String.Format("{0} (Php{1:N2})", item, sellingPrice);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No data found in the products list.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private bool IsItemExists(string selectedItem, string selectedUnit)
        {
            foreach (OrderItem item in order.OrderItems)
            {
                if (item.Item != null && item.Unit != null &&
                    item.Item.Equals(selectedItem) && item.Unit.Equals(selectedUnit))
                {
                    return true;
                }
            }
            return false;
        }


        private void UpdateExistingItem(string selectedItem, string selectedUnit, int quantity)
        {
            // Find and update the existing item in order.OrderItems
            foreach (OrderItem item in order.OrderItems)
            {
                if (item.Item.Equals(selectedItem) && item.Unit.Equals(selectedUnit))
                {
                    item.Quantity = Calculations.NewTotalQuantity(item.Quantity, quantity);
                    item.TotalPrice = Calculations.CalculateItemTotalPrice(item);

                    // Update the corresponding row in dataGridView1 manually
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        string dgvItem = row.Cells[ProductFields.Item].Value.ToString();
                        string dgvUnit = row.Cells[ProductFields.Unit].Value.ToString();

                        if (dgvItem.Equals(selectedItem) && dgvUnit.Equals(selectedUnit))
                        {
                            row.Cells[ProductFields.Quantity].Value = item.Quantity;
                            row.Cells[ProductFields.TotalPrice].Value = item.TotalPrice;
                            break;
                        }
                    }

                    break;
                }
            }
        }


        private void AddNewItem(string selectedItem, string selectedUnit, string category, int quantity)
        {
            double sellingPrice = 0.0;
            double totalPrice = 0.0;
            int productID = 0;

            foreach (Product p in productList)
            {
                if (p.Item.Equals(selectedItem))
                {
                    productID = p.ProductID;
                    sellingPrice = p.SellingPrice;
                    totalPrice = Calculations.CalculateItemTotalPrice(sellingPrice, quantity);
                    break;
                }
            }

            OrderItem newItem = new OrderItem(productID, selectedItem, category, selectedUnit, quantity, sellingPrice, totalPrice);
            order.OrderItems.Add(newItem);

            dataGridView1.Rows.Add(newItem.ProductID, newItem.Item, newItem.Categories, newItem.Unit, newItem.Quantity, newItem.SellingPrice, newItem.TotalPrice);

        }




        private void AddToCart(string selectedItem, string selectedUnit, string category, string quantityText)
        {
            if (int.TryParse(quantityText, out int quantity) && quantity > 0)
            {
                bool itemFound = IsItemExists(selectedItem, selectedUnit);

                if (itemFound)
                {
                    UpdateExistingItem(selectedItem, selectedUnit, quantity);
                }
                else
                {
                    AddNewItem(selectedItem, selectedUnit, category, quantity);
                }

                order.TotalPrice = Calculations.CalculateTotalPrice(order.OrderItems);
                totalPrice.Text = order.TotalPrice.ToString();
            }
            else
            {
                MessageBox.Show("Please enter a valid quantity.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DeleteItem(string selectedItem, string selectedUnit)
        {
            OrderItem itemToRemove = order.OrderItems.FirstOrDefault(item =>
                item.Item.Equals(selectedItem) && item.Unit.Equals(selectedUnit));

            if (itemToRemove != null)
            {
                order.OrderItems.Remove(itemToRemove);

                // Find the corresponding row in dataGridView1 and remove it
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        string dgvItem = row.Cells[ProductFields.Item].Value.ToString();
                        string dgvUnit = row.Cells[ProductFields.Unit].Value.ToString();

                        if (dgvItem.Equals(selectedItem) && dgvUnit.Equals(selectedUnit))
                        {
                            dataGridView1.Rows.Remove(row);
                            break;
                        }
                    }
                }
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0 && order.OrderItems.Count > 0)
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                    // Check if the row is new and uncommitted
                    if (!selectedRow.IsNewRow)
                    {
                        string selectedItem = selectedRow.Cells[ProductFields.Item].Value.ToString();
                        string selectedUnit = selectedRow.Cells[ProductFields.Unit].Value.ToString();

                        // Delete the selected item from order.OrderItems and dataGridView1
                        DeleteItem(selectedItem, selectedUnit);

                        // Update the total price
                        order.TotalPrice = Calculations.CalculateTotalPrice(order.OrderItems);
                        totalPrice.Text = order.TotalPrice.ToString();
                        dataGridView1.Refresh();
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



        private void btnAdd1_Click(object sender, EventArgs e)
        {
            string selectedItem = comboRice1.Text.Trim();
            string selectedUnit = comboRice3.Text.Trim();
            string category = ProductCategory.Rice;
            string quantityText = numericUpDown22.Text.Trim();

            AddToCart(selectedItem, selectedUnit, category, quantityText);
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            string selectedItem = comboWatr1.Text.Trim();
            string selectedUnit = comboWatr3.Text.Trim();
            string category = ProductCategory.Water;
            string quantityText = numericUpDown1.Text.Trim();

            AddToCart(selectedItem, selectedUnit, category, quantityText);
        }
        private void btnAdd3_Click(object sender, EventArgs e)
        {
            string selectedItem = comboDrinks1.Text.Trim();
            string selectedUnit = comboDrinks3.Text.Trim();
            string category = ProductCategory.Soft_Drinks;
            string quantityText = numericUpDown2.Text.Trim();

            AddToCart(selectedItem, selectedUnit, category, quantityText);
        }
        private void btnAdd4_Click(object sender, EventArgs e)
        {
            string selectedItem = cmbEmpe1.Text.Trim();
            string selectedUnit = cmbEmpe3.Text.Trim();
            string category = ProductCategory.Alcohol_Drinks;
            string quantityText = numericUpDown3.Text.Trim();

            AddToCart(selectedItem, selectedUnit, category, quantityText);
        }
        private void btnAdd6_Click(object sender, EventArgs e)
        {
            string selectedItem = cmbGoods1.Text.Trim();
            string selectedUnit = cmbGoods3.Text.Trim();
            string category = ProductCategory.Others;
            string quantityText = numericUpDown7.Text.Trim();

            AddToCart(selectedItem, selectedUnit, category, quantityText);
        }


        private void Exit11_Click(object sender, EventArgs e)
        {
            this.Close();
            StartingPoint backk = new StartingPoint();
            backk.Show();
        }
        
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(order.OrderItems.Count <= 0)
            {
                MessageBox.Show("You must add to cart atleast one item", "No Add to Cart Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PriorityNum num = new PriorityNum(order);
            num.Show();
            this.Hide();
        }


        //********************************************************* UI ONLY FUNCTIONS *************************************************************//
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

    }

}
