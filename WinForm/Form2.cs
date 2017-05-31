using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Permissions;

namespace WinForm
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            webBrowser1.ObjectForScripting = this;
            webBrowser1.DocumentText = WinForm.Resource1.test;

        }

        public void CallMessageBox(string message)
        {
            MessageBox.Show(message);
        }

        public void SetPoint(string lat, string lng)
        {
            this.textBox_Lat.Text = lat;
            this.textBox_Lng.Text = lng;
        }

        private void button_CallWebBrowser_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.textBox_Lat.Text.Trim()) && !string.IsNullOrEmpty(this.textBox_Lng.Text.Trim()))
                this.webBrowser1.Navigate("javascript:AddMarker('" + this.textBox_Lat.Text.Trim() + "','" + this.textBox_Lng.Text.Trim() + "');void(0);");
            else
                MessageBox.Show("Lat && Lng 不得為空!!");
        }

    }
}
