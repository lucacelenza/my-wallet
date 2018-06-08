using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLSoft.MyWallet.Models.Wallets
{
    public class WalletsViewModel
    {
        public IEnumerable<IWalletTableRecordViewModel> Wallets { get; set; }

        public class WalletTableRecordViewModel : IWalletTableRecordViewModel
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public class NotDeletableWalletTableRecordViewModel : IWalletTableRecordViewModel
        {
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public interface IWalletTableRecordViewModel
        {
            string Name { get; set; }
            string Description { get; set; }
        }
    }
}