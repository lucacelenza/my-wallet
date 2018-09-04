using System.Collections.Generic;

namespace CLSoft.MyWallet.Models.Home
{
    public class TimeBalanceViewModel
    {
        public IEnumerable<string> Labels { get; set; }
        public IEnumerable<decimal> Data { get; set; }
        public string Culture { get; set; }
        public string CurrencyCode { get; set; }
    }
}