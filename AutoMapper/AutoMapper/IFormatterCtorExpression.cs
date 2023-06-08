using System;

namespace AutoMapper;

[Obsolete("Formatters should not be used.")]
public interface IFormatterCtorExpression
{
	void ConstructedBy(Func<IValueFormatter> constructor);
}
[Obsolete("Formatters should not be used.")]
public interface IFormatterCtorExpression<TValueFormatter> where TValueFormatter : IValueFormatter
{
	void ConstructedBy(Func<TValueFormatter> constructor);
}
