using System;

namespace AutoMapper;

public class DeferredInstantiatedFormatter : IValueFormatter
{
	private readonly Func<ResolutionContext, IValueFormatter> _instantiator;

	public DeferredInstantiatedFormatter(Func<ResolutionContext, IValueFormatter> instantiator)
	{
		_instantiator = instantiator;
	}

	public string FormatValue(ResolutionContext context)
	{
		IValueFormatter valueFormatter = _instantiator(context);
		return valueFormatter.FormatValue(context);
	}

	public Type GetFormatterType(ResolutionContext context)
	{
		IValueFormatter valueFormatter = _instantiator(context);
		return valueFormatter.GetType();
	}
}
