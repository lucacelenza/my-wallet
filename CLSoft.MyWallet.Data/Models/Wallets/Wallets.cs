using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CLSoft.MyWallet.Data.Models.Wallets
{
    public class Wallets : IEnumerable<Wallets.Wallet>
    {
        private readonly List<Wallet> _wallets;

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
        }
    }
}
