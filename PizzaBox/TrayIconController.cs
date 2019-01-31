﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaBox
{
    public class TrayIconController : ITrayController
    {
        public TrayIconController()
        {
            InitTrayIcon();
        }

        public NotifyIcon TrayIcon { get; set; }
        private ContextMenu Menu { get; set; }

        private void InitTrayIcon()
        {
            TrayIcon = new NotifyIcon();
            TrayIcon.Icon = new System.Drawing.Icon(@"Assets/pizza.ico");
            TrayIcon.Text = "Pizza Manager";
            TrayIcon.Visible = true;

            AddOnClicks();
        }

        private void AddOnClicks()
        {
            TrayIcon.MouseClick += new MouseEventHandler(this.TrayIconSingleClick);
            TrayIcon.BalloonTipClicked += new EventHandler(BalloonTipOnClick);
        }



        private void InitContextMenu()
        {
        }

        private void ShowBaloonTip(String msg)
        {
            TrayIcon.BalloonTipIcon = ToolTipIcon.None;
            TrayIcon.BalloonTipText = "" + msg;
            TrayIcon.BalloonTipTitle = "Welcome Message";
            TrayIcon.ShowBalloonTip(2000);
        }

        #region  Event Handlers
        private void BalloonTipOnClick(object sender, EventArgs e)
        {
            ShowBaloonTip("balloon clicked");
        }

        private void TrayIconSingleClick(object Sender, MouseEventArgs e)
        {
            if(e.Button.Equals(MouseButtons.Left)) 
            {
                Form1 window = new Form1();
                window.Show();


            }
            else
            {
                ShowBaloonTip("Right Click");
            }

        }
        #endregion 
    }
}
