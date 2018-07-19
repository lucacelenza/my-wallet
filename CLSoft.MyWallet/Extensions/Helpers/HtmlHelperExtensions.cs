using CLSoft.MyWallet.Models.Home;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq.Expressions;

namespace CLSoft.MyWallet.Extensions.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlContent DisplayForInterface<TModel, TInterface>(this IHtmlHelper<TModel> helper, Expression<Func<TModel, TInterface>> expression)
        {
            var propertyInfo = helper.ViewData.GetViewDataInfo(
                ((MemberExpression)expression.Body).Member.Name);

            var destination = propertyInfo.Value;

            if (destination is IWalletViewModel)
            {
                if (destination is SelectedWalletViewModel)
                {
                    return helper.DisplayForImplementation<TModel, TInterface, SelectedWalletViewModel>(expression);
                }
                else
                {
                    return helper.DisplayForImplementation<TModel, TInterface, WalletViewModel>(expression);
                }
            }

            return helper.DisplayFor(expression);
        }

        private static IHtmlContent DisplayForImplementation<TModel, TInterface, TImplementation>(this IHtmlHelper<TModel> helper, Expression<Func<TModel, TInterface>> expression)
        {
            var newExpression = new ReturnTypeVisitor<TModel, TImplementation>().Visit(expression);
            return helper.DisplayFor((Expression<Func<TModel, TImplementation>>)newExpression);
        }
    }
}