using AutoMapper;
using CLSoft.MyWallet.Business.Identity;
using CLSoft.MyWallet.Business.Identity.Models;
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
        private readonly IMapper _mapper;

        public HttpContextIdentityManager(IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor ?? 
                throw new ArgumentNullException(nameof(httpContextAccessor));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task SignInAsync(SignInRequest request)
        {
            var principal = _mapper.Map<ClaimsPrincipal>(request);
            var properties = _mapper.Map<AuthenticationProperties>(request);
            await _httpContextAccessor.HttpContext.SignInAsync(principal, properties);
        }

        public async Task SignOutAsync()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync();
        }
    }
}