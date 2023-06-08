#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Richfit.Garnet.Common.Properties;

namespace Richfit.Garnet.Common.Utility;

/// <summary>
/// <see cref="T:System.Array" /> 辅助类
/// </summary>
public static class ArrayHelper
{
	/// <summary>
	/// 将当前数组转换为 <see cref="T:System.Collections.IEnumerable" /> 接口的枚举器对象
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <returns>枚举器对象</returns>
	/// <exception cref="T:System.InvalidCastException">当前数组无法转换为 <see cref="T:System.Collections.IEnumerable" /> 接口对象。</exception>
	public static IEnumerable AsEnumerable(Array array)
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
	public static IEnumerable<T> AsEnumerable<T>(Array array)
	{
		return (IEnumerable<T>)array;
	}

	/// <summary>
	/// 将当前数组对象转换为 <see cref="T:System.Collections.IList" /> 接口对象
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <returns>转换后的列表对象</returns>
	/// <exception cref="T:System.InvalidCastException">当前数组无法转换为 <see cref="T:System.Collections.IList" /> 接口对象。</exception>
	public static IList AsList(Array array)
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
	public static IList<T> AsList<T>(Array array)
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
	public static IList<T> AsList<T>(T[] array)
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
	public static int BinarySearch(Array array, object value)
	{
		Guard.AssertNotNull(array, "array");
		return BinarySearch(array, 0, array.Length, value);
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
	public static int BinarySearch(Array array, object value, IComparer comparer)
	{
		Guard.AssertNotNull(array, "array");
		return BinarySearch(array, 0, array.Length, value, comparer);
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
	public static int BinarySearch(Array array, object value, Func<object, object, int> comparison)
	{
		Guard.AssertNotNull(array, "array");
		return BinarySearch(array, 0, array.Length, value, comparison);
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
	public static int BinarySearch(Array array, int start, object value)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return BinarySearch(array, start, array.Length - start, value);
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
	public static int BinarySearch(Array array, int start, object value, IComparer comparer)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return BinarySearch(array, start, array.Length - start, value, comparer);
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
	public static int BinarySearch(Array array, int start, object value, Func<object, object, int> comparison)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return BinarySearch(array, start, array.Length - start, value, comparison);
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
	public static int BinarySearch(Array array, int start, int count, object value)
	{
		return BinarySearch(array, start, count, value, Comparer.Default.Compare);
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
	public static int BinarySearch(Array array, int start, int count, object value, IComparer comparer)
	{
		Guard.AssertNotNull(comparer, "comparer");
		return BinarySearch(array, start, count, value, comparer.Compare);
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
	public static int BinarySearch(Array array, int start, int count, object value, Func<object, object, int> comparison)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(comparison, "comparison");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		Guard.AssertBetween(count, 0, array.Length - start, "count");
		if (count > 0)
		{
			int[] weights = GetWeight(array);
			int i = start;
			int j = start + count - 1;
			while (i <= j)
			{
				int median = i + j >> 1;
				int result = comparison(GetValue(array, median, weights), value);
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
	public static long BinarySearch(Array array, long start, object value)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return BinarySearch(array, start, array.Length - start, value);
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
	public static long BinarySearch(Array array, long start, object value, IComparer comparer)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return BinarySearch(array, start, array.Length - start, value, comparer);
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
	public static long BinarySearch(Array array, long start, object value, Func<object, object, int> comparison)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return BinarySearch(array, start, array.Length - start, value, comparison);
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
	public static long BinarySearch(Array array, long start, long count, object value)
	{
		return BinarySearch(array, start, count, value, Comparer.Default.Compare);
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
	public static long BinarySearch(Array array, long start, long count, object value, IComparer comparer)
	{
		Guard.AssertNotNull(comparer, "comparer");
		return BinarySearch(array, start, count, value, comparer.Compare);
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
	public static long BinarySearch(Array array, long start, long count, object value, Func<object, object, int> comparison)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(comparison, "comparison");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		Guard.AssertBetween(count, 0L, array.LongLength - start, "count");
		if (count > 0)
		{
			long[] weights = GetLongWeight(array);
			long i = start;
			long j = start + count - 1;
			while (i <= j)
			{
				long median = i + j >> 1;
				int result = comparison(GetValue(array, median, weights), value);
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
	public static int BinarySearch<T>(T[] array, T value)
	{
		Guard.AssertNotNull(array, "array");
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
	public static int BinarySearch<T>(T[] array, T value, IComparer<T> comparer)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(comparer, "comparer");
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
	public static int BinarySearch<T>(T[] array, T value, Func<T, T, int> comparison)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(comparison, "comparison");
		return Array.BinarySearch(array, value, ConvertHelper.ToComparer(comparison));
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
	public static int BinarySearch<T>(T[] array, int start, T value)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
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
	public static int BinarySearch<T>(T[] array, int start, T value, IComparer<T> comparer)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(comparer, "comparer");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
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
	public static int BinarySearch<T>(T[] array, int start, T value, Func<T, T, int> comparison)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(comparison, "comparison");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return Array.BinarySearch(array, start, array.Length - start, value, ConvertHelper.ToComparer(comparison));
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
	public static int BinarySearch<T>(T[] array, int start, int count, T value)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		Guard.AssertBetween(count, 0, array.Length - start, "count");
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
	public static int BinarySearch<T>(T[] array, int start, int count, T value, IComparer<T> comparer)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(comparer, "comparer");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		Guard.AssertBetween(count, 0, array.Length - start, "count");
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
	public static int BinarySearch<T>(T[] array, int start, int count, T value, Func<T, T, int> comparison)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(comparison, "comparison");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		Guard.AssertBetween(count, 0, array.Length - start, "count");
		return Array.BinarySearch(array, start, count, value, ConvertHelper.ToComparer(comparison));
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
	public static long BinarySearch<T>(T[] array, long start, T value)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return BinarySearch(array, start, array.LongLength - start, value);
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
	public static long BinarySearch<T>(T[] array, long start, T value, IComparer<T> comparer)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(comparer, "comparer");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return BinarySearch(array, start, array.LongLength - start, value, comparer);
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
	public static long BinarySearch<T>(T[] array, long start, T value, Func<T, T, int> comparison)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(comparison, "comparison");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return BinarySearch(array, start, array.LongLength - start, value, comparison);
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
	public static long BinarySearch<T>(T[] array, long start, long count, T value)
	{
		Guard.AssertNotNull(array, "array");
		return BinarySearch(array, start, count, value, Comparer<T>.Default.Compare);
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
	public static long BinarySearch<T>(T[] array, long start, long count, T value, IComparer<T> comparer)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(comparer, "comparer");
		return BinarySearch(array, start, count, value, comparer.Compare);
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
	public static long BinarySearch<T>(T[] array, long start, long count, T value, Func<T, T, int> comparison)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(comparison, "comparison");
		return BinarySearch(array, start, count, value, (T x, T y) => comparison(x, y));
	}

	/// <summary>
	/// 清空当前数组，将数组元素设置为其类型的默认值；当前数组可以是一维或者多维数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <returns>处理后的当前数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static Array Clear(Array array)
	{
		Guard.AssertNotNull(array, "array");
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
	public static Array Clear(Array array, int start)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
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
	public static Array Clear(Array array, int start, int count)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		Guard.AssertBetween(count, 0, array.Length - start, "count");
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
	public static Array Clear(Array array, long start)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return Clear(array, start, array.LongLength - start);
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
	public static Array Clear(Array array, long start, long count)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		Guard.AssertBetween(count, 0L, array.LongLength - start, "count");
		long[] weight = GetLongWeight(array);
		long end = start + count;
		for (long i = start; i < end; i++)
		{
			SetValue(array, TypeHelper.CreateDefault(GetElementType(array)), i, weight);
		}
		return array;
	}

	/// <summary>
	/// 清空当前数组，将数组元素设置为其类型的默认值
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <returns>处理后的当前数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static T[] Clear<T>(T[] array)
	{
		Guard.AssertNotNull(array, "array");
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
	public static T[] Clear<T>(T[] array, int start)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
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
	public static T[] Clear<T>(T[] array, int start, int count)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		Guard.AssertBetween(count, 0, array.Length - start, "count");
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
	public static T[] Clear<T>(T[] array, long start)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return Clear(array, start, array.LongLength - start);
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
	public static T[] Clear<T>(T[] array, long start, long count)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		Guard.AssertBetween(count, 0L, array.LongLength - start, "count");
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
	public static void ConstrainedCopyTo(Array source, Array target)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		Guard.AssertArrayRank(source, target.Rank, string.Empty, string.Format(Literals.MSG_ArrayRankNotSame_2, "source", "target"));
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
	public static void ConstrainedCopyTo(Array source, Array target, int targetStart)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		Guard.AssertArrayRank(source, target.Rank, string.Empty, string.Format(Literals.MSG_ArrayRankNotSame_2, "source", "target"));
		Guard.AssertIndexRange(targetStart, 0, target.Length - 1, "target start");
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
	public static void ConstrainedCopyTo(Array source, Array target, int targetStart, int copyCount)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		Guard.AssertArrayRank(source, target.Rank, string.Empty, string.Format(Literals.MSG_ArrayRankNotSame_2, "source", "target"));
		Guard.AssertIndexRange(targetStart, 0, target.Length - 1, "target start");
		Guard.AssertBetween(copyCount, 0, Math.Min(source.Length, target.Length - targetStart), "copy count");
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
	public static void ConstrainedCopyTo(Array source, int sourceStart, Array target)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		Guard.AssertArrayRank(source, target.Rank, string.Empty, string.Format(Literals.MSG_ArrayRankNotSame_2, "source", "target"));
		Guard.AssertIndexRange(sourceStart, 0, source.Length - 1, "source target");
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
	public static void ConstrainedCopyTo(Array source, int sourceStart, Array target, int targetStart)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		Guard.AssertArrayRank(source, target.Rank, string.Empty, string.Format(Literals.MSG_ArrayRankNotSame_2, "source", "target"));
		Guard.AssertIndexRange(sourceStart, 0, source.Length - 1, "source start");
		Guard.AssertIndexRange(targetStart, 0, target.Length - 1, "target start");
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
	public static void ConstrainedCopyTo(Array source, int sourceStart, Array target, int targetStart, int copyCount)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		Guard.AssertIndexRange(sourceStart, 0, source.Length - 1, "source start");
		Guard.AssertIndexRange(targetStart, 0, target.Length - 1, "target start");
		Guard.AssertBetween(copyCount, 0, Math.Min(source.Length - sourceStart, target.Length - targetStart), "copy count");
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
	public static Array ConvertAll(Array array, Func<object, object> conversion)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(conversion, "conversion");
		return Copy(array, conversion);
	}

	/// <summary>
	/// 将当前数组转换为另一种类型的数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="conversion">数组元素转换方法</param>
	/// <returns>转换后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="conversion" /> 为空。</exception>
	/// <remarks>当前数组可以为一维或者多维数组</remarks>
	public static Array ConvertAll(Array array, Func<object, int, object> conversion)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(conversion, "conversion");
		return Copy(array, conversion);
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
	public static T[] ConvertAll<S, T>(S[] array, Func<S, T> conversion)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(conversion, "conversion");
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
	public static T[] ConvertAll<S, T>(S[] array, Func<S, int, T> conversion)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(conversion, "conversion");
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
	public static Array Copy(Array array)
	{
		Guard.AssertNotNull(array, "array");
		return (Array)array.Clone();
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="copying" /> 为空。</exception>
	public static Array Copy(Array array, Func<object, object> copying)
	{
		return Copy(array, (object x) => true, copying);
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素和该元素的索引作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="copying" /> 为空。</exception>
	public static Array Copy(Array array, Func<object, int, object> copying)
	{
		return Copy(array, (object x, int i) => true, copying);
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">数组元素复制筛选条件，接收当前筛选的元素作为参数</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="copying" /> 为空。</exception>
	public static Array Copy(Array array, Func<object, bool> predicate, Func<object, object> copying)
	{
		Guard.AssertNotNull(array, "array");
		return Copy(array, 0, array.Length, predicate, copying);
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">数组元素复制筛选条件，接收当前筛选的元素和该元素的索引作为参数</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素和该元素的索引作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="copying" /> 为空。</exception>
	public static Array Copy(Array array, Func<object, int, bool> predicate, Func<object, int, object> copying)
	{
		Guard.AssertNotNull(array, "array");
		return Copy(array, 0, array.Length, predicate, copying);
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
	public static Array Copy(Array array, int start)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		int[] weights = GetWeight(array);
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
	public static Array Copy(Array array, int start, Func<object, object> copying)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return Copy(array, start, array.Length - start, (object x) => true, copying);
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
	public static Array Copy(Array array, int start, Func<object, int, object> copying)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return Copy(array, start, array.Length - start, (object x, int i) => true, copying);
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
	public static Array Copy(Array array, int start, Func<object, bool> predicate, Func<object, object> copying)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return Copy(array, start, array.Length - start, predicate, copying);
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
	public static Array Copy(Array array, int start, Func<object, int, bool> predicate, Func<object, int, object> copying)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return Copy(array, start, array.Length - start, predicate, copying);
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
	public static Array Copy(Array array, int start, int count)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		Guard.AssertBetween(count, 0, array.Length - start, "count");
		int[] weights = GetWeight(array);
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
	public static Array Copy(Array array, int start, int count, Func<object, object> copying)
	{
		Guard.AssertNotNull(array, "array");
		return Copy(array, start, count, (object x) => true, copying);
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
	public static Array Copy(Array array, int start, int count, Func<object, int, object> copying)
	{
		Guard.AssertNotNull(array, "array");
		return Copy(array, start, count, (object x, int i) => true, copying);
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
	public static Array Copy(Array array, int start, int count, Func<object, bool> predicate, Func<object, object> copying)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(copying, "copying");
		return Copy(array, start, count, (object x, int i) => predicate(x), (object x, int i) => copying(x));
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
	public static Array Copy(Array array, int start, int count, Func<object, int, bool> predicate, Func<object, int, object> copying)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(copying, "copying");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		Guard.AssertBetween(count, 0, array.Length - start, "count");
		int end = start + count;
		int[] weights = GetWeight(array);
		Array result = Array.CreateInstance(array.GetType().GetElementType(), weights);
		for (int i = start; i < end; i++)
		{
			object value = GetValue(array, i, weights);
			if (predicate(value, i))
			{
				SetValue(result, copying(value, i), i, weights);
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
	public static Array Copy(Array array, long start)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		long[] weight = GetLongWeight(array);
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
	public static Array Copy(Array array, long start, Func<object, object> copying)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return Copy(array, start, array.LongLength - start, (object x) => true, copying);
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
	public static Array Copy(Array array, long start, Func<object, long, object> copying)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return Copy(array, start, array.LongLength - start, (object x, long i) => true, copying);
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
	public static Array Copy(Array array, long start, Func<object, bool> predicate, Func<object, object> copying)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return Copy(array, start, array.LongLength - start, predicate, copying);
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
	public static Array Copy(Array array, long start, Func<object, long, bool> predicate, Func<object, long, object> copying)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return Copy(array, start, array.LongLength - start, predicate, copying);
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
	public static Array Copy(Array array, long start, long count)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		Guard.AssertBetween(count, 0L, array.LongLength - start, "count");
		long[] weights = GetLongWeight(array);
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
	public static Array Copy(Array array, long start, long count, Func<object, object> copying)
	{
		Guard.AssertNotNull(array, "array");
		return Copy(array, start, count, (object x) => true, copying);
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
	public static Array Copy(Array array, long start, long count, Func<object, long, object> copying)
	{
		Guard.AssertNotNull(array, "array");
		return Copy(array, start, count, (object x, long i) => true, copying);
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
	public static Array Copy(Array array, long start, long count, Func<object, bool> predicate, Func<object, object> copying)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(copying, "copying");
		return Copy(array, start, count, (object x, long i) => predicate(x), (object x, long i) => copying(x));
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
	public static Array Copy(Array array, long start, long count, Func<object, long, bool> predicate, Func<object, long, object> copying)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(copying, "copying");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		Guard.AssertBetween(count, 0L, array.LongLength - start, "count");
		long end = start + count;
		long[] weight = GetLongWeight(array);
		Array result = Array.CreateInstance(array.GetType().GetElementType(), weight);
		for (long i = start; i < end; i++)
		{
			object value = GetValue(array, i, weight);
			if (predicate(value, i))
			{
				SetValue(result, copying(value, i), i, weight);
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
	public static T[] Copy<T>(T[] array)
	{
		Guard.AssertNotNull(array, "array");
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
	public static T[] Copy<T>(T[] array, Func<T, T> copying)
	{
		Guard.AssertNotNull(array, "array");
		return Copy(array, 0, array.Length, copying);
	}

	/// <summary>
	/// 复制当前数组
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="copying">数组元素复制方法，接收当前筛选的元素和该元素的索引作为参数</param>
	/// <returns>复制的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="copying" /> 为空。</exception>
	public static T[] Copy<T>(T[] array, Func<T, int, T> copying)
	{
		Guard.AssertNotNull(array, "array");
		return Copy(array, 0, array.Length, copying);
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
	public static T[] Copy<T>(T[] array, Func<T, bool> predicate, Func<T, T> copying)
	{
		Guard.AssertNotNull(array, "array");
		return Copy(array, 0, array.Length, predicate, copying);
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
	public static T[] Copy<T>(T[] array, Func<T, int, bool> predicate, Func<T, int, T> copying)
	{
		Guard.AssertNotNull(array, "array");
		return Copy(array, 0, array.Length, predicate, copying);
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
	public static T[] Copy<T>(T[] array, int start)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
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
	public static T[] Copy<T>(T[] array, int start, Func<T, T> copying)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return Copy(array, start, array.Length - start, (T x) => true, copying);
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
	public static T[] Copy<T>(T[] array, int start, Func<T, int, T> copying)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return Copy(array, start, array.Length - start, (T x, int i) => true, copying);
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
	public static T[] Copy<T>(T[] array, int start, Func<T, bool> predicate, Func<T, T> copying)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return Copy(array, start, array.Length - start, predicate, copying);
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
	public static T[] Copy<T>(T[] array, int start, Func<T, int, bool> predicate, Func<T, int, T> copying)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return Copy(array, start, array.Length - start, predicate, copying);
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
	public static T[] Copy<T>(T[] array, int start, int count)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		Guard.AssertBetween(count, 0, array.Length - start, "count");
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
	public static T[] Copy<T>(T[] array, int start, int count, Func<T, T> copying)
	{
		return Copy(array, start, count, (T x) => true, copying);
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
	public static T[] Copy<T>(T[] array, int start, int count, Func<T, int, T> copying)
	{
		return Copy(array, start, count, (T x, int i) => true, copying);
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
	public static T[] Copy<T>(T[] array, int start, int count, Func<T, bool> predicate, Func<T, T> copying)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(copying, "copying");
		return Copy(array, start, count, (T x, int i) => predicate(x), (T x, int i) => copying(x));
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
	public static T[] Copy<T>(T[] array, int start, int count, Func<T, int, bool> predicate, Func<T, int, T> copying)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(copying, "copying");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		Guard.AssertBetween(count, 0, array.Length - start, "count");
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
	public static T[] Copy<T>(T[] array, long start)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
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
	public static T[] Copy<T>(T[] array, long start, Func<T, T> copying)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return Copy(array, start, array.LongLength - start, (T x) => true, copying);
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
	public static T[] Copy<T>(T[] array, long start, Func<T, long, T> copying)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return Copy(array, start, array.LongLength - start, (T x, long i) => true, copying);
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
	public static T[] Copy<T>(T[] array, long start, Func<T, bool> predicate, Func<T, T> copying)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return Copy(array, start, array.LongLength - start, predicate, copying);
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
	public static T[] Copy<T>(T[] array, long start, Func<T, long, bool> predicate, Func<T, long, T> copying)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return Copy(array, start, array.LongLength - start, predicate, copying);
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
	public static T[] Copy<T>(T[] array, long start, long count)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		Guard.AssertBetween(count, 0L, array.LongLength - start, "count");
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
	public static T[] Copy<T>(T[] array, long start, long count, Func<T, T> copying)
	{
		return Copy(array, start, count, (T x) => true, copying);
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
	public static T[] Copy<T>(T[] array, long start, long count, Func<T, long, T> copying)
	{
		return Copy(array, start, count, (T x, long i) => true, copying);
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
	public static T[] Copy<T>(T[] array, long start, long count, Func<T, bool> predicate, Func<T, T> copying)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(copying, "copying");
		return Copy(array, start, count, (T x, long i) => predicate(x), (T x, long i) => copying(x));
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
	public static T[] Copy<T>(T[] array, long start, long count, Func<T, long, bool> predicate, Func<T, long, T> copying)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(copying, "copying");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		Guard.AssertBetween(count, 0L, array.LongLength - start, "count");
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
	public static void CopyTo(Array source, Array target)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		Guard.AssertArrayRank(source, target.Rank, string.Empty, string.Format(Literals.MSG_ArrayRankNotSame_2, "source", "target"));
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
	public static void CopyTo(Array source, Array target, int targetStart)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		Guard.AssertArrayRank(source, target.Rank, string.Empty, string.Format(Literals.MSG_ArrayRankNotSame_2, "source", "target"));
		Guard.AssertIndexRange(targetStart, 0, target.Length - 1, "target start");
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
	public static void CopyTo(Array source, Array target, int targetStart, int copyCount)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		Guard.AssertArrayRank(source, target.Rank, string.Empty, string.Format(Literals.MSG_ArrayRankNotSame_2, "source", "target"));
		Guard.AssertIndexRange(targetStart, 0, target.Length - 1, "target start");
		Guard.AssertBetween(copyCount, 0, Math.Min(source.Length, target.Length - targetStart), "copy count");
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
	public static void CopyTo(Array source, int sourceStart, Array target)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		Guard.AssertArrayRank(source, target.Rank, string.Empty, string.Format(Literals.MSG_ArrayRankNotSame_2, "source", "target"));
		Guard.AssertIndexRange(sourceStart, 0, source.Length - 1, "source target");
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
	public static void CopyTo(Array source, int sourceStart, Array target, int targetStart)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		Guard.AssertArrayRank(source, target.Rank, string.Empty, string.Format(Literals.MSG_ArrayRankNotSame_2, "source", "target"));
		Guard.AssertIndexRange(sourceStart, 0, source.Length - 1, "source start");
		Guard.AssertIndexRange(targetStart, 0, target.Length - 1, "target start");
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
	public static void CopyTo(Array source, int sourceStart, Array target, int targetStart, int copyCount)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		Guard.AssertIndexRange(sourceStart, 0, source.Length - 1, "source start");
		Guard.AssertIndexRange(targetStart, 0, target.Length - 1, "target start");
		Guard.AssertBetween(copyCount, 0, Math.Min(source.Length - sourceStart, target.Length - targetStart), "copy count");
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
	public static void CopyTo(Array source, Array target, long targetStart)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		Guard.AssertIndexRange(targetStart, 0L, target.LongLength - 1, "target start");
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
	public static void CopyTo(Array source, Array target, long targetStart, long copyCount)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		Guard.AssertIndexRange(targetStart, 0L, target.LongLength - 1, "target start");
		Guard.AssertBetween(copyCount, 0L, Math.Min(source.LongLength, target.LongLength - targetStart), "copy count");
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
	public static void CopyTo(Array source, long sourceStart, Array target)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		Guard.AssertIndexRange(sourceStart, 0L, source.LongLength - 1, "source target");
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
	public static void CopyTo(Array source, long sourceStart, Array target, long targetStart)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		Guard.AssertIndexRange(sourceStart, 0L, source.LongLength - 1, "source start");
		Guard.AssertIndexRange(targetStart, 0L, target.LongLength - 1, "target start");
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
	public static void CopyTo(Array source, long sourceStart, Array target, long targetStart, long copyCount)
	{
		Guard.AssertNotNull(source, "source");
		Guard.AssertNotNull(target, "target");
		Guard.AssertIndexRange(sourceStart, 0L, source.LongLength - 1, "source start");
		Guard.AssertIndexRange(targetStart, 0L, target.LongLength - 1, "target start");
		Guard.AssertBetween(copyCount, 0L, Math.Min(source.LongLength - sourceStart, target.LongLength - targetStart), "copy count");
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
	public static bool Exists(Array array, Func<object, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
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
	public static bool Exists(Array array, Func<object, int, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		return CollectionHelper.Any(array.OfType<object>(), predicate);
	}

	/// <summary>
	/// 检测当前数组是否包含与满足指定条件的元素
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">元素检测条件</param>
	/// <returns>如果存在满足条件的元素返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static bool Exists<T>(T[] array, Func<T, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
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
	public static bool Exists<T>(T[] array, Func<T, int, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
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
	public static Array Fill(Array array, object value)
	{
		Guard.AssertNotNull(array, "array");
		return Fill(array, 0, array.Length, value);
	}

	/// <summary>
	/// 填充当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="evaluation">元素计算方法</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static Array Fill(Array array, Func<int, object> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		return Fill(array, 0, array.Length, evaluation);
	}

	/// <summary>
	/// 填充当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="evaluation">元素计算方法</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static Array Fill(Array array, Func<object, int, object> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		return Fill(array, 0, array.Length, evaluation);
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
	public static Array Fill(Array array, int start, int count, object value)
	{
		return Fill(array, start, count, (int i) => value);
	}

	/// <summary>
	/// 填充当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始填充的索引位置</param>
	/// <param name="count">填充的元素个数</param>
	/// <param name="evaluation">元素计算方法</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组索引有效范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 开始剩余的元素数量。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static Array Fill(Array array, int start, int count, Func<int, object> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(evaluation, "evaluation");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		Guard.AssertBetween(count, 0, array.Length - start, "count");
		int end = start + count;
		int[] weights = GetWeight(array);
		for (int i = start; i < end; i++)
		{
			SetValue(array, evaluation(i), i, weights);
		}
		return array;
	}

	/// <summary>
	/// 填充当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始填充的索引位置</param>
	/// <param name="count">填充的元素个数</param>
	/// <param name="evaluation">元素计算方法</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组索引有效范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 开始剩余的元素数量。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static Array Fill(Array array, int start, int count, Func<object, int, object> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(evaluation, "evaluation");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		Guard.AssertBetween(count, 0, array.Length - start, "count");
		int end = start + count;
		int[] weights = GetWeight(array);
		for (int i = start; i < end; i++)
		{
			SetValue(array, evaluation(GetValue(array, i, weights), i), i, weights);
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
	public static T[] Fill<T>(T[] array, T value)
	{
		Guard.AssertNotNull(array, "array");
		return Fill(array, 0, array.Length, value);
	}

	/// <summary>
	/// 填充当前数组
	/// </summary>
	/// <typeparam name="T">当前数组的元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="evaluation">元素计算方法</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluation" /> 为空。</exception>
	public static T[] Fill<T>(T[] array, Func<int, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		return Fill(array, 0, array.Length, evaluation);
	}

	/// <summary>
	/// 填充当前数组
	/// </summary>
	/// <typeparam name="T">当前数组的元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="evaluation">元素计算方法</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluation" /> 为空。</exception>
	public static T[] Fill<T>(T[] array, Func<T, int, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		return Fill(array, 0, array.Length, evaluation);
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
	public static T[] Fill<T>(T[] array, int start, int count, T value)
	{
		return Fill(array, start, count, (int i) => value);
	}

	/// <summary>
	/// 填充当前数组
	/// </summary>
	/// <typeparam name="T">当前数组的元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始填充的索引位置</param>
	/// <param name="count">填充的元素个数</param>
	/// <param name="evaluation">元素计算方法</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组索引有效范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static T[] Fill<T>(T[] array, int start, int count, Func<int, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(evaluation, "evaluation");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		Guard.AssertBetween(count, 0, array.Length - start, "count");
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			array[i] = evaluation(i);
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
	/// <param name="evaluation">元素计算方法</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组索引有效范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static T[] Fill<T>(T[] array, int start, int count, Func<T, int, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(evaluation, "evaluation");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		Guard.AssertBetween(count, 0, array.Length - start, "count");
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			array[i] = evaluation(array[i], i);
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
	public static Array FillLong(Array array, object value)
	{
		Guard.AssertNotNull(array, "array");
		return FillLong(array, 0L, array.LongLength, value);
	}

	/// <summary>
	/// 填充当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="evaluation">元素计算方法</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static Array FillLong(Array array, Func<long, object> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		return FillLong(array, 0L, array.LongLength, evaluation);
	}

	/// <summary>
	/// 填充当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="evaluation">元素计算方法</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static Array FillLong(Array array, Func<object, long, object> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		return FillLong(array, 0L, array.LongLength, evaluation);
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
	public static Array FillLong(Array array, long start, long count, object value)
	{
		return FillLong(array, start, count, (long i) => value);
	}

	/// <summary>
	/// 填充当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始填充的索引位置</param>
	/// <param name="count">填充的元素个数</param>
	/// <param name="evaluation">元素计算方法</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组索引有效范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 开始剩余的元素数量。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static Array FillLong(Array array, long start, long count, Func<long, object> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(evaluation, "evaluation");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		Guard.AssertBetween(count, 0L, array.LongLength - start, "count");
		long end = start + count;
		long[] weights = GetLongWeight(array);
		for (long i = start; i < end; i++)
		{
			SetValue(array, evaluation(i), i, weights);
		}
		return array;
	}

	/// <summary>
	/// 填充当前数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始填充的索引位置</param>
	/// <param name="count">填充的元素个数</param>
	/// <param name="evaluation">元素计算方法</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组索引有效范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 开始剩余的元素数量。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static Array FillLong(Array array, long start, long count, Func<object, long, object> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(evaluation, "evaluation");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		Guard.AssertBetween(count, 0L, array.LongLength - start, "count");
		long end = start + count;
		long[] weights = GetLongWeight(array);
		for (long i = start; i < end; i++)
		{
			SetValue(array, evaluation(GetValue(array, i, weights), i), i, weights);
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
	public static T[] FillLong<T>(T[] array, T value)
	{
		Guard.AssertNotNull(array, "array");
		return FillLong(array, 0L, array.LongLength, value);
	}

	/// <summary>
	/// 填充当前数组
	/// </summary>
	/// <typeparam name="T">当前数组的元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="evaluation">元素计算方法</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluation" /> 为空。</exception>
	public static T[] FillLong<T>(T[] array, Func<long, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		return FillLong(array, 0L, array.LongLength, evaluation);
	}

	/// <summary>
	/// 填充当前数组
	/// </summary>
	/// <typeparam name="T">当前数组的元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="evaluation">元素计算方法</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluation" /> 为空。</exception>
	public static T[] FillLong<T>(T[] array, Func<T, long, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		return FillLong(array, 0L, array.LongLength, evaluation);
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
	public static T[] FillLong<T>(T[] array, long start, long count, T value)
	{
		return FillLong(array, start, count, (long i) => value);
	}

	/// <summary>
	/// 填充当前数组
	/// </summary>
	/// <typeparam name="T">当前数组的元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始填充的索引位置</param>
	/// <param name="count">填充的元素个数</param>
	/// <param name="evaluation">元素计算方法</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组索引有效范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static T[] FillLong<T>(T[] array, long start, long count, Func<long, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(evaluation, "evaluation");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		Guard.AssertBetween(count, 0L, array.LongLength - start, "count");
		long end = start + count;
		for (long i = start; i < end; i++)
		{
			array[i] = evaluation(i);
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
	/// <param name="evaluation">元素计算方法</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组索引有效范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static T[] FillLong<T>(T[] array, long start, long count, Func<T, long, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(evaluation, "evaluation");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		Guard.AssertBetween(count, 0L, array.LongLength - start, "count");
		long end = start + count;
		for (long i = start; i < end; i++)
		{
			array[i] = evaluation(array[i], i);
		}
		return array;
	}

	/// <summary>
	/// 向当前数组中填充空值（\0）
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] FillNull(byte[] array)
	{
		Guard.AssertNotNull(array, "array");
		return Fill(array, (byte)0);
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
	public static object Find(Array array, Func<object, bool> predicate, object defaultValue = null)
	{
		Guard.AssertNotNull(array, "array");
		return Find(array, 0, array.Length, predicate, defaultValue);
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
	public static object Find(Array array, Func<object, int, bool> predicate, object defaultValue = null)
	{
		Guard.AssertNotNull(array, "array");
		return Find(array, 0, array.Length, predicate, defaultValue);
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
	public static object Find(Array array, int start, Func<object, bool> predicate, object defaultValue = null)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return Find(array, start, array.Length - start, predicate, defaultValue);
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
	public static object Find(Array array, int start, Func<object, int, bool> predicate, object defaultValue = null)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return Find(array, start, array.Length - start, predicate, defaultValue);
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
	public static object Find(Array array, int start, int count, Func<object, bool> predicate, object defaultValue = null)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		return Find(array, start, count, (object x, int i) => predicate(x), defaultValue);
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
	public static object Find(Array array, int start, int count, Func<object, int, bool> predicate, object defaultValue = null)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		Guard.AssertBetween(count, 0, array.Length - start, "count");
		Guard.AssertNotNull(predicate, "predicate");
		if (count > 0)
		{
			int end = start + count;
			int[] weights = GetWeight(array);
			for (int i = start; i < end; i++)
			{
				object value = GetValue(array, i, weights);
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
	public static object Find(Array array, long start, Func<object, bool> predicate, object defaultValue = null)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return Find(array, start, array.LongLength - start, predicate, defaultValue);
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
	public static object Find(Array array, long start, Func<object, long, bool> predicate, object defaultValue = null)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return Find(array, start, array.LongLength - start, predicate, defaultValue);
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
	public static object Find(Array array, long start, long count, Func<object, bool> predicate, object defaultValue = null)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		return Find(array, start, count, (object x, long i) => predicate(x), defaultValue);
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
	public static object Find(Array array, long start, long count, Func<object, long, bool> predicate, object defaultValue = null)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		Guard.AssertBetween(count, 0L, array.LongLength - start, "count");
		Guard.AssertNotNull(predicate, "predicate");
		if (count > 0)
		{
			long end = start + count;
			long[] weight = GetLongWeight(array);
			for (long i = start; i < end; i++)
			{
				object value = GetValue(array, i, weight);
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
	public static T Find<T>(T[] array, Func<T, bool> predicate, T defaultValue = default(T))
	{
		Guard.AssertNotNull(array, "array");
		return Find(array, 0, array.Length, predicate, defaultValue);
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
	public static T Find<T>(T[] array, Func<T, int, bool> predicate, T defaultValue = default(T))
	{
		Guard.AssertNotNull(array, "array");
		return Find(array, 0, array.Length, predicate, defaultValue);
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
	public static T Find<T>(T[] array, int start, Func<T, bool> predicate, T defaultValue = default(T))
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return Find(array, start, array.Length - start, predicate, defaultValue);
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
	public static T Find<T>(T[] array, int start, Func<T, int, bool> predicate, T defaultValue = default(T))
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return Find(array, start, array.Length - start, predicate, defaultValue);
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
	public static T Find<T>(T[] array, int start, int count, Func<T, bool> predicate, T defaultValue = default(T))
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		return Find(array, start, count, (T x, int i) => predicate(x), defaultValue);
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
	public static T Find<T>(T[] array, int start, int count, Func<T, int, bool> predicate, T defaultValue = default(T))
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		Guard.AssertBetween(count, 0, array.Length - start, "count");
		int index = FindIndex(array, start, count, predicate);
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
	public static T Find<T>(T[] array, long start, Func<T, bool> predicate, T defaultValue = default(T))
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return Find(array, start, array.Length - start, predicate, defaultValue);
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
	public static T Find<T>(T[] array, long start, Func<T, long, bool> predicate, T defaultValue = default(T))
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return Find(array, start, array.LongLength - start, predicate, defaultValue);
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
	public static T Find<T>(T[] array, long start, long count, Func<T, bool> predicate, T defaultValue = default(T))
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		return Find(array, start, count, (T x, long i) => predicate(x), defaultValue);
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
	public static T Find<T>(T[] array, long start, long count, Func<T, long, bool> predicate, T defaultValue = default(T))
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		Guard.AssertBetween(count, 0L, array.LongLength - start, "count");
		long index = FindIndex(array, start, count, predicate);
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
	public static object[] FindAll(Array array, Func<object, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		return FindAll(array, (object x, int i) => predicate(x));
	}

	/// <summary>
	/// 在当前数组中查找所有符合条件的元素
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">元素筛选条件</param>
	/// <returns>符合条件的元素数组；如果没有满足条件的元素则返回空数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static object[] FindAll(Array array, Func<object, int, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		List<object> list = new List<object>();
		int[] weights = GetWeight(array);
		for (int i = 0; i < array.Length; i++)
		{
			object value = GetValue(array, i, weights);
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
	public static T[] FindAll<T>(T[] array, Func<T, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
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
	public static T[] FindAll<T>(T[] array, Func<T, int, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
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
	public static int FindIndex(Array array, Func<object, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		return FindIndex(array, 0, array.Length, predicate);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的第一个数组元素的位置
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <remarks>当前数组可以是一维或者多维数组</remarks>
	public static int FindIndex(Array array, Func<object, int, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		return FindIndex(array, 0, array.Length, predicate);
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
	public static int FindIndex(Array array, int start, Func<object, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return FindIndex(array, start, array.Length - start, predicate);
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
	public static int FindIndex(Array array, int start, Func<object, int, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return FindIndex(array, start, array.Length - start, predicate);
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
	public static int FindIndex(Array array, int start, int count, Func<object, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		return FindIndex(array, start, count, (object x, int i) => predicate(x));
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
	public static int FindIndex(Array array, int start, int count, Func<object, int, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		Guard.AssertBetween(count, 0, array.Length - start, "count");
		if (count > 0)
		{
			int end = start + count;
			int[] weights = GetWeight(array);
			for (int i = start; i < end; i++)
			{
				if (predicate(GetValue(array, i, weights), i))
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
	public static long FindIndex(Array array, long start, Func<object, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return FindIndex(array, start, array.LongLength - start, predicate);
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
	public static long FindIndex(Array array, long start, Func<object, long, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return FindIndex(array, start, array.LongLength - start, predicate);
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
	public static long FindIndex(Array array, long start, long count, Func<object, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		return FindIndex(array, start, count, (object x, long i) => predicate(x));
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
	public static long FindIndex(Array array, long start, long count, Func<object, long, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		Guard.AssertBetween(count, 0L, array.LongLength - start, "count");
		if (count > 0)
		{
			long end = start + count;
			long[] weight = GetLongWeight(array);
			for (long i = start; i < end; i++)
			{
				if (predicate(GetValue(array, i, weight), i))
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
	public static int FindIndex<T>(T[] array, Func<T, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		return FindIndex(array, 0, array.Length, predicate);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的第一个数组元素的位置
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static int FindIndex<T>(T[] array, Func<T, int, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		return FindIndex(array, 0, array.Length, predicate);
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
	public static int FindIndex<T>(T[] array, int start, Func<T, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return FindIndex(array, start, array.Length - start, predicate);
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
	public static int FindIndex<T>(T[] array, int start, Func<T, int, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return FindIndex(array, start, array.Length - start, predicate);
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
	public static int FindIndex<T>(T[] array, int start, int count, Func<T, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
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
	public static int FindIndex<T>(T[] array, int start, int count, Func<T, int, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "array");
		Guard.AssertBetween(count, 0, array.Length - start, "count");
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
	public static long FindIndex<T>(T[] array, long start, Func<T, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return FindIndex(array, start, array.LongLength - start, predicate);
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
	public static long FindIndex<T>(T[] array, long start, Func<T, long, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return FindIndex(array, start, array.LongLength - start, predicate);
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
	public static long FindIndex<T>(T[] array, long start, long count, Func<T, bool> predicate)
	{
		Guard.AssertNotNull(predicate, "predicate");
		return FindIndex(array, start, count, (T x, long i) => predicate(x));
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
	public static long FindIndex<T>(T[] array, long start, long count, Func<T, long, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "array");
		Guard.AssertBetween(count, 0L, array.LongLength - start, "count");
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
	public static object FindLast(Array array, Func<object, bool> predicate, object defaultValue = null)
	{
		Guard.AssertNotNull(array, "array");
		return FindLast(array, array.Length - 1, array.Length, predicate, defaultValue);
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
	public static object FindLast(Array array, Func<object, int, bool> predicate, object defaultValue = null)
	{
		Guard.AssertNotNull(array, "array");
		return FindLast(array, array.Length - 1, array.Length, predicate, defaultValue);
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
	public static object FindLast(Array array, int start, Func<object, bool> predicate, object defaultValue = null)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return FindLast(array, start, start + 1, predicate, defaultValue);
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
	public static object FindLast(Array array, int start, Func<object, int, bool> predicate, object defaultValue = null)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return FindLast(array, start, start + 1, predicate, defaultValue);
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
	public static object FindLast(Array array, int start, int count, Func<object, bool> predicate, object defaultValue = null)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		return FindLast(array, start, count, (object x, int i) => predicate(x), defaultValue);
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
	public static object FindLast(Array array, int start, int count, Func<object, int, bool> predicate, object defaultValue = null)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		Guard.AssertBetween(count, 0, start + 1, "count");
		if (count > 0)
		{
			int[] weights = GetWeight(array);
			int end = start - count;
			for (int i = start; i > end; i--)
			{
				object value = GetValue(array, i, weights);
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
	public static object FindLast(Array array, long start, Func<object, bool> predicate, object defaultValue = null)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return FindLast(array, start, start + 1, predicate, defaultValue);
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
	public static object FindLast(Array array, long start, Func<object, long, bool> predicate, object defaultValue = null)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return FindLast(array, start, start + 1, predicate, defaultValue);
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
	public static object FindLast(Array array, long start, long count, Func<object, bool> predicate, object defaultValue = null)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		return FindLast(array, start, count, (object x, long i) => predicate(x), defaultValue);
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
	public static object FindLast(Array array, long start, long count, Func<object, long, bool> predicate, object defaultValue = null)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		Guard.AssertBetween(count, 0L, start + 1, "count");
		if (count > 0)
		{
			long[] weight = GetLongWeight(array);
			long end = start - count;
			for (long i = start; i > end; i--)
			{
				object value = GetValue(array, i, weight);
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
	public static T FindLast<T>(T[] array, Func<T, bool> predicate, T defaultValue = default(T))
	{
		Guard.AssertNotNull(array, "array");
		return FindLast(array, array.Length - 1, array.Length, predicate, defaultValue);
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
	public static T FindLast<T>(T[] array, Func<T, int, bool> predicate, T defaultValue = default(T))
	{
		Guard.AssertNotNull(array, "array");
		return FindLast(array, array.Length - 1, array.Length, predicate, defaultValue);
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
	public static T FindLast<T>(T[] array, int start, Func<T, bool> predicate, T defaultValue = default(T))
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return FindLast(array, start, start + 1, predicate, defaultValue);
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
	public static T FindLast<T>(T[] array, int start, Func<T, int, bool> predicate, T defaultValue = default(T))
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return FindLast(array, start, start + 1, predicate, defaultValue);
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
	public static T FindLast<T>(T[] array, int start, int count, Func<T, bool> predicate, T defaultValue = default(T))
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		return FindLast(array, start, count, (T x, int i) => predicate(x), defaultValue);
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
	public static T FindLast<T>(T[] array, int start, int count, Func<T, int, bool> predicate, T defaultValue = default(T))
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		Guard.AssertBetween(count, 0, start + 1, "count");
		int index = FindLastIndex(array, start, count, predicate);
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
	public static T FindLast<T>(T[] array, long start, Func<T, bool> predicate, T defaultValue = default(T))
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return FindLast(array, start, start + 1, predicate, defaultValue);
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
	public static T FindLast<T>(T[] array, long start, Func<T, long, bool> predicate, T defaultValue = default(T))
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return FindLast(array, start, start + 1, predicate, defaultValue);
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
	public static T FindLast<T>(T[] array, long start, long count, Func<T, bool> predicate, T defaultValue = default(T))
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		return FindLast(array, start, count, (T x, long i) => predicate(x), defaultValue);
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
	public static T FindLast<T>(T[] array, long start, long count, Func<T, long, bool> predicate, T defaultValue = default(T))
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		Guard.AssertBetween(count, 0L, start + 1, "count");
		long index = FindLastIndex(array, start, count, predicate);
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
	public static int FindLastIndex(Array array, Func<object, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		return FindLastIndex(array, array.Length - 1, array.Length, predicate);
	}

	/// <summary>
	/// 在当前数组中查找符合指定条件的最后一个数组元素的位置
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>如果找到匹配的数组元素则返回其索引，否则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	/// <remarks>当前数组可以是一维或者多维数组。本方法从当前数组的结束位置开始，逆向搜索到数组的起始位置。</remarks>
	public static int FindLastIndex(Array array, Func<object, int, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		return FindLastIndex(array, array.Length - 1, array.Length, predicate);
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
	public static int FindLastIndex(Array array, int start, Func<object, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return FindLastIndex(array, start, start + 1, predicate);
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
	public static int FindLastIndex(Array array, int start, Func<object, int, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return FindLastIndex(array, start, start + 1, predicate);
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
	public static int FindLastIndex(Array array, int start, int count, Func<object, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		return FindLastIndex(array, start, count, (object x, int i) => predicate(x));
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
	public static int FindLastIndex(Array array, int start, int count, Func<object, int, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		Guard.AssertBetween(count, 0, start + 1, "count");
		if (count > 0)
		{
			int[] weights = GetWeight(array);
			int end = start - count;
			for (int i = start; i > end; i--)
			{
				if (predicate(GetValue(array, i, weights), i))
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
	public static long FindLastIndex(Array array, long start, Func<object, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return FindLastIndex(array, start, start + 1, predicate);
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
	public static long FindLastIndex(Array array, long start, Func<object, long, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return FindLastIndex(array, start, start + 1, predicate);
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
	public static long FindLastIndex(Array array, long start, long count, Func<object, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		return FindLastIndex(array, start, count, (object x, long i) => predicate(x));
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
	public static long FindLastIndex(Array array, long start, long count, Func<object, long, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		Guard.AssertBetween(count, 0L, start + 1, "count");
		if (count > 0)
		{
			long[] weight = GetLongWeight(array);
			long end = start - count;
			for (long i = start; i > end; i--)
			{
				if (predicate(GetValue(array, i, weight), i))
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
	public static int FindLastIndex<T>(T[] array, Func<T, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
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
	public static int FindLastIndex<T>(T[] array, Func<T, int, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
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
	public static int FindLastIndex<T>(T[] array, int start, Func<T, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return FindLastIndex(array, start, start + 1, predicate);
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
	public static int FindLastIndex<T>(T[] array, int start, Func<T, int, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return FindLastIndex(array, start, start + 1, predicate);
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
	public static int FindLastIndex<T>(T[] array, int start, int count, Func<T, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		Guard.AssertBetween(count, 0, start + 1, "count");
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
	public static int FindLastIndex<T>(T[] array, int start, int count, Func<T, int, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		Guard.AssertBetween(count, 0, start + 1, "count");
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
	public static long FindLastIndex<T>(T[] array, long start, Func<T, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return FindLastIndex(array, start, start + 1, predicate);
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
	public static long FindLastIndex<T>(T[] array, long start, Func<T, long, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return FindLastIndex(array, start, start + 1, predicate);
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
	public static long FindLastIndex<T>(T[] array, long start, long count, Func<T, bool> predicate)
	{
		Guard.AssertNotNull(predicate, "predicate");
		return FindLastIndex(array, start, count, (T x, long i) => predicate(x));
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
	public static long FindLastIndex<T>(T[] array, long start, long count, Func<T, long, bool> predicate)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		Guard.AssertBetween(count, 0L, start + 1, "count");
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
	public static Type GetElementType(Array array)
	{
		Guard.AssertNotNull(array, "array");
		return array.GetType().GetElementType();
	}

	/// <summary>
	/// 获取当前数组的最后一个元素的索引
	/// </summary>
	/// <param name="array">当前的数组</param>
	/// <returns>最后一个元素的索引，如果数组不包含任何元素，则返回null</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static int[] GetLastIndex(Array array)
	{
		Guard.AssertNotNull(array, "array");
		return (array.Length == 0) ? null : Fill(GetWeight(array), (int x, int i) => x - 1);
	}

	/// <summary>
	/// 获取当前数组的最后一个元素的索引
	/// </summary>
	/// <param name="array">当前的数组</param>
	/// <returns>最后一个元素的索引，如果数组不包含任何元素，则返回null</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static long[] GetLastLongIndex(Array array)
	{
		Guard.AssertNotNull(array, "array");
		return (array.LongLength == 0) ? null : Fill(GetLongWeight(array), (long x, int i) => x - 1);
	}

	/// <summary>
	/// 获取当前数组各个秩（维数）的元素数量
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <returns>当前数组各个秩（维数）的元素数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static long[] GetLongWeight(Array array)
	{
		Guard.AssertNotNull(array, "array");
		return Fill(new long[array.Rank], (int i) => array.GetLongLength(i));
	}

	/// <summary>
	/// 获取当前数组中符合条件的元素组成的子数组
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>当前数组中符合条件的元素组成的子数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static T[] GetRange<T>(T[] array, Func<T, bool> predicate)
	{
		return GetRange(array, predicate, (T x) => x);
	}

	/// <summary>
	/// 获取当前数组中符合条件的元素组成的子数组
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">数组元素筛选条件</param>
	/// <returns>当前数组中符合条件的元素组成的子数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空。</exception>
	public static T[] GetRange<T>(T[] array, Func<T, int, bool> predicate)
	{
		return GetRange(array, predicate, (T x, int i) => x);
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
	public static T[] GetRange<S, T>(S[] array, Func<S, bool> predicate, Func<S, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(evaluation, "evaluation");
		return GetRange(array, (S x, int i) => predicate(x), (S x, int i) => evaluation(x));
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
	public static T[] GetRange<S, T>(S[] array, Func<S, int, bool> predicate, Func<S, int, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(evaluation, "evaluation");
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
	public static T[] GetRange<T>(T[] array, int start)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return GetRange(array, start, array.Length - start);
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
	public static T[] GetRange<T>(T[] array, int start, int count)
	{
		return GetRange(array, start, count, (T x) => x);
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
	public static T[] GetRange<S, T>(S[] array, int start, int count, Func<S, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(evaluation, "evaluation");
		return GetRange(array, start, count, (S x, int i) => evaluation(x));
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
	public static T[] GetRange<S, T>(S[] array, int start, int count, Func<S, int, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(evaluation, "evaluation");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		Guard.AssertBetween(count, 0, array.Length - start, "count");
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
	public static T[] GetRange<T>(T[] array, int start, int count, Func<T, bool> predicate)
	{
		return GetRange(array, start, count, predicate, (T x) => x);
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
	public static T[] GetRange<T>(T[] array, int start, int count, Func<T, int, bool> predicate)
	{
		return GetRange(array, start, count, predicate, (T x, int i) => x);
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
	public static T[] GetRange<S, T>(S[] array, int start, int count, Func<S, bool> predicate, Func<S, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(evaluation, "evaluation");
		return GetRange(array, start, count, (S x, int i) => predicate(x), (S x, int i) => evaluation(x));
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
	public static T[] GetRange<S, T>(S[] array, int start, int count, Func<S, int, bool> predicate, Func<S, int, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(evaluation, "evaluation");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		Guard.AssertBetween(count, 0, array.Length - start, "count");
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
	public static T[] GetLongRange<T>(T[] array, long start)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return GetLongRange(array, start, array.LongLength - start);
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
	public static T[] GetLongRange<T>(T[] array, long start, long count)
	{
		return GetLongRange(array, start, count, (T x) => x);
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
	public static T[] GetLongRange<S, T>(S[] array, long start, long count, Func<S, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(evaluation, "evaluation");
		return GetLongRange(array, start, count, (S x, long i) => evaluation(x));
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
	public static T[] GetLongRange<S, T>(S[] array, long start, long count, Func<S, long, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(evaluation, "evaluation");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		Guard.AssertBetween(count, 0L, array.LongLength - start, "count");
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
	public static T[] GetLongRange<T>(T[] array, long start, long count, Func<T, bool> predicate)
	{
		return GetLongRange(array, start, count, predicate, (T x) => x);
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
	public static T[] GetLongRange<T>(T[] array, long start, long count, Func<T, long, bool> predicate)
	{
		return GetLongRange(array, start, count, predicate, (T x, long i) => x);
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
	public static T[] GetLongRange<S, T>(S[] array, long start, long count, Func<S, bool> predicate, Func<S, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		Guard.AssertBetween(count, 0L, array.LongLength - start, "count");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(evaluation, "evaluation");
		return CollectionHelper.Select(CollectionHelper.Where(CollectionHelper.LongTake(CollectionHelper.LongSkip(array, start), count), predicate), evaluation).ToArray();
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
	public static T[] GetLongRange<S, T>(S[] array, long start, long count, Func<S, long, bool> predicate, Func<S, long, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		Guard.AssertBetween(count, 0L, array.LongLength - start, "count");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(evaluation, "evaluation");
		return CollectionHelper.Select(CollectionHelper.Where(CollectionHelper.LongTake(CollectionHelper.LongSkip(array, start), count), predicate), evaluation).ToArray();
	}

	/// <summary>
	/// 获取当前数组中每个元素的类型
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <returns>与当前数组结构相同的由数组元素类型组成的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <remarks>如果数组元素为空，则其类型也为空。</remarks>
	public static Array GetTypeArray(Array array)
	{
		Guard.AssertNotNull(array, "array");
		long[] weight = GetLongWeight(array);
		long[] dimension = new long[weight.LongLength];
		Array types = Array.CreateInstance(typeof(Type), weight);
		do
		{
			object value = array.GetValue(dimension);
			if (ObjectHelper.IsNull(value))
			{
				types.SetValue(null, dimension);
			}
			else
			{
				types.SetValue(value.GetType(), dimension);
			}
		}
		while (NumericHelper.PermuteIncrease(dimension, weight));
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
	public static Type[] GetTypeArray<T>(T[] items)
	{
		Guard.AssertNotNull(items, "items");
		Type[] types = new Type[items.LongLength];
		for (long i = 0L; i < items.LongLength; i++)
		{
			types[i] = (ObjectHelper.IsNull(items[i]) ? null : items[i].GetType());
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
	public static T GetValue<T>(Array array, int[] indices)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertArrayLength(indices, array.Rank, "indices");
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
	public static T GetValue<T>(Array array, long[] indices)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertArrayLength(indices, array.Rank, "indices");
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
	public static T GetValue<T>(Array array, int index)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(index, 0, array.Length - 1, "index");
		if (array.Rank == 1)
		{
			return (T)array.GetValue(index);
		}
		return GetValue<T>(array, index, null);
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
	public static T GetValue<T>(Array array, long index)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(index, 0L, array.LongLength - 1, "index");
		if (array.Rank == 1)
		{
			return (T)array.GetValue(index);
		}
		return GetValue<T>(array, index, null);
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
	public static object GetValue(Array array, int index, int[] weight)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(index, 0, array.Length - 1, "index");
		return array.GetValue(NumericHelper.RadixParse(index, ObjectHelper.IfNull(weight, GetWeight(array))));
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
	public static object GetValue(Array array, long index, long[] weight)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(index, 0L, array.LongLength - 1, "index");
		return array.GetValue(NumericHelper.RadixParse(index, ObjectHelper.IfNull(weight, GetLongWeight(array)), 1L));
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
	public static T GetValue<T>(Array array, int index, int[] weight)
	{
		return (T)GetValue(array, index, weight);
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
	public static T GetValue<T>(Array array, long index, long[] weight)
	{
		return (T)GetValue(array, index, weight);
	}

	/// <summary>
	/// 获取当前数组各个秩（维数）的元素数量
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <returns>当前数组各个秩（维数）的元素数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static int[] GetWeight(Array array)
	{
		Guard.AssertNotNull(array, "array");
		return Fill(new int[array.Rank], (int i) => array.GetLength(i));
	}

	/// <summary>
	/// 检测当前数组是否为空或者没有元素
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <returns>如果当前数组为空或者没有元素返回true，否则返回false。</returns>
	public static bool IsNullOrEmpty(Array array)
	{
		return ObjectHelper.IsNull(array) || array.LongLength <= 0;
	}

	/// <summary>
	/// 检测数组是否为空或者没有元素
	/// </summary>
	/// <typeparam name="T">数组元素类型</typeparam>
	/// <param name="array">待检测的数组</param>
	/// <returns>如果数组为空或者没有元素返回true，否则返回false。</returns>
	public static bool IsNullOrEmpty<T>(T[] array)
	{
		return ObjectHelper.IsNull(array) || array.LongLength <= 0;
	}

	/// <summary>
	/// 检测当前数组不为空且不为空数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <returns>如果当前数组不为空且不为空数组返回true，否则返回false。</returns>
	public static bool IsNotNullAndEmpty(Array array)
	{
		return ObjectHelper.IsNotNull(array) && array.LongLength > 0;
	}

	/// <summary>
	/// 检测当前数组不为空且不为空数组
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <returns>如果当前数组不为空且不为空数组返回true，否则返回false。</returns>
	public static bool IsNotNullAndEmpty<T>(T[] array)
	{
		return ObjectHelper.IsNotNull(array) && array.LongLength > 0;
	}

	/// <summary>
	/// 检测当前数组和目标数组结构是否相同（具有相同的维度，每个维度上具有相同数量的元素）
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="target">目标数组</param>
	/// <returns>如果当前数组和目标数组结构</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="target" /> 为空。</exception>
	public static bool IsSameStructure(Array array, Array target)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(target, "target");
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
	public static bool EnsureArraySameStructure<T, K>(T[] array, K[] target)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(target, "target");
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
	public static Array Resize(Array array, int[] newSize)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(newSize, "newSize");
		Guard.AssertGreaterThanOrEqualTo(newSize.Length, 1, "newSize");
		Array newArray = Array.CreateInstance(GetElementType(array), newSize);
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
	public static Array Resize(Array array, long[] newSize)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(newSize, "newSize");
		Guard.AssertGreaterThanOrEqualTo(newSize.Length, 1, "newSize");
		Array newArray = Array.CreateInstance(GetElementType(array), newSize);
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
	public static T[] Resize<T>(T[] array, int newSize)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertGreaterThanOrEqualTo(newSize, 0, "newSize");
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
	public static T[] Resize<T>(T[] array, long newSize)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertGreaterThanOrEqualTo(newSize, 0L, "newSize");
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
	public static Array Reverse(Array array)
	{
		Guard.AssertNotNull(array, "array");
		return Reverse(array, 0, array.Length);
	}

	/// <summary>
	/// 反转当前数组中的元素
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">反转元素的起始位置</param>
	/// <returns>反转后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 不在当前数组的元素索引范围内。</exception>
	public static Array Reverse(Array array, int start)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return Reverse(array, start, array.Length - start);
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
	public static Array Reverse(Array array, int start, int count)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		Guard.AssertBetween(count, 0, array.Length - start, "count");
		int[] weights = GetWeight(array);
		int left = start;
		int right = start + count - 1;
		while (left < right)
		{
			object temp = GetValue(array, left, weights);
			SetValue(array, GetValue(array, right, weights), left, weights);
			SetValue(array, temp, right, weights);
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
	public static Array Reverse(Array array, long start)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return Reverse(array, start, array.LongLength - start);
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
	public static Array Reverse(Array array, long start, long count)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		Guard.AssertBetween(count, 0L, array.LongLength - start, "count");
		long[] weight = GetLongWeight(array);
		long left = start;
		long right = start + count - 1;
		while (left < right)
		{
			object temp = GetValue(array, left, weight);
			SetValue(array, GetValue(array, right, weight), left, weight);
			SetValue(array, temp, right, weight);
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
	public static T[] Reverse<T>(T[] array)
	{
		Guard.AssertNotNull(array, "array");
		return Reverse(array, 0, array.Length);
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
	public static T[] Reverse<T>(T[] array, int start)
	{
		Guard.AssertNotNull(array, "start");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return Reverse(array, start, array.Length - start);
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
	public static T[] Reverse<T>(T[] array, int start, int count)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		Guard.AssertBetween(count, 0, array.Length - start, "count");
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
	public static T[] Reverse<T>(T[] array, long start)
	{
		Guard.AssertNotNull(array, "start");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return Reverse(array, start, array.LongLength - start);
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
	public static T[] Reverse<T>(T[] array, long start, long count)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		Guard.AssertBetween(count, 0L, array.LongLength - start, "count");
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
	public static Array SetValue(Array array, object value, int index, int[] weight)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(index, 0, array.Length - 1, "index");
		array.SetValue(value, NumericHelper.RadixParse(index, ObjectHelper.IfNull(weight, GetWeight(array))));
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
	public static Array SetValue(Array array, object value, long index, long[] weight)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(index, 0L, array.LongLength - 1, "index");
		array.SetValue(value, NumericHelper.RadixParse(index, ObjectHelper.IfNull(weight, GetLongWeight(array)), 1L));
		return array;
	}

	/// <summary>
	/// 对当前数组进行排序
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <returns>排序后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static Array Sort(Array array)
	{
		Guard.AssertNotNull(array, "array");
		return Sort(array, 0, array.Length);
	}

	/// <summary>
	/// 对当前数组进行排序
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="comparer">数组元素比较器</param>
	/// <returns>排序后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；<paramref name="comparer" /> 为空。</exception>
	public static Array Sort(Array array, IComparer comparer)
	{
		Guard.AssertNotNull(array, "array");
		return Sort(array, 0, array.Length, comparer);
	}

	/// <summary>
	/// 对当前数组进行排序
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="comparison">数组元素比较方法</param>
	/// <returns>排序后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；<paramref name="comparison" /> 为空。</exception>
	public static Array Sort(Array array, Func<object, object, int> comparison)
	{
		Guard.AssertNotNull(array, "array");
		return Sort(array, 0, array.Length, comparison);
	}

	/// <summary>
	/// 对当前数组进行排序
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始排序位置</param>
	/// <returns>排序后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组元素索引范围。</exception>
	public static Array Sort(Array array, int start)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return Sort(array, start, array.Length - start, Comparer.Default.Compare);
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
	public static Array Sort(Array array, int start, IComparer comparer)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return Sort(array, start, array.Length - start, comparer);
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
	public static Array Sort(Array array, int start, Func<object, object, int> comparison)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return Sort(array, start, array.Length - start, comparison);
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
	public static Array Sort(Array array, int start, int count)
	{
		return Sort(array, start, count, Comparer.Default.Compare);
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
	public static Array Sort(Array array, int start, int count, IComparer comparer)
	{
		Guard.AssertNotNull(comparer, "comparer");
		return Sort(array, start, count, comparer.Compare);
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
	public static Array Sort(Array array, int start, int count, Func<object, object, int> comparison)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(comparison, "comparison");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		Guard.AssertBetween(count, 0, array.Length - start, "count");
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
		weights = ObjectHelper.IfNull(weights, GetWeight(array));
		int i = start;
		int j = end;
		object pivot = GetValue(array, i + j >> 1, weights);
		while (i <= j)
		{
			object vi = GetValue(array, i, weights);
			object vj = GetValue(array, j, weights);
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
				SetValue(array, vj, i, weights);
				SetValue(array, temp, j, weights);
				i++;
				j--;
				if (ObjectHelper.IsNotNull(items))
				{
					temp = GetValue(items, i, weights);
					SetValue(items, GetValue(items, j, weights), i, weights);
					SetValue(items, temp, j, weights);
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
	public static Array Sort(Array array, long start)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return Sort(array, start, array.LongLength - start, Comparer.Default.Compare);
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
	public static Array Sort(Array array, long start, IComparer comparer)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return Sort(array, start, array.LongLength - start, comparer);
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
	public static Array Sort(Array array, long start, Func<object, object, int> comparison)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return Sort(array, start, array.LongLength - start, comparison);
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
	public static Array Sort(Array array, long start, long count)
	{
		return Sort(array, start, count, Comparer.Default.Compare);
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
	public static Array Sort(Array array, long start, long count, IComparer comparer)
	{
		Guard.AssertNotNull(comparer, "comparer");
		return Sort(array, start, count, comparer.Compare);
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
	public static Array Sort(Array array, long start, long count, Func<object, object, int> comparison)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(comparison, "comparison");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		Guard.AssertBetween(count, 0L, array.LongLength - start, "count");
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
		weights = ObjectHelper.IfNull(weights, GetLongWeight(array));
		long i = start;
		long j = end;
		object pivot = GetValue(array, i + j >> 1, weights);
		while (i <= j)
		{
			object vi = GetValue(array, i, weights);
			object vj = GetValue(array, j, weights);
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
				SetValue(array, vj, i, weights);
				SetValue(array, temp, j, weights);
				i++;
				j--;
				if (ObjectHelper.IsNotNull(items))
				{
					temp = GetValue(items, i, weights);
					SetValue(items, GetValue(items, j, weights), i, weights);
					SetValue(items, temp, j, weights);
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
	public static T[] Sort<T>(T[] array)
	{
		Guard.AssertNotNull(array, "array");
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
	public static T[] Sort<T>(T[] array, IComparer<T> comparer)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(comparer, "comparer");
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
	public static T[] Sort<T>(T[] array, Func<T, T, int> comparison)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(comparison, "comparison");
		Array.Sort(array, ConvertHelper.ToComparer(comparison));
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
	public static T[] Sort<T>(T[] array, int start)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return Sort(array, start, array.Length - start, Comparer<T>.Default);
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
	public static T[] Sort<T>(T[] array, int start, IComparer<T> comparer)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return Sort(array, start, array.Length - start, comparer);
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
	public static T[] Sort<T>(T[] array, int start, Func<T, T, int> comparison)
	{
		Guard.AssertNotNull(array, "aray");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return Sort(array, start, array.Length - start, comparison);
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
	public static T[] Sort<T>(T[] array, int start, int count)
	{
		return Sort(array, start, count, Comparer<T>.Default);
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
	public static T[] Sort<T>(T[] array, int start, int count, IComparer<T> comparer)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(comparer, "comparer");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		Guard.AssertBetween(count, 0, array.Length - start, "count");
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
	public static T[] Sort<T>(T[] array, int start, int count, Func<T, T, int> comparison)
	{
		Guard.AssertNotNull(comparison, "comparison");
		return Sort(array, start, count, ConvertHelper.ToComparer(comparison));
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
	public static T[] Sort<T>(T[] array, long start)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return Sort(array, start, array.LongLength - start, Comparer<T>.Default);
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
	public static T[] Sort<T>(T[] array, long start, IComparer<T> comparer)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return Sort(array, start, array.LongLength - start, comparer);
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
	public static T[] Sort<T>(T[] array, long start, Func<T, T, int> comparison)
	{
		Guard.AssertNotNull(array, "aray");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return Sort(array, start, array.LongLength - start, comparison);
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
	public static T[] Sort<T>(T[] array, long start, long count)
	{
		return Sort(array, start, count, Comparer<T>.Default);
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
	public static T[] Sort<T>(T[] array, long start, long count, IComparer<T> comparer)
	{
		return Sort(array, start, count, ObjectHelper.IfNull(comparer, Comparer<T>.Default).Compare);
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
	public static T[] Sort<T>(T[] array, long start, long count, Func<T, T, int> comparison)
	{
		Guard.AssertNotNull(comparison, "comparison");
		return (T[])Sort(array, start, count, (object x, object y) => comparison((T)x, (T)y));
	}

	/// <summary>
	/// 按照指定的键数组对当前数组进行排序
	/// </summary>
	/// <param name="array">当前数组</param>
	/// <param name="keys">键数组</param>
	/// <returns>排序后的当前数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="keys" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前数组和 <paramref name="keys" /> 不相同。</exception>
	public static Array SortBy(Array array, Array keys)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(keys, "keys");
		return SortBy(array, keys, 0, array.Length, Comparer.Default);
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
	public static Array SortBy(Array array, Array keys, IComparer comparer)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(keys, "keys");
		return SortBy(array, keys, 0, array.Length, comparer);
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
	public static Array SortBy(Array array, Array keys, Func<object, object, int> comparison)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(keys, "keys");
		return SortBy(array, keys, 0, array.Length, comparison);
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
	public static Array SortBy(Array array, Array keys, int start)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return SortBy(array, keys, start, array.Length - start, Comparer.Default.Compare);
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
	public static Array SortBy(Array array, Array keys, int start, IComparer comparer)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return SortBy(array, keys, start, array.Length - start, comparer);
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
	public static Array SortBy(Array array, Array keys, int start, Func<object, object, int> comparison)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return SortBy(array, keys, start, array.Length - start, comparison);
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
	public static Array SortBy(Array array, Array keys, int start, int count)
	{
		return SortBy(array, keys, start, count, Comparer.Default.Compare);
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
	public static Array SortBy(Array array, Array keys, int start, int count, IComparer comparer)
	{
		Guard.AssertNotNull(comparer, "comparer");
		return SortBy(array, keys, start, count, comparer.Compare);
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
	public static Array SortBy(Array array, Array keys, int start, int count, Func<object, object, int> comparison)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(keys, "keys");
		Guard.AssertNotNull(comparison, "comparison");
		Guard.AssertSameArray(array, keys, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		Guard.AssertBetween(count, 0, array.Length - start, "count");
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
	public static Array SortBy(Array array, Array keys, long start)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return SortBy(array, keys, start, array.LongLength - start, Comparer.Default.Compare);
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
	public static Array SortBy(Array array, Array keys, long start, IComparer comparer)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		Guard.AssertNotNull(comparer, "comparer");
		return SortBy(array, keys, start, array.LongLength - start, comparer);
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
	public static Array SortBy(Array array, Array keys, long start, Func<object, object, int> comparison)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		Guard.AssertNotNull(comparison, "comparison");
		return SortBy(array, keys, start, array.LongLength - start, comparison);
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
	public static Array SortBy(Array array, Array keys, long start, long count)
	{
		return SortBy(array, keys, start, count, Comparer.Default.Compare);
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
	public static Array SortBy(Array array, Array keys, long start, long count, IComparer comparer)
	{
		Guard.AssertNotNull(comparer, "comparer");
		return SortBy(array, keys, start, count, comparer.Compare);
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
	public static Array SortBy(Array array, Array keys, long start, long count, Func<object, object, int> comparison)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(keys, "keys");
		Guard.AssertNotNull(comparison, "comparison");
		Guard.AssertSameArray(array, keys, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		Guard.AssertBetween(count, 0L, array.LongLength - start, "count");
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
	public static V[] SortBy<K, V>(V[] array, K[] keys)
	{
		return SortBy(array, keys, Comparer<K>.Default);
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
	public static V[] SortBy<K, V>(V[] array, K[] keys, IComparer<K> comparer)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(keys, "keys");
		Guard.AssertNotNull(comparer, "comparer");
		Guard.AssertSameArray(array, keys, "array");
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
	public static V[] SortBy<K, V>(V[] array, K[] keys, Func<K, K, int> comparison)
	{
		Guard.AssertNotNull(comparison, "comparison");
		return SortBy(array, keys, ConvertHelper.ToComparer(comparison));
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
	public static V[] SortBy<K, V>(V[] array, K[] keys, int start)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return SortBy(array, keys, start, array.Length - start, Comparer<K>.Default);
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
	public static V[] SortBy<K, V>(V[] array, K[] keys, int start, IComparer<K> comparer)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(keys, "keys");
		Guard.AssertNotNull(comparer, "comparer");
		Guard.AssertSameArray(array, keys, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
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
	public static V[] SortBy<K, V>(V[] array, K[] keys, int start, Func<K, K, int> comparison)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return SortBy(array, keys, start, array.Length - start, comparison);
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
	public static V[] SortBy<K, V>(V[] array, K[] keys, int start, int count)
	{
		Guard.AssertNotNull(array, "array");
		return SortBy(array, keys, start, count, Comparer<K>.Default);
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
	public static V[] SortBy<K, V>(V[] array, K[] keys, int start, int count, IComparer<K> comparer)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(keys, "keys");
		Guard.AssertNotNull(comparer, "comparer");
		Guard.AssertSameArray(array, keys, "array");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		Guard.AssertBetween(count, 0, array.Length - start, "count");
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
	public static V[] SortBy<K, V>(V[] array, K[] keys, int start, int count, Func<K, K, int> comparison)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(comparison, "comparison");
		return SortBy(array, keys, start, count, ConvertHelper.ToComparer(comparison));
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
	public static V[] SortBy<K, V>(V[] array, K[] keys, long start)
	{
		return SortBy(array, keys, start, Comparer<K>.Default.Compare);
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
	public static V[] SortBy<K, V>(V[] array, K[] keys, long start, IComparer<K> comparer)
	{
		Guard.AssertNotNull(comparer, "comparer");
		return SortBy(array, keys, start, comparer.Compare);
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
	public static V[] SortBy<K, V>(V[] array, K[] keys, long start, Func<K, K, int> comparison)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		Guard.AssertNotNull(comparison, "comparison");
		return SortBy(array, keys, start, array.LongLength - start, comparison);
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
	public static V[] SortBy<K, V>(V[] array, K[] keys, long start, long count)
	{
		return SortBy(array, keys, start, count, Comparer<K>.Default.Compare);
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
	public static V[] SortBy<K, V>(V[] array, K[] keys, long start, long count, IComparer<K> comparer)
	{
		Guard.AssertNotNull(comparer, "comparer");
		return SortBy(array, keys, start, count, comparer.Compare);
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
	public static V[] SortBy<K, V>(V[] array, K[] keys, long start, long count, Func<K, K, int> comparison)
	{
		Guard.AssertNotNull(comparison, "comparison");
		return (V[])SortBy(array, keys, start, count, (object x, object y) => comparison((K)x, (K)y));
	}

	/// <summary>
	/// 将当前二维数组分解为数组的数组
	/// </summary>
	/// <typeparam name="T">数组元素类型</typeparam>
	/// <param name="array">当前二维数组</param>
	/// <returns>分解生成的二维数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前二维数组为空。</exception>
	public static T[][] Split<T>(T[,] array)
	{
		Guard.AssertNotNull(array, "array");
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
	public static T[][][] Split<T>(T[,,] array)
	{
		Guard.AssertNotNull(array, "array");
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
	public static T[] ToArray<T>(Array array)
	{
		Guard.AssertNotNull(array, "array");
		return ToArray(array, (object x, int i) => (T)x);
	}

	/// <summary>
	/// 将当前数组转换为指定类型的一维数组
	/// </summary>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluation" /> 为空。</exception>
	public static T[] ToArray<T>(Array array, Func<object, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(evaluation, "evaluation");
		return ToArray(array, (object x, int i) => evaluation(x));
	}

	/// <summary>
	/// 将当前数组转换为指定类型的一维数组
	/// </summary>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluation" /> 为空。</exception>
	public static T[] ToArray<T>(Array array, Func<object, int, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(evaluation, "evaluation");
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
	public static T[] ToArray<T>(Array array, Func<object, bool> predicate, Func<object, T> evaluation)
	{
		return ToList(array, predicate, evaluation).ToArray();
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
	public static T[] ToArray<T>(Array array, Func<object, int, bool> predicate, Func<object, int, T> evaluation)
	{
		return ToList(array, predicate, evaluation).ToArray();
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
	public static T[] ToArray<T>(Array array, int start, Func<object, bool> predicate, Func<object, T> evaluation)
	{
		return ToList(array, start, predicate, evaluation).ToArray();
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
	public static T[] ToArray<T>(Array array, int start, Func<object, int, bool> predicate, Func<object, int, T> evaluation)
	{
		return ToList(array, start, predicate, evaluation).ToArray();
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
	public static T[] ToArray<T>(Array array, int start, int count, Func<object, bool> predicate, Func<object, T> evaluation)
	{
		return ToList(array, start, count, predicate, evaluation).ToArray();
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
	public static T[] ToArray<T>(Array array, int start, int count, Func<object, int, bool> predicate, Func<object, int, T> evaluation)
	{
		return ToList(array, start, count, predicate, evaluation).ToArray();
	}

	/// <summary>
	/// 将当前数组转换为指定类型的一维数组
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <returns>转换后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static T[] ToArray<S, T>(S[] array)
	{
		Guard.AssertNotNull(array, "array");
		return ToArray(array, (S x, int i) => ObjectHelper.As<T>(x));
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
	public static T[] ToArray<S, T>(S[] array, Func<S, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(evaluation, "evaluation");
		return ToArray(array, (S x, int i) => evaluation(x));
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
	public static T[] ToArray<S, T>(S[] array, Func<S, int, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(evaluation, "evaluation");
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
	public static T[] ToArray<S, T>(S[] array, Func<S, bool> predicate, Func<S, T> evaluation)
	{
		return ToList(array, predicate, evaluation).ToArray();
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
	public static T[] ToArray<S, T>(S[] array, Func<S, int, bool> predicate, Func<S, int, T> evaluation)
	{
		return ToList(array, predicate, evaluation).ToArray();
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
	public static T[] ToArray<S, T>(S[] array, int start, Func<S, bool> predicate, Func<S, T> evaluation)
	{
		return ToList(array, start, predicate, evaluation).ToArray();
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
	public static T[] ToArray<S, T>(S[] array, int start, Func<S, int, bool> predicate, Func<S, int, T> evaluation)
	{
		return ToList(array, start, predicate, evaluation).ToArray();
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
	public static T[] ToArray<S, T>(S[] array, int start, int count, Func<S, bool> predicate, Func<S, T> evaluation)
	{
		return ToList(array, start, count, predicate, evaluation).ToArray();
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
	public static T[] ToArray<S, T>(S[] array, int start, int count, Func<S, int, bool> predicate, Func<S, int, T> evaluation)
	{
		return ToList(array, start, count, predicate, evaluation).ToArray();
	}

	/// <summary>
	/// 将当前数组转换为指定类型的一维数组
	/// </summary>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <returns>转换后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static T[] ToLongArray<T>(Array array)
	{
		Guard.AssertNotNull(array, "array");
		return ToLongArray(array, (object x, long i) => (T)x);
	}

	/// <summary>
	/// 将当前数组转换为指定类型的一维数组
	/// </summary>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluation" /> 为空。</exception>
	public static T[] ToLongArray<T>(Array array, Func<object, long, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(evaluation, "evaluation");
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
	public static T[] ToLongArray<T>(Array array, long start, Func<object, bool> predicate, Func<object, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return ToLongArray(array, start, array.LongLength - start, predicate, evaluation);
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
	public static T[] ToLongArray<T>(Array array, long start, Func<object, long, bool> predicate, Func<object, long, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return ToLongArray(array, start, array.LongLength - start, predicate, evaluation);
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
	public static T[] ToLongArray<T>(Array array, long start, long count, Func<object, bool> predicate, Func<object, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(evaluation, "evaluation");
		return ToLongArray(array, start, count, (object x, long i) => predicate(x), (object x, long i) => evaluation(x));
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
	public static T[] ToLongArray<T>(Array array, long start, long count, Func<object, long, bool> predicate, Func<object, long, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(evaluation, "evaluation");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		Guard.AssertBetween(count, 0L, array.LongLength - start, "count");
		return CollectionHelper.Select(CollectionHelper.Where(CollectionHelper.LongTake(CollectionHelper.LongSkip(array.OfType<object>(), start), count), predicate), evaluation).ToArray();
	}

	/// <summary>
	/// 将当前数组转换为指定类型的一维数组
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <returns>转换后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static T[] ToLongArray<S, T>(S[] array)
	{
		Guard.AssertNotNull(array, "array");
		return ToLongArray(array, (S x, long i) => ObjectHelper.As<T>(x));
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
	public static T[] ToLongArray<S, T>(S[] array, Func<S, long, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(evaluation, "evaluation");
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
	public static T[] ToLongArray<S, T>(S[] array, long start, Func<S, bool> predicate, Func<S, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return ToLongArray(array, start, array.LongLength - start, predicate, evaluation);
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
	public static T[] ToLongArray<S, T>(S[] array, long start, Func<S, long, bool> predicate, Func<S, long, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		return ToLongArray(array, start, array.LongLength - start, predicate, evaluation);
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
	public static T[] ToLongArray<S, T>(S[] array, long start, long count, Func<S, bool> predicate, Func<S, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(evaluation, "evaluation");
		return ToLongArray(array, start, count, (S x, long i) => predicate(x), (S x, long i) => evaluation(x));
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
	public static T[] ToLongArray<S, T>(S[] array, long start, long count, Func<S, long, bool> predicate, Func<S, long, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertIndexRange(start, 0L, array.LongLength - 1, "start");
		Guard.AssertBetween(count, 0L, array.LongLength - start, "count");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(evaluation, "evaluation");
		return CollectionHelper.Select(CollectionHelper.Where(CollectionHelper.LongTake(CollectionHelper.LongSkip(array, start), count), predicate), evaluation).ToArray();
	}

	/// <summary>
	/// 将二维数组转换为数组的列表
	/// </summary>
	/// <typeparam name="T">数组元素类型</typeparam>
	/// <param name="array">当前二维数组</param>
	/// <returns>转换后的数组列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static List<T[]> ToArrayList<T>(T[,] array)
	{
		Guard.AssertNotNull(array, "array");
		List<T[]> list = new List<T[]>(array.GetLength(0));
		T[][] array2 = Split(array);
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
	public static List<T> ToList<T>(Array array)
	{
		Guard.AssertNotNull(array, "array");
		return (from x in array.OfType<object>()
			select ObjectHelper.As<T>(x)).ToList();
	}

	/// <summary>
	/// 将当前数组转换为 <see cref="T:System.Collections.Generic.List`1" /> 列表对象
	/// </summary>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">待转换的当前数组</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluation" /> 为空。</exception>
	public static List<T> ToList<T>(Array array, Func<object, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(evaluation, "evaluation");
		return array.OfType<object>().Select(evaluation).ToList();
	}

	/// <summary>
	/// 将当前数组转换为 <see cref="T:System.Collections.Generic.List`1" /> 列表对象
	/// </summary>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">待转换的当前数组</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluation" /> 为空。</exception>
	public static List<T> ToList<T>(Array array, Func<object, int, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(evaluation, "evaluation");
		return array.OfType<object>().Select(evaluation).ToList();
	}

	/// <summary>
	/// 将当前数组转换为 <see cref="T:System.Collections.Generic.List`1" /> 列表对象
	/// </summary>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">待转换的当前数组</param>
	/// <param name="predicate">数组元素筛选方法</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	public static List<T> ToList<T>(Array array, Func<object, bool> predicate, Func<object, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(evaluation, "evaluation");
		return ToList(array, 0, array.Length, predicate, evaluation);
	}

	/// <summary>
	/// 将当前数组转换为 <see cref="T:System.Collections.Generic.List`1" /> 列表对象
	/// </summary>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">数组元素筛选方法</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	public static List<T> ToList<T>(Array array, Func<object, int, bool> predicate, Func<object, int, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(evaluation, "evaluation");
		return ToList(array, 0, array.Length, predicate, evaluation);
	}

	/// <summary>
	/// 将当前数组转换为 <see cref="T:System.Collections.Generic.List`1" /> 列表对象
	/// </summary>
	/// <typeparam name="T">列表元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">转换的起始索引位置</param>
	/// <param name="predicate">数组元素筛选方法</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	public static List<T> ToList<T>(Array array, int start, Func<object, bool> predicate, Func<object, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(evaluation, "evaluation");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return ToList(array, start, array.Length - start, predicate, evaluation);
	}

	/// <summary>
	/// 将当前数组转换为 <see cref="T:System.Collections.Generic.List`1" /> 列表对象
	/// </summary>
	/// <typeparam name="T">列表元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">转换的起始索引位置</param>
	/// <param name="predicate">数组元素筛选方法</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	public static List<T> ToList<T>(Array array, int start, Func<object, int, bool> predicate, Func<object, int, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(evaluation, "evaluation");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return ToList(array, start, array.Length - start, predicate, evaluation);
	}

	/// <summary>
	/// 将当前数组转换为 <see cref="T:System.Collections.Generic.List`1" /> 列表对象
	/// </summary>
	/// <typeparam name="T">列表元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">转换的起始索引位置</param>
	/// <param name="count">转换的元素个数</param>
	/// <param name="predicate">数组元素筛选方法</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static List<T> ToList<T>(Array array, int start, int count, Func<object, bool> predicate, Func<object, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(evaluation, "evaluation");
		return ToList(array, start, count, (object x, int i) => predicate(x), (object x, int i) => evaluation(x));
	}

	/// <summary>
	/// 将当前数组转换为 <see cref="T:System.Collections.Generic.List`1" /> 列表对象
	/// </summary>
	/// <typeparam name="T">列表元素类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">转换的起始索引位置</param>
	/// <param name="count">转换的元素个数</param>
	/// <param name="predicate">数组元素筛选方法</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static List<T> ToList<T>(Array array, int start, int count, Func<object, int, bool> predicate, Func<object, int, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(evaluation, "evaluation");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		Guard.AssertBetween(count, 0, array.Length - start, "count");
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
				list.Add(evaluation(item, index));
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
	public static List<T> ToList<S, T>(S[] array)
	{
		Guard.AssertNotNull(array, "array");
		return ToList(array, (S x) => ObjectHelper.As<T>(x));
	}

	/// <summary>
	/// 将当前数组转换为 <see cref="T:System.Collections.Generic.List`1" /> 列表对象
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">待转换的当前数组</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluation" /> 为空。</exception>
	public static List<T> ToList<S, T>(S[] array, Func<S, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(evaluation, "evaluation");
		return ToList(array, (S x, int i) => evaluation(x));
	}

	/// <summary>
	/// 将当前数组转换为 <see cref="T:System.Collections.Generic.List`1" /> 列表对象
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">待转换的当前数组</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="evaluation" /> 为空。</exception>
	public static List<T> ToList<S, T>(S[] array, Func<S, int, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(evaluation, "evaluation");
		List<T> list = new List<T>(array.Length);
		for (int i = 0; i < array.Length; i++)
		{
			list[i] = evaluation(array[i], i);
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
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	public static List<T> ToList<S, T>(S[] array, Func<S, bool> predicate, Func<S, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(evaluation, "evaluation");
		return ToList(array, 0, array.Length, predicate, evaluation);
	}

	/// <summary>
	/// 将当前数组转换为 <see cref="T:System.Collections.Generic.List`1" /> 列表对象
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="predicate">数组元素筛选方法</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	public static List<T> ToList<S, T>(S[] array, Func<S, int, bool> predicate, Func<S, int, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(evaluation, "evaluation");
		return ToList(array, 0, array.Length, predicate, evaluation);
	}

	/// <summary>
	/// 将当前数组转换为 <see cref="T:System.Collections.Generic.List`1" /> 列表对象
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始转换的位置索引</param>
	/// <param name="predicate">数组元素筛选方法</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	public static List<T> ToList<S, T>(S[] array, int start, Func<S, bool> predicate, Func<S, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(evaluation, "evaluation");
		return ToList(array, start, (S x, int i) => predicate(x), (S x, int i) => evaluation(x));
	}

	/// <summary>
	/// 将当前数组转换为 <see cref="T:System.Collections.Generic.List`1" /> 列表对象
	/// </summary>
	/// <typeparam name="S">当前数组元素类型</typeparam>
	/// <typeparam name="T">目标数组的类型</typeparam>
	/// <param name="array">当前数组</param>
	/// <param name="start">开始转换的位置索引</param>
	/// <param name="predicate">数组元素筛选方法</param>
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	public static List<T> ToList<S, T>(S[] array, int start, Func<S, int, bool> predicate, Func<S, int, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(evaluation, "evaluation");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		return ToList(array, start, array.Length - start, predicate, evaluation);
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
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static List<T> ToList<S, T>(S[] array, int start, int count, Func<S, bool> predicate, Func<S, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(evaluation, "evaluation");
		return ToList(array, start, count, (S x, int i) => predicate(x), (S x, int i) => evaluation(x));
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
	/// <param name="evaluation">数组元素转换方法</param>
	/// <returns>转换后的列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；或者 <paramref name="predicate" /> 为空；或者 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始剩余的元素数量。</exception>
	public static List<T> ToList<S, T>(S[] array, int start, int count, Func<S, int, bool> predicate, Func<S, int, T> evaluation)
	{
		Guard.AssertNotNull(array, "array");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(evaluation, "evaluation");
		Guard.AssertIndexRange(start, 0, array.Length - 1, "start");
		Guard.AssertBetween(count, 0, array.Length - start, "count");
		List<T> list = new List<T>();
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			if (predicate(array[i], i))
			{
				list.Add(evaluation(array[i], i));
			}
		}
		return list;
	}
}
