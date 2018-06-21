using AutoMapper;
using CLSoft.MyWallet.Data.Repositories;
using System;

namespace CLSoft.MyWallet.Business.Mappings
{
    public class EmailUserIdResolver : IMemberValueResolver<object, object, string, long>
    {
        private readonly IAuthRepository _repository;

        public EmailUserIdResolver(IAuthRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public long Resolve(object source, object destination, string sourceMember, long destMember, ResolutionContext context)
        {
            var user = _repository.GetUserByEmailAddress(sourceMember);
            return user.Id;
        }
    }
}