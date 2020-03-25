using GlobVpn.Views.Utilities;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GlobVpn.Views
{
    public partial class Register : Page
    {
        public Register()
        {
            InitializeComponent();
        }

        private void ButtonRegister_OnClick(object sender, RoutedEventArgs e)
        {
            ApplicationActions.SetContent(WindowContent.PrimaryPanel);
        }

        private void ButtonGoToLogin_Click(object sender, RoutedEventArgs e)
        {
            ApplicationActions.SetContent(WindowContent.Login);
        }
    }
}