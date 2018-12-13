using System;
using System.Threading.Tasks;
using CLSoft.MyWallet.Business.User;
using CLSoft.MyWallet.Data.Repositories;

namespace CLSoft.MyWallet.Components.User
{
    public class RepositoryUserNameProvider : IUserNameProvider
    {
        private readonly IUserEmailAddressProvider _emailAddressProvider;
        private readonly IAuthRepository _repository;

        public RepositoryUserNameProvider(
            IUserEmailAddressProvider emailAddressProvider, IAuthRepository repository)
        {
            _emailAddressProvider = emailAddressProvider ?? throw new ArgumentException(nameof(emailAddressProvider));
            _repository = repository ?? throw new ArgumentException(nameof(repository));
        }

        public async Task<string> GetUserNameAsync()
        {
            var emailAddress = _emailAddressProvider.GetUserEmailAddress();

            var user = await _repository.GetUserByEmailAddressAsync(emailAddress);

            return $"{user.FirstName} {user.LastName}";
        }
    }
}
