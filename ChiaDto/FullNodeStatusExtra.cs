using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ChiaDto
{
    public partial class FullNodeStatus
    {
        public string PeakTimeFormat
        {
            get
            {
                DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(this.PeakTime);
                return dateTimeOffset.DateTime.ToLocalTime().ToString("g");
            }
        }

        public string EstimatedNetworkSpaceFormat
        {
            get
            {
                return FormatBytes(this.EstimatedNetworkSpace);
            }
        }

        public string TotalIterationFormat
        {
            get
            {
                NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
                // Displays the same value with a blank as the separator.
                nfi.NumberGroupSeparator = "'";
                return TotalIterations.ToString("N0", nfi);
            }
        }

        private string FormatBytes(decimal size)
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

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}
