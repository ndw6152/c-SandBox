using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void PizzaForm_Closing(object sender, FormClosingEventArgs e)
        {
            //if the form is minimized  
            //hide it from the task bar  
            //and show the system tray icon (represented by the NotifyIcon control)  
            e.Cancel = true;
            Hide();
        }

        // make sure to enable notifications in the OS settings
        private void ShowBaloonTip(String msg)
        {
            pizzaIcon.BalloonTipIcon = ToolTipIcon.None;
            pizzaIcon.BalloonTipText = "" + msg;
            pizzaIcon.BalloonTipTitle = "Welcome Message";
            pizzaIcon.ShowBalloonTip(100);
        }

        private void PizzaIcon_MouseClick(object sender, MouseEventArgs e)
        {
            
                this.Show();
                this.WindowState = FormWindowState.Normal;
                Debug.WriteLine("" + this.WindowState);
            
        }
    }
}
