using System;
using System.Collections.Generic;
using System.Linq;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// <see cref="T:System.Collections.Generic.ICollection`1" /> 泛型接口类型扩展方法类
/// </summary>
public static class ICollectionTExtensions
{
	/// <summary>
	/// 向当前集合中添加项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="item">向集合中添加的项目</param>
	/// <param name="times">项目添加的次数</param>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">项目添加的次数 <paramref name="times" /> 小于0。</exception>
	public static void Add<T>(this ICollection<T> collection, T item, int times)
	{
		collection.GuardNotNull("collection");
		times.GuardGreaterThanOrEqualTo(0, "times");
		while (times-- > 0)
		{
			collection.Add(item);
		}
	}

	/// <summary>
	/// 向当前集合中添加项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <typeparam name="V">添加的项目的类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="item">向集合中添加的项目</param>
	/// <param name="evaluation">添加的项目值处理方法</param>
	/// <param name="times">项目添加的次数</param>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者项目值处理方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">项目添加的次数 <paramref name="times" /> 小于0。</exception>
	public static void Add<T, V>(this ICollection<T> collection, V item, Func<V, T> evaluation, int times = 1)
	{
		collection.GuardNotNull("collection");
		evaluation.GuardNotNull("evaluation");
		times.GuardGreaterThanOrEqualTo(0, "times");
		while (times-- > 0)
		{
			collection.Add(evaluation(item));
		}
	}

	/// <summary>
	/// 向当前集合中添加项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="evaluation">项目值生成方法</param>
	/// <param name="times">项目添加的次数</param>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者项目值生成方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">项目添加的次数 <paramref name="times" /> 小于0。</exception>
	public static void Add<T>(this ICollection<T> collection, Func<T> evaluation, int times = 1)
	{
		collection.GuardNotNull("collection");
		evaluation.GuardNotNull("evaluation");
		times.GuardGreaterThanOrEqualTo(0, "times");
		while (times-- > 0)
		{
			collection.Add(evaluation());
		}
	}

	/// <summary>
	/// 向当前集合中添加项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="evaluation">项目值生成方法</param>
	/// <param name="times">项目添加的次数</param>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者项目值生成方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">项目添加的次数 <paramref name="times" /> 小于0。</exception>
	public static void Add<T>(this ICollection<T> collection, Func<int, T> evaluation, int times = 1)
	{
		collection.GuardNotNull("collection");
		evaluation.GuardNotNull("evaluation");
		times.GuardGreaterThanOrEqualTo(0, "times");
		for (int i = 0; i < times; i++)
		{
			collection.Add(evaluation(i));
		}
	}

	/// <summary>
	/// 向当前集合中添加项目副本
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="item">添加的项目</param>
	/// <param name="copying">项目副本生成方法，默认为生成项目的浅表副本</param>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空。</exception>
	public static void AddCopy<T>(this ICollection<T> collection, T item, Func<T, T> copying = null)
	{
		collection.AddCopy(item, 1, copying);
	}

	/// <summary>
	/// 向当前集合中添加项目副本
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="item">添加的项目</param>
	/// <param name="times">项目添加的次数</param>
	/// <param name="copying">项目副本生成方法，默认为生成项目的浅表副本</param>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前项目添加的次数 <paramref name="times" /> 小于0。</exception>
	public static void AddCopy<T>(this ICollection<T> collection, T item, int times, Func<T, T> copying = null)
	{
		collection.GuardNotNull("collection");
		copying = copying.IfNull((T x) => x.ShallowCopy());
		while (times-- > 0)
		{
			collection.Add(copying(item));
		}
	}

	/// <summary>
	/// 向当前集合中添加多个项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">添加的项目数组</param>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者添加的项目数组 <paramref name="items" /> 为空。</exception>
	public static void AddRange<T>(this ICollection<T> collection, params T[] items)
	{
		collection.AddRange(items, 1);
	}

