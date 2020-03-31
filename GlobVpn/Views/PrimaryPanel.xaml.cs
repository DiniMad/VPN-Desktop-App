using GlobVpn.Views.Resources.Attached_Properties;
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
        private bool isServersPanelExpanded;

        public bool IsServersPanelExpanded
        {
            get { return isServersPanelExpanded; }
            set
            {
                var heightAnimation=new DoubleAnimation()
                {
                    To=value?100:14,
                    Duration=TimeSpan.FromSeconds(.25)
                };
                BorderServersContainer.BeginAnimation(HeightProperty, heightAnimation);

                ButtonExpandServers.Content = value ? "X" : "V";

                isServersPanelExpanded = value;
            }
        }
        public PrimaryPanel()
        {
            InitializeComponent();
        }

        private void ButtonExpandServers_Click(object sender, RoutedEventArgs e)
        {
            IsServersPanelExpanded = !IsServersPanelExpanded;
        }

        private void ButtonSelectServerClicked(object sender, RoutedEventArgs e)
        {
            var selectedButton=(Button) sender;
            var selectedButtonIcon=ElementIcon.GetIcon(selectedButton);

            ElementIcon.SetIcon(ButtonSelectedServer, selectedButtonIcon);
            ButtonSelectedServer.Content = selectedButton.Content;

            IsServersPanelExpanded = false;
        }
    }
}
