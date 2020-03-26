using System.Diagnostics;
using System.Windows;
using System.Windows.Interop;
using System.Runtime.InteropServices;
using System;
using GlobVpn.Views;
using System.Windows.Navigation;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.Threading;
using System.Windows.Controls;
using System.ComponentModel;
using System.Threading.Tasks;
using GlobVpn.Views.Utilities;

namespace GlobVpn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public WindowContent SetContent
        {
            set
            {
                Page newPage;
                switch (value)
                {
                    case WindowContent.Login:
                        newPage = new Login();
                        break;
                    case WindowContent.Register:
                        newPage = new Register();
                        break;
                    case WindowContent.PrimaryPanel:
                        // If its already a layout means that we should just change the content of the layout
                        if (FrameContent.Content is Layout layoutPage)
                        {
                            layoutPage.SetContent = value;
                            return;
                        }
                        // Otherwise we should change the content of the window
                        else
                        {
                            newPage = new Layout();
                            break;
                        }
                    case WindowContent.SubscribePlans:
                    case WindowContent.FeedBack:
                    case WindowContent.EditProfile:
                        ((Layout) FrameContent.Content).SetContent = value;
                        return;
                    default:
                        throw new AggregateException();
                }
                var frameActions=new FrameAnimation(FrameContent,.8);
                frameActions.ChangeFrameContentWithAnimation(newPage);
            }
        }
        public Page SetModalContent { set => FrameModal.Content = value; }

        public MainWindow()
        {
            InitializeComponent();
            FrameContent.Content = new Login();
        }

        private void Grid_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ButtonMaximize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(0);
        }
    }
}