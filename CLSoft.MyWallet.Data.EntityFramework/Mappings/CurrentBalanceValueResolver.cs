using AutoMapper;
using CLSoft.MyWallet.Data.EntityFramework.Entities;
using System.Linq;

namespace CLSoft.MyWallet.Data.EntityFramework.Mappings
{
    public class CurrentBalanceValueResolver : IValueResolver<Wallet, object, decimal>
    {
        public decimal Resolve(Wallet source, object destination, decimal destMember, ResolutionContext context)
        {
            return source.Transactions.Select(t => t.Amount).Sum();
        }
    }
}