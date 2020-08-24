using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace ACM.Presentation.Converters.Multis
{
    public class RobotMarkerRotateToTranslateMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || value.Length != 3 || value.Contains( DependencyProperty.UnsetValue)) return Binding.DoNothing;
            double angle = -1;
            double width = -1;
            double height = -1;
            try
            {
                angle = (double)value[0];
                width = (double)value[1];
                height = (double)value[2];
            }
            catch (Exception)
            {
                return Binding.DoNothing;
            }

            if (width == 0 || height == 0) return Binding.DoNothing;

            // standerdize the rotation angle and degree to radian
            angle = angle % 360;
            if (angle < 0) angle += 360;
            double radian = angle / 180 * Math.PI;
           
            // calculating offset distance
            double distance = width - height;
            distance = Math.Sin(radian) * distance;

            return distance * -0.5;
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
