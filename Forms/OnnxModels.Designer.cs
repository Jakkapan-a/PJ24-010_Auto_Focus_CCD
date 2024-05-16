namespace PJ24_010_Auto_Focus_CCD.Forms
{
    partial class OnnxModels
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
            btnLabel = new Button();
            btnDelete = new Button();
            btnNew = new Button();
            btnEdit = new Button();
            btnSave = new Button();
            btnOnnx = new Button();
            txtLabel = new TextBox();
            txtOnnx = new TextBox();
            txtName = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            splitContainer1 = new SplitContainer();
            dataGridView1 = new DataGridView();
            label4 = new Label();
            richTextBox1 = new RichTextBox();
            label5 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new Point(10, 667);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1126, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnLabel);
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnNew);
            groupBox1.Controls.Add(btnEdit);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(btnOnnx);
            groupBox1.Controls.Add(txtLabel);
            groupBox1.Controls.Add(txtOnnx);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(10, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1126, 216);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Forms";
            // 
            // btnLabel
            // 
            btnLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLabel.Enabled = false;
            btnLabel.Location = new Point(1083, 119);
            btnLabel.Name = "btnLabel";
            btnLabel.Size = new Size(37, 23);
            btnLabel.TabIndex = 3;
            btnLabel.Text = "...";
            btnLabel.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.BackgroundImage = Properties.Resources.delete_32;
            btnDelete.BackgroundImageLayout = ImageLayout.Zoom;
            btnDelete.Enabled = false;
            btnDelete.Location = new Point(7, 178);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(25, 23);
            btnDelete.TabIndex = 2;
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            btnNew.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNew.Location = new Point(847, 178);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(75, 23);
            btnNew.TabIndex = 2;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEdit.Enabled = false;
            btnEdit.Location = new Point(928, 178);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 23);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSave.Enabled = false;
            btnSave.Location = new Point(1045, 178);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnOnnx
            // 
            btnOnnx.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOnnx.Enabled = false;
            btnOnnx.Location = new Point(1083, 86);
            btnOnnx.Name = "btnOnnx";
            btnOnnx.Size = new Size(37, 23);
            btnOnnx.TabIndex = 2;
            btnOnnx.Text = "...";
            btnOnnx.UseVisualStyleBackColor = true;
            // 
            // txtLabel
            // 
            txtLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtLabel.Location = new Point(81, 119);
            txtLabel.Name = "txtLabel";
            txtLabel.ReadOnly = true;
            txtLabel.Size = new Size(996, 23);
            txtLabel.TabIndex = 1;
            // 
            // txtOnnx
            // 
            txtOnnx.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtOnnx.Location = new Point(84, 86);
            txtOnnx.Name = "txtOnnx";
            txtOnnx.ReadOnly = true;
            txtOnnx.Size = new Size(996, 23);
            txtOnnx.TabIndex = 1;
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtName.Location = new Point(85, 48);
            txtName.Name = "txtName";
            txtName.Size = new Size(996, 23);
            txtName.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 119);
            label3.Name = "label3";
            label3.Size = new Size(35, 15);
            label3.TabIndex = 0;
            label3.Text = "Label";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 86);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 0;
            label2.Text = "ONNX";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 51);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 0;
            label1.Text = "Name";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(splitContainer1);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(10, 221);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1126, 446);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Tables";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 19);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dataGridView1);
            splitContainer1.Panel1.Controls.Add(label4);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(richTextBox1);
            splitContainer1.Panel2.Controls.Add(label5);
            splitContainer1.Size = new Size(1120, 424);
            splitContainer1.SplitterDistance = 549;
            splitContainer1.TabIndex = 6;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(13, 34);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(521, 376);
            dataGridView1.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(4, 16);
            label4.Name = "label4";
            label4.Size = new Size(62, 15);
            label4.TabIndex = 4;
            label4.Text = "Model List";
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox1.Location = new Point(20, 34);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(532, 376);
            richTextBox1.TabIndex = 6;
            richTextBox1.Text = "";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 16);
            label5.Name = "label5";
            label5.Size = new Size(62, 15);
            label5.TabIndex = 5;
            label5.Text = "Model List";
            // 
            // OnnxModels
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1146, 691);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(statusStrip1);
            Name = "OnnxModels";
            Padding = new Padding(10, 5, 10, 2);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "OnnxModel";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btnLabel;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnSave;
        private Button btnOnnx;
        private TextBox txtLabel;
        private TextBox txtOnnx;
        private TextBox txtName;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnNew;
        private Label label5;
        private Label label4;
        private SplitContainer splitContainer1;
        private DataGridView dataGridView1;
        private RichTextBox richTextBox1;
    }
}