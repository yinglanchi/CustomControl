using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ACM.Presentation.Converters.Multis
{
    public class ItemIndexOfItemsControlMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length != 2) return Binding.DoNothing;
            if (values.Contains(DependencyProperty.UnsetValue)) return Binding.DoNothing;

            // resolve values
            int currentIndex = -1;
            try
            {
                ItemCollection items = values[1] as ItemCollection;
                if (items == null) return Binding.DoNothing;

                currentIndex = items.IndexOf(values[0]);
            }
            catch (Exception)
            {
                return Binding.DoNothing;
            }
            return currentIndex;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
