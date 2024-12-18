using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Expenses_and_Income_tracker
{
    public partial class MainForm : Form
    {

        private Button activeButton;
        private Color normalColor = Color.CadetBlue;
        private Color activeColor = Color.White;
        private Color fontColor = Color.Black;



        public MainForm()
        {
            InitializeComponent();
            category_1_Form1.CategoryAdded += CategoryForm_CategoryChanged;
            category_1_Form1.CategoryUpdated += CategoryForm_CategoryChanged;
            category_1_Form1.CategoryDeleted += CategoryForm_CategoryChanged;
            
            income1.IncomeAdd += IncomeForm_IncomeChanged;
            income1.IncomeUpdate += IncomeForm_IncomeChanged;
            income1.IncomeDelete += IncomeForm_IncomeChanged;

            expenses1.ExpensesAdd += ExpensesForm_IncomeChanged;
            expenses1.ExpensesUpdate += ExpensesForm_IncomeChanged;
            expenses1.ExpensesDelete += ExpensesForm_IncomeChanged;


        }



        private void button4_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to log out?", "Conformation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                Form1 login = new Form1();
                login.Show();
                
            }
        }

    

        private void btnDaskboard_Click(object sender, EventArgs e)
        {
            SetActiveButton((Button)sender);

            category_1_Form1.Visible = false;
            daskboard1.Visible = true;
            income1.Visible = false;
            expenses1.Visible = false;


        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetActiveButton(btnDaskboard);

            category_1_Form1.Visible = false;
            daskboard1.Visible = true;
            income1.Visible = false;
            expenses1.Visible = false;


        }



        private void btnCategory_Click(object sender, EventArgs e)
        {
            SetActiveButton((Button)sender);

            category_1_Form1.Visible = true;
            daskboard1.Visible = false;
            income1.Visible = false;
            expenses1.Visible = false;



        }

        private void btnincome_Click(object sender, EventArgs e)
        {
            SetActiveButton((Button)sender);

            category_1_Form1.Visible = false;
            daskboard1.Visible = false;
            income1.Visible = true;
            expenses1.Visible = false;

        }

        private void SetActiveButton(Button button)
        {
            if (activeButton != null)
            {
                activeButton.BackColor = normalColor;
            }

            activeButton = button;
            activeButton.BackColor = activeColor;
            activeButton.ForeColor = fontColor;
        }

        private void CategoryForm_CategoryChanged(object sender, EventArgs e)
        {
            // Refresh the CBBCategory combo box in the income1  and expenses user control
            income1.BindCategoryToCBB();
            expenses1.BindCategoryToCBB();
        }

        private void IncomeForm_IncomeChanged(object sender, EventArgs e)
        {
            // Refresh the income datagridview in the daskboard user control
            daskboard1.TodayIncome();
            daskboard1.YesterdayIncome();
            daskboard1.TotalIncome();
            daskboard1.ThisMonthIncome();
            daskboard1.ThisYearIncome();

        }

        private void ExpensesForm_IncomeChanged(object sender, EventArgs e)
        {
            // Refresh the income datagridview in the daskboard user control
            daskboard1.TodayExpenses();
            daskboard1.TotaleExpenses();
            daskboard1.YesterdayExpenses();
            daskboard1.ThisMonthExpenses();
            daskboard1.ThisYearExpenses();

        }

        private void btnExpenses_Click(object sender, EventArgs e)
        {
            SetActiveButton((Button)sender);

            expenses1.Visible = true;
            category_1_Form1.Visible = false;
            daskboard1.Visible = false;
            income1.Visible = false;

        }

    }
    
}
