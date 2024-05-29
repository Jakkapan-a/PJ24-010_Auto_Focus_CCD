using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace PJ24_010_Auto_Focus_CCD.Helpers
{
    public partial class Notification : Form
    {
        public Notification()
        {
            InitializeComponent();
        }



        public enum NotificationAction
        {
            wait, start, close
        }

        public enum NotificationType
        {
            Success, Error, Warning, Info
        }

        private NotificationAction _action;

        private NotificationType _type;

        public NotificationType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public NotificationAction Action
        {
            get { return _action; }
            set { _action = value; }
        }

        private int x, y;
        private int duration = 5000;
        public void ShowNotification(string message, NotificationType type = NotificationType.Success, int duration = 5000)
        {
            this.Type = type;
            this.ShowNotification(message, duration);
        }

        public void ShowNotification(string message, int duration = 5000)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;
            for (int i = 1; i < 10; i++)
            {
                fname = "alert" + i.ToString();
                Notification frm = (Notification)Application.OpenForms[fname];
                if (frm == null)
                {
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i - 5 * i;
                    this.Location = new Point(this.x, this.y);
                    break;
                }
            }

            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

            switch(this.Type)
            {
                case NotificationType.Success:
                    this.pbIcon.Image = Properties.Resources.success;
                    this.BackColor = Color.SeaGreen;
                    break;
                case NotificationType.Error:
                    this.pbIcon.Image = Properties.Resources.error;
                    this.BackColor = Color.DarkRed;
                    break;
                case NotificationType.Warning:
                    this.pbIcon.Image = Properties.Resources.warning;
                    this.BackColor = Color.DarkOrange;
                    break;
                case NotificationType.Info:
                    this.pbIcon.Image = Properties.Resources.info;
                    this.BackColor = Color.DarkBlue;
                    break;
            }



            this.Message.Text = message;
            this.Show();

            this.Action = NotificationAction.start;
            this.duration = duration;
            this.timer1.Start();
            this.timer1.Interval = 1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Action = NotificationAction.close;
            this.timer1.Interval = 1;
        }

        private void Timer1_Tick(object? sender, EventArgs e)
        {
            switch (this.Action)
            {
                case NotificationAction.wait:
                    this.timer1.Interval = this.duration;
                    this.Action = NotificationAction.close;
                    this.timer1.Start();
                    break;
                case NotificationAction.start:
                    this.timer1.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            this.Action = NotificationAction.wait;
                        }
                    }
                    break;
                case NotificationAction.close:
                    this.timer1.Interval = 1;
                    this.Opacity -= 0.1;
                    this.Left -= 3;
                    if (base.Opacity == 0.0)
                    {
                        this.timer1.Stop();
                        base.Close();
                    }
                    break;
            }
        }
    }
}
