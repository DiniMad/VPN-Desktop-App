using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    static class ApplicationActions
    {
        public static MainWindow MainWindow => (Application.Current.MainWindow as MainWindow);

        public static void SetContent(WindowContent content)
        {
            MainWindow.SetContent = content;
        }
        public static void ChangeTheme()
        {
            ((App)Application.Current).ChangeTheme();
        }
        public static void SetModalContent(Page content)
        {
            MainWindow.SetModalContent = content;
        }
    }
}
