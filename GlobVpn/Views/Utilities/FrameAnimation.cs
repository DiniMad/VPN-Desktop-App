using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace GlobVpn.Views.Utilities
{
    class FrameAnimation
    {
        private TimeSpan _animationsDuration { get; }
        private Frame _frame { get; }

        public FrameAnimation(Frame frame, double animationDuration)
        {
            _frame = frame;
            _animationsDuration = TimeSpan.FromSeconds(animationDuration);
        }
        public void ChangeFrameContentWithAnimation(Page newPage)
        {
            var opacityAnimation = new DoubleAnimation
            {
                To = 0,
                Duration = _animationsDuration
            };
            opacityAnimation.Completed += (sender, e) => OpacityAnimation_Completed(newPage);
            _frame.BeginAnimation(UIElement.OpacityProperty, opacityAnimation);
        }

        private void OpacityAnimation_Completed(Page newPage)
        {
            _frame.Content = newPage;
            var opacity = new DoubleAnimation
            {
                To = 1,
                Duration = _animationsDuration
            };
            _frame.BeginAnimation(UIElement.OpacityProperty, opacity);
        }
    }
}
