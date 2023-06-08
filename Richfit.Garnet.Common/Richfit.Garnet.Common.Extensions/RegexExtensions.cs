using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// <see cref="T:System.Text.RegularExpressions.Regex" /> 类型扩展方法
/// </summary>
public static class RegexExtensions
{
	/// <summary>
	/// 检测当前的正则表达式是否在输入文本中存在匹配项目
	/// </summary>
	/// <param name="regex">当前正则表达式</param>
	/// <param name="text">输入文本</param>
	/// <param name="times">检测匹配的次数</param>
	/// <returns>如果存在匹配返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前正则模式为空；或者输入文本 <paramref name="text" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">匹配次数 <paramref name="times" /> 小于1。</exception>
	public static bool IsPartialMatch(this Regex regex, string text, int times = 1)
	{
		if (times == 1)
		{
			return regex.IsMatch(text);
		}
		return regex.GetMatch(text, times).IsNotNull();
	}

	/// <summary>
	/// 检测当前的正则表达式是否在输入文本的区域中存在匹配项目
	/// </summary>
	/// <param name="regex">当前正则表达式</param>
	/// <param name="text">输入文本</param>
	/// <param name="start">检测区域的起始字符位置</param>
	/// <param name="count">检测区域的字符数量</param>
	/// <param name="times">检测匹配次数</param>
	/// <returns>如果存在匹配返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前正则模式为空；或者输入文本 <paramref name="text" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置 <paramref name="start" /> 小于0，或者大于输入文本的最大字符索引</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域内字符数量小于0，或者大于输入文本从 <paramref name="start" /> 起剩余的字符数量；或者匹配次数 <paramref name="times" /> 小于1。</exception>
	public static bool IsPartialMatch(this Regex regex, string text, int start, int count, int times = 1)
	{
		return regex.GetMatch(text, start, count, times).IsNotNull();
	}

	/// <summary>
	/// 检测当前的正则表达式是否与输入文本完全匹配（从文本开始到文本结束整体与当前正则表达式匹配）
	/// </summary>
	/// <param name="regex">当前正则表达式</param>
	/// <param name="text">输入文本</param>
	/// <returns>如果存在匹配返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前正则表达式为空；或者输入文本 <paramref name="text" /> 为空。</exception>
	public static bool IsWholeMatch(this Regex regex, string text)
	{
		regex.GuardNotNull("regex");
		text.GuardNotNull("text");
		return regex.IsWholeMatch(text, 0, text.Length);
	}

	/// <summary>
	/// 检测当前的正则表达式是否与输入文本的区域完全匹配（从区域开始到区域结束整体与当前正则表达式匹配）
	/// </summary>
	/// <param name="regex">当前正则表达式</param>
	/// <param name="text">输入文本</param>
	/// <param name="start">检测区域的起始字符位置</param>
	/// <param name="count">检测区域的字符数量</param>
	/// <returns>如果存在匹配返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前正则模式为空；或者输入文本 <paramref name="text" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置 <paramref name="start" /> 小于0，或者大于输入文本的最大字符索引</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域内字符数量小于0，或者大于输入文本从 <paramref name="start" /> 起剩余的字符数量。</exception>
	public static bool IsWholeMatch(this Regex regex, string text, int start, int count)
	{
		regex.GuardNotNull("regex");
		text.GuardNotNull("text");
		start.GuardIndexRange(0, text.Length - 1, "start");
		count.GuardBetween(0, text.Length - start, "count");
		return regex.GetMatches(text, (Match m) => m.Success && m.Index == start && m.Length == count).Any();
	}

	/// <summary>
	/// 获取当前匹配模式在输入文本中逆向匹配指定次数的匹配项目
	/// </summary>
	/// <param name="regex">当前正则模式</param>
	/// <param name="text">输入文本</param>
	/// <param name="times">执行匹配的次数，默认为1次。</param>
	/// <returns>符合条件的匹配项</returns>
	/// <exception cref="T:System.ArgumentNullException">当前正则模式为空；或者输入文本 <paramref name="text" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">匹配次数 <paramref name="times" /> 小于1。</exception>
	public static Match GetLastMatch(this Regex regex, string text, int times = 1)
	{
		text.GuardNotNull("text");
		if (times == 1)
		{
			regex = EnsureRightToLeftOption(regex);
			return regex.Match(text);
		}
		return regex.GetLastMatch(text, text.Length - 1, text.Length, times);
	}

