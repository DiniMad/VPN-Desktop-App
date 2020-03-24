using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GlobVpn.Views
{
    /// <summary>
    /// Interaction logic for PrimaryPanel.xaml
    /// </summary>
    public partial class PrimaryPanel : Page
    {
        public Window Window => Window.GetWindow(this);
        public PrimaryPanel()
        {
            InitializeComponent();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window.DragMove();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).ChangeTheme();
        }

        private void ButtonFeedBack_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window).WindowContent = MainWindow.Windows.SubscribePlans;
        }
    }
}
