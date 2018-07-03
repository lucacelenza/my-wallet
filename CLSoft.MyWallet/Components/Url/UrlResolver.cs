using CLSoft.MyWallet.Business.Url;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using System;

namespace CLSoft.MyWallet.Components.Url
{
    public class UrlResolver : IUrlResolver
    {
        private readonly IActionContextAccessor _actionContextAccessor;

        public UrlResolver(IActionContextAccessor actionContextAccessor)
        {
            _actionContextAccessor = actionContextAccessor ?? 
                throw new ArgumentNullException(nameof(actionContextAccessor));
        }

        public string ResolveUrl(string action, string controller, object routeValues)
        {
            IUrlHelper urlHelper = new UrlHelper(_actionContextAccessor.ActionContext);

            var scheme = urlHelper.ActionContext.HttpContext.Request.Scheme;
            var host = urlHelper.ActionContext.HttpContext.Request.Host.ToUriComponent();

            return urlHelper.Action(action, controller, routeValues, scheme, host);
        }
    }
}