	/// <summary>
	/// 获取当前匹配模式在输入文本的区域内逆向匹配指定次数的匹配项目
	/// </summary>
	/// <param name="regex">当前正则模式</param>
	/// <param name="text">输入文本</param>
	/// <param name="start">区域的起始的字符索引</param>
	/// <param name="count">区域内的字符数量</param>
	/// <param name="times">执行匹配的次数，默认为1次。</param>
	/// <returns>符合条件的匹配项</returns>
	/// <exception cref="T:System.ArgumentNullException">当前正则模式为空；或者输入文本 <paramref name="text" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置 <paramref name="start" /> 小于0，或者大于输入文本的最大字符索引</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域内字符数量小于0，或者大于输入文本从 <paramref name="start" /> 起逆向剩余的字符数量；或者执行匹配的次数 <paramref name="times" /> 小于1。</exception>
	public static Match GetLastMatch(this Regex regex, string text, int start, int count, int times = 1)
	{
		regex.GuardNotNull("regex");
		text.GuardNotNull("text");
		start.GuardIndexRange(0, text.Length - 1, "start");
		count.GuardBetween(0, start + 1, "count");
		times.GuardGreaterThanOrEqualTo(1, "times");
		regex = EnsureRightToLeftOption(regex);
		int end = start - count;
		int matched = 0;
		return regex.Matches(text, start).OfType<Match>().FirstOrDefault((Match m) => m.Success && end < m.Index && m.Index <= start && m.Index + m.Length - 1 <= start && ++matched <= times);
	}

	/// <summary>
	/// 获取当前匹配模式在输入文本中逆向匹配的项目
	/// </summary>
	/// <param name="regex">当前正则模式</param>
	/// <param name="text">输入文本</param>
	/// <returns>符合条件的匹配项</returns>
	/// <exception cref="T:System.ArgumentNullException">当前正则模式为空；或者输入文本 <paramref name="text" /> 为空。</exception>
	public static Match[] GetLastMatches(this Regex regex, string text)
	{
		text.GuardNotNull("text");
		regex = EnsureRightToLeftOption(regex);
		return regex.Matches(text).OfType<Match>().ToArray();
	}

	/// <summary>
	/// 获取当前匹配模式在输入文本指定位置开始的逆向匹配的项目
	/// </summary>
	/// <param name="regex">当前正则模式</param>
	/// <param name="text">输入文本</param>
	/// <param name="start">开始匹配的字符索引</param>
	/// <returns>符合条件的匹配项</returns>
	/// <exception cref="T:System.ArgumentNullException">当前正则模式为空；或者输入文本 <paramref name="text" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始匹配的起始位置 <paramref name="start" /> 小于0，或者大于输入文本的最大字符索引</exception>
	public static Match[] GetLastMatches(this Regex regex, string text, int start)
	{
		text.GuardNotNull("text");
		return regex.GetLastMatches(text, start, start + 1);
	}

	/// <summary>
	/// 获取当前匹配模式在输入文本的区域内的逆向匹配的项目
	/// </summary>
	/// <param name="regex">当前正则模式</param>
	/// <param name="text">输入文本</param>
	/// <param name="start">区域的起始的字符索引</param>
	/// <param name="count">区域内的字符数量</param>
	/// <returns>符合条件的匹配项</returns>
	/// <exception cref="T:System.ArgumentNullException">当前正则模式为空；或者输入文本 <paramref name="text" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置 <paramref name="start" /> 小于0，或者大于输入文本的最大字符索引</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域内字符数量小于0，或者大于输入文本从 <paramref name="start" /> 起剩余的字符数量。</exception>
	public static Match[] GetLastMatches(this Regex regex, string text, int start, int count)
	{
		regex.GuardNotNull("regex");
		text.GuardNotNull("text");
		start.GuardIndexRange(0, text.Length - 1, "start");
		count.GuardBetween(0, start + 1, "count");
		regex = EnsureRightToLeftOption(regex);
		int end = start - count;
		return (from m in regex.Matches(text, start).OfType<Match>()
			where m.Success && end < m.Index && m.Index <= start && m.Index + m.Length - 1 <= start
			select m).ToArray();
	}

