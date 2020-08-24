using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Data;

namespace ACM.Presentation.Converters
{
    public class EnumTypeToAnotherOneConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return Binding.DoNothing;
            int enumValue = -1;
            try
            {
                enumValue = (int)value;
            }
            catch (Exception)
            {
                return Binding.DoNothing;
            }

            Type type = targetType;
            object ins = Activator.CreateInstance(type);
            FieldInfo[] fieldInfos = type.GetFields(BindingFlags.Public | BindingFlags.Static);
            FieldInfo targetField = fieldInfos.SingleOrDefault(item =>
            {
                object valueObj = item.GetValue(ins);
                int valueCst = -1;
                try
                {
                    valueCst = (int)valueObj;
                }
                catch  { }

                if(valueCst == enumValue)
                {
                    return true;
                }

                return false;
            });

            try
            {
                object newEnum = Enum.Parse(type, targetField.Name);
                return newEnum;
            }
            catch (Exception)
            {
                return Binding.DoNothing;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
