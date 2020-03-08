namespace MultiDocking.UserInterface.Controls
{
    partial class RunMultiDockingControl
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
            this.textBoxPathLigand = new System.Windows.Forms.TextBox();
            this.groupBoxResults = new System.Windows.Forms.GroupBox();
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.buttonSelectAll = new System.Windows.Forms.Button();
            this.buttonSelectNone = new System.Windows.Forms.Button();
            this.textBoxNumModes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.labelPath = new System.Windows.Forms.Label();
            this.textBoxExhaustiveness = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPathInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxRemove = new System.Windows.Forms.GroupBox();
            this.dockingRunsTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBoxFirstMer = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxVinaPath = new System.Windows.Forms.TextBox();
            this.buttonBrowseOutputPath = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxResultsPath = new System.Windows.Forms.TextBox();
            this.buttonConvertToPdbQt = new System.Windows.Forms.Button();
            this.groupBoxResults.SuspendLayout();
            this.groupBoxRemove.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxPathLigand
            // 
            this.textBoxPathLigand.Location = new System.Drawing.Point(79, 19);
            this.textBoxPathLigand.Name = "textBoxPathLigand";
            this.textBoxPathLigand.Size = new System.Drawing.Size(751, 20);
            this.textBoxPathLigand.TabIndex = 8;
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
            // textBoxNumModes
            // 
            this.textBoxNumModes.Location = new System.Drawing.Point(122, 71);
            this.textBoxNumModes.Name = "textBoxNumModes";
            this.textBoxNumModes.Size = new System.Drawing.Size(80, 20);
            this.textBoxNumModes.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Docking num_modes:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(840, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonBrowseLigand_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(850, 6);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(108, 23);
            this.buttonLoad.TabIndex = 24;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(739, 6);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(105, 23);
            this.buttonBrowse.TabIndex = 21;
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
            this.labelPath.TabIndex = 22;
            this.labelPath.Text = "Path:";
            // 
            // textBoxExhaustiveness
            // 
            this.textBoxExhaustiveness.Location = new System.Drawing.Point(346, 71);
            this.textBoxExhaustiveness.Name = "textBoxExhaustiveness";
            this.textBoxExhaustiveness.Size = new System.Drawing.Size(80, 20);
            this.textBoxExhaustiveness.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(214, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Docking exhaustiveness:";
            // 
            // textBoxPathInput
            // 
            this.textBoxPathInput.Location = new System.Drawing.Point(48, 8);
            this.textBoxPathInput.Name = "textBoxPathInput";
            this.textBoxPathInput.Size = new System.Drawing.Size(685, 20);
            this.textBoxPathInput.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Ligand Path:";
            // 
            // groupBoxRemove
            // 
            this.groupBoxRemove.Controls.Add(this.dockingRunsTextBox);
            this.groupBoxRemove.Controls.Add(this.label6);
            this.groupBoxRemove.Controls.Add(this.checkBoxFirstMer);
            this.groupBoxRemove.Controls.Add(this.label5);
            this.groupBoxRemove.Controls.Add(this.textBoxVinaPath);
            this.groupBoxRemove.Controls.Add(this.buttonBrowseOutputPath);
            this.groupBoxRemove.Controls.Add(this.label4);
            this.groupBoxRemove.Controls.Add(this.textBoxResultsPath);
            this.groupBoxRemove.Controls.Add(this.textBoxExhaustiveness);
            this.groupBoxRemove.Controls.Add(this.label3);
            this.groupBoxRemove.Controls.Add(this.textBoxNumModes);
            this.groupBoxRemove.Controls.Add(this.label2);
            this.groupBoxRemove.Controls.Add(this.buttonConvertToPdbQt);
            this.groupBoxRemove.Controls.Add(this.button1);
            this.groupBoxRemove.Controls.Add(this.label1);
            this.groupBoxRemove.Controls.Add(this.textBoxPathLigand);
            this.groupBoxRemove.Location = new System.Drawing.Point(7, 533);
            this.groupBoxRemove.Name = "groupBoxRemove";
            this.groupBoxRemove.Size = new System.Drawing.Size(951, 130);
            this.groupBoxRemove.TabIndex = 26;
            this.groupBoxRemove.TabStop = false;
            this.groupBoxRemove.Text = "Run Multi Docking";
            // 
            // dockingRunsTextBox
            // 
            this.dockingRunsTextBox.Location = new System.Drawing.Point(564, 71);
            this.dockingRunsTextBox.Name = "dockingRunsTextBox";
            this.dockingRunsTextBox.Size = new System.Drawing.Size(80, 20);
            this.dockingRunsTextBox.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(435, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Number of docking runs:";
            // 
            // checkBoxFirstMer
            // 
            this.checkBoxFirstMer.AutoSize = true;
            this.checkBoxFirstMer.Location = new System.Drawing.Point(879, 73);
            this.checkBoxFirstMer.Name = "checkBoxFirstMer";
            this.checkBoxFirstMer.Size = new System.Drawing.Size(66, 17);
            this.checkBoxFirstMer.TabIndex = 19;
            this.checkBoxFirstMer.Text = "First Mer";
            this.checkBoxFirstMer.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Vina path:";
            // 
            // textBoxVinaPath
            // 
            this.textBoxVinaPath.Location = new System.Drawing.Point(79, 45);
            this.textBoxVinaPath.Name = "textBoxVinaPath";
            this.textBoxVinaPath.Size = new System.Drawing.Size(866, 20);
            this.textBoxVinaPath.TabIndex = 17;
            // 
            // buttonBrowseOutputPath
            // 
            this.buttonBrowseOutputPath.Location = new System.Drawing.Point(650, 96);
            this.buttonBrowseOutputPath.Name = "buttonBrowseOutputPath";
            this.buttonBrowseOutputPath.Size = new System.Drawing.Size(105, 23);
            this.buttonBrowseOutputPath.TabIndex = 16;
            this.buttonBrowseOutputPath.Text = "Browse";
            this.buttonBrowseOutputPath.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Results path:";
            // 
            // textBoxResultsPath
            // 
            this.textBoxResultsPath.Location = new System.Drawing.Point(79, 98);
            this.textBoxResultsPath.Name = "textBoxResultsPath";
            this.textBoxResultsPath.Size = new System.Drawing.Size(565, 20);
            this.textBoxResultsPath.TabIndex = 14;
            // 
            // buttonConvertToPdbQt
            // 
            this.buttonConvertToPdbQt.Location = new System.Drawing.Point(761, 96);
            this.buttonConvertToPdbQt.Name = "buttonConvertToPdbQt";
            this.buttonConvertToPdbQt.Size = new System.Drawing.Size(184, 23);
            this.buttonConvertToPdbQt.TabIndex = 9;
            this.buttonConvertToPdbQt.Text = "Run Multi Docking";
            this.buttonConvertToPdbQt.UseVisualStyleBackColor = true;
            this.buttonConvertToPdbQt.Click += new System.EventHandler(this.buttonRunDocking_Click);
            // 
            // RunMultiDockingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxResults);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.textBoxPathInput);
            this.Controls.Add(this.groupBoxRemove);
            this.Name = "RunMultiDockingControl";
            this.Size = new System.Drawing.Size(970, 670);
            this.groupBoxResults.ResumeLayout(false);
            this.groupBoxRemove.ResumeLayout(false);
            this.groupBoxRemove.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPathLigand;
        private System.Windows.Forms.GroupBox groupBoxResults;
        private System.Windows.Forms.CheckedListBox checkedListBox;
        private System.Windows.Forms.Button buttonSelectAll;
        private System.Windows.Forms.Button buttonSelectNone;
        private System.Windows.Forms.TextBox textBoxNumModes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.TextBox textBoxExhaustiveness;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPathInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxRemove;
        private System.Windows.Forms.Button buttonConvertToPdbQt;
        private System.Windows.Forms.Button buttonBrowseOutputPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxResultsPath;
        private System.Windows.Forms.TextBox textBoxVinaPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBoxFirstMer;
        private System.Windows.Forms.TextBox dockingRunsTextBox;
        private System.Windows.Forms.Label label6;
    }
}
