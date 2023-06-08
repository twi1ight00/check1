using System;

namespace AutoMapper;

public class DeferredInstantiatedResolver : IValueResolver
{
	private readonly Func<ResolutionContext, IValueResolver> _constructor;

	public DeferredInstantiatedResolver(Func<ResolutionContext, IValueResolver> constructor)
	{
		_constructor = constructor;
	}

	public ResolutionResult Resolve(ResolutionResult source)
	{
		IValueResolver valueResolver = _constructor(source.Context);
		return valueResolver.Resolve(source);
	}
}
