using System;
using System.Configuration;

namespace Enyim.Caching.Configuration;

public class InterfaceValidator : ConfigurationValidatorBase
{
	private Type interfaceType;

	public InterfaceValidator(Type type)
	{
		if (!type.IsInterface)
		{
			throw new ArgumentException(string.Concat(type, " must be an interface"));
		}
		interfaceType = type;
	}

	public override bool CanValidate(Type type)
	{
		if (type != typeof(Type))
		{
			return base.CanValidate(type);
		}
		return true;
	}

	public override void Validate(object value)
	{
		if (value != null)
		{
			ConfigurationHelper.CheckForInterface((Type)value, interfaceType);
		}
	}
}
