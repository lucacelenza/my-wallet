using AutoMapper;
using CLSoft.MyWallet.Data.Models.Auth;

namespace CLSoft.MyWallet.Data.EntityFramework.Mappings
{
    public class FogotPasswordTokenProfile : Profile
    {
        public FogotPasswordTokenProfile()
        {
            CreateMap<Entities.ForgotPasswordToken, ForgotPasswordToken>();
            CreateMap<ForgotPasswordToken, Entities.ForgotPasswordToken>();
        }
    }
}