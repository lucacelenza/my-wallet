using AutoMapper;
using CLSoft.MyWallet.Data.EntityFramework.Entities;
using CLSoft.MyWallet.Data.Models.Auth;
using System.Collections.Generic;

namespace CLSoft.MyWallet.Data.EntityFramework.Mappings
{
    public class NewUserWalletsValueResolver : IValueResolver<AddUserRequest, Entities.User, ICollection<Wallet>>
    {
        public ICollection<Wallet> Resolve(AddUserRequest source, Entities.User destination, ICollection<Wallet> destMember, ResolutionContext context)
        {
            return new[] {
                new Wallet()
                {
                    Name = source.StartWallet.Name,
                    Description = source.StartWallet.Description,
                    RegisteredOn = source.RegisteredOn,
                    Transactions = new[]
                    {
                        new Transaction()
                        {
                            Description = source.StartWallet.DepositTransaction.Description,
                            Amount = source.StartWallet.DepositTransaction.Amount,
                            RegisteredOn = source.RegisteredOn
                        }
                    }
                }
            };
        }
    }
}