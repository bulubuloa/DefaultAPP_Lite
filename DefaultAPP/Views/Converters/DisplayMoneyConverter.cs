using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DefaultAPP.Views.Converters
{
    public class DisplayMoneyConverter : IValueConverter, IMarkupExtension
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null)
            {
                var keyParameter = parameter.ToString();
                if (keyParameter.Equals("Percent"))
                {
                    var date = (string)value;
                    try
                    {
                        return Math.Round(Double.Parse(date), 2);
                    }
                    catch (Exception ex)
                    {

                    }
                }
                else if (keyParameter.Equals("PercentValue"))
                {
                    var date = (string)value;
                    try
                    {
                        return Math.Round(Double.Parse(date), 2);
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
