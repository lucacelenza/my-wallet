using System.Collections.Generic;
using System.Security.Claims;
using AutoMapper;
using CLSoft.MyWallet.Business.Identity.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace CLSoft.MyWallet.Mappings.Auth
{
    public class IdentityManagerProfile : Profile
    {
        public IdentityManagerProfile()
        {
            CreateMap<SignInRequest, ClaimsPrincipal>()
                .ConvertUsing((source, destination, context) =>
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, source.IdentityName)
                    };

                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    return new ClaimsPrincipal(claimsIdentity);
                });

            CreateMap<SignInRequest, AuthenticationProperties>()
                .ConvertUsing((source, destination, context) => new AuthenticationProperties
                {
                    IsPersistent = source.IsPersistent
                });
        }
    }
}