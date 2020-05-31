using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace MultiDocking.UserInterface
{
    public partial class AboutMultiDocking : Form
    {
        public AboutMultiDocking()
        {
            InitializeComponent();
            labelTitle.Text += " " + Assembly.GetExecutingAssembly().GetName().Version.Major + "." +
                               Assembly.GetExecutingAssembly().GetName().Version.Minor;
        }

        private void buttonLicense_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/AlinNereid/MultiDocking/blob/master/LICENSE");
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start((sender as LinkLabel).Text);
        }

    }
}
