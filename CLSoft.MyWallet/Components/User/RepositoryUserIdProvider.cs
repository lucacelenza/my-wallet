using CLSoft.MyWallet.Business.User;
using CLSoft.MyWallet.Data.Repositories;
using System;

namespace CLSoft.MyWallet.Components.User
{
    public class RepositoryUserIdProvider : IUserIdProvider
    {
        private readonly IUserEmailAddressProvider _emailAddressProvider;
        private readonly IAuthRepository _repository;

        public RepositoryUserIdProvider(
            IUserEmailAddressProvider emailAddressProvider, IAuthRepository repository)
        {
            _emailAddressProvider = emailAddressProvider ?? 
                throw new ArgumentException(nameof(emailAddressProvider));

            _repository = repository ?? throw new ArgumentException(nameof(repository));
        }

        public long GetUserId()
        {
            var emailAddress = _emailAddressProvider.GetUserEmailAddress();

            var user = _repository.GetUserByEmailAddress(emailAddress);

            return user.Id;
        }
    }
}