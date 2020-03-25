using System.Windows;
using System.Windows.Media.Imaging;

namespace GlobVpn.Views.Resources.Attached_Properties
{
    class ButtonRadius : DependencyObject
    {
        public static readonly DependencyProperty RadiusProperty = DependencyProperty
            .RegisterAttached("Radius", typeof(CornerRadius), typeof(ButtonRadius));

        public static void SetRadius(UIElement element, CornerRadius value) =>
            element.SetValue(RadiusProperty, value);
        public static CornerRadius GetRadius(UIElement element) => 
            (CornerRadius) element.GetValue(RadiusProperty);
    }
}