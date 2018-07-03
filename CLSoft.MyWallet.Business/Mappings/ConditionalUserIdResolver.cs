using AutoMapper;
using CLSoft.MyWallet.Business.Password.Exceptions;
using CLSoft.MyWallet.Business.Password.Models;
using CLSoft.MyWallet.Business.Time;
using CLSoft.MyWallet.Business.User;
using CLSoft.MyWallet.Data.Repositories;
using System;

namespace CLSoft.MyWallet.Business.Mappings
{
    public class ConditionalUserIdResolver : IValueResolver<ChangePasswordRequest, object, long>
    {
        private readonly IUserIdProvider _userIdProvider;
        private readonly IAuthRepository _authRepository;
        
        public ConditionalUserIdResolver(IUserIdProvider userIdProvider, IAuthRepository authRepository)
        {
            _userIdProvider = userIdProvider ?? throw new ArgumentNullException(nameof(userIdProvider));
            _authRepository = authRepository ?? throw new ArgumentNullException(nameof(authRepository));
        }

        public long Resolve(ChangePasswordRequest source, object destination, long destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.Token))
            {
                return _userIdProvider.GetUserId();
            }
            else
            {
                var forgotPasswordToken = _authRepository.GetForgotPasswordTokenByToken(source.Token);

                if (forgotPasswordToken.ExpiresOn < TimeProvider.Current.Now)
                    throw new ExpiredTokenException();

                return forgotPasswordToken.UserId;
            }
        }
    }
}