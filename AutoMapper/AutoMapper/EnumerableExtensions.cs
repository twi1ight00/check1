using System;
using System.Collections.Generic;

namespace AutoMapper;

public static class EnumerableExtensions
{
	public static void Each<T>(this IEnumerable<T> items, Action<T> action)
	{
		foreach (T item in items)
		{
			action(item);
		}
	}
}
