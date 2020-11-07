using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace MultiDocking.UserInterface.Controls
{
    public partial class ExportResultsControl : MUserControl
    {
        public ExportResultsControl()
        {
            InitializeComponent();
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
            foreach (var results in Directory.GetFiles(textBoxPathInput.Text, "*.txt"))
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

        private double MinEnergy(string content)
        {
            var splits = content.Split(Environment.NewLine.ToCharArray());
            var lineIndex = -1;
            for (var index = 0; index < splits.Length; index++)
            {
                var s = splits[index];
                if (s.Contains("-----"))
                {
                    lineIndex = index + 2;
                    break;
                }
            }

            return Convert.ToDouble(splits[lineIndex].Substring(11, 8));
        }

        private double Duration(string content)
        {
            var duration = content.IndexOf("Duration (seconds): ");

            return Convert.ToDouble(content.Substring(duration + "Duration (seconds): ".Length,
                content.Length - (duration + "Duration (seconds): ".Length)));
        }

        private void buttonExportToExcel_Click(object sender, EventArgs e)
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


                if (saveFile.FileName.ToLower().EndsWith("xlsx"))
                {
                    
                    var workbook = new XLWorkbook();
                    var worksheet = workbook.Worksheets.Add("MinEnergy");

                    var row = 1;

                    worksheet.Row(row).Cell(1).Value = "Protein";
                    worksheet.Row(row).Cell(2).Value = "MinEnergy";
                    worksheet.Row(row).Cell(3).Value = "Duration (seconds)";
                    row++;

                    foreach (var fileInfo in files)
                    {
                        var content = File.ReadAllText(fileInfo.FullName);
                        worksheet.Row(row).Cell(1).Value = fileInfo.Name;
                        worksheet.Row(row).Cell(2).Value = MinEnergy(content);
                        worksheet.Row(row).Cell(3).Value = Duration(content);
                        row++;
                    }

                    workbook.SaveAs(saveFile.FileName);
                }
                else
                {
                    var sb = new StringBuilder();

                    sb.Append("Protein,MinEnergy,Duration (seconds)\r\n");
                    foreach (var fileInfo in files)
                    {
                        var content = File.ReadAllText(fileInfo.FullName);
                        sb.AppendLine($"\"{fileInfo.Name}\",\"{MinEnergy(content)}\",\"{Duration(content)}\"");
                    }

                    File.WriteAllText(saveFile.FileName, sb.ToString());
                }
            }
        }
    }
}
