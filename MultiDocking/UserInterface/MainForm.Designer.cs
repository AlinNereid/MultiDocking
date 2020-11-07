namespace MultiDocking.UserInterface
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.downloadPdbControl = new MultiDocking.UserInterface.Controls.DownloadPdbControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.prepareTargetsControl = new MultiDocking.UserInterface.Controls.PrepareTargetsControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.targetsToPdbqtControl = new MultiDocking.UserInterface.Controls.TargetsToPdbqtControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.runMultiDockingControl = new MultiDocking.UserInterface.Controls.RunMultiDockingControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.exportResultsControl = new MultiDocking.UserInterface.Controls.ExportResultsControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.calculateRMSDsControl = new MultiDocking.UserInterface.Controls.CalculateRMSDsControl();
            this.tabHelp = new System.Windows.Forms.TabPage();
            this.buttonAskAQuestion = new System.Windows.Forms.Button();
            this.buttonReportBug = new System.Windows.Forms.Button();
            this.buttonUserManual = new System.Windows.Forms.Button();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabHelp.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Controls.Add(this.tabPage5);
            this.tabControl.Controls.Add(this.tabPage6);
            this.tabControl.Controls.Add(this.tabHelp);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(984, 705);
            this.tabControl.TabIndex = 2;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.downloadPdbControl);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(976, 679);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Search Targets";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // downloadPdbControl
            // 
            this.downloadPdbControl.Location = new System.Drawing.Point(2, 2);
            this.downloadPdbControl.Name = "downloadPdbControl";
            this.downloadPdbControl.Size = new System.Drawing.Size(970, 670);
            this.downloadPdbControl.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.prepareTargetsControl);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(976, 679);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Prepare Targets";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // prepareTargetsControl
            // 
            this.prepareTargetsControl.Location = new System.Drawing.Point(2, 2);
            this.prepareTargetsControl.Name = "prepareTargetsControl";
            this.prepareTargetsControl.Size = new System.Drawing.Size(970, 670);
            this.prepareTargetsControl.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.targetsToPdbqtControl);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(976, 679);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Targets to PDBQT";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // targetsToPdbqtControl
            // 
            this.targetsToPdbqtControl.Location = new System.Drawing.Point(2, 2);
            this.targetsToPdbqtControl.Name = "targetsToPdbqtControl";
            this.targetsToPdbqtControl.Size = new System.Drawing.Size(970, 670);
            this.targetsToPdbqtControl.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.runMultiDockingControl);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(976, 679);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Run Multi Docking";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // runMultiDockingControl
            // 
            this.runMultiDockingControl.Location = new System.Drawing.Point(2, 2);
            this.runMultiDockingControl.Name = "runMultiDockingControl";
            this.runMultiDockingControl.Size = new System.Drawing.Size(970, 670);
            this.runMultiDockingControl.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.exportResultsControl);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(976, 679);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Export Results";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // exportResultsControl
            // 
            this.exportResultsControl.Location = new System.Drawing.Point(2, 2);
            this.exportResultsControl.Name = "exportResultsControl";
            this.exportResultsControl.Size = new System.Drawing.Size(970, 670);
            this.exportResultsControl.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.calculateRMSDsControl);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(976, 679);
            this.tabPage6.TabIndex = 6;
            this.tabPage6.Text = "Calculate RMSDs (experimental)";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // calculateRMSDsControl
            // 
            this.calculateRMSDsControl.Location = new System.Drawing.Point(2, 2);
            this.calculateRMSDsControl.Name = "calculateRMSDsControl";
            this.calculateRMSDsControl.Size = new System.Drawing.Size(970, 670);
            this.calculateRMSDsControl.TabIndex = 1;
            // 
            // tabHelp
            // 
            this.tabHelp.Controls.Add(this.buttonAskAQuestion);
            this.tabHelp.Controls.Add(this.buttonReportBug);
            this.tabHelp.Controls.Add(this.buttonUserManual);
            this.tabHelp.Controls.Add(this.buttonAbout);
            this.tabHelp.Location = new System.Drawing.Point(4, 22);
            this.tabHelp.Name = "tabHelp";
            this.tabHelp.Padding = new System.Windows.Forms.Padding(3);
            this.tabHelp.Size = new System.Drawing.Size(976, 679);
            this.tabHelp.TabIndex = 5;
            this.tabHelp.Text = "Help";
            this.tabHelp.UseVisualStyleBackColor = true;
            // 
            // buttonAskAQuestion
            // 
            this.buttonAskAQuestion.Location = new System.Drawing.Point(25, 107);
            this.buttonAskAQuestion.Name = "buttonAskAQuestion";
            this.buttonAskAQuestion.Size = new System.Drawing.Size(252, 23);
            this.buttonAskAQuestion.TabIndex = 3;
            this.buttonAskAQuestion.Text = "Ask a question";
            this.buttonAskAQuestion.UseVisualStyleBackColor = true;
            this.buttonAskAQuestion.Click += new System.EventHandler(this.buttonAskAQuestion_Click);
            // 
            // buttonReportBug
            // 
            this.buttonReportBug.Location = new System.Drawing.Point(25, 78);
            this.buttonReportBug.Name = "buttonReportBug";
            this.buttonReportBug.Size = new System.Drawing.Size(252, 23);
            this.buttonReportBug.TabIndex = 2;
            this.buttonReportBug.Text = "Report a bug";
            this.buttonReportBug.UseVisualStyleBackColor = true;
            this.buttonReportBug.Click += new System.EventHandler(this.buttonReportBug_Click);
            // 
            // buttonUserManual
            // 
            this.buttonUserManual.Location = new System.Drawing.Point(25, 49);
            this.buttonUserManual.Name = "buttonUserManual";
            this.buttonUserManual.Size = new System.Drawing.Size(252, 23);
            this.buttonUserManual.TabIndex = 1;
            this.buttonUserManual.Text = "User\'s Manual";
            this.buttonUserManual.UseVisualStyleBackColor = true;
            this.buttonUserManual.Click += new System.EventHandler(this.buttonUserManual_Click);
            // 
            // buttonAbout
            // 
            this.buttonAbout.Location = new System.Drawing.Point(25, 20);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(252, 23);
            this.buttonAbout.TabIndex = 0;
            this.buttonAbout.Text = "About Multi Docking";
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1024, 768);
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MultiDocking";
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabHelp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private Controls.DownloadPdbControl downloadPdbControl;
        private Controls.PrepareTargetsControl prepareTargetsControl;
        private Controls.TargetsToPdbqtControl targetsToPdbqtControl;
        private Controls.RunMultiDockingControl runMultiDockingControl;
        private Controls.ExportResultsControl exportResultsControl;
        private Controls.CalculateRMSDsControl calculateRMSDsControl;
        private System.Windows.Forms.TabPage tabHelp;
        private System.Windows.Forms.Button buttonAskAQuestion;
        private System.Windows.Forms.Button buttonReportBug;
        private System.Windows.Forms.Button buttonUserManual;
        private System.Windows.Forms.Button buttonAbout;
        private System.Windows.Forms.TabPage tabPage6;
    }
}

