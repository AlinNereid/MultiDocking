using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ClosedXML.Excel;
using MultiDocking.Controller;

namespace MultiDocking.UserInterface.Controls
{
    public partial class CalculateRMSDsControl : MUserControl
    {
        public CalculateRMSDsControl()
        {
            InitializeComponent();
        }

        public override void SetInput(string input)
        {
            if (textBoxPathInputResults.Text == string.Empty)
                textBoxPathInputResults.Text = input;
        }

        public void SetPdbFolder(string pdbFolderPath)
        {
            if (textBoxPathInputPdbs.Text == string.Empty)
                textBoxPathInputPdbs.Text = pdbFolderPath;
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            var folderBrowser = new FolderBrowserDialog();
            folderBrowser.SelectedPath = textBoxPathInputResults.Text;
            var res = folderBrowser.ShowDialog();
            if (res == DialogResult.OK)
            {
                textBoxPathInputResults.Text = folderBrowser.SelectedPath;
            }
        }

        private void buttonBrowsePdb_Click(object sender, EventArgs e)
        {
            var folderBrowser = new FolderBrowserDialog();
            folderBrowser.SelectedPath = textBoxPathInputPdbs.Text;
            var res = folderBrowser.ShowDialog();
            if (res == DialogResult.OK)
            {
                textBoxPathInputPdbs.Text = folderBrowser.SelectedPath;
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            checkedListBox.Items.Clear();
            foreach (var results in Directory.GetFiles(textBoxPathInputResults.Text, "*.pdbqt"))
            {
                checkedListBox.Items.Add(results, true);
            }
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

        private bool _abortWork = false;

        private bool AbortDownload()
        {
            return _abortWork;
        }

        private void buttonCalculateAndExport_Click(object sender, EventArgs e)
        {
            var saveFile = new SaveFileDialog();
            saveFile.DefaultExt = ".csv";
            saveFile.Filter = "CSV Document|*.csv|Excel Worksheet|*.xlsx";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                var files = new List<FileInfo>();
                for (int i = 0; i < checkedListBox.Items.Count; i++)
                {
                    if (checkedListBox.GetItemCheckState(i) == CheckState.Checked)
                    {
                        files.Add(new FileInfo(checkedListBox.Items[i] as string));
                    }
                }
                var results = new Dictionary<string,double>();
                _abortWork = false;
                var abortFunc = new Func<bool>(AbortDownload);
                ProgressDialog progressDialog = null;
                var actionStart = new Action(() =>
                {
                    results = Controllers.RmsdController.RunRmsds(files, textBoxPathInputPdbs.Text,
                        (barValue, eta) => { progressDialog.Refresh(barValue, eta); },
                        () => { Invoke(new Action(() => { progressDialog.Close(); })); },
                        abortFunc);
                });


                progressDialog = new ProgressDialog(actionStart, () => { _abortWork = true; });

                progressDialog.ShowDialog();

                if (!_abortWork)
                {
                    if (saveFile.FileName.ToLower().EndsWith("xlsx"))
                    {
                        var workbook = new XLWorkbook();
                        var worksheet = workbook.Worksheets.Add("RMSDs");

                        var row = 1;

                        worksheet.Row(row).Cell(1).Value = "Protein";
                        worksheet.Row(row).Cell(2).Value = "RMSD";
                        row++;

                        foreach (var result in results)
                        {
                            worksheet.Row(row).Cell(1).Value = result.Key;
                            worksheet.Row(row).Cell(2).Value = double.IsPositiveInfinity(result.Value) ? "-" : result.Value.ToString();
                            row++;
                        }

                        workbook.SaveAs(saveFile.FileName);
                    }
                    else
                    {
                        var sb = new StringBuilder();

                        sb.Append("Protein,RMSD\r\n");
                        foreach (var result in results)
                        {
                            sb.AppendLine($"\"{result.Key}\",\"{(double.IsPositiveInfinity(result.Value) ? "-" : result.Value.ToString())}\"");
                        }

                        File.WriteAllText(saveFile.FileName, sb.ToString());
                    }
                }
            }
        }
    }
}
