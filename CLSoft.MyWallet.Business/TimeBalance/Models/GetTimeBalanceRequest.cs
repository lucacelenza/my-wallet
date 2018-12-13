using System;

namespace CLSoft.MyWallet.Business.TimeBalance.Models
{
    public class GetTimeBalanceRequest
    {
        public TimeBalanceSearchRange SearchRange { get; }
        public long? WalletId { get; }

        public GetTimeBalanceRequest(TimeBalanceSearchRange searchRange)
        {
            SearchRange = searchRange ?? throw new ArgumentNullException(nameof(searchRange));
        }
        public GetTimeBalanceRequest(long walletId, TimeBalanceSearchRange searchRange) : this(searchRange)
        {
            WalletId = walletId;
        }
    }
}