	/// <summary>
	/// 获取当前匹配模式在输入文本中满足条件的逆向匹配的项目
	/// </summary>
	/// <param name="regex">当前正则模式</param>
	/// <param name="text">输入文本</param>
	/// <param name="predicate">匹配项目筛选条件</param>
	/// <returns>符合条件的匹配项目</returns>
	/// <exception cref="T:System.ArgumentNullException">当前正则模式为空；或者输入文本 <paramref name="text" /> 为空；或者匹配项目筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static Match[] GetLastMatches(this Regex regex, string text, Func<Match, bool> predicate)
	{
		regex.GuardNotNull("regex");
		text.GuardNotNull("text");
		predicate.GuardNotNull("predicate");
		regex = EnsureRightToLeftOption(regex);
		return regex.Matches(text).OfType<Match>().Where(predicate)
			.ToArray();
	}

	/// <summary>
	/// 获取当前匹配模式在输入文本输入文本中满足条件的逆向匹配的项目
	/// </summary>
	/// <param name="regex">当前正则模式</param>
	/// <param name="text">输入文本</param>
	/// <param name="predicate">匹配项目筛选条件</param>
	/// <returns>符合条件的匹配项目</returns>
	/// <exception cref="T:System.ArgumentNullException">当前正则模式为空；或者输入文本 <paramref name="text" /> 为空；或者匹配项目筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static Match[] GetLastMatches(this Regex regex, string text, Func<Match, int, bool> predicate)
	{
		regex.GuardNotNull("regex");
		text.GuardNotNull("text");
		predicate.GuardNotNull("predicate");
		regex = EnsureRightToLeftOption(regex);
		return regex.Matches(text).OfType<Match>().Where(predicate)
			.ToArray();
	}

	/// <summary>
	/// 获取当前匹配模式在输入文本中的匹配指定次数的匹配项
	/// </summary>
	/// <param name="regex">当前正则模式</param>
	/// <param name="text">输入文本</param>
	/// <param name="times">匹配的指定次数，默认为1次。</param>
	/// <returns>符合条件的匹配项</returns>
	/// <exception cref="T:System.ArgumentNullException">当前正则模式为空；或者输入文本 <paramref name="text" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">匹配次数 <paramref name="times" /> 小于1。</exception>
	public static Match GetMatch(this Regex regex, string text, int times = 1)
	{
		text.GuardNotNull("text");
		if (times == 1)
		{
			regex = EnsureLeftToRightOption(regex);
			return regex.Match(text);
		}
		return regex.GetMatch(text, 0, text.Length, times);
	}

	/// <summary>
	/// 获取当前匹配模式在输入文本的区域匹配指定次数的匹配项
	/// </summary>
	/// <param name="regex">当前正则模式</param>
	/// <param name="text">输入文本</param>
	/// <param name="start">区域的起始的字符索引</param>
	/// <param name="count">区域内的字符数量</param>
	/// <param name="times">匹配的指定次数，默认为1次。</param>
	/// <returns>符合条件的匹配项</returns>
	/// <exception cref="T:System.ArgumentNullException">当前正则模式为空；或者输入文本 <paramref name="text" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置 <paramref name="start" /> 小于0，或者大于输入文本的最大字符索引</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域内字符数量小于0，或者大于输入文本从 <paramref name="start" /> 起剩余的字符数量；或者匹配次数 <paramref name="times" /> 小于1。</exception>
	public static Match GetMatch(this Regex regex, string text, int start, int count, int times = 1)
	{
		regex.GuardNotNull("regex");
		text.GuardNotNull("text");
		start.GuardIndexRange(0, text.Length - 1, "start");
		count.GuardBetween(0, text.Length - start, "count");
		times.GuardGreaterThanOrEqualTo(1, "times");
		regex = EnsureLeftToRightOption(regex);
		int end = start + count;
		int matched = 0;
		return regex.Matches(text, start).OfType<Match>().FirstOrDefault((Match m) => m.Success && start <= m.Index && m.Index < end && m.Index + m.Length <= end && ++matched <= times);
	}

