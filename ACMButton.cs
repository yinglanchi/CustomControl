using System.Windows;
using System.Windows.Media;

namespace ACM.Presentation.Controls.Buttons
{
    public enum ACMButtonType
    {
        ContentMode,        // Default mode
        SimpleMode,         // Combined geometry and title for simple button function.
        ProcessingMode      // Indicates that someone task will being processed.
    }

    public enum ACMButtonForm
    {
        Square,             // Default
        Circle              // Circle status
    }

    public enum TitlePlacement
    {
        Left,
        Top,
        Right,
        Bottom
    }

    public class ACMButton : ACMButtonBase
    {
        private double _radiusTemp = 0;

        public static readonly DependencyProperty RadiusProperty = DependencyProperty.Register("Radius", typeof(double), typeof(ACMButton), new PropertyMetadata(0.0, OnRadiusPropertyChanged, OnRadiusCoerceCallback));
        public static readonly DependencyProperty FormTypeProperty = DependencyProperty.Register("FormType", typeof(ACMButtonForm), typeof(ACMButton), new PropertyMetadata(ACMButtonForm.Square, OnFormtypeChanged));
        public static readonly DependencyProperty ButtonTypeProperty = DependencyProperty.Register("ButtonType", typeof(ACMButtonType), typeof(ACMButton), new PropertyMetadata(ACMButtonType.ContentMode));
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(ACMButton), new PropertyMetadata(string.Empty));
        public static readonly DependencyProperty TitlePlacementProperty = DependencyProperty.Register("TitlePlacement", typeof(TitlePlacement), typeof(ACMButton), new PropertyMetadata(TitlePlacement.Right));
        public static readonly DependencyProperty IconGeometryProperty = DependencyProperty.Register("IconGeometry", typeof(PathGeometry), typeof(ACMButton));

        public static readonly DependencyProperty IsProcessStartProperty = DependencyProperty.Register("IsProcessStart", typeof(bool), typeof(ACMButton), new PropertyMetadata(false, OnProcessStartPropertyChanged));
        public static readonly DependencyProperty IsProcessingProperty = DependencyProperty.Register("IsProcessing", typeof(bool), typeof(ACMButton), new PropertyMetadata(false, OnProcessingPropertyChanged));
        public static readonly DependencyProperty IsProcessCompletedProperty = DependencyProperty.Register("IsProcessCompleted", typeof(bool), typeof(ACMButton), new PropertyMetadata(false, OnProcessCompletedChanged));

        public static readonly DependencyProperty ProcessValueProperty = DependencyProperty.Register("ProcessValue", typeof(double), typeof(ACMButton), new PropertyMetadata(0.0));
        public static readonly DependencyProperty ProcessBrushProperty = DependencyProperty.Register("ProcessBrush", typeof(Brush), typeof(ACMButton), new PropertyMetadata(Brushes.Pink));
        public static readonly DependencyProperty ProgressMarginProperty = DependencyProperty.Register("ProgressMargin", typeof(Thickness), typeof(ACMButton), new PropertyMetadata(new Thickness(3)));
        public static readonly DependencyProperty IsIndeterminateProperty = DependencyProperty.Register("IsIndeterminate", typeof(bool), typeof(ACMButton), new PropertyMetadata(false));
        public static readonly DependencyProperty ProcessCompletedIconGeometryProperty = DependencyProperty.Register("ProcessCompletedIconGeometry", typeof(PathGeometry), typeof(ACMButton));
        public static readonly DependencyProperty IsShowProcessCompletedTipsProperty = DependencyProperty.Register("IsShowProcessCompletedTips", typeof(bool), typeof(ACMButton));

