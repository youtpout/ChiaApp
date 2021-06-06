using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace ChiaApp.Helpers
{
    public class ImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string source;
            if (value == null)
            {
                return null;
            }
            else
            {
                source = "OnePunchQuiz.Assets.Images." + value.ToString();
            }

            var imageSource = ImageSource.FromResource(source, typeof(ImageSourceConverter).GetTypeInfo().Assembly);

            return imageSource;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
