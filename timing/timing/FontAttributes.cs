using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace timing
{
    public partial class FontAttributeViewModel
    {
        public String ScaleFontSize
        {
            get
            {
                int width = App.ScreenWidth;
                return "5";
            }
        }
    }

    public class FontSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //float factor = (float)App.ScreenWidth / App.GuideWidth;
            float factor = (float)App.ScreenWidth / 420;
            String scaledSize = (float.Parse(parameter.ToString()) * factor).ToString();
            return scaledSize;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}