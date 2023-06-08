using System;

namespace Oracle.DataAccess.Client;

internal static class EntityUtils
{
	internal static T CheckArgumentNull<T>(T value, string parameterName) where T : class
	{
		if (value == null)
		{
			throw new ArgumentNullException(parameterName);
		}
		return value;
	}
}
