using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace store
{
    public partial class EmployeeViews : Form
    {
        OleDbConnection myConn;
        OleDbCommand cmd;
        public EmployeeViews()
        {
            InitializeComponent();
            myConn = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=C:\\Users\\ll\\Desktop\\oop2week8\\store.mdb");
        }

        private void EmployeeViews_Load(object sender, EventArgs e)
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
            string query = "SELECT * FROM tblEmp";
            OleDbDataAdapter da = new OleDbDataAdapter(query, myConn);
            DataTable dt = new DataTable();

            // Fill the DataTable with data from the database
            da.Fill(dt);

            // Bind the DataTable to the DataGridView
            dataGridView2.DataSource = dt;


        }

        private void Exit5_Click(object sender, EventArgs e)
        {
            this.Close();
            Homepage Home = new Homepage();
            Home.Show();

        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView2.Rows.Count)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];

                // Display employee details in textboxes
                textID.Text = row.Cells["EmpID"].Value.ToString();
                textName.Text = row.Cells["EmpName"].Value.ToString();
                textPhone.Text = row.Cells["EmpPhone"].Value.ToString();
                textAdd.Text = row.Cells["EmpAddress"].Value.ToString();
                textPass.Text = row.Cells["EmpPass"].Value.ToString();

                // Display employee image in PictureBox
                byte[] imageData = (byte[])row.Cells["EmpImage"].Value;
                if (imageData != null && imageData.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        pictureBox4.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    // If no image available, clear the PictureBox
                    pictureBox4.Image = null;
                }
            }
        }
        private void btnUplaod_Click(object sender, EventArgs e)
        {

            try
            {
                using (OpenFileDialog filedialog = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
                {
                    if (filedialog.ShowDialog() == DialogResult.OK)
                    {
                        // Load the image from the file
                        Image image = Image.FromFile(filedialog.FileName);

                        // Check the orientation and rotate/flip if necessary
                        if (Array.IndexOf(image.PropertyIdList, 274) > -1)
                        {
                            var orientation = (int)image.GetPropertyItem(274).Value[0];
                            switch (orientation)
                            {
                                case 1:
                                    // No rotation required
                                    break;
                                case 2:
                                    image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                                    break;
                                case 3:
                                    image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                                    break;
                                case 4:
                                    image.RotateFlip(RotateFlipType.Rotate180FlipX);
                                    break;
                                case 5:
                                    image.RotateFlip(RotateFlipType.Rotate90FlipX);
                                    break;
                                case 6:
                                    image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                    break;
                                case 7:
                                    image.RotateFlip(RotateFlipType.Rotate270FlipX);
                                    break;
                                case 8:
                                    image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                                    break;
                            }
                        }

                        // Display the adjusted image in the PictureBox
                        pictureBox4.Image = image;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            /*
            try
            {
                using (OpenFileDialog filedialog = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
                {
                    if (filedialog.ShowDialog() == DialogResult.OK)
                    {
                        pictureBox4.Image = Image.FromFile(filedialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Image Uploaded Successfully!");
            }*/
        }
        private void RefreshDataGridView()
        {
            dataGridView2.DataSource = null;

            // Rebind the DataGridView to your data source
            string query = "SELECT * FROM tblEmp"; // Assuming tblEmp is your table name
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, myConn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;

        }
        private void UpdateDataGridView()
        {

            // Implement your logic to refresh the DataGridView with updated data
            // This can be similar to how you populated the DataGridView initially
            // For example:
            string query = "SELECT * FROM tblEmp"; // Assuming tblEmp is your table name
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, myConn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
        }
        private byte[] ConvertImageToByteArray(Image image)
        {
            if (image == null)
                return null;

            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Jpeg); // Change ImageFormat as needed
                return ms.ToArray();
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            byte[] imageData = ConvertImageToByteArray(pictureBox4.Image);

            // Your existing code to insert other employee details into the database...
            // Make sure to replace "EmpImage" with the actual column name for storing image data

            string query = "INSERT INTO tblEmp (EmpName, EmpPhone, EmpAddress, EmpPass, EmpImage) VALUES (@EmpName, @EmpPhone, @EmpAddress, @EmpPass, @EmpImage)";
            cmd = new OleDbCommand(query, myConn);
            cmd.Parameters.AddWithValue("@EmpName", textName.Text);
            cmd.Parameters.AddWithValue("@EmpPhone", textPhone.Text);
            cmd.Parameters.AddWithValue("@EmpAddress", textAdd.Text);
            cmd.Parameters.AddWithValue("@EmpPass", textPass.Text);
            cmd.Parameters.AddWithValue("@EmpImage", imageData); // Add image data parameter

            myConn.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            myConn.Close();

            if (rowsAffected > 0)
            {
                // Insertion successful, notify user
                MessageBox.Show("Data inserted successfully.");

                // Clear the PictureBox
                pictureBox4.Image = null;

                // Refresh the DataGridView to display the newly inserted information
                RefreshDataGridView();
            }
            else
            {
                // Insertion failed
                MessageBox.Show("Failed to insert data.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] imageData = ConvertImageToByteArray(pictureBox4.Image);
                string query = "UPDATE tblEmp SET EmpName=@EmpName, EmpPhone=@EmpPhone, EmpAddress=@EmpAddress, EmpPass=@EmpPass, EmpImage=@EmpImage WHERE EmpID=@ID";
                using (OleDbConnection myConn = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=C:\\Users\\ll\\Desktop\\oop2week8\\store.mdb"))
                {
                    using (OleDbCommand cmd = new OleDbCommand(query, myConn))
                    {
                        cmd.Parameters.AddWithValue("@EmpName", textName.Text);
                        cmd.Parameters.AddWithValue("@EmpPhone", textPhone.Text);
                        cmd.Parameters.AddWithValue("@EmpAddress", textAdd.Text);
                        cmd.Parameters.AddWithValue("@EmpPass", textPass.Text);
                        cmd.Parameters.AddWithValue("@EmpImage", imageData);
                        cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(textID.Text));

                        myConn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data updated successfully.");
                            UpdateDataGridView(); // Update the DataGridView if necessary
                        }
                        else
                        {
                            MessageBox.Show("No rows were updated. Check the provided EmpID.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating data: " + ex.Message);
            }
        }
        private int index;
        private void btnDel_Click(object sender, EventArgs e)
        {
            string query = "Delete From tblEmp Where EmpID = @ID";
            cmd = new OleDbCommand(query, myConn);
            cmd.Parameters.AddWithValue("@ID", dataGridView2.CurrentRow.Cells[0].Value);
            myConn.Open();
            cmd.ExecuteNonQuery();
            myConn.Close();
            index = dataGridView2.CurrentCell.RowIndex;
            dataGridView2.Rows.RemoveAt(index);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textID.Text = String.Empty;
            textName.Text = String.Empty;
            textPhone.Text = String.Empty;
            textAdd.Text = String.Empty;
            textPass.Text = String.Empty;
            pictureBox4.Image = null;
        }
        private void textID_Enter(object sender, EventArgs e)
        {
            if (textID.Text == "EmpID")
            {
                textID.Text = "";

                textID.ForeColor = Color.Black;
            }
        }
        private void textID_Leave(object sender, EventArgs e)
        {
            if (textID.Text == "")
            {
                textID.Text = "EmpID";

                textID.ForeColor = Color.Black;
            }
        }
        private void textName_Enter(object sender, EventArgs e)
        {
            if (textName.Text == "EmpName")
            {
                textName.Text = "";

                textName.ForeColor = Color.Black;
            }
        }
        private void textName_Leave(object sender, EventArgs e)
        {
            if (textName.Text == "")
            {
                textName.Text = "EmpName";

                textName.ForeColor = Color.Black;
            }
        }
        private void textPhone_Enter(object sender, EventArgs e)
        {
            if (textPhone.Text == "EmpPhone")
            {
                textPhone.Text = "";

                textPhone.ForeColor = Color.Black;
            }
        }
        private void textPhone_Leave(object sender, EventArgs e)
        {
            if (textPhone.Text == "")
            {
                textPhone.Text = "EmpPhone";

                textPhone.ForeColor = Color.Black;
            }
        }
        private void textPass_Enter(object sender, EventArgs e)
        {
            if (textPass.Text == "EmpPass")
            {
                textPass.Text = "";

                textPass.ForeColor = Color.Black;
            }
        }
        private void textPass_Leave(object sender, EventArgs e)
        {

            if (textPass.Text == "")
            {
                textPass.Text = "EmpPass";

                textPass.ForeColor = Color.Black;
            }
        }
        private void textAdd_Enter(object sender, EventArgs e)
        {
            if (textAdd.Text == "EmpAdd")
            {
                textAdd.Text = "";

                textAdd.ForeColor = Color.Black;
            }
        }
        private void textAdd_Leave(object sender, EventArgs e)
        {
            if (textAdd.Text == "")
            {
                textAdd.Text = "EmpAdd";

                textAdd.ForeColor = Color.Black;
            }
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
