using System.Collections.Generic;
using System.Data.Entity.Resources;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace System.Data.Entity.ModelConfiguration.Utilities;

internal static class ExpressionExtensions
{
	public static PropertyPath GetSimplePropertyAccess(this LambdaExpression propertyAccessExpression)
	{
		PropertyPath propertyPath = propertyAccessExpression.Parameters.Single().MatchSimplePropertyAccess(propertyAccessExpression.Body);
		if (propertyPath == null)
		{
			throw Error.InvalidPropertyExpression(propertyAccessExpression);
		}
		return propertyPath;
	}

	public static PropertyPath GetComplexPropertyAccess(this LambdaExpression propertyAccessExpression)
	{
		PropertyPath propertyPath = propertyAccessExpression.Parameters.Single().MatchComplexPropertyAccess(propertyAccessExpression.Body);
		if (propertyPath == null)
		{
			throw Error.InvalidComplexPropertyExpression(propertyAccessExpression);
		}
		return propertyPath;
	}

	public static IEnumerable<PropertyPath> GetSimplePropertyAccessList(this LambdaExpression propertyAccessExpression)
	{
		IEnumerable<PropertyPath> enumerable = propertyAccessExpression.MatchPropertyAccessList((Expression p, Expression e) => e.MatchSimplePropertyAccess(p));
		if (enumerable == null)
		{
			throw Error.InvalidPropertiesExpression(propertyAccessExpression);
		}
		return enumerable;
	}

	public static IEnumerable<PropertyPath> GetComplexPropertyAccessList(this LambdaExpression propertyAccessExpression)
	{
		IEnumerable<PropertyPath> enumerable = propertyAccessExpression.MatchPropertyAccessList((Expression p, Expression e) => e.MatchComplexPropertyAccess(p));
		if (enumerable == null)
		{
			throw Error.InvalidComplexPropertiesExpression(propertyAccessExpression);
		}
		return enumerable;
	}

	private static IEnumerable<PropertyPath> MatchPropertyAccessList(this LambdaExpression lambdaExpression, Func<Expression, Expression, PropertyPath> propertyMatcher)
	{
		if (lambdaExpression.Body.RemoveConvert() is NewExpression newExpression)
		{
			ParameterExpression parameterExpression = lambdaExpression.Parameters.Single();
			IEnumerable<PropertyPath> enumerable = from a in newExpression.Arguments
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
		PropertyPath propertyPath = propertyMatcher(lambdaExpression.Body, lambdaExpression.Parameters.Single());
		if (!(propertyPath != null))
		{
			return null;
		}
		return propertyPath.AsEnumerable();
	}

	private static bool HasDefaultMembersOnly(this NewExpression newExpression, IEnumerable<PropertyPath> propertyPaths)
	{
		return !newExpression.Members.Where((MemberInfo t, int i) => !string.Equals(t.Name, propertyPaths.ElementAt(i).Last().Name, StringComparison.Ordinal)).Any();
	}

	private static PropertyPath MatchSimplePropertyAccess(this Expression parameterExpression, Expression propertyAccessExpression)
	{
		PropertyPath propertyPath = parameterExpression.MatchPropertyAccess(propertyAccessExpression);
		if (propertyPath.Count() != 1)
		{
			return null;
		}
		return propertyPath;
	}

	private static PropertyPath MatchComplexPropertyAccess(this Expression parameterExpression, Expression propertyAccessExpression)
	{
		PropertyPath propertyPath = parameterExpression.MatchPropertyAccess(propertyAccessExpression);
		if (!propertyPath.Any())
		{
			return null;
		}
		return propertyPath;
	}

	private static PropertyPath MatchPropertyAccess(this Expression parameterExpression, Expression propertyAccessExpression)
	{
		List<PropertyInfo> list = new List<PropertyInfo>();
		do
		{
			if (!(propertyAccessExpression.RemoveConvert() is MemberExpression memberExpression))
			{
				return PropertyPath.Empty;
			}
			PropertyInfo propertyInfo = memberExpression.Member as PropertyInfo;
			if (propertyInfo == null)
			{
				return PropertyPath.Empty;
			}
			list.Insert(0, propertyInfo);
			propertyAccessExpression = memberExpression.Expression;
		}
		while (memberExpression.Expression != parameterExpression);
		return new PropertyPath(list);
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
