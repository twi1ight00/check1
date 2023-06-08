using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// <see cref="T:System.Text.StringBuilder" /> 扩展方法类
/// </summary>
public static class StringBuilderExtensions
{
	/// <summary>
	/// 向当前可变文本中追加指定数量的数值
	/// </summary>
	/// <typeparam name="T">数值类型</typeparam>
	/// <param name="text">当前可变文本</param>
	/// <param name="value">待追加的数值</param>
	/// <param name="count">追加的数量</param>
	/// <returns>追加后的可变文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">追加的字符数量小于0。</exception>
	public static StringBuilder AppendValue<T>(this StringBuilder text, T value, int count)
	{
		text.GuardNotNull("string builder");
		count.GuardGreaterThanOrEqualTo(0, "count");
		while (count-- > 0)
		{
			text.Append(value);
		}
		return text;
	}

	/// <summary>
	/// 向当前可变文本中追加数值。
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="values">待追加的数值数组</param>
	/// <returns>追加后的可变文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空；或者追加的数值数组 <paramref name="values" /> 为空。</exception>
	public static StringBuilder AppendValue(this StringBuilder text, params object[] values)
	{
		text.GuardNotNull("string builder");
		values.GuardNotNull("values");
		for (int i = 0; i < values.Length; i++)
		{
			text.Append(values[i]);
		}
		return text;
	}

	/// <summary>
	/// 向当前可变文本中追加数值。
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="values">待追加的数值数组</param>
	/// <returns>追加后的可变文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空；或者追加的数值数组 <paramref name="values" /> 为空。</exception>
	public static StringBuilder AppendValue(this StringBuilder text, IEnumerable<object> values)
	{
		text.GuardNotNull("string builder");
		values.GuardNotNull("values");
		foreach (object value in values)
		{
			text.Append(value);
		}
		return text;
	}

	/// <summary>
	/// 向当前可变文本中追加数值。
	/// </summary>
	/// <typeparam name="T">数值类型</typeparam>
	/// <param name="text">当前可变文本</param>
	/// <param name="values">待追加的数值数组</param>
	/// <returns>追加后的可变文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空；或者追加的数值数组 <paramref name="values" /> 为空。</exception>
	public static StringBuilder AppendValue<T>(this StringBuilder text, params T[] values)
	{
		text.GuardNotNull("string builder");
		values.GuardNotNull("values");
		for (int i = 0; i < values.Length; i++)
		{
			text.Append(values[i]);
		}
		return text;
	}

	/// <summary>
	/// 向当前可变文本中追加数值。
	/// </summary>
	/// <typeparam name="T">数值类型</typeparam>
	/// <param name="text">当前可变文本</param>
	/// <param name="values">待追加的数值序列</param>
	/// <returns>追加后的可变文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空；或者追加的数值序列 <paramref name="values" /> 为空。</exception>
	public static StringBuilder AppendValue<T>(this StringBuilder text, IEnumerable<T> values)
	{
		text.GuardNotNull("string builder");
		values.GuardNotNull("values");
		foreach (T value in values)
		{
			text.Append(value);
		}
		return text;
	}

	/// <summary>
	/// 向当前可变文本中追加通过处理复合格式化字符串生成的字符串
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="format">复合格式化字符串</param>
	/// <param name="args">复合格式化参数数组</param>
	/// <param name="provider">格式化提供器</param>
	/// <returns>追加后的可变文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空；或者符合格式化字符串 <paramref name="format" /> 为空；或者格式化参数数组 <paramref name="args" /> 为空。</exception>
	public static StringBuilder AppendFormat(this StringBuilder text, string format, object[] args, IFormatProvider provider)
	{
		text.GuardNotNull("string builder");
		format.GuardNotNull("format");
		args.GuardNotNull("args");
		text.AppendFormat(provider, format, args);
		return text;
	}

