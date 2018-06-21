using AutoMapper;
using CLSoft.MyWallet.Data.Repositories;
using System;

namespace CLSoft.MyWallet.Business.Mappings
{
    public class UserIdEmailResolver : IMemberValueResolver<object, object, long, string>
    {
        private readonly IAuthRepository _repository;

        public UserIdEmailResolver(IAuthRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public string Resolve(object source, object destination, long sourceMember, string destMember, ResolutionContext context)
        {
            var user = _repository.GetUserById(sourceMember);
            return user.EmailAddress;
        }
    }
}