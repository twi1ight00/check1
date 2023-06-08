using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Richfit.Garnet.Common.Extensions.Collections;

/// <summary>
/// <see cref="T:System.Collections.IList" /> 接口扩展方法类
/// </summary>
public static class IListExtensions
{
	/// <summary>
	/// 将当前列表作为 <see cref="T:System.Collections.IList" /> 类型的集合返回
	/// </summary>
	/// <param name="list">输入列表</param>
	/// <returns><see cref="T:System.Collections.IList" /> 类型的列表</returns>
	public static IList AsList(this IList list)
	{
		return list;
	}

	/// <summary>
	/// 在当前列表中使用二分法查找指定的项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="predicate">当前元素的判断条件，继续左半部分判断返回小于0的值，继续右半部分的判断返回大于0的值</param>
	/// <returns>如果找到匹配的元素返回该元素的位置索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者元素判断条件 <paramref name="predicate" /> 为空。</exception>
	public static int BinarySearch(this IList list, Func<object, int> predicate)
	{
		list.GuardNotNull("list");
		return list.BinarySearch(0, list.Count, predicate);
	}

	/// <summary>
	/// 在当前列表的指定区域中使用二分法查找指定的项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="item">待查找的元素</param>
	/// <param name="comparer">序列元素比较器</param>
	/// <returns>如果找到匹配的元素返回该元素的位置索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	public static int BinarySearch(this IList list, object item, IComparer comparer)
	{
		list.GuardNotNull("list");
		return list.BinarySearch(0, list.Count, item, comparer.IfNull(Comparer.Default).Compare);
	}

	/// <summary>
	/// 在当前列表的指定区域中使用二分法查找指定的项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="item">待查找的元素</param>
	/// <param name="comparison">序列元素比较方法</param>
	/// <returns>如果找到匹配的元素返回该元素的位置索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	public static int BinarySearch(this IList list, object item, Func<object, object, int> comparison)
	{
		list.GuardNotNull("list");
		return list.BinarySearch(0, list.Count, item, comparison.IfNull(Comparer.Default.Compare));
	}

	/// <summary>
	/// 在当前列表的指定区域中使用二分法查找指定的项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="start">查找区域的起始位置</param>
	/// <param name="count">查找区域中的元素数量</param>
	/// <param name="predicate">当前元素的判断条件，继续左半部分判断返回小于0的值，继续右半部分的判断返回大于0的值</param>
	/// <returns>如果找到匹配的元素返回该元素的位置索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者元素判断条件 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找起始位置 <paramref name="start" /> 小于0，或者大于当前列表元素的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的元素数量 <paramref name="count" /> 小于0，或者当前列表从起始位置 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static int BinarySearch(this IList list, int start, int count, Func<object, int> predicate)
	{
		list.GuardNotNull("list");
		start.GuardIndexRange(0, list.Count - 1, "start");
		count.GuardBetween(0, list.Count - start, "count");
		predicate.GuardNotNull("predicate");
		int i = start;
		int j = ((count > 0) ? (start + count - 1) : start);
		while (i <= j)
		{
			int median = start + count >> 1;
			int result = predicate(list[median]);
			if (result > 0)
			{
				i = median - 1;
				continue;
			}
			if (result < 0)
			{
				j = median - 1;
				continue;
			}
			return median;
		}
		return -1;
	}

	/// <summary>
	/// 在当前列表的指定区域中使用二分法查找指定的项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="start">查找区域的起始位置</param>
	/// <param name="count">查找区域中的元素数量</param>
	/// <param name="item">待查找的元素</param>
	/// <param name="comparer">序列元素比较器</param>
	/// <returns>如果找到匹配的元素返回该元素的位置索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找起始位置 <paramref name="start" /> 小于0，或者大于当前列表元素的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的元素数量 <paramref name="count" /> 小于0，或者当前列表从起始位置 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static int BinarySearch(this IList list, int start, int count, object item, IComparer comparer)
	{
		return list.BinarySearch(start, count, item, comparer.IfNull(Comparer.Default).Compare);
	}

