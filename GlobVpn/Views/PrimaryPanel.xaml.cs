using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace GlobVpn.Views
{
    /// <summary>
    /// Interaction logic for PrimaryPanel.xaml
    /// </summary>
    public partial class PrimaryPanel : Page
    {
        public bool IsServersPanelExpanded { get; set; }
        public PrimaryPanel()
        {
            InitializeComponent();
        }

        private void ButtonExpandServers_Click(object sender, RoutedEventArgs e)
        {
            var heightAnimation=new DoubleAnimation()
            {
                To=IsServersPanelExpanded?13:100,
                Duration=TimeSpan.FromSeconds(.25)
            };
            BorderServersContainer.BeginAnimation(HeightProperty, heightAnimation);

            ButtonExpandServers.Content = IsServersPanelExpanded ? "V" : "X";

            IsServersPanelExpanded = !IsServersPanelExpanded;
        }
    }
}
