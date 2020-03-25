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

            // TODO: Different plans should bind to different methods
            YearPlane.ButtonBuyClick = Button_Click;
            YearPlane2.ButtonBuyClick = Button_Click;
            YearPlane3.ButtonBuyClick = Button_Click;
            YearPlane4.ButtonBuyClick = Button_Click;
        }
        public Action<object, RoutedEventArgs> ButtonBuyClick { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e, int planTitle, int dolarPrice, int rialPrice)
        {
            ApplicationActions.SetModalContent(new CheckOut(planTitle, dolarPrice, rialPrice));
        }
    }
}
