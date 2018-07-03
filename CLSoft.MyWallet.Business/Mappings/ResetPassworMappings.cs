using AutoMapper;
using CLSoft.MyWallet.Business.Url;
using System;
using System.Dynamic;

namespace CLSoft.MyWallet.Business.Mappings
{
    public class ResetPasswordModelResolver : IMemberValueResolver<object, object, string, object>
    {
        private readonly IUrlResolver _urlResolver;

        public ResetPasswordModelResolver(IUrlResolver urlResolver)
        {
            _urlResolver = urlResolver ?? throw new ArgumentNullException(nameof(urlResolver));
        }

        public object Resolve(object source, object destination, string sourceMember, object destMember, ResolutionContext context)
        {
            dynamic model = new ExpandoObject();
            model.Url = _urlResolver.ResolveUrl("ChangePassword", "Auth", new { token = sourceMember });

            return model;
        }
    }
}