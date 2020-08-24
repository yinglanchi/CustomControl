using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ACM.Presentation.Converters
{
    public class CanvasToBoundsCenterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || value == DependencyProperty.UnsetValue) return Binding.DoNothing;

            double controlWidth = default(double);
            int dir = 1;

            try
            {
                controlWidth = (double)value;
            }
            catch (Exception)
            {
                return Binding.DoNothing;
            }

            if (parameter != null)
            {
                string paramStr = parameter.ToString();
                if (int.TryParse(paramStr, out dir))
                {
                    controlWidth *= dir;
                } 
            }

            return controlWidth / 2;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
