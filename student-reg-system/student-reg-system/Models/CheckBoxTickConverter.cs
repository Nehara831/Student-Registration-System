using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace student_reg_system.Models
{
    public class CheckBoxTickConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            bool isSelected = (bool)values[0];
            bool isChecked = (bool)values[1];

            if (isSelected && isChecked)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;

            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
