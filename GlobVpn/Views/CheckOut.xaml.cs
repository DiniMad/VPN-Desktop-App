using GlobVpn.Views.Utilities;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace GlobVpn.Views
{
    public partial class CheckOut : Page
    {

        private readonly SolidColorBrush _selectedItemBackgroundBrush=new SolidColorBrush(Color.FromRgb(83, 77, 151));
        private readonly SolidColorBrush _defaultItemBackgroundBrush=new SolidColorBrush(Color.FromRgb(70, 70, 70));

        public int PlanDuration { get; }
        public string PlanDurationDisplay =>
            PlanDuration == 1 ? $"{PlanDuration} month" : $"{PlanDuration} months";

        public int DollarPrice { get; }
        public int RialPrice { get; }

        public CheckOut(int planDuration, int dollarPrice, int rialPrice)
        {
            InitializeComponent();
            DataContext = this;
            PlanDuration = planDuration;
            DollarPrice = dollarPrice;
            RialPrice = rialPrice;
        }

        private void ItemsControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item =(ItemsControl)sender;

            if (item.Background == _selectedItemBackgroundBrush)
                return;
            if (ItemsControl1.Background == _selectedItemBackgroundBrush)
                ItemsControl1.Background = _defaultItemBackgroundBrush;

            if (ItemsControl2.Background == _selectedItemBackgroundBrush)
                ItemsControl2.Background = _defaultItemBackgroundBrush;

            if (ItemsControl3.Background == _selectedItemBackgroundBrush)
                ItemsControl3.Background = _defaultItemBackgroundBrush;

            item.Background = _selectedItemBackgroundBrush;
        }

        private void GridEmptySpaceMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ApplicationActions.SetModalContent(null);
        }

        private void ButtonEditPlay_OnClick(object sender, RoutedEventArgs e)
        {
            ApplicationActions.SetModalContent(null);
        }
    }
}