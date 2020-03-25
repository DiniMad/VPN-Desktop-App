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
    /// Interaction logic for Layout.xaml
    /// </summary>
    public partial class Layout : Page
    {
        public Window Window => Window.GetWindow(this);

        public Layout()
        {
            InitializeComponent();
            FrameContent.Content = new PrimaryPanel();
        }
        private void ButtonChangeTheme_Click(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).ChangeTheme();
        }

        private void ButtonFeedBack_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Window).WindowContent = MainWindow.Windows.SubscribePlans;
        }
    }
}
