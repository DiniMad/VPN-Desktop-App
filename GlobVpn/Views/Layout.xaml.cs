﻿using GlobVpn.Views.Utilities;
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
            ApplicationActions.SetContent(WindowContent.SubscribePlans);
        }
        private void ButtonChangeTheme_Click(object sender, RoutedEventArgs e)
        {
            ApplicationActions.ChangeTheme();
        }

    }
}
