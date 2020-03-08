using System;
using System.Windows.Forms;
using NLog;

namespace MultiDocking.UserInterface
{
    public partial class WelcomeSetWorkspaceForm : Form
    {
        private Logger _logger = LogManager.GetCurrentClassLogger();

        public string WorkSpacePath => textBoxPath.Text;
        public WelcomeSetWorkspaceForm()
        {
            InitializeComponent();

            textBoxPath.Text = Settings.Default.WorkSpacePath;
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            var browseFolder = new FolderBrowserDialog();
            browseFolder.SelectedPath = textBoxPath.Text;
            if (browseFolder.ShowDialog() == DialogResult.OK)
            {
                textBoxPath.Text = browseFolder.SelectedPath;
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            _logger.Debug("Set Workspace");
            Settings.Default.WorkSpacePath = WorkSpacePath;
            Settings.Default.Save();
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
