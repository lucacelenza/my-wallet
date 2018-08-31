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
                .ForMember(d => d.CurrentBalance, o => o.MapFrom(s => s.Any(w => w.IsSelected) ? s.Where(w => w.IsSelected).Select(w => w.CurrentBalance).Sum() : s.Select(w => w.CurrentBalance).Sum()));
        }
    }
}