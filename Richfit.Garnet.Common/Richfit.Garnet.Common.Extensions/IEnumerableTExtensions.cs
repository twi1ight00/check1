using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Richfit.Garnet.Common.Data;
using Richfit.Garnet.Common.Properties;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// IEnumerable泛型接口扩展方法类
/// </summary>
public static class IEnumerableTExtensions
{
	/// <summary>
	/// 检测当前序列中的所有元素是否都满足条件
	/// </summary>
	/// <typeparam name="T">当前序列元素的类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">检测规则</param>
	/// <returns>如果所有元素都满足指定条件返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测条件 <paramref name="predicate" /> 为空。</exception>
	public static bool All<T>(this IEnumerable<T> source, Func<T, int, bool> predicate)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		int index = 0;
		foreach (T o in source)
		{
			if (!predicate(o, index++))
			{
				return false;
			}
		}
		return true;
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否都不满足条件
	/// </summary>
	/// <typeparam name="T">当前序列元素的类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">检测规则</param>
	/// <returns>如果所有元素都不满足指定条件返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测条件 <paramref name="predicate" /> 为空。</exception>
	public static bool AllNot<T>(this IEnumerable<T> source, Func<T, bool> predicate)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		foreach (T o in source)
		{
			if (predicate(o))
			{
				return false;
			}
		}
		return true;
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否都不满足条件
	/// </summary>
	/// <typeparam name="T">当前序列元素的类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">检测规则</param>
	/// <returns>如果所有元素都不满足指定条件返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测条件 <paramref name="predicate" /> 为空。</exception>
	public static bool AllNot<T>(this IEnumerable<T> source, Func<T, int, bool> predicate)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		int index = 0;
		foreach (T o in source)
		{
			if (predicate(o, index++))
			{
				return false;
			}
		}
		return true;
	}

	/// <summary>
	/// 检测当前序列中是否有任意一个元素满足指定条件
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">检测条件</param>
	/// <returns>如果有任意一个元素满足指定条件则返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测条件 <paramref name="predicate" /> 为空。</exception>
	public static bool Any<T>(this IEnumerable<T> source, Func<T, int, bool> predicate)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		int index = 0;
		foreach (T o in source)
		{
			if (predicate(o, index++))
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 检测当前序列中是否有任意一个元素不满足指定条件
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">检测条件</param>
	/// <returns>如果有任意一个元素不满足指定条件则返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测条件 <paramref name="predicate" /> 为空。</exception>
	public static bool AnyNot<T>(this IEnumerable<T> source, Func<T, bool> predicate)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		foreach (T o in source)
		{
			if (!predicate(o))
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 检测当前序列中是否有任意一个元素不满足指定条件
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">待检测的当前序列</param>
	/// <param name="predicate">检测条件</param>
	/// <returns>如果有任意一个元素不满足指定条件则返回true，否则返回false</returns>
	public static bool AnyNot<T>(this IEnumerable<T> source, Func<T, int, bool> predicate)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		int index = 0;
		foreach (T o in source)
		{
			if (!predicate(o, index++))
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 向当前序列尾部添加元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="item">向序列尾部添加的元素</param>
	/// <returns>追加了新的元素的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<T> Append<T>(this IEnumerable<T> source, T item)
	{
		source.GuardNotNull("source");
		foreach (T item2 in source)
		{
			yield return item2;
		}
		yield return item;
	}

	/// <summary>
	/// 向当前序列尾部添加元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="items">向序列尾部添加的元素列表</param>
	/// <returns>追加了新的元素的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<T> Append<T>(this IEnumerable<T> source, params T[] items)
	{
		return source.Append((IEnumerable<T>)items);
	}

	/// <summary>
	/// 向当前序列尾部添加元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="items">向序列尾部添加的元素序列</param>
	/// <returns>追加了新的元素的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<T> Append<T>(this IEnumerable<T> source, IEnumerable<T> items)
	{
		source.GuardNotNull("source");
		foreach (T item in source)
		{
			yield return item;
		}
		if (!items.IsNotNull())
		{
			yield break;
		}
		foreach (T item2 in items)
		{
			yield return item2;
		}
	}

	/// <summary>
	/// 比较当前序列与指定序列是否相等，如果两个序列元素数量相同且每个序列元素都相等则为true
	/// </summary>
	/// <typeparam name="T">当前序列的元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="target">比较的目标序列</param>
	/// <param name="equalition">元素相等比较方法</param>
	/// <returns>两个源序列的长度相等，且其相应元素相等，则为 true；否则为 false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列为空。</exception>
	public static bool AreEqualTo<T>(this IEnumerable<T> source, IEnumerable<T> target, Func<T, T, bool> equalition = null)
	{
		source.GuardNotNull("source");
		target.GuardNotNull("target");
		equalition = equalition.IfNull(EqualityComparer<T>.Default.Equals);
		ICollection<T> s = source as ICollection<T>;
		ICollection<T> t = source as ICollection<T>;
		if (s.IsNotNull() && t.IsNotNull() && s.Count != t.Count)
		{
			return false;
		}
		IEnumerator<T> es = source.GetEnumerator();
		IEnumerator<T> et = target.GetEnumerator();
		try
		{
			bool fs = es.MoveNext();
			bool ft = et.MoveNext();
			while (fs && ft)
			{
				if (!equalition(es.Current, et.Current))
				{
					return false;
				}
				fs = es.MoveNext();
				ft = et.MoveNext();
			}
			return !fs && !ft;
		}
		finally
		{
			es.Dispose();
			et.Dispose();
		}
	}

	/// <summary>
	/// 比较当前序列是否大于目标序列，当前序列的每个元素都大于目标序列相应的元素则返回true，或者当前序列元素个数大于目标序列的元素个数返回true。
	/// </summary>
	/// <typeparam name="T">当前序列的元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="target">比较的目标序列</param>
	/// <param name="comparison">元素大小比较方法</param>
	/// <returns>如果当前序列的每个元素都大于目标序列相应的元素则返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列为空。</exception>
	public static bool AreGreaterThan<T>(this IEnumerable<T> source, IEnumerable<T> target, Func<T, T, int> comparison = null)
	{
		source.GuardNotNull("source");
		target.GuardNotNull("target");
		comparison = comparison.IfNull(Comparer<T>.Default.Compare);
		IEnumerator<T> es = source.GetEnumerator();
		IEnumerator<T> et = target.GetEnumerator();
		try
		{
			bool fs = es.MoveNext();
			bool ft = et.MoveNext();
			while (fs && ft)
			{
				if (comparison(es.Current, et.Current) <= 0)
				{
					return false;
				}
				fs = es.MoveNext();
				ft = et.MoveNext();
			}
			return fs;
		}
		finally
		{
			es.Dispose();
			et.Dispose();
		}
	}

	/// <summary>
	/// 比较当前序列是否大于或者等于目标序列，当前序列的每个元素都大于或等于目标序列相应的元素则返回true，或者当前序列元素个数大于等于目标序列的元素个数返回true。
	/// </summary>
	/// <typeparam name="T">当前序列的元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="target">比较的目标序列</param>
	/// <param name="comparison">元素大小比较方法</param>
	/// <returns>如果当前序列的每个元素都大于或等于目标序列相应的元素则返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列为空。</exception>
	public static bool AreGreaterThanOrEqualTo<T>(this IEnumerable<T> source, IEnumerable<T> target, Func<T, T, int> comparison = null)
	{
		source.GuardNotNull("source");
		target.GuardNotNull("target");
		comparison = comparison.IfNull(Comparer<T>.Default.Compare);
		IEnumerator<T> es = source.GetEnumerator();
		IEnumerator<T> et = target.GetEnumerator();
		try
		{
			bool fs = es.MoveNext();
			bool ft = et.MoveNext();
			while (fs && ft)
			{
				if (comparison(es.Current, et.Current) < 0)
				{
					return false;
				}
				fs = es.MoveNext();
				ft = et.MoveNext();
			}
			return (!fs && !ft) || fs;
		}
		finally
		{
			es.Dispose();
			et.Dispose();
		}
	}

	/// <summary>
	/// 比较当前序列是否小于目标序列，当前序列的每个元素都小于目标序列相应的元素则返回true，或者当前序列元素个数小于目标序列的元素个数返回true。
	/// </summary>
	/// <typeparam name="T">当前序列的元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="target">比较的目标序列</param>
	/// <param name="comparison">元素大小比较方法</param>
	/// <returns>如果当前序列的每个元素都小于目标序列相应的元素则返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列为空。</exception>
	public static bool AreLessThan<T>(this IEnumerable<T> source, IEnumerable<T> target, Func<T, T, int> comparison = null)
	{
		source.GuardNotNull("source");
		target.GuardNotNull("target");
		comparison = comparison.IfNull(Comparer<T>.Default.Compare);
		IEnumerator<T> es = source.GetEnumerator();
		IEnumerator<T> et = target.GetEnumerator();
		try
		{
			bool fs = es.MoveNext();
			bool ft = et.MoveNext();
			while (fs && ft)
			{
				if (comparison(es.Current, et.Current) >= 0)
				{
					return false;
				}
				fs = es.MoveNext();
				ft = et.MoveNext();
			}
			return ft;
		}
		finally
		{
			es.Dispose();
			et.Dispose();
		}
	}

	/// <summary>
	/// 比较当前序列是否小于或者等于目标序列，当前序列的每个元素都小于或者等于目标序列相应的元素则返回true
	/// </summary>
	/// <typeparam name="T">当前序列的元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="target">比较的目标序列</param>
	/// <param name="comparison">元素大小比较方法</param>
	/// <returns>如果当前序列的每个元素都小于或者等于目标序列相应的元素则返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列为空。</exception>
	public static bool AreLessThanOrEqualTo<T>(this IEnumerable<T> source, IEnumerable<T> target, Func<T, T, int> comparison = null)
	{
		source.GuardNotNull("source");
		target.GuardNotNull("target");
		comparison = comparison.IfNull(Comparer<T>.Default.Compare);
		IEnumerator<T> es = source.GetEnumerator();
		IEnumerator<T> et = target.GetEnumerator();
		try
		{
			bool fs = es.MoveNext();
			bool ft = et.MoveNext();
			while (fs && ft)
			{
				if (comparison(es.Current, et.Current) > 0)
				{
					return false;
				}
				fs = es.MoveNext();
				ft = et.MoveNext();
			}
			return (!fs && !ft) || ft;
		}
		finally
		{
			es.Dispose();
			et.Dispose();
		}
	}

	/// <summary>
	/// 将当前序列的元素类型转换为另一种类型
	/// </summary>
	/// <typeparam name="S">当前序列的元素类型</typeparam>
	/// <typeparam name="T">目标序列的元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="conversion">序列元素转换方法</param>
	/// <returns>转换后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者转换方法 <paramref name="conversion" /> 为空。</exception>
	public static IEnumerable<T> Cast<S, T>(this IEnumerable<S> source, Func<S, T> conversion)
	{
		source.GuardNotNull("source");
		conversion.GuardNotNull("conversion");
		return source.Select(conversion);
	}

	/// <summary>
	/// 将当前序列的元素类型转换为另一种类型
	/// </summary>
	/// <typeparam name="S">当前序列的元素类型</typeparam>
	/// <typeparam name="T">目标序列的元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="conversion">序列元素转换方法</param>
	/// <returns>转换后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者转换方法 <paramref name="conversion" /> 为空。</exception>
	public static IEnumerable<T> Cast<S, T>(this IEnumerable<S> source, Func<S, int, T> conversion)
	{
		source.GuardNotNull("source");
		conversion.GuardNotNull("conversion");
		return source.Select(conversion);
	}

	/// <summary>
	/// 将当前序列与多个目标序列进行连接，返回连接后的新序列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="targets">连接的目标序列列表</param>
	/// <returns>连接后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者连接的目标序列列表 <paramref name="targets" /> 为空。</exception>
	public static IEnumerable<T> Concat<T>(this IEnumerable<T> source, params IEnumerable<T>[] targets)
	{
		return source.Concat((IEnumerable<IEnumerable<T>>)targets);
	}

	/// <summary>
	/// 将当前序列与多个目标序列进行连接，返回连接后的新序列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="targets">连接的目标序列列表</param>
	/// <returns>连接后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者连接的目标序列列表 <paramref name="targets" /> 为空。</exception>
	public static IEnumerable<T> Concat<T>(this IEnumerable<T> source, IEnumerable<IEnumerable<T>> targets)
	{
		source.GuardNotNull("source");
		targets.GuardNotNull("targets");
		foreach (IEnumerable<T> target in targets)
		{
			if (target.IsNotNull())
			{
				source = source.Concat(target);
			}
		}
		return source;
	}

	/// <summary>
	/// 检测当前序列中是否包含指定的元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="value">待检测的元素</param>
	/// <param name="equalition">相等比较方法</param>
	/// <returns>如果当前序列中包含指定的元素返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static bool Contains<T>(this IEnumerable<T> source, T value, Func<T, T, bool> equalition)
	{
		source.GuardNotNull("source");
		equalition = equalition.IfNull(EqualityComparer<T>.Default.Equals);
		return source.Any((T item) => equalition(item, value));
	}

	/// <summary>
	/// 检测当前的序列是否包含指定的全部元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="items">待检测的元素数组</param>
	/// <returns>如果当前序列中包含指定的全部元素返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者待检测的元素数组 <paramref name="items" /> 为空。</exception>
	public static bool ContainsAll<T>(this IEnumerable<T> source, params T[] items)
	{
		return source.ContainsAll(items, null);
	}

	/// <summary>
	/// 检测当前的序列是否包含指定的全部元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="items">待检测的元素序列</param>
	/// <param name="equalition">序列元素相等比较方法</param>
	/// <returns>如果当前序列中包含指定的全部元素返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者待检测的元素序列 <paramref name="items" /> 为空。</exception>
	public static bool ContainsAll<T>(this IEnumerable<T> source, IEnumerable<T> items, Func<T, T, bool> equalition = null)
	{
		source.GuardNotNull("source");
		items.GuardNotNull("items");
		equalition = equalition.IfNull(EqualityComparer<T>.Default.Equals);
		foreach (T item in items)
		{
			Func<T, bool> predicate = (T x) => equalition(x, item);
			if (!source.Any(predicate))
			{
				return false;
			}
		}
		return true;
	}

	/// <summary>
	/// 检测当前的序列中是否包含指定的元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="items">待检测的元素数组</param>
	/// <returns>如果当前序列中包含指定的元素中的任意一个返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者待检测的元素数组 <paramref name="items" /> 为空。</exception>
	public static bool ContainsAny<T>(this IEnumerable<T> source, params T[] items)
	{
		return source.ContainsAny(items, null);
	}

	/// <summary>
	/// 检测当前的序列中是否包含指定的元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="items">待检测的元素序列</param>
	/// <param name="equalition">序列元素相等比较方法</param>
	/// <returns>如果当前序列中包含指定的元素中的任意一个返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者待检测的元素序列 <paramref name="items" /> 为空。</exception>
	public static bool ContainsAny<T>(this IEnumerable<T> source, IEnumerable<T> items, Func<T, T, bool> equalition = null)
	{
		source.GuardNotNull("source");
		items.GuardNotNull("item");
		equalition = equalition.IfNull(EqualityComparer<T>.Default.Equals);
		foreach (T item in items)
		{
			Func<T, bool> predicate = (T x) => equalition(x, item);
			if (source.Any(predicate))
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 使用指定的比较方法检测当前序列中是否包含指定的元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="V">待比较的元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="value">待比较的元素</param>
	/// <param name="equalition">相等比较方法</param>
	/// <returns>如果当前序列中包含指定的元素返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素比较方法 <paramref name="equalition" /> 为空。</exception>
	public static bool ContainsValue<T, V>(this IEnumerable<T> source, V value, Func<T, V, bool> equalition)
	{
		source.GuardNotNull("source");
		equalition.GuardNotNull("equalition");
		return source.Any((T x) => equalition(x, value));
	}

	/// <summary>
	/// 检测当前的序列中是否包含所有指定的元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="V">待比较的元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="values">待比较的元素序列</param>
	/// <param name="equalition">相等比较方法</param>
	/// <returns>如果当前序列包含全部元素返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者比较的元素序列 <paramref name="values" /> 为空；或者元素比较方法 <paramref name="equalition" /> 为空。</exception>
	public static bool ContainsAllValue<T, V>(this IEnumerable<T> source, IEnumerable<V> values, Func<T, V, bool> equalition)
	{
		source.GuardNotNull("source");
		values.GuardNotNull("values");
		equalition.GuardNotNull("equalition");
		foreach (V value in values)
		{
			Func<T, bool> predicate = (T x) => equalition(x, value);
			if (!source.Any(predicate))
			{
				return false;
			}
		}
		return true;
	}

	/// <summary>
	/// 检测当前的序列中是否包含所有指定的元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="V">待比较的元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="values">待比较的元素列表</param>
	/// <param name="equalition">相等比较方法</param>
	/// <returns>如果当前序列包含全部元素返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者比较的元素序列 <paramref name="values" /> 为空；或者元素比较方法 <paramref name="equalition" /> 为空。</exception>
	public static bool ContainsAnyValue<T, V>(this IEnumerable<T> source, IEnumerable<V> values, Func<T, V, bool> equalition)
	{
		source.GuardNotNull("source");
		values.GuardNotNull("values");
		equalition.GuardNotNull("equalition");
		foreach (V value in values)
		{
			Func<T, bool> predicate = (T x) => equalition(x, value);
			if (source.Any(predicate))
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 将当前序列中的元素复制到目标数组中
	/// </summary>
	/// <typeparam name="T">序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="array">目标数组</param>
	/// <param name="copying">元素复制方法；如果为空，则仅复制元素的引用</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标数组 <paramref name="array" /> 为空。</exception>
	public static void CopyTo<T>(this IEnumerable<T> source, T[] array, Func<T, T> copying = null)
	{
		source.CopyTo<T>(array, 0, copying);
	}

	/// <summary>
	/// 将当前序列中的元素复制到目标数组中
	/// </summary>
	/// <typeparam name="T">序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="array">目标数组</param>
	/// <param name="start">目标数组开始复制的位置</param>
	/// <param name="copying">元素复制方法；如果为空，则仅复制元素的引用</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标数组 <paramref name="array" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">目标数组起始复制位置 <paramref name="start" /> 小于0，或者大于目标数组的最大索引。</exception>
	public static void CopyTo<T>(this IEnumerable<T> source, T[] array, int start, Func<T, T> copying = null)
	{
		source.GuardNotNull("source");
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "array start");
		copying = copying.IfNull((T x) => x);
		foreach (T o in source)
		{
			if (start >= array.Length)
			{
				break;
			}
			array[start++] = copying(o);
		}
	}

	/// <summary>
	/// 将当前序列中的元素复制到目标数组中
	/// </summary>
	/// <typeparam name="T">序列元素类型</typeparam>
	/// <typeparam name="V">目标数组元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="array">目标数组</param>
	/// <param name="copying">复制元素方法；如果为空，则进行默认转换</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标数组 <paramref name="array" /> 为空。</exception>
	public static void CopyTo<T, V>(this IEnumerable<T> source, V[] array, Func<T, V> copying = null)
	{
		source.CopyTo(array, 0, copying);
	}

	/// <summary>
	/// 将当前序列中的元素复制到目标数组中
	/// </summary>
	/// <typeparam name="T">序列元素类型</typeparam>
	/// <typeparam name="V">目标数组元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="array">目标数组</param>
	/// <param name="start">目标数组开始复制的位置</param>
	/// <param name="copying">复制元素方法；如果为空，则进行默认转换</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标数组 <paramref name="array" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">目标数组起始复制位置 <paramref name="start" /> 小于0，或者大于目标数组的最大索引。</exception>
	public static void CopyTo<T, V>(this IEnumerable<T> source, V[] array, int start, Func<T, V> copying = null)
	{
		source.GuardNotNull("source");
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "array start");
		copying = copying.IfNull((T x) => x.As<V>());
		foreach (T o in source)
		{
			if (start >= array.Length)
			{
				break;
			}
			array[start++] = copying(o);
		}
	}

	/// <summary>
	/// 将当前序列中的元素复制到目标数组中
	/// </summary>
	/// <typeparam name="T">序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="list">目标列表</param>
	/// <param name="copying">元素复制方法；如果为空，则仅复制元素的引用</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标列表 <paramref name="list" /> 为空。</exception>
	public static void CopyTo<T>(this IEnumerable<T> source, IList<T> list, Func<T, T> copying = null)
	{
		source.CopyTo<T>(list, 0, copying);
	}

	/// <summary>
	/// 将当前序列中的元素复制到目标数组中
	/// </summary>
	/// <typeparam name="T">序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="list">目标列表</param>
	/// <param name="listStart">目标列表开始复制的位置</param>
	/// <param name="copying">元素复制方法；如果为空，则仅复制元素的引用</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标列表 <paramref name="list" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">目标列表起始复制位置 <paramref name="listStart" /> 小于0，或者大于目标列表的最大索引。</exception>
	public static void CopyTo<T>(this IEnumerable<T> source, IList<T> list, int listStart, Func<T, T> copying = null)
	{
		source.GuardNotNull("source");
		list.GuardNotNull("list");
		listStart.GuardIndexRange(0, list.Count - 1, "list start");
		copying = copying.IfNull((T x) => x);
		foreach (T o in source)
		{
			if (listStart >= list.Count)
			{
				break;
			}
			list[listStart++] = copying(o);
		}
	}

	/// <summary>
	/// 将当前序列中的元素复制到目标数组中
	/// </summary>
	/// <typeparam name="T">序列元素类型</typeparam>
	/// <typeparam name="V">目标数组元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="list">目标列表</param>
	/// <param name="copying">复制元素方法；如果为空，则进行默认转换</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标列表 <paramref name="list" /> 为空。</exception>
	public static void CopyTo<T, V>(this IEnumerable<T> source, IList<V> list, Func<T, V> copying = null)
	{
		source.CopyTo(list, 0, copying);
	}

	/// <summary>
	/// 将当前序列中的元素复制到目标数组中
	/// </summary>
	/// <typeparam name="T">序列元素类型</typeparam>
	/// <typeparam name="V">目标数组元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="list">目标列表</param>
	/// <param name="listStart">目标列表开始复制的位置</param>
	/// <param name="copying">复制元素方法；如果为空，则进行默认转换</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标列表 <paramref name="list" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">目标列表起始复制位置 <paramref name="listStart" /> 小于0，或者大于目标列表的最大索引。</exception>
	public static void CopyTo<T, V>(this IEnumerable<T> source, IList<V> list, int listStart, Func<T, V> copying = null)
	{
		source.GuardNotNull("source");
		list.GuardNotNull("list");
		listStart.GuardIndexRange(0, list.Count - 1, "list start");
		copying = copying.IfNull((T x) => x.As<V>());
		foreach (T o in source)
		{
			if (listStart >= list.Count)
			{
				break;
			}
			list[listStart++] = copying(o);
		}
	}

	/// <summary>
	/// 返回当前非泛型序列中元素的个数
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>序列中元素的个数</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者序列元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static int Count<T>(this IEnumerable<T> source, Func<object, int, bool> predicate)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		int index = 0;
		return source.OfType<T>().Count((T x) => predicate(x, index++));
	}

	/// <summary>
	/// 返回当前序列中非重复的元素组成的序列
	/// </summary>
	/// <typeparam name="T">序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="equalition">元素相等比较方法</param>
	/// <returns>筛选后的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<T> Distinct<T>(this IEnumerable<T> source, Func<T, T, bool> equalition)
	{
		source.GuardNotNull("source");
		return source.Distinct(equalition.ToComparer());
	}

	/// <summary>
	/// 获取当前序列中指定位置的元素，如果指定位置的值不存在则返回指定的元素默认值  <paramref name="defaultValue" />。
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="index">获取的元素索引</param>
	/// <param name="defaultValue">元素默认值</param>
	/// <returns>当前序列指定位置的元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">获取的元素索引 <paramref name="index" /> 小于0。</exception>
	public static T ElementAtOrDefault<T>(this IEnumerable<T> source, int index, T defaultValue)
	{
		source.GuardNotNull("source");
		index.GuardIndexLowBound(0, "index");
		int current = 0;
		foreach (T item in source)
		{
			if (current++ == index)
			{
				return item;
			}
		}
		return defaultValue;
	}

	/// <summary>
	/// 对当前序列进行计算
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="V">计算结果类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="initValue">计算初始值</param>
	/// <param name="evaluator">计算方法</param>
	/// <returns>计算结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者计算方法 <paramref name="evaluator" /> 为空。</exception>
	public static V Evaluate<T, V>(this IEnumerable<T> source, V initValue, Func<object, V, V> evaluator)
	{
		return source.Evaluate(initValue, (T x, int i, V v) => evaluator(x, v));
	}

	/// <summary>
	/// 对当前序列进行计算
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="V">计算结果类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="initValue">计算初始值</param>
	/// <param name="evaluator">计算方法</param>
	/// <returns>计算结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者计算方法 <paramref name="evaluator" /> 为空。</exception>
	public static V Evaluate<T, V>(this IEnumerable<T> source, V initValue, Func<T, int, V, V> evaluator)
	{
		source.GuardNotNull("source");
		evaluator.GuardNotNull("evaluator");
		int index = 0;
		foreach (T o in source)
		{
			initValue = evaluator(o, index++, initValue);
		}
		return initValue;
	}

	/// <summary>
	/// 从当前序列中排除与给定值匹配的元素
	/// </summary>
	/// <typeparam name="T">当前序列的元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="items">排除的元素值序列</param>
	/// <returns>处理后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<T> Except<T>(this IEnumerable<T> source, params T[] items)
	{
		return source.Except(items, null);
	}

	/// <summary>
	/// 从当前序列中排除与给定值匹配的元素
	/// </summary>
	/// <typeparam name="T">当前序列的元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="items">排除的元素值序列</param>
	/// <param name="equalition">元素相等比较方法</param>
	/// <returns>处理后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<T> Except<T>(this IEnumerable<T> source, IEnumerable<T> items, Func<T, T, bool> equalition = null)
	{
		source.GuardNotNull("source");
		items.GuardNotNull("items");
		foreach (T o in source)
		{
			if (items.IsNull() || !items.Contains(o, equalition))
			{
				yield return o;
			}
		}
	}

	/// <summary>
	/// 检测当前序列中是否存在满足检测条件的元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">检测条件</param>
	/// <returns>如果存在符合条件的元素返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测条件 <paramref name="predicate" /> 为空。</exception>
	public static bool Exists<T>(this IEnumerable<T> source, Func<T, bool> predicate)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("preidcate");
		return source.Any((T item) => predicate(item));
	}

	/// <summary>
	/// 检测当前序列中是否存在满足检测条件的元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待检测的序列</param>
	/// <param name="predicate">检测条件</param>
	/// <returns>如果存在符合条件的元素返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测条件 <paramref name="predicate" /> 为空。</exception>
	public static bool Exists<T>(this IEnumerable<T> source, Func<T, int, bool> predicate)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("preidcate");
		return source.Any((T item, int i) => predicate(item, i));
	}

	/// <summary>
	/// 在当前序列中查找与指定条件匹配的元素，如果未找到匹配的元素则抛出异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>找到的匹配元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">未找到匹配的元素。</exception>
	public static T Find<T>(this IEnumerable<T> source, Func<T, bool> predicate)
	{
		predicate.GuardNotNull("predicate");
		return source.Find((T x, int i) => predicate(x));
	}

	/// <summary>
	/// 在当前序列中查找与指定条件匹配的元素，如果未找到匹配的元素则抛出异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <param name="defaultValue">如果无法找到匹配的元素，则返回该默认值</param>
	/// <returns>找到的匹配元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static T Find<T>(this IEnumerable<T> source, Func<T, bool> predicate, T defaultValue)
	{
		predicate.GuardNotNull("predicate");
		return source.Find((T x, int i) => predicate(x), defaultValue);
	}

	/// <summary>
	/// 在当前序列中查找与指定条件匹配的元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>找到的匹配元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">未找到匹配的元素。</exception>
	public static T Find<T>(this IEnumerable<T> source, Func<T, int, bool> predicate)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		int index = 0;
		foreach (T item in source)
		{
			if (predicate(item, index++))
			{
				return item;
			}
		}
		throw new InvalidOperationException(Literals.MSG_ValueNotFound);
	}

	/// <summary>
	/// 在当前序列中查找与指定条件匹配的元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <param name="defaultValue">如果无法找到匹配的元素，则返回该默认值</param>
	/// <returns>找到的匹配元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static T Find<T>(this IEnumerable<T> source, Func<T, int, bool> predicate, T defaultValue)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		int index = 0;
		foreach (T item in source)
		{
			if (predicate(item, index++))
			{
				return item;
			}
		}
		return defaultValue;
	}

	/// <summary>
	/// 在当前序列中查找满足指定条件的元素，并返回匹配的元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>满足条件的元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件为空。</exception>
	public static T[] FindAll<T>(this IEnumerable<T> source, Func<T, bool> predicate)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		return source.Where(predicate).ToArray();
	}

	/// <summary>
	/// 在当前序列中查找满足指定条件的元素，并返回匹配的元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>满足条件的元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件为空。</exception>
	public static T[] FindAll<T>(this IEnumerable<T> source, Func<T, int, bool> predicate)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		return source.Where(predicate).ToArray();
	}

	/// <summary>
	/// 获取在当前序列中第一个符合指定条件的元素在序列中的索引位置
	/// </summary>
	/// <typeparam name="T">序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">筛选条件</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	public static int FindIndex<T>(this IEnumerable<T> source, Func<T, bool> predicate)
	{
		predicate.GuardNotNull("predicate");
		return source.FindIndex((T x, int i) => predicate(x));
	}

	/// <summary>
	/// 获取在当前序列第一个符合指定条件的元素在序列中的索引位置
	/// </summary>
	/// <typeparam name="T">序列元素的类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">筛选条件</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件为空。</exception>
	public static int FindIndex<T>(this IEnumerable<T> source, Func<T, int, bool> predicate)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		int index = 0;
		foreach (T item in source)
		{
			if (predicate(item, index))
			{
				return index;
			}
			index++;
		}
		return -1;
	}

	/// <summary>
	/// 获取在当前序列第一个符合指定条件的元素在序列中的索引位置
	/// </summary>
	/// <typeparam name="T">序列元素的类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="start">从零开始的搜索的起始索引</param>
	/// <param name="predicate">筛选条件</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">搜索的起始位置小于0。</exception>
	public static int FindIndex<T>(this IEnumerable<T> source, int start, Func<T, bool> predicate)
	{
		predicate.GuardNotNull("predicate");
		return source.FindIndex(start, (T x, int i) => predicate(x));
	}

	/// <summary>
	/// 获取在当前序列第一个符合指定条件的元素在序列中的索引位置
	/// </summary>
	/// <typeparam name="T">序列元素的类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="start">从零开始的搜索的起始索引</param>
	/// <param name="predicate">筛选条件</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">搜索的起始位置小于0。</exception>
	public static int FindIndex<T>(this IEnumerable<T> source, int start, Func<T, int, bool> predicate)
	{
		source.GuardNotNull("source");
		start.GuardIndexLowBound(0, "start");
		predicate.GuardNotNull("predicate");
		foreach (T o in source.Skip(start))
		{
			if (predicate(o, start))
			{
				return start;
			}
			start++;
		}
		return -1;
	}

	/// <summary>
	/// 获取在当前序列第一个符合指定条件的元素在序列中的索引位置
	/// </summary>
	/// <typeparam name="T">序列元素的类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="start">从零开始的搜索的起始索引</param>
	/// <param name="count">要搜索的部分中的元素数</param>
	/// <param name="predicate">筛选条件</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">搜索的起始位置小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">搜索的元素数量小于0。</exception>
	public static int FindIndex<T>(this IEnumerable<T> source, int start, int count, Func<T, bool> predicate)
	{
		predicate.GuardNotNull("predicate");
		return source.FindIndex(start, count, (T x, int i) => predicate(x));
	}

	/// <summary>
	/// 获取在当前序列第一个符合指定条件的元素在序列中的索引位置
	/// </summary>
	/// <typeparam name="T">序列元素的类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="start">从零开始的搜索的起始索引</param>
	/// <param name="count">要搜索的部分中的元素数</param>
	/// <param name="predicate">筛选条件</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">搜索的起始位置小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">搜索的元素数量小于0。</exception>
	public static int FindIndex<T>(this IEnumerable<T> source, int start, int count, Func<T, int, bool> predicate)
	{
		source.GuardNotNull("source");
		start.GuardIndexLowBound(0, "start");
		count.GuardGreaterThanOrEqualTo(0, "count");
		predicate.GuardNotNull("predicate");
		int end = start + count;
		foreach (T o in source.Skip(start))
		{
			if (start >= end)
			{
				break;
			}
			if (predicate(o, start))
			{
				return start;
			}
			start++;
		}
		return -1;
	}

	/// <summary>
	/// 返回当前序列中第一个符合指定条件的元素，如果没有符合条件的元素，则抛出异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>满足条件的一个元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列没有符合条件的元素。</exception>
	public static T First<T>(this IEnumerable<T> source, Func<T, int, bool> predicate)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		int index = 0;
		foreach (T item in source)
		{
			if (predicate(item, index++))
			{
				return item;
			}
		}
		throw new InvalidOperationException(Literals.MSG_SequenceNotElementInPredicate);
	}

	/// <summary>
	/// 获取当前序列中从头部开始指定数量的元素，如果序列中存在的元素不足，则只返回序列中存在的元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="count">子序列元素的数量</param>
	/// <returns>选取的子序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">获取的元素数量 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable<T> First<T>(this IEnumerable<T> source, int count)
	{
		source.GuardNotNull("source");
		count.GuardGreaterThanOrEqualTo(0, "count");
		return source.Take(count);
	}

	/// <summary>
	/// 获取当前序列的第一个元素，如果不存在则返回元素默认值  <paramref name="defaultValue" />。
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="defaultValue">元素默认值</param>
	/// <returns>当前序列中符合条件的第一个元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static T FirstOrDefault<T>(this IEnumerable<T> source, T defaultValue)
	{
		source.GuardNotNull("source");
		using (IEnumerator<T> enumerator = source.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				return enumerator.Current;
			}
		}
		return defaultValue;
	}

	/// <summary>
	/// 获取当前序列中符合条件的第一个元素，如果不存在则返回元素默认值  <paramref name="defaultValue" />。
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">元素筛选条件</param>
	/// <param name="defaultValue">元素默认值</param>
	/// <returns>当前序列中符合条件的第一个元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static T FirstOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate, T defaultValue)
	{
		predicate.GuardNotNull("predicate");
		return source.FirstOrDefault((T x, int i) => predicate(x), defaultValue);
	}

	/// <summary>
	/// 获取当前序列中符合条件的第一个元素，如果不存在则返回元素默认值  <paramref name="defaultValue" />。
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">元素筛选条件</param>
	/// <param name="defaultValue">元素默认值</param>
	/// <returns>当前序列中符合条件的第一个元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static T FirstOrDefault<T>(this IEnumerable<T> source, Func<T, int, bool> predicate, T defaultValue = default(T))
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		int index = 0;
		foreach (T item in source)
		{
			if (predicate(item, index++))
			{
				return item;
			}
		}
		return defaultValue;
	}

	/// <summary>
	/// 获取当前序列中从开始指定数量元素的子序列，如果序列中的元素数量不足指定的数量，则使用序列元素默认值  <paramref name="defaultValue" /> 进行填充
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="count">获取的序列元素数量</param>
	/// <param name="defaultValue">元素默认值</param>
	/// <returns>获取的子序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">获取的序列元素 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable<T> FirstOrDefault<T>(this IEnumerable<T> source, int count, T defaultValue = default(T))
	{
		source.GuardNotNull("source");
		count.GuardGreaterThanOrEqualTo(0, "count");
		int index = 0;
		foreach (T item in source)
		{
			if (index++ >= count)
			{
				yield break;
			}
			yield return item;
		}
		if (index < count)
		{
			while (index++ >= count)
			{
				yield return defaultValue;
			}
		}
	}

	/// <summary>
	/// 对当前序列中的每个元素索引执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	public static void For<T>(this IEnumerable<T> source, Action<int> action)
	{
		source.GuardNotNull("source");
		action.GuardNotNull("action");
		int index = 0;
		foreach (T item in source)
		{
			action(index++);
		}
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static void For<T>(this IEnumerable<T> source, Action<int> action, int count)
	{
		source.GuardNotNull("source");
		action.GuardNotNull("action");
		count.GuardGreaterThanOrEqualTo(0, "count");
		int index = 0;
		foreach (T item in source)
		{
			if (index >= count)
			{
				break;
			}
			action(index++);
		}
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理的索引 <paramref name="start" /> 为空。</exception>
	public static void For<T>(this IEnumerable<T> source, int start, Action<int> action)
	{
		source.GuardNotNull("source");
		start.GuardGreaterThanOrEqualTo(0, "start");
		action.GuardNotNull("action");
		foreach (T item in source.Skip(start))
		{
			action(start++);
		}
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理的索引 <paramref name="start" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static void For<T>(this IEnumerable<T> source, int start, int count, Action<int> action)
	{
		source.GuardNotNull("source");
		start.GuardIndexLowBound(0, "start");
		count.GuardGreaterThanOrEqualTo(0, "count");
		action.GuardNotNull("action");
		int end = start + count;
		foreach (T item in source.Skip(start))
		{
			if (start >= end)
			{
				break;
			}
			action(start++);
		}
	}

	/// <summary>
	/// 对当前序列中的每个元素执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列为空</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
	{
		action.GuardNotNull("action");
		source.ForEach(delegate(T x, int i)
		{
			action(x);
		});
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static void ForEach<T>(this IEnumerable<T> source, Action<T> action, int count)
	{
		action.GuardNotNull("action");
		source.ForEach(delegate(T x, int i)
		{
			action(x);
		}, count);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理的索引 <paramref name="start" /> 为空。</exception>
	public static void ForEach<T>(this IEnumerable<T> source, int start, Action<T> action)
	{
		action.GuardNotNull("action");
		source.ForEach(start, delegate(T x, int i)
		{
			action(x);
		});
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理的索引 <paramref name="start" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static void ForEach<T>(this IEnumerable<T> source, int start, int count, Action<T> action)
	{
		action.GuardNotNull("action");
		source.ForEach(start, count, delegate(T x, int i)
		{
			action(x);
		});
	}

	/// <summary>
	/// 对当前序列中的每个元素执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	public static void ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
	{
		source.GuardNotNull("source");
		action.GuardNotNull("action");
		int index = 0;
		foreach (T item in source)
		{
			action(item, index++);
		}
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static void ForEach<T>(this IEnumerable<T> source, Action<T, int> action, int count)
	{
		source.GuardNotNull("source");
		action.GuardNotNull("action");
		count.GuardGreaterThanOrEqualTo(0, "count");
		int index = 0;
		foreach (T item in source)
		{
			if (index >= count)
			{
				break;
			}
			action(item, index++);
		}
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理的索引 <paramref name="start" /> 为空。</exception>
	public static void ForEach<T>(this IEnumerable<T> source, int start, Action<T, int> action)
	{
		source.GuardNotNull("source");
		start.GuardGreaterThanOrEqualTo(0, "start");
		action.GuardNotNull("action");
		foreach (T item in source.Skip(start))
		{
			action(item, start++);
		}
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理的索引 <paramref name="start" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static void ForEach<T>(this IEnumerable<T> source, int start, int count, Action<T, int> action)
	{
		source.GuardNotNull("source");
		start.GuardIndexLowBound(0, "start");
		count.GuardGreaterThanOrEqualTo(0, "count");
		action.GuardNotNull("action");
		int end = start + count;
		foreach (T item in source.Skip(start))
		{
			if (start >= end)
			{
				break;
			}
			action(item, start++);
		}
	}

	/// <summary>
	/// 对当前序列中的每个元素索引执行指定的函数操作，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">处理函数返回值类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="evaluator">处理函数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluator" /> 为空。</exception>
	public static IEnumerable<T> ForEval<S, T>(this IEnumerable<S> source, Func<int, T> evaluator)
	{
		source.GuardNotNull("source");
		evaluator.GuardNotNull("evaluator");
		int index = 0;
		foreach (S item in source)
		{
			_ = item;
			yield return evaluator(index++);
		}
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素索引执行指定的函数，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">处理函数返回值类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="evaluator">处理函数</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable<T> ForEval<S, T>(this IEnumerable<S> source, Func<int, T> evaluator, int count)
	{
		source.GuardNotNull("source");
		evaluator.GuardNotNull("evaluator");
		count.GuardGreaterThanOrEqualTo(0, "count");
		int index = 0;
		foreach (S item in source)
		{
			_ = item;
			if (index >= count)
			{
				break;
			}
			yield return evaluator(index++);
		}
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素索引执行指定的函数，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">处理函数返回值类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="evaluator">处理函数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluator" /> 为空。</exception>
	public static IEnumerable<T> ForEval<S, T>(this IEnumerable<S> source, int start, Func<int, T> evaluator)
	{
		source.GuardNotNull("source");
		start.GuardGreaterThanOrEqualTo(0, "start");
		evaluator.GuardNotNull("evaluator");
		foreach (S item in source.Skip(start))
		{
			_ = item;
			yield return evaluator(start++);
		}
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素索引执行指定的函数，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">处理函数返回值类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="evaluator">处理函数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理的索引 <paramref name="start" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable<T> ForEval<S, T>(this IEnumerable<S> source, int start, int count, Func<int, T> evaluator)
	{
		source.GuardNotNull("source");
		start.GuardIndexLowBound(0, "start");
		count.GuardGreaterThanOrEqualTo(0, "count");
		evaluator.GuardNotNull("evaluator");
		int end = start + count;
		foreach (S item in source.Skip(start))
		{
			_ = item;
			if (start >= end)
			{
				break;
			}
			yield return evaluator(start++);
		}
	}

	/// <summary>
	/// 对当前序列中的每个元素执行指定的函数操作，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">处理函数返回值类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="evaluator">处理函数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluator" /> 为空。</exception>
	public static IEnumerable<T> ForEachEval<S, T>(this IEnumerable<S> source, Func<S, T> evaluator)
	{
		evaluator.GuardNotNull("evaluator");
		return source.ForEachEval((S x, int i) => evaluator(x));
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的函数，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">处理函数返回值类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="evaluator">处理函数</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable<T> ForEachEval<S, T>(this IEnumerable<S> source, Func<S, T> evaluator, int count)
	{
		evaluator.GuardNotNull("evaluator");
		return source.ForEachEval((S x, int i) => evaluator(x), count);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的函数，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">处理函数返回值类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="evaluator">处理函数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理的索引 <paramref name="start" /> 为空。</exception>
	public static IEnumerable<T> ForEachEval<S, T>(this IEnumerable<S> source, int start, Func<S, T> evaluator)
	{
		evaluator.GuardNotNull("evaluator");
		return source.ForEachEval(start, (S x, int i) => evaluator(x));
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的函数，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">处理函数返回值类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="evaluator">处理函数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理的索引 <paramref name="start" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable<T> ForEachEval<S, T>(this IEnumerable<S> source, int start, int count, Func<S, T> evaluator)
	{
		evaluator.GuardNotNull("evaluator");
		return source.ForEachEval(start, count, (S x, int i) => evaluator(x));
	}

	/// <summary>
	/// 对当前序列中的每个元素执行指定的函数操作，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">处理函数返回值类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="evaluator">处理函数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluator" /> 为空。</exception>
	public static IEnumerable<T> ForEachEval<S, T>(this IEnumerable<S> source, Func<S, int, T> evaluator)
	{
		source.GuardNotNull("source");
		evaluator.GuardNotNull("evaluator");
		int index = 0;
		foreach (S value in source)
		{
			yield return evaluator(value, index++);
		}
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的函数，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">处理函数返回值类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="evaluator">处理函数</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable<T> ForEachEval<S, T>(this IEnumerable<S> source, Func<S, int, T> evaluator, int count)
	{
		source.GuardNotNull("source");
		evaluator.GuardNotNull("evaluator");
		count.GuardGreaterThanOrEqualTo(0, "count");
		int index = 0;
		foreach (S item in source)
		{
			if (index >= count)
			{
				break;
			}
			yield return evaluator(item, index++);
		}
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的函数，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">处理函数返回值类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="evaluator">处理函数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluator" /> 为空。</exception>
	public static IEnumerable<T> ForEachEval<S, T>(this IEnumerable<S> source, int start, Func<S, int, T> evaluator)
	{
		source.GuardNotNull("source");
		start.GuardGreaterThanOrEqualTo(0, "start");
		evaluator.GuardNotNull("evaluator");
		foreach (S item in source.Skip(start))
		{
			yield return evaluator(item, start++);
		}
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的函数，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">处理函数返回值类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="evaluator">处理函数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理的索引 <paramref name="start" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable<T> ForEachEval<S, T>(this IEnumerable<S> source, int start, int count, Func<S, int, T> evaluator)
	{
		source.GuardNotNull("source");
		start.GuardIndexLowBound(0, "start");
		count.GuardGreaterThanOrEqualTo(0, "count");
		evaluator.GuardNotNull("evaluator");
		int end = start + count;
		foreach (S item in source.Skip(start))
		{
			if (start >= end)
			{
				break;
			}
			yield return evaluator(item, start++);
		}
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel<T>(this IEnumerable<T> source, Action<int> action, ParallelOptions options = null)
	{
		source.GuardNotNull("source");
		return source.ForParallel(0, source.Count(), action, options);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel<T>(this IEnumerable<T> source, Action<long> action, ParallelOptions options = null)
	{
		source.GuardNotNull("source");
		return source.ForParallel(0L, source.LongCount(), action, options);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel<T>(this IEnumerable<T> source, Action<int, ParallelLoopState> action, ParallelOptions options = null)
	{
		source.GuardNotNull("source");
		return source.ForParallel(0, source.Count(), action, options);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel<T>(this IEnumerable<T> source, Action<long, ParallelLoopState> action, ParallelOptions options = null)
	{
		source.GuardNotNull("source");
		return source.ForParallel(0L, source.LongCount(), action, options);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">操作之间传递变量的类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="func">对每个元素索引执行的操作方法</param>
	/// <param name="initializer">操作间变量的初始化方法</param>
	/// <param name="finalizer">操作间变量的清理方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="func" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel<S, T>(this IEnumerable<S> source, Func<int, ParallelLoopState, T, T> func, Func<T> initializer = null, Action<T> finalizer = null, ParallelOptions options = null)
	{
		source.GuardNotNull("source");
		return source.ForParallel(0, source.Count(), func, initializer, finalizer, options);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">操作之间传递变量的类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="func">对每个元素索引执行的操作方法</param>
	/// <param name="initializer">操作间变量的初始化方法</param>
	/// <param name="finalizer">操作间变量的清理方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="func" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel<S, T>(this IEnumerable<S> source, Func<long, ParallelLoopState, T, T> func, Func<T> initializer = null, Action<T> finalizer = null, ParallelOptions options = null)
	{
		source.GuardNotNull("source");
		return source.ForParallel(0L, source.LongCount(), func, initializer, finalizer, options);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel<T>(this IEnumerable<T> source, int start, int count, Action<int> action, ParallelOptions options = null)
	{
		source.GuardNotNull("source");
		start.GuardIndexLowBound(0, "start");
		count.GuardGreaterThanOrEqualTo(0, "count");
		action.GuardNotNull("action");
		if (options.IsNull())
		{
			return Parallel.For(start, start + count, action);
		}
		return Parallel.For(start, start + count, options, action);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel<T>(this IEnumerable<T> source, long start, long count, Action<long> action, ParallelOptions options = null)
	{
		source.GuardNotNull("source");
		start.GuardIndexLowBound(0L, "start");
		count.GuardGreaterThanOrEqualTo(0L, "count");
		action.GuardNotNull("action");
		if (options.IsNull())
		{
			return Parallel.For(start, start + count, action);
		}
		return Parallel.For(start, start + count, options, action);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel<T>(this IEnumerable<T> source, int start, int count, Action<int, ParallelLoopState> action, ParallelOptions options = null)
	{
		source.GuardNotNull("source");
		start.GuardIndexLowBound(0, "start");
		count.GuardGreaterThanOrEqualTo(0, "count");
		action.GuardNotNull("action");
		if (options.IsNull())
		{
			return Parallel.For(start, start + count, action);
		}
		return Parallel.For(start, start + count, options, action);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel<T>(this IEnumerable<T> source, long start, long count, Action<long, ParallelLoopState> action, ParallelOptions options = null)
	{
		source.GuardNotNull("source");
		start.GuardIndexLowBound(0L, "start");
		count.GuardGreaterThanOrEqualTo(0L, "count");
		action.GuardNotNull("action");
		if (options.IsNull())
		{
			return Parallel.For(start, start + count, action);
		}
		return Parallel.For(start, start + count, options, action);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">操作之间传递变量的类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="func">对每个元素索引执行的操作方法</param>
	/// <param name="initializer">操作间变量的初始化方法</param>
	/// <param name="finalizer">操作间变量的清理方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="func" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel<S, T>(this IEnumerable<S> source, int start, int count, Func<int, ParallelLoopState, T, T> func, Func<T> initializer = null, Action<T> finalizer = null, ParallelOptions options = null)
	{
		source.GuardNotNull("source");
		func.GuardNotNull("func");
		start.GuardIndexLowBound(0, "start");
		count.GuardGreaterThanOrEqualTo(0, "count");
		initializer = initializer.IfNull(() => default(T));
		finalizer = finalizer.IfNull(delegate
		{
		});
		if (options.IsNull())
		{
			return Parallel.For(start, count, initializer, func, finalizer);
		}
		return Parallel.For(start, count, options, initializer, func, finalizer);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">操作之间传递变量的类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="func">对每个元素索引执行的操作方法</param>
	/// <param name="initializer">操作间变量的初始化方法</param>
	/// <param name="finalizer">操作间变量的清理方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="func" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel<S, T>(this IEnumerable<S> source, long start, long count, Func<long, ParallelLoopState, T, T> func, Func<T> initializer = null, Action<T> finalizer = null, ParallelOptions options = null)
	{
		source.GuardNotNull("source");
		func.GuardNotNull("func");
		start.GuardIndexLowBound(0L, "start");
		count.GuardGreaterThanOrEqualTo(0L, "count");
		initializer = initializer.IfNull(() => default(T));
		finalizer = finalizer.IfNull(delegate
		{
		});
		if (options.IsNull())
		{
			return Parallel.For(start, count, initializer, func, finalizer);
		}
		return Parallel.For(start, count, options, initializer, func, finalizer);
	}

	/// <summary>
	/// 对当前序列中所有元素执行指定的操作，该操作可能并行
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>循环结果信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	public static ParallelLoopResult ForEachParallel<T>(this IEnumerable<T> source, Action<T> action, ParallelOptions options = null)
	{
		source.GuardNotNull("source");
		action.GuardNotNull("action");
		if (options.IsNull())
		{
			return Parallel.ForEach(source, action);
		}
		return Parallel.ForEach(source, options, action);
	}

	/// <summary>
	/// 对当前序列中所有元素执行指定的操作，该操作可能并行
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	public static ParallelLoopResult ForEachParallel<T>(this IEnumerable<T> source, Action<T, long> action, ParallelOptions options = null)
	{
		source.GuardNotNull("source");
		action.GuardNotNull("action");
		if (options.IsNull())
		{
			return Parallel.ForEach(source, delegate(T x, ParallelLoopState p, long i)
			{
				action(x, i);
			});
		}
		return Parallel.ForEach(source, options, delegate(T x, ParallelLoopState p, long i)
		{
			action(x, i);
		});
	}

	/// <summary>
	/// 对当前序列中所有元素执行指定的操作，该操作可能并行
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	public static ParallelLoopResult ForEachParallel<T>(this IEnumerable<T> source, Action<T, ParallelLoopState> action, ParallelOptions options = null)
	{
		source.GuardNotNull("source");
		action.GuardNotNull("action");
		if (options.IsNull())
		{
			return Parallel.ForEach(source, action);
		}
		return Parallel.ForEach(source, options, action);
	}

	/// <summary>
	/// 对当前序列中所有元素执行指定的操作，该操作可能并行
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	public static ParallelLoopResult ForEachParallel<T>(this IEnumerable<T> source, Action<T, long, ParallelLoopState> action, ParallelOptions options = null)
	{
		source.GuardNotNull("source");
		action.GuardNotNull("action");
		if (options.IsNull())
		{
			return Parallel.ForEach(source, delegate(T x, ParallelLoopState p, long i)
			{
				action(x, i, p);
			});
		}
		return Parallel.ForEach(source, options, delegate(T x, ParallelLoopState p, long i)
		{
			action(x, i, p);
		});
	}

	/// <summary>
	///             对当前序列中所有元素执行指定的操作，该操作可能并行
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">操作之间传递变量的类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="func">对每个元素执行的操作方法</param>
	/// <param name="initializer">操作间变量的初始化方法</param>
	/// <param name="finalizer">操作间变量的清理方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="func" /> 为空。</exception>
	public static ParallelLoopResult ForEachParallel<S, T>(this IEnumerable<S> source, Func<S, ParallelLoopState, T, T> func, Func<T> initializer = null, Action<T> finalizer = null, ParallelOptions options = null)
	{
		source.GuardNotNull("source");
		func.GuardNotNull("func");
		initializer = initializer.IfNull(() => default(T));
		finalizer = finalizer.IfNull(delegate
		{
		});
		if (options.IsNull())
		{
			return Parallel.ForEach(source, initializer, func, finalizer);
		}
		return Parallel.ForEach(source, options, initializer, func, finalizer);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">操作之间传递变量的类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="func">对每个元素执行的操作方法</param>
	/// <param name="initializer">操作间变量的初始化方法</param>
	/// <param name="finalizer">操作间变量的清理方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="func" /> 为空。</exception>
	public static ParallelLoopResult ForEachParallel<S, T>(this IEnumerable<S> source, Func<S, long, ParallelLoopState, T, T> func, Func<T> initializer = null, Action<T> finalizer = null, ParallelOptions options = null)
	{
		source.GuardNotNull("source");
		func.GuardNotNull("func");
		initializer = initializer.IfNull(() => default(T));
		finalizer = finalizer.IfNull(delegate
		{
		});
		if (options.IsNull())
		{
			return Parallel.ForEach(source, initializer, (S x, ParallelLoopState p, long i, T v) => func(x, i, p, v), finalizer);
		}
		return Parallel.ForEach(source, options, initializer, (S x, ParallelLoopState p, long i, T v) => func(x, i, p, v), finalizer);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForEachParallel<T>(this IEnumerable<T> source, int start, int count, Action<T> action, ParallelOptions options = null)
	{
		source.GuardNotNull("source");
		start.GuardIndexLowBound(0, "start");
		count.GuardGreaterThanOrEqualTo(0, "count");
		action.GuardNotNull("action");
		if (options.IsNull())
		{
			return Parallel.For(start, start + count, delegate(int i)
			{
				action(source.ElementAt(i));
			});
		}
		return Parallel.For(start, start + count, options, delegate(int i)
		{
			action(source.ElementAt(i));
		});
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForEachParallel<T>(this IEnumerable<T> source, int start, int count, Action<T, int> action, ParallelOptions options = null)
	{
		source.GuardNotNull("source");
		start.GuardIndexLowBound(0, "start");
		count.GuardGreaterThanOrEqualTo(0, "count");
		action.GuardNotNull("action");
		if (options.IsNull())
		{
			return Parallel.For(start, start + count, delegate(int i)
			{
				action(source.ElementAt(i), i);
			});
		}
		return Parallel.For(start, start + count, options, delegate(int i)
		{
			action(source.ElementAt(i), i);
		});
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForEachParallel<T>(this IEnumerable<T> source, int start, int count, Action<T, ParallelLoopState> action, ParallelOptions options = null)
	{
		source.GuardNotNull("source");
		start.GuardIndexLowBound(0, "start");
		count.GuardGreaterThanOrEqualTo(0, "count");
		action.GuardNotNull("action");
		if (options.IsNull())
		{
			return Parallel.For(start, start + count, delegate(int i, ParallelLoopState p)
			{
				action(source.ElementAt(i), p);
			});
		}
		return Parallel.For(start, start + count, options, delegate(int i, ParallelLoopState p)
		{
			action(source.ElementAt(i), p);
		});
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForEachParallel<T>(this IEnumerable<T> source, int start, int count, Action<T, int, ParallelLoopState> action, ParallelOptions options = null)
	{
		source.GuardNotNull("source");
		start.GuardIndexLowBound(0, "start");
		count.GuardGreaterThanOrEqualTo(0, "count");
		action.GuardNotNull("action");
		if (options.IsNull())
		{
			return Parallel.For(start, start + count, delegate(int i, ParallelLoopState p)
			{
				action(source.ElementAt(i), i, p);
			});
		}
		return Parallel.For(start, start + count, options, delegate(int i, ParallelLoopState p)
		{
			action(source.ElementAt(i), i, p);
		});
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">操作之间传递变量的类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="func">对每个元素执行的操作方法</param>
	/// <param name="initializer">操作间变量的初始化方法</param>
	/// <param name="finalizer">操作间变量的清理方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="func" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForEachParallel<S, T>(this IEnumerable<S> source, int start, int count, Func<S, ParallelLoopState, T, T> func, Func<T> initializer = null, Action<T> finalizer = null, ParallelOptions options = null)
	{
		source.GuardNotNull("start");
		func.GuardNotNull("func");
		start.GuardIndexLowBound(0, "start");
		count.GuardGreaterThanOrEqualTo(0, "count");
		initializer = initializer.IfNull(() => default(T));
		finalizer = finalizer.IfNull(delegate
		{
		});
		if (options.IsNull())
		{
			return Parallel.For(start, count, initializer, (int i, ParallelLoopState p, T v) => func(source.ElementAt(i), p, v), finalizer);
		}
		return Parallel.For(start, count, options, initializer, (int i, ParallelLoopState p, T v) => func(source.ElementAt(i), p, v), finalizer);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">操作之间传递变量的类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="func">对每个元素执行的操作方法</param>
	/// <param name="initializer">操作间变量的初始化方法</param>
	/// <param name="finalizer">操作间变量的清理方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="func" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForEachParallel<S, T>(this IEnumerable<S> source, int start, int count, Func<S, int, ParallelLoopState, T, T> func, Func<T> initializer = null, Action<T> finalizer = null, ParallelOptions options = null)
	{
		source.GuardNotNull("source");
		func.GuardNotNull("func");
		start.GuardIndexLowBound(0, "start");
		count.GuardGreaterThanOrEqualTo(0, "count");
		initializer = initializer.IfNull(() => default(T));
		finalizer = finalizer.IfNull(delegate
		{
		});
		if (options.IsNull())
		{
			return Parallel.For(start, count, initializer, (int i, ParallelLoopState p, T v) => func(source.ElementAt(i), i, p, v), finalizer);
		}
		return Parallel.For(start, count, options, initializer, (int i, ParallelLoopState p, T v) => func(source.ElementAt(i), i, p, v), finalizer);
	}

	/// <summary>
	/// 获取当前序列中每个元素的类型，如果元素为空，则对应的类型为空
	/// </summary>
	/// <typeparam name="T">当前序列类型</typeparam>
	/// <param name="items">当前序列</param>
	/// <returns>当前序列中各个元素的类型的数组；如果序列元素为空，则元素类型为空。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<Type> GetTypes<T>(this IEnumerable<T> items)
	{
		items.GuardNotNull("items");
		foreach (T item2 in items)
		{
			object item = item2;
			yield return item.IsNull() ? null : item.GetType();
		}
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否全部满足指定的条件，不全部满足则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="name">序列名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前序列中的任一元素不满足指定检测规则。</exception>
	public static E GuardAll<T, E>(this E items, Func<T, bool> predicate, string name = null, string message = null) where E : IEnumerable<T>
	{
		items.GuardNotNull("items");
		predicate.GuardNotNull("predicate");
		items.Guard(items.All(predicate), name.IfNull("item"), message.IfNull(Literals.MSG_SequenceAnyOneElementNotInPredicate));
		return items;
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否全部满足指定的条件，不全部满足则抛出指定异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前序列中的任一元素不满足指定检测规则，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static E GuardAll<T, E>(this E items, Func<T, bool> predicate, Func<Exception> exceptionCreator) where E : IEnumerable<T>
	{
		items.GuardNotNull("items");
		predicate.GuardNotNull("predicate");
		items.Guard(items.All(predicate), exceptionCreator);
		return items;
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否全部满足指定的条件，不全部满足则抛出指定异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前序列中的任一元素不满足指定检测规则，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static E GuardAll<T, E>(this E items, Func<T, bool> predicate, Type exceptionType, params object[] args) where E : IEnumerable<T>
	{
		items.GuardNotNull("items");
		predicate.GuardNotNull("predicate");
		items.Guard(items.All(predicate), exceptionType, args);
		return items;
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否全部不满足指定的条件，如果存在满足条件的元素则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="name">序列名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前序列中的任一元素满足指定检测规则。</exception>
	public static E GuardAllNot<T, E>(this E items, Func<T, bool> predicate, string name = null, string message = null) where E : IEnumerable<T>
	{
		items.GuardNotNull("items");
		predicate.GuardNotNull("predicate");
		items.Guard(items.AllNot(predicate), name.IfNull("item"), message.IfNull(Literals.MSG_SequenceAnyOneElementInPredicate));
		return items;
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否全部不满足指定的条件，如果存在满足条件的元素则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前序列中的任一元素满足指定检测规则，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static E GuardAllNot<T, E>(this E items, Func<T, bool> predicate, Func<Exception> exceptionCreator) where E : IEnumerable<T>
	{
		items.GuardNotNull("items");
		predicate.GuardNotNull("predicate");
		items.Guard(items.AllNot(predicate), exceptionCreator);
		return items;
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否全部不满足指定的条件，如果存在满足条件的元素则抛出 <paramref name="exceptionType" /> 类型的异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前待检测的序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前序列中的任一元素满足指定检测规则，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static E GuardAllNot<T, E>(this E items, Func<T, bool> predicate, Type exceptionType, params object[] args) where E : IEnumerable<T>
	{
		items.GuardNotNull("items");
		predicate.GuardNotNull("predicate");
		items.Guard(items.AllNot(predicate), exceptionType, args);
		return items;
	}

	/// <summary>
	/// 检测当前序列中是否有满足指定的条件的元素，如果不存在满足条件的元素则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前待检测的序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="name">序列名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前序列中的元素全部不满足指定检测规则。</exception>
	public static E GuardAny<T, E>(this E items, Func<T, bool> predicate, string name = null, string message = null) where E : IEnumerable<T>
	{
		items.GuardNotNull("items");
		predicate.GuardNotNull("predicate");
		items.Guard(items.Any(predicate), name.IfNull("item"), message.IfNull(Literals.MSG_SequenceNotElementInPredicate));
		return items;
	}

	/// <summary>
	/// 检测当前序列中是否有满足指定的条件的元素，如果不存在满足条件的元素则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前待检测的序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前序列中的元素全部不满足指定检测规则，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static E GuardAny<T, E>(this E items, Func<T, bool> predicate, Func<Exception> exceptionCreator) where E : IEnumerable<T>
	{
		items.GuardNotNull("items");
		predicate.GuardNotNull("predicate");
		items.Guard(items.Any(predicate), exceptionCreator);
		return items;
	}

	/// <summary>
	/// 检测当前序列中是否有满足指定的条件的元素，如果不存在满足条件的元素则抛出 <paramref name="exceptionType" /> 类型的异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前待检测的序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前序列中的元素全部不满足指定检测规则，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static E GuardAny<T, E>(this E items, Func<T, bool> predicate, Type exceptionType, params object[] args) where E : IEnumerable<T>
	{
		items.GuardNotNull("items");
		predicate.GuardNotNull("predicate");
		items.Guard(items.Any(predicate), exceptionType, args);
		return items;
	}

	/// <summary>
	/// 检测当前序列中是否有不满足指定的条件的元素，全部都满足条件的元素则抛出ArgumentException
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前待检测的序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="name">序列名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前序列中的元素全部满足指定检测规则。</exception>
	public static E GuardAnyNot<T, E>(this E items, Func<T, bool> predicate, string name = null, string message = null) where E : IEnumerable<T>
	{
		items.GuardNotNull("items");
		predicate.GuardNotNull("predicate");
		items.Guard(items.AnyNot(predicate), name.IfNull("item"), message.IfNull(Literals.MSG_SequenceAllElementInPredicate));
		return items;
	}

	/// <summary>
	/// 检测当前序列中是否有不满足指定的条件的元素，全部都满足条件的元素则抛出指定异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前待检测的序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前序列中的元素全部满足指定检测规则，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static E GuardAnyNot<T, E>(this E items, Func<T, bool> predicate, Func<Exception> exceptionCreator) where E : IEnumerable<T>
	{
		items.GuardNotNull("items");
		predicate.GuardNotNull("predicate");
		items.Guard(items.AnyNot(predicate), exceptionCreator);
		return items;
	}

	/// <summary>
	/// 检测当前序列中是否有不满足指定的条件的元素，全部都满足条件的元素则抛出指定异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前待检测的序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前序列中的元素全部满足指定检测规则，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static E GuardAnyNot<T, E>(this E items, Func<T, bool> predicate, Type exceptionType, params object[] args) where E : IEnumerable<T>
	{
		items.GuardNotNull("items");
		predicate.GuardNotNull("predicate");
		items.Guard(items.AnyNot(predicate), exceptionType, args);
		return items;
	}

	/// <summary>
	/// 获取当前序列中指定对象第一次出现的位置的索引
	/// </summary>
	/// <typeparam name="T">序列元素的类型</typeparam>
	/// <param name="source">待检测的序列</param>
	/// <param name="obj">待查找的指定对象</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static int IndexOf<T>(this IEnumerable<T> source, T obj)
	{
		return source.IndexOf(0, obj);
	}

	/// <summary>
	/// 获取当前序列中指定对象第一次出现的位置的索引
	/// </summary>
	/// <typeparam name="T">序列元素的类型</typeparam>
	/// <param name="source">待检测的序列</param>
	/// <param name="obj">待检测的指定对象</param>
	/// <param name="equalition">对象相等比较方法</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static int IndexOf<T>(this IEnumerable<T> source, T obj, Func<T, T, bool> equalition)
	{
		return source.IndexOf(0, obj, equalition);
	}

	/// <summary>
	/// 获取当前序列中指定对象第一次出现的位置的索引
	/// </summary>
	/// <typeparam name="T">序列元素的类型</typeparam>
	/// <param name="source">待检测的序列</param>
	/// <param name="start">从零开始的搜索的起始索引</param>
	/// <param name="obj">待检测的指定对象</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始搜索的索引小于0。</exception>
	public static int IndexOf<T>(this IEnumerable<T> source, int start, T obj)
	{
		return source.IndexOf(start, obj, EqualityComparer<T>.Default.Equals);
	}

	/// <summary>
	/// 获取当前序列中指定对象第一次出现的位置的索引
	/// </summary>
	/// <typeparam name="T">序列元素的类型</typeparam>
	/// <param name="source">待检测的序列</param>
	/// <param name="start">从零开始的搜索的起始索引</param>
	/// <param name="obj">待检测的指定对象</param>
	/// <param name="equalition">对象相等比较方法</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始搜索的索引小于0。</exception>
	public static int IndexOf<T>(this IEnumerable<T> source, int start, T obj, Func<T, T, bool> equalition)
	{
		source.GuardNotNull("source");
		start.GuardIndexLowBound(0, "start");
		equalition = equalition.IfNull(EqualityComparer<T>.Default.Equals);
		foreach (T item in source.Skip(start))
		{
			if (equalition(item, obj))
			{
				return start;
			}
			start++;
		}
		return -1;
	}

	/// <summary>
	/// 获取当前序列中指定对象第一次出现的位置的索引
	/// </summary>
	/// <typeparam name="T">序列元素的类型</typeparam>
	/// <param name="source">待检测的序列</param>
	/// <param name="start">从零开始的搜索的起始索引</param>
	/// <param name="count">要搜索的部分中的元素数</param>
	/// <param name="obj">待检测的指定对象</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始搜索的索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">搜索的元素数量小于0。</exception>
	public static int IndexOf<T>(this IEnumerable<T> source, int start, int count, T obj)
	{
		return source.IndexOf(start, count, obj, EqualityComparer<T>.Default.Equals);
	}

	/// <summary>
	/// 获取当前序列中指定对象第一次出现的位置的索引
	/// </summary>
	/// <typeparam name="T">序列元素的类型</typeparam>
	/// <param name="source">待检测的序列</param>
	/// <param name="start">从零开始的搜索的起始索引</param>
	/// <param name="count">要搜索的部分中的元素数</param>
	/// <param name="obj">待检测的指定对象</param>
	/// <param name="equalition">对象相等比较方法</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始搜索的索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">搜索的元素数量小于0。</exception>
	public static int IndexOf<T>(this IEnumerable<T> source, int start, int count, T obj, Func<T, T, bool> equalition)
	{
		source.GuardNotNull("source");
		start.GuardIndexLowBound(0, "start");
		count.GuardGreaterThanOrEqualTo(0, "count");
		equalition = equalition.IfNull(EqualityComparer<T>.Default.Equals);
		int end = start + count;
		foreach (T item in source.Skip(start))
		{
			if (start >= end)
			{
				break;
			}
			if (equalition(item, obj))
			{
				return start;
			}
			start++;
		}
		return -1;
	}

	/// <summary>
	/// 获取当前序列中指定对象中任意一个对象第一次里出现的位置的索引
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="values">待查找的对象集合</param>
	/// <returns>找到的元素的索引，未找到返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者查找的对象集合为空。</exception>
	public static int IndexOfAny<T>(this IEnumerable<T> source, params T[] values)
	{
		return source.IndexOfAny(0, values);
	}

	/// <summary>
	/// 获取当前序列中指定对象中任意一个对象第一次里出现的位置的索引
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="values">待查找的对象集合</param>
	/// <param name="equalition">对象比较方法</param>
	/// <returns>找到的元素的索引，未找到返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者查找的对象集合为空。</exception>
	public static int IndexOfAny<T>(this IEnumerable<T> source, IEnumerable<T> values, Func<T, T, bool> equalition)
	{
		return source.IndexOfAny(0, values, equalition);
	}

	/// <summary>
	/// 获取当前序列中指定对象中任意一个对象第一次里出现的位置的索引
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="values">待查找的对象集合</param>
	/// <returns>找到的元素的索引，未找到返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者查找的对象集合为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始搜索的索引小于0。</exception>
	public static int IndexOfAny<T>(this IEnumerable<T> source, int start, params T[] values)
	{
		return source.IndexOfAny(start, values, EqualityComparer<T>.Default.Equals);
	}

	/// <summary>
	/// 获取当前序列中指定对象中任意一个对象第一次里出现的位置的索引
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="values">待查找的对象集合</param>
	/// <param name="equalition">对象比较方法</param>
	/// <returns>找到的元素的索引，未找到返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者查找的对象集合为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始搜索的索引小于0。</exception>
	public static int IndexOfAny<T>(this IEnumerable<T> source, int start, IEnumerable<T> values, Func<T, T, bool> equalition)
	{
		source.GuardNotNull("source");
		start.GuardIndexLowBound(0, "start");
		values.GuardNotNull("values");
		equalition = equalition.IfNull(EqualityComparer<T>.Default.Equals);
		foreach (T item in source.Skip(start))
		{
			Func<T, bool> predicate = (T x) => equalition(x, item);
			if (values.Any(predicate))
			{
				return start;
			}
			start++;
		}
		return -1;
	}

	/// <summary>
	/// 获取当前序列中指定对象中任意一个对象第一次里出现的位置的索引
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="count">查找的元素数量</param>
	/// <param name="values">待查找的对象集合</param>
	/// <returns>找到的元素的索引，未找到返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者查找的对象集合为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始搜索的索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">搜索的元素数量小于0。</exception>
	public static int IndexOfAny<T>(this IEnumerable<T> source, int start, int count, params T[] values)
	{
		return source.IndexOfAny(start, count, values, EqualityComparer<T>.Default.Equals);
	}

	/// <summary>
	/// 获取当前序列中指定对象中任意一个对象第一次里出现的位置的索引
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="count">查找的元素数量</param>
	/// <param name="values">待查找的对象集合</param>
	/// <param name="equalition">对象比较方法</param>
	/// <returns>找到的元素的索引，未找到返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者查找的对象集合为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始搜索的索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">搜索的元素数量小于0。</exception>
	public static int IndexOfAny<T>(this IEnumerable<T> source, int start, int count, IEnumerable<T> values, Func<T, T, bool> equalition)
	{
		source.GuardNotNull("source");
		start.GuardIndexLowBound(0, "start");
		count.GuardGreaterThanOrEqualTo(0, "count");
		values.GuardNotNull("values");
		equalition = equalition.IfNull(EqualityComparer<T>.Default.Equals);
		int end = start + count;
		foreach (T item in source.Skip(start))
		{
			if (start >= end)
			{
				break;
			}
			if (values.Any((T x) => equalition(x, item)))
			{
				return start;
			}
			start++;
		}
		return -1;
	}

	/// <summary>
	/// 获取当前序列与目标序列的交集
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="target">合并的目标序列</param>
	/// <param name="equalition">返回两个序列的交集</param>
	/// <returns>返回两个序列的交集。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列 <paramref name="target" /> 为空。</exception>
	public static IEnumerable<T> Intersect<T>(this IEnumerable<T> source, IEnumerable<T> target, Func<T, T, bool> equalition)
	{
		source.GuardNotNull("source");
		target.GuardNotNull("target");
		return source.Intersect(target, equalition.ToComparer());
	}

	/// <summary>
	/// 获取当前序列与多个目标序列的交集
	/// </summary>
	/// <typeparam name="T">当前序列的元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="targets">合并的多个目标序列</param>
	/// <returns>处理后的交集</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列数组 <paramref name="targets" /> 为空。</exception>
	public static IEnumerable<T> Intersect<T>(this IEnumerable<T> source, params IEnumerable<T>[] targets)
	{
		return source.Intersect(targets, EqualityComparer<T>.Default);
	}

	/// <summary>
	/// 获取当前序列与多个目标序列的交集
	/// </summary>
	/// <typeparam name="T">当前序列的元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="targets">合并的多个目标序列</param>
	/// <param name="equaliter">序列元素比较器</param>
	/// <returns>处理后的交集</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列列表 <paramref name="targets" /> 为空。</exception>
	public static IEnumerable<T> Intersect<T>(this IEnumerable<T> source, IEnumerable<IEnumerable<T>> targets, IEqualityComparer<T> equaliter)
	{
		source.GuardNotNull("source");
		targets.GuardNotNull("targets");
		foreach (IEnumerable<T> target in targets)
		{
			if (target.IsNotNull())
			{
				source = source.Intersect(target, equaliter);
			}
		}
		return source;
	}

	/// <summary>
	/// 获取当前序列与多个目标序列的交集
	/// </summary>
	/// <typeparam name="T">当前序列的元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="targets">合并的多个目标序列</param>
	/// <param name="equalition">序列元素比较方法</param>
	/// <returns>处理后的交集</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列列表 <paramref name="targets" /> 为空。</exception>
	public static IEnumerable<T> Intersect<T>(this IEnumerable<T> source, IEnumerable<IEnumerable<T>> targets, Func<T, T, bool> equalition)
	{
		return source.Intersect(targets, equalition.ToComparer());
	}

	/// <summary>
	/// 检测当前序列是否为空或者不包含任何元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="items">当前序列</param>
	/// <returns>如果序列为空或者不包含任何元素返回true，否则返回false</returns>
	public static bool IsNullOrEmpty<T>(this IEnumerable<T> items)
	{
		return items.IsNull() || !items.Any();
	}

	/// <summary>
	/// 检测当前序列是否不为空且包含序列元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="items">当前序列</param>
	/// <returns>如果当前序列序列不为空且包含元素返回true，否则返回false</returns>
	public static bool IsNotNullAndEmpty<T>(this IEnumerable<T> items)
	{
		return items.IsNotNull() && items.Any();
	}

	/// <summary>
	/// 将序列元素连接为字符串；序列中各个元素通过调用ToString方法获取其字符串表示
	/// </summary>
	/// <typeparam name="T">序列元素类型</typeparam>
	/// <param name="source">源序列</param>
	/// <param name="separator">元素间分隔符</param>
	/// <returns>转换后的字符串</returns>
	public static string JoinString<T>(this IEnumerable<T> source, string separator = null)
	{
		source.GuardNotNull("source");
		separator = separator.IfNull(string.Empty);
		return source.JoinString((T x) => x.ToString(), separator);
	}

	/// <summary>
	/// 将当前序列元素按指定格式连接为字符串
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="format">当前序列元素格式化符合字符串</param>
	/// <param name="separator">元素间分隔符</param>
	/// <returns>转换后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static string JoinString<T>(this IEnumerable<T> source, string format, string separator = null)
	{
		source.GuardNotNull("source");
		format = format.IfNull("{0}");
		separator = separator.IfNull(string.Empty);
		return source.JoinString((T x) => string.Format(format, x), separator);
	}

	/// <summary>
	/// 将当前序列元素按指定格式连接为字符串
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="formatting">当前序列元素格式化方法</param>
	/// <param name="separator">元素间分隔符</param>
	/// <returns>转换后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static string JoinString<T>(this IEnumerable<T> source, Func<T, string> formatting, string separator = null)
	{
		source.GuardNotNull("source");
		formatting = formatting.IfNull((T x) => x.ToString());
		return source.JoinString((T x, int i) => formatting(x), separator);
	}

	/// <summary>
	/// 将当前序列元素按指定格式连接为字符串
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="formatting">当前序列元素格式化方法</param>
	/// <param name="separator">元素间分隔符</param>
	/// <returns>转换后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static string JoinString<T>(this IEnumerable<T> source, Func<T, int, string> formatting, string separator = null)
	{
		source.GuardNotNull("source");
		formatting = formatting.IfNull((T x, int i) => x.ToString());
		separator = separator.IfNull(string.Empty);
		StringBuilder buff = new StringBuilder();
		int index = 0;
		foreach (T item in source)
		{
			buff.Append(formatting(item, index++).IfNull(string.Empty)).Append(separator);
		}
		return (buff.Length > 0) ? buff.ToString(0, buff.Length - separator.Length) : string.Empty;
	}

	/// <summary>
	/// 获取当前序列中最后一个符合条件的元素，如果没有符合条件的元素抛出异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>最后一个符合条件的元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者序列元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static T Last<T>(this IEnumerable<T> source, Func<T, int, bool> predicate)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		int index = source.Count() - 1;
		foreach (T item in source.Reverse())
		{
			if (predicate(item, index--))
			{
				return item;
			}
		}
		throw new InvalidOperationException(Literals.MSG_SequenceNotElementInPredicate);
	}

	/// <summary>
	/// 获取当前序列中最后指定数量的元素的子序列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="count">获取的元素数量</param>
	/// <returns>获取的子序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">获取的元素数量 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable<T> Last<T>(this IEnumerable<T> source, int count)
	{
		source.GuardNotNull("source");
		count.GuardGreaterThanOrEqualTo(0, "count");
		int start = source.Count() - count;
		start = ((start >= 0) ? start : 0);
		return source.Skip(start).Take(count);
	}

	/// <summary>
	/// 获取当前序列最后一个元素，如果当前序列为空则返回元素默认值 <paramref name="defaultValue" />。
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="defaultValue">元素默认值</param>
	/// <returns>当前序列的最后一个元素或者元素默认值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static T LastOrDefault<T>(this IEnumerable<T> source, T defaultValue)
	{
		source.GuardNotNull("source");
		source.GuardNotNull("source");
		using (IEnumerator<T> enumerator = source.Reverse().GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				return enumerator.Current;
			}
		}
		return defaultValue;
	}

	/// <summary>
	/// 获取当前序列中最后一个符合条件的元素，如果没有符合条件的元素返回元素默认值 <paramref name="defaultValue" />。
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <param name="defaultValue">元素默认值</param>
	/// <returns>最后一个符合条件的元素或者元素类型的默认值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者序列元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static T LastOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate, T defaultValue)
	{
		predicate.GuardNotNull("predicate");
		return source.LastOrDefault((T x, int i) => predicate(x), defaultValue);
	}

	/// <summary>
	/// 获取当前序列中最后一个符合条件的元素，如果没有符合条件的元素返回元素默认值 <paramref name="defaultValue" />。
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <param name="defaultValue">元素默认值</param>
	/// <returns>最后一个符合条件的元素或者元素类型的默认值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者序列元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static T LastOrDefault<T>(this IEnumerable<T> source, Func<T, int, bool> predicate, T defaultValue = default(T))
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		int index = source.Count() - 1;
		foreach (T item in source.Reverse())
		{
			if (predicate(item, index--))
			{
				return item;
			}
		}
		return defaultValue;
	}

	/// <summary>
	/// 获取当前序列中最后指定数量元素的子序列，如果序列中的元素数量不足指定的数量，则使用序列元素默认值 <paramref name="defaultValue" /> 进行填充
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="count">获取的序列元素数量</param>
	/// <param name="defaultValue">元素默认值</param>
	/// <returns>获取的子序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">获取的序列元素 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable<T> LastOrDefault<T>(this IEnumerable<T> source, int count, T defaultValue = default(T))
	{
		source.GuardNotNull("source");
		count.GuardGreaterThanOrEqualTo(0, "count");
		int total = source.Count();
		if (total >= count)
		{
			return source.Skip(total - count).Take(count);
		}
		return new T[count - total].Fill(defaultValue).Concat(source);
	}

	/// <summary>
	/// 获取当前序列中的最大值，如果当前序列为空序列则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="comparer">序列元素比较器</param>
	/// <returns>返回序列中的最大值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static T Max<T>(this IEnumerable<T> source, IComparer<T> comparer)
	{
		return source.Max(comparer.IfNull(Comparer<T>.Default).Compare);
	}

	/// <summary>
	/// 获取当前序列中的最大值，如果当前序列为空序列则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="comparison">序列元素比较方法</param>
	/// <returns>返回序列中的最大值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static T Max<T>(this IEnumerable<T> source, Func<T, T, int> comparison)
	{
		source.GuardNotNull("source");
		comparison = comparison.IfNull(Comparer<T>.Default.Compare);
		if (!source.Any())
		{
			throw new InvalidOperationException(Literals.MSG_SequenceEmpty);
		}
		T max = source.First();
		foreach (T item in source)
		{
			if (comparison(item, max) > 0)
			{
				max = item;
			}
		}
		return max;
	}

	/// <summary>
	/// 获取当前序列中的最大值，如果当前序列为空序列则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="comparer">序列元素比较器</param>
	/// <param name="defaultValue">最大值的默认值</param>
	/// <returns>返回序列中的最大值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static T MaxOrDefault<T>(this IEnumerable<T> source, IComparer<T> comparer, T defaultValue = default(T))
	{
		return source.MaxOrDefault(comparer.IfNull(Comparer<T>.Default).Compare);
	}

	/// <summary>
	/// 获取当前序列中的最大值，如果当前序列为空序列则默认值
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="comparison">序列元素比较方法</param>
	/// <param name="defaultValue">最大值的默认值</param>
	/// <returns>返回序列中的最大值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static T MaxOrDefault<T>(this IEnumerable<T> source, Func<T, T, int> comparison, T defaultValue = default(T))
	{
		source.GuardNotNull("source");
		comparison = comparison.IfNull(Comparer<T>.Default.Compare);
		if (!source.Any())
		{
			return defaultValue;
		}
		T max = source.First();
		foreach (T item in source)
		{
			if (comparison(item, max) > 0)
			{
				max = item;
			}
		}
		return max;
	}

	/// <summary>
	/// 获取当前序列中所有元素的中间值
	/// </summary>
	/// <typeparam name="T">序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <returns>返回序列中的中间值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素。</exception>
	public static T Median<T>(this IEnumerable<T> source)
	{
		return source.Median(Comparer<T>.Default);
	}

	/// <summary>
	/// 获取当前序列中所有元素的中间值
	/// </summary>
	/// <typeparam name="T">序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="comparer">序列元素比较器</param>
	/// <returns>返回序列中的中间值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素。</exception>
	public static T Median<T>(this IEnumerable<T> source, IComparer<T> comparer)
	{
		source.GuardNotNull("source");
		comparer = comparer.IfNull(Comparer<T>.Default);
		int count = source.Count();
		if (count == 0)
		{
			throw new InvalidOperationException(Literals.MSG_SequenceEmpty);
		}
		return source.OrderBy(comparer).ElementAt(count / 2);
	}

	/// <summary>
	/// 获取当前序列中所有元素的中间值
	/// </summary>
	/// <typeparam name="T">序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="comparison">序列元素比较方法</param>
	/// <returns>返回序列中的中间值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素。</exception>
	public static T Median<T>(this IEnumerable<T> source, Func<T, T, int> comparison)
	{
		return source.Median(comparison.ToComparer());
	}

	/// <summary>
	/// 获取当前序列中的最小值，如果当前序列为空序列则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="comparer">序列元素比较器</param>
	/// <returns>返回序列中的最小值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static T Min<T>(this IEnumerable<T> source, IComparer<T> comparer)
	{
		return source.Min(comparer.IfNull(Comparer<T>.Default).Compare);
	}

	/// <summary>
	/// 获取当前序列中的最小值，如果当前序列为空序列则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="comparison">序列元素比较方法</param>
	/// <returns>返回序列中的最小值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static T Min<T>(this IEnumerable<T> source, Func<T, T, int> comparison)
	{
		source.GuardNotNull("source");
		comparison = comparison.IfNull(Comparer<T>.Default.Compare);
		if (!source.Any())
		{
			throw new InvalidOperationException(Literals.MSG_SequenceEmpty);
		}
		T min = source.First();
		foreach (T item in source)
		{
			if (comparison(item, min) < 0)
			{
				min = item;
			}
		}
		return min;
	}

	/// <summary>
	/// 获取当前序列中的最小值，如果当前序列为空序列则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="comparer">序列元素比较器</param>
	/// <param name="defaultValue">最小值的默认值</param>
	/// <returns>返回序列中的最小值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static T MinOrDefault<T>(this IEnumerable<T> source, IComparer<T> comparer, T defaultValue = default(T))
	{
		return source.MinOrDefault(comparer.IfNull(Comparer<T>.Default).Compare);
	}

	/// <summary>
	/// 获取当前序列中的最小值，如果当前序列为空序列则默认值
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="comparison">序列元素比较方法</param>
	/// <param name="defaultValue">最小值的默认值</param>
	/// <returns>返回序列中的最小值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static T MinOrDefault<T>(this IEnumerable<T> source, Func<T, T, int> comparison, T defaultValue = default(T))
	{
		source.GuardNotNull("source");
		comparison = comparison.IfNull(Comparer<T>.Default.Compare);
		if (!source.Any())
		{
			return defaultValue;
		}
		T min = source.First();
		foreach (T item in source)
		{
			if (comparison(item, min) < 0)
			{
				min = item;
			}
		}
		return min;
	}

	/// <summary>
	/// 获取当前序列中出现次数最多的元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <returns>出现次数最多的元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static T Most<T>(this IEnumerable<T> source)
	{
		return source.Most(EqualityComparer<T>.Default);
	}

	/// <summary>
	/// 获取当前序列中出现次数最多的元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="equaliter">序列元素比较器</param>
	/// <returns>出现次数最多的元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static T Most<T>(this IEnumerable<T> source, IEqualityComparer<T> equaliter)
	{
		source.GuardNotNull("source");
		if (!source.Any())
		{
			throw new InvalidOperationException(Literals.MSG_SequenceEmpty);
		}
		Dictionary<T, int> bag = new Dictionary<T, int>(equaliter);
		foreach (T item in source)
		{
			if (bag.ContainsKey(item))
			{
				bag[item]++;
			}
			else
			{
				bag.Add(item, 1);
			}
		}
		return bag.Max((KeyValuePair<T, int> p1, KeyValuePair<T, int> p2) => p1.Value - p2.Value).Key;
	}

	/// <summary>
	/// 获取当前序列中出现次数最多的元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="equalition">序列元素比较方法</param>
	/// <returns>出现次数最多的元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static T Most<T>(this IEnumerable<T> source, Func<T, T, bool> equalition)
	{
		return source.Most(equalition.ToComparer());
	}

	/// <summary>
	/// 对当前序列进行升序排列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <returns>排序后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> source)
	{
		return source.OrderBy(Comparer<T>.Default);
	}

	/// <summary>
	/// 对当前序列进行升序排列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="comparer">元素排序比较器</param>
	/// <returns>排序后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> source, IComparer<T> comparer)
	{
		source.GuardNotNull("source");
		return source.OrderBy((T x) => x, comparer.IfNull(Comparer<T>.Default));
	}

	/// <summary>
	/// 对当前序列进行升序排列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="comparison">元素排序比较方法</param>
	/// <returns>排序后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> source, Func<T, T, int> comparison)
	{
		return source.OrderBy(comparison.IsNull() ? null : comparison.ToComparer());
	}

	/// <summary>
	/// 对当前序列进行升序排列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="keys">排序键选择方法</param>
	/// <returns>排序后的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者排序键选择方法为空。</exception>
	public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> source, params Func<T, object>[] keys)
	{
		source.GuardNotNull("source");
		keys.GuardNotNull("key selectors");
		IOrderedEnumerable<T> ordered = null;
		for (int i = 0; i < keys.Length; i++)
		{
			keys[i].GuardNotNull("key selector");
			ordered = ((i != 0) ? ordered.ThenBy(keys[i], Comparer<object>.Default) : source.OrderBy(keys[i], Comparer<object>.Default));
		}
		return ordered;
	}

	/// <summary>
	/// 对当前序列进行升序排列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="keys">排序键选择方法</param>
	/// <param name="comparers">排序键排序对象</param>
	/// <returns>排序后的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者排序键选择方法为空；或者排序键排序对象为空。</exception>
	public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> source, Func<T, object>[] keys, IComparer<object>[] comparers)
	{
		source.GuardNotNull("source");
		keys.GuardNotNull("key selectors");
		comparers.GuardNotNull("key comparers");
		comparers.GuardArrayLength(keys.Length, "key comparers");
		IOrderedEnumerable<T> ordered = null;
		for (int i = 0; i < keys.Length; i++)
		{
			keys[i].GuardNotNull("key selector");
			comparers[i].GuardNotNull("key comparer");
			ordered = ((i != 0) ? ordered.ThenBy(keys[i], comparers[i]) : source.OrderBy(keys[i], comparers[i]));
		}
		return ordered;
	}

	/// <summary>
	/// 对当前序列进行升序排列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="keys">排序键选择方法</param>
	/// <param name="comparisons">排序键排序方法</param>
	/// <returns>排序后的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者排序键选择方法为空；或者排序键排序方法为空。</exception>
	public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> source, Func<T, object>[] keys, Func<object, object, int>[] comparisons)
	{
		source.GuardNotNull("source");
		keys.GuardNotNull("key selectors");
		comparisons.GuardNotNull("key comparisons");
		comparisons.GuardArrayLength(keys.Length, "key comparisons");
		IOrderedEnumerable<T> ordered = null;
		for (int i = 0; i < keys.Length; i++)
		{
			keys[i].GuardNotNull("key selector");
			comparisons[i].GuardNotNull("key comparsion");
			ordered = ((i != 0) ? ordered.ThenBy(keys[i], comparisons[i].ToComparer<object>()) : source.OrderBy(keys[i], comparisons[i].ToComparer<object>()));
		}
		return ordered;
	}

	/// <summary>
	/// 对当前序列进行降序排列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <returns>排序后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<T> OrderByDescending<T>(this IEnumerable<T> source)
	{
		return source.OrderByDescending(Comparer<T>.Default);
	}

	/// <summary>
	/// 对当前序列进行降序排列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="comparer">元素排序比较器</param>
	/// <returns>排序后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<T> OrderByDescending<T>(this IEnumerable<T> source, IComparer<T> comparer)
	{
		source.GuardNotNull("source");
		return source.OrderByDescending((T x) => x, comparer.IfNull(Comparer<T>.Default));
	}

	/// <summary>
	/// 对当前序列进行降序排列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="comparison">元素排序比较方法</param>
	/// <returns>排序后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<T> OrderByDescending<T>(this IEnumerable<T> source, Func<T, T, int> comparison)
	{
		return source.OrderByDescending(comparison.IsNull() ? null : comparison.ToComparer());
	}

	/// <summary>
	/// 对当前序列进行降序排列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="keys">排序键选择方法</param>
	/// <returns>排序后的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者排序键选择方法为空。</exception>
	public static IEnumerable<T> OrderByDescending<T>(this IEnumerable<T> source, params Func<T, object>[] keys)
	{
		source.GuardNotNull("source");
		keys.GuardNotNull("key selectors");
		IOrderedEnumerable<T> ordered = null;
		for (int i = 0; i < keys.Length; i++)
		{
			keys[i].GuardNotNull("key selector");
			ordered = ((i != 0) ? ordered.ThenByDescending(keys[i], Comparer<object>.Default) : source.OrderByDescending(keys[i], Comparer<object>.Default));
		}
		return ordered;
	}

	/// <summary>
	/// 对当前序列进行降序排列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="keys">排序键选择方法</param>
	/// <param name="comparers">排序键排序对象</param>
	/// <returns>排序后的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者排序键选择方法为空；或者排序键排序对象为空。</exception>
	public static IEnumerable<T> OrderByDescending<T>(this IEnumerable<T> source, Func<T, object>[] keys, IComparer<object>[] comparers)
	{
		source.GuardNotNull("source");
		keys.GuardNotNull("key selectors");
		comparers.GuardNotNull("key comparers");
		comparers.GuardArrayLength(keys.Length, "key comparers");
		IOrderedEnumerable<T> ordered = null;
		for (int i = 0; i < keys.Length; i++)
		{
			keys[i].GuardNotNull("key selector");
			comparers[i].GuardNotNull("key comparer");
			ordered = ((i != 0) ? ordered.ThenByDescending(keys[i], comparers[i]) : source.OrderByDescending(keys[i], comparers[i]));
		}
		return ordered;
	}

	/// <summary>
	/// 对当前序列进行降序排列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="keys">排序键选择方法</param>
	/// <param name="comparisons">排序键排序方法</param>
	/// <returns>排序后的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者排序键选择方法为空；或者排序键排序方法为空。</exception>
	public static IEnumerable<T> OrderByDescending<T>(this IEnumerable<T> source, Func<T, object>[] keys, Func<object, object, int>[] comparisons)
	{
		source.GuardNotNull("source");
		keys.GuardNotNull("key selectors");
		comparisons.GuardNotNull("key comparisons");
		comparisons.GuardArrayLength(keys.Length, "key comparisons");
		IOrderedEnumerable<T> ordered = null;
		for (int i = 0; i < keys.Length; i++)
		{
			keys[i].GuardNotNull("key selector");
			comparisons[i].GuardNotNull("key comparsion");
			ordered = ((i != 0) ? ordered.ThenByDescending(keys[i], comparisons[i].ToComparer<object>()) : source.OrderByDescending(keys[i], comparisons[i].ToComparer<object>()));
		}
		return ordered;
	}

	/// <summary>
	/// 向当前序列头部添加元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="item">向序列头部添加的元素列表</param>
	/// <returns>追加了新的元素的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<T> Prepend<T>(this IEnumerable<T> source, T item)
	{
		source.GuardNotNull("source");
		yield return item;
		foreach (T item2 in source)
		{
			yield return item2;
		}
	}

	/// <summary>
	/// 向当前序列头部添加元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="items">向序列头部添加的元素列表</param>
	/// <returns>追加了新的元素的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<T> Prepend<T>(this IEnumerable<T> source, params T[] items)
	{
		return source.Prepend((IEnumerable<T>)items);
	}

	/// <summary>
	/// 向当前序列头部添加元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="items">向序列头部添加的元素列表</param>
	/// <returns>追加了新的元素的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<T> Prepend<T>(this IEnumerable<T> source, IEnumerable<T> items)
	{
		source.GuardNotNull("source");
		if (items.IsNotNull())
		{
			foreach (T item in items)
			{
				yield return item;
			}
		}
		foreach (T item2 in source)
		{
			yield return item2;
		}
	}

	/// <summary>
	/// 通过合并元素的索引将当前序列的每个元素投影到新表中
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <typeparam name="R">结果序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="selection">当前序列元素转换方法</param>
	/// <returns>映射后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者序列元素转换方法 <paramref name="selection" /> 为空。</exception>
	public static IEnumerable<R> Select<T, R>(this IEnumerable<T> source, Func<T, long, R> selection)
	{
		source.GuardNotNull("source");
		selection.GuardNotNull("selection");
		long index = 0L;
		foreach (T item in source)
		{
			yield return selection(item, index++);
		}
	}

	/// <summary>
	/// 递归获取当前序列中元素对象属性值
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="selector">属性集合选择器</param>
	/// <param name="predicate">筛选条件</param>
	/// <returns>递归的元素序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者属性集合选择方法 <paramref name="selector" /> 为空。</exception>
	public static IEnumerable<T> SelectRecursion<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> selector, Func<T, bool> predicate = null)
	{
		source.GuardNotNull("source");
		selector.GuardNotNull("selector");
		return source.SelectMany((T x) => x.Enumerate(selector, predicate));
	}

	/// <summary>
	/// 跳过当前序列中指定数量的元素，返回剩余的元素
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="count">跳过元素的数量</param>
	/// <returns>当前序列中剩余元素组成的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">跳过元素的数量 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable<T> SkipLong<T>(this IEnumerable<T> source, long count)
	{
		source.GuardNotNull("source");
		count.GuardGreaterThanOrEqualTo(0L, "count");
		long index = 0L;
		foreach (T item in source)
		{
			if (index++ >= count)
			{
				yield return item;
			}
		}
	}

	/// <summary>
	/// 从当前序列的开头返回指定数量的连续元素。
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="count">获取的元素数量</param>
	/// <returns>当前序列中剩余元素组成的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">获取的元素数量 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable<T> TakeLong<T>(this IEnumerable<T> source, long count)
	{
		source.GuardNotNull("source");
		count.GuardGreaterThanOrEqualTo(0L, "count");
		long index = 0L;
		foreach (T item in source)
		{
			if (index++ < count)
			{
				yield return item;
				continue;
			}
			break;
		}
	}

	/// <summary>
	/// 将当前序列转换为指定类型的数组
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">目标数组元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <returns>创建的指定类型的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static T[] ToArray<S, T>(this IEnumerable<S> source)
	{
		source.GuardNotNull("source");
		return source.Select((S x) => x.As<T>()).ToArray();
	}

	/// <summary>
	/// 将当前序列转换为指定类型的数组
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">目标数组元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="evaluator">序列元素转换方法</param>
	/// <returns>创建的指定类型的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者转换方法 <paramref name="evaluator" /> 为空。</exception>
	public static T[] ToArray<S, T>(this IEnumerable<S> source, Func<S, T> evaluator)
	{
		source.GuardNotNull("source");
		evaluator.GuardNotNull("evaluator");
		return source.Select(evaluator).ToArray();
	}

	/// <summary>
	/// 将当前序列转换为指定类型的数组
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">目标数组元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="evaluator">序列元素转换方法</param>
	/// <returns>创建的指定类型的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者转换方法 <paramref name="evaluator" /> 为空。</exception>
	public static T[] ToArray<S, T>(this IEnumerable<S> source, Func<S, int, T> evaluator)
	{
		source.GuardNotNull("source");
		evaluator.GuardNotNull("evaluator");
		return source.Select(evaluator).ToArray();
	}

	/// <summary>
	/// 将当前序列转换为指定类型的数组
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">目标数组元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">当前序列元素筛选条件</param>
	/// <param name="evaluator">序列元素转换方法</param>
	/// <returns>创建的指定类型的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件 <paramref name="predicate" /> 为空；或者转换方法 <paramref name="evaluator" /> 为空。</exception>
	public static T[] ToArray<S, T>(this IEnumerable<S> source, Func<S, bool> predicate, Func<S, T> evaluator)
	{
		predicate.GuardNotNull("predicate");
		evaluator.GuardNotNull("evaluator");
		return source.ToArray((S x, int i) => predicate(x), (S x, int i) => evaluator(x));
	}

	/// <summary>
	/// 将当前序列转换为指定类型的数组
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">目标数组元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">当前序列元素筛选条件</param>
	/// <param name="evaluator">序列元素转换方法</param>
	/// <returns>创建的指定类型的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件 <paramref name="predicate" /> 为空；或者转换方法 <paramref name="evaluator" /> 为空。</exception>
	public static T[] ToArray<S, T>(this IEnumerable<S> source, Func<S, int, bool> predicate, Func<S, int, T> evaluator)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		evaluator.GuardNotNull("evaluator");
		List<T> list = new List<T>();
		int index = 0;
		foreach (S item in source)
		{
			if (predicate(item, index))
			{
				list.Add(evaluator(item, index));
			}
			index++;
		}
		return list.ToArray();
	}

	/// <summary>
	/// 将当前序列转换为数据表，序列中每个对象转换为一个数据行
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <returns>映射生成的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static DataTable ToDataTable<T>(this IEnumerable<T> source)
	{
		return source.ToDataTable();
	}

	/// <summary>
	/// 将当前序列转换为数据表，序列中每个对象转换为一个数据行
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="flags">属性绑定标志</param>
	/// <returns>映射生成的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static DataTable ToDataTable<T>(this IEnumerable<T> source, BindingFlags flags)
	{
		return source.ToDataTable(flags);
	}

	/// <summary>
	/// 将当前序列转换为数据表，序列中每个对象转换为一个数据行
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="propertyNames">转换的对象属性名称列表</param>
	/// <returns>映射生成的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者转换的对象属性名称列表 <paramref name="propertyNames" /> 为空。</exception>
	/// <exception cref="T:System.MissingMemberException">指定的对象属性不存在</exception>
	public static DataTable ToDataTable<T>(this IEnumerable<T> source, params string[] propertyNames)
	{
		return source.ToDataTable(propertyNames);
	}

	/// <summary>
	/// 将当前序列转换为数据表，序列中每个对象转换为一个数据行
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="propertyNames">转换的对象属性名称列表</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <returns>映射生成的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者转换的对象属性名称列表 <paramref name="propertyNames" /> 为空。</exception>
	/// <exception cref="T:System.MissingMemberException">指定的对象属性不存在</exception>
	public static DataTable ToDataTable<T>(this IEnumerable<T> source, string[] propertyNames, bool ignoreCase = false)
	{
		return source.ToDataTable(propertyNames, ignoreCase);
	}

	/// <summary>
	/// 将当前序列转换为数据表，序列中每个对象转换为一个数据行
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="propertyNames">转换的对象属性名称列表</param>
	/// <param name="flags">属性绑定标志</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <returns>映射生成的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者转换的对象属性名称列表 <paramref name="propertyNames" /> 为空。</exception>
	/// <exception cref="T:System.MissingMemberException">指定的对象属性不存在</exception>
	public static DataTable ToDataTable<T>(this IEnumerable<T> source, string[] propertyNames, BindingFlags flags, bool ignoreCase = false)
	{
		return source.ToDataTable(propertyNames, flags, ignoreCase);
	}

	/// <summary>
	/// 将当前序列转换为数据表，序列中每个对象转换为一个数据行
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="mappings">序列元素属性到数据列的映射，序列元素属性名称支持属性路径，未设置序列元素属性则忽略</param>
	/// <param name="onlyMapping">是否只处理在映射中定义的属性</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <returns>映射生成的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者属性映射规则 <paramref name="mappings" /> 为空。</exception>
	/// <exception cref="T:System.MissingMemberException">映射中指定的序列元素属性不存在</exception>
	/// <exception cref="T:System.Data.DuplicateNameException">映射的数据列名称重复</exception>
	public static DataTable ToDataTable<T>(this IEnumerable<T> source, DataMapping[] mappings, bool onlyMapping = false, bool ignoreCase = false)
	{
		return source.ToDataTable(mappings, BindingFlags.Instance | BindingFlags.Public, onlyMapping, ignoreCase);
	}

	/// <summary>
	/// 将当前序列转换为数据表，序列中每个对象转换为一个数据行
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="mappings">序列元素属性到数据列的映射，序列元素属性名称支持属性路径，未设置序列元素属性则忽略</param>
	/// <param name="flags">属性绑定标志</param>
	/// <param name="onlyMapping">是否只处理在映射中定义的属性</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <returns>映射生成的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者属性映射规则 <paramref name="mappings" /> 为空。</exception>
	/// <exception cref="T:System.MissingMemberException">映射中指定的序列元素属性不存在</exception>
	/// <exception cref="T:System.Data.DuplicateNameException">映射的数据列名称重复</exception>
	public static DataTable ToDataTable<T>(this IEnumerable<T> source, DataMapping[] mappings, BindingFlags flags, bool onlyMapping = false, bool ignoreCase = false)
	{
		source.GuardNotNull("source");
		mappings.GuardNotNull("mappings");
		DataTable table = null;
		foreach (T item in source)
		{
			table = item.ToDataTable(mappings, flags, onlyMapping, ignoreCase, table);
		}
		return table;
	}

	/// <summary>
	/// 将当前序列转换为指定类型的数组
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">目标列表元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <returns>创建的指定类型的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static List<T> ToList<S, T>(this IEnumerable<S> source)
	{
		source.GuardNotNull("source");
		return source.Select((S x) => x.As<T>()).ToList();
	}

	/// <summary>
	/// 将当前序列转换为指定类型的数组
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">目标列表元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="evaluator">序列元素转换方法</param>
	/// <returns>创建的指定类型的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者转换方法 <paramref name="evaluator" /> 为空。</exception>
	public static List<T> ToList<S, T>(this IEnumerable<S> source, Func<S, T> evaluator)
	{
		source.GuardNotNull("source");
		evaluator.GuardNotNull("evaluator");
		return source.Select(evaluator).ToList();
	}

	/// <summary>
	/// 将当前序列转换为指定类型的数组
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">目标列表元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="evaluator">序列元素转换方法</param>
	/// <returns>创建的指定类型的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者转换方法 <paramref name="evaluator" /> 为空。</exception>
	public static List<T> ToList<S, T>(this IEnumerable<S> source, Func<S, int, T> evaluator)
	{
		source.GuardNotNull("source");
		evaluator.GuardNotNull("evaluator");
		return source.Select(evaluator).ToList();
	}

	/// <summary>
	/// 将当前序列转换为指定类型的数组
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">目标列表元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">当前序列元素筛选条件</param>
	/// <param name="evaluator">序列元素转换方法</param>
	/// <returns>创建的指定类型的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件 <paramref name="predicate" /> 为空；或者转换方法 <paramref name="evaluator" /> 为空。</exception>
	public static List<T> ToList<S, T>(this IEnumerable<S> source, Func<S, bool> predicate, Func<S, T> evaluator)
	{
		predicate.GuardNotNull("predicate");
		evaluator.GuardNotNull("evaluator");
		return source.ToList((S x, int i) => predicate(x), (S x, int i) => evaluator(x));
	}

	/// <summary>
	/// 将当前序列转换为指定类型的列表
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">目标列表元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">当前序列元素筛选条件</param>
	/// <param name="evaluator">序列元素转换方法</param>
	/// <returns>创建的指定类型的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件 <paramref name="predicate" /> 为空；或者转换方法 <paramref name="evaluator" /> 为空。</exception>
	public static List<T> ToList<S, T>(this IEnumerable<S> source, Func<S, int, bool> predicate, Func<S, int, T> evaluator)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		evaluator.GuardNotNull("evaluator");
		List<T> list = new List<T>();
		int index = 0;
		foreach (S item in source)
		{
			if (predicate(item, index))
			{
				list.Add(evaluator(item, index));
			}
			index++;
		}
		return list;
	}

	/// <summary>
	/// 将当前序列转换为集
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="equaliter">序列元素比较器</param>
	/// <returns>生成的集</returns>
	public static HashSet<T> ToSet<T>(this IEnumerable<T> source, IEqualityComparer<T> equaliter = null)
	{
		source.GuardNotNull();
		return new HashSet<T>(source, equaliter);
	}

	/// <summary>
	/// 将当前序列转换为集
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="filling">元素填充方法，当元素转换失败则调用该填充方法</param>
	/// <param name="equaliter">序列元素比较器</param>
	/// <returns>生成的集</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；集填充方法 <paramref name="filling" /> 为空。</exception>
	public static HashSet<T> ToSet<T>(this IEnumerable<T> source, Action<T, ISet<T>> filling, IEqualityComparer<T> equaliter = null)
	{
		filling.GuardNotNull("filling");
		return source.ToSet(delegate(T x, int i, ISet<T> s)
		{
			filling(x, s);
		}, equaliter);
	}

	/// <summary>
	/// 将当前序列转换为集
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="filling">元素填充方法，当元素转换失败则调用该填充方法</param>
	/// <param name="equaliter">序列元素比较器</param>
	/// <returns>生成的集</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；集填充方法 <paramref name="filling" /> 为空。</exception>
	public static HashSet<T> ToSet<T>(this IEnumerable<T> source, Action<T, int, ISet<T>> filling, IEqualityComparer<T> equaliter = null)
	{
		source.GuardNotNull("source");
		filling.GuardNotNull("filling");
		HashSet<T> set = new HashSet<T>(equaliter);
		int index = 0;
		foreach (T item in source)
		{
			if (!set.Add(item))
			{
				filling(item, index++, set);
			}
		}
		return set;
	}

	/// <summary>
	/// 将当前序列转换为集
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">目标集的元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="evaluator">序列元素转换方法</param>
	/// <param name="equaliter">序列元素比较器</param>
	/// <returns>生成的集</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素转换方法 <paramref name="evaluator" /> 为空。</exception>
	public static HashSet<T> ToSet<S, T>(this IEnumerable<S> source, Func<S, T> evaluator, IEqualityComparer<T> equaliter = null)
	{
		source.GuardNotNull("source");
		evaluator.GuardNotNull("evaluator");
		return new HashSet<T>(source.Select(evaluator), equaliter);
	}

	/// <summary>
	/// 将当前序列转换为集
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">目标集的元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="evaluator">序列元素转换方法</param>
	/// <param name="equaliter">序列元素比较器</param>
	/// <returns>生成的集</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素转换方法 <paramref name="evaluator" /> 为空。</exception>
	public static HashSet<T> ToSet<S, T>(this IEnumerable<S> source, Func<S, int, T> evaluator, IEqualityComparer<T> equaliter = null)
	{
		source.GuardNotNull("source");
		evaluator.GuardNotNull("evaluator");
		return new HashSet<T>(source.Select(evaluator), equaliter);
	}

	/// <summary>
	/// 将当前序列转换为集
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">目标集的元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="evaluator">序列元素转换方法</param>
	/// <param name="filling">元素填充方法，当元素转换失败则调用该填充方法</param>
	/// <param name="equaliter">序列元素比较器</param>
	/// <returns>生成的集</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素转换方法 <paramref name="evaluator" /> 为空；集填充方法 <paramref name="filling" /> 为空。</exception>
	public static HashSet<T> ToSet<S, T>(this IEnumerable<S> source, Func<S, T> evaluator, Action<S, ISet<T>> filling, IEqualityComparer<T> equaliter = null)
	{
		evaluator.GuardNotNull("evaluator");
		filling.GuardNotNull("filling");
		return source.ToSet((S x, int i) => evaluator(x), delegate(S x, int i, ISet<T> s)
		{
			filling(x, s);
		}, equaliter);
	}

	/// <summary>
	/// 当当前序列转换为集
	/// </summary>
	/// <typeparam name="S">当前序列元素类型</typeparam>
	/// <typeparam name="T">目标集的元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="conversion">序列元素转换方法</param>
	/// <param name="filling">元素填充方法，当元素转换失败则调用该填充方法</param>
	/// <param name="equaliter">序列元素比较器</param>
	/// <returns>生成的集</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素转换方法 <paramref name="conversion" /> 为空；集填充方法 <paramref name="filling" /> 为空。</exception>
	public static HashSet<T> ToSet<S, T>(this IEnumerable<S> source, Func<S, int, T> conversion, Action<S, int, ISet<T>> filling, IEqualityComparer<T> equaliter = null)
	{
		source.GuardNotNull("source");
		conversion.GuardNotNull("conversion");
		filling.GuardNotNull("filling");
		HashSet<T> set = new HashSet<T>(equaliter);
		int index = 0;
		foreach (S item in source)
		{
			if (item.Try((S x) => conversion(x, index), out var value).IsNull())
			{
				if (!set.Add(value))
				{
					filling(item, index, set);
				}
			}
			else
			{
				filling(item, index, set);
			}
			index++;
		}
		return set;
	}

	/// <summary>
	/// 合并当前序列和目标序列，合并后的序列中不包含重复的项目
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="target">合并的目标序列</param>
	/// <param name="equalition">序列元素相等比较方法</param>
	/// <returns>合并后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列 <paramref name="target" /> 为空。</exception>
	public static IEnumerable<T> Union<T>(this IEnumerable<T> source, IEnumerable<T> target, Func<T, T, bool> equalition)
	{
		source.GuardNotNull("source");
		target.GuardNotNull("target");
		return source.Union(target, equalition.ToComparer());
	}

	/// <summary>
	/// 合并当前序列和指多个目标序列，合并后的序列中不包含重复的项目
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="targets">合并的目标序列数组</param>
	/// <returns>合并后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列数组 <paramref name="targets" /> 为空。</exception>
	public static IEnumerable<T> Union<T>(this IEnumerable<T> source, params IEnumerable<T>[] targets)
	{
		return source.Union(targets, EqualityComparer<T>.Default);
	}

	/// <summary>
	/// 合并当前序列和指多个目标序列，合并后的序列中不包含重复的项目
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="targets">合并的目标序列集合</param>
	/// <param name="equaliter">序列元素相等比较器</param>
	/// <returns>合并后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列集合 <paramref name="targets" /> 为空。</exception>
	public static IEnumerable<T> Union<T>(this IEnumerable<T> source, IEnumerable<IEnumerable<T>> targets, IEqualityComparer<T> equaliter)
	{
		source.GuardNotNull("source");
		targets.GuardNotNull("targets");
		equaliter = equaliter.IfNull(EqualityComparer<T>.Default);
		foreach (IEnumerable<T> target in targets)
		{
			if (target.IsNotNull())
			{
				source = source.Union(target, equaliter);
			}
		}
		return source;
	}

	/// <summary>
	/// 合并当前序列和指多个目标序列，合并后的序列中不包含重复的项目
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="targets">合并的目标序列集合</param>
	/// <param name="equalition">序列元素相等比较方法</param>
	/// <returns>合并后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列集合 <paramref name="targets" /> 为空。</exception>
	public static IEnumerable<T> Union<T>(this IEnumerable<T> source, IEnumerable<IEnumerable<T>> targets, Func<T, T, bool> equalition)
	{
		return source.Union(targets, equalition.IsNull() ? null : equalition.ToComparer());
	}

	/// <summary>
	/// 对当前序列进行筛选，返回满足条件的元素组成的新序列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>当前序列满足条件组成的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者序列元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, long, bool> predicate)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		long index = 0L;
		foreach (T item in source)
		{
			if (predicate(item, index++))
			{
				yield return item;
			}
		}
	}

	/// <summary>
	/// 获取当前序列中所有不为空的元素组成的新序列
	/// </summary>
	/// <typeparam name="T">序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <returns>筛选后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T> source)
	{
		source.GuardNotNull("source");
		return source.Where((T x) => x.IsNotNull());
	}

	/// <summary>
	/// 获取当前序列中所有不为空且不为 <see cref="T:System.DBNull" /> 的元素组成的新序列
	/// </summary>
	/// <typeparam name="T">序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <returns>筛选后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<T> WhereNotNullAndDBNull<T>(this IEnumerable<T> source)
	{
		source.GuardNotNull("source");
		return source.Where((T x) => x.IsNotNullAndDBNull());
	}

	/// <summary>
	/// 获取当前序列中所有不为空且不为其类型默认值的元素组成的新序列
	/// </summary>
	/// <typeparam name="T">序列元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="defaultType">期望的元素默认值类型</param>
	/// <returns>筛选后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<T> WhereNotNullAndDefault<T>(this IEnumerable<T> source, Type defaultType = null)
	{
		source.GuardNotNull("source");
		return source.Where((T x) => x.IsNotNullAndDefault(defaultType));
	}
}
