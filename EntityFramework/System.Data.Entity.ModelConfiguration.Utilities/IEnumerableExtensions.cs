using System.Collections.Generic;

namespace System.Data.Entity.ModelConfiguration.Utilities;

internal static class IEnumerableExtensions
{
	public static void Each<T>(this IEnumerable<T> ts, Action<T, int> action)
	{
		int num = 0;
		foreach (T t in ts)
		{
			action(t, num++);
		}
	}

	public static void Each<T>(this IEnumerable<T> ts, Action<T> action)
	{
		foreach (T t in ts)
		{
			action(t);
		}
	}

	public static void Each<T, S>(this IEnumerable<T> ts, Func<T, S> action)
	{
		foreach (T t in ts)
		{
			action(t);
		}
	}
}
