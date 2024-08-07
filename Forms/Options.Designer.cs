﻿namespace PJ24_010_Auto_Focus_CCD.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
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
            txtScore = new NumericUpDown();
            txtCountTest = new NumericUpDown();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            cbByPass = new CheckBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtClearDelay).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtKeyNGDelay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtScore).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCountTest).BeginInit();
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
            groupBox1.Size = new Size(322, 92);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Auto Clear";
            // 
            // txtClearDelay
            // 
            txtClearDelay.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtClearDelay.Location = new Point(92, 52);
            txtClearDelay.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            txtClearDelay.Name = "txtClearDelay";
            txtClearDelay.Size = new Size(217, 23);
            txtClearDelay.TabIndex = 3;
            txtClearDelay.ValueChanged += txtClearDelay_ValueChanged;
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
            txtClearMessage.Size = new Size(216, 23);
            txtClearMessage.TabIndex = 0;
            txtClearMessage.TextChanged += txtClearMessage_TextChanged;
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
            groupBox2.Size = new Size(322, 155);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "KEY NG";
            // 
            // txtKeyNGDelay
            // 
            txtKeyNGDelay.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtKeyNGDelay.Location = new Point(92, 51);
            txtKeyNGDelay.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            txtKeyNGDelay.Name = "txtKeyNGDelay";
            txtKeyNGDelay.Size = new Size(217, 23);
            txtKeyNGDelay.TabIndex = 3;
            txtKeyNGDelay.ValueChanged += txtKeyNGDelay_ValueChanged;
            // 
            // txtKeyNGDescription
            // 
            txtKeyNGDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtKeyNGDescription.Location = new Point(92, 80);
            txtKeyNGDescription.Name = "txtKeyNGDescription";
            txtKeyNGDescription.Size = new Size(217, 69);
            txtKeyNGDescription.TabIndex = 3;
            txtKeyNGDescription.Text = "";
            txtKeyNGDescription.TextChanged += txtKeyNGDescription_TextChanged;
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
            txtKeyNG.Size = new Size(216, 23);
            txtKeyNG.TabIndex = 0;
            txtKeyNG.TextChanged += txtKeyNG_TextChanged;
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
            IsAllowSendData.CheckedChanged += IsAllowSendData_CheckedChanged;
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new Point(0, 409);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(350, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // txtScore
            // 
            txtScore.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtScore.DecimalPlaces = 2;
            txtScore.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            txtScore.Location = new Point(109, 315);
            txtScore.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            txtScore.Name = "txtScore";
            txtScore.Size = new Size(194, 23);
            txtScore.TabIndex = 4;
            txtScore.Value = new decimal(new int[] { 5, 0, 0, 65536 });
            txtScore.ValueChanged += txtScore_ValueChanged;
            // 
            // txtCountTest
            // 
            txtCountTest.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCountTest.DecimalPlaces = 1;
            txtCountTest.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            txtCountTest.Location = new Point(109, 344);
            txtCountTest.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            txtCountTest.Name = "txtCountTest";
            txtCountTest.Size = new Size(194, 23);
            txtCountTest.TabIndex = 5;
            txtCountTest.Value = new decimal(new int[] { 15, 0, 0, 65536 });
            txtCountTest.ValueChanged += txtCountTest_ValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(61, 317);
            label6.Name = "label6";
            label6.Size = new Size(42, 15);
            label6.TabIndex = 2;
            label6.Text = "Score :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(35, 346);
            label7.Name = "label7";
            label7.Size = new Size(69, 15);
            label7.TabIndex = 2;
            label7.Text = "Count Test :";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Location = new Point(317, 323);
            label8.Name = "label8";
            label8.Size = new Size(17, 15);
            label8.TabIndex = 2;
            label8.Text = "%";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Location = new Point(317, 346);
            label9.Name = "label9";
            label9.Size = new Size(25, 15);
            label9.TabIndex = 2;
            label9.Text = "Sec";
            // 
            // cbByPass
            // 
            cbByPass.AutoSize = true;
            cbByPass.ForeColor = Color.Red;
            cbByPass.Location = new Point(12, 387);
            cbByPass.Name = "cbByPass";
            cbByPass.Size = new Size(69, 19);
            cbByPass.TabIndex = 6;
            cbByPass.Text = "BY PASS";
            cbByPass.UseVisualStyleBackColor = true;
            cbByPass.CheckedChanged += cbByPass_CheckedChanged;
            // 
            // Options
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 431);
            Controls.Add(cbByPass);
            Controls.Add(txtCountTest);
            Controls.Add(txtScore);
            Controls.Add(label7);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(statusStrip1);
            Controls.Add(IsAllowSendData);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
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
            ((System.ComponentModel.ISupportInitialize)txtScore).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCountTest).EndInit();
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
        private NumericUpDown txtScore;
        private NumericUpDown txtCountTest;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private CheckBox cbByPass;
    }
}