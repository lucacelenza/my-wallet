namespace CLSoft.MyWallet.Business.Wallets.Models
{
    public class Wallet
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal CurrentBalance { get; set; }
    }
}