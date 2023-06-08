using System;
using System.Collections;
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
/// <see cref="T:System.Collections.IEnumerable" /> 类扩展方法
/// </summary>
public static class IEnumerableExtensions
{
	/// <summary>
	/// 检测当前序列中的所有元素是否都满足条件
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">检测规则</param>
	/// <returns>如果所有元素都满足指定条件返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测条件 <paramref name="predicate" /> 为空。</exception>
	public static bool All(this IEnumerable source, Func<object, bool> predicate)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		foreach (object o in source)
		{
			if (!predicate(o))
			{
				return false;
			}
		}
		return true;
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否都满足条件
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">检测规则</param>
	/// <returns>如果所有元素都满足指定条件返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测条件 <paramref name="predicate" /> 为空。</exception>
	public static bool All(this IEnumerable source, Func<object, int, bool> predicate)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		int index = 0;
		foreach (object o in source)
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
	/// <param name="source">当前序列</param>
	/// <param name="predicate">检测规则</param>
	/// <returns>如果所有元素都不满足指定条件返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测条件 <paramref name="predicate" /> 为空。</exception>
	public static bool AllNot(this IEnumerable source, Func<object, bool> predicate)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		foreach (object o in source)
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
	/// <param name="source">当前序列</param>
	/// <param name="predicate">检测规则</param>
	/// <returns>如果所有元素都不满足指定条件返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测条件 <paramref name="predicate" /> 为空。</exception>
	public static bool AllNot(this IEnumerable source, Func<object, int, bool> predicate)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		int index = 0;
		foreach (object o in source)
		{
			if (predicate(o, index++))
			{
				return false;
			}
		}
		return true;
	}

	/// <summary>
	/// 检测当前序列中是否包含元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <returns>如果当前序列包含元素返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static bool Any(this IEnumerable source)
	{
		source.GuardNotNull("source");
		IEnumerator enumerator = source.GetEnumerator();
		try
		{
			if (enumerator.MoveNext())
			{
				object o = enumerator.Current;
				return true;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return false;
	}

	/// <summary>
	/// 检测当前序列中是否有任意一个元素满足指定条件
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">检测条件</param>
	/// <returns>如果有任意一个元素满足指定条件则返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测条件 <paramref name="predicate" /> 为空。</exception>
	public static bool Any(this IEnumerable source, Func<object, bool> predicate)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		foreach (object o in source)
		{
			if (predicate(o))
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 检测当前序列中是否有任意一个元素满足指定条件
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">检测条件</param>
	/// <returns>如果有任意一个元素满足指定条件则返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测条件 <paramref name="predicate" /> 为空。</exception>
	public static bool Any(this IEnumerable source, Func<object, int, bool> predicate)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		int index = 0;
		foreach (object o in source)
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
	/// <param name="source">当前序列</param>
	/// <param name="predicate">检测条件</param>
	/// <returns>如果有任意一个元素不满足指定条件则返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测条件 <paramref name="predicate" /> 为空。</exception>
	public static bool AnyNot(this IEnumerable source, Func<object, bool> predicate)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		foreach (object o in source)
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
	/// <param name="source">当前序列</param>
	/// <param name="predicate">检测条件</param>
	/// <returns>如果有任意一个元素不满足指定条件则返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测条件 <paramref name="predicate" /> 为空。</exception>
	public static bool AnyNot(this IEnumerable source, Func<object, int, bool> predicate)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		int index = 0;
		foreach (object o in source)
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
	/// <param name="source">当前序列</param>
	/// <param name="item">向序列尾部添加的元素</param>
	/// <returns>追加了新的元素的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable Append(this IEnumerable source, object item)
	{
		source.GuardNotNull("source");
		foreach (object item2 in source)
		{
			yield return item2;
		}
		yield return item;
	}

	/// <summary>
	/// 向当前序列尾部添加元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="items">向序列尾部添加的元素数组</param>
	/// <returns>追加了新的元素的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable Append(this IEnumerable source, params object[] items)
	{
		return source.Append((IEnumerable)items);
	}

	/// <summary>
	/// 向当前序列尾部添加元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="items">向序列尾部添加的元素序列</param>
	/// <returns>追加了新的元素的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable Append(this IEnumerable source, IEnumerable items)
	{
		source.GuardNotNull("source");
		foreach (object item in source)
		{
			yield return item;
		}
		if (!items.IsNotNull())
		{
			yield break;
		}
		foreach (object item2 in items)
		{
			yield return item2;
		}
	}

	/// <summary>
	/// 比较当前序列与指定序列是否相等，如果两个序列元素数量相同且每个序列元素都相等则为true
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="target">比较的目标序列</param>
	/// <param name="equalition">元素相等比较方法</param>
	/// <returns>两个源序列的长度相等，且其相应元素相等，则为 true；否则为 false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列为空。</exception>
	public static bool AreEqualTo(this IEnumerable source, IEnumerable target, Func<object, object, bool> equalition = null)
	{
		source.GuardNotNull("source");
		target.GuardNotNull("target");
		return source.OfType<object>().AreEqualTo(target.OfType<object>(), equalition);
	}

	/// <summary>
	/// 比较当前序列是否大于目标序列，当前序列的每个元素都大于目标序列相应的元素则返回true，或者当前序列元素个数大于目标序列的元素个数返回true。
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="target">比较的目标序列</param>
	/// <param name="comparison">元素大小比较方法</param>
	/// <returns>如果当前序列的每个元素都大于目标序列相应的元素则返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列为空。</exception>
	public static bool AreGreaterThan(this IEnumerable source, IEnumerable target, Func<object, object, int> comparison = null)
	{
		source.GuardNotNull("source");
		target.GuardNotNull("target");
		return source.OfType<object>().AreGreaterThan(target.OfType<object>(), comparison);
	}

	/// <summary>
	/// 比较当前序列是否大于或者等于目标序列，当前序列的每个元素都大于或等于目标序列相应的元素则返回true，或者当前序列元素个数大于等于目标序列的元素个数返回true。
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="target">比较的目标序列</param>
	/// <param name="comparison">元素大小比较方法</param>
	/// <returns>如果当前序列的每个元素都大于或等于目标序列相应的元素则返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列为空。</exception>
	public static bool AreGreaterThanOrEqualTo(this IEnumerable source, IEnumerable target, Func<object, object, int> comparison = null)
	{
		source.GuardNotNull("source");
		target.GuardNotNull("target");
		return source.OfType<object>().AreGreaterThanOrEqualTo(target.OfType<object>(), comparison);
	}

	/// <summary>
	/// 比较当前序列是否小于目标序列，当前序列的每个元素都小于目标序列相应的元素则返回true，或者当前序列元素个数小于目标序列的元素个数返回true。
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="target">比较的目标序列</param>
	/// <param name="comparison">元素大小比较方法</param>
	/// <returns>如果当前序列的每个元素都小于目标序列相应的元素则返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列为空。</exception>
	public static bool AreLessThan(this IEnumerable source, IEnumerable target, Func<object, object, int> comparison = null)
	{
		source.GuardNotNull("source");
		target.GuardNotNull("target");
		return source.OfType<object>().AreLessThan(target.OfType<object>(), comparison);
	}

	/// <summary>
	/// 比较当前序列是否小于或者等于目标序列，当前序列的每个元素都小于或者等于目标序列相应的元素则返回true
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="target">比较的目标序列</param>
	/// <param name="comparison">元素大小比较方法</param>
	/// <returns>如果当前序列的每个元素都小于或者等于目标序列相应的元素则返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列为空。</exception>
	public static bool AreLessThanOrEqualTo(this IEnumerable source, IEnumerable target, Func<object, object, int> comparison = null)
	{
		source.GuardNotNull("source");
		target.GuardNotNull("target");
		return source.OfType<object>().AreLessThanOrEqualTo(target.OfType<object>(), comparison);
	}

	/// <summary>
	/// 将任意实现了 <see cref="T:System.Collections.IEnumerable" /> 接口的集合，作为该接口返回。
	/// </summary>
	/// <param name="items">实现了 <see cref="T:System.Collections.IEnumerable" /> 接口的集合</param>
	/// <returns><see cref="T:System.Collections.IEnumerable" /> 接口类型的序列</returns>
	public static IEnumerable AsEnumerable(IEnumerable items)
	{
		return items;
	}

	/// <summary>
	/// 将当前非泛型序列转换为泛型序列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待转换的序列</param>
	/// <param name="conversion">序列元素转换方法</param>
	/// <returns>转换后的泛型序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者转换方法 <paramref name="conversion" /> 为空。</exception>
	public static IEnumerable<T> Cast<T>(this IEnumerable source, Func<object, T> conversion)
	{
		source.GuardNotNull("source");
		conversion.GuardNotNull("conversion");
		return source.OfType<object>().Select(conversion);
	}

	/// <summary>
	/// 将当前非泛型序列转换为泛型序列
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="source">当前待转换的序列</param>
	/// <param name="conversion">序列元素转换方法</param>
	/// <returns>转换后的泛型序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者转换方法 <paramref name="conversion" /> 为空。</exception>
	public static IEnumerable<T> Cast<T>(this IEnumerable source, Func<object, int, T> conversion)
	{
		source.GuardNotNull("source");
		conversion.GuardNotNull("conversion");
		return source.OfType<object>().Select(conversion);
	}

	/// <summary>
	/// 将当前序列与给定序列进行连接，返回连接后的新序列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="list">待连接的子序列列表</param>
	/// <returns>连接后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable ConcatObject(this IEnumerable source, IEnumerable list)
	{
		source.GuardNotNull("source");
		foreach (object item in source)
		{
			yield return item;
		}
		if (!list.IsNotNull())
		{
			yield break;
		}
		foreach (object item2 in list)
		{
			yield return item2;
		}
	}

	/// <summary>
	/// 将当前序列与多个给定序列进行连接，返回连接后的新序列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="lists">待连接的子序列列表</param>
	/// <returns>连接后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable ConcatObject(this IEnumerable source, params IEnumerable[] lists)
	{
		return source.ConcatObject((IEnumerable<IEnumerable>)lists);
	}

	/// <summary>
	/// 将当前序列与多个给定序列进行连接，返回连接后的新序列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="lists">待连接的子序列列表</param>
	/// <returns>连接后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable ConcatObject(this IEnumerable source, IEnumerable<IEnumerable> lists)
	{
		source.GuardNotNull("source");
		foreach (object item in source)
		{
			yield return item;
		}
		if (!lists.IsNotNull())
		{
			yield break;
		}
		foreach (IEnumerable list in lists)
		{
			foreach (object item2 in list)
			{
				yield return item2;
			}
		}
	}

	/// <summary>
	/// 检测当前序列中是否包含指定的元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="value">待检测的元素</param>
	/// <param name="equalition">元素相等比较方法</param>
	/// <returns>如果当前序列中包含指定的元素返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static bool Contains(this IEnumerable source, object value, Func<object, object, bool> equalition = null)
	{
		source.GuardNotNull("source");
		return source.OfType<object>().Contains(value, equalition);
	}

	/// <summary>
	/// 检测当前的序列是否包含指定的全部元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="items">待检测的元素数组</param>
	/// <returns>如果当前序列中包含指定的全部元素返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者待检测的元素数组 <paramref name="items" /> 为空。</exception>
	public static bool ContainsAll(this IEnumerable source, params object[] items)
	{
		return source.ContainsAll(items, null);
	}

	/// <summary>
	/// 检测当前的序列是否包含指定的全部元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="items">待检测的元素序列</param>
	/// <param name="equalition">元素相等比较方法</param>
	/// <returns>如果当前序列中包含指定的全部元素返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者待检测的元素序列 <paramref name="items" /> 为空。</exception>
	public static bool ContainsAll(this IEnumerable source, IEnumerable items, Func<object, object, bool> equalition = null)
	{
		source.GuardNotNull("source");
		items.GuardNotNull("items");
		equalition = equalition.IfNull(ObjectExtensions.ObjectEquals);
		foreach (object item in items)
		{
			Func<object, bool> predicate = (object x) => equalition(x, item);
			if (!source.Any(predicate))
			{
				return false;
			}
		}
		return true;
	}

	/// <summary>
	/// 检测当前的序列中是否包含指定的任意一个元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="items">待检测的元素数组</param>
	/// <returns>如果当前序列中包含指定的元素中的任意一个返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者待检测的元素数组 <paramref name="items" /> 为空。</exception>
	public static bool ContainsAny(this IEnumerable source, params object[] items)
	{
		return source.ContainsAny(items, null);
	}

	/// <summary>
	/// 检测当前的序列中是否包含指定的任意一个元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="items">待检测的元素序列</param>
	/// <param name="equalition">序列元素相等比较方法</param>
	/// <returns>如果当前序列中包含指定的元素中的任意一个返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者待检测的元素序列 <paramref name="items" /> 为空。</exception>
	public static bool ContainsAny(this IEnumerable source, IEnumerable items, Func<object, object, bool> equalition = null)
	{
		source.GuardNotNull("source");
		items.GuardNotNull("items");
		equalition = equalition.IfNull(ObjectExtensions.ObjectEquals);
		foreach (object item in items)
		{
			Func<object, bool> predicate = (object x) => equalition(x, item);
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
	/// <param name="source">当前序列</param>
	/// <param name="array">目标数组</param>
	/// <param name="copying">元素复制方法；如果为空，则仅复制元素的引用</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标数组 <paramref name="array" /> 为空。</exception>
	public static void CopyTo(this IEnumerable source, object[] array, Func<object, object> copying = null)
	{
		source.CopyTo(array, 0, copying);
	}

	/// <summary>
	/// 将当前序列中的元素复制到目标数组中
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="array">目标数组</param>
	/// <param name="start">目标数组开始复制的位置</param>
	/// <param name="copying">元素复制方法；如果为空，则仅复制元素的引用</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标数组 <paramref name="array" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">目标数组起始复制位置 <paramref name="start" /> 小于0，或者大于目标数组的最大索引。</exception>
	public static void CopyTo(this IEnumerable source, object[] array, int start, Func<object, object> copying = null)
	{
		source.GuardNotNull("source");
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "array start");
		copying = copying.IfNull((object x) => x);
		foreach (object o in source)
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
	/// <typeparam name="V">目标数组元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="array">目标数组</param>
	/// <param name="copying">复制元素方法；如果为空，则进行默认转换</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标数组 <paramref name="array" /> 为空。</exception>
	public static void CopyTo<V>(this IEnumerable source, V[] array, Func<object, V> copying = null)
	{
		source.CopyTo(array, 0, copying);
	}

	/// <summary>
	/// 将当前序列中的元素复制到目标数组中
	/// </summary>
	/// <typeparam name="V">目标数组元素类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="array">目标数组</param>
	/// <param name="start">目标数组开始复制的位置</param>
	/// <param name="copying">复制元素方法；如果为空，则进行默认转换</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标数组 <paramref name="array" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">目标数组起始复制位置 <paramref name="start" /> 小于0，或者大于目标数组的最大索引。</exception>
	public static void CopyTo<V>(this IEnumerable source, V[] array, int start, Func<object, V> copying = null)
	{
		source.GuardNotNull("source");
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "array start");
		copying = copying.IfNull((object x) => (V)x);
		foreach (object o in source)
		{
			if (start >= array.Length)
			{
				break;
			}
			array[start++] = copying(o);
		}
	}

	/// <summary>
	/// 返回当前非泛型序列中元素的个数
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <returns>序列中元素的个数</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static int CountObject(this IEnumerable source)
	{
		source.GuardNotNull("source");
		return source.OfType<object>().Count();
	}

	/// <summary>
	/// 返回当前非泛型序列中元素的个数
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>序列中元素的个数</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者序列元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static int CountObject(this IEnumerable source, Func<object, bool> predicate)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		return source.OfType<object>().Count(predicate);
	}

	/// <summary>
	/// 返回当前非泛型序列中元素的个数
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>序列中元素的个数</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者序列元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static int CountObject(this IEnumerable source, Func<object, int, bool> predicate)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		int index = 0;
		return source.OfType<object>().Count((object x) => predicate(x, index++));
	}

	/// <summary>
	/// 返回当前序列中非重复的元素组成的序列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="equalition">元素相等比较方法</param>
	/// <returns>筛选后的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable DistinctObject(this IEnumerable source, Func<object, object, bool> equalition = null)
	{
		source.GuardNotNull("source");
		equalition = equalition.IfNull(ObjectExtensions.ObjectEquals);
		return source.OfType<object>().Distinct(equalition.ToComparer<object>());
	}

	/// <summary>
	/// 获取当前序列中指定位置的元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="index">获取的元素索引</param>
	/// <returns>当前序列指定位置的元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">指定的元素索引 <paramref name="index" /> 小于0。</exception>
	public static object ObjectAt(this IEnumerable source, int index)
	{
		source.GuardNotNull("source");
		index.GuardIndexLowBound(0, "index");
		long current = 0L;
		foreach (object item in source)
		{
			if (current++ == index)
			{
				return item;
			}
		}
		throw new IndexOutOfRangeException(Literals.MSG_IndexOutOfRange_1.FormatValue(index));
	}

	/// <summary>
	/// 获取当前序列中指定位置的元素，如果指定位置的值不存在则返回元素默认值 <paramref name="defaultValue" />
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="index">获取的元素索引</param>
	/// <param name="defaultValue">元素默认值</param>
	/// <returns>当前序列指定位置的元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">指定的元素索引 <paramref name="index" /> 小于0。</exception>
	public static object ObjectAtOrDefault(this IEnumerable source, int index, object defaultValue = null)
	{
		source.GuardNotNull("source");
		index.GuardIndexLowBound(0, "index");
		long current = 0L;
		foreach (object item in source)
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
	/// <typeparam name="T">计算结果类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="initValue">计算初始值</param>
	/// <param name="evaluator">计算方法</param>
	/// <returns>计算结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者计算方法 <paramref name="evaluator" /> 为空。</exception>
	public static T Evaluate<T>(this IEnumerable source, T initValue, Func<object, T, T> evaluator)
	{
		source.GuardNotNull("source");
		return source.OfType<T>().Evaluate(initValue, evaluator);
	}

	/// <summary>
	/// 对当前序列进行计算
	/// </summary>
	/// <typeparam name="T">计算结果类型</typeparam>
	/// <param name="source">当前序列</param>
	/// <param name="initValue">计算初始值</param>
	/// <param name="evaluator">计算方法</param>
	/// <returns>计算结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者计算方法 <paramref name="evaluator" /> 为空。</exception>
	public static T Evaluate<T>(this IEnumerable source, T initValue, Func<object, int, T, T> evaluator)
	{
		source.GuardNotNull("source");
		return source.OfType<T>().Evaluate(initValue, evaluator);
	}

	/// <summary>
	/// 从当前序列中排除与给定值匹配的元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="items">排除的元素值数组</param>
	/// <returns>处理后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable Except(this IEnumerable source, params object[] items)
	{
		return source.Except(items, null);
	}

	/// <summary>
	/// 从当前序列中排除与给定值匹配的元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="items">排除的元素值序列</param>
	/// <param name="equalition">序列元素比较方法</param>
	/// <returns>处理后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable Except(this IEnumerable source, IEnumerable items, Func<object, object, bool> equalition = null)
	{
		source.GuardNotNull("source");
		items.GuardNotNull("items");
		foreach (object o in source)
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
	/// <param name="source">当前序列</param>
	/// <param name="predicate">检测条件</param>
	/// <returns>如果存在符合条件的元素返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测条件 <paramref name="predicate" /> 为空。</exception>
	public static bool Exists(this IEnumerable source, Func<object, bool> predicate)
	{
		source.GuardNotNull("source");
		return source.OfType<object>().Exists(predicate);
	}

	/// <summary>
	/// 检测当前序列中是否存在满足检测条件的元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">检测条件</param>
	/// <returns>如果存在符合条件的元素返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测条件 <paramref name="predicate" /> 为空。</exception>
	public static bool Exists(this IEnumerable source, Func<object, int, bool> predicate)
	{
		source.GuardNotNull("source");
		return source.OfType<object>().Exists(predicate);
	}

	/// <summary>
	/// 在当前序列中查找与指定条件匹配的元素，如果未找到匹配的元素则抛出异常
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>找到的匹配元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">未找到匹配的元素。</exception>
	public static object Find(this IEnumerable source, Func<object, bool> predicate)
	{
		predicate.GuardNotNull("predicate");
		return source.Find((object x, int i) => predicate(x));
	}

	/// <summary>
	/// 在当前序列中查找与指定条件匹配的元素，如果未找到匹配的元素则抛出异常
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <param name="defaultValue">如果无法找到匹配的元素，则返回该默认值</param>
	/// <returns>找到的匹配元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static object Find(this IEnumerable source, Func<object, bool> predicate, object defaultValue)
	{
		predicate.GuardNotNull("predicate");
		return source.Find((object x, int i) => predicate(x), defaultValue);
	}

	/// <summary>
	/// 在当前序列中查找与指定条件匹配的元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>找到的匹配元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">未找到匹配的元素。</exception>
	public static object Find(this IEnumerable source, Func<object, int, bool> predicate)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		int index = 0;
		foreach (object item in source)
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
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <param name="defaultValue">如果无法找到匹配的元素，则返回该默认值</param>
	/// <returns>找到的匹配元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static object Find(this IEnumerable source, Func<object, int, bool> predicate, object defaultValue)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		int index = 0;
		foreach (object item in source)
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
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>满足条件的元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件为空。</exception>
	public static object[] FindAll(this IEnumerable source, Func<object, bool> predicate)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		return source.OfType<object>().Where(predicate).ToArray();
	}

	/// <summary>
	/// 在当前序列中查找满足指定条件的元素，并返回匹配的元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>满足条件的元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件为空。</exception>
	public static object[] FindAll(this IEnumerable source, Func<object, int, bool> predicate)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		return source.OfType<object>().Where(predicate).ToArray();
	}

	/// <summary>
	/// 获取在当前序列中第一个符合指定条件的元素在序列中的索引位置
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">筛选条件</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	public static int FindIndex(this IEnumerable source, Func<object, bool> predicate)
	{
		predicate.GuardNotNull("predicate");
		return source.FindIndex((object x, int i) => predicate(x));
	}

	/// <summary>
	/// 获取在当前序列第一个符合指定条件的元素在序列中的索引位置
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">筛选条件</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件为空。</exception>
	public static int FindIndex(this IEnumerable source, Func<object, int, bool> predicate)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		int index = 0;
		foreach (object item in source)
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
	/// <param name="source">当前序列</param>
	/// <param name="start">从零开始的搜索的起始索引</param>
	/// <param name="predicate">筛选条件</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">搜索的起始位置小于0。</exception>
	public static int FindIndex(this IEnumerable source, int start, Func<object, bool> predicate)
	{
		predicate.GuardNotNull("predicate");
		return source.FindIndex(start, (object x, int i) => predicate(x));
	}

	/// <summary>
	/// 获取在当前序列第一个符合指定条件的元素在序列中的索引位置
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="start">从零开始的搜索的起始索引</param>
	/// <param name="predicate">筛选条件</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">搜索的起始位置小于0。</exception>
	public static int FindIndex(this IEnumerable source, int start, Func<object, int, bool> predicate)
	{
		source.GuardNotNull("source");
		start.GuardIndexLowBound(0, "start");
		predicate.GuardNotNull("predicate");
		foreach (object o in source.SkipObject(start))
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
	/// <param name="source">当前序列</param>
	/// <param name="start">从零开始的搜索的起始索引</param>
	/// <param name="count">要搜索的部分中的元素数</param>
	/// <param name="predicate">筛选条件</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">搜索的起始位置小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">搜索的元素数量小于0。</exception>
	public static int FindIndex(this IEnumerable source, int start, int count, Func<object, bool> predicate)
	{
		predicate.GuardNotNull("predicate");
		return source.FindIndex(start, count, (object x, int i) => predicate(x));
	}

	/// <summary>
	/// 获取在当前序列第一个符合指定条件的元素在序列中的索引位置
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="start">从零开始的搜索的起始索引</param>
	/// <param name="count">要搜索的部分中的元素数</param>
	/// <param name="predicate">筛选条件</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">搜索的起始位置小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">搜索的元素数量小于0。</exception>
	public static int FindIndex(this IEnumerable source, int start, int count, Func<object, int, bool> predicate)
	{
		source.GuardNotNull("source");
		start.GuardIndexLowBound(0, "start");
		count.GuardGreaterThanOrEqualTo(0, "count");
		predicate.GuardNotNull("predicate");
		int end = start + count;
		foreach (object o in source.SkipObject(start))
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
	/// 获取当前序列中第一个元素，如果序列为空则抛出异常
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <returns>当前序列的第一个元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素。</exception>
	public static object FirstObject(this IEnumerable source)
	{
		source.GuardNotNull("source");
		IEnumerator enumerator = source.GetEnumerator();
		try
		{
			if (enumerator.MoveNext())
			{
				return enumerator.Current;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		throw new InvalidOperationException(Literals.MSG_SequenceEmpty);
	}

	/// <summary>
	/// 获取当前序列中符合条件的第一个元素，如果不存在则抛出异常。
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">元素筛选条件</param>
	/// <returns>当前序列中符合条件的第一个元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列没有符合条件的元素。</exception>
	public static object FirstObject(this IEnumerable source, Func<object, bool> predicate)
	{
		return source.FirstObject((object x, int i) => predicate(x));
	}

	/// <summary>
	/// 获取当前序列中符合条件的第一个元素，如果不存在则抛出异常。
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">元素筛选条件</param>
	/// <returns>当前序列中符合条件的第一个元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列没有符合条件的元素。</exception>
	public static object FirstObject(this IEnumerable source, Func<object, int, bool> predicate)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		int index = 0;
		foreach (object o in source)
		{
			if (predicate(o, index++))
			{
				return o;
			}
		}
		throw new InvalidOperationException(Literals.MSG_SequenceNotElementInPredicate);
	}

	/// <summary>
	/// 获取当前序列中从头部开始指定数量的元素，如果序列中存在的元素不足，则只返回序列中存在的元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="count">子序列元素的数量</param>
	/// <returns>选取的子序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">获取的元素数量 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable FirstObject(this IEnumerable source, int count)
	{
		source.GuardNotNull("source");
		count.GuardGreaterThanOrEqualTo(0, "count");
		return source.TakeObject(count);
	}

	/// <summary>
	/// 获取当前序列中第一个元素，如果序列为空则返回 <paramref name="defaultValue" /> 指定的默认值
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="defaultValue">元素默认值</param>
	/// <returns>当前序列的第一个元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static object FirstObjectOrDefault(this IEnumerable source, object defaultValue = null)
	{
		source.GuardNotNull("source");
		IEnumerator enumerator = source.GetEnumerator();
		try
		{
			if (enumerator.MoveNext())
			{
				return enumerator.Current;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return defaultValue;
	}

	/// <summary>
	/// 获取当前序列中符合条件的第一个元素，如果序列为空则返回 <paramref name="defaultValue" /> 指定的默认值
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">元素筛选条件</param>
	/// <param name="defaultValue">元素默认值</param>
	/// <returns>当前序列中符合条件的第一个元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static object FirstObjectOrDefault(this IEnumerable source, Func<object, bool> predicate, object defaultValue = null)
	{
		predicate.GuardNotNull("predicate");
		return source.FirstObjectOrDefault((object x, int i) => predicate(x), defaultValue);
	}

	/// <summary>
	/// 获取当前序列中符合条件的第一个元素，如果序列为空则返回 <paramref name="defaultValue" /> 指定的默认值
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">元素筛选条件</param>
	/// <param name="defaultValue">元素默认值</param>
	/// <returns>当前序列中符合条件的第一个元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static object FirstObjectOrDefault(this IEnumerable source, Func<object, int, bool> predicate, object defaultValue = null)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		int index = 0;
		foreach (object o in source)
		{
			if (predicate(o, index++))
			{
				return o;
			}
		}
		return defaultValue;
	}

	/// <summary>
	/// 获取当前序列中从开始指定数量元素的子序列，如果序列中的元素数量不足指定的数量，则使用序列元素默认值 <paramref name="defaultValue" /> 进行填充
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="count">获取的序列元素数量</param>
	/// <param name="defaultValue">元素默认值</param>
	/// <returns>获取的子序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">获取的序列元素 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable FirstObjectOrDefault(this IEnumerable source, int count, object defaultValue = null)
	{
		source.GuardNotNull("source");
		count.GuardGreaterThanOrEqualTo(0, "count");
		int index = 0;
		foreach (object item in source)
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
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	public static void For(this IEnumerable source, Action<int> action)
	{
		source.GuardNotNull("source");
		action.GuardNotNull("action");
		int index = 0;
		foreach (object item in source)
		{
			action(index++);
		}
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static void For(this IEnumerable source, Action<int> action, int count)
	{
		source.GuardNotNull("source");
		action.GuardNotNull("action");
		count.GuardGreaterThanOrEqualTo(0, "count");
		int index = 0;
		foreach (object item in source)
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
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理的索引 <paramref name="start" /> 为空。</exception>
	public static void For(this IEnumerable source, int start, Action<int> action)
	{
		source.GuardNotNull("source");
		start.GuardGreaterThanOrEqualTo(0, "start");
		action.GuardNotNull("action");
		foreach (object item in source.SkipObject(start))
		{
			action(start++);
		}
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理的索引 <paramref name="start" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static void For(this IEnumerable source, int start, int count, Action<int> action)
	{
		source.GuardNotNull("source");
		start.GuardIndexLowBound(0, "start");
		count.GuardGreaterThanOrEqualTo(0, "count");
		action.GuardNotNull("action");
		int end = start + count;
		foreach (object item in source.SkipObject(start))
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
	/// <param name="source">当前序列为空</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	public static void ForEach(this IEnumerable source, Action<object> action)
	{
		action.GuardNotNull("action");
		source.ForEach(delegate(object x, int i)
		{
			action(x);
		});
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static void ForEach(this IEnumerable source, Action<object> action, int count)
	{
		action.GuardNotNull("action");
		source.ForEach(delegate(object x, int i)
		{
			action(x);
		}, count);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理的索引 <paramref name="start" /> 为空。</exception>
	public static void ForEach(this IEnumerable source, int start, Action<object> action)
	{
		action.GuardNotNull("action");
		source.ForEach(start, delegate(object x, int i)
		{
			action(x);
		});
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理的索引 <paramref name="start" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static void ForEach(this IEnumerable source, int start, int count, Action<object> action)
	{
		action.GuardNotNull("action");
		source.ForEach(start, count, delegate(object x, int i)
		{
			action(x);
		});
	}

	/// <summary>
	/// 对当前序列中的每个元素执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	public static void ForEach(this IEnumerable source, Action<object, int> action)
	{
		source.GuardNotNull("source");
		action.GuardNotNull("action");
		int index = 0;
		foreach (object item in source)
		{
			action(item, index++);
		}
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static void ForEach(this IEnumerable source, Action<object, int> action, int count)
	{
		source.GuardNotNull("source");
		action.GuardNotNull("action");
		count.GuardGreaterThanOrEqualTo(0, "count");
		int index = 0;
		foreach (object item in source)
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
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理的索引 <paramref name="start" /> 为空。</exception>
	public static void ForEach(this IEnumerable source, int start, Action<object, int> action)
	{
		source.GuardNotNull("source");
		start.GuardGreaterThanOrEqualTo(0, "start");
		action.GuardNotNull("action");
		foreach (object item in source.SkipObject(start))
		{
			action(item, start++);
		}
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者元素执行方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理的索引 <paramref name="start" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static void ForEach(this IEnumerable source, int start, int count, Action<object, int> action)
	{
		source.GuardNotNull("source");
		start.GuardIndexLowBound(0, "start");
		count.GuardGreaterThanOrEqualTo(0, "count");
		action.GuardNotNull("action");
		int end = start + count;
		foreach (object item in source.SkipObject(start))
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
	/// <param name="source">当前待处理的序列</param>
	/// <param name="evaluator">处理函数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluator" /> 为空。</exception>
	public static IEnumerable ForEval(this IEnumerable source, Func<int, object> evaluator)
	{
		return source.OfType<object>().ForEval(evaluator);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素索引执行指定的函数，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="evaluator">处理函数</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable ForEval(this IEnumerable source, Func<int, object> evaluator, int count)
	{
		return source.OfType<object>().ForEval(evaluator, count);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素索引执行指定的函数，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="evaluator">处理函数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluator" /> 为空。</exception>
	public static IEnumerable ForEval(this IEnumerable source, int start, Func<int, object> evaluator)
	{
		return source.OfType<object>().ForEval(start, evaluator);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素索引执行指定的函数，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="evaluator">处理函数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理的索引 <paramref name="start" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable ForEval(this IEnumerable source, int start, int count, Func<int, object> evaluator)
	{
		return source.OfType<object>().ForEval(start, count, evaluator);
	}

	/// <summary>
	/// 对当前序列中的每个元素执行指定的函数操作，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="evaluator">处理函数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluator" /> 为空。</exception>
	public static IEnumerable ForEachEval(this IEnumerable source, Func<object, object> evaluator)
	{
		return source.OfType<object>().ForEachEval(evaluator);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的函数，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="evaluator">处理函数</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable ForEachEval(this IEnumerable source, Func<object, object> evaluator, int count)
	{
		return source.OfType<object>().ForEachEval(evaluator, count);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的函数，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="evaluator">处理函数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理的索引 <paramref name="start" /> 为空。</exception>
	public static IEnumerable ForEachEval(this IEnumerable source, int start, Func<object, object> evaluator)
	{
		return source.OfType<object>().ForEachEval(start, evaluator);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的函数，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="evaluator">处理函数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理的索引 <paramref name="start" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable ForEachEval(this IEnumerable source, int start, int count, Func<object, object> evaluator)
	{
		return source.OfType<object>().ForEachEval(start, count, evaluator);
	}

	/// <summary>
	/// 对当前序列中的每个元素执行指定的函数操作，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="evaluator">处理函数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluator" /> 为空。</exception>
	public static IEnumerable ForEachEval(this IEnumerable source, Func<object, int, object> evaluator)
	{
		return source.OfType<object>().ForEachEval(evaluator);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的函数，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="evaluator">处理函数</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable ForEachEval(this IEnumerable source, Func<object, int, object> evaluator, int count)
	{
		return source.OfType<object>().ForEachEval(evaluator, count);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的函数，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="evaluator">处理函数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluator" /> 为空。</exception>
	public static IEnumerable ForEachEval(this IEnumerable source, int start, Func<object, int, object> evaluator)
	{
		return source.OfType<object>().ForEachEval(start, evaluator);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的函数，并把每个元素执行的函数的返回值组成新的序列返回
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="evaluator">处理函数</param>
	/// <returns>函数返回值组成新的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者处理函数 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理的索引 <paramref name="start" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable ForEachEval(this IEnumerable source, int start, int count, Func<object, int, object> evaluator)
	{
		return source.OfType<object>().ForEachEval(start, count, evaluator);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel(this IEnumerable source, Action<int> action, ParallelOptions options = null)
	{
		return source.OfType<object>().ForParallel(action, options);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel(this IEnumerable source, Action<long> action, ParallelOptions options = null)
	{
		return source.OfType<object>().ForParallel(action, options);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel(this IEnumerable source, Action<int, ParallelLoopState> action, ParallelOptions options = null)
	{
		return source.OfType<object>().ForParallel(action, options);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel(this IEnumerable source, Action<long, ParallelLoopState> action, ParallelOptions options = null)
	{
		return source.OfType<object>().ForParallel(action, options);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="func">对每个元素索引执行的操作方法</param>
	/// <param name="initializer">操作间变量的初始化方法</param>
	/// <param name="finalizer">操作间变量的清理方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="func" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel(this IEnumerable source, Func<int, ParallelLoopState, object, object> func, Func<object> initializer = null, Action<object> finalizer = null, ParallelOptions options = null)
	{
		return source.OfType<object>().ForParallel(func, initializer, finalizer, options);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="func">对每个元素索引执行的操作方法</param>
	/// <param name="initializer">操作间变量的初始化方法</param>
	/// <param name="finalizer">操作间变量的清理方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="func" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel(this IEnumerable source, Func<long, ParallelLoopState, object, object> func, Func<object> initializer = null, Action<object> finalizer = null, ParallelOptions options = null)
	{
		return source.OfType<object>().ForParallel(func, initializer, finalizer, options);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel(this IEnumerable source, int start, int count, Action<int> action, ParallelOptions options = null)
	{
		return source.OfType<object>().ForParallel(start, count, action, options);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel(this IEnumerable source, long start, long count, Action<long> action, ParallelOptions options = null)
	{
		return source.OfType<object>().ForParallel(start, count, action, options);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel(this IEnumerable source, int start, int count, Action<int, ParallelLoopState> action, ParallelOptions options = null)
	{
		return source.OfType<object>().ForParallel(start, count, action, options);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素索引执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForParallel(this IEnumerable source, long start, long count, Action<long, ParallelLoopState> action, ParallelOptions options = null)
	{
		return source.OfType<object>().ForParallel(start, count, action, options);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
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
	public static ParallelLoopResult ForParallel(this IEnumerable source, int start, int count, Func<int, ParallelLoopState, object, object> func, Func<object> initializer = null, Action<object> finalizer = null, ParallelOptions options = null)
	{
		return source.OfType<object>().ForParallel(start, count, func, initializer, finalizer, options);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素索引执行指定的操作
	/// </summary>
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
	public static ParallelLoopResult ForParallel(this IEnumerable source, long start, long count, Func<long, ParallelLoopState, object, object> func, Func<object> initializer = null, Action<object> finalizer = null, ParallelOptions options = null)
	{
		return source.OfType<object>().ForParallel(start, count, func, initializer, finalizer, options);
	}

	/// <summary>
	/// 对当前序列中所有元素执行指定的操作，该操作可能并行
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>循环结果信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	public static ParallelLoopResult ForEachParallel(this IEnumerable source, Action<object> action, ParallelOptions options = null)
	{
		return source.OfType<object>().ForEachParallel(action, options);
	}

	/// <summary>
	/// 对当前序列中所有元素执行指定的操作，该操作可能并行
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	public static ParallelLoopResult ForEachParallel(this IEnumerable source, Action<object, long> action, ParallelOptions options = null)
	{
		return source.OfType<object>().ForEachParallel(action, options);
	}

	/// <summary>
	/// 对当前序列中所有元素执行指定的操作，该操作可能并行
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	public static ParallelLoopResult ForEachParallel(this IEnumerable source, Action<object, ParallelLoopState> action, ParallelOptions options = null)
	{
		return source.OfType<object>().ForEachParallel(action, options);
	}

	/// <summary>
	/// 对当前序列中所有元素执行指定的操作，该操作可能并行
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	public static ParallelLoopResult ForEachParallel(this IEnumerable source, Action<object, long, ParallelLoopState> action, ParallelOptions options = null)
	{
		return source.OfType<object>().ForEachParallel(action, options);
	}

	/// <summary>
	///             对当前序列中所有元素执行指定的操作，该操作可能并行
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="func">对每个元素执行的操作方法</param>
	/// <param name="initializer">操作间变量的初始化方法</param>
	/// <param name="finalizer">操作间变量的清理方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="func" /> 为空。</exception>
	public static ParallelLoopResult ForEachParallel(this IEnumerable source, Func<object, ParallelLoopState, object, object> func, Func<object> initializer = null, Action<object> finalizer = null, ParallelOptions options = null)
	{
		return source.OfType<object>().ForEachParallel(func, initializer, finalizer, options);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="func">对每个元素执行的操作方法</param>
	/// <param name="initializer">操作间变量的初始化方法</param>
	/// <param name="finalizer">操作间变量的清理方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="func" /> 为空。</exception>
	public static ParallelLoopResult ForEachParallel(this IEnumerable source, Func<object, long, ParallelLoopState, object, object> func, Func<object> initializer = null, Action<object> finalizer = null, ParallelOptions options = null)
	{
		return source.OfType<object>().ForEachParallel(func, initializer, finalizer, options);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForEachParallel(this IEnumerable source, int start, int count, Action<object> action, ParallelOptions options = null)
	{
		return source.OfType<object>().ForEachParallel(start, count, action, options);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForEachParallel(this IEnumerable source, int start, int count, Action<object, int> action, ParallelOptions options = null)
	{
		return source.OfType<object>().ForEachParallel(start, count, action, options);
	}

	/// <summary>
	/// 对当前序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForEachParallel(this IEnumerable source, int start, int count, Action<object, ParallelLoopState> action, ParallelOptions options = null)
	{
		return source.OfType<object>().ForEachParallel(start, count, action, options);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素执行指定的操作
	/// </summary>
	/// <param name="source">当前待处理的序列</param>
	/// <param name="start">开始处理的序列元素的索引</param>
	/// <param name="count">开始处理的序列元素的个数</param>
	/// <param name="action">对每个元素执行的操作方法</param>
	/// <param name="options">执行参数</param>
	/// <returns>已完成的循环信息</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者操作方法 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始处理索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">处理的元素个数小于0。</exception>
	public static ParallelLoopResult ForEachParallel<T>(this IEnumerable source, int start, int count, Action<object, int, ParallelLoopState> action, ParallelOptions options = null)
	{
		return source.OfType<object>().ForEachParallel(start, count, action, options);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素执行指定的操作
	/// </summary>
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
	public static ParallelLoopResult ForEachParallel(this IEnumerable source, int start, int count, Func<object, ParallelLoopState, object, object> func, Func<object> initializer = null, Action<object> finalizer = null, ParallelOptions options = null)
	{
		return source.OfType<object>().ForEachParallel(start, count, func, initializer, finalizer, options);
	}

	/// <summary>
	/// 对序列中指定范围内的每个元素执行指定的操作
	/// </summary>
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
	public static ParallelLoopResult ForEachParallel(this IEnumerable source, int start, int count, Func<object, int, ParallelLoopState, object, object> func, Func<object> initializer = null, Action<object> finalizer = null, ParallelOptions options = null)
	{
		return source.OfType<object>().ForEachParallel(start, count, func, initializer, finalizer, options);
	}

	/// <summary>
	/// 获取当前序列中每个元素的类型，如果元素为空，则对应的类型为空
	/// </summary>
	/// <param name="items">当前序列</param>
	/// <returns>当前序列中各个元素的类型的数组；如果序列元素为空，则元素类型为空。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable<Type> GetTypes(this IEnumerable items)
	{
		items.GuardNotNull("items");
		foreach (object item in items)
		{
			yield return item.IsNull() ? null : item.GetType();
		}
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否全部满足指定的条件，不全部满足则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="name">序列名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前序列中的任一元素不满足指定检测规则。</exception>
	public static E GuardAll<E>(this E items, Func<object, bool> predicate, string name = null, string message = null) where E : IEnumerable
	{
		items.GuardNotNull("items");
		predicate.GuardNotNull("predicate");
		items.Guard(items.All(predicate), name.IfNull("item"), message.IfNull(Literals.MSG_SequenceAnyOneElementNotInPredicate));
		return items;
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否全部满足指定的条件，不全部满足则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前序列中的任一元素不满足指定检测规则，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static E GuardAll<E>(this E items, Func<object, bool> predicate, Func<Exception> exceptionCreator) where E : IEnumerable
	{
		items.GuardNotNull("items");
		predicate.GuardNotNull("predicate");
		items.Guard(items.All(predicate), exceptionCreator);
		return items;
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否全部满足指定的条件，不全部满足则抛出 <paramref name="exceptionType" /> 类型的异常
	/// </summary>
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
	public static E GuardAll<E>(this E items, Func<object, bool> predicate, Type exceptionType, params object[] args) where E : IEnumerable
	{
		items.GuardNotNull("items");
		predicate.GuardNotNull("predicate");
		items.Guard(items.All(predicate), exceptionType, args);
		return items;
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否全部不满足指定的条件，如果存在满足条件的元素则抛出 <see cref="T:System.ArgumentException" /> 异常。
	/// </summary>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="name">序列名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前序列中的任一元素满足指定检测规则。</exception>
	public static E GuardAllNot<E>(this E items, Func<object, bool> predicate, string name = null, string message = null) where E : IEnumerable
	{
		items.GuardNotNull("items");
		predicate.GuardNotNull("predicate");
		items.Guard(items.AllNot(predicate), name.IfNull("item"), message.IfNull(Literals.MSG_SequenceAnyOneElementInPredicate));
		return items;
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否全部不满足指定的条件，如果存在满足条件的元素则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前序列中的任一元素满足指定检测规则，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static E GuardAllNot<E>(this E items, Func<object, bool> predicate, Func<Exception> exceptionCreator) where E : IEnumerable
	{
		items.GuardNotNull("items");
		predicate.GuardNotNull("predicate");
		items.Guard(items.AllNot(predicate), exceptionCreator);
		return items;
	}

	/// <summary>
	/// 检测当前序列中的所有元素是否全部不满足指定的条件，如果存在满足条件的元素则抛出 <paramref name="exceptionType" /> 类型的异常
	/// </summary>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前序列中的任一元素满足指定检测规则，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static E GuardAllNot<E>(this E items, Func<object, bool> predicate, Type exceptionType, params object[] args) where E : IEnumerable
	{
		items.GuardNotNull("items");
		predicate.GuardNotNull("predicate");
		items.Guard(items.AllNot(predicate), exceptionType, args);
		return items;
	}

	/// <summary>
	/// 检测当前序列中是否有满足指定的条件的元素，如果不存在满足条件的元素则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前待检测的序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="name">序列名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前序列中的元素全部不满足指定检测规则。</exception>
	public static E GuardAny<E>(this E items, Func<object, bool> predicate, string name = null, string message = null) where E : IEnumerable
	{
		items.GuardNotNull("items");
		predicate.GuardNotNull("predicate");
		items.Guard(items.Any(predicate), name.IfNull("item"), message.IfNull(Literals.MSG_SequenceNotElementInPredicate));
		return items;
	}

	/// <summary>
	/// 检测当前序列中是否有满足指定的条件的元素，如果不存在满足条件的元素则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前待检测的序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前序列中的元素全部不满足指定检测规则，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static E GuardAny<E>(this E items, Func<object, bool> predicate, Func<Exception> exceptionCreator) where E : IEnumerable
	{
		items.GuardNotNull("items");
		predicate.GuardNotNull("predicate");
		items.Guard(items.Any(predicate), exceptionCreator);
		return items;
	}

	/// <summary>
	/// 检测当前序列中是否有满足指定的条件的元素，如果不存在满足条件的元素则抛出 <paramref name="exceptionType" /> 类型的异常
	/// </summary>
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
	public static E GuardAny<E>(this E items, Func<object, bool> predicate, Type exceptionType, params object[] args) where E : IEnumerable
	{
		items.GuardNotNull("items");
		predicate.GuardNotNull("predicate");
		items.Guard(items.Any(predicate), exceptionType, args);
		return items;
	}

	/// <summary>
	/// 检测当前序列中是否有不满足指定的条件的元素，全部都满足条件的元素则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="name">序列名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前序列中的元素全部满足指定检测规则。</exception>
	public static E GuardAnyNot<E>(this E items, Func<object, bool> predicate, string name = null, string message = null) where E : IEnumerable
	{
		items.GuardNotNull("items");
		predicate.GuardNotNull("predicate");
		items.Guard(items.AnyNot(predicate), name.IfNull("item"), message.IfNull(Literals.MSG_SequenceAllElementInPredicate));
		return items;
	}

	/// <summary>
	/// 检测当前序列中是否有不满足指定的条件的元素，全部都满足条件的元素则抛出指定异常
	/// </summary>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前待检测的序列</param>
	/// <param name="predicate">指定的检测规则</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检查通过则返回原序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者检测规则 <paramref name="predicate" /> 为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前序列中的元素全部满足指定检测规则，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static E GuardAnyNot<E>(this E items, Func<object, bool> predicate, Func<Exception> exceptionCreator) where E : IEnumerable
	{
		items.GuardNotNull("items");
		predicate.GuardNotNull("predicate");
		items.Guard(items.AnyNot(predicate), exceptionCreator);
		return items;
	}

	/// <summary>
	/// 检测当前序列中是否有不满足指定的条件的元素，全部都满足条件的元素则抛出指定异常
	/// </summary>
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
	public static E GuardAnyNot<E>(this E items, Func<object, bool> predicate, Type exceptionType, params object[] args) where E : IEnumerable
	{
		items.GuardNotNull("items");
		predicate.GuardNotNull("predicate");
		items.Guard(items.AnyNot(predicate), exceptionType, args);
		return items;
	}

	/// <summary>
	/// 检测当前序列是否不为空或者空序列，如果为空或者空序列抛出 <see cref="T:System.ArgumentNullException" /> 异常
	/// </summary>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前序列</param>
	/// <param name="name">列表名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空或者为空序列。</exception>
	public static E GuardNotNullAndEmpty<E>(this E items, string name = null, string message = null) where E : IEnumerable
	{
		items.Guard(items.IsNotNullAndEmpty(), () => new ArgumentNullException(name.IfNull("items"), message.IfNull(Literals.MSG_SequenceNullOrEmpty)));
		return items;
	}

	/// <summary>
	/// 检测当前序列是否不为空或者空序列，如果为空或者空序列抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前序列</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前序列为空或者空序列，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static E GuardNotNullAndEmpty<E>(this E items, Func<Exception> exceptionCreator) where E : IEnumerable
	{
		items.Guard(items.IsNotNullAndEmpty(), exceptionCreator);
		return items;
	}

	/// <summary>f
	/// 检测当前序列是否不为空或者空序列，如果为空或者空序列抛出 <paramref name="exceptionType" /> 类型的异常
	/// </summary>
	/// <typeparam name="E">当前序列类型</typeparam>
	/// <param name="items">当前序列</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前序列为空或者空序列，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static E GuardNotNullAndEmpty<E>(this E items, Type exceptionType, params object[] args) where E : IEnumerable
	{
		items.Guard(items.IsNotNullAndEmpty(), exceptionType, args);
		return items;
	}

	/// <summary>
	/// 获取当前序列中指定对象第一次出现的位置的索引
	/// </summary>
	/// <param name="source">待检测的序列</param>
	/// <param name="obj">待查找的指定对象</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static int IndexOf(this IEnumerable source, object obj)
	{
		return source.IndexOf(0, obj);
	}

	/// <summary>
	/// 获取当前序列中指定对象第一次出现的位置的索引
	/// </summary>
	/// <param name="source">待检测的序列</param>
	/// <param name="obj">待检测的指定对象</param>
	/// <param name="equalition">对象相等比较方法</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static int IndexOf(this IEnumerable source, object obj, Func<object, object, bool> equalition)
	{
		return source.IndexOf(0, obj, equalition);
	}

	/// <summary>
	/// 获取当前序列中指定对象第一次出现的位置的索引
	/// </summary>
	/// <param name="source">待检测的序列</param>
	/// <param name="start">从零开始的搜索的起始索引</param>
	/// <param name="obj">待检测的指定对象</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始搜索的索引小于0。</exception>
	public static int IndexOf(this IEnumerable source, int start, object obj)
	{
		return source.IndexOf(start, obj, ObjectExtensions.ObjectEquals);
	}

	/// <summary>
	/// 获取当前序列中指定对象第一次出现的位置的索引
	/// </summary>
	/// <param name="source">待检测的序列</param>
	/// <param name="start">从零开始的搜索的起始索引</param>
	/// <param name="obj">待检测的指定对象</param>
	/// <param name="equalition">对象相等比较方法</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始搜索的索引小于0。</exception>
	public static int IndexOf(this IEnumerable source, int start, object obj, Func<object, object, bool> equalition)
	{
		source.GuardNotNull("source");
		start.GuardIndexLowBound(0, "start");
		equalition = equalition.IfNull(ObjectExtensions.ObjectEquals);
		foreach (object item in source.SkipObject(start))
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
	/// <param name="source">待检测的序列</param>
	/// <param name="start">从零开始的搜索的起始索引</param>
	/// <param name="count">要搜索的部分中的元素数</param>
	/// <param name="obj">待检测的指定对象</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始搜索的索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">搜索的元素数量小于0。</exception>
	public static int IndexOf(this IEnumerable source, int start, int count, object obj)
	{
		return source.IndexOf(start, count, obj, ObjectExtensions.ObjectEquals);
	}

	/// <summary>
	/// 获取当前序列中指定对象第一次出现的位置的索引
	/// </summary>
	/// <param name="source">待检测的序列</param>
	/// <param name="start">从零开始的搜索的起始索引</param>
	/// <param name="count">要搜索的部分中的元素数</param>
	/// <param name="obj">待检测的指定对象</param>
	/// <param name="equalition">对象相等比较方法</param>
	/// <returns>符合条件的元素在序列中的索引；如果在序列中没有找到符合条件的元素，则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始搜索的索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">搜索的元素数量小于0。</exception>
	public static int IndexOf(this IEnumerable source, int start, int count, object obj, Func<object, object, bool> equalition)
	{
		source.GuardNotNull("source");
		start.GuardIndexLowBound(0, "start");
		count.GuardGreaterThanOrEqualTo(0, "count");
		equalition = equalition.IfNull(ObjectExtensions.ObjectEquals);
		int end = start + count;
		foreach (object item in source.SkipObject(start))
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
	/// <param name="source">当前序列</param>
	/// <param name="values">待查找的对象集合</param>
	/// <returns>找到的元素的索引，未找到返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者查找的对象集合为空。</exception>
	public static int IndexOfAny(this IEnumerable source, params object[] values)
	{
		return source.IndexOfAny(0, values);
	}

	/// <summary>
	/// 获取当前序列中指定对象中任意一个对象第一次里出现的位置的索引
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="values">待查找的对象集合</param>
	/// <param name="equalition">对象比较方法</param>
	/// <returns>找到的元素的索引，未找到返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者查找的对象集合为空。</exception>
	public static int IndexOfAny(this IEnumerable source, IEnumerable values, Func<object, object, bool> equalition)
	{
		return source.IndexOfAny(0, values, equalition);
	}

	/// <summary>
	/// 获取当前序列中指定对象中任意一个对象第一次里出现的位置的索引
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="values">待查找的对象集合</param>
	/// <returns>找到的元素的索引，未找到返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者查找的对象集合为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始搜索的索引小于0。</exception>
	public static int IndexOfAny(this IEnumerable source, int start, params object[] values)
	{
		return source.IndexOfAny(start, values, ObjectExtensions.ObjectEquals);
	}

	/// <summary>
	/// 获取当前序列中指定对象中任意一个对象第一次里出现的位置的索引
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="values">待查找的对象集合</param>
	/// <param name="equalition">对象比较方法</param>
	/// <returns>找到的元素的索引，未找到返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者查找的对象集合为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始搜索的索引小于0。</exception>
	public static int IndexOfAny(this IEnumerable source, int start, IEnumerable values, Func<object, object, bool> equalition)
	{
		source.GuardNotNull("source");
		start.GuardIndexLowBound(0, "start");
		values.GuardNotNull("values");
		equalition = equalition.IfNull(ObjectExtensions.ObjectEquals);
		foreach (object item in source.SkipObject(start))
		{
			Func<object, bool> predicate = (object x) => equalition(x, item);
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
	/// <param name="source">当前序列</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="count">查找的元素数量</param>
	/// <param name="values">待查找的对象集合</param>
	/// <returns>找到的元素的索引，未找到返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者查找的对象集合为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始搜索的索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">搜索的元素数量小于0。</exception>
	public static int IndexOfAny(this IEnumerable source, int start, int count, params object[] values)
	{
		return source.IndexOfAny(start, count, values, ObjectExtensions.ObjectEquals);
	}

	/// <summary>
	/// 获取当前序列中指定对象中任意一个对象第一次里出现的位置的索引
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="count">查找的元素数量</param>
	/// <param name="values">待查找的对象集合</param>
	/// <param name="equalition">对象比较方法</param>
	/// <returns>找到的元素的索引，未找到返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者查找的对象集合为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始搜索的索引小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">搜索的元素数量小于0。</exception>
	public static int IndexOfAny(this IEnumerable source, int start, int count, IEnumerable values, Func<object, object, bool> equalition)
	{
		source.GuardNotNull("source");
		start.GuardIndexLowBound(0, "start");
		count.GuardGreaterThanOrEqualTo(0, "count");
		values.GuardNotNull("values");
		equalition = equalition.IfNull(ObjectExtensions.ObjectEquals);
		int end = start + count;
		foreach (object item in source.SkipObject(start))
		{
			if (start >= end)
			{
				break;
			}
			if (values.Any((object x) => equalition(x, item)))
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
	/// <param name="source">当前序列</param>
	/// <param name="target">合并的目标序列</param>
	/// <param name="equalition">返回两个序列的交集</param>
	/// <returns>返回两个序列的交集。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列 <paramref name="target" /> 为空。</exception>
	public static IEnumerable Intersect(this IEnumerable source, IEnumerable target, Func<object, object, bool> equalition)
	{
		return source.OfType<object>().Intersect(target.OfType<object>(), equalition);
	}

	/// <summary>
	/// 获取当前序列与多个目标序列的交集
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="targets">合并的多个目标序列</param>
	/// <returns>处理后的交集</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列数组 <paramref name="targets" /> 为空。</exception>
	public static IEnumerable Intersect(this IEnumerable source, params IEnumerable[] targets)
	{
		return source.OfType<object>().Intersect(targets.Select((IEnumerable x) => x.OfType<object>()), ObjectExtensions.ObjectEquals);
	}

	/// <summary>
	/// 获取当前序列与多个目标序列的交集
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="targets">合并的多个目标序列</param>
	/// <param name="equalition">序列元素比较方法</param>
	/// <returns>处理后的交集</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列列表 <paramref name="targets" /> 为空。</exception>
	public static IEnumerable Intersect(this IEnumerable source, IEnumerable<IEnumerable> targets, Func<object, object, bool> equalition)
	{
		return source.OfType<object>().Intersect(targets.Select((IEnumerable x) => x.OfType<object>()), ObjectExtensions.ObjectEquals);
	}

	/// <summary>
	/// 检测当前序列是否为空或者不包含任何元素
	/// </summary>
	/// <param name="items">当前序列</param>
	/// <returns>如果当前序列为空或者不包含任何元素返回true，否则返回false</returns>
	public static bool IsNullOrEmpty(this IEnumerable items)
	{
		return items.IsNull() || !items.Any();
	}

	/// <summary>
	/// 检测当前序列是否不为空且包含序列元素
	/// </summary>
	/// <param name="items">当前序列</param>
	/// <returns>如果当前序列不为空且包含序列元素返回true，否则返回false</returns>
	public static bool IsNotNullAndEmpty(this IEnumerable items)
	{
		return items.IsNull() && items.Any();
	}

	/// <summary>
	/// 将序列元素连接为字符串；序列中各个元素通过调用ToString方法获取其字符串表示
	/// </summary>
	/// <param name="source">源序列</param>
	/// <param name="separator">元素间分隔符</param>
	/// <returns>转换后的字符串</returns>
	public static string JoinObjectString(this IEnumerable source, string separator = null)
	{
		source.GuardNotNull("source");
		separator = separator.IfNull(string.Empty);
		return source.JoinObjectString((object x) => x.ToString(), separator);
	}

	/// <summary>
	/// 将当前序列元素按指定格式连接为字符串
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="format">当前序列元素格式化符合字符串</param>
	/// <param name="separator">元素间分隔符</param>
	/// <returns>转换后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static string JoinObjectString(this IEnumerable source, string format, string separator = null)
	{
		source.GuardNotNull("source");
		format = format.IfNull("{0}");
		separator = separator.IfNull(string.Empty);
		return source.JoinObjectString((object x) => string.Format(format, x), separator);
	}

	/// <summary>
	/// 将当前序列元素按指定格式连接为字符串
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="formatting">当前序列元素格式化方法</param>
	/// <param name="separator">元素间分隔符</param>
	/// <returns>转换后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static string JoinObjectString(this IEnumerable source, Func<object, string> formatting, string separator = null)
	{
		source.GuardNotNull("source");
		formatting = formatting.IfNull((object x) => x.ToString());
		return source.JoinObjectString((object x, int i) => formatting(x), separator);
	}

	/// <summary>
	/// 将当前序列元素按指定格式连接为字符串
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="formatting">当前序列元素格式化方法</param>
	/// <param name="separator">元素间分隔符</param>
	/// <returns>转换后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static string JoinObjectString(this IEnumerable source, Func<object, int, string> formatting, string separator = null)
	{
		source.GuardNotNull("source");
		formatting = formatting.IfNull((object x, int i) => x.ToString());
		separator = separator.IfNull(string.Empty);
		StringBuilder buff = new StringBuilder();
		int index = 0;
		foreach (object item in source)
		{
			buff.Append(formatting(item, index++).IfNull(string.Empty)).Append(separator);
		}
		return (buff.Length > 0) ? buff.ToString(0, buff.Length - separator.Length) : string.Empty;
	}

	/// <summary>
	/// 获取当前序列中的最后一个元素，如果当前序列不包含任何元素则抛出异常。
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <returns>最后一个符合条件的元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static object LastObject(this IEnumerable source)
	{
		source.GuardNotNull("source");
		IEnumerator enumerator = source.ReverseObject().GetEnumerator();
		try
		{
			if (enumerator.MoveNext())
			{
				return enumerator.Current;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		throw new InvalidOperationException(Literals.MSG_SequenceEmpty);
	}

	/// <summary>
	/// 获取当前序列中最后一个符合条件的元素，如果没有符合条件的元素抛出异常
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>最后一个符合条件的元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者序列元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static object LastObject(this IEnumerable source, Func<object, bool> predicate)
	{
		return source.LastObject((object x, int i) => predicate(x));
	}

	/// <summary>
	/// 获取当前序列中最后一个符合条件的元素，如果没有符合条件的元素抛出异常
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>最后一个符合条件的元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者序列元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static object LastObject(this IEnumerable source, Func<object, int, bool> predicate)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		int index = source.CountObject() - 1;
		foreach (object item in source.ReverseObject())
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
	/// <param name="source">当前序列</param>
	/// <param name="count">获取的元素数量</param>
	/// <returns>获取的子序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">获取的元素数量 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable LastObject(this IEnumerable source, int count)
	{
		source.GuardNotNull("source");
		count.GuardGreaterThanOrEqualTo(0, "count");
		int start = source.CountObject() - count;
		start = ((start >= 0) ? start : 0);
		return source.SkipObject(start).TakeObject(count);
	}

	/// <summary>
	/// 获取当前序列中的最后一个元素，如果当前序列为空则返回元素默认值 <paramref name="defaultValue" />
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="defaultValue">元素默认值</param>
	/// <returns>最后一个条件的元素或者元素类型的默认值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static object LastObjectOrDefault(this IEnumerable source, object defaultValue = null)
	{
		source.GuardNotNull("source");
		IEnumerator enumerator = source.ReverseObject().GetEnumerator();
		try
		{
			if (enumerator.MoveNext())
			{
				return enumerator.Current;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return defaultValue;
	}

	/// <summary>
	/// 获取当前序列中最后一个符合条件的元素，如果没有符合条件的元素默认值 <paramref name="defaultValue" />
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <param name="defaultValue">元素默认值</param>
	/// <returns>最后一个符合条件的元素或者元素类型的默认值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者序列元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static object LastObjectOrDefault(this IEnumerable source, Func<object, bool> predicate, object defaultValue = null)
	{
		predicate.GuardNotNull("predicate");
		return source.LastObjectOrDefault((object x, int i) => predicate(x), defaultValue);
	}

	/// <summary>
	/// 获取当前序列中最后一个符合条件的元素，如果没有符合条件的元素则返回元素默认值 <paramref name="defaultValue" />
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <param name="defaultValue">元素默认值</param>
	/// <returns>最后一个符合条件的元素或者元素类型的默认值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者序列元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static object LastObjectOrDefault(this IEnumerable source, Func<object, int, bool> predicate, object defaultValue = null)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		int index = source.CountObject() - 1;
		foreach (object item in source.ReverseObject())
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
	/// <param name="source">当前序列</param>
	/// <param name="count">获取的序列元素数量</param>
	/// <param name="defaultValue">元素默认值</param>
	/// <returns>获取的子序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">获取的序列元素 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable LastObjectOrDefault(this IEnumerable source, int count, object defaultValue = null)
	{
		source.GuardNotNull("source");
		count.GuardGreaterThanOrEqualTo(0, "count");
		int total = source.CountObject();
		if (total >= count)
		{
			return source.SkipObject(total - count);
		}
		return new object[total - count].Fill(defaultValue).ConcatObject(source);
	}

	/// <summary>
	/// 获取当前序列中的最大值，如果当前序列为空序列则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <returns>返回序列中的最大值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static object Max(this IEnumerable source)
	{
		return source.Max(Comparer.Default.Compare);
	}

	/// <summary>
	/// 获取当前序列中的最大值，如果当前序列为空序列则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="comparer">序列元素比较器</param>
	/// <returns>返回序列中的最大值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static object Max(this IEnumerable source, IComparer comparer)
	{
		return source.Max(comparer.IfNull(Comparer.Default).Compare);
	}

	/// <summary>
	/// 获取当前序列中的最大值，如果当前序列为空序列则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="comparison">序列元素比较方法</param>
	/// <returns>返回序列中的最大值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static object Max(this IEnumerable source, Func<object, object, int> comparison)
	{
		source.GuardNotNull("source");
		comparison = comparison.IfNull(Comparer.Default.Compare);
		if (!source.Any())
		{
			throw new InvalidOperationException(Literals.MSG_SequenceEmpty);
		}
		object max = source.FirstObject();
		foreach (object item in source)
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
	/// <param name="source">当前序列</param>
	/// <param name="defaultValue">最大值的默认值</param>
	/// <returns>返回序列中的最大值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static object MaxOrDefault(this IEnumerable source, object defaultValue = null)
	{
		return source.MaxOrDefault(Comparer.Default.Compare);
	}

	/// <summary>
	/// 获取当前序列中的最大值，如果当前序列为空序列则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="comparer">序列元素比较器</param>
	/// <param name="defaultValue">最大值的默认值</param>
	/// <returns>返回序列中的最大值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static object MaxOrDefault(this IEnumerable source, IComparer comparer, object defaultValue = null)
	{
		return source.MaxOrDefault(comparer.IfNull(Comparer.Default).Compare);
	}

	/// <summary>
	/// 获取当前序列中的最大值，如果当前序列为空序列则默认值
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="comparison">序列元素比较方法</param>
	/// <param name="defaultValue">最大值的默认值</param>
	/// <returns>返回序列中的最大值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static object MaxOrDefault(this IEnumerable source, Func<object, object, int> comparison, object defaultValue = null)
	{
		source.GuardNotNull("source");
		comparison = comparison.IfNull(Comparer.Default.Compare);
		if (!source.Any())
		{
			return defaultValue;
		}
		object max = source.FirstObject();
		foreach (object item in source)
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
	/// <param name="source">当前序列</param>
	/// <returns>返回序列中的中间值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素。</exception>
	public static object Median(this IEnumerable source)
	{
		return source.Median(Comparer.Default.Compare);
	}

	/// <summary>
	/// 获取当前序列中所有元素的中间值
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="comparer">序列元素比较器</param>
	/// <returns>返回序列中的中间值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素。</exception>
	public static object Median(this IEnumerable source, IComparer comparer)
	{
		return source.Median(comparer.IfNull(Comparer.Default).Compare);
	}

	/// <summary>
	/// 获取当前序列中所有元素的中间值
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="comparison">序列元素比较方法</param>
	/// <returns>返回序列中的中间值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素。</exception>
	public static object Median(this IEnumerable source, Func<object, object, int> comparison)
	{
		source.GuardNotNull("source");
		comparison = comparison.IfNull(Comparer.Default.Compare);
		int count = source.CountObject();
		if (count == 0)
		{
			throw new InvalidOperationException(Literals.MSG_SequenceEmpty);
		}
		return source.OfType<object>().OrderBy(comparison.ToComparer<object>()).ElementAt(count / 2);
	}

	/// <summary>
	/// 获取当前序列中的最小值，如果当前序列为空序列则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <returns>返回序列中的最小值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static object Min(this IEnumerable source)
	{
		return source.Min(Comparer.Default.Compare);
	}

	/// <summary>
	/// 获取当前序列中的最小值，如果当前序列为空序列则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="comparer">序列元素比较器</param>
	/// <returns>返回序列中的最小值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static object Min(this IEnumerable source, IComparer comparer)
	{
		return source.Min(comparer.IfNull(Comparer.Default).Compare);
	}

	/// <summary>
	/// 获取当前序列中的最小值，如果当前序列为空序列则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="comparison">序列元素比较方法</param>
	/// <returns>返回序列中的最小值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static object Min(this IEnumerable source, Func<object, object, int> comparison)
	{
		source.GuardNotNull("source");
		comparison = comparison.IfNull(Comparer.Default.Compare);
		if (!source.Any())
		{
			throw new InvalidOperationException(Literals.MSG_SequenceEmpty);
		}
		object min = source.FirstObject();
		foreach (object item in source)
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
	/// <param name="source">当前序列</param>
	/// <param name="defaultValue">最小值的默认值</param>
	/// <returns>返回序列中的最小值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static object MinOrDefault(this IEnumerable source, object defaultValue = null)
	{
		return source.MinOrDefault(Comparer.Default.Compare);
	}

	/// <summary>
	/// 获取当前序列中的最小值，如果当前序列为空序列则抛出 <see cref="T:System.InvalidOperationException" /> 异常
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="comparer">序列元素比较器</param>
	/// <param name="defaultValue">最小值的默认值</param>
	/// <returns>返回序列中的最小值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static object MinOrDefault(this IEnumerable source, IComparer comparer, object defaultValue = null)
	{
		return source.MinOrDefault(comparer.IfNull(Comparer.Default).Compare);
	}

	/// <summary>
	/// 获取当前序列中的最小值，如果当前序列为空序列则默认值
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="comparison">序列元素比较方法</param>
	/// <param name="defaultValue">最小值的默认值</param>
	/// <returns>返回序列中的最小值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static object MinOrDefault(this IEnumerable source, Func<object, object, int> comparison, object defaultValue = null)
	{
		source.GuardNotNull("source");
		comparison = comparison.IfNull(Comparer.Default.Compare);
		if (!source.Any())
		{
			return defaultValue;
		}
		object min = source.FirstObject();
		foreach (object item in source)
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
	/// <param name="source">当前序列</param>
	/// <returns>出现次数最多的元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static object MostObject(this IEnumerable source)
	{
		return source.MostObject(ObjectExtensions.ObjectEquals);
	}

	/// <summary>
	/// 获取当前序列中出现次数最多的元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="equalition">序列元素比较方法</param>
	/// <returns>出现次数最多的元素</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当前序列不包含任何元素</exception>
	public static object MostObject(this IEnumerable source, Func<object, object, bool> equalition)
	{
		source.GuardNotNull("source");
		if (!source.Any())
		{
			throw new InvalidOperationException(Literals.MSG_SequenceEmpty);
		}
		Dictionary<object, int> bag = new Dictionary<object, int>(equalition.ToComparer<object>());
		foreach (object item in source)
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
		return bag.Max((KeyValuePair<object, int> p1, KeyValuePair<object, int> p2) => p1.Value - p2.Value).Key;
	}

	/// <summary>
	/// 对当前序列进行升序排列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <returns>排序后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable ObjectOrderBy(this IEnumerable source)
	{
		return source.ObjectOrderBy(Comparer.Default);
	}

	/// <summary>
	/// 对当前序列进行升序排列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="comparer">元素排序比较器</param>
	/// <returns>排序后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable ObjectOrderBy(this IEnumerable source, IComparer comparer)
	{
		source.GuardNotNull("source");
		return source.OfType<object>().OrderBy((object x) => x, comparer.IfNull(Comparer.Default).ToComparer());
	}

	/// <summary>
	/// 对当前序列进行升序排列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="comparison">元素排序比较方法</param>
	/// <returns>排序后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable ObjectOrderBy(this IEnumerable source, Func<object, object, int> comparison)
	{
		source.GuardNotNull("source");
		return source.OfType<object>().OrderBy((object x) => x, comparison.IfNull(Comparer.Default.Compare).ToComparer<object>());
	}

	/// <summary>
	/// 对当前序列进行升序排列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="keys">排序键选择方法</param>
	/// <returns>排序后的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者排序键选择方法为空。</exception>
	public static IEnumerable ObjectOrderBy(this IEnumerable source, params Func<object, object>[] keys)
	{
		source.GuardNotNull("source");
		keys.GuardNotNull("key selectors");
		IOrderedEnumerable<object> ordered = null;
		for (int i = 0; i < keys.Length; i++)
		{
			keys[i].GuardNotNull("key selector");
			ordered = ((i != 0) ? ordered.ThenBy(keys[i], Comparer<object>.Default) : source.OfType<object>().OrderBy(keys[i], Comparer<object>.Default));
		}
		return ordered;
	}

	/// <summary>
	/// 对当前序列进行升序排列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="keys">排序键选择方法</param>
	/// <param name="comparers">排序键排序对象</param>
	/// <returns>排序后的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者排序键选择方法为空；或者排序键排序对象为空。</exception>
	public static IEnumerable ObjectOrderBy(this IEnumerable source, Func<object, object>[] keys, IComparer[] comparers)
	{
		source.GuardNotNull("source");
		keys.GuardNotNull("key selectors");
		comparers.GuardNotNull("key comparers");
		comparers.GuardArrayLength(keys.Length, "key comparers");
		IOrderedEnumerable<object> ordered = null;
		for (int i = 0; i < keys.Length; i++)
		{
			keys[i].GuardNotNull("key selector");
			comparers[i].GuardNotNull("key comparer");
			ordered = ((i != 0) ? ordered.ThenBy(keys[i], comparers[i].ToComparer()) : source.OfType<object>().OrderBy(keys[i], comparers[i].ToComparer()));
		}
		return ordered;
	}

	/// <summary>
	/// 对当前序列进行升序排列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="keys">排序键选择方法</param>
	/// <param name="comparisons">排序键排序方法</param>
	/// <returns>排序后的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者排序键选择方法为空；或者排序键排序方法为空。</exception>
	public static IEnumerable ObjectOrderBy(this IEnumerable source, Func<object, object>[] keys, Func<object, object, int>[] comparisons)
	{
		source.GuardNotNull("source");
		keys.GuardNotNull("key selectors");
		comparisons.GuardNotNull("key comparisons");
		comparisons.GuardArrayLength(keys.Length, "key comparisons");
		IOrderedEnumerable<object> ordered = null;
		for (int i = 0; i < keys.Length; i++)
		{
			keys[i].GuardNotNull("key selector");
			comparisons[i].GuardNotNull("key comparsion");
			ordered = ((i != 0) ? ordered.ThenBy(keys[i], comparisons[i].ToComparer<object>()) : source.OfType<object>().OrderBy(keys[i], comparisons[i].ToComparer<object>()));
		}
		return ordered;
	}

	/// <summary>
	/// 对当前序列进行降序排列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <returns>排序后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable ObjectOrderByDescending(this IEnumerable source)
	{
		return source.ObjectOrderByDescending(Comparer.Default);
	}

	/// <summary>
	/// 对当前序列进行降序排列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="comparer">元素排序比较器</param>
	/// <returns>排序后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable ObjectOrderByDescending(this IEnumerable source, IComparer comparer)
	{
		source.GuardNotNull("source");
		return source.OfType<object>().OrderByDescending((object x) => x, comparer.IfNull(Comparer.Default).ToComparer());
	}

	/// <summary>
	/// 对当前序列进行降序排列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="comparison">元素排序比较方法</param>
	/// <returns>排序后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable ObjectOrderByDescending(this IEnumerable source, Func<object, object, int> comparison)
	{
		source.GuardNotNull("source");
		return source.OfType<object>().OrderByDescending((object x) => x, comparison.IfNull(Comparer.Default.Compare).ToComparer<object>());
	}

	/// <summary>
	/// 对当前序列进行降序排列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="keys">排序键选择方法</param>
	/// <returns>排序后的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者排序键选择方法为空。</exception>
	public static IEnumerable ObjectOrderByDescending(this IEnumerable source, params Func<object, object>[] keys)
	{
		source.GuardNotNull("source");
		keys.GuardNotNull("key selectors");
		IOrderedEnumerable<object> ordered = null;
		for (int i = 0; i < keys.Length; i++)
		{
			keys[i].GuardNotNull("key selector");
			ordered = ((i != 0) ? ordered.ThenByDescending(keys[i], Comparer<object>.Default) : source.OfType<object>().OrderByDescending(keys[i], Comparer<object>.Default));
		}
		return ordered;
	}

	/// <summary>
	/// 对当前序列进行降序排列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="keys">排序键选择方法</param>
	/// <param name="comparers">排序键排序对象</param>
	/// <returns>排序后的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者排序键选择方法为空；或者排序键排序对象为空。</exception>
	public static IEnumerable ObjectOrderByDescending(this IEnumerable source, Func<object, object>[] keys, IComparer[] comparers)
	{
		source.GuardNotNull("source");
		keys.GuardNotNull("key selectors");
		comparers.GuardNotNull("key comparers");
		comparers.GuardArrayLength(keys.Length, "key comparers");
		IOrderedEnumerable<object> ordered = null;
		for (int i = 0; i < keys.Length; i++)
		{
			keys[i].GuardNotNull("key selector");
			comparers[i].GuardNotNull("key comparer");
			ordered = ((i != 0) ? ordered.ThenByDescending(keys[i], comparers[i].ToComparer()) : source.OfType<object>().OrderByDescending(keys[i], comparers[i].ToComparer()));
		}
		return ordered;
	}

	/// <summary>
	/// 对当前序列进行降序排列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="keys">排序键选择方法</param>
	/// <param name="comparisons">排序键排序方法</param>
	/// <returns>排序后的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者排序键选择方法为空；或者排序键排序方法为空。</exception>
	public static IEnumerable ObjectOrderByDescending(this IEnumerable source, Func<object, object>[] keys, Func<object, object, int>[] comparisons)
	{
		source.GuardNotNull("source");
		keys.GuardNotNull("key selectors");
		comparisons.GuardNotNull("key comparisons");
		comparisons.GuardArrayLength(keys.Length, "key comparisons");
		IOrderedEnumerable<object> ordered = null;
		for (int i = 0; i < keys.Length; i++)
		{
			keys[i].GuardNotNull("key selector");
			comparisons[i].GuardNotNull("key comparsion");
			ordered = ((i != 0) ? ordered.ThenByDescending(keys[i], comparisons[i].ToComparer<object>()) : source.OfType<object>().OrderByDescending(keys[i], comparisons[i].ToComparer<object>()));
		}
		return ordered;
	}

	/// <summary>
	/// 向当前序列头部添加元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="item">向序列头部添加的元素列表</param>
	/// <returns>追加了新的元素的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable Prepend(this IEnumerable source, object item)
	{
		source.GuardNotNull("source");
		yield return item;
		foreach (object item2 in source)
		{
			yield return item2;
		}
	}

	/// <summary>
	/// 向当前序列头部添加元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="items">向序列头部添加的元素列表</param>
	/// <returns>追加了新的元素的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable Prepend(this IEnumerable source, params object[] items)
	{
		return source.Prepend((IEnumerable)items);
	}

	/// <summary>
	/// 向当前序列头部添加元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="items">向序列头部添加的元素列表</param>
	/// <returns>追加了新的元素的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable Prepend(this IEnumerable source, IEnumerable items)
	{
		source.GuardNotNull("source");
		if (items.IsNotNull())
		{
			foreach (object item in items)
			{
				yield return item;
			}
		}
		foreach (object item2 in source)
		{
			yield return item2;
		}
	}

	/// <summary>
	/// 反转当前序列中元素的顺序
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <returns>返回当前序列的相反顺序的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable ReverseObject(this IEnumerable source)
	{
		source.GuardNotNull("source");
		return source.OfType<object>().Reverse();
	}

	/// <summary>
	/// 将当前序列中的每个元素投影到新的序列中
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="selector">序列元素投影方法</param>
	/// <returns>投影生成的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者投影方法 <paramref name="selector" /> 为空。</exception>
	public static IEnumerable SelectObject(this IEnumerable source, Func<object, object> selector)
	{
		source.GuardNotNull("source");
		selector.GuardNotNull("selector");
		return source.OfType<object>().Select(selector);
	}

	/// <summary>
	/// 将当前序列中的每个元素投影到新的序列中
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="selector">序列元素投影方法</param>
	/// <returns>投影生成的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者投影方法 <paramref name="selector" /> 为空。</exception>
	public static IEnumerable SelectObject(this IEnumerable source, Func<object, int, object> selector)
	{
		source.GuardNotNull("source");
		selector.GuardNotNull("selector");
		return source.OfType<object>().Select(selector);
	}

	/// <summary>
	/// 通过合并元素的索引将当前序列的每个元素投影到新表中
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="selection">当前序列元素转换方法</param>
	/// <returns>映射后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者序列元素转换方法 <paramref name="selection" /> 为空。</exception>
	public static IEnumerable SelectObject(this IEnumerable source, Func<object, long, object> selection)
	{
		source.GuardNotNull("source");
		selection.GuardNotNull("selection");
		long index = 0L;
		foreach (object item in source)
		{
			yield return selection(item, index++);
		}
	}

	/// <summary>
	/// 将当前序列中的每个元素投影到新的序列中，再将全部新序列合并为一个序列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="selector">序列元素投影方法</param>
	/// <returns>投影生成的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者投影方法 <paramref name="selector" /> 为空。</exception>
	public static IEnumerable SelectManyObject(this IEnumerable source, Func<object, IEnumerable> selector)
	{
		source.GuardNotNull("source");
		selector.GuardNotNull("selector");
		return source.OfType<object>().SelectMany((object x) => selector(x).OfType<object>());
	}

	/// <summary>
	/// 将当前序列中的每个元素投影到新的序列中，再将全部新序列合并为一个序列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="selector">序列元素投影方法</param>
	/// <returns>投影生成的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者投影方法 <paramref name="selector" /> 为空。</exception>
	public static IEnumerable SelectManyObject(this IEnumerable source, Func<object, int, IEnumerable> selector)
	{
		source.GuardNotNull("source");
		selector.GuardNotNull("selector");
		return source.OfType<object>().SelectMany((object x, int i) => selector(x, i).OfType<object>());
	}

	/// <summary>
	/// 跳过当前序列中指定数量的元素，然后返回剩余的元素。
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="count">跳过的元素数量</param>
	/// <returns>当前序列跳过指定数量元素后剩余的元素序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">跳过的元素数量 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable SkipObject(this IEnumerable source, int count)
	{
		source.GuardNotNull("source");
		count.GuardGreaterThanOrEqualTo(0, "count");
		int index = 0;
		foreach (object o in source)
		{
			if (index >= count)
			{
				yield return o;
			}
		}
	}

	/// <summary>
	/// 跳过当前序列中指定数量的元素，返回剩余的元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="count">跳过元素的数量</param>
	/// <returns>当前序列中剩余元素组成的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">跳过元素的数量 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable SkipObjectLong(this IEnumerable source, long count)
	{
		source.GuardNotNull("source");
		count.GuardGreaterThanOrEqualTo(0L, "count");
		long index = 0L;
		foreach (object item in source)
		{
			if (index++ >= count)
			{
				yield return item;
			}
		}
	}

	/// <summary>
	/// 从当前序列的开头返回指定数量的连续元素
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="count">返回的元素数量</param>
	/// <returns>从当前序列开头返回的指定数量元素的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">跳过的元素数量 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable TakeObject(this IEnumerable source, int count)
	{
		source.GuardNotNull("source");
		count.GuardGreaterThanOrEqualTo(0, "count");
		foreach (object o in source)
		{
			if (count-- > 0)
			{
				yield return o;
				continue;
			}
			break;
		}
	}

	/// <summary>
	/// 从当前序列的开头返回指定数量的连续元素。
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="count">获取的元素数量</param>
	/// <returns>当前序列中剩余元素组成的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">获取的元素数量 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable TakeObjectLong(this IEnumerable source, long count)
	{
		source.GuardNotNull("source");
		count.GuardGreaterThanOrEqualTo(0L, "count");
		long index = 0L;
		foreach (object item in source)
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
	/// <param name="source">当前序列</param>
	/// <returns>创建的指定类型的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static ArrayList ToArrayList(this IEnumerable source)
	{
		source.GuardNotNull("source");
		ArrayList array = new ArrayList();
		foreach (object item in source)
		{
			array.Add(item);
		}
		return array;
	}

	/// <summary>
	/// 将当前序列转换为指定类型的数组
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="evaluator">序列元素转换方法</param>
	/// <returns>创建的指定类型的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者转换方法 <paramref name="evaluator" /> 为空。</exception>
	public static ArrayList ToArrayList(this IEnumerable source, Func<object, object> evaluator)
	{
		evaluator.GuardNotNull("evaluator");
		return source.ToArrayList((object x, int i) => true, (object x, int i) => evaluator(x));
	}

	/// <summary>
	/// 将当前序列转换为指定类型的数组
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="evaluator">序列元素转换方法</param>
	/// <returns>创建的指定类型的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者转换方法 <paramref name="evaluator" /> 为空。</exception>
	public static ArrayList ToArrayList(this IEnumerable source, Func<object, int, object> evaluator)
	{
		evaluator.GuardNotNull("evaluator");
		return source.ToArrayList((object x, int i) => true, evaluator);
	}

	/// <summary>
	/// 将当前序列转换为指定类型的数组
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">当前序列元素筛选条件</param>
	/// <param name="evaluator">序列元素转换方法</param>
	/// <returns>创建的指定类型的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件 <paramref name="predicate" /> 为空；或者转换方法 <paramref name="evaluator" /> 为空。</exception>
	public static ArrayList ToArrayList(this IEnumerable source, Func<object, bool> predicate, Func<object, object> evaluator)
	{
		predicate.GuardNotNull("predicate");
		evaluator.GuardNotNull("evaluator");
		return source.ToArrayList((object x, int i) => predicate(x), (object x, int i) => evaluator(x));
	}

	/// <summary>
	/// 将当前序列转换为指定类型的列表
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">当前序列元素筛选条件</param>
	/// <param name="evaluator">序列元素转换方法</param>
	/// <returns>创建的指定类型的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件 <paramref name="predicate" /> 为空；或者转换方法 <paramref name="evaluator" /> 为空。</exception>
	public static ArrayList ToArrayList(this IEnumerable source, Func<object, int, bool> predicate, Func<object, int, object> evaluator)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		evaluator.GuardNotNull("evaluator");
		ArrayList list = new ArrayList();
		int index = 0;
		foreach (object item in source)
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
	/// 将当前序列转换为数据表，序列中每个对象转换为一个数据行
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <returns>映射生成的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static DataTable ToDataTable(this IEnumerable source)
	{
		return source.ToDataTable();
	}

	/// <summary>
	/// 将当前序列转换为数据表，序列中每个对象转换为一个数据行
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="flags">属性绑定标志</param>
	/// <returns>映射生成的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static DataTable ToDataTable(this IEnumerable source, BindingFlags flags)
	{
		return source.ToDataTable(flags);
	}

	/// <summary>
	/// 将当前序列转换为数据表，序列中每个对象转换为一个数据行
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="propertyNames">转换的对象属性名称列表</param>
	/// <returns>映射生成的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者转换的对象属性名称列表 <paramref name="propertyNames" /> 为空。</exception>
	/// <exception cref="T:System.MissingMemberException">指定的对象属性不存在</exception>
	public static DataTable ToDataTable(this IEnumerable source, params string[] propertyNames)
	{
		return source.ToDataTable(propertyNames);
	}

	/// <summary>
	/// 将当前序列转换为数据表，序列中每个对象转换为一个数据行
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="propertyNames">转换的对象属性名称列表</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <returns>映射生成的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者转换的对象属性名称列表 <paramref name="propertyNames" /> 为空。</exception>
	/// <exception cref="T:System.MissingMemberException">指定的对象属性不存在</exception>
	public static DataTable ToDataTable(this IEnumerable source, string[] propertyNames, bool ignoreCase = false)
	{
		return source.ToDataTable(propertyNames, ignoreCase);
	}

	/// <summary>
	/// 将当前序列转换为数据表，序列中每个对象转换为一个数据行
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="propertyNames">转换的对象属性名称列表</param>
	/// <param name="flags">属性绑定标志</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <returns>映射生成的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者转换的对象属性名称列表 <paramref name="propertyNames" /> 为空。</exception>
	/// <exception cref="T:System.MissingMemberException">指定的对象属性不存在</exception>
	public static DataTable ToDataTable(this IEnumerable source, string[] propertyNames, BindingFlags flags, bool ignoreCase = false)
	{
		return source.ToDataTable(propertyNames, flags, ignoreCase);
	}

	/// <summary>
	/// 将当前序列转换为数据表，序列中每个对象转换为一个数据行
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="mappings">序列元素属性到数据列的映射，序列元素属性名称支持属性路径，未设置序列元素属性则忽略</param>
	/// <param name="onlyMapping">是否只处理在映射中定义的属性</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <returns>映射生成的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者属性映射规则 <paramref name="mappings" /> 为空。</exception>
	/// <exception cref="T:System.MissingMemberException">映射中指定的序列元素属性不存在</exception>
	/// <exception cref="T:System.Data.DuplicateNameException">映射的数据列名称重复</exception>
	public static DataTable ToDataTable(this IEnumerable source, DataMapping[] mappings, bool onlyMapping = false, bool ignoreCase = false)
	{
		return source.ToDataTable(mappings, BindingFlags.Instance | BindingFlags.Public, onlyMapping, ignoreCase);
	}

	/// <summary>
	/// 将当前序列转换为数据表，序列中每个对象转换为一个数据行
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="mappings">序列元素属性到数据列的映射，序列元素属性名称支持属性路径，未设置序列元素属性则忽略</param>
	/// <param name="flags">属性绑定标志</param>
	/// <param name="onlyMapping">是否只处理在映射中定义的属性</param>
	/// <param name="ignoreCase">名称比较是否区分大小写</param>
	/// <returns>映射生成的数据表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者属性映射规则 <paramref name="mappings" /> 为空。</exception>
	/// <exception cref="T:System.MissingMemberException">映射中指定的序列元素属性不存在</exception>
	/// <exception cref="T:System.Data.DuplicateNameException">映射的数据列名称重复</exception>
	public static DataTable ToDataTable(this IEnumerable source, DataMapping[] mappings, BindingFlags flags, bool onlyMapping = false, bool ignoreCase = false)
	{
		source.GuardNotNull("source");
		mappings.GuardNotNull("mappings");
		DataTable table = null;
		foreach (object item in source)
		{
			table = item.ToDataTable(mappings, flags, onlyMapping, ignoreCase, table);
		}
		return table;
	}

	/// <summary>
	/// 将当前序列转换为指定类型的数组
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <returns>转换后的目标数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static object[] ToObjectArray(this IEnumerable source)
	{
		source.GuardNotNull("source");
		return source.OfType<object>().ToArray();
	}

	/// <summary>
	/// 将当前序列转换为指定类型的数组
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="evaluator">序列元素变换方法</param>
	/// <returns>转换后的目标数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者变化方法 <paramref name="evaluator" /> 为空。</exception>
	public static object[] ToObjectArray(this IEnumerable source, Func<object, object> evaluator)
	{
		source.GuardNotNull("source");
		return source.OfType<object>().ToArray(evaluator);
	}

	/// <summary>
	/// 将当前序列转换为指定类型的数组
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="evaluator">序列元素变换方法</param>
	/// <returns>转换后的目标数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者变化方法 <paramref name="evaluator" /> 为空。</exception>
	public static object[] ToObjectArray(this IEnumerable source, Func<object, int, object> evaluator)
	{
		source.GuardNotNull("source");
		return source.OfType<object>().ToArray(evaluator);
	}

	/// <summary>
	/// 将当前序列转换为指定类型的数组
	/// </summary>
	/// <param name="source">转换的当前序列</param>
	/// <param name="predicate">当前序列元素筛选条件</param>
	/// <param name="evaluator">序列元素变换方法</param>
	/// <returns>转换后的目标数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件 <paramref name="predicate" /> 为空；或者变化方法 <paramref name="evaluator" /> 为空。</exception>
	public static object[] ToObjectArray(this IEnumerable source, Func<object, bool> predicate, Func<object, object> evaluator)
	{
		source.GuardNotNull("source");
		return source.OfType<object>().ToArray(predicate, evaluator);
	}

	/// <summary>
	/// 将当前序列转换为指定类型的数组
	/// </summary>
	/// <param name="source">转换的当前序列</param>
	/// <param name="predicate">当前序列元素筛选条件</param>
	/// <param name="evaluator">序列元素变换方法</param>
	/// <returns>转换后的目标数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选条件 <paramref name="predicate" /> 为空；或者变化方法 <paramref name="evaluator" /> 为空。</exception>
	public static object[] ToObjectArray(this IEnumerable source, Func<object, int, bool> predicate, Func<object, int, object> evaluator)
	{
		source.GuardNotNull("source");
		return source.OfType<object>().ToArray(predicate, evaluator);
	}

	/// <summary>
	/// 合并当前序列和目标序列，返回合并后的新序列；合并后的新序列中不包含重复的项目
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="target">合并的目标序列</param>
	/// <returns>合并后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者合并的目标序列 <paramref name="target" /> 为空。</exception>
	public static IEnumerable UnionObject(this IEnumerable source, IEnumerable target)
	{
		source.GuardNotNull("source");
		target.GuardNotNull("target");
		return source.OfType<object>().Union(target.OfType<object>());
	}

	/// <summary>
	/// 合并当前序列和目标序列，合并后的序列中不包含重复的项目
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="target">合并的目标序列</param>
	/// <param name="equalition">序列元素相等比较方法</param>
	/// <returns>合并后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列 <paramref name="target" /> 为空。</exception>
	public static IEnumerable UnionObject(this IEnumerable source, IEnumerable target, Func<object, object, bool> equalition)
	{
		source.GuardNotNull("source");
		target.GuardNotNull("target");
		return source.OfType<object>().Union(target.OfType<object>(), equalition.IfNull(ObjectExtensions.ObjectEquals).ToComparer<object>());
	}

	/// <summary>
	/// 合并当前序列和指多个目标序列，合并后的序列中不包含重复的项目
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="targets">合并的目标序列数组</param>
	/// <returns>合并后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列数组 <paramref name="targets" /> 为空。</exception>
	public static IEnumerable UnionObject(this IEnumerable source, params IEnumerable[] targets)
	{
		return source.OfType<object>().Union((IEnumerable<IEnumerable>)targets, ObjectExtensions.ObjectEquals);
	}

	/// <summary>
	/// 合并当前序列和指多个目标序列，合并后的序列中不包含重复的项目
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="targets">合并的目标序列集合</param>
	/// <param name="equalition">序列元素相等比较方法</param>
	/// <returns>合并后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者目标序列集合 <paramref name="targets" /> 为空。</exception>
	public static IEnumerable UnionObject(this IEnumerable source, IEnumerable<IEnumerable> targets, Func<object, object, bool> equalition)
	{
		source.GuardNotNull("source");
		targets.GuardNotNull("targets");
		IEqualityComparer<object> equaliter = equalition.IfNull(ObjectExtensions.ObjectEquals).ToComparer<object>();
		IEnumerable<object> result = source.OfType<object>();
		foreach (IEnumerable target in targets)
		{
			if (target.IsNotNull())
			{
				result = result.Union(target.OfType<object>(), equaliter);
			}
		}
		return source;
	}

	/// <summary>
	/// 从当前序列中筛选满足指定谓词条件的元素，返回这些元素组成的新元素。
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选谓词</param>
	/// <returns>满足条件组成的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选谓词条件 <paramref name="predicate" /> 为空。</exception>
	public static IEnumerable WhereObject(this IEnumerable source, Func<object, bool> predicate)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		foreach (object item in source)
		{
			if (predicate(item))
			{
				yield return item;
			}
		}
	}

	/// <summary>
	/// 从当前序列中筛选满足指定谓词条件的元素，返回这些元素组成的新元素。
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选谓词</param>
	/// <returns>满足条件组成的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者筛选谓词条件 <paramref name="predicate" /> 为空。</exception>
	public static IEnumerable WhereObject(this IEnumerable source, Func<object, int, bool> predicate)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		int index = 0;
		foreach (object item in source)
		{
			if (predicate(item, index++))
			{
				yield return item;
			}
		}
	}

	/// <summary>
	/// 对当前序列进行筛选，返回满足条件的元素组成的新序列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="predicate">序列元素筛选条件</param>
	/// <returns>当前序列满足条件组成的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者序列元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static IEnumerable WhereObject(this IEnumerable source, Func<object, long, bool> predicate)
	{
		source.GuardNotNull("source");
		predicate.GuardNotNull("predicate");
		long index = 0L;
		foreach (object item in source)
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
	/// <param name="source">当前序列</param>
	/// <returns>筛选后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable WhereObjectNotNull(this IEnumerable source)
	{
		source.GuardNotNull("source");
		return source.WhereObject((object x) => x.IsNotNull());
	}

	/// <summary>
	/// 获取当前序列中所有不为空且不为 <see cref="T:System.DBNull" /> 的元素组成的新序列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <returns>筛选后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable WhereObjectNotNullAndDBNull(this IEnumerable source)
	{
		source.GuardNotNull("source");
		return source.WhereObject((object x) => x.IsNotNullAndDBNull());
	}

	/// <summary>
	/// 获取当前序列中所有不为空且不为其类型默认值的元素组成的新序列
	/// </summary>
	/// <param name="source">当前序列</param>
	/// <param name="defaultType">期望的元素默认值类型</param>
	/// <returns>筛选后的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static IEnumerable WhereObjectNotNullOrDefault(this IEnumerable source, Type defaultType = null)
	{
		source.GuardNotNull("source");
		return source.WhereObject((object x) => x.IsNotNullAndDefault(defaultType));
	}
}