	/// <summary>
	/// 获取当前匹配模式在输入文本中的匹配项目
	/// </summary>
	/// <param name="regex">当前正则模式</param>
	/// <param name="text">输入文本</param>
	/// <returns>符合条件的匹配项</returns>
	/// <exception cref="T:System.ArgumentNullException">当前正则模式为空；或者输入文本 <paramref name="text" /> 为空。</exception>
	public static Match[] GetMatches(this Regex regex, string text)
	{
		text.GuardNotNull("text");
		regex = EnsureLeftToRightOption(regex);
		return regex.Matches(text).OfType<Match>().ToArray();
	}

	/// <summary>
	/// 获取当前匹配模式在输入文本指定位置开始的匹配项目
	/// </summary>
	/// <param name="regex">当前正则模式</param>
	/// <param name="text">输入文本</param>
	/// <param name="start">区域的起始的字符索引</param>
	/// <returns>符合条件的匹配项</returns>
	/// <exception cref="T:System.ArgumentNullException">当前正则模式为空；或者输入文本 <paramref name="text" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置 <paramref name="start" /> 小于0，或者大于输入文本的最大字符索引</exception>
	public static Match[] GetMatches(this Regex regex, string text, int start)
	{
		text.GuardNotNull("text");
		return regex.GetMatches(text, start, text.Length - start);
	}

	/// <summary>
	/// 获取当前匹配模式在输入文本的区域内的匹配项目
	/// </summary>
	/// <param name="regex">当前正则模式</param>
	/// <param name="text">输入文本</param>
	/// <param name="start">区域的起始的字符索引</param>
	/// <param name="count">区域内的字符数量</param>
	/// <returns>符合条件的匹配项</returns>
	/// <exception cref="T:System.ArgumentNullException">当前正则模式为空；或者输入文本 <paramref name="text" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置 <paramref name="start" /> 小于0，或者大于输入文本的最大字符索引</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域内字符数量小于0，或者大于输入文本从 <paramref name="start" /> 起剩余的字符数量。</exception>
	public static Match[] GetMatches(this Regex regex, string text, int start, int count)
	{
		regex.GuardNotNull("regex");
		text.GuardNotNull("text");
		start.GuardIndexRange(0, text.Length - 1, "start");
		count.GuardBetween(0, text.Length - start, "count");
		regex = EnsureLeftToRightOption(regex);
		int end = start + count;
		return (from m in regex.Matches(text, start).OfType<Match>()
			where m.Success && start <= m.Index && m.Index < end && m.Index + m.Length <= end
			select m).ToArray();
	}

	/// <summary>
	/// 获取当前匹配模式在输入文本中满足条件的匹配项目
	/// </summary>
	/// <param name="regex">当前正则模式</param>
	/// <param name="text">输入文本</param>
	/// <param name="predicate">匹配项目筛选条件</param>
	/// <returns>符合条件的匹配项目</returns>
	/// <exception cref="T:System.ArgumentNullException">当前正则模式为空；或者输入文本 <paramref name="text" /> 为空；或者匹配项目筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static Match[] GetMatches(this Regex regex, string text, Func<Match, bool> predicate)
	{
		regex.GuardNotNull("regex");
		text.GuardNotNull("text");
		predicate.GuardNotNull("predicate");
		regex = EnsureLeftToRightOption(regex);
		return regex.Matches(text).OfType<Match>().Where(predicate)
			.ToArray();
	}

	/// <summary>
	/// 获取当前匹配模式在输入文本中满足条件的匹配项目
	/// </summary>
	/// <param name="regex">当前正则模式</param>
	/// <param name="text">输入文本</param>
	/// <param name="predicate">匹配项目筛选条件</param>
	/// <returns>符合条件的匹配项目</returns>
	/// <exception cref="T:System.ArgumentNullException">当前正则模式为空；或者输入文本 <paramref name="text" /> 为空；或者匹配项目筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static Match[] GetMatches(this Regex regex, string text, Func<Match, int, bool> predicate)
	{
		regex.GuardNotNull("regex");
		text.GuardNotNull("text");
		predicate.GuardNotNull("predicate");
		regex = EnsureLeftToRightOption(regex);
		return regex.Matches(text).OfType<Match>().Where(predicate)
			.ToArray();
	}

