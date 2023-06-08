using System;

namespace ns301;

internal static class Class6892
{
	public static void smethod_0(object @object, string paramName)
	{
		if (object.ReferenceEquals(null, @object))
		{
			throw new ArgumentNullException(paramName);
		}
	}

	public static void smethod_1(string param, string paramName)
	{
		if (string.IsNullOrEmpty(param))
		{
			throw new ArgumentNullException(paramName);
		}
	}
}
