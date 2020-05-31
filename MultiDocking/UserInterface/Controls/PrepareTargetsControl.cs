using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using MultiDocking.Controller;
using NLog;

namespace MultiDocking.UserInterface.Controls
{
    public partial class PrepareTargetsControl : MUserControl
    {
        private Logger _logger = LogManager.GetCurrentClassLogger();

        public PrepareTargetsControl()
        {
            InitializeComponent();
            groupBoxRemove.Visible = false;
            groupBoxResults.Visible = false;
            textBoxPathOutput.Text = Path.Combine(Settings.Default.WorkSpacePath, "onlyProteins");
        }

        public override string GetOutputPath()
        {
            return textBoxPathOutput.Text;
        }

        public override void SetInput(string input)
        {
            if (textBoxPathInput.Text == string.Empty)
                textBoxPathInput.Text = input;
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            var folderBrowser = new FolderBrowserDialog();
            folderBrowser.SelectedPath = textBoxPathInput.Text;
            var res = folderBrowser.ShowDialog();
            if (res == DialogResult.OK)
            {
                textBoxPathInput.Text = folderBrowser.SelectedPath;
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            checkedListBox.Items.Clear();
            foreach (var pdb in Directory.GetFiles(textBoxPathInput.Text,"*.pdb"))
            {
                checkedListBox.Items.Add(pdb, true);
            }
            textBoxPathOutput.Text = Path.Combine(Settings.Default.WorkSpacePath, "onlyProteins");
            groupBoxRemove.Visible = true;
            groupBoxResults.Visible = true;
            Cursor = Cursors.Arrow;
        }

        private void buttonSelectNone_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                checkedListBox.SetItemChecked(i, false);
            }
        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                checkedListBox.SetItemChecked(i, true);
            }
        }

        private void buttonBrowserOutput_Click(object sender, EventArgs e)
        {
            var folderBrowser = new FolderBrowserDialog();
            folderBrowser.SelectedPath = textBoxPathOutput.Text;
            var res = folderBrowser.ShowDialog();
            if (res == DialogResult.OK)
            {
                textBoxPathOutput.Text = folderBrowser.SelectedPath;
            }
        }

        private bool _abortDownload = false;
        private bool AbortDownload()
        {
            return _abortDownload;
        }

        private void buttonRemoveLigands_Click(object sender, EventArgs e)
        {
            var files = new List<FileInfo>();
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                if (checkedListBox.GetItemCheckState(i) == CheckState.Checked)
                {
                    files.Add(new FileInfo(checkedListBox.Items[i] as string));
                }
            }
            _abortDownload = false;
            var abortFunc = new Func<bool>(AbortDownload);
            ProgressDialog progressDialog = null;
            var actionStart = new Action(() =>
            {
                Controllers.RemoveLigandsController.RemoveLigands(files, textBoxPathOutput.Text,
                    (barValue, eta) => { progressDialog.Refresh(barValue, eta); },
                    () => { Invoke(new Action(() => { progressDialog.Close(); })); },
                    abortFunc);
            });

            progressDialog = new ProgressDialog(actionStart, () => { _abortDownload = true; });

            progressDialog.ShowDialog();
        }
    }
}
