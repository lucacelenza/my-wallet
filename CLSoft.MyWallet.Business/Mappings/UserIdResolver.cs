using AutoMapper;
using CLSoft.MyWallet.Business.User;
using System;

namespace CLSoft.MyWallet.Business.Mappings
{
    public class UserIdResolver : IValueResolver<object, object, long>
    {
        private readonly IUserIdProvider _userIdProvider;

        public UserIdResolver(IUserIdProvider userIdProvider)
        {
            _userIdProvider = userIdProvider ?? throw new ArgumentNullException(nameof(userIdProvider));
        }

        public long Resolve(object source, object destination, long destMember, ResolutionContext context)
        {
            return _userIdProvider.GetUserId();
        }
    }
}