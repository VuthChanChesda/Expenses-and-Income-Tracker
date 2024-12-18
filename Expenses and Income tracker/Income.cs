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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Expenses_and_Income_tracker
{
    public partial class Income : UserControl
    {
        public event EventHandler IncomeAdd;
        public event EventHandler IncomeUpdate;
        public event EventHandler IncomeDelete;

        public Income()
        {
            InitializeComponent();
        }

        private void Income_Load(object sender, EventArgs e)
        {
            BindCategoryToCBB();
            BindDatagridview();
        }

        private void BindDatagridview()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UULUR2C\SQLEXPRESS;Initial Catalog=ExpenseAndIncomeManagementSystem;Integrated Security=True;");
            SqlDataAdapter da;
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("GetViewIncomeWithCategories", con);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        public void BindCategoryToCBB()
        {

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UULUR2C\SQLEXPRESS;Initial Catalog=ExpenseAndIncomeManagementSystem;Integrated Security=True;");

            SqlDataAdapter da;
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select category, ID from categories where Type = @Type and Status = @Status", con);

            // Add parameter values
            da.SelectCommand.Parameters.AddWithValue("@Type", "Income");
            da.SelectCommand.Parameters.AddWithValue("@Status", "Active");

            da.Fill(dt);
            CBBCategory.DataSource = dt;
            CBBCategory.DisplayMember = "category";
            CBBCategory.ValueMember = "ID"; 
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(txtDescription.Text) || String.IsNullOrEmpty(txtIncome.Text) || String.IsNullOrEmpty(txtItem.Text) || CBBCategory.SelectedIndex == -1)           
            {
                MessageBox.Show("Please fill all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UULUR2C\SQLEXPRESS;Initial Catalog=ExpenseAndIncomeManagementSystem;Integrated Security=True;");
                SqlCommand add = new SqlCommand("InsertIncome", con);
                add.CommandType = CommandType.StoredProcedure;
                add.Parameters.AddWithValue("@CategoryID", CBBCategory.SelectedValue);
                add.Parameters.AddWithValue("@Item", txtItem.Text);
                add.Parameters.AddWithValue("@Income", txtIncome.Text);
                add.Parameters.AddWithValue("@Description", txtDescription.Text);
                add.Parameters.AddWithValue("@DateIncome", DTPIncome.Value);
                con.Open();
                add.ExecuteNonQuery();
                con.Close();
                con.Dispose();
                BindDatagridview();
                MessageBox.Show("Add new Income Successfuly", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                IncomeAdd?.Invoke(this, EventArgs.Empty);

            }


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (GetID == 0)
            {
                MessageBox.Show("Please select data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show($"Are you sure you want to update this Income ID {GetID}?", "Update Income", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UULUR2C\SQLEXPRESS;Initial Catalog=ExpenseAndIncomeManagementSystem;Integrated Security=True;");
                    SqlCommand update = new SqlCommand("UpdateIncome", con);
                    update.CommandType = CommandType.StoredProcedure;
                    // Add parameters for the stored procedure
                    update.Parameters.AddWithValue("@ID", GetID);
                    update.Parameters.AddWithValue("@CategoryID", CBBCategory.SelectedValue);
                    update.Parameters.AddWithValue("@Item", txtItem.Text);
                    update.Parameters.AddWithValue("@Income", txtIncome.Text);
                    update.Parameters.AddWithValue("@Description", txtDescription.Text);
                    update.Parameters.AddWithValue("@Date_income", DTPIncome.Value);
                    update.Parameters.AddWithValue("@Date_insert", DateTime.Now);
                    con.Open();
                    update.ExecuteNonQuery();
                    con.Close();
                    con.Dispose();
                    BindDatagridview();
                    MessageBox.Show("Income updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    IncomeUpdate?.Invoke(this, EventArgs.Empty);

                }


            }



        }

        private int GetID = 0;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                if (row.Cells[0].Value != null && row.Cells[0].Value != DBNull.Value)
                {
                    GetID = Convert.ToInt32(row.Cells[0].Value);
                    CBBCategory.SelectedValue = row.Cells[7].Value.ToString();
                    txtItem.Text = row.Cells[2].Value.ToString();
                    txtIncome.Text = row.Cells[3].Value.ToString();
                    txtDescription.Text = row.Cells[4].Value.ToString();
                    DTPIncome.Value = Convert.ToDateTime(row.Cells[5].Value);
                }
                else
                {
                    //for empty row
                    return;
                }
            }
        }

        private void Clear()
        {
            CBBCategory.SelectedIndex = -1;
            txtItem.Text = "";
            txtIncome.Text = "";
            txtDescription.Text = "";
            DTPIncome.Value = DateTime.Now;
            GetID = 0;


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(GetID == 0)
            {
                MessageBox.Show("please select Data" , "Error" , MessageBoxButtons.OK , MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show($"Are you sure you want to Delete this Income ID {GetID}?", "Update Income", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UULUR2C\SQLEXPRESS;Initial Catalog=ExpenseAndIncomeManagementSystem;Integrated Security=True;");
                    SqlCommand delete = new SqlCommand("DeleteIncome", con);
                    delete.CommandType = CommandType.StoredProcedure;
                    delete.Parameters.AddWithValue("@GetID", GetID);
                    con.Open();
                    delete.ExecuteNonQuery();
                    con.Close();
                    con.Dispose();
                    BindDatagridview();
                    MessageBox.Show($"Delete ID: {GetID} successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    IncomeDelete?.Invoke(this, EventArgs.Empty);

                }

            }




        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
    
}
