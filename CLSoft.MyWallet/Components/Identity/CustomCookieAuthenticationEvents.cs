using CLSoft.MyWallet.Business.Identity;
using CLSoft.MyWallet.Business.Identity.Exceptions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Threading.Tasks;

namespace CLSoft.MyWallet.Components.Identity
{
    public class CustomCookieAuthenticationEvents : CookieAuthenticationEvents
    {
        private readonly IIdentityValidator _identityValidator;

        public CustomCookieAuthenticationEvents(IIdentityValidator identityValidator)
        {
            _identityValidator = identityValidator ?? throw new ArgumentNullException(nameof(identityValidator));
        }

        public override async Task ValidatePrincipal(CookieValidatePrincipalContext context)
        {
            try
            {
                await _identityValidator.ValidatePrincipalAsync(context.Principal);
            }
            catch (InvalidIdentityException)
            {
                context.RejectPrincipal();

                await context.HttpContext.SignOutAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme);
            }
        }        
    }
}