	/// <summary>
	/// 获取当前匹配模式与输入文本的完整匹配项
	/// </summary>
	/// <param name="regex">当前正则模式</param>
	/// <param name="text">输入文本</param>
	/// <returns>如果当前匹配模式无法与输入文本完整匹配则返回空， 否则返回完整匹配项。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前正则模式为空；或者输入文本 <paramref name="text" /> 为空。</exception>
	public static Match GetWholeMatch(this Regex regex, string text)
	{
		regex.GuardNotNull("regex");
		text.GuardNotNull("text");
		return regex.GetMatches(text).FirstOrDefault((Match m) => m.Success && m.Index == 0 && m.Length == text.Length);
	}

	/// <summary>
	/// 从输入文本中移除符合当前正则模式的匹配项
	/// </summary>
	/// <param name="regex">当前正则模式</param>
	/// <param name="text">输入文本</param>
	/// <param name="times">执行匹配移除的次数，如果设置为-1则不限制次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前正则模式为空；或者输入文本 <paramref name="text" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">执行匹配替换的次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string Remove(this Regex regex, string text, int times = -1)
	{
		return regex.ReplaceText(text, string.Empty, times);
	}

	/// <summary>
	/// 从输入文本的区域中移除符合当前正则模式的匹配项
	/// </summary>
	/// <param name="regex">当前正则模式</param>
	/// <param name="text">输入文本</param>
	/// <param name="start">匹配区域的起始位置</param>
	/// <param name="count">匹配区域的字符数量</param>
	/// <param name="times">执行匹配移除的次数，如果设置为-1则不限制次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前正则模式为空；或者输入文本 <paramref name="text" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">匹配区域的起始索引 <paramref name="start" /> 小于0，或者大于输入文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">匹配区域的字符数量 <paramref name="count" /> 小于0，或者大于输入文本从区域起始索引位置开始剩余的字符数量；或者执行匹配替换的次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string Remove(this Regex regex, string text, int start, int count, int times = -1)
	{
		return regex.ReplaceText(text, string.Empty, start, count, times);
	}

	/// <summary>
	/// 从输入文本中逆向移除符合当前正则模式的匹配项
	/// </summary>
	/// <param name="regex">当前正则模式</param>
	/// <param name="text">输入文本</param>
	/// <param name="times">执行匹配移除的次数，如果设置为-1则不限制次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前正则模式为空；或者输入文本 <paramref name="text" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">执行匹配替换的次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveLast(this Regex regex, string text, int times = -1)
	{
		return regex.ReplaceLastText(text, string.Empty, times);
	}

	/// <summary>
	/// 从输入文本的区域中逆向移除符合当前正则模式的匹配项
	/// </summary>
	/// <param name="regex">当前正则模式</param>
	/// <param name="text">输入文本</param>
	/// <param name="start">匹配区域的起始位置</param>
	/// <param name="count">匹配区域的字符数量</param>
	/// <param name="times">执行匹配移除的次数，如果设置为-1则不限制次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前正则模式为空；或者输入文本 <paramref name="text" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">匹配区域的起始索引 <paramref name="start" /> 小于0，或者大于输入文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">匹配区域的字符数量 <paramref name="count" /> 小于0，或者大于输入文本从区域起始索引位置开始逆向剩余的字符数量；或者执行匹配替换的次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveLast(this Regex regex, string text, int start, int count, int times = -1)
	{
		return regex.ReplaceLastText(text, string.Empty, start, count, times);
	}

	/// <summary>
	/// 在输入文本中将符合当前正则模式的匹配项替换为指定的字符串
	/// </summary>
	/// <param name="regex">当前正则模式</param>
	/// <param name="text">输入文本</param>
	/// <param name="replacement">替换的字符串</param>
	/// <param name="times">执行匹配替换的次数，如果设置为-1则不限制次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前正则模式为空；或者输入文本 <paramref name="text" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">执行匹配替换的次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceText(this Regex regex, string text, string replacement, int times = -1)
	{
		replacement = replacement.IfNull(string.Empty);
		return regex.ReplaceText(text, (Match m) => replacement, times);
	}

