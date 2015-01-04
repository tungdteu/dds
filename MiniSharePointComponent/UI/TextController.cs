using System.Windows.Forms;

namespace MiniSharePointComponent.UI
{
    public partial class TextController : UserControl
    {
        public TextController()
        {
            InitializeComponent();
        }

        public new string Text
        {
            get { return txtInsider.Text; }
            set { txtInsider.Text = value; }
        }
    }
}