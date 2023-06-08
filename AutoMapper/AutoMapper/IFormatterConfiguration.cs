using System;
using System.Collections.Generic;

namespace AutoMapper;

[Obsolete("Formatters should not be used")]
public interface IFormatterConfiguration : IProfileConfiguration
{
	[Obsolete("Formatters should not be used")]
	IValueFormatter[] GetFormatters();

	[Obsolete("Formatters should not be used")]
	IDictionary<Type, IFormatterConfiguration> GetTypeSpecificFormatters();

	[Obsolete("Formatters should not be used")]
	Type[] GetFormatterTypesToSkip();

	[Obsolete("Formatters should not be used")]
	IEnumerable<IValueFormatter> GetFormattersToApply(ResolutionContext context);
}
