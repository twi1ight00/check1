using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Utilities;

internal static class DynamicEqualityComparerLinqIntegration
{
	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	public static IEnumerable<T> Distinct<T>(this IEnumerable<T> source, Func<T, T, bool> func) where T : class
	{
		return source.Distinct(new DynamicEqualityComparer<T>(func));
	}

	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	public static IEnumerable<T> Intersect<T>(this IEnumerable<T> first, IEnumerable<T> second, Func<T, T, bool> func) where T : class
	{
		return first.Intersect(second, new DynamicEqualityComparer<T>(func));
	}

	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	public static IEnumerable<IGrouping<TSource, TSource>> GroupBy<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, bool> func) where TSource : class
	{
		return source.GroupBy((TSource t) => t, new DynamicEqualityComparer<TSource>(func));
	}

	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	public static bool SequenceEqual<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other, Func<TSource, TSource, bool> func) where TSource : class
	{
		return source.SequenceEqual(other, new DynamicEqualityComparer<TSource>(func));
	}
}
