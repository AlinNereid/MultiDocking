using System;
using System.Diagnostics;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Drawing;
using MultiDocking.Controller;

namespace MultiDocking.UserInterface
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            Controllers.WorkSpacePath = Settings.Default.WorkSpacePath;
            InitializeComponent();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 1)
            {
                prepareTargetsControl.SetInput(downloadPdbControl.GetOutputPath());
            }
            else if (tabControl.SelectedIndex == 2)
            {
                targetsToPdbqtControl.SetInput(prepareTargetsControl.GetOutputPath());
            }
            else if (tabControl.SelectedIndex == 3)
            {
                runMultiDockingControl.SetInput(targetsToPdbqtControl.GetOutputPath());
            }
            else if (tabControl.SelectedIndex == 4)
            {
                exportResultsControl.SetInput(runMultiDockingControl.GetOutputPath());
            }
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            new AboutMultiDocking().ShowDialog();
        }

        private void buttonUserManual_Click(object sender, EventArgs e)
        {
            Process.Start(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(
                    System.Reflection.Assembly.GetEntryAssembly().Location),
                @"Resources\UserManual\MultiDockingUserManual.pdf"));
        }

        private void buttonReportBug_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/AlinNereid/MultiDocking/issues");
        }

        private void buttonAskAQuestion_Click(object sender, EventArgs e)
        {
            string mailto = string.Format("mailto:{0}?Subject={1}", "gina.lupascu@yahoo.com", "Question about Multi Docking");
            mailto = Uri.EscapeUriString(mailto);
            System.Diagnostics.Process.Start(mailto);
        }
    }
}
