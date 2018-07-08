using AutoMapper;
using CLSoft.MyWallet.Data.Models.Wallets;
using System.Collections.Generic;

namespace CLSoft.MyWallet.Data.EntityFramework.Mappings
{
    public class WalletProfile : Profile
    {
        public WalletProfile()
        {
            CreateMap<AddWalletRequest, Entities.Wallet>();
            CreateMap<Entities.Wallet, Wallet>();

            CreateMap<IEnumerable<Entities.Wallet>, Wallets>()
                .ConvertUsing<WalletsTypeConverter>();

            CreateMap<Entities.Wallet, Wallets.Wallet>()
                .ForMember(d => d.CurrentBalance, o => o.ResolveUsing<CurrentBalanceValueResolver>());
        }
    }
}