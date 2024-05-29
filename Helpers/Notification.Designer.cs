namespace PJ24_010_Auto_Focus_CCD.Helpers
{
    partial class Notification
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
            components = new System.ComponentModel.Container();
            Message = new Label();
            btnClose = new Button();
            pbIcon = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pbIcon).BeginInit();
            SuspendLayout();
            // 
            // Message
            // 
            Message.AutoSize = true;
            Message.BackColor = Color.Transparent;
            Message.ForeColor = Color.White;
            Message.Location = new Point(69, 26);
            Message.Name = "Message";
            Message.Size = new Size(91, 22);
            Message.TabIndex = 0;
            Message.Text = "Message";
            // 
            // btnClose
            // 
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.ForeColor = Color.White;
            btnClose.Image = Properties.Resources.cancel;
            btnClose.Location = new Point(311, 20);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(38, 34);
            btnClose.TabIndex = 1;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // pbIcon
            // 
            pbIcon.Image = Properties.Resources.success;
            pbIcon.Location = new Point(12, 12);
            pbIcon.Name = "pbIcon";
            pbIcon.Size = new Size(51, 50);
            pbIcon.SizeMode = PictureBoxSizeMode.CenterImage;
            pbIcon.TabIndex = 2;
            pbIcon.TabStop = false;
            // 
            // timer1
            // 
            timer1.Tick += Timer1_Tick;
            // 
            // Notification
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.Highlight;
            ClientSize = new Size(361, 74);
            Controls.Add(pbIcon);
            Controls.Add(btnClose);
            Controls.Add(Message);
            Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Notification";
            Text = "Notification";
            ((System.ComponentModel.ISupportInitialize)pbIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Message;
        private Button btnClose;
        private PictureBox pbIcon;
        private System.Windows.Forms.Timer timer1;
    }
}