	/// <summary>
	/// 在当前列表的指定区域中使用二分法查找指定的项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="start">查找区域的起始位置</param>
	/// <param name="count">查找区域中的元素数量</param>
	/// <param name="item">待查找的元素</param>
	/// <param name="comparison">序列元素比较方法</param>
	/// <returns>如果找到匹配的元素返回该元素的位置索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找起始位置 <paramref name="start" /> 小于0，或者大于当前列表元素的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的元素数量 <paramref name="count" /> 小于0，或者当前列表从起始位置 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static int BinarySearch(this IList list, int start, int count, object item, Func<object, object, int> comparison)
	{
		comparison = comparison.IfNull(Comparer.Default.Compare);
		return list.BinarySearch(start, count, (object x) => comparison(item, x));
	}

	/// <summary>
	/// 填充当前列表
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="value">列表填充的值</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	public static void Fill(this IList list, object value)
	{
		list.GuardNotNull("list");
		for (int i = 0; i < list.Count; i++)
		{
			list[i] = value;
		}
	}

	/// <summary>
	/// 填充当前列表
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="evaluation">元素计算方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者列表元素值计算方法为空。</exception>
	public static void Fill(this IList list, Func<object> evaluation)
	{
		list.GuardNotNull("list");
		evaluation.GuardNotNull("evaluator");
		list.Fill((object x, int i) => evaluation());
	}

	/// <summary>
	/// 填充当前列表
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="evaluation">元素计算方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者列表元素值计算方法为空。</exception>
	public static void Fill(this IList list, Func<int, object> evaluation)
	{
		list.GuardNotNull("list");
		evaluation.GuardNotNull("evaluator");
		list.Fill((object x, int i) => evaluation(i));
	}

	/// <summary>
	/// 填充当前列表
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="evaluation">元素计算方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者列表元素值计算方法为空。</exception>
	public static void Fill(this IList list, Func<object, int, object> evaluation)
	{
		list.GuardNotNull("list");
		evaluation.GuardNotNull("evaluator");
		for (int i = 0; i < list.Count; i++)
		{
			list[i] = evaluation(list[i], i);
		}
	}

	/// <summary>
	/// 向当前列表中插入元素值
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="item">待插入的元素</param>
	/// <param name="times">元素插入的次数</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置小于0，或者大于当前列表元素个数。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">插入次数小于0。</exception>
	public static void Insert(this IList list, int index, object item, int times)
	{
		list.GuardNotNull("list");
		index.GuardIndexRange(0, list.Count, "index");
		times.GuardGreaterThanOrEqualTo(0, "times");
		while (times-- > 0)
		{
			list.Insert(index++, item);
		}
	}

	/// <summary>
	/// 向当前列表中插入元素值
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="item">插入的元素</param>
	/// <param name="evaluation">元素值处理方法</param>
	/// <param name="times">元素插入的次数</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者元素值处理方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置小于0，或者大于当前列表元素个数。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">插入次数小于0。</exception>
	public static void Insert(this IList list, int index, object item, Func<object, object> evaluation, int times = 1)
	{
		list.GuardNotNull("list");
		index.GuardIndexRange(0, list.Count, "index");
		evaluation.GuardNotNull("evaluator");
		list.Insert(index, evaluation(item), times);
	}

	/// <summary>
	/// 向当前列表中插入元素值
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="evaluation">计算方法</param>
	/// <param name="times">元素插入的次数</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者计算方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置小于0，或者大于当前列表元素个数。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">插入次数小于0。</exception>
	public static void Insert(this IList list, int index, Func<object> evaluation, int times = 1)
	{
		evaluation.GuardNotNull("evaluator");
		list.Insert(index, (int i) => evaluation(), times);
	}

	/// <summary>
	/// 向当前列表中插入元素值
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="evaluation">计算方法</param>
	/// <param name="times">元素插入的次数</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者计算方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置小于0，或者大于当前列表元素个数。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">插入次数小于0。</exception>
	public static void Insert(this IList list, int index, Func<int, object> evaluation, int times = 1)
	{
		list.GuardNotNull("list");
		index.GuardIndexRange(0, list.Count, "index");
		evaluation.GuardNotNull("evaluator");
		times.GuardGreaterThanOrEqualTo(0, "times");
		for (int i = 0; i < times; i++)
		{
			list.Insert(index++, evaluation(i));
		}
	}

