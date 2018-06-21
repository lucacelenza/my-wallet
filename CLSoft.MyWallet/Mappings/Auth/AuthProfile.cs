using AutoMapper;
using CLSoft.MyWallet.Business.Time;
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
                .ForMember(d => d.RegisteredOn, o => o.UseValue(TimeProvider.Current.Now));
        }
    }
}