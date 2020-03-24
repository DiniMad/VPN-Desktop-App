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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GlobVpn.Views.Resources.User_Controls
{
    /// <summary>
    /// Interaction logic for SubscribePlanItem.xaml
    /// </summary>
    public partial class SubscribePlanItem : UserControl
    {
        public Brush BoxBackground { get; set; }
        public BitmapImage Icon { get; set; }
        public int PlanDurationInMonth { private get; set; } // Refactor Get method to return $"{Value} Plan"
        public string PlanDurationDisplay =>
            PlanDurationInMonth == 1 ? $"{PlanDurationInMonth} month" : $"{PlanDurationInMonth} months";
        public int GiftDurationInMonth { private get; set; } // Refactor Get method to return 
        public string GiftDurationInMonthDisplay =>
            GiftDurationInMonth == 1 ? $"Gifted {GiftDurationInMonth} month" : $"Gifted {GiftDurationInMonth} months";
        public string DollarPrice { private get; set; }
        public string DollarPriceWithSign => $"${DollarPrice}";
        public string RialPrice { get; set; }
        public Action<object, RoutedEventArgs, int, int, int> ButtonBuyClick { get; set; }

        public SubscribePlanItem()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e) =>
            ButtonBuyClick.Invoke(sender, e, PlanDurationInMonth, int.Parse(DollarPrice), int.Parse(RialPrice));
    }
}
