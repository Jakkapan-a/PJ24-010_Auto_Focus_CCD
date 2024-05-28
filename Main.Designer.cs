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
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            settingToolStripMenuItem = new ToolStripMenuItem();
            oNNXToolStripMenuItem = new ToolStripMenuItem();
            modelsToolStripMenuItem = new ToolStripMenuItem();
            configurationToolStripMenuItem = new ToolStripMenuItem();
            testToolStripMenuItem = new ToolStripMenuItem();
            runToolStripMenuItem = new ToolStripMenuItem();
            parameterToolStripMenuItem = new ToolStripMenuItem();
            captureToolStripMenuItem = new ToolStripMenuItem();
            clearMESToolStripMenuItem1 = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripProgressBar1 = new ToolStripProgressBar();
            panel1 = new Panel();
            lbDateTime = new Label();
            lbVoltage = new Label();
            lbCurrent = new Label();
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
            lbTitle = new Label();
            timer = new System.Windows.Forms.Timer(components);
            contextMenuStrip = new ContextMenuStrip(components);
            clearMESToolStripMenuItem = new ToolStripMenuItem();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            panel1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { settingToolStripMenuItem, testToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1209, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // settingToolStripMenuItem
            // 
            settingToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { oNNXToolStripMenuItem, modelsToolStripMenuItem, configurationToolStripMenuItem });
            settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            settingToolStripMenuItem.Size = new Size(56, 20);
            settingToolStripMenuItem.Text = "Setting";
            // 
            // oNNXToolStripMenuItem
            // 
            oNNXToolStripMenuItem.Name = "oNNXToolStripMenuItem";
            oNNXToolStripMenuItem.Size = new Size(159, 22);
            oNNXToolStripMenuItem.Text = "ONNX";
            oNNXToolStripMenuItem.Click += oNNXToolStripMenuItem_Click;
            // 
            // modelsToolStripMenuItem
            // 
            modelsToolStripMenuItem.Name = "modelsToolStripMenuItem";
            modelsToolStripMenuItem.Size = new Size(159, 22);
            modelsToolStripMenuItem.Text = "Models CCD";
            modelsToolStripMenuItem.Click += modelsToolStripMenuItem_Click;
            // 
            // configurationToolStripMenuItem
            // 
            configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            configurationToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            configurationToolStripMenuItem.Size = new Size(159, 22);
            configurationToolStripMenuItem.Text = "Options";
            configurationToolStripMenuItem.Click += configurationToolStripMenuItem_Click;
            // 
            // testToolStripMenuItem
            // 
            testToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { runToolStripMenuItem, parameterToolStripMenuItem, captureToolStripMenuItem, clearMESToolStripMenuItem1 });
            testToolStripMenuItem.Name = "testToolStripMenuItem";
            testToolStripMenuItem.Size = new Size(39, 20);
            testToolStripMenuItem.Text = "Test";
            // 
            // runToolStripMenuItem
            // 
            runToolStripMenuItem.Name = "runToolStripMenuItem";
            runToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.R;
            runToolStripMenuItem.Size = new Size(180, 22);
            runToolStripMenuItem.Text = "Run";
            // 
            // parameterToolStripMenuItem
            // 
            parameterToolStripMenuItem.Name = "parameterToolStripMenuItem";
            parameterToolStripMenuItem.Size = new Size(180, 22);
            parameterToolStripMenuItem.Text = "Parameter Simple";
            // 
            // captureToolStripMenuItem
            // 
            captureToolStripMenuItem.Name = "captureToolStripMenuItem";
            captureToolStripMenuItem.Size = new Size(180, 22);
            captureToolStripMenuItem.Text = "Capture";
            captureToolStripMenuItem.Click += captureToolStripMenuItem_Click;
            // 
            // clearMESToolStripMenuItem1
            // 
            clearMESToolStripMenuItem1.Name = "clearMESToolStripMenuItem1";
            clearMESToolStripMenuItem1.Size = new Size(180, 22);
            clearMESToolStripMenuItem1.Text = "Clear MES";
            clearMESToolStripMenuItem1.Click += clearMESToolStripMenuItem1_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripProgressBar1, toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 730);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1209, 24);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(100, 18);
            // 
            // panel1
            // 
            panel1.Controls.Add(lbDateTime);
            panel1.Controls.Add(lbVoltage);
            panel1.Controls.Add(lbCurrent);
            panel1.Controls.Add(txtLog);
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(groupBox1);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(1002, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(207, 706);
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
            // lbCurrent
            // 
            lbCurrent.AutoSize = true;
            lbCurrent.BackColor = Color.White;
            lbCurrent.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbCurrent.ForeColor = Color.Red;
            lbCurrent.Location = new Point(7, 42);
            lbCurrent.Name = "lbCurrent";
            lbCurrent.Size = new Size(44, 20);
            lbCurrent.TabIndex = 2;
            lbCurrent.Text = "--mA";
            // 
            // txtLog
            // 
            txtLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtLog.Location = new Point(7, 409);
            txtLog.Name = "txtLog";
            txtLog.Size = new Size(191, 297);
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
            panel2.Controls.Add(lbTitle);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 24);
            panel2.Name = "panel2";
            panel2.Size = new Size(1002, 706);
            panel2.TabIndex = 3;
            // 
            // pictureBox
            // 
            pictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox.BackColor = Color.Black;
            pictureBox.Location = new Point(12, 50);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(984, 653);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 1;
            pictureBox.TabStop = false;
            // 
            // lbTitle
            // 
            lbTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbTitle.BackColor = Color.Yellow;
            lbTitle.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTitle.Location = new Point(12, 3);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(984, 44);
            lbTitle.TabIndex = 0;
            lbTitle.Text = "CAMERA";
            lbTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { clearMESToolStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(128, 26);
            // 
            // clearMESToolStripMenuItem
            // 
            clearMESToolStripMenuItem.Name = "clearMESToolStripMenuItem";
            clearMESToolStripMenuItem.Size = new Size(127, 22);
            clearMESToolStripMenuItem.Text = "Clear MES";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.BorderSides = ToolStripStatusLabelBorderSides.Left;
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(16, 19);
            toolStripStatusLabel1.Text = "-";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1209, 754);
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
            contextMenuStrip.ResumeLayout(false);
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
        private Label lbTitle;
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
        private Label lbCurrent;
        private RichTextBox txtLog;
        private Label lbDateTime;
        private ToolStripMenuItem parameterToolStripMenuItem;
        private System.Windows.Forms.Timer timer;
        private ToolStripMenuItem modelsToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem clearMESToolStripMenuItem;
        private ToolStripMenuItem clearMESToolStripMenuItem1;
        private ToolStripMenuItem captureToolStripMenuItem;
        private ToolStripStatusLabel toolStripStatusLabel1;
    }
}
