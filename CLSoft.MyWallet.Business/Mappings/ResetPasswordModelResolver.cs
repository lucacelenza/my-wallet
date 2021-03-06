﻿using AutoMapper;
using CLSoft.MyWallet.Business.Password.Models;
using CLSoft.MyWallet.Business.Time;
using System;

namespace CLSoft.MyWallet.Business.Mappings
{
    public class PasswordManagerProfile : Profile
    {
        public PasswordManagerProfile()
        {
            CreateMap<ChangePasswordRequest, Data.Models.Auth.ChangeUserPasswordRequest>()
                .ForMember(d => d.UserId, o => o.ResolveUsing<ConditionalUserIdResolver>())
                .ForMember(d => d.NewHashedPassword, o => o.ResolveUsing<HashedStringResolver, string>(s => s.NewPassword))
                .ForMember(d => d.ChangedOn, o => o.UseValue(TimeProvider.Current.Now));

            CreateMap<IssueChangePasswordRequest, Data.Models.Auth.ForgotPasswordToken>()
                .ForMember(d => d.Token, o => o.UseValue(Guid.NewGuid().ToString()))
                .ForMember(d => d.UserId, o => o.ResolveUsing<EmailUserIdResolver, string>(s => s.EmailAddress))
                .ForMember(d => d.RegisteredOn, o => o.UseValue(TimeProvider.Current.Now))
                .ForMember(d => d.ExpiresOn, o => o.UseValue(TimeProvider.Current.Now.AddHours(1)));
        }
    }
}