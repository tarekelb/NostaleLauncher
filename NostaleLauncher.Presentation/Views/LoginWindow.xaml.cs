using NostaleLauncher.Presentation.ViewModels;
using System.Windows;
using System.Windows.Navigation;

namespace NostaleLauncher.Presentation.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {

            InitializeComponent();
            var viewModel = new LoginViewModel();
            DataContext = viewModel;

            viewModel.OnLoginSuccess += NavigateToInstaller;
        }

        private void NavigateToInstaller()
        {
            var window = new InstallerWindow();
            window.Show();

            this.Close();
        }
    }
}