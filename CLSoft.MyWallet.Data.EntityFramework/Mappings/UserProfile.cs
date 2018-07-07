using AutoMapper;
using CLSoft.MyWallet.Data.Models.Auth;

namespace CLSoft.MyWallet.Data.EntityFramework.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AddUserRequest, Entities.User>()
                .ForMember(dest => dest.Wallets, o => o.ResolveUsing<NewUserWalletsValueResolver>());

            CreateMap<User, Entities.User>();
        }
    }
}