	/// <summary>
	/// 向当前列表中插入指定项目的副本，默认将插入指定项目的浅表副本
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="item">待插入的项目</param>
	/// <param name="copying">项目复制函数</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置小于0，或者大于当前列表元素个数。</exception>
	public static void InsertCopy(this IList list, int index, object item, Func<object, object> copying = null)
	{
		list.GuardNotNull("list");
		index.GuardIndexRange(0, list.Count, "index");
		copying = copying.IfNull((object x) => x.ShallowCopy());
		list.Insert(index, copying(item));
	}

	/// <summary>
	/// 向当前列表中插入指定项目的副本，默认将插入指定项目的浅表副本
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="item">待插入的项目</param>
	/// <param name="times">插入次数</param>
	/// <param name="copying">项目复制函数</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置小于0，或者大于当前列表元素个数。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">插入次数小于0。</exception>
	public static void InsertCopy(this IList list, int index, object item, int times, Func<object, object> copying = null)
	{
		list.GuardNotNull("list");
		index.GuardIndexRange(0, list.Count, "index");
		times.GuardGreaterThanOrEqualTo(0, "times");
		copying = copying.IfNull((object x) => x.ShallowCopy());
		while (times-- > 0)
		{
			list.Insert(index++, copying(item));
		}
	}

	/// <summary>
	/// 向当前列表中插入指定项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入的位置</param>
	/// <param name="items">待插入的元素数组</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者插入的元素数组 <paramref name="items" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置小于0，或者大于当前列表元素个数。</exception>
	public static void InsertRange(this IList list, int index, params object[] items)
	{
		list.InsertRange(index, items, 1);
	}

	/// <summary>
	/// 向当前列表中插入指定的元素序列
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入的位置</param>
	/// <param name="items">待插入的元素序列</param>
	/// <param name="times">插入次数</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；插入的元素序列 <paramref name="items" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置小于0，或者大于当前列表元素个数。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">插入的次数小于0。</exception>
	public static void InsertRange(this IList list, int index, IEnumerable items, int times = 1)
	{
		list.GuardNotNull("list");
		index.GuardIndexRange(0, list.Count, "index");
		items.GuardNotNull("items");
		times.GuardGreaterThanOrEqualTo(0, "times");
		while (times-- > 0)
		{
			foreach (object item in items)
			{
				list.Insert(index++, item);
			}
		}
	}

	/// <summary>
	/// 向当前列表中插入指定的元素序列
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入的位置</param>
	/// <param name="items">待插入的元素序列</param>
	/// <param name="evaluation">元素处理方法</param>
	/// <param name="times">插入次数</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者插入的元素序列 <paramref name="items" /> 为空：或者元素处理方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置小于0，或者大于当前列表元素个数。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">插入的次数小于0。</exception>
	public static void InsertRange(this IList list, int index, IEnumerable items, Func<object, object> evaluation, int times = 1)
	{
		evaluation.GuardNotNull("evaluator");
		list.InsertRange(index, items, (object x, int i) => evaluation(x), times);
	}

	/// <summary>
	/// 向当前列表中插入指定的元素序列
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入的位置</param>
	/// <param name="items">待插入的元素序列</param>
	/// <param name="evaluation">项目处理方法</param>
	/// <param name="times">插入次数</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空：或者插入的元素序列 <paramref name="items" /> 为空；或者元素处理方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置小于0，或者大于当前列表元素个数。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">插入的次数小于0。</exception>
	public static void InsertRange(this IList list, int index, IEnumerable items, Func<object, int, object> evaluation, int times = 1)
	{
		list.GuardNotNull("list");
		index.GuardIndexRange(0, list.Count, "index");
		items.GuardNotNull("items");
		evaluation.GuardNotNull("evaluator");
		times.GuardGreaterThanOrEqualTo(0, "times");
		while (times-- > 0)
		{
			int no = 0;
			foreach (object item in items)
			{
				list.Insert(index++, evaluation(item, no++));
			}
		}
	}

	/// <summary>
	/// 向当前列表中插入指定序列元素的副本，默认插入序列元素的浅表副本
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="items">插入的元素序列</param>
	/// <param name="copying">元素复制方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者插入的元素序列 <paramref name="items" /> 为空。</exception>
	public static void InsertRangeCopy(this IList list, int index, IEnumerable items, Func<object, object> copying = null)
	{
		copying = copying.IfNull((object x) => x.ShallowCopy());
		list.InsertRangeCopy(index, items, (object x, int i) => copying(x));
	}

