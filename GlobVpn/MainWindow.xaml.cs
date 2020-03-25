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
                        // If its already a layout means that we should just change the contetn of the layout
                        if (FrameContent.Content is Layout)
                        {
                            (FrameContent.Content as Layout).SetContent = value;
                            return;
                        }
                        // Otherwise we should change the content of the window
                        else
                        {
                            newPage = new Layout();
                            break;
                        }
                    case WindowContent.SubscribePlans:
                        (FrameContent.Content as Layout).SetContent = value;
                        return;
                    default:
                        throw new AggregateException();
                }
                var frameActions=new FrameAnimation(FrameContent,.8);
                frameActions.ChangeFrameContentWithAnimation(newPage);
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            FrameContent.Content = new Login();
        }

        public void SetModalContent(Page content) => FrameModal.Content = content;
    }
}