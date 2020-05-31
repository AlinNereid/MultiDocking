using System;
using System.Windows.Forms;
using MultiDocking.UserInterface;

namespace MultiDocking
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var welcomeForm = new WelcomeSetWorkspaceForm();
            welcomeForm.ShowDialog();
            if (welcomeForm.DialogResult == DialogResult.OK)
            {
                Application.Run(new MainForm());
            }
        }
    }
}
