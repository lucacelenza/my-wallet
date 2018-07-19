using AutoMapper;
using CLSoft.MyWallet.Business.Wallets.Models;
using CLSoft.MyWallet.Models.Home;
using System.Collections.Generic;
using System.Linq;

namespace CLSoft.MyWallet.Mappings.Home
{
    public class WalletsProviderProfile : Profile
    {
        public WalletsProviderProfile()
        {
            CreateMap<Wallet, WalletViewModel>()
                .ForMember(d => d.CurrentBalance, o => o.MapFrom(s => s.CurrentBalance));

            CreateMap<IEnumerable<Wallet>, CurrentBalanceViewModel>()
                .ForMember(d => d.CurrentBalance, o => o.MapFrom(s => s.Select(w => w.CurrentBalance).Sum()));

            CreateMap<Wallet, IWalletViewModel>().ConvertUsing<WalletViewModelTypeConverter>();
        }
    }
}