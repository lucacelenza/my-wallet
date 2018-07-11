namespace CLSoft.MyWallet.Models.Home
{
    public interface IWalletViewModel
    {
        long Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string CurrentBalance { get; set; }
    }
}