using AppLauncher.ViewModels;
using System.Windows;

namespace AppLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(NavigationViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}