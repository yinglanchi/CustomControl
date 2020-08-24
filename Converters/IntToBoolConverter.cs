using System;
using System.Globalization;
using System.Windows.Data;

namespace ACM.Presentation.Converters
{
    public class IntToBoolConverter : IValueConverter
    {
        public bool IsZero2False { get; set; } = true;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int number = -1;
            try
            {
                number = (int)value;
            }
            catch
            {
                return Binding.DoNothing;
            }

            if (IsZero2False)
            {
                if (number >= 1) return true;
                if (number == 0) return false;
            }
            else
            {
                if (number >= 1) return false;
                if (number == 0) return true;
            }

            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
