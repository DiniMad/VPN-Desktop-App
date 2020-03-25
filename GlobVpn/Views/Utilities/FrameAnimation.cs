using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace GlobVpn.Views.Utilities
{
    class FrameAnimation
    {
        private TimeSpan AnimationsDuration { get; }
        private Frame Frame { get; }
        public event EventHandler AnimationCompleted;

        public FrameAnimation(Frame frame, double animationDuration)
        {
            Frame = frame;
            AnimationsDuration = TimeSpan.FromSeconds(animationDuration);
        }


        public void ChangeFrameContentWithAnimation(Page newPage)
        {
            var opacityAnimation = new DoubleAnimation
            {
                To = 0,
                Duration = AnimationsDuration
            };
            opacityAnimation.Completed += (sender, e) => OpacityAnimation_Completed(newPage);
            Frame.BeginAnimation(UIElement.OpacityProperty, opacityAnimation);
        }

        private void OpacityAnimation_Completed(Page newPage)
        {
            Frame.Content = newPage;
            var opacity = new DoubleAnimation
            {
                To = 1,
                Duration = AnimationsDuration
            };
            if (AnimationCompleted != null)
                opacity.Completed += (sender, e) => AnimationCompleted(sender, e);
            Frame.BeginAnimation(UIElement.OpacityProperty, opacity);
        }
    }
}
