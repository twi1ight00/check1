using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Richfit.Garnet.Common.Properties;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// <see cref="T:System.Array" /> 类型扩展方法类
/// </summary>
/// <remarks>
/// 包括：
/// 1. Array类的扩展方法
/// 2. 没有类型约束的泛型数组的扩展方法
/// </remarks>
public static class ArrayExtensions
{
	/// <summary>
	/// 将当前数组转换为 <see cref="T:System.Collections.IEnumerable" /> 接口的枚举器对象
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <returns>枚举器对象</returns>
	/// <exception cref="T:System.InvalidCastException">当前数组无法转换为 <see cref="T:System.Collections.IEnumerable" /> 接口对象。</exception>
	public static IEnumerable AsEnumerable(this Array array)
	{
		return array;
	}

	/// <summary>
	/// 将当前数组转换为 <see cref="T:System.Collections.Generic.IEnumerable`1" /> 接口的枚举器对象
	/// </summary>
	/// <typeparam name="T">枚举器元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <returns>枚举器对象</returns>
	/// <exception cref="T:System.InvalidCastException">当前数组无法转换为 <see cref="T:System.Collections.Generic.IEnumerable`1" /> 接口对象。</exception>
	public static IEnumerable<T> AsEnumerable<T>(this Array array)
	{
		return (IEnumerable<T>)array;
	}

	/// <summary>
	/// 将当前数组对象转换为 <see cref="T:System.Collections.IList" /> 接口对象
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <returns>转换后的列表对象</returns>
	/// <exception cref="T:System.InvalidCastException">当前数组无法转换为 <see cref="T:System.Collections.IList" /> 接口对象。</exception>
	public static IList AsList(this Array array)
	{
		return array;
	}

	/// <summary>
	/// 将当前数组对象转换为 <see cref="T:System.Collections.Generic.IList`1" /> 接口对象
	/// </summary>
	/// <typeparam name="T">数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <returns>数组转换的列表</returns>
	/// <exception cref="T:System.InvalidCastException">当前数组无法转换为 <see cref="T:System.Collections.Generic.IList`1" /> 接口对象。</exception>
	public static IList<T> AsList<T>(this Array array)
	{
		return (IList<T>)array;
	}

	/// <summary>
	/// 将当前数组对象转换为 <see cref="T:System.Collections.Generic.IList`1" /> 接口对象
	/// </summary>
	/// <typeparam name="T">数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <returns>数组转换的列表</returns>
	/// <exception cref="T:System.InvalidCastException">当前数组无法转换为 <see cref="T:System.Collections.Generic.IList`1" /> 接口对象。</exception>
	public static IList<T> AsList<T>(this T[] array)
	{
		return array;
	}

	/// <summary>
	/// 在当前数组中搜索特定元素
	/// </summary>
	/// <param name="array">当前的数组</param>
	/// <param name="value">要搜索的对象</param>
	/// <returns>如果找到指定对象则返回对象的索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的数组为空。</exception>
	/// <remarks>当前的数组应是已经排序的。</remarks>
	public static int BinarySearch(this Array array, object value)
	{
		array.GuardNotNull("array");
		return array.BinarySearch(0, array.Length, value);
	}

	/// <summary>
	/// 在当前数组中搜索特定元素
	/// </summary>
	/// <param name="array">当前的数组</param>
	/// <param name="value">要搜索的对象</param>
	/// <param name="comparer">数组元素比较器</param>
	/// <returns>如果找到指定对象则返回对象的索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的数组为空；<paramref name="comparer" /> 为空。</exception>
	/// <remarks>当前的数组应是已经排序的。</remarks>
	public static int BinarySearch(this Array array, object value, IComparer comparer)
	{
		array.GuardNotNull("array");
		return array.BinarySearch(0, array.Length, value, comparer);
	}

	/// <summary>
	/// 在当前的数组中搜索特定元素
	/// </summary>
	/// <param name="array">当前的数组</param>
	/// <param name="value">要搜索的对象</param>
	/// <param name="comparison">数组元素比较方法</param>
	/// <returns>如果找到指定对象则返回对象的索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的数组为空；<paramref name="comparison" /> 为空。</exception>
	/// <remarks>当前的数组应是已经排序的。</remarks>
	public static int BinarySearch(this Array array, object value, Func<object, object, int> comparison)
	{
		array.GuardNotNull("array");
		return array.BinarySearch(0, array.Length, value, comparison);
	}

