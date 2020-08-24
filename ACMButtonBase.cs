using System.Windows;
using System.Windows.Controls.Primitives;

namespace ACM.Presentation.Controls.Buttons
{
    public class ACMButtonBase : ButtonBase
    {
        public static DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ACMButtonBase), new PropertyMetadata(default(CornerRadius)));

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
    }
}
