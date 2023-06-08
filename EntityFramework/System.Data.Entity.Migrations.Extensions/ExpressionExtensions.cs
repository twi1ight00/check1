using System.Collections.Generic;
using System.Data.Entity.Resources;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace System.Data.Entity.Migrations.Extensions;

internal static class ExpressionExtensions
{
	public static IEnumerable<PropertyInfo> GetPropertyAccessList(this LambdaExpression propertyAccessExpression)
	{
		IEnumerable<PropertyInfo> enumerable = propertyAccessExpression.MatchPropertyAccessList((Expression p, Expression e) => e.MatchPropertyAccess(p));
		if (enumerable == null)
		{
			throw Error.InvalidPropertiesExpression(propertyAccessExpression);
		}
		return enumerable;
	}

	private static IEnumerable<PropertyInfo> MatchPropertyAccessList(this LambdaExpression lambdaExpression, Func<Expression, Expression, PropertyInfo> propertyMatcher)
	{
		if (lambdaExpression.Body.RemoveConvert() is NewExpression newExpression)
		{
			ParameterExpression parameterExpression = lambdaExpression.Parameters.Single();
			IEnumerable<PropertyInfo> enumerable = from a in newExpression.Arguments
				select propertyMatcher(a, parameterExpression) into p
				where p != null
				select p;
			if (enumerable.Count() == newExpression.Arguments.Count())
			{
				if (!newExpression.HasDefaultMembersOnly(enumerable))
				{
					return null;
				}
				return enumerable;
			}
		}
		PropertyInfo propertyInfo = propertyMatcher(lambdaExpression.Body, lambdaExpression.Parameters.Single());
		if (!(propertyInfo != null))
		{
			return null;
		}
		return new PropertyInfo[1] { propertyInfo };
	}

	private static bool HasDefaultMembersOnly(this NewExpression newExpression, IEnumerable<PropertyInfo> propertyInfos)
	{
		return !newExpression.Members.Where((MemberInfo t, int i) => !string.Equals(t.Name, propertyInfos.ElementAt(i).Name, StringComparison.Ordinal)).Any();
	}

	private static PropertyInfo MatchPropertyAccess(this Expression parameterExpression, Expression propertyAccessExpression)
	{
		if (!(propertyAccessExpression.RemoveConvert() is MemberExpression memberExpression))
		{
			return null;
		}
		PropertyInfo propertyInfo = memberExpression.Member as PropertyInfo;
		if (propertyInfo == null)
		{
			return null;
		}
		if (memberExpression.Expression != parameterExpression)
		{
			return null;
		}
		return propertyInfo;
	}

	public static Expression RemoveConvert(this Expression expression)
	{
		while (expression != null && (expression.NodeType == ExpressionType.Convert || expression.NodeType == ExpressionType.ConvertChecked))
		{
			expression = ((UnaryExpression)expression).Operand.RemoveConvert();
		}
		return expression;
	}
}
