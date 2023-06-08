using System;
using System.Configuration;

namespace Enyim.Caching.Configuration;

public sealed class InterfaceValidatorAttribute : ConfigurationValidatorAttribute
{
	private Type interfaceType;

	public override ConfigurationValidatorBase ValidatorInstance => new InterfaceValidator(interfaceType);

	public InterfaceValidatorAttribute(Type type)
	{
		if (!type.IsInterface)
		{
			throw new ArgumentException(string.Concat(type, " must be an interface"));
		}
		interfaceType = type;
	}
}