	/// <summary>
	/// 在输入文本的区域中将符合当前正则模式的匹配项替换为指定的字符串
	/// </summary>
	/// <param name="regex">当前正则模式</param>
	/// <param name="text">输入文本</param>
	/// <param name="replacement">替换的字符串</param>
	/// <param name="start">替换区域的起始的字符索引</param>
	/// <param name="count">替换区域中字符的数量</param>
	/// <param name="times">执行匹配替换的次数，如果设置为-1则不限制次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前正则模式为空；或者输入文本 <paramref name="text" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">替换区域的起始索引 <paramref name="start" /> 小于0，或者大于输入文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换区域的字符数量 <paramref name="count" /> 小于0，或者大于输入文本从区域起始索引位置开始剩余的字符数量；或者执行匹配替换的次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceText(this Regex regex, string text, string replacement, int start, int count, int times = -1)
	{
		replacement = replacement.IfNull(string.Empty);
		return regex.ReplaceText(text, (Match m) => replacement, start, count, times);
	}

	/// <summary>
	/// 在输入文本的区域中将符合当前正则模式的匹配项替换为处理方法的返回值
	/// </summary>
	/// <param name="regex">当前正则模式</param>
	/// <param name="text">输入文本</param>
	/// <param name="evaluation">替换文本处理方法</param>
	/// <param name="times">执行匹配替换的次数，如果设置为-1则不限制次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前正则模式为空；或者输入文本 <paramref name="text" /> 为空；或者替换处理方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">执行匹配替换的次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceText(this Regex regex, string text, Func<Match, string> evaluation, int times = -1)
	{
		regex.GuardNotNull("regex");
		text.GuardNotNull("text");
		evaluation.GuardNotNull("evaluation");
		times.GuardGreaterThanOrEqualTo(-1, "times");
		regex = EnsureLeftToRightOption(regex);
		if (times == -1)
		{
			return regex.Replace(text, (Match m) => evaluation(m));
		}
		return regex.Replace(text, (Match m) => evaluation(m), times);
	}

	/// <summary>
	/// 在输入文本的区域中将符合当前正则模式的匹配项替换为处理方法的返回值
	/// </summary>
	/// <param name="regex">当前正则模式</param>
	/// <param name="text">输入文本</param>
	/// <param name="evaluation">替换文本处理方法</param>
	/// <param name="start">替换区域的起始的字符索引</param>
	/// <param name="count">替换区域中字符的数量</param>
	/// <param name="times">执行匹配替换的次数，如果设置为-1则不限制次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前正则模式为空；或者输入文本 <paramref name="text" /> 为空；或者替换处理方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">替换区域的起始索引 <paramref name="start" /> 小于0，或者大于输入文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换区域的字符数量 <paramref name="count" /> 小于0，或者大于输入文本从区域起始索引位置开始剩余的字符数量；或者执行匹配替换的次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceText(this Regex regex, string text, Func<Match, string> evaluation, int start, int count, int times = -1)
	{
		regex.GuardNotNull("regex");
		text.GuardNotNull("text");
		evaluation.GuardNotNull("evaluation");
		start.GuardIndexRange(0, text.Length - 1, "start");
		count.GuardBetween(0, text.Length - start, "count");
		times.GuardGreaterThanOrEqualTo(-1, "times");
		regex = EnsureLeftToRightOption(regex);
		int end = start + count;
		int matched = 0;
		return regex.Replace(text, (Match m) => (start <= m.Index && m.Index < end && m.Index + m.Length <= end && (times == -1 || ++matched <= times)) ? evaluation(m) : m.Value, int.MaxValue, start);
	}

	/// <summary>
	/// 在输入文本中逆向搜索，将符合当前正则模式的匹配项替换为指定的字符串
	/// </summary>
	/// <param name="regex">当前正则模式</param>
	/// <param name="text">输入文本</param>
	/// <param name="replacement">替换的字符串</param>
	/// <param name="times">执行匹配替换的次数，如果设置为-1则不限制次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前正则模式为空；或者输入文本 <paramref name="text" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">执行匹配替换的次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceLastText(this Regex regex, string text, string replacement, int times = -1)
	{
		replacement = replacement.IfNull(string.Empty);
		return regex.ReplaceLastText(text, (Match m) => replacement, times);
	}

