﻿using AutoMapper;
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
            CreateMap<WalletViewModel, AddWalletRequest>()
                .ForMember(d => d.RegisteredOn, o => o.UseValue(TimeProvider.Current.Now))
                .ForMember(d => d.UserId, o => o.ResolveUsing<UserIdResolver>());

            CreateMap<WalletViewModel, EditWalletRequest>()
                .ForMember(d => d.UpdatedOn, o => o.UseValue(TimeProvider.Current.Now));

            CreateMap<Wallet, WalletViewModel>();
        }
    }
}
