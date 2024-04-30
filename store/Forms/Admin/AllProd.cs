using store.Models;
using store.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;

namespace store
{
    public partial class AllProd : Form
    {
        private List<Product> productList = null;
        private ProductRepository productRepository = new ProductRepository();
      
        public AllProd()
        {
            InitializeComponent();

            InitializeDataGridView();
            PopulateDataGridView();

            dataGridView5.SelectionChanged += DataGridView5_SelectionChanged;
        }

        private void btnUpDate_Click(object sender, EventArgs e)
        {
            if (dataGridView5.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow selectedRow = dataGridView5.SelectedRows[0];
                    int productId = Convert.ToInt32(selectedRow.Cells["ProductID"].Value);

                    string itemName = txtSaleName.Text;
                    string unit = txtSaleUnit.Text;
                    double origPrice = Convert.ToDouble(
                        txtSaleOrg.Text
                            .Replace("$", "")
                            .Replace(",", "")
                            .Replace("₱", ""),
                        CultureInfo.InvariantCulture
                    );

                    double sellingPrice = Convert.ToDouble(
                        txtSaleSelling.Text
                            .Replace("$", "")
                            .Replace(",", "")
                            .Replace("₱", ""),
                        CultureInfo.InvariantCulture
                    );
                    double markup = Convert.ToDouble(
                        txtMarkUp.Text
                            .Replace("$", "")
                            .Replace(",", "")
                            .Replace("₱", ""),
                        CultureInfo.InvariantCulture
                    );

                    int stock = Convert.ToInt32(txtSaleStock.Text);
                    string categories = comboSaleCat.Text;
                    int itemSold = Convert.ToInt32(txtSold.Text);

                    Product updatedProduct = new Product(productId, itemName, unit, origPrice, sellingPrice, stock, categories, itemSold, markup);

                    bool success = productRepository.UpdateProduct(updatedProduct);

                    if (success)
                    {
                        MessageBox.Show("Product updated successfully.");
                        PopulateDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update product.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error updating product: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a product to update.");
            }
        }

        private void DataGridView5_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView5.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow selectedRow = dataGridView5.SelectedRows[0];

                    txtSaleName.Text = GetValueAsString(selectedRow.Cells["Item"]);
                    txtSaleUnit.Text = GetValueAsString(selectedRow.Cells["Unit"]);
                    txtSaleOrg.Text = GetValueAsString(selectedRow.Cells["OrigPrice"]);
                    txtSaleSelling.Text = GetValueAsString(selectedRow.Cells["SellingPrice"]);
                    txtSaleStock.Text = GetValueAsString(selectedRow.Cells["Stock"]);
                    comboSaleCat.Text = GetValueAsString(selectedRow.Cells["Categories"]);
                    txtSold.Text = GetValueAsString(selectedRow.Cells["ItemSold"]);
                    txtMarkUp.Text = GetValueAsString(selectedRow.Cells["MarkUp"]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        private string GetValueAsString(DataGridViewCell cell)
        {
            return cell.Value != null ? cell.Value.ToString() : "";
        }


        private void InitializeDataGridView()
        {
            dataGridView5.ColumnCount = 9;
            dataGridView5.Columns[0].Name = "ProductID";
            dataGridView5.Columns[1].Name = "Item";
            dataGridView5.Columns[2].Name = "Unit";
            dataGridView5.Columns[3].Name = "OrigPrice";
            dataGridView5.Columns[4].Name = "SellingPrice";
            dataGridView5.Columns[5].Name = "Stock";
            dataGridView5.Columns[6].Name = "Categories";
            dataGridView5.Columns[7].Name = "ItemSold";
            dataGridView5.Columns[8].Name = "MarkUp";
        }

        private void PopulateDataGridView()
        {

            productList = productRepository.GetAllProducts();

            dataGridView5.Rows.Clear();
            
            productList = productList.OrderBy(p => p.ProductID).ToList();

            foreach (Product product in productList)
            {
                dataGridView5.Rows.Add(
                    product.ProductID,
                    product.Item,
                    product.Unit,
                    product.OrigPrice.ToString("C"),
                    product.SellingPrice.ToString("C"),
                    product.Stock,
                    product.Categories,
                    product.ItemSold,
                    product.MarkUp.ToString("C")
                );
            }
        }
        
        private void buttonClear_Click(object sender, EventArgs e)
        {
            txtSaleName.Text = String.Empty;
            txtSaleUnit.Text = String.Empty;
            txtSaleStock.Text = String.Empty;
            txtSaleOrg.Text = String.Empty;
            txtSaleSelling.Text = String.Empty;
            comboSaleCat.Text = String.Empty;
            txtSold.Text = String.Empty;
            txtMarkUp.Text = String.Empty;
            

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

        private void Exit4_Click(object sender, EventArgs e)
        {

            Homepage hp = new Homepage();
            hp.Show();
            this.Hide();
        }

        private void AllProd_Load(object sender, EventArgs e)
        {

        }
    }
}
