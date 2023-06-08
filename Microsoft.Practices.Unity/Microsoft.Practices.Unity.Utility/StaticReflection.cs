using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Microsoft.Practices.Unity.Utility;

/// <summary>
/// A set of helper methods to pick through lambdas and pull out
/// <see cref="T:System.Reflection.MethodInfo" /> from them.
/// </summary>
public static class StaticReflection
{
	/// <summary>
	/// Pull out a <see cref="T:System.Reflection.MethodInfo" /> object from an expression of the form
	/// () =&gt; SomeClass.SomeMethod()
	/// </summary>
	/// <param name="expression">Expression describing the method to call.</param>
	/// <returns>Corresponding <see cref="T:System.Reflection.MethodInfo" />.</returns>
	public static MethodInfo GetMethodInfo(Expression<Action> expression)
	{
		return GetMethodInfo((LambdaExpression)expression);
	}

	/// <summary>
	/// Pull out a <see cref="T:System.Reflection.MethodInfo" /> object from an expression of the form
	/// x =&gt; x.SomeMethod()
	/// </summary>
	/// <typeparam name="T">The type where the method is defined.</typeparam>
	/// <param name="expression">Expression describing the method to call.</param>
	/// <returns>Corresponding <see cref="T:System.Reflection.MethodInfo" />.</returns>
	public static MethodInfo GetMethodInfo<T>(Expression<Action<T>> expression)
	{
		return GetMethodInfo((LambdaExpression)expression);
	}

	private static MethodInfo GetMethodInfo(LambdaExpression lambda)
	{
		GuardProperExpressionForm(lambda.Body);
		MethodCallExpression methodCallExpression = (MethodCallExpression)lambda.Body;
		return methodCallExpression.Method;
	}

	/// <summary>
	/// Pull out a <see cref="T:System.Reflection.MethodInfo" /> object for the get method from an expression of the form
	/// x =&gt; x.SomeProperty
	/// </summary>
	/// <typeparam name="T">The type where the method is defined.</typeparam>
	/// <typeparam name="TProperty">The type for the property.</typeparam>
	/// <param name="expression">Expression describing the property for which the get method is to be extracted.</param>
	/// <returns>Corresponding <see cref="T:System.Reflection.MethodInfo" />.</returns>
	public static MethodInfo GetPropertyGetMethodInfo<T, TProperty>(Expression<Func<T, TProperty>> expression)
	{
		PropertyInfo propertyInfo = GetPropertyInfo<T, TProperty>(expression);
		MethodInfo getMethod = propertyInfo.GetGetMethod();
		if (getMethod == null)
		{
			throw new InvalidOperationException("Invalid expression form passed");
		}
		return getMethod;
	}

	/// <summary>
	/// Pull out a <see cref="T:System.Reflection.MethodInfo" /> object for the set method from an expression of the form
	/// x =&gt; x.SomeProperty
	/// </summary>
	/// <typeparam name="T">The type where the method is defined.</typeparam>
	/// <typeparam name="TProperty">The type for the property.</typeparam>
	/// <param name="expression">Expression describing the property for which the set method is to be extracted.</param>
	/// <returns>Corresponding <see cref="T:System.Reflection.MethodInfo" />.</returns>
	public static MethodInfo GetPropertySetMethodInfo<T, TProperty>(Expression<Func<T, TProperty>> expression)
	{
		PropertyInfo propertyInfo = GetPropertyInfo<T, TProperty>(expression);
		MethodInfo setMethod = propertyInfo.GetSetMethod();
		if (setMethod == null)
		{
			throw new InvalidOperationException("Invalid expression form passed");
		}
		return setMethod;
	}

	private static PropertyInfo GetPropertyInfo<T, TProperty>(LambdaExpression lambda)
	{
		if (!(lambda.Body is MemberExpression memberExpression))
		{
			throw new InvalidOperationException("Invalid expression form passed");
		}
		if (!(memberExpression.Member is PropertyInfo result))
		{
			throw new InvalidOperationException("Invalid expression form passed");
		}
		return result;
	}

	/// <summary>
	/// Pull out a <see cref="T:System.Reflection.ConstructorInfo" /> object from an expression of the form () =&gt; new SomeType()
	/// </summary>
	/// <typeparam name="T">The type where the constructor is defined.</typeparam>
	/// <param name="expression">Expression invoking the desired constructor.</param>
	/// <returns>Corresponding <see cref="T:System.Reflection.ConstructorInfo" />.</returns>
	public static ConstructorInfo GetConstructorInfo<T>(Expression<Func<T>> expression)
	{
		if (!(expression.Body is NewExpression newExpression))
		{
			throw new InvalidOperationException("Invalid expression form passed");
		}
		return newExpression.Constructor;
	}

	private static void GuardProperExpressionForm(Expression expression)
	{
		if (expression.NodeType != ExpressionType.Call)
		{
			throw new InvalidOperationException("Invalid expression form passed");
		}
	}
}
