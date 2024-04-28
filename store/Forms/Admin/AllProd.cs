using store.Models;
using store.Repositories;
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
        private List<Product> productList = null;
        private ProductRepository productRepository = new ProductRepository();
        public AllProd()
        {
            InitializeComponent();

            productList = productRepository.GetAllProducts();

            InitializeDataGridView();
            PopulateDataGridView();
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
            dataGridView5.Rows.Clear();
            
            productList = productList.OrderBy(p => p.ProductID).ToList();

            foreach (Product product in productList)
            {
                dataGridView5.Rows.Add(
                    product.ProductID,
                    product.Item,
                    product.Unit,
                    product.OrigPrice,
                    product.SellingPrice,
                    product.Stock,
                    product.Categories,
                    product.ItemSold,
                    product.MarkUp
                );
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView5.Rows[e.RowIndex];

            // Display employee details in textboxes
            /*
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
            */
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

        private void Exit4_Click(object sender, EventArgs e)
        {

            Homepage hp = new Homepage();
            hp.Show();
            this.Hide();
        }
    }
}
