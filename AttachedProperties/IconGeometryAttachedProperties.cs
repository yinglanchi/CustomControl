using System.Windows;
using System.Windows.Media;

namespace ACM.Presentation.Views.AttachedProperties
{
    public class IconGeometryAttachedProperties : DependencyObject
    {
        public static Geometry GetIconGeometry(DependencyObject obj)
        {
            return obj.GetValue(IconGeometryProperty) as Geometry;
        }
        public static void SetIconGeometry(DependencyObject obj, Geometry value)
        {
            obj.SetValue(IconGeometryProperty, value);
        }

        public static readonly DependencyProperty IconGeometryProperty 
            = DependencyProperty.RegisterAttached("IconGeometry", typeof(Geometry), typeof(IconGeometryAttachedProperties), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));
    }
}
