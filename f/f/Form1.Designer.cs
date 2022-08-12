namespace f
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.Companies = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.ProductRange = new System.Windows.Forms.DataGridView();
            this.Product = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Companies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Product)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Предприятия";
            // 
            // Companies
            // 
            this.Companies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Companies.Location = new System.Drawing.Point(21, 32);
            this.Companies.Name = "Companies";
            this.Companies.ReadOnly = true;
            this.Companies.RowHeadersVisible = false;
            this.Companies.Size = new System.Drawing.Size(398, 224);
            this.Companies.TabIndex = 1;
            this.Companies.Click += new System.EventHandler(this.CompanyDGV_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(438, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ассортимент";
            // 
            // ProductRange
            // 
            this.ProductRange.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductRange.Location = new System.Drawing.Point(441, 32);
            this.ProductRange.Name = "ProductRange";
            this.ProductRange.RowHeadersVisible = false;
            this.ProductRange.Size = new System.Drawing.Size(398, 224);
            this.ProductRange.TabIndex = 3;
            this.ProductRange.Click += new System.EventHandler(this.ListDGV_Click);
            // 
            // Product
            // 
            this.Product.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Product.Location = new System.Drawing.Point(21, 275);
            this.Product.Name = "Product";
            this.Product.RowHeadersVisible = false;
            this.Product.Size = new System.Drawing.Size(398, 224);
            this.Product.TabIndex = 5;
            this.Product.Click += new System.EventHandler(this.ProductDGV_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Товар";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(441, 275);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 117);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Операции над данными";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 64);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(386, 40);
            this.button4.TabIndex = 10;
            this.button4.Text = "Запрос";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.QueryMethod);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(6, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(386, 39);
            this.button1.TabIndex = 7;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Add);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 541);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Product);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ProductRange);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Companies);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "Работа с базой данных";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Companies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Product)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView Companies;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView ProductRange;
        private System.Windows.Forms.DataGridView Product;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
    }
}

