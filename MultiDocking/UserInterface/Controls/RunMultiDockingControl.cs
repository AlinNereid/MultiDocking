using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using MultiDocking.Controller;

namespace MultiDocking.UserInterface.Controls
{
    public partial class RunMultiDockingControl : MUserControl
    {
        public RunMultiDockingControl()
        {
            InitializeComponent();
            groupBoxRemove.Visible = false;
            groupBoxResults.Visible = false;
            textBoxPathLigand.Text = Settings.Default.LigandPath;
            textBoxVinaPath.Text = Settings.Default.VinaPath;
            textBoxExhaustiveness.Text = Settings.Default.Exhaustiveness.ToString();
            textBoxNumModes.Text = Settings.Default.NumModes.ToString();
            checkBoxFirstMer.Checked = Settings.Default.FirstMer;
            dockingRunsTextBox.Text = Settings.Default.DockingRuns.ToString();
        }

        public override string GetOutputPath()
        {
            return textBoxResultsPath.Text;
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
            if (res == DialogResult.OK) textBoxPathInput.Text = folderBrowser.SelectedPath;
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            checkedListBox.Items.Clear();
            foreach (var pdb in Directory.GetFiles(textBoxPathInput.Text, "*.pdb")) checkedListBox.Items.Add(pdb, true);
            textBoxResultsPath.Text = Path.Combine(Settings.Default.WorkSpacePath, "dockingResults");
            groupBoxRemove.Visible = true;
            groupBoxResults.Visible = true;
            Cursor = Cursors.Arrow;
        }

        private void buttonSelectNone_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < checkedListBox.Items.Count; i++) checkedListBox.SetItemChecked(i, false);
        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < checkedListBox.Items.Count; i++) checkedListBox.SetItemChecked(i, true);
        }

        private void buttonBrowseLigand_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = "pdbqt";
            openFileDialog.Filter = "pdbqt |*.pdbqt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxPathLigand.Text = openFileDialog.FileName;
                Settings.Default.LigandPath = textBoxPathLigand.Text;
                Settings.Default.Save();
            }
        }

        private bool _abortDownload = false;

        private bool AbortDownload()
        {
            return _abortDownload;
        }

        private void buttonRunDocking_Click(object sender, EventArgs e)
        {
            Settings.Default.LigandPath = textBoxPathLigand.Text;
            Settings.Default.VinaPath = textBoxVinaPath.Text;
            Settings.Default.NumModes = Convert.ToDouble(textBoxNumModes.Text);
            Settings.Default.Exhaustiveness = Convert.ToDouble(textBoxExhaustiveness.Text);
            Settings.Default.FirstMer = checkBoxFirstMer.Checked;
            Settings.Default.DockingRuns = Convert.ToInt32(dockingRunsTextBox.Text);
            Settings.Default.Save();

            var files = new List<FileInfo>();
            for (var i = 0; i < checkedListBox.Items.Count; i++)
                if (checkedListBox.GetItemCheckState(i) == CheckState.Checked)
                    files.Add(new FileInfo(checkedListBox.Items[i] as string));

            _abortDownload = false;
            var abortFunc = new Func<bool>(AbortDownload);
            ProgressDialog progressDialog = null;
            var actionStart = new Action(() =>
            {
                Controllers.DockingVinaController.RunVina(files, textBoxResultsPath.Text, textBoxPathLigand.Text,
                    checkBoxFirstMer.Checked,
                    Convert.ToInt32(dockingRunsTextBox.Text),
                    (barValue, eta) => { progressDialog.Refresh(barValue, eta); },
                    () => { Invoke(new Action(() => { progressDialog.Close(); })); },
                    abortFunc);
            });


            progressDialog = new ProgressDialog(actionStart, () => { _abortDownload = true; });

            progressDialog.ShowDialog();
        }
    }
}