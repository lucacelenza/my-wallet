using AutoMapper;
using CLSoft.MyWallet.Business.Email.Models;
using CLSoft.MyWallet.Business.Mappings;
using CLSoft.MyWallet.Mappings.Auth;

namespace CLSoft.MyWallet.Mappings
{
    public class EmailSenderProfile : Profile
    {
        public EmailSenderProfile()
        {
            CreateMap<Data.Models.Auth.ForgotPasswordToken, SendEmailRequest>()
                .ForMember(d => d.To, o => o.ResolveUsing<UserIdEmailResolver, long>(s => s.UserId))
                .ForMember(d => d.Subject, o => o.UseValue("Reset password"))
                .ForMember(d => d.Template, o => o.UseValue("ResetPassword"))
                .ForMember(d => d.Model, o => o.ResolveUsing<ResetPasswordModelResolver, string>(s => s.Token));
        }
    }
}