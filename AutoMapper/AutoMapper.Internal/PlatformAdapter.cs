using System;

namespace AutoMapper.Internal;

public static class PlatformAdapter
{
	private static readonly string[] KnownPlatformNames = new string[6] { "Net4", "WinRT", "SL5", "WP8", "Android", "iOS" };

	private static IAdapterResolver _resolver = new ProbingAdapterResolver(KnownPlatformNames);

	public static T Resolve<T>(bool throwIfNotFound = true)
	{
		T val = (T)_resolver.Resolve(typeof(T));
		if (val == null && throwIfNotFound)
		{
			throw new PlatformNotSupportedException("This type is not supported on this platform " + typeof(T).Name);
		}
		return val;
	}

	internal static void SetResolver(IAdapterResolver resolver)
	{
		_resolver = resolver;
	}
}
