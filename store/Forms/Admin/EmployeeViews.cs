using store.Constants.Users;
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

            dataGridView2.SelectionChanged += DataGridView2_SelectionChanged;
        }
        private bool ValidateInputFields()
        {
            if (string.IsNullOrWhiteSpace(textName.Text) || string.IsNullOrWhiteSpace(textPass.Text) ||
                string.IsNullOrWhiteSpace(textAdd.Text) || string.IsNullOrWhiteSpace(textPhone.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textName.Text = string.Empty;
            textPhone.Text = string.Empty;
            textAdd.Text = string.Empty;
            textPass.Text = string.Empty;
            pictureBox4.Image = null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
                {
                if (!ValidateInputFields())
                {
                    return; 
                }

                User newUser = new User
                {
                    UserName = textName.Text,
                    UserPassword = textPass.Text,
                    UserAddress = textAdd.Text,
                    UserPhone = Convert.ToInt32(textPhone.Text),
                    UserType = UserTypes.Employee,
                };

                bool added = userRepository.AddUser(newUser);

                if (added)
                {
                    MessageBox.Show("User added successfully.");
                    PopulateDataGridView(); 
                }
                else
                {
                    MessageBox.Show("Failed to add user.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Warning: " + ex.Message);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];
                int userID = Convert.ToInt32(selectedRow.Cells["UserID"].Value);

                bool deleted = userRepository.DeleteUser(userID);

                if (deleted)
                {
                    MessageBox.Show("User deleted successfully.");
                    PopulateDataGridView();
                }
                else
                {
                    MessageBox.Show("Failed to delete user.");
                }
            }
            else
            {
                MessageBox.Show("Please select a user to delete.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                try
                {

                    if (!ValidateInputFields())
                    {
                        return;
                    }

                    DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];
                    int userID = Convert.ToInt32(selectedRow.Cells["UserID"].Value);
                    User selectedUser = userList.FirstOrDefault(user => user.UserID == userID);

                    if (selectedUser != null)
                    {
                        selectedUser.UserName = textName.Text;
                        selectedUser.UserPhone = Convert.ToInt32(textPhone.Text);
                        selectedUser.UserAddress = textAdd.Text;
                        selectedUser.UserPassword = textPass.Text;

                        bool updated = userRepository.UpdateUser(selectedUser);
                        if (updated)
                        {
                            MessageBox.Show("User updated successfully.");
                            PopulateDataGridView();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update user.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        private void DataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];

                    int userID = Convert.ToInt32(selectedRow.Cells["UserID"].Value);
                    User selectedUser = userList.FirstOrDefault(user => user.UserID == userID);

                    if (selectedUser != null && selectedUser.UserImage != null && selectedUser.UserImage.Length > 0)
                    {
                        using (MemoryStream stream = new MemoryStream(selectedUser.UserImage))
                        {
                            pictureBox4.Image = Image.FromStream(stream);
                        }
                    }

                    else
                    {
                        pictureBox4.Image = null; 
                    }

                    textName.Text = GetValueAsString(selectedRow.Cells["UserName"]);
                    textPhone.Text = GetValueAsString(selectedRow.Cells["UserPhone"]);
                    textPass.Text = GetValueAsString(selectedRow.Cells["UserPassword"]);
                    textAdd.Text = GetValueAsString(selectedRow.Cells["UserAddress"]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }


        private string GetValueAsString(DataGridViewCell cell)
        {
            return cell.Value?.ToString() ?? string.Empty;
        }


        private void PopulateDataGridView()
        {
            userList = userRepository.GetAllEmployee();

            userList = userList.OrderBy(user => user.UserID).ToList();

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
                        string filePath = filedialog.FileName;
                        Image image = LoadAndAdjustImage(filePath);

                        if (image != null)
                        {
                            pictureBox4.Image = image;
                            UpdateUserImage(image);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private Image LoadAndAdjustImage(string filePath)
        {
            Image image = Image.FromFile(filePath);

            if (Array.IndexOf(image.PropertyIdList, 274) > -1)
            {
                int orientation = (int)image.GetPropertyItem(274).Value[0];
                switch (orientation)
                {
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

            return image;
        }

        private void UpdateUserImage(Image image)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];
                int userID = Convert.ToInt32(selectedRow.Cells["UserID"].Value);
                User selectedUser = userList.FirstOrDefault(user => user.UserID == userID);

                if (selectedUser != null)
                {
                    selectedUser.UserImage = ImageToByteArray(image);
                }
            }
        }

        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                return stream.ToArray();
            }
        }



        private void btnClear_Click(object sender, EventArgs e)
        {
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
       
    }
}
