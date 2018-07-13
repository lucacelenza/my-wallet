using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace CLSoft.MyWallet.Extensions.Helpers
{
    public static class HtmlHelperInterfaceExtensions
    {
        public static IHtmlContent DisplayForInterface<TInterface, TImplementation>(this IHtmlHelper<TInterface> helper,
            Expression<Func<TInterface, TImplementation>> expression)
        {
            var modelType = expression.Parameters[0].Type;
            var expBody = expression.Body as MemberExpression;
            var p = (PropertyInfo)expBody.Member;

            var type = p.GetType();
            var param = Expression.Parameter(type);
            var body = new Visitor(param, type).Visit(expression.Body);

            var lambda = Expression.Lambda<Func<TInterface, TImplementation>>(body, param);

            return helper.DisplayFor(lambda);
        }
    }
}