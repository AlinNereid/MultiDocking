using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using MultiDocking.Controller;

namespace MultiDocking.UserInterface.Controls
{
    public partial class TargetsToPdbqtControl : MUserControl
    {
        public TargetsToPdbqtControl()
        {
            InitializeComponent();
            groupBoxRemove.Visible = false;
            groupBoxResults.Visible = false;

            textBoxPythonPath.Text = Settings.Default.MGLToolsPython;
            textBoxScript.Text = Settings.Default.PrepareReceptorScript;
            textBoxPathOutput.Text = Path.Combine(Settings.Default.WorkSpacePath, "proteinsPdbqt");
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
            foreach (var pdb in Directory.GetFiles(textBoxPathInput.Text, "*.pdb"))
            {
                checkedListBox.Items.Add(pdb, true);
            }
            textBoxPathOutput.Text = Path.Combine(Settings.Default.WorkSpacePath, "proteinsPdbqt");
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

        private void buttonConvertToPdbQt_Click(object sender, EventArgs e)
        {
            Settings.Default.MGLToolsPython = textBoxPythonPath.Text;
            Settings.Default.PrepareReceptorScript = textBoxScript.Text;
            Settings.Default.Save();

            var files = new List<string>();
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                if (checkedListBox.GetItemCheckState(i) == CheckState.Checked)
                {
                    files.Add(checkedListBox.Items[i] as string);
                }
            }

            _abortDownload = false;
            var abortFunc = new Func<bool>(AbortDownload);
            ProgressDialog progressDialog = null;

            var actionStart = new Action(() =>
            {
                Controllers.PrepareReceptorController.PdbToPdbqtFolder(files, textBoxPathInput.Text, textBoxPathOutput.Text,
                (barValue, eta) => { progressDialog.Refresh(barValue, eta); },
                () => { Invoke(new Action(() => { progressDialog.Close(); })); },
                abortFunc);
            });

            progressDialog = new ProgressDialog(actionStart, () => { _abortDownload = true; });

            progressDialog.ShowDialog();
        }
    }
}
