using GlobVpn.Views.Resources.Attached_Properties;
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
    /// Interaction logic for FeedBack.xaml
    /// </summary>
    public partial class FeedBack : Page
    {
        private readonly Uri StartEmpty=new Uri("/Views/Resources/Images/StarEmpty.png",UriKind.Relative);
        private readonly Uri StartFill=new Uri("/Views/Resources/Images/StarFill.png",UriKind.Relative);
        private IList<Button> StarButtons { get; }
        public FeedBack()
        {
            InitializeComponent();
            StarButtons = new List<Button>
            {
                ButtonStart1,
                ButtonStart2,
                ButtonStart3,
                ButtonStart4,
                ButtonStart5
            };
            DataContext = this;
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            var buttonName=((Button) sender).Name;

            var buttonIndex=int.Parse(buttonName[buttonName.Length-1].ToString());

            for (int i = 1; i < 5; i++)
            {
                if (i < buttonIndex)
                    ElementIcon.SetIcon(StarButtons[i], new BitmapImage(StartFill));
                else
                    ElementIcon.SetIcon(StarButtons[i], new BitmapImage(StartEmpty));
            }
        }
    }
}
