using GlobVpn.Views.Utilities;
using System.Windows;
using System.Windows.Controls;

namespace GlobVpn.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }
        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            ApplicationActions.SetContent(WindowContent.PrimaryPanel);
        }

        private void ButtonGoToSignUp_Click(object sender, RoutedEventArgs e)
        {
            ApplicationActions.SetContent(WindowContent.Register);
        }
    }
}
