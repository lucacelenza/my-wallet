using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;

namespace CLSoft.MyWallet.Mappings.Auth
{
    public class ResetPasswordModelResolver : IMemberValueResolver<object, object, string, object>
    {
        private readonly IUrlHelper _urlHelper;

        public ResetPasswordModelResolver(IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper ?? throw new ArgumentNullException(nameof(urlHelper));
        }

        public object Resolve(object source, object destination, string sourceMember, object destMember, ResolutionContext context)
        {
            dynamic model = new ExpandoObject();
            model.Url = _urlHelper.Action("ChangePassword", "Auth", new { token = sourceMember });

            return model;
        }
    }
}