	/// <summary>
	/// 向当前集合中添加多个项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">添加的项目序列</param>
	/// <param name="times">项目序列添加的次数</param>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者添加的项目序列 <paramref name="items" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">项目序列添加的次数 <paramref name="items" /> 小于0。</exception>
	public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items, int times = 1)
	{
		collection.GuardNotNull("collection");
		items.GuardNotNull("items");
		times.GuardGreaterThanOrEqualTo(0, "times");
		while (times-- > 0)
		{
			foreach (T item in items)
			{
				collection.Add(item);
			}
		}
	}

	/// <summary>
	/// 向当前集合中添加多个项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <typeparam name="V">添加的项目序列</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">添加的项目序列</param>
	/// <param name="evaluation">项目值处理方法</param>
	/// <param name="times">项目序列添加次数</param>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者添加的项目序列 <paramref name="items" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">项目序列添加的次数</exception>
	public static void AddRange<T, V>(this ICollection<T> collection, IEnumerable<V> items, Func<V, T> evaluation, int times = 1)
	{
		evaluation.GuardNotNull("evaluation");
		collection.AddRange(items, (V x, int i) => evaluation(x), times);
	}

	/// <summary>
	/// 向当前集合中添加多个项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <typeparam name="V">添加的项目序列</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">添加的项目序列</param>
	/// <param name="evaluation">项目值处理方法</param>
	/// <param name="times">项目序列添加次数</param>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者添加的项目序列 <paramref name="items" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">项目序列添加的次数</exception>
	public static void AddRange<T, V>(this ICollection<T> collection, IEnumerable<V> items, Func<V, int, T> evaluation, int times = 1)
	{
		collection.GuardNotNull("collection");
		items.GuardNotNull("items");
		evaluation.GuardNotNull("evaluation");
		times.GuardGreaterThanOrEqualTo(0, "times");
		while (times-- > 0)
		{
			int index = 0;
			foreach (V item in items)
			{
				collection.Add(evaluation(item, index++));
			}
		}
	}

	/// <summary>
	/// 向当前集合中添加多个项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">添加的项目序列</param>
	/// <param name="copying">项目复制方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者添加的项目序列 <paramref name="copying" /> 为空。</exception>
	public static void AddRangeCopy<T>(this ICollection<T> collection, IEnumerable<T> items, Func<T, T> copying)
	{
		collection.AddRangeCopy(items, 1, copying);
	}

	/// <summary>
	/// 向当前集合中添加多个项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">添加的项目序列</param>
	/// <param name="copying">项目复制方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者添加的项目序列 <paramref name="copying" /> 为空。</exception>
	public static void AddRangeCopy<T>(this ICollection<T> collection, IEnumerable<T> items, Func<T, int, T> copying)
	{
		collection.AddRangeCopy(items, 1, copying);
	}

	/// <summary>
	/// 向当前集合中添加多个项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">添加的项目序列</param>
	/// <param name="times">项目序列添加次数</param>
	/// <param name="copying">项目复制方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者添加的项目序列 <paramref name="copying" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">项目序列添加的次数 <paramref name="times" /> 小于0。</exception>
	public static void AddRangeCopy<T>(this ICollection<T> collection, IEnumerable<T> items, int times, Func<T, T> copying = null)
	{
		copying = copying.IfNull((T x) => x.ShallowCopy());
		collection.AddRangeCopy(items, times, (T x, int i) => copying(x));
	}

	/// <summary>
	/// 向当前集合中添加多个项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">添加的项目序列</param>
	/// <param name="times">项目序列添加次数</param>
	/// <param name="copying">项目复制方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者添加的项目序列 <paramref name="copying" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">项目序列添加的次数 <paramref name="times" /> 小于0。</exception>
	public static void AddRangeCopy<T>(this ICollection<T> collection, IEnumerable<T> items, int times, Func<T, int, T> copying)
	{
		collection.GuardNotNull("collection");
		items.GuardNotNull("items");
		times.GuardGreaterThanOrEqualTo(0, "times");
		copying = copying.IfNull((T x, int i) => x.ShallowCopy());
		while (times-- > 0)
		{
			int index = 0;
			foreach (T item in items)
			{
				collection.Add(copying(item, index++));
			}
		}
	}

	/// <summary>
	/// 向当前集合中添加唯一的项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="item">待添加的项目</param>
	/// <param name="equaliter">集合元素相等比较器</param>
	/// <returns>如果添加成功返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空。</exception>
	public static bool AddUnique<T>(this ICollection<T> collection, T item, IEqualityComparer<T> equaliter = null)
	{
		collection.GuardNotNull("collection");
		equaliter = equaliter.IfNull(EqualityComparer<T>.Default);
		if (collection.Contains(item, equaliter))
		{
			return false;
		}
		collection.Add(item);
		return true;
	}

	/// <summary>
	/// 向当前集合中添加唯一的项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="item">待添加的项目</param>
	/// <param name="equalition">集合元素相等比较方法</param>
	/// <returns>如果添加成功返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空。</exception>
	public static bool AddUnique<T>(this ICollection<T> collection, T item, Func<T, T, bool> equalition)
	{
		collection.GuardNotNull("collection");
		equalition = equalition.IfNull(EqualityComparer<T>.Default.Equals);
		if (collection.Contains(item, equalition))
		{
			return false;
		}
		collection.Add(item);
		return true;
	}

	/// <summary>
	/// 向当前集合中添加唯一的项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <typeparam name="V">待添加的项目类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="item">待添加的项目</param>
	/// <param name="evaluation">项目处理方法</param>
	/// <param name="equaliter">集合元素比较器</param>
	/// <returns>如果添加成功返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者项目处理方法 <paramref name="evaluation" /> 为空。</exception>
	public static bool AddUnique<T, V>(this ICollection<T> collection, V item, Func<V, T> evaluation, IEqualityComparer<T> equaliter = null)
	{
		collection.GuardNotNull("collection");
		evaluation.GuardNotNull("evaluator");
		return collection.AddUnique(evaluation(item), equaliter);
	}

	/// <summary>
	/// 向当前集合中添加唯一的项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <typeparam name="V">待添加的项目类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="item">待添加的项目</param>
	/// <param name="evaluation">项目处理方法</param>
	/// <param name="equalition">集合元素比较方法</param>
	/// <returns>如果添加成功返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者项目处理方法 <paramref name="evaluation" /> 为空。</exception>
	public static bool AddUnique<T, V>(this ICollection<T> collection, V item, Func<V, T> evaluation, Func<T, T, bool> equalition)
	{
		collection.GuardNotNull("collection");
		evaluation.GuardNotNull("evaluator");
		return collection.AddUnique(evaluation(item), equalition);
	}

	/// <summary>
	/// 向当前集合中添加唯一的项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <typeparam name="V">待添加的项目类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="item">待添加的项目</param>
	/// <param name="equalition">集合元素比较方法</param>
	/// <param name="evaluator">项目处理方法</param>
	/// <returns>如果添加成功返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者项目处理方法 <paramref name="evaluator" /> 为空；或者集合元素比较方法 <paramref name="equalition" /> 为空。</exception>
	public static bool AddUnique<T, V>(this ICollection<T> collection, V item, Func<T, V, bool> equalition, Func<V, T> evaluator)
	{
		collection.GuardNotNull("collection");
		equalition.GuardNotNull("equalition");
		evaluator.GuardNotNull("evaluator");
		if (collection.ContainsValue(item, equalition))
		{
			return false;
		}
		collection.Add(evaluator(item));
		return true;
	}

	/// <summary>
	/// 向当前集合中插入指定序列中的项目，重复的项目将不会添加
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">待添加的项目数组</param>
	/// <returns>返回成功添加的项目数量</returns>
	public static int AddRangeUnique<T>(this ICollection<T> collection, params T[] items)
	{
		return collection.AddRangeUnique((IEnumerable<T>)items, (IEqualityComparer<T>)null);
	}

	/// <summary>
	/// 向当前集合中插入指定序列中的项目，重复的项目将不会添加
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">待添加的项目序列</param>
	/// <param name="equaliter">集合论元素比较器</param>
	/// <returns>返回成功添加的项目数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者添加的项目序列 <paramref name="items" /> 为空。</exception>
	public static int AddRangeUnique<T>(this ICollection<T> collection, IEnumerable<T> items, IEqualityComparer<T> equaliter = null)
	{
		collection.GuardNotNull("collection");
		items.GuardNotNull("items");
		int count = 0;
		foreach (T item in items)
		{
			if (collection.AddUnique(item, equaliter))
			{
				count++;
			}
		}
		return count;
	}

	/// <summary>
	/// 向当前集合中插入指定序列中的项目，重复的项目将不会添加
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">待添加的项目序列</param>
	/// <param name="equalition">集合论元素比较方法</param>
	/// <returns>返回成功添加的项目数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者添加的项目序列 <paramref name="items" /> 为空。</exception>
	public static int AddRangeUnique<T>(this ICollection<T> collection, IEnumerable<T> items, Func<T, T, bool> equalition)
	{
		collection.GuardNotNull("collection");
		items.GuardNotNull("items");
		int count = 0;
		foreach (T item in items)
		{
			if (collection.AddUnique(item, equalition))
			{
				count++;
			}
		}
		return count;
	}

	/// <summary>
	/// 向当前集合中插入指定序列中的项目，重复的项目将不会添加
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <typeparam name="V">待添加的项目类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">待添加的项目序列</param>
	/// <param name="evaluator">项目处理方法</param>
	/// <param name="equaliter">集合元素比较器</param>
	/// <returns>返回成功添加的项目数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者添加的项目序列 <paramref name="items" /> 为空；或者项目处理方法 <paramref name="evaluator" /> 为空。</exception>
	public static int AddRangeUnique<T, V>(this ICollection<T> collection, IEnumerable<V> items, Func<V, T> evaluator, IEqualityComparer<T> equaliter = null)
	{
		collection.GuardNotNull("collection");
		items.GuardNotNull("items");
		evaluator.GuardNotNull("evaluator");
		return collection.AddRangeUnique(items, (V x, int i) => evaluator(x), equaliter);
	}

	/// <summary>
	/// 向当前集合中插入指定序列中的项目，重复的项目将不会添加
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <typeparam name="V">待添加的项目类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">待添加的项目序列</param>
	/// <param name="evaluator">项目处理方法</param>
	/// <param name="equalition">集合元素比较方法</param>
	/// <returns>返回成功添加的项目数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者添加的项目序列 <paramref name="items" /> 为空；或者项目处理方法 <paramref name="evaluator" /> 为空。</exception>
	public static int AddRangeUnique<T, V>(this ICollection<T> collection, IEnumerable<V> items, Func<V, T> evaluator, Func<T, T, bool> equalition)
	{
		collection.GuardNotNull("collection");
		items.GuardNotNull("items");
		evaluator.GuardNotNull("evaluator");
		return collection.AddRangeUnique(items, (V x, int i) => evaluator(x), equalition);
	}

	/// <summary>
	/// 向当前集合中插入指定序列中的项目，重复的项目将不会添加
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <typeparam name="V">待添加的项目类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">待添加的项目序列</param>
	/// <param name="evaluator">项目处理方法</param>
	/// <param name="equliater">集合元素比较器</param>
	/// <returns>返回成功添加的项目数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者添加的项目序列 <paramref name="items" /> 为空；或者项目处理方法 <paramref name="evaluator" /> 为空。</exception>
	public static int AddRangeUnique<T, V>(this ICollection<T> collection, IEnumerable<V> items, Func<V, int, T> evaluator, IEqualityComparer<T> equliater = null)
	{
		collection.GuardNotNull("collection");
		items.GuardNotNull("items");
		evaluator.GuardNotNull("evaluator");
		int count = 0;
		if (items.IsNotNull())
		{
			int index = 0;
			foreach (V item in items)
			{
				if (collection.AddUnique(item, (V x) => evaluator(x, index++), equliater))
				{
					count++;
				}
			}
		}
		return count;
	}

	/// <summary>
	/// 向当前集合中插入指定序列中的项目，重复的项目将不会添加
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <typeparam name="V">待添加的项目类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">待添加的项目序列</param>
	/// <param name="evaluator">项目处理方法</param>
	/// <param name="equalition">集合元素比较方法</param>
	/// <returns>返回成功添加的项目数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者添加的项目序列 <paramref name="items" /> 为空；或者项目处理方法 <paramref name="evaluator" /> 为空。</exception>
	public static int AddRangeUnique<T, V>(this ICollection<T> collection, IEnumerable<V> items, Func<V, int, T> evaluator, Func<T, T, bool> equalition)
	{
		collection.GuardNotNull("collection");
		items.GuardNotNull("items");
		evaluator.GuardNotNull("evaluator");
		int count = 0;
		if (items.IsNotNull())
		{
			int index = 0;
			foreach (V item in items)
			{
				if (collection.AddUnique(item, (V x) => evaluator(x, index++), equalition))
				{
					count++;
				}
			}
		}
		return count;
	}

	/// <summary>
	/// 向当前集合中插入指定序列中的项目，重复的项目将不会添加
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <typeparam name="V">待添加的项目类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">待添加的项目序列</param>
	/// <param name="equalition">集合元素比较方法</param>
	/// <param name="evaluator">项目处理方法</param>
	/// <returns>返回成功添加的项目数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者添加的项目序列 <paramref name="items" /> 为空；或者集合元素比较方法 <paramref name="equalition" /> 为空；或者项目处理方法 <paramref name="evaluator" /> 为空。</exception>
	public static int AddRangeUnique<T, V>(this ICollection<T> collection, IEnumerable<V> items, Func<T, V, bool> equalition, Func<V, T> evaluator)
	{
		collection.GuardNotNull("collection");
		items.GuardNotNull("items");
		equalition.GuardNotNull("equalition");
		evaluator.GuardNotNull("evaluator");
		return collection.AddRangeUnique(items, equalition, (V x, int i) => evaluator(x));
	}

	/// <summary>
	/// 向当前集合中插入指定序列中的项目，重复的项目将不会添加
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <typeparam name="V">待添加的项目类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">待添加的项目序列</param>
	/// <param name="equalition">集合元素比较方法</param>
	/// <param name="evaluator">项目处理方法</param>
	/// <returns>返回成功添加的项目数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者添加的项目序列 <paramref name="items" /> 为空；或者集合元素比较方法 <paramref name="equalition" /> 为空；或者项目处理方法 <paramref name="evaluator" /> 为空。</exception>
	public static int AddRangeUnique<T, V>(this ICollection<T> collection, IEnumerable<V> items, Func<T, V, bool> equalition, Func<V, int, T> evaluator)
	{
		collection.GuardNotNull("collection");
		items.GuardNotNull("items");
		equalition.GuardNotNull("equalition");
		evaluator.GuardNotNull("evaluator");
		int count = 0;
		int index = 0;
		foreach (V item in items)
		{
			if (collection.AddUnique(item, equalition, (V x) => evaluator(x, index++)))
			{
				count++;
			}
		}
		return count;
	}

	/// <summary>
	/// 将当前集合作为 <see cref="T:System.Collections.Generic.ICollection`1" /> 类型返回
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <returns><see cref="T:System.Collections.Generic.ICollection`1" /> 类型的集合</returns>
	public static ICollection<T> AsCollection<T>(this ICollection<T> collection)
	{
		return collection;
	}

	/// <summary>
	/// 检测当前集合是否为空或者不包含任何元素。
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <returns>如果当前集合为空或者不包含任何元素返回true，否则返回false。</returns>
	public static bool IsNullOrEmpty<T>(this ICollection<T> collection)
	{
		return collection.IsNull() || collection.Count == 0;
	}

	/// <summary>
	/// 检测当前集合是否不为空且包含元素
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <returns>如果当前集合不为空且包含元素返回true，否则返回false。</returns>
	public static bool IsNotNullAndEmpty<T>(this ICollection<T> collection)
	{
		return collection.IsNotNull() && collection.Count > 0;
	}

	/// <summary>
	/// 从当前集合中移除序列中每个元素匹配的第一个项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">移除的匹配元素数组</param>
	/// <returns>移除的元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者移除的元素序列 <paramref name="items" /> 为空。</exception>
	public static int Remove<T>(this ICollection<T> collection, params T[] items)
	{
		return collection.Remove((IEnumerable<T>)items);
	}

	/// <summary>
	/// 从当前集合中移除序列中每个元素匹配的第一个项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">移除的匹配元素序列</param>
	/// <returns>移除的元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者移除的元素序列 <paramref name="items" /> 为空。</exception>
	public static int Remove<T>(this ICollection<T> collection, IEnumerable<T> items)
	{
		collection.GuardNotNull("collection");
		items.GuardNotNull("items");
		int count = 0;
		foreach (T item in items)
		{
			if (collection.Remove(item))
			{
				count++;
			}
		}
		return count;
	}

	/// <summary>
	/// 从当前集合中移除数组中任意元素匹配的第一个项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">移除的匹配元素数组</param>
	/// <returns>如果成功移除元素返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者移除的元素数组 <paramref name="items" /> 为空。</exception>
	public static bool RemoveAny<T>(this ICollection<T> collection, params T[] items)
	{
		return collection.RemoveAny((IEnumerable<T>)items);
	}

	/// <summary>
	/// 从当前集合中移除序列中任意元素匹配的第一个项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">移除的匹配元素序列</param>
	/// <returns>如果成功移除元素返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空；或者移除的元素序列 <paramref name="items" /> 为空。</exception>
	public static bool RemoveAny<T>(this ICollection<T> collection, IEnumerable<T> items)
	{
		collection.GuardNotNull("collection");
		items.GuardNotNull("items");
		foreach (T item in items)
		{
			if (collection.Remove(item))
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 从当前集合中移除所有与指定元素匹配的元素
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="item">移除的元素</param>
	/// <returns>移除的元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前集合为空。</exception>
	public static int RemoveAll<T>(this ICollection<T> collection, T item)
	{
		collection.GuardNotNull("collection");
		int count = 0;
		while (collection.Remove(item))
		{
			count++;
		}
		return count;
	}

	/// <summary>
	/// 从当前集合中移除所有与指定的序列中的任一元素匹配的项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">待移除的元素数组</param>
	/// <returns>移除的元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者移除的元素数组 <paramref name="items" /> 为空。</exception>
	public static int RemoveAll<T>(this ICollection<T> collection, params T[] items)
	{
		return collection.RemoveAll((IEnumerable<T>)items);
	}

	/// <summary>
	/// 从当前集合中移除所有与指定的序列中的任一元素匹配的项目
	/// </summary>
	/// <typeparam name="T">当前集合元素类型</typeparam>
	/// <param name="collection">当前集合</param>
	/// <param name="items">待移除的元素序列</param>
	/// <returns>移除的元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空；或者移除的元素序列 <paramref name="items" /> 为空。</exception>
	public static int RemoveAll<T>(this ICollection<T> collection, IEnumerable<T> items)
	{
		collection.GuardNotNull("collection");
		items.GuardNotNull("items");
		int count = 0;
		foreach (T item in items)
		{
			count += collection.RemoveAll(item);
		}
		return count;
	}
}
