using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ACM.Presentation.Converters
{
    public class MarginRatioConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double actualWidth = -1;
            double actualHeight = -1;

            if (value is FrameworkElement)
            {
                FrameworkElement element = value as FrameworkElement;
                actualWidth = element.ActualWidth;
                actualHeight = element.ActualHeight;
            }
            else
            {
                return Binding.DoNothing;
            }

            Thickness thickness = default(Thickness);
            if (parameter is string)
            {
                string paramStr = (string)parameter;
                string[] ratios = paramStr.Split(new char[] { ' ', ',' });
                switch (ratios.Length)
                {
                    case 1:
                        string ratio = ratios[0];
                        double ret = default(double);
                        if (double.TryParse(ratio, out ret))
                        {
                            thickness = GetThicknessWithRatio(ret, ret, ret, ret, actualWidth, actualHeight);
                        }
                        break;
                    case 2:
                        string ratioHori = ratios[0];
                        string ratioVert = ratios[1];
                        double retH = default(double);
                        double retV = default(double);
                        if (double.TryParse(ratioHori, out retH) &&
                            double.TryParse(ratioVert, out retV))
                        {
                            thickness = GetThicknessWithRatio(retH, retV, retH, retV, actualWidth, actualHeight);
                        }
                        break;
                    case 4:
                        string ratioL = ratios[0];
                        string ratioT = ratios[1];
                        string ratioR = ratios[2];
                        string ratioB = ratios[3];

                        double retL = default(double);
                        double retR = default(double);
                        double retT = default(double);
                        double retB = default(double);

                        if (double.TryParse(ratioL, out retL) &&
                            double.TryParse(ratioT, out retT) &&
                            double.TryParse(ratioR, out retR) &&
                            double.TryParse(ratioB, out retB))
                        {
                            thickness = GetThicknessWithRatio(retL, retT, retR, retB, actualWidth, actualHeight);
                        }
                        break;

                    default:
                        thickness = default(Thickness);
                        break;
                }
            }

            return thickness;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Debugger.Break();
            return value;
        }

        private Thickness GetThicknessWithRatio(double left, double top, double right, double bottom, double width, double height)
        {
            double marginLeft = left * width;
            double marginRight = right * width;
            double marginTop = top * height;
            double marginBottom = bottom * height;
            return new Thickness(marginLeft, marginTop, marginRight, marginBottom);
        }
    }
}
