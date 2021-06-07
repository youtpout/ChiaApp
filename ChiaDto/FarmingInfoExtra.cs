using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiaDto
{
    public partial class FarmingInfo
    {
        public string FarmedAmountFormat
        {
            get
            {
                return this.FarmedAmount.GetXchFromMojo();
            }
        }
        public string FeeAmountFormat
        {
            get
            {
                return this.FeeAmount.GetXchFromMojo();
            }
        }
        public string RewardAmountFormat
        {
            get
            {
                return this.RewardAmount.GetXchFromMojo();
            }
        }
        public string PoolRewardAmountFormat
        {
            get
            {
                return this.PoolRewardAmount.GetXchFromMojo();
            }
        }
        public string TotalPlotSizeFormat
        {
            get
            {
                return this.TotalPlotSize.FormatBytes();
            }
        }
        public string EstimatedNetworkSpaceFormat
        {
            get
            {
                return this.EstimatedNetworkSpace.FormatBytes();
            }
        }
        public string ExpectedTimeToWinFormat
        {
            get
            {
                return this.ExpectedTimeToWin.GetDaysFromMinutes();
            }
        }


    }
}
