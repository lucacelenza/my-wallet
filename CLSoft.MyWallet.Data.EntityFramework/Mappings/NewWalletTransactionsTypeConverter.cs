using AutoMapper;
using CLSoft.MyWallet.Data.EntityFramework.Entities;
using CLSoft.MyWallet.Data.Models.Wallets;
using System.Collections.Generic;

namespace CLSoft.MyWallet.Data.EntityFramework.Mappings
{
    public class NewWalletTransactionsTypeConverter : IValueResolver<AddWalletRequest, Entities.Wallet, ICollection<Transaction>>
    {
        public ICollection<Transaction> Resolve(AddWalletRequest source, Entities.Wallet destination, ICollection<Transaction> destMember, ResolutionContext context)
        {
            return new[]
            {
                new Transaction()
                {
                    Description = source.BaseTransaction.Description,
                    Amount = source.BaseTransaction.Amount,
                    RegisteredOn = source.RegisteredOn
                }
            };
        }
    }
}