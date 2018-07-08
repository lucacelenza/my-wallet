using System.Collections;
using System.Collections.Generic;

namespace CLSoft.MyWallet.Data.Models.Wallets
{
    public class Wallets : IEnumerable<Wallets.Wallet>
    {
        private readonly List<Wallet> _wallets;

        public Wallets()
        {
            _wallets = new List<Wallet>();
        }
        public Wallets(IEnumerable<Wallet> wallets)
        {
            _wallets = new List<Wallet>(wallets);
        }

        public IEnumerator<Wallet> GetEnumerator()
        {
            return _wallets.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class Wallet
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal CurrentBalance { get; set; }
        }
    }
}