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
    public partial class Expenses : UserControl
    {
        public event EventHandler ExpensesAdd;
        public event EventHandler ExpensesUpdate;
        public event EventHandler ExpensesDelete;

        public Expenses()
        {
            InitializeComponent();
        }

        private void Expenses_Load(object sender, EventArgs e)
        {
            BindDatagridview();
            BindCategoryToCBB();
        }

        public void BindDatagridview()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UULUR2C\SQLEXPRESS;Initial Catalog=ExpenseAndIncomeManagementSystem;Integrated Security=True;");
            SqlDataAdapter da;
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("GetViewExpensesWithCategories", con);
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
            da.SelectCommand.Parameters.AddWithValue("@Type", "Expenses");
            da.SelectCommand.Parameters.AddWithValue("@Status", "Active");

            da.Fill(dt);
            CBBCategory.DataSource = dt;
            CBBCategory.DisplayMember = "category";
            CBBCategory.ValueMember = "ID";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtDescription.Text) || String.IsNullOrEmpty(txtExpenses.Text) || String.IsNullOrEmpty(txtItem.Text) || CBBCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UULUR2C\SQLEXPRESS;Initial Catalog=ExpenseAndIncomeManagementSystem;Integrated Security=True;");
                SqlCommand add = new SqlCommand("InsertExpense", con);
                add.CommandType = CommandType.StoredProcedure;
                add.Parameters.AddWithValue("@Category", CBBCategory.SelectedValue);
                add.Parameters.AddWithValue("@Item", txtItem.Text);
                add.Parameters.AddWithValue("@Expense", txtExpenses.Text);
                add.Parameters.AddWithValue("@Description", txtDescription.Text);
                add.Parameters.AddWithValue("@Date_expenses", DTPIncome.Value);
                con.Open();
                add.ExecuteNonQuery();
                con.Close();
                con.Dispose();
                BindDatagridview();
                MessageBox.Show("Add new Expenses Successfuly", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                ExpensesAdd?.Invoke(this, EventArgs.Empty);

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
                if (MessageBox.Show($"Are you sure you want to update this Income ID {GetID}?", "Update Expnenses", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UULUR2C\SQLEXPRESS;Initial Catalog=ExpenseAndIncomeManagementSystem;Integrated Security=True;");
                    SqlCommand update = new SqlCommand("[UpdateExpenses]", con);
                    update.CommandType = CommandType.StoredProcedure;
                    // Add parameters for the stored procedure
                    update.Parameters.AddWithValue("@ID", GetID);
                    update.Parameters.AddWithValue("@Category", CBBCategory.SelectedValue);
                    update.Parameters.AddWithValue("@Item", txtItem.Text);
                    update.Parameters.AddWithValue("@Expense", txtExpenses.Text);
                    update.Parameters.AddWithValue("@Description", txtDescription.Text);
                    update.Parameters.AddWithValue("@Date_Expenses", DTPIncome.Value);
                    update.Parameters.AddWithValue("@Date_insert", DateTime.Now);
                    con.Open();
                    update.ExecuteNonQuery();
                    con.Close();
                    con.Dispose();
                    BindDatagridview();
                    MessageBox.Show("Expenses updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    ExpensesUpdate?.Invoke(this, EventArgs.Empty);

                }


            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (GetID == 0)
            {
                MessageBox.Show("please select Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show($"Are you sure you want to Delete this Expenses ID {GetID}?", "Update Income", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UULUR2C\SQLEXPRESS;Initial Catalog=ExpenseAndIncomeManagementSystem;Integrated Security=True;");
                    SqlCommand delete = new SqlCommand("DeleteExpense", con);
                    delete.CommandType = CommandType.StoredProcedure;
                    delete.Parameters.AddWithValue("@GetID", GetID);
                    con.Open();
                    delete.ExecuteNonQuery();
                    con.Close();
                    con.Dispose();
                    BindDatagridview();
                    MessageBox.Show($"Delete ID: {GetID} successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    ExpensesDelete?.Invoke(this, EventArgs.Empty);

                }

            }




        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private int GetID = 0;

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                GetID = Convert.ToInt32(row.Cells[0].Value);
                CBBCategory.SelectedValue = row.Cells[7].Value.ToString();
                txtItem.Text = row.Cells[2].Value.ToString();
                txtExpenses.Text = row.Cells[3].Value.ToString();
                txtDescription.Text = row.Cells[4].Value.ToString();
                DTPIncome.Value = Convert.ToDateTime(row.Cells[5].Value);
            }
            else
            {
                // for empty row
                return;
            }
        }

        private void Clear()
        {
            CBBCategory.SelectedIndex = -1;
            txtItem.Text = "";
            txtExpenses.Text = "";
            txtDescription.Text = "";
            DTPIncome.Value = DateTime.Now;
            GetID = 0;


        }
    }
    
}
