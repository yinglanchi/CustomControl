using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ACM.Presentation.Converters
{
    public class BoolToVisibleConverter : IValueConverter
    {
        public bool IsTrue2Collapsed { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool b = false;

            try
            {
                b = (bool)value;
            }
            catch
            {
                return Binding.DoNothing;
            }

            if (b)
            {
                return IsTrue2Collapsed ? Visibility.Collapsed : Visibility.Visible;
            }
            else
            {
                return IsTrue2Collapsed ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility visibility = default(Visibility);
            try
            {
                visibility = (Visibility)value;
            }
            catch
            {
                return Binding.DoNothing;
            }

            if(IsTrue2Collapsed)
            {
                if (visibility == Visibility.Visible) return false;
                if (visibility == Visibility.Collapsed) return true;
            }

            else
            {
                if (visibility == Visibility.Visible) return true;
                if (visibility == Visibility.Collapsed) return false;
            }

            return Binding.DoNothing;
        }
    }
}
