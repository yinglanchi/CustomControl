using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ACM.Presentation.Converters
{
    public class NullOrEmptyToVisibilityConverter : IValueConverter
    {
        public bool IsToVisible { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value == null || value.ToString() == string.Empty)
            {
                return GetVisibilityState(IsToVisible);
            }

            return GetVisibilityState(!IsToVisible);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private Visibility GetVisibilityState(bool isToVisible)
        {
            Visibility visibility = isToVisible ? Visibility.Visible : Visibility.Collapsed;

            return visibility;
        }
    }
}
