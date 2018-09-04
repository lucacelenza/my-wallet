namespace CLSoft.MyWallet.Business.TimeBalance.Models
{
    public class GetTimeBalanceRequest
    {
        public TimeBalanceSearchRange SearchRange { get; set; }
        public long? WalletId { get; set; }
    }
}