	/// <summary>
	/// 在当前可变文本中查找字符的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果在可变文本中找到字符返回字符的位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	public static int IndexOf(this StringBuilder text, char c, bool ignoreCase = false)
	{
		return text.IndexOf(c, CultureInfo.CurrentCulture, ignoreCase);
	}

	/// <summary>
	/// 在当前可变文本中查找字符的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果在可变文本中找到字符返回字符的位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	public static int IndexOf(this StringBuilder text, char c, CultureInfo culture, bool ignoreCase = false)
	{
		return text.IndexOf(c, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 在当前可变文本中查找字符的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="options">比较字符时的选项</param>
	/// <returns>如果在可变文本中找到字符返回字符的位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	public static int IndexOf(this StringBuilder text, char c, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("string builder");
		return text.IndexOf(c, 0, text.Length, culture, options);
	}

	/// <summary>
	/// 在当前可变文本中查找字符的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果在可变文本中找到字符返回字符的位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始查找的字符位置小于0， 或者大于当前可变文本中字符的最大索引。</exception>
	public static int IndexOf(this StringBuilder text, char c, int start, bool ignoreCase = false)
	{
		return text.IndexOf(c, start, CultureInfo.CurrentCulture, ignoreCase);
	}

	/// <summary>
	/// 在当前可变文本中查找字符的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果在可变文本中找到字符返回字符的位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始查找的字符位置小于0， 或者大于当前可变文本中字符的最大索引。</exception>
	public static int IndexOf(this StringBuilder text, char c, int start, CultureInfo culture, bool ignoreCase = false)
	{
		return text.IndexOf(c, start, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 在当前可变文本中查找字符的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="options">比较字符时的选项</param>
	/// <returns>如果在可变文本中找到字符返回字符的位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始查找的字符位置小于0， 或者大于当前可变文本中字符的最大索引。</exception>
	public static int IndexOf(this StringBuilder text, char c, int start, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("string builder");
		start.GuardIndexRange(0, text.Length - 1, "start");
		return text.IndexOf(c, start, text.Length - start, culture, options);
	}

	/// <summary>
	/// 在当前可变文本的区域中查找字符的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="count">查找的字符数量</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果在可变文本中找到字符返回字符的位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始查找的字符位置小于0， 或者大于当前可变文本中字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的字符数量小于0，或者大于从 <paramref name="start" /> 开始剩余的字符数量。</exception>
	public static int IndexOf(this StringBuilder text, char c, int start, int count, bool ignoreCase = false)
	{
		return text.IndexOf(c, start, count, CultureInfo.CurrentCulture, ignoreCase);
	}

	/// <summary>
	/// 在当前可变文本的区域中查找字符的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="count">查找的字符数量</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果在可变文本中找到字符返回字符的位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始查找的字符位置小于0， 或者大于当前可变文本中字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的字符数量小于0，或者大于从 <paramref name="start" /> 开始剩余的字符数量。</exception>
	public static int IndexOf(this StringBuilder text, char c, int start, int count, CultureInfo culture, bool ignoreCase = false)
	{
		return text.IndexOf(c, start, count, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 在当前可变文本的区域中查找字符的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="count">查找的字符数量</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="options">比较字符时的选项</param>
	/// <returns>如果在可变文本中找到字符返回字符的位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始查找的字符位置小于0， 或者大于当前可变文本中字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的字符数量小于0，或者大于从 <paramref name="start" /> 开始剩余的字符数量。</exception>
	public static int IndexOf(this StringBuilder text, char c, int start, int count, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("string builder");
		start.GuardIndexRange(0, text.Length - 1, "start");
		count.GuardBetween(0, text.Length - start, "count");
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			if (text[i].IsEqualTo(c, culture, options))
			{
				return i;
			}
		}
		return -1;
	}

	/// <summary>
	/// 在当前可变文本中查找字符串的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="searching">查找的字符串</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果在可变文本中找到字符串返回该字符串的起始位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	public static int IndexOf(this StringBuilder text, string searching, bool ignoreCase = false)
	{
		return text.IndexOf(searching, CultureInfo.CurrentCulture, ignoreCase);
	}

	/// <summary>
	/// 在当前可变文本中查找字符串的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="searching">查找的字符串</param>
	/// <param name="comparison">比较字符时的选项</param>
	/// <returns>如果在可变文本中找到字符串返回该字符串的起始位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	public static int IndexOf(this StringBuilder text, string searching, StringComparison comparison)
	{
		text.GuardNotNull("text");
		searching.GuardNotNull("searching text");
		return text.IndexOf(searching, 0, text.Length, comparison);
	}

	/// <summary>
	/// 在当前可变文本中查找字符串的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="searching">查找的字符串</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果在可变文本中找到字符串返回该字符串的起始位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	public static int IndexOf(this StringBuilder text, string searching, CultureInfo culture, bool ignoreCase = false)
	{
		return text.IndexOf(searching, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 在当前可变文本中查找字符串的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="searching">查找的字符串</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="options">比较字符时的选项</param>
	/// <returns>如果在可变文本中找到字符串返回该字符串的起始位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	public static int IndexOf(this StringBuilder text, string searching, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		searching.GuardNotNull("searching text");
		return text.IndexOf(searching, 0, text.Length, culture, options);
	}

	/// <summary>
	/// 在当前可变文本中查找字符串的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="searching">查找的字符串</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果在可变文本中找到字符串返回该字符串的起始位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始查找的字符串位置小于0， 或者大于当前可变文本中字符的最大索引。</exception>
	public static int IndexOf(this StringBuilder text, string searching, int start, bool ignoreCase = false)
	{
		return text.IndexOf(searching, start, CultureInfo.CurrentCulture, ignoreCase);
	}

	/// <summary>
	/// 在当前可变文本中查找字符串的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="searching">查找的字符串</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="comparison">比较字符时的选项</param>
	/// <returns>如果在可变文本中找到字符串返回该字符串的起始位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始查找的字符串位置小于0， 或者大于当前可变文本中字符的最大索引。</exception>
	public static int IndexOf(this StringBuilder text, string searching, int start, StringComparison comparison)
	{
		text.GuardNotNull("text");
		searching.GuardNotNull("searching text");
		start.GuardIndexRange(0, text.Length - 1, "start");
		return text.IndexOf(searching, start, text.Length - start, comparison);
	}

	/// <summary>
	/// 在当前可变文本中查找字符串的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="searching">查找的字符串</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果在可变文本中找到字符串返回该字符串的起始位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始查找的字符串位置小于0， 或者大于当前可变文本中字符的最大索引。</exception>
	public static int IndexOf(this StringBuilder text, string searching, int start, CultureInfo culture, bool ignoreCase = false)
	{
		return text.IndexOf(searching, start, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 在当前可变文本中查找字符串的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="searching">查找的字符串</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="options">比较字符时的选项</param>
	/// <returns>如果在可变文本中找到字符串返回该字符串的起始位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始查找的字符串位置小于0， 或者大于当前可变文本中字符的最大索引。</exception>
	public static int IndexOf(this StringBuilder text, string searching, int start, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		searching.GuardNotNull("searching text");
		start.GuardIndexRange(0, text.Length - 1, "start");
		return text.IndexOf(searching, start, text.Length - start, culture, options);
	}

	/// <summary>
	/// 在当前可变文本的区域中查找字符串的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="searching">查找的字符串</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="count">查找的字符数量</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果在可变文本中找到字符串返回该字符串的起始位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始查找的字符串位置小于0， 或者大于当前可变文本中字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的字符串数量小于0，或者大于从 <paramref name="start" /> 开始剩余的字符数量。</exception>
	public static int IndexOf(this StringBuilder text, string searching, int start, int count, bool ignoreCase = false)
	{
		return text.IndexOf(searching, start, count, CultureInfo.CurrentCulture, ignoreCase);
	}

	/// <summary>
	/// 在当前可变文本的区域中查找字符串的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="searching">查找的字符串</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="count">查找的字符数量</param>
	/// <param name="comparison">比较字符时的选项</param>
	/// <returns>如果在可变文本中找到字符串返回该字符串的起始位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始查找的字符串位置小于0， 或者大于当前可变文本中字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的字符串数量小于0，或者大于从 <paramref name="start" /> 开始剩余的字符数量。</exception>
	public static int IndexOf(this StringBuilder text, string searching, int start, int count, StringComparison comparison)
	{
		text.GuardNotNull("text");
		searching.GuardNotNull("searching text");
		start.GuardIndexRange(0, text.Length - 1, "start");
		count.GuardBetween(0, text.Length - start, "count");
		if (searching.Length > count)
		{
			return -1;
		}
		int end = start + count;
		bool found = false;
		while (start < end)
		{
			if (searching.Length <= end - start)
			{
				found = true;
				for (int i = 0; i < searching.Length; i++)
				{
					if (!searching[i].IsEqualTo(text[i + start], comparison))
					{
						start++;
						found = false;
						break;
					}
				}
				if (found)
				{
					return start;
				}
				continue;
			}
			return -1;
		}
		return -1;
	}

	/// <summary>
	/// 在当前可变文本的区域中查找字符串的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="searching">查找的字符串</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="count">查找的字符数量</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果在可变文本中找到字符串返回该字符串的起始位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始查找的字符串位置小于0， 或者大于当前可变文本中字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的字符串数量小于0，或者大于从 <paramref name="start" /> 开始剩余的字符数量。</exception>
	public static int IndexOf(this StringBuilder text, string searching, int start, int count, CultureInfo culture, bool ignoreCase = false)
	{
		return text.IndexOf(searching, start, count, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 在当前可变文本的区域中查找字符串的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="searching">查找的字符串</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="count">查找的字符数量</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="options">比较字符时的选项</param>
	/// <returns>如果在可变文本中找到字符串返回该字符串的起始位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始查找的字符串位置小于0， 或者大于当前可变文本中字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的字符串数量小于0，或者大于从 <paramref name="start" /> 开始剩余的字符数量。</exception>
	public static int IndexOf(this StringBuilder text, string searching, int start, int count, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		searching.GuardNotNull("searching text");
		start.GuardIndexRange(0, text.Length - 1, "start");
		count.GuardBetween(0, text.Length - start, "count");
		if (searching.Length > count)
		{
			return -1;
		}
		int end = start + count;
		bool found = false;
		while (start < end)
		{
			if (searching.Length <= end - start)
			{
				found = true;
				for (int i = 0; i < searching.Length; i++)
				{
					if (!searching[i].IsEqualTo(text[i + start], culture, options))
					{
						start++;
						found = false;
						break;
					}
				}
				if (found)
				{
					return start;
				}
				continue;
			}
			return -1;
		}
		return -1;
	}

	/// <summary>
	/// 向当前可变文本的指定位置中插入指定数量的数值
	/// </summary>
	/// <typeparam name="T">数值类型</typeparam>
	/// <param name="text">当前可变文本</param>
	/// <param name="index">插入位置索引</param>
	/// <param name="value">插入的数值</param>
	/// <param name="count">插入数值的数量</param>
	/// <returns>插入的可变文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">插入位置索引 <paramref name="index" /> 小于0，或者大于可变文本的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">插入的数量 <paramref name="count" /> 小于0。</exception>
	public static StringBuilder Insert<T>(this StringBuilder text, int index, T value, int count)
	{
		text.GuardNotNull("string builder");
		index.GuardIndexRange(0, text.Length - 1, "index");
		count.GuardBetween(0, text.Length, "count");
		while (count-- > 0)
		{
			text.Insert(index++, value);
		}
		return text;
	}

	/// <summary>
	/// 向当前可变文本的指定位置中插入数值
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="index">插入位置索引</param>
	/// <param name="values">插入的数值数组</param>
	/// <returns>插入的可变文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空；插入的数值数组 <paramref name="values" /> 为空。</exception>
	public static StringBuilder Insert(this StringBuilder text, int index, params object[] values)
	{
		text.GuardNotNull("string builder");
		index.GuardIndexRange(0, text.Length - 1, "index");
		values.GuardNotNull("values");
		for (int i = 0; i < values.Length; i++)
		{
			text.Insert(index++, values[i]);
		}
		return text;
	}

	/// <summary>
	/// 向当前可变文本的指定位置中插入数值
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="index">插入位置索引</param>
	/// <param name="values">插入的数值序列</param>
	/// <returns>插入的可变文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空；插入的数值数组 <paramref name="values" /> 为空。</exception>
	public static StringBuilder Insert(this StringBuilder text, int index, IEnumerable<object> values)
	{
		text.GuardNotNull("builder");
		index.GuardIndexRange(0, text.Length - 1, "index");
		values.GuardNotNull("values");
		foreach (object value in values)
		{
			text.Insert(index++, value);
		}
		return text;
	}

	/// <summary>
	/// 向当前可变文本的指定位置中插入数值
	/// </summary>
	/// <typeparam name="T">数值类型</typeparam>
	/// <param name="text">当前可变文本</param>
	/// <param name="index">插入位置索引</param>
	/// <param name="values">插入的数值数组</param>
	/// <returns>插入的可变文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空；插入的数值数组 <paramref name="values" /> 为空。</exception>
	public static StringBuilder Insert<T>(this StringBuilder text, int index, params T[] values)
	{
		text.GuardNotNull("string builder");
		index.GuardIndexRange(0, text.Length - 1, "index");
		values.GuardNotNull("values");
		for (int i = 0; i < values.Length; i++)
		{
			text.Insert(index++, values[i]);
		}
		return text;
	}

	/// <summary>
	/// 向当前可变文本的指定位置中插入数值
	/// </summary>
	/// <typeparam name="T">数值类型</typeparam>
	/// <param name="text">当前可变文本</param>
	/// <param name="index">插入位置索引</param>
	/// <param name="values">插入的数值序列</param>
	/// <returns>插入的可变文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空；插入的数值数组 <paramref name="values" /> 为空。</exception>
	public static StringBuilder Insert<T>(this StringBuilder text, int index, IEnumerable<T> values)
	{
		text.GuardNotNull("builder");
		index.GuardIndexRange(0, text.Length - 1, "index");
		values.GuardNotNull("values");
		foreach (T value2 in values)
		{
			object value = value2;
			text.Insert(index++, value);
		}
		return text;
	}

	/// <summary>
	/// 在当前可变文本中逆向查找字符的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果在可变文本中找到字符返回字符的位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	public static int LastIndexOf(this StringBuilder text, char c, bool ignoreCase = false)
	{
		return text.LastIndexOf(c, CultureInfo.CurrentCulture, ignoreCase);
	}

	/// <summary>
	/// 在当前可变文本中逆向查找字符的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果在可变文本中找到字符返回字符的位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	public static int LastIndexOf(this StringBuilder text, char c, CultureInfo culture, bool ignoreCase = false)
	{
		return text.LastIndexOf(c, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 在当前可变文本中逆向查找字符的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="options">比较字符时的选项</param>
	/// <returns>如果在可变文本中找到字符返回字符的位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	public static int LastIndexOf(this StringBuilder text, char c, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("string builder");
		return text.LastIndexOf(c, 0, text.Length, culture, options);
	}

	/// <summary>
	/// 在当前可变文本中逆向查找字符的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果在可变文本中找到字符返回字符的位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始查找的字符位置小于0， 或者大于当前可变文本中字符的最大索引。</exception>
	public static int LastIndexOf(this StringBuilder text, char c, int start, bool ignoreCase = false)
	{
		return text.LastIndexOf(c, start, CultureInfo.CurrentCulture, ignoreCase);
	}

	/// <summary>
	/// 在当前可变文本中逆向查找字符的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果在可变文本中找到字符返回字符的位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始查找的字符位置小于0， 或者大于当前可变文本中字符的最大索引。</exception>
	public static int LastIndexOf(this StringBuilder text, char c, int start, CultureInfo culture, bool ignoreCase = false)
	{
		return text.LastIndexOf(c, start, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 在当前可变文本中逆向查找字符的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="options">比较字符时的选项</param>
	/// <returns>如果在可变文本中找到字符返回字符的位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始查找的字符位置小于0， 或者大于当前可变文本中字符的最大索引。</exception>
	public static int LastIndexOf(this StringBuilder text, char c, int start, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("string builder");
		start.GuardIndexRange(0, text.Length - 1, "start");
		return text.LastIndexOf(c, start, text.Length - start, culture, options);
	}

	/// <summary>
	/// 在当前可变文本的区域中逆向查找字符的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="count">查找的字符数量</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果在可变文本中找到字符返回字符的位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始查找的字符位置小于0， 或者大于当前可变文本中字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的字符数量小于0，或者大于从 <paramref name="start" /> 开始逆向剩余的字符数量。</exception>
	public static int LastIndexOf(this StringBuilder text, char c, int start, int count, bool ignoreCase = false)
	{
		return text.LastIndexOf(c, start, count, CultureInfo.CurrentCulture, ignoreCase);
	}

	/// <summary>
	/// 在当前可变文本的区域中逆向查找字符的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="count">查找的字符数量</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果在可变文本中找到字符返回字符的位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始查找的字符位置小于0， 或者大于当前可变文本中字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的字符数量小于0，或者大于从 <paramref name="start" /> 开始逆向剩余的字符数量。</exception>
	public static int LastIndexOf(this StringBuilder text, char c, int start, int count, CultureInfo culture, bool ignoreCase = false)
	{
		return text.LastIndexOf(c, start, count, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 在当前可变文本的区域中逆向查找字符的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="count">查找的字符数量</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="options">比较字符时的选项</param>
	/// <returns>如果在可变文本中找到字符返回字符的位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始查找的字符位置小于0， 或者大于当前可变文本中字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的字符数量小于0，或者大于从 <paramref name="start" /> 开始逆向剩余的字符数量。</exception>
	public static int LastIndexOf(this StringBuilder text, char c, int start, int count, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("string builder");
		start.GuardIndexRange(0, text.Length - 1, "start");
		count.GuardBetween(0, start + 1, "count");
		int end = start - count;
		for (int i = start; i > end; i--)
		{
			if (text[i].IsEqualTo(c, culture, options))
			{
				return i;
			}
		}
		return -1;
	}

	/// <summary>
	/// 在当前可变文本中逆向查找字符串的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="searching">查找的字符串</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果在可变文本中找到字符串返回该字符串的起始位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	public static int LastIndexOf(this StringBuilder text, string searching, bool ignoreCase = false)
	{
		return text.LastIndexOf(searching, CultureInfo.CurrentCulture, ignoreCase);
	}

	/// <summary>
	/// 在当前可变文本中逆向查找字符串的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="searching">查找的字符串</param>
	/// <param name="comparison">比较字符时的选项</param>
	/// <returns>如果在可变文本中找到字符串返回该字符串的起始位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	public static int LastIndexOf(this StringBuilder text, string searching, StringComparison comparison)
	{
		text.GuardNotNull("text");
		searching.GuardNotNull("searching text");
		return text.LastIndexOf(searching, 0, text.Length, comparison);
	}

	/// <summary>
	/// 在当前可变文本中逆向查找字符串的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="searching">查找的字符串</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果在可变文本中找到字符串返回该字符串的起始位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	public static int LastIndexOf(this StringBuilder text, string searching, CultureInfo culture, bool ignoreCase = false)
	{
		return text.LastIndexOf(searching, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 在当前可变文本中逆向查找字符串的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="searching">查找的字符串</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="options">比较字符时的选项</param>
	/// <returns>如果在可变文本中找到字符串返回该字符串的起始位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	public static int LastIndexOf(this StringBuilder text, string searching, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		searching.GuardNotNull("searching text");
		return text.LastIndexOf(searching, 0, text.Length, culture, options);
	}

	/// <summary>
	/// 在当前可变文本中逆向查找字符串的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="searching">查找的字符串</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果在可变文本中找到字符串返回该字符串的起始位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始查找的字符串位置小于0， 或者大于当前可变文本中字符的最大索引。</exception>
	public static int LastIndexOf(this StringBuilder text, string searching, int start, bool ignoreCase = false)
	{
		return text.LastIndexOf(searching, start, CultureInfo.CurrentCulture, ignoreCase);
	}

	/// <summary>
	/// 在当前可变文本中逆向查找字符串的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="searching">查找的字符串</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="comparison">比较字符时的选项</param>
	/// <returns>如果在可变文本中找到字符串返回该字符串的起始位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始查找的字符串位置小于0， 或者大于当前可变文本中字符的最大索引。</exception>
	public static int LastIndexOf(this StringBuilder text, string searching, int start, StringComparison comparison)
	{
		text.GuardNotNull("text");
		searching.GuardNotNull("searching text");
		start.GuardIndexRange(0, text.Length - 1, "start");
		return text.LastIndexOf(searching, start, text.Length - start, comparison);
	}

	/// <summary>
	/// 在当前可变文本中逆向查找字符串的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="searching">查找的字符串</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果在可变文本中找到字符串返回该字符串的起始位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始查找的字符串位置小于0， 或者大于当前可变文本中字符的最大索引。</exception>
	public static int LastIndexOf(this StringBuilder text, string searching, int start, CultureInfo culture, bool ignoreCase = false)
	{
		return text.LastIndexOf(searching, start, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 在当前可变文本中逆向查找字符串的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="searching">查找的字符串</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="options">比较字符时的选项</param>
	/// <returns>如果在可变文本中找到字符串返回该字符串的起始位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始查找的字符串位置小于0， 或者大于当前可变文本中字符的最大索引。</exception>
	public static int LastIndexOf(this StringBuilder text, string searching, int start, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		searching.GuardNotNull("searching text");
		start.GuardIndexRange(0, text.Length - 1, "start");
		return text.IndexOf(searching, start, text.Length - start, culture, options);
	}

	/// <summary>
	/// 在当前可变文本的区域中逆向查找字符串的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="searching">查找的字符串</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="count">查找的字符数量</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果在可变文本中找到字符串返回该字符串的起始位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始查找的字符串位置小于0， 或者大于当前可变文本中字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的字符串数量小于0，或者大于从 <paramref name="start" /> 开始逆向剩余的字符数量。</exception>
	public static int LastIndexOf(this StringBuilder text, string searching, int start, int count, bool ignoreCase = false)
	{
		return text.LastIndexOf(searching, start, count, CultureInfo.CurrentCulture, ignoreCase);
	}

	/// <summary>
	/// 在当前可变文本的区域中逆向查找字符串的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="searching">查找的字符串</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="count">查找的字符数量</param>
	/// <param name="comparison">比较字符时的选项</param>
	/// <returns>如果在可变文本中找到字符串返回该字符串的起始位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始查找的字符串位置小于0， 或者大于当前可变文本中字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的字符串数量小于0，或者大于从 <paramref name="start" /> 开始逆向剩余的字符数量。</exception>
	public static int LastIndexOf(this StringBuilder text, string searching, int start, int count, StringComparison comparison)
	{
		text.GuardNotNull("text");
		searching.GuardNotNull("searching text");
		start.GuardIndexRange(0, text.Length - 1, "start");
		count.GuardBetween(0, text.Length + 1, "count");
		if (searching.Length > count)
		{
			return -1;
		}
		int end = start - count;
		bool found = false;
		while (start > end)
		{
			if (searching.Length <= start - end)
			{
				found = true;
				for (int i = 0; i < searching.Length; i++)
				{
					if (!searching[i].IsEqualTo(text[start - searching.Length + 1 + i], comparison))
					{
						start--;
						found = false;
						break;
					}
				}
				if (found)
				{
					return start;
				}
				continue;
			}
			return -1;
		}
		return -1;
	}

	/// <summary>
	/// 在当前可变文本的区域中逆向查找字符串的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="searching">查找的字符串</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="count">查找的字符数量</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果在可变文本中找到字符串返回该字符串的起始位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始查找的字符串位置小于0， 或者大于当前可变文本中字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的字符串数量小于0，或者大于从 <paramref name="start" /> 开始逆向剩余的字符数量。</exception>
	public static int LastIndexOf(this StringBuilder text, string searching, int start, int count, CultureInfo culture, bool ignoreCase = false)
	{
		return text.LastIndexOf(searching, start, count, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 在当前可变文本的区域中逆向查找字符串的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="searching">查找的字符串</param>
	/// <param name="start">开始查找的位置</param>
	/// <param name="count">查找的字符数量</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="options">比较字符时的选项</param>
	/// <returns>如果在可变文本中找到字符串返回该字符串的起始位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始查找的字符串位置小于0， 或者大于当前可变文本中字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的字符串数量小于0，或者大于从 <paramref name="start" /> 开始逆向剩余的字符数量。</exception>
	public static int LastIndexOf(this StringBuilder text, string searching, int start, int count, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		searching.GuardNotNull("searching text");
		start.GuardIndexRange(0, text.Length - 1, "start");
		count.GuardBetween(0, text.Length + 1, "count");
		if (searching.Length > count)
		{
			return -1;
		}
		int end = start - count;
		bool found = false;
		while (start > end)
		{
			if (searching.Length <= start - end)
			{
				found = true;
				for (int i = 0; i < searching.Length; i++)
				{
					if (!searching[i].IsEqualTo(text[start - searching.Length + 1 + i], culture, options))
					{
						start--;
						found = false;
						break;
					}
				}
				if (found)
				{
					return start;
				}
				continue;
			}
			return -1;
		}
		return -1;
	}

	/// <summary>
	/// 获取当前可变字符的子字符串
	/// </summary>
	/// <param name="text">当前可变字符串</param>
	/// <param name="start">子字符串的起始位置</param>
	/// <returns>获取的子字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变字符串为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">起始位置小于0，或者大于当前可变字符串的最大索引。</exception>
	public static string Substring(this StringBuilder text, int start)
	{
		text.GuardNotNull("text");
		start.GuardIndexRange(0, text.Length - 1, "start");
		return text.ToString(start, text.Length - start);
	}

	/// <summary>
	/// 获取当前可变字符的子字符串
	/// </summary>
	/// <param name="text">当前可变字符串</param>
	/// <param name="start">子字符串的起始位置</param>
	/// <param name="count">获取的子字符串的字符数量</param>
	/// <returns>获取的子字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变字符串为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">起始位置小于0，或者大于当前可变字符串的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">子字符串字符数量小于0，或者大于从 <paramref name="start" /> 开始剩余的字符数量。</exception>
	public static string Substring(this StringBuilder text, int start, int count)
	{
		text.GuardNotNull("text");
		start.GuardIndexRange(0, text.Length - 1, "start");
		count.GuardBetween(0, text.Length - start, "count");
		return text.ToString(start, count);
	}
}
