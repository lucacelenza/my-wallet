using AutoMapper;
using CLSoft.MyWallet.Business.Time;
using CLSoft.MyWallet.Data.Models.Wallets;
using CLSoft.MyWallet.Models.Wallets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLSoft.MyWallet.Mappings.Wallets
{
    public class WalletsProfile : Profile
    {
        public WalletsProfile()
        {
            CreateMap<WalletViewModel, Wallet>()
                .ForMember(d => d.RegisteredOn, s => s.UseValue(TimeProvider.Current.Now))
                .ForMember(d => d.UserId, s => s.ResolveUsing<UserIdResolver>());

            CreateMap<Wallet, WalletViewModel>();
        }
    }
}
