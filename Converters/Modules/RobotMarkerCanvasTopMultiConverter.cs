using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace ACM.Presentation.Converters.Multis
{
    public class RobotMarkerCanvasTopMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length != 2 || values.Contains(DependencyProperty.UnsetValue)) return Binding.DoNothing;

            double markerTipsHeight = -1;
            double canvasHegiht = -1;
            try
            {
                markerTipsHeight = (double)values[0];
                canvasHegiht = (double)values[1];
            }
            catch
            {
                return Binding.DoNothing;
            }
            

            double offset = (markerTipsHeight - canvasHegiht) / 2;
            return -1 * offset;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
