using AutoMapper;
using CLSoft.MyWallet.Business.Time;
using CLSoft.MyWallet.Data.Models.Wallets;
using CLSoft.MyWallet.Models.Wallets;

namespace CLSoft.MyWallet.Mappings.Wallets
{
    public class WalletsProfile : Profile
    {
        public WalletsProfile()
        {
            CreateMap<WalletViewModel, AddWalletRequest>()
                .ForMember(d => d.RegisteredOn, o => o.UseValue(TimeProvider.Current.Now))
                .ForMember(d => d.UserId, o => o.ResolveUsing<UserIdResolver>())
                .ForMember(d => d.BaseTransaction, o => o.ResolveUsing<AddWalletBaseTransactionResolver>());

            CreateMap<WalletViewModel, EditWalletRequest>()
                .ForMember(d => d.UpdatedOn, o => o.UseValue(TimeProvider.Current.Now))
                .ForMember(d => d.BaseTransactionAmount, o => o.MapFrom(s => s.Amount.Value));

            CreateMap<Wallet, WalletViewModel>()
                .ForMember(d => d.Amount, o => o.ResolveUsing<WalletBaseAmountResolver>());
        }
    }
}
