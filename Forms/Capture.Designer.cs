namespace PJ24_010_Auto_Focus_CCD.Forms
{
    partial class Capture
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
            btnCapture = new Button();
            SuspendLayout();
            // 
            // btnCapture
            // 
            btnCapture.Anchor = AnchorStyles.None;
            btnCapture.Location = new Point(39, 31);
            btnCapture.Name = "btnCapture";
            btnCapture.Size = new Size(178, 44);
            btnCapture.TabIndex = 0;
            btnCapture.Text = "CAPTURE";
            btnCapture.UseVisualStyleBackColor = true;
            // 
            // Capture
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(267, 114);
            Controls.Add(btnCapture);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Capture";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Capture";
            Load += Capture_Load;
            ResumeLayout(false);
        }

        #endregion

        public Button btnCapture;
    }
}