	/// <summary>
	/// 向当前列表中插入指定序列元素的副本，默认插入序列元素的浅表副本
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="items">插入的元素序列</param>
	/// <param name="copying">元素复制方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者插入的元素序列 <paramref name="items" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置 <paramref name="index" /> 小于0，或者大于列表元素的数量。</exception>
	public static void InsertRangeCopy(this IList list, int index, IEnumerable items, Func<object, int, object> copying)
	{
		list.GuardNotNull("list");
		index.GuardIndexRange(0, list.Count, "index");
		items.GuardNotNull("items");
		copying = copying.IfNull((object x, int i) => x.ShallowCopy());
		int no = 0;
		foreach (object item in items)
		{
			list.Insert(index++, copying(item, no++));
		}
	}

	/// <summary>
	/// 向当前列表中插入指定序列元素的副本，默认插入序列元素的浅表副本
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="items">插入的元素序列</param>
	/// <param name="times">插入的次数</param>
	/// <param name="copying">元素复制方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；插入的元素序列 <paramref name="items" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置 <paramref name="index" /> 小于0，或者大于列表元素的数量。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">插入的次数小于0。</exception>
	public static void InsertRangeCopy(this IList list, int index, IEnumerable items, int times, Func<object, object> copying = null)
	{
		copying = copying.IfNull((object x) => x.ShallowCopy());
		list.InsertRangeCopy(index, items, times, (object x, int i) => copying(x));
	}

	/// <summary>
	/// 向当前列表中插入指定序列元素的副本，默认插入序列元素的浅表副本
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="items">插入的元素序列</param>
	/// <param name="times">插入的次数</param>
	/// <param name="copying">元素复制方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；插入的元素序列 <paramref name="items" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置 <paramref name="index" /> 小于0，或者大于列表元素的数量。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">插入的次数小于0。</exception>
	public static void InsertRangeCopy(this IList list, int index, IEnumerable items, int times, Func<object, int, object> copying)
	{
		list.GuardNotNull("list");
		index.GuardIndexRange(0, list.Count, "index");
		items.GuardNotNull("items");
		times.GuardGreaterThanOrEqualTo(0, "times");
		copying = copying.IfNull((object x, int i) => x.ShallowCopy());
		int no = 0;
		while (times-- > 0)
		{
			no = 0;
			foreach (object item in items)
			{
				list.Insert(index++, copying(item, no++));
			}
		}
	}

	/// <summary>
	/// 向当前列表中插入唯一的元素
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="item">待插入的元素</param>
	/// <param name="equalition">列表元素相等比较方法</param>
	/// <returns>如果插入成功返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置 <paramref name="index" /> 小于0，或者大于列表元素的数量。</exception>
	public static bool InsertUnique(this IList list, int index, object item, Func<object, object, bool> equalition = null)
	{
		list.GuardNotNull("list");
		index.GuardIndexRange(0, list.Count, "index");
		equalition = equalition.IfNull(ObjectExtensions.ObjectEquals);
		if (!list.Contains(item, equalition))
		{
			list.Insert(index, item);
			return true;
		}
		return false;
	}

	/// <summary>
	/// 向当前序列中插入唯一的元素
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="item">待插入的元素</param>
	/// <param name="evaluation">元素处理方法</param>
	/// <param name="equalition">列表元素比较方法</param>
	/// <returns>如果插入成功返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者元素处理方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置 <paramref name="index" /> 小于0，或者大于列表元素的数量。</exception>
	public static bool InsertUnique(this IList list, int index, object item, Func<object, object> evaluation, Func<object, object, bool> equalition = null)
	{
		list.GuardNotNull("list");
		index.GuardIndexRange(0, list.Count, "index");
		evaluation.GuardNotNull("evaluator");
		return list.InsertUnique(index, evaluation(item), equalition);
	}

	/// <summary>
	/// 向当前序列中插入指定元素序列，重复的元素将不会插入
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="items">插入的元素数组</param>
	/// <returns>返回成功插入的元素数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；插入的元素数组 <paramref name="items" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置 <paramref name="index" /> 小于0，或者大于列表元素的数量。</exception>
	public static int InsertRangeUnique(this IList list, int index, params object[] items)
	{
		return list.InsertRangeUnique(index, (IEnumerable)items, (Func<object, object, bool>)null);
	}

