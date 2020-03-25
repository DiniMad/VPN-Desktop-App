using System.Windows;
using System.Windows.Media.Imaging;

namespace GlobVpn.Views.Resources.Attached_Properties
{
    class InputIcon : DependencyObject
    {
        public static readonly DependencyProperty IconProperty = DependencyProperty
            .RegisterAttached("Icon", typeof(BitmapImage), typeof(InputIcon));

        public static void SetIcon(UIElement element, BitmapImage value) =>
            element.SetValue(IconProperty, value);
        public static BitmapImage GetIcon(UIElement element) => 
            (BitmapImage) element.GetValue(IconProperty);
    }
}