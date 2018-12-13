namespace CLSoft.MyWallet.Models.Home
{
    public class WalletViewModel
    {
        public long Id { get; }
        public string Name { get; }
        public string Description { get; }
        public string CurrentBalance { get; }
        public bool IsNewWalletViewModel { get; }

        public WalletViewModel(long id, string name, string description, string currentBalance)
        {
            Id = id;
            Name = name;
            Description = description;
            CurrentBalance = currentBalance;
        }
        private WalletViewModel()
        {
            IsNewWalletViewModel = true;
        }

        public static WalletViewModel CreateNewWalletViewModel()
        {
            return new WalletViewModel();
        }
    }
}