	/// <summary>
	/// 向当前序列中插入指定元素序列，重复的元素将不会插入
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="items">插入的元素序列</param>
	/// <param name="equalition">元素比较方法</param>
	/// <returns>返回成功插入的元素数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；插入的元素序列 <paramref name="items" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置 <paramref name="index" /> 小于0，或者大于列表元素的数量。</exception>
	public static int InsertRangeUnique(this IList list, int index, IEnumerable items, Func<object, object, bool> equalition = null)
	{
		list.GuardNotNull("list");
		index.GuardIndexRange(0, list.Count, "index");
		items.GuardNotNull("items");
		int count = 0;
		foreach (object item in items)
		{
			if (list.InsertUnique(index, item, equalition))
			{
				index++;
				count++;
			}
		}
		return count;
	}

	/// <summary>
	/// 向当前序列中插入指定元素序列，重复的元素将不会插入
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="items">插入的元素序列</param>
	/// <param name="evaluation">元素处理方法</param>
	/// <param name="equalition">元素比较方法</param>
	/// <returns>返回成功插入的元素数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者插入的元素序列 <paramref name="items" /> 为空；或者元素处理方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置 <paramref name="index" /> 小于0，或者大于列表元素的数量。</exception>
	public static int InsertRangeUnique(this IList list, int index, IEnumerable items, Func<object, object> evaluation, Func<object, object, bool> equalition = null)
	{
		evaluation.GuardNotNull("evaluator");
		return list.InsertRangeUnique(index, items, (object x, int i) => evaluation(x), equalition);
	}

	/// <summary>
	/// 向当前序列中插入指定元素序列，重复的元素将不会插入
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="index">插入位置</param>
	/// <param name="items">插入的元素序列</param>
	/// <param name="evaluation">元素处理方法</param>
	/// <param name="equalition">元素比较方法</param>
	/// <returns>返回成功插入的元素数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者插入的元素序列 <paramref name="items" /> 为空；或者元素处理方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置 <paramref name="index" /> 小于0，或者大于列表元素的数量。</exception>
	public static int InsertRangeUnique(this IList list, int index, IEnumerable items, Func<object, int, object> evaluation, Func<object, object, bool> equalition = null)
	{
		list.GuardNotNull("list");
		index.GuardIndexRange(0, list.Count, "index");
		items.GuardNotNull("items");
		evaluation.GuardNotNull("evaluator");
		int count = 0;
		int no = 0;
		foreach (object item in items)
		{
			if (list.InsertUnique(index, item, (object x) => evaluation(x, no++), equalition))
			{
				index++;
				count++;
			}
		}
		return count;
	}

	/// <summary>
	/// 将当前列表指定的序列进行合并, 相同的序列元素由指定的合并方法进行处理
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="items">合并的序列</param>
	/// <param name="merging">合并相同元素的方法，接收列表中的元素和待合并的相同的元素</param>
	/// <param name="equalition">合并元素的比较方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者合并的序列 <paramref name="items" /> 为空；或者合并方法 <paramref name="merging" /> 为空。</exception>
	public static void Merge(this IList list, IEnumerable items, Func<object, object, object> merging, Func<object, object, bool> equalition = null)
	{
		list.GuardNotNull("list");
		items.GuardNotNull("items");
		merging.GuardNotNull("merging");
		equalition = equalition.IfNull(ObjectExtensions.ObjectEquals);
		int index = 0;
		foreach (object item in items)
		{
			if ((index = list.IndexOf(item, equalition)) >= 0)
			{
				list[index] = merging(list[index], item);
			}
			else
			{
				list.Add(item);
			}
		}
	}

	/// <summary>
	/// 将当前列表指定的序列进行合并, 相同的序列元素由指定的合并方法进行处理
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="items">合并的序列</param>
	/// <param name="merging">合并中找到相同元素的合并方法，接收当前列表、当前列表中重复元素的索引以及待合并的元素</param>
	/// <param name="equalition">合并元素的比较方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者合并序列 <paramref name="items" /> 为空；或者合并方法 <paramref name="merging" /> 为空。</exception>
	public static void Merge(this IList list, IEnumerable items, Action<IList, int, object> merging, Func<object, object, bool> equalition = null)
	{
		list.GuardNotNull("list");
		items.GuardNotNull("items");
		merging.GuardNotNull("merging");
		equalition = equalition.IfNull(ObjectExtensions.ObjectEquals);
		int index = 0;
		foreach (object item in items)
		{
			if ((index = list.IndexOf(item, equalition)) >= 0)
			{
				merging(list, index, item);
			}
			else
			{
				list.Add(item);
			}
		}
	}