	/// <summary>
	/// 在输入文本的区域中逆向搜索，将符合当前正则模式的匹配项替换为指定的字符串
	/// </summary>
	/// <param name="regex">当前正则模式</param>
	/// <param name="text">输入文本</param>
	/// <param name="replacement">替换的字符串</param>
	/// <param name="start">替换区域的起始的字符索引</param>
	/// <param name="count">替换区域中字符的数量</param>
	/// <param name="times">执行匹配替换的次数，如果设置为-1则不限制次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前正则模式为空；或者输入文本 <paramref name="text" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">替换区域的起始索引 <paramref name="start" /> 小于0，或者大于输入文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换区域的字符数量 <paramref name="count" /> 小于0，或者大于输入文本从区域起始索引位置逆向开始剩余的字符数量；或者执行匹配替换的次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceLastText(this Regex regex, string text, string replacement, int start, int count, int times = -1)
	{
		replacement = replacement.IfNull(string.Empty);
		return regex.ReplaceLastText(text, (Match m) => replacement, start, count, times);
	}

	/// <summary>
	/// 在输入文本的区域中逆向搜索，将符合当前正则模式的匹配项替换为指定的字符串
	/// </summary>
	/// <param name="regex">当前正则模式</param>
	/// <param name="text">输入文本</param>
	/// <param name="evaluation">替换文本处理方法</param>
	/// <param name="times">执行匹配替换的次数，如果设置为-1则不限制次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前正则模式为空；或者输入文本 <paramref name="text" /> 为空；或者替换文本处理方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">执行匹配替换的次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceLastText(this Regex regex, string text, Func<Match, string> evaluation, int times = -1)
	{
		regex.GuardNotNull("regex");
		text.GuardNotNull("text");
		evaluation.GuardNotNull("evaluation");
		times.GuardGreaterThanOrEqualTo(-1, "times");
		regex = EnsureRightToLeftOption(regex);
		if (times == -1)
		{
			return regex.Replace(text, (Match m) => evaluation(m));
		}
		return regex.Replace(text, (Match m) => evaluation(m), times);
	}

	/// <summary>
	/// 在输入文本的区域中逆向搜索，将符合当前正则模式的匹配项替换为替换文本处理方法返回值
	/// </summary>
	/// <param name="regex">当前正则模式</param>
	/// <param name="text">输入文本</param>
	/// <param name="evaluation">替换文本处理方法</param>
	/// <param name="start">替换区域的起始的字符索引</param>
	/// <param name="count">替换区域中字符的数量</param>
	/// <param name="times">执行匹配替换的次数，如果设置为-1则不限制次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前正则模式为空；或者输入文本 <paramref name="text" /> 为空；或者替换文本处理方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">替换区域的起始索引 <paramref name="start" /> 小于0，或者大于输入文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换区域的字符数量 <paramref name="count" /> 小于0，或者大于输入文本从区域起始索引位置逆向开始剩余的字符数量；或者执行匹配替换的次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceLastText(this Regex regex, string text, Func<Match, string> evaluation, int start, int count, int times = -1)
	{
		regex.GuardNotNull("regex");
		text.GuardNotNull("text");
		evaluation.GuardNotNull("evaluation");
		start.GuardIndexRange(0, text.Length - 1, "start");
		count.GuardBetween(0, start + 1, "count");
		times.GuardGreaterThanOrEqualTo(-1, "times");
		regex = EnsureRightToLeftOption(regex);
		int end = start - count;
		int matched = 0;
		return regex.Replace(text, (Match m) => (end < m.Index && m.Index <= start && m.Index + m.Length - 1 <= start && (times == -1 || ++matched <= times)) ? evaluation(m) : m.Value, int.MaxValue, start);
	}

	/// <summary>
	/// 确保当前正则表达式具有 LeftToRight 选项
	/// </summary>
	/// <param name="regex">当前正则表达式</param>
	/// <returns>具有 LeftToRight 选项的正则表达式</returns>
	private static Regex EnsureLeftToRightOption(Regex regex)
	{
		if (regex.RightToLeft)
		{
			return new Regex(regex.ToString(), regex.Options & ~RegexOptions.RightToLeft);
		}
		return regex;
	}

	/// <summary>
	/// 确保当前正则表达式具有 RightToLeft 选项
	/// </summary>
	/// <param name="regex">当前正则表达式</param>
	/// <returns>具有 RightToLeft 选项的正则表达式</returns>
	private static Regex EnsureRightToLeftOption(Regex regex)
	{
		if (!regex.RightToLeft)
		{
			return new Regex(regex.ToString(), regex.Options | RegexOptions.RightToLeft);
		}
		return regex;
	}
}
