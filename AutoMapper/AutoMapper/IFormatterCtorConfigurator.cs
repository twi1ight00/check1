using System;

namespace AutoMapper;

public interface IFormatterCtorConfigurator
{
	void ConstructFormatterBy(Type formatterType, Func<IValueFormatter> instantiator);
}
