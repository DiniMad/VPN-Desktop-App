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

        private readonly SolidColorBrush selectedItemBackgroundBrush=new SolidColorBrush(Color.FromRgb(83, 77, 151));
        private readonly SolidColorBrush DefaultItemBackgroundBrush=new SolidColorBrush(Color.FromRgb(70, 70, 70));




        public int PlanDuration { get; }
        public string PlanDurationDisplay =>
            PlanDuration == 1 ? $"{PlanDuration} month" : $"{PlanDuration} months";

        public int DolarPrice { get; }
        public int RialPrice { get; }

        public CheckOut(int planDuration, int dolarPrice, int rialPrice)
        {
            InitializeComponent();
            DataContext = this;
            PlanDuration = planDuration;
            DolarPrice = dolarPrice;
            RialPrice = rialPrice;
        }

        private void ItemsControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item =sender as ItemsControl;

            if (item.Background == selectedItemBackgroundBrush)
                return;
            if (ItemsControl1.Background == selectedItemBackgroundBrush)
                ItemsControl1.Background = DefaultItemBackgroundBrush;

            if (ItemsControl2.Background == selectedItemBackgroundBrush)
                ItemsControl2.Background = DefaultItemBackgroundBrush;

            if (ItemsControl3.Background == selectedItemBackgroundBrush)
                ItemsControl3.Background = DefaultItemBackgroundBrush;

            item.Background = selectedItemBackgroundBrush;
        }

        private void GridEmptySpaceMouseLeftButtonUp(object sender, MouseButtonEventArgs e) =>
            ApplicationActions.SetModalContent(null);
    }
}