using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ACM.Presentation.Converters.Multis
{
    public class BoolsAndToVisibleMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length == 0) return Binding.DoNothing;

            for (int i = 0; i < values.Length; i++)
            {
                object value = values[i];
                if ((value is bool) == false) return Binding.DoNothing;

                bool boolValue = (bool)value;
                if (boolValue == false) return Visibility.Collapsed;

            }
            return Visibility.Visible;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
