
using System.Windows.Controls;

namespace AppLauncher.Views
{
    public partial class LauncherView : UserControl
    {
        public LauncherView()
        {
            InitializeComponent();
            this.Loaded += (s, e) => this.Focus();
        }
    }
}
