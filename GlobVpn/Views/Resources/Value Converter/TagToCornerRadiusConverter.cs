﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace GlobVpn.Views.Resources.Value_Converter
{
    class TagToCornerRadiusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value;
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
