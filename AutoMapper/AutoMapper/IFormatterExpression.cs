using System;

namespace AutoMapper;

[Obsolete("Formatters should not be used.")]
public interface IFormatterExpression
{
	[Obsolete("Formatters should not be used.")]
	IFormatterCtorExpression<TValueFormatter> AddFormatter<TValueFormatter>() where TValueFormatter : IValueFormatter;

	[Obsolete("Formatters should not be used.")]
	IFormatterCtorExpression AddFormatter(Type valueFormatterType);

	[Obsolete("Formatters should not be used.")]
	void AddFormatter(IValueFormatter formatter);

	[Obsolete("Formatters should not be used.")]
	void AddFormatExpression(Func<ResolutionContext, string> formatExpression);

	[Obsolete("Formatters should not be used.")]
	void SkipFormatter<TValueFormatter>() where TValueFormatter : IValueFormatter;

	[Obsolete("Formatters should not be used.")]
	IFormatterExpression ForSourceType<TSource>();
}
