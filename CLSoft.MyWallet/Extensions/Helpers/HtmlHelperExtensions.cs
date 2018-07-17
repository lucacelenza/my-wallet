using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CLSoft.MyWallet.Extensions.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlContent DisplayForInterface<TModel, TValue>(
            this IHtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression)
        {
            var propertyInfo = helper.ViewData.GetViewDataInfo(
                ((MemberExpression)expression.Body).Member.Name);

            var destinationType = propertyInfo.Value.GetType();

            return helper.DisplayFor(expression);
        }
    }
}
