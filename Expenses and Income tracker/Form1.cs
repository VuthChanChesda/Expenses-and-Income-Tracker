using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Expenses_and_Income_tracker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSignUP_Click(object sender, EventArgs e)
        {
            RegisterForm Register = new RegisterForm();
            Register.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUserName.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please fill all the fields");
                return;
            }

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UULUR2C\SQLEXPRESS;Initial Catalog=ExpenseAndIncomeManagementSystem;Integrated Security=True;");

            SqlCommand sc = new SqlCommand("SELECT [UserName],[Passwords] FROM [dbo].[users] where UserName = @UserName and Passwords = @Password" , con);
            sc.Parameters.AddWithValue("@UserName", txtUserName.Text);
            sc.Parameters.AddWithValue("@Password", txtPassword.Text);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sc);
            DataSet dataset1 = new System.Data.DataSet();
            dataAdapter.Fill(dataset1);
            DataTable DTable1 = new DataTable();
            DTable1 = dataset1.Tables[0];

            if (DTable1.Rows.Count > 0)
            {
                MessageBox.Show("Login Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainForm mainform = new MainForm();
                mainform.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Invalid Username or Password", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = checkBox1.Checked ? '\0' : '*'; // if it check = number if not = *
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
