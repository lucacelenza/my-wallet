using AutoMapper;
using CLSoft.MyWallet.Data.Models.Auth;
using System.Collections.Generic;

namespace CLSoft.MyWallet.Data.EntityFramework.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AddUserRequest, Entities.User>()
                .ForMember(dest => dest.Wallets, o => o.MapFrom(source => source.StartWallet));

            CreateMap<AddUserRequest.Wallet, ICollection<Entities.Wallet>>()
                .ConvertUsing<NewUserWalletsTypeConverter>();

            CreateMap<AddUserRequest.Wallet, Entities.Wallet>();
            CreateMap<User, Entities.User>();
        }
    }
}