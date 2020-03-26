using GlobVpn.Views.Utilities;
using System;
using System.Windows;
using System.Windows.Controls;

namespace GlobVpn.Views
{
    /// <summary>
    /// Interaction logic for Layout.xaml
    /// </summary>
    public partial class Layout : Page
    {
        public WindowContent SetContent
        {
            set
            {
                if (FrameContent.Content.GetType().Name == value.ToString())
                    return;
                Page newPage;
                switch (value)
                {
                    case WindowContent.PrimaryPanel:
                        newPage = new PrimaryPanel();
                        break;
                    case WindowContent.SubscribePlans:
                        newPage = new SubscribePlans();
                        break;
                    case WindowContent.FeedBack:
                        newPage = new FeedBack();
                        break;
                    case WindowContent.EditProfile:
                        newPage = new EditProfile();
                        break;
                    default:
                        throw new AggregateException();
                }
                if (IsFrameAnimationRunning)
                    return;
                var frameActions=new FrameAnimation(FrameContent,.8);
                frameActions.AnimationCompleted += (sender, e) => IsFrameAnimationRunning = false;
                IsFrameAnimationRunning = true;
                frameActions.ChangeFrameContentWithAnimation(newPage);
            }
        }
        private bool IsFrameAnimationRunning { get; set; }
        public Layout()
        {
            InitializeComponent();
            FrameContent.Content = new PrimaryPanel();
        }
        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            ApplicationActions.SetContent(WindowContent.PrimaryPanel);
        }
        private void ButtonFeedBack_Click(object sender, RoutedEventArgs e)
        {
            ApplicationActions.SetContent(WindowContent.FeedBack);
        }

        private void ButtonInfo_Click(object sender, RoutedEventArgs e)
        {
            ApplicationActions.SetContent(WindowContent.SubscribePlans);
        }
        private void ButtonChangeTheme_Click(object sender, RoutedEventArgs e)
        {
            ApplicationActions.ChangeTheme();
        }
    }
}
