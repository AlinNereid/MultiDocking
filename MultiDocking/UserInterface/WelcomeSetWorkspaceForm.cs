using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using NLog;

namespace MultiDocking.UserInterface
{
    public partial class WelcomeSetWorkspaceForm : Form
    {
        private Logger _logger = LogManager.GetCurrentClassLogger();

        public string WorkSpacePath => textBoxPath.Text;
        public string MglToolsPath => mglToolsPath.Text;
        public string AutoDockVinaPath => autoDockVinaPath.Text;

        private const string AutoDockVinaDefaultPath = @"C:\Program Files (x86)\The Scripps Research Institute\Vina";
        private const string MglToolsDefaultPath = @"C:\Program Files (x86)\MGLTools-1.5.6";

        public WelcomeSetWorkspaceForm()
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Settings.Default.AutoDockVinaPath))
            {
                if (Directory.Exists(AutoDockVinaDefaultPath))
                {
                    autoDockVinaPath.Text = AutoDockVinaDefaultPath;
                }
            }
            else
            {
                autoDockVinaPath.Text = Settings.Default.AutoDockVinaPath;
            }

            if (string.IsNullOrEmpty(Settings.Default.MglToolsPath))
            {
                if (Directory.Exists(MglToolsDefaultPath))
                {
                    mglToolsPath.Text = MglToolsDefaultPath;
                }
            }
            else
            {
                mglToolsPath.Text = Settings.Default.MglToolsPath;
            }

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
            if (AutoDockVinaPath != Settings.Default.AutoDockVinaPath)
            {
                Settings.Default.VinaPath = Path.Combine(AutoDockVinaPath, "vina.exe");
            }
            Settings.Default.AutoDockVinaPath = AutoDockVinaPath;
            if (MglToolsPath != Settings.Default.MglToolsPath)
            {
                Settings.Default.MGLToolsPython = Path.Combine(MglToolsPath, "python.exe");
                Settings.Default.PrepareReceptorScript = Path.Combine(MglToolsPath, @"\Lib\site-packages\AutoDockTools\Utilities24\prepare_receptor4.py");
            }
            Settings.Default.MglToolsPath = MglToolsPath;
            Settings.Default.Save();
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start((sender as LinkLabel).Text);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start((sender as LinkLabel).Text);
        }

        private void mglToolsBrowse_Click(object sender, EventArgs e)
        {
            var browseFolder = new FolderBrowserDialog();
            browseFolder.SelectedPath = mglToolsPath.Text;
            if (browseFolder.ShowDialog() == DialogResult.OK)
            {
                mglToolsPath.Text = browseFolder.SelectedPath;
            }
        }

        private void autoDockVinaBrowse_Click(object sender, EventArgs e)
        {
            var browseFolder = new FolderBrowserDialog();
            browseFolder.SelectedPath = autoDockVinaPath.Text;
            if (browseFolder.ShowDialog() == DialogResult.OK)
            {
                autoDockVinaPath.Text = browseFolder.SelectedPath;
            }
        }
    }
}
