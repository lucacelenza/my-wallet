using AutoMapper;
using CLSoft.MyWallet.Business.Identity.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Collections.Generic;
using System.Security.Claims;

namespace CLSoft.MyWallet.Mappings
{
    public class IdentityManagerProfile : Profile
    {
        public IdentityManagerProfile()
        {
            CreateMap<SignInRequest, ClaimsPrincipal>()
                .ConvertUsing<ClaimsPrincipalTypeConverter>();

            CreateMap<SignInRequest, AuthenticationProperties>()
                .ConvertUsing<AuthenticationPropertiesTypeConverter>();
        }

        public class ClaimsPrincipalTypeConverter : ITypeConverter<SignInRequest, ClaimsPrincipal>
        {
            public ClaimsPrincipal Convert(SignInRequest source, ClaimsPrincipal destination, ResolutionContext context)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, source.IdentityName)
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                return new ClaimsPrincipal(claimsIdentity);
            }
        }

        public class AuthenticationPropertiesTypeConverter : ITypeConverter<SignInRequest, AuthenticationProperties>
        {
            public AuthenticationProperties Convert(SignInRequest source, AuthenticationProperties destination, ResolutionContext context)
            {
                return new AuthenticationProperties
                {
                    IsPersistent = source.IsPersistent
                };
            }
        }
    }
}