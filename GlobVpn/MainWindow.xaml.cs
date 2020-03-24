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

namespace GlobVpn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public enum Windows
        {
            Login,
            Register,
            PrimaryPanel,
            SubscribePlans,
        }

        public Windows WindowContent
        {
            set
            {
                Page newPage;
                switch (value)
                {
                    case Windows.Login:
                        newPage = new Login();
                        break;
                    case Windows.Register:
                        newPage = new Register();
                        break;
                    case Windows.PrimaryPanel:
                        newPage = new PrimaryPanel();
                        break;
                    case Windows.SubscribePlans:
                        newPage = new SubscribePlans();
                        break;
                    default:
                        throw new AggregateException();
                }
                //FrameContent.Content = newPage;
                NavigateToWindow(newPage);
            }
        }

        private bool IsWindowOpacityAnimationRunning;
        private bool IsWindowMarginAnimationRunning;
        private TimeSpan AnimationsDuration=TimeSpan.FromSeconds(.8);
        private int MarginAnimationOffset=600;
     

        public MainWindow()
        {
            InitializeComponent();
            FrameContent.Content = new Login();
        }

        private void NavigateToWindow(Page newPage)
        {
            if (IsWindowOpacityAnimationRunning || IsWindowMarginAnimationRunning)
                return;
            //IsWindowMarginAnimationRunning = true;
            IsWindowOpacityAnimationRunning = true;
            var marginAnimation = new ThicknessAnimation
            {
                To = new Thickness(-MarginAnimationOffset, 0, MarginAnimationOffset, 0),
                Duration = AnimationsDuration
            };
            var opacityAnimation = new DoubleAnimation
            {
                To = 0,
                Duration = AnimationsDuration
            };
            marginAnimation.Completed += (sender, e) => MarginAnimation_Completed(sender, e, newPage);
            opacityAnimation.Completed += (sender, e) => OpacityAnimation_Completed(sender, e, newPage);
            //FrameContent.BeginAnimation(MarginProperty, marginAnimation);
            FrameContent.BeginAnimation(OpacityProperty, opacityAnimation);
        }
        private void MarginAnimation_Completed(object sender, EventArgs e, Page newPage)
        {
            IsWindowMarginAnimationRunning = false;
            RunSecondPartOfAnimation(newPage);


        }
        private void OpacityAnimation_Completed(object sender, EventArgs e, Page newPage)
        {
            IsWindowOpacityAnimationRunning = false;
            RunSecondPartOfAnimation(newPage);
        }
        private void RunSecondPartOfAnimation(Page newPage)
        {
            if (IsWindowMarginAnimationRunning || IsWindowOpacityAnimationRunning)
                return;

            FrameContent.Content = newPage;
            //Task.Delay(300);
            var marginAnimation = new ThicknessAnimation
            {
                From= new Thickness(MarginAnimationOffset, 0, -MarginAnimationOffset, 0),
                To = new Thickness(0),
                Duration = AnimationsDuration
            };
            var opacity = new DoubleAnimation
            {
                To = 1,
                Duration = AnimationsDuration
            };
            //FrameContent.BeginAnimation(MarginProperty, marginAnimation);
            FrameContent.BeginAnimation(OpacityProperty, opacity);
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