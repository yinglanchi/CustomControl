using System;
using System.Globalization;
using System.Windows.Data;

namespace ACM.Presentation.Converters.Multis
{
    public class BoolOrToTrueMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length == 0) return false;

            for (int i = 0; i < values.Length; i++)
            {
                object value = values[i];
                if (value is bool)
                {
                    bool boolValue = (bool)value;
                    if (boolValue) return true;
                }
            }

            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
