using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace System.Data.Entity.Migrations.Extensions;

[DebuggerStepThrough]
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

	public static string Join<T>(this IEnumerable<T> ts, Func<T, string> selector = null, string separator = ", ")
	{
		selector = selector ?? ((Func<T, string>)((T t) => t.ToString()));
		return string.Join(separator, ts.Select(selector));
	}
}
