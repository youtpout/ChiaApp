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
                return GetXchFromMojo(this.TotalBalance);
            }
        }
        public string PendingBalanceFormat
        {
            get
            {
                return GetXchFromMojo(this.PendingBalance);
            }
        }
        public string SpendableBalanceFormat
        {
            get
            {
                return GetXchFromMojo(this.SpendableBalance);
            }
        }

        private string GetXchFromMojo(decimal mojo)
        {
            decimal result = 0;
            result = mojo / (decimal)Math.Pow(10, 12);
            return $"{result} XCH";
        }
    }
}
