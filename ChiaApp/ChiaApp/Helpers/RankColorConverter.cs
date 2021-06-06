using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace ChiaApp.Helpers
{
    public class RankColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color color = Color.Black;
            //if (value is RankType)
            //{
            //    RankType rank = (RankType)value;
            //    switch (rank)
            //    {
            //        case RankType.None:
            //            color = Color.Black;
            //            break;
            //        case RankType.S:
            //            color = Color.Gold;
            //            break;
            //        case RankType.A:
            //            color = Color.Silver;
            //            break;
            //        case RankType.B:
            //            color = Color.FromRgb(205, 127, 50);
            //            break;
            //        case RankType.C:
            //            color = Color.Brown;
            //            break;
            //        case RankType.D:
            //            color = Color.BlueViolet;
            //            break;
            //        default:
            //            color = Color.Black;
            //            break;
            //    }
            //}
            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
