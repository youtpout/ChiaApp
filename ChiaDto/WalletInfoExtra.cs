using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiaDto
{
    public partial class WalletInfo
    {
        public string TotalBalanceFormat
        {
            get
            {
                return this.TotalBalance.GetXchFromMojo();
            }
        }
        public string PendingBalanceFormat
        {
            get
            {
                return this.PendingBalance.GetXchFromMojo();
            }
        }
        public string SpendableBalanceFormat
        {
            get
            {
                return this.SpendableBalance.GetXchFromMojo();
            }
        }


    }
}
