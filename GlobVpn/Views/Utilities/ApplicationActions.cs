using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
      
        public static void SetContent(WindowContent content)
        {
            (Application.Current.MainWindow as MainWindow).SetContent = content;
        }
        public static void ChangeTheme()
        {
            ((App)Application.Current).ChangeTheme();
        }
    }
}
