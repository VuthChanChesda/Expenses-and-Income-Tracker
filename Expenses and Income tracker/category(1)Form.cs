using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Expenses_and_Income_tracker
{
    public partial class category_1_Form : UserControl
    {
        public event EventHandler CategoryAdded;
        public event EventHandler CategoryUpdated;
        public event EventHandler CategoryDeleted;

        public category_1_Form()
        {
            InitializeComponent();
        }

        void BindcategroyDataGridView()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UULUR2C\SQLEXPRESS;Initial Catalog=ExpenseAndIncomeManagementSystem;Integrated Security=True;");

            SqlDataAdapter da;
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select * from categories", con);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void category_1_Form_Load(object sender, EventArgs e)
        {
            BindcategroyDataGridView();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(txtCategory.Text) || String.IsNullOrEmpty(CBBStatus.Text) || String.IsNullOrEmpty(CBBType.Text))
            {
                MessageBox.Show("Please fill all the fields" , "Error" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else {
              
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UULUR2C\SQLEXPRESS;Initial Catalog=ExpenseAndIncomeManagementSystem;Integrated Security=True;");
                SqlCommand add = new SqlCommand("Proc_InsertCategory", con);
                add.CommandType = CommandType.StoredProcedure;
                add.Parameters.AddWithValue("@Category", txtCategory.Text);
                add.Parameters.AddWithValue("@Status", CBBStatus.Text);
                add.Parameters.AddWithValue("@Type", CBBType.Text);
                con.Open();
                add.ExecuteNonQuery();
                con.Close();
                con.Dispose();
                BindcategroyDataGridView();
                MessageBox.Show("Add new Category Successfuly", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                CategoryAdded?.Invoke(this, EventArgs.Empty);



            }

        }


        private int getID = 0;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                getID = Convert.ToInt32(row.Cells[0].Value);
                txtCategory.Text = row.Cells[1].Value.ToString();
                CBBStatus.Text = row.Cells[2].Value.ToString();
                CBBType.Text = row.Cells[4].Value.ToString();
            }
            else
            {
                //for empty row
                return;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtCategory.Text) || String.IsNullOrEmpty(CBBStatus.Text) || String.IsNullOrEmpty(CBBType.Text))
            {
                MessageBox.Show("Please fill all the fields", "Error" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if(MessageBox.Show($"Are you sure you want to update this category ID {getID}?", "Update Category", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UULUR2C\SQLEXPRESS;Initial Catalog=ExpenseAndIncomeManagementSystem;Integrated Security=True;");
                    SqlCommand update = new SqlCommand("UpdateCategory", con);
                    update.CommandType = CommandType.StoredProcedure;
                    update.Parameters.AddWithValue("@ID", getID);
                    update.Parameters.AddWithValue("@Category", txtCategory.Text);
                    update.Parameters.AddWithValue("@Status", CBBStatus.Text);
                    update.Parameters.AddWithValue("@Type", CBBType.Text);
                    con.Open();
                    update.ExecuteNonQuery();
                    con.Close();
                    con.Dispose();
                    BindcategroyDataGridView();
                    MessageBox.Show("Update Category Successfuly", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    CategoryUpdated?.Invoke(this, EventArgs.Empty); 

                }

            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (getID == 0)
            {
                MessageBox.Show("Please select a category to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (MessageBox.Show($"Are you sure you want to delete this category ID {getID}?", "Delete Category", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UULUR2C\SQLEXPRESS;Initial Catalog=ExpenseAndIncomeManagementSystem;Integrated Security=True;");
                        SqlCommand delete = new SqlCommand("DeleteCategory", con);
                        delete.CommandType = CommandType.StoredProcedure;

                        delete.Parameters.AddWithValue("@ID", getID);
                        con.Open();
                        delete.ExecuteNonQuery();
                        con.Close();
                        con.Dispose();
                        BindcategroyDataGridView();
                        MessageBox.Show("Delete Category Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                        // Trigger the CategoryDeleted event
                        CategoryDeleted?.Invoke(this, EventArgs.Empty);
                    }
                    catch (SqlException ex)
                    {
                        // Check if the error number corresponds to a foreign key constraint violation
                        if (ex.Number == 547) // 547 is the error number for foreign key constraint violation
                        {
                            MessageBox.Show("Cannot delete this category because it is referenced by other records. Please delete the related records first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            // Handle other SQL exceptions
                            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void Clear ()
        {
            txtCategory.Text = "";
            CBBStatus.Text = "";
            CBBType.Text = "";
            getID = 0;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();  
        }
    }
}