	/// <summary>
	/// 从当前列表中移除满足条件的第一个匹配的项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="predicate">列表元素筛选条件</param>
	/// <returns>如果成功移除返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static bool Remove(this IList list, Func<object, bool> predicate)
	{
		predicate.GuardNotNull("predicate");
		return list.Remove((object x, int i) => predicate(x));
	}

	/// <summary>
	/// 从当前列表中移除满足条件的第一个匹配的项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="predicate">列表元素筛选条件</param>
	/// <returns>如果成功移除返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static bool Remove(this IList list, Func<object, int, bool> predicate)
	{
		list.GuardNotNull("list");
		predicate.GuardNotNull("predicate");
		for (int i = 0; i < list.Count; i++)
		{
			if (predicate(list[i], i))
			{
				list.RemoveAt(i--);
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 从当前列表中移除第一个匹配的项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="item">待移除的项目</param>
	/// <param name="equalition">列表元素比较方法</param>
	/// <returns>如果成功移除返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	public static bool Remove(this IList list, object item, Func<object, object, bool> equalition)
	{
		list.GuardNotNull("list");
		equalition = equalition.IfNull(ObjectExtensions.ObjectEquals);
		for (int i = 0; i < list.Count; i++)
		{
			if (equalition(list[i], item))
			{
				list.RemoveAt(i--);
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 从当前列表中移除指定序列中每个元素匹配的第一个项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="items">待移除的元素数组</param>
	/// <returns>成功移除元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者移除的元素数组 <paramref name="items" /> 为空。</exception>
	public static int Remove(this IList list, params object[] items)
	{
		return list.Remove(items, ObjectExtensions.ObjectEquals);
	}

	/// <summary>
	/// 从当前列表中移除指定序列中每个元素匹配的第一个项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="items">待移除的元素序列</param>
	/// <returns>成功移除元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者移除的元素序列 <paramref name="items" /> 为空。</exception>
	public static int Remove(this IList list, IEnumerable items)
	{
		return list.Remove(items, ObjectExtensions.ObjectEquals);
	}

	/// <summary>
	/// 从当前列表中移除指定序列中每个元素匹配的第一个项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="items">待移除的元素序列</param>
	/// <param name="equalition">列表元素比较方法</param>
	/// <returns>成功移除元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为；或者移除的元素序列 <paramref name="items" /> 为空。</exception>
	public static int Remove(this IList list, IEnumerable items, Func<object, object, bool> equalition)
	{
		list.GuardNotNull("list");
		items.GuardNotNull("items");
		equalition = equalition.IfNull(ObjectExtensions.ObjectEquals);
		int count = 0;
		for (int i = 0; i < list.Count; i++)
		{
			foreach (object item in items)
			{
				if (equalition(list[i], item))
				{
					list.RemoveAt(i--);
					count++;
					break;
				}
			}
		}
		return count;
	}

	/// <summary>
	/// 从当前集合中移除数组中任意元素匹配的第一个项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="items">待移除的元素数组</param>
	/// <returns>如果成功移除返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者移除的元素数组 <paramref name="items" /> 为空。</exception>
	public static bool RemoveAny(this IList list, params object[] items)
	{
		return list.RemoveAny(items, ObjectExtensions.ObjectEquals);
	}

	/// <summary>
	/// 从当前集合中移除序列中任意元素匹配的第一个项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="items">待移除的元素序列</param>
	/// <returns>如果成功移除返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者移除的元素序列 <paramref name="items" /> 为空。</exception>
	public static bool RemoveAny(this IList list, IEnumerable items)
	{
		return list.RemoveAny(items, ObjectExtensions.ObjectEquals);
	}

	/// <summary>
	/// 从当前集合中移除序列中任意元素匹配的第一个项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="items">待移除的元素序列</param>
	/// <param name="equalition">列表元素比较方法</param>
	/// <returns>如果成功移除返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者移除的元素序列 <paramref name="items" /> 为空。</exception>
	public static bool RemoveAny(this IList list, IEnumerable items, Func<object, object, bool> equalition)
	{
		list.GuardNotNull("list");
		items.GuardNotNull("items");
		equalition = equalition.IfNull(ObjectExtensions.ObjectEquals);
		for (int i = 0; i < list.Count; i++)
		{
			if (items.Contains(list[i], equalition))
			{
				list.RemoveAt(i--);
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 从当前列表中删除多个指定索引位置的元素
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="indices">删除的多个索引位置</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者删除的索引位置数组 <paramref name="indices" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">指定删除的索引位置超出当前列表元素有效的索引范围。</exception>
	public static void RemoveAt(this IList list, params int[] indices)
	{
		list.RemoveAt((IEnumerable<int>)indices);
	}

	/// <summary>
	/// 从当前列表中删除多个指定索引位置的元素
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="indices">删除的多个索引序列</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者删除的索引位置序列 <paramref name="indices" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">指定删除的索引位置超出当前列表元素有效的索引范围。</exception>
	public static void RemoveAt(this IList list, IEnumerable<int> indices)
	{
		list.GuardNotNull("list");
		indices.GuardNotNull("indices");
		foreach (int index in indices.OrderByDescending().Distinct())
		{
			index.GuardIndexRange(0, list.Count - 1);
			list.RemoveAt(index);
		}
	}

	/// <summary>
	/// 从当前列表中移除满足条件的所有项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="predicate">列表元素筛选条件</param>
	/// <returns>成功移除元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static int RemoveAll(this IList list, Func<object, bool> predicate)
	{
		predicate.GuardNotNull("predicate");
		return list.RemoveAll((object x, int i) => predicate(x));
	}

	/// <summary>
	/// 从当前列表中移除满足条件的所有项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="predicate">列表元素筛选条件</param>
	/// <returns>成功移除元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者元素筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static int RemoveAll(this IList list, Func<object, int, bool> predicate)
	{
		list.GuardNotNull("list");
		predicate.GuardNotNull("predicate");
		int count = 0;
		for (int i = 0; i < list.Count; i++)
		{
			if (predicate(list[i], i))
			{
				list.RemoveAt(i--);
				count++;
			}
		}
		return count;
	}

	/// <summary>
	/// 从当前列表中移除与指定项目匹配的所有项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="item">待移除的项目</param>
	/// <returns>成功移除元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	public static int RemoveAll(this IList list, object item)
	{
		return list.RemoveAll(item, ObjectExtensions.ObjectEquals);
	}

	/// <summary>
	/// 从当前列表中移除与指定项目匹配的所有项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="item">待移除的项目</param>
	/// <param name="equalition">列表元素比较方法</param>
	/// <returns>成功移除元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	public static int RemoveAll(this IList list, object item, Func<object, object, bool> equalition)
	{
		list.GuardNotNull("list");
		equalition = equalition.IfNull(ObjectExtensions.ObjectEquals);
		int count = 0;
		for (int i = 0; i < list.Count; i++)
		{
			if (equalition(list[i], item))
			{
				list.RemoveAt(i--);
				count++;
			}
		}
		return count;
	}

	/// <summary>
	/// 从当前列表中移除指定序列中匹配的所有项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="items">待移除的元素数组</param>
	/// <returns>成功移除元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者移除的元素数组 <paramref name="items" /> 为空。</exception>
	public static int RemoveAll(this IList list, params object[] items)
	{
		return list.RemoveAll(items, ObjectExtensions.ObjectEquals);
	}

	/// <summary>
	/// 从当前列表中移除指定序列中匹配的所有项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="items">待移除的元素序列</param>
	/// <returns>成功移除元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者移除的元素数组 <paramref name="items" /> 为空。</exception>
	public static int RemoveAll(this IList list, IEnumerable items)
	{
		return list.RemoveAll(items, ObjectExtensions.ObjectEquals);
	}

	/// <summary>
	/// 从当前列表中移除指定序列中匹配的所有项目
	/// </summary>
	/// <param name="list">当前列表</param>
	/// <param name="items">待移除的元素序列</param>
	/// <param name="equalition">列表元素比较方法</param>
	/// <returns>成功移除元素的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空；或者移除的元素数组 <paramref name="items" /> 为空。</exception>
	public static int RemoveAll(this IList list, IEnumerable items, Func<object, object, bool> equalition)
	{
		list.GuardNotNull("list");
		items.GuardNotNull("items");
		equalition = equalition.IfNull(ObjectExtensions.ObjectEquals);
		int count = 0;
		for (int i = 0; i < list.Count; i++)
		{
			if (items.Contains(list[i], equalition))
			{
				list.RemoveAt(i--);
				count++;
			}
		}
		return count;
	}

	/// <summary>
	/// 对当前序列进行排序
	/// </summary>
	/// <param name="list">当前序列</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	public static void Sort(this IList list)
	{
		list.GuardNotNull("list");
		list.Sort(0, list.Count, Comparer.Default);
	}

	/// <summary>
	/// 对当前序列进行排序
	/// </summary>
	/// <param name="list">当前序列</param>
	/// <param name="comparer">序列元素的排序比较对象</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	public static void Sort(this IList list, IComparer comparer)
	{
		list.GuardNotNull("list");
		list.Sort(0, list.Count, comparer);
	}

	/// <summary>
	/// 对当前序列进行排序
	/// </summary>
	/// <param name="list">当前序列</param>
	/// <param name="comparison">序列元素的排序比较方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	public static void Sort(this IList list, Func<object, object, int> comparison)
	{
		list.GuardNotNull("list");
		list.Sort(0, list.Count, comparison);
	}

	/// <summary>
	/// 对当前序列的指定区域进行排序
	/// </summary>
	/// <param name="list">当前序列</param>
	/// <param name="start">排序区域的起始位置</param>
	/// <param name="count">排序区域内的元素个数</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找起始位置 <paramref name="start" /> 小于0，或者大于当前列表元素的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的元素数量 <paramref name="count" /> 小于0，或者当前列表从起始位置 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static void Sort(this IList list, int start, int count)
	{
		list.Sort(start, count, Comparer.Default.Compare);
	}

	/// <summary>
	/// 对当前序列的指定区域进行排序
	/// </summary>
	/// <param name="list">当前序列</param>
	/// <param name="start">排序区域的起始位置</param>
	/// <param name="count">排序区域内的元素个数</param>
	/// <param name="comparer">序列元素的排序比较对象</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找起始位置 <paramref name="start" /> 小于0，或者大于当前列表元素的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的元素数量 <paramref name="count" /> 小于0，或者当前列表从起始位置 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static void Sort(this IList list, int start, int count, IComparer comparer)
	{
		list.Sort(start, count, comparer.IfNull(Comparer.Default).Compare);
	}

	/// <summary>
	/// 对当前序列的指定区域进行排序
	/// </summary>
	/// <param name="list">当前序列</param>
	/// <param name="start">排序区域的起始位置</param>
	/// <param name="count">排序区域内的元素个数</param>
	/// <param name="comparison">序列元素的排序比较方法</param>
	/// <exception cref="T:System.ArgumentNullException">当前列表为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找起始位置 <paramref name="start" /> 小于0，或者大于当前列表元素的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的元素数量 <paramref name="count" /> 小于0，或者当前列表从起始位置 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static void Sort(this IList list, int start, int count, Func<object, object, int> comparison)
	{
		list.GuardNotNull("list");
		start.GuardIndexRange(0, list.Count - 1, "start");
		count.GuardBetween(0, list.Count - start, "count");
		comparison = comparison.IfNull(Comparer.Default.Compare);
		QuickSort(list, start, (count > 0) ? (start + count - 1) : start, comparison);
	}

	/// <summary>
	/// QuickSort排序算法
	/// </summary>
	/// <param name="elements">待排序列表</param>
	/// <param name="start">排序区域起始位置</param>
	/// <param name="end">排序区域结束位置</param>
	/// <param name="comparison">元素比较方法</param>
	private static void QuickSort(IList elements, int start, int end, Func<object, object, int> comparison)
	{
		int i = start;
		int j = end;
		object pivot = elements[i + j >> 1];
		while (i <= j)
		{
			for (; comparison(elements[i], pivot) < 0; i++)
			{
			}
			while (comparison(elements[j], pivot) > 0)
			{
				j--;
			}
			if (i <= j)
			{
				object temp = elements[i];
				elements[i] = elements[j];
				elements[j] = temp;
				i++;
				j--;
			}
		}
		if (start < j)
		{
			QuickSort(elements, start, j, comparison);
		}
		if (i < end)
		{
			QuickSort(elements, i, end, comparison);
		}
	}
}
