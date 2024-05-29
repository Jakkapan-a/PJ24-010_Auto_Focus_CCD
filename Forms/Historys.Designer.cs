namespace PJ24_010_Auto_Focus_CCD.Forms
{
    partial class Historys
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Historys));
            statusStrip1 = new StatusStrip();
            toolStripProgressBar = new ToolStripProgressBar();
            groupBox1 = new GroupBox();
            btnSelectModel = new Button();
            txtModel = new TextBox();
            txtReJudg = new TextBox();
            txtResult = new TextBox();
            txtQrCode = new TextBox();
            txtEmp = new TextBox();
            label6 = new Label();
            label5 = new Label();
            cbUseDate = new CheckBox();
            label4 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            btnExportCSV = new Button();
            btnPrevious = new Button();
            btnNext = new Button();
            dgvHistory = new DataGridView();
            lbPage = new Label();
            statusStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripProgressBar });
            statusStrip1.Location = new Point(0, 638);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1125, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar
            // 
            toolStripProgressBar.Name = "toolStripProgressBar";
            toolStripProgressBar.Size = new Size(100, 16);
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox1.Controls.Add(btnSelectModel);
            groupBox1.Controls.Add(txtModel);
            groupBox1.Controls.Add(txtReJudg);
            groupBox1.Controls.Add(txtResult);
            groupBox1.Controls.Add(txtQrCode);
            groupBox1.Controls.Add(txtEmp);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(cbUseDate);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(259, 623);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Form";
            // 
            // btnSelectModel
            // 
            btnSelectModel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSelectModel.BackgroundImage = Properties.Resources.search;
            btnSelectModel.BackgroundImageLayout = ImageLayout.Zoom;
            btnSelectModel.Location = new Point(200, 114);
            btnSelectModel.Name = "btnSelectModel";
            btnSelectModel.Size = new Size(23, 23);
            btnSelectModel.TabIndex = 2;
            btnSelectModel.UseVisualStyleBackColor = true;
            btnSelectModel.Click += btnSelectModel_Click;
            // 
            // txtModel
            // 
            txtModel.Location = new Point(26, 114);
            txtModel.Name = "txtModel";
            txtModel.Size = new Size(168, 23);
            txtModel.TabIndex = 3;
            txtModel.TextChanged += txtModel_TextChanged;
            // 
            // txtReJudg
            // 
            txtReJudg.Location = new Point(26, 326);
            txtReJudg.Name = "txtReJudg";
            txtReJudg.Size = new Size(198, 23);
            txtReJudg.TabIndex = 3;
            txtReJudg.TextChanged += txtReJudg_TextChanged;
            // 
            // txtResult
            // 
            txtResult.Location = new Point(26, 270);
            txtResult.Name = "txtResult";
            txtResult.Size = new Size(198, 23);
            txtResult.TabIndex = 3;
            txtResult.TextChanged += txtResult_TextChanged;
            // 
            // txtQrCode
            // 
            txtQrCode.Location = new Point(26, 217);
            txtQrCode.Name = "txtQrCode";
            txtQrCode.Size = new Size(198, 23);
            txtQrCode.TabIndex = 3;
            txtQrCode.TextChanged += txtQrCode_TextChanged;
            // 
            // txtEmp
            // 
            txtEmp.Location = new Point(27, 163);
            txtEmp.Name = "txtEmp";
            txtEmp.Size = new Size(197, 23);
            txtEmp.TabIndex = 3;
            txtEmp.TextChanged += txtEmp_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 96);
            label6.Name = "label6";
            label6.Size = new Size(41, 15);
            label6.TabIndex = 0;
            label6.Text = "Model";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 308);
            label5.Name = "label5";
            label5.Size = new Size(78, 15);
            label5.TabIndex = 0;
            label5.Text = "Re-Judgment";
            // 
            // cbUseDate
            // 
            cbUseDate.AutoSize = true;
            cbUseDate.Location = new Point(228, 69);
            cbUseDate.Name = "cbUseDate";
            cbUseDate.Size = new Size(15, 14);
            cbUseDate.TabIndex = 2;
            cbUseDate.UseVisualStyleBackColor = true;
            cbUseDate.CheckedChanged += cbUseDate_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 252);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 0;
            label4.Text = "Result";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(26, 63);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(198, 23);
            dateTimePicker1.TabIndex = 1;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 199);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 0;
            label3.Text = "QR S/N :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 147);
            label2.Name = "label2";
            label2.Size = new Size(65, 15);
            label2.TabIndex = 0;
            label2.Text = "Employee :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 45);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 0;
            label1.Text = "Date :";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(btnExportCSV);
            groupBox2.Controls.Add(btnPrevious);
            groupBox2.Controls.Add(btnNext);
            groupBox2.Controls.Add(dgvHistory);
            groupBox2.Controls.Add(lbPage);
            groupBox2.Location = new Point(277, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(836, 623);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Table";
            // 
            // btnExportCSV
            // 
            btnExportCSV.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportCSV.BackgroundImage = Properties.Resources.Export_CSV;
            btnExportCSV.BackgroundImageLayout = ImageLayout.Zoom;
            btnExportCSV.Location = new Point(788, 22);
            btnExportCSV.Name = "btnExportCSV";
            btnExportCSV.Size = new Size(32, 32);
            btnExportCSV.TabIndex = 2;
            btnExportCSV.UseVisualStyleBackColor = true;
            btnExportCSV.Click += btnExportCSV_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnPrevious.Location = new Point(674, 594);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(75, 23);
            btnPrevious.TabIndex = 1;
            btnPrevious.Text = "<<";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // btnNext
            // 
            btnNext.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnNext.Location = new Point(755, 594);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(75, 23);
            btnNext.TabIndex = 1;
            btnNext.Text = ">>";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // dgvHistory
            // 
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.AllowUserToDeleteRows = false;
            dgvHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistory.Location = new Point(15, 63);
            dgvHistory.Name = "dgvHistory";
            dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistory.Size = new Size(815, 525);
            dgvHistory.TabIndex = 0;
            // 
            // lbPage
            // 
            lbPage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbPage.AutoSize = true;
            lbPage.Location = new Point(15, 598);
            lbPage.Name = "lbPage";
            lbPage.Size = new Size(12, 15);
            lbPage.TabIndex = 0;
            lbPage.Text = "-";
            // 
            // Historys
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 660);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(statusStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Historys";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Historys";
            WindowState = FormWindowState.Maximized;
            Load += Historys_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private CheckBox cbUseDate;
        private DateTimePicker dateTimePicker1;
        private Label label1;
        private Label label2;
        private TextBox txtEmp;
        private CheckBox cbUseEmp;
        private TextBox txtQrCode;
        private CheckBox checkBox3;
        private Label label3;
        private TextBox txtModel;
        private TextBox txtReJudg;
        private CheckBox cbUse;
        private TextBox txtResult;
        private CheckBox checkBox5;
        private CheckBox checkBox4;
        private Label label6;
        private Label label5;
        private Label label4;
        private Button btnPrevious;
        private Button btnNext;
        private DataGridView dgvHistory;
        private Label lbPage;
        private Button btnSelectModel;
        private Button btnExportCSV;
        private ToolStripProgressBar toolStripProgressBar;
    }
}