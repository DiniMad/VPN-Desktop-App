using System;
using System.Windows;

namespace GlobVpn
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            SetUpTheme();
            new MainWindow().ShowDialog();
        }

        private static void SetUpTheme()
        {
            var isDarkTheme=GlobVpn.Properties.Settings.Default.DarkTheme;

            var themeName=!isDarkTheme?"DefaultThemeResources.xaml":"DarkThemeResources.xaml";
            var uri = new Uri($"Views/Resources/{themeName}", UriKind.Relative);

            Current.Resources.MergedDictionaries[0].MergedDictionaries.Clear();
            Current.Resources.MergedDictionaries[0].MergedDictionaries.Add(new ResourceDictionary{Source = uri});
        }

        public static void ChangeTheme()
        {
            var isDarkTheme=GlobVpn.Properties.Settings.Default.DarkTheme;

            var themeName=isDarkTheme?"DefaultThemeResources.xaml":"DarkThemeResources.xaml";
            var uri = new Uri($"Views/Resources/{themeName}", UriKind.Relative);

            Current.Resources.MergedDictionaries[0].MergedDictionaries.Clear();
            Current.Resources.MergedDictionaries[0].MergedDictionaries.Add(new ResourceDictionary { Source = uri });

            GlobVpn.Properties.Settings.Default.DarkTheme = !isDarkTheme;
            GlobVpn.Properties.Settings.Default.Save();
        }
    }
}