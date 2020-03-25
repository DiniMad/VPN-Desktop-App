using GlobVpn.Views.Utilities;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static GlobVpn.MainWindow;

namespace GlobVpn.Views
{
    /// <summary>
    /// Interaction logic for Layout.xaml
    /// </summary>
    public partial class Layout : Page
    {
        private bool IsWindowOpacityAnimationRunning;
        private TimeSpan AnimationsDuration=TimeSpan.FromSeconds(.8);
        private int MarginAnimationOffset=600;
        public Window Window => Window.GetWindow(this);
        public WindowContent SetContent
        {
            set
            {
                Page newPage;
                switch (value)
                {
                    case WindowContent.PrimaryPanel:
                        newPage = new PrimaryPanel();
                        break;
                    case WindowContent.SubscribePlans:
                        newPage = new SubscribePlans();
                        break;
                    default:
                        throw new AggregateException();
                }
                NavigateToWindow(newPage);
            }
        }
        private void NavigateToWindow(Page newPage)
        {
            if (IsWindowOpacityAnimationRunning)
                return;
            IsWindowOpacityAnimationRunning = true;
            var opacityAnimation = new DoubleAnimation
            {
                To = 0,
                Duration = AnimationsDuration
            };
            opacityAnimation.Completed += (sender, e) => OpacityAnimation_Completed(sender, e, newPage);
            FrameContent.BeginAnimation(OpacityProperty, opacityAnimation);
        }

        private void OpacityAnimation_Completed(object sender, EventArgs e, Page newPage)
        {
            IsWindowOpacityAnimationRunning = false;
            RunSecondPartOfAnimation(newPage);
        }
        private void RunSecondPartOfAnimation(Page newPage)
        {
            if (IsWindowOpacityAnimationRunning)
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
            FrameContent.BeginAnimation(OpacityProperty, opacity);
        }

        public Layout()
        {
            InitializeComponent();
            FrameContent.Content = new PrimaryPanel();
        }
        private void ButtonChangeTheme_Click(object sender, RoutedEventArgs e)
        {
            ApplicationActions.ChangeTheme();
        }

        private void ButtonFeedBack_Click(object sender, RoutedEventArgs e)
        {
            ApplicationActions.SetContent(WindowContent.SubscribePlans);
        }
    }
}