        public static readonly RoutedEvent ProcessCompletedRoutedEvent = EventManager.RegisterRoutedEvent("ProcessCompleted", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ACMButton));

        /// <summary>
        /// Indicates button's shape
        /// </summary>
        public ACMButtonForm FormType
        {
            get { return (ACMButtonForm)GetValue(FormTypeProperty); }
            set { SetValue(FormTypeProperty, value); }
        }
        /// <summary>
        /// Indicating button's function type. eg showing process indicator duaring processing task.
        /// </summary>
        public ACMButtonType ButtonType
        {
            get { return (ACMButtonType)GetValue(ButtonTypeProperty); }
            set { SetValue(ButtonTypeProperty, value); }
        }
        /// <summary>
        /// Button's icon geometry. Invalid in ContentMode.
        /// </summary>
        public PathGeometry IconGeometry
        {
            get { return (PathGeometry)GetValue(IconGeometryProperty); }
            set { SetValue(IconGeometryProperty, value); }
        }
        /// <summary>
        /// Indicates circle button's radius. Valid in ACMButtonForm.Circle state only.
        /// </summary>
        public double Radius
        {
            get { return (double)GetValue(RadiusProperty); }
            set { SetValue(RadiusProperty, value); }
        }
        /// <summary>
        /// Button's title. Invalid in ContentMode.
        /// </summary>
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        /// <summary>
        /// Indicates the title direction.
        /// </summary>
        public TitlePlacement TitlePlacement
        {
            get { return (TitlePlacement)GetValue(TitlePlacementProperty); }
            set { SetValue(TitlePlacementProperty, value); }
        }
        /// <summary>
        /// Indicates the task start.
        /// </summary>
        public bool IsProcessStart
        {
            get { return (bool)GetValue(IsProcessStartProperty); }
            set { SetValue(IsProcessStartProperty, value); }
        }
        /// <summary>
        /// Indicator for processing task. Valid in ProcessingMode only.
        /// </summary>
        public bool IsProcessing
        {
            get { return (bool)GetValue(IsProcessingProperty); }
            set { SetValue(IsProcessingProperty, value); }
        }
        /// <summary>
        /// Indicates the task completed.
        /// </summary>
        public bool IsProcessCompleted
        {
            get { return (bool)GetValue(IsProcessCompletedProperty); }
            set { SetValue(IsProcessCompletedProperty, value); }
        }
        public double ProcessValue
        {
            get { return (double)GetValue(ProcessValueProperty); }
            set { SetValue(ProcessValueProperty, value); }
        }
        public Brush ProcessBrush
        {
            get { return (Brush)GetValue(ProcessBrushProperty); }
            set { SetValue(ProcessBrushProperty, value); }
        }
        public PathGeometry ProcessCompletedIconGeometry
        {
            get { return (PathGeometry)GetValue(ProcessCompletedIconGeometryProperty); }
            set { SetValue(ProcessCompletedIconGeometryProperty, value); }
        }
        public Thickness ProgressMargin
        {
            get { return (Thickness)GetValue(ProgressMarginProperty); }
            set { SetValue(ProgressMarginProperty, value); }
        }
        public bool IsIndeterminate
        {
            get { return (bool)GetValue(IsIndeterminateProperty); }
            set { SetValue(IsIndeterminateProperty, value); }
        }
        public bool IsShowProcessCompletedTips
        {
            get { return (bool)GetValue(IsShowProcessCompletedTipsProperty); }
            set { SetValue(IsShowProcessCompletedTipsProperty, value); }
        }

        public event RoutedEventHandler ProcessCompleted
        {
            add { AddHandler(ProcessCompletedRoutedEvent, value); }
            remove { RemoveHandler(ProcessCompletedRoutedEvent, value); }
        }

        private void RaiseProcessCompletedEvent()
        {
            RoutedEventArgs args = new RoutedEventArgs();
            args.RoutedEvent = ProcessCompletedRoutedEvent;
            RaiseEvent(args);
        }


        /// <summary>
        /// Refresh Radius value once FormType was changed.
        /// </summary>
        static void OnFormtypeChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            ACMButton @this = obj as ACMButton;

            ACMButtonForm forType = (ACMButtonForm)args.NewValue;
            if (forType == ACMButtonForm.Circle)
            {
                @this.Radius = @this._radiusTemp;
            }
        }

        /// <summary>
        /// If Radius property is validation, then change width and height by force.
        /// </summary>
        static void OnRadiusPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            ACMButton @this = obj as ACMButton;

            if (null != args.NewValue)
            {
                double newValue = (double)args.NewValue;
                @this.Width = newValue;
                @this.Height = newValue;
            }
        }

        static void OnProcessStartPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            ACMButton @this = obj as ACMButton;

            bool newValue = (bool)args.NewValue;
            if (newValue != true) return;

            @this.IsProcessing = true;
            @this.IsProcessCompleted = false;
        }
        static void OnProcessingPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            ACMButton @this = obj as ACMButton;

            bool newValue = (bool)args.NewValue;
            if (newValue != true) return;

            @this.IsProcessStart = true;
        }
        static void OnProcessCompletedChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            ACMButton @this = obj as ACMButton;

            bool newValue = (bool)args.NewValue;
            if (newValue != true) return;

            @this.IsProcessStart = false;
            @this.IsProcessing = false;
            @this.RaiseProcessCompletedEvent();
        }

        static object OnRadiusCoerceCallback(DependencyObject obj, object value)
        {
            ACMButton @this = obj as ACMButton;

            @this._radiusTemp = (double)value;          // Saving value to temporary variable for reset when FormType property was changed from square to circle.
            if (@this.FormType != ACMButtonForm.Circle)
            {
                return 0.0;
            }
            return value;
        }
        static object OnWithOrHeightCoerceCallback(DependencyObject obj, object value)
        {
            ACMButton @this = obj as ACMButton;

            switch (@this.FormType)
            {
                case ACMButtonForm.Square: return value;
                case ACMButtonForm.Circle: return @this.Radius;
                default: return value;
            }
        }

        static ACMButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ACMButton), new FrameworkPropertyMetadata(typeof(ACMButton)));

            WidthProperty.OverrideMetadata(typeof(ACMButton), new FrameworkPropertyMetadata(double.NaN, null, OnWithOrHeightCoerceCallback));
            HeightProperty.OverrideMetadata(typeof(ACMButton), new FrameworkPropertyMetadata(double.NaN, null, OnWithOrHeightCoerceCallback));
        }

        public ACMButton() { }
    }
}
