using System.Windows;

namespace ACM.Presentation.Views.AttachedProperties
{
    public class EffectAttachedProperties
    {
        public static double GetBlurRadius(DependencyObject obj)
        {
            return (double)obj.GetValue(BlurRadiusProperty);
        }
        public static void SetBlurRadius(DependencyObject obj, double value)
        {
            obj.SetValue(BlurRadiusProperty, value);
        }
        // Using a DependencyProperty as the backing store for BlurRadiusProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BlurRadiusProperty = DependencyProperty.RegisterAttached("BlurRadius", typeof(double), typeof(EffectAttachedProperties), new PropertyMetadata(5.0));
    }
}
