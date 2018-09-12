using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBL;

namespace VC_UI
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();

            this.FormClosing += new FormClosingEventHandler(login_FormClosing);
            this.WindowState = FormWindowState.Maximized;
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            DBL.User user = new DBL.User();
            user.Username1 = textBoxUsername.Text;
            user.Password1 = textBoxPassword.Text;
            if (user.IsValidUser(user))
            {
                notificationUser(textBoxUsername.Text);

                manage c = new manage(textBoxUsername.Text);
                c.Show();
                this.Hide();

            }
            else
            {
                //MessageBox.Show("Your username and password are not matched !");
                textBoxPassword.Text = "";
                textBoxUsername.Select();
                textBoxUsername.SelectAll();
                labelAlert.Text = "Your username and password are not matched !";
                notificationUserFailed();
            }
        }

        void login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show("Do you want to Exit ?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else if (result == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonLogin.PerformClick();
            }
        }

        private void textBoxUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxPassword.Select();
            }
        }

        private void notificationUser(String usr)
        {
            var notification = new System.Windows.Forms.NotifyIcon()
            {
                Visible = true,
                Icon = System.Drawing.SystemIcons.Information,
                BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info,
                BalloonTipTitle = "Veloce Car Pvt Ltd",
                BalloonTipText = "Hi "+usr.ToUpper()+" We hope you are more active today !",
            };
            notification.ShowBalloonTip(5);
            notification.Dispose();
        }

        private void notificationUserFailed()
        {
            var notification = new System.Windows.Forms.NotifyIcon()
            {
                Visible = true,
                Icon = System.Drawing.SystemIcons.Information,
                BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Error,
                BalloonTipTitle = "Veloce Car Pvt Ltd",
                BalloonTipText = "Your username or password is wrong, Please check it and try again",
            };
            notification.ShowBalloonTip(5);
            notification.Dispose();
        }

    }
}
