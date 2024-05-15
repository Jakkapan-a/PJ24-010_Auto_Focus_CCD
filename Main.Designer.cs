namespace PJ24_010_Auto_Focus_CCD
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            settingToolStripMenuItem = new ToolStripMenuItem();
            oNNXToolStripMenuItem = new ToolStripMenuItem();
            configurationToolStripMenuItem = new ToolStripMenuItem();
            testToolStripMenuItem = new ToolStripMenuItem();
            runToolStripMenuItem = new ToolStripMenuItem();
            parameterToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripProgressBar1 = new ToolStripProgressBar();
            panel1 = new Panel();
            lbDateTime = new Label();
            lbVoltage = new Label();
            lbAmp = new Label();
            txtLog = new RichTextBox();
            groupBox2 = new GroupBox();
            btnReload = new Button();
            btnConnect = new Button();
            comBaudRate = new ComboBox();
            comPort = new ComboBox();
            comDevice = new ComboBox();
            label6 = new Label();
            label4 = new Label();
            label5 = new Label();
            groupBox1 = new GroupBox();
            txtQr = new TextBox();
            txtEmp = new TextBox();
            label3 = new Label();
            label2 = new Label();
            panel2 = new Panel();
            pictureBox = new PictureBox();
            label1 = new Label();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            panel1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { settingToolStripMenuItem, testToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1104, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // settingToolStripMenuItem
            // 
            settingToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { oNNXToolStripMenuItem, configurationToolStripMenuItem });
            settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            settingToolStripMenuItem.Size = new Size(56, 20);
            settingToolStripMenuItem.Text = "Setting";
            // 
            // oNNXToolStripMenuItem
            // 
            oNNXToolStripMenuItem.Name = "oNNXToolStripMenuItem";
            oNNXToolStripMenuItem.Size = new Size(159, 22);
            oNNXToolStripMenuItem.Text = "ONNX";
            // 
            // configurationToolStripMenuItem
            // 
            configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            configurationToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            configurationToolStripMenuItem.Size = new Size(159, 22);
            configurationToolStripMenuItem.Text = "Options";
            // 
            // testToolStripMenuItem
            // 
            testToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { runToolStripMenuItem, parameterToolStripMenuItem });
            testToolStripMenuItem.Name = "testToolStripMenuItem";
            testToolStripMenuItem.Size = new Size(39, 20);
            testToolStripMenuItem.Text = "Test";
            // 
            // runToolStripMenuItem
            // 
            runToolStripMenuItem.Name = "runToolStripMenuItem";
            runToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.R;
            runToolStripMenuItem.Size = new Size(167, 22);
            runToolStripMenuItem.Text = "Run";
            // 
            // parameterToolStripMenuItem
            // 
            parameterToolStripMenuItem.Name = "parameterToolStripMenuItem";
            parameterToolStripMenuItem.Size = new Size(167, 22);
            parameterToolStripMenuItem.Text = "Parameter Simple";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripProgressBar1 });
            statusStrip1.Location = new Point(0, 613);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1104, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(100, 16);
            // 
            // panel1
            // 
            panel1.Controls.Add(lbDateTime);
            panel1.Controls.Add(lbVoltage);
            panel1.Controls.Add(lbAmp);
            panel1.Controls.Add(txtLog);
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(groupBox1);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(897, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(207, 589);
            panel1.TabIndex = 2;
            // 
            // lbDateTime
            // 
            lbDateTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbDateTime.BackColor = SystemColors.Control;
            lbDateTime.ForeColor = Color.Blue;
            lbDateTime.Location = new Point(77, 3);
            lbDateTime.Name = "lbDateTime";
            lbDateTime.Size = new Size(125, 21);
            lbDateTime.TabIndex = 4;
            lbDateTime.Text = "------------";
            lbDateTime.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbVoltage
            // 
            lbVoltage.AutoSize = true;
            lbVoltage.BackColor = Color.White;
            lbVoltage.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbVoltage.ForeColor = Color.Blue;
            lbVoltage.Location = new Point(7, 16);
            lbVoltage.Name = "lbVoltage";
            lbVoltage.Size = new Size(30, 20);
            lbVoltage.TabIndex = 4;
            lbVoltage.Text = "--V";
            // 
            // lbAmp
            // 
            lbAmp.AutoSize = true;
            lbAmp.BackColor = Color.White;
            lbAmp.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbAmp.ForeColor = Color.Red;
            lbAmp.Location = new Point(7, 42);
            lbAmp.Name = "lbAmp";
            lbAmp.Size = new Size(44, 20);
            lbAmp.TabIndex = 2;
            lbAmp.Text = "--mA";
            // 
            // txtLog
            // 
            txtLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtLog.Location = new Point(7, 409);
            txtLog.Name = "txtLog";
            txtLog.Size = new Size(191, 180);
            txtLog.TabIndex = 2;
            txtLog.Text = "";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnReload);
            groupBox2.Controls.Add(btnConnect);
            groupBox2.Controls.Add(comBaudRate);
            groupBox2.Controls.Add(comPort);
            groupBox2.Controls.Add(comDevice);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label5);
            groupBox2.Location = new Point(6, 200);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(196, 203);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Communication";
            // 
            // btnReload
            // 
            btnReload.BackgroundImage = Properties.Resources._refresh_32;
            btnReload.BackgroundImageLayout = ImageLayout.Zoom;
            btnReload.Location = new Point(6, 174);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(25, 23);
            btnReload.TabIndex = 3;
            btnReload.UseVisualStyleBackColor = true;
            btnReload.Click += btnReload_Click;
            // 
            // btnConnect
            // 
            btnConnect.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnConnect.Location = new Point(115, 174);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(75, 23);
            btnConnect.TabIndex = 4;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // comBaudRate
            // 
            comBaudRate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comBaudRate.FormattingEnabled = true;
            comBaudRate.Location = new Point(6, 145);
            comBaudRate.Name = "comBaudRate";
            comBaudRate.Size = new Size(182, 23);
            comBaudRate.TabIndex = 2;
            // 
            // comPort
            // 
            comPort.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comPort.FormattingEnabled = true;
            comPort.Location = new Point(6, 91);
            comPort.Name = "comPort";
            comPort.Size = new Size(182, 23);
            comPort.TabIndex = 1;
            // 
            // comDevice
            // 
            comDevice.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comDevice.FormattingEnabled = true;
            comDevice.Location = new Point(6, 37);
            comDevice.Name = "comDevice";
            comDevice.Size = new Size(182, 23);
            comDevice.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 127);
            label6.Name = "label6";
            label6.Size = new Size(63, 15);
            label6.TabIndex = 1;
            label6.Text = "Baud rate :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(2, 73);
            label4.Name = "label4";
            label4.Size = new Size(66, 15);
            label4.TabIndex = 0;
            label4.Text = "COM Port :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(2, 19);
            label5.Name = "label5";
            label5.Size = new Size(48, 15);
            label5.TabIndex = 0;
            label5.Text = "Device :";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtQr);
            groupBox1.Controls.Add(txtEmp);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(4, 68);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 126);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Input";
            // 
            // txtQr
            // 
            txtQr.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtQr.Location = new Point(6, 87);
            txtQr.Name = "txtQr";
            txtQr.Size = new Size(188, 23);
            txtQr.TabIndex = 1;
            txtQr.KeyPress += txtQr_KeyPress;
            // 
            // txtEmp
            // 
            txtEmp.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtEmp.Location = new Point(6, 37);
            txtEmp.Name = "txtEmp";
            txtEmp.Size = new Size(188, 23);
            txtEmp.TabIndex = 0;
            txtEmp.KeyPress += txtEmp_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 69);
            label3.Name = "label3";
            label3.Size = new Size(29, 15);
            label3.TabIndex = 0;
            label3.Text = "QR :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 19);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 0;
            label2.Text = "Employee";
            // 
            // panel2
            // 
            panel2.Controls.Add(pictureBox);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 24);
            panel2.Name = "panel2";
            panel2.Size = new Size(897, 589);
            panel2.TabIndex = 3;
            // 
            // pictureBox
            // 
            pictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox.BackColor = Color.Black;
            pictureBox.Location = new Point(12, 50);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(879, 536);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 1;
            pictureBox.TabStop = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.BackColor = Color.Yellow;
            label1.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 3);
            label1.Name = "label1";
            label1.Size = new Size(879, 44);
            label1.TabIndex = 0;
            label1.Text = "CAMERA";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1104, 635);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main";
            WindowState = FormWindowState.Maximized;
            FormClosing += Main_FormClosing;
            Load += Main_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem settingToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripProgressBar toolStripProgressBar1;
        private ToolStripMenuItem testToolStripMenuItem;
        private Panel panel1;
        private Panel panel2;
        private GroupBox groupBox1;
        private ToolStripMenuItem oNNXToolStripMenuItem;
        private ToolStripMenuItem runToolStripMenuItem;
        private Label label1;
        private PictureBox pictureBox;
        private Label label3;
        private Label label2;
        private ToolStripMenuItem configurationToolStripMenuItem;
        private GroupBox groupBox2;
        private Label label4;
        private Label label5;
        private TextBox txtQr;
        private TextBox txtEmp;
        private Button btnReload;
        private Button btnConnect;
        private ComboBox comBaudRate;
        private ComboBox comPort;
        private ComboBox comDevice;
        private Label label6;
        private Label lbVoltage;
        private Label lbAmp;
        private RichTextBox txtLog;
        private Label lbDateTime;
        private ToolStripMenuItem parameterToolStripMenuItem;
    }
}
