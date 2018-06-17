using CLSoft.MyWallet.Business.Identity;
using CLSoft.MyWallet.Business.Identity.Models;
using CLSoft.MyWallet.Mappings;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CLSoft.MyWallet.Components.Identity
{
    public class HttpContextIdentityManager : IIdentityManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpContextIdentityManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? 
                throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public async Task SignInAsync(SignInRequest request)
        {
            var principal = Mapper.Current.Map<ClaimsPrincipal>(request);
            var properties = Mapper.Current.Map<AuthenticationProperties>(request);
            await _httpContextAccessor.HttpContext.SignInAsync(principal, properties);
        }

//        var claims = new List<Claim>
//{
//    new Claim(ClaimTypes.Name, user.Email),
//    new Claim("LastChanged", {Database Value})
//};

//    var claimsIdentity = new ClaimsIdentity(
//        claims,
//        CookieAuthenticationDefaults.AuthenticationScheme);

        public async Task SignOutAsync()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync();
        }
    }
}