using AutoMapper;
using CLSoft.MyWallet.Business.Wallets.Models;
using System.Collections.Generic;

namespace CLSoft.MyWallet.Business.Mappings
{
    public class WalletsProfile : Profile
    {
        public WalletsProfile()
        {
            CreateMap<Data.Models.Wallets.Wallets.Wallet, Wallet>();
            CreateMap<Data.Models.Wallets.Wallets, IEnumerable<Wallet>>();
        }
    }
}