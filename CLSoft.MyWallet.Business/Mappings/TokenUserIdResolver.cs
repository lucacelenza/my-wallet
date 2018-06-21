using AutoMapper;
using CLSoft.MyWallet.Business.Password.Exceptions;
using CLSoft.MyWallet.Business.Time;
using CLSoft.MyWallet.Data.Repositories;
using System;

namespace CLSoft.MyWallet.Business.Mappings
{
    public class TokenUserIdResolver : IMemberValueResolver<object, object, string, long>
    {
        private readonly IAuthRepository _repository;

        public TokenUserIdResolver(IAuthRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public long Resolve(object source, object destination, string sourceMember, long destMember, ResolutionContext context)
        {
            var forgotPasswordToken = _repository.GetForgotPasswordTokenByToken(sourceMember);

            if (forgotPasswordToken.ExpiresOn < TimeProvider.Current.Now)
                throw new ExpiredTokenException();

            return forgotPasswordToken.UserId;
        }
    }
}