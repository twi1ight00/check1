using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using AutoMapper.Internal;

namespace AutoMapper;

public class DelegateFactory : IDelegateFactory
{
	private static readonly IDictionaryFactory DictionaryFactory = PlatformAdapter.Resolve<IDictionaryFactory>();

	private static readonly AutoMapper.Internal.IDictionary<Type, LateBoundCtor> _ctorCache = DictionaryFactory.CreateDictionary<Type, LateBoundCtor>();

	public LateBoundMethod CreateGet(MethodInfo method)
	{
		ParameterExpression parameterExpression = Expression.Parameter(typeof(object), "target");
		ParameterExpression parameterExpression2 = Expression.Parameter(typeof(object[]), "arguments");
		MethodCallExpression expression = (method.IsDefined(typeof(ExtensionAttribute), inherit: false) ? Expression.Call(method, CreateParameterExpressions(method, parameterExpression, parameterExpression2)) : Expression.Call(Expression.Convert(parameterExpression, method.DeclaringType), method, CreateParameterExpressions(method, parameterExpression, parameterExpression2)));
		Expression<LateBoundMethod> expression2 = Expression.Lambda<LateBoundMethod>(Expression.Convert(expression, typeof(object)), new ParameterExpression[2] { parameterExpression, parameterExpression2 });
		return expression2.Compile();
	}

	public LateBoundPropertyGet CreateGet(PropertyInfo property)
	{
		ParameterExpression parameterExpression = Expression.Parameter(typeof(object), "target");
		MemberExpression expression = Expression.Property(Expression.Convert(parameterExpression, property.DeclaringType), property);
		Expression<LateBoundPropertyGet> expression2 = Expression.Lambda<LateBoundPropertyGet>(Expression.Convert(expression, typeof(object)), new ParameterExpression[1] { parameterExpression });
		return expression2.Compile();
	}

	public LateBoundFieldGet CreateGet(FieldInfo field)
	{
		ParameterExpression parameterExpression = Expression.Parameter(typeof(object), "target");
		MemberExpression expression = Expression.Field(Expression.Convert(parameterExpression, field.DeclaringType), field);
		Expression<LateBoundFieldGet> expression2 = Expression.Lambda<LateBoundFieldGet>(Expression.Convert(expression, typeof(object)), new ParameterExpression[1] { parameterExpression });
		return expression2.Compile();
	}

	public virtual LateBoundFieldSet CreateSet(FieldInfo field)
	{
		return delegate(object target, object value)
		{
			field.SetValue(target, value);
		};
	}

	public virtual LateBoundPropertySet CreateSet(PropertyInfo property)
	{
		return delegate(object target, object value)
		{
			property.SetValue(target, value, null);
		};
	}

	public LateBoundCtor CreateCtor(Type type)
	{
		return _ctorCache.GetOrAdd(type, delegate
		{
			Expression<LateBoundCtor> expression = Expression.Lambda<LateBoundCtor>(Expression.Convert(Expression.New(type), typeof(object)), new ParameterExpression[0]);
			return expression.Compile();
		});
	}

	private static Expression[] CreateParameterExpressions(MethodInfo method, Expression instanceParameter, Expression argumentsParameter)
	{
		List<UnaryExpression> list = new List<UnaryExpression>();
		ParameterInfo[] source = method.GetParameters();
		if (method.IsDefined(typeof(ExtensionAttribute), inherit: false))
		{
			Type parameterType = method.GetParameters()[0].ParameterType;
			list.Add(Expression.Convert(instanceParameter, parameterType));
			source = source.Skip(1).ToArray();
		}
		list.AddRange(source.Select((ParameterInfo parameter, int index) => Expression.Convert(Expression.ArrayIndex(argumentsParameter, Expression.Constant(index)), parameter.ParameterType)));
		return list.ToArray();
	}

	public LateBoundParamsCtor CreateCtor(ConstructorInfo constructorInfo, IEnumerable<ConstructorParameterMap> ctorParams)
	{
		ParameterExpression paramsExpr = Expression.Parameter(typeof(object[]), "parameters");
		UnaryExpression[] arguments = ctorParams.Select((ConstructorParameterMap ctorParam, int i) => Expression.Convert(Expression.ArrayIndex(paramsExpr, Expression.Constant(i)), ctorParam.Parameter.ParameterType)).ToArray();
		NewExpression body = Expression.New(constructorInfo, arguments);
		Expression<LateBoundParamsCtor> expression = Expression.Lambda<LateBoundParamsCtor>(body, new ParameterExpression[1] { paramsExpr });
		return expression.Compile();
	}
}
