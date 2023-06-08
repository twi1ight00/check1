using System;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper.Impl;

public static class ReflectionHelper
{
	public static MemberInfo FindProperty(LambdaExpression lambdaExpression)
	{
		Expression expression = lambdaExpression;
		bool flag = false;
		while (!flag)
		{
			switch (expression.NodeType)
			{
			case ExpressionType.Convert:
				expression = ((UnaryExpression)expression).Operand;
				break;
			case ExpressionType.Lambda:
				expression = ((LambdaExpression)expression).Body;
				break;
			case ExpressionType.MemberAccess:
			{
				MemberExpression memberExpression = (MemberExpression)expression;
				if (memberExpression.Expression.NodeType != ExpressionType.Parameter && memberExpression.Expression.NodeType != ExpressionType.Convert)
				{
					throw new ArgumentException($"Expression '{lambdaExpression}' must resolve to top-level member and not any child object's properties. Use a custom resolver on the child type or the AfterMap option instead.", "lambdaExpression");
				}
				return memberExpression.Member;
			}
			default:
				flag = true;
				break;
			}
		}
		throw new AutoMapperConfigurationException("Custom configuration for members is only supported for top-level individual members on a type.");
	}

	public static Type GetMemberType(this MemberInfo memberInfo)
	{
		if (memberInfo is MethodInfo)
		{
			return ((MethodInfo)memberInfo).ReturnType;
		}
		if (memberInfo is PropertyInfo)
		{
			return ((PropertyInfo)memberInfo).PropertyType;
		}
		if (memberInfo is FieldInfo)
		{
			return ((FieldInfo)memberInfo).FieldType;
		}
		return null;
	}

	public static IMemberGetter ToMemberGetter(this MemberInfo accessorCandidate)
	{
		if ((object)accessorCandidate == null)
		{
			return null;
		}
		if (accessorCandidate is PropertyInfo)
		{
			return new PropertyGetter((PropertyInfo)accessorCandidate);
		}
		if (accessorCandidate is FieldInfo)
		{
			return new FieldGetter((FieldInfo)accessorCandidate);
		}
		if (accessorCandidate is MethodInfo)
		{
			return new MethodGetter((MethodInfo)accessorCandidate);
		}
		return null;
	}

	public static IMemberAccessor ToMemberAccessor(this MemberInfo accessorCandidate)
	{
		if (accessorCandidate is FieldInfo fieldInfo)
		{
			if (!accessorCandidate.DeclaringType.IsValueType)
			{
				return new FieldAccessor(fieldInfo);
			}
			return new ValueTypeFieldAccessor(fieldInfo);
		}
		if (accessorCandidate is PropertyInfo propertyInfo)
		{
			if (!accessorCandidate.DeclaringType.IsValueType)
			{
				return new PropertyAccessor(propertyInfo);
			}
			return new ValueTypePropertyAccessor(propertyInfo);
		}
		return null;
	}
}
