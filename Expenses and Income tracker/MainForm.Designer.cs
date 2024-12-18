namespace Expenses_and_Income_tracker
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.btnincome = new System.Windows.Forms.Button();
            this.btnExpenses = new System.Windows.Forms.Button();
            this.btnCategory = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnDaskboard = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.daskboard1 = new Expenses_and_Income_tracker.Daskboard();
            this.expenses1 = new Expenses_and_Income_tracker.Expenses();
            this.income1 = new Expenses_and_Income_tracker.Income();
            this.category_1_Form1 = new Expenses_and_Income_tracker.category_1_Form();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1297, 39);
            this.panel2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(26, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Income and Expenses Tracker";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CadetBlue;
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.btnincome);
            this.panel1.Controls.Add(this.btnExpenses);
            this.panel1.Controls.Add(this.btnCategory);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnDaskboard);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(289, 527);
            this.panel1.TabIndex = 3;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.CadetBlue;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.CadetBlue;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button4.Location = new System.Drawing.Point(30, 476);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(235, 39);
            this.button4.TabIndex = 15;
            this.button4.Text = "Logout";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnincome
            // 
            this.btnincome.BackColor = System.Drawing.Color.CadetBlue;
            this.btnincome.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.btnincome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnincome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnincome.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnincome.Location = new System.Drawing.Point(12, 315);
            this.btnincome.Name = "btnincome";
            this.btnincome.Size = new System.Drawing.Size(259, 39);
            this.btnincome.TabIndex = 14;
            this.btnincome.Text = "Income";
            this.btnincome.UseVisualStyleBackColor = false;
            this.btnincome.Click += new System.EventHandler(this.btnincome_Click);
            // 
            // btnExpenses
            // 
            this.btnExpenses.BackColor = System.Drawing.Color.CadetBlue;
            this.btnExpenses.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.btnExpenses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpenses.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpenses.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnExpenses.Location = new System.Drawing.Point(12, 369);
            this.btnExpenses.Name = "btnExpenses";
            this.btnExpenses.Size = new System.Drawing.Size(259, 39);
            this.btnExpenses.TabIndex = 13;
            this.btnExpenses.Text = "Expenses";
            this.btnExpenses.UseVisualStyleBackColor = false;
            this.btnExpenses.Click += new System.EventHandler(this.btnExpenses_Click);
            // 
            // btnCategory
            // 
            this.btnCategory.BackColor = System.Drawing.Color.CadetBlue;
            this.btnCategory.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategory.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCategory.Location = new System.Drawing.Point(12, 258);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Size = new System.Drawing.Size(259, 39);
            this.btnCategory.TabIndex = 12;
            this.btnCategory.Text = "Add Category";
            this.btnCategory.UseVisualStyleBackColor = false;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(93, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // btnDaskboard
            // 
            this.btnDaskboard.BackColor = System.Drawing.Color.CadetBlue;
            this.btnDaskboard.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDaskboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDaskboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDaskboard.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDaskboard.Location = new System.Drawing.Point(12, 202);
            this.btnDaskboard.Name = "btnDaskboard";
            this.btnDaskboard.Size = new System.Drawing.Size(259, 39);
            this.btnDaskboard.TabIndex = 10;
            this.btnDaskboard.Text = "Daskboard";
            this.btnDaskboard.UseVisualStyleBackColor = false;
            this.btnDaskboard.Click += new System.EventHandler(this.btnDaskboard_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(89, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Welcome,";
            // 
            // daskboard1
            // 
            this.daskboard1.Location = new System.Drawing.Point(319, 39);
            this.daskboard1.Name = "daskboard1";
            this.daskboard1.Size = new System.Drawing.Size(954, 513);
            this.daskboard1.TabIndex = 8;
            // 
            // expenses1
            // 
            this.expenses1.Location = new System.Drawing.Point(350, 45);
            this.expenses1.Name = "expenses1";
            this.expenses1.Size = new System.Drawing.Size(855, 499);
            this.expenses1.TabIndex = 7;
            // 
            // income1
            // 
            this.income1.Location = new System.Drawing.Point(348, 45);
            this.income1.Name = "income1";
            this.income1.Size = new System.Drawing.Size(857, 499);
            this.income1.TabIndex = 5;
            // 
            // category_1_Form1
            // 
            this.category_1_Form1.Location = new System.Drawing.Point(371, 55);
            this.category_1_Form1.Name = "category_1_Form1";
            this.category_1_Form1.Size = new System.Drawing.Size(857, 499);
            this.category_1_Form1.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1297, 566);
            this.Controls.Add(this.daskboard1);
            this.Controls.Add(this.expenses1);
            this.Controls.Add(this.income1);
            this.Controls.Add(this.category_1_Form1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDaskboard;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnincome;
        private System.Windows.Forms.Button btnExpenses;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.Button button4;
        private category_1_Form category_1_Form1;
        private Income income1;
        private Expenses expenses1;
        private Daskboard daskboard1;
    }
}