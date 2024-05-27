namespace PJ24_010_Auto_Focus_CCD.Forms
{
    partial class Options
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
            groupBox1 = new GroupBox();
            txtClearDelay = new NumericUpDown();
            label3 = new Label();
            label2 = new Label();
            txtClearMessage = new TextBox();
            groupBox2 = new GroupBox();
            txtKeyNGDelay = new NumericUpDown();
            txtKeyNGDescription = new RichTextBox();
            label5 = new Label();
            label1 = new Label();
            label4 = new Label();
            txtKeyNG = new TextBox();
            IsAllowSendData = new CheckBox();
            statusStrip1 = new StatusStrip();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtClearDelay).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtKeyNGDelay).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(txtClearDelay);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtClearMessage);
            groupBox1.Location = new Point(16, 56);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(330, 92);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Auto Clear";
            // 
            // txtClearDelay
            // 
            txtClearDelay.Location = new Point(92, 52);
            txtClearDelay.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            txtClearDelay.Name = "txtClearDelay";
            txtClearDelay.Size = new Size(225, 23);
            txtClearDelay.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(45, 54);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 2;
            label3.Text = "Delay :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 25);
            label2.Name = "label2";
            label2.Size = new Size(68, 15);
            label2.TabIndex = 2;
            label2.Text = "Message 1 :";
            // 
            // txtClearMessage
            // 
            txtClearMessage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtClearMessage.Location = new Point(93, 22);
            txtClearMessage.Name = "txtClearMessage";
            txtClearMessage.Size = new Size(224, 23);
            txtClearMessage.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(txtKeyNGDelay);
            groupBox2.Controls.Add(txtKeyNGDescription);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(txtKeyNG);
            groupBox2.Location = new Point(16, 154);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(330, 155);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "KEY NG";
            // 
            // txtKeyNGDelay
            // 
            txtKeyNGDelay.Location = new Point(92, 51);
            txtKeyNGDelay.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            txtKeyNGDelay.Name = "txtKeyNGDelay";
            txtKeyNGDelay.Size = new Size(225, 23);
            txtKeyNGDelay.TabIndex = 3;
            // 
            // txtKeyNGDescription
            // 
            txtKeyNGDescription.Location = new Point(92, 80);
            txtKeyNGDescription.Name = "txtKeyNGDescription";
            txtKeyNGDescription.Size = new Size(225, 69);
            txtKeyNGDescription.TabIndex = 3;
            txtKeyNGDescription.Text = "";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 80);
            label5.Name = "label5";
            label5.Size = new Size(73, 15);
            label5.TabIndex = 2;
            label5.Text = "Description :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 54);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 2;
            label1.Text = "Delay :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(54, 25);
            label4.Name = "label4";
            label4.Size = new Size(33, 15);
            label4.TabIndex = 2;
            label4.Text = "KEY :";
            // 
            // txtKeyNG
            // 
            txtKeyNG.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtKeyNG.Location = new Point(93, 22);
            txtKeyNG.Name = "txtKeyNG";
            txtKeyNG.Size = new Size(224, 23);
            txtKeyNG.TabIndex = 0;
            // 
            // IsAllowSendData
            // 
            IsAllowSendData.AutoSize = true;
            IsAllowSendData.Location = new Point(16, 31);
            IsAllowSendData.Name = "IsAllowSendData";
            IsAllowSendData.Size = new Size(150, 19);
            IsAllowSendData.TabIndex = 2;
            IsAllowSendData.Text = "Allow Send Data (If NG)";
            IsAllowSendData.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new Point(0, 324);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(358, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // Options
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(358, 346);
            Controls.Add(statusStrip1);
            Controls.Add(IsAllowSendData);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Options";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Options";
            Load += Options_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtClearDelay).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtKeyNGDelay).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox groupBox1;
        private TextBox txtClearMessage;
        private Label label3;
        private Label label2;
        private GroupBox groupBox2;
        private RichTextBox txtKeyNGDescription;
        private Label label5;
        private Label label1;
        private Label label4;
        private TextBox txtKeyNG;
        private CheckBox IsAllowSendData;
        private StatusStrip statusStrip1;
        private NumericUpDown txtClearDelay;
        private NumericUpDown txtKeyNGDelay;
    }
}