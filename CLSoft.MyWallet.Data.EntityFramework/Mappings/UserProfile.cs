using AutoMapper;
using CLSoft.MyWallet.Data.Models.Auth;

namespace CLSoft.MyWallet.Data.EntityFramework.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AddUserRequest, Entities.User>();
            CreateMap<User, Entities.User>();
        }
    }
}