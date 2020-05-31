using System;
using System.Windows.Forms;
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
    }
}
