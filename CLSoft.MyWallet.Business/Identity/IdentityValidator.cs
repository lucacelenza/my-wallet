using CLSoft.MyWallet.Business.Identity.Exceptions;
using CLSoft.MyWallet.Data.Exceptions;
using CLSoft.MyWallet.Data.Repositories;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CLSoft.MyWallet.Business.Identity
{
    public class IdentityValidator : IIdentityValidator
    {
        private readonly IAuthRepository _repository;

        public IdentityValidator(IAuthRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task ValidatePrincipalAsync(ClaimsPrincipal principal)
        {
            if (!principal.Identity.IsAuthenticated)
                throw new InvalidIdentityException();

            try
            {
                var user = await _repository
                    .GetUserByEmailAddressAsync(principal.Identity.Name);
            }
            catch (DataNotFoundException)
            {
                throw new InvalidIdentityException();
            }
        }
    }
}