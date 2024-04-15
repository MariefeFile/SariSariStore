using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace store
{
    public partial class EmployeeViews : Form
    {
        OleDbConnection myConn;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;
        int indexRow;
        public EmployeeViews()
        {
            InitializeComponent();
            myConn = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=C:\\Users\\ll\\Desktop\\oop2week8\\LOG_in.mdb");
        }

       

        private void btnBack4_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Sign_in back2 = new Sign_in();
            back2.Show();
        }

        private void btnProds_Click(object sender, EventArgs e)
        {
           
            groupProds.Visible = true;
            groupIncome.Visible = false;
            myConn = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=C:\\Users\\ll\\Desktop\\oop2week8\\\\LOG_in.mdb");
           
                //or da = newOleDbDataAdapter("SELECT Student.Lastname, Student.FirstName,
                //Student.Course, SubjectsEnrolled.* FinalGrade.StudentID\r\nFrom (Student
                //INNER JOIN SubjectsEnrolled ON Student.StudentID =
                //SubjectsEnrolled.StudentID) INNER JOIN FinalGrade ON Student.StudentID =
                //FinalGrade.Student", myConn);
                da = new OleDbDataAdapter("SELECT *FROM Productss", myConn);

            ds = new DataSet();
            myConn.Open();
            da.Fill(ds, "Productss");
            dataGridView1.DataSource = ds.Tables["Productss"];
            myConn.Close();

        }

        private void btnIncome_Click(object sender, EventArgs e)
        {
            groupIncome.Location = groupProds.Location;
            groupProds.Visible = false;
            groupIncome.Visible = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
