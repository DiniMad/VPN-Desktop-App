using System;
using System.Globalization;
using System.Windows.Data;

namespace GlobVpn.Views.Resources.Value_Converter
{
    class ConnectButtonIsCheckedToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is null) return "Stop";
            var isChecked=(bool) value;
            return isChecked ? "Connecting..." : "Start";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
