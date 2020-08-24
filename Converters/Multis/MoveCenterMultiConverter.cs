using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ACM.Presentation.Converters.Multis
{
    public class MoveCenterMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length != 2 || values[0] == DependencyProperty.UnsetValue || values[1] == DependencyProperty.UnsetValue) return Binding.DoNothing;

            double ret = 0.0;

            try
            {
                double pos = (double)values[0];
                double offset = (double)values[1];

                ret = pos - offset / 2;
            }
            catch (Exception)
            {
                return Binding.DoNothing;
            }

            return ret;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
