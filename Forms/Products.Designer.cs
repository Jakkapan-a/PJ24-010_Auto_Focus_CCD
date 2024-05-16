namespace PJ24_010_Auto_Focus_CCD.Forms
{
    partial class Products
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
            statusStrip1 = new StatusStrip();
            groupBox1 = new GroupBox();
            txtMaxAmp = new NumericUpDown();
            txtMinAmp = new NumericUpDown();
            txtMinVoltage = new NumericUpDown();
            txtMaxVoltage = new NumericUpDown();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label3 = new Label();
            label2 = new Label();
            cbType = new ComboBox();
            btnOnnxSelect = new Button();
            btnDelete = new Button();
            btnNew = new Button();
            btnSave = new Button();
            txtOnnx = new TextBox();
            txtName = new TextBox();
            label7 = new Label();
            label12 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            dgvProduct = new DataGridView();
            lbPage = new Label();
            btnPrevious = new Button();
            btnNext = new Button();
            txtSearch = new TextBox();
            label14 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtMaxAmp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtMinAmp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtMinVoltage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtMaxVoltage).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProduct).BeginInit();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new Point(5, 546);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1046, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtMaxAmp);
            groupBox1.Controls.Add(txtMinAmp);
            groupBox1.Controls.Add(txtMinVoltage);
            groupBox1.Controls.Add(txtMaxVoltage);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cbType);
            groupBox1.Controls.Add(btnOnnxSelect);
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnNew);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(txtOnnx);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Left;
            groupBox1.Location = new Point(5, 10);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(248, 536);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Information";
            // 
            // txtMaxAmp
            // 
            txtMaxAmp.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMaxAmp.DecimalPlaces = 2;
            txtMaxAmp.Location = new Point(26, 341);
            txtMaxAmp.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            txtMaxAmp.Name = "txtMaxAmp";
            txtMaxAmp.Size = new Size(180, 23);
            txtMaxAmp.TabIndex = 5;
            txtMaxAmp.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // txtMinAmp
            // 
            txtMinAmp.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMinAmp.DecimalPlaces = 2;
            txtMinAmp.Location = new Point(26, 291);
            txtMinAmp.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            txtMinAmp.Name = "txtMinAmp";
            txtMinAmp.Size = new Size(180, 23);
            txtMinAmp.TabIndex = 4;
            // 
            // txtMinVoltage
            // 
            txtMinVoltage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMinVoltage.DecimalPlaces = 2;
            txtMinVoltage.Location = new Point(26, 175);
            txtMinVoltage.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            txtMinVoltage.Name = "txtMinVoltage";
            txtMinVoltage.Size = new Size(180, 23);
            txtMinVoltage.TabIndex = 2;
            // 
            // txtMaxVoltage
            // 
            txtMaxVoltage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMaxVoltage.DecimalPlaces = 2;
            txtMaxVoltage.Location = new Point(26, 219);
            txtMaxVoltage.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            txtMaxVoltage.Name = "txtMaxVoltage";
            txtMaxVoltage.Size = new Size(180, 23);
            txtMaxVoltage.TabIndex = 3;
            txtMaxVoltage.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(26, 325);
            label6.Name = "label6";
            label6.Size = new Size(52, 15);
            label6.TabIndex = 6;
            label6.Text = "Max mA";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(26, 273);
            label5.Name = "label5";
            label5.Size = new Size(50, 15);
            label5.TabIndex = 6;
            label5.Text = "Min mA";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 201);
            label4.Name = "label4";
            label4.Size = new Size(72, 15);
            label4.TabIndex = 5;
            label4.Text = "Max Voltage";
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Location = new Point(212, 345);
            label11.Name = "label11";
            label11.Size = new Size(26, 15);
            label11.TabIndex = 5;
            label11.Text = "mA";
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Location = new Point(212, 295);
            label10.Name = "label10";
            label10.Size = new Size(26, 15);
            label10.TabIndex = 5;
            label10.Text = "mA";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Location = new Point(212, 223);
            label9.Name = "label9";
            label9.Size = new Size(14, 15);
            label9.TabIndex = 5;
            label9.Text = "V";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Location = new Point(212, 179);
            label8.Name = "label8";
            label8.Size = new Size(14, 15);
            label8.TabIndex = 5;
            label8.Text = "V";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 157);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 5;
            label3.Text = "Min Voltage";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 92);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 4;
            label2.Text = "Type";
            // 
            // cbType
            // 
            cbType.FormattingEnabled = true;
            cbType.Items.AddRange(new object[] { "None", "PVM" });
            cbType.Location = new Point(26, 110);
            cbType.Name = "cbType";
            cbType.Size = new Size(203, 23);
            cbType.TabIndex = 1;
            // 
            // btnOnnxSelect
            // 
            btnOnnxSelect.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOnnxSelect.Location = new Point(208, 407);
            btnOnnxSelect.Name = "btnOnnxSelect";
            btnOnnxSelect.Size = new Size(34, 23);
            btnOnnxSelect.TabIndex = 7;
            btnOnnxSelect.Text = "...";
            btnOnnxSelect.UseVisualStyleBackColor = true;
            btnOnnxSelect.Click += btnOnnxSelect_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDelete.BackgroundImage = Properties.Resources.delete_32;
            btnDelete.BackgroundImageLayout = ImageLayout.Zoom;
            btnDelete.Location = new Point(6, 507);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(25, 23);
            btnDelete.TabIndex = 8;
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnNew
            // 
            btnNew.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnNew.Location = new Point(86, 507);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(75, 23);
            btnNew.TabIndex = 9;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Location = new Point(167, 507);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 10;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtOnnx
            // 
            txtOnnx.Location = new Point(26, 407);
            txtOnnx.MaxLength = 7;
            txtOnnx.Name = "txtOnnx";
            txtOnnx.ReadOnly = true;
            txtOnnx.Size = new Size(176, 23);
            txtOnnx.TabIndex = 6;
            // 
            // txtName
            // 
            txtName.Location = new Point(26, 66);
            txtName.MaxLength = 7;
            txtName.Name = "txtName";
            txtName.Size = new Size(205, 23);
            txtName.TabIndex = 0;
            txtName.TextChanged += txtName_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.Red;
            label7.Location = new Point(71, 48);
            label7.Name = "label7";
            label7.Size = new Size(105, 15);
            label7.TabIndex = 0;
            label7.Text = "(7 Digit, 721TMCX)";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(21, 387);
            label12.Name = "label12";
            label12.Size = new Size(41, 15);
            label12.TabIndex = 0;
            label12.Text = "ONNX";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 48);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 0;
            label1.Text = "Name";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvProduct);
            groupBox2.Controls.Add(lbPage);
            groupBox2.Controls.Add(btnPrevious);
            groupBox2.Controls.Add(btnNext);
            groupBox2.Controls.Add(txtSearch);
            groupBox2.Controls.Add(label14);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(253, 10);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(798, 536);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "List";
            // 
            // dgvProduct
            // 
            dgvProduct.AllowUserToAddRows = false;
            dgvProduct.AllowUserToDeleteRows = false;
            dgvProduct.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProduct.Location = new Point(17, 48);
            dgvProduct.Name = "dgvProduct";
            dgvProduct.RowHeadersVisible = false;
            dgvProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProduct.Size = new Size(775, 453);
            dgvProduct.TabIndex = 3;
            dgvProduct.SelectionChanged += dgvProduct_SelectionChanged;
            // 
            // lbPage
            // 
            lbPage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbPage.AutoSize = true;
            lbPage.Location = new Point(17, 511);
            lbPage.Name = "lbPage";
            lbPage.Size = new Size(12, 15);
            lbPage.TabIndex = 0;
            lbPage.Text = "-";
            // 
            // btnPrevious
            // 
            btnPrevious.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnPrevious.Location = new Point(636, 507);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(75, 23);
            btnPrevious.TabIndex = 1;
            btnPrevious.Text = "<<";
            btnPrevious.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            btnNext.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnNext.Location = new Point(717, 507);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(75, 23);
            btnNext.TabIndex = 2;
            btnNext.Text = ">>";
            btnNext.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.Location = new Point(636, 22);
            txtSearch.MaxLength = 7;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(156, 23);
            txtSearch.TabIndex = 0;
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label14.AutoSize = true;
            label14.Location = new Point(591, 25);
            label14.Name = "label14";
            label14.Size = new Size(39, 15);
            label14.TabIndex = 0;
            label14.Text = "Name";
            // 
            // Products
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1056, 573);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(statusStrip1);
            Name = "Products";
            Padding = new Padding(5, 10, 5, 5);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Models";
            Load += Products_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtMaxAmp).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtMinAmp).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtMinVoltage).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtMaxVoltage).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProduct).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox txtName;
        private Label label1;
        private Button btnSave;
        private Label label3;
        private Label label2;
        private ComboBox cbType;
        private Label label6;
        private Label label5;
        private Label label4;
        private Button btnDelete;
        private Label label7;
        private NumericUpDown txtMaxAmp;
        private NumericUpDown txtMinAmp;
        private NumericUpDown txtMinVoltage;
        private NumericUpDown txtMaxVoltage;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Button btnOnnxSelect;
        private TextBox txtOnnx;
        private Label label12;
        private Label lbPage;
        private Button btnPrevious;
        private Button btnNext;
        private DataGridView dgvProduct;
        private Button btnNew;
        private TextBox txtSearch;
        private Label label14;
    }
}