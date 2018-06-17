using CLSoft.MyWallet.Business.User;
using Microsoft.AspNetCore.Http;
using System;

namespace CLSoft.MyWallet.Components.User
{
    public class HttpContextUserEmailAddressProvider : IUserEmailAddressProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpContextUserEmailAddressProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? 
                throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public string GetUserEmailAddress()
        {
            return _httpContextAccessor.HttpContext.User.Identity.Name;
        }
    }
}