using System.Drawing;
using System.Windows.Forms;

namespace MultiDocking.UserInterface.Controls
{
    public class MUserControl : UserControl
    {
        public virtual void SetInput(string input)
        {

        }

        public virtual string GetOutputPath()
        {
            return string.Empty;
        }
    }
}
