using System;
using System.Globalization;
using System.Windows.Data;

namespace ACM.Presentation.Converters
{
    public class BoolToOppositeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool b = default(bool);
            try
            {
                b = (bool)value;
            }
            catch
            {
                return Binding.DoNothing;
            }
            return !b;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
