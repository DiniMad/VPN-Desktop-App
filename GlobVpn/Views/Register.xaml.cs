using GlobVpn.Views.Utilities;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GlobVpn.Views
{
    public partial class Register : Page
    {
        public Window Window => Window.GetWindow(this);

        public Register()
        {
            InitializeComponent();
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            Window.WindowState = WindowState.Minimized;
        }

        private void ButtonMaximize_Click(object sender, RoutedEventArgs e)
        {
            Window.WindowState = Window.WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(0);
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