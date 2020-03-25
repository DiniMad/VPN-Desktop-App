using System.Windows;
using System.Windows.Controls;

namespace GlobVpn.Views.Utilities
{
    public enum WindowContent
    {
        Login,
        Register,
        PrimaryPanel,
        SubscribePlans,
    }

    internal static class ApplicationActions
    {
        private static MainWindow MainWindow => Application.Current.MainWindow as MainWindow;

        public static void SetContent(WindowContent content)
        {
            MainWindow.SetContent = content;
        }
        public static void ChangeTheme()
        {
            App.ChangeTheme();
        }
        public static void SetModalContent(Page content)
        {
            MainWindow.SetModalContent = content;
        }
    }
}
