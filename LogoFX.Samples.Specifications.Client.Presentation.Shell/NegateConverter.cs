using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace LogoFX.Samples.Specifications.Client.Presentation.Shell
{
    public class NegateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool f = (bool) value;

            return !f;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool f = (bool)value;

            return !f;
        }
    }
}