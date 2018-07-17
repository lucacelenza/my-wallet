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

            var newExpression = new ReturnTypeVisitor<TModel>(destinationType).Visit(expression);

            return helper.DisplayFor(newExpression);
        }
    }

    public class ReturnTypeVisitor<TSource> : ExpressionVisitor
    {
        private readonly Type _returnValueType;

        public ReturnTypeVisitor(Type returnValueType)
        {
            _returnValueType = returnValueType;
        }

        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            var delegateType = typeof(Func<,>).MakeGenericType(typeof(TSource), _returnValueType);
            return Expression.Lambda(delegateType, Visit(node.Body), node.Parameters);
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Member.DeclaringType == typeof(TSource))
            {
                return Expression.Property(Visit(node.Expression), node.Member.Name);
            }
            return base.VisitMember(node);
        }
    }
}
