namespace PJ24_010_Auto_Focus_CCD.Forms
{
    partial class SelectOnnxModels
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
            dgvOnnx = new DataGridView();
            txtSearch = new TextBox();
            btnNext = new Button();
            btnPrevious = new Button();
            label1 = new Label();
            lbPage = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvOnnx).BeginInit();
            SuspendLayout();
            // 
            // dgvOnnx
            // 
            dgvOnnx.AllowUserToAddRows = false;
            dgvOnnx.AllowUserToDeleteRows = false;
            dgvOnnx.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvOnnx.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOnnx.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOnnx.Location = new Point(12, 41);
            dgvOnnx.Name = "dgvOnnx";
            dgvOnnx.ReadOnly = true;
            dgvOnnx.RowHeadersVisible = false;
            dgvOnnx.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOnnx.Size = new Size(265, 365);
            dgvOnnx.TabIndex = 0;
            dgvOnnx.MouseDoubleClick += dgvOnnx_MouseDoubleClick;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.Location = new Point(159, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(118, 23);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btnNext
            // 
            btnNext.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnNext.Location = new Point(201, 409);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(75, 23);
            btnNext.TabIndex = 2;
            btnNext.Text = ">>";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnPrevious.Location = new Point(120, 409);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(75, 23);
            btnPrevious.TabIndex = 2;
            btnPrevious.Text = "<<";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(111, 15);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 3;
            label1.Text = "Search";
            // 
            // lbPage
            // 
            lbPage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbPage.AutoSize = true;
            lbPage.Location = new Point(11, 413);
            lbPage.Name = "lbPage";
            lbPage.Size = new Size(12, 15);
            lbPage.TabIndex = 3;
            lbPage.Text = "-";
            // 
            // SelectOnnxModels
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(289, 444);
            Controls.Add(lbPage);
            Controls.Add(label1);
            Controls.Add(btnPrevious);
            Controls.Add(btnNext);
            Controls.Add(txtSearch);
            Controls.Add(dgvOnnx);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SelectOnnxModels";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Select Onnx Models";
            Load += SelectOnnxModels_Load;
            ((System.ComponentModel.ISupportInitialize)dgvOnnx).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvOnnx;
        private TextBox txtSearch;
        private Button btnNext;
        private Button btnPrevious;
        private Label label1;
        private Label lbPage;
    }
}