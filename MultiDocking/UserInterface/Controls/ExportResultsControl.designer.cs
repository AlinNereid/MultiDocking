namespace MultiDocking.UserInterface.Controls
{
    partial class ExportResultsControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxResults = new System.Windows.Forms.GroupBox();
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.buttonSelectAll = new System.Windows.Forms.Button();
            this.buttonSelectNone = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.labelPath = new System.Windows.Forms.Label();
            this.textBoxPathInput = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBoxResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxResults
            // 
            this.groupBoxResults.Controls.Add(this.checkedListBox);
            this.groupBoxResults.Controls.Add(this.buttonSelectAll);
            this.groupBoxResults.Controls.Add(this.buttonSelectNone);
            this.groupBoxResults.Location = new System.Drawing.Point(13, 34);
            this.groupBoxResults.Name = "groupBoxResults";
            this.groupBoxResults.Size = new System.Drawing.Size(945, 594);
            this.groupBoxResults.TabIndex = 24;
            this.groupBoxResults.TabStop = false;
            this.groupBoxResults.Text = "Results";
            // 
            // checkedListBox
            // 
            this.checkedListBox.FormattingEnabled = true;
            this.checkedListBox.Location = new System.Drawing.Point(6, 19);
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.Size = new System.Drawing.Size(933, 529);
            this.checkedListBox.TabIndex = 3;
            // 
            // buttonSelectAll
            // 
            this.buttonSelectAll.Location = new System.Drawing.Point(828, 554);
            this.buttonSelectAll.Name = "buttonSelectAll";
            this.buttonSelectAll.Size = new System.Drawing.Size(111, 23);
            this.buttonSelectAll.TabIndex = 5;
            this.buttonSelectAll.Text = "Select All";
            this.buttonSelectAll.UseVisualStyleBackColor = true;
            this.buttonSelectAll.Click += new System.EventHandler(this.buttonSelectAll_Click);
            // 
            // buttonSelectNone
            // 
            this.buttonSelectNone.Location = new System.Drawing.Point(711, 554);
            this.buttonSelectNone.Name = "buttonSelectNone";
            this.buttonSelectNone.Size = new System.Drawing.Size(111, 23);
            this.buttonSelectNone.TabIndex = 4;
            this.buttonSelectNone.Text = "Select None";
            this.buttonSelectNone.UseVisualStyleBackColor = true;
            this.buttonSelectNone.Click += new System.EventHandler(this.buttonSelectNone_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(850, 6);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(108, 23);
            this.buttonLoad.TabIndex = 23;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(739, 6);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(105, 23);
            this.buttonBrowse.TabIndex = 20;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(10, 11);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(32, 13);
            this.labelPath.TabIndex = 21;
            this.labelPath.Text = "Path:";
            // 
            // textBoxPathInput
            // 
            this.textBoxPathInput.Location = new System.Drawing.Point(48, 8);
            this.textBoxPathInput.Name = "textBoxPathInput";
            this.textBoxPathInput.Size = new System.Drawing.Size(685, 20);
            this.textBoxPathInput.TabIndex = 22;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 634);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(945, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "Export to CSV/XLS";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonExportToExcel_Click);
            // 
            // ExportResultsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBoxResults);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.textBoxPathInput);
            this.Name = "ExportResultsControl";
            this.Size = new System.Drawing.Size(970, 670);
            this.groupBoxResults.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxResults;
        private System.Windows.Forms.CheckedListBox checkedListBox;
        private System.Windows.Forms.Button buttonSelectAll;
        private System.Windows.Forms.Button buttonSelectNone;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.TextBox textBoxPathInput;
        private System.Windows.Forms.Button button1;
    }
}
