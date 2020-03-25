using System.Windows;

namespace GlobVpn.Views.Resources.Attached_Properties
{
    class TexBoxPlaceHolder : DependencyObject
    {
        public static readonly DependencyProperty PlaceHolderProperty = DependencyProperty
            .RegisterAttached("PlaceHolder", typeof(string), typeof(TexBoxPlaceHolder));

        public static void SetPlaceHolder(UIElement element, string value) =>
            element.SetValue(PlaceHolderProperty, value);
        public static string GetPlaceHolder(UIElement element) => 
            (string) element.GetValue(PlaceHolderProperty);
    }
}