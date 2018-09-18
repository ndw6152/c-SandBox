namespace PizzaBox
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pizzaIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // pizzaIcon
            // 
            this.pizzaIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.pizzaIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("pizzaIcon.Icon")));
            this.pizzaIcon.Text = "PizzaBoxApp";
            this.pizzaIcon.Visible = true;
            this.pizzaIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PizzaIcon_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 361);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "PizzaBox";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PizzaForm_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.NotifyIcon pizzaIcon;
    }
}

