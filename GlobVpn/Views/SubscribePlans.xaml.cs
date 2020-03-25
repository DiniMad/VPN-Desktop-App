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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GlobVpn.Views
{
    /// <summary>
    /// Interaction logic for SubscribePlans.xaml
    /// </summary>
    public partial class SubscribePlans : Page
    {
        public SubscribePlans()
        {
            InitializeComponent();

            OneMonthPlan.ButtonBuyClick = ButtonBuy_Click;
            ThreeMonthsPlan.ButtonBuyClick = ButtonBuy_Click;
            SixMonthsPlan.ButtonBuyClick = ButtonBuy_Click;
            TwelveMonthsPlan.ButtonBuyClick = ButtonBuy_Click;
        }
        public Action<object, RoutedEventArgs> ButtonBuyClick { get; set; }

        private void ButtonBuy_Click(object sender, RoutedEventArgs e, int planTitle, int dolarPrice, int rialPrice)
        {
            ApplicationActions.SetModalContent(new CheckOut(planTitle, dolarPrice, rialPrice));
        }
    }
}
