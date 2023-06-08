using System;
using System.Reflection;

namespace AutoMapper;

public class DeferredInstantiatedConverter : ITypeConverter<object, object>
{
	private readonly Func<ResolutionContext, object> _instantiator;

	private readonly MethodInfo _converterMethod;

	public DeferredInstantiatedConverter(Type typeConverterType, Func<ResolutionContext, object> instantiator)
	{
		_instantiator = instantiator;
		_converterMethod = typeConverterType.GetMethod("Convert");
	}

	public object Convert(ResolutionContext context)
	{
		object obj = _instantiator(context);
		return _converterMethod.Invoke(obj, new ResolutionContext[1] { context });
	}
}
public class DeferredInstantiatedConverter<TSource, TDestination> : ITypeConverter<TSource, TDestination>
{
	private readonly Func<ResolutionContext, ITypeConverter<TSource, TDestination>> _instantiator;

	public DeferredInstantiatedConverter(Func<ResolutionContext, ITypeConverter<TSource, TDestination>> instantiator)
	{
		_instantiator = instantiator;
	}

	public TDestination Convert(ResolutionContext context)
	{
		ITypeConverter<TSource, TDestination> typeConverter = _instantiator(context);
		return typeConverter.Convert(context);
	}
}
