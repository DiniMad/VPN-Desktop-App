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


        private void Window_SourceInitialized(object sender, EventArgs e)
        {
            //WindowAspectRatio.Register((Window)sender);
        }

        public void SetModalContent(Page content) => FrameModal.Content = content;
    }

    internal class WindowAspectRatio
    {
        private double _ratio;
        Window         _window;

        private WindowAspectRatio(Window window)
        {
            _window = window;
            _ratio = window.Width / window.Height;
            ((HwndSource)HwndSource.FromVisual(window)).AddHook(DragHook);
        }

        public static void Register(Window window)
        {
            new WindowAspectRatio(window);
        }

        internal enum WM
        {
            WINDOWPOSCHANGING = 0x0046,
        }

        [Flags()]
        public enum SWP
        {
            NoMove = 0x2,
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct WINDOWPOS
        {
            public IntPtr hwnd;
            public IntPtr hwndInsertAfter;
            public int    x;
            public int    y;
            public int    cx;
            public int    cy;
            public int    flags;
        }

        private IntPtr DragHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handeled)
        {
            if (_window.WindowState != WindowState.Normal)
                return IntPtr.Zero;
            if ((WM)msg == WM.WINDOWPOSCHANGING)
            {
                WINDOWPOS position = (WINDOWPOS) Marshal.PtrToStructure(lParam, typeof(WINDOWPOS));

                if ((position.flags & (int)SWP.NoMove) != 0 ||
                    HwndSource.FromHwnd(hwnd).RootVisual == null)
                    return IntPtr.Zero;

                position.cx = (int)(position.cy * _ratio);

                Marshal.StructureToPtr(position, lParam, true);
                handeled = true;
            }

            return IntPtr.Zero;
        }
    }
}