	/// <summary>
	/// 在当前数组中搜索特定元素
	/// </summary>
	/// <param name="array">当前的数组</param>
	/// <param name="start">搜索范围的起始索引</param>
	/// <param name="value">要搜索的对象</param>
	/// <returns>如果找到指定对象则返回对象的索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素的索引范围内。</exception>
	/// <remarks>当前的数组应是已经排序的。</remarks>
	public static int BinarySearch(this Array array, int start, object value)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.BinarySearch(start, array.Length - start, value);
	}

	/// <summary>
	/// 在当前数组中搜索特定元素
	/// </summary>
	/// <param name="array">当前的数组</param>
	/// <param name="start">搜索范围的起始索引</param>
	/// <param name="value">要搜索的对象</param>
	/// <param name="comparer">数组元素比较器</param>
	/// <returns>如果找到指定对象则返回对象的索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的数组为空；<paramref name="comparer" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素的索引范围内。</exception>
	/// <remarks>当前的数组应是已经排序的。</remarks>
	public static int BinarySearch(this Array array, int start, object value, IComparer comparer)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.BinarySearch(start, array.Length - start, value, comparer);
	}

	/// <summary>
	/// 在当前的数组中搜索特定元素
	/// </summary>
	/// <param name="array">当前的数组</param>
	/// <param name="start">搜索范围的起始索引</param>
	/// <param name="value">要搜索的对象</param>
	/// <param name="comparison">数组元素比较方法</param>
	/// <returns>如果找到指定对象则返回对象的索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的数组为空；<paramref name="comparison" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素的索引范围内。</exception>
	/// <remarks>当前的数组应是已经排序的。</remarks>
	public static int BinarySearch(this Array array, int start, object value, Func<object, object, int> comparison)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.BinarySearch(start, array.Length - start, value, comparison);
	}

	/// <summary>
	/// 在当前的数组的指定范围中搜索特定元素
	/// </summary>
	/// <param name="array">当前的数组</param>
	/// <param name="start">搜索范围的起始索引</param>
	/// <param name="count">搜索范围的元素个数</param>
	/// <param name="value">要搜索的对象</param>
	/// <returns>如果找到指定对象则返回对象的索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素的索引范围内。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组中从索引位置 <paramref name="start" /> 处开始剩余元素的个数。</exception>
	/// <remarks>当前的数组应是已经排序的。</remarks>
	public static int BinarySearch(this Array array, int start, int count, object value)
	{
		return array.BinarySearch(start, count, value, Comparer.Default.Compare);
	}

	/// <summary>
	/// 在当前的数组的指定范围中搜索特定元素
	/// </summary>
	/// <param name="array">当前的数组</param>
	/// <param name="start">搜索范围的起始索引</param>
	/// <param name="count">搜索范围的元素个数</param>
	/// <param name="value">要搜索的对象</param>
	/// <param name="comparer">数组元素比较器</param>
	/// <returns>如果找到指定对象则返回对象的索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的数组为空；<paramref name="comparer" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素的索引范围内。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组中从索引位置 <paramref name="start" /> 处开始剩余元素的个数。</exception>
	/// <remarks>当前的数组应是已经排序的。</remarks>
	public static int BinarySearch(this Array array, int start, int count, object value, IComparer comparer)
	{
		comparer.GuardNotNull("comparer");
		return array.BinarySearch(start, count, value, comparer.Compare);
	}

	/// <summary>
	/// 在当前的数组的指定范围中搜索特定元素
	/// </summary>
	/// <param name="array">当前的数组</param>
	/// <param name="start">搜索范围的起始索引</param>
	/// <param name="count">搜索范围的元素个数</param>
	/// <param name="value">要搜索的对象</param>
	/// <param name="comparison">数组元素比较方法</param>
	/// <returns>如果找到指定对象则返回对象的索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的数组为空；<paramref name="comparison" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素的索引范围内。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组中从索引位置 <paramref name="start" /> 处开始剩余元素的个数。</exception>
	/// <remarks>当前的数组应是已经排序的。</remarks>
	public static int BinarySearch(this Array array, int start, int count, object value, Func<object, object, int> comparison)
	{
		array.GuardNotNull("array");
		comparison.GuardNotNull("comparison");
		start.GuardIndexRange(0, array.Length - 1, "start");
		count.GuardBetween(0, array.Length - start, "count");
		if (count > 0)
		{
			int[] weights = array.GetWeight();
			int i = start;
			int j = start + count - 1;
			while (i <= j)
			{
				int median = i + j >> 1;
				int result = comparison(array.GetValue(median, weights), value);
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
		}
		return -1;
	}

	/// <summary>
	/// 在当前数组中搜索特定元素
	/// </summary>
	/// <param name="array">当前的数组</param>
	/// <param name="start">搜索范围的起始索引</param>
	/// <param name="value">要搜索的对象</param>
	/// <returns>如果找到指定对象则返回对象的索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素的索引范围内。</exception>
	/// <remarks>当前的数组应是已经排序的。</remarks>
	public static long BinarySearch(this Array array, long start, object value)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.BinarySearch(start, array.Length - start, value);
	}

	/// <summary>
	/// 在当前数组中搜索特定元素
	/// </summary>
	/// <param name="array">当前的数组</param>
	/// <param name="start">搜索范围的起始索引</param>
	/// <param name="value">要搜索的对象</param>
	/// <param name="comparer">数组元素比较器</param>
	/// <returns>如果找到指定对象则返回对象的索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的数组为空；<paramref name="comparer" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素的索引范围内。</exception>
	/// <remarks>当前的数组应是已经排序的。</remarks>
	public static long BinarySearch(this Array array, long start, object value, IComparer comparer)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.BinarySearch(start, array.Length - start, value, comparer);
	}

	/// <summary>
	/// 在当前的数组中搜索特定元素
	/// </summary>
	/// <param name="array">当前的数组</param>
	/// <param name="start">搜索范围的起始索引</param>
	/// <param name="value">要搜索的对象</param>
	/// <param name="comparison">数组元素比较方法</param>
	/// <returns>如果找到指定对象则返回对象的索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的数组为空；<paramref name="comparison" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素的索引范围内。</exception>
	/// <remarks>当前的数组应是已经排序的。</remarks>
	public static long BinarySearch(this Array array, long start, object value, Func<object, object, int> comparison)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.BinarySearch(start, array.Length - start, value, comparison);
	}

	/// <summary>
	/// 在当前的数组的指定范围中搜索特定元素
	/// </summary>
	/// <param name="array">当前的数组</param>
	/// <param name="start">搜索范围的起始索引</param>
	/// <param name="count">搜索范围的元素个数</param>
	/// <param name="value">要搜索的对象</param>
	/// <returns>如果找到指定对象则返回对象的索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素的索引范围内。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组中从索引位置 <paramref name="start" /> 处开始剩余元素的个数。</exception>
	/// <remarks>当前的数组应是已经排序的。</remarks>
	public static long BinarySearch(this Array array, long start, long count, object value)
	{
		return array.BinarySearch(start, count, value, Comparer.Default.Compare);
	}

	/// <summary>
	/// 在当前的数组的指定范围中搜索特定元素
	/// </summary>
	/// <param name="array">当前的数组</param>
	/// <param name="start">搜索范围的起始索引</param>
	/// <param name="count">搜索范围的元素个数</param>
	/// <param name="value">要搜索的对象</param>
	/// <param name="comparer">数组元素比较器</param>
	/// <returns>如果找到指定对象则返回对象的索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的数组为空；<paramref name="comparer" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素的索引范围内。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组中从索引位置 <paramref name="start" /> 处开始剩余元素的个数。</exception>
	/// <remarks>当前的数组应是已经排序的。</remarks>
	public static long BinarySearch(this Array array, long start, long count, object value, IComparer comparer)
	{
		comparer.GuardNotNull("comparer");
		return array.BinarySearch(start, count, value, comparer.Compare);
	}

	/// <summary>
	/// 在当前的数组的指定范围中搜索特定元素
	/// </summary>
	/// <param name="array">当前的数组</param>
	/// <param name="start">搜索范围的起始索引</param>
	/// <param name="count">搜索范围的元素个数</param>
	/// <param name="value">要搜索的对象</param>
	/// <param name="comparison">数组元素比较方法</param>
	/// <returns>如果找到指定对象则返回对象的索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的数组为空；<paramref name="comparison" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素的索引范围内。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组中从索引位置 <paramref name="start" /> 处开始剩余元素的个数。</exception>
	/// <remarks>当前的数组应是已经排序的。</remarks>
	public static long BinarySearch(this Array array, long start, long count, object value, Func<object, object, int> comparison)
	{
		array.GuardNotNull("array");
		comparison.GuardNotNull("comparison");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		count.GuardBetween(0L, array.LongLength - start, "count");
		if (count > 0)
		{
			long[] weights = array.GetLongWeight();
			long i = start;
			long j = start + count - 1;
			while (i <= j)
			{
				long median = i + j >> 1;
				int result = comparison(array.GetValue(median, weights), value);
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
		}
		return -1L;
	}

	/// <summary>
	/// 在当前的数组的指定范围中搜索特定元素
	/// </summary>
	/// <typeparam name="T">数组元素类型</typeparam>
	/// <param name="array">当前的数组</param>
	/// <param name="value">要搜索的对象</param>
	/// <returns>如果找到指定对象则返回对象的索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的数组为空。</exception>
	/// <remarks>当前的数组应是已经排序的。</remarks>
	public static int BinarySearch<T>(this T[] array, T value)
	{
		array.GuardNotNull("array");
		return Array.BinarySearch(array, value);
	}

	/// <summary>
	/// 在当前的数组的指定范围中搜索特定元素
	/// </summary>
	/// <typeparam name="T">数组元素类型</typeparam>
	/// <param name="array">当前的数组</param>
	/// <param name="value">要搜索的对象</param>
	/// <param name="comparer">数组元素比较器</param>
	/// <returns>如果找到指定对象则返回对象的索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的数组为空；<paramref name="comparer" /> 为空。</exception>
	/// <remarks>当前的数组应是已经排序的。</remarks>
	public static int BinarySearch<T>(this T[] array, T value, IComparer<T> comparer)
	{
		array.GuardNotNull("array");
		comparer.GuardNotNull("comparer");
		return Array.BinarySearch(array, value, comparer);
	}

	/// <summary>
	/// 在当前的数组的指定范围中搜索特定元素
	/// </summary>
	/// <typeparam name="T">数组元素类型</typeparam>
	/// <param name="array">当前的数组</param>
	/// <param name="value">要搜索的对象</param>
	/// <param name="comparison">数组元素比较方法</param>
	/// <returns>如果找到指定对象则返回对象的索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的数组为空；<paramref name="comparison" /> 为空。</exception>
	/// <remarks>当前的数组应是已经排序的。</remarks>
	public static int BinarySearch<T>(this T[] array, T value, Func<T, T, int> comparison)
	{
		array.GuardNotNull("array");
		comparison.GuardNotNull("comparison");
		return Array.BinarySearch(array, value, comparison.ToComparer());
	}

	/// <summary>
	/// 在当前的数组的指定范围中搜索特定元素
	/// </summary>
	/// <typeparam name="T">数组元素类型</typeparam>
	/// <param name="array">当前的数组</param>
	/// <param name="start">搜索范围的起始索引</param>
	/// <param name="value">要搜索的对象</param>
	/// <returns>如果找到指定对象则返回对象的索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素的索引范围内。</exception>
	/// <remarks>当前的数组应是已经排序的。</remarks>
	public static int BinarySearch<T>(this T[] array, int start, T value)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return Array.BinarySearch(array, start, array.Length - start, value);
	}

	/// <summary>
	/// 在当前的数组的指定范围中搜索特定元素
	/// </summary>
	/// <typeparam name="T">数组元素类型</typeparam>
	/// <param name="array">当前的数组</param>
	/// <param name="start">搜索范围的起始索引</param>
	/// <param name="value">要搜索的对象</param>
	/// <param name="comparer">数组元素比较器</param>
	/// <returns>如果找到指定对象则返回对象的索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的数组为空；<paramref name="comparer" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素的索引范围内。</exception>
	/// <remarks>当前的数组应是已经排序的。</remarks>
	public static int BinarySearch<T>(this T[] array, int start, T value, IComparer<T> comparer)
	{
		array.GuardNotNull("array");
		comparer.GuardNotNull("comparer");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return Array.BinarySearch(array, start, array.Length - start, value, comparer);
	}

	/// <summary>
	/// 在当前的数组的指定范围中搜索特定元素
	/// </summary>
	/// <typeparam name="T">数组元素类型</typeparam>
	/// <param name="array">当前的数组</param>
	/// <param name="start">搜索范围的起始索引</param>
	/// <param name="value">要搜索的对象</param>
	/// <param name="comparison">数组元素比较方法</param>
	/// <returns>如果找到指定对象则返回对象的索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的数组为空；<paramref name="comparison" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素的索引范围内。</exception>
	/// <remarks>当前的数组应是已经排序的。</remarks>
	public static int BinarySearch<T>(this T[] array, int start, T value, Func<T, T, int> comparison)
	{
		array.GuardNotNull("array");
		comparison.GuardNotNull("comparison");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return Array.BinarySearch(array, start, array.Length - start, value, comparison.ToComparer());
	}

	/// <summary>
	/// 在当前的数组的指定范围中搜索特定元素
	/// </summary>
	/// <typeparam name="T">数组元素类型</typeparam>
	/// <param name="array">当前的数组</param>
	/// <param name="start">搜索范围的起始索引</param>
	/// <param name="count">搜索范围的元素数量</param>
	/// <param name="value">要搜索的对象</param>
	/// <returns>如果找到指定对象则返回对象的索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素的索引范围内。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组中从索引位置 <paramref name="start" /> 处开始剩余元素的个数。</exception>
	/// <remarks>当前的数组应是已经排序的。</remarks>
	public static int BinarySearch<T>(this T[] array, int start, int count, T value)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		count.GuardBetween(0, array.Length - start, "count");
		return Array.BinarySearch(array, start, count, value);
	}

	/// <summary>
	/// 在当前的数组的指定范围中搜索特定元素
	/// </summary>
	/// <typeparam name="T">数组元素类型</typeparam>
	/// <param name="array">当前的数组</param>
	/// <param name="start">搜索范围的起始索引</param>
	/// <param name="count">搜索范围的元素数量</param>
	/// <param name="value">要搜索的对象</param>
	/// <param name="comparer">数组元素比较器</param>
	/// <returns>如果找到指定对象则返回对象的索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的数组为空；<paramref name="comparer" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素的索引范围内。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组中从索引位置 <paramref name="start" /> 处开始剩余元素的个数。</exception>
	/// <remarks>当前的数组应是已经排序的。</remarks>
	public static int BinarySearch<T>(this T[] array, int start, int count, T value, IComparer<T> comparer)
	{
		array.GuardNotNull("array");
		comparer.GuardNotNull("comparer");
		start.GuardIndexRange(0, array.Length - 1, "start");
		count.GuardBetween(0, array.Length - start, "count");
		return Array.BinarySearch(array, start, count, value, comparer);
	}

	/// <summary>
	/// 在当前的数组的指定范围中搜索特定元素
	/// </summary>
	/// <typeparam name="T">数组元素类型</typeparam>
	/// <param name="array">当前的数组</param>
	/// <param name="start">搜索范围的起始索引</param>
	/// <param name="count">搜索范围的元素数量</param>
	/// <param name="value">要搜索的对象</param>
	/// <param name="comparison">数组元素比较方法</param>
	/// <returns>如果找到指定对象则返回对象的索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的数组为空；<paramref name="comparison" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素的索引范围内。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组中从索引位置 <paramref name="start" /> 处开始剩余元素的个数。</exception>
	/// <remarks>当前的数组应是已经排序的。</remarks>
	public static int BinarySearch<T>(this T[] array, int start, int count, T value, Func<T, T, int> comparison)
	{
		array.GuardNotNull("array");
		comparison.GuardNotNull("comparison");
		start.GuardIndexRange(0, array.Length - 1, "start");
		count.GuardBetween(0, array.Length - start, "count");
		return Array.BinarySearch(array, start, count, value, comparison.ToComparer());
	}

	/// <summary>
	/// 在当前的数组的指定范围中搜索特定元素
	/// </summary>
	/// <typeparam name="T">数组元素类型</typeparam>
	/// <param name="array">当前的数组</param>
	/// <param name="start">搜索范围的起始索引</param>
	/// <param name="value">要搜索的对象</param>
	/// <returns>如果找到指定对象则返回对象的索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素的索引范围内。</exception>
	/// <remarks>当前的数组应是已经排序的。</remarks>
	public static long BinarySearch<T>(this T[] array, long start, T value)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.BinarySearch(start, array.LongLength - start, value);
	}

	/// <summary>
	/// 在当前的数组的指定范围中搜索特定元素
	/// </summary>
	/// <typeparam name="T">数组元素类型</typeparam>
	/// <param name="array">当前的数组</param>
	/// <param name="start">搜索范围的起始索引</param>
	/// <param name="value">要搜索的对象</param>
	/// <param name="comparer">数组元素比较器</param>
	/// <returns>如果找到指定对象则返回对象的索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的数组为空；<paramref name="comparer" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素的索引范围内。</exception>
	/// <remarks>当前的数组应是已经排序的。</remarks>
	public static long BinarySearch<T>(this T[] array, long start, T value, IComparer<T> comparer)
	{
		array.GuardNotNull("array");
		comparer.GuardNotNull("comparer");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.BinarySearch(start, array.LongLength - start, value, comparer);
	}

	/// <summary>
	/// 在当前的数组的指定范围中搜索特定元素
	/// </summary>
	/// <typeparam name="T">数组元素类型</typeparam>
	/// <param name="array">当前的数组</param>
	/// <param name="start">搜索范围的起始索引</param>
	/// <param name="value">要搜索的对象</param>
	/// <param name="comparison">数组元素比较方法</param>
	/// <returns>如果找到指定对象则返回对象的索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的数组为空；<paramref name="comparison" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素的索引范围内。</exception>
	/// <remarks>当前的数组应是已经排序的。</remarks>
	public static long BinarySearch<T>(this T[] array, long start, T value, Func<T, T, int> comparison)
	{
		array.GuardNotNull("array");
		comparison.GuardNotNull("comparison");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.BinarySearch(start, array.LongLength - start, value, comparison);
	}

	/// <summary>
	/// 在当前的数组的指定范围中搜索特定元素
	/// </summary>
	/// <typeparam name="T">数组元素类型</typeparam>
	/// <param name="array">当前的数组</param>
	/// <param name="start">搜索范围的起始索引</param>
	/// <param name="count">搜索范围的元素数量</param>
	/// <param name="value">要搜索的对象</param>
	/// <returns>如果找到指定对象则返回对象的索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素的索引范围内。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组中从索引位置 <paramref name="start" /> 处开始剩余元素的个数。</exception>
	/// <remarks>当前的数组应是已经排序的。</remarks>
	public static long BinarySearch<T>(this T[] array, long start, long count, T value)
	{
		array.GuardNotNull("array");
		return array.BinarySearch(start, count, value, Comparer<T>.Default.Compare);
	}

	/// <summary>
	/// 在当前的数组的指定范围中搜索特定元素
	/// </summary>
	/// <typeparam name="T">数组元素类型</typeparam>
	/// <param name="array">当前的数组</param>
	/// <param name="start">搜索范围的起始索引</param>
	/// <param name="count">搜索范围的元素数量</param>
	/// <param name="value">要搜索的对象</param>
	/// <param name="comparer">数组元素比较器</param>
	/// <returns>如果找到指定对象则返回对象的索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的数组为空；<paramref name="comparer" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素的索引范围内。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组中从索引位置 <paramref name="start" /> 处开始剩余元素的个数。</exception>
	/// <remarks>当前的数组应是已经排序的。</remarks>
	public static long BinarySearch<T>(this T[] array, long start, long count, T value, IComparer<T> comparer)
	{
		array.GuardNotNull("array");
		comparer.GuardNotNull("comparer");
		return array.BinarySearch(start, count, value, comparer.Compare);
	}

	/// <summary>
	/// 在当前的数组的指定范围中搜索特定元素
	/// </summary>
	/// <typeparam name="T">数组元素类型</typeparam>
	/// <param name="array">当前的数组</param>
	/// <param name="start">搜索范围的起始索引</param>
	/// <param name="count">搜索范围的元素数量</param>
	/// <param name="value">要搜索的对象</param>
	/// <param name="comparison">数组元素比较方法</param>
	/// <returns>如果找到指定对象则返回对象的索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的数组为空；<paramref name="comparison" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素的索引范围内。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组中从索引位置 <paramref name="start" /> 处开始剩余元素的个数。</exception>
	/// <remarks>当前的数组应是已经排序的。</remarks>
	public static long BinarySearch<T>(this T[] array, long start, long count, T value, Func<T, T, int> comparison)
	{
		array.GuardNotNull("array");
		comparison.GuardNotNull("comparison");
		return array.As<Array>().BinarySearch(start, count, value, (object x, object y) => comparison((T)x, (T)y));
	}

	/// <summary>
	/// 清空当前数组，将数组元素设置为其类型的默认值；当前数组可以是一维或者多维数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <returns>处理后的当前数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static Array Clear(this Array array)
	{
		array.GuardNotNull("array");
		Array.Clear(array, 0, array.Length);
		return array;
	}

	/// <summary>
	/// 清空当前数组的指定区域，将区域内的数据元素设置为其类型的默认值；当前数组可以是一维或者多维数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">清空区域起始位置</param>
	/// <returns>处理后的当前数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素的索引范围内。</exception>
	public static Array Clear(this Array array, int start)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		Array.Clear(array, start, array.Length - start);
		return array;
	}

	/// <summary>
	/// 清空当前数组的指定区域，将区域内的数据元素设置为其类型的默认值；当前数组可以是一维或者多维数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">清空区域起始位置</param>
	/// <param name="count">清空区域元素个数</param>
	/// <returns>处理后的当前数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素的索引范围内。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组中从索引位置 <paramref name="start" /> 处开始剩余元素的个数。</exception>
	public static Array Clear(this Array array, int start, int count)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		count.GuardBetween(0, array.Length - start, "count");
		Array.Clear(array, start, count);
		return array;
	}

	/// <summary>
	/// 清空当前数组的指定区域，将区域内的数据元素设置为其类型的默认值；当前数组可以是一维或者多维数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">清空区域起始位置</param>
	/// <returns>处理后的当前数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素的索引范围内。</exception>
	public static Array Clear(this Array array, long start)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.Clear(start, array.LongLength - start);
	}

	/// <summary>
	/// 清空当前数组的指定区域，将区域内的数据元素设置为其类型的默认值；当前数组可以是一维或者多维数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">清空区域起始位置</param>
	/// <param name="count">清空区域元素个数</param>
	/// <returns>处理后的当前数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素的索引范围内。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组中从索引位置 <paramref name="start" /> 处开始剩余元素的个数。</exception>
	public static Array Clear(this Array array, long start, long count)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		count.GuardBetween(0L, array.LongLength - start, "count");
		long[] weight = array.GetLongWeight();
		long end = start + count;
		for (long i = start; i < end; i++)
		{
			array.SetValue(array.GetElementType().CreateDefault(), i, weight);
		}
		return array;
	}

	/// <summary>
	/// 清空当前数组，将数组元素设置为其类型的默认值
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <returns>处理后的当前数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static T[] Clear<T>(this T[] array)
	{
		array.GuardNotNull("array");
		Array.Clear(array, 0, array.Length);
		return array;
	}

	/// <summary>
	/// 清空当前数组的指定区域，将区域内的数据元素设置为其类型的默认值
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">清空区域起始位置</param>
	/// <returns>处理后的当前数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素的索引范围内。</exception>
	public static T[] Clear<T>(this T[] array, int start)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		Array.Clear(array, start, array.Length - start);
		return array;
	}

	/// <summary>
	/// 清空当前数组的指定区域，将区域内的数据元素设置为其类型的默认值
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">清空区域起始位置</param>
	/// <param name="count">清空区域元素个数</param>
	/// <returns>处理后的当前数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素的索引范围内。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组中从索引位置 <paramref name="start" /> 处开始剩余元素的个数。</exception>
	public static T[] Clear<T>(this T[] array, int start, int count)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		count.GuardBetween(0, array.Length - start, "count");
		Array.Clear(array, start, count);
		return array;
	}

	/// <summary>
	/// 清空当前数组的指定区域，将区域内的数据元素设置为其类型的默认值
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">清空区域起始位置</param>
	/// <returns>处理后的当前数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素的索引范围内。</exception>
	public static T[] Clear<T>(this T[] array, long start)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.Clear(start, array.LongLength - start);
	}

	/// <summary>
	/// 清空当前数组的指定区域，将区域内的数据元素设置为其类型的默认值
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">清空区域起始位置</param>
	/// <param name="count">清空区域元素个数</param>
	/// <returns>处理后的当前数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素的索引范围内。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组中从索引位置 <paramref name="start" /> 处开始剩余元素的个数。</exception>
	public static T[] Clear<T>(this T[] array, long start, long count)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		count.GuardBetween(0L, array.LongLength - start, "count");
		long end = start + count;
		for (long i = start; i < end; i++)
		{
			array[i] = default(T);
		}
		return array;
	}

	/// <summary>
	/// 以安全模式从当前数组向目标数组复制元素，保证在复制未成功完成的情况下撤消所有更改。当前数组和目标数组可以是多维数组，但是其维度必须相同。
	/// </summary>
	/// <param name="source">当前数组</param>
	/// <param name="target">复制的目标数组</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> 为空；或者 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.RankException">当前数组和目标数组的秩（维数）不相同。</exception>
	public static void ConstrainedCopyTo(this Array source, Array target)
	{
		source.GuardNotNull("source");
		target.GuardNotNull("target");
		source.GuardArrayRank(target.Rank, string.Empty, Literals.MSG_ArrayRankNotSame_2.FormatValue("source", "target"));
		Array.ConstrainedCopy(source, 0, target, 0, Math.Min(source.Length, target.Length));
	}

	/// <summary>
	/// 以安全模式从当前数组向目标数组复制元素，保证在复制未成功完成的情况下撤消所有更改。当前数组和目标数组可以是多维数组，但是其维度必须相同。
	/// </summary>
	/// <param name="source">当前数组</param>
	/// <param name="target">复制的目标数组</param>
	/// <param name="targetStart">向目标数组复制的起始位置</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> 为空；或者 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.RankException">当前数组和目标数组的秩（维数）不相同。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="targetStart" /> 不在目标数组的元素索引范围内。</exception>
	public static void ConstrainedCopyTo(this Array source, Array target, int targetStart)
	{
		source.GuardNotNull("source");
		target.GuardNotNull("target");
		source.GuardArrayRank(target.Rank, string.Empty, Literals.MSG_ArrayRankNotSame_2.FormatValue("source", "target"));
		targetStart.GuardIndexRange(0, target.Length - 1, "target start");
		Array.ConstrainedCopy(source, 0, target, targetStart, Math.Min(source.Length, target.Length - targetStart));
	}

	/// <summary>
	/// 以安全模式从当前数组向目标数组复制元素，保证在复制未成功完成的情况下撤消所有更改。当前数组和目标数组可以是多维数组，但是其维度必须相同。
	/// </summary>
	/// <param name="source">当前数组</param>
	/// <param name="target">复制的目标数组</param>
	/// <param name="targetStart">起始复制位置</param>
	/// <param name="copyCount">复制的数组元素个数</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> 为空；或者 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.RankException">当前数组和目标数组的秩（维数）不相同。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="targetStart" /> 不在目标数组的索引范围内。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="copyCount" /> 小于0，或者大于当前数组可复制的数量和目标数组可容纳的数量。</exception>
	public static void ConstrainedCopyTo(this Array source, Array target, int targetStart, int copyCount)
	{
		source.GuardNotNull("source");
		target.GuardNotNull("target");
		source.GuardArrayRank(target.Rank, string.Empty, Literals.MSG_ArrayRankNotSame_2.FormatValue("source", "target"));
		targetStart.GuardIndexRange(0, target.Length - 1, "target start");
		copyCount.GuardBetween(0, Math.Min(source.Length, target.Length - targetStart), "copy count");
		Array.ConstrainedCopy(source, 0, target, targetStart, copyCount);
	}

	/// <summary>
	/// 以安全模式从当前数组向目标数组复制元素，保证在复制未成功完成的情况下撤消所有更改。当前数组和目标数组可以是多维数组，但是其维度必须相同。
	/// </summary>
	/// <param name="source">当前数组</param>
	/// <param name="sourceStart">向当前数组复制的起始位置</param>
	/// <param name="target">复制的目标数组</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> 为空；或者 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.RankException">当前数组和目标数组的秩（维数）不相同。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="sourceStart" /> 不在当前数组元素的索引范围内。</exception>
	public static void ConstrainedCopyTo(this Array source, int sourceStart, Array target)
	{
		source.GuardNotNull("source");
		target.GuardNotNull("target");
		source.GuardArrayRank(target.Rank, string.Empty, Literals.MSG_ArrayRankNotSame_2.FormatValue("source", "target"));
		sourceStart.GuardIndexRange(0, source.Length - 1, "source target");
		Array.ConstrainedCopy(source, sourceStart, target, 0, Math.Min(source.Length - sourceStart, target.Length));
	}

	/// <summary>
	/// 以安全模式从当前数组向目标数组复制元素，保证在复制未成功完成的情况下撤消所有更改。当前数组和目标数组可以是多维数组，但是其维度必须相同。
	/// </summary>
	/// <param name="source">当前数组</param>
	/// <param name="sourceStart">向当前数组复制的起始位置</param>
	/// <param name="target">复制的目标数组</param>
	/// <param name="targetStart">向目标数组复制的起始位置</param>
	/// <returns>复制的目标数组</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> 为空；或者 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.RankException">当前数组和目标数组的秩（维数）不相同。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="sourceStart" /> 不在当前数组元素的索引范围内；<paramref name="targetStart" /> 不在目标数组元素的索引范围内。</exception>
	public static void ConstrainedCopyTo(this Array source, int sourceStart, Array target, int targetStart)
	{
		source.GuardNotNull("source");
		target.GuardNotNull("target");
		source.GuardArrayRank(target.Rank, string.Empty, Literals.MSG_ArrayRankNotSame_2.FormatValue("source", "target"));
		sourceStart.GuardIndexRange(0, source.Length - 1, "source start");
		targetStart.GuardIndexRange(0, target.Length - 1, "target start");
		Array.ConstrainedCopy(source, sourceStart, target, targetStart, Math.Min(source.Length - sourceStart, target.Length - targetStart));
	}

	/// <summary>
	/// 以安全模式从当前数组向目标数组复制元素，保证在复制未成功完成的情况下撤消所有更改。当前数组和目标数组可以是多维数组，但是其维度必须相同。
	/// </summary>
	/// <param name="source">当前数组</param>
	/// <param name="sourceStart">向当前数组复制的起始位置</param>
	/// <param name="target">目标数组</param>
	/// <param name="targetStart">向目标数组复制的起始位置</param>
	/// <param name="copyCount">复制的元素数量</param>
	/// <returns>复制的目标数组</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> 为空；或者 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.RankException">当前数组和目标数组的秩（维数）不相同。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="sourceStart" /> 不在当前数组元素的索引范围内；<paramref name="targetStart" /> 不在目标数组元素的索引范围内。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="copyCount" /> 小于0，或者大于当前数组剩余的元素数量和目标数组剩余元素个数。</exception>
	public static void ConstrainedCopyTo(this Array source, int sourceStart, Array target, int targetStart, int copyCount)
	{
		source.GuardNotNull("source");
		target.GuardNotNull("target");
		sourceStart.GuardIndexRange(0, source.Length - 1, "source start");
		targetStart.GuardIndexRange(0, target.Length - 1, "target start");
		copyCount.GuardBetween(0, Math.Min(source.Length - sourceStart, target.Length - targetStart), "copy count");
		Array.ConstrainedCopy(source, sourceStart, target, targetStart, copyCount);
	}

	/// <summary>
	/// 将当前数组转换为另一种类型的数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="conversion">数组元素转换方法</param>
	/// <returns>转换后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="conversion" /> 为空。</exception>
	/// <remarks>当前数组可以为一维或者多维数组</remarks>
	public static Array ConvertAll(this Array array, Func<object, object> conversion)
	{
		array.GuardNotNull("array");
		conversion.GuardNotNull("conversion");
		return array.Copy(conversion);
	}

	/// <summary>
	/// 将当前数组转换为另一种类型的数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="conversion">数组元素转换方法</param>
	/// <returns>转换后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="conversion" /> 为空。</exception>
	/// <remarks>当前数组可以为一维或者多维数组</remarks>
	public static Array ConvertAll(this Array array, Func<object, int, object> conversion)
	{
		array.GuardNotNull("array");
		conversion.GuardNotNull("conversion");
		return array.Copy(conversion);
	}

	/// <summary>
	/// 将当前数组转换为另一种类型的数组
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">目标数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="conversion">数组元素转换方法</param>
	/// <returns>转换后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="conversion" /> 为空。</exception>
	public static T[] ConvertAll<S, T>(this S[] array, Func<S, T> conversion)
	{
		array.GuardNotNull("array");
		conversion.GuardNotNull("conversion");
		return Array.ConvertAll(array, (S x) => conversion(x));
	}

	/// <summary>
	/// 将当前数组转换为另一种类型的数组
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">目标数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="conversion">数组元素转换方法</param>
	/// <returns>转换后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="conversion" /> 为空。</exception>
	public static T[] ConvertAll<S, T>(this S[] array, Func<S, int, T> conversion)
	{
		array.GuardNotNull("array");
		conversion.GuardNotNull("conversion");
		int index = 0;
		return Array.ConvertAll(array, (S x) => conversion(x, index++));
	}

	/// <summary>
	/// 复制当前数组，默认复制每个数组元素的引用
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <remarks>本方法使用 <see cref="M:System.Array.Clone" /> 方法复制当前数组。</remarks>
	public static Array Copy(this Array array)
	{
		array.GuardNotNull("array");
		return (Array)array.Clone();
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="copying" /> 为空。</exception>
	public static Array Copy(this Array array, Func<object, object> copying)
	{
		return array.Copy((object x) => true, copying);
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素和该元素的索引作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="copying" /> 为空。</exception>
	public static Array Copy(this Array array, Func<object, int, object> copying)
	{
		return array.Copy((object x, int i) => true, copying);
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">数组元素复制筛选条件，接收当前筛选的元素作为参数</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="copying" /> 为空。</exception>
	public static Array Copy(this Array array, Func<object, bool> predicate, Func<object, object> copying)
	{
		array.GuardNotNull("array");
		return array.Copy(0, array.Length, predicate, copying);
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">数组元素复制筛选条件，接收当前筛选的元素和该元素的索引作为参数</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素和该元素的索引作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="copying" /> 为空。</exception>
	public static Array Copy(this Array array, Func<object, int, bool> predicate, Func<object, int, object> copying)
	{
		array.GuardNotNull("array");
		return array.Copy(0, array.Length, predicate, copying);
	}

	/// <summary>
	/// 复制当前数组，默认复制每个数组元素引用
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">复制的起始位置</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <remarks>本方法使用 <see cref="M:System.Array.Copy(System.Array,System.Int32,System.Array,System.Int32,System.Int32)" /> 方法复制数组。复制的数组和源数组具有相同的秩（维数）和元素数量，只复制指定索引范围内的元素。</remarks>
	public static Array Copy(this Array array, int start)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		int[] weights = array.GetWeight();
		Array result = Array.CreateInstance(array.GetType().GetElementType(), weights);
		Array.Copy(array, start, result, start, array.Length - start);
		return result;
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">复制的起始位置</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="copying" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <remarks>复制的数组和源数组具有相同的秩（维数）和元素数量，只复制指定索引范围内的元素。</remarks>
	public static Array Copy(this Array array, int start, Func<object, object> copying)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.Copy(start, array.Length - start, (object x) => true, copying);
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">复制的起始位置</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素和该元素的索引作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="copying" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	public static Array Copy(this Array array, int start, Func<object, int, object> copying)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.Copy(start, array.Length - start, (object x, int i) => true, copying);
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">复制的起始位置</param>
	/// <param name="predicate">数组元素复制筛选条件，接收当前筛选的元素作为参数</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="copying" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <remarks>复制的数组和源数组具有相同的秩（维数）和元素数量，只复制指定索引范围内的元素。</remarks>
	public static Array Copy(this Array array, int start, Func<object, bool> predicate, Func<object, object> copying)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.Copy(start, array.Length - start, predicate, copying);
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">复制的起始位置</param>
	/// <param name="predicate">数组元素复制筛选条件，接收当前筛选的元素和该元素的索引作为参数</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素和该元素的索引作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="copying" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <remarks>复制的数组和源数组具有相同的秩（维数）和元素数量，只复制指定索引范围内的元素。</remarks>
	public static Array Copy(this Array array, int start, Func<object, int, bool> predicate, Func<object, int, object> copying)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.Copy(start, array.Length - start, predicate, copying);
	}

	/// <summary>
	/// 复制当前数组，默认复制每个数组元素引用
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">复制的起始位置</param>
	/// <param name="count">复制的数组元素个数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 超过数组从 <paramref name="start" /> 开始剩余的元素个数。</exception>
	/// <remarks>本方法使用 <see cref="M:System.Array.Copy(System.Array,System.Int32,System.Array,System.Int32,System.Int32)" /> 方法复制数组。复制的数组和源数组具有相同的秩（维数）和元素数量，只复制指定索引范围内的元素。</remarks>
	public static Array Copy(this Array array, int start, int count)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		count.GuardBetween(0, array.Length - start, "count");
		int[] weights = array.GetWeight();
		Array result = Array.CreateInstance(array.GetType().GetElementType(), weights);
		Array.Copy(array, start, result, start, count);
		return result;
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">复制的起始位置</param>
	/// <param name="count">复制的数组元素个数</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="copying" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 超过数组从 <paramref name="start" /> 开始剩余的元素个数。</exception>
	/// <remarks>复制的数组和源数组具有相同的秩（维数）和元素数量，只复制指定索引范围内的元素。</remarks>
	public static Array Copy(this Array array, int start, int count, Func<object, object> copying)
	{
		array.GuardNotNull("array");
		return array.Copy(start, count, (object x) => true, copying);
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">复制的起始位置</param>
	/// <param name="count">复制的数组元素个数</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素和该元素的索引作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="copying" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 超过数组从 <paramref name="start" /> 开始剩余的元素个数。</exception>
	public static Array Copy(this Array array, int start, int count, Func<object, int, object> copying)
	{
		array.GuardNotNull("array");
		return array.Copy(start, count, (object x, int i) => true, copying);
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">复制的起始位置</param>
	/// <param name="count">复制的数组元素个数</param>
	/// <param name="predicate">数组元素复制筛选条件，接收当前筛选的元素作为参数</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="copying" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 超过数组从 <paramref name="start" /> 开始剩余的元素个数。</exception>
	/// <remarks>复制的数组和源数组具有相同的秩（维数）和元素数量，只复制指定索引范围内的元素。</remarks>
	public static Array Copy(this Array array, int start, int count, Func<object, bool> predicate, Func<object, object> copying)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		copying.GuardNotNull("copying");
		return array.Copy(start, count, (object x, int i) => predicate(x), (object x, int i) => copying(x));
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">复制的起始位置</param>
	/// <param name="count">复制的数组元素个数</param>
	/// <param name="predicate">数组元素复制筛选条件，接收当前筛选的元素和该元素的索引作为参数</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素和该元素的索引作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="copying" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 超过数组从 <paramref name="start" /> 开始剩余的元素个数。</exception>
	/// <remarks>复制的数组和源数组具有相同的秩（维数）和元素数量，只复制指定索引范围内的元素。</remarks>
	public static Array Copy(this Array array, int start, int count, Func<object, int, bool> predicate, Func<object, int, object> copying)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		copying.GuardNotNull("copying");
		start.GuardIndexRange(0, array.Length - 1, "start");
		count.GuardBetween(0, array.Length - start, "count");
		int end = start + count;
		int[] weights = array.GetWeight();
		Array result = Array.CreateInstance(array.GetType().GetElementType(), weights);
		for (int i = start; i < end; i++)
		{
			object value = array.GetValue(i, weights);
			if (predicate(value, i))
			{
				result.SetValue(copying(value, i), i, weights);
			}
		}
		return result;
	}

	/// <summary>
	/// 复制当前数组，默认复制每个数组元素引用
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">复制的起始位置</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <remarks>本方法使用 <see cref="M:System.Array.Copy(System.Array,System.Int64,System.Array,System.Int64,System.Int64)" /> 方法复制数组。复制的数组和源数组具有相同的秩（维数）和元素数量，只复制指定索引范围内的元素。</remarks>
	public static Array Copy(this Array array, long start)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		long[] weight = array.GetLongWeight();
		Array result = Array.CreateInstance(array.GetType().GetElementType(), weight);
		Array.Copy(array, start, result, start, array.LongLength - start);
		return result;
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">复制的起始位置</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="copying" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <remarks>复制的数组和源数组具有相同的秩（维数）和元素数量，只复制指定索引范围内的元素。</remarks>
	public static Array Copy(this Array array, long start, Func<object, object> copying)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.Copy(start, array.LongLength - start, (object x) => true, copying);
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">复制的起始位置</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素和该元素的索引作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="copying" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	public static Array Copy(this Array array, long start, Func<object, long, object> copying)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.Copy(start, array.LongLength - start, (object x, long i) => true, copying);
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">复制的起始位置</param>
	/// <param name="predicate">数组元素复制筛选条件，接收当前筛选的元素作为参数</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="copying" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <remarks>复制的数组和源数组具有相同的秩（维数）和元素数量，只复制指定索引范围内的元素。</remarks>
	public static Array Copy(this Array array, long start, Func<object, bool> predicate, Func<object, object> copying)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.Copy(start, array.LongLength - start, predicate, copying);
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">复制的起始位置</param>
	/// <param name="predicate">数组元素复制筛选条件，接收当前筛选的元素和该元素的索引作为参数</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素和该元素的索引作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="copying" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <remarks>复制的数组和源数组具有相同的秩（维数）和元素数量，只复制指定索引范围内的元素。</remarks>
	public static Array Copy(this Array array, long start, Func<object, long, bool> predicate, Func<object, long, object> copying)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.Copy(start, array.LongLength - start, predicate, copying);
	}

	/// <summary>
	/// 复制当前数组，默认复制每个数组元素引用
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">复制的起始位置</param>
	/// <param name="count">复制的数组元素个数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 超过数组从 <paramref name="start" /> 开始剩余的元素个数。</exception>
	/// <remarks>本方法使用 <see cref="M:System.Array.Copy(System.Array,System.Int64,System.Array,System.Int64,System.Int64)" /> 方法复制数组。复制的数组和源数组具有相同的秩（维数）和元素数量，只复制指定索引范围内的元素。</remarks>
	public static Array Copy(this Array array, long start, long count)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		count.GuardBetween(0L, array.LongLength - start, "count");
		long[] weights = array.GetLongWeight();
		Array result = Array.CreateInstance(array.GetType().GetElementType(), weights);
		Array.Copy(array, start, result, start, count);
		return result;
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">复制的起始位置</param>
	/// <param name="count">复制的数组元素个数</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="copying" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 超过数组从 <paramref name="start" /> 开始剩余的元素个数。</exception>
	/// <remarks>复制的数组和源数组具有相同的秩（维数）和元素数量，只复制指定索引范围内的元素。</remarks>
	public static Array Copy(this Array array, long start, long count, Func<object, object> copying)
	{
		array.GuardNotNull("array");
		return array.Copy(start, count, (object x) => true, copying);
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">复制的起始位置</param>
	/// <param name="count">复制的数组元素个数</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素和该元素的索引作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="copying" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 超过数组从 <paramref name="start" /> 开始剩余的元素个数。</exception>
	public static Array Copy(this Array array, long start, long count, Func<object, long, object> copying)
	{
		array.GuardNotNull("array");
		return array.Copy(start, count, (object x, long i) => true, copying);
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">复制的起始位置</param>
	/// <param name="count">复制的数组元素个数</param>
	/// <param name="predicate">数组元素复制筛选条件，接收当前筛选的元素作为参数</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="copying" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 超过数组从 <paramref name="start" /> 开始剩余的元素个数。</exception>
	/// <remarks>复制的数组和源数组具有相同的秩（维数）和元素数量，只复制指定索引范围内的元素。</remarks>
	public static Array Copy(this Array array, long start, long count, Func<object, bool> predicate, Func<object, object> copying)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		copying.GuardNotNull("copying");
		return array.Copy(start, count, (object x, long i) => predicate(x), (object x, long i) => copying(x));
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">复制的起始位置</param>
	/// <param name="count">复制的数组元素个数</param>
	/// <param name="predicate">数组元素复制筛选条件，接收当前筛选的元素和该元素的索引作为参数</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素和该元素的索引作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="copying" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 超过数组从 <paramref name="start" /> 开始剩余的元素个数。</exception>
	/// <remarks>复制的数组和源数组具有相同的秩（维数）和元素数量，只复制指定索引范围内的元素。</remarks>
	public static Array Copy(this Array array, long start, long count, Func<object, long, bool> predicate, Func<object, long, object> copying)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		copying.GuardNotNull("copying");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		count.GuardBetween(0L, array.LongLength - start, "count");
		long end = start + count;
		long[] weight = array.GetLongWeight();
		Array result = Array.CreateInstance(array.GetType().GetElementType(), weight);
		for (long i = start; i < end; i++)
		{
			object value = array.GetValue(i, weight);
			if (predicate(value, i))
			{
				result.SetValue(copying(value, i), i, weight);
			}
		}
		return result;
	}

	/// <summary>
	/// 复制当前数组，默认复制每个数组元素的引用
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <remarks>本方法使用 <see cref="M:System.Array.Clone" /> 方法复制当前数组。</remarks>
	public static T[] Copy<T>(this T[] array)
	{
		array.GuardNotNull("array");
		return (T[])array.Clone();
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="copying" /> 为空。</exception>
	public static T[] Copy<T>(this T[] array, Func<T, T> copying)
	{
		array.GuardNotNull("array");
		return array.Copy(0, array.Length, copying);
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素和该元素的索引作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="copying" /> 为空。</exception>
	public static T[] Copy<T>(this T[] array, Func<T, int, T> copying)
	{
		array.GuardNotNull("array");
		return array.Copy(0, array.Length, copying);
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">复制数组元素筛选条件，接收当前筛选的元素作为参数</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="copying" /> 为空。</exception>
	public static T[] Copy<T>(this T[] array, Func<T, bool> predicate, Func<T, T> copying)
	{
		array.GuardNotNull("array");
		return array.Copy(0, array.Length, predicate, copying);
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">复制数组元素筛选条件，接收当前筛选的元素和该元素的索引作为参数</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素和该元素的索引作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="copying" /> 为空。</exception>
	public static T[] Copy<T>(this T[] array, Func<T, int, bool> predicate, Func<T, int, T> copying)
	{
		array.GuardNotNull("array");
		return array.Copy(0, array.Length, predicate, copying);
	}

	/// <summary>
	/// 复制当前数组，默认复制每个数组元素引用
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">复制的起始位置</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <remarks>本方法使用 <see cref="M:System.Array.Copy(System.Array,System.Int32,System.Array,System.Int32,System.Int32)" /> 方法复制数组。复制的数组和源数组具有相同的秩（维数）和元素数量，只复制指定索引范围内的元素。</remarks>
	public static T[] Copy<T>(this T[] array, int start)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		T[] result = new T[array.Length];
		Array.Copy(array, start, result, start, array.Length - start);
		return result;
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">复制的起始位置</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="copying" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <remarks>复制的数组和源数组具有相同的秩（维数）和元素数量，只复制指定索引范围内的元素。</remarks>
	public static T[] Copy<T>(this T[] array, int start, Func<T, T> copying)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.Copy(start, array.Length - start, (T x) => true, copying);
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">复制的起始位置</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素和该元素的索引作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="copying" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <remarks>复制的数组和源数组具有相同的秩（维数）和元素数量，只复制指定索引范围内的元素。</remarks>
	public static T[] Copy<T>(this T[] array, int start, Func<T, int, T> copying)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.Copy(start, array.Length - start, (T x, int i) => true, copying);
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">复制的起始位置</param>
	/// <param name="predicate">复制数组元素筛选条件，接收当前筛选的元素作为参数</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="copying" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <remarks>复制的数组和源数组具有相同的秩（维数）和元素数量，只复制指定索引范围内的元素。</remarks>
	public static T[] Copy<T>(this T[] array, int start, Func<T, bool> predicate, Func<T, T> copying)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.Copy(start, array.Length - start, predicate, copying);
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">复制的起始位置</param>
	/// <param name="predicate">复制数组元素筛选条件，接收当前筛选的元素和该元素的索引作为参数</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素和该元素的索引作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="copying" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <remarks>复制的数组和源数组具有相同的秩（维数）和元素数量，只复制指定索引范围内的元素。</remarks>
	public static T[] Copy<T>(this T[] array, int start, Func<T, int, bool> predicate, Func<T, int, T> copying)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.Copy(start, array.Length - start, predicate, copying);
	}

	/// <summary>
	/// 复制当前数组，默认复制每个数组元素引用
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">复制的起始位置</param>
	/// <param name="count">复制的数组元素的个数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" />小于0，或者大于从 <paramref name="start" /> 开始剩余的元素个数。</exception>
	/// <remarks>本方法使用 <see cref="M:System.Array.Copy(System.Array,System.Int32,System.Array,System.Int32,System.Int32)" /> 方法复制数组。复制的数组和源数组具有相同的秩（维数）和元素数量，只复制指定索引范围内的元素。</remarks>
	public static T[] Copy<T>(this T[] array, int start, int count)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		count.GuardBetween(0, array.Length - start, "count");
		T[] result = new T[array.Length];
		Array.Copy(array, start, result, start, count);
		return result;
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">复制的起始位置</param>
	/// <param name="count">复制的数组元素的个数</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="copying" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" />小于0，或者大于从 <paramref name="start" /> 开始剩余的元素个数。</exception>
	/// <remarks>复制的数组和源数组具有相同的秩（维数）和元素数量，只复制指定索引范围内的元素。</remarks>
	public static T[] Copy<T>(this T[] array, int start, int count, Func<T, T> copying)
	{
		return array.Copy(start, count, (T x) => true, copying);
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">复制的起始位置</param>
	/// <param name="count">复制的数组元素的个数</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素和该元素的索引作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="copying" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" />小于0，或者大于从 <paramref name="start" /> 开始剩余的元素个数。</exception>
	/// <remarks>复制的数组和源数组具有相同的秩（维数）和元素数量，只复制指定索引范围内的元素。</remarks>
	public static T[] Copy<T>(this T[] array, int start, int count, Func<T, int, T> copying)
	{
		return array.Copy(start, count, (T x, int i) => true, copying);
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">复制的起始位置</param>
	/// <param name="count">复制的数组元素个数</param>
	/// <param name="predicate">复制数组元素筛选条件，接收当前筛选的元素作为参数</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="copying" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" />小于0，或者大于从 <paramref name="start" /> 开始剩余的元素个数。</exception>
	/// <remarks>复制的数组和源数组具有相同的秩（维数）和元素数量，只复制指定索引范围内的元素。</remarks>
	public static T[] Copy<T>(this T[] array, int start, int count, Func<T, bool> predicate, Func<T, T> copying)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		copying.GuardNotNull("copying");
		return array.Copy(start, count, (T x, int i) => predicate(x), (T x, int i) => copying(x));
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">复制的起始位置</param>
	/// <param name="count">复制的数组元素数量</param>
	/// <param name="predicate">复制数组元素筛选条件，接收当前筛选的元素和该元素的索引作为参数</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素和该元素的索引作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="copying" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" />小于0，或者大于从 <paramref name="start" /> 开始剩余的元素个数。</exception>
	/// <remarks>复制的数组和源数组具有相同的秩（维数）和元素数量，只复制指定索引范围内的元素。</remarks>
	public static T[] Copy<T>(this T[] array, int start, int count, Func<T, int, bool> predicate, Func<T, int, T> copying)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		copying.GuardNotNull("copying");
		start.GuardIndexRange(0, array.Length - 1, "start");
		count.GuardBetween(0, array.Length - start, "count");
		int end = start + count;
		T[] result = new T[array.Length];
		for (int i = start; i < end; i++)
		{
			if (predicate(array[i], i))
			{
				result[i - start] = copying(array[i], i);
			}
		}
		return result;
	}

	/// <summary>
	/// 复制当前数组，默认复制每个数组元素引用
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">复制的起始位置</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <remarks>本方法使用 <see cref="M:System.Array.Copy(System.Array,System.Int64,System.Array,System.Int64,System.Int64)" /> 方法复制数组。复制的数组和源数组具有相同的秩（维数）和元素数量，只复制指定索引范围内的元素。</remarks>
	public static T[] Copy<T>(this T[] array, long start)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		T[] result = new T[array.LongLength];
		Array.Copy(array, start, result, start, array.LongLength - start);
		return result;
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">复制的起始位置</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="copying" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <remarks>复制的数组和源数组具有相同的秩（维数）和元素数量，只复制指定索引范围内的元素。</remarks>
	public static T[] Copy<T>(this T[] array, long start, Func<T, T> copying)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.Copy(start, array.LongLength - start, (T x) => true, copying);
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">复制的起始位置</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素和该元素的索引作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="copying" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <remarks>复制的数组和源数组具有相同的秩（维数）和元素数量，只复制指定索引范围内的元素。</remarks>
	public static T[] Copy<T>(this T[] array, long start, Func<T, long, T> copying)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.Copy(start, array.LongLength - start, (T x, long i) => true, copying);
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">复制的起始位置</param>
	/// <param name="predicate">复制数组元素筛选条件，接收当前筛选的元素作为参数</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="copying" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <remarks>复制的数组和源数组具有相同的秩（维数）和元素数量，只复制指定索引范围内的元素。</remarks>
	public static T[] Copy<T>(this T[] array, long start, Func<T, bool> predicate, Func<T, T> copying)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.Copy(start, array.LongLength - start, predicate, copying);
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">复制的起始位置</param>
	/// <param name="predicate">复制数组元素筛选条件，接收当前筛选的元素和该元素的索引作为参数</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素和该元素的索引作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="copying" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <remarks>复制的数组和源数组具有相同的秩（维数）和元素数量，只复制指定索引范围内的元素。</remarks>
	public static T[] Copy<T>(this T[] array, long start, Func<T, long, bool> predicate, Func<T, long, T> copying)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.Copy(start, array.LongLength - start, predicate, copying);
	}

	/// <summary>
	/// 复制当前数组，默认复制每个数组元素引用
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">复制的起始位置</param>
	/// <param name="count">复制的数组元素的个数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" />小于0，或者大于从 <paramref name="start" /> 开始剩余的元素个数。</exception>
	/// <remarks>本方法使用 <see cref="M:System.Array.Copy(System.Array,System.Int64,System.Array,System.Int64,System.Int64)" /> 方法复制数组。复制的数组和源数组具有相同的秩（维数）和元素数量，只复制指定索引范围内的元素。</remarks>
	public static T[] Copy<T>(this T[] array, long start, long count)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		count.GuardBetween(0L, array.LongLength - start, "count");
		T[] result = new T[array.LongLength];
		Array.Copy(array, start, result, start, count);
		return result;
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">复制的起始位置</param>
	/// <param name="count">复制的数组元素的个数</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="copying" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" />小于0，或者大于从 <paramref name="start" /> 开始剩余的元素个数。</exception>
	/// <remarks>复制的数组和源数组具有相同的秩（维数）和元素数量，只复制指定索引范围内的元素。</remarks>
	public static T[] Copy<T>(this T[] array, long start, long count, Func<T, T> copying)
	{
		return array.Copy(start, count, (T x) => true, copying);
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">复制的起始位置</param>
	/// <param name="count">复制的数组元素的个数</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素和该元素的索引作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="copying" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" />小于0，或者大于从 <paramref name="start" /> 开始剩余的元素个数。</exception>
	/// <remarks>复制的数组和源数组具有相同的秩（维数）和元素数量，只复制指定索引范围内的元素。</remarks>
	public static T[] Copy<T>(this T[] array, long start, long count, Func<T, long, T> copying)
	{
		return array.Copy(start, count, (T x, long i) => true, copying);
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">复制的起始位置</param>
	/// <param name="count">复制的数组元素个数</param>
	/// <param name="predicate">复制数组元素筛选条件，接收当前筛选的元素作为参数</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="copying" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" />小于0，或者大于从 <paramref name="start" /> 开始剩余的元素个数。</exception>
	/// <remarks>复制的数组和源数组具有相同的秩（维数）和元素数量，只复制指定索引范围内的元素。</remarks>
	public static T[] Copy<T>(this T[] array, long start, long count, Func<T, bool> predicate, Func<T, T> copying)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		copying.GuardNotNull("copying");
		return array.Copy(start, count, (T x, long i) => predicate(x), (T x, long i) => copying(x));
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">复制的起始位置</param>
	/// <param name="count">复制的数组元素数量</param>
	/// <param name="predicate">复制数组元素筛选条件，接收当前筛选的元素和该元素的索引作为参数</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素和该元素的索引作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="copying" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" />小于0，或者大于从 <paramref name="start" /> 开始剩余的元素个数。</exception>
	/// <remarks>复制的数组和源数组具有相同的秩（维数）和元素数量，只复制指定索引范围内的元素。</remarks>
	public static T[] Copy<T>(this T[] array, long start, long count, Func<T, long, bool> predicate, Func<T, long, T> copying)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		copying.GuardNotNull("copying");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		count.GuardBetween(0L, array.LongLength - start, "count");
		long end = start + count;
		T[] result = new T[array.LongLength];
		for (long i = start; i < end; i++)
		{
			if (predicate(array[i], i))
			{
				result[i - start] = copying(array[i], i);
			}
		}
		return result;
	}

	/// <summary>
	/// 从当前数组向目标数组复制元素；当前数组和目标数组可以是多维数组，但是其维度必须相同。
	/// </summary>
	/// <param name="source">当前数组</param>
	/// <param name="target">复制的目标数组</param>
	/// <returns>复制的目标数组</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> 为空；或者 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.RankException">当前数组和目标数组的秩（维数）不相同。</exception>
	public static void CopyTo(this Array source, Array target)
	{
		source.GuardNotNull("source");
		target.GuardNotNull("target");
		source.GuardArrayRank(target.Rank, string.Empty, Literals.MSG_ArrayRankNotSame_2.FormatValue("source", "target"));
		Array.Copy(source, 0L, target, 0L, Math.Min(source.LongLength, target.LongLength));
	}

	/// <summary>
	/// 从当前数组向目标数组复制元素；当前数组和目标数组可以是多维数组，但是其维度必须相同。
	/// </summary>
	/// <param name="source">当前数组</param>
	/// <param name="target">复制的目标数组</param>
	/// <param name="targetStart">向目标数组复制的起始位置</param>
	/// <returns>复制的目标数组</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> 为空；或者 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.RankException">当前数组和目标数组的秩（维数）不相同。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="targetStart" /> 不在目标数组的元素索引范围内。</exception>
	public static void CopyTo(this Array source, Array target, int targetStart)
	{
		source.GuardNotNull("source");
		target.GuardNotNull("target");
		source.GuardArrayRank(target.Rank, string.Empty, Literals.MSG_ArrayRankNotSame_2.FormatValue("source", "target"));
		targetStart.GuardIndexRange(0, target.Length - 1, "target start");
		Array.Copy(source, 0, target, targetStart, Math.Min(source.Length, target.Length - targetStart));
	}

	/// <summary>
	/// 从当前数组向目标数组复制元素；当前数组和目标数组可以是多维数组，但是其维度必须相同。
	/// </summary>
	/// <param name="source">当前数组</param>
	/// <param name="target">复制的目标数组</param>
	/// <param name="targetStart">起始复制位置</param>
	/// <param name="copyCount">复制的数组元素个数</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> 为空；或者 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.RankException">当前数组和目标数组的秩（维数）不相同。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="targetStart" /> 不在目标数组的索引范围内。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="copyCount" /> 小于0，或者大于当前数组可复制的数量和目标数组可容纳的数量。</exception>
	public static void CopyTo(this Array source, Array target, int targetStart, int copyCount)
	{
		source.GuardNotNull("source");
		target.GuardNotNull("target");
		source.GuardArrayRank(target.Rank, string.Empty, Literals.MSG_ArrayRankNotSame_2.FormatValue("source", "target"));
		targetStart.GuardIndexRange(0, target.Length - 1, "target start");
		copyCount.GuardBetween(0, Math.Min(source.Length, target.Length - targetStart), "copy count");
		Array.Copy(source, 0, target, targetStart, copyCount);
	}

	/// <summary>
	/// 从当前数组向目标数组复制元素；当前数组和目标数组可以是多维数组，但是其维度必须相同。
	/// </summary>
	/// <param name="source">当前数组</param>
	/// <param name="sourceStart">向当前数组复制的起始位置</param>
	/// <param name="target">复制的目标数组</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> 为空；或者 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.RankException">当前数组和目标数组的秩（维数）不相同。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="sourceStart" /> 不在当前数组元素的索引范围内。</exception>
	public static void CopyTo(this Array source, int sourceStart, Array target)
	{
		source.GuardNotNull("source");
		target.GuardNotNull("target");
		source.GuardArrayRank(target.Rank, string.Empty, Literals.MSG_ArrayRankNotSame_2.FormatValue("source", "target"));
		sourceStart.GuardIndexRange(0, source.Length - 1, "source target");
		Array.Copy(source, sourceStart, target, 0, Math.Min(source.Length - sourceStart, target.Length));
	}

	/// <summary>
	/// 从当前数组向目标数组复制元素；当前数组和目标数组可以是多维数组，但是其维度必须相同。
	/// </summary>
	/// <param name="source">当前数组</param>
	/// <param name="sourceStart">向当前数组复制的起始位置</param>
	/// <param name="target">复制的目标数组</param>
	/// <param name="targetStart">向目标数组复制的起始位置</param>
	/// <returns>复制的目标数组</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> 为空；或者 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.RankException">当前数组和目标数组的秩（维数）不相同。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="sourceStart" /> 不在当前数组元素的索引范围内；<paramref name="targetStart" /> 不在目标数组元素的索引范围内。</exception>
	public static void CopyTo(this Array source, int sourceStart, Array target, int targetStart)
	{
		source.GuardNotNull("source");
		target.GuardNotNull("target");
		source.GuardArrayRank(target.Rank, string.Empty, Literals.MSG_ArrayRankNotSame_2.FormatValue("source", "target"));
		sourceStart.GuardIndexRange(0, source.Length - 1, "source start");
		targetStart.GuardIndexRange(0, target.Length - 1, "target start");
		Array.Copy(source, sourceStart, target, targetStart, Math.Min(source.Length - sourceStart, target.Length - targetStart));
	}

	/// <summary>
	/// 从当前数组向目标数组复制元素；当前数组和目标数组可以是多维数组，但是其维度必须相同。
	/// </summary>
	/// <param name="source">当前数组</param>
	/// <param name="sourceStart">向当前数组复制的起始位置</param>
	/// <param name="target">目标数组</param>
	/// <param name="targetStart">向目标数组复制的起始位置</param>
	/// <param name="copyCount">复制的元素数量</param>
	/// <returns>复制的目标数组</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> 为空；或者 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.RankException">当前数组和目标数组的秩（维数）不相同。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="sourceStart" /> 不在当前数组元素的索引范围内；<paramref name="targetStart" /> 不在目标数组元素的索引范围内。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="copyCount" /> 小于0，或者大于当前数组剩余的元素数量和目标数组剩余元素个数。</exception>
	public static void CopyTo(this Array source, int sourceStart, Array target, int targetStart, int copyCount)
	{
		source.GuardNotNull("source");
		target.GuardNotNull("target");
		sourceStart.GuardIndexRange(0, source.Length - 1, "source start");
		targetStart.GuardIndexRange(0, target.Length - 1, "target start");
		copyCount.GuardBetween(0, Math.Min(source.Length - sourceStart, target.Length - targetStart), "copy count");
		Array.Copy(source, sourceStart, target, targetStart, copyCount);
	}

	/// <summary>
	/// 从当前数组向目标数组复制元素；当前数组和目标数组可以是多维数组，但是其维度必须相同。
	/// </summary>
	/// <param name="source">当前数组</param>
	/// <param name="target">复制的目标数组</param>
	/// <param name="targetStart">向目标数组复制的起始位置</param>
	/// <returns>复制的目标数组</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> 为空；或者 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.RankException">当前数组和目标数组的秩（维数）不相同。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="targetStart" /> 不在目标数组的元素索引范围内。</exception>
	public static void CopyTo(this Array source, Array target, long targetStart)
	{
		source.GuardNotNull("source");
		target.GuardNotNull("target");
		targetStart.GuardIndexRange(0L, target.LongLength - 1, "target start");
		Array.Copy(source, 0L, target, targetStart, Math.Min(source.LongLength, target.LongLength - targetStart));
	}

	/// <summary>
	/// 从当前数组向目标数组复制元素；当前数组和目标数组可以是多维数组，但是其维度必须相同。
	/// </summary>
	/// <param name="source">当前数组</param>
	/// <param name="target">复制的目标数组</param>
	/// <param name="targetStart">起始复制位置</param>
	/// <param name="copyCount">复制的数组元素个数</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> 为空；或者 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.RankException">当前数组和目标数组的秩（维数）不相同。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="targetStart" /> 不在目标数组的索引范围内。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="copyCount" /> 小于0，或者大于当前数组可复制的数量和目标数组可容纳的数量。</exception>
	public static void CopyTo(this Array source, Array target, long targetStart, long copyCount)
	{
		source.GuardNotNull("source");
		target.GuardNotNull("target");
		targetStart.GuardIndexRange(0L, target.LongLength - 1, "target start");
		copyCount.GuardBetween(0L, Math.Min(source.LongLength, target.LongLength - targetStart), "copy count");
		Array.Copy(source, 0L, target, targetStart, copyCount);
	}

	/// <summary>
	/// 从当前数组向目标数组复制元素；当前数组和目标数组可以是多维数组，但是其维度必须相同。
	/// </summary>
	/// <param name="source">当前数组</param>
	/// <param name="sourceStart">向当前数组复制的起始位置</param>
	/// <param name="target">复制的目标数组</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> 为空；或者 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.RankException">当前数组和目标数组的秩（维数）不相同。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="sourceStart" /> 不在当前数组元素的索引范围内。</exception>
	public static void CopyTo(this Array source, long sourceStart, Array target)
	{
		source.GuardNotNull("source");
		target.GuardNotNull("target");
		sourceStart.GuardIndexRange(0L, source.LongLength - 1, "source target");
		Array.Copy(source, sourceStart, target, 0L, Math.Min(source.LongLength - sourceStart, target.LongLength));
	}

	/// <summary>
	/// 从当前数组向目标数组复制元素；当前数组和目标数组可以是多维数组，但是其维度必须相同。
	/// </summary>
	/// <param name="source">当前数组</param>
	/// <param name="sourceStart">向当前数组复制的起始位置</param>
	/// <param name="target">复制的目标数组</param>
	/// <param name="targetStart">向目标数组复制的起始位置</param>
	/// <returns>复制的目标数组</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> 为空；或者 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.RankException">当前数组和目标数组的秩（维数）不相同。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="sourceStart" /> 不在当前数组元素的索引范围内；<paramref name="targetStart" /> 不在目标数组元素的索引范围内。</exception>
	public static void CopyTo(this Array source, long sourceStart, Array target, long targetStart)
	{
		source.GuardNotNull("source");
		target.GuardNotNull("target");
		sourceStart.GuardIndexRange(0L, source.LongLength - 1, "source start");
		targetStart.GuardIndexRange(0L, target.LongLength - 1, "target start");
		Array.Copy(source, sourceStart, target, targetStart, Math.Min(source.LongLength - sourceStart, target.LongLength - targetStart));
	}

	/// <summary>
	/// 从当前数组向目标数组复制元素；当前数组和目标数组可以是多维数组，但是其维度必须相同。
	/// </summary>
	/// <param name="source">当前数组</param>
	/// <param name="sourceStart">向当前数组复制的起始位置</param>
	/// <param name="target">目标数组</param>
	/// <param name="targetStart">向目标数组复制的起始位置</param>
	/// <param name="copyCount">复制的元素数量</param>
	/// <returns>复制的目标数组</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> 为空；或者 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.RankException">当前数组和目标数组的秩（维数）不相同。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="sourceStart" /> 不在当前数组元素的索引范围内；<paramref name="targetStart" /> 不在目标数组元素的索引范围内。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="copyCount" /> 小于0，或者大于当前数组剩余的元素数量和目标数组剩余元素个数。</exception>
	public static void CopyTo(this Array source, long sourceStart, Array target, long targetStart, long copyCount)
	{
		source.GuardNotNull("source");
		target.GuardNotNull("target");
		sourceStart.GuardIndexRange(0L, source.LongLength - 1, "source start");
		targetStart.GuardIndexRange(0L, target.LongLength - 1, "target start");
		copyCount.GuardBetween(0L, Math.Min(source.LongLength - sourceStart, target.LongLength - targetStart), "copy count");
		Array.Copy(source, sourceStart, target, targetStart, copyCount);
	}

	/// <summary>
	/// 检测当前数组是否包含与满足指定条件的元素
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">元素检测条件</param>
	/// <returns>如果存在满足条件的元素返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static bool Exists(this Array array, Func<object, bool> predicate)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		return array.OfType<object>().Any(predicate);
	}

	/// <summary>
	/// 检测当前数组是否包含与满足指定条件的元素；当前数组可以是一维或者多维数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">元素检测条件</param>
	/// <returns>如果存在满足条件的元素返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static bool Exists(this Array array, Func<object, int, bool> predicate)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		return array.OfType<object>().Any(predicate);
	}

	/// <summary>
	/// 检测当前数组是否包含与满足指定条件的元素
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">元素检测条件</param>
	/// <returns>如果存在满足条件的元素返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static bool Exists<T>(this T[] array, Func<T, bool> predicate)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		return Array.Exists(array, (T x) => predicate(x));
	}

	/// <summary>
	/// 检测当前数组是否包含与满足指定条件的元素
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">元素检测条件</param>
	/// <returns>如果存在满足条件的元素返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static bool Exists<T>(this T[] array, Func<T, int, bool> predicate)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		int index = 0;
		return Array.Exists(array, (T x) => predicate(x, index++));
	}

	/// <summary>
	/// 填充当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="value">填充值</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static Array Fill(this Array array, object value)
	{
		array.GuardNotNull("array");
		return array.Fill(0, array.Length, value);
	}

	/// <summary>
	/// 填充当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="evaluator">元素计算方法</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluator" /> 为空。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static Array Fill(this Array array, Func<int, object> evaluator)
	{
		array.GuardNotNull("array");
		return array.Fill(0, array.Length, evaluator);
	}

	/// <summary>
	/// 填充当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="evaluator">元素计算方法</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluator" /> 为空。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static Array Fill(this Array array, Func<object, int, object> evaluator)
	{
		array.GuardNotNull("array");
		return array.Fill(0, array.Length, evaluator);
	}

	/// <summary>
	/// 填充当前数组
	/// </summary>
	/// <param name="array"></param>
	/// <param name="start">开始填充的索引位置</param>
	/// <param name="count">填充的元素个数</param>
	/// <param name="value">填充值</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组索引有效范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 开始剩余的元素数量。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static Array Fill(this Array array, int start, int count, object value)
	{
		return array.Fill(start, count, (int i) => value);
	}

	/// <summary>
	/// 填充当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始填充的索引位置</param>
	/// <param name="count">填充的元素个数</param>
	/// <param name="evaluator">元素计算方法</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组索引有效范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 开始剩余的元素数量。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static Array Fill(this Array array, int start, int count, Func<int, object> evaluator)
	{
		array.GuardNotNull("array");
		evaluator.GuardNotNull("evaluator");
		start.GuardIndexRange(0, array.Length - 1, "start");
		count.GuardBetween(0, array.Length - start, "count");
		int end = start + count;
		int[] weights = array.GetWeight();
		for (int i = start; i < end; i++)
		{
			array.SetValue(evaluator(i), i, weights);
		}
		return array;
	}

	/// <summary>
	/// 填充当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始填充的索引位置</param>
	/// <param name="count">填充的元素个数</param>
	/// <param name="evaluator">元素计算方法</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组索引有效范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 开始剩余的元素数量。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static Array Fill(this Array array, int start, int count, Func<object, int, object> evaluator)
	{
		array.GuardNotNull("array");
		evaluator.GuardNotNull("evaluator");
		start.GuardIndexRange(0, array.Length - 1, "start");
		count.GuardBetween(0, array.Length - start, "count");
		int end = start + count;
		int[] weights = array.GetWeight();
		for (int i = start; i < end; i++)
		{
			array.SetValue(evaluator(array.GetValue(i, weights), i), i, weights);
		}
		return array;
	}

	/// <summary>
	/// 填充当前数组
	/// </summary>
	/// <typeparam name="T">当前数组的元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="value">填充值</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static T[] Fill<T>(this T[] array, T value)
	{
		array.GuardNotNull("array");
		return array.Fill(0, array.Length, value);
	}

	/// <summary>
	/// 填充当前数组
	/// </summary>
	/// <typeparam name="T">当前数组的元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="evaluator">元素计算方法</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluator" /> 为空。</exception>
	public static T[] Fill<T>(this T[] array, Func<int, T> evaluator)
	{
		array.GuardNotNull("array");
		return array.Fill(0, array.Length, evaluator);
	}

	/// <summary>
	/// 填充当前数组
	/// </summary>
	/// <typeparam name="T">当前数组的元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="evaluator">元素计算方法</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluator" /> 为空。</exception>
	public static T[] Fill<T>(this T[] array, Func<T, int, T> evaluator)
	{
		array.GuardNotNull("array");
		return array.Fill(0, array.Length, evaluator);
	}

	/// <summary>
	/// 填充当前数组
	/// </summary>
	/// <typeparam name="T">当前数组的元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始填充的索引位置</param>
	/// <param name="count">填充的元素个数</param>
	/// <param name="value">填充值</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组索引有效范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static T[] Fill<T>(this T[] array, int start, int count, T value)
	{
		return array.Fill(start, count, (int i) => value);
	}

	/// <summary>
	/// 填充当前数组
	/// </summary>
	/// <typeparam name="T">当前数组的元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始填充的索引位置</param>
	/// <param name="count">填充的元素个数</param>
	/// <param name="evaluator">元素计算方法</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组索引有效范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static T[] Fill<T>(this T[] array, int start, int count, Func<int, T> evaluator)
	{
		array.GuardNotNull("array");
		evaluator.GuardNotNull("evaluator");
		start.GuardIndexRange(0, array.Length - 1, "start");
		count.GuardBetween(0, array.Length - start, "count");
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			array[i] = evaluator(i);
		}
		return array;
	}

	/// <summary>
	/// 填充当前数组
	/// </summary>
	/// <typeparam name="T">当前数组的元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始填充的索引位置</param>
	/// <param name="count">填充的元素个数</param>
	/// <param name="evaluator">元素计算方法</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组索引有效范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static T[] Fill<T>(this T[] array, int start, int count, Func<T, int, T> evaluator)
	{
		array.GuardNotNull("array");
		evaluator.GuardNotNull("evaluator");
		start.GuardIndexRange(0, array.Length - 1, "start");
		count.GuardBetween(0, array.Length - start, "count");
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			array[i] = evaluator(array[i], i);
		}
		return array;
	}

	/// <summary>
	/// 填充当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="value">填充值</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static Array FillLong(this Array array, object value)
	{
		array.GuardNotNull("array");
		return array.FillLong(0L, array.LongLength, value);
	}

	/// <summary>
	/// 填充当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="evaluator">元素计算方法</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluator" /> 为空。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static Array FillLong(this Array array, Func<long, object> evaluator)
	{
		array.GuardNotNull("array");
		return array.FillLong(0L, array.LongLength, evaluator);
	}

	/// <summary>
	/// 填充当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="evaluator">元素计算方法</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluator" /> 为空。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static Array FillLong(this Array array, Func<object, long, object> evaluator)
	{
		array.GuardNotNull("array");
		return array.FillLong(0L, array.LongLength, evaluator);
	}

	/// <summary>
	/// 填充当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始填充的索引位置</param>
	/// <param name="count">填充的元素个数</param>
	/// <param name="value">填充值</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组索引有效范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 开始剩余的元素数量。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static Array FillLong(this Array array, long start, long count, object value)
	{
		return array.FillLong(start, count, (long i) => value);
	}

	/// <summary>
	/// 填充当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始填充的索引位置</param>
	/// <param name="count">填充的元素个数</param>
	/// <param name="evaluator">元素计算方法</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组索引有效范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 开始剩余的元素数量。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static Array FillLong(this Array array, long start, long count, Func<long, object> evaluator)
	{
		array.GuardNotNull("array");
		evaluator.GuardNotNull("evaluator");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		count.GuardBetween(0L, array.LongLength - start, "count");
		long end = start + count;
		long[] weights = array.GetLongWeight();
		for (long i = start; i < end; i++)
		{
			array.SetValue(evaluator(i), i, weights);
		}
		return array;
	}

	/// <summary>
	/// 填充当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始填充的索引位置</param>
	/// <param name="count">填充的元素个数</param>
	/// <param name="evaluator">元素计算方法</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组索引有效范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 开始剩余的元素数量。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static Array FillLong(this Array array, long start, long count, Func<object, long, object> evaluator)
	{
		array.GuardNotNull("array");
		evaluator.GuardNotNull("evaluator");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		count.GuardBetween(0L, array.LongLength - start, "count");
		long end = start + count;
		long[] weights = array.GetLongWeight();
		for (long i = start; i < end; i++)
		{
			array.SetValue(evaluator(array.GetValue(i, weights), i), i, weights);
		}
		return array;
	}

	/// <summary>
	/// 填充当前数组
	/// </summary>
	/// <typeparam name="T">当前数组的元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="value">填充值</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static T[] FillLong<T>(this T[] array, T value)
	{
		array.GuardNotNull("array");
		return array.FillLong(0L, array.LongLength, value);
	}

	/// <summary>
	/// 填充当前数组
	/// </summary>
	/// <typeparam name="T">当前数组的元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="evaluator">元素计算方法</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluator" /> 为空。</exception>
	public static T[] FillLong<T>(this T[] array, Func<long, T> evaluator)
	{
		array.GuardNotNull("array");
		return array.FillLong(0L, array.LongLength, evaluator);
	}

	/// <summary>
	/// 填充当前数组
	/// </summary>
	/// <typeparam name="T">当前数组的元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="evaluator">元素计算方法</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluator" /> 为空。</exception>
	public static T[] FillLong<T>(this T[] array, Func<T, long, T> evaluator)
	{
		array.GuardNotNull("array");
		return array.FillLong(0L, array.LongLength, evaluator);
	}

	/// <summary>
	/// 填充当前数组
	/// </summary>
	/// <typeparam name="T">当前数组的元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始填充的索引位置</param>
	/// <param name="count">填充的元素个数</param>
	/// <param name="value">填充值</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组索引有效范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static T[] FillLong<T>(this T[] array, long start, long count, T value)
	{
		return array.FillLong(start, count, (long i) => value);
	}

	/// <summary>
	/// 填充当前数组
	/// </summary>
	/// <typeparam name="T">当前数组的元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始填充的索引位置</param>
	/// <param name="count">填充的元素个数</param>
	/// <param name="evaluator">元素计算方法</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组索引有效范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static T[] FillLong<T>(this T[] array, long start, long count, Func<long, T> evaluator)
	{
		array.GuardNotNull("array");
		evaluator.GuardNotNull("evaluator");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		count.GuardBetween(0L, array.LongLength - start, "count");
		long end = start + count;
		for (long i = start; i < end; i++)
		{
			array[i] = evaluator(i);
		}
		return array;
	}

	/// <summary>
	/// 填充当前数组
	/// </summary>
	/// <typeparam name="T">当前数组的元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始填充的索引位置</param>
	/// <param name="count">填充的元素个数</param>
	/// <param name="evaluator">元素计算方法</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组索引有效范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static T[] FillLong<T>(this T[] array, long start, long count, Func<T, long, T> evaluator)
	{
		array.GuardNotNull("array");
		evaluator.GuardNotNull("evaluator");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		count.GuardBetween(0L, array.LongLength - start, "count");
		long end = start + count;
		for (long i = start; i < end; i++)
		{
			array[i] = evaluator(array[i], i);
		}
		return array;
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的元素，返回匹配的第一个元素
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">元素筛选条件</param>
	/// <param name="defaultValue">如果找不到符合条件的元素返回的默认值</param>
	/// <returns>找到匹配的第一个元素，如果未找到则返回 <paramref name="defaultValue" /> 的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static object Find(this Array array, Func<object, bool> predicate, object defaultValue = null)
	{
		array.GuardNotNull("array");
		return array.Find(0, array.Length, predicate, defaultValue);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的元素，返回匹配的第一个元素
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">元素筛选条件</param>
	/// <param name="defaultValue">如果找不到符合条件的元素返回的默认值</param>
	/// <returns>找到匹配的第一个元素，如果未找到则返回 <paramref name="defaultValue" /> 的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static object Find(this Array array, Func<object, int, bool> predicate, object defaultValue = null)
	{
		array.GuardNotNull("array");
		return array.Find(0, array.Length, predicate, defaultValue);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的元素，返回匹配的第一个元素
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始查找的索引位置</param>
	/// <param name="predicate">元素筛选条件</param>
	/// <param name="defaultValue">如果找不到符合条件的元素返回的默认值</param>
	/// <returns>找到匹配的第一个元素，如果未找到则返回 <paramref name="defaultValue" /> 的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static object Find(this Array array, int start, Func<object, bool> predicate, object defaultValue = null)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.Find(start, array.Length - start, predicate, defaultValue);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的元素，返回匹配的第一个元素
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始查找的索引位置</param>
	/// <param name="predicate">元素筛选条件</param>
	/// <param name="defaultValue">如果找不到符合条件的元素返回的默认值</param>
	/// <returns>找到匹配的第一个元素，如果未找到则返回 <paramref name="defaultValue" /> 的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static object Find(this Array array, int start, Func<object, int, bool> predicate, object defaultValue = null)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.Find(start, array.Length - start, predicate, defaultValue);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的元素，返回匹配的第一个元素
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始查找的索引位置</param>
	/// <param name="count">查找的元素数量</param>
	/// <param name="predicate">元素筛选条件</param>
	/// <param name="defaultValue">如果找不到符合条件的元素返回的默认值</param>
	/// <returns>找到匹配的第一个元素，如果未找到则返回 <paramref name="defaultValue" /> 的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始剩余的元素数量。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static object Find(this Array array, int start, int count, Func<object, bool> predicate, object defaultValue = null)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		return array.Find(start, count, (object x, int i) => predicate(x), defaultValue);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的元素，返回匹配的第一个元素
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始查找的索引位置</param>
	/// <param name="count">查找的元素数量</param>
	/// <param name="predicate">元素筛选条件</param>
	/// <param name="defaultValue">如果找不到符合条件的元素返回的默认值</param>
	/// <returns>找到匹配的第一个元素，如果未找到则返回 <paramref name="defaultValue" /> 的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始剩余的元素数量。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static object Find(this Array array, int start, int count, Func<object, int, bool> predicate, object defaultValue = null)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		count.GuardBetween(0, array.Length - start, "count");
		predicate.GuardNotNull("predicate");
		if (count > 0)
		{
			int end = start + count;
			int[] weights = array.GetWeight();
			for (int i = start; i < end; i++)
			{
				object value = array.GetValue(i, weights);
				if (predicate(value, i))
				{
					return value;
				}
			}
		}
		return defaultValue;
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的元素，返回匹配的第一个元素
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始查找的索引位置</param>
	/// <param name="predicate">元素筛选条件</param>
	/// <param name="defaultValue">如果找不到符合条件的元素返回的默认值</param>
	/// <returns>找到匹配的第一个元素，如果未找到则返回 <paramref name="defaultValue" /> 的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static object Find(this Array array, long start, Func<object, bool> predicate, object defaultValue = null)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.Find(start, array.LongLength - start, predicate, defaultValue);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的元素，返回匹配的第一个元素
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始查找的索引位置</param>
	/// <param name="predicate">元素筛选条件</param>
	/// <param name="defaultValue">如果找不到符合条件的元素返回的默认值</param>
	/// <returns>找到匹配的第一个元素，如果未找到则返回 <paramref name="defaultValue" /> 的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static object Find(this Array array, long start, Func<object, long, bool> predicate, object defaultValue = null)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.Find(start, array.LongLength - start, predicate, defaultValue);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的元素，返回匹配的第一个元素
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始查找的索引位置</param>
	/// <param name="count">查找的元素数量</param>
	/// <param name="predicate">元素筛选条件</param>
	/// <param name="defaultValue">如果找不到符合条件的元素返回的默认值</param>
	/// <returns>找到匹配的第一个元素，如果未找到则返回 <paramref name="defaultValue" /> 的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始剩余的元素数量。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static object Find(this Array array, long start, long count, Func<object, bool> predicate, object defaultValue = null)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		return array.Find(start, count, (object x, long i) => predicate(x), defaultValue);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的元素，返回匹配的第一个元素
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始查找的索引位置</param>
	/// <param name="count">查找的元素数量</param>
	/// <param name="predicate">元素筛选条件</param>
	/// <param name="defaultValue">如果找不到符合条件的元素返回的默认值</param>
	/// <returns>找到匹配的第一个元素，如果未找到则返回 <paramref name="defaultValue" /> 的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始剩余的元素数量。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static object Find(this Array array, long start, long count, Func<object, long, bool> predicate, object defaultValue = null)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		count.GuardBetween(0L, array.LongLength - start, "count");
		predicate.GuardNotNull("predicate");
		if (count > 0)
		{
			long end = start + count;
			long[] weight = array.GetLongWeight();
			for (long i = start; i < end; i++)
			{
				object value = array.GetValue(i, weight);
				if (predicate(value, i))
				{
					return value;
				}
			}
		}
		return defaultValue;
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的元素，返回找到的第一个元素
	/// </summary>
	/// <typeparam name="T">当前数组元素的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">元素筛选条件</param>
	/// <param name="defaultValue">如果找不到符合条件的元素返回的默认值</param>
	/// <returns>找到匹配的第一个元素，如果未找到则返回 <paramref name="defaultValue" /> 的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static T Find<T>(this T[] array, Func<T, bool> predicate, T defaultValue = default(T))
	{
		array.GuardNotNull("array");
		return array.Find(0, array.Length, predicate, defaultValue);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的元素，返回找到的第一个元素
	/// </summary>
	/// <typeparam name="T">当前数组元素的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">元素筛选条件</param>
	/// <param name="defaultValue">如果找不到符合条件的元素返回的默认值</param>
	/// <returns>找到匹配的第一个元素，如果未找到则返回 <paramref name="defaultValue" /> 的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static T Find<T>(this T[] array, Func<T, int, bool> predicate, T defaultValue = default(T))
	{
		array.GuardNotNull("array");
		return array.Find(0, array.Length, predicate, defaultValue);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的元素，返回找到的第一个元素
	/// </summary>
	/// <typeparam name="T">当前数组元素的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始查找的索引位置</param>
	/// <param name="predicate">元素筛选条件</param>
	/// <param name="defaultValue">如果找不到符合条件的元素返回的默认值</param>
	/// <returns>找到匹配的第一个元素，如果未找到则返回 <paramref name="defaultValue" /> 的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	public static T Find<T>(this T[] array, int start, Func<T, bool> predicate, T defaultValue = default(T))
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.Find(start, array.Length - start, predicate, defaultValue);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的元素，返回找到的第一个元素
	/// </summary>
	/// <typeparam name="T">当前数组元素的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始查找的索引位置</param>
	/// <param name="predicate">元素筛选条件</param>
	/// <param name="defaultValue">如果找不到符合条件的元素返回的默认值</param>
	/// <returns>找到匹配的第一个元素，如果未找到则返回 <paramref name="defaultValue" /> 的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	public static T Find<T>(this T[] array, int start, Func<T, int, bool> predicate, T defaultValue = default(T))
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.Find(start, array.Length - start, predicate, defaultValue);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的元素，返回找到的第一个元素
	/// </summary>
	/// <typeparam name="T">当前数组元素的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始查找的索引位置</param>
	/// <param name="count">查找的元素数量</param>
	/// <param name="predicate">元素筛选条件</param>
	/// <param name="defaultValue">如果找不到符合条件的元素返回的默认值</param>
	/// <returns>找到匹配的第一个元素，如果未找到则返回 <paramref name="defaultValue" /> 的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static T Find<T>(this T[] array, int start, int count, Func<T, bool> predicate, T defaultValue = default(T))
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		return array.Find(start, count, (T x, int i) => predicate(x), defaultValue);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的元素，返回找到的第一个元素
	/// </summary>
	/// <typeparam name="T">当前数组元素的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始查找的索引位置</param>
	/// <param name="count">查找的元素数量</param>
	/// <param name="predicate">元素筛选条件</param>
	/// <param name="defaultValue">如果找不到符合条件的元素返回的默认值</param>
	/// <returns>找到匹配的第一个元素，如果未找到则返回 <paramref name="defaultValue" /> 的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static T Find<T>(this T[] array, int start, int count, Func<T, int, bool> predicate, T defaultValue = default(T))
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		start.GuardIndexRange(0, array.Length - 1, "start");
		count.GuardBetween(0, array.Length - start, "count");
		int index = array.FindIndex(start, count, predicate);
		return (index >= 0) ? array[index] : defaultValue;
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的元素，返回找到的第一个元素
	/// </summary>
	/// <typeparam name="T">当前数组元素的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始查找的索引位置</param>
	/// <param name="predicate">元素筛选条件</param>
	/// <param name="defaultValue">如果找不到符合条件的元素返回的默认值</param>
	/// <returns>找到匹配的第一个元素，如果未找到则返回 <paramref name="defaultValue" /> 的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	public static T Find<T>(this T[] array, long start, Func<T, bool> predicate, T defaultValue = default(T))
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.Find(start, array.Length - start, predicate, defaultValue);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的元素，返回找到的第一个元素
	/// </summary>
	/// <typeparam name="T">当前数组元素的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始查找的索引位置</param>
	/// <param name="predicate">元素筛选条件</param>
	/// <param name="defaultValue">如果找不到符合条件的元素返回的默认值</param>
	/// <returns>找到匹配的第一个元素，如果未找到则返回 <paramref name="defaultValue" /> 的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	public static T Find<T>(this T[] array, long start, Func<T, long, bool> predicate, T defaultValue = default(T))
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.Find(start, array.LongLength - start, predicate, defaultValue);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的元素，返回找到的第一个元素
	/// </summary>
	/// <typeparam name="T">当前数组元素的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始查找的索引位置</param>
	/// <param name="count">查找的元素数量</param>
	/// <param name="predicate">元素筛选条件</param>
	/// <param name="defaultValue">如果找不到符合条件的元素返回的默认值</param>
	/// <returns>找到匹配的第一个元素，如果未找到则返回 <paramref name="defaultValue" /> 的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static T Find<T>(this T[] array, long start, long count, Func<T, bool> predicate, T defaultValue = default(T))
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		return array.Find(start, count, (T x, long i) => predicate(x), defaultValue);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的元素，返回找到的第一个元素
	/// </summary>
	/// <typeparam name="T">当前数组元素的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始查找的索引位置</param>
	/// <param name="count">查找的元素数量</param>
	/// <param name="predicate">元素筛选条件</param>
	/// <param name="defaultValue">如果找不到符合条件的元素返回的默认值</param>
	/// <returns>找到匹配的第一个元素，如果未找到则返回 <paramref name="defaultValue" /> 的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static T Find<T>(this T[] array, long start, long count, Func<T, long, bool> predicate, T defaultValue = default(T))
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		count.GuardBetween(0L, array.LongLength - start, "count");
		long index = array.FindIndex(start, count, predicate);
		return (index >= 0) ? array[index] : defaultValue;
	}

	/// <summary>
	/// 在当前数组中查找所有符合条件的元素
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">元素筛选条件</param>
	/// <returns>符合条件的元素数组；如果没有满足条件的元素则返回空数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static object[] FindAll(this Array array, Func<object, bool> predicate)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		return array.FindAll((object x, int i) => predicate(x));
	}

	/// <summary>
	/// 在当前数组中查找所有符合条件的元素
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">元素筛选条件</param>
	/// <returns>符合条件的元素数组；如果没有满足条件的元素则返回空数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static object[] FindAll(this Array array, Func<object, int, bool> predicate)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		List<object> list = new List<object>();
		int[] weights = array.GetWeight();
		for (int i = 0; i < array.Length; i++)
		{
			object value = array.GetValue(i, weights);
			if (predicate(value, i))
			{
				list.Add(value);
			}
		}
		return list.ToArray();
	}

	/// <summary>
	/// 在当前数组中查找所有符合条件的元素
	/// </summary>
	/// <typeparam name="T">当前数组元素的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">元素筛选条件</param>
	/// <returns>符合条件的元素数组；如果没有满足条件的元素则返回空数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static T[] FindAll<T>(this T[] array, Func<T, bool> predicate)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		return Array.FindAll(array, (T x) => predicate(x));
	}

	/// <summary>
	/// 在当前数组中查找所有符合条件的元素
	/// </summary>
	/// <typeparam name="T">当前数组元素的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">元素筛选条件</param>
	/// <returns>符合条件的元素数组；如果没有满足条件的元素则返回空数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static T[] FindAll<T>(this T[] array, Func<T, int, bool> predicate)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		int index = 0;
		return Array.FindAll(array, (T x) => predicate(x, index++));
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的第一个数组元素的位置
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static int FindIndex(this Array array, Func<object, bool> predicate)
	{
		array.GuardNotNull("array");
		return array.FindIndex(0, array.Length, predicate);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的第一个数组元素的位置
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static int FindIndex(this Array array, Func<object, int, bool> predicate)
	{
		array.GuardNotNull("array");
		return array.FindIndex(0, array.Length, predicate);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的第一个数组元素的位置；当前数组可以是一维或者多维数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static int FindIndex(this Array array, int start, Func<object, bool> predicate)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.FindIndex(start, array.Length - start, predicate);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的第一个数组元素的位置
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static int FindIndex(this Array array, int start, Func<object, int, bool> predicate)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.FindIndex(start, array.Length - start, predicate);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的第一个数组元素的位置
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="count">搜做的元素的个数</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其序号索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组中从索引位置 <paramref name="start" /> 处开始剩余元素的个数。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static int FindIndex(this Array array, int start, int count, Func<object, bool> predicate)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		return array.FindIndex(start, count, (object x, int i) => predicate(x));
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的第一个数组元素的位置
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="count">搜做的元素的个数</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其序号索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组中从索引位置 <paramref name="start" /> 处开始剩余元素的个数。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static int FindIndex(this Array array, int start, int count, Func<object, int, bool> predicate)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		start.GuardIndexRange(0, array.Length - 1, "start");
		count.GuardBetween(0, array.Length - start, "count");
		if (count > 0)
		{
			int end = start + count;
			int[] weights = array.GetWeight();
			for (int i = start; i < end; i++)
			{
				if (predicate(array.GetValue(i, weights), i))
				{
					return i;
				}
			}
		}
		return -1;
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的第一个数组元素的位置；当前数组可以是一维或者多维数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static long FindIndex(this Array array, long start, Func<object, bool> predicate)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.FindIndex(start, array.LongLength - start, predicate);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的第一个数组元素的位置
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static long FindIndex(this Array array, long start, Func<object, long, bool> predicate)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.FindIndex(start, array.LongLength - start, predicate);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的第一个数组元素的位置
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="count">搜做的元素的个数</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其序号索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组中从索引位置 <paramref name="start" /> 处开始剩余元素的个数。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static long FindIndex(this Array array, long start, long count, Func<object, bool> predicate)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		return array.FindIndex(start, count, (object x, long i) => predicate(x));
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的第一个数组元素的位置
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="count">搜做的元素的个数</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其序号索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组中从索引位置 <paramref name="start" /> 处开始剩余元素的个数。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static long FindIndex(this Array array, long start, long count, Func<object, long, bool> predicate)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		count.GuardBetween(0L, array.LongLength - start, "count");
		if (count > 0)
		{
			long end = start + count;
			long[] weight = array.GetLongWeight();
			for (long i = start; i < end; i++)
			{
				if (predicate(array.GetValue(i, weight), i))
				{
					return i;
				}
			}
		}
		return -1L;
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的第一个数组元素的位置
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static int FindIndex<T>(this T[] array, Func<T, bool> predicate)
	{
		array.GuardNotNull("array");
		return array.FindIndex(0, array.Length, predicate);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的第一个数组元素的位置
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static int FindIndex<T>(this T[] array, Func<T, int, bool> predicate)
	{
		array.GuardNotNull("array");
		return array.FindIndex(0, array.Length, predicate);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的第一个数组元素的位置
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	public static int FindIndex<T>(this T[] array, int start, Func<T, bool> predicate)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.FindIndex(start, array.Length - start, predicate);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的第一个数组元素的位置
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	public static int FindIndex<T>(this T[] array, int start, Func<T, int, bool> predicate)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.FindIndex(start, array.Length - start, predicate);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的第一个数组元素的位置
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="count">搜做的元素的个数</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组中从索引位置 <paramref name="start" /> 处开始剩余元素的个数。</exception>
	public static int FindIndex<T>(this T[] array, int start, int count, Func<T, bool> predicate)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		return Array.FindIndex(array, start, count, (T x) => predicate(x));
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的第一个数组元素的位置
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="count">搜做的元素的个数</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组中从索引位置 <paramref name="start" /> 处开始剩余元素的个数。</exception>
	public static int FindIndex<T>(this T[] array, int start, int count, Func<T, int, bool> predicate)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		start.GuardIndexRange(0, array.Length - 1, "array");
		count.GuardBetween(0, array.Length - start, "count");
		int index = start;
		return Array.FindIndex(array, start, count, (T x) => predicate(x, index++));
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的第一个数组元素的位置
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	public static long FindIndex<T>(this T[] array, long start, Func<T, bool> predicate)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.FindIndex(start, array.LongLength - start, predicate);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的第一个数组元素的位置
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	public static long FindIndex<T>(this T[] array, long start, Func<T, long, bool> predicate)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.FindIndex(start, array.LongLength - start, predicate);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的第一个数组元素的位置
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="count">搜做的元素的个数</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组中从索引位置 <paramref name="start" /> 处开始剩余元素的个数。</exception>
	public static long FindIndex<T>(this T[] array, long start, long count, Func<T, bool> predicate)
	{
		predicate.GuardNotNull("predicate");
		return array.FindIndex(start, count, (T x, long i) => predicate(x));
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的第一个数组元素的位置
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="count">搜做的元素的个数</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组中从索引位置 <paramref name="start" /> 处开始剩余元素的个数。</exception>
	public static long FindIndex<T>(this T[] array, long start, long count, Func<T, long, bool> predicate)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		start.GuardIndexRange(0L, array.LongLength - 1, "array");
		count.GuardBetween(0L, array.LongLength - start, "count");
		long end = start + count;
		for (long i = start; i < end; i++)
		{
			if (predicate(array[i], i))
			{
				return i;
			}
		}
		return -1L;
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的最后一个数组元素
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <param name="defaultValue">如果找不到符合条件的元素返回的默认值</param>
	/// <returns>找到匹配的元素，如果未找到则返回 <paramref name="defaultValue" /> 的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static object FindLast(this Array array, Func<object, bool> predicate, object defaultValue = null)
	{
		array.GuardNotNull("array");
		return array.FindLast(array.Length - 1, array.Length, predicate, defaultValue);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的最后一个数组元素
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <param name="defaultValue">如果找不到符合条件的元素返回的默认值</param>
	/// <returns>找到匹配的元素，如果未找到则返回 <paramref name="defaultValue" /> 的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static object FindLast(this Array array, Func<object, int, bool> predicate, object defaultValue = null)
	{
		array.GuardNotNull("array");
		return array.FindLast(array.Length - 1, array.Length, predicate, defaultValue);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的最后一个数组元素
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <param name="defaultValue">如果找不到符合条件的元素返回的默认值</param>
	/// <returns>找到匹配的元素，如果未找到则返回 <paramref name="defaultValue" /> 的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static object FindLast(this Array array, int start, Func<object, bool> predicate, object defaultValue = null)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.FindLast(start, start + 1, predicate, defaultValue);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的最后一个数组元素
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <param name="defaultValue">如果找不到符合条件的元素返回的默认值</param>
	/// <returns>找到匹配的元素，如果未找到则返回 <paramref name="defaultValue" /> 的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static object FindLast(this Array array, int start, Func<object, int, bool> predicate, object defaultValue = null)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.FindLast(start, start + 1, predicate, defaultValue);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的最后一个数组元素
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="count">搜做的元素的个数</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <param name="defaultValue">如果找不到符合条件的元素返回的默认值</param>
	/// <returns>找到匹配的元素，如果未找到则返回 <paramref name="defaultValue" /> 的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组中从起始位置到索引位置 <paramref name="start" /> 处的元素个数。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static object FindLast(this Array array, int start, int count, Func<object, bool> predicate, object defaultValue = null)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		return array.FindLast(start, count, (object x, int i) => predicate(x), defaultValue);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的最后一个数组元素
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="count">搜做的元素的个数</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <param name="defaultValue">如果找不到符合条件的元素返回的默认值</param>
	/// <returns>找到匹配的元素，如果未找到则返回 <paramref name="defaultValue" /> 的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组中从起始位置到索引位置 <paramref name="start" /> 处的元素个数。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static object FindLast(this Array array, int start, int count, Func<object, int, bool> predicate, object defaultValue = null)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		start.GuardIndexRange(0, array.Length - 1, "start");
		count.GuardBetween(0, start + 1, "count");
		if (count > 0)
		{
			int[] weights = array.GetWeight();
			int end = start - count;
			for (int i = start; i > end; i--)
			{
				object value = array.GetValue(i, weights);
				if (predicate(value, i))
				{
					return value;
				}
			}
		}
		return defaultValue;
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的最后一个数组元素
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <param name="defaultValue">如果找不到符合条件的元素返回的默认值</param>
	/// <returns>找到匹配的元素，如果未找到则返回 <paramref name="defaultValue" /> 的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static object FindLast(this Array array, long start, Func<object, bool> predicate, object defaultValue = null)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.FindLast(start, start + 1, predicate, defaultValue);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的最后一个数组元素
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <param name="defaultValue">如果找不到符合条件的元素返回的默认值</param>
	/// <returns>找到匹配的元素，如果未找到则返回 <paramref name="defaultValue" /> 的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static object FindLast(this Array array, long start, Func<object, long, bool> predicate, object defaultValue = null)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.FindLast(start, start + 1, predicate, defaultValue);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的最后一个数组元素
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="count">搜做的元素的个数</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <param name="defaultValue">如果找不到符合条件的元素返回的默认值</param>
	/// <returns>找到匹配的元素，如果未找到则返回 <paramref name="defaultValue" /> 的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组中从起始位置到索引位置 <paramref name="start" /> 处的元素个数。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static object FindLast(this Array array, long start, long count, Func<object, bool> predicate, object defaultValue = null)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		return array.FindLast(start, count, (object x, long i) => predicate(x), defaultValue);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的最后一个数组元素
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="count">搜做的元素的个数</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <param name="defaultValue">如果找不到符合条件的元素返回的默认值</param>
	/// <returns>找到匹配的元素，如果未找到则返回 <paramref name="defaultValue" /> 的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组中从起始位置到索引位置 <paramref name="start" /> 处的元素个数。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static object FindLast(this Array array, long start, long count, Func<object, long, bool> predicate, object defaultValue = null)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		count.GuardBetween(0L, start + 1, "count");
		if (count > 0)
		{
			long[] weight = array.GetLongWeight();
			long end = start - count;
			for (long i = start; i > end; i--)
			{
				object value = array.GetValue(i, weight);
				if (predicate(value, i))
				{
					return value;
				}
			}
		}
		return defaultValue;
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的最后一个数组元素
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <param name="defaultValue">如果找不到符合条件的元素返回的默认值</param>
	/// <returns>找到匹配的元素，如果未找到则返回 <paramref name="defaultValue" /> 的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static T FindLast<T>(this T[] array, Func<T, bool> predicate, T defaultValue = default(T))
	{
		array.GuardNotNull("array");
		return array.FindLast(array.Length - 1, array.Length, predicate, defaultValue);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的最后一个数组元素
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <param name="defaultValue">如果找不到符合条件的元素返回的默认值</param>
	/// <returns>找到匹配的元素，如果未找到则返回 <paramref name="defaultValue" /> 的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static T FindLast<T>(this T[] array, Func<T, int, bool> predicate, T defaultValue = default(T))
	{
		array.GuardNotNull("array");
		return array.FindLast(array.Length - 1, array.Length, predicate, defaultValue);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的最后一个数组元素
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <param name="defaultValue">如果找不到符合条件的元素返回的默认值</param>
	/// <returns>找到匹配的元素，如果未找到则返回 <paramref name="defaultValue" /> 的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	public static T FindLast<T>(this T[] array, int start, Func<T, bool> predicate, T defaultValue = default(T))
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.FindLast(start, start + 1, predicate, defaultValue);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的最后一个数组元素
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <param name="defaultValue">如果找不到符合条件的元素返回的默认值</param>
	/// <returns>找到匹配的元素，如果未找到则返回 <paramref name="defaultValue" /> 的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	public static T FindLast<T>(this T[] array, int start, Func<T, int, bool> predicate, T defaultValue = default(T))
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.FindLast(start, start + 1, predicate, defaultValue);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的最后一个数组元素
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="count">搜做的元素的个数</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <param name="defaultValue">如果找不到符合条件的元素返回的默认值</param>
	/// <returns>找到匹配的元素，如果未找到则返回 <paramref name="defaultValue" /> 的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组中从起始位置到索引位置 <paramref name="start" /> 处的元素个数。</exception>
	public static T FindLast<T>(this T[] array, int start, int count, Func<T, bool> predicate, T defaultValue = default(T))
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		return array.FindLast(start, count, (T x, int i) => predicate(x), defaultValue);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的最后一个数组元素
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="count">搜做的元素的个数</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <param name="defaultValue">如果找不到符合条件的元素返回的默认值</param>
	/// <returns>找到匹配的元素，如果未找到则返回 <paramref name="defaultValue" /> 的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组中从起始位置到索引位置 <paramref name="start" /> 处的元素个数。</exception>
	public static T FindLast<T>(this T[] array, int start, int count, Func<T, int, bool> predicate, T defaultValue = default(T))
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		start.GuardIndexRange(0, array.Length - 1, "start");
		count.GuardBetween(0, start + 1, "count");
		int index = array.FindLastIndex(start, count, predicate);
		return (index >= 0) ? array[index] : defaultValue;
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的最后一个数组元素
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <param name="defaultValue">如果找不到符合条件的元素返回的默认值</param>
	/// <returns>找到匹配的元素，如果未找到则返回 <paramref name="defaultValue" /> 的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	public static T FindLast<T>(this T[] array, long start, Func<T, bool> predicate, T defaultValue = default(T))
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.FindLast(start, start + 1, predicate, defaultValue);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的最后一个数组元素
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <param name="defaultValue">如果找不到符合条件的元素返回的默认值</param>
	/// <returns>找到匹配的元素，如果未找到则返回 <paramref name="defaultValue" /> 的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	public static T FindLast<T>(this T[] array, long start, Func<T, long, bool> predicate, T defaultValue = default(T))
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.FindLast(start, start + 1, predicate, defaultValue);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的最后一个数组元素
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="count">搜做的元素的个数</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <param name="defaultValue">如果找不到符合条件的元素返回的默认值</param>
	/// <returns>找到匹配的元素，如果未找到则返回 <paramref name="defaultValue" /> 的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组中从起始位置到索引位置 <paramref name="start" /> 处的元素个数。</exception>
	public static T FindLast<T>(this T[] array, long start, long count, Func<T, bool> predicate, T defaultValue = default(T))
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		return array.FindLast(start, count, (T x, long i) => predicate(x), defaultValue);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的最后一个数组元素
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="count">搜做的元素的个数</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <param name="defaultValue">如果找不到符合条件的元素返回的默认值</param>
	/// <returns>找到匹配的元素，如果未找到则返回 <paramref name="defaultValue" /> 的值。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组中从起始位置到索引位置 <paramref name="start" /> 处的元素个数。</exception>
	public static T FindLast<T>(this T[] array, long start, long count, Func<T, long, bool> predicate, T defaultValue = default(T))
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		count.GuardBetween(0L, start + 1, "count");
		long index = array.FindLastIndex(start, count, predicate);
		return (index >= 0) ? array[index] : defaultValue;
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的最后一个数组元素的位置
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其索引，否则返回null</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <remarks>当前数组可以是一维或者多维数组。本方法从当前数组的结束位置开始，逆向搜索到数组的起始位置。</remarks>
	public static int FindLastIndex(this Array array, Func<object, bool> predicate)
	{
		array.GuardNotNull("array");
		return array.FindLastIndex(array.Length - 1, array.Length, predicate);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的最后一个数组元素的位置
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <remarks>当前数组可以是一维或者多维数组。本方法从当前数组的结束位置开始，逆向搜索到数组的起始位置。</remarks>
	public static int FindLastIndex(this Array array, Func<object, int, bool> predicate)
	{
		array.GuardNotNull("array");
		return array.FindLastIndex(array.Length - 1, array.Length, predicate);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的最后一个数组元素的位置
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <remarks>当前数组可以是一维或者多维数组。本方法从 <paramref name="start" /> 指定的位置开始，逆向搜索到数组的起始位置元素。</remarks>
	public static int FindLastIndex(this Array array, int start, Func<object, bool> predicate)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.FindLastIndex(start, start + 1, predicate);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的最后一个数组元素的位置
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <remarks>当前数组可以是一维或者多维数组。本方法从 <paramref name="start" /> 指定的位置开始，逆向搜索到数组的起始位置元素。</remarks>
	public static int FindLastIndex(this Array array, int start, Func<object, int, bool> predicate)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.FindLastIndex(start, start + 1, predicate);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的最后一个数组元素的位置
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="count">逆向查找的元素数量</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于到索引位置 <paramref name="start" /> 为止的元素个数。</exception>
	/// <remarks>当前数组可以是一维或者多维数组。本方法从 <paramref name="start" /> 指定的位置开始，逆向搜索 <paramref name="count" /> 指定数量的元素。</remarks>
	public static int FindLastIndex(this Array array, int start, int count, Func<object, bool> predicate)
	{
		array.GuardNotNull("array");
		return array.FindLastIndex(start, count, (object x, int i) => predicate(x));
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的最后一个数组元素的位置
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="count">逆向查找查找的元素数量</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其序号索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于到索引位置 <paramref name="start" /> 为止的元素个数。</exception>
	/// <remarks>当前数组可以是一维或者多维数组。本方法从 <paramref name="start" /> 指定的位置开始，逆向搜索 <paramref name="count" /> 指定数量的元素。</remarks>
	public static int FindLastIndex(this Array array, int start, int count, Func<object, int, bool> predicate)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		start.GuardIndexRange(0, array.Length - 1, "start");
		count.GuardBetween(0, start + 1, "count");
		if (count > 0)
		{
			int[] weights = array.GetWeight();
			int end = start - count;
			for (int i = start; i > end; i--)
			{
				if (predicate(array.GetValue(i, weights), i))
				{
					return i;
				}
			}
		}
		return -1;
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的最后一个数组元素的位置
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <remarks>当前数组可以是一维或者多维数组。本方法从 <paramref name="start" /> 指定的位置开始，逆向搜索到数组的起始位置元素。</remarks>
	public static long FindLastIndex(this Array array, long start, Func<object, bool> predicate)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.FindLastIndex(start, start + 1, predicate);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的最后一个数组元素的位置
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <remarks>当前数组可以是一维或者多维数组。本方法从 <paramref name="start" /> 指定的位置开始，逆向搜索到数组的起始位置元素。</remarks>
	public static long FindLastIndex(this Array array, long start, Func<object, long, bool> predicate)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.FindLastIndex(start, start + 1, predicate);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的最后一个数组元素的位置
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="count">逆向查找的元素数量</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于到索引位置 <paramref name="start" /> 为止的元素个数。</exception>
	/// <remarks>当前数组可以是一维或者多维数组。本方法从 <paramref name="start" /> 指定的位置开始，逆向搜索 <paramref name="count" /> 指定数量的元素。</remarks>
	public static long FindLastIndex(this Array array, long start, long count, Func<object, bool> predicate)
	{
		array.GuardNotNull("array");
		return array.FindLastIndex(start, count, (object x, long i) => predicate(x));
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的最后一个数组元素的位置
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="count">逆向查找查找的元素数量</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其序号索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于到索引位置 <paramref name="start" /> 为止的元素个数。</exception>
	/// <remarks>当前数组可以是一维或者多维数组。本方法从 <paramref name="start" /> 指定的位置开始，逆向搜索 <paramref name="count" /> 指定数量的元素。</remarks>
	public static long FindLastIndex(this Array array, long start, long count, Func<object, long, bool> predicate)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		count.GuardBetween(0L, start + 1, "count");
		if (count > 0)
		{
			long[] weight = array.GetLongWeight();
			long end = start - count;
			for (long i = start; i > end; i--)
			{
				if (predicate(array.GetValue(i, weight), i))
				{
					return i;
				}
			}
		}
		return -1L;
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的最后一个数组元素的位置
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <remarks>本方法从当前数组的结束位置开始，逆向搜索到数组的起始位置。</remarks>
	public static int FindLastIndex<T>(this T[] array, Func<T, bool> predicate)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		return Array.FindLastIndex(array, (T x) => predicate(x));
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的最后一个数组元素的位置
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <remarks>本方法从当前数组的结束位置开始，逆向搜索到数组的起始位置。</remarks>
	public static int FindLastIndex<T>(this T[] array, Func<T, int, bool> predicate)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		int index = array.Length - 1;
		return Array.FindLastIndex(array, (T x) => predicate(x, index--));
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的最后一个数组元素的位置
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <remarks>本方法从 <paramref name="start" /> 指定的位置开始，逆向搜索到数组的起始位置元素。</remarks>
	public static int FindLastIndex<T>(this T[] array, int start, Func<T, bool> predicate)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.FindLastIndex(start, start + 1, predicate);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的最后一个数组元素的位置
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <remarks>本方法从 <paramref name="start" /> 指定的位置开始，逆向搜索到数组的起始位置元素。</remarks>
	public static int FindLastIndex<T>(this T[] array, int start, Func<T, int, bool> predicate)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.FindLastIndex(start, start + 1, predicate);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的最后一个数组元素的位置
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="count">逆向查找的元素数量</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于到索引位置 <paramref name="start" /> 为止的元素个数。</exception>
	/// <remarks>本方法从 <paramref name="start" /> 指定的位置开始，逆向搜索 <paramref name="count" /> 指定数量的元素。</remarks>
	public static int FindLastIndex<T>(this T[] array, int start, int count, Func<T, bool> predicate)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		start.GuardIndexRange(0, array.Length - 1, "start");
		count.GuardBetween(0, start + 1, "count");
		return Array.FindLastIndex(array, start, count, (T x) => predicate(x));
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的最后一个数组元素的位置
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="count">逆向查找的元素数量</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于到索引位置 <paramref name="start" /> 为止的元素个数。</exception>
	/// <remarks>本方法从 <paramref name="start" /> 指定的位置开始，逆向搜索 <paramref name="count" /> 指定数量的元素。</remarks>
	public static int FindLastIndex<T>(this T[] array, int start, int count, Func<T, int, bool> predicate)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		start.GuardIndexRange(0, array.Length - 1, "start");
		count.GuardBetween(0, start + 1, "count");
		int index = start;
		return Array.FindLastIndex(array, start, count, (T x) => predicate(x, index--));
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的最后一个数组元素的位置
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <remarks>本方法从 <paramref name="start" /> 指定的位置开始，逆向搜索到数组的起始位置元素。</remarks>
	public static long FindLastIndex<T>(this T[] array, long start, Func<T, bool> predicate)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.FindLastIndex(start, start + 1, predicate);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的最后一个数组元素的位置
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <remarks>本方法从 <paramref name="start" /> 指定的位置开始，逆向搜索到数组的起始位置元素。</remarks>
	public static long FindLastIndex<T>(this T[] array, long start, Func<T, long, bool> predicate)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.FindLastIndex(start, start + 1, predicate);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的最后一个数组元素的位置
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="count">逆向查找的元素数量</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于到索引位置 <paramref name="start" /> 为止的元素个数。</exception>
	/// <remarks>本方法从 <paramref name="start" /> 指定的位置开始，逆向搜索 <paramref name="count" /> 指定数量的元素。</remarks>
	public static long FindLastIndex<T>(this T[] array, long start, long count, Func<T, bool> predicate)
	{
		predicate.GuardNotNull("predicate");
		return array.FindLastIndex(start, count, (T x, long i) => predicate(x));
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的最后一个数组元素的位置
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">在当前数组中开始查找的位置</param>
	/// <param name="count">逆向查找的元素数量</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于到索引位置 <paramref name="start" /> 为止的元素个数。</exception>
	/// <remarks>本方法从 <paramref name="start" /> 指定的位置开始，逆向搜索 <paramref name="count" /> 指定数量的元素。</remarks>
	public static long FindLastIndex<T>(this T[] array, long start, long count, Func<T, long, bool> predicate)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		count.GuardBetween(0L, start + 1, "count");
		if (count > 0)
		{
			long end = start - count;
			for (long i = start; i > end; i--)
			{
				if (predicate(array[i], i))
				{
					return i;
				}
			}
		}
		return -1L;
	}

	/// <summary>
	/// 获取当前数组的元素类型
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <returns>当前数组的元素类型</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static Type GetElementType(this Array array)
	{
		array.GuardNotNull("array");
		return array.GetType().GetElementType();
	}

	/// <summary>
	/// 获取当前数组的最后一个元素的索引
	/// </summary>
	/// <param name="array">当前的数组</param>
	/// <returns>最后一个元素的索引，如果数组不包含任何元素，则返回null</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static int[] GetLastIndex(this Array array)
	{
		array.GuardNotNull("array");
		return (array.Length == 0) ? null : array.GetWeight().Fill((int x, int i) => x - 1);
	}

	/// <summary>
	/// 获取当前数组的最后一个元素的索引
	/// </summary>
	/// <param name="array">当前的数组</param>
	/// <returns>最后一个元素的索引，如果数组不包含任何元素，则返回null</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static long[] GetLastLongIndex(this Array array)
	{
		array.GuardNotNull("array");
		return (array.LongLength == 0) ? null : array.GetLongWeight().Fill((long x, int i) => x - 1);
	}

	/// <summary>
	/// 获取当前数组各个秩（维数）的元素数量
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <returns>当前数组各个秩（维数）的元素数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static long[] GetLongWeight(this Array array)
	{
		array.GuardNotNull("array");
		return new long[array.Rank].Fill((int i) => array.GetLongLength(i));
	}

	/// <summary>
	/// 获取当前数组中符合条件的元素组成的子数组
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>当前数组中符合条件的元素组成的子数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static T[] GetRange<T>(this T[] array, Func<T, bool> predicate)
	{
		return array.GetRange(predicate, (T x) => x);
	}

	/// <summary>
	/// 获取当前数组中符合条件的元素组成的子数组
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>当前数组中符合条件的元素组成的子数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static T[] GetRange<T>(this T[] array, Func<T, int, bool> predicate)
	{
		return array.GetRange(predicate, (T x, int i) => x);
	}

	/// <summary>
	/// 获取当前数组中符合条件的元素组成的子数组
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">子数组类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <param name="evaluation">数组元素处理方法</param>
	/// <returns>当前数组中符合条件的元素处理后的子数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	public static T[] GetRange<S, T>(this S[] array, Func<S, bool> predicate, Func<S, T> evaluation)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		evaluation.GuardNotNull("evaluation");
		return array.GetRange((S x, int i) => predicate(x), (S x, int i) => evaluation(x));
	}

	/// <summary>
	/// 获取当前数组中符合条件的元素组成的子数组
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">子数组类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <param name="evaluation">数组元素处理方法</param>
	/// <returns>当前数组中符合条件的元素处理后的子数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	public static T[] GetRange<S, T>(this S[] array, Func<S, int, bool> predicate, Func<S, int, T> evaluation)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		evaluation.GuardNotNull("evaluation");
		List<T> result = new List<T>(array.Length / 2);
		for (int i = 0; i < array.Length; i++)
		{
			if (predicate(array[i], i))
			{
				result.Add(evaluation(array[i], i));
			}
		}
		return result.ToArray();
	}

	/// <summary>
	/// 获取当前数组指定范围内的元素组成的子数组
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">获取子数组的起始位置索引</param>
	/// <returns>当前数组指定范围内的元素组成的子数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素索引范围内。</exception>
	public static T[] GetRange<T>(this T[] array, int start)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.GetRange(start, array.Length - start);
	}

	/// <summary>
	/// 获取当前数组指定范围内的元素组成的子数组
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">获取子数组的起始位置索引</param>
	/// <param name="count">获取的子数组的元素个数</param>
	/// <returns>当前数组指定范围内的元素组成的子数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素索引范围内。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始到当前数组结束的元素个数。</exception>
	public static T[] GetRange<T>(this T[] array, int start, int count)
	{
		return array.GetRange(start, count, (T x) => x);
	}

	/// <summary>
	/// 获取当前数组指定范围内的元素组成的子数组
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">子数组类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">获取子数组的起始位置索引</param>
	/// <param name="count">获取的子数组的元素个数</param>
	/// <param name="evaluation">数组元素处理方法</param>
	/// <returns>当前数组指定范围内的元素组成的子数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；<paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素索引范围内。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始到当前数组结束的元素个数。</exception>
	public static T[] GetRange<S, T>(this S[] array, int start, int count, Func<S, T> evaluation)
	{
		array.GuardNotNull("array");
		evaluation.GuardNotNull("evaluation");
		return array.GetRange(start, count, (S x, int i) => evaluation(x));
	}

	/// <summary>
	/// 获取当前数组指定范围内的元素组成的子数组
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">子数组类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">获取子数组的起始位置索引</param>
	/// <param name="count">获取的子数组的元素个数</param>
	/// <param name="evaluation">数组元素处理方法</param>
	/// <returns>当前数组指定范围内的元素组成的子数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；<paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素索引范围内。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始到当前数组结束的元素个数。</exception>
	public static T[] GetRange<S, T>(this S[] array, int start, int count, Func<S, int, T> evaluation)
	{
		array.GuardNotNull("array");
		evaluation.GuardNotNull("evaluation");
		start.GuardIndexRange(0, array.Length - 1, "start");
		count.GuardBetween(0, array.Length - start, "count");
		T[] result = new T[count];
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			result[i - start] = evaluation(array[i], i);
		}
		return result;
	}

	/// <summary>
	/// 获取当前数组指定范围内满足指定条件的元素组成的子数组
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">获取子数组的起始位置索引</param>
	/// <param name="count">获取的子数组的范围的元素个数</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>获取当前数组指定范围内满足指定条件的元素组成的子数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素索引范围内。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始到当前数组结束的元素个数。</exception>
	public static T[] GetRange<T>(this T[] array, int start, int count, Func<T, bool> predicate)
	{
		return array.GetRange(start, count, predicate, (T x) => x);
	}

	/// <summary>
	/// 获取当前数组指定范围内满足指定条件的元素组成的子数组
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">获取子数组的起始位置索引</param>
	/// <param name="count">获取的子数组的范围的元素个数</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>获取当前数组指定范围内满足指定条件的元素组成的子数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素索引范围内。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始到当前数组结束的元素个数。</exception>
	public static T[] GetRange<T>(this T[] array, int start, int count, Func<T, int, bool> predicate)
	{
		return array.GetRange(start, count, predicate, (T x, int i) => x);
	}

	/// <summary>
	/// 获取当前数组指定范围内满足指定条件的元素组成的子数组
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">子数组类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">获取子数组的起始位置索引</param>
	/// <param name="count">获取的子数组的范围的元素个数</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <param name="evaluation">数组元素处理方法</param>
	/// <returns>获取当前数组指定范围内满足指定条件的元素组成的子数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素索引范围内。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始到当前数组结束的元素个数。</exception>
	public static T[] GetRange<S, T>(this S[] array, int start, int count, Func<S, bool> predicate, Func<S, T> evaluation)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		evaluation.GuardNotNull("evaluation");
		return array.GetRange(start, count, (S x, int i) => predicate(x), (S x, int i) => evaluation(x));
	}

	/// <summary>
	/// 获取当前数组指定范围内满足指定条件的元素组成的子数组
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">子数组类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">获取子数组的起始位置索引</param>
	/// <param name="count">获取的子数组的范围的元素个数</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <param name="evaluation">数组元素处理方法</param>
	/// <returns>获取当前数组指定范围内满足指定条件的元素组成的子数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素索引范围内。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始到当前数组结束的元素个数。</exception>
	public static T[] GetRange<S, T>(this S[] array, int start, int count, Func<S, int, bool> predicate, Func<S, int, T> evaluation)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		evaluation.GuardNotNull("evaluation");
		start.GuardIndexRange(0, array.Length - 1, "start");
		count.GuardBetween(0, array.Length - start, "count");
		if (count > 0)
		{
			List<T> result = new List<T>(count);
			int end = start + count;
			for (int i = start; i < end; i++)
			{
				if (predicate(array[i], i))
				{
					result.Add(evaluation(array[i], i));
				}
			}
			return result.ToArray();
		}
		return new T[0];
	}

	/// <summary>
	/// 获取当前数组指定范围内的元素组成的子数组
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">获取子数组的起始位置索引</param>
	/// <returns>当前数组指定范围内的元素组成的子数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素索引范围内。</exception>
	public static T[] GetLongRange<T>(this T[] array, long start)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.GetLongRange(start, array.LongLength - start);
	}

	/// <summary>
	/// 获取当前数组指定范围内的元素组成的子数组
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">获取子数组的起始位置索引</param>
	/// <param name="count">获取的子数组的元素个数</param>
	/// <returns>当前数组指定范围内的元素组成的子数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素索引范围内。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始到当前数组结束的元素个数。</exception>
	public static T[] GetLongRange<T>(this T[] array, long start, long count)
	{
		return array.GetLongRange(start, count, (T x) => x);
	}

	/// <summary>
	/// 获取当前数组指定范围内的元素组成的子数组
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">子数组类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">获取子数组的起始位置索引</param>
	/// <param name="count">获取的子数组的元素个数</param>
	/// <param name="evaluation">数组元素处理方法</param>
	/// <returns>当前数组指定范围内的元素组成的子数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；<paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素索引范围内。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始到当前数组结束的元素个数。</exception>
	public static T[] GetLongRange<S, T>(this S[] array, long start, long count, Func<S, T> evaluation)
	{
		array.GuardNotNull("array");
		evaluation.GuardNotNull("evaluation");
		return array.GetLongRange(start, count, (S x, long i) => evaluation(x));
	}

	/// <summary>
	/// 获取当前数组指定范围内的元素组成的子数组
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">子数组类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">获取子数组的起始位置索引</param>
	/// <param name="count">获取的子数组的元素个数</param>
	/// <param name="evaluation">数组元素处理方法</param>
	/// <returns>当前数组指定范围内的元素组成的子数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；<paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素索引范围内。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始到当前数组结束的元素个数。</exception>
	public static T[] GetLongRange<S, T>(this S[] array, long start, long count, Func<S, long, T> evaluation)
	{
		array.GuardNotNull("array");
		evaluation.GuardNotNull("evaluation");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		count.GuardBetween(0L, array.LongLength - start, "count");
		T[] result = new T[count];
		long end = start + count;
		for (long i = start; i < end; i++)
		{
			result[i - start] = evaluation(array[i], i);
		}
		return result;
	}

	/// <summary>
	/// 获取当前数组指定范围内满足指定条件的元素组成的子数组
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">获取子数组的起始位置索引</param>
	/// <param name="count">获取的子数组的范围的元素个数</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>获取当前数组指定范围内满足指定条件的元素组成的子数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素索引范围内。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始到当前数组结束的元素个数。</exception>
	public static T[] GetLongRange<T>(this T[] array, long start, long count, Func<T, bool> predicate)
	{
		return array.GetLongRange(start, count, predicate, (T x) => x);
	}

	/// <summary>
	/// 获取当前数组指定范围内满足指定条件的元素组成的子数组
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">获取子数组的起始位置索引</param>
	/// <param name="count">获取的子数组的范围的元素个数</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>获取当前数组指定范围内满足指定条件的元素组成的子数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素索引范围内。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始到当前数组结束的元素个数。</exception>
	public static T[] GetLongRange<T>(this T[] array, long start, long count, Func<T, long, bool> predicate)
	{
		return array.GetLongRange(start, count, predicate, (T x, long i) => x);
	}

	/// <summary>
	/// 获取当前数组指定范围内满足指定条件的元素组成的子数组
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">子数组类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">获取子数组的起始位置索引</param>
	/// <param name="count">获取的子数组的范围的元素个数</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <param name="evaluation">数组元素处理方法</param>
	/// <returns>获取当前数组指定范围内满足指定条件的元素组成的子数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素索引范围内。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始到当前数组结束的元素个数。</exception>
	public static T[] GetLongRange<S, T>(this S[] array, long start, long count, Func<S, bool> predicate, Func<S, T> evaluation)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		count.GuardBetween(0L, array.LongLength - start, "count");
		predicate.GuardNotNull("predicate");
		evaluation.GuardNotNull("evaluation");
		return array.SkipLong(start).TakeLong(count).Where(predicate)
			.Select(evaluation)
			.ToArray();
	}

	/// <summary>
	/// 获取当前数组指定范围内满足指定条件的元素组成的子数组
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">子数组类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">获取子数组的起始位置索引</param>
	/// <param name="count">获取的子数组的范围的元素个数</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <param name="evaluation">数组元素处理方法</param>
	/// <returns>获取当前数组指定范围内满足指定条件的元素组成的子数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组元素索引范围内。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始到当前数组结束的元素个数。</exception>
	public static T[] GetLongRange<S, T>(this S[] array, long start, long count, Func<S, long, bool> predicate, Func<S, long, T> evaluation)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		count.GuardBetween(0L, array.LongLength - start, "count");
		predicate.GuardNotNull("predicate");
		evaluation.GuardNotNull("evaluation");
		return array.SkipLong(start).TakeLong(count).Where(predicate)
			.Select(evaluation)
			.ToArray();
	}

	/// <summary>
	/// 获取当前数组中每个元素的类型
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <returns>与当前数组结构相同的由数组元素类型组成的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <remarks>如果数组元素为空，则其类型也为空。</remarks>
	public static Array GetTypeArray(this Array array)
	{
		array.GuardNotNull("array");
		long[] weight = array.GetLongWeight();
		long[] dimension = new long[weight.LongLength];
		Array types = Array.CreateInstance(typeof(Type), weight);
		do
		{
			object value = array.GetValue(dimension);
			if (value.IsNull())
			{
				types.SetValue(null, dimension);
			}
			else
			{
				types.SetValue(value.GetType(), dimension);
			}
		}
		while (dimension.PermuteIncrease(weight));
		return types;
	}

	/// <summary>
	/// 获取当前数组中每个元素的类型
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="items">数组集合</param>
	/// <returns>数组元素类型的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <remarks>如果数组元素为空，则其类型也为空。</remarks>
	public static Type[] GetTypeArray<T>(this T[] items)
	{
		items.GuardNotNull("items");
		Type[] types = new Type[items.LongLength];
		for (long i = 0L; i < items.LongLength; i++)
		{
			types[i] = (items[i].IsNull() ? null : items[i].GetType());
		}
		return types;
	}

	/// <summary>
	/// 获取当前数组中指定位置的值
	/// </summary>
	/// <typeparam name="T">获取的值的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="indices">元素索引位置</param>
	/// <returns>当前数组中指定位置的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="indices" /> 的元素数量不等于当前数组的维度。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="indices" /> 超出了当前数组索引的有效范围。</exception>
	public static T GetValue<T>(this Array array, int[] indices)
	{
		array.GuardNotNull("array");
		indices.GuardArrayLength(array.Rank, "indices");
		return (T)array.GetValue(indices);
	}

	/// <summary>
	/// 获取当前数组中指定位置的值
	/// </summary>
	/// <typeparam name="T">获取的值的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="indices">元素索引位置</param>
	/// <returns>当前数组中指定位置的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="indices" /> 的元素数量不等于当前数组的维度。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="indices" /> 超出了当前数组索引的有效范围。</exception>
	public static T GetValue<T>(this Array array, long[] indices)
	{
		array.GuardNotNull("array");
		indices.GuardArrayLength(array.Rank, "indices");
		return (T)array.GetValue(indices);
	}

	/// <summary>
	/// 获取当前数组中指定位置的值
	/// </summary>
	/// <typeparam name="T">获取的值的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="index">元素索引位置</param>
	/// <returns>当前数组中指定位置的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="index" /> 超出了当前数组索引的有效范围。</exception>
	/// <remarks>本方法支持获取任意维度的数组的元素值。对于多维数组，参数 <paramref name="index" /> 将表示数组各维度头尾相连后的索引位置。</remarks>
	public static T GetValue<T>(this Array array, int index)
	{
		array.GuardNotNull("array");
		index.GuardIndexRange(0, array.Length - 1, "index");
		if (array.Rank == 1)
		{
			return (T)array.GetValue(index);
		}
		return array.GetValue<T>(index, null);
	}

	/// <summary>
	/// 获取当前数组中指定位置的值
	/// </summary>
	/// <typeparam name="T">获取的值的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="index">元素索引位置</param>
	/// <returns>当前数组中指定位置的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="index" /> 超出了当前数组索引的有效范围。</exception>
	/// <remarks>本方法支持获取任意维度的数组的元素值。对于多维数组，参数 <paramref name="index" /> 将表示数组各维度头尾相连后的索引位置。</remarks>
	public static T GetValue<T>(this Array array, long index)
	{
		array.GuardNotNull("array");
		index.GuardIndexRange(0L, array.LongLength - 1, "index");
		if (array.Rank == 1)
		{
			return (T)array.GetValue(index);
		}
		return array.GetValue<T>(index, null);
	}

	/// <summary>
	/// 获取当前数组中指定位置的值
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="index">元素索引位置，如果当前数组为多维数组，则元素位置表示数组各维度头尾相连后的索引位置</param>
	/// <param name="weight">当前数组各个秩（维数）的元素个数；如果设置为nul，则使用当前数组的各个秩（维数）的元素个数。</param>
	/// <returns>当前数组中指定位置的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="index" /> 超出了当前数组索引的有效范围。</exception>
	/// <remarks>本方法支持获取任意维度的数组的元素值。对于多维数组，参数 <paramref name="index" /> 将表示数组各维度头尾相连后的索引位置。</remarks>
	public static object GetValue(this Array array, int index, int[] weight)
	{
		array.GuardNotNull("array");
		index.GuardIndexRange(0, array.Length - 1, "index");
		return array.GetValue(index.RadixParse(weight.IfNull(array.GetWeight())));
	}

	/// <summary>
	/// 获取当前数组中指定位置的值
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="index">元素索引位置，如果当前数组为多维数组，则元素位置表示数组各维度头尾相连后的索引位置</param>
	/// <param name="weight">当前数组各个秩（维数）的元素个数；如果设置为nul，则使用当前数组的各个秩（维数）的元素个数。</param>
	/// <returns>当前数组中指定位置的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="index" /> 超出了当前数组索引的有效范围。</exception>
	/// <remarks>本方法支持获取任意维度的数组的元素值。对于多维数组，参数 <paramref name="index" /> 将表示数组各维度头尾相连后的索引位置。</remarks>
	public static object GetValue(this Array array, long index, long[] weight)
	{
		array.GuardNotNull("array");
		index.GuardIndexRange(0L, array.LongLength - 1, "index");
		return array.GetValue(index.RadixParse(weight.IfNull(array.GetLongWeight()), 1L));
	}

	/// <summary>
	/// 获取当前数组中指定位置的值
	/// </summary>
	/// <typeparam name="T">获取的值的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="index">元素索引位置，如果当前数组为多维数组，则元素位置表示数组各维度头尾相连后的索引位置</param>
	/// <param name="weight">当前数组各个秩（维数）的元素个数；如果设置为nul，则使用当前数组的各个秩（维数）的元素个数。</param>
	/// <returns>当前数组中指定位置的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="index" /> 超出了当前数组索引的有效范围。</exception>
	/// <remarks>本方法支持获取任意维度的数组的元素值。对于多维数组，参数 <paramref name="index" /> 将表示数组各维度头尾相连后的索引位置。</remarks>
	public static T GetValue<T>(this Array array, int index, int[] weight)
	{
		return (T)array.GetValue(index, weight);
	}

	/// <summary>
	/// 获取当前数组中指定位置的值
	/// </summary>
	/// <typeparam name="T">获取的值的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="index">元素索引位置，如果当前数组为多维数组，则元素位置表示数组各维度头尾相连后的索引位置</param>
	/// <param name="weight">当前数组各个秩（维数）的元素个数；如果设置为nul，则使用当前数组的各个秩（维数）的元素个数。</param>
	/// <returns>当前数组中指定位置的值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="index" /> 超出了当前数组索引的有效范围。</exception>
	/// <remarks>本方法支持获取任意维度的数组的元素值。对于多维数组，参数 <paramref name="index" /> 将表示数组各维度头尾相连后的索引位置。</remarks>
	public static T GetValue<T>(this Array array, long index, long[] weight)
	{
		return (T)array.GetValue(index, weight);
	}

	/// <summary>
	/// 获取当前数组各个秩（维数）的元素数量
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <returns>当前数组各个秩（维数）的元素数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static int[] GetWeight(this Array array)
	{
		array.GuardNotNull("array");
		return new int[array.Rank].Fill((int i) => array.GetLength(i));
	}

	/// <summary>
	/// 检测当前数组的元素个数，如果数组的元素个数不等于 <paramref name="length" />，则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="length">数组需要满足的指定长度</param>
	/// <param name="name">数组对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.ArgumentException">如果当前数组元素个数不等于 <paramref name="length" />，则抛出该异常。</exception>
	public static Array GuardArrayLength(this Array array, int length, string name = null, string message = null)
	{
		array.GuardNotNull("array");
		length.GuardGreaterThanOrEqualTo(0, "length");
		array.Guard(array.Length == length, () => new ArgumentException(message.IfNull(Literals.MSG_ArrayLengthError), name.IfNull("array")));
		return array;
	}

	/// <summary>
	/// 检测当前数组的元素个数，如果数组的元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="length">数组需要满足的指定长度</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前数组元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static Array GuardArrayLength(this Array array, int length, Func<Exception> exceptionCreator)
	{
		array.GuardNotNull("array");
		length.GuardGreaterThanOrEqualTo(0, "length");
		array.Guard(array.Length == length, exceptionCreator);
		return array;
	}

	/// <summary>
	/// 检测当前数组的元素个数，如果数组的元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="length">数组需要满足的指定长度</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前数组元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static Array GuardArrayLength(this Array array, int length, Type exceptionType, params object[] args)
	{
		array.GuardNotNull("array");
		length.GuardGreaterThanOrEqualTo(0, "length");
		array.Guard(array.Length == length, exceptionType, args);
		return array;
	}

	/// <summary>
	/// 检测当前数组的元素个数，如果数组的元素个数不等于 <paramref name="length" />，则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="length">数组需要满足的指定长度</param>
	/// <param name="name">数组对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.ArgumentException">如果当前数组元素个数不等于 <paramref name="length" />，则抛出该异常。</exception>
	public static Array GuardArrayLength(this Array array, long length, string name = null, string message = null)
	{
		array.GuardNotNull("array");
		length.GuardGreaterThanOrEqualTo(0L, "length");
		array.Guard(array.LongLength == length, () => new ArgumentException(message.IfNull(Literals.MSG_ArrayLengthError), name.IfNull("array")));
		return array;
	}

	/// <summary>
	/// 检测当前数组的元素个数，如果数组的元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="length">数组需要满足的指定长度</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前数组元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static Array GuardArrayLength(this Array array, long length, Func<Exception> exceptionCreator)
	{
		array.GuardNotNull("array");
		length.GuardGreaterThanOrEqualTo(0L, "length");
		array.Guard(array.LongLength == length, exceptionCreator);
		return array;
	}

	/// <summary>
	/// 检测当前数组的元素个数，如果数组的元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="length">数组需要满足的指定长度</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前数组元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static Array GuardArrayLength(this Array array, long length, Type exceptionType, params object[] args)
	{
		array.GuardNotNull("array");
		length.GuardGreaterThanOrEqualTo(0L, "length");
		array.Guard(array.LongLength == length, exceptionType, args);
		return array;
	}

	/// <summary>
	/// 检测当前数组的元素个数，如果数组的元素个数不等于 <paramref name="length" />，则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="length">数组需要满足的指定长度</param>
	/// <param name="name">数组对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.ArgumentException">如果当前数组元素个数不等于 <paramref name="length" />，则抛出该异常。</exception>
	public static T[] GuardArrayLength<T>(this T[] array, int length, string name = null, string message = null)
	{
		array.GuardNotNull("array");
		length.GuardGreaterThanOrEqualTo(0, "length");
		array.Guard(array.Length == length, () => new ArgumentException(message.IfNull(Literals.MSG_ArrayLengthError), name.IfNull("array")));
		return array;
	}

	/// <summary>
	/// 检测当前数组的元素个数，如果数组的元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="length">数组需要满足的指定长度</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前数组元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T[] GuardArrayLength<T>(this T[] array, int length, Func<Exception> exceptionCreator)
	{
		array.GuardNotNull("array");
		length.GuardGreaterThanOrEqualTo(0, "length");
		array.Guard(array.Length == length, exceptionCreator);
		return array;
	}

	/// <summary>
	/// 检测当前数组的元素个数，如果数组的元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="length">数组需要满足的指定长度</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前数组元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T[] GuardArrayLength<T>(this T[] array, int length, Type exceptionType, params object[] args)
	{
		array.GuardNotNull("array");
		length.GuardGreaterThanOrEqualTo(0, "length");
		array.Guard(array.Length == length, exceptionType, args);
		return array;
	}

	/// <summary>
	/// 检测当前数组的元素个数，如果数组的元素个数不等于 <paramref name="length" />，则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="length">数组需要满足的指定长度</param>
	/// <param name="name">数组对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.ArgumentException">如果当前数组元素个数不等于 <paramref name="length" />，则抛出该异常。</exception>
	public static T[] GuardArrayLength<T>(this T[] array, long length, string name = null, string message = null)
	{
		array.GuardNotNull("array");
		length.GuardGreaterThanOrEqualTo(0L, "length");
		array.Guard(array.LongLength == length, () => new ArgumentException(message.IfNull(Literals.MSG_ArrayLengthError), name.IfNull("array")));
		return array;
	}

	/// <summary>
	/// 检测当前数组的元素个数，如果数组的元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="length">数组需要满足的指定长度</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前数组元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T[] GuardArrayLength<T>(this T[] array, long length, Func<Exception> exceptionCreator)
	{
		array.GuardNotNull("array");
		length.GuardGreaterThanOrEqualTo(0L, "length");
		array.Guard(array.LongLength == length, exceptionCreator);
		return array;
	}

	/// <summary>
	/// 检测当前数组的元素个数，如果数组的元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="length">数组需要满足的指定长度</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前数组元素个数不等于 <paramref name="length" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T[] GuardArrayLength<T>(this T[] array, long length, Type exceptionType, params object[] args)
	{
		array.GuardNotNull("array");
		length.GuardGreaterThanOrEqualTo(0L, "length");
		array.Guard(array.LongLength == length, exceptionType, args);
		return array;
	}

	/// <summary>
	/// 检测当前数组的秩（维数），如果数组的秩（维数）不等于 <paramref name="rank" />，则抛出 <see cref="T:System.RankException" /> 异常
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组需要满足的秩（维数）</param>
	/// <param name="name">数组对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1。</exception>
	/// <exception cref="T:System.RankException">当前数组的秩（维数）不等于 <paramref name="rank" />。</exception>
	public static Array GuardArrayRank(this Array array, int rank, string name = null, string message = null)
	{
		array.GuardNotNull("array");
		rank.GuardGreaterThanOrEqualTo(1, "rank");
		array.Guard(array.Rank == rank, () => new RankException(string.Format(message.IfNull(Literals.MSG_ArrayRankError_1), name.IfNull("array"))));
		return array;
	}

	/// <summary>
	/// 检测当前数组的秩（维数），如果数组的秩（维数）不等于 <paramref name="rank" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组需要满足的秩（维数）</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前数组的秩（维数）不等于 <paramref name="rank" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常</exception>
	public static Array GuardArrayRank(this Array array, int rank, Func<Exception> exceptionCreator)
	{
		array.GuardNotNull("array");
		rank.GuardGreaterThanOrEqualTo(1, "rank");
		array.Guard(array.Rank == rank, exceptionCreator);
		return array;
	}

	/// <summary>
	/// 检测当前数组的秩（维数），如果数组的秩（维数）不等于 <paramref name="rank" />，则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组需要满足的秩（维数）</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前数组的秩（维数）不等于 <paramref name="rank" />，则抛出 <paramref name="exceptionType" /> 指定的异常</exception>
	public static Array GuardArrayRank(this Array array, int rank, Type exceptionType, params object[] args)
	{
		array.GuardNotNull("array");
		rank.GuardGreaterThanOrEqualTo(1, "rank");
		array.Guard(array.Rank == rank, exceptionType, args);
		return array;
	}

	/// <summary>
	/// 检测当前数组的秩（维数），如果数组的秩（维数）不等于 <paramref name="rank" />，则抛出 <see cref="T:System.RankException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组需要满足的秩（维数）</param>
	/// <param name="name">数组对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1。</exception>
	/// <exception cref="T:System.RankException">当前数组的秩（维数）不等于 <paramref name="rank" />。</exception>
	public static T[] GuardArrayRank<T>(this T[] array, int rank, string name = null, string message = null)
	{
		array.GuardNotNull("array");
		rank.GuardGreaterThanOrEqualTo(1, "rank");
		array.Guard(array.Rank == rank, () => new RankException(string.Format(message.IfNull(Literals.MSG_ArrayRankError_1), name.IfNull("array"))));
		return array;
	}

	/// <summary>
	/// 检测当前数组的秩（维数），如果数组的秩（维数）不等于 <paramref name="rank" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">前数组</param>
	/// <param name="rank">数组需要满足的秩（维数）</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前数组的秩（维数）不等于 <paramref name="rank" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常</exception>
	public static T[] GuardArrayRank<T>(this T[] array, int rank, Func<Exception> exceptionCreator)
	{
		array.GuardNotNull("array");
		rank.GuardGreaterThanOrEqualTo(1, "rank");
		array.Guard(array.Rank == rank, exceptionCreator);
		return array;
	}

	/// <summary>
	/// 检测当前数组的秩（维数），如果数组的秩（维数）不等于 <paramref name="rank" />，则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组需要满足的秩（维数）</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前数组的秩（维数）不等于 <paramref name="rank" />，则抛出 <paramref name="exceptionType" /> 指定的异常</exception>
	public static T[] GuardArrayRank<T>(this T[] array, int rank, Type exceptionType, params object[] args)
	{
		array.GuardNotNull("array");
		rank.GuardGreaterThanOrEqualTo(1, "rank");
		array.Guard(array.Rank == rank, exceptionType, args);
		return array;
	}

	/// <summary>
	/// 检测当前数组的指定秩（维度） <paramref name="rank" /> 的元素数量，如果不等于 <paramref name="length" /> 则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组检查元素数量的秩（维度），从1开始</param>
	/// <param name="length">数组指定秩（维度）中元素数量的条件</param>
	/// <param name="name">数组的名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1；或者 <paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.ArgumentException">如果当前数组指定秩（维数）<paramref name="rank" /> 的元素数量不等于 <paramref name="length" />，则抛出该异常。</exception>
	public static Array GuardArrayRankLength(this Array array, int rank, int length, string name = null, string message = null)
	{
		array.GuardNotNull("array");
		rank.GuardGreaterThanOrEqualTo(1, "rank");
		length.GuardGreaterThanOrEqualTo(0, "length");
		array.Guard(array.GetLength(rank - 1) == length, () => new ArgumentException(string.Format(message.IfNull(Literals.MSG_ArrayRankLengthError_1), rank), name.IfNull("array")));
		return array;
	}

	/// <summary>
	/// 检测当前数组的指定秩（维度） <paramref name="rank" /> 的元素数量，如果不等于 <paramref name="length" /> 则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组检查元素数量的秩（维度），从1开始</param>
	/// <param name="length">数组指定秩（维度）中元素数量的条件</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1；或者 <paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前数组指定秩（维数）<paramref name="rank" /> 的元素数量不等于 <paramref name="length" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static Array GuardArrayRankLength(this Array array, int rank, int length, Func<Exception> exceptionCreator)
	{
		array.GuardNotNull("array");
		rank.GuardGreaterThanOrEqualTo(1, "rank");
		length.GuardGreaterThanOrEqualTo(0, "length");
		array.Guard(array.GetLength(rank - 1) == length, exceptionCreator);
		return array;
	}

	/// <summary>
	/// 检测当前数组的指定秩（维度） <paramref name="rank" /> 的元素数量，如果不等于 <paramref name="length" /> 则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组检查元素数量的秩（维度），从1开始</param>
	/// <param name="length">数组指定秩（维度）中元素数量的条件</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1；或者 <paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前数组指定秩（维数）<paramref name="rank" /> 的元素数量不等于 <paramref name="length" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static Array GuardArrayRankLength(this Array array, int rank, int length, Type exceptionType, params object[] args)
	{
		array.GuardNotNull("array");
		rank.GuardGreaterThanOrEqualTo(1, "rank");
		length.GuardGreaterThanOrEqualTo(0, "length");
		array.Guard(array.GetLength(rank - 1) == length, exceptionType, args);
		return array;
	}

	/// <summary>
	/// 检测当前数组的指定秩（维度） <paramref name="rank" /> 的元素数量，如果不等于 <paramref name="length" /> 则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组检查元素数量的秩（维度），从1开始</param>
	/// <param name="length">数组指定秩（维度）中元素数量的条件</param>
	/// <param name="name">数组的名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1；或者 <paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.ArgumentException">如果当前数组指定秩（维数）<paramref name="rank" /> 的元素数量不等于 <paramref name="length" />，则抛出该异常。</exception>
	public static Array GuardArrayRankLength(this Array array, int rank, long length, string name = null, string message = null)
	{
		array.GuardNotNull("array");
		rank.GuardGreaterThanOrEqualTo(1, "rank");
		length.GuardGreaterThanOrEqualTo(0L, "length");
		array.Guard(array.GetLongLength(rank - 1) == length, () => new ArgumentException(string.Format(message.IfNull(Literals.MSG_ArrayRankLengthError_1), rank), name.IfNull("array")));
		return array;
	}

	/// <summary>
	/// 检测当前数组的指定秩（维度） <paramref name="rank" /> 的元素数量，如果不等于 <paramref name="length" /> 则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组检查元素数量的秩（维度），从1开始</param>
	/// <param name="length">数组指定秩（维度）中元素数量的条件</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1；或者 <paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前数组指定秩（维数）<paramref name="rank" /> 的元素数量不等于 <paramref name="length" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static Array GuardArrayRankLength(this Array array, int rank, long length, Func<Exception> exceptionCreator)
	{
		array.GuardNotNull("array");
		rank.GuardGreaterThanOrEqualTo(1, "rank");
		length.GuardGreaterThanOrEqualTo(0L, "length");
		array.Guard(array.GetLongLength(rank - 1) == length, exceptionCreator);
		return array;
	}

	/// <summary>
	/// 检测当前数组的指定秩（维度） <paramref name="rank" /> 的元素数量，如果不等于 <paramref name="length" /> 则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组检查元素数量的秩（维度），从1开始</param>
	/// <param name="length">数组指定秩（维度）中元素数量的条件</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1；或者 <paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前数组指定秩（维数）<paramref name="rank" /> 的元素数量不等于 <paramref name="length" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static Array GuardArrayRankLength(this Array array, int rank, long length, Type exceptionType, params object[] args)
	{
		array.GuardNotNull("array");
		rank.GuardGreaterThanOrEqualTo(1, "rank");
		length.GuardGreaterThanOrEqualTo(0L, "length");
		array.Guard(array.GetLongLength(rank - 1) == length, exceptionType, args);
		return array;
	}

	/// <summary>
	/// 检测当前数组的指定秩（维度） <paramref name="rank" /> 的元素数量，如果不等于 <paramref name="length" /> 则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组检查元素数量的秩（维度），从1开始</param>
	/// <param name="length">数组指定秩（维度）中元素数量的条件</param>
	/// <param name="name">数组的名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1；或者 <paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.ArgumentException">如果当前数组指定秩（维数）<paramref name="rank" /> 的元素数量不等于 <paramref name="length" />，则抛出该异常。</exception>
	public static T[] GuardArrayRankLength<T>(this T[] array, int rank, int length, string name = null, string message = null)
	{
		array.GuardNotNull("array");
		rank.GuardGreaterThanOrEqualTo(1, "rank");
		length.GuardGreaterThanOrEqualTo(0, "length");
		array.Guard(array.GetLength(rank - 1) == length, () => new ArgumentException(string.Format(message.IfNull(Literals.MSG_ArrayRankLengthError_1), rank), name.IfNull("array")));
		return array;
	}

	/// <summary>
	/// 检测当前数组的指定秩（维度） <paramref name="rank" /> 的元素数量，如果不等于 <paramref name="length" /> 则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组检查元素数量的秩（维度），从1开始</param>
	/// <param name="length">数组指定秩（维度）中元素数量的条件</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1；或者 <paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前数组指定秩（维数）<paramref name="rank" /> 的元素数量不等于 <paramref name="length" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T[] GuardArrayRankLength<T>(this T[] array, int rank, int length, Func<Exception> exceptionCreator)
	{
		array.GuardNotNull("array");
		rank.GuardGreaterThanOrEqualTo(1, "rank");
		length.GuardGreaterThanOrEqualTo(0, "length");
		array.Guard(array.GetLength(rank - 1) == length, exceptionCreator);
		return array;
	}

	/// <summary>
	/// 检测当前数组的指定秩（维度） <paramref name="rank" /> 的元素数量，如果不等于 <paramref name="length" /> 则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组检查元素数量的秩（维度），从1开始</param>
	/// <param name="length">数组指定秩（维度）中元素数量的条件</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1；或者 <paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前数组指定秩（维数）<paramref name="rank" /> 的元素数量不等于 <paramref name="length" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T[] GuardArrayRankLength<T>(this T[] array, int rank, int length, Type exceptionType, params object[] args)
	{
		array.GuardNotNull("array");
		rank.GuardGreaterThanOrEqualTo(1, "rank");
		length.GuardGreaterThanOrEqualTo(0, "length");
		array.Guard(array.GetLength(rank - 1) == length, exceptionType, args);
		return array;
	}

	/// <summary>
	/// 检测当前数组的指定秩（维度） <paramref name="rank" /> 的元素数量，如果不等于 <paramref name="length" /> 则抛出 <see cref="T:System.ArgumentException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组检查元素数量的秩（维度），从1开始</param>
	/// <param name="length">数组指定秩（维度）中元素数量的条件</param>
	/// <param name="name">数组的名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1；或者 <paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.ArgumentException">如果当前数组指定秩（维数）<paramref name="rank" /> 的元素数量不等于 <paramref name="length" />，则抛出该异常。</exception>
	public static T[] GuardArrayRankLength<T>(this T[] array, int rank, long length, string name = null, string message = null)
	{
		array.GuardNotNull("array");
		rank.GuardGreaterThanOrEqualTo(1, "rank");
		length.GuardGreaterThanOrEqualTo(0L, "length");
		array.Guard(array.GetLongLength(rank - 1) == length, () => new ArgumentException(string.Format(message.IfNull(Literals.MSG_ArrayRankLengthError_1), rank), name.IfNull("array")));
		return array;
	}

	/// <summary>
	/// 检测当前数组的指定秩（维度） <paramref name="rank" /> 的元素数量，如果不等于 <paramref name="length" /> 则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组检查元素数量的秩（维度），从1开始</param>
	/// <param name="length">数组指定秩（维度）中元素数量的条件</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1；或者 <paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前数组指定秩（维数）<paramref name="rank" /> 的元素数量不等于 <paramref name="length" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T[] GuardArrayRankLength<T>(this T[] array, int rank, long length, Func<Exception> exceptionCreator)
	{
		array.GuardNotNull("array");
		rank.GuardGreaterThanOrEqualTo(1, "rank");
		length.GuardGreaterThanOrEqualTo(0L, "length");
		array.Guard(array.GetLongLength(rank - 1) == length, exceptionCreator);
		return array;
	}

	/// <summary>
	/// 检测当前数组的指定秩（维度） <paramref name="rank" /> 的元素数量，如果不等于 <paramref name="length" /> 则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="rank">数组检查元素数量的秩（维度），从1开始</param>
	/// <param name="length">数组指定秩（维度）中元素数量的条件</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过返回当前数组本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rank" /> 小于1；或者 <paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前数组指定秩（维数）<paramref name="rank" /> 的元素数量不等于 <paramref name="length" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T[] GuardArrayRankLength<T>(this T[] array, int rank, long length, Type exceptionType, params object[] args)
	{
		array.GuardNotNull("array");
		rank.GuardGreaterThanOrEqualTo(1, "rank");
		length.GuardGreaterThanOrEqualTo(0L, "length");
		array.Guard(array.GetLongLength(rank - 1) == length, exceptionType, args);
		return array;
	}

	/// <summary>
	/// 检测当前数组是否与目标数组具有相同的结构（维度相同，各维度元素数量相同），如果不相同则抛出 <see cref="T:System.ArgumentException" /> 异常。
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="target">比较的目标数组</param>
	/// <param name="name">数组名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回原数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">如果当前数组与目标数组不相同则抛出该异常。</exception>
	public static Array GuardSameArray(this Array array, Array target, string name = null, string message = null)
	{
		array.GuardNotNull("array");
		target.GuardNotNull("target");
		array.Guard(array.IsSame(target), () => new ArgumentException(message.IfNull(Literals.MSG_ArrayDifferent), name.IfNull("array")));
		return array;
	}

	/// <summary>
	/// 检测当前数组是否与目标数组具有相同的结构（维度相同，各维度元素数量相同），如果不相同则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="target">比较的目标数组</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回原数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="target" /> 为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前数组与目标数组不相同，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static Array GuardSameArray(this Array array, Array target, Func<Exception> exceptionCreator)
	{
		array.GuardNotNull("array");
		target.GuardNotNull("target");
		array.Guard(array.IsSame(target), exceptionCreator);
		return array;
	}

	/// <summary>
	/// 检测当前数组是否与目标数组具有相同的结构（维度相同，各维度元素数量相同），如果不相同则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="target">比较的目标数组</param>
	/// <param name="exceptionType">指定的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回原数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="target" /> 为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前数组与目标数组不相同，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static Array GuardSameArray(this Array array, Array target, Type exceptionType, params object[] args)
	{
		array.GuardNotNull("array");
		target.GuardNotNull("target");
		array.Guard(array.IsSame(target), exceptionType, args);
		return array;
	}

	/// <summary>
	/// 检测当前数组是否与目标数组具有相同的结构（维度相同，各维度元素数量相同），如果不相同则抛出 <see cref="T:System.ArgumentException" /> 异常。
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <typeparam name="K">比较的数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="target">比较的目标数组</param>
	/// <param name="name">数组名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回原数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">如果当前数组与目标数组不相同则抛出该异常。</exception>
	public static T[] GuardSameArray<T, K>(this T[] array, K[] target, string name = null, string message = null)
	{
		array.GuardNotNull("array");
		target.GuardNotNull("target");
		array.Guard(array.IsSame(target), () => new ArgumentException(message.IfNull(Literals.MSG_ArrayDifferent), name.IfNull("array")));
		return array;
	}

	/// <summary>
	/// 检测当前数组是否与目标数组具有相同的结构（维度相同，各维度元素数量相同），如果不相同则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <typeparam name="K">比较的数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="target">比较的目标数组</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回原数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="target" /> 为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前数组与目标数组不相同，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T[] GuardSameArray<T, K>(this T[] array, K[] target, Func<Exception> exceptionCreator)
	{
		array.GuardNotNull("array");
		target.GuardNotNull("target");
		array.Guard(array.IsSame(target), exceptionCreator);
		return array;
	}

	/// <summary>
	/// 检测当前数组是否与目标数组具有相同的结构（维度相同，各维度元素数量相同），如果不相同则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <typeparam name="K">比较的数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="target">比较的目标数组</param>
	/// <param name="exceptionType">指定的异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回原数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="target" /> 为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前数组与目标数组不相同，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T[] GuardSameArray<T, K>(this T[] array, K[] target, Type exceptionType, params object[] args)
	{
		array.GuardNotNull("array");
		target.GuardNotNull("target");
		array.Guard(array.IsSame(target), exceptionType, args);
		return array;
	}

	/// <summary>
	/// 检测当前数组是否为空或者没有元素
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <returns>如果当前数组为空或者没有元素返回true，否则返回false。</returns>
	public static bool IsNullOrEmpty(this Array array)
	{
		return array.IsNull() || array.LongLength <= 0;
	}

	/// <summary>
	/// 检测数组是否为空或者没有元素
	/// </summary>
	/// <typeparam name="T">数组元素类型</typeparam>
	/// <param name="array">待检测的数组</param>
	/// <returns>如果数组为空或者没有元素返回true，否则返回false。</returns>
	public static bool IsNullOrEmpty<T>(this T[] array)
	{
		return array.IsNull() || array.LongLength <= 0;
	}

	/// <summary>
	/// 检测当前数组不为空且不为空数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <returns>如果当前数组不为空且不为空数组返回true，否则返回false。</returns>
	public static bool IsNotNullAndEmpty(this Array array)
	{
		return array.IsNotNull() && array.LongLength > 0;
	}

	/// <summary>
	/// 检测当前数组不为空且不为空数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <returns>如果当前数组不为空且不为空数组返回true，否则返回false。</returns>
	public static bool IsNotNullAndEmpty<T>(this T[] array)
	{
		return array.IsNotNull() && array.LongLength > 0;
	}

	/// <summary>
	/// 检测当前数组和目标数组结构是否相同（具有相同的维度，每个维度上具有相同数量的元素）
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="target">目标数组</param>
	/// <returns>如果当前数组和目标数组结构</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="target" /> 为空。</exception>
	public static bool IsSame(this Array array, Array target)
	{
		array.GuardNotNull("array");
		target.GuardNotNull("target");
		if (array.Rank == target.Rank)
		{
			for (int r = 0; r < array.Rank; r++)
			{
				if (array.GetLongLength(r) != target.GetLongLength(r))
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	/// <summary>
	/// 检测当前数组和目标数组结构是否相同（具有相同的维度，每个维度上具有相同数量的元素）
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <typeparam name="K">目标数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="target">目标数组</param>
	/// <returns>如果当前数组和目标数组结构</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="target" /> 为空。</exception>
	public static bool IsSame<T, K>(this T[] array, K[] target)
	{
		array.GuardNotNull("array");
		target.GuardNotNull("target");
		return array.LongLength == target.LongLength;
	}

	/// <summary>
	/// 将当前数组更改为指定的容量
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="newSize">数组的新容量</param>
	/// <returns>返回改变容量后的新数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；<paramref name="newSize" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="newSize" /> 的元素个数小于1。</exception>
	public static Array Resize(this Array array, int[] newSize)
	{
		array.GuardNotNull("array");
		newSize.GuardNotNull("newSize");
		newSize.Length.GuardGreaterThanOrEqualTo(1, "newSize");
		Array newArray = Array.CreateInstance(array.GetElementType(), newSize);
		Array.Copy(array, newArray, Math.Min(array.Length, newArray.Length));
		return newArray;
	}

	/// <summary>
	/// 将当前数组更改为指定的容量
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="newSize">数组的新容量</param>
	/// <returns>返回改变容量后的新数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；<paramref name="newSize" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="newSize" /> 的元素个数小于1。</exception>
	public static Array Resize(this Array array, long[] newSize)
	{
		array.GuardNotNull("array");
		newSize.GuardNotNull("newSize");
		newSize.Length.GuardGreaterThanOrEqualTo(1, "newSize");
		Array newArray = Array.CreateInstance(array.GetElementType(), newSize);
		Array.Copy(array, newArray, Math.Min(array.LongLength, newArray.LongLength));
		return newArray;
	}

	/// <summary>
	/// 将当前数组更改为指定的容量
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="newSize">数组的新容量</param>
	/// <returns>返回改变容量后的新数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="newSize" /> 小于0。</exception>
	public static T[] Resize<T>(this T[] array, int newSize)
	{
		array.GuardNotNull("array");
		newSize.GuardGreaterThanOrEqualTo(0, "newSize");
		Array.Resize(ref array, newSize);
		return array;
	}

	/// <summary>
	/// 将当前数组更改为指定的容量
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="newSize">数组的新容量</param>
	/// <returns>返回改变容量后的新数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="newSize" /> 小于0。</exception>
	public static T[] Resize<T>(this T[] array, long newSize)
	{
		array.GuardNotNull("array");
		newSize.GuardGreaterThanOrEqualTo(0L, "newSize");
		T[] newArray = new T[newSize];
		Array.Copy(array, newArray, Math.Min(array.LongLength, newArray.LongLength));
		return newArray;
	}

	/// <summary>
	/// 反转当前数组中的所有元素
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <returns>反转后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static Array Reverse(this Array array)
	{
		array.GuardNotNull("array");
		return array.Reverse(0, array.Length);
	}

	/// <summary>
	/// 反转当前数组中的元素
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">反转元素的起始位置</param>
	/// <returns>反转后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组的元素索引范围内。</exception>
	public static Array Reverse(this Array array, int start)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.Reverse(start, array.Length - start);
	}

	/// <summary>
	/// 反转当前数组中的元素
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">反转元素的起始位置</param>
	/// <param name="count">反转的元素的数量</param>
	/// <returns>反转后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组的元素索引范围内。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组中的元素个数。</exception>
	public static Array Reverse(this Array array, int start, int count)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		count.GuardBetween(0, array.Length - start, "count");
		int[] weights = array.GetWeight();
		int left = start;
		int right = start + count - 1;
		while (left < right)
		{
			object temp = array.GetValue(left, weights);
			array.SetValue(array.GetValue(right, weights), left, weights);
			array.SetValue(temp, right, weights);
			left++;
			right--;
		}
		return array;
	}

	/// <summary>
	/// 反转当前数组中的元素
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">反转元素的起始位置</param>
	/// <returns>反转后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组的元素索引范围内。</exception>
	public static Array Reverse(this Array array, long start)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.Reverse(start, array.LongLength - start);
	}

	/// <summary>
	/// 反转当前数组中的元素
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">反转元素的起始位置</param>
	/// <param name="count">反转的元素的数量</param>
	/// <returns>反转后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组的元素索引范围内。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组中的元素个数。</exception>
	public static Array Reverse(this Array array, long start, long count)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		count.GuardBetween(0L, array.LongLength - start, "count");
		long[] weight = array.GetLongWeight();
		long left = start;
		long right = start + count - 1;
		while (left < right)
		{
			object temp = array.GetValue(left, weight);
			array.SetValue(array.GetValue(right, weight), left, weight);
			array.SetValue(temp, right, weight);
			left++;
			right--;
		}
		return array;
	}

	/// <summary>
	/// 反转当前数组中的元素
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <returns>反转后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static T[] Reverse<T>(this T[] array)
	{
		array.GuardNotNull("array");
		return array.Reverse(0, array.Length);
	}

	/// <summary>
	/// 反转当前数组中的元素
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">反转元素的起始位置</param>
	/// <returns>反转后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组的元素索引范围内。</exception>
	public static T[] Reverse<T>(this T[] array, int start)
	{
		array.GuardNotNull("start");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.Reverse(start, array.Length - start);
	}

	/// <summary>
	/// 反转当前数组中的元素
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">反转的起始位置</param>
	/// <param name="count">反转的元素数量</param>
	/// <returns>反转后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组的元素索引范围内。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组中的元素个数。</exception>
	public static T[] Reverse<T>(this T[] array, int start, int count)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		count.GuardBetween(0, array.Length - start, "count");
		Array.Reverse(array, start, count);
		return array;
	}

	/// <summary>
	/// 反转当前数组中的元素
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">反转元素的起始位置</param>
	/// <returns>反转后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组的元素索引范围内。</exception>
	public static T[] Reverse<T>(this T[] array, long start)
	{
		array.GuardNotNull("start");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.Reverse(start, array.LongLength - start);
	}

	/// <summary>
	/// 反转当前数组中的元素
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">反转的起始位置</param>
	/// <param name="count">反转的元素数量</param>
	/// <returns>反转后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组的元素索引范围内。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组中的元素个数。</exception>
	public static T[] Reverse<T>(this T[] array, long start, long count)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		count.GuardBetween(0L, array.LongLength - start, "count");
		long left = start;
		long right = start + count - 1;
		while (left < right)
		{
			T temp = array[left];
			array[left] = array[right];
			array[right] = temp;
			left++;
			right--;
		}
		return array;
	}

	/// <summary>
	/// 设置当前数组中指定位置的值
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="value">待设置的值</param>
	/// <param name="index">元素索引位置，如果当前数组为多维数组，则元素位置表示数组各维度头尾相连后的索引位置</param>
	/// <param name="weight">当前数组各个秩（维数）的元素个数；如果设置为nul，则使用当前数组的各个秩（维数）的元素个数。</param>
	/// <returns>处理后的当前数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="index" /> 超出了当前数组索引的有效范围。</exception>
	/// <exception cref="T:System.InvalidCastException"><paramref name="value" /> 不能转换为当前数组元素的类型。</exception>
	/// <remarks>本方法支持设置任意维度的数组的元素值。对于多维数组，参数 <paramref name="index" /> 将表示数组各维度头尾相连后的索引位置。</remarks>
	public static Array SetValue(this Array array, object value, int index, int[] weight)
	{
		array.GuardNotNull("array");
		index.GuardIndexRange(0, array.Length - 1, "index");
		array.SetValue(value, index.RadixParse(weight.IfNull(array.GetWeight())));
		return array;
	}

	/// <summary>
	/// 设置当前数组中指定位置的值
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="value">待设置的值</param>
	/// <param name="index">元素索引位置，如果当前数组为多维数组，则元素位置表示数组各维度头尾相连后的索引位置</param>
	/// <param name="weight">当前数组各个秩（维数）的元素个数；如果设置为nul，则使用当前数组的各个秩（维数）的元素个数。</param>
	/// <returns>处理后的当前数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="index" /> 超出了当前数组索引的有效范围。</exception>
	/// <exception cref="T:System.InvalidCastException"><paramref name="value" /> 不能转换为当前数组元素的类型。</exception>
	/// <remarks>本方法支持设置任意维度的数组的元素值。对于多维数组，参数 <paramref name="index" /> 将表示数组各维度头尾相连后的索引位置。</remarks>
	public static Array SetValue(this Array array, object value, long index, long[] weight)
	{
		array.GuardNotNull("array");
		index.GuardIndexRange(0L, array.LongLength - 1, "index");
		array.SetValue(value, index.RadixParse(weight.IfNull(array.GetLongWeight()), 1L));
		return array;
	}

	/// <summary>
	/// 对当前数组进行排序
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <returns>排序后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static Array Sort(this Array array)
	{
		array.GuardNotNull("array");
		return array.Sort(0, array.Length);
	}

	/// <summary>
	/// 对当前数组进行排序
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="comparer">数组元素比较器</param>
	/// <returns>排序后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；<paramref name="comparer" /> 为空。</exception>
	public static Array Sort(this Array array, IComparer comparer)
	{
		array.GuardNotNull("array");
		return array.Sort(0, array.Length, comparer);
	}

	/// <summary>
	/// 对当前数组进行排序
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="comparison">数组元素比较方法</param>
	/// <returns>排序后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；<paramref name="comparison" /> 为空。</exception>
	public static Array Sort(this Array array, Func<object, object, int> comparison)
	{
		array.GuardNotNull("array");
		return array.Sort(0, array.Length, comparison);
	}

	/// <summary>
	/// 对当前数组进行排序
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始排序位置</param>
	/// <returns>排序后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	public static Array Sort(this Array array, int start)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.Sort(start, array.Length - start, Comparer.Default.Compare);
	}

	/// <summary>
	/// 对当前数组进行排序
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始排序位置</param>
	/// <param name="comparer">数组元素排序比较对象</param>
	/// <returns>排序后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；<paramref name="comparer" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	public static Array Sort(this Array array, int start, IComparer comparer)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.Sort(start, array.Length - start, comparer);
	}

	/// <summary>
	/// 对当前数组进行排序
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始排序位置</param>
	/// <param name="comparison">数组元素排序比较方法</param>
	/// <returns>排序后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；<paramref name="comparison" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	public static Array Sort(this Array array, int start, Func<object, object, int> comparison)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.Sort(start, array.Length - start, comparison);
	}

	/// <summary>
	/// 对当前数组进行排序
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始排序位置</param>
	/// <param name="count">排序的元素数量</param>
	/// <returns>排序后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组从 <paramref name="start" /> 位置开始剩余的元素数量。</exception>
	public static Array Sort(this Array array, int start, int count)
	{
		return array.Sort(start, count, Comparer.Default.Compare);
	}

	/// <summary>
	/// 对当前数组进行排序
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始排序位置</param>
	/// <param name="count">排序的元素数量</param>
	/// <param name="comparer">数组元素排序比较对象</param>
	/// <returns>排序后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；<paramref name="comparer" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组从 <paramref name="start" /> 位置开始剩余的元素数量。</exception>
	public static Array Sort(this Array array, int start, int count, IComparer comparer)
	{
		comparer.GuardNotNull("comparer");
		return array.Sort(start, count, comparer.Compare);
	}

	/// <summary>
	/// 对当前数组进行排序
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始排序位置</param>
	/// <param name="count">排序的元素数量</param>
	/// <param name="comparison">数组元素排序比较方法</param>
	/// <returns>排序后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；<paramref name="comparison" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组从 <paramref name="start" /> 位置开始剩余的元素数量。</exception>
	public static Array Sort(this Array array, int start, int count, Func<object, object, int> comparison)
	{
		array.GuardNotNull("array");
		comparison.GuardNotNull("comparison");
		start.GuardIndexRange(0, array.Length - 1, "start");
		count.GuardBetween(0, array.Length - start, "count");
		int end = start + count - 1;
		if (start <= end)
		{
			QuickSortForArray(array, start, end, null, null, comparison);
		}
		return array;
	}

	/// <summary>
	/// 用于数组对象的快速排序算法
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">排序区域起始位置</param>
	/// <param name="end">排序区域结束位置</param>
	/// <param name="weights">当前数组的尺寸</param>
	/// <param name="items">按当前数组排序的目标值数组</param>
	/// <param name="comparison">元素比较方法</param>
	private static void QuickSortForArray(Array array, int start, int end, int[] weights, Array items, Func<object, object, int> comparison)
	{
		weights = weights.IfNull(array.GetWeight());
		int i = start;
		int j = end;
		object pivot = array.GetValue(i + j >> 1, weights);
		while (i <= j)
		{
			object vi = array.GetValue(i, weights);
			object vj = array.GetValue(j, weights);
			while (comparison(vi, pivot) < 0)
			{
				i++;
			}
			while (comparison(vj, pivot) > 0)
			{
				j--;
			}
			if (i <= j)
			{
				object temp = vi;
				array.SetValue(vj, i, weights);
				array.SetValue(temp, j, weights);
				i++;
				j--;
				if (items.IsNotNull())
				{
					temp = items.GetValue(i, weights);
					items.SetValue(items.GetValue(j, weights), i, weights);
					items.SetValue(temp, j, weights);
				}
			}
		}
		if (start < j)
		{
			QuickSortForArray(array, start, j, weights, items, comparison);
		}
		if (i < end)
		{
			QuickSortForArray(array, i, end, weights, items, comparison);
		}
	}

	/// <summary>
	/// 对当前数组进行排序
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始排序位置</param>
	/// <returns>排序后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	public static Array Sort(this Array array, long start)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.Sort(start, array.LongLength - start, Comparer.Default.Compare);
	}

	/// <summary>
	/// 对当前数组进行排序
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始排序位置</param>
	/// <param name="comparer">数组元素排序比较对象</param>
	/// <returns>排序后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；<paramref name="comparer" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	public static Array Sort(this Array array, long start, IComparer comparer)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.Sort(start, array.LongLength - start, comparer);
	}

	/// <summary>
	/// 对当前数组进行排序
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始排序位置</param>
	/// <param name="comparison">数组元素排序比较方法</param>
	/// <returns>排序后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；<paramref name="comparison" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	public static Array Sort(this Array array, long start, Func<object, object, int> comparison)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.Sort(start, array.LongLength - start, comparison);
	}

	/// <summary>
	/// 对当前数组进行排序
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始排序位置</param>
	/// <param name="count">排序的元素数量</param>
	/// <returns>排序后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组从 <paramref name="start" /> 位置开始剩余的元素数量。</exception>
	public static Array Sort(this Array array, long start, long count)
	{
		return array.Sort(start, count, Comparer.Default.Compare);
	}

	/// <summary>
	/// 对当前数组进行排序
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始排序位置</param>
	/// <param name="count">排序的元素数量</param>
	/// <param name="comparer">数组元素排序比较对象</param>
	/// <returns>排序后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；<paramref name="comparer" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组从 <paramref name="start" /> 位置开始剩余的元素数量。</exception>
	public static Array Sort(this Array array, long start, long count, IComparer comparer)
	{
		comparer.GuardNotNull("comparer");
		return array.Sort(start, count, comparer.Compare);
	}

	/// <summary>
	/// 对当前数组进行排序
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始排序位置</param>
	/// <param name="count">排序的元素数量</param>
	/// <param name="comparison">数组元素排序比较方法</param>
	/// <returns>排序后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；<paramref name="comparison" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组从 <paramref name="start" /> 位置开始剩余的元素数量。</exception>
	public static Array Sort(this Array array, long start, long count, Func<object, object, int> comparison)
	{
		array.GuardNotNull("array");
		comparison.GuardNotNull("comparison");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		count.GuardBetween(0L, array.LongLength - start, "count");
		long end = start + count - 1;
		if (start <= end)
		{
			QuickSortForArray(array, start, end, null, null, comparison);
		}
		return array;
	}

	/// <summary>
	/// 用于数组对象的快速排序算法
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">排序区域起始位置</param>
	/// <param name="weights">当前数组的尺寸</param>
	/// <param name="items">按当前数组排序的目标值数组</param>
	/// <param name="end">排序区域结束位置</param>
	/// <param name="comparison">元素比较方法</param>
	private static void QuickSortForArray(Array array, long start, long end, long[] weights, Array items, Func<object, object, int> comparison)
	{
		weights = weights.IfNull(array.GetLongWeight());
		long i = start;
		long j = end;
		object pivot = array.GetValue(i + j >> 1, weights);
		while (i <= j)
		{
			object vi = array.GetValue(i, weights);
			object vj = array.GetValue(j, weights);
			while (comparison(vi, pivot) < 0)
			{
				i++;
			}
			while (comparison(vj, pivot) > 0)
			{
				j--;
			}
			if (i <= j)
			{
				object temp = vi;
				array.SetValue(vj, i, weights);
				array.SetValue(temp, j, weights);
				i++;
				j--;
				if (items.IsNotNull())
				{
					temp = items.GetValue(i, weights);
					items.SetValue(items.GetValue(j, weights), i, weights);
					items.SetValue(temp, j, weights);
				}
			}
		}
		if (start < j)
		{
			QuickSortForArray(array, start, j, weights, items, comparison);
		}
		if (i < end)
		{
			QuickSortForArray(array, i, end, weights, items, comparison);
		}
	}

	/// <summary>
	/// 对当前数组进行排序
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前待排序数组</param>
	/// <returns>排序后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static T[] Sort<T>(this T[] array)
	{
		array.GuardNotNull("array");
		Array.Sort(array);
		return array;
	}

	/// <summary>
	/// 对当前数组进行排序
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前待排序数组</param>
	/// <param name="comparer">数组元素排序比较器</param>
	/// <returns>排序后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；<paramref name="comparer" /> 为空。</exception>
	public static T[] Sort<T>(this T[] array, IComparer<T> comparer)
	{
		array.GuardNotNull("array");
		comparer.GuardNotNull("comparer");
		Array.Sort(array, comparer);
		return array;
	}

	/// <summary>
	/// 对当前数组进行排序
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前待排序数组</param>
	/// <param name="comparison">数组元素排序比较器</param>
	/// <returns>排序后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；<paramref name="comparison" /> 为空。</exception>
	public static T[] Sort<T>(this T[] array, Func<T, T, int> comparison)
	{
		array.GuardNotNull("array");
		comparison.GuardNotNull("comparison");
		Array.Sort(array, comparison.ToComparer());
		return array;
	}

	/// <summary>
	/// 对当前数组进行排序
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前待排序数组</param>
	/// <param name="start">开始排序的位置</param>
	/// <returns>排序后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	public static T[] Sort<T>(this T[] array, int start)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.Sort(start, array.Length - start, Comparer<T>.Default);
	}

	/// <summary>
	/// 对当前数组进行排序
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前待排序数组</param>
	/// <param name="start">开始排序的位置</param>
	/// <param name="comparer">数组元素排序比较器</param>
	/// <returns>排序后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；<paramref name="comparer" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	public static T[] Sort<T>(this T[] array, int start, IComparer<T> comparer)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.Sort(start, array.Length - start, comparer);
	}

	/// <summary>
	/// 对当前数组进行排序
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前待排序数组</param>
	/// <param name="start">开始排序的位置</param>
	/// <param name="comparison">数组元素排序比较方法</param>
	/// <returns>排序后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；<paramref name="comparison" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	public static T[] Sort<T>(this T[] array, int start, Func<T, T, int> comparison)
	{
		array.GuardNotNull("aray");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.Sort(start, array.Length - start, comparison);
	}

	/// <summary>
	/// 对当前数组进行排序
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前待排序数组</param>
	/// <param name="start">开始排序的位置</param>
	/// <param name="count">排序的元素数量</param>
	/// <returns>排序后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组从 <paramref name="start" /> 位置开始剩余的元素数量。</exception>
	public static T[] Sort<T>(this T[] array, int start, int count)
	{
		return array.Sort(start, count, Comparer<T>.Default);
	}

	/// <summary>
	/// 对当前数组进行排序
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前待排序数组</param>
	/// <param name="start">开始排序的位置</param>
	/// <param name="count">排序的元素数量</param>
	/// <param name="comparer">数组元素排序比较器</param>
	/// <returns>排序后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；<paramref name="comparer" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组从 <paramref name="start" /> 位置开始剩余的元素数量。</exception>
	public static T[] Sort<T>(this T[] array, int start, int count, IComparer<T> comparer)
	{
		array.GuardNotNull("array");
		comparer.GuardNotNull("comparer");
		start.GuardIndexRange(0, array.Length - 1, "start");
		count.GuardBetween(0, array.Length - start, "count");
		Array.Sort(array, start, count, comparer);
		return array;
	}

	/// <summary>
	/// 对当前数组进行排序
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前待排序数组</param>
	/// <param name="start">开始排序的位置</param>
	/// <param name="count">排序的元素数量</param>
	/// <param name="comparison">数组元素排序比较方法</param>
	/// <returns>排序后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；<paramref name="comparison" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组从 <paramref name="start" /> 位置开始剩余的元素数量。</exception>
	public static T[] Sort<T>(this T[] array, int start, int count, Func<T, T, int> comparison)
	{
		comparison.GuardNotNull("comparison");
		return array.Sort(start, count, comparison.ToComparer());
	}

	/// <summary>
	/// 对当前数组进行排序
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前待排序数组</param>
	/// <param name="start">开始排序的位置</param>
	/// <returns>排序后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	public static T[] Sort<T>(this T[] array, long start)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.Sort(start, array.LongLength - start, Comparer<T>.Default);
	}

	/// <summary>
	/// 对当前数组进行排序
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前待排序数组</param>
	/// <param name="start">开始排序的位置</param>
	/// <param name="comparer">数组元素排序比较器</param>
	/// <returns>排序后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；<paramref name="comparer" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	public static T[] Sort<T>(this T[] array, long start, IComparer<T> comparer)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.Sort(start, array.LongLength - start, comparer);
	}

	/// <summary>
	/// 对当前数组进行排序
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前待排序数组</param>
	/// <param name="start">开始排序的位置</param>
	/// <param name="comparison">数组元素排序比较方法</param>
	/// <returns>排序后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；<paramref name="comparison" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	public static T[] Sort<T>(this T[] array, long start, Func<T, T, int> comparison)
	{
		array.GuardNotNull("aray");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.Sort(start, array.LongLength - start, comparison);
	}

	/// <summary>
	/// 对当前数组进行排序
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前待排序数组</param>
	/// <param name="start">开始排序的位置</param>
	/// <param name="count">排序的元素数量</param>
	/// <returns>排序后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组从 <paramref name="start" /> 位置开始剩余的元素数量。</exception>
	public static T[] Sort<T>(this T[] array, long start, long count)
	{
		return array.Sort(start, count, Comparer<T>.Default);
	}

	/// <summary>
	/// 对当前数组进行排序
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前待排序数组</param>
	/// <param name="start">开始排序的位置</param>
	/// <param name="count">排序的元素数量</param>
	/// <param name="comparer">数组元素排序比较器</param>
	/// <returns>排序后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；<paramref name="comparer" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组从 <paramref name="start" /> 位置开始剩余的元素数量。</exception>
	public static T[] Sort<T>(this T[] array, long start, long count, IComparer<T> comparer)
	{
		return array.Sort(start, count, comparer.IfNull(Comparer<T>.Default).Compare);
	}

	/// <summary>
	/// 对当前数组进行排序
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前待排序数组</param>
	/// <param name="start">开始排序的位置</param>
	/// <param name="count">排序的元素数量</param>
	/// <param name="comparison">数组元素排序比较方法</param>
	/// <returns>排序后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；<paramref name="comparison" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组从 <paramref name="start" /> 位置开始剩余的元素数量。</exception>
	public static T[] Sort<T>(this T[] array, long start, long count, Func<T, T, int> comparison)
	{
		comparison.GuardNotNull("comparison");
		return array.As<Array>().Sort(start, count, (object x, object y) => comparison((T)x, (T)y)).As<T[]>();
	}

	/// <summary>
	/// 按照指定的键数组对当前数组进行排序
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="keys">键数组</param>
	/// <returns>排序后的当前数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="keys" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前数组和 <paramref name="keys" /> 不相同。</exception>
	public static Array SortBy(this Array array, Array keys)
	{
		array.GuardNotNull("array");
		keys.GuardNotNull("keys");
		return array.SortBy(keys, 0, array.Length, Comparer.Default);
	}

	/// <summary>
	/// 按照指定的键数组对当前数组进行排序
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="keys">键数组</param>
	/// <param name="comparer">键数组元素比较器</param>
	/// <returns>排序后的当前数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="keys" /> 为空；或者 <paramref name="comparer" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前数组和 <paramref name="keys" /> 不相同。</exception>
	public static Array SortBy(this Array array, Array keys, IComparer comparer)
	{
		array.GuardNotNull("array");
		keys.GuardNotNull("keys");
		return array.SortBy(keys, 0, array.Length, comparer);
	}

	/// <summary>
	/// 按照指定的键数组对当前数组进行排序
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="keys">键数组</param>
	/// <param name="comparison">键数组元素比较方法</param>
	/// <returns>排序后的当前数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="keys" /> 为空；或者 <paramref name="comparison" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前数组和 <paramref name="keys" /> 不相同。</exception>
	public static Array SortBy(this Array array, Array keys, Func<object, object, int> comparison)
	{
		array.GuardNotNull("array");
		keys.GuardNotNull("keys");
		return array.SortBy(keys, 0, array.Length, comparison);
	}

	/// <summary>
	/// 按照指定的键数组对当前数组进行排序
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="keys">键数组</param>
	/// <param name="start">排序范围的起始索引</param>
	/// <returns>排序后的当前数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="keys" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前数组和 <paramref name="keys" /> 不相同。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	public static Array SortBy(this Array array, Array keys, int start)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.SortBy(keys, start, array.Length - start, Comparer.Default.Compare);
	}

	/// <summary>
	/// 按照指定的键数组对当前数组进行排序
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="keys">键数组</param>
	/// <param name="start">排序范围的起始索引</param>
	/// <param name="comparer">键数组元素比较器</param>
	/// <returns>排序后的当前数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="keys" /> 为空；或者 <paramref name="comparer" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前数组和 <paramref name="keys" /> 不相同。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	public static Array SortBy(this Array array, Array keys, int start, IComparer comparer)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.SortBy(keys, start, array.Length - start, comparer);
	}

	/// <summary>
	/// 按照指定的键数组对当前数组进行排序
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="keys">键数组</param>
	/// <param name="start">排序范围的起始索引</param>
	/// <param name="comparison">键数组元素比较方法</param>
	/// <returns>排序后的当前数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="keys" /> 为空；或者 <paramref name="comparison" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前数组和 <paramref name="keys" /> 不相同。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	public static Array SortBy(this Array array, Array keys, int start, Func<object, object, int> comparison)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.SortBy(keys, start, array.Length - start, comparison);
	}

	/// <summary>
	/// 按照指定的键数组对当前数组进行排序
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="keys">键数组</param>
	/// <param name="start">排序范围的起始索引</param>
	/// <param name="count">排序范围内的元素数</param>
	/// <returns>排序后的当前数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="keys" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前数组和 <paramref name="keys" /> 不相同。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组从 <paramref name="start" /> 位置开始剩余的元素数量。</exception>
	public static Array SortBy(this Array array, Array keys, int start, int count)
	{
		return array.SortBy(keys, start, count, Comparer.Default.Compare);
	}

	/// <summary>
	/// 按照指定的键数组对当前数组进行排序
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="keys">键数组</param>
	/// <param name="start">排序范围的起始索引</param>
	/// <param name="count">排序范围内的元素数</param>
	/// <param name="comparer">键数组元素比较器</param>
	/// <returns>排序后的当前数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="keys" /> 为空；或者 <paramref name="comparer" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前数组和 <paramref name="keys" /> 不相同。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组从 <paramref name="start" /> 位置开始剩余的元素数量。</exception>
	public static Array SortBy(this Array array, Array keys, int start, int count, IComparer comparer)
	{
		comparer.GuardNotNull("comparer");
		return array.SortBy(keys, start, count, comparer.Compare);
	}

	/// <summary>
	/// 按照指定的键数组对当前数组进行排序
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="keys">键数组</param>
	/// <param name="start">排序范围的起始索引</param>
	/// <param name="count">排序范围内的元素数</param>
	/// <param name="comparison">键数组元素比较方法</param>
	/// <returns>排序后的当前数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="keys" /> 为空；或者 <paramref name="comparison" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前数组和 <paramref name="keys" /> 不相同。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组从 <paramref name="start" /> 位置开始剩余的元素数量。</exception>
	public static Array SortBy(this Array array, Array keys, int start, int count, Func<object, object, int> comparison)
	{
		array.GuardNotNull("array");
		keys.GuardNotNull("keys");
		comparison.GuardNotNull("comparison");
		array.GuardSameArray(keys, "array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		count.GuardBetween(0, array.Length - start, "count");
		if (count > 0)
		{
			int end = start + count - 1;
			if (start <= end)
			{
				QuickSortForArray(keys, start, end, null, array, comparison);
			}
		}
		return array;
	}

	/// <summary>
	/// 按照指定的键数组对当前数组进行排序
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="keys">键数组</param>
	/// <param name="start">排序范围的起始索引</param>
	/// <returns>排序后的当前数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="keys" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前数组和 <paramref name="keys" /> 不相同。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	public static Array SortBy(this Array array, Array keys, long start)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.SortBy(keys, start, array.LongLength - start, Comparer.Default.Compare);
	}

	/// <summary>
	/// 按照指定的键数组对当前数组进行排序
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="keys">键数组</param>
	/// <param name="start">排序范围的起始索引</param>
	/// <param name="comparer">键数组元素比较器</param>
	/// <returns>排序后的当前数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="keys" /> 为空；或者 <paramref name="comparer" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前数组和 <paramref name="keys" /> 不相同。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	public static Array SortBy(this Array array, Array keys, long start, IComparer comparer)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		comparer.GuardNotNull("comparer");
		return array.SortBy(keys, start, array.LongLength - start, comparer);
	}

	/// <summary>
	/// 按照指定的键数组对当前数组进行排序
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="keys">键数组</param>
	/// <param name="start">排序范围的起始索引</param>
	/// <param name="comparison">键数组元素比较方法</param>
	/// <returns>排序后的当前数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="keys" /> 为空；或者 <paramref name="comparison" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前数组和 <paramref name="keys" /> 不相同。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	public static Array SortBy(this Array array, Array keys, long start, Func<object, object, int> comparison)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		comparison.GuardNotNull("comparison");
		return array.SortBy(keys, start, array.LongLength - start, comparison);
	}

	/// <summary>
	/// 按照指定的键数组对当前数组进行排序
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="keys">键数组</param>
	/// <param name="start">排序范围的起始索引</param>
	/// <param name="count">排序范围内的元素数</param>
	/// <returns>排序后的当前数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="keys" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前数组和 <paramref name="keys" /> 不相同。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组从 <paramref name="start" /> 位置开始剩余的元素数量。</exception>
	public static Array SortBy(this Array array, Array keys, long start, long count)
	{
		return array.SortBy(keys, start, count, Comparer.Default.Compare);
	}

	/// <summary>
	/// 按照指定的键数组对当前数组进行排序
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="keys">键数组</param>
	/// <param name="start">排序范围的起始索引</param>
	/// <param name="count">排序范围内的元素数</param>
	/// <param name="comparer">键数组元素比较器</param>
	/// <returns>排序后的当前数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="keys" /> 为空；或者 <paramref name="comparer" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前数组和 <paramref name="keys" /> 不相同。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组从 <paramref name="start" /> 位置开始剩余的元素数量。</exception>
	public static Array SortBy(this Array array, Array keys, long start, long count, IComparer comparer)
	{
		comparer.GuardNotNull("comparer");
		return array.SortBy(keys, start, count, comparer.Compare);
	}

	/// <summary>
	/// 按照指定的键数组对当前数组进行排序
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="keys">键数组</param>
	/// <param name="start">排序范围的起始索引</param>
	/// <param name="count">排序范围内的元素数</param>
	/// <param name="comparison">键数组元素比较方法</param>
	/// <returns>排序后的当前数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="keys" /> 为空；或者 <paramref name="comparison" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前数组和 <paramref name="keys" /> 不相同。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组从 <paramref name="start" /> 位置开始剩余的元素数量。</exception>
	public static Array SortBy(this Array array, Array keys, long start, long count, Func<object, object, int> comparison)
	{
		array.GuardNotNull("array");
		keys.GuardNotNull("keys");
		comparison.GuardNotNull("comparison");
		array.GuardSameArray(keys, "array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		count.GuardBetween(0L, array.LongLength - start, "count");
		if (count > 0)
		{
			long end = start + count - 1;
			if (start <= end)
			{
				QuickSortForArray(keys, start, end, null, array, comparison);
			}
		}
		return array;
	}

	/// <summary>
	/// 按照指定的键数组对当前数组进行排序
	/// </summary>
	/// <typeparam name="K">键数组的元素类型</typeparam>
	/// <typeparam name="V">当前数组的元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="keys">键数组</param>
	/// <returns>排序后的值数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="keys" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前数组和 <paramref name="keys" /> 不相同。</exception>
	public static V[] SortBy<K, V>(this V[] array, K[] keys)
	{
		return array.SortBy(keys, Comparer<K>.Default);
	}

	/// <summary>
	/// 按照指定的键数组对当前数组进行排序
	/// </summary>
	/// <typeparam name="K">键数组的元素类型</typeparam>
	/// <typeparam name="V">当前数组的元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="keys">键数组</param>
	/// <param name="comparer">键数组元素比较器</param>
	/// <returns>排序后的值数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="keys" /> 为空；或者 <paramref name="comparer" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前数组和 <paramref name="keys" /> 不相同。</exception>
	public static V[] SortBy<K, V>(this V[] array, K[] keys, IComparer<K> comparer)
	{
		array.GuardNotNull("array");
		keys.GuardNotNull("keys");
		comparer.GuardNotNull("comparer");
		array.GuardSameArray(keys, "array");
		Array.Sort(keys, array, comparer);
		return array;
	}

	/// <summary>
	/// 按照指定的键数组对当前数组进行排序
	/// </summary>
	/// <typeparam name="K">键数组的元素类型</typeparam>
	/// <typeparam name="V">当前数组的元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="keys">键数组</param>
	/// <param name="comparison">键数组元素比较方法</param>
	/// <returns>排序后的值数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="keys" /> 为空；或者 <paramref name="comparison" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前数组和 <paramref name="keys" /> 不相同。</exception>
	public static V[] SortBy<K, V>(this V[] array, K[] keys, Func<K, K, int> comparison)
	{
		comparison.GuardNotNull("comparison");
		return array.SortBy(keys, comparison.ToComparer());
	}

	/// <summary>
	/// 按照指定的键数组对当前数组进行排序
	/// </summary>
	/// <typeparam name="K">键数组的元素类型</typeparam>
	/// <typeparam name="V">当前数组的元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="keys">键数组</param>
	/// <param name="start">排序范围的起始索引</param>
	/// <returns>排序后的值数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="keys" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前数组和 <paramref name="keys" /> 不相同。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	public static V[] SortBy<K, V>(this V[] array, K[] keys, int start)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.SortBy(keys, start, array.Length - start, Comparer<K>.Default);
	}

	/// <summary>
	/// 按照指定的键数组 <paramref name="keys" /> 对当前数组进行排序
	/// </summary>
	/// <typeparam name="K">键数组的元素类型</typeparam>
	/// <typeparam name="V">当前数组的元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="keys">键数组</param>
	/// <param name="start">排序范围的起始索引</param>
	/// <param name="comparer">键数组元素比较器</param>
	/// <returns>排序后的值数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="keys" /> 为空；或者 <paramref name="comparer" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前数组和 <paramref name="keys" /> 不相同。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	public static V[] SortBy<K, V>(this V[] array, K[] keys, int start, IComparer<K> comparer)
	{
		array.GuardNotNull("array");
		keys.GuardNotNull("keys");
		comparer.GuardNotNull("comparer");
		array.GuardSameArray(keys, "array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		Array.Sort(keys, array, start, array.Length - start, comparer);
		return array;
	}

	/// <summary>
	/// 按照指定的键数组 <paramref name="keys" /> 对当前数组进行排序
	/// </summary>
	/// <typeparam name="K">键数组的元素类型</typeparam>
	/// <typeparam name="V">当前数组的元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="keys">键数组</param>
	/// <param name="start">排序范围的起始索引</param>
	/// <param name="comparison">键数组元素比较方法</param>
	/// <returns>排序后的值数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="keys" /> 为空；或者 <paramref name="comparison" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前数组和 <paramref name="keys" /> 不相同。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	public static V[] SortBy<K, V>(this V[] array, K[] keys, int start, Func<K, K, int> comparison)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.SortBy(keys, start, array.Length - start, comparison);
	}

	/// <summary>
	/// 按照指定的键数组对当前数组进行排序
	/// </summary>
	/// <typeparam name="K">键数组的元素类型</typeparam>
	/// <typeparam name="V">当前数组的元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="keys">键数组</param>
	/// <param name="start">排序范围的起始索引</param>
	/// <param name="count">排序范围内的元素数</param>
	/// <returns>排序后的值数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="keys" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前数组和 <paramref name="keys" /> 不相同。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组从 <paramref name="start" /> 位置开始剩余的元素数量。</exception>
	public static V[] SortBy<K, V>(this V[] array, K[] keys, int start, int count)
	{
		array.GuardNotNull("array");
		return array.SortBy(keys, start, count, Comparer<K>.Default);
	}

	/// <summary>
	/// 按照指定的键数组 <paramref name="keys" /> 对当前数组进行排序
	/// </summary>
	/// <typeparam name="K">键数组的元素类型</typeparam>
	/// <typeparam name="V">当前数组的元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="keys">键数组</param>
	/// <param name="start">排序范围的起始索引</param>
	/// <param name="count">排序范围内的元素数</param>
	/// <param name="comparer">键数组元素比较器</param>
	/// <returns>排序后的值数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="keys" /> 为空；或者 <paramref name="comparer" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前数组和 <paramref name="keys" /> 不相同。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组从 <paramref name="start" /> 位置开始剩余的元素数量。</exception>
	public static V[] SortBy<K, V>(this V[] array, K[] keys, int start, int count, IComparer<K> comparer)
	{
		array.GuardNotNull("array");
		keys.GuardNotNull("keys");
		comparer.GuardNotNull("comparer");
		array.GuardSameArray(keys, "array");
		start.GuardIndexRange(0, array.Length - 1, "start");
		count.GuardBetween(0, array.Length - start, "count");
		Array.Sort(keys, array, start, count, comparer);
		return array;
	}

	/// <summary>
	/// 按照指定的键数组 <paramref name="keys" /> 对当前数组进行排序
	/// </summary>
	/// <typeparam name="K">键数组的元素类型</typeparam>
	/// <typeparam name="V">当前数组的元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="keys">键数组</param>
	/// <param name="start">排序范围的起始索引</param>
	/// <param name="count">排序范围内的元素数</param>
	/// <param name="comparison">键数组元素比较方法</param>
	/// <returns>排序后的值数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="keys" /> 为空；或者 <paramref name="comparison" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前数组和 <paramref name="keys" /> 不相同。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组从 <paramref name="start" /> 位置开始剩余的元素数量。</exception>
	public static V[] SortBy<K, V>(this V[] array, K[] keys, int start, int count, Func<K, K, int> comparison)
	{
		array.GuardNotNull("array");
		comparison.GuardNotNull("comparison");
		return array.SortBy(keys, start, count, comparison.ToComparer());
	}

	/// <summary>
	/// 按照指定的键数组对当前数组进行排序
	/// </summary>
	/// <typeparam name="K">键数组的元素类型</typeparam>
	/// <typeparam name="V">当前数组的元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="keys">键数组</param>
	/// <param name="start">排序范围的起始索引</param>
	/// <returns>排序后的值数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="keys" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前数组和 <paramref name="keys" /> 不相同。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	public static V[] SortBy<K, V>(this V[] array, K[] keys, long start)
	{
		return array.SortBy(keys, start, Comparer<K>.Default.Compare);
	}

	/// <summary>
	/// 按照指定的键数组 <paramref name="keys" /> 对当前数组进行排序
	/// </summary>
	/// <typeparam name="K">键数组的元素类型</typeparam>
	/// <typeparam name="V">当前数组的元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="keys">键数组</param>
	/// <param name="start">排序范围的起始索引</param>
	/// <param name="comparer">键数组元素比较器</param>
	/// <returns>排序后的值数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="keys" /> 为空；或者 <paramref name="comparer" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前数组和 <paramref name="keys" /> 不相同。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	public static V[] SortBy<K, V>(this V[] array, K[] keys, long start, IComparer<K> comparer)
	{
		comparer.GuardNotNull("comparer");
		return array.SortBy(keys, start, comparer.Compare);
	}

	/// <summary>
	/// 按照指定的键数组 <paramref name="keys" /> 对当前数组进行排序
	/// </summary>
	/// <typeparam name="K">键数组的元素类型</typeparam>
	/// <typeparam name="V">当前数组的元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="keys">键数组</param>
	/// <param name="start">排序范围的起始索引</param>
	/// <param name="comparison">键数组元素比较方法</param>
	/// <returns>排序后的值数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="keys" /> 为空；或者 <paramref name="comparison" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前数组和 <paramref name="keys" /> 不相同。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	public static V[] SortBy<K, V>(this V[] array, K[] keys, long start, Func<K, K, int> comparison)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		comparison.GuardNotNull("comparison");
		return array.SortBy(keys, start, array.LongLength - start, comparison);
	}

	/// <summary>
	/// 按照指定的键数组对当前数组进行排序
	/// </summary>
	/// <typeparam name="K">键数组的元素类型</typeparam>
	/// <typeparam name="V">当前数组的元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="keys">键数组</param>
	/// <param name="start">排序范围的起始索引</param>
	/// <param name="count">排序范围内的元素数</param>
	/// <returns>排序后的值数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="keys" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前数组和 <paramref name="keys" /> 不相同。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组从 <paramref name="start" /> 位置开始剩余的元素数量。</exception>
	public static V[] SortBy<K, V>(this V[] array, K[] keys, long start, long count)
	{
		return array.SortBy(keys, start, count, Comparer<K>.Default.Compare);
	}

	/// <summary>
	/// 按照指定的键数组 <paramref name="keys" /> 对当前数组进行排序
	/// </summary>
	/// <typeparam name="K">键数组的元素类型</typeparam>
	/// <typeparam name="V">当前数组的元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="keys">键数组</param>
	/// <param name="start">排序范围的起始索引</param>
	/// <param name="count">排序范围内的元素数</param>
	/// <param name="comparer">键数组元素比较器</param>
	/// <returns>排序后的值数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="keys" /> 为空；或者 <paramref name="comparer" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前数组和 <paramref name="keys" /> 不相同。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组从 <paramref name="start" /> 位置开始剩余的元素数量。</exception>
	public static V[] SortBy<K, V>(this V[] array, K[] keys, long start, long count, IComparer<K> comparer)
	{
		comparer.GuardNotNull("comparer");
		return array.SortBy(keys, start, count, comparer.Compare);
	}

	/// <summary>
	/// 按照指定的键数组 <paramref name="keys" /> 对当前数组进行排序
	/// </summary>
	/// <typeparam name="K">键数组的元素类型</typeparam>
	/// <typeparam name="V">当前数组的元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="keys">键数组</param>
	/// <param name="start">排序范围的起始索引</param>
	/// <param name="count">排序范围内的元素数</param>
	/// <param name="comparison">键数组元素比较方法</param>
	/// <returns>排序后的值数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="keys" /> 为空；或者 <paramref name="comparison" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前数组和 <paramref name="keys" /> 不相同。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于当前数组从 <paramref name="start" /> 位置开始剩余的元素数量。</exception>
	public static V[] SortBy<K, V>(this V[] array, K[] keys, long start, long count, Func<K, K, int> comparison)
	{
		comparison.GuardNotNull("comparison");
		return array.As<Array>().SortBy(keys.As<Array>(), start, count, (object x, object y) => comparison((K)x, (K)y)).As<V[]>();
	}

	/// <summary>
	/// 将当前二维数组分解为数组的数组
	/// </summary>
	/// <typeparam name="T">数组元素类型</typeparam>
	/// <param name="array">当前二维数组</param>
	/// <returns>分解生成的二维数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前二维数组为空。</exception>
	public static T[][] Split<T>(this T[,] array)
	{
		array.GuardNotNull("array");
		int d1 = array.GetLength(0);
		int d2 = array.GetLength(1);
		T[][] result = new T[d1][];
		for (int i = 0; i < d1; i++)
		{
			T[] subArray = new T[d2];
			for (int j = 0; j < d2; j++)
			{
				subArray[j] = array[i, j];
			}
			result[i] = subArray;
		}
		return result;
	}

	/// <summary>
	/// 将当前三维数组分解为数组的数组的数组
	/// </summary>
	/// <typeparam name="T">数组元素类型</typeparam>
	/// <param name="array">当前三维数组</param>
	/// <returns>分解生成的三维数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前二维数组为空。</exception>
	public static T[][][] Split<T>(this T[,,] array)
	{
		array.GuardNotNull("array");
		int d1 = array.GetLength(0);
		int d2 = array.GetLength(1);
		int d3 = array.GetLength(2);
		T[][][] result = new T[d1][][];
		for (int i = 0; i < d1; i++)
		{
			T[][] subArray1 = new T[d2][];
			for (int j = 0; j < d2; j++)
			{
				T[] subArray2 = new T[d3];
				for (int k = 0; k < d3; k++)
				{
					subArray2[k] = array[i, j, k];
				}
				subArray1[j] = subArray2;
			}
			result[i] = subArray1;
		}
		return result;
	}

	/// <summary>
	/// 将当前数组转换为指定类型的一维数组
	/// </summary>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <returns>转换后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static T[] ToArray<T>(this Array array)
	{
		array.GuardNotNull("array");
		return array.ToArray((object x, int i) => (T)x);
	}

	/// <summary>
	/// 将当前数组转换为指定类型的一维数组
	/// </summary>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluation" /> 为空。</exception>
	public static T[] ToArray<T>(this Array array, Func<object, T> evaluation)
	{
		array.GuardNotNull("array");
		evaluation.GuardNotNull("evaluation");
		return array.ToArray((object x, int i) => evaluation(x));
	}

	/// <summary>
	/// 将当前数组转换为指定类型的一维数组
	/// </summary>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluation" /> 为空。</exception>
	public static T[] ToArray<T>(this Array array, Func<object, int, T> evaluation)
	{
		array.GuardNotNull("array");
		evaluation.GuardNotNull("evaluation");
		T[] result = new T[array.Length];
		int index = 0;
		foreach (object item in array)
		{
			result[index] = evaluation(item, index);
			index++;
		}
		return result;
	}

	/// <summary>
	/// 将当前数组转换为指定类型的一维数组
	/// </summary>
	/// <typeparam name="T">目标数据的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">数组元素筛选方法</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	public static T[] ToArray<T>(this Array array, Func<object, bool> predicate, Func<object, T> evaluation)
	{
		return array.ToList(predicate, evaluation).ToArray();
	}

	/// <summary>
	/// 将当前数组转换为指定类型的一维数组
	/// </summary>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">数组元素筛选方法</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	public static T[] ToArray<T>(this Array array, Func<object, int, bool> predicate, Func<object, int, T> evaluation)
	{
		return array.ToList(predicate, evaluation).ToArray();
	}

	/// <summary>
	/// 将当前数组转换为指定类型的一维数组
	/// </summary>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始转换的索引位置</param>
	/// <param name="predicate">数组元素筛选方法</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	public static T[] ToArray<T>(this Array array, int start, Func<object, bool> predicate, Func<object, T> evaluation)
	{
		return array.ToList(start, predicate, evaluation).ToArray();
	}

	/// <summary>
	/// 将当前数组转换为指定类型的一维数组
	/// </summary>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始转换的索引位置</param>
	/// <param name="predicate">数组元素筛选方法</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	public static T[] ToArray<T>(this Array array, int start, Func<object, int, bool> predicate, Func<object, int, T> evaluation)
	{
		return array.ToList(start, predicate, evaluation).ToArray();
	}

	/// <summary>
	/// 将当前数组转换为指定类型的一维数组
	/// </summary>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始转换的索引位置</param>
	/// <param name="count">转换的元素数量</param>
	/// <param name="predicate">数组元素筛选方法</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static T[] ToArray<T>(this Array array, int start, int count, Func<object, bool> predicate, Func<object, T> evaluation)
	{
		return array.ToList(start, count, predicate, evaluation).ToArray();
	}

	/// <summary>
	/// 将当前数组转换为指定类型的一维数组
	/// </summary>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始转换的索引位置</param>
	/// <param name="count">转换的元素数量</param>
	/// <param name="predicate">数组元素筛选方法</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static T[] ToArray<T>(this Array array, int start, int count, Func<object, int, bool> predicate, Func<object, int, T> evaluation)
	{
		return array.ToList(start, count, predicate, evaluation).ToArray();
	}

	/// <summary>
	/// 将当前数组转换为指定类型的一维数组
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <returns>转换后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static T[] ToArray<S, T>(this S[] array)
	{
		array.GuardNotNull("array");
		return array.ToArray((S x, int i) => x.As<T>());
	}

	/// <summary>
	/// 将当前数组转换为指定类型的一维数组
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluation" /> 为空。</exception>
	public static T[] ToArray<S, T>(this S[] array, Func<S, T> evaluation)
	{
		array.GuardNotNull("array");
		evaluation.GuardNotNull("evaluation");
		return array.ToArray((S x, int i) => evaluation(x));
	}

	/// <summary>
	/// 将当前数组转换为指定类型的一维数组
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluation" /> 为空。</exception>
	public static T[] ToArray<S, T>(this S[] array, Func<S, int, T> evaluation)
	{
		array.GuardNotNull("array");
		evaluation.GuardNotNull("evaluation");
		T[] result = new T[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			result[i] = evaluation(array[i], i);
		}
		return result;
	}

	/// <summary>
	/// 将当前数组转换为指定类型的一维数组
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">目标数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">数组元素筛选方法</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	public static T[] ToArray<S, T>(this S[] array, Func<S, bool> predicate, Func<S, T> evaluation)
	{
		return array.ToList(predicate, evaluation).ToArray();
	}

	/// <summary>
	/// 将当前数组转换为指定类型的一维数组
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">目标数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">数组元素筛选方法</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	public static T[] ToArray<S, T>(this S[] array, Func<S, int, bool> predicate, Func<S, int, T> evaluation)
	{
		return array.ToList(predicate, evaluation).ToArray();
	}

	/// <summary>
	/// 将当前数组转换为指定类型的一维数组
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">目标数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始转换的索引位置</param>
	/// <param name="predicate">数组元素筛选方法</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	public static T[] ToArray<S, T>(this S[] array, int start, Func<S, bool> predicate, Func<S, T> evaluation)
	{
		return array.ToList(start, predicate, evaluation).ToArray();
	}

	/// <summary>
	/// 将当前数组转换为指定类型的一维数组
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">目标数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始转换的索引位置</param>
	/// <param name="predicate">数组元素筛选方法</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	public static T[] ToArray<S, T>(this S[] array, int start, Func<S, int, bool> predicate, Func<S, int, T> evaluation)
	{
		return array.ToList(start, predicate, evaluation).ToArray();
	}

	/// <summary>
	/// 将当前数组转换为指定类型的一维数组
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">目标数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始转换的索引位置</param>
	/// <param name="count">转换的元素数量</param>
	/// <param name="predicate">数组元素筛选方法</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static T[] ToArray<S, T>(this S[] array, int start, int count, Func<S, bool> predicate, Func<S, T> evaluation)
	{
		return array.ToList(start, count, predicate, evaluation).ToArray();
	}

	/// <summary>
	/// 将当前数组转换为指定类型的一维数组
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">目标数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始转换的索引位置</param>
	/// <param name="count">转换的元素数量</param>
	/// <param name="predicate">数组元素筛选方法</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static T[] ToArray<S, T>(this S[] array, int start, int count, Func<S, int, bool> predicate, Func<S, int, T> evaluation)
	{
		return array.ToList(start, count, predicate, evaluation).ToArray();
	}

	/// <summary>
	/// 将当前数组转换为指定类型的一维数组
	/// </summary>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <returns>转换后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static T[] ToLongArray<T>(this Array array)
	{
		array.GuardNotNull("array");
		return array.ToLongArray((object x, long i) => (T)x);
	}

	/// <summary>
	/// 将当前数组转换为指定类型的一维数组
	/// </summary>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluation" /> 为空。</exception>
	public static T[] ToLongArray<T>(this Array array, Func<object, long, T> evaluation)
	{
		array.GuardNotNull("array");
		evaluation.GuardNotNull("evaluation");
		T[] result = new T[array.Length];
		long index = 0L;
		foreach (object item in array)
		{
			result[index] = evaluation(item, index);
			index++;
		}
		return result;
	}

	/// <summary>
	/// 将当前数组转换为指定类型的一维数组
	/// </summary>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始转换的索引位置</param>
	/// <param name="predicate">数组元素筛选方法</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	public static T[] ToLongArray<T>(this Array array, long start, Func<object, bool> predicate, Func<object, T> evaluation)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.ToLongArray(start, array.LongLength - start, predicate, evaluation);
	}

	/// <summary>
	/// 将当前数组转换为指定类型的一维数组
	/// </summary>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始转换的索引位置</param>
	/// <param name="predicate">数组元素筛选方法</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	public static T[] ToLongArray<T>(this Array array, long start, Func<object, long, bool> predicate, Func<object, long, T> evaluation)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.ToLongArray(start, array.LongLength - start, predicate, evaluation);
	}

	/// <summary>
	/// 将当前数组转换为指定类型的一维数组
	/// </summary>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始转换的索引位置</param>
	/// <param name="count">转换的元素数量</param>
	/// <param name="predicate">数组元素筛选方法</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static T[] ToLongArray<T>(this Array array, long start, long count, Func<object, bool> predicate, Func<object, T> evaluation)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		evaluation.GuardNotNull("evaluation");
		return array.ToLongArray(start, count, (object x, long i) => predicate(x), (object x, long i) => evaluation(x));
	}

	/// <summary>
	/// 将当前数组转换为指定类型的一维数组
	/// </summary>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始转换的索引位置</param>
	/// <param name="count">转换的元素数量</param>
	/// <param name="predicate">数组元素筛选方法</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static T[] ToLongArray<T>(this Array array, long start, long count, Func<object, long, bool> predicate, Func<object, long, T> evaluation)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		evaluation.GuardNotNull("evaluation");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		count.GuardBetween(0L, array.LongLength - start, "count");
		return array.OfType<object>().SkipLong(start).TakeLong(count)
			.Where(predicate)
			.Select(evaluation)
			.ToArray();
	}

	/// <summary>
	/// 将当前数组转换为指定类型的一维数组
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <returns>转换后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static T[] ToLongArray<S, T>(this S[] array)
	{
		array.GuardNotNull("array");
		return array.ToLongArray((S x, long i) => x.As<T>());
	}

	/// <summary>
	/// 将当前数组转换为指定类型的一维数组
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluation" /> 为空。</exception>
	public static T[] ToLongArray<S, T>(this S[] array, Func<S, long, T> evaluation)
	{
		array.GuardNotNull("array");
		evaluation.GuardNotNull("evaluation");
		T[] result = new T[array.Length];
		for (long i = 0L; i < array.Length; i++)
		{
			result[i] = evaluation(array[i], i);
		}
		return result;
	}

	/// <summary>
	/// 将当前数组转换为指定类型的一维数组
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">目标数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始转换的索引位置</param>
	/// <param name="predicate">数组元素筛选方法</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	public static T[] ToLongArray<S, T>(this S[] array, long start, Func<S, bool> predicate, Func<S, T> evaluation)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.ToLongArray(start, array.LongLength - start, predicate, evaluation);
	}

	/// <summary>
	/// 将当前数组转换为指定类型的一维数组
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">目标数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始转换的索引位置</param>
	/// <param name="predicate">数组元素筛选方法</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	public static T[] ToLongArray<S, T>(this S[] array, long start, Func<S, long, bool> predicate, Func<S, long, T> evaluation)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		return array.ToLongArray(start, array.LongLength - start, predicate, evaluation);
	}

	/// <summary>
	/// 将当前数组转换为指定类型的一维数组
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">目标数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始转换的索引位置</param>
	/// <param name="count">转换的元素数量</param>
	/// <param name="predicate">数组元素筛选方法</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static T[] ToLongArray<S, T>(this S[] array, long start, long count, Func<S, bool> predicate, Func<S, T> evaluation)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		evaluation.GuardNotNull("evaluation");
		return array.ToLongArray(start, count, (S x, long i) => predicate(x), (S x, long i) => evaluation(x));
	}

	/// <summary>
	/// 将当前数组转换为指定类型的一维数组
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">目标数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始转换的索引位置</param>
	/// <param name="count">转换的元素数量</param>
	/// <param name="predicate">数组元素筛选方法</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static T[] ToLongArray<S, T>(this S[] array, long start, long count, Func<S, long, bool> predicate, Func<S, long, T> evaluation)
	{
		array.GuardNotNull("array");
		start.GuardIndexRange(0L, array.LongLength - 1, "start");
		count.GuardBetween(0L, array.LongLength - start, "count");
		predicate.GuardNotNull("predicate");
		evaluation.GuardNotNull("evaluation");
		return array.SkipLong(start).TakeLong(count).Where(predicate)
			.Select(evaluation)
			.ToArray();
	}

	/// <summary>
	/// 将二维数组转换为数组的列表
	/// </summary>
	/// <typeparam name="T">数组元素类型</typeparam>
	/// <param name="array">当前二维数组</param>
	/// <returns>转换后的数组列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static List<T[]> ToArrayList<T>(this T[,] array)
	{
		array.GuardNotNull("array");
		List<T[]> list = new List<T[]>(array.GetLength(0));
		T[][] array2 = array.Split();
		foreach (T[] subArray in array2)
		{
			list.Add(subArray);
		}
		return list;
	}

	/// <summary>
	/// 将当前数组转换为 <see cref="T:System.Collections.Generic.List`1" /> 列表对象
	/// </summary>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">待转换的当前数组</param>
	/// <returns>转换后的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static List<T> ToList<T>(this Array array)
	{
		array.GuardNotNull("array");
		return (from x in array.OfType<object>()
			select x.As<T>()).ToList();
	}

	/// <summary>
	/// 将当前数组转换为 <see cref="T:System.Collections.Generic.List`1" /> 列表对象
	/// </summary>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">待转换的当前数组</param>
	/// <param name="evaluator">数组元素转换方法</param>
	/// <returns>转换后的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluator" /> 为空。</exception>
	public static List<T> ToList<T>(this Array array, Func<object, T> evaluator)
	{
		array.GuardNotNull("array");
		evaluator.GuardNotNull("evaluator");
		return array.OfType<object>().Select(evaluator).ToList();
	}

	/// <summary>
	/// 将当前数组转换为 <see cref="T:System.Collections.Generic.List`1" /> 列表对象
	/// </summary>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">待转换的当前数组</param>
	/// <param name="evaluator">数组元素转换方法</param>
	/// <returns>转换后的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluator" /> 为空。</exception>
	public static List<T> ToList<T>(this Array array, Func<object, int, T> evaluator)
	{
		array.GuardNotNull("array");
		evaluator.GuardNotNull("evaluator");
		return array.OfType<object>().Select(evaluator).ToList();
	}

	/// <summary>
	/// 将当前数组转换为 <see cref="T:System.Collections.Generic.List`1" /> 列表对象
	/// </summary>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">待转换的当前数组</param>
	/// <param name="predicate">数组元素筛选方法</param>
	/// <param name="evaluator">数组元素转换方法</param>
	/// <returns>转换后的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluator" /> 为空。</exception>
	public static List<T> ToList<T>(this Array array, Func<object, bool> predicate, Func<object, T> evaluator)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		evaluator.GuardNotNull("evaluator");
		return array.ToList(0, array.Length, predicate, evaluator);
	}

	/// <summary>
	/// 将当前数组转换为 <see cref="T:System.Collections.Generic.List`1" /> 列表对象
	/// </summary>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">数组元素筛选方法</param>
	/// <param name="evaluator">数组元素转换方法</param>
	/// <returns>转换后的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluator" /> 为空。</exception>
	public static List<T> ToList<T>(this Array array, Func<object, int, bool> predicate, Func<object, int, T> evaluator)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		evaluator.GuardNotNull("evaluator");
		return array.ToList(0, array.Length, predicate, evaluator);
	}

	/// <summary>
	/// 将当前数组转换为 <see cref="T:System.Collections.Generic.List`1" /> 列表对象
	/// </summary>
	/// <typeparam name="T">列表元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">转换的起始索引位置</param>
	/// <param name="predicate">数组元素筛选方法</param>
	/// <param name="evaluator">数组元素转换方法</param>
	/// <returns>转换后的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	public static List<T> ToList<T>(this Array array, int start, Func<object, bool> predicate, Func<object, T> evaluator)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		evaluator.GuardNotNull("evaluator");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.ToList(start, array.Length - start, predicate, evaluator);
	}

	/// <summary>
	/// 将当前数组转换为 <see cref="T:System.Collections.Generic.List`1" /> 列表对象
	/// </summary>
	/// <typeparam name="T">列表元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">转换的起始索引位置</param>
	/// <param name="predicate">数组元素筛选方法</param>
	/// <param name="evaluator">数组元素转换方法</param>
	/// <returns>转换后的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	public static List<T> ToList<T>(this Array array, int start, Func<object, int, bool> predicate, Func<object, int, T> evaluator)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		evaluator.GuardNotNull("evaluator");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.ToList(start, array.Length - start, predicate, evaluator);
	}

	/// <summary>
	/// 将当前数组转换为 <see cref="T:System.Collections.Generic.List`1" /> 列表对象
	/// </summary>
	/// <typeparam name="T">列表元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">转换的起始索引位置</param>
	/// <param name="count">转换的元素个数</param>
	/// <param name="predicate">数组元素筛选方法</param>
	/// <param name="evaluator">数组元素转换方法</param>
	/// <returns>转换后的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static List<T> ToList<T>(this Array array, int start, int count, Func<object, bool> predicate, Func<object, T> evaluator)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		evaluator.GuardNotNull("evaluator");
		return array.ToList(start, count, (object x, int i) => predicate(x), (object x, int i) => evaluator(x));
	}

	/// <summary>
	/// 将当前数组转换为 <see cref="T:System.Collections.Generic.List`1" /> 列表对象
	/// </summary>
	/// <typeparam name="T">列表元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">转换的起始索引位置</param>
	/// <param name="count">转换的元素个数</param>
	/// <param name="predicate">数组元素筛选方法</param>
	/// <param name="evaluator">数组元素转换方法</param>
	/// <returns>转换后的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static List<T> ToList<T>(this Array array, int start, int count, Func<object, int, bool> predicate, Func<object, int, T> evaluator)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		evaluator.GuardNotNull("evaluator");
		start.GuardIndexRange(0, array.Length - 1, "start");
		count.GuardBetween(0, array.Length - start, "count");
		List<T> list = new List<T>();
		int index = start;
		foreach (object item in array.OfType<object>().Skip(start))
		{
			if (count-- <= 0)
			{
				break;
			}
			if (predicate(item, index))
			{
				list.Add(evaluator(item, index));
			}
			index++;
		}
		return list;
	}

	/// <summary>
	/// 将当前数组转换为 <see cref="T:System.Collections.Generic.List`1" /> 列表对象
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">待转换的当前数组</param>
	/// <returns>转换后的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static List<T> ToList<S, T>(this S[] array)
	{
		array.GuardNotNull("array");
		return array.ToList((S x) => x.As<T>());
	}

	/// <summary>
	/// 将当前数组转换为 <see cref="T:System.Collections.Generic.List`1" /> 列表对象
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">待转换的当前数组</param>
	/// <param name="evaluator">数组元素转换方法</param>
	/// <returns>转换后的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluator" /> 为空。</exception>
	public static List<T> ToList<S, T>(this S[] array, Func<S, T> evaluator)
	{
		array.GuardNotNull("array");
		evaluator.GuardNotNull("evaluator");
		return array.ToList((S x, int i) => evaluator(x));
	}

	/// <summary>
	/// 将当前数组转换为 <see cref="T:System.Collections.Generic.List`1" /> 列表对象
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">待转换的当前数组</param>
	/// <param name="evaluator">数组元素转换方法</param>
	/// <returns>转换后的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluator" /> 为空。</exception>
	public static List<T> ToList<S, T>(this S[] array, Func<S, int, T> evaluator)
	{
		array.GuardNotNull("array");
		evaluator.GuardNotNull("evaluator");
		List<T> list = new List<T>(array.Length);
		for (int i = 0; i < array.Length; i++)
		{
			list[i] = evaluator(array[i], i);
		}
		return list;
	}

	/// <summary>
	/// 将当前数组转换为 <see cref="T:System.Collections.Generic.List`1" /> 列表对象
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">数组元素筛选方法</param>
	/// <param name="evaluator">数组元素转换方法</param>
	/// <returns>转换后的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluator" /> 为空。</exception>
	public static List<T> ToList<S, T>(this S[] array, Func<S, bool> predicate, Func<S, T> evaluator)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		evaluator.GuardNotNull("evaluator");
		return array.ToList(0, array.Length, predicate, evaluator);
	}

	/// <summary>
	/// 将当前数组转换为 <see cref="T:System.Collections.Generic.List`1" /> 列表对象
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">数组元素筛选方法</param>
	/// <param name="evaluator">数组元素转换方法</param>
	/// <returns>转换后的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluator" /> 为空。</exception>
	public static List<T> ToList<S, T>(this S[] array, Func<S, int, bool> predicate, Func<S, int, T> evaluator)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		evaluator.GuardNotNull("evaluator");
		return array.ToList(0, array.Length, predicate, evaluator);
	}

	/// <summary>
	/// 将当前数组转换为 <see cref="T:System.Collections.Generic.List`1" /> 列表对象
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始转换的位置索引</param>
	/// <param name="predicate">数组元素筛选方法</param>
	/// <param name="evaluator">数组元素转换方法</param>
	/// <returns>转换后的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	public static List<T> ToList<S, T>(this S[] array, int start, Func<S, bool> predicate, Func<S, T> evaluator)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		evaluator.GuardNotNull("evaluator");
		return array.ToList(start, (S x, int i) => predicate(x), (S x, int i) => evaluator(x));
	}

	/// <summary>
	/// 将当前数组转换为 <see cref="T:System.Collections.Generic.List`1" /> 列表对象
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始转换的位置索引</param>
	/// <param name="predicate">数组元素筛选方法</param>
	/// <param name="evaluator">数组元素转换方法</param>
	/// <returns>转换后的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	public static List<T> ToList<S, T>(this S[] array, int start, Func<S, int, bool> predicate, Func<S, int, T> evaluator)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		evaluator.GuardNotNull("evaluator");
		start.GuardIndexRange(0, array.Length - 1, "start");
		return array.ToList(start, array.Length - start, predicate, evaluator);
	}

	/// <summary>
	/// 将当前数组转换为 <see cref="T:System.Collections.Generic.List`1" /> 列表对象
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始转换的位置索引</param>
	/// <param name="count">转换的元素个数</param>
	/// <param name="predicate">数组元素筛选方法</param>
	/// <param name="evaluator">数组元素转换方法</param>
	/// <returns>转换后的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static List<T> ToList<S, T>(this S[] array, int start, int count, Func<S, bool> predicate, Func<S, T> evaluator)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		evaluator.GuardNotNull("evaluator");
		return array.ToList(start, count, (S x, int i) => predicate(x), (S x, int i) => evaluator(x));
	}

	/// <summary>
	/// 将当前数组转换为 <see cref="T:System.Collections.Generic.List`1" /> 列表对象
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始转换的位置索引</param>
	/// <param name="count">转换的元素个数</param>
	/// <param name="predicate">数组元素筛选方法</param>
	/// <param name="evaluator">数组元素转换方法</param>
	/// <returns>转换后的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static List<T> ToList<S, T>(this S[] array, int start, int count, Func<S, int, bool> predicate, Func<S, int, T> evaluator)
	{
		array.GuardNotNull("array");
		predicate.GuardNotNull("predicate");
		evaluator.GuardNotNull("evaluator");
		start.GuardIndexRange(0, array.Length - 1, "start");
		count.GuardBetween(0, array.Length - start, "count");
		List<T> list = new List<T>();
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			if (predicate(array[i], i))
			{
				list.Add(evaluator(array[i], i));
			}
		}
		return list;
	}
}
