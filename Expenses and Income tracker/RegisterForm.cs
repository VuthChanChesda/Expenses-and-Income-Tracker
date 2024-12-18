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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = checkBox1.Checked ? '\0' : '*'; // if it check = number if not = *
            txtConformPassword.PasswordChar = checkBox1.Checked ? '\0' : '*'; // if it check = number if not = *
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {

            if(txtUserName.Text == "" || txtPassword.Text == "" || txtConformPassword.Text == "")
            {
                MessageBox.Show("Please fill all the fields");
                return;
            }

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UULUR2C\SQLEXPRESS;Initial Catalog=ExpenseAndIncomeManagementSystem;Integrated Security=True;");
            con.Open();
            SqlCommand sc = new SqlCommand("SELECT [UserName],[Passwords] FROM [dbo].[users] where UserName = @UserName", con);
            sc.Parameters.AddWithValue("@UserName", txtUserName.Text);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sc);
            DataSet dataset1 = new System.Data.DataSet();
            dataAdapter.Fill(dataset1);
            DataTable DTable1 = new DataTable();
            DTable1 = dataset1.Tables[0];

            if (DTable1.Rows.Count > 0)
            {
                MessageBox.Show($"Username '{txtUserName.Text}' already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                con.Close();
            }
            else
            {
                if(txtPassword.Text == txtConformPassword.Text)
                {           
                    SqlCommand cmd = new SqlCommand("INSERT INTO Users (UserName, Passwords) VALUES (@Username, @Password)", con);
                    cmd.Parameters.AddWithValue("@Username", txtUserName.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    con.Dispose();
                    MessageBox.Show("User Registered Successfully" , "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Passwords do not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
