using AutoMapper;
using CLSoft.MyWallet.Data.Models.Wallets;
using System;
using System.Collections.Generic;
using System.Text;

namespace CLSoft.MyWallet.Data.EntityFramework.Mappings
{
    public class WalletProfile : Profile
    {
        public WalletProfile()
        {
            CreateMap<AddWalletRequest, Entities.Wallet>();
            CreateMap<Entities.Wallet, Wallet>();
            CreateMap<IEnumerable<Entities.Wallet>, Wallets>();
        }
    }
}