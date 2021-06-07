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
                return this.PeakTime.UnixTimeStampToDateTime();
            }
        }

        public string EstimatedNetworkSpaceFormat
        {
            get
            {
                return this.EstimatedNetworkSpace.FormatBytes();
            }
        }

        public string TotalIterationFormat
        {
            get
            {
                return this.TotalIterations.FormatThousand();
            }
        }


    }
}
