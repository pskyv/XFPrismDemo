using System;
using System.Globalization;
using Xamarin.Forms;

namespace XFPrismDemo.Converters
{
    public class IsUrgentToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if((bool)value)
            {
                return "ic_urgent.png";
            }

            return "ic_noturgent.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
