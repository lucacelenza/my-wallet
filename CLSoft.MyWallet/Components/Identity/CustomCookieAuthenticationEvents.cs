using CLSoft.MyWallet.Business.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Threading.Tasks;

namespace CLSoft.MyWallet.Components.Identity
{
    public class CustomCookieAuthenticationEvents : CookieAuthenticationEvents
    {
        private readonly IUserIdProvider _userIdProvider;

        public CustomCookieAuthenticationEvents(IUserIdProvider userIdProvider)
        {
            _userIdProvider = userIdProvider ?? throw new ArgumentNullException(nameof(userIdProvider));
        }

        public override async Task ValidatePrincipal(CookieValidatePrincipalContext context)
        {
            try
            {
                _userIdProvider.GetUserId();
            }
            catch
            {
                context.RejectPrincipal();

                await context.HttpContext.SignOutAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme);
            }
        }
    }
}