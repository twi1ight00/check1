using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Newtonsoft.Json.Serialization;

namespace Newtonsoft.Json.Utilities;

internal class ExpressionReflectionDelegateFactory : ReflectionDelegateFactory
{
	private class ByRefParameter
	{
		public Expression Value;

		public ParameterExpression Variable;

		public bool IsOut;
	}

	private static readonly ExpressionReflectionDelegateFactory _instance = new ExpressionReflectionDelegateFactory();

	internal static ReflectionDelegateFactory Instance => _instance;

	public override ObjectConstructor<object> CreateParameterizedConstructor(MethodBase method)
	{
		ValidationUtils.ArgumentNotNull(method, "method");
		Type typeFromHandle = typeof(object);
		ParameterExpression parameterExpression = Expression.Parameter(typeof(object[]), "args");
		Expression body = BuildMethodCall(method, typeFromHandle, null, parameterExpression);
		return (ObjectConstructor<object>)Expression.Lambda(typeof(ObjectConstructor<object>), body, parameterExpression).Compile();
	}

	public override MethodCall<T, object> CreateMethodCall<T>(MethodBase method)
	{
		ValidationUtils.ArgumentNotNull(method, "method");
		Type typeFromHandle = typeof(object);
		ParameterExpression parameterExpression = Expression.Parameter(typeFromHandle, "target");
		ParameterExpression parameterExpression2 = Expression.Parameter(typeof(object[]), "args");
		Expression body = BuildMethodCall(method, typeFromHandle, parameterExpression, parameterExpression2);
		return (MethodCall<T, object>)Expression.Lambda(typeof(MethodCall<T, object>), body, parameterExpression, parameterExpression2).Compile();
	}

	private Expression BuildMethodCall(MethodBase method, Type type, ParameterExpression targetParameterExpression, ParameterExpression argsParameterExpression)
	{
		ParameterInfo[] parameters = method.GetParameters();
		Expression[] array = new Expression[parameters.Length];
		IList<ByRefParameter> list = new List<ByRefParameter>();
		for (int i = 0; i < parameters.Length; i++)
		{
			ParameterInfo parameterInfo = parameters[i];
			Type type2 = parameterInfo.ParameterType;
			bool flag = false;
			if (type2.IsByRef)
			{
				type2 = type2.GetElementType();
				flag = true;
			}
			Expression index = Expression.Constant(i);
			Expression expression = Expression.ArrayIndex(argsParameterExpression, index);
			Expression expression3;
			if (type2.IsValueType())
			{
				BinaryExpression expression2 = Expression.Coalesce(expression, Expression.New(type2));
				expression3 = EnsureCastExpression(expression2, type2);
			}
			else
			{
				expression3 = EnsureCastExpression(expression, type2);
			}
			if (flag)
			{
				ParameterExpression parameterExpression = Expression.Variable(type2);
				list.Add(new ByRefParameter
				{
					Value = expression3,
					Variable = parameterExpression,
					IsOut = parameterInfo.IsOut
				});
				expression3 = parameterExpression;
			}
			array[i] = expression3;
		}
		Expression expression4 = (method.IsConstructor ? ((Expression)Expression.New((ConstructorInfo)method, array)) : ((Expression)((!method.IsStatic) ? Expression.Call(EnsureCastExpression(targetParameterExpression, method.DeclaringType), (MethodInfo)method, array) : Expression.Call((MethodInfo)method, array))));
		expression4 = ((!(method is MethodInfo)) ? EnsureCastExpression(expression4, type) : ((!(((MethodInfo)method).ReturnType != typeof(void))) ? Expression.Block(expression4, Expression.Constant(null)) : EnsureCastExpression(expression4, type)));
		if (list.Count > 0)
		{
			IList<ParameterExpression> list2 = new List<ParameterExpression>();
			IList<Expression> list3 = new List<Expression>();
			foreach (ByRefParameter item in list)
			{
				if (!item.IsOut)
				{
					list3.Add(Expression.Assign(item.Variable, item.Value));
				}
				list2.Add(item.Variable);
			}
			list3.Add(expression4);
			expression4 = Expression.Block(list2, list3);
		}
		return expression4;
	}

	public override Func<T> CreateDefaultConstructor<T>(Type type)
	{
		ValidationUtils.ArgumentNotNull(type, "type");
		if (type.IsAbstract())
		{
			return () => (T)Activator.CreateInstance(type);
		}
		try
		{
			Type typeFromHandle = typeof(T);
			Expression expression = Expression.New(type);
			expression = EnsureCastExpression(expression, typeFromHandle);
			return (Func<T>)Expression.Lambda(typeof(Func<T>), expression).Compile();
		}
		catch
		{
			return () => (T)Activator.CreateInstance(type);
		}
	}

	public override Func<T, object> CreateGet<T>(PropertyInfo propertyInfo)
	{
		ValidationUtils.ArgumentNotNull(propertyInfo, "propertyInfo");
		Type typeFromHandle = typeof(T);
		Type typeFromHandle2 = typeof(object);
		ParameterExpression parameterExpression = Expression.Parameter(typeFromHandle, "instance");
		Expression expression = ((!propertyInfo.GetGetMethod(nonPublic: true).IsStatic) ? Expression.MakeMemberAccess(EnsureCastExpression(parameterExpression, propertyInfo.DeclaringType), propertyInfo) : Expression.MakeMemberAccess(null, propertyInfo));
		expression = EnsureCastExpression(expression, typeFromHandle2);
		return (Func<T, object>)Expression.Lambda(typeof(Func<T, object>), expression, parameterExpression).Compile();
	}

	public override Func<T, object> CreateGet<T>(FieldInfo fieldInfo)
	{
		ValidationUtils.ArgumentNotNull(fieldInfo, "fieldInfo");
		ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "source");
		Expression expression = ((!fieldInfo.IsStatic) ? Expression.Field(EnsureCastExpression(parameterExpression, fieldInfo.DeclaringType), fieldInfo) : Expression.Field(null, fieldInfo));
		expression = EnsureCastExpression(expression, typeof(object));
		return Expression.Lambda<Func<T, object>>(expression, new ParameterExpression[1] { parameterExpression }).Compile();
	}

	public override Action<T, object> CreateSet<T>(FieldInfo fieldInfo)
	{
		ValidationUtils.ArgumentNotNull(fieldInfo, "fieldInfo");
		if (fieldInfo.DeclaringType.IsValueType() || fieldInfo.IsInitOnly)
		{
			return LateBoundReflectionDelegateFactory.Instance.CreateSet<T>(fieldInfo);
		}
		ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "source");
		ParameterExpression parameterExpression2 = Expression.Parameter(typeof(object), "value");
		Expression expression = ((!fieldInfo.IsStatic) ? Expression.Field(EnsureCastExpression(parameterExpression, fieldInfo.DeclaringType), fieldInfo) : Expression.Field(null, fieldInfo));
		Expression right = EnsureCastExpression(parameterExpression2, expression.Type);
		BinaryExpression body = Expression.Assign(expression, right);
		return (Action<T, object>)Expression.Lambda(typeof(Action<T, object>), body, parameterExpression, parameterExpression2).Compile();
	}

	public override Action<T, object> CreateSet<T>(PropertyInfo propertyInfo)
	{
		ValidationUtils.ArgumentNotNull(propertyInfo, "propertyInfo");
		if (propertyInfo.DeclaringType.IsValueType())
		{
			return LateBoundReflectionDelegateFactory.Instance.CreateSet<T>(propertyInfo);
		}
		Type typeFromHandle = typeof(T);
		Type typeFromHandle2 = typeof(object);
		ParameterExpression parameterExpression = Expression.Parameter(typeFromHandle, "instance");
		ParameterExpression parameterExpression2 = Expression.Parameter(typeFromHandle2, "value");
		Expression expression = EnsureCastExpression(parameterExpression2, propertyInfo.PropertyType);
		MethodInfo setMethod = propertyInfo.GetSetMethod(nonPublic: true);
		return (Action<T, object>)Expression.Lambda(body: (!setMethod.IsStatic) ? Expression.Call(EnsureCastExpression(parameterExpression, propertyInfo.DeclaringType), setMethod, expression) : Expression.Call(setMethod, expression), delegateType: typeof(Action<T, object>), parameters: new ParameterExpression[2] { parameterExpression, parameterExpression2 }).Compile();
	}

	private Expression EnsureCastExpression(Expression expression, Type targetType)
	{
		Type type = expression.Type;
		if (type == targetType || (!type.IsValueType() && targetType.IsAssignableFrom(type)))
		{
			return expression;
		}
		return Expression.Convert(expression, targetType);
	}
}
