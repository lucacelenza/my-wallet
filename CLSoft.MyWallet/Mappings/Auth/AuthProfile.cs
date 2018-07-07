using AutoMapper;
using CLSoft.MyWallet.Business.Time;
using CLSoft.MyWallet.Models;
using CLSoft.MyWallet.Models.Auth;

namespace CLSoft.MyWallet.Mappings.Auth
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<LoginViewModel, Business.Identity.Models.SignInRequest>()
                .ForMember(d => d.IdentityName, o => o.MapFrom(s => s.EmailAddress))
                .ForMember(d => d.IsPersistent, o => o.MapFrom(s => s.RememeberMe));

            CreateMap<RegisterUserViewModel, Data.Models.Auth.AddUserRequest>()
                .ForMember(d => d.HashedPassword, o => o.ResolveUsing<HashedStringResolver, string>(s => s.Password))
                .ForMember(d => d.RegisteredOn, o => o.UseValue(TimeProvider.Current.Now))
                .ForMember(d => d.StartWallet, o => o.MapFrom(s => s.StartWallet));

            CreateMap<RegisterUserViewModel.StartWalletViewModel, Data.Models.Auth.AddUserRequest.Wallet>()
                .ForMember(d => d.RegisteredOn, o => o.UseValue(TimeProvider.Current.Now))
                .ForMember(d => d.DepositTransaction, o => o.MapFrom(s => s));

            CreateMap<RegisterUserViewModel.StartWalletViewModel, Data.Models.Auth.AddUserRequest.Wallet.Transaction>()
                .ForMember(d => d.Description, o => o.ResolveUsing<DepositTransactionValueResolver>())
                .ForMember(d => d.Amount, o => o.ResolveUsing<CurrencyValueResolver, CurrencyViewModel>(s => s.Amount));
        }
    }
}