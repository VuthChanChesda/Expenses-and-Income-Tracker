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
    public partial class Daskboard : UserControl
    {
        public Daskboard()
        {
            InitializeComponent();
        }

        private void Daskboard_Load(object sender, EventArgs e)
        {
            TodayIncome();
            YesterdayIncome();
            ThisMonthIncome();
            ThisYearIncome();

            TodayExpenses();
            YesterdayExpenses();
            ThisMonthExpenses();
            ThisYearExpenses();

            TotaleExpenses();
            TotalIncome();
        }

        public void TodayIncome()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UULUR2C\SQLEXPRESS;Initial Catalog=ExpenseAndIncomeManagementSystem;Integrated Security=True;");

            SqlDataAdapter da;
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select SUM(Income) as todayIncome from income where Date_income = @Date_income", con);

            // Add parameter values
            DateTime today = DateTime.Today; 
            da.SelectCommand.Parameters.AddWithValue("@Date_income", today);

            // Fill the DataTable
            da.Fill(dt);

            if (dt.Rows.Count > 0 && dt.Rows[0]["todayIncome"] != DBNull.Value)
            {
                labelTodayIncome.Text = $"{dt.Rows[0]["todayIncome"].ToString()} $";
            }
            else
            {
                labelTodayIncome.Text = "0.00 $";
            }

        }


        public void YesterdayIncome()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UULUR2C\SQLEXPRESS;Initial Catalog=ExpenseAndIncomeManagementSystem;Integrated Security=True;");

            SqlDataAdapter da;
            DataTable dt = new DataTable();

            // Date_income = TodayDayDate - 1 = yesterday
            da = new SqlDataAdapter("select SUM(Income) as YesIncome from income where CONVERT(Date, Date_income) = DATEADD(day, DATEDIFF(day,0, GETDATE()) , -1) ", con); 



            // Fill the DataTable
            da.Fill(dt);

            if (dt.Rows.Count > 0 && dt.Rows[0]["YesIncome"] != DBNull.Value)
            {
                labelYesIncome.Text = $"{dt.Rows[0]["YesIncome"].ToString()} $";
            }
            else
            {
                labelYesIncome.Text = "0.00 $";
            }

        }

        public void ThisMonthIncome()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UULUR2C\SQLEXPRESS;Initial Catalog=ExpenseAndIncomeManagementSystem;Integrated Security=True;");

            SqlDataAdapter da;
            DataTable dt = new DataTable();

            // SQL query to sum the income for the current month and year
            da = new SqlDataAdapter("select SUM(Income) as MonthIncome from income where DATEPART(month, Date_income) = DATEPART(month, GETDATE()) AND DATEPART(year, Date_income) = DATEPART(year, GETDATE())", con);

            // Fill the DataTable with the results of the SQL query
            da.Fill(dt);

            // Check if the DataTable has rows and the MonthIncome column is not DBNull
            if (dt.Rows.Count > 0 && dt.Rows[0]["MonthIncome"] != DBNull.Value)
            {
                // Set the label text to the sum of income for the current month
                labelMonthIncome.Text = $"{dt.Rows[0]["MonthIncome"].ToString()} $";
            }
            else
            {
                // If there is no income for the current month, set the label text to "0.00 $"
                labelMonthIncome.Text = "0.00 $";
            }
        }

        public void ThisYearIncome()
        {
            // Create a connection to the SQL Server database
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UULUR2C\SQLEXPRESS;Initial Catalog=ExpenseAndIncomeManagementSystem;Integrated Security=True;");

            // Create a SqlDataAdapter to execute the SQL query and fill the DataTable
            SqlDataAdapter da;
            DataTable dt = new DataTable();

            // SQL query to sum the income for the current year
            da = new SqlDataAdapter("select SUM(Income) as YearIncome from income where DATEPART(year, Date_income) = DATEPART(year, GETDATE())", con);

            // Fill the DataTable with the results of the SQL query
            da.Fill(dt);

            // Check if the DataTable has rows and the YearIncome column is not DBNull
            if (dt.Rows.Count > 0 && dt.Rows[0]["YearIncome"] != DBNull.Value)
            {
                // Set the label text to the sum of income for the current year
                labelYearIncome.Text = $"{dt.Rows[0]["YearIncome"].ToString()} $";
            }
            else
            {
                // If there is no income for the current year, set the label text to "0.00 $"
                labelYearIncome.Text = "0.00 $";
            }
        }



        public void TodayExpenses()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UULUR2C\SQLEXPRESS;Initial Catalog=ExpenseAndIncomeManagementSystem;Integrated Security=True;");

            SqlDataAdapter da;
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select SUM(Expense) as todayExpenses from expenses where Date_expenses = @Date_expenses", con);

            // Add parameter values
            DateTime today = DateTime.Today;
            da.SelectCommand.Parameters.AddWithValue("@Date_expenses", today);

            // Fill the DataTable
            da.Fill(dt);

            if (dt.Rows.Count > 0 && dt.Rows[0]["todayExpenses"] != DBNull.Value)
            {
                labelTodayExpenses.Text = $"{dt.Rows[0]["todayExpenses"].ToString()} $";
            }
            else
            {
                labelTodayExpenses.Text = "0.00 $";
            }

        }

        public void YesterdayExpenses()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UULUR2C\SQLEXPRESS;Initial Catalog=ExpenseAndIncomeManagementSystem;Integrated Security=True;");

            SqlDataAdapter da;
            DataTable dt = new DataTable();

            // Date_income = TodayDayDate - 1 = yesterday
            da = new SqlDataAdapter("select SUM(Expense) as YesExpenses from expenses where CONVERT(Date, Date_expenses) = DATEADD(day, DATEDIFF(day,0, GETDATE()) , -1) ", con);


            // Fill the DataTable
            da.Fill(dt);

            if (dt.Rows.Count > 0 && dt.Rows[0]["YesExpenses"] != DBNull.Value)
            {
                labelYesterdayExpenses.Text = $"{dt.Rows[0]["YesExpenses"].ToString()} $";
            }
            else
            {
                labelYesterdayExpenses.Text = "0.00 $";
            }

        }

        public void ThisMonthExpenses()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UULUR2C\SQLEXPRESS;Initial Catalog=ExpenseAndIncomeManagementSystem;Integrated Security=True;");

            SqlDataAdapter da;
            DataTable dt = new DataTable();

            // SQL query to sum the expenses for the current month and year

            da = new SqlDataAdapter("select SUM(Expense) as MonthExpenses from expenses where DATEPART(month, Date_expenses) = DATEPART(month, GETDATE()) AND DATEPART(year, Date_expenses) = DATEPART(year, GETDATE())", con);



            // Fill the DataTable
            da.Fill(dt);

            if (dt.Rows.Count > 0 && dt.Rows[0]["MonthExpenses"] != DBNull.Value)
            {
                labelMonthExpenses.Text = $"{dt.Rows[0]["MonthExpenses"].ToString()} $";
            }
            else
            {
                labelMonthExpenses.Text = "0.00 $";
            }

        }

        public void ThisYearExpenses()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UULUR2C\SQLEXPRESS;Initial Catalog=ExpenseAndIncomeManagementSystem;Integrated Security=True;");

            // Create a SqlDataAdapter to execute the SQL query and fill the DataTable
            SqlDataAdapter da;
            DataTable dt = new DataTable();

            // SQL query to sum the expenses for the current year
            da = new SqlDataAdapter("select SUM(Expense) as YearExpenses from expenses where DATEPART(year, Date_expenses) = DATEPART(year, GETDATE())", con);

            // Fill the DataTable with the results of the SQL query
            da.Fill(dt);

            // Check if the DataTable has rows and the YearExpenses column is not DBNull
            if (dt.Rows.Count > 0 && dt.Rows[0]["YearExpenses"] != DBNull.Value)
            {
                // Set the label text to the sum of expenses for the current year
                labelYearExpenses.Text = $"{dt.Rows[0]["YearExpenses"].ToString()} $";
            }
            else
            {
                // If there are no expenses for the current year, set the label text to "0.00 $"
                labelYearExpenses.Text = "0.00 $";
            }
        }


        public void TotalIncome()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UULUR2C\SQLEXPRESS;Initial Catalog=ExpenseAndIncomeManagementSystem;Integrated Security=True;");

            SqlDataAdapter da;
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select SUM(Income) as TotalIncome from income", con);


            // Fill the DataTable
            da.Fill(dt);

            if (dt.Rows.Count > 0 && dt.Rows[0]["TotalIncome"] != DBNull.Value)
            {
                labelTotalIncome.Text = $"{dt.Rows[0]["TotalIncome"].ToString()} $";
            }
            else
            {
                labelTotalIncome.Text = "0.00 $";
            }

        }

        public void TotaleExpenses()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UULUR2C\SQLEXPRESS;Initial Catalog=ExpenseAndIncomeManagementSystem;Integrated Security=True;");

            SqlDataAdapter da;
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select SUM(Expense) as totalExpenses from expenses", con);


            // Fill the DataTable
            da.Fill(dt);

            if (dt.Rows.Count > 0 && dt.Rows[0]["totalExpenses"] != DBNull.Value)
            {
                labelTotalExpenses.Text = $"{dt.Rows[0]["totalExpenses"].ToString()} $";
            }
            else
            {
                labelTotalExpenses.Text = "0.00 $";
            }

        }
    }
}
