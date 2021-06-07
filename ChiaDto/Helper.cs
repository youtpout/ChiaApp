using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ChiaDto
{
    public static class Helper
    {
        public static string FormatBytes(this decimal size)
        {
            string result = string.Empty;
            if (size < 0)
            {
                return "invalid";
            }
            var labels = new string[] { "MiB", "GiB", "TiB", "PiB", "EiB", "ZiB", "YiB" };
            decimal baseOctet = 1024;
            decimal value = size / baseOctet;
            foreach (var item in labels)
            {
                value /= baseOctet;
                if (value < baseOctet)
                {
                    return $"{value.ToString("F3")} {item}";
                }

            }
            return $"{value.ToString("F3")} {labels[labels.Length - 1]}";
        }

        public static string UnixTimeStampToDateTime(this long unixTimeStamp)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(unixTimeStamp);
            return dateTimeOffset.DateTime.ToLocalTime().ToString("g");
        }

        public static string GetXchFromMojo(this decimal mojo)
        {
            decimal result = 0;
            result = mojo / (decimal)Math.Pow(10, 12);
            return $"{result} XCH";
        }

        public static string GetXchFromMojo(this int mojo)
        {
            decimal result = 0;
            result = mojo / (decimal)Math.Pow(10, 12);
            return $"{result} XCH";
        }

        public static string FormatThousand(this long value)
        {
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            // Displays the same value with a blank as the separator.
            nfi.NumberGroupSeparator = "'";
            return value.ToString("N0", nfi);
        }

        public static string GetDaysFromMinutes(this int minutes)
        {
            TimeSpan time = new TimeSpan(0, minutes, 0);
            return Math.Ceiling(time.TotalDays).ToString();
        }
    }
}
