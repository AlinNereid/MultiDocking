using System;
using System.Threading;
using System.Windows.Forms;

namespace MultiDocking.UserInterface
{
    public partial class ProgressDialog : Form
    {
        public ProgressDialog()
        {
            InitializeComponent();
        }

        private readonly Action _onStart = null;
        private readonly Action _onAbort = null;
        public ProgressDialog(Action onStart, Action onAbort)
        {
            this._onStart = onStart;
            this._onAbort = onAbort;
            InitializeComponent();

        }

        public void Refresh(int progressBarValue, string eta)
        {
            Invoke(new Action(() =>
            {
                labelRunning.Text = "Running for: " + (DateTime.Now - _startTime).TotalSeconds + " seconds";
                progressBar.Maximum = 100;
                progressBar.Value = progressBarValue;
                labelEta.Text = "Eta (seconds): " + eta;
            }));
        }

        private void buttonAbort_Click(object sender, EventArgs e)
        {
            _onAbort?.Invoke();
        }

        private DateTime _startTime;
        private void ProgressDialog_Load(object sender, EventArgs e)
        {
            _startTime = DateTime.Now;;
            var t = new Thread(() =>
            {
                _onStart(); 
            });
            t.Start();
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            labelRunning.Text = "Running for: " + (DateTime.Now - _startTime).TotalSeconds + " seconds";
        }
    }
}
