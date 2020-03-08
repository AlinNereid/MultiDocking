namespace MultiDocking.UserInterface.Controls
{
    partial class TargetsToPdbqtControl
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
            this.groupBoxRemove = new System.Windows.Forms.GroupBox();
            this.textBoxScript = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPythonPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonConvertToPdbQt = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPathOutput = new System.Windows.Forms.TextBox();
            this.groupBoxResults.SuspendLayout();
            this.groupBoxRemove.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxResults
            // 
            this.groupBoxResults.Controls.Add(this.checkedListBox);
            this.groupBoxResults.Controls.Add(this.buttonSelectAll);
            this.groupBoxResults.Controls.Add(this.buttonSelectNone);
            this.groupBoxResults.Location = new System.Drawing.Point(13, 34);
            this.groupBoxResults.Name = "groupBoxResults";
            this.groupBoxResults.Size = new System.Drawing.Size(945, 493);
            this.groupBoxResults.TabIndex = 19;
            this.groupBoxResults.TabStop = false;
            this.groupBoxResults.Text = "Results";
            // 
            // checkedListBox
            // 
            this.checkedListBox.FormattingEnabled = true;
            this.checkedListBox.Location = new System.Drawing.Point(6, 19);
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.Size = new System.Drawing.Size(933, 439);
            this.checkedListBox.TabIndex = 3;
            // 
            // buttonSelectAll
            // 
            this.buttonSelectAll.Location = new System.Drawing.Point(828, 464);
            this.buttonSelectAll.Name = "buttonSelectAll";
            this.buttonSelectAll.Size = new System.Drawing.Size(111, 23);
            this.buttonSelectAll.TabIndex = 5;
            this.buttonSelectAll.Text = "Select All";
            this.buttonSelectAll.UseVisualStyleBackColor = true;
            this.buttonSelectAll.Click += new System.EventHandler(this.buttonSelectAll_Click);
            // 
            // buttonSelectNone
            // 
            this.buttonSelectNone.Location = new System.Drawing.Point(711, 464);
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
            this.buttonLoad.TabIndex = 18;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(739, 6);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(105, 23);
            this.buttonBrowse.TabIndex = 15;
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
            this.labelPath.TabIndex = 16;
            this.labelPath.Text = "Path:";
            // 
            // textBoxPathInput
            // 
            this.textBoxPathInput.Location = new System.Drawing.Point(48, 8);
            this.textBoxPathInput.Name = "textBoxPathInput";
            this.textBoxPathInput.Size = new System.Drawing.Size(685, 20);
            this.textBoxPathInput.TabIndex = 17;
            // 
            // groupBoxRemove
            // 
            this.groupBoxRemove.Controls.Add(this.textBoxScript);
            this.groupBoxRemove.Controls.Add(this.label3);
            this.groupBoxRemove.Controls.Add(this.textBoxPythonPath);
            this.groupBoxRemove.Controls.Add(this.label2);
            this.groupBoxRemove.Controls.Add(this.buttonConvertToPdbQt);
            this.groupBoxRemove.Controls.Add(this.button1);
            this.groupBoxRemove.Controls.Add(this.label1);
            this.groupBoxRemove.Controls.Add(this.textBoxPathOutput);
            this.groupBoxRemove.Location = new System.Drawing.Point(7, 533);
            this.groupBoxRemove.Name = "groupBoxRemove";
            this.groupBoxRemove.Size = new System.Drawing.Size(951, 130);
            this.groupBoxRemove.TabIndex = 20;
            this.groupBoxRemove.TabStop = false;
            this.groupBoxRemove.Text = "Convert to PDBQT";
            // 
            // textBoxScript
            // 
            this.textBoxScript.Location = new System.Drawing.Point(158, 71);
            this.textBoxScript.Name = "textBoxScript";
            this.textBoxScript.Size = new System.Drawing.Size(787, 20);
            this.textBoxScript.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Path prepare_receptor4.py:";
            // 
            // textBoxPythonPath
            // 
            this.textBoxPythonPath.Location = new System.Drawing.Point(158, 45);
            this.textBoxPythonPath.Name = "textBoxPythonPath";
            this.textBoxPythonPath.Size = new System.Drawing.Size(787, 20);
            this.textBoxPythonPath.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Path python MGLTools-1.5.6:";
            // 
            // buttonConvertToPdbQt
            // 
            this.buttonConvertToPdbQt.Location = new System.Drawing.Point(765, 97);
            this.buttonConvertToPdbQt.Name = "buttonConvertToPdbQt";
            this.buttonConvertToPdbQt.Size = new System.Drawing.Size(180, 23);
            this.buttonConvertToPdbQt.TabIndex = 9;
            this.buttonConvertToPdbQt.Text = "Convert To Pdbqt";
            this.buttonConvertToPdbQt.UseVisualStyleBackColor = true;
            this.buttonConvertToPdbQt.Click += new System.EventHandler(this.buttonConvertToPdbQt_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(840, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonBrowserOutput_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Path:";
            // 
            // textBoxPathOutput
            // 
            this.textBoxPathOutput.Location = new System.Drawing.Point(44, 19);
            this.textBoxPathOutput.Name = "textBoxPathOutput";
            this.textBoxPathOutput.Size = new System.Drawing.Size(784, 20);
            this.textBoxPathOutput.TabIndex = 8;
            // 
            // TargetsToPdbqtControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxResults);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.textBoxPathInput);
            this.Controls.Add(this.groupBoxRemove);
            this.Name = "TargetsToPdbqtControl";
            this.Size = new System.Drawing.Size(970, 670);
            this.groupBoxResults.ResumeLayout(false);
            this.groupBoxRemove.ResumeLayout(false);
            this.groupBoxRemove.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBoxRemove;
        private System.Windows.Forms.Button buttonConvertToPdbQt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPathOutput;
        private System.Windows.Forms.TextBox textBoxPythonPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxScript;
        private System.Windows.Forms.Label label3;
    }
}
