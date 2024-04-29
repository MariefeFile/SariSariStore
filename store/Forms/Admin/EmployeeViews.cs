using store.Models;
using store.Repositories;
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
        private List<User> userList = null;
        private UserRepository userRepository = new UserRepository();
        public EmployeeViews()
        {
            InitializeComponent();

            userList = userRepository.GetAllEmployee();

            InitializeDataGridView();
            PopulateDataGridView();
        }

        private void PopulateDataGridView()
        {

            userList = userRepository.GetAllEmployee();
            dataGridView2.Rows.Clear();

            foreach (User user in userList)
            {
                dataGridView2.Rows.Add(
                    user.UserID,
                    user.UserName,
                    user.UserPhone,
                    user.UserAddress,
                    user.UserPassword
                );
            }
        }



        private void InitializeDataGridView()
        {
            
            dataGridView2.Columns.Add("UserID", "User ID");
            dataGridView2.Columns.Add("UserName", "UserName");
            dataGridView2.Columns.Add("UserPhone", "Phone");
            dataGridView2.Columns.Add("UserAddress", "Address");
            dataGridView2.Columns.Add("UserPassword", "Password");
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
            /*
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
            */
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
        private void Exit5_Click(object sender, EventArgs e)
        {
            this.Close();
            Homepage Home = new Homepage();
            Home.Show();

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
    }
}
