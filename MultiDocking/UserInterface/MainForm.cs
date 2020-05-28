using System;
using System.Windows.Forms;
using MultiDocking.Controller;

namespace MultiDocking.UserInterface
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var welcomeForm = new WelcomeSetWorkspaceForm();
            welcomeForm.ShowDialog();
            if (welcomeForm.DialogResult != DialogResult.OK)
                Application.Exit();
            Controllers.WorkSpacePath = Settings.Default.WorkSpacePath;
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
