using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using MultiDocking.Controller;

namespace MultiDocking.UserInterface.Controls
{
    public partial class DownloadPdbControl : MUserControl
    {
        public DownloadPdbControl()
        {
            InitializeComponent();
            groupBoxDownload.Visible = false;
            groupBoxResults.Visible = false;
            textBoxPath.Text = Path.Combine(Controllers.WorkSpacePath, "downloadPdb");
        }

        private async void buttonSearch_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var pdbs = await Controllers.RcsbController.GetPdbId(textBoxSearch.Text);
            checkedListBox.Items.Clear();
            foreach (var pdb in pdbs)
            {
                checkedListBox.Items.Add(pdb, true);
            }
            textBoxPath.Text = Path.Combine(Controllers.WorkSpacePath, "downloadPdb");
            groupBoxDownload.Visible = true;
            groupBoxResults.Visible = true;
            Cursor = Cursors.Arrow;
        }

        private void buttonSelectNone_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < checkedListBox.Items.Count; i++)
            {
                checkedListBox.SetItemChecked(i, false);
            }
        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < checkedListBox.Items.Count; i++)
            {
                checkedListBox.SetItemChecked(i, true);
            }
        }

        private bool _abortDownload = false;
        private bool AbortDownload()
        {
            return _abortDownload;
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            var pdbIds = new List<string>();
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                if (checkedListBox.GetItemCheckState(i) == CheckState.Checked)
                {
                    pdbIds.Add(checkedListBox.Items[i].ToString());
                }
            }

            _abortDownload = false;
            var abortFunc = new Func<bool>(AbortDownload);
            ProgressDialog progressDialog =null;
            var actionStart = new Action(() =>
            {
                Controllers.RcsbController.Download(textBoxPath.Text, pdbIds,
                    (barValue, eta) => { progressDialog.Refresh(barValue, eta); },
                    () => { Invoke(new Action(() => { progressDialog.Close(); })); },
                    abortFunc);
            });

            progressDialog = new ProgressDialog(actionStart, () => { _abortDownload = true; });

            progressDialog.ShowDialog();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            var folderBrowser = new FolderBrowserDialog();
            folderBrowser.SelectedPath = textBoxPath.Text;
            var res = folderBrowser.ShowDialog();
            if (res == DialogResult.OK)
            {
                textBoxPath.Text = folderBrowser.SelectedPath;
            }
        }

        public override string GetOutputPath()
        {
            return textBoxPath.Text;
        }
    }
}
