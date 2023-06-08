#define DEBUG
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Richfit.Garnet.Common.Text;

namespace Richfit.Garnet.Common.Utility;

/// <summary>
/// <see cref="T:System.String" /> 辅助类
/// </summary>
public static class TextHelper
{
	/// <summary>
	/// 向当前可变文本中追加通过处理复合格式化字符串生成的字符串
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="format">复合格式化字符串</param>
	/// <param name="args">复合格式化参数数组</param>
	/// <param name="provider">格式化提供器</param>
	/// <returns>追加后的可变文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空；或者符合格式化字符串 <paramref name="format" /> 为空；或者格式化参数数组 <paramref name="args" /> 为空。</exception>
	public static StringBuilder AppendFormat(StringBuilder text, string format, object[] args, IFormatProvider provider)
	{
		Guard.AssertNotNull(text, "string builder");
		Guard.AssertNotNull(format, "format");
		Guard.AssertNotNull(args, "args");
		text.AppendFormat(provider, format, args);
		return text;
	}

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
	public static StringBuilder AppendValue<T>(StringBuilder text, T value, int count)
	{
		Guard.AssertNotNull(text, "string builder");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
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
	public static StringBuilder AppendValue(StringBuilder text, params object[] values)
	{
		Guard.AssertNotNull(text, "string builder");
		Guard.AssertNotNull(values, "values");
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
	public static StringBuilder AppendValue(StringBuilder text, IEnumerable<object> values)
	{
		Guard.AssertNotNull(text, "string builder");
		Guard.AssertNotNull(values, "values");
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
	public static StringBuilder AppendValue<T>(StringBuilder text, params T[] values)
	{
		Guard.AssertNotNull(text, "string builder");
		Guard.AssertNotNull(values, "values");
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
	public static StringBuilder AppendValue<T>(StringBuilder text, IEnumerable<T> values)
	{
		Guard.AssertNotNull(text, "string builder");
		Guard.AssertNotNull(values, "values");
		foreach (T value in values)
		{
			text.Append(value);
		}
		return text;
	}

	/// <summary>
	/// 使用Ascii编码对当前字节数据进行解码，返回解码后的字符串
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <returns>解码后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	public static string AsciiDecode(byte[] bytes)
	{
		return TextDecode(bytes, Encoding.ASCII);
	}

	/// <summary>
	/// 使用Ascii编码对当前字节数据进行解码，返回解码后的字符串
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">开始转换的字节索引位置</param>
	/// <param name="count">转换的字节数量</param>
	/// <returns>解码后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出了当前字节数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于从开始转换位置 <paramref name="start" /> 起剩余的字节数量。</exception>
	public static string AsciiDecode(byte[] bytes, int start, int count)
	{
		return TextDecode(bytes, start, count, Encoding.ASCII);
	}

	/// <summary>
	/// 使用Ascii编码对当前字节序列进行解码，返回解码后的字符串
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <returns>解码后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空。</exception>
	public static string AsciiDecode(IEnumerable<byte> bytes)
	{
		return TextDecode(bytes, Encoding.ASCII);
	}

	/// <summary>
	/// 将当前字符按Ascii编码，编码为字节数据
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>编码生成的字节数据</returns>
	public static byte[] AsciiEncode(char c)
	{
		return TextEncode(c, Encoding.ASCII);
	}

	/// <summary>
	/// 将当前字符数组按Ascii编码，编码为字节数据
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <returns>编码生成的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static byte[] AsciiEncode(char[] cs)
	{
		return TextEncode(cs, Encoding.ASCII);
	}

	/// <summary>
	/// 将当前字符数组按Ascii编码，编码为字节数据
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <param name="start">开始转换的字符索引位置</param>
	/// <param name="count">转换的字符数量</param>
	/// <returns>编码生成的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出了当前字符数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的字符数量。</exception>
	public static byte[] AsciiEncode(char[] cs, int start, int count)
	{
		return TextEncode(cs, start, count, Encoding.ASCII);
	}

	/// <summary>
	/// 将当前字符序列按Ascii编码，编码为的字节数据
	/// </summary>
	/// <param name="cs">当前字符序列</param>
	/// <returns>编码生成的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static byte[] AsciiEncode(IEnumerable<char> cs)
	{
		return TextEncode(cs, Encoding.ASCII);
	}

	/// <summary>
	/// 使用ASCII编码对当前文本进行编码，返回编码后的字节数据
	/// </summary>
	/// <param name="text">当前待编码的文本</param>
	/// <returns>编码后的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static byte[] AsciiEncode(string text)
	{
		return TextEncode(text, Encoding.ASCII);
	}

	/// <summary>
	/// 使用ASCII编码对当前文本进行编码，返回编码后的字节数据
	/// </summary>
	/// <param name="text">当前待编码的文本</param>
	/// <param name="start">开始编码的字符索引位置</param>
	/// <param name="count">编码的字符数量</param>
	/// <returns>编码生成的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">起始索引位置 <paramref name="start" /> 超出了当前文本中字符的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">字符数量 <paramref name="count" /> 小于0，或者大于从起始索引位置 <paramref name="start" /> 起字符串中剩余的字符数量。</exception>
	public static byte[] AsciiEncode(string text, int start, int count)
	{
		return TextEncode(text, start, count, Encoding.ASCII);
	}

	/// <summary>
	/// 创建内容为当前字符的字符串
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <param name="intern">是否对创建的字符串进行暂存</param>
	/// <returns>创建的字符串</returns>
	public static string BuildString(char c, bool intern = false)
	{
		string s = new string(c, 1);
		return intern ? string.Intern(s) : s;
	}

	/// <summary>
	/// 创建内容为指定数量的当前字符的字符串
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <param name="count">当前字符的数量</param>
	/// <param name="intern">是否对创建的字符串进行暂存</param>
	/// <returns>创建的字符串</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">生成的字符数量 <paramref name="count" /> 小于0。</exception>
	public static string BuildString(char c, int count, bool intern = false)
	{
		Guard.AssertGreaterThanOrEqualTo(count, 0, "char count");
		string s = new string(c, count);
		return intern ? string.Intern(s) : s;
	}

	/// <summary>
	/// 创建内容为当前字符数组的字符串
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <param name="intern">是否对创建的字符串进行暂存</param>
	/// <returns>生成的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static string BuildString(char[] cs, bool intern = false)
	{
		Guard.AssertNotNull(cs, "char array");
		return BuildString(cs, 0, cs.Length, intern);
	}

	/// <summary>
	/// 创建内容为当前字符数组中指定范围字符的字符串
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <param name="start">范围开始的字符索引</param>
	/// <param name="count">范围中的字符数量</param>
	/// <param name="intern">是否对创建的字符串进行暂存</param>
	/// <returns>生成的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始字符索引 <paramref name="start" /> 小于，或则大于当前字符数组的最大索引数量。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">字符个数小于0，或者大于当前字符数组的剩余字符个数。</exception>
	public static string BuildString(char[] cs, int start, int count, bool intern = false)
	{
		Guard.AssertNotNull(cs, "char array");
		Guard.AssertIndexRange(start, 0, cs.Length - 1, "start");
		Guard.AssertBetween(count, 0, cs.Length - start, "char count");
		int end = start + count;
		StringBuilder buff = new StringBuilder(count);
		for (int i = start; i < end; i++)
		{
			buff.Append(cs[i]);
		}
		return intern ? string.Intern(buff.ToString()) : buff.ToString();
	}

	/// <summary>
	/// 创建内容为当前字符序列中字符的字符串
	/// </summary>
	/// <param name="cs">当前字符序列</param>
	/// <param name="intern">是否对创建的字符串进行暂存</param>
	/// <returns>生成的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符序列为空。</exception>
	public static string BuildString(IEnumerable<char> cs, bool intern = false)
	{
		Guard.AssertNotNull(cs, "char array");
		StringBuilder buff = new StringBuilder(512);
		foreach (char c in cs)
		{
			buff.Append(c);
		}
		return intern ? string.Intern(buff.ToString()) : buff.ToString();
	}

	/// <summary>
	/// 将当前文本的第一个字母字符转换为大写
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="culture">转字符的大小写时使用的区域信息，默认使用当前线程的区域信息。</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static string Capitalize(string text, CultureInfo culture = null)
	{
		Guard.AssertNotNull(text, "text");
		if (text.Length == 0)
		{
			return text;
		}
		StringBuilder buff = new StringBuilder(text);
		int index = 0;
		while (index < buff.Length && !IsLetter(buff[index++]))
		{
		}
		if (index < buff.Length)
		{
			buff[index] = ToUpper(buff[index], culture);
		}
		return buff.ToString();
	}

	/// <summary>
	/// 将当前文本中每个符合指定模式的文本块的第一个非空白字符转换为大写
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">文本块匹配模式</param>
	/// <param name="culture">转字符的大小写时使用的区域信息，默认使用当前线程的区域信息。</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者文本块匹配模式 <paramref name="pattern" /> 为空。</exception>
	public static string Capitalize(string text, Regex pattern, CultureInfo culture = null)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(pattern, "pattern");
		StringBuilder buff = new StringBuilder(text);
		MatchCollection mc = pattern.Matches(text);
		int index = 0;
		foreach (Match i in mc)
		{
			index = i.Index;
			while (index < i.Index + i.Length && !IsLetter(buff[index++]))
			{
			}
			if (index < i.Index + i.Length)
			{
				buff[index] = ToUpper(buff[index], culture);
			}
		}
		return buff.ToString();
	}

	/// <summary>
	/// 将当前文本中的每一个段落的首字母转换为大写
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="culture">转换字符大小写时使用的区域信息，默认为当前线程使用的区域信息。</param>
	/// <returns>转换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <remarks>默认以换号、回车或者段落标记分隔段落。</remarks>
	public static string CapitalizeParagraph(string text, CultureInfo culture = null)
	{
		Guard.AssertNotNull(text, "text");
		return Capitalize(text, ConvertHelper.ToRegex("[^\\r\\n\\p{Zp}]+[\\r\\n\\p{Zp}]?"), culture);
	}

	/// <summary>
	/// 将当前文本中的每一个段落的首字母转换为大写
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="separators">段落的分隔符数组</param>
	/// <param name="culture">转换字符大小写时使用的区域信息，默认为当前线程使用的区域信息。</param>
	/// <returns>转换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者词语分隔符数组 <paramref name="separators" /> 为空。</exception>
	public static string CapitalizeParagraph(string text, char[] separators, CultureInfo culture = null)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(separators, "separators");
		string pattern = string.Format("[^{0}]+[{0}]?", RegexEscape(BuildString(separators)));
		return Capitalize(text, ConvertHelper.ToRegex(pattern), culture);
	}

	/// <summary>
	/// 将当前文本中的每一个句子的首字母转换为大写
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="culture">转换字符大小写时使用的区域信息，默认为当前线程使用的区域信息。</param>
	/// <returns>转换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <remarks>每个句子由如下字符进行分割：".", "?", "!", ";", "。", "？", "！", "；"。</remarks>
	public static string CapitalizeSentence(string text, CultureInfo culture = null)
	{
		return CapitalizeSentence(text, new char[8] { '.', '?', ';', '!', '。', '？', '！', '；' }, culture);
	}

	/// <summary>
	/// 将当前文本中的每一个句子的首字母转换为大写
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="separators">句子的分隔符数组</param>
	/// <param name="culture">转换字符大小写时使用的区域信息，默认为当前线程使用的区域信息。</param>
	/// <returns>转换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者句子的分隔符数组 <paramref name="separators" /> 为空。</exception>
	public static string CapitalizeSentence(string text, char[] separators, CultureInfo culture = null)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(separators, "separators");
		string pattern = string.Format("[^{0}]+[{0}]?", RegexEscape(BuildString(separators)));
		return Capitalize(text, ConvertHelper.ToRegex(pattern), culture);
	}

	/// <summary>
	/// 将当前文本中的每一个词语的首字母转换为大写
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="culture">转换字符大小写时使用的区域信息，默认为当前线程使用的区域信息。</param>
	/// <returns>转换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <remarks>默认以空白字符或者标点符号分隔单词。</remarks>
	public static string CapitalizeWord(string text, CultureInfo culture = null)
	{
		Guard.AssertNotNull(text, "text");
		return Capitalize(text, ConvertHelper.ToRegex("\\w+[\\s\\p{P}]"), culture);
	}

	/// <summary>
	/// 将当前文本中的每一个词语的首字母转换为大写
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="separators">词语的分隔符数组</param>
	/// <param name="culture">转换字符大小写时使用的区域信息，默认为当前线程使用的区域信息。</param>
	/// <returns>转换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者词语分隔符数组 <paramref name="separators" /> 为空。</exception>
	public static string CapitalizeWord(string text, char[] separators, CultureInfo culture = null)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(separators, "separators");
		string pattern = $"\\w+[{RegexEscape(BuildString(separators))}]";
		return Capitalize(text, ConvertHelper.ToRegex(pattern), culture);
	}

	/// <summary>
	/// 将当前字符串居中放置；如果居中宽度大于字符串的长度，则字符串的两边用指定填充字符填充
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="width">居中放置的宽度</param>
	/// <param name="padding">填充的字符，默认为空格（\u0020）</param>
	/// <returns>处理后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">居中放置的宽度小于0。</exception>
	public static string Center(string s, int width, char padding = ' ')
	{
		Guard.AssertNotNull(s, "s");
		Guard.AssertGreaterThanOrEqualTo(width, 0, "width");
		if (width <= s.Length)
		{
			return s;
		}
		StringBuilder buff = new StringBuilder(NumericHelper.Max(s.Length, width));
		int delta = width - s.Length;
		for (int x = 0; x < delta / 2; x++)
		{
			buff.Append(padding);
		}
		buff.Append(s);
		for (int x = 0; x < delta / 2; x++)
		{
			buff.Append(padding);
		}
		return buff.ToString();
	}

	/// <summary>
	/// 将指定的字符串居中放置，如果指定的字符串的宽度大于字符串的长度，则字符串的两边用指定的字符串填充
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="width">居中放置的宽度</param>
	/// <param name="padding">填充的字符串</param>
	/// <returns>居中放置的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者填充的字符串为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">放置宽度 <paramref name="width" /> 小于0。</exception>
	public static string Center(string s, int width, string padding)
	{
		Guard.AssertNotNull(s, "s");
		Guard.AssertGreaterThanOrEqualTo(width, 0, "width");
		Guard.AssertNotNull(padding, "padding");
		if (width <= s.Length || padding.Length == 0)
		{
			return s;
		}
		StringBuilder buff = new StringBuilder(NumericHelper.Max(s.Length, width));
		int delta = width - s.Length;
		for (int x = 0; x < delta / 2; x++)
		{
			buff.Append(padding[x % padding.Length]);
		}
		buff.Append(s);
		for (int x = 0; x < delta / 2; x++)
		{
			buff.Append(padding[x % padding.Length]);
		}
		return buff.ToString();
	}

	/// <summary>
	/// 将当前字节数组按 <paramref name="encoding" /> 指定编码解码为字符数组
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="encoding">转换使用的字符编码，默认使用 <see cref="P:System.Text.Encoding.UTF8" /> 编码</param>
	/// <returns>解码生成的字符数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	public static char[] CharDecode(byte[] bytes, Encoding encoding = null)
	{
		Guard.AssertNotNull(bytes, "bytes");
		return ObjectHelper.IfNull(encoding, Encoding.UTF8).GetChars(bytes);
	}

	/// <summary>
	/// 将当前字节数组按 <paramref name="encoding" /> 指定编码解码为字符数组
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">开始转换的字节索引位置</param>
	/// <param name="count">转换的字节数量</param>
	/// <param name="encoding">转换使用的字符编码，默认使用 <see cref="P:System.Text.Encoding.UTF8" /> 编码</param>
	/// <returns>解码生成的字符数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出了当前字节数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的字节数量。</exception>
	public static char[] CharDecode(byte[] bytes, int start, int count, Encoding encoding = null)
	{
		Guard.AssertNotNull(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "start");
		Guard.AssertBetween(count, 0, bytes.Length - start, "count");
		return ObjectHelper.IfNull(encoding, Encoding.UTF8).GetChars(bytes, start, count);
	}

	/// <summary>
	/// 将当前字节序列按 <paramref name="encoding" /> 指定编码解码为字符数组
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="encoding">转换使用的字符编码，默认使用 <see cref="P:System.Text.Encoding.UTF8" /> 编码</param>
	/// <returns>解码生成的字符数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空。</exception>
	public static char[] CharDecode(IEnumerable<byte> bytes, Encoding encoding = null)
	{
		Guard.AssertNotNull(bytes, "bytes");
		encoding = ObjectHelper.IfNull(encoding, Encoding.UTF8);
		Decoder decoder = encoding.GetDecoder();
		List<char> result = new List<char>();
		byte[] buff = new byte[1024];
		char[] chars = new char[1024];
		int index = 0;
		int charCount = 0;
		foreach (byte b in bytes)
		{
			buff[index++] = b;
			if (index >= buff.Length)
			{
				charCount = decoder.GetChars(buff, 0, buff.Length, chars, 0);
				result.AddRange(chars.Take(charCount));
				index = 0;
			}
		}
		if (index > 0)
		{
			charCount = decoder.GetChars(buff, 0, index, chars, 0, flush: true);
			result.AddRange(chars.Take(charCount));
		}
		return chars.ToArray();
	}

	/// <summary>
	/// 将以"\u"开头的字符十六进制字符串表示解码为文本
	/// </summary>
	/// <param name="text">当前字符的十六进制表示</param>
	/// <returns>解码后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static string CharDecode(string text)
	{
		Guard.AssertNotNull(text, "text");
		string[] parts = Split(text, "\\u");
		List<char> chars = new List<char>();
		if (parts.Length > 1)
		{
			for (int i = 1; i < parts.Length; i++)
			{
				chars.Add((char)short.Parse(parts[i], NumberStyles.HexNumber));
			}
		}
		return BuildString(chars);
	}

	/// <summary>
	/// 将当前字符按字符常量的表示方式进行编码
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <param name="upperCase">编码后的字符串是否使用大写字母</param>
	/// <returns>字符常量形式的字符串表示</returns>
	public static string CharEncode(char c, bool upperCase = false)
	{
		return "\\u" + ConvertHelper.HexEncode(ConvertHelper.GetRawBytes(c), upperCase);
	}

	/// <summary>
	/// 将当前字符数组中的字符按字符常量的表示方式进行编码
	/// </summary>
	/// <param name="chars">当前字符数组</param>
	/// <param name="upperCase">编码后的字符串是否使用大写字母</param>
	/// <returns>字符常量形式的字符串表示</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static string CharEncode(char[] chars, bool upperCase = false)
	{
		Guard.AssertNotNull(chars, "chars");
		return ConvertHelper.ToHex(ConvertHelper.GetRawBytes(chars), 2, "\\u{0}", upperCase);
	}

	/// <summary>
	/// 将当前字符数组中的字符按字符常量的表示方式进行编码
	/// </summary>
	/// <param name="chars">当前字符数组</param>
	/// <param name="start">开始转换的字符索引位置</param>
	/// <param name="count">转换的字符数量</param>
	/// <param name="upperCase">编码后的字符串是否使用大写字母</param>
	/// <returns>字符常量形式的字符串表示</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出了当前字符数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的字符数量。</exception>
	public static string CharEncode(char[] chars, int start, int count, bool upperCase = false)
	{
		Guard.AssertNotNull(chars, "chars");
		return ConvertHelper.ToHex(ConvertHelper.GetRawBytes(chars, start, count), 2, "\\u{0}", upperCase);
	}

	/// <summary>
	/// 将当前字符序列中的字符按字符常量的表示方式进行编码
	/// </summary>
	/// <param name="chars">当前字符序列</param>
	/// <param name="upperCase">编码后的字符串是否使用大写字母</param>
	/// <returns>字符常量形式的字符串表示</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static string CharEncode(IEnumerable<char> chars, bool upperCase = false)
	{
		Guard.AssertNotNull(chars, "chars");
		return ConvertHelper.ToHex(ConvertHelper.GetRawBytes(chars), 2, "\\u{0}", upperCase);
	}

	/// <summary>
	/// 将当前文本区域中的字符编码为字符十六进制字符串的表示
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="upperCase">十六进制字符串是否使用大写字母</param>
	/// <returns>当前文本区域中字符的十六进制字符串表示</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static string CharEncode(string text, bool upperCase = false)
	{
		Guard.AssertNotNull(text, "text");
		return ConvertHelper.ToHex(ConvertHelper.GetRawBytes(text), 2, "\\u{0}", upperCase);
	}

	/// <summary>
	/// 将当前文本区域中的字符编码为字符十六进制字符串的表示
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="start">区域的起始位置</param>
	/// <param name="count">区域中的字符数量</param>
	/// <param name="upperCase">十六进制字符串是否使用大写字母</param>
	/// <returns>当前文本区域中字符的十六进制字符串表示</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出了当前字符数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的字符数量。</exception>
	public static string CharEncode(string text, int start, int count, bool upperCase = false)
	{
		Guard.AssertNotNull(text, "text");
		return ConvertHelper.ToHex(ConvertHelper.GetRawBytes(text, start, count), 2, "\\u{0}", upperCase);
	}

	/// <summary>
	/// 将当前字节数组从一种字符编码转换为另一种字符编码
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="from">字节数组使用的源编码,默认为ASCII</param>
	/// <param name="to">字节数组转换的目标编码,默认为UTF-8</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组空；或者源编码 <paramref name="from" /> 为空；或者目标编码 <paramref name="to" /> 为空。</exception>
	public static byte[] ChangeEncoding(byte[] bytes, Encoding from, Encoding to)
	{
		Guard.AssertNotNull(bytes, "bytes");
		Guard.AssertNotNull(from, "from");
		Guard.AssertNotNull(to, "to");
		return Encoding.Convert(from, to, bytes);
	}

	/// <summary>
	/// 将当前文本从一种编码转换为另一种编码
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="from">字符串使用的源编码,默认为ASCII</param>
	/// <param name="to">字符串转换的目标编码,默认为UTF-8</param>
	/// <returns>转换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static string ChangeEncoding(string text, Encoding from = null, Encoding to = null)
	{
		Guard.AssertNotNull(text, "text");
		from = ObjectHelper.IfNull(from, Encoding.ASCII);
		to = ObjectHelper.IfNull(to, Encoding.UTF8);
		return to.GetString(ChangeEncoding(from.GetBytes(text), from, to));
	}

	/// <summary>
	/// 使用区域敏感排序规则比较当前字符串和目标字符串
	/// </summary>
	/// <param name="source">当前字符串</param>
	/// <param name="target">比较的目标字符串</param>
	/// <param name="ignoreCase">字符串比较是否忽略大小写</param>
	/// <returns>如果当前字符串大于目标字符串返回大于0的值；当前字符串等于目标字符串返回0；当前字符串小于目标字符串返回小于0的值；如果当前字符串和目标字符串都为空，则返回0。</returns>
	public static int CompareCultural(string source, string target, bool ignoreCase = false)
	{
		return CompareCultural(source, target, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
	}

	/// <summary>
	/// 使用区域敏感排序规则比较当前字符串和目标字符串
	/// </summary>
	/// <param name="source">当前字符串</param>
	/// <param name="target">比较的目标字符串</param>
	/// <param name="comparison">字符串比较规则</param>
	/// <returns>如果当前字符串大于目标字符串返回大于0的值；当前字符串等于目标字符串返回0；当前字符串小于目标字符串返回小于0的值；如果当前字符串和目标字符串都为空，则返回0。</returns>
	public static int CompareCultural(string source, string target, StringComparison comparison)
	{
		return (!object.ReferenceEquals(source, target)) ? string.Compare(source, target, comparison) : 0;
	}

	/// <summary>
	/// 使用区域敏感排序规则比较当前字符串和目标字符串
	/// </summary>
	/// <param name="source">当前字符串</param>
	/// <param name="target">比较的目标字符串</param>
	/// <param name="culture">比较时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="ignoreCase">字符串比较是否忽略大小写</param>
	/// <returns>如果当前字符串大于目标字符串返回大于0的值；当前字符串等于目标字符串返回0；当前字符串小于目标字符串返回小于0的值；如果当前字符串和目标字符串都为空，则返回0。</returns>
	public static int CompareCultural(string source, string target, CultureInfo culture, bool ignoreCase = false)
	{
		return (!object.ReferenceEquals(source, target)) ? string.Compare(source, target, ignoreCase, ObjectHelper.IfNull(culture, CultureInfo.CurrentCulture)) : 0;
	}

	/// <summary>
	/// 使用区域敏感排序规则比较当前字符串和目标字符串
	/// </summary>
	/// <param name="source">当前字符串</param>
	/// <param name="target">比较的目标字符串</param>
	/// <param name="culture">比较时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="options">比较时使用的选项</param>
	/// <returns>如果当前字符串大于目标字符串返回大于0的值；当前字符串等于目标字符串返回0；当前字符串小于目标字符串返回小于0的值；如果当前字符串和目标字符串都为空，则返回0。</returns>
	public static int CompareCultural(string source, string target, CultureInfo culture, CompareOptions options)
	{
		return (!object.ReferenceEquals(source, target)) ? string.Compare(source, target, ObjectHelper.IfNull(culture, CultureInfo.CurrentCulture), options) : 0;
	}

	/// <summary>
	/// 使用区域敏感排序规则比较当前字符串和目标字符串
	/// </summary>
	/// <param name="source">当前字符串</param>
	/// <param name="sourceStart">当前字符串开始比较的字符索引位置</param>
	/// <param name="target">比较的目标字符串</param>
	/// <param name="targetStart">目标搜字符串开始比较的字符索引位置</param>
	/// <param name="count">比较的字符数量</param>
	/// <param name="ignoreCase">字符串比较是否忽略大小写</param>
	/// <returns>如果当前字符串大于目标字符串返回大于0的值；当前字符串等于目标字符串返回0；当前字符串小于目标字符串返回小于0的值；如果当前字符串和目标字符串都为空，则返回0。</returns>
	/// <exception cref="T:System.IndexOutOfRangeException">
	/// 当前字符串开始比较的位置 <paramref name="sourceStart" /> 小于0，或者大于当前字符串中字符的最大索引；
	/// 目标字符串开始比较的位置 <paramref name="targetStart" /> 小于0，或者大于目标字符串中字符的最大索引；
	/// 比较的字符数量 <paramref name="count" /> 小于0，或者大于当前字符串和目标字符串中可比较的字符数量。
	/// </exception>
	public static int CompareCultural(string source, int sourceStart, string target, int targetStart, int count, bool ignoreCase = false)
	{
		return CompareCultural(source, sourceStart, target, targetStart, count, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
	}

	/// <summary>
	/// 使用区域敏感排序规则比较当前字符串和目标字符串
	/// </summary>
	/// <param name="source">当前字符串</param>
	/// <param name="sourceStart">当前字符串开始比较的字符索引位置</param>
	/// <param name="target">比较的目标字符串</param>
	/// <param name="targetStart">目标搜字符串开始比较的字符索引位置</param>
	/// <param name="count">比较的字符数量</param>
	/// <param name="comparison">字符串比较规则</param>
	/// <returns>如果当前字符串大于目标字符串返回大于0的值；当前字符串等于目标字符串返回0；当前字符串小于目标字符串返回小于0的值；如果当前字符串和目标字符串都为空，则返回0。</returns>
	/// <exception cref="T:System.IndexOutOfRangeException">
	/// 当前字符串开始比较的位置 <paramref name="sourceStart" /> 小于0，或者大于当前字符串中字符的最大索引；
	/// 目标字符串开始比较的位置 <paramref name="targetStart" /> 小于0，或者大于目标字符串中字符的最大索引；
	/// 比较的字符数量 <paramref name="count" /> 小于0，或者大于当前字符串和目标字符串中可比较的字符数量。
	/// </exception>
	public static int CompareCultural(string source, int sourceStart, string target, int targetStart, int count, StringComparison comparison)
	{
		Guard.AssertGreaterThanOrEqualTo(sourceStart, 0, "source start");
		Guard.AssertGreaterThanOrEqualTo(targetStart, 0, "target start");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		return (!object.ReferenceEquals(source, target)) ? string.Compare(source, sourceStart, target, targetStart, count, comparison) : 0;
	}

	/// <summary>
	/// 使用区域敏感排序规则比较当前字符串和目标字符串
	/// </summary>
	/// <param name="source">当前字符串</param>
	/// <param name="sourceStart">当前字符串开始比较的字符索引位置</param>
	/// <param name="target">比较的目标字符串</param>
	/// <param name="targetStart">目标搜字符串开始比较的字符索引位置</param>
	/// <param name="count">比较的字符数量</param>
	/// <param name="culture">比较时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="ignoreCase">字符串比较是否忽略大小写</param>
	/// <returns>如果当前字符串大于目标字符串返回大于0的值；当前字符串等于目标字符串返回0；当前字符串小于目标字符串返回小于0的值；如果当前字符串和目标字符串都为空，则返回0。</returns>
	/// <exception cref="T:System.IndexOutOfRangeException">
	/// 当前字符串开始比较的位置 <paramref name="sourceStart" /> 小于0，或者大于当前字符串中字符的最大索引；
	/// 目标字符串开始比较的位置 <paramref name="targetStart" /> 小于0，或者大于目标字符串中字符的最大索引；
	/// 比较的字符数量 <paramref name="count" /> 小于0，或者大于当前字符串和目标字符串中可比较的字符数量。
	/// </exception>
	public static int CompareCultural(string source, int sourceStart, string target, int targetStart, int count, CultureInfo culture, bool ignoreCase = false)
	{
		return CompareCultural(source, sourceStart, target, targetStart, count, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 使用区域敏感排序规则比较当前字符串和目标字符串
	/// </summary>
	/// <param name="source">当前字符串</param>
	/// <param name="sourceStart">当前字符串开始比较的字符索引位置</param>
	/// <param name="target">比较的目标字符串</param>
	/// <param name="targetStart">目标搜字符串开始比较的字符索引位置</param>
	/// <param name="count">比较的字符数量</param>
	/// <param name="culture">比较时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="options">比较时使用的选项</param>
	/// <returns>如果当前字符串大于目标字符串返回大于0的值；当前字符串等于目标字符串返回0；当前字符串小于目标字符串返回小于0的值；如果当前字符串和目标字符串都为空，则返回0。</returns>
	/// <exception cref="T:System.IndexOutOfRangeException">
	/// 当前字符串开始比较的位置 <paramref name="sourceStart" /> 小于0，或者大于当前字符串中字符的最大索引；
	/// 目标字符串开始比较的位置 <paramref name="targetStart" /> 小于0，或者大于目标字符串中字符的最大索引；
	/// 比较的字符数量 <paramref name="count" /> 小于0，或者大于当前字符串和目标字符串中可比较的字符数量。
	/// </exception>
	public static int CompareCultural(string source, int sourceStart, string target, int targetStart, int count, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertGreaterThanOrEqualTo(sourceStart, 0, "source start");
		Guard.AssertGreaterThanOrEqualTo(targetStart, 0, "target start");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		return (!object.ReferenceEquals(source, target)) ? string.Compare(source, sourceStart, target, targetStart, count, ObjectHelper.IfNull(culture, CultureInfo.CurrentCulture), options) : 0;
	}

	/// <summary>
	/// 使用固定区域排序规则比较当前字符串和目标字符串
	/// </summary>
	/// <param name="source">当前字符串</param>
	/// <param name="target">比较的目标字符串</param>
	/// <param name="ignoreCase">比较是否忽略大小写</param>
	/// <returns>如果当前字符串大于目标字符串返回大于0的值；当前字符串等于目标字符串返回0；当前字符串小于目标字符串返回小于0的值；如果当前字符串和目标字符串都为空，则返回0。</returns>
	public static int CompareInvariant(string source, string target, bool ignoreCase = false)
	{
		return (!object.ReferenceEquals(source, target)) ? string.Compare(source, target, ignoreCase ? StringComparison.InvariantCultureIgnoreCase : StringComparison.InvariantCulture) : 0;
	}

	/// <summary>
	/// 使用固定区域排序规则比较当前字符串和目标字符串
	/// </summary>
	/// <param name="source">当前字符串</param>
	/// <param name="target">比较的目标字符串</param>
	/// <param name="options">比较时使用的选项</param>
	/// <returns>如果当前字符串大于目标字符串返回大于0的值；当前字符串等于目标字符串返回0；当前字符串小于目标字符串返回小于0的值；如果当前字符串和目标字符串都为空，则返回0。</returns>
	public static int CompareInvariant(string source, string target, CompareOptions options)
	{
		return (!object.ReferenceEquals(source, target)) ? string.Compare(source, target, CultureInfo.InvariantCulture, options) : 0;
	}

	/// <summary>
	/// 使用固定区域排序规则比较当前字符串和目标字符串
	/// </summary>
	/// <param name="source">当前字符串</param>
	/// <param name="sourceStart">当前字符串开始比较的字符索引位置</param>
	/// <param name="target">比较的目标字符串</param>
	/// <param name="targetStart">目标搜字符串开始比较的字符索引位置</param>
	/// <param name="count">比较的字符数量</param>
	/// <param name="ignoreCase">字符串比较是否忽略大小写</param>
	/// <returns>如果当前字符串大于目标字符串返回大于0的值；当前字符串等于目标字符串返回0；当前字符串小于目标字符串返回小于0的值；如果当前字符串和目标字符串都为空，则返回0。</returns>
	/// <exception cref="T:System.IndexOutOfRangeException">
	/// 当前字符串开始比较的位置 <paramref name="sourceStart" /> 小于0，或者大于当前字符串中字符的最大索引；
	/// 目标字符串开始比较的位置 <paramref name="targetStart" /> 小于0，或者大于目标字符串中字符的最大索引；
	/// 比较的字符数量 <paramref name="count" /> 小于0，或者大于当前字符串和目标字符串中可比较的字符数量。
	/// </exception>
	public static int CompareInvariant(string source, int sourceStart, string target, int targetStart, int count, bool ignoreCase = false)
	{
		Guard.AssertGreaterThanOrEqualTo(sourceStart, 0, "source start");
		Guard.AssertGreaterThanOrEqualTo(targetStart, 0, "target start");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		return (!object.ReferenceEquals(source, target)) ? string.Compare(source, sourceStart, target, targetStart, count, ignoreCase ? StringComparison.InvariantCultureIgnoreCase : StringComparison.InvariantCulture) : 0;
	}

	/// <summary>
	/// 使用区域敏感排序规则比较当前字符串和目标字符串
	/// </summary>
	/// <param name="source">当前字符串</param>
	/// <param name="sourceStart">当前字符串开始比较的字符索引位置</param>
	/// <param name="target">比较的目标字符串</param>
	/// <param name="targetStart">目标搜字符串开始比较的字符索引位置</param>
	/// <param name="count">比较的字符数量</param>
	/// <param name="options">比较时使用的选项</param>
	/// <returns>如果当前字符串大于目标字符串返回大于0的值；当前字符串等于目标字符串返回0；当前字符串小于目标字符串返回小于0的值；如果当前字符串和目标字符串都为空，则返回0。</returns>
	/// <exception cref="T:System.IndexOutOfRangeException">
	/// 当前字符串开始比较的位置 <paramref name="sourceStart" /> 小于0，或者大于当前字符串中字符的最大索引；
	/// 目标字符串开始比较的位置 <paramref name="targetStart" /> 小于0，或者大于目标字符串中字符的最大索引；
	/// 比较的字符数量 <paramref name="count" /> 小于0，或者大于当前字符串和目标字符串中可比较的字符数量。
	/// </exception>
	public static int CompareInvariant(string source, int sourceStart, string target, int targetStart, int count, CompareOptions options)
	{
		Guard.AssertGreaterThanOrEqualTo(sourceStart, 0, "source start");
		Guard.AssertGreaterThanOrEqualTo(targetStart, 0, "target start");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		return (!object.ReferenceEquals(source, target)) ? string.Compare(source, sourceStart, target, targetStart, count, CultureInfo.InvariantCulture, options) : 0;
	}

	/// <summary>
	/// 使用序号排序规则比较当前字符串和目标字符串
	/// </summary>
	/// <param name="source">当前字符串</param>
	/// <param name="target">比较的目标字符串</param>
	/// <param name="ignoreCase">比较是否忽略大小写</param>
	/// <returns>如果当前字符串大于目标字符串返回大于0的值；当前字符串等于目标字符串返回0；当前字符串小于目标字符串返回小于0的值；如果当前字符串和目标字符串都为空，则返回0。</returns>
	public static int CompareOrdinal(string source, string target, bool ignoreCase = false)
	{
		if (object.ReferenceEquals(source, target))
		{
			return 0;
		}
		if (ignoreCase)
		{
			return string.Compare(source, target, StringComparison.OrdinalIgnoreCase);
		}
		return string.CompareOrdinal(source, target);
	}

	/// <summary>
	/// 使用序号排序规则比较当前字符串和目标字符串
	/// </summary>
	/// <param name="source">当前字符串</param>
	/// <param name="sourceStart">当前字符串开始比较的字符索引位置</param>
	/// <param name="target">比较的目标字符串</param>
	/// <param name="targetStart">目标搜字符串开始比较的字符索引位置</param>
	/// <param name="count">比较的字符数量</param>
	/// <param name="ignoreCase">字符串比较是否忽略大小写</param>
	/// <returns>如果当前字符串大于目标字符串返回大于0的值；当前字符串等于目标字符串返回0；当前字符串小于目标字符串返回小于0的值；如果当前字符串和目标字符串都为空，则返回0。</returns>
	/// <exception cref="T:System.IndexOutOfRangeException">
	/// 当前字符串开始比较的位置 <paramref name="sourceStart" /> 小于0，或者大于当前字符串中字符的最大索引；
	/// 目标字符串开始比较的位置 <paramref name="targetStart" /> 小于0，或者大于目标字符串中字符的最大索引；
	/// 比较的字符数量 <paramref name="count" /> 小于0，或者大于当前字符串和目标字符串中可比较的字符数量。
	/// </exception>
	public static int CompareOrdinal(string source, int sourceStart, string target, int targetStart, int count, bool ignoreCase = false)
	{
		Guard.AssertGreaterThanOrEqualTo(sourceStart, 0, "source start");
		Guard.AssertGreaterThanOrEqualTo(targetStart, 0, "target start");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		if (object.ReferenceEquals(source, target))
		{
			return 0;
		}
		if (ignoreCase)
		{
			return string.Compare(source, sourceStart, target, targetStart, count, StringComparison.OrdinalIgnoreCase);
		}
		return string.CompareOrdinal(source, sourceStart, target, targetStart, count);
	}

	/// <summary>
	/// 将当前字符串和对象数组中各个对象的字符串表示形式串联在一起
	/// </summary>
	/// <typeparam name="T">串联的对象序列元素类型</typeparam>
	/// <param name="s">当前字符串</param>
	/// <param name="values">对象数组</param>
	/// <returns>串联后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者对象数组 <paramref name="values" /> 为空。</exception>
	public static string Concat<T>(string s, params T[] values)
	{
		return Concat(s, values, string.Empty);
	}

	/// <summary>
	/// 将当前字符串和对象序列中各个对象的字符串表示形式串联在一起
	/// </summary>
	/// <typeparam name="T">串联的对象序列元素类型</typeparam>
	/// <param name="s">当前字符串</param>
	/// <param name="values">对象序列</param>
	/// <param name="splitter">当前字符串和对象序列中各个对象的字符串表示之间的分隔符，默认无分隔符。</param>
	/// <returns>串联后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者对象序列 <paramref name="values" /> 为空。</exception>
	public static string Concat<T>(string s, IEnumerable<T> values, string splitter = "")
	{
		return Concat(s, values, (T x) => x.ToString(), splitter);
	}

	/// <summary>
	/// 将当前字符串和对象序列中各个对象的字符串表示形式串联在一起
	/// </summary>
	/// <typeparam name="T">串联的对象序列元素类型</typeparam>
	/// <param name="s">当前字符串</param>
	/// <param name="values">对象序列</param>
	/// <param name="formatting">对象格式化方法，将对象转换为相应的字符串表示</param>
	/// <param name="splitter">当前字符串和对象序列中各个对象的字符串表示之间的分隔符，默认无分隔符。</param>
	/// <returns>串联后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者对象序列 <paramref name="values" /> 为空；或者对象格式化方法 <paramref name="formatting" /> 为空。</exception>
	public static string Concat<T>(string s, IEnumerable<T> values, Func<T, string> formatting, string splitter = "")
	{
		Guard.AssertNotNull(s, "s");
		Guard.AssertNotNull(values, "values");
		Guard.AssertNotNull(formatting, "formatter");
		splitter = ObjectHelper.IfNull(splitter, string.Empty);
		StringBuilder buff = new StringBuilder();
		buff.Append(s).Append(splitter);
		foreach (T value in values)
		{
			buff.Append(formatting(value)).Append(splitter);
		}
		return (buff.Length > 0) ? buff.ToString(0, buff.Length - splitter.Length) : buff.ToString();
	}

	/// <summary>
	/// 检测当前文本中是否包含指定的字符；使用当前区域信息比较字符。
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">检测的字符</param>
	/// <param name="ignoreCase">比较字符是否区分大小写</param>
	/// <returns>如果当前的文本中包含指定的字符返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static bool Contains(string text, char c, bool ignoreCase = false)
	{
		return Contains(text, c, CultureInfo.CurrentCulture, ignoreCase);
	}

	/// <summary>
	/// 检测当前文本中是否包含指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">检测的字符</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="ignoreCase">比较字符是否区分大小写</param>
	/// <returns>如果当前文本中包含指定的字符返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static bool Contains(string text, char c, CultureInfo culture, bool ignoreCase = false)
	{
		return Contains(text, c, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 检测当前文本中是否包含指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">检测的字符</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="options">比较字符时使用的选项</param>
	/// <returns>如果当前的文本中包含指定的字符返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static bool Contains(string text, char c, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "s");
		return ObjectHelper.IfNull(culture, CultureInfo.CurrentCulture).CompareInfo.IndexOf(text, c, options) >= 0;
	}

	/// <summary>
	/// 检测当前文本中是否包含指定的字符串
	/// </summary>
	/// <param name="text">当前的文本</param>
	/// <param name="value">检测的字符串</param>
	/// <param name="ignoreCase">字符串比较是否区分大小写</param>
	/// <returns>如果检测当前文本中包含指定的字符串返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者待检测的字符串 <paramref name="value" /> 为空。</exception>
	public static bool Contains(string text, string value, bool ignoreCase)
	{
		Guard.AssertNotNull(text, "s");
		Guard.AssertNotNull(value, "value");
		return text.IndexOf(value, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal) >= 0;
	}

	/// <summary>
	/// 检测当前文本中是否包含指定的字符串
	/// </summary>
	/// <param name="text">当前的文本</param>
	/// <param name="value">检测的字符串</param>
	/// <param name="comparison">字符串比较方式</param>
	/// <returns>如果检测当前文本中是否包含指定的字符串返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者待检测的字符串 <paramref name="value" /> 为空。</exception>
	public static bool Contains(string text, string value, StringComparison comparison)
	{
		Guard.AssertNotNull(text, "s");
		Guard.AssertNotNull(value, "value");
		return text.IndexOf(value, comparison) >= 0;
	}

	/// <summary>
	/// 检测当前文本中是否包含指定的字符串
	/// </summary>
	/// <param name="text">当前的文本</param>
	/// <param name="value">检测的字符串</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="ignoreCase">比较字符串时是否区分大小写</param>
	/// <returns>如果检测当前文本中是否包含指定的字符串返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者待检测的字符串 <paramref name="value" /> 为空。</exception>
	public static bool Contains(string text, string value, CultureInfo culture, bool ignoreCase = false)
	{
		return Contains(text, value, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 检测当前文本中是否包含指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="value">检测的字符串</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="options">比较字符时使用的选项</param>
	/// <returns>如果检测当前文本中是否包含指定的字符串返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者待检测的字符串 <paramref name="value" /> 为空。</exception>
	public static bool Contains(string text, string value, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "s");
		Guard.AssertNotNull(value, "value");
		return ObjectHelper.IfNull(culture, CultureInfo.CurrentCulture).CompareInfo.IndexOf(text, value, options) >= 0;
	}

	/// <summary>
	/// 检测当前文本是否包含全部指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="cs">待检测的字符数组</param>
	/// <returns>如果当前文本中包含指定的全部字符返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者待检测的字符数组 <paramref name="cs" /> 为空。</exception>
	public static bool ContainsAll(string text, params char[] cs)
	{
		return ContainsAll(text, cs, ignoreCase: false);
	}

	/// <summary>
	/// 检测当前文本是否包含全部指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="cs">检测的字符串数组</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果当前文本包含指定的全部字符返回true，否则返回flase。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者检测的字符数组 <paramref name="cs" /> 为空。</exception>
	public static bool ContainsAll(string text, char[] cs, bool ignoreCase)
	{
		return ContainsAll(text, cs, CultureInfo.CurrentCulture, ignoreCase);
	}

	/// <summary>
	/// 检测当前文本是否包含全部指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="cs">检测的字符串数组</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果当前文本包含指定的全部字符返回true，否则返回flase。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者检测的字符数组 <paramref name="cs" /> 为空。</exception>
	public static bool ContainsAll(string text, char[] cs, CultureInfo culture, bool ignoreCase = false)
	{
		return ContainsAll(text, cs, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 检测当前文本是否包含全部指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="cs">检测的字符串数组</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="options">比较字符时的选项</param>
	/// <returns>如果当前文本包含指定的全部字符返回true，否则返回flase。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者检测的字符数组 <paramref name="cs" /> 为空。</exception>
	public static bool ContainsAll(string text, char[] cs, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(cs, "chars");
		return cs.All((char c) => Contains(text, c, culture, options));
	}

	/// <summary>
	/// 检测当前文本是否包含任意指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="cs">待检测的字符数组</param>
	/// <returns>如果当前文本中包含指定的任意字符返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者待检测的字符数组 <paramref name="cs" /> 为空。</exception>
	public static bool ContainsAny(string text, params char[] cs)
	{
		return ContainsAny(text, cs, ignoreCase: false);
	}

	/// <summary>
	/// 检测当前文本是否包含任意指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="cs">检测的字符数组</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果当前文本中包含任意指定的字符返回true，或者返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者检测的字符数组 <paramref name="cs" /> 为空。</exception>
	public static bool ContainsAny(string text, char[] cs, bool ignoreCase)
	{
		return ContainsAny(text, cs, CultureInfo.CurrentCulture, ignoreCase);
	}

	/// <summary>
	/// 检测当前文本是否包含任意指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="cs">检测的字符数组</param>
	/// <param name="culture">比较字符时使用的区域信息，默认使用当前线程的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果当前文本中包含任意指定的字符返回true，或者返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者检测的字符数组 <paramref name="cs" /> 为空。</exception>
	public static bool ContainsAny(string text, char[] cs, CultureInfo culture, bool ignoreCase = false)
	{
		return ContainsAny(text, cs, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 检测当前文本是否包含任意指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="cs">检测的字符数组</param>
	/// <param name="culture">比较字符时使用的区域信息，默认使用当前线程的区域信息</param>
	/// <param name="options">比较字符时的选项</param>
	/// <returns>如果当前文本中包含任意指定的字符返回true，或者返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者检测的字符数组 <paramref name="cs" /> 为空。</exception>
	public static bool ContainsAny(string text, char[] cs, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(cs, "chars");
		return cs.Any((char c) => Contains(text, c, culture, options));
	}

	/// <summary>
	/// 判断当前文本中是否包含字符串复合格式化标记
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <returns>如果当前文本中包含字符串复合格式化标记返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static bool ContainsFormatToken(string text)
	{
		Guard.AssertNotNull(text, "text");
		return RegexPatterns.StringFormatToken.IsMatch(text);
	}

	/// <summary>
	/// 判断当前文本中是否包含HTML标记
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <returns>如果当前文本包含HTML标记返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static bool ContainsHtmlTag(string text)
	{
		Guard.AssertNotNull(text, "text");
		return RegexPatterns.HtmlTag.IsMatch(text);
	}

	/// <summary>
	/// 判断当前文本中是否包含Unicode的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <returns>如果当前文本包含Unicode字符返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static bool ContainsUnicode(string text)
	{
		Guard.AssertNotNull(text, "text");
		return RegexPatterns.NonAsciiMore.IsMatch(text);
	}

	/// <summary>
	/// 统计当前文本中与指定字符相同
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">统计的字符</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>与指定字符相同的字符的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static int CountChar(string text, char c, bool ignoreCase = false)
	{
		Guard.AssertNotNull(text, "text");
		return CountChar(text, c, 0, text.Length, ignoreCase);
	}

	/// <summary>
	/// 统计当前文本中与指定字符相同
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">统计的字符</param>
	/// <param name="culture">比较字符的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>与指定字符相同的字符的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static int CountChar(string text, char c, CultureInfo culture, bool ignoreCase = false)
	{
		Guard.AssertNotNull(text, "text");
		return CountChar(text, c, 0, text.Length, culture, ignoreCase);
	}

	/// <summary>
	/// 统计当前文本中与指定字符相同
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">统计的字符</param>
	/// <param name="culture">比较字符的区域信息</param>
	/// <param name="options">比较字符的选项</param>
	/// <returns>与指定字符相同的字符的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static int CountChar(string text, char c, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		return CountChar(text, c, 0, text.Length, culture, options);
	}

	/// <summary>
	/// 统计当前文本中符合条件的字符数量
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="predicate">字符筛选条件</param>
	/// <returns>符合筛选条件的字符个数</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者字符筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static int CountChar(string text, Func<char, bool> predicate)
	{
		Guard.AssertNotNull(text, "text");
		return CountChar(text, predicate, 0, text.Length);
	}

	/// <summary>
	/// 统计当前文本区域中与指定字符相同的字符的数量
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">统计的字符</param>
	/// <param name="start">统计区域的起始索引</param>
	/// <param name="count">统计区域的字符数量</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>与指定字符相同的字符的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">统计区域的起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">统计的字符数量 <paramref name="count" /> 小于0，或者大于当前文本中剩余的字符个数。</exception>
	public static int CountChar(string text, char c, int start, int count, bool ignoreCase = false)
	{
		return CountChar(text, (char x) => IsEqualTo(c, x, CultureInfo.CurrentCulture, ignoreCase), start, count);
	}

	/// <summary>
	/// 统计当前文本区域中与指定字符相同的字符的数量
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">统计的字符</param>
	/// <param name="start">统计区域的起始索引</param>
	/// <param name="count">统计区域的字符数量</param>
	/// <param name="culture">比较字符的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>与指定字符相同的字符的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">统计区域的起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">统计的字符数量 <paramref name="count" /> 小于0，或者大于当前文本中剩余的字符个数。</exception>
	public static int CountChar(string text, char c, int start, int count, CultureInfo culture, bool ignoreCase = false)
	{
		return CountChar(text, (char x) => IsEqualTo(c, x, culture, ignoreCase), start, count);
	}

	/// <summary>
	/// 统计当前文本区域中与指定字符相同的字符的数量
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">统计的字符</param>
	/// <param name="start">统计区域的起始索引</param>
	/// <param name="count">统计区域的字符数量</param>
	/// <param name="culture">比较字符的区域信息</param>
	/// <param name="options">比较字符的选项</param>
	/// <returns>与指定字符相同的字符的数量</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">统计区域的起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">统计的字符数量 <paramref name="count" /> 小于0，或者大于当前文本中剩余的字符个数。</exception>
	public static int CountChar(string text, char c, int start, int count, CultureInfo culture, CompareOptions options)
	{
		return CountChar(text, (char x) => IsEqualTo(c, x, culture, options), start, count);
	}

	/// <summary>
	/// 统计当前文本的指定区域中符合条件的字符的数量
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="predicate">字符筛选条件</param>
	/// <param name="start">统计区域的起始索引</param>
	/// <param name="count">统计区域的字符数量</param>
	/// <returns>符合条件字符的个数</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者字符筛选条件 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">统计区域的起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">统计的字符数量 <paramref name="count" /> 小于0，或者大于当前文本中剩余的字符个数。</exception>
	public static int CountChar(string text, Func<char, bool> predicate, int start, int count)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertIndexRange(start, 0, text.Length - 1, "start");
		Guard.AssertBetween(count, 0, text.Length - start, "count");
		int end = start + count;
		int charCount = 0;
		for (int i = start; i < end; i++)
		{
			if (predicate(text[i]))
			{
				charCount++;
			}
		}
		return charCount;
	}

	/// <summary>
	/// 统计当前文本中正则模式的匹配次数
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">用于匹配的正则模式</param>
	/// <param name="options">正则模式匹配参数</param>
	/// <returns>正则模式匹配计数</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者用于匹配的正则模式 <paramref name="pattern" /> 为空。</exception>
	public static int CountRegex(string text, string pattern, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return CountRegex(text, ConvertHelper.ToRegex(pattern, options));
	}

	/// <summary>
	/// 统计当前文本的指定区域中正则模式的匹配次数
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">用于匹配的正则模式</param>
	/// <param name="start">统计区域的起始索引</param>
	/// <param name="count">统计区域的字符数量</param>
	/// <param name="options">正则模式匹配参数</param>
	/// <returns>正则模式匹配计数</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者用于匹配的正则模式 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">统计区域的起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">统计的字符数量 <paramref name="count" /> 小于0，或者大于当前文本中剩余的字符个数。</exception>
	public static int CountRegex(string text, string pattern, int start, int count, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return CountRegex(text, ConvertHelper.ToRegex(pattern, options), start, count);
	}

	/// <summary>
	/// 统计当前文本中正则模式的匹配次数
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">用于匹配的正则模式</param>
	/// <returns>正则模式匹配计数</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者用于匹配的正则模式 <paramref name="pattern" /> 为空。</exception>
	public static int CountRegex(string text, Regex pattern)
	{
		return GetMatches(pattern, text).Length;
	}

	/// <summary>
	/// 统计当前文本的指定区域中正则模式的匹配次数
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">用于匹配的正则模式</param>
	/// <param name="start">统计区域的起始索引</param>
	/// <param name="count">统计区域的字符数量</param>
	/// <returns>正则模式匹配计数</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者用于匹配的正则模式 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">统计区域的起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">统计的字符数量 <paramref name="count" /> 小于0，或者大于当前文本中剩余的字符个数。</exception>
	public static int CountRegex(string text, Regex pattern, int start, int count)
	{
		return GetMatches(pattern, text, start, count).Length;
	}

	/// <summary>
	/// 使用区域敏感排序规则比较当前字符串和目标字符串的相等性
	/// </summary>
	/// <param name="source">当前字符串</param>
	/// <param name="target">比较的目标字符串</param>
	/// <param name="ignoreCase">比较是否忽略大小写</param>
	/// <returns>如果两个字符串相同返回true,否则返回false。</returns>
	public static bool EqualCultural(string source, string target, bool ignoreCase = false)
	{
		return CompareCultural(source, target, ignoreCase) == 0;
	}

	/// <summary>
	/// 使用区域敏感排序规则比较当前字符串和目标字符串的相等性
	/// </summary>
	/// <param name="source">当前字符串</param>
	/// <param name="target">比较的目标字符串</param>
	/// <param name="comparison">字符串比较规则</param>
	/// <returns>如果两个字符串相同返回true,否则返回false。</returns>
	public static bool EqualCultural(string source, string target, StringComparison comparison)
	{
		return CompareCultural(source, target, comparison) == 0;
	}

	/// <summary>
	/// 使用区域敏感排序规则比较当前字符串和目标字符串的相等性
	/// </summary>
	/// <param name="source">当前字符串</param>
	/// <param name="target">比较的目标字符串</param>
	/// <param name="culture">用于比较的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="ignoreCase">比较是否忽略大小写</param>
	/// <returns>如果两个字符串相同返回true,否则返回false。</returns>
	public static bool EqualCultural(string source, string target, CultureInfo culture, bool ignoreCase = false)
	{
		return CompareCultural(source, target, culture, ignoreCase) == 0;
	}

	/// <summary>
	/// 使用区域敏感排序规则比较当前字符串和目标字符串的相等性
	/// </summary>
	/// <param name="source">当前字符串</param>
	/// <param name="target">比较的目标字符串</param>
	/// <param name="culture">用于比较的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="options">字符串比较选项</param>
	/// <returns>如果两个字符串相同返回true,否则返回false。</returns>
	public static bool EqualCultural(string source, string target, CultureInfo culture, CompareOptions options)
	{
		return CompareCultural(source, target, culture, options) == 0;
	}

	/// <summary>
	/// 使用固定区域排序规则比较当前字符串和目标字符串的相等性
	/// </summary>
	/// <param name="source">当前字符串</param>
	/// <param name="target">比较的目标字符串</param>
	/// <param name="ignoreCase">比较是否忽略大小写</param>
	/// <returns>如果两个字符串相同返回true,否则返回false。</returns>
	public static bool EqualInvariant(string source, string target, bool ignoreCase = false)
	{
		return CompareInvariant(source, target, ignoreCase) == 0;
	}

	/// <summary>
	/// 使用固定区域排序规则比较当前字符串和目标字符串的相等性
	/// </summary>
	/// <param name="source">当前字符串</param>
	/// <param name="target">比较的目标字符串</param>
	/// <param name="options">字符串比较选项</param>
	/// <returns>如果两个字符串相同返回true,否则返回false。</returns>
	public static bool EqualInvariant(string source, string target, CompareOptions options)
	{
		return CompareInvariant(source, target, options) == 0;
	}

	/// <summary>
	/// 使用序号排序规则比较当前字符串和目标字符串的相等性
	/// </summary>
	/// <param name="source">当前字符串</param>
	/// <param name="target">比较的目标字符串</param>
	/// <param name="ignoreCase">比较是否忽略大小写</param>
	/// <returns>如果两个字符串相同返回true,否则返回false。</returns>
	public static bool EqualOrdinal(string source, string target, bool ignoreCase = false)
	{
		return CompareOrdinal(source, target, ignoreCase) == 0;
	}

	/// <summary>
	/// 将当前文本中的制表符用指定数量的空格替换后返回，如果指定的空格数量等于0则移除制表符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="tabSize">制表符的大小，默认一个制表符转换为4个空格，制表符大小应大于等于0</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">制表符转换的空格数量 <paramref name="tabSize" /> 小于0。</exception>
	public static string ExpandTabs(string text, int tabSize = 4)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertGreaterThanOrEqualTo(tabSize, 0, "tab size");
		return text.Replace("\t", (tabSize > 0) ? new string(' ', tabSize) : null);
	}

	/// <summary>
	/// 向当前字符数组中填充全角空格
	/// </summary>
	/// <param name="chars">当前字符数组</param>
	/// <returns>填充后的字符数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static char[] FillFullSpace(char[] chars)
	{
		Guard.AssertNotNull(chars, "chars");
		return ArrayHelper.Fill(chars, '\u3000');
	}

	/// <summary>
	/// 向当前字符数组中填充空值（\0）
	/// </summary>
	/// <param name="chars">当前字符数组</param>
	/// <returns>填充后的字符数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static char[] FillNull(char[] chars)
	{
		Guard.AssertNotNull(chars, "chars");
		return ArrayHelper.Fill(chars, '\0');
	}

	/// <summary>
	/// 向当前字符数组中填充空格
	/// </summary>
	/// <param name="chars">当前字符数组</param>
	/// <returns>填充后的字符数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static char[] FillSpace(char[] chars)
	{
		Guard.AssertNotNull(chars, "chars");
		return ArrayHelper.Fill(chars, ' ');
	}

	/// <summary>
	/// 在当前文本中查找字符串出现的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="value">待查找的字符串</param>
	/// <param name="ignoreCase">字符串是否区分大小写</param>
	/// <returns>指定的字符串在当前文本中出现的索引位置，如果没有找到匹配的字符串，返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的文本为空；或者查找的字符串为空。</exception>
	public static int Find(string text, string value, bool ignoreCase = false)
	{
		Guard.AssertNotNull(text, "text");
		return Find(text, value, 0, text.Length, 1, ignoreCase);
	}

	/// <summary>
	/// 在当前文本中查找字符串出现的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="value">待查找的字符串</param>
	/// <param name="comparison">文本比较参数</param>
	/// <returns>指定的字符串在当前文本中出现的索引位置，如果没有找到匹配的字符串，返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的文本为空；或者查找的字符串为空。</exception>
	public static int Find(string text, string value, StringComparison comparison)
	{
		Guard.AssertNotNull(text, "text");
		return Find(text, value, 0, text.Length, 1, comparison);
	}

	/// <summary>
	/// 在当前文本中的区域内查找出现指定次数的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="value">待查找的字符串</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>指定的字符串在当前文本中出现指定次数时的索引位置，如果没有找到匹配的字符串，返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的文本为空；或者查找的字符串为空。</exception>
	public static int Find(string text, string value, CultureInfo culture, bool ignoreCase = false)
	{
		Guard.AssertNotNull(text, "text");
		return Find(text, value, 0, text.Length, 1, culture, ignoreCase);
	}

	/// <summary>
	/// 在当前文本中的区域内查找出现指定次数的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="value">待查找的字符串</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="options">比较字符时使用的选项</param>
	/// <returns>指定的字符串在当前文本中出现指定次数时的索引位置，如果没有找到匹配的字符串，返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的文本为空；或者查找的字符串为空。</exception>
	public static int Find(string text, string value, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		return Find(text, value, 0, text.Length, 1, culture, options);
	}

	/// <summary>
	/// 在当前文本中查找出现指定次数的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="value">待查找的字符串</param>
	/// <param name="times">查找字符串出现的次数</param>
	/// <param name="ignoreCase">字符串是否区分大小写</param>
	/// <returns>指定的字符串在当前文本中出现指定次数时的索引位置，如果没有找到匹配的字符串，返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的文本为空；或者查找的字符串为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的次数 <paramref name="times" /> 小于1。</exception>
	public static int Find(string text, string value, int times, bool ignoreCase = false)
	{
		Guard.AssertNotNull(text, "text");
		return Find(text, value, 0, text.Length, times, ignoreCase);
	}

	/// <summary>
	/// 在当前文本中查找出现指定次数的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="value">待查找的字符串</param>
	/// <param name="times">查找字符串出现的次数</param>
	/// <param name="comparison">文本比较参数</param>
	/// <returns>指定的字符串在当前文本中出现指定次数时的索引位置，如果没有找到匹配的字符串，返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的文本为空；或者查找的字符串为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的次数 <paramref name="times" /> 小于1。</exception>
	public static int Find(string text, string value, int times, StringComparison comparison)
	{
		Guard.AssertNotNull(text, "text");
		return Find(text, value, 0, text.Length, times, comparison);
	}

	/// <summary>
	/// 在当前文本中的区域内查找出现指定次数的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="value">待查找的字符串</param>
	/// <param name="times">查找字符串出现的次数</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>指定的字符串在当前文本中出现指定次数时的索引位置，如果没有找到匹配的字符串，返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的文本为空；或者查找的字符串为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的次数 <paramref name="times" /> 小于1。</exception>
	public static int Find(string text, string value, int times, CultureInfo culture, bool ignoreCase = false)
	{
		Guard.AssertNotNull(text, "text");
		return Find(text, value, 0, text.Length, times, culture, ignoreCase);
	}

	/// <summary>
	/// 在当前文本中的区域内查找出现指定次数的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="value">待查找的字符串</param>
	/// <param name="times">查找字符串出现的次数</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="options">比较字符时使用的选项</param>
	/// <returns>指定的字符串在当前文本中出现指定次数时的索引位置，如果没有找到匹配的字符串，返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的文本为空；或者查找的字符串为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的次数 <paramref name="times" /> 小于1。</exception>
	public static int Find(string text, string value, int times, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		return Find(text, value, 0, text.Length, times, culture, options);
	}

	/// <summary>
	/// 在当前文本中的区域内查找出现指定次数的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="value">待查找的字符串</param>
	/// <param name="start">查找区域的起始索引</param>
	/// <param name="count">查找区域中的字符数量</param>
	/// <param name="ignoreCase">字符串是否区分大小写</param>
	/// <returns>指定的字符串在当前文本中出现的索引位置，如果没有找到匹配的字符串，返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的文本为空；或者查找的字符串为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找的起始索引 <paramref name="start" /> 小于0，大于当前文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的字符数量 <paramref name="count" /> 小于0，大于当前文本中从起始位置开始剩余的字符数量。</exception>
	public static int Find(string text, string value, int start, int count, bool ignoreCase = false)
	{
		return Find(text, value, start, count, 1, ignoreCase);
	}

	/// <summary>
	/// 在当前文本中的区域内查找出现指定次数的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="value">待查找的字符串</param>
	/// <param name="start">查找区域的起始索引</param>
	/// <param name="count">查找区域中的字符数量</param>
	/// <param name="comparison">文本比较参数</param>
	/// <returns>指定的字符串在当前文本中出现的索引位置，如果没有找到匹配的字符串，返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的文本为空；或者查找的字符串为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找的起始索引 <paramref name="start" /> 小于0，大于当前文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的字符数量 <paramref name="count" /> 小于0，大于当前文本中从起始位置开始剩余的字符数量。</exception>
	public static int Find(string text, string value, int start, int count, StringComparison comparison)
	{
		return Find(text, value, start, count, 1, comparison);
	}

	/// <summary>
	/// 在当前文本中的区域内查找出现指定次数的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="value">待查找的字符串</param>
	/// <param name="start">查找区域的起始索引</param>
	/// <param name="count">查找区域中的字符数量</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>指定的字符串在当前文本中出现指定次数时的索引位置，如果没有找到匹配的字符串，返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的文本为空；或者查找的字符串为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找的起始索引 <paramref name="start" /> 小于0，大于当前文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的字符数量 <paramref name="count" /> 小于0，大于当前文本中从起始位置开始剩余的字符数量。</exception>
	public static int Find(string text, string value, int start, int count, CultureInfo culture, bool ignoreCase = false)
	{
		return Find(text, value, start, count, 1, culture, ignoreCase);
	}

	/// <summary>
	/// 在当前文本中的区域内查找出现指定次数的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="value">待查找的字符串</param>
	/// <param name="start">查找区域的起始索引</param>
	/// <param name="count">查找区域中的字符数量</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="options">比较字符时使用的选项</param>
	/// <returns>指定的字符串在当前文本中出现指定次数时的索引位置，如果没有找到匹配的字符串，返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的文本为空；或者查找的字符串为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找的起始索引 <paramref name="start" /> 小于0，大于当前文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的字符数量 <paramref name="count" /> 小于0，大于当前文本中从起始位置开始剩余的字符数量。</exception>
	public static int Find(string text, string value, int start, int count, CultureInfo culture, CompareOptions options)
	{
		return Find(text, value, start, count, 1, culture, options);
	}

	/// <summary>
	/// 在当前文本中的区域内查找出现指定次数的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="value">待查找的字符串</param>
	/// <param name="start">查找区域的起始索引</param>
	/// <param name="count">查找区域中的字符数量</param>
	/// <param name="times">查找出现指定次数的字符串</param>
	/// <param name="ignoreCase">字符串是否区分大小写</param>
	/// <returns>指定的字符串在当前文本中出现指定次数时的索引位置，如果没有找到匹配的字符串，返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的文本为空；或者查找的字符串为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找的起始索引 <paramref name="start" /> 小于0，大于当前文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的字符数量 <paramref name="count" /> 小于0，大于当前文本中从起始位置开始剩余的字符数量；或者查找的次数 <paramref name="times" /> 小于1。</exception>
	public static int Find(string text, string value, int start, int count, int times, bool ignoreCase = false)
	{
		return Find(text, value, start, count, times, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
	}

	/// <summary>
	/// 在当前文本中的区域内查找出现指定次数的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="value">待查找的字符串</param>
	/// <param name="start">查找区域的起始索引</param>
	/// <param name="count">查找区域中的字符数量</param>
	/// <param name="times">查找出现指定次数的字符串</param>
	/// <param name="comparison">文本比较参数</param>
	/// <returns>指定的字符串在当前文本中出现指定次数时的索引位置，如果没有找到匹配的字符串，返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的文本为空；或者查找的字符串为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找的起始索引 <paramref name="start" /> 小于0，大于当前文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的字符数量 <paramref name="count" /> 小于0，大于当前文本中从起始位置开始剩余的字符数量；或者查找的次数 <paramref name="times" /> 小于1。</exception>
	public static int Find(string text, string value, int start, int count, int times, StringComparison comparison)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(value, "value");
		Guard.AssertBetween(start, 0, text.Length - 1, "start");
		Guard.AssertBetween(count, 0, text.Length - start, "count");
		Guard.AssertGreaterThanOrEqualTo(times, 1, "times");
		int end = start + count;
		int found = 0;
		int index = 0;
		while ((index = text.IndexOf(value, start, count, comparison)) >= 0)
		{
			if (++found >= times)
			{
				return index;
			}
			start = index + value.Length;
			if (start >= end)
			{
				return -1;
			}
		}
		return -1;
	}

	/// <summary>
	/// 在当前文本中的区域内查找出现指定次数的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="value">待查找的字符串</param>
	/// <param name="start">查找区域的起始索引</param>
	/// <param name="count">查找区域中的字符数量</param>
	/// <param name="times">查找出现指定次数的字符串</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>指定的字符串在当前文本中出现指定次数时的索引位置，如果没有找到匹配的字符串，返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的文本为空；或者查找的字符串为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找的起始索引 <paramref name="start" /> 小于0，大于当前文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的字符数量 <paramref name="count" /> 小于0，大于当前文本中从起始位置开始剩余的字符数量；或者查找的次数 <paramref name="times" /> 小于1。</exception>
	public static int Find(string text, string value, int start, int count, int times, CultureInfo culture, bool ignoreCase = false)
	{
		return Find(text, value, start, count, times, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 在当前文本中的区域内查找出现指定次数的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="value">待查找的字符串</param>
	/// <param name="start">查找区域的起始索引</param>
	/// <param name="count">查找区域中的字符数量</param>
	/// <param name="times">查找出现指定次数的字符串</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="options">比较字符时使用的选项</param>
	/// <returns>指定的字符串在当前文本中出现指定次数时的索引位置，如果没有找到匹配的字符串，返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的文本为空；或者查找的字符串为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找的起始索引 <paramref name="start" /> 小于0，大于当前文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的字符数量 <paramref name="count" /> 小于0，大于当前文本中从起始位置开始剩余的字符数量；或者查找的次数 <paramref name="times" /> 小于1。</exception>
	public static int Find(string text, string value, int start, int count, int times, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(value, "value");
		Guard.AssertBetween(start, 0, text.Length - 1, "start");
		Guard.AssertBetween(count, 0, text.Length - start, "count");
		Guard.AssertGreaterThanOrEqualTo(times, 1, "times");
		int end = start + count;
		int found = 0;
		int index = 0;
		while ((index = IndexOf(text, value, start, count, culture, options)) >= 0)
		{
			if (++found >= times)
			{
				return index;
			}
			start = index + value.Length;
			if (start >= end)
			{
				return -1;
			}
		}
		return -1;
	}

	/// <summary>
	/// 在当前文本中逆向查找字符串的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="value">待查找的字符串</param>
	/// <param name="ignoreCase">字符串是否区分大小写</param>
	/// <returns>指定的字符串在当前文本中出现的索引位置，如果没有找到匹配的字符串，返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的文本为空；或者查找的字符串为空。</exception>
	public static int FindLast(string text, string value, bool ignoreCase = false)
	{
		Guard.AssertNotNull(text, "text");
		return FindLast(text, value, text.Length - 1, text.Length, 1, ignoreCase);
	}

	/// <summary>
	/// 在当前文本中逆向查找字符串的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="value">待查找的字符串</param>
	/// <param name="comparison">文本比较参数</param>
	/// <returns>指定的字符串在当前文本中出现的索引位置，如果没有找到匹配的字符串，返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的文本为空；或者查找的字符串为空。</exception>
	public static int FindLast(string text, string value, StringComparison comparison)
	{
		Guard.AssertNotNull(text, "text");
		return FindLast(text, value, text.Length - 1, text.Length, 1, comparison);
	}

	/// <summary>
	/// 在当前文本中逆向查找字符串的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="value">待查找的字符串</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>指定的字符串在当前文本中出现的索引位置，如果没有找到匹配的字符串，返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的文本为空；或者查找的字符串为空。</exception>
	public static int FindLast(string text, string value, CultureInfo culture, bool ignoreCase = false)
	{
		Guard.AssertNotNull(text, "text");
		return FindLast(text, value, text.Length - 1, text.Length, 1, culture, ignoreCase);
	}

	/// <summary>
	/// 在当前文本中逆向查找字符串的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="value">待查找的字符串</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="options">比较字符时使用的选项</param>
	/// <returns>指定的字符串在当前文本中出现的索引位置，如果没有找到匹配的字符串，返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的文本为空；或者查找的字符串为空。</exception>
	public static int FindLast(string text, string value, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		return FindLast(text, value, text.Length - 1, text.Length, 1, culture, options);
	}

	/// <summary>
	/// 在当前文本中逆向查找出现指定次数的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="value">待查找的字符串</param>
	/// <param name="times">查找出现指定次数的字符串</param>
	/// <param name="ignoreCase">字符串是否区分大小写</param>
	/// <returns>指定的字符串在当前文本中出现指定次数时的索引位置，如果没有找到匹配的字符串，返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的文本为空；或者查找的字符串为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的次数 <paramref name="times" /> 小于1。</exception>
	public static int FindLast(string text, string value, int times, bool ignoreCase = false)
	{
		Guard.AssertNotNull(text, "text");
		return FindLast(text, value, text.Length - 1, text.Length, times, ignoreCase);
	}

	/// <summary>
	/// 在当前文本中逆向查找出现指定次数的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="value">待查找的字符串</param>
	/// <param name="times">查找出现指定次数的字符串</param>
	/// <param name="comparison">文本比较参数</param>
	/// <returns>指定的字符串在当前文本中出现指定次数时的索引位置，如果没有找到匹配的字符串，返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的文本为空；或者查找的字符串为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的次数 <paramref name="times" /> 小于1。</exception>
	public static int FindLast(string text, string value, int times, StringComparison comparison)
	{
		Guard.AssertNotNull(text, "text");
		return FindLast(text, value, text.Length - 1, text.Length, times, comparison);
	}

	/// <summary>
	/// 在当前文本中逆向查找出现指定次数的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="value">待查找的字符串</param>
	/// <param name="times">查找出现指定次数的字符串</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>指定的字符串在当前文本中出现指定次数时的索引位置，如果没有找到匹配的字符串，返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的文本为空；或者查找的字符串为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的次数 <paramref name="times" /> 小于1。</exception>
	public static int FindLast(string text, string value, int times, CultureInfo culture, bool ignoreCase = false)
	{
		Guard.AssertNotNull(text, "text");
		return FindLast(text, value, text.Length - 1, text.Length, times, culture, ignoreCase);
	}

	/// <summary>
	/// 在当前文本中逆向查找出现指定次数的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="value">待查找的字符串</param>
	/// <param name="times">查找出现指定次数的字符串</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="options">比较字符时使用的选项</param>
	/// <returns>指定的字符串在当前文本中出现指定次数时的索引位置，如果没有找到匹配的字符串，返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的文本为空；或者查找的字符串为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找的次数 <paramref name="times" /> 小于1。</exception>
	public static int FindLast(string text, string value, int times, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		return FindLast(text, value, text.Length - 1, text.Length, times, culture, options);
	}

	/// <summary>
	/// 在当前文本中的区域内逆向查找字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="value">待查找的字符串</param>
	/// <param name="start">查找区域的起始索引</param>
	/// <param name="count">查找区域中的字符数量</param>
	/// <param name="ignoreCase">字符串是否区分大小写</param>
	/// <returns>指定的字符串在当前文本中出现的索引位置，如果没有找到匹配的字符串，返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的文本为空；或者查找的字符串为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域的起始索引 <paramref name="start" /> 小于0，大于当前文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域的字符数量 <paramref name="count" /> 小于0，大于当前文本中从起始位置到索引起始位置的字符数量。</exception>
	public static int FindLast(string text, string value, int start, int count, bool ignoreCase = false)
	{
		return FindLast(text, value, start, count, 1, ignoreCase);
	}

	/// <summary>
	/// 在当前文本中的区域内逆向查找字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="value">待查找的字符串</param>
	/// <param name="start">查找区域的起始索引</param>
	/// <param name="count">查找区域中的字符数量</param>
	/// <param name="comparison">文本比较参数</param>
	/// <returns>指定的字符串在当前文本中出现的索引位置，如果没有找到匹配的字符串，返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的文本为空；或者查找的字符串为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域的起始索引 <paramref name="start" /> 小于0，大于当前文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域的字符数量 <paramref name="count" /> 小于0，大于当前文本中从起始位置到索引起始位置的字符数量。</exception>
	public static int FindLast(string text, string value, int start, int count, StringComparison comparison)
	{
		return FindLast(text, value, start, count, 1, comparison);
	}

	/// <summary>
	/// 在当前文本中的区域内逆向查找字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="value">待查找的字符串</param>
	/// <param name="start">查找区域的起始索引</param>
	/// <param name="count">查找区域中的字符数量</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否使用大小写</param>
	/// <returns>指定的字符串在当前文本中出现的索引位置，如果没有找到匹配的字符串，返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的文本为空；或者查找的字符串为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域的起始索引 <paramref name="start" /> 小于0，大于当前文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域的字符数量 <paramref name="count" /> 小于0，大于当前文本中从起始位置到索引起始位置的字符数量。</exception>
	public static int FindLast(string text, string value, int start, int count, CultureInfo culture, bool ignoreCase = false)
	{
		return FindLast(text, value, start, count, 1, culture, ignoreCase);
	}

	/// <summary>
	/// 在当前文本中的区域内逆向查找字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="value">待查找的字符串</param>
	/// <param name="start">查找区域的起始索引</param>
	/// <param name="count">查找区域中的字符数量</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="options">比较字符时使用的选项</param>
	/// <returns>指定的字符串在当前文本中出现的索引位置，如果没有找到匹配的字符串，返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的文本为空；或者查找的字符串为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域的起始索引 <paramref name="start" /> 小于0，大于当前文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域的字符数量 <paramref name="count" /> 小于0，大于当前文本中从起始位置到索引起始位置的字符数量。</exception>
	public static int FindLast(string text, string value, int start, int count, CultureInfo culture, CompareOptions options)
	{
		return FindLast(text, value, start, count, 1, culture, options);
	}

	/// <summary>
	/// 在当前文本中的区域内逆向查找出现指定次数的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="value">待查找的字符串</param>
	/// <param name="start">查找区域的起始索引</param>
	/// <param name="count">查找区域中的字符数量</param>
	/// <param name="times">查找出现指定次数的字符串</param>
	/// <param name="ignoreCase">字符串是否区分大小写</param>
	/// <returns>指定的字符串在当前文本中出现指定次数时的索引位置，如果没有找到匹配的字符串，返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的文本为空；或者查找的字符串为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域的起始索引 <paramref name="start" /> 小于0，大于当前文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域的字符数量 <paramref name="count" /> 小于0，大于当前文本中从起始位置到索引起始位置的字符数量；或者查找的次数 <paramref name="times" /> 小于1。</exception>
	public static int FindLast(string text, string value, int start, int count, int times, bool ignoreCase = false)
	{
		return FindLast(text, value, start, count, times, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
	}

	/// <summary>
	/// 在当前文本中的区域内逆向查找出现指定次数的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="value">待查找的字符串</param>
	/// <param name="start">查找区域的起始索引</param>
	/// <param name="count">查找区域中的字符数量</param>
	/// <param name="times">查找出现指定次数的字符串</param>
	/// <param name="comparison">文本比较参数</param>
	/// <returns>指定的字符串在当前文本中出现指定次数时的索引位置，如果没有找到匹配的字符串，返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的文本为空；或者查找的字符串为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域的起始索引 <paramref name="start" /> 小于0，大于当前文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域的字符数量 <paramref name="count" /> 小于0，大于当前文本中从起始位置到索引起始位置的字符数量；或者查找的次数 <paramref name="times" /> 小于1。</exception>
	public static int FindLast(string text, string value, int start, int count, int times, StringComparison comparison)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(value, "value");
		Guard.AssertBetween(start, 0, text.Length - 1, "start");
		Guard.AssertBetween(count, 0, start + 1, "count");
		Guard.AssertGreaterThanOrEqualTo(times, 1, "times");
		int end = start - count;
		int found = 0;
		int index = 0;
		while ((index = text.LastIndexOf(value, start, count, comparison)) >= 0)
		{
			if (++found >= times)
			{
				return index;
			}
			start = index - 1;
			if (start <= end)
			{
				return -1;
			}
		}
		return -1;
	}

	/// <summary>
	/// 在当前文本中的区域内逆向查找出现指定次数的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="value">待查找的字符串</param>
	/// <param name="start">查找区域的起始索引</param>
	/// <param name="count">查找区域中的字符数量</param>
	/// <param name="times">查找出现指定次数的字符串</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否使用大小写</param>
	/// <returns>指定的字符串在当前文本中出现指定次数时的索引位置，如果没有找到匹配的字符串，返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的文本为空；或者查找的字符串为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域的起始索引 <paramref name="start" /> 小于0，大于当前文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域的字符数量 <paramref name="count" /> 小于0，大于当前文本中从起始位置到索引起始位置的字符数量；或者查找的次数 <paramref name="times" /> 小于1。</exception>
	public static int FindLast(string text, string value, int start, int count, int times, CultureInfo culture, bool ignoreCase = false)
	{
		return FindLast(text, value, start, count, times, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 在当前文本中的区域内逆向查找出现指定次数的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="value">待查找的字符串</param>
	/// <param name="start">查找区域的起始索引</param>
	/// <param name="count">查找区域中的字符数量</param>
	/// <param name="times">查找出现指定次数的字符串</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="options">比较字符时使用的选项</param>
	/// <returns>指定的字符串在当前文本中出现指定次数时的索引位置，如果没有找到匹配的字符串，返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的文本为空；或者查找的字符串为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域的起始索引 <paramref name="start" /> 小于0，大于当前文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域的字符数量 <paramref name="count" /> 小于0，大于当前文本中从起始位置到索引起始位置的字符数量；或者查找的次数 <paramref name="times" /> 小于1。</exception>
	public static int FindLast(string text, string value, int start, int count, int times, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(value, "value");
		Guard.AssertBetween(start, 0, text.Length - 1, "start");
		Guard.AssertBetween(count, 0, start + 1, "count");
		Guard.AssertGreaterThanOrEqualTo(times, 1, "times");
		int end = start - count;
		int found = 0;
		int index = 0;
		while ((index = LastIndexOf(text, value, start, count, culture, options)) >= 0)
		{
			if (++found >= times)
			{
				return index;
			}
			start = index - 1;
			if (start <= end)
			{
				return -1;
			}
		}
		return -1;
	}

	/// <summary>
	/// 在当前文本中的区域内查找与指定字符相同的字符的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>指定字符的位置索引，如果未找到指定字符，返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static int FindChar(string text, char c, bool ignoreCase = false)
	{
		return FindChar(text, (char x) => IsEqualTo(x, c, CultureInfo.CurrentCulture, ignoreCase));
	}

	/// <summary>
	/// 在当前文本中的区域内查找与指定字符相同的字符的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>指定字符的位置索引，如果未找到指定字符，返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static int FindChar(string text, char c, CultureInfo culture, bool ignoreCase = false)
	{
		return FindChar(text, (char x) => IsEqualTo(x, c, culture, ignoreCase));
	}

	/// <summary>
	/// 在当前文本中的区域内查找与指定字符相同的字符的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="options">比较字符时使用的选项</param>
	/// <returns>指定字符的位置索引，如果未找到指定字符，返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static int FindChar(string text, char c, CultureInfo culture, CompareOptions options)
	{
		return FindChar(text, (char x) => IsEqualTo(x, c, culture, options));
	}

	/// <summary>
	/// 在当前文本中的区域内查找与指定字符相同的字符的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="times">字符匹配的次数</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>指定字符的位置索引，如果未找到指定字符，返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">匹配的次数 <paramref name="times" /> 小于1。</exception>
	public static int FindChar(string text, char c, int times, bool ignoreCase = false)
	{
		return FindChar(text, (char x) => IsEqualTo(x, c, CultureInfo.CurrentCulture, ignoreCase), times);
	}

	/// <summary>
	/// 在当前文本中的区域内查找与指定字符相同的字符的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="times">字符匹配的次数</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>指定字符的位置索引，如果未找到指定字符，返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">匹配的次数 <paramref name="times" /> 小于1。</exception>
	public static int FindChar(string text, char c, int times, CultureInfo culture, bool ignoreCase = false)
	{
		return FindChar(text, (char x) => IsEqualTo(x, c, culture, ignoreCase), times);
	}

	/// <summary>
	/// 在当前文本中的区域内查找与指定字符相同的字符的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="times">字符匹配的次数</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="options">比较字符时使用的选项</param>
	/// <returns>指定字符的位置索引，如果未找到指定字符，返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">匹配的次数 <paramref name="times" /> 小于1。</exception>
	public static int FindChar(string text, char c, int times, CultureInfo culture, CompareOptions options)
	{
		return FindChar(text, (char x) => IsEqualTo(x, c, culture, options), times);
	}

	/// <summary>
	/// 在当前文本中的区域内查找与指定字符相同的字符的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="start">区域的起始索引</param>
	/// <param name="count">区域内的字符数量</param>
	/// <param name="times">字符匹配的次数</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>指定字符的位置索引，如果未找到指定字符，返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域的起始索引 <paramref name="start" /> 小于0，大于当前文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域的字符数量 <paramref name="count" /> 小于0，大于当前文本中从起始位置剩余的字符的位置；或者匹配的次数 <paramref name="times" /> 小于1。</exception>
	public static int FindChar(string text, char c, int start, int count, int times, bool ignoreCase = false)
	{
		return FindChar(text, (char x) => IsEqualTo(x, c, CultureInfo.CurrentCulture, ignoreCase), start, count, times);
	}

	/// <summary>
	/// 在当前文本中的区域内查找与指定字符相同的字符的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="start">区域的起始索引</param>
	/// <param name="count">区域内的字符数量</param>
	/// <param name="times">字符匹配的次数</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>指定字符的位置索引，如果未找到指定字符，返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域的起始索引 <paramref name="start" /> 小于0，大于当前文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域的字符数量 <paramref name="count" /> 小于0，大于当前文本中从起始位置剩余的字符的位置；或者匹配的次数 <paramref name="times" /> 小于1。</exception>
	public static int FindChar(string text, char c, int start, int count, int times, CultureInfo culture, bool ignoreCase = false)
	{
		return FindChar(text, (char x) => IsEqualTo(x, c, culture, ignoreCase), start, count, times);
	}

	/// <summary>
	/// 在当前文本中的区域内查找与指定字符相同的字符的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="start">区域的起始索引</param>
	/// <param name="count">区域内的字符数量</param>
	/// <param name="times">字符匹配的次数</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="options">比较字符时使用的选项</param>
	/// <returns>指定字符的位置索引，如果未找到指定字符，返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域的起始索引 <paramref name="start" /> 小于0，大于当前文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域的字符数量 <paramref name="count" /> 小于0，大于当前文本中从起始位置剩余的字符的位置；或者匹配的次数 <paramref name="times" /> 小于1。</exception>
	public static int FindChar(string text, char c, int start, int count, int times, CultureInfo culture, CompareOptions options)
	{
		return FindChar(text, (char x) => IsEqualTo(x, c, culture, options), start, count, times);
	}

	/// <summary>
	/// 在当前文本中查找符合条件的字符的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="predicate">字符搜索条件</param>
	/// <param name="times">字符匹配的次数</param>
	/// <returns>匹配的字符索引，如果未找到则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的文本为空；或者字符筛选条件 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">匹配的次数 <paramref name="times" /> 小于1。</exception>
	public static int FindChar(string text, Func<char, bool> predicate, int times = 1)
	{
		Guard.AssertNotNull(text, "text");
		return FindChar(text, predicate, 0, text.Length, times);
	}

	/// <summary>
	/// 在当前文本中的区域内查找符合条件的字符的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="predicate">字符搜索条件</param>
	/// <param name="start">区域的起始索引</param>
	/// <param name="count">区域内的字符数量</param>
	/// <param name="times">字符匹配的次数</param>
	/// <returns>匹配的字符索引，如果未找到则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的文本为空；或者字符筛选条件 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域的起始索引 <paramref name="start" /> 小于0，大于当前文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域的字符数量 <paramref name="count" /> 小于0，大于当前文本中从起始位置剩余的字符的位置；或者匹配的次数 <paramref name="times" /> 小于1。</exception>
	public static int FindChar(string text, Func<char, bool> predicate, int start, int count, int times = 1)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertBetween(start, 0, text.Length - 1, "start");
		Guard.AssertBetween(count, 0, text.Length - start, "count");
		Guard.AssertGreaterThanOrEqualTo(times, 1, "times");
		int end = start + count;
		int found = 0;
		for (int i = start; i < end; i++)
		{
			if (predicate(text[i]) && ++found >= times)
			{
				return i;
			}
		}
		return -1;
	}

	/// <summary>
	/// 在当前文本中的区域内逆向查找与指定字符相同的字符的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>指定字符的位置索引，如果未找到指定字符，返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static int FindLastChar(string text, char c, bool ignoreCase = false)
	{
		return FindChar(text, (char x) => IsEqualTo(x, c, CultureInfo.CurrentCulture, ignoreCase));
	}

	/// <summary>
	/// 在当前文本中的区域内逆向查找与指定字符相同的字符的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>指定字符的位置索引，如果未找到指定字符，返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static int FindLastChar(string text, char c, CultureInfo culture, bool ignoreCase = false)
	{
		return FindChar(text, (char x) => IsEqualTo(x, c, culture, ignoreCase));
	}

	/// <summary>
	/// 在当前文本中的区域内逆向查找与指定字符相同的字符的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="options">比较字符时使用的选项</param>
	/// <returns>指定字符的位置索引，如果未找到指定字符，返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static int FindLastChar(string text, char c, CultureInfo culture, CompareOptions options)
	{
		return FindChar(text, (char x) => IsEqualTo(x, c, culture, options));
	}

	/// <summary>
	/// 在当前文本中的区域内逆向查找与指定字符相同的字符的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="times">字符匹配的次数</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>指定字符的位置索引，如果未找到指定字符，返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">匹配的次数 <paramref name="times" /> 小于1。</exception>
	public static int FindLastChar(string text, char c, int times, bool ignoreCase = false)
	{
		return FindChar(text, (char x) => IsEqualTo(x, c, CultureInfo.CurrentCulture, ignoreCase), times);
	}

	/// <summary>
	/// 在当前文本中的区域内逆向查找与指定字符相同的字符的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="times">字符匹配的次数</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>指定字符的位置索引，如果未找到指定字符，返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">匹配的次数 <paramref name="times" /> 小于1。</exception>
	public static int FindLastChar(string text, char c, int times, CultureInfo culture, bool ignoreCase = false)
	{
		return FindChar(text, (char x) => IsEqualTo(x, c, culture, ignoreCase), times);
	}

	/// <summary>
	/// 在当前文本中的区域内逆向查找与指定字符相同的字符的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="times">字符匹配的次数</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="options">比较字符时使用的选项</param>
	/// <returns>指定字符的位置索引，如果未找到指定字符，返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">匹配的次数 <paramref name="times" /> 小于1。</exception>
	public static int FindLastChar(string text, char c, int times, CultureInfo culture, CompareOptions options)
	{
		return FindChar(text, (char x) => IsEqualTo(x, c, culture, options), times);
	}

	/// <summary>
	/// 在当前文本中的区域内逆向查找与指定字符相同的字符的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="start">区域的起始索引</param>
	/// <param name="count">区域内的字符数量</param>
	/// <param name="times">字符匹配的次数</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>指定字符的位置索引，如果未找到指定字符，返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域的起始索引 <paramref name="start" /> 小于0，大于当前文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域的字符数量 <paramref name="count" /> 小于0，大于当前文本中从起始位置逆向剩余的字符的位置；或者匹配的次数 <paramref name="times" /> 小于1。</exception>
	public static int FindLastChar(string text, char c, int start, int count, int times, bool ignoreCase = false)
	{
		return FindChar(text, (char x) => IsEqualTo(x, c, CultureInfo.CurrentCulture, ignoreCase), start, count, times);
	}

	/// <summary>
	/// 在当前文本中的区域内逆向查找与指定字符相同的字符的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="start">区域的起始索引</param>
	/// <param name="count">区域内的字符数量</param>
	/// <param name="times">字符匹配的次数</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>指定字符的位置索引，如果未找到指定字符，返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域的起始索引 <paramref name="start" /> 小于0，大于当前文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域的字符数量 <paramref name="count" /> 小于0，大于当前文本中从起始位置逆向剩余的字符的位置；或者匹配的次数 <paramref name="times" /> 小于1。</exception>
	public static int FindLastChar(string text, char c, int start, int count, int times, CultureInfo culture, bool ignoreCase = false)
	{
		return FindChar(text, (char x) => IsEqualTo(x, c, culture, ignoreCase), start, count, times);
	}

	/// <summary>
	/// 在当前文本中的区域内逆向查找与指定字符相同的字符的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="start">区域的起始索引</param>
	/// <param name="count">区域内的字符数量</param>
	/// <param name="times">字符匹配的次数</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="options">比较字符时使用的选项</param>
	/// <returns>指定字符的位置索引，如果未找到指定字符，返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域的起始索引 <paramref name="start" /> 小于0，大于当前文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域的字符数量 <paramref name="count" /> 小于0，大于当前文本中从起始位置逆向剩余的字符的位置；或者匹配的次数 <paramref name="times" /> 小于1。</exception>
	public static int FindLastChar(string text, char c, int start, int count, int times, CultureInfo culture, CompareOptions options)
	{
		return FindChar(text, (char x) => IsEqualTo(x, c, culture, options), start, count, times);
	}

	/// <summary>
	/// 在当前文本中逆向查找符合条件的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="predicate">字符搜索条件</param>
	/// <param name="times">字符匹配的次数</param>
	/// <returns>匹配的字符索引，如果未找到则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的文本为空；或者字符筛选条件 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">匹配的次数 <paramref name="times" /> 小于1。</exception>
	public static int FindLastChar(string text, Func<char, bool> predicate, int times = 1)
	{
		Guard.AssertNotNull(text, "text");
		return FindLastChar(text, predicate, text.Length - 1, text.Length, times);
	}

	/// <summary>
	/// 在当前文本的区域中逆向查找符合条件的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="predicate">字符搜索条件</param>
	/// <param name="start">区域的起始索引</param>
	/// <param name="count">区域内的字符数量</param>
	/// <param name="times">字符匹配的次数</param>
	/// <returns>匹配的字符索引，如果未找到则返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的文本为空；或者字符筛选条件 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域的起始索引 <paramref name="start" /> 小于0，大于当前文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域的字符数量 <paramref name="count" /> 小于0，大于当前文本中从起始位置逆向剩余的字符的位置；或者匹配的次数 <paramref name="times" /> 小于1。</exception>
	public static int FindLastChar(string text, Func<char, bool> predicate, int start, int count, int times = 1)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertBetween(start, 0, text.Length - 1, "start");
		Guard.AssertBetween(count, 0, start + 1, "count");
		Guard.AssertGreaterThanOrEqualTo(times, 1, "times");
		int end = start - count;
		int found = 0;
		for (int i = start; i > end; i--)
		{
			if (predicate(text[i]) && ++found >= times)
			{
				return i;
			}
		}
		return -1;
	}

	/// <summary>
	/// 在当前文本中查找与指定模式匹配的字符串的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">查找的正则模式</param>
	/// <param name="options">正则模式参数</param>
	/// <returns>查找到的匹配文本的索引，未找到返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者查找的正则模式 <paramref name="pattern" /> 为空。</exception>
	public static int FindRegex(string text, string pattern, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return FindRegex(text, ConvertHelper.ToRegex(pattern, EnumHelper.EnsureLeftToRightOption(options)));
	}

	/// <summary>
	/// 在当前文本中查找与指定模式匹配的字符串的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">查找的正则模式</param>
	/// <param name="times">查找在指定次数匹配时的文本</param>
	/// <param name="options">正则模式参数</param>
	/// <returns>查找到的匹配文本的索引，未找到返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者查找的正则模式 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">匹配的次数 <paramref name="times" /> 小于1。</exception>
	public static int FindRegex(string text, string pattern, int times, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return FindRegex(text, ConvertHelper.ToRegex(pattern, EnumHelper.EnsureLeftToRightOption(options)), times);
	}

	/// <summary>
	/// 在当前文本的区域中查找与指定模式匹配的字符串的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">查找的正则模式</param>
	/// <param name="start">文本区域的起始索引</param>
	/// <param name="count">文本区域的字符个数</param>
	/// <param name="options">正则模式参数</param>
	/// <returns>查找到的匹配文本的索引，未找到返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者查找的正则模式 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域的起始索引 <paramref name="start" /> 小于0，大于当前文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域的字符数量 <paramref name="count" /> 小于0，大于当前文本中从起始位置到索引起始位置的字符数量。</exception>
	public static int FindRegex(string text, string pattern, int start, int count, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return FindRegex(text, ConvertHelper.ToRegex(pattern, EnumHelper.EnsureLeftToRightOption(options)), start, count);
	}

	/// <summary>
	/// 在当前文本的区域中查找与指定模式匹配的字符串的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">查找的正则模式</param>
	/// <param name="start">文本区域的起始索引</param>
	/// <param name="count">文本区域的字符个数</param>
	/// <param name="times">查找在指定次数匹配时的文本</param>
	/// <param name="options">正则模式参数</param>
	/// <returns>查找到的匹配文本的索引，未找到返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者查找的正则模式 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域的起始索引 <paramref name="start" /> 小于0，大于当前文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域的字符数量 <paramref name="count" /> 小于0，大于当前文本中从起始位置到索引起始位置的字符数量；或者匹配的次数 <paramref name="times" /> 小于1。</exception>
	public static int FindRegex(string text, string pattern, int start, int count, int times, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return FindRegex(text, ConvertHelper.ToRegex(pattern, EnumHelper.EnsureLeftToRightOption(options)), start, count, times);
	}

	/// <summary>
	/// 在当前文本中查找与指定模式匹配的字符串的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">查找的正则模式</param>
	/// <param name="times">查找在指定次数匹配时的文本</param>
	/// <returns>查找到的匹配文本的索引，未找到返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者查找的正则模式 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">匹配的次数 <paramref name="times" /> 小于1。</exception>
	public static int FindRegex(string text, Regex pattern, int times = 1)
	{
		Match match = GetMatch(pattern, text, times);
		return ObjectHelper.IsNull(match) ? (-1) : match.Index;
	}

	/// <summary>
	/// 在当前文本的区域中查找与指定模式匹配的字符串的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">查找的正则模式</param>
	/// <param name="start">文本区域的起始索引</param>
	/// <param name="count">文本区域的字符个数</param>
	/// <param name="times">查找在指定次数匹配时的文本</param>
	/// <returns>查找到的匹配文本的索引，未找到返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者查找的正则模式 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域的起始索引 <paramref name="start" /> 小于0，大于当前文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域的字符数量 <paramref name="count" /> 小于0，大于当前文本中从起始位置到索引起始位置的字符数量；或者匹配的次数 <paramref name="times" /> 小于1。</exception>
	public static int FindRegex(string text, Regex pattern, int start, int count, int times = 1)
	{
		Match match = GetMatch(pattern, text, start, count, times);
		return ObjectHelper.IsNull(match) ? (-1) : match.Index;
	}

	/// <summary>
	/// 在当前文本中逆向查找与指定模式匹配的字符串的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">查找的正则模式</param>
	/// <param name="options">正则模式匹配参数</param>
	/// <returns>查找到的匹配文本的索引，未找到返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者查找的正则模式 <paramref name="pattern" /> 为空。</exception>
	public static int FindLastRegex(string text, string pattern, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return FindLastRegex(text, ConvertHelper.ToRegex(pattern, EnumHelper.EnsureRightToLeftOption(options)));
	}

	/// <summary>
	/// 在当前文本中逆向查找与指定模式匹配的字符串的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">查找的正则模式</param>
	/// <param name="times">查找在指定次数匹配时的文本</param>
	/// <param name="options">正则模式匹配参数</param>
	/// <returns>查找到的匹配文本的索引，未找到返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者查找的正则模式 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">匹配的次数 <paramref name="times" /> 小于1。</exception>
	public static int FindLastRegex(string text, string pattern, int times, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return FindLastRegex(text, ConvertHelper.ToRegex(pattern, EnumHelper.EnsureRightToLeftOption(options)), times);
	}

	/// <summary>
	/// 在当前文本的区域中逆向查找与指定模式匹配的字符串的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">查找的正则模式</param>
	/// <param name="start">文本区域的起始索引</param>
	/// <param name="count">文本区域的字符个数</param>
	/// <param name="options">正则模式匹配参数</param>
	/// <returns>查找到的匹配文本的索引，未找到返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者查找的正则模式 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域的起始索引 <paramref name="start" /> 小于0，大于当前文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域的字符数量 <paramref name="count" /> 小于0，大于当前文本中从起始位置到索引起始位置的字符数量。</exception>
	public static int FindLastRegex(string text, string pattern, int start, int count, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return FindLastRegex(text, ConvertHelper.ToRegex(pattern, EnumHelper.EnsureRightToLeftOption(options)), start, count);
	}

	/// <summary>
	/// 在当前文本的区域中逆向查找与指定模式匹配的字符串的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">查找的正则模式</param>
	/// <param name="start">文本区域的起始索引</param>
	/// <param name="count">文本区域的字符个数</param>
	/// <param name="times">查找在指定次数匹配时的文本</param>
	/// <param name="options">正则模式匹配参数</param>
	/// <returns>查找到的匹配文本的索引，未找到返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者查找的正则模式 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域的起始索引 <paramref name="start" /> 小于0，大于当前文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域的字符数量 <paramref name="count" /> 小于0，大于当前文本中从起始位置到索引起始位置的字符数量；或者匹配的次数 <paramref name="times" /> 小于1。</exception>
	public static int FindLastRegex(string text, string pattern, int start, int count, int times, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return FindLastRegex(text, ConvertHelper.ToRegex(pattern, EnumHelper.EnsureRightToLeftOption(options)), start, count, times);
	}

	/// <summary>
	/// 在当前文本中逆向查找与指定模式匹配的字符串的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">查找的正则模式</param>
	/// <param name="times">查找在指定次数匹配时的文本</param>
	/// <returns>查找到的匹配文本的索引，未找到返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者查找的正则模式 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">匹配的次数 <paramref name="times" /> 小于1。</exception>
	public static int FindLastRegex(string text, Regex pattern, int times = 1)
	{
		Match match = GetLastMatch(pattern, text, times);
		return ObjectHelper.IsNull(match) ? (-1) : match.Index;
	}

	/// <summary>
	/// 在当前文本的区域中逆向查找与指定模式匹配的字符串的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">查找的正则模式</param>
	/// <param name="start">文本区域的起始索引</param>
	/// <param name="count">文本区域的字符个数</param>
	/// <param name="times">查找在指定次数匹配时的文本</param>
	/// <returns>查找到的匹配文本的索引，未找到返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者查找的正则模式 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域的起始索引 <paramref name="start" /> 小于0，大于当前文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域的字符数量 <paramref name="count" /> 小于0，大于当前文本中从起始位置到索引起始位置的字符数量；或者匹配的次数 <paramref name="times" /> 小于1。</exception>
	public static int FindLastRegex(string text, Regex pattern, int start, int count, int times = 1)
	{
		Match match = GetLastMatch(pattern, text, start, count, times);
		return ObjectHelper.IsNull(match) ? (-1) : match.Index;
	}

	/// <summary>
	/// 根据指定格式，格式化当前字符串
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="format">输出的字符格式</param>
	/// <param name="digitChar">数字标识符，默认为'#'，表示一个数字字符</param>
	/// <param name="alphaChar">字母标识符，默认为'@'，表示一个字母字符</param>
	/// <param name="escapeChar">转移标识符，默认为'\'，表示其后的一个字符为转移字符</param>
	/// <returns>格式化后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者格式化字符串 <paramref name="format" /> 为空。</exception>
	public static string FormatText(string s, string format, char digitChar = '#', char alphaChar = '@', char escapeChar = '\\')
	{
		Guard.AssertNotNull(s, "s");
		Guard.AssertNotNull(format, "format");
		Guard.Assert(format, delegate
		{
			bool flag = false;
			for (int i = 0; i < format.Length; i++)
			{
				if (flag && format[i] != digitChar && format[i] != alphaChar && format[i] != escapeChar)
				{
					return false;
				}
				if (flag)
				{
					flag = false;
				}
				else if (format[i] == escapeChar)
				{
					flag = true;
				}
			}
			return (!flag) ? true : false;
		}, "format");
		StringBuilder buff = new StringBuilder();
		int start = 0;
		for (int x = 0; x < format.Length; x++)
		{
			if (format[x] == escapeChar)
			{
				x++;
				buff.Append(format[x]);
				continue;
			}
			if (format[x] != digitChar && format[x] != alphaChar)
			{
				buff.Append(format[x]);
				continue;
			}
			for (int y = start; y < s.Length; y++)
			{
				if ((format[x] == digitChar && char.IsDigit(s[y])) || (format[x] == alphaChar && char.IsLetter(s[y])))
				{
					buff.Append(s[y]);
					start = y + 1;
					break;
				}
			}
		}
		return buff.ToString();
	}

	/// <summary>
	/// 按照当前格式化字符串，格式化指定的参数值；如果给定的参数值为空，则使用 <see cref="F:System.String.Empty" /> 替换。
	/// </summary>
	/// <param name="format">当前格式化字符串</param>
	/// <param name="args">格式化的参数值数组</param>
	/// <returns>格式化的参数值字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前格式化字符串为空；或者格式化参数值数组 <paramref name="args" /> 为空。</exception>
	public static string FormatValue(string format, params object[] args)
	{
		Guard.AssertNotNull(format, "format");
		Guard.AssertNotNull(args, "formatting arguments");
		for (int i = 0; i < args.Length; i++)
		{
			if (ObjectHelper.IsNull(args[i]))
			{
				args[i] = string.Empty;
			}
		}
		return string.Format(format, args);
	}

	/// <summary>
	/// 使用936代码页(GB2312)编码把当前字节数据解码为字符串
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <returns>解码后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	public static string GB2312Decode(byte[] data)
	{
		return TextDecode(data, Encoding.GetEncoding(936));
	}

	/// <summary>
	/// 使用936代码页(GB2312)编码把当前字节数据解码为字符串
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <param name="start">开始转换的字节索引位置</param>
	/// <param name="count">转换的字节数量</param>
	/// <returns>解码后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出了当前字节数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的字节数量。</exception>
	public static string GB2312Decode(byte[] data, int start, int count)
	{
		return TextDecode(data, start, count, Encoding.GetEncoding(936));
	}

	/// <summary>
	/// 使用936代码页(GB2312)编码把当前字节序列解码为字符串
	/// </summary>
	/// <param name="data">当前字节序列</param>
	/// <returns>解码后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空。</exception>
	public static string GB2312Decode(IEnumerable<byte> data)
	{
		return TextDecode(data, Encoding.GetEncoding(936));
	}

	/// <summary>
	/// 将当前字符按GB2312编码（代码页936），编码为字节数据
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>编码生成的字节数据</returns>
	public static byte[] GB2312Encode(char c)
	{
		return TextEncode(c, Encoding.GetEncoding(936));
	}

	/// <summary>
	/// 将当前字符数组按GB2312编码（代码页936），编码为字节数据
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <returns>编码生成的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static byte[] GB2312Encode(char[] cs)
	{
		return TextEncode(cs, Encoding.GetEncoding(936));
	}

	/// <summary>
	/// 将当前字符数组按GB2312编码（代码页936），编码为字节数据
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <param name="start">开始转换的字符索引位置</param>
	/// <param name="count">转换的字符数量</param>
	/// <returns>编码生成的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出了当前字符数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的字符数量。</exception>
	public static byte[] GB2312Encode(char[] cs, int start, int count)
	{
		return TextEncode(cs, start, count, Encoding.GetEncoding(936));
	}

	/// <summary>
	/// 将当前字符序列按GB2312编码（代码页936），编码为的字节数据
	/// </summary>
	/// <param name="cs">当前字符序列</param>
	/// <returns>编码生成的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static byte[] GB2312Encode(IEnumerable<char> cs)
	{
		return TextEncode(cs, Encoding.GetEncoding(936));
	}

	/// <summary>
	/// 使用GB2312编码（代码页936）对当前文本进行编码，返回编码后的字节数据
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <returns>编码生成的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static byte[] GB2312Encode(string text)
	{
		return TextEncode(text, Encoding.GetEncoding(936));
	}

	/// <summary>
	/// 使用GB2312编码（代码页936）对当前文本进行编码，返回编码后的字节数据
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="start">开始编码的字符索引位置</param>
	/// <param name="count">编码的字符数量</param>
	/// <returns>编码生成的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">起始索引位置 <paramref name="start" /> 超出了当前文本中字符的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">字符数量 <paramref name="count" /> 小于0，或者大于从起始索引位置 <paramref name="start" /> 起字符串中剩余的字符数量。</exception>
	public static byte[] GB2312Encode(string text, int start, int count)
	{
		return TextEncode(text, start, count, Encoding.GetEncoding(936));
	}

	/// <summary>
	/// 获取当前路径字符串中的目录的信息对象
	/// </summary>
	/// <param name="path">当前路径字符串</param>
	/// <returns>返回当前路径字符串中的目录的信息对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前路径字符串为空。</exception>
	/// <remarks>本方法返回当前路径字符串中最后一个路径分隔符之前的目录信息对象。</remarks>
	public static DirectoryInfo GetDirectory(string path)
	{
		return new DirectoryInfo(GetDirectoryName(path));
	}

	/// <summary>
	/// 获取当前路径字符串中的目录路径
	/// </summary>
	/// <param name="path">当前路径字符串</param>
	/// <returns>返回当前路径字符串中的目录路径</returns>
	/// <exception cref="T:System.ArgumentNullException">当前路径字符串为空。</exception>
	/// <remarks>本方法返回当前路径字符串中最后一个路径分隔符之前的目录路径。</remarks>
	public static string GetDirectoryName(string path)
	{
		Guard.AssertNotNull(path, "path");
		return (path.Length == 0) ? string.Empty : Path.GetDirectoryName(path);
	}

	/// <summary>
	/// 获取当前路径字符串中包含的扩展名，获取的扩展名不包含句点。
	/// </summary>
	/// <param name="path">当前路径字符串</param>
	/// <returns>当前路径字符串中包含的扩展名；如果没有扩展名返回空串。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前路径字符串为空。</exception>
	public static string GetExtension(string path)
	{
		Guard.AssertNotNull(path, "path");
		string extension = Path.GetExtension(path);
		return ObjectHelper.IfNull(extension, string.Empty).Trim('.');
	}

	/// <summary>
	/// 获取当前路径字符串中的文件名称，包括扩展名
	/// </summary>
	/// <param name="path">当前路径字符串</param>
	/// <returns>当前路径字符串中包含的文件名</returns>
	/// <exception cref="T:System.ArgumentNullException">当前路径字符串为空。</exception>
	public static string GetFileName(string path)
	{
		Guard.AssertNotNull(path, "path");
		return Path.GetFileName(path);
	}

	/// <summary>
	/// 获取当前路径字符串中的文件名称，不包含扩展名
	/// </summary>
	/// <param name="path">当前路径字符串</param>
	/// <returns>当前路径字符串中包含的文件名，不包含扩展名</returns>
	/// <exception cref="T:System.ArgumentNullException">当前路径字符串为空。</exception>
	public static string GetFileNameWithoutExtension(string path)
	{
		Guard.AssertNotNull(path, "path");
		return Path.GetFileNameWithoutExtension(path);
	}

	/// <summary>
	/// 获取当前路径字符串的完整路径（绝对路径）
	/// </summary>
	/// <param name="path">当前路径字符串</param>
	/// <returns>当前路径字符串的完整路径（绝对路径）</returns>
	/// <exception cref="T:System.ArgumentNullException">当前路径字符串为空。</exception>
	public static string GetFullPath(string path)
	{
		Guard.AssertNotNull(path, "path");
		return Path.GetFullPath(path);
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
	public static Match GetLastMatch(Regex regex, string text, int times = 1)
	{
		Guard.AssertNotNull(text, "text");
		if (times == 1)
		{
			regex = EnsureRightToLeftOption(regex);
			return regex.Match(text);
		}
		return GetLastMatch(regex, text, text.Length - 1, text.Length, times);
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
	public static Match GetLastMatch(Regex regex, string text, int start, int count, int times = 1)
	{
		Guard.AssertNotNull(regex, "regex");
		Guard.AssertNotNull(text, "text");
		Guard.AssertIndexRange(start, 0, text.Length - 1, "start");
		Guard.AssertBetween(count, 0, start + 1, "count");
		Guard.AssertGreaterThanOrEqualTo(times, 1, "times");
		regex = EnsureRightToLeftOption(regex);
		int end = start - count;
		int matched = 0;
		return regex.Matches(text, start).OfType<Match>().FirstOrDefault((Match m) => m.Success && end < m.Index && m.Index <= start && m.Index + m.Length - 1 <= start && ++matched <= times);
	}

	/// <summary>
	/// 逆向获取在当前文本中与给定正则模式匹配的匹配项目
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">匹配的正则模式</param>
	/// <param name="options">正则模式参数</param>
	/// <returns>匹配项目数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者匹配的正则模式 <paramref name="pattern" /> 为空。</exception>
	public static Match[] GetLastMatches(string text, string pattern, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return GetMatches(ConvertHelper.ToRegex(pattern, EnumHelper.EnsureRightToLeftOption(options)), text);
	}

	/// <summary>
	/// 逆向获取在当前文本的指定位置开始与给定正则模式匹配的匹配项目
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">匹配的正则模式</param>
	/// <param name="start">匹配的起始位置</param>
	/// <param name="options">正则模式参数</param>
	/// <returns>匹配项目数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者匹配的正则模式 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">匹配的起始位置小于0，或者大于当前文本字符的最大索引。</exception>
	public static Match[] GetLastMatches(string text, string pattern, int start, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return GetMatches(ConvertHelper.ToRegex(pattern, EnumHelper.EnsureRightToLeftOption(options)), text, start);
	}

	/// <summary>
	/// 逆向获取在当前文本的区域内与给定正则模式匹配的匹配项目
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">匹配的正则模式</param>
	/// <param name="start">匹配区域的起始位置</param>
	/// <param name="count">匹配区域中字符的个数</param>
	/// <param name="options">正则模式参数</param>
	/// <returns>匹配项目数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者匹配的正则模式 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域中的字符数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始剩余的字符数量。</exception>
	public static Match[] GetLastMatches(string text, string pattern, int start, int count, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return GetMatches(ConvertHelper.ToRegex(pattern, EnumHelper.EnsureRightToLeftOption(options)), text, start, count);
	}

	/// <summary>
	/// 逆向获取在当前文本中与给定正则模式匹配的匹配项目
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">匹配的正则模式</param>
	/// <returns>匹配项目数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者匹配的正则模式 <paramref name="pattern" /> 为空。</exception>
	public static Match[] GetLastMatches(string text, Regex pattern)
	{
		return GetLastMatches(pattern, text);
	}

	/// <summary>
	/// 逆向获取在当前文本的指定位置开始与给定正则模式匹配的匹配项目
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">匹配的正则模式</param>
	/// <param name="start">匹配的起始位置</param>
	/// <returns>匹配项目数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者匹配的正则模式 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">匹配的起始位置小于0，或者大于当前文本字符的最大索引。</exception>
	public static Match[] GetLastMatches(string text, Regex pattern, int start)
	{
		return GetLastMatches(pattern, text, start);
	}

	/// <summary>
	/// 逆向获取在当前文本的区域内与给定正则模式匹配的匹配项目
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">匹配的正则模式</param>
	/// <param name="start">匹配区域的起始位置</param>
	/// <param name="count">匹配区域中字符的个数</param>
	/// <returns>匹配项目数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者匹配的正则模式 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域中的字符数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始剩余的字符数量。</exception>
	public static Match[] GetLastMatches(string text, Regex pattern, int start, int count)
	{
		return GetLastMatches(pattern, text, start, count);
	}

	/// <summary>
	/// 逆向获取在当前文本中与指定的正则模式匹配的满足条件的匹配项目
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">匹配的正则模式</param>
	/// <param name="predicate">匹配项目筛选方法</param>
	/// <returns>筛选后的匹配数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者匹配的正则模式 <paramref name="pattern" /> 为空；或者匹配筛选方法 <paramref name="predicate" /> 为空。</exception>
	public static Match[] GetLastMatches(string text, Regex pattern, Func<Match, bool> predicate)
	{
		return GetLastMatches(pattern, text, predicate);
	}

	/// <summary>
	/// 逆向获取在当前文本中与指定的正则模式匹配的满足条件的匹配项目
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">匹配的正则模式</param>
	/// <param name="predicate">匹配项目筛选方法</param>
	/// <returns>筛选后的匹配数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者匹配的正则模式 <paramref name="pattern" /> 为空；或者匹配筛选方法 <paramref name="predicate" /> 为空。</exception>
	public static Match[] GetLastMatches(string text, Regex pattern, Func<Match, int, bool> predicate)
	{
		return GetLastMatches(pattern, text, predicate);
	}

	/// <summary>
	/// 获取当前匹配模式在输入文本中逆向匹配的项目
	/// </summary>
	/// <param name="regex">当前正则模式</param>
	/// <param name="text">输入文本</param>
	/// <returns>符合条件的匹配项</returns>
	/// <exception cref="T:System.ArgumentNullException">当前正则模式为空；或者输入文本 <paramref name="text" /> 为空。</exception>
	public static Match[] GetLastMatches(Regex regex, string text)
	{
		Guard.AssertNotNull(text, "text");
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
	public static Match[] GetLastMatches(Regex regex, string text, int start)
	{
		Guard.AssertNotNull(text, "text");
		return GetLastMatches(regex, text, start, start + 1);
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
	public static Match[] GetLastMatches(Regex regex, string text, int start, int count)
	{
		Guard.AssertNotNull(regex, "regex");
		Guard.AssertNotNull(text, "text");
		Guard.AssertIndexRange(start, 0, text.Length - 1, "start");
		Guard.AssertBetween(count, 0, start + 1, "count");
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
	public static Match[] GetLastMatches(Regex regex, string text, Func<Match, bool> predicate)
	{
		Guard.AssertNotNull(regex, "regex");
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(predicate, "predicate");
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
	public static Match[] GetLastMatches(Regex regex, string text, Func<Match, int, bool> predicate)
	{
		Guard.AssertNotNull(regex, "regex");
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(predicate, "predicate");
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
	public static Match GetMatch(Regex regex, string text, int times = 1)
	{
		Guard.AssertNotNull(text, "text");
		if (times == 1)
		{
			regex = EnsureLeftToRightOption(regex);
			return regex.Match(text);
		}
		return GetMatch(regex, text, 0, text.Length, times);
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
	public static Match GetMatch(Regex regex, string text, int start, int count, int times = 1)
	{
		Guard.AssertNotNull(regex, "regex");
		Guard.AssertNotNull(text, "text");
		Guard.AssertIndexRange(start, 0, text.Length - 1, "start");
		Guard.AssertBetween(count, 0, text.Length - start, "count");
		Guard.AssertGreaterThanOrEqualTo(times, 1, "times");
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
	public static Match[] GetMatches(Regex regex, string text)
	{
		Guard.AssertNotNull(text, "text");
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
	public static Match[] GetMatches(Regex regex, string text, int start)
	{
		Guard.AssertNotNull(text, "text");
		return GetMatches(regex, text, start, text.Length - start);
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
	public static Match[] GetMatches(Regex regex, string text, int start, int count)
	{
		Guard.AssertNotNull(regex, "regex");
		Guard.AssertNotNull(text, "text");
		Guard.AssertIndexRange(start, 0, text.Length - 1, "start");
		Guard.AssertBetween(count, 0, text.Length - start, "count");
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
	public static Match[] GetMatches(Regex regex, string text, Func<Match, bool> predicate)
	{
		Guard.AssertNotNull(regex, "regex");
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(predicate, "predicate");
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
	public static Match[] GetMatches(Regex regex, string text, Func<Match, int, bool> predicate)
	{
		Guard.AssertNotNull(regex, "regex");
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(predicate, "predicate");
		regex = EnsureLeftToRightOption(regex);
		return regex.Matches(text).OfType<Match>().Where(predicate)
			.ToArray();
	}

	/// <summary>
	/// 获取在当前文本中与给定正则模式匹配的匹配项目
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">匹配的正则模式</param>
	/// <param name="options">正则模式参数</param>
	/// <returns>匹配项目数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者匹配的正则模式 <paramref name="pattern" /> 为空。</exception>
	public static Match[] GetMatches(string text, string pattern, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return GetMatches(ConvertHelper.ToRegex(pattern, EnumHelper.EnsureLeftToRightOption(options)), text);
	}

	/// <summary>
	/// 获取在当前文本的指定位置开始与给定正则模式匹配的匹配项目
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">匹配的正则模式</param>
	/// <param name="start">匹配的起始位置</param>
	/// <param name="options">正则模式参数</param>
	/// <returns>匹配项目数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者匹配的正则模式 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">匹配的起始位置小于0，或者大于当前文本字符的最大索引。</exception>
	public static Match[] GetMatches(string text, string pattern, int start, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return GetMatches(ConvertHelper.ToRegex(pattern, EnumHelper.EnsureLeftToRightOption(options)), text, start);
	}

	/// <summary>
	/// 获取在当前文本的区域内与给定正则模式匹配的匹配项目
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">匹配的正则模式</param>
	/// <param name="start">匹配区域的起始位置</param>
	/// <param name="count">匹配区域中字符的个数</param>
	/// <param name="options">正则模式参数</param>
	/// <returns>匹配项目数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者匹配的正则模式 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域中的字符数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始剩余的字符数量。</exception>
	public static Match[] GetMatches(string text, string pattern, int start, int count, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return GetMatches(ConvertHelper.ToRegex(pattern, EnumHelper.EnsureLeftToRightOption(options)), text, start, count);
	}

	/// <summary>
	/// 获取在当前文本中与给定正则模式匹配的匹配项目
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">匹配的正则模式</param>
	/// <returns>匹配项目数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者匹配的正则模式 <paramref name="pattern" /> 为空。</exception>
	public static Match[] GetMatches(string text, Regex pattern)
	{
		return GetMatches(pattern, text);
	}

	/// <summary>
	/// 获取在当前文本的指定位置开始与给定正则模式匹配的匹配项目
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">匹配的正则模式</param>
	/// <param name="start">匹配的起始位置</param>
	/// <returns>匹配项目数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者匹配的正则模式 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">匹配的起始位置小于0，或者大于当前文本字符的最大索引。</exception>
	public static Match[] GetMatches(string text, Regex pattern, int start)
	{
		return GetMatches(pattern, text, start);
	}

	/// <summary>
	/// 获取在当前文本的区域内与给定正则模式匹配的匹配项目
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">匹配的正则模式</param>
	/// <param name="start">匹配区域的起始位置</param>
	/// <param name="count">匹配区域中字符的个数</param>
	/// <returns>匹配项目数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者匹配的正则模式 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域中的字符数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始剩余的字符数量。</exception>
	public static Match[] GetMatches(string text, Regex pattern, int start, int count)
	{
		return GetMatches(pattern, text, start, count);
	}

	/// <summary>
	/// 获取在当前文本中与指定的正则模式匹配的满足条件的匹配项目
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">匹配的正则模式</param>
	/// <param name="predicate">匹配项目筛选方法</param>
	/// <returns>筛选后的匹配数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者匹配的正则模式 <paramref name="pattern" /> 为空；或者匹配筛选方法 <paramref name="predicate" /> 为空。</exception>
	public static Match[] GetMatches(string text, Regex pattern, Func<Match, bool> predicate)
	{
		return GetMatches(pattern, text, predicate);
	}

	/// <summary>
	/// 获取在当前文本中与指定的正则模式匹配的满足条件的匹配项目
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">匹配的正则模式</param>
	/// <param name="predicate">匹配项目筛选方法</param>
	/// <returns>筛选后的匹配数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者匹配的正则模式 <paramref name="pattern" /> 为空；或者匹配筛选方法 <paramref name="predicate" /> 为空。</exception>
	public static Match[] GetMatches(string text, Regex pattern, Func<Match, int, bool> predicate)
	{
		return GetMatches(pattern, text, predicate);
	}

	/// <summary>
	/// 获取当前字符所在的标识组
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>当前字符所在的标识组</returns>
	public static UnicodeCategory GetUnicodeCategory(char c)
	{
		return char.GetUnicodeCategory(c);
	}

	/// <summary>
	/// 获取当前匹配模式与输入文本的完整匹配项
	/// </summary>
	/// <param name="regex">当前正则模式</param>
	/// <param name="text">输入文本</param>
	/// <returns>如果当前匹配模式无法与输入文本完整匹配则返回空， 否则返回完整匹配项。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前正则模式为空；或者输入文本 <paramref name="text" /> 为空。</exception>
	public static Match GetWholeMatch(Regex regex, string text)
	{
		Guard.AssertNotNull(regex, "regex");
		Guard.AssertNotNull(text, "text");
		return GetMatches(regex, text).FirstOrDefault((Match m) => m.Success && m.Index == 0 && m.Length == text.Length);
	}

	/// <summary>
	/// 将当前HTML编码的文本解码为普通文本
	/// </summary>
	/// <param name="html">当前HTML编码的文本</param>
	/// <returns>解码后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前HTML文本为空。</exception>
	public static string HtmlDecode(string html)
	{
		Guard.AssertNotNull(html, "html-encoded text");
		return HttpUtility.HtmlDecode(html);
	}

	/// <summary>
	/// 将当前文本转换为HTML编码的文本
	/// </summary>
	/// <param name="text">当前待编码的文本</param>
	/// <returns>编码后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前待编码的文本为空。</exception>
	public static string HtmlEncode(string text)
	{
		Guard.AssertNotNull(text, "text");
		return HttpUtility.HtmlEncode(text);
	}

	/// <summary>
	/// 如果当前字符串为空或者空串，返回指定替代字符串，否则返回当前字符串
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="value">用于替换的字符串</param>
	/// <returns>当前字符串或者替换的字符串</returns>
	public static string IfNullOrEmpty(string s, string value)
	{
		return string.IsNullOrEmpty(s) ? value : s;
	}

	/// <summary>
	/// 如果当前字符串为空或者空串返回 <paramref name="evaluation" /> 生成的字符串，否则返回当前字符串。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="evaluation">用于生成替代字符串的方法</param>
	/// <returns>当前字符串或者生成的替代字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">替代字符串生成方法 <paramref name="evaluation" /> 为空。</exception>
	public static string IfNullOrEmptyThen(string s, Func<string> evaluation)
	{
		Guard.AssertNotNull(evaluation, "evaluation");
		return string.IsNullOrEmpty(s) ? evaluation() : s;
	}

	/// <summary>
	/// 如果当前字符串为空或者空串，执行指定的处理方法 <paramref name="action" />。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="action">处理方法</param>
	/// <exception cref="T:System.ArgumentNullException">替代处理方法 <paramref name="action" /> 为空。</exception>
	public static void IfNullOrEmptyThen(string s, Action action)
	{
		Guard.AssertNotNull(action, "action");
		if (string.IsNullOrEmpty(s))
		{
			action();
		}
	}

	/// <summary>
	/// 如果当前字符串不是空或者空串，返回指定的替代字符串，否则返回当前字符串
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="value">用于替代的字符串</param>
	/// <returns>当前字符串或者替换的字符串</returns>
	public static string IfNotNullAndEmpty(string s, string value)
	{
		return (!string.IsNullOrEmpty(s)) ? value : s;
	}

	/// <summary>
	/// 如果当前字符串不是空或者空串，返回 <paramref name="evaluation" /> 生成的替代字符串，否则返回当前字符串。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="evaluation">替代字符串生成方法</param>
	/// <returns>当前字符串或者生成的替换字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">替代字符串的生成方法 <paramref name="evaluation" /> 为空。</exception>
	public static string IfNotNullAndEmptyThen(string s, Func<string> evaluation)
	{
		Guard.AssertNotNull(evaluation, "evaluation");
		return (!string.IsNullOrEmpty(s)) ? evaluation() : s;
	}

	/// <summary>
	/// 如果当前字符串不是空或者空串，执行指定的处理 <paramref name="action" />。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="action">处理方法</param>
	/// <returns>处理结果</returns>
	/// <exception cref="T:System.ArgumentNullException">处理方法 <paramref name="action" /> 为空。</exception>
	public static void IfNotNullAndEmptyThen(string s, Action action)
	{
		Guard.AssertNotNull(action, "action");
		if (!string.IsNullOrEmpty(s))
		{
			action();
		}
	}

	/// <summary>
	/// 如果当前字符串为空、空串或者只包含空白字符，返回指定的替代字符串，否则返回当前字符串
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="value">用于替代的字符串</param>
	/// <returns>当前字符串或者替代的字符串</returns>
	public static string IfNullOrWhiteSpace(string s, string value)
	{
		return string.IsNullOrWhiteSpace(s) ? value : s;
	}

	/// <summary>
	/// 如果当前字符串为空、空串或者只包含空白字符，返回 <paramref name="evaluation" /> 生成的替代字符串，否则返回当前字符串。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="evaluation">替代字符串生成方法</param>
	/// <returns>当前字符串或者生成的替代字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">替代值生成方法 <paramref name="evaluation" /> 为空。</exception>
	public static string IfNullOrWhiteSpaceThen(string s, Func<string> evaluation)
	{
		Guard.AssertNotNull(evaluation, "evaluation");
		return string.IsNullOrWhiteSpace(s) ? evaluation() : s;
	}

	/// <summary>
	/// 如果当前字符串为空、空串或者只包含空白字符，执行指定的处理 <paramref name="action" />。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="action">处理方法</param>
	/// <exception cref="T:System.ArgumentNullException">处理方法 <paramref name="action" /> 为空。</exception>
	public static void IfNullOrWhiteSpaceThen(string s, Action action)
	{
		Guard.AssertNotNull(action, "action");
		if (string.IsNullOrWhiteSpace(s))
		{
			action();
		}
	}

	/// <summary>
	/// 如果当前字符串不是空、空串或者只包含空白字符，返回指定的替代字符串，否则返回当前字符串
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="value">用于替代的字符串</param>
	/// <returns>当前字符串或者替代字符串</returns>
	public static string IfNotNullAndWhiteSpace(string s, string value)
	{
		return (!string.IsNullOrWhiteSpace(s)) ? value : s;
	}

	/// <summary>
	/// 如果当前字符串不是空、空串或者只包含空白字符返回 <paramref name="evaluation" /> 生成的替代字符串，否则返回当前字符串
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="evaluation">替代字符串生成方法</param>
	/// <returns>当前字符串或者生成的替代字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">替代字符串生成方法 <paramref name="evaluation" /> 为空。</exception>
	public static string IfNotNullAndWhiteSpace(string s, Func<string> evaluation)
	{
		Guard.AssertNotNull(evaluation, "evaluation");
		return (!string.IsNullOrWhiteSpace(s)) ? evaluation() : s;
	}

	/// <summary>
	/// 如果当前字符串不是空、空串或者只包含空白字符，执行指定的处理 <paramref name="action" />
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="action">处理方法</param>
	/// <exception cref="T:System.ArgumentNullException">处理方法 <paramref name="action" /> 为空。</exception>
	public static void IfNotNullAndWhiteSpace(string s, Action action)
	{
		Guard.AssertNotNull(action, "action");
		if (!string.IsNullOrWhiteSpace(s))
		{
			action();
		}
	}

	/// <summary>
	/// 判断当前字符串是否存在于给定的字符串列表中；字符串区分大小写。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="values">用于比较的字符串列表</param>
	/// <returns>如果当前字符串存在于列表中返回true，否则返回false。</returns>
	public static bool In(string s, params string[] values)
	{
		return In(s, values, StringComparison.CurrentCulture);
	}

	/// <summary>
	/// 判断当前字符串是否存在于给定的字符串列表中
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="values">用于比较的字符串列表</param>
	/// <param name="ignoreCase">字符串比较是否区分大小写</param>
	/// <returns>如果当前字符串存在于列表中返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者比较字符串列表为空。</exception>
	public static bool In(string s, IEnumerable<string> values, bool ignoreCase)
	{
		return In(s, values, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
	}

	/// <summary>
	/// 判断当前字符串是否存在于给定的字符串列表中
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="values">用于比较的字符串列表</param>
	/// <param name="comparison">字符串比较方式</param>
	/// <returns>如果当前字符串存在于列表中返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者比较字符串列表为空。</exception>
	public static bool In(string s, IEnumerable<string> values, StringComparison comparison)
	{
		Guard.AssertNotNull(s, "s");
		Guard.AssertNotNull(values, "values");
		return values.Any((string x) => string.Equals(x, s, comparison));
	}

	/// <summary>
	/// 在当前文本的区域中查找指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果找到指定的字符返回其索引，否则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static int IndexOf(string text, char c, bool ignoreCase = false)
	{
		Guard.AssertNotNull(text, "text");
		return IndexOf(text, c, 0, text.Length, ignoreCase);
	}

	/// <summary>
	/// 在当前文本的区域中查找指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="culture">比较字符使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果找到指定的字符返回其索引，否则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static int IndexOf(string text, char c, CultureInfo culture, bool ignoreCase = false)
	{
		Guard.AssertNotNull(text, "text");
		return IndexOf(text, c, 0, text.Length, culture, ignoreCase);
	}

	/// <summary>
	/// 在当前文本的区域中查找指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="culture">比较字符使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="options">比较字符使用的选项</param>
	/// <returns>如果找到指定的字符返回其索引，否则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static int IndexOf(string text, char c, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		return IndexOf(text, c, 0, text.Length, culture, options);
	}

	/// <summary>
	/// 在当前文本的区域中查找指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="start">查找区域的起始位置</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果找到指定的字符返回其索引，否则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找区域的起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	public static int IndexOf(string text, char c, int start, bool ignoreCase = false)
	{
		return IndexOf(text, c, start, CultureInfo.CurrentCulture, ignoreCase);
	}

	/// <summary>
	/// 在当前文本的区域中查找指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="start">查找区域的起始位置</param>
	/// <param name="culture">比较字符使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果找到指定的字符返回其索引，否则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找区域的起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	public static int IndexOf(string text, char c, int start, CultureInfo culture, bool ignoreCase = false)
	{
		return IndexOf(text, c, start, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 在当前文本的区域中查找指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="start">查找区域的起始位置</param>
	/// <param name="culture">比较字符使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="options">比较字符使用的选项</param>
	/// <returns>如果找到指定的字符返回其索引，否则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找区域的起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	public static int IndexOf(string text, char c, int start, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertIndexRange(start, 0, text.Length - 1, "start");
		return ObjectHelper.IfNull(culture, CultureInfo.CurrentCulture).CompareInfo.IndexOf(text, c, start, options);
	}

	/// <summary>
	/// 在当前文本的区域中查找指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="start">查找区域的起始位置</param>
	/// <param name="count">查找区域中的字符数量</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果找到指定的字符返回其索引，否则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找区域的起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找区域的字符数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始字符串中剩余的字符数量。</exception>
	public static int IndexOf(string text, char c, int start, int count, bool ignoreCase = false)
	{
		return IndexOf(text, c, start, count, CultureInfo.CurrentCulture, ignoreCase);
	}

	/// <summary>
	/// 在当前文本的区域中查找指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="start">查找区域的起始位置</param>
	/// <param name="count">查找区域中的字符数量</param>
	/// <param name="culture">比较字符使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果找到指定的字符返回其索引，否则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找区域的起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找区域的字符数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始字符串中剩余的字符数量。</exception>
	public static int IndexOf(string text, char c, int start, int count, CultureInfo culture, bool ignoreCase = false)
	{
		return IndexOf(text, c, start, count, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 在当前文本的区域中查找指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="start">查找区域的起始位置</param>
	/// <param name="count">查找区域中的字符数量</param>
	/// <param name="culture">比较字符使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="options">比较字符使用的选项</param>
	/// <returns>如果找到指定的字符返回其索引，否则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找区域的起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找区域的字符数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始字符串中剩余的字符数量。</exception>
	public static int IndexOf(string text, char c, int start, int count, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertIndexRange(start, 0, text.Length - 1, "start");
		Guard.AssertBetween(count, 0, text.Length - start, "count");
		return ObjectHelper.IfNull(culture, CultureInfo.CurrentCulture).CompareInfo.IndexOf(text, c, start, count, options);
	}

	/// <summary>
	/// 在当前文本的区域中查找指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="s">查找的字符串</param>
	/// <param name="ignoreCase">比较字符是否区分大小写</param>
	/// <returns>如果找到指定的字符串返回其索引，否则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者查找的字符串为空。</exception>
	public static int IndexOf(string text, string s, bool ignoreCase = false)
	{
		Guard.AssertNotNull(text, "text");
		return IndexOf(text, s, 0, text.Length, ignoreCase);
	}

	/// <summary>
	/// 在当前文本的区域中查找指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="s">查找的字符串</param>
	/// <param name="culture">比较字符使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="ignoreCase">比较字符是否区分大小写</param>
	/// <returns>如果找到指定的字符串返回其索引，否则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者查找的字符串为空。</exception>
	public static int IndexOf(string text, string s, CultureInfo culture, bool ignoreCase = false)
	{
		Guard.AssertNotNull(text, "text");
		return IndexOf(text, s, 0, text.Length, culture, ignoreCase);
	}

	/// <summary>
	/// 在当前文本的区域中查找指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="s">查找的字符串</param>
	/// <param name="culture">比较字符使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="options">比较字符使用的选项</param>
	/// <returns>如果找到指定的字符串返回其索引，否则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者查找的字符串为空。</exception>
	public static int IndexOf(string text, string s, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		return IndexOf(text, s, 0, text.Length, culture, options);
	}

	/// <summary>
	/// 在当前文本的区域中查找指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="s">查找的字符串</param>
	/// <param name="start">查找区域的起始位置</param>
	/// <param name="ignoreCase">比较字符是否区分大小写</param>
	/// <returns>如果找到指定的字符串返回其索引，否则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者查找的字符串为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找区域的起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	public static int IndexOf(string text, string s, int start, bool ignoreCase = false)
	{
		return IndexOf(text, s, start, CultureInfo.CurrentCulture, ignoreCase);
	}

	/// <summary>
	/// 在当前文本的区域中查找指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="s">查找的字符串</param>
	/// <param name="start">查找区域的起始位置</param>
	/// <param name="culture">比较字符使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="ignoreCase">比较字符是否区分大小写</param>
	/// <returns>如果找到指定的字符串返回其索引，否则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者查找的字符串为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找区域的起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	public static int IndexOf(string text, string s, int start, CultureInfo culture, bool ignoreCase = false)
	{
		return IndexOf(text, s, start, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 在当前文本的区域中查找指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="s">查找的字符串</param>
	/// <param name="start">查找区域的起始位置</param>
	/// <param name="culture">比较字符使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="options">比较字符使用的选项</param>
	/// <returns>如果找到指定的字符串返回其索引，否则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者查找的字符串为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找区域的起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	public static int IndexOf(string text, string s, int start, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(s, "s");
		Guard.AssertIndexRange(start, 0, text.Length - 1, "start");
		return ObjectHelper.IfNull(culture, CultureInfo.CurrentCulture).CompareInfo.IndexOf(text, s, start, options);
	}

	/// <summary>
	/// 在当前文本的区域中查找指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="s">查找的字符串</param>
	/// <param name="start">查找区域的起始位置</param>
	/// <param name="count">查找区域中的字符数量</param>
	/// <param name="ignoreCase">比较字符是否区分大小写</param>
	/// <returns>如果找到指定的字符串返回其索引，否则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者查找的字符串为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找区域的起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找区域的字符数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始字符串中剩余的字符数量。</exception>
	public static int IndexOf(string text, string s, int start, int count, bool ignoreCase = false)
	{
		return IndexOf(text, s, start, count, CultureInfo.CurrentCulture, ignoreCase);
	}

	/// <summary>
	/// 在当前文本的区域中查找指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="s">查找的字符串</param>
	/// <param name="start">查找区域的起始位置</param>
	/// <param name="count">查找区域中的字符数量</param>
	/// <param name="culture">比较字符使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="ignoreCase">比较字符是否区分大小写</param>
	/// <returns>如果找到指定的字符串返回其索引，否则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者查找的字符串为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找区域的起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找区域的字符数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始字符串中剩余的字符数量。</exception>
	public static int IndexOf(string text, string s, int start, int count, CultureInfo culture, bool ignoreCase = false)
	{
		return IndexOf(text, s, start, count, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 在当前文本的区域中查找指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="s">查找的字符串</param>
	/// <param name="start">查找区域的起始位置</param>
	/// <param name="count">查找区域中的字符数量</param>
	/// <param name="culture">比较字符使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="options">比较字符使用的选项</param>
	/// <returns>如果找到指定的字符串返回其索引，否则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者查找的字符串为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找区域的起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找区域的字符数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始字符串中剩余的字符数量。</exception>
	public static int IndexOf(string text, string s, int start, int count, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(s, "s");
		Guard.AssertIndexRange(start, 0, text.Length - 1, "start");
		Guard.AssertBetween(count, 0, text.Length - start, "count");
		return ObjectHelper.IfNull(culture, CultureInfo.CurrentCulture).CompareInfo.IndexOf(text, s, start, count, options);
	}

	/// <summary>
	/// 在当前可变文本中查找字符的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果在可变文本中找到字符返回字符的位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	public static int IndexOf(StringBuilder text, char c, bool ignoreCase = false)
	{
		return IndexOf(text, c, CultureInfo.CurrentCulture, ignoreCase);
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
	public static int IndexOf(StringBuilder text, char c, CultureInfo culture, bool ignoreCase = false)
	{
		return IndexOf(text, c, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static int IndexOf(StringBuilder text, char c, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "string builder");
		return IndexOf(text, c, 0, text.Length, culture, options);
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
	public static int IndexOf(StringBuilder text, char c, int start, bool ignoreCase = false)
	{
		return IndexOf(text, c, start, CultureInfo.CurrentCulture, ignoreCase);
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
	public static int IndexOf(StringBuilder text, char c, int start, CultureInfo culture, bool ignoreCase = false)
	{
		return IndexOf(text, c, start, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static int IndexOf(StringBuilder text, char c, int start, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "string builder");
		Guard.AssertIndexRange(start, 0, text.Length - 1, "start");
		return IndexOf(text, c, start, text.Length - start, culture, options);
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
	public static int IndexOf(StringBuilder text, char c, int start, int count, bool ignoreCase = false)
	{
		return IndexOf(text, c, start, count, CultureInfo.CurrentCulture, ignoreCase);
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
	public static int IndexOf(StringBuilder text, char c, int start, int count, CultureInfo culture, bool ignoreCase = false)
	{
		return IndexOf(text, c, start, count, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static int IndexOf(StringBuilder text, char c, int start, int count, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "string builder");
		Guard.AssertIndexRange(start, 0, text.Length - 1, "start");
		Guard.AssertBetween(count, 0, text.Length - start, "count");
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			if (IsEqualTo(text[i], c, culture, options))
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
	public static int IndexOf(StringBuilder text, string searching, bool ignoreCase = false)
	{
		return IndexOf(text, searching, CultureInfo.CurrentCulture, ignoreCase);
	}

	/// <summary>
	/// 在当前可变文本中查找字符串的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="searching">查找的字符串</param>
	/// <param name="comparison">比较字符时的选项</param>
	/// <returns>如果在可变文本中找到字符串返回该字符串的起始位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	public static int IndexOf(StringBuilder text, string searching, StringComparison comparison)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(searching, "searching text");
		return IndexOf(text, searching, 0, text.Length, comparison);
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
	public static int IndexOf(StringBuilder text, string searching, CultureInfo culture, bool ignoreCase = false)
	{
		return IndexOf(text, searching, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static int IndexOf(StringBuilder text, string searching, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(searching, "searching text");
		return IndexOf(text, searching, 0, text.Length, culture, options);
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
	public static int IndexOf(StringBuilder text, string searching, int start, bool ignoreCase = false)
	{
		return IndexOf(text, searching, start, CultureInfo.CurrentCulture, ignoreCase);
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
	public static int IndexOf(StringBuilder text, string searching, int start, StringComparison comparison)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(searching, "searching text");
		Guard.AssertIndexRange(start, 0, text.Length - 1, "start");
		return IndexOf(text, searching, start, text.Length - start, comparison);
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
	public static int IndexOf(StringBuilder text, string searching, int start, CultureInfo culture, bool ignoreCase = false)
	{
		return IndexOf(text, searching, start, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static int IndexOf(StringBuilder text, string searching, int start, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(searching, "searching text");
		Guard.AssertIndexRange(start, 0, text.Length - 1, "start");
		return IndexOf(text, searching, start, text.Length - start, culture, options);
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
	public static int IndexOf(StringBuilder text, string searching, int start, int count, bool ignoreCase = false)
	{
		return IndexOf(text, searching, start, count, CultureInfo.CurrentCulture, ignoreCase);
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
	public static int IndexOf(StringBuilder text, string searching, int start, int count, StringComparison comparison)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(searching, "searching text");
		Guard.AssertIndexRange(start, 0, text.Length - 1, "start");
		Guard.AssertBetween(count, 0, text.Length - start, "count");
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
					if (!IsEqualTo(searching[i], text[i + start], comparison))
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
	public static int IndexOf(StringBuilder text, string searching, int start, int count, CultureInfo culture, bool ignoreCase = false)
	{
		return IndexOf(text, searching, start, count, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static int IndexOf(StringBuilder text, string searching, int start, int count, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(searching, "searching text");
		Guard.AssertIndexRange(start, 0, text.Length - 1, "start");
		Guard.AssertBetween(count, 0, text.Length - start, "count");
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
					if (!IsEqualTo(searching[i], text[i + start], culture, options))
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
	public static StringBuilder Insert<T>(StringBuilder text, int index, T value, int count)
	{
		Guard.AssertNotNull(text, "string builder");
		Guard.AssertIndexRange(index, 0, text.Length - 1, "index");
		Guard.AssertBetween(count, 0, text.Length, "count");
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
	public static StringBuilder Insert(StringBuilder text, int index, params object[] values)
	{
		Guard.AssertNotNull(text, "string builder");
		Guard.AssertIndexRange(index, 0, text.Length - 1, "index");
		Guard.AssertNotNull(values, "values");
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
	public static StringBuilder Insert(StringBuilder text, int index, IEnumerable<object> values)
	{
		Guard.AssertNotNull(text, "builder");
		Guard.AssertIndexRange(index, 0, text.Length - 1, "index");
		Guard.AssertNotNull(values, "values");
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
	public static StringBuilder Insert<T>(StringBuilder text, int index, params T[] values)
	{
		Guard.AssertNotNull(text, "string builder");
		Guard.AssertIndexRange(index, 0, text.Length - 1, "index");
		Guard.AssertNotNull(values, "values");
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
	public static StringBuilder Insert<T>(StringBuilder text, int index, IEnumerable<T> values)
	{
		Guard.AssertNotNull(text, "builder");
		Guard.AssertIndexRange(index, 0, text.Length - 1, "index");
		Guard.AssertNotNull(values, "values");
		foreach (T value2 in values)
		{
			object value = value2;
			text.Insert(index++, value);
		}
		return text;
	}

	/// <summary>
	/// 检索系统对当前字符串的暂存引用；如果系统没有暂存当前字符串，则暂存后返回暂存的字符串。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <returns>系统暂存的与当前字符串值相同的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static string Intern(string s)
	{
		Guard.AssertNotNull(s, "s");
		return string.Intern(s);
	}

	/// <summary>
	/// 检测当前字符是否是Ascii字符
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果是Ascii字符返回true，否则返回false</returns>
	public static bool IsAscii(char c)
	{
		return c <= '\u007f';
	}

	/// <summary>
	/// 检测当前字符是否是中文文字，不包括中文标点符号
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果当前字符是中文字符（不包括中文符号）返回true，否则返回false</returns>
	public static bool IsChineseCharacter(char c)
	{
		return ObjectHelper.Between((int)c, 19968, 40869);
	}

	/// <summary>
	/// 检测当前字符是否属于中文标点
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果当前字符是中文字符返回true，否则返回false</returns>
	public static bool IsChinesePunctuation(char c)
	{
		int[] array = new int[31]
		{
			8317, 8318, 8333, 8334, 9001, 9002, 10181, 10182, 10748, 10749,
			11518, 11519, 11804, 11805, 12336, 12349, 12448, 12539, 64830, 64831,
			65123, 65128, 65130, 65131, 65306, 65307, 65311, 65312, 65343, 65371,
			65373
		};
		return ObjectHelper.In(c, array) || ObjectHelper.Between((int)c, 8208, 8231) || ObjectHelper.Between((int)c, 8240, 8259) || ObjectHelper.Between((int)c, 8261, 8273) || ObjectHelper.Between((int)c, 8275, 8286) || ObjectHelper.Between((int)c, 10088, 10101) || ObjectHelper.Between((int)c, 10214, 10219) || ObjectHelper.Between((int)c, 10627, 10648) || ObjectHelper.Between((int)c, 10712, 10715) || ObjectHelper.Between((int)c, 11513, 11516) || ObjectHelper.Between((int)c, 11776, 11799) || ObjectHelper.Between((int)c, 12289, 12291) || ObjectHelper.Between((int)c, 12296, 12305) || ObjectHelper.Between((int)c, 12308, 12319) || ObjectHelper.Between((int)c, 43124, 43127) || ObjectHelper.Between((int)c, 65040, 65049) || ObjectHelper.Between((int)c, 65072, 65106) || ObjectHelper.Between((int)c, 65108, 65121) || ObjectHelper.Between((int)c, 65281, 65283) || ObjectHelper.Between((int)c, 65285, 65290) || ObjectHelper.Between((int)c, 65292, 65295) || ObjectHelper.Between((int)c, 65339, 65341) || ObjectHelper.Between((int)c, 65375, 65381);
	}

	/// <summary>
	/// 检测当前字符是否是CJK字符
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果当前字符是CJK字符返回true，否则返回false</returns>
	public static bool IsCJK(char c)
	{
		return ObjectHelper.Between((int)c, 11904, 65533);
	}

	/// <summary>
	/// 检测当前字符是否属于控制字符
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果当前字符是控制字符返回true，否则返回false</returns>
	/// <seealso cref="M:System.Char.IsControl(System.Char)" />
	public static bool IsControl(char c)
	{
		return char.IsControl(c);
	}

	/// <summary>
	/// 检测当前字符是否属于十进制数字
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果当前字符是十进制数字返回true， 否则返回false</returns>
	/// <seealso cref="M:System.Char.IsDigit(System.Char)" />
	public static bool IsDigit(char c)
	{
		return char.IsDigit(c);
	}

	/// <summary>
	/// 检查当前字符是否是英文字符（包括全角英文字符）
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果当前字符是英文字母则为true,否则为false</returns>
	public static bool IsEnglishLetter(char c)
	{
		return ObjectHelper.Between((int)c, 65, 90) || ObjectHelper.Between((int)c, 97, 122) || ObjectHelper.Between((int)c, 65313, 65338) || ObjectHelper.Between((int)c, 65345, 65370);
	}

	/// <summary>
	/// 判断当前字符与指定的字符是否相等
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <param name="value">待比较的指定字符</param>
	/// <param name="ignoreCase">字符比较是否区分大小写</param>
	/// <returns>如果当前字符与指定字符相等则返回true，否则返回false。</returns>
	public static bool IsEqualTo(char c, char value, bool ignoreCase)
	{
		return IsEqualTo(c, value, CultureInfo.CurrentCulture, ignoreCase);
	}

	/// <summary>
	/// 判断当前字符与指定的字符是否相等
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <param name="value">待比较的指定字符</param>
	/// <param name="comparison">字符比较设置</param>
	/// <returns>如果当前字符与指定字符相等则返回true，否则返回false。</returns>
	public static bool IsEqualTo(char c, char value, StringComparison comparison)
	{
		return comparison switch
		{
			StringComparison.CurrentCulture => IsEqualTo(c, value, CultureInfo.CurrentCulture, ignoreCase: false), 
			StringComparison.CurrentCultureIgnoreCase => IsEqualTo(c, value, CultureInfo.CurrentCulture, ignoreCase: true), 
			StringComparison.InvariantCulture => IsEqualTo(c, value, CultureInfo.InvariantCulture, ignoreCase: false), 
			StringComparison.InvariantCultureIgnoreCase => IsEqualTo(c, value, CultureInfo.InvariantCulture, ignoreCase: true), 
			StringComparison.Ordinal => c.ToString().Equals(value.ToString(), StringComparison.Ordinal), 
			StringComparison.OrdinalIgnoreCase => c.ToString().Equals(value.ToString(), StringComparison.Ordinal), 
			_ => false, 
		};
	}

	/// <summary>
	/// 判断当前字符与指定的字符是否相等
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <param name="value">待比较的指定字符</param>
	/// <param name="culture">字符比较时使用的区域信息；如果为空，则使用当前线程的区域信息。</param>
	/// <param name="ignoreCase">字符比较是否区分大小写</param>
	/// <returns>如果当前字符与指定字符相等则返回true，否则返回false。</returns>
	public static bool IsEqualTo(char c, char value, CultureInfo culture, bool ignoreCase)
	{
		culture = ObjectHelper.IfNull(culture, CultureInfo.CurrentCulture);
		return ignoreCase ? ToUpper(c, culture).Equals(ToUpper(value, culture)) : c.Equals(value);
	}

	/// <summary>
	/// 判断当前字符与指定字符是否相等
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <param name="value">比较的指定字符</param>
	/// <param name="culture">字符比较时使用的区域信息；如果为空，则使用当前线程的区域信息。</param>
	/// <param name="options">字符比较选项</param>
	/// <returns>如果当前字符与指定字符相等则返回true，否则返回false。</returns>
	public static bool IsEqualTo(char c, char value, CultureInfo culture, CompareOptions options)
	{
		return IsEqualTo(c, value, culture, options.HasFlag(CompareOptions.IgnoreCase));
	}

	/// <summary>
	/// 检测当前字符是否属于全角字符（全宽度字符）
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>以宋体字体显示当前字符时，字符宽度为全宽度（双字节），则返回true，否则返回false。对于非CJK字符集的语言字符（如阿拉伯语、泰语、梵语等），返回false。</returns>
	public static bool IsFullWidth(char c)
	{
		int[] array = new int[146]
		{
			160, 164, 167, 168, 176, 177, 183, 215, 247, 256,
			274, 282, 331, 332, 461, 463, 465, 467, 469, 471,
			473, 475, 501, 592, 596, 603, 618, 629, 643, 650,
			711, 713, 714, 715, 717, 729, 8208, 8211, 8212, 8213,
			8214, 8216, 8217, 8220, 8221, 8228, 8229, 8230, 8231, 8240,
			8242, 8243, 8245, 8251, 8254, 8273, 8211, 8213, 8457, 8470,
			8481, 8491, 8632, 8633, 8658, 8660, 8679, 8704, 8707, 8711,
			8712, 8715, 8719, 8721, 8725, 8726, 8728, 8729, 8730, 8733,
			8734, 8735, 8736, 8739, 8741, 8743, 8744, 8745, 8746, 8747,
			8748, 8750, 8756, 8757, 8758, 8759, 8765, 8776, 8876, 8786,
			8800, 8801, 8803, 8804, 8805, 8806, 8807, 8810, 8811, 8814,
			8815, 8834, 8835, 8838, 8839, 8853, 8857, 8869, 8895, 8967,
			8978, 8984, 9001, 9002, 9166, 9178, 9179, 9251, 9650, 9651,
			9660, 9661, 9670, 9671, 9675, 9678, 9679, 9698, 9699, 9700,
			9701, 9711, 9832, 9834, 9837, 10687
		};
		return ObjectHelper.In(c, array) || ObjectHelper.Between((int)c, 913, 937) || ObjectHelper.Between((int)c, 945, 969) || ObjectHelper.Between((int)c, 1040, 1105) || ObjectHelper.Between((int)c, 4352, 4607) || ObjectHelper.Between((int)c, 8352, 8364) || ObjectHelper.Between((int)c, 8544, 8595) || ObjectHelper.Between((int)c, 8598, 8601) || ObjectHelper.Between((int)c, 9152, 9164) || ObjectHelper.Between((int)c, 9312, 9547) || ObjectHelper.Between((int)c, 9552, 9588) || ObjectHelper.Between((int)c, 9601, 9615) || ObjectHelper.Between((int)c, 9619, 9633) || ObjectHelper.Between((int)c, 9728, 9784) || ObjectHelper.Between((int)c, 9789, 9823) || ObjectHelper.Between((int)c, 9985, 10239) || ObjectHelper.Between((int)c, 11904, 12350) || ObjectHelper.Between((int)c, 12352, 12687) || ObjectHelper.Between((int)c, 12704, 19903) || ObjectHelper.Between((int)c, 19936, 40959) || ObjectHelper.Between((int)c, 43360, 43391) || ObjectHelper.Between((int)c, 44032, 55295) || ObjectHelper.Between((int)c, 63744, 64255) || ObjectHelper.Between((int)c, 65040, 65055) || ObjectHelper.Between((int)c, 65072, 65135) || ObjectHelper.Between((int)c, 65281, 65376) || ObjectHelper.Between((int)c, 65504, 65511);
	}

	/// <summary>
	/// 判断当前字符串是否符合Guid的字符串格式
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <returns>如果当前字符串符合Guid的格式返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static bool IsGuid(string s)
	{
		Guard.AssertNotNull(s, "s");
		return IsWholeMatch(RegexPatterns.Guid, s);
	}

	/// <summary>
	/// 检测当前字符是否属于半角字符（半宽度字符）
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果当前字符是半角字符返回true，否则返回false</returns>
	public static bool IsHalfWidth(char c)
	{
		return !IsFullWidth(c);
	}

	/// <summary>
	/// 检测当前字符是否属于高代理项
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果字符是高代理项返回true， 否则返回false</returns>
	public static bool IsHighSurrogate(char c)
	{
		return char.IsHighSurrogate(c);
	}

	/// <summary>
	/// 检测当前字符是否是CJK象形字符
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果当前字符是CJK象形字符返回true，否则返回false</returns>
	public static bool IsIdeograph(char c)
	{
		return ObjectHelper.Between((int)c, 13312, 19893) || ObjectHelper.Between((int)c, 19968, 40869) || ObjectHelper.Between((int)c, 40870, 40891) || ObjectHelper.Between((int)c, 63744, 64045) || ObjectHelper.Between((int)c, 64048, 64106) || ObjectHelper.Between((int)c, 64112, 64217);
	}

	/// <summary>
	/// 检测当前字符串是否已经被系统暂存
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <returns>如果当前字符串已经被暂存返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static bool IsInterned(string s)
	{
		Guard.AssertNotNull(s, "s");
		return ObjectHelper.IsNotNull(string.IsInterned(s));
	}

	/// <summary>
	/// 检测当前字符是否属于日文假名
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果当前字符属于日文假名返回true，否则返回false</returns>
	public static bool IsJapaneseKana(char c)
	{
		return ObjectHelper.Between((int)c, 12352, 12447) || ObjectHelper.Between((int)c, 12448, 12543) || ObjectHelper.Between((int)c, 12784, 12799) || ObjectHelper.Between((int)c, 65382, 65439);
	}

	/// <summary>
	/// 判断当前字符串是否符合JSON样式
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <returns>如果当前字符串符合JSON的样式返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static bool IsJson(string s)
	{
		Guard.AssertNotNull(s, "s");
		return IsWholeMatch(RegexPatterns.Json, s);
	}

	/// <summary>
	/// 判断当前字符串是否符合JSON数组样式
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <returns>如果当前字符串符合JSON数组的样式返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static bool IsJsonArray(string s)
	{
		Guard.AssertNotNull(s, "s");
		return IsWholeMatch(RegexPatterns.JsonArray, s);
	}

	/// <summary>
	/// 判断当前字符串是否符合JSON对象样式
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <returns>如果当前字符串符合JSON数组的样式返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static bool IsJsonObject(string s)
	{
		Guard.AssertNotNull(s, "s");
		return IsWholeMatch(RegexPatterns.JsonObject, s);
	}

	/// <summary>
	/// 检测当前字符是否属于字母类别
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果当前字符属于字母类别返回true，否则返回false</returns>
	/// <seealso cref="M:System.Char.IsLetter(System.Char)" />
	public static bool IsLetter(char c)
	{
		return char.IsLetter(c);
	}

	/// <summary>
	/// 检测当前字符是否属于字母类别或者十进制数字
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果字符属于字母类别或者十进制数字返回true，否则返回false</returns>
	/// <seealso cref="M:System.Char.IsLetterOrDigit(System.Char)" />
	public static bool IsLetterOrDigit(char c)
	{
		return char.IsLetterOrDigit(c);
	}

	/// <summary>
	/// 检测当前字符是否属于字母类别或者数字类别
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果字符属于字母类别或者数字类别返回true，否则返回false</returns>
	/// <seealso cref="M:System.Char.IsLetter(System.Char)" />
	/// <seealso cref="M:System.Char.IsNumber(System.Char)" />
	public static bool IsLetterOrNumber(char c)
	{
		return char.IsLetter(c) || char.IsNumber(c);
	}

	/// <summary>
	/// 检测当前字符是否属于小写字母类别
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果当前字符属于小写字母类别返回true，否则返回false</returns>
	/// <seealso cref="M:System.Char.IsLower(System.Char)" />
	public static bool IsLower(char c)
	{
		return char.IsLower(c);
	}

	/// <summary>
	/// 检测当前字符是否为低代理项
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果当前字符属于小写字母类别返回true，否则返回false</returns>
	/// <seealso cref="M:System.Char.IsLowSurrogate(System.Char)" />
	public static bool IsLowSurrogate(char c)
	{
		return char.IsLowSurrogate(c);
	}

	/// <summary>
	/// 判断当前文本是否与指定的正则模式匹配
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">匹配的模式</param>
	/// <param name="options">正则模式选项</param>
	/// <returns>如果匹配返回true,否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者匹配的正则模式 <paramref name="pattern" /> 为空。</exception>
	public static bool IsMatch(string text, string pattern, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return IsMatch(text, ConvertHelper.ToRegex(pattern, options));
	}

	/// <summary>
	/// 判断当前文本是否与指定的正则模式匹配
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">匹配的模式</param>
	/// <param name="wholeMatching">是否进行完整匹配，默认为false。</param>
	/// <param name="options">正则模式选项</param>
	/// <returns>如果匹配返回true,否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者匹配的正则模式 <paramref name="pattern" /> 为空。</exception>
	public static bool IsMatch(string text, string pattern, bool wholeMatching, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return IsMatch(text, ConvertHelper.ToRegex(pattern, options), wholeMatching);
	}

	/// <summary>
	/// 判断当前文本是否与指定的正则模式匹配
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">匹配的模式</param>
	/// <param name="wholeMatching">是否进行完整匹配，默认为false。</param>
	/// <returns>如果匹配返回true,否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者匹配的正则模式 <paramref name="pattern" /> 为空。</exception>
	public static bool IsMatch(string text, Regex pattern, bool wholeMatching = false)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(pattern, "pattern");
		return wholeMatching ? IsWholeMatch(pattern, text) : pattern.IsMatch(text);
	}

	/// <summary>
	/// 判断当前字符串是否为空或者空串
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <returns>如果当前字符串为空或者空串返回true,否则false</returns>
	public static bool IsNullOrEmpty(string s)
	{
		return string.IsNullOrEmpty(s);
	}

	/// <summary>
	/// 检测当前字符是否属于数字字符
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果当前字符属于数字字符返回true，否则返回false</returns>
	/// <seealso cref="M:System.Char.IsNumber(System.Char)" />
	public static bool IsNumber(char c)
	{
		return char.IsNumber(c);
	}

	/// <summary>
	/// 判断当前字符串是否不为空或者空串
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <returns>如果当前字符串不是空或者空串返回true，否则返回false</returns>
	public static bool IsNotNullAndEmpty(string s)
	{
		return !string.IsNullOrEmpty(s);
	}

	/// <summary>
	/// 判断当前字符串是否为空、空串或者空白字符
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <returns>如果当前字符串为空、空串或者空白字符返回true,否则false</returns>
	public static bool IsNullOrWhiteSpace(string s)
	{
		return string.IsNullOrWhiteSpace(s);
	}

	/// <summary>
	/// 判断当前字符串是否不是空、空串或者空白字符
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <returns>如果当前字符串不是空、空串或者空白字符返回true，否则返回false</returns>
	public static bool IsNotNullAndWhiteSpace(string s)
	{
		return !string.IsNullOrWhiteSpace(s);
	}

	/// <summary>
	/// 检测当前的正则表达式是否在输入文本中存在匹配项目
	/// </summary>
	/// <param name="regex">当前正则表达式</param>
	/// <param name="text">输入文本</param>
	/// <param name="times">检测匹配的次数</param>
	/// <returns>如果存在匹配返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前正则模式为空；或者输入文本 <paramref name="text" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">匹配次数 <paramref name="times" /> 小于1。</exception>
	public static bool IsPartialMatch(Regex regex, string text, int times = 1)
	{
		if (times == 1)
		{
			return regex.IsMatch(text);
		}
		return ObjectHelper.IsNotNull(GetMatch(regex, text, times));
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
	public static bool IsPartialMatch(Regex regex, string text, int start, int count, int times = 1)
	{
		return ObjectHelper.IsNotNull(GetMatch(regex, text, start, count, times));
	}

	/// <summary>
	/// 检测当前字符是否属于标点符号
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果字符属于标点符号返回true，否则返回false</returns>
	/// <seealso cref="M:System.Char.IsPunctuation(System.Char)" />
	public static bool IsPunctuation(char c)
	{
		return char.IsPunctuation(c);
	}

	/// <summary>
	/// 检测当前字符是否属于分隔符
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果当前字符属于分隔符返回true，否则返回false</returns>
	public static bool IsSeparator(char c)
	{
		return char.IsSeparator(c);
	}

	/// <summary>
	/// 检测当前字符是否属于代理项
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果当前字符属于代理项返回true，否则返回false</returns>
	public static bool IsSurrogate(char c)
	{
		return char.IsSurrogate(c);
	}

	/// <summary>
	/// 检测当前字符和指定的字符是否形成代理项对
	/// </summary>
	/// <param name="hc">高代理项字符</param>
	/// <param name="lc">低代理项字符</param>
	/// <returns>如果两个字符形成代理项对返回true，否则返回false</returns>
	public static bool IsSurrogatePair(char hc, char lc)
	{
		return char.IsSurrogatePair(hc, lc);
	}

	/// <summary>
	/// 检测当前字符是否属于符号字符类别
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果当前字符属于符号字符返回true，否则返回false</returns>
	public static bool IsSymbol(char c)
	{
		return char.IsSymbol(c);
	}

	/// <summary>
	/// 检测当前字符是否是Unicode字符
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果是Unicode字符返回true,否则返回false</returns>
	/// <remarks>Unicode字符是不能直接转换为Ascii编码，必须转换为UTF-8等编码。</remarks>
	public static bool IsUnicode(char c)
	{
		return !IsAscii(c);
	}

	/// <summary>
	/// 检测当前字符是否属于大写字母类别
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果当前字符属于符号字符返回true，否则返回false</returns>
	public static bool IsUpper(char c)
	{
		return char.IsUpper(c);
	}

	/// <summary>
	/// 检测当前字符是否属于空白类别
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果当前字符属于空白类别返回true，否则返回false</returns>
	public static bool IsWhiteSpace(char c)
	{
		return char.IsWhiteSpace(c);
	}

	/// <summary>
	/// 检测当前的正则表达式是否与输入文本完全匹配（从文本开始到文本结束整体与当前正则表达式匹配）
	/// </summary>
	/// <param name="regex">当前正则表达式</param>
	/// <param name="text">输入文本</param>
	/// <returns>如果存在匹配返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前正则表达式为空；或者输入文本 <paramref name="text" /> 为空。</exception>
	public static bool IsWholeMatch(Regex regex, string text)
	{
		Guard.AssertNotNull(regex, "regex");
		Guard.AssertNotNull(text, "text");
		return IsWholeMatch(regex, text, 0, text.Length);
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
	public static bool IsWholeMatch(Regex regex, string text, int start, int count)
	{
		Guard.AssertNotNull(regex, "regex");
		Guard.AssertNotNull(text, "text");
		Guard.AssertIndexRange(start, 0, text.Length - 1, "start");
		Guard.AssertBetween(count, 0, text.Length - start, "count");
		return GetMatches(regex, text, (Match m) => m.Success && m.Index == start && m.Length == count).Any();
	}

	/// <summary>
	/// 保留当前文本中所有的字母（大写和小写的英文字母）
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <returns>被保留的当前文本中所有的字母字符的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static string KeepAlpha(string text)
	{
		return KeepRegex(text, RegexPatterns.AlphaMore);
	}

	/// <summary>
	/// 保留当前文本中所有的字母和数字（大写和小写的英文字母、数字）
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <returns>当前文本中所有的字母和数字字符的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static string KeepAlphaDigit(string text)
	{
		return KeepRegex(text, RegexPatterns.AlphaDigitMore);
	}

	/// <summary>
	/// 保留当前文本中所有指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="chars">需要保留的字符数组</param>
	/// <returns>当前文本中保留的字符组成的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者保留的字符数组 <paramref name="chars" /> 为空。</exception>
	public static string KeepChar(string text, params char[] chars)
	{
		return KeepChar(text, chars, CultureInfo.CurrentCulture);
	}

	/// <summary>
	/// 保留当前文本中所有指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="chars">需要保留的字符数组</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>当前文本中保留的字符组成的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者保留的字符数组 <paramref name="chars" /> 为空。</exception>
	public static string KeepChar(string text, char[] chars, bool ignoreCase = false)
	{
		return KeepChar(text, chars, CultureInfo.CurrentCulture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 保留当前文本中所有指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="chars">需要保留的字符数组</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>当前文本中保留的字符组成的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者保留的字符数组 <paramref name="chars" /> 为空。</exception>
	public static string KeepChar(string text, char[] chars, CultureInfo culture, bool ignoreCase = false)
	{
		return KeepChar(text, chars, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 保留当前文本中所有指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="chars">需要保留的字符数组</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="options">比较字符时选项</param>
	/// <returns>当前文本中保留的字符组成的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者保留的字符数组 <paramref name="chars" /> 为空。</exception>
	public static string KeepChar(string text, char[] chars, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(chars, "chars");
		StringBuilder buff = new StringBuilder();
		foreach (char c in text)
		{
			Func<char, bool> predicate = (char x) => IsEqualTo(x, c, culture, options);
			if (chars.Any(predicate))
			{
				buff.Append(c);
			}
		}
		return buff.ToString();
	}

	/// <summary>
	/// 保留当前文本中满足条件的字符；如果没有指定字符的检测条件,则不返回任何字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="predicate">当前文本中字符的检测条件</param>
	/// <returns>当前文本中所有满足条件的字符</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者字符筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static string KeepChar(string text, Func<char, bool> predicate)
	{
		Guard.AssertNotNull(predicate, "predicate");
		return KeepChar(text, (char c, int i) => predicate(c));
	}

	/// <summary>
	/// 保留当前文本中满足条件的字符；如果没有指定字符的检测条件,则不返回任何字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="predicate">当前文本中字符的检测条件</param>
	/// <returns>当前文本中所有满足条件的字符</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者字符筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static string KeepChar(string text, Func<char, int, bool> predicate)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(predicate, "predicate");
		StringBuilder buff = new StringBuilder(text.Length);
		for (int i = 0; i < text.Length; i++)
		{
			if (predicate(text[i], i))
			{
				buff.Append(text[i]);
			}
		}
		return buff.ToString();
	}

	/// <summary>
	/// 逆向检测并保留当前文本中所有指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="chars">需要保留的字符数组</param>
	/// <returns>当前文本中保留的字符组成的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者保留的字符数组 <paramref name="chars" /> 为空。</exception>
	public static string KeepLastChar(string text, params char[] chars)
	{
		return KeepLastChar(text, chars, CultureInfo.CurrentCulture);
	}

	/// <summary>
	/// 逆向检测并保留当前文本中所有指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="chars">需要保留的字符数组</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>当前文本中保留的字符组成的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者保留的字符数组 <paramref name="chars" /> 为空。</exception>
	public static string KeepLastChar(string text, char[] chars, bool ignoreCase = false)
	{
		return KeepLastChar(text, chars, CultureInfo.CurrentCulture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 逆向检测并保留当前文本中所有指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="chars">需要保留的字符数组</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>当前文本中保留的字符组成的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者保留的字符数组 <paramref name="chars" /> 为空。</exception>
	public static string KeepLastChar(string text, char[] chars, CultureInfo culture, bool ignoreCase = false)
	{
		return KeepLastChar(text, chars, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 逆向检测并保留当前文本中所有指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="chars">需要保留的字符数组</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="options">比较字符时选项</param>
	/// <returns>当前文本中保留的字符组成的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者保留的字符数组 <paramref name="chars" /> 为空。</exception>
	public static string KeepLastChar(string text, char[] chars, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(chars, "chars");
		StringBuilder buff = new StringBuilder();
		int i;
		for (i = text.Length - 1; i >= 0; i--)
		{
			if (chars.Any((char x) => IsEqualTo(x, text[i], culture, options)))
			{
				buff.Append(text[i]);
			}
		}
		return buff.ToString();
	}

	/// <summary>
	/// 逆向检测并保留当前文本中满足条件的字符；如果没有指定字符的检测条件,则不返回任何字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="predicate">字符检测条件</param>
	/// <returns>当前文本中所有满足条件的字符组成的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者字符筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static string KeepLastChar(string text, Func<char, bool> predicate)
	{
		Guard.AssertNotNull(predicate, "predicate");
		return KeepLastChar(text, (char c, int i) => predicate(c));
	}

	/// <summary>
	/// 逆向检测并保留当前文本中满足条件的字符；如果没有指定字符的检测条件,则不返回任何字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="predicate">字符检测条件</param>
	/// <returns>当前文本中所有满足条件的字符组成的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者字符筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static string KeepLastChar(string text, Func<char, int, bool> predicate)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(predicate, "predicate");
		StringBuilder buff = new StringBuilder(text.Length);
		for (int i = text.Length - 1; i >= 0; i--)
		{
			if (predicate(text[i], i))
			{
				buff.Append(text[i]);
			}
		}
		return buff.ToString();
	}

	/// <summary>
	/// 保留当前文本中的中文字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <returns>当前文本中的中文字符组成的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static string KeepChineseCharacter(string text)
	{
		return KeepRegex(text, RegexPatterns.ChineseCharacterMore);
	}

	/// <summary>
	/// 保留当前文本中的中文字符和符号
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <returns>当前文本中的中文字符组成的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static string KeepChineseSymbol(string text)
	{
		return KeepRegex(text, RegexPatterns.ChineseSymbolMore);
	}

	/// <summary>
	/// 保留当期文本中的数字
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <returns>当前文本中数组组成的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static string KeepDigit(string text)
	{
		return KeepRegex(text, RegexPatterns.DigitMore);
	}

	/// <summary>
	/// 保留当前文本中的具有“+XXX.XXX”数值；只保留第一个具有浮点数值形式的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <returns>输入文本中第一个具有浮点数值形式的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static string KeepFixedPointNumber(string text)
	{
		return KeepRegex(text, RegexPatterns.FixedPointNumber, 1);
	}

	/// <summary>
	/// 保留当前文本的区域中与指定模式匹配的文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">需要保留的文本的正则表达式</param>
	/// <param name="options">正则表达式参数</param>
	/// <returns>被保留的符合指定模式的文本组成的字符串。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者保留文本的正则模式 <paramref name="pattern" /> 为空</exception>
	public static string KeepRegex(string text, string pattern, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return KeepRegex(text, ConvertHelper.ToRegex(pattern, options));
	}

	/// <summary>
	/// 保留当前文本的区域中与指定模式匹配的文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">需要保留的文本的正则表达式</param>
	/// <param name="times">需要保留的文本的最大匹配次数，设置为-1则不限制匹配次数。</param>
	/// <param name="options">正则表达式参数</param>
	/// <returns>被保留的符合指定模式的文本组成的字符串。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者保留文本的正则模式 <paramref name="pattern" /> 为空</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">最大匹配次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string KeepRegex(string text, string pattern, int times, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return KeepRegex(text, ConvertHelper.ToRegex(pattern, options), times);
	}

	/// <summary>
	/// 保留当前文本的区域中与指定模式匹配的文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">需要保留的文本的正则表达式</param>
	/// <param name="start">区域的起始位置</param>
	/// <param name="count">区域中字符的个数</param>
	/// <param name="options">正则表达式参数</param>
	/// <returns>被保留的符合指定模式的文本组成的字符串。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者保留文本的正则模式 <paramref name="pattern" /> 为空</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域的起始位置小于0，或者大于当前文本的字符索引的最大值。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">匹配区域中的字符数 <paramref name="count" /> 量小于0，或者大于当前文本从 <paramref name="start" /> 起剩余的字符串数。</exception>
	public static string KeepRegex(string text, string pattern, int start, int count, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return KeepRegex(text, ConvertHelper.ToRegex(pattern, options), start, count);
	}

	/// <summary>
	/// 保留当前文本的区域中与指定模式匹配的文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">需要保留的文本的正则表达式</param>
	/// <param name="start">区域的起始位置</param>
	/// <param name="count">区域中字符的个数</param>
	/// <param name="times">需要保留的文本的最大匹配次数，设置为-1则不限制匹配次数。</param>
	/// <param name="options">正则表达式参数</param>
	/// <returns>被保留的符合指定模式的文本组成的字符串。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者保留文本的正则模式 <paramref name="pattern" /> 为空</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域的起始位置小于0，或者大于当前文本的字符索引的最大值。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">匹配区域中的字符数 <paramref name="count" /> 量小于0，或者大于当前文本从 <paramref name="start" /> 起剩余的字符串数；或者最大匹配次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string KeepRegex(string text, string pattern, int start, int count, int times, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return KeepRegex(text, ConvertHelper.ToRegex(pattern, options), start, count, times);
	}

	/// <summary>
	/// 保留当前文本的区域中与指定模式匹配的文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">需要保留的文本的正则表达式</param>
	/// <param name="times">需要保留的文本的最大匹配次数，设置为-1则不限制匹配次数。</param>
	/// <returns>被保留的符合指定模式的文本组成的字符串。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者保留文本的正则模式 <paramref name="pattern" /> 为空</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">最大匹配次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string KeepRegex(string text, Regex pattern, int times = -1)
	{
		Guard.AssertNotNull(text, "text");
		return KeepRegex(text, pattern, 0, text.Length, times);
	}

	/// <summary>
	/// 保留当前文本的区域中与指定模式匹配的文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">需要保留的文本的正则表达式</param>
	/// <param name="start">区域的起始位置</param>
	/// <param name="count">区域中字符的个数</param>
	/// <param name="times">需要保留的文本的最大匹配次数，设置为-1则不限制匹配次数。</param>
	/// <returns>被保留的符合指定模式的文本组成的字符串。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者保留文本的正则模式 <paramref name="pattern" /> 为空</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域的起始位置小于0，或者大于当前文本的字符索引的最大值。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">匹配区域中的字符数 <paramref name="count" /> 量小于0，或者大于当前文本从 <paramref name="start" /> 起剩余的字符串数；或者最大匹配次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string KeepRegex(string text, Regex pattern, int start, int count, int times = -1)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(pattern, "pattern");
		Guard.AssertGreaterThanOrEqualTo(times, -1, "times");
		StringBuilder buff = new StringBuilder();
		int found = 0;
		Match[] matches = GetMatches(pattern, text, start, count);
		foreach (Match i in matches)
		{
			if (times == -1 || ++found <= times)
			{
				buff.Append(i.Value);
			}
		}
		return buff.ToString();
	}

	/// <summary>
	/// 逆向搜索当前文本的区域中与指定模式匹配的文本，返回匹配文本组成的文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">需要保留的文本的正则表达式</param>
	/// <param name="options">正则表达式参数</param>
	/// <returns>被保留的符合指定模式的文本组成的字符串。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者保留文本的正则模式 <paramref name="pattern" /> 为空</exception>
	public static string KeepLastRegex(string text, string pattern, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return KeepLastRegex(text, ConvertHelper.ToRegex(pattern, options));
	}

	/// <summary>
	/// 逆向搜索当前文本的区域中与指定模式匹配的文本，返回匹配文本组成的文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">需要保留的文本的正则表达式</param>
	/// <param name="times">需要保留的文本的最大匹配次数，设置为-1则不限制匹配次数。</param>
	/// <param name="options">正则表达式参数</param>
	/// <returns>被保留的符合指定模式的文本组成的字符串。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者保留文本的正则模式 <paramref name="pattern" /> 为空</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">最大匹配次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string KeepLastRegex(string text, string pattern, int times, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return KeepLastRegex(text, ConvertHelper.ToRegex(pattern, options), times);
	}

	/// <summary>
	/// 逆向搜索当前文本的区域中与指定模式匹配的文本，返回匹配文本组成的文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">需要保留的文本的正则表达式</param>
	/// <param name="start">区域的起始位置</param>
	/// <param name="count">区域中字符的个数</param>
	/// <param name="options">正则表达式参数</param>
	/// <returns>被保留的符合指定模式的文本组成的字符串。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者保留文本的正则模式 <paramref name="pattern" /> 为空</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域的起始位置小于0，或者大于当前文本的字符索引的最大值。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">匹配区域中的字符数 <paramref name="count" /> 量小于0，或者大于当前文本从 <paramref name="start" /> 起剩余的字符串数。</exception>
	public static string KeepLastRegex(string text, string pattern, int start, int count, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return KeepLastRegex(text, ConvertHelper.ToRegex(pattern, options), start, count);
	}

	/// <summary>
	/// 逆向搜索当前文本的区域中与指定模式匹配的文本，返回匹配文本组成的文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">需要保留的文本的正则表达式</param>
	/// <param name="start">区域的起始位置</param>
	/// <param name="count">区域中字符的个数</param>
	/// <param name="times">需要保留的文本的最大匹配次数，设置为-1则不限制匹配次数。</param>
	/// <param name="options">正则表达式参数</param>
	/// <returns>被保留的符合指定模式的文本组成的字符串。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者保留文本的正则模式 <paramref name="pattern" /> 为空</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域的起始位置小于0，或者大于当前文本的字符索引的最大值。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">匹配区域中的字符数 <paramref name="count" /> 量小于0，或者大于当前文本从 <paramref name="start" /> 起剩余的字符串数；或者最大匹配次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string KeepLastRegex(string text, string pattern, int start, int count, int times, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return KeepLastRegex(text, ConvertHelper.ToRegex(pattern, options), start, count, times);
	}

	/// <summary>
	/// 逆向搜索当前文本的区域中与指定模式匹配的文本，返回匹配文本组成的文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">需要保留的文本的正则表达式</param>
	/// <param name="times">需要保留的文本的最大匹配次数，设置为-1则不限制匹配次数。</param>
	/// <returns>被保留的符合指定模式的文本组成的字符串。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者保留文本的正则模式 <paramref name="pattern" /> 为空</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">最大匹配次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string KeepLastRegex(string text, Regex pattern, int times = -1)
	{
		Guard.AssertNotNull(text, "text");
		return KeepLastRegex(text, pattern, text.Length - 1, text.Length, times);
	}

	/// <summary>
	/// 逆向搜索当前文本的区域中与指定模式匹配的文本，返回匹配文本组成的文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">需要保留的文本的正则表达式</param>
	/// <param name="start">区域的起始位置</param>
	/// <param name="count">区域中字符的个数</param>
	/// <param name="times">需要保留的文本的最大匹配次数，设置为-1则不限制匹配次数。</param>
	/// <returns>被保留的符合指定模式的文本组成的字符串。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者保留文本的正则模式 <paramref name="pattern" /> 为空</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域的起始位置小于0，或者大于当前文本的字符索引的最大值。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">匹配区域中的字符数 <paramref name="count" /> 量小于0，或者大于当前文本从 <paramref name="start" /> 起剩余的字符串数；或者最大匹配次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string KeepLastRegex(string text, Regex pattern, int start, int count, int times = -1)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(pattern, "pattern");
		Guard.AssertGreaterThanOrEqualTo(times, -1, "times");
		StringBuilder buff = new StringBuilder();
		int found = 0;
		foreach (Match i in GetLastMatches(pattern, text, start, count).Reverse())
		{
			if (times == -1 || ++found <= times)
			{
				buff.Append(i.Value);
			}
		}
		return buff.ToString();
	}

	/// <summary>
	/// 在当前文本的区域中逆向查找指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果找到指定的字符返回其索引，否则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static int LastIndexOf(string text, char c, bool ignoreCase = false)
	{
		Guard.AssertNotNull(text, "text");
		return LastIndexOf(text, c, 0, text.Length, ignoreCase);
	}

	/// <summary>
	/// 在当前文本的区域中逆向查找指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="culture">比较字符使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果找到指定的字符返回其索引，否则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static int LastIndexOf(string text, char c, CultureInfo culture, bool ignoreCase = false)
	{
		Guard.AssertNotNull(text, "text");
		return LastIndexOf(text, c, 0, text.Length, culture, ignoreCase);
	}

	/// <summary>
	/// 在当前文本的区域中逆向查找指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="culture">比较字符使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="options">比较字符使用的选项</param>
	/// <returns>如果找到指定的字符返回其索引，否则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static int LastIndexOf(string text, char c, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		return LastIndexOf(text, c, 0, text.Length, culture, options);
	}

	/// <summary>
	/// 在当前文本的区域中逆向查找指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="start">查找区域的起始位置</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果找到指定的字符返回其索引，否则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找区域的起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	public static int LastIndexOf(string text, char c, int start, bool ignoreCase = false)
	{
		return LastIndexOf(text, c, start, CultureInfo.CurrentCulture, ignoreCase);
	}

	/// <summary>
	/// 在当前文本的区域中逆向查找指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="start">查找区域的起始位置</param>
	/// <param name="culture">比较字符使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果找到指定的字符返回其索引，否则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找区域的起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	public static int LastIndexOf(string text, char c, int start, CultureInfo culture, bool ignoreCase = false)
	{
		return LastIndexOf(text, c, start, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 在当前文本的区域中逆向查找指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="start">查找区域的起始位置</param>
	/// <param name="culture">比较字符使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="options">比较字符使用的选项</param>
	/// <returns>如果找到指定的字符返回其索引，否则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找区域的起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	public static int LastIndexOf(string text, char c, int start, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertIndexRange(start, 0, text.Length - 1, "start");
		return ObjectHelper.IfNull(culture, CultureInfo.CurrentCulture).CompareInfo.LastIndexOf(text, c, start, options);
	}

	/// <summary>
	/// 在当前文本的区域中逆向查找指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="start">查找区域的起始位置</param>
	/// <param name="count">查找区域中的字符数量</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果找到指定的字符返回其索引，否则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找区域的起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找区域的字符数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始字符串中逆向剩余的字符数量。</exception>
	public static int LastIndexOf(string text, char c, int start, int count, bool ignoreCase = false)
	{
		return LastIndexOf(text, c, start, count, CultureInfo.CurrentCulture, ignoreCase);
	}

	/// <summary>
	/// 在当前文本的区域中逆向查找指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="start">查找区域的起始位置</param>
	/// <param name="count">查找区域中的字符数量</param>
	/// <param name="culture">比较字符使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果找到指定的字符返回其索引，否则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找区域的起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找区域的字符数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始字符串中逆向剩余的字符数量。</exception>
	public static int LastIndexOf(string text, char c, int start, int count, CultureInfo culture, bool ignoreCase = false)
	{
		return LastIndexOf(text, c, start, count, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 在当前文本的区域中逆向查找指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="start">查找区域的起始位置</param>
	/// <param name="count">查找区域中的字符数量</param>
	/// <param name="culture">比较字符使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="options">比较字符使用的选项</param>
	/// <returns>如果找到指定的字符返回其索引，否则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找区域的起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找区域的字符数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始字符串中逆向剩余的字符数量。</exception>
	public static int LastIndexOf(string text, char c, int start, int count, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertIndexRange(start, 0, text.Length - 1, "start");
		Guard.AssertBetween(count, 0, text.Length - start, "count");
		return ObjectHelper.IfNull(culture, CultureInfo.CurrentCulture).CompareInfo.LastIndexOf(text, c, start, count, options);
	}

	/// <summary>
	/// 在当前文本的区域中逆向查找指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="s">查找的字符串</param>
	/// <param name="ignoreCase">比较字符是否区分大小写</param>
	/// <returns>如果找到指定的字符串返回其索引，否则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者查找的字符串为空。</exception>
	public static int LastIndexOf(string text, string s, bool ignoreCase = false)
	{
		Guard.AssertNotNull(text, "text");
		return LastIndexOf(text, s, 0, text.Length, ignoreCase);
	}

	/// <summary>
	/// 在当前文本的区域中逆向查找指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="s">查找的字符串</param>
	/// <param name="culture">比较字符使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="ignoreCase">比较字符是否区分大小写</param>
	/// <returns>如果找到指定的字符串返回其索引，否则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者查找的字符串为空。</exception>
	public static int LastIndexOf(string text, string s, CultureInfo culture, bool ignoreCase = false)
	{
		Guard.AssertNotNull(text, "text");
		return LastIndexOf(text, s, 0, text.Length, culture, ignoreCase);
	}

	/// <summary>
	/// 在当前文本的区域中逆向查找指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="s">查找的字符串</param>
	/// <param name="culture">比较字符使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="options">比较字符使用的选项</param>
	/// <returns>如果找到指定的字符串返回其索引，否则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者查找的字符串为空。</exception>
	public static int LastIndexOf(string text, string s, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		return LastIndexOf(text, s, 0, text.Length, culture, options);
	}

	/// <summary>
	/// 在当前文本的区域中逆向查找指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="s">查找的字符串</param>
	/// <param name="start">查找区域的起始位置</param>
	/// <param name="ignoreCase">比较字符是否区分大小写</param>
	/// <returns>如果找到指定的字符串返回其索引，否则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者查找的字符串为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找区域的起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	public static int LastIndexOf(string text, string s, int start, bool ignoreCase = false)
	{
		return LastIndexOf(text, s, start, CultureInfo.CurrentCulture, ignoreCase);
	}

	/// <summary>
	/// 在当前文本的区域中逆向查找指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="s">查找的字符串</param>
	/// <param name="start">查找区域的起始位置</param>
	/// <param name="culture">比较字符使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="ignoreCase">比较字符是否区分大小写</param>
	/// <returns>如果找到指定的字符串返回其索引，否则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者查找的字符串为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找区域的起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	public static int LastIndexOf(string text, string s, int start, CultureInfo culture, bool ignoreCase = false)
	{
		return LastIndexOf(text, s, start, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 在当前文本的区域中逆向查找指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="s">查找的字符串</param>
	/// <param name="start">查找区域的起始位置</param>
	/// <param name="culture">比较字符使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="options">比较字符使用的选项</param>
	/// <returns>如果找到指定的字符串返回其索引，否则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者查找的字符串为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找区域的起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	public static int LastIndexOf(string text, string s, int start, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(s, "s");
		Guard.AssertIndexRange(start, 0, text.Length - 1, "start");
		return ObjectHelper.IfNull(culture, CultureInfo.CurrentCulture).CompareInfo.LastIndexOf(text, s, start, options);
	}

	/// <summary>
	/// 在当前文本的区域中逆向查找指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="s">查找的字符串</param>
	/// <param name="start">查找区域的起始位置</param>
	/// <param name="count">查找区域中的字符数量</param>
	/// <param name="ignoreCase">比较字符是否区分大小写</param>
	/// <returns>如果找到指定的字符串返回其索引，否则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者查找的字符串为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找区域的起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找区域的字符数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始字符串中逆向剩余的字符数量。</exception>
	public static int LastIndexOf(string text, string s, int start, int count, bool ignoreCase = false)
	{
		return LastIndexOf(text, s, start, count, CultureInfo.CurrentCulture, ignoreCase);
	}

	/// <summary>
	/// 在当前文本的区域中逆向查找指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="s">查找的字符串</param>
	/// <param name="start">查找区域的起始位置</param>
	/// <param name="count">查找区域中的字符数量</param>
	/// <param name="culture">比较字符使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="ignoreCase">比较字符是否区分大小写</param>
	/// <returns>如果找到指定的字符串返回其索引，否则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者查找的字符串为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找区域的起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找区域的字符数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始字符串中逆向剩余的字符数量。</exception>
	public static int LastIndexOf(string text, string s, int start, int count, CultureInfo culture, bool ignoreCase = false)
	{
		return LastIndexOf(text, s, start, count, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 在当前文本的区域中逆向查找指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="s">查找的字符串</param>
	/// <param name="start">查找区域的起始位置</param>
	/// <param name="count">查找区域中的字符数量</param>
	/// <param name="culture">比较字符使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="options">比较字符使用的选项</param>
	/// <returns>如果找到指定的字符串返回其索引，否则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者查找的字符串为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">查找区域的起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">查找区域的字符数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始字符串中逆向剩余的字符数量。</exception>
	public static int LastIndexOf(string text, string s, int start, int count, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(s, "s");
		Guard.AssertIndexRange(start, 0, text.Length - 1, "start");
		Guard.AssertBetween(count, 0, text.Length - start, "count");
		return ObjectHelper.IfNull(culture, CultureInfo.CurrentCulture).CompareInfo.LastIndexOf(text, s, start, count, options);
	}

	/// <summary>
	/// 在当前可变文本中逆向查找字符的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果在可变文本中找到字符返回字符的位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	public static int LastIndexOf(StringBuilder text, char c, bool ignoreCase = false)
	{
		return LastIndexOf(text, c, CultureInfo.CurrentCulture, ignoreCase);
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
	public static int LastIndexOf(StringBuilder text, char c, CultureInfo culture, bool ignoreCase = false)
	{
		return LastIndexOf(text, c, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static int LastIndexOf(StringBuilder text, char c, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "string builder");
		return LastIndexOf(text, c, 0, text.Length, culture, options);
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
	public static int LastIndexOf(StringBuilder text, char c, int start, bool ignoreCase = false)
	{
		return LastIndexOf(text, c, start, CultureInfo.CurrentCulture, ignoreCase);
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
	public static int LastIndexOf(StringBuilder text, char c, int start, CultureInfo culture, bool ignoreCase = false)
	{
		return LastIndexOf(text, c, start, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static int LastIndexOf(StringBuilder text, char c, int start, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "string builder");
		Guard.AssertIndexRange(start, 0, text.Length - 1, "start");
		return LastIndexOf(text, c, start, text.Length - start, culture, options);
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
	public static int LastIndexOf(StringBuilder text, char c, int start, int count, bool ignoreCase = false)
	{
		return LastIndexOf(text, c, start, count, CultureInfo.CurrentCulture, ignoreCase);
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
	public static int LastIndexOf(StringBuilder text, char c, int start, int count, CultureInfo culture, bool ignoreCase = false)
	{
		return LastIndexOf(text, c, start, count, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static int LastIndexOf(StringBuilder text, char c, int start, int count, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "string builder");
		Guard.AssertIndexRange(start, 0, text.Length - 1, "start");
		Guard.AssertBetween(count, 0, start + 1, "count");
		int end = start - count;
		for (int i = start; i > end; i--)
		{
			if (IsEqualTo(text[i], c, culture, options))
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
	public static int LastIndexOf(StringBuilder text, string searching, bool ignoreCase = false)
	{
		return LastIndexOf(text, searching, CultureInfo.CurrentCulture, ignoreCase);
	}

	/// <summary>
	/// 在当前可变文本中逆向查找字符串的位置
	/// </summary>
	/// <param name="text">当前可变文本</param>
	/// <param name="searching">查找的字符串</param>
	/// <param name="comparison">比较字符时的选项</param>
	/// <returns>如果在可变文本中找到字符串返回该字符串的起始位置，如果未找到则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变文本为空。</exception>
	public static int LastIndexOf(StringBuilder text, string searching, StringComparison comparison)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(searching, "searching text");
		return LastIndexOf(text, searching, 0, text.Length, comparison);
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
	public static int LastIndexOf(StringBuilder text, string searching, CultureInfo culture, bool ignoreCase = false)
	{
		return LastIndexOf(text, searching, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static int LastIndexOf(StringBuilder text, string searching, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(searching, "searching text");
		return LastIndexOf(text, searching, 0, text.Length, culture, options);
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
	public static int LastIndexOf(StringBuilder text, string searching, int start, bool ignoreCase = false)
	{
		return LastIndexOf(text, searching, start, CultureInfo.CurrentCulture, ignoreCase);
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
	public static int LastIndexOf(StringBuilder text, string searching, int start, StringComparison comparison)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(searching, "searching text");
		Guard.AssertIndexRange(start, 0, text.Length - 1, "start");
		return LastIndexOf(text, searching, start, text.Length - start, comparison);
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
	public static int LastIndexOf(StringBuilder text, string searching, int start, CultureInfo culture, bool ignoreCase = false)
	{
		return LastIndexOf(text, searching, start, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static int LastIndexOf(StringBuilder text, string searching, int start, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(searching, "searching text");
		Guard.AssertIndexRange(start, 0, text.Length - 1, "start");
		return IndexOf(text, searching, start, text.Length - start, culture, options);
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
	public static int LastIndexOf(StringBuilder text, string searching, int start, int count, bool ignoreCase = false)
	{
		return LastIndexOf(text, searching, start, count, CultureInfo.CurrentCulture, ignoreCase);
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
	public static int LastIndexOf(StringBuilder text, string searching, int start, int count, StringComparison comparison)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(searching, "searching text");
		Guard.AssertIndexRange(start, 0, text.Length - 1, "start");
		Guard.AssertBetween(count, 0, text.Length + 1, "count");
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
					if (!IsEqualTo(searching[i], text[start - searching.Length + 1 + i], comparison))
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
	public static int LastIndexOf(StringBuilder text, string searching, int start, int count, CultureInfo culture, bool ignoreCase = false)
	{
		return LastIndexOf(text, searching, start, count, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static int LastIndexOf(StringBuilder text, string searching, int start, int count, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(searching, "searching text");
		Guard.AssertIndexRange(start, 0, text.Length - 1, "start");
		Guard.AssertBetween(count, 0, text.Length + 1, "count");
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
					if (!IsEqualTo(searching[i], text[start - searching.Length + 1 + i], culture, options))
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
	/// 获取当前文本左侧指定长度的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="count">从左侧获取的字符数量</param>
	/// <returns>截取的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">获取的字符数量 <paramref name="count" /> 小于0，或者大于当前文本的字符数量。</exception>
	public static string Left(string text, int count)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertBetween(count, 0, text.Length, "count");
		return text.Substring(0, count);
	}

	/// <summary>
	/// 将当前文本中左侧指定数量的字符替换为遮蔽字符后返回。
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="count">替换字符的数量</param>
	/// <param name="mask">遮蔽字符，默认是'*'</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换的字符数量 <paramref name="count" /> 小于0，或者大于当前文本的字符个数。</exception>
	public static string MaskLeft(string text, int count, char mask = '*')
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertBetween(count, 0, text.Length, "count");
		StringBuilder buff = new StringBuilder(text.Length);
		for (int i = 0; i < count; i++)
		{
			buff.Append(mask);
		}
		buff.Append(text.Substring(count));
		return buff.ToString();
	}

	/// <summary>
	/// 将当前文本中右侧指定数量的字符替换为遮蔽字符后返回。
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="count">替换字符的数量</param>
	/// <param name="mask">遮蔽字符，默认是'*'</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换的字符数量 <paramref name="count" /> 小于0，或者大于当前文本的字符个数。</exception>
	public static string MaskRight(string text, int count, char mask = '*')
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertBetween(count, 0, text.Length, "count");
		StringBuilder buff = new StringBuilder(text.Length);
		buff.Append(text.Substring(0, text.Length - count));
		for (int i = 0; i < count; i++)
		{
			buff.Append(mask);
		}
		return buff.ToString();
	}

	/// <summary>
	/// 转义当前字符串中所有的正则特殊字符
	/// </summary>
	/// <param name="pattern">当前字符串</param>
	/// <returns>处理后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static string RegexEscape(string pattern)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return Regex.Escape(pattern);
	}

	/// <summary>
	/// 取消转义当前字符串中所有的正则特殊字符。
	/// </summary>
	/// <param name="pattern">当前字符串</param>
	/// <returns>处理后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static string RegexUnescape(string pattern)
	{
		Guard.AssertNotNull(pattern, "s");
		return Regex.Unescape(pattern);
	}

	/// <summary>
	/// 在当前文本内移除出现指定次数以内的目标文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标文本</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>移除后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者移除的目标字符串 <paramref name="target" /> 为空。</exception>
	public static string Remove(string text, string target, bool ignoreCase = false)
	{
		return Replace(text, target, null, -1, ignoreCase);
	}

	/// <summary>
	/// 在当前文本内移除出现指定次数以内的目标文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标文本</param>
	/// <param name="comparison">字符串比较方式</param>
	/// <returns>移除后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者移除的目标字符串 <paramref name="target" /> 为空。</exception>
	public static string Remove(string text, string target, StringComparison comparison)
	{
		return Replace(text, target, null, -1, comparison);
	}

	/// <summary>
	/// 在当前文本内移除出现指定次数以内的目标文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标文本</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>移除后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者移除的目标字符串 <paramref name="target" /> 为空。</exception>
	public static string Remove(string text, string target, CultureInfo culture, bool ignoreCase = false)
	{
		return Replace(text, target, null, -1, culture, ignoreCase);
	}

	/// <summary>
	/// 在当前文本内移除出现指定次数以内的目标文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标文本</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="options">比较字符时的选项</param>
	/// <returns>移除后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者移除的目标字符串 <paramref name="target" /> 为空。</exception>
	public static string Remove(string text, string target, CultureInfo culture, CompareOptions options)
	{
		return Replace(text, target, null, -1, culture, options);
	}

	/// <summary>
	/// 在当前文本内移除出现指定次数以内的目标文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标文本</param>
	/// <param name="times">匹配的次数，设置为-1则不限制匹配次数</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>移除后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者移除的目标字符串 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">匹配次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string Remove(string text, string target, int times, bool ignoreCase = false)
	{
		return Replace(text, target, null, times, ignoreCase);
	}

	/// <summary>
	/// 在当前文本内移除出现指定次数以内的目标文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标文本</param>
	/// <param name="times">匹配的次数，设置为-1则不限制匹配次数</param>
	/// <param name="comparison">字符串比较方式</param>
	/// <returns>移除后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者移除的目标字符串 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">匹配次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string Remove(string text, string target, int times, StringComparison comparison)
	{
		return Replace(text, target, null, times, comparison);
	}

	/// <summary>
	/// 在当前文本内移除出现指定次数以内的目标文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标文本</param>
	/// <param name="times">匹配的次数，设置为-1则不限制匹配次数</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>移除后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者移除的目标字符串 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">匹配次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string Remove(string text, string target, int times, CultureInfo culture, bool ignoreCase = false)
	{
		return Replace(text, target, null, times, culture, ignoreCase);
	}

	/// <summary>
	/// 在当前文本内移除出现指定次数以内的目标文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标文本</param>
	/// <param name="times">匹配的次数，设置为-1则不限制匹配次数</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="options">比较字符时的选项</param>
	/// <returns>移除后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者移除的目标字符串 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">匹配次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string Remove(string text, string target, int times, CultureInfo culture, CompareOptions options)
	{
		return Replace(text, target, null, times, culture, options);
	}

	/// <summary>
	/// 在当前文本的区域内移除出现指定次数以内的目标文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标文本</param>
	/// <param name="start">区域起始位置</param>
	/// <param name="count">区域内字符的数量</param>
	/// <param name="times">匹配的次数，设置为-1则不限制匹配次数</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>移除后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者移除的目标字符串 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始剩余的字符数量；匹配次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string Remove(string text, string target, int start, int count, int times, bool ignoreCase = false)
	{
		return Replace(text, target, null, start, count, times, ignoreCase);
	}

	/// <summary>
	/// 在当前文本的区域内移除出现指定次数以内的目标文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标文本</param>
	/// <param name="start">区域起始位置</param>
	/// <param name="count">区域内字符的数量</param>
	/// <param name="times">匹配的次数，设置为-1则不限制匹配次数</param>
	/// <param name="comparison">字符串比较方式</param>
	/// <returns>移除后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者移除的目标字符串 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始剩余的字符数量；匹配次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string Remove(string text, string target, int start, int count, int times, StringComparison comparison)
	{
		return Replace(text, target, null, start, count, times, comparison);
	}

	/// <summary>
	/// 在当前文本的区域内移除出现指定次数以内的目标文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标文本</param>
	/// <param name="start">区域起始位置</param>
	/// <param name="count">区域内字符的数量</param>
	/// <param name="times">匹配的次数，设置为-1则不限制匹配次数</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>移除后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者移除的目标字符串 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始剩余的字符数量；匹配次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string Remove(string text, string target, int start, int count, int times, CultureInfo culture, bool ignoreCase = false)
	{
		return Replace(text, target, null, start, count, times, culture, ignoreCase);
	}

	/// <summary>
	/// 在当前文本的区域内移除出现指定次数以内的目标文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标文本</param>
	/// <param name="start">区域起始位置</param>
	/// <param name="count">区域内字符的数量</param>
	/// <param name="times">匹配的次数，设置为-1则不限制匹配次数</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="options">比较字符时的选项</param>
	/// <returns>移除后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者移除的目标字符串 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始剩余的字符数量；匹配次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string Remove(string text, string target, int start, int count, int times, CultureInfo culture, CompareOptions options)
	{
		return Replace(text, target, null, start, count, times, culture, options);
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
	public static string Remove(Regex regex, string text, int times = -1)
	{
		return ReplaceText(regex, text, string.Empty, times);
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
	public static string Remove(Regex regex, string text, int start, int count, int times = -1)
	{
		return ReplaceText(regex, text, string.Empty, start, count, times);
	}

	/// <summary>
	/// 在当前文本内逆向移除出现的目标文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标文本</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>移除后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者移除的目标字符串 <paramref name="target" /> 为空。</exception>
	public static string RemoveLast(string text, string target, bool ignoreCase = false)
	{
		return ReplaceLast(text, target, null, -1, ignoreCase);
	}

	/// <summary>
	/// 在当前文本内逆向移除出现的目标文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标文本</param>
	/// <param name="comparison">字符串比较方式</param>
	/// <returns>移除后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者移除的目标字符串 <paramref name="target" /> 为空。</exception>
	public static string RemoveLast(string text, string target, StringComparison comparison)
	{
		return ReplaceLast(text, target, null, -1, comparison);
	}

	/// <summary>
	/// 在当前文本内逆向移除出现的目标文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标文本</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>移除后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者移除的目标字符串 <paramref name="target" /> 为空。</exception>
	public static string RemoveLast(string text, string target, CultureInfo culture, bool ignoreCase = false)
	{
		return ReplaceLast(text, target, null, -1, culture, ignoreCase);
	}

	/// <summary>
	/// 在当前文本内逆向移除出现的目标文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标文本</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="options">比较字符时的选项</param>
	/// <returns>移除后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者移除的目标字符串 <paramref name="target" /> 为空。</exception>
	public static string RemoveLast(string text, string target, CultureInfo culture, CompareOptions options)
	{
		return ReplaceLast(text, target, null, -1, culture, options);
	}

	/// <summary>
	/// 在当前文本的区域内逆向移除出现指定次数以内的目标文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标文本</param>
	/// <param name="times">匹配的次数，设置为-1则不限制匹配次数</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>移除后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者移除的目标字符串 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">匹配次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveLast(string text, string target, int times, bool ignoreCase = false)
	{
		return ReplaceLast(text, target, null, times, ignoreCase);
	}

	/// <summary>
	/// 在当前文本的区域内逆向移除出现指定次数以内的目标文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标文本</param>
	/// <param name="times">匹配的次数，设置为-1则不限制匹配次数</param>
	/// <param name="comparison">字符串比较方式</param>
	/// <returns>移除后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者移除的目标字符串 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">匹配次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveLast(string text, string target, int times, StringComparison comparison)
	{
		return ReplaceLast(text, target, null, times, comparison);
	}

	/// <summary>
	/// 在当前文本的区域内逆向移除出现指定次数以内的目标文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标文本</param>
	/// <param name="times">匹配的次数，设置为-1则不限制匹配次数</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>移除后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者移除的目标字符串 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">匹配次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveLast(string text, string target, int times, CultureInfo culture, bool ignoreCase = false)
	{
		return ReplaceLast(text, target, null, times, culture, ignoreCase);
	}

	/// <summary>
	/// 在当前文本的区域内逆向移除出现指定次数以内的目标文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标文本</param>
	/// <param name="times">匹配的次数，设置为-1则不限制匹配次数</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="options">比较字符时的选项</param>
	/// <returns>移除后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者移除的目标字符串 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">匹配次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveLast(string text, string target, int times, CultureInfo culture, CompareOptions options)
	{
		return ReplaceLast(text, target, null, times, culture, options);
	}

	/// <summary>
	/// 在当前文本的区域内逆向移除出现指定次数以内的目标文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标文本</param>
	/// <param name="start">区域起始位置</param>
	/// <param name="count">区域内字符的数量</param>
	/// <param name="times">匹配的次数，设置为-1则不限制匹配次数</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>移除后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者移除的目标字符串 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始逆向剩余的字符数量；匹配次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveLast(string text, string target, int start, int count, int times, bool ignoreCase = false)
	{
		return ReplaceLast(text, target, null, start, count, times, ignoreCase);
	}

	/// <summary>
	/// 在当前文本的区域内逆向移除出现指定次数以内的目标文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标文本</param>
	/// <param name="start">区域起始位置</param>
	/// <param name="count">区域内字符的数量</param>
	/// <param name="times">匹配的次数，设置为-1则不限制匹配次数</param>
	/// <param name="comparison">字符串比较方式</param>
	/// <returns>移除后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者移除的目标字符串 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始逆向剩余的字符数量；匹配次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveLast(string text, string target, int start, int count, int times, StringComparison comparison)
	{
		return ReplaceLast(text, target, null, start, count, times, comparison);
	}

	/// <summary>
	/// 在当前文本的区域内逆向移除出现指定次数以内的目标文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标文本</param>
	/// <param name="start">区域起始位置</param>
	/// <param name="count">区域内字符的数量</param>
	/// <param name="times">匹配的次数，设置为-1则不限制匹配次数</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>移除后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者移除的目标字符串 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始逆向剩余的字符数量；匹配次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveLast(string text, string target, int start, int count, int times, CultureInfo culture, bool ignoreCase = false)
	{
		return ReplaceLast(text, target, null, start, count, times, culture, ignoreCase);
	}

	/// <summary>
	/// 在当前文本的区域内逆向移除出现指定次数以内的目标文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标文本</param>
	/// <param name="start">区域起始位置</param>
	/// <param name="count">区域内字符的数量</param>
	/// <param name="times">匹配的次数，设置为-1则不限制匹配次数</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="options">比较字符时的选项</param>
	/// <returns>移除后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者移除的目标字符串 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始逆向剩余的字符数量；匹配次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveLast(string text, string target, int start, int count, int times, CultureInfo culture, CompareOptions options)
	{
		return ReplaceLast(text, target, null, start, count, times, culture, options);
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
	public static string RemoveLast(Regex regex, string text, int times = -1)
	{
		return ReplaceLastText(regex, text, string.Empty, times);
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
	public static string RemoveLast(Regex regex, string text, int start, int count, int times = -1)
	{
		return ReplaceLastText(regex, text, string.Empty, start, count, times);
	}

	/// <summary>
	/// 移除当前文本区域中的目标字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标字符</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static string RemoveChar(string text, char target, bool ignoreCase = false)
	{
		return RemoveChar(text, target, -1, ignoreCase);
	}

	/// <summary>
	/// 移除当前文本区域中的目标字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标字符</param>
	/// <param name="culture">字符比较时使用的区域信息，默认为当前线程的区域信息。</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static string RemoveChar(string text, char target, CultureInfo culture, bool ignoreCase = false)
	{
		return RemoveChar(text, target, -1, culture, ignoreCase);
	}

	/// <summary>
	/// 移除当前文本区域中的目标字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标字符</param>
	/// <param name="culture">字符比较时使用的区域信息，默认为当前线程的区域信息。</param>
	/// <param name="options">字符比较时的选项</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static string RemoveChar(string text, char target, CultureInfo culture, CompareOptions options)
	{
		return RemoveChar(text, target, -1, culture, options);
	}

	/// <summary>
	/// 移除当前文本区域中的目标字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标字符</param>
	/// <param name="times">移除指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveChar(string text, char target, int times, bool ignoreCase = false)
	{
		Guard.AssertNotNull(text, "text");
		return RemoveChar(text, target, 0, text.Length, times, ignoreCase);
	}

	/// <summary>
	/// 移除当前文本区域中的目标字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标字符</param>
	/// <param name="times">移除指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="culture">字符比较时使用的区域信息，默认为当前线程的区域信息。</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveChar(string text, char target, int times, CultureInfo culture, bool ignoreCase = false)
	{
		Guard.AssertNotNull(text, "text");
		return RemoveChar(text, target, 0, text.Length, times, culture, ignoreCase);
	}

	/// <summary>
	/// 移除当前文本区域中的目标字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标字符</param>
	/// <param name="times">移除指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="culture">字符比较时使用的区域信息，默认为当前线程的区域信息。</param>
	/// <param name="options">字符比较时的选项</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveChar(string text, char target, int times, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		return RemoveChar(text, target, 0, text.Length, times, culture, options);
	}

	/// <summary>
	/// 移除当前文本区域中的目标字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标字符</param>
	/// <param name="start">区域的起始位置</param>
	/// <param name="count">区域中的字符数量</param>
	/// <param name="times">移除指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始剩余的字符数量；移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveChar(string text, char target, int start, int count, int times, bool ignoreCase = false)
	{
		return RemoveChar(text, new char[1] { target }, start, count, times, CultureInfo.CurrentCulture, ignoreCase);
	}

	/// <summary>
	/// 移除当前文本区域中的目标字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标字符</param>
	/// <param name="start">区域的起始位置</param>
	/// <param name="count">区域中的字符数量</param>
	/// <param name="times">移除指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="culture">字符比较时使用的区域信息，默认为当前线程的区域信息。</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始剩余的字符数量；移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveChar(string text, char target, int start, int count, int times, CultureInfo culture, bool ignoreCase = false)
	{
		return RemoveChar(text, new char[1] { target }, start, count, times, culture, ignoreCase);
	}

	/// <summary>
	/// 移除当前文本区域中的目标字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标字符</param>
	/// <param name="start">区域的起始位置</param>
	/// <param name="count">区域中的字符数量</param>
	/// <param name="times">移除指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="culture">字符比较时使用的区域信息，默认为当前线程的区域信息。</param>
	/// <param name="options">字符比较时的选项</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始剩余的字符数量；移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveChar(string text, char target, int start, int count, int times, CultureInfo culture, CompareOptions options)
	{
		return RemoveChar(text, new char[1] { target }, start, count, times, culture, options);
	}

	/// <summary>
	/// 移除当前文本区域中的目标字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="targets">移除的目标字符数组</param>
	/// <param name="ignoreCase">字符比较是否区分大小写</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；移除的目标字符数组 <paramref name="targets" /> 为空。</exception>
	public static string RemoveChar(string text, char[] targets, bool ignoreCase = false)
	{
		return RemoveChar(text, targets, -1, ignoreCase);
	}

	/// <summary>
	/// 移除当前文本区域中的目标字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="targets">移除的目标字符数组</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="ignoreCase">字符比较是否区分大小写</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；移除的目标字符数组 <paramref name="targets" /> 为空。</exception>
	public static string RemoveChar(string text, char[] targets, CultureInfo culture, bool ignoreCase = false)
	{
		return RemoveChar(text, targets, -1, culture, ignoreCase);
	}

	/// <summary>
	/// 移除当前文本区域中的目标字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="targets">移除的目标字符数组</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="options">比较字符是否区分大小写</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；移除的目标字符数组 <paramref name="targets" /> 为空。</exception>
	public static string RemoveChar(string text, char[] targets, CultureInfo culture, CompareOptions options)
	{
		return RemoveChar(text, targets, -1, culture, options);
	}

	/// <summary>
	/// 移除当前文本区域中的目标字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="targets">移除的目标字符数组</param>
	/// <param name="times">移除指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="ignoreCase">字符比较是否区分大小写</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；移除的目标字符数组 <paramref name="targets" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveChar(string text, char[] targets, int times, bool ignoreCase = false)
	{
		Guard.AssertNotNull(text, "text");
		return RemoveChar(text, targets, 0, text.Length, times, ignoreCase);
	}

	/// <summary>
	/// 移除当前文本中的目标字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="targets">移除的目标字符数组</param>
	/// <param name="times">移除指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="ignoreCase">字符比较是否区分大小写</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；移除的目标字符数组 <paramref name="targets" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveChar(string text, char[] targets, int times, CultureInfo culture, bool ignoreCase = false)
	{
		Guard.AssertNotNull(text, "text");
		return RemoveChar(text, targets, 0, text.Length, times, culture, ignoreCase);
	}

	/// <summary>
	/// 移除当前文本中的目标字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="targets">移除的目标字符数组</param>
	/// <param name="times">移除指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="options">比较字符是否区分大小写</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；移除的目标字符数组 <paramref name="targets" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveChar(string text, char[] targets, int times, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		return RemoveChar(text, targets, 0, text.Length, times, culture, options);
	}

	/// <summary>
	/// 移除当前文本中的目标字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="targets">移除的目标字符数组</param>
	/// <param name="start">区域的起始位置</param>
	/// <param name="count">区域中的字符数量</param>
	/// <param name="times">移除指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="ignoreCase">字符比较是否区分大小写</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；移除的目标字符数组 <paramref name="targets" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始剩余的字符数量；移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveChar(string text, char[] targets, int start, int count, int times, bool ignoreCase = false)
	{
		return RemoveChar(text, targets, start, count, times, CultureInfo.CurrentCulture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 移除当前文本区域中的目标字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="targets">移除的目标字符数组</param>
	/// <param name="start">区域的起始位置</param>
	/// <param name="count">区域中的字符数量</param>
	/// <param name="times">移除指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="ignoreCase">字符比较是否区分大小写</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；移除的目标字符数组 <paramref name="targets" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始剩余的字符数量；移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveChar(string text, char[] targets, int start, int count, int times, CultureInfo culture, bool ignoreCase = false)
	{
		return RemoveChar(text, targets, start, count, times, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 移除当前文本区域中的目标字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="targets">移除的目标字符数组</param>
	/// <param name="start">区域的起始位置</param>
	/// <param name="count">区域中的字符数量</param>
	/// <param name="times">移除指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="options">比较字符是否区分大小写</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；移除的目标字符数组 <paramref name="targets" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始剩余的字符数量；移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveChar(string text, char[] targets, int start, int count, int times, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(targets, "targets");
		return RemoveChar(text, (char x, int i) => targets.Any((char c) => IsEqualTo(x, c, culture, options)), start, count, times);
	}

	/// <summary>
	/// 移除当前文本区域中满足条件的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="predicate">文本字符筛选条件</param>
	/// <param name="times">移除字符的次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者字符筛选条件 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveChar(string text, Func<char, bool> predicate, int times = -1)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(predicate, "predicate");
		return RemoveChar(text, (char x, int i) => predicate(x), 0, text.Length, times);
	}

	/// <summary>
	/// 移除当前文本区域中满足条件的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="predicate">文本字符筛选条件</param>
	/// <param name="start">区域的起始位置</param>
	/// <param name="count">区域中的字符数量</param>
	/// <param name="times">移除字符的次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者字符筛选条件 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始剩余的字符数量；移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveChar(string text, Func<char, bool> predicate, int start, int count, int times = -1)
	{
		Guard.AssertNotNull(predicate, "predicate");
		return RemoveChar(text, (char x, int i) => predicate(x), start, count, times);
	}

	/// <summary>
	/// 移除当前文本区域中满足条件的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="predicate">文本字符筛选条件</param>
	/// <param name="times">移除字符的次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者字符筛选条件 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveChar(string text, Func<char, int, bool> predicate, int times = -1)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(predicate, "predicate");
		return RemoveChar(text, predicate, 0, text.Length, times);
	}

	/// <summary>
	/// 移除当前文本区域中满足条件的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="predicate">文本字符筛选条件</param>
	/// <param name="start">区域的起始位置</param>
	/// <param name="count">区域中的字符数量</param>
	/// <param name="times">移除字符的次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者字符筛选条件 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始剩余的字符数量；移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveChar(string text, Func<char, int, bool> predicate, int start, int count, int times = -1)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertIndexRange(start, 0, text.Length - 1, "start");
		Guard.AssertBetween(count, 0, text.Length - start, "count");
		Guard.AssertGreaterThanOrEqualTo(times, -1, "times");
		StringBuilder buff = new StringBuilder();
		buff.Append(text.Substring(0, start));
		int end = start + count;
		int matched = 0;
		for (int i = start; i < end; i++)
		{
			if (!predicate(text[i], i) || (times != -1 && ++matched > times))
			{
				buff.Append(text[i]);
			}
		}
		buff.Append(text.Substring(end));
		return buff.ToString();
	}

	/// <summary>
	/// 逆向移除当前文本中的目标字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标字符</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static string RemoveLastChar(string text, char target, bool ignoreCase = false)
	{
		return RemoveLastChar(text, new char[1] { target }, -1, CultureInfo.CurrentCulture, ignoreCase);
	}

	/// <summary>
	/// 逆向移除当前文本中的目标字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标字符</param>
	/// <param name="culture">字符比较时使用的区域信息，默认为当前线程的区域信息。</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static string RemoveLastChar(string text, char target, CultureInfo culture, bool ignoreCase = false)
	{
		return RemoveLastChar(text, new char[1] { target }, -1, culture, ignoreCase);
	}

	/// <summary>
	/// 逆向移除当前文本中的目标字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标字符</param>
	/// <param name="culture">字符比较时使用的区域信息，默认为当前线程的区域信息。</param>
	/// <param name="options">字符比较时的选项</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static string RemoveLastChar(string text, char target, CultureInfo culture, CompareOptions options)
	{
		return RemoveLastChar(text, new char[1] { target }, -1, culture, options);
	}

	/// <summary>
	/// 逆向移除当前文本中的目标字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标字符</param>
	/// <param name="times">移除指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveLastChar(string text, char target, int times, bool ignoreCase = false)
	{
		return RemoveLastChar(text, new char[1] { target }, times, CultureInfo.CurrentCulture, ignoreCase);
	}

	/// <summary>
	/// 逆向移除当前文本中的目标字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标字符</param>
	/// <param name="times">移除指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="culture">字符比较时使用的区域信息，默认为当前线程的区域信息。</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveLastChar(string text, char target, int times, CultureInfo culture, bool ignoreCase = false)
	{
		return RemoveLastChar(text, new char[1] { target }, times, culture, ignoreCase);
	}

	/// <summary>
	/// 逆向移除当前文本中的目标字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标字符</param>
	/// <param name="times">移除指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="culture">字符比较时使用的区域信息，默认为当前线程的区域信息。</param>
	/// <param name="options">字符比较时的选项</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveLastChar(string text, char target, int times, CultureInfo culture, CompareOptions options)
	{
		return RemoveLastChar(text, new char[1] { target }, times, culture, options);
	}

	/// <summary>
	/// 逆向移除当前文本区域中的目标字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标字符</param>
	/// <param name="start">区域的起始位置</param>
	/// <param name="count">区域中的字符数量</param>
	/// <param name="times">移除指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始剩余的字符数量；移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveLastChar(string text, char target, int start, int count, int times, bool ignoreCase = false)
	{
		return RemoveLastChar(text, new char[1] { target }, start, count, times, CultureInfo.CurrentCulture, ignoreCase);
	}

	/// <summary>
	/// 逆向移除当前文本区域中的目标字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标字符</param>
	/// <param name="start">区域的起始位置</param>
	/// <param name="count">区域中的字符数量</param>
	/// <param name="times">移除指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="culture">字符比较时使用的区域信息，默认为当前线程的区域信息。</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始剩余的字符数量；移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveLastChar(string text, char target, int start, int count, int times, CultureInfo culture, bool ignoreCase = false)
	{
		return RemoveLastChar(text, new char[1] { target }, start, count, times, culture, ignoreCase);
	}

	/// <summary>
	/// 逆向移除当前文本区域中的目标字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标字符</param>
	/// <param name="start">区域的起始位置</param>
	/// <param name="count">区域中的字符数量</param>
	/// <param name="times">移除指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="culture">字符比较时使用的区域信息，默认为当前线程的区域信息。</param>
	/// <param name="options">字符比较时的选项</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始剩余的字符数量；移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveLastChar(string text, char target, int start, int count, int times, CultureInfo culture, CompareOptions options)
	{
		return RemoveLastChar(text, new char[1] { target }, start, count, times, culture, options);
	}

	/// <summary>
	/// 逆向移除当前文本中的目标字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="targets">移除的目标字符数组</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；移除的目标字符数组 <paramref name="targets" /> 为空。</exception>
	public static string RemoveLastChar(string text, char[] targets, bool ignoreCase = false)
	{
		return RemoveLastChar(text, targets, CultureInfo.CurrentCulture, ignoreCase);
	}

	/// <summary>
	/// 逆向移除当前文本中的目标字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="targets">移除的目标字符数组</param>
	/// <param name="culture">字符比较时使用的区域信息，默认为当前线程的区域信息。</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；移除的目标字符数组 <paramref name="targets" /> 为空。</exception>
	public static string RemoveLastChar(string text, char[] targets, CultureInfo culture, bool ignoreCase = false)
	{
		return RemoveLastChar(text, targets, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 逆向移除当前文本中的目标字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="targets">移除的目标字符数组</param>
	/// <param name="culture">字符比较时使用的区域信息，默认为当前线程的区域信息。</param>
	/// <param name="options">字符比较时的选项</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；移除的目标字符数组 <paramref name="targets" /> 为空。</exception>
	public static string RemoveLastChar(string text, char[] targets, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(targets, "targets");
		return RemoveLastChar(text, (char x, int i) => targets.Any((char c) => IsEqualTo(x, c, culture, options)), 0, text.Length);
	}

	/// <summary>
	/// 逆向移除当前文本中的目标字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="targets">移除的目标字符数组</param>
	/// <param name="times">移除指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；移除的目标字符数组 <paramref name="targets" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveLastChar(string text, char[] targets, int times, bool ignoreCase = false)
	{
		return RemoveLastChar(text, targets, times, CultureInfo.CurrentCulture, ignoreCase);
	}

	/// <summary>
	/// 逆向移除当前文本中的目标字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="targets">移除的目标字符数组</param>
	/// <param name="times">移除指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="culture">字符比较时使用的区域信息，默认为当前线程的区域信息。</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；移除的目标字符数组 <paramref name="targets" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveLastChar(string text, char[] targets, int times, CultureInfo culture, bool ignoreCase = false)
	{
		return RemoveLastChar(text, targets, times, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 逆向移除当前文本中的目标字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="targets">移除的目标字符数组</param>
	/// <param name="times">移除指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="culture">字符比较时使用的区域信息，默认为当前线程的区域信息。</param>
	/// <param name="options">字符比较时的选项</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；移除的目标字符数组 <paramref name="targets" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveLastChar(string text, char[] targets, int times, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(targets, "targets");
		return RemoveLastChar(text, (char x, int i) => targets.Any((char c) => IsEqualTo(x, c, culture, options)), 0, text.Length, times);
	}

	/// <summary>
	/// 逆向移除当前文本区域中的目标字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="targets">移除的目标字符数组</param>
	/// <param name="start">区域的起始位置</param>
	/// <param name="count">区域中的字符数量</param>
	/// <param name="times">移除指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；移除的目标字符数组 <paramref name="targets" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始逆向剩余的字符数量；移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveLastChar(string text, char[] targets, int start, int count, int times, bool ignoreCase = false)
	{
		return RemoveLastChar(text, targets, start, count, times, CultureInfo.CurrentCulture, ignoreCase);
	}

	/// <summary>
	/// 逆向移除当前文本区域中的目标字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="targets">移除的目标字符数组</param>
	/// <param name="start">区域的起始位置</param>
	/// <param name="count">区域中的字符数量</param>
	/// <param name="times">移除指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="culture">字符比较时使用的区域信息，默认为当前线程的区域信息。</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；移除的目标字符数组 <paramref name="targets" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始逆向剩余的字符数量；移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveLastChar(string text, char[] targets, int start, int count, int times, CultureInfo culture, bool ignoreCase = false)
	{
		return RemoveLastChar(text, targets, start, count, times, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 逆向移除当前文本区域中的目标字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="targets">移除的目标字符数组</param>
	/// <param name="start">区域的起始位置</param>
	/// <param name="count">区域中的字符数量</param>
	/// <param name="times">移除指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="culture">字符比较时使用的区域信息，默认为当前线程的区域信息。</param>
	/// <param name="options">字符比较时的选项</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；移除的目标字符数组 <paramref name="targets" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始逆向剩余的字符数量；移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveLastChar(string text, char[] targets, int start, int count, int times, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(targets, "targets");
		return RemoveLastChar(text, (char x, int i) => targets.Any((char c) => IsEqualTo(x, c, culture, options)), start, count, times);
	}

	/// <summary>
	/// 逆向移除当前文本区域中满足条件的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="predicate">文本字符筛选条件</param>
	/// <param name="times">移除字符的次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者字符筛选条件 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveLastChar(string text, Func<char, bool> predicate, int times = -1)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(predicate, "predicate");
		return RemoveLastChar(text, (char x, int i) => predicate(x), text.Length - 1, text.Length, times);
	}

	/// <summary>
	/// 逆向移除当前文本区域中满足条件的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="predicate">文本字符筛选条件</param>
	/// <param name="start">区域的起始位置</param>
	/// <param name="count">区域中的字符数量</param>
	/// <param name="times">移除字符的次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者字符筛选条件 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始剩余的字符数量；移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveLastChar(string text, Func<char, bool> predicate, int start, int count, int times = -1)
	{
		Guard.AssertNotNull(predicate, "predicate");
		return RemoveLastChar(text, (char x, int i) => predicate(x), start, count, times);
	}

	/// <summary>
	/// 逆向移除当前文本区域中满足条件的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="predicate">文本字符筛选条件</param>
	/// <param name="times">移除字符的次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者字符筛选条件 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveLastChar(string text, Func<char, int, bool> predicate, int times = -1)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(predicate, "predicate");
		return RemoveLastChar(text, predicate, text.Length - 1, text.Length, times);
	}

	/// <summary>
	/// 逆向移除当前文本区域中满足条件的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="predicate">文本字符筛选条件</param>
	/// <param name="start">区域的起始位置</param>
	/// <param name="count">区域中的字符数量</param>
	/// <param name="times">移除字符的次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者字符筛选条件 <paramref name="predicate" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始剩余的字符数量；移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveLastChar(string text, Func<char, int, bool> predicate, int start, int count, int times = -1)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertIndexRange(start, 0, text.Length - 1, "start");
		Guard.AssertBetween(count, 0, start + 1, "count");
		Guard.AssertGreaterThanOrEqualTo(times, -1, "times");
		StringBuilder buff = new StringBuilder();
		int end = start - count;
		if (end >= 0)
		{
			buff.Append(text.Substring(0, end + 1));
		}
		List<char> chars = new List<char>();
		int matched = 0;
		for (int i = start; i > end; i--)
		{
			if (!predicate(text[i], i) || (times != -1 && ++matched > times))
			{
				chars.Add(text[i]);
			}
		}
		chars.Reverse();
		chars.ForEach(delegate(char c)
		{
			buff.Append(c);
		});
		buff.Append(text.Substring(start + 1));
		return buff.ToString();
	}

	/// <summary>
	/// 从当前HTML文本中移除所有HTML标记
	/// </summary>
	/// <param name="html">当前HTML文本</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前HTML文本为空。</exception>
	public static string RemoveHtmlTags(string html)
	{
		Guard.AssertNotNull(html, "html");
		return Remove(RegexPatterns.HtmlTag, html);
	}

	/// <summary>
	/// 从当前文本区域中移除符合指定正则模式的文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">移除文本的正则模式</param>
	/// <param name="times">执行匹配移除的次数，如果设置为-1则不限制次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者移除文本的正则模式 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">执行匹配替换的次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveRegex(string text, Regex pattern, int times = -1)
	{
		return Remove(pattern, text, times);
	}

	/// <summary>
	/// 从当前文本区域中移除符合指定正则模式的文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">移除文本的正则模式</param>
	/// <param name="start">匹配区域的起始位置</param>
	/// <param name="count">匹配区域的字符数量</param>
	/// <param name="times">执行匹配移除的次数，如果设置为-1则不限制次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者移除文本的正则模式 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">匹配区域的起始索引 <paramref name="start" /> 小于0，或者大于当前文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">匹配区域的字符数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始索引位置开始剩余的字符数量；或者执行匹配替换的次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveRegex(string text, Regex pattern, int start, int count, int times = -1)
	{
		return Remove(pattern, text, start, count, times);
	}

	/// <summary>
	/// 从当前文本区域中逆向移除符合指定正则模式的文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">移除文本的正则模式</param>
	/// <param name="times">执行匹配移除的次数，如果设置为-1则不限制次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者移除文本的正则模式 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">执行匹配替换的次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveLastRegex(string text, Regex pattern, int times = -1)
	{
		return RemoveLast(pattern, text, times);
	}

	/// <summary>
	/// 从当前文本区域中逆向移除符合指定正则模式的文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">移除文本的正则模式</param>
	/// <param name="start">匹配区域的起始位置</param>
	/// <param name="count">匹配区域的字符数量</param>
	/// <param name="times">执行匹配移除的次数，如果设置为-1则不限制次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者移除文本的正则模式 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">匹配区域的起始索引 <paramref name="start" /> 小于0，或者大于当前文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">匹配区域的字符数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始索引位置开始逆向剩余的字符数量；或者执行匹配替换的次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveLastRegex(string text, Regex pattern, int start, int count, int times = -1)
	{
		return RemoveLast(pattern, text, start, count, times);
	}

	/// <summary>
	/// 移除当前文本中指定数量的空白字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <returns>移除所有空白的字符</returns>
	/// <param name="times">空白字符匹配的次数（移除的数量）</param>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">执行匹配替换的次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveWhiteSpace(string text, int times = -1)
	{
		return Remove(RegexPatterns.WhiteSpaceMore, text, times);
	}

	/// <summary>
	/// 移除当前文本区域中指定数量的空白字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="start">区域起始位置</param>
	/// <param name="count">区域中字符数量</param>
	/// <param name="times">空白字符匹配的次数（移除的数量）</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">匹配区域的起始索引 <paramref name="start" /> 小于0，或者大于输入文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">匹配区域的字符数量 <paramref name="count" /> 小于0，或者大于输入文本从区域起始索引位置开始逆向剩余的字符数量；或者执行匹配替换的次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveWhiteSpace(string text, int start, int count, int times = -1)
	{
		return Remove(RegexPatterns.WhiteSpaceMore, text, start, count, times);
	}

	/// <summary>
	/// 逆向移除当前文本中指定数量的空白字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <returns>移除所有空白的字符</returns>
	/// <param name="times">空白字符匹配的次数（移除的数量）</param>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">执行匹配替换的次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveLastWhiteSpace(string text, int times = -1)
	{
		return RemoveLast(RegexPatterns.WhiteSpaceMore, text, times);
	}

	/// <summary>
	/// 逆向移除当前文本区域中指定数量的空白字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="start">区域起始位置</param>
	/// <param name="count">区域中字符数量</param>
	/// <param name="times">空白字符匹配的次数（移除的数量）</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">匹配区域的起始索引 <paramref name="start" /> 小于0，或者大于输入文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">匹配区域的字符数量 <paramref name="count" /> 小于0，或者大于输入文本从区域起始索引位置开始逆向剩余的字符数量；或者执行匹配替换的次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveLastWhiteSpace(string text, int start, int count, int times = -1)
	{
		return RemoveLast(RegexPatterns.WhiteSpaceMore, text, start, count, times);
	}

	/// <summary>
	/// 替换当前文本的替换区域中的目标字符串为指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符串</param>
	/// <param name="replacement">替换的字符串</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的目标字符串 <paramref name="target" /> 为空。</exception>
	public static string Replace(string text, string target, string replacement, bool ignoreCase = false)
	{
		return Replace(text, target, replacement, -1, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
	}

	/// <summary>
	/// 替换当前文本的替换区域中的目标字符串为指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符串</param>
	/// <param name="replacement">替换的字符串</param>
	/// <param name="comparison">比较字符时的选项</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的目标字符串 <paramref name="target" /> 为空。</exception>
	public static string Replace(string text, string target, string replacement, StringComparison comparison)
	{
		Guard.AssertNotNull(text, "text");
		return Replace(text, target, replacement, 0, text.Length, -1, comparison);
	}

	/// <summary>
	/// 替换当前文本的替换区域中的目标字符串为指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符串</param>
	/// <param name="replacement">替换的字符串</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的目标字符串 <paramref name="target" /> 为空。</exception>
	public static string Replace(string text, string target, string replacement, CultureInfo culture, bool ignoreCase = false)
	{
		return Replace(text, target, replacement, -1, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 替换当前文本的替换区域中的目标字符串为指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符串</param>
	/// <param name="replacement">替换的字符串</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="options">比较字符时的选项</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的目标字符串 <paramref name="target" /> 为空。</exception>
	public static string Replace(string text, string target, string replacement, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		return Replace(text, target, replacement, 0, text.Length, -1, culture, options);
	}

	/// <summary>
	/// 替换当前文本的替换区域中的目标字符串为指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符串</param>
	/// <param name="replacement">替换的字符串</param>
	/// <param name="times">替换指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的目标字符串 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string Replace(string text, string target, string replacement, int times, bool ignoreCase = false)
	{
		return Replace(text, target, replacement, times, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
	}

	/// <summary>
	/// 替换当前文本的替换区域中的目标字符串为指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符串</param>
	/// <param name="replacement">替换的字符串</param>
	/// <param name="times">替换指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="comparison">比较字符时的选项</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的目标字符串 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string Replace(string text, string target, string replacement, int times, StringComparison comparison)
	{
		Guard.AssertNotNull(text, "text");
		return Replace(text, target, replacement, 0, text.Length, times, comparison);
	}

	/// <summary>
	/// 替换当前文本的替换区域中的目标字符串为指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符串</param>
	/// <param name="replacement">替换的字符串</param>
	/// <param name="times">替换指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的目标字符串 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string Replace(string text, string target, string replacement, int times, CultureInfo culture, bool ignoreCase = false)
	{
		return Replace(text, target, replacement, times, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 替换当前文本的替换区域中的目标字符串为指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符串</param>
	/// <param name="replacement">替换的字符串</param>
	/// <param name="times">替换指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="options">比较字符时的选项</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的目标字符串 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string Replace(string text, string target, string replacement, int times, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		return Replace(text, target, replacement, 0, text.Length, times, culture, options);
	}

	/// <summary>
	/// 替换当前文本的替换区域中的目标字符串为指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符串</param>
	/// <param name="replacement">替换的字符串</param>
	/// <param name="start">替换区域的起始位置</param>
	/// <param name="count">替换区域中的字符数量</param>
	/// <param name="times">替换指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的目标字符串 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">替换区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始剩余的字符数量；替换次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string Replace(string text, string target, string replacement, int start, int count, int times, bool ignoreCase = false)
	{
		return Replace(text, target, replacement, start, count, times, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
	}

	/// <summary>
	/// 替换当前文本的替换区域中的目标字符串为指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符串</param>
	/// <param name="replacement">替换的字符串</param>
	/// <param name="start">替换区域的起始位置</param>
	/// <param name="count">替换区域中的字符数量</param>
	/// <param name="times">替换指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="comparison">比较字符时的选项</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的目标字符串 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">替换区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始剩余的字符数量；替换次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string Replace(string text, string target, string replacement, int start, int count, int times, StringComparison comparison)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(target, "target");
		Guard.AssertIndexRange(start, 0, text.Length - 1, "start");
		Guard.AssertBetween(count, 0, text.Length - start, "count");
		Guard.AssertGreaterThanOrEqualTo(times, -1, "times");
		replacement = ObjectHelper.IfNull(replacement, string.Empty);
		StringBuilder buff = new StringBuilder();
		buff.Append(text.Substring(0, start));
		int end = start + count;
		int matched = 0;
		int index = start;
		while (start < end && (index = text.IndexOf(target, start, end - start, comparison)) >= 0 && (times == -1 || ++matched <= times))
		{
			buff.Append(text.Substring(start, index - start));
			buff.Append(replacement);
			start = index + target.Length;
		}
		buff.Append(text.Substring(start));
		return buff.ToString();
	}

	/// <summary>
	/// 替换当前文本的替换区域中的目标字符串为指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符串</param>
	/// <param name="replacement">替换的字符串</param>
	/// <param name="start">替换区域的起始位置</param>
	/// <param name="count">替换区域中的字符数量</param>
	/// <param name="times">替换指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的目标字符串 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">替换区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始剩余的字符数量；替换次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string Replace(string text, string target, string replacement, int start, int count, int times, CultureInfo culture, bool ignoreCase = false)
	{
		return Replace(text, target, replacement, start, count, times, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 替换当前文本的替换区域中的目标字符串为指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符串</param>
	/// <param name="replacement">替换的字符串</param>
	/// <param name="start">替换区域的起始位置</param>
	/// <param name="count">替换区域中的字符数量</param>
	/// <param name="times">替换指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="culture">比较字符时使用的区域信息</param>
	/// <param name="options">比较字符时的选项</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的目标字符串 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">替换区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始剩余的字符数量；替换次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string Replace(string text, string target, string replacement, int start, int count, int times, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(target, "target");
		Guard.AssertIndexRange(start, 0, text.Length - 1, "start");
		Guard.AssertBetween(count, 0, text.Length - start, "count");
		Guard.AssertGreaterThanOrEqualTo(times, -1, "times");
		replacement = ObjectHelper.IfNull(replacement, string.Empty);
		StringBuilder buff = new StringBuilder();
		buff.Append(text.Substring(0, start));
		int end = start + count;
		int matched = 0;
		int index = start;
		while (start < end && (index = IndexOf(text, target, start, end - start, culture, options)) >= 0 && (times == -1 || ++matched <= times))
		{
			buff.Append(text.Substring(start, index - start));
			buff.Append(replacement);
			start = index + target.Length;
		}
		buff.Append(text.Substring(start));
		return buff.ToString();
	}

	/// <summary>
	/// 逆向替换当前文本的替换区域中的目标字符串为指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符串</param>
	/// <param name="replacement">替换的字符串</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的目标字符串 <paramref name="target" /> 为空。</exception>
	public static string ReplaceLast(string text, string target, string replacement, bool ignoreCase = false)
	{
		return ReplaceLast(text, target, replacement, -1, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
	}

	/// <summary>
	/// 逆向替换当前文本的替换区域中的目标字符串为指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符串</param>
	/// <param name="replacement">替换的字符串</param>
	/// <param name="comparison">字符比较时的选项</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的目标字符串 <paramref name="target" /> 为空。</exception>
	public static string ReplaceLast(string text, string target, string replacement, StringComparison comparison)
	{
		Guard.AssertNotNull(text, "text");
		return ReplaceLast(text, target, replacement, 0, text.Length, -1, comparison);
	}

	/// <summary>
	/// 逆向替换当前文本的替换区域中的目标字符串为指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符串</param>
	/// <param name="replacement">替换的字符串</param>
	/// <param name="culture">字符比较时使用的区域信息</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的目标字符串 <paramref name="target" /> 为空。</exception>
	public static string ReplaceLast(string text, string target, string replacement, CultureInfo culture, bool ignoreCase = false)
	{
		return ReplaceLast(text, target, replacement, -1, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 逆向替换当前文本的替换区域中的目标字符串为指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符串</param>
	/// <param name="replacement">替换的字符串</param>
	/// <param name="culture">字符比较时使用的区域信息</param>
	/// <param name="options">字符比较时的选项</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的目标字符串 <paramref name="target" /> 为空。</exception>
	public static string ReplaceLast(string text, string target, string replacement, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		return ReplaceLast(text, target, replacement, 0, text.Length, -1, culture, options);
	}

	/// <summary>
	/// 逆向替换当前文本的替换区域中的目标字符串为指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符串</param>
	/// <param name="replacement">替换的字符串</param>
	/// <param name="times">替换指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的目标字符串 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceLast(string text, string target, string replacement, int times, bool ignoreCase = false)
	{
		return ReplaceLast(text, target, replacement, times, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
	}

	/// <summary>
	/// 逆向替换当前文本的替换区域中的目标字符串为指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符串</param>
	/// <param name="replacement">替换的字符串</param>
	/// <param name="times">替换指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="comparison">字符比较时的选项</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的目标字符串 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceLast(string text, string target, string replacement, int times, StringComparison comparison)
	{
		Guard.AssertNotNull(text, "text");
		return ReplaceLast(text, target, replacement, 0, text.Length, times, comparison);
	}

	/// <summary>
	/// 逆向替换当前文本的替换区域中的目标字符串为指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符串</param>
	/// <param name="replacement">替换的字符串</param>
	/// <param name="times">替换指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="culture">字符比较时使用的区域信息</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的目标字符串 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceLast(string text, string target, string replacement, int times, CultureInfo culture, bool ignoreCase = false)
	{
		return ReplaceLast(text, target, replacement, times, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 逆向替换当前文本的替换区域中的目标字符串为指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符串</param>
	/// <param name="replacement">替换的字符串</param>
	/// <param name="times">替换指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="culture">字符比较时使用的区域信息</param>
	/// <param name="options">字符比较时的选项</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的目标字符串 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceLast(string text, string target, string replacement, int times, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		return ReplaceLast(text, target, replacement, 0, text.Length, times, culture, options);
	}

	/// <summary>
	/// 逆向替换当前文本的替换区域中的目标字符串为指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符串</param>
	/// <param name="replacement">替换的字符串</param>
	/// <param name="start">替换区域的起始位置</param>
	/// <param name="count">替换区域中的字符数量</param>
	/// <param name="times">替换指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的目标字符串 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">替换区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始逆向剩余的字符数量；替换次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceLast(string text, string target, string replacement, int start, int count, int times, bool ignoreCase = false)
	{
		return ReplaceLast(text, target, replacement, start, count, times, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
	}

	/// <summary>
	/// 逆向替换当前文本的替换区域中的目标字符串为指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符串</param>
	/// <param name="replacement">替换的字符串</param>
	/// <param name="start">替换区域的起始位置</param>
	/// <param name="count">替换区域中的字符数量</param>
	/// <param name="times">替换指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="comparison">字符比较时的选项</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的目标字符串 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">替换区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始逆向剩余的字符数量；替换次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceLast(string text, string target, string replacement, int start, int count, int times, StringComparison comparison)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(target, "target");
		Guard.AssertIndexRange(start, 0, text.Length - 1, "start");
		Guard.AssertBetween(count, 0, start + 1, "count");
		Guard.AssertGreaterThanOrEqualTo(times, -1, "times");
		replacement = ObjectHelper.IfNull(replacement, string.Empty);
		StringBuilder buff = new StringBuilder();
		int end = start - count;
		if (end >= 0)
		{
			buff.Append(text.Substring(0, end + 1));
		}
		List<string> list = new List<string>();
		int matched = 0;
		int index = 0;
		while (start > end && (index = text.LastIndexOf(target, start, start - end, comparison)) >= 0 && (times == -1 || ++matched <= times))
		{
			list.Add(text.Substring(index + target.Length, start - index - target.Length + 1));
			list.Add(replacement);
			start = index - 1;
		}
		if (start > end)
		{
			list.Add(text.Substring(end + 1, start - end));
		}
		list.Reverse();
		list.ForEach(delegate(string s)
		{
			buff.Append(s);
		});
		buff.Append(text.Substring(start + 1));
		return buff.ToString();
	}

	/// <summary>
	/// 逆向替换当前文本的替换区域中的目标字符串为指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符串</param>
	/// <param name="replacement">替换的字符串</param>
	/// <param name="start">替换区域的起始位置</param>
	/// <param name="count">替换区域中的字符数量</param>
	/// <param name="times">替换指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="culture">字符比较时使用的区域信息</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的目标字符串 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">替换区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始逆向剩余的字符数量；替换次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceLast(string text, string target, string replacement, int start, int count, int times, CultureInfo culture, bool ignoreCase = false)
	{
		return ReplaceLast(text, target, replacement, start, count, times, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 逆向替换当前文本的替换区域中的目标字符串为指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符串</param>
	/// <param name="replacement">替换的字符串</param>
	/// <param name="start">替换区域的起始位置</param>
	/// <param name="count">替换区域中的字符数量</param>
	/// <param name="times">替换指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="culture">字符比较时使用的区域信息</param>
	/// <param name="options">字符比较时的选项</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的目标字符串 <paramref name="target" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">替换区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始逆向剩余的字符数量；替换次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceLast(string text, string target, string replacement, int start, int count, int times, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(target, "target");
		Guard.AssertIndexRange(start, 0, text.Length - 1, "start");
		Guard.AssertBetween(count, 0, start + 1, "count");
		Guard.AssertGreaterThanOrEqualTo(times, -1, "times");
		replacement = ObjectHelper.IfNull(replacement, string.Empty);
		StringBuilder buff = new StringBuilder();
		int end = start - count;
		if (end >= 0)
		{
			buff.Append(text.Substring(0, end + 1));
		}
		List<string> list = new List<string>();
		int matched = 0;
		int index = 0;
		while (start > end && (index = LastIndexOf(text, target, start, start - end, culture, options)) >= 0 && (times == -1 || ++matched <= times))
		{
			list.Add(text.Substring(index + target.Length, start - index - target.Length + 1));
			list.Add(replacement);
			start = index - 1;
		}
		if (start > end)
		{
			list.Add(text.Substring(end + 1, start - end));
		}
		list.Reverse();
		list.ForEach(delegate(string s)
		{
			buff.Append(s);
		});
		buff.Append(text.Substring(start + 1));
		return buff.ToString();
	}

	/// <summary>
	/// 替换当前文本的替换区域中的目标字符为指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符</param>
	/// <param name="replacement">替换的字符</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static string ReplaceChar(string text, char target, char replacement, bool ignoreCase = false)
	{
		return ReplaceChar(text, target, replacement, -1, ignoreCase);
	}

	/// <summary>
	/// 替换当前文本的替换区域中的目标字符为指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符</param>
	/// <param name="replacement">替换的字符</param>
	/// <param name="culture">字符比较时使用的区域信息，默认为当前线程的区域信息。</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static string ReplaceChar(string text, char target, char replacement, CultureInfo culture, bool ignoreCase = false)
	{
		return ReplaceChar(text, target, replacement, -1, culture, ignoreCase);
	}

	/// <summary>
	/// 替换当前文本的替换区域中的目标字符为指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符</param>
	/// <param name="replacement">替换的字符</param>
	/// <param name="culture">字符比较时使用的区域信息，默认为当前线程的区域信息。</param>
	/// <param name="options">字符比较的选项</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static string ReplaceChar(string text, char target, char replacement, CultureInfo culture, CompareOptions options)
	{
		return ReplaceChar(text, target, replacement, -1, culture, options);
	}

	/// <summary>
	/// 替换当前文本的替换区域中的目标字符为指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符</param>
	/// <param name="replacement">替换的字符</param>
	/// <param name="times">替换指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceChar(string text, char target, char replacement, int times, bool ignoreCase = false)
	{
		Guard.AssertNotNull(text, "text");
		return ReplaceChar(text, target, replacement, 0, text.Length, times, ignoreCase);
	}

	/// <summary>
	/// 替换当前文本的替换区域中的目标字符为指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符</param>
	/// <param name="replacement">替换的字符</param>
	/// <param name="times">替换指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="culture">字符比较时使用的区域信息，默认为当前线程的区域信息。</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceChar(string text, char target, char replacement, int times, CultureInfo culture, bool ignoreCase = false)
	{
		Guard.AssertNotNull(text, "text");
		return ReplaceChar(text, target, replacement, 0, text.Length, times, culture, ignoreCase);
	}

	/// <summary>
	/// 替换当前文本的替换区域中的目标字符为指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符</param>
	/// <param name="replacement">替换的字符</param>
	/// <param name="times">替换指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="culture">字符比较时使用的区域信息，默认为当前线程的区域信息。</param>
	/// <param name="options">字符比较的选项</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceChar(string text, char target, char replacement, int times, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		return ReplaceChar(text, target, replacement, 0, text.Length, times, culture, options);
	}

	/// <summary>
	/// 替换当前文本的替换区域中的目标字符为指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符</param>
	/// <param name="replacement">替换的字符</param>
	/// <param name="start">替换区域的起始位置</param>
	/// <param name="count">替换区域中的字符数量</param>
	/// <param name="times">替换指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">替换区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始剩余的字符数量；替换次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceChar(string text, char target, char replacement, int start, int count, int times, bool ignoreCase = false)
	{
		Guard.AssertNotNull(text, "text");
		return ReplaceChar(text, (char c, int i) => IsEqualTo(c, target, CultureInfo.CurrentCulture, ignoreCase), (char c, int i) => replacement, start, count, times);
	}

	/// <summary>
	/// 替换当前文本的替换区域中的目标字符为指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符</param>
	/// <param name="replacement">替换的字符</param>
	/// <param name="start">替换区域的起始位置</param>
	/// <param name="count">替换区域中的字符数量</param>
	/// <param name="times">替换指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="culture">字符比较时使用的区域信息，默认为当前线程的区域信息。</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">替换区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始剩余的字符数量；替换次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceChar(string text, char target, char replacement, int start, int count, int times, CultureInfo culture, bool ignoreCase = false)
	{
		Guard.AssertNotNull(text, "text");
		return ReplaceChar(text, (char c, int i) => IsEqualTo(c, target, culture, ignoreCase), (char c, int i) => replacement, start, count, times);
	}

	/// <summary>
	/// 替换当前文本的替换区域中的目标字符为指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符</param>
	/// <param name="replacement">替换的字符</param>
	/// <param name="start">替换区域的起始位置</param>
	/// <param name="count">替换区域中的字符数量</param>
	/// <param name="times">替换指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="culture">字符比较时使用的区域信息，默认为当前线程的区域信息。</param>
	/// <param name="options">字符比较的选项</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">替换区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始剩余的字符数量；替换次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceChar(string text, char target, char replacement, int start, int count, int times, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		return ReplaceChar(text, (char c, int i) => IsEqualTo(c, target, culture, options), (char c, int i) => replacement, start, count, times);
	}

	/// <summary>
	/// 替换当前文本的替换区域中满足条件的字符替换为计算表达式的值
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="predicate">字符筛选条件</param>
	/// <param name="evaluation">字符生成方法</param>
	/// <param name="times">移除字符的次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者字符筛选条件 <paramref name="predicate" /> 为空；或者字符生成方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceChar(string text, Func<char, bool> predicate, Func<char, char> evaluation, int times = -1)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(evaluation, "evaluation");
		return ReplaceChar(text, (char x, int i) => predicate(x), (char x, int i) => evaluation(x), 0, text.Length, times);
	}

	/// <summary>
	/// 替换当前文本的替换区域中满足条件的字符替换为计算表达式的值
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="predicate">字符筛选条件</param>
	/// <param name="evaluation">字符生成方法</param>
	/// <param name="start">区域的起始位置</param>
	/// <param name="count">区域中的字符数量</param>
	/// <param name="times">移除字符的次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者字符筛选条件 <paramref name="predicate" /> 为空；或者字符生成方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始剩余的字符数量；移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceChar(string text, Func<char, bool> predicate, Func<char, char> evaluation, int start, int count, int times = -1)
	{
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(evaluation, "evaluation");
		return ReplaceChar(text, (char x, int i) => predicate(x), (char x, int i) => evaluation(x), start, count, times);
	}

	/// <summary>
	/// 替换当前文本的替换区域中满足条件的字符替换为计算表达式的值
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="predicate">字符筛选条件</param>
	/// <param name="evaluation">字符生成方法</param>
	/// <param name="times">移除字符的次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者字符筛选条件 <paramref name="predicate" /> 为空；或者字符生成方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceChar(string text, Func<char, int, bool> predicate, Func<char, int, char> evaluation, int times = -1)
	{
		Guard.AssertNotNull(text, "text");
		return ReplaceChar(text, predicate, evaluation, 0, text.Length, times);
	}

	/// <summary>
	/// 替换当前文本的替换区域中满足条件的字符替换为计算表达式的值
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="predicate">字符筛选条件</param>
	/// <param name="evaluation">字符生成方法</param>
	/// <param name="start">区域的起始位置</param>
	/// <param name="count">区域中的字符数量</param>
	/// <param name="times">移除字符的次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者字符筛选条件 <paramref name="predicate" /> 为空；或者字符生成方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始剩余的字符数量；移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceChar(string text, Func<char, int, bool> predicate, Func<char, int, char> evaluation, int start, int count, int times = -1)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(evaluation, "evaluation");
		Guard.AssertIndexRange(start, 0, text.Length - 1, "start");
		Guard.AssertBetween(count, 0, text.Length - start, "count");
		Guard.AssertGreaterThanOrEqualTo(times, -1, "times");
		StringBuilder buff = new StringBuilder(text.Length);
		buff.Append(text.Substring(0, start));
		int end = start + count;
		int matched = 0;
		for (int i = start; i < end; i++)
		{
			if (predicate(text[i], i) && (times == -1 || ++matched <= times))
			{
				buff.Append(evaluation(text[i], i));
			}
			else
			{
				buff.Append(text[i]);
			}
		}
		return buff.ToString();
	}

	/// <summary>
	/// 逆向替换当前文本的替换区域中的目标字符为指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符</param>
	/// <param name="replacement">替换的字符</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static string ReplaceLastChar(string text, char target, char replacement, bool ignoreCase = false)
	{
		return ReplaceLastChar(text, target, replacement, -1, ignoreCase);
	}

	/// <summary>
	/// 逆向替换当前文本的替换区域中的目标字符为指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符</param>
	/// <param name="replacement">替换的字符</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static string ReplaceLastChar(string text, char target, char replacement, CultureInfo culture, bool ignoreCase = false)
	{
		return ReplaceLastChar(text, target, replacement, -1, culture, ignoreCase);
	}

	/// <summary>
	/// 逆向替换当前文本的替换区域中的目标字符为指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符</param>
	/// <param name="replacement">替换的字符</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="options">比较字符时的选项</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static string ReplaceLastChar(string text, char target, char replacement, CultureInfo culture, CompareOptions options)
	{
		return ReplaceLastChar(text, target, replacement, -1, culture, options);
	}

	/// <summary>
	/// 逆向替换当前文本的替换区域中的目标字符为指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符</param>
	/// <param name="replacement">替换的字符</param>
	/// <param name="times">替换指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceLastChar(string text, char target, char replacement, int times, bool ignoreCase = false)
	{
		Guard.AssertNotNull(text, "text");
		return ReplaceLastChar(text, target, replacement, 0, text.Length, times, ignoreCase);
	}

	/// <summary>
	/// 逆向替换当前文本的替换区域中的目标字符为指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符</param>
	/// <param name="replacement">替换的字符</param>
	/// <param name="times">替换指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceLastChar(string text, char target, char replacement, int times, CultureInfo culture, bool ignoreCase = false)
	{
		Guard.AssertNotNull(text, "text");
		return ReplaceLastChar(text, target, replacement, 0, text.Length, times, culture, ignoreCase);
	}

	/// <summary>
	/// 逆向替换当前文本的替换区域中的目标字符为指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符</param>
	/// <param name="replacement">替换的字符</param>
	/// <param name="times">替换指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="options">比较字符时的选项</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceLastChar(string text, char target, char replacement, int times, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		return ReplaceLastChar(text, target, replacement, 0, text.Length, times, culture, options);
	}

	/// <summary>
	/// 逆向替换当前文本的替换区域中的目标字符为指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符</param>
	/// <param name="replacement">替换的字符</param>
	/// <param name="start">替换区域的起始位置</param>
	/// <param name="count">替换区域中的字符数量</param>
	/// <param name="times">替换指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">替换区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始逆向剩余的字符数量；替换次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceLastChar(string text, char target, char replacement, int start, int count, int times, bool ignoreCase = false)
	{
		Guard.AssertNotNull(text, "text");
		return ReplaceLastChar(text, (char c, int i) => IsEqualTo(c, replacement, CultureInfo.CurrentCulture, ignoreCase), (char c, int i) => replacement, start, count, times);
	}

	/// <summary>
	/// 逆向替换当前文本的替换区域中的目标字符为指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符</param>
	/// <param name="replacement">替换的字符</param>
	/// <param name="start">替换区域的起始位置</param>
	/// <param name="count">替换区域中的字符数量</param>
	/// <param name="times">替换指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">替换区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始逆向剩余的字符数量；替换次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceLastChar(string text, char target, char replacement, int start, int count, int times, CultureInfo culture, bool ignoreCase = false)
	{
		Guard.AssertNotNull(text, "text");
		return ReplaceLastChar(text, (char c, int i) => IsEqualTo(c, replacement, culture, ignoreCase), (char c, int i) => replacement, start, count, times);
	}

	/// <summary>
	/// 逆向替换当前文本的替换区域中的目标字符为指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">替换的目标字符</param>
	/// <param name="replacement">替换的字符</param>
	/// <param name="start">替换区域的起始位置</param>
	/// <param name="count">替换区域中的字符数量</param>
	/// <param name="times">替换指定次数，设置为-1则不限定替换次数。</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="options">比较字符时的选项</param>
	/// <returns>替换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">替换区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始逆向剩余的字符数量；替换次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceLastChar(string text, char target, char replacement, int start, int count, int times, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		return ReplaceLastChar(text, (char c, int i) => IsEqualTo(c, replacement, culture, options), (char c, int i) => replacement, start, count, times);
	}

	/// <summary>
	/// 逆向替换当前文本的替换区域中满足条件的字符替换为计算表达式的值
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="predicate">字符筛选条件</param>
	/// <param name="evaluation">字符生成方法</param>
	/// <param name="times">移除字符的次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者字符筛选条件 <paramref name="predicate" /> 为空；或者字符生成方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceLastChar(string text, Func<char, bool> predicate, Func<char, char> evaluation, int times = -1)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(evaluation, "evaluation");
		return ReplaceLastChar(text, (char x, int i) => predicate(x), (char x, int i) => evaluation(x), text.Length - 1, text.Length, times);
	}

	/// <summary>
	/// 逆向替换当前文本的替换区域中满足条件的字符替换为计算表达式的值
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="predicate">字符筛选条件</param>
	/// <param name="evaluation">字符生成方法</param>
	/// <param name="start">区域的起始位置</param>
	/// <param name="count">区域中的字符数量</param>
	/// <param name="times">移除字符的次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者字符筛选条件 <paramref name="predicate" /> 为空；或者字符生成方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始剩余的字符数量；移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceLastChar(string text, Func<char, bool> predicate, Func<char, char> evaluation, int start, int count, int times = -1)
	{
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(evaluation, "evaluation");
		return ReplaceLastChar(text, (char x, int i) => predicate(x), (char x, int i) => evaluation(x), start, count, times);
	}

	/// <summary>
	/// 逆向替换当前文本的替换区域中满足条件的字符替换为计算表达式的值
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="predicate">字符筛选条件</param>
	/// <param name="evaluation">字符生成方法</param>
	/// <param name="times">移除字符的次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者字符筛选条件 <paramref name="predicate" /> 为空；或者字符生成方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceLastChar(string text, Func<char, int, bool> predicate, Func<char, int, char> evaluation, int times = -1)
	{
		Guard.AssertNotNull(text, "text");
		return ReplaceLastChar(text, predicate, evaluation, text.Length - 1, text.Length, times);
	}

	/// <summary>
	/// 逆向替换当前文本的替换区域中满足条件的字符替换为计算表达式的值
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="predicate">字符筛选条件</param>
	/// <param name="evaluation">字符生成方法</param>
	/// <param name="start">区域的起始位置</param>
	/// <param name="count">区域中的字符数量</param>
	/// <param name="times">移除字符的次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者字符筛选条件 <paramref name="predicate" /> 为空；或者字符生成方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始剩余的字符数量；移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceLastChar(string text, Func<char, int, bool> predicate, Func<char, int, char> evaluation, int start, int count, int times = -1)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(predicate, "predicate");
		Guard.AssertNotNull(evaluation, "evaluation");
		Guard.AssertIndexRange(start, 0, text.Length - 1, "start");
		Guard.AssertBetween(count, 0, start + 1, "count");
		Guard.AssertGreaterThanOrEqualTo(times, -1, "times");
		StringBuilder buff = new StringBuilder();
		int end = start - count;
		if (end >= 0)
		{
			buff.Append(text.Substring(0, end + 1));
		}
		List<char> chars = new List<char>(count);
		int matched = 0;
		for (int i = start; i > end; i--)
		{
			if (predicate(text[i], i) && (times == -1 || ++matched <= times))
			{
				chars.Add(evaluation(text[i], i));
			}
			else
			{
				chars.Add(text[i]);
			}
		}
		chars.Reverse();
		chars.ForEach(delegate(char c)
		{
			buff.Append(c);
		});
		buff.Append(text.Substring(start + 1));
		return buff.ToString();
	}

	/// <summary>
	/// 在当前文本的区域中将符合指定正则模式的字符串替换为指定文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">替换的正则模式</param>
	/// <param name="replacement">替换的文本</param>
	/// <param name="options">正则模式参数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的正则模式 <paramref name="pattern" /> 为空；或者替换的文本 <paramref name="replacement" /> 为空。</exception>
	public static string ReplaceRegex(string text, string pattern, string replacement, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return ReplaceText(ConvertHelper.ToRegex(pattern, EnumHelper.EnsureLeftToRightOption(options)), text, replacement);
	}

	/// <summary>
	/// 在当前文本的区域中将符合指定正则模式的字符串替换为指定文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">替换的正则模式</param>
	/// <param name="replacement">替换的文本</param>
	/// <param name="times">执行匹配替换的次数，如果设置为-1则不限制次数</param>
	/// <param name="options">正则模式参数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的正则模式 <paramref name="pattern" /> 为空；或者替换的文本 <paramref name="replacement" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">执行匹配替换的次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceRegex(string text, string pattern, string replacement, int times, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return ReplaceText(ConvertHelper.ToRegex(pattern, EnumHelper.EnsureLeftToRightOption(options)), text, replacement, times);
	}

	/// <summary>
	/// 在当前文本的区域中将符合指定正则模式的字符串替换为指定文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">替换的正则模式</param>
	/// <param name="replacement">替换的文本</param>
	/// <param name="start">替换区域的起始的字符索引</param>
	/// <param name="count">替换区域中字符的数量</param>
	/// <param name="options">正则模式参数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的正则模式 <paramref name="pattern" /> 为空；或者替换文本 <paramref name="replacement" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">替换区域的起始索引 <paramref name="start" /> 小于0，或者大于输入文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换区域的字符数量 <paramref name="count" /> 小于0，或者大于输入文本从区域起始索引位置开始剩余的字符数量。</exception>
	public static string ReplaceRegex(string text, string pattern, string replacement, int start, int count, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return ReplaceText(ConvertHelper.ToRegex(pattern, EnumHelper.EnsureLeftToRightOption(options)), text, replacement, start, count);
	}

	/// <summary>
	/// 在当前文本的区域中将符合指定正则模式的字符串替换为指定文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">替换的正则模式</param>
	/// <param name="replacement">替换的文本</param>
	/// <param name="start">替换区域的起始的字符索引</param>
	/// <param name="count">替换区域中字符的数量</param>
	/// <param name="times">执行匹配替换的次数，如果设置为-1则不限制次数</param>
	/// <param name="options">正则模式参数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的正则模式 <paramref name="pattern" /> 为空；或者替换文本 <paramref name="replacement" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">替换区域的起始索引 <paramref name="start" /> 小于0，或者大于输入文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换区域的字符数量 <paramref name="count" /> 小于0，或者大于输入文本从区域起始索引位置开始剩余的字符数量；或者执行匹配替换的次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceRegex(string text, string pattern, string replacement, int start, int count, int times, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return ReplaceText(ConvertHelper.ToRegex(pattern, EnumHelper.EnsureLeftToRightOption(options)), text, replacement, start, count, times);
	}

	/// <summary>
	/// 在当前文本的区域中将符合指定正则模式的字符串替换为替换处理方法的返回值
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">替换的正则模式</param>
	/// <param name="evaluation">替换处理方法</param>
	/// <param name="options">正则模式参数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的正则模式 <paramref name="pattern" /> 为空；或者替换处理方法 <paramref name="evaluation" /> 为空。</exception>
	public static string ReplaceRegex(string text, string pattern, Func<Match, string> evaluation, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return ReplaceText(ConvertHelper.ToRegex(pattern, EnumHelper.EnsureLeftToRightOption(options)), text, evaluation);
	}

	/// <summary>
	/// 在当前文本的区域中将符合指定正则模式的字符串替换为替换处理方法的返回值
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">替换的正则模式</param>
	/// <param name="evaluation">替换处理方法</param>
	/// <param name="times">执行匹配替换的次数，如果设置为-1则不限制次数</param>
	/// <param name="options">正则模式参数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的正则模式 <paramref name="pattern" /> 为空；或者替换处理方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">执行匹配替换的次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceRegex(string text, string pattern, Func<Match, string> evaluation, int times, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return ReplaceText(ConvertHelper.ToRegex(pattern, EnumHelper.EnsureLeftToRightOption(options)), text, evaluation, times);
	}

	/// <summary>
	/// 在当前文本的区域中将符合指定正则模式的字符串替换为替换处理方法的返回值
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">替换的正则模式</param>
	/// <param name="evaluation">替换处理方法</param>
	/// <param name="start">替换区域的起始的字符索引</param>
	/// <param name="count">替换区域中字符的数量</param>
	/// <param name="options">正则模式参数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的正则模式 <paramref name="pattern" /> 为空；或者替换处理方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">替换区域的起始索引 <paramref name="start" /> 小于0，或者大于输入文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换区域的字符数量 <paramref name="count" /> 小于0，或者大于输入文本从区域起始索引位置开始剩余的字符数量。</exception>
	public static string ReplaceRegex(string text, string pattern, Func<Match, string> evaluation, int start, int count, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return ReplaceText(ConvertHelper.ToRegex(pattern, EnumHelper.EnsureLeftToRightOption(options)), text, evaluation, start, count);
	}

	/// <summary>
	/// 在当前文本的区域中将符合指定正则模式的字符串替换为替换处理方法的返回值
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">替换的正则模式</param>
	/// <param name="evaluation">替换处理方法</param>
	/// <param name="start">替换区域的起始的字符索引</param>
	/// <param name="count">替换区域中字符的数量</param>
	/// <param name="times">执行匹配替换的次数，如果设置为-1则不限制次数</param>
	/// <param name="options">正则模式参数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的正则模式 <paramref name="pattern" /> 为空；或者替换处理方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">替换区域的起始索引 <paramref name="start" /> 小于0，或者大于输入文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换区域的字符数量 <paramref name="count" /> 小于0，或者大于输入文本从区域起始索引位置开始剩余的字符数量；或者执行匹配替换的次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceRegex(string text, string pattern, Func<Match, string> evaluation, int start, int count, int times, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return ReplaceText(ConvertHelper.ToRegex(pattern, EnumHelper.EnsureLeftToRightOption(options)), text, evaluation, start, count, times);
	}

	/// <summary>
	/// 在当前文本的区域中将符合指定正则模式的字符串替换为指定文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">替换的正则模式</param>
	/// <param name="replacement">替换的文本</param>
	/// <param name="times">执行匹配替换的次数，如果设置为-1则不限制次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的正则模式 <paramref name="pattern" /> 为空；或者替换的文本 <paramref name="replacement" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">执行匹配替换的次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceRegex(string text, Regex pattern, string replacement, int times = -1)
	{
		return ReplaceText(pattern, text, replacement, times);
	}

	/// <summary>
	/// 在当前文本的区域中将符合指定正则模式的字符串替换为指定文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">替换的正则模式</param>
	/// <param name="replacement">替换的文本</param>
	/// <param name="start">替换区域的起始的字符索引</param>
	/// <param name="count">替换区域中字符的数量</param>
	/// <param name="times">执行匹配替换的次数，如果设置为-1则不限制次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的正则模式 <paramref name="pattern" /> 为空；或者替换文本 <paramref name="replacement" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">替换区域的起始索引 <paramref name="start" /> 小于0，或者大于输入文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换区域的字符数量 <paramref name="count" /> 小于0，或者大于输入文本从区域起始索引位置开始剩余的字符数量；或者执行匹配替换的次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceRegex(string text, Regex pattern, string replacement, int start, int count, int times = -1)
	{
		return ReplaceText(pattern, text, replacement, start, count, times);
	}

	/// <summary>
	/// 在当前文本的区域中将符合指定正则模式的字符串替换为替换处理方法的返回值
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">替换的正则模式</param>
	/// <param name="evaluation">替换处理方法</param>
	/// <param name="times">执行匹配替换的次数，如果设置为-1则不限制次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的正则模式 <paramref name="pattern" /> 为空；或者替换处理方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">执行匹配替换的次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceRegex(string text, Regex pattern, Func<Match, string> evaluation, int times = -1)
	{
		return ReplaceText(pattern, text, evaluation, times);
	}

	/// <summary>
	/// 在当前文本的区域中将符合指定正则模式的字符串替换为替换处理方法的返回值
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">替换的正则模式</param>
	/// <param name="evaluation">替换处理方法</param>
	/// <param name="start">替换区域的起始的字符索引</param>
	/// <param name="count">替换区域中字符的数量</param>
	/// <param name="times">执行匹配替换的次数，如果设置为-1则不限制次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的正则模式 <paramref name="pattern" /> 为空；或者替换处理方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">替换区域的起始索引 <paramref name="start" /> 小于0，或者大于输入文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换区域的字符数量 <paramref name="count" /> 小于0，或者大于输入文本从区域起始索引位置开始剩余的字符数量；或者执行匹配替换的次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceRegex(string text, Regex pattern, Func<Match, string> evaluation, int start, int count, int times = -1)
	{
		return ReplaceText(pattern, text, evaluation, start, count, times);
	}

	/// <summary>
	/// 在当前文本的区域中进行逆向搜索，将符合指定正则模式的字符串替换为指定文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">替换的正则模式</param>
	/// <param name="replacement">替换的文本</param>
	/// <param name="options">正则模式参数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的正则模式 <paramref name="pattern" /> 为空；或者替换的文本 <paramref name="replacement" /> 为空。</exception>
	public static string ReplaceLastRegex(string text, string pattern, string replacement, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return ReplaceLastText(ConvertHelper.ToRegex(pattern, EnumHelper.EnsureLeftToRightOption(options)), text, replacement);
	}

	/// <summary>
	/// 在当前文本的区域中进行逆向搜索，将符合指定正则模式的字符串替换为指定文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">替换的正则模式</param>
	/// <param name="replacement">替换的文本</param>
	/// <param name="times">执行匹配替换的次数，如果设置为-1则不限制次数</param>
	/// <param name="options">正则模式参数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的正则模式 <paramref name="pattern" /> 为空；或者替换的文本 <paramref name="replacement" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">执行匹配替换的次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceLastRegex(string text, string pattern, string replacement, int times, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return ReplaceLastText(ConvertHelper.ToRegex(pattern, EnumHelper.EnsureLeftToRightOption(options)), text, replacement, times);
	}

	/// <summary>
	/// 在当前文本的区域中进行逆向搜索，将符合指定正则模式的字符串替换为指定文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">替换的正则模式</param>
	/// <param name="replacement">替换的文本</param>
	/// <param name="start">替换区域的起始的字符索引</param>
	/// <param name="count">替换区域中字符的数量</param>
	/// <param name="options">正则模式参数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的正则模式 <paramref name="pattern" /> 为空；或者替换文本 <paramref name="replacement" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">替换区域的起始索引 <paramref name="start" /> 小于0，或者大于输入文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换区域的字符数量 <paramref name="count" /> 小于0，或者大于输入文本从区域起始索引位置开始剩余的字符数量。</exception>
	public static string ReplaceLastRegex(string text, string pattern, string replacement, int start, int count, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return ReplaceLastText(ConvertHelper.ToRegex(pattern, EnumHelper.EnsureLeftToRightOption(options)), text, replacement, start, count);
	}

	/// <summary>
	/// 在当前文本的区域中进行逆向搜索，将符合指定正则模式的字符串替换为指定文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">替换的正则模式</param>
	/// <param name="replacement">替换的文本</param>
	/// <param name="start">替换区域的起始的字符索引</param>
	/// <param name="count">替换区域中字符的数量</param>
	/// <param name="times">执行匹配替换的次数，如果设置为-1则不限制次数</param>
	/// <param name="options">正则模式参数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的正则模式 <paramref name="pattern" /> 为空；或者替换文本 <paramref name="replacement" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">替换区域的起始索引 <paramref name="start" /> 小于0，或者大于输入文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换区域的字符数量 <paramref name="count" /> 小于0，或者大于输入文本从区域起始索引位置开始剩余的字符数量；或者执行匹配替换的次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceLastRegex(string text, string pattern, string replacement, int start, int count, int times, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return ReplaceLastText(ConvertHelper.ToRegex(pattern, EnumHelper.EnsureLeftToRightOption(options)), text, replacement, start, count, times);
	}

	/// <summary>
	/// 在当前文本的区域中进行逆向搜索，将符合指定正则模式的字符串替换为替换处理方法的返回值
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">替换的正则模式</param>
	/// <param name="evaluation">替换处理方法</param>
	/// <param name="options">正则模式参数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的正则模式 <paramref name="pattern" /> 为空；或者替换处理方法 <paramref name="evaluation" /> 为空。</exception>
	public static string ReplaceLastRegex(string text, string pattern, Func<Match, string> evaluation, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return ReplaceLastText(ConvertHelper.ToRegex(pattern, EnumHelper.EnsureLeftToRightOption(options)), text, evaluation);
	}

	/// <summary>
	/// 在当前文本的区域中进行逆向搜索，将符合指定正则模式的字符串替换为替换处理方法的返回值
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">替换的正则模式</param>
	/// <param name="evaluation">替换处理方法</param>
	/// <param name="times">执行匹配替换的次数，如果设置为-1则不限制次数</param>
	/// <param name="options">正则模式参数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的正则模式 <paramref name="pattern" /> 为空；或者替换处理方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">执行匹配替换的次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceLastRegex(string text, string pattern, Func<Match, string> evaluation, int times, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return ReplaceLastText(ConvertHelper.ToRegex(pattern, EnumHelper.EnsureLeftToRightOption(options)), text, evaluation, times);
	}

	/// <summary>
	/// 在当前文本的区域中进行逆向搜索，将符合指定正则模式的字符串替换为替换处理方法的返回值
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">替换的正则模式</param>
	/// <param name="evaluation">替换处理方法</param>
	/// <param name="start">替换区域的起始的字符索引</param>
	/// <param name="count">替换区域中字符的数量</param>
	/// <param name="options">正则模式参数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的正则模式 <paramref name="pattern" /> 为空；或者替换处理方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">替换区域的起始索引 <paramref name="start" /> 小于0，或者大于输入文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换区域的字符数量 <paramref name="count" /> 小于0，或者大于输入文本从区域起始索引位置开始剩余的字符数量。</exception>
	public static string ReplaceLastRegex(string text, string pattern, Func<Match, string> evaluation, int start, int count, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return ReplaceLastText(ConvertHelper.ToRegex(pattern, EnumHelper.EnsureLeftToRightOption(options)), text, evaluation, start, count);
	}

	/// <summary>
	/// 在当前文本的区域中进行逆向搜索，将符合指定正则模式的字符串替换为替换处理方法的返回值
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">替换的正则模式</param>
	/// <param name="evaluation">替换处理方法</param>
	/// <param name="start">替换区域的起始的字符索引</param>
	/// <param name="count">替换区域中字符的数量</param>
	/// <param name="times">执行匹配替换的次数，如果设置为-1则不限制次数</param>
	/// <param name="options">正则模式参数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的正则模式 <paramref name="pattern" /> 为空；或者替换处理方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">替换区域的起始索引 <paramref name="start" /> 小于0，或者大于输入文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换区域的字符数量 <paramref name="count" /> 小于0，或者大于输入文本从区域起始索引位置开始剩余的字符数量；或者执行匹配替换的次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceLastRegex(string text, string pattern, Func<Match, string> evaluation, int start, int count, int times, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return ReplaceLastText(ConvertHelper.ToRegex(pattern, EnumHelper.EnsureLeftToRightOption(options)), text, evaluation, start, count, times);
	}

	/// <summary>
	/// 在当前文本的区域中进行逆向搜索，将符合指定正则模式的字符串替换为指定文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">替换的正则模式</param>
	/// <param name="replacement">替换的文本</param>
	/// <param name="times">执行匹配替换的次数，如果设置为-1则不限制次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的正则模式 <paramref name="pattern" /> 为空；或者替换的文本 <paramref name="replacement" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">执行匹配替换的次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceLastRegex(string text, Regex pattern, string replacement, int times = -1)
	{
		return ReplaceLastText(pattern, text, replacement, times);
	}

	/// <summary>
	/// 在当前文本的区域中进行逆向搜索，将符合指定正则模式的字符串替换为指定文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">替换的正则模式</param>
	/// <param name="replacement">替换的文本</param>
	/// <param name="start">替换区域的起始的字符索引</param>
	/// <param name="count">替换区域中字符的数量</param>
	/// <param name="times">执行匹配替换的次数，如果设置为-1则不限制次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的正则模式 <paramref name="pattern" /> 为空；或者替换文本 <paramref name="replacement" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">替换区域的起始索引 <paramref name="start" /> 小于0，或者大于输入文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换区域的字符数量 <paramref name="count" /> 小于0，或者大于输入文本从区域起始索引位置开始剩余的字符数量；或者执行匹配替换的次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceLastRegex(string text, Regex pattern, string replacement, int start, int count, int times = -1)
	{
		return ReplaceLastText(pattern, text, replacement, start, count, times);
	}

	/// <summary>
	/// 在当前文本的区域中进行逆向搜索，将符合指定正则模式的字符串替换为替换处理方法的返回值
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">替换的正则模式</param>
	/// <param name="evaluation">替换处理方法</param>
	/// <param name="times">执行匹配替换的次数，如果设置为-1则不限制次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的正则模式 <paramref name="pattern" /> 为空；或者替换处理方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">执行匹配替换的次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceLastRegex(string text, Regex pattern, Func<Match, string> evaluation, int times = -1)
	{
		return ReplaceLastText(pattern, text, evaluation, times);
	}

	/// <summary>
	/// 在当前文本的区域中逆向搜索，将符合指定正则模式的字符串替换为替换处理方法的返回值
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">替换的正则模式</param>
	/// <param name="evaluation">替换处理方法</param>
	/// <param name="start">替换区域的起始的字符索引</param>
	/// <param name="count">替换区域中字符的数量</param>
	/// <param name="times">执行匹配替换的次数，如果设置为-1则不限制次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者替换的正则模式 <paramref name="pattern" /> 为空；或者替换处理方法 <paramref name="evaluation" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">替换区域的起始索引 <paramref name="start" /> 小于0，或者大于输入文本的字符最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">替换区域的字符数量 <paramref name="count" /> 小于0，或者大于输入文本从区域起始索引位置开始剩余的字符数量；或者执行匹配替换的次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceLastRegex(string text, Regex pattern, Func<Match, string> evaluation, int start, int count, int times = -1)
	{
		return ReplaceLastText(pattern, text, evaluation, start, count, times);
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
	public static string ReplaceText(Regex regex, string text, string replacement, int times = -1)
	{
		replacement = ObjectHelper.IfNull(replacement, string.Empty);
		return ReplaceText(regex, text, (Match m) => replacement, times);
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
	public static string ReplaceText(Regex regex, string text, string replacement, int start, int count, int times = -1)
	{
		replacement = ObjectHelper.IfNull(replacement, string.Empty);
		return ReplaceText(regex, text, (Match m) => replacement, start, count, times);
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
	public static string ReplaceText(Regex regex, string text, Func<Match, string> evaluation, int times = -1)
	{
		Guard.AssertNotNull(regex, "regex");
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(evaluation, "evaluation");
		Guard.AssertGreaterThanOrEqualTo(times, -1, "times");
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
	public static string ReplaceText(Regex regex, string text, Func<Match, string> evaluation, int start, int count, int times = -1)
	{
		Guard.AssertNotNull(regex, "regex");
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(evaluation, "evaluation");
		Guard.AssertIndexRange(start, 0, text.Length - 1, "start");
		Guard.AssertBetween(count, 0, text.Length - start, "count");
		Guard.AssertGreaterThanOrEqualTo(times, -1, "times");
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
	public static string ReplaceLastText(Regex regex, string text, string replacement, int times = -1)
	{
		replacement = ObjectHelper.IfNull(replacement, string.Empty);
		return ReplaceLastText(regex, text, (Match m) => replacement, times);
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
	public static string ReplaceLastText(Regex regex, string text, string replacement, int start, int count, int times = -1)
	{
		replacement = ObjectHelper.IfNull(replacement, string.Empty);
		return ReplaceLastText(regex, text, (Match m) => replacement, start, count, times);
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
	public static string ReplaceLastText(Regex regex, string text, Func<Match, string> evaluation, int times = -1)
	{
		Guard.AssertNotNull(regex, "regex");
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(evaluation, "evaluation");
		Guard.AssertGreaterThanOrEqualTo(times, -1, "times");
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
	public static string ReplaceLastText(Regex regex, string text, Func<Match, string> evaluation, int start, int count, int times = -1)
	{
		Guard.AssertNotNull(regex, "regex");
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(evaluation, "evaluation");
		Guard.AssertIndexRange(start, 0, text.Length - 1, "start");
		Guard.AssertBetween(count, 0, start + 1, "count");
		Guard.AssertGreaterThanOrEqualTo(times, -1, "times");
		regex = EnsureRightToLeftOption(regex);
		int end = start - count;
		int matched = 0;
		return regex.Replace(text, (Match m) => (end < m.Index && m.Index <= start && m.Index + m.Length - 1 <= start && (times == -1 || ++matched <= times)) ? evaluation(m) : m.Value, int.MaxValue, start);
	}

	/// <summary>
	/// 饭庄当前文本中的字符顺序并返回反转后的新的文本
	/// </summary>
	/// <param name="text">当前本文</param>
	/// <returns>字符顺序反转后的文本</returns>
	public static string Reverse(string text)
	{
		Guard.AssertNotNull(text, "text");
		StringBuilder buff = new StringBuilder(text.Length);
		for (int i = 0; i < text.Length; i++)
		{
			buff.Append(text[i]);
		}
		return buff.ToString();
	}

	/// <summary>
	/// 获取当前文本右侧指定长度的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="count">右侧截取的字符数量</param>
	/// <returns>右侧截取的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">截取的字符数量 <paramref name="count" /> 小于0，或者大于当前文本中字符的数量。</exception>
	public static string Right(string text, int count)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertBetween(count, 0, text.Length, "count");
		return text.Substring(text.Length - count);
	}

	/// <summary>
	/// 将当前文本分割为指定长度的字符串数组
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="length">分割的字符串的长度</param>
	/// <returns>分割后的字符串数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">分割的字符串的长度小于1，或者大于当前文本的长度。</exception>
	public static string[] Split(string text, int length)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertBetween(length, 1, text.Length, "length");
		List<string> parts = new List<string>();
		int count = text.Length / length;
		for (int i = 0; i < count; i++)
		{
			parts.Add(text.Substring(length * i, length));
		}
		if (text.Length % length > 0)
		{
			parts.Add(text.Substring(length * count));
		}
		return parts.ToArray();
	}

	/// <summary>
	/// 将当前文本按照指定的分隔字符分解为字符串数组
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="separator">分隔字符</param>
	/// <param name="removeEmptyEntries">是否不包括含有空字符串的数组元素</param>
	/// <returns>分解后的字符串数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static string[] Split(string text, char separator, bool removeEmptyEntries = false)
	{
		return Split(text, new char[1] { separator }, removeEmptyEntries);
	}

	/// <summary>
	/// 将当前文本按照指定的分隔字符分解为字符串数组
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="separator">分隔字符</param>
	/// <param name="count">分解的字符串的数量</param>
	/// <param name="removeEmptyEntries">是否不包括含有空字符串的数组元素</param>
	/// <returns>分解后的字符串数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">分解的字符串的数量 <paramref name="count" /> 小于0。</exception>
	public static string[] Split(string text, char separator, int count, bool removeEmptyEntries = false)
	{
		return Split(text, new char[1] { separator }, count, removeEmptyEntries);
	}

	/// <summary>
	/// 将当前文本按照指定的分隔字符分解为字符串数组
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="separators">分隔字符数组</param>
	/// <param name="removeEmptyEntries">是否不包括含有空字符串的数组元素</param>
	/// <returns>分解后的字符串数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者分隔符数组 <paramref name="separators" /> 为空。</exception>
	public static string[] Split(string text, char[] separators, bool removeEmptyEntries)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(separators, "separators");
		return text.Split(separators, removeEmptyEntries ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None);
	}

	/// <summary>
	/// 将当前文本按照指定的分隔字符分解为字符串数组
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="separators">分隔字符数组</param>
	/// <param name="count">分解的字符串的数量</param>
	/// <param name="removeEmptyEntries">是否不包括含有空字符串的数组元素</param>
	/// <returns>分解后的字符串数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；分解的字符串的数量 <paramref name="separators" /> 为空。</exception>
	public static string[] Split(string text, char[] separators, int count, bool removeEmptyEntries)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(separators, "separators");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		return text.Split(separators, count, removeEmptyEntries ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None);
	}

	/// <summary>
	/// 将当前文本按指定的分隔字符串分解为字符串数组
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="separator">分隔字符串</param>
	/// <param name="removeEmptyEntries">是否不包括含有空字符串的数组元素</param>
	/// <returns>分解后的字符串数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者分隔字符串 <paramref name="separator" /> 为空。</exception>
	public static string[] Split(string text, string separator, bool removeEmptyEntries = false)
	{
		return Split(text, new string[1] { separator }, removeEmptyEntries);
	}

	/// <summary>
	/// 将当前文本按指定的分隔字符串分解为字符串数组
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="separator">分隔字符串</param>
	/// <param name="count">分解的字符串的数量</param>
	/// <param name="removeEmptyEntries">是否不包括含有空字符串的数组元素</param>
	/// <returns>分解后的字符串数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者分隔字符串 <paramref name="separator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">分解的字符串的数量 <paramref name="count" /> 小于0。</exception>
	public static string[] Split(string text, string separator, int count, bool removeEmptyEntries = false)
	{
		return Split(text, new string[1] { separator }, count, removeEmptyEntries);
	}

	/// <summary>
	/// 将当前文本按指定的分隔字符串分解为字符串数组
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="separators">分隔字符串数组</param>
	/// <param name="removeEmptyEntries">是否不包括含有空字符串的数组元素</param>
	/// <returns>分解后的字符串数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者分隔字符串数组 <paramref name="separators" /> 为空。</exception>
	public static string[] Split(string text, string[] separators, bool removeEmptyEntries)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(separators, "separators");
		return text.Split(separators, removeEmptyEntries ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None);
	}

	/// <summary>
	/// 将当前文本按指定的分隔字符串分解为字符串数组
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="separators">分隔字符串数组</param>
	/// <param name="count">分解的字符串的数量</param>
	/// <param name="removeEmptyEntries">是否不包括含有空字符串的数组元素</param>
	/// <returns>分解后的字符串数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者分隔字符串数组 <paramref name="separators" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">分解的字符串的数量 <paramref name="count" /> 小于0。</exception>
	public static string[] Split(string text, string[] separators, int count, bool removeEmptyEntries)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(separators, "separators");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		return text.Split(separators, count, removeEmptyEntries ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None);
	}

	/// <summary>
	/// 按指定的正则模式的分隔符将当前文本分解为字符串数组
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">分隔符的正则模式</param>
	/// <param name="removeEmptyEntries">是否不包括含有空字符串的数组元素</param>
	/// <param name="keepSpliter">是否保留分隔符作为分解的字符串数组中元素</param>
	/// <param name="options">正则模式参数</param>
	/// <returns>分解后的字符串数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者分隔符 <paramref name="pattern" /> 为空。</exception>
	public static string[] SplitRegex(string text, string pattern, bool removeEmptyEntries = false, bool keepSpliter = false, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return SplitRegex(text, ConvertHelper.ToRegex(pattern, options), removeEmptyEntries, keepSpliter);
	}

	/// <summary>
	/// 在当前文本中搜索符合指定正则模式的分隔符，并按照分隔符将文本分解为字符串数组
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">分隔符的正则模式</param>
	/// <param name="count">分解的字符串的数量</param>
	/// <param name="removeEmptyEntries">是否不包括含有空字符串的数组元素</param>
	/// <param name="keepSpliter">是否保留分隔符作为分解的字符串数组中元素</param>
	/// <param name="options">正则模式参数</param>
	/// <returns>分解后的字符串数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者分隔符 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">分割字符串的数量 <paramref name="count" /> 小于0。</exception>
	public static string[] SplitRegex(string text, string pattern, int count, bool removeEmptyEntries = false, bool keepSpliter = false, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		return SplitRegex(text, ConvertHelper.ToRegex(pattern, options), count, removeEmptyEntries, keepSpliter);
	}

	/// <summary>
	/// 在当前文本中搜索符合指定正则模式的分隔符，并按照分隔符将文本分解为字符串数组
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">分隔符的正则模式</param>
	/// <param name="removeEmptyEntries">是否不包括含有空字符串的数组元素</param>
	/// <param name="keepSpliter">是否保留分隔符作为分解的字符串数组中元素</param>
	/// <returns>分解后的字符串数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者分隔符的正则模式 <paramref name="pattern" /> 为空。</exception>
	public static string[] SplitRegex(string text, Regex pattern, bool removeEmptyEntries = false, bool keepSpliter = false)
	{
		return SplitRegex(text, pattern, (Match m, int i) => true, removeEmptyEntries, keepSpliter);
	}

	/// <summary>
	/// 在当前文本中搜索符合指定正则模式的分隔符，并按照分隔符将文本分解为字符串数组
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">分隔符的正则模式</param>
	/// <param name="count">分解的字符串的数量</param>
	/// <param name="removeEmptyEntries">是否不包括含有空字符串的数组元素</param>
	/// <param name="keepSpliter">是否保留分隔符作为分解的字符串数组中元素</param>
	/// <returns>分解后的字符串数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者分隔符的正则模式 <paramref name="pattern" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">分解的字符串数量 <paramref name="count" /> 小于0。</exception>
	public static string[] SplitRegex(string text, Regex pattern, int count, bool removeEmptyEntries = false, bool keepSpliter = false)
	{
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		int matched = 0;
		return SplitRegex(text, pattern, (Match m, int i) => ++matched <= count, removeEmptyEntries, keepSpliter);
	}

	/// <summary>
	/// 按符合正则模式的分隔符将当前文本分解为字符串数组
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">分隔符的正则模式</param>
	/// <param name="predicate">符合正则模式的分隔符筛选条件</param>
	/// <param name="removeEmptyEntries">是否不包括含有空字符串的数组元素，默认为false</param>
	/// <param name="keepSpliter">是否在分解的字符串数组中保留匹配的分割符，默认为false</param>
	/// <returns>分解后的字符串数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者分隔符 <paramref name="pattern" /> 为空；或者分隔符筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static string[] SplitRegex(string text, Regex pattern, Func<Match, bool> predicate, bool removeEmptyEntries = false, bool keepSpliter = false)
	{
		Guard.AssertNotNull(predicate, "predicate");
		return SplitRegex(text, pattern, (Match m, int i) => predicate(m), removeEmptyEntries, keepSpliter);
	}

	/// <summary>
	/// 按符合正则模式的分隔符将当前文本分解为字符串数组
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">分隔符的正则模式</param>
	/// <param name="predicate">符合正则模式的分隔符筛选条件；筛选条件方法接受的第二个参数是分隔符匹配的次数，从1开始计数。</param>
	/// <param name="removeEmptyEntries">是否不包括含有空字符串的数组元素，默认为false</param>
	/// <param name="keepSpliter">是否在分解的字符串数组中保留匹配的分割符，默认为false</param>
	/// <returns>分解后的字符串数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者分隔符 <paramref name="pattern" /> 为空；或者分隔符筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static string[] SplitRegex(string text, Regex pattern, Func<Match, int, bool> predicate, bool removeEmptyEntries = false, bool keepSpliter = false)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(pattern, "pattern");
		Guard.AssertNotNull(predicate, "predicate");
		List<string> parts = new List<string>();
		int index = 0;
		int count = 0;
		string part = null;
		foreach (Match i in pattern.Matches(text))
		{
			if (predicate(i, ++count))
			{
				part = text.Substring(index, i.Index - index);
				if (!removeEmptyEntries || part.Length > 0)
				{
					parts.Add(text.Substring(index, i.Index - index));
				}
				if (keepSpliter && (!removeEmptyEntries || i.Value.Length > 0))
				{
					parts.Add(i.Value);
				}
				index = i.Index + i.Length;
			}
		}
		part = text.Substring(index);
		if (!removeEmptyEntries || part.Length > 0)
		{
			parts.Add(text.Substring(index));
		}
		return parts.ToArray();
	}

	/// <summary>
	/// 获取当前可变字符的子字符串
	/// </summary>
	/// <param name="text">当前可变字符串</param>
	/// <param name="start">子字符串的起始位置</param>
	/// <returns>获取的子字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前可变字符串为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">起始位置小于0，或者大于当前可变字符串的最大索引。</exception>
	public static string Substring(StringBuilder text, int start)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertIndexRange(start, 0, text.Length - 1, "start");
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
	public static string Substring(StringBuilder text, int start, int count)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertIndexRange(start, 0, text.Length - 1, "start");
		Guard.AssertBetween(count, 0, text.Length - start, "count");
		return text.ToString(start, count);
	}

	/// <summary>
	/// 将当前字节数组按 <paramref name="encoding" /> 指定编码解码为字符串
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="encoding">转换的字符串使用的编码，默认使用 <see cref="P:System.Text.Encoding.UTF8" /> 编码</param>
	/// <returns>解码生成的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	public static string TextDecode(byte[] bytes, Encoding encoding = null)
	{
		Guard.AssertNotNull(bytes, "bytes");
		return ObjectHelper.IfNull(encoding, Encoding.UTF8).GetString(bytes);
	}

	/// <summary>
	/// 将当前字节数组按 <paramref name="encoding" /> 指定编码解码为字符串
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">开始转换的字节索引位置</param>
	/// <param name="count">转换的字节数量</param>
	/// <param name="encoding">转换的字符串使用的编码，默认使用 <see cref="P:System.Text.Encoding.UTF8" /> 编码</param>
	/// <returns>解码生成的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出了当前字节数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的字节数量。</exception>
	public static string TextDecode(byte[] bytes, int start, int count, Encoding encoding = null)
	{
		Guard.AssertNotNull(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "start");
		Guard.AssertBetween(count, 0, bytes.Length - start, "count");
		return ObjectHelper.IfNull(encoding, Encoding.UTF8).GetString(bytes, start, count);
	}

	/// <summary>
	/// 将当前字节序列按 <paramref name="encoding" /> 指定编码解码为字符串
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="encoding">转换的字符串使用的编码，默认使用 <see cref="P:System.Text.Encoding.UTF8" /> 编码</param>
	/// <returns>解码生成的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空。</exception>
	public static string TextDecode(IEnumerable<byte> bytes, Encoding encoding = null)
	{
		Guard.AssertNotNull(bytes, "bytes");
		encoding = ObjectHelper.IfNull(encoding, Encoding.UTF8);
		Decoder decoder = encoding.GetDecoder();
		StringBuilder text = new StringBuilder();
		byte[] buff = new byte[1024];
		char[] chars = new char[1024];
		int index = 0;
		int charCount = 0;
		foreach (byte b in bytes)
		{
			buff[index++] = b;
			if (index >= buff.Length)
			{
				charCount = decoder.GetChars(buff, 0, buff.Length, chars, 0);
				text.Append(chars, 0, charCount);
				index = 0;
			}
		}
		if (index > 0)
		{
			charCount = decoder.GetChars(buff, 0, index, chars, 0, flush: true);
			text.Append(chars, 0, charCount);
		}
		return text.ToString();
	}

	/// <summary>
	/// 将当前字符按 <paramref name="encoding" /> 指定的编码，编码为字节数据
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <param name="encoding">转换使用的编码，默认使用 <see cref="P:System.Text.Encoding.UTF8" /> 编码</param>
	/// <returns>编码生成的字节数据</returns>
	public static byte[] TextEncode(char c, Encoding encoding = null)
	{
		return ObjectHelper.IfNull(encoding, Encoding.UTF8).GetBytes(new char[1] { c });
	}

	/// <summary>
	/// 将当前字符数组按 <paramref name="encoding" /> 指定的编码，编码为字节数据
	/// </summary>
	/// <param name="chars">当前字符数组</param>
	/// <param name="encoding">转换使用的编码，默认使用 <see cref="P:System.Text.Encoding.UTF8" /> 编码</param>
	/// <returns>编码生成的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static byte[] TextEncode(char[] chars, Encoding encoding = null)
	{
		Guard.AssertNotNull(chars, "chars");
		return ObjectHelper.IfNull(encoding, Encoding.UTF8).GetBytes(chars);
	}

	/// <summary>
	/// 将当前字符数组按 <paramref name="encoding" /> 指定的编码，编码为字节数据
	/// </summary>
	/// <param name="chars">当前字符数组</param>
	/// <param name="start">开始转换的字符索引位置</param>
	/// <param name="count">转换的字符数量</param>
	/// <param name="encoding">转换使用的编码，默认使用 <see cref="P:System.Text.Encoding.UTF8" /> 编码</param>
	/// <returns>编码生成的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出了当前字符数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的字符数量。</exception>
	public static byte[] TextEncode(char[] chars, int start, int count, Encoding encoding = null)
	{
		Guard.AssertNotNull(chars, "chars");
		Guard.AssertIndexRange(start, 0, chars.Length - 1, "start");
		Guard.AssertBetween(count, 0, chars.Length - start, "count");
		return ObjectHelper.IfNull(encoding, Encoding.UTF8).GetBytes(chars, start, count);
	}

	/// <summary>
	/// 将当前字符序列按 <paramref name="encoding" /> 指定编码，编码为字节数据
	/// </summary>
	/// <param name="chars">当前字符序列</param>
	/// <param name="encoding">转换使用的编码，默认使用 <see cref="P:System.Text.Encoding.UTF8" /> 编码</param>
	/// <returns>编码生成的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空。</exception>
	public static byte[] TextEncode(IEnumerable<char> chars, Encoding encoding = null)
	{
		Guard.AssertNotNull(chars, "chars");
		encoding = ObjectHelper.IfNull(encoding, Encoding.UTF8);
		Encoder encoder = encoding.GetEncoder();
		List<byte> result = new List<byte>();
		char[] buff = new char[1024];
		byte[] bytes = new byte[4096];
		int index = 0;
		int byteCount = 0;
		foreach (char c in chars)
		{
			buff[index++] = c;
			if (index >= buff.Length)
			{
				byteCount = encoder.GetBytes(buff, 0, buff.Length, bytes, 0, flush: false);
				for (int i = 0; i < byteCount; i++)
				{
					result.Add(bytes[i]);
				}
				index = 0;
			}
		}
		if (index > 0)
		{
			byteCount = encoder.GetBytes(buff, 0, index, bytes, 0, flush: true);
			for (int i = 0; i < byteCount; i++)
			{
				result.Add(bytes[i]);
			}
		}
		return result.ToArray();
	}

	/// <summary>
	/// 根据指定的文本编码将当前文本编码为字节数组
	/// </summary>
	/// <param name="text">当前待编码的文本</param>
	/// <param name="encoding">编码文本所使用的编码，默认为UTF-8</param>
	/// <returns>编码后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static byte[] TextEncode(string text, Encoding encoding = null)
	{
		Guard.AssertNotNull(text, "text");
		encoding = ObjectHelper.IfNull(encoding, Encoding.UTF8);
		return encoding.GetBytes(text);
	}

	/// <summary>
	/// 根据指定的文本编码将当前文本编码为字节数组
	/// </summary>
	/// <param name="text">当前待编码的文本</param>
	/// <param name="start">开始编码的字符索引位置</param>
	/// <param name="count">编码的字符数量</param>
	/// <param name="encoding">编码文本所使用的编码，默认为UTF-8</param>
	/// <returns>编码生成的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">起始索引位置 <paramref name="start" /> 超出了当前文本中字符的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">字符数量 <paramref name="count" /> 小于0，或者大于从起始索引位置 <paramref name="start" /> 起字符串中剩余的字符数量。</exception>
	public static byte[] TextEncode(string text, int start, int count, Encoding encoding = null)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertIndexRange(start, 0, text.Length - 1, "start");
		Guard.AssertBetween(count, 0, text.Length - start, "count");
		encoding = ObjectHelper.IfNull(encoding, Encoding.UTF8);
		int buffSize = encoding.GetMaxByteCount(count);
		byte[] buff = new byte[buffSize];
		int resultSize = encoding.GetBytes(text, start, count, buff, 0);
		if (resultSize == buffSize)
		{
			return buff;
		}
		byte[] result = new byte[resultSize];
		Array.Copy(buff, 0, result, 0, resultSize);
		return result;
	}

	/// <summary>
	/// 将当前字符转换为小写形式
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <param name="culture">转换时使用的区域，为空则使用当前线程的区域特性进行转换</param>
	/// <returns>当前字符的小写形式</returns>
	public static char ToLower(char c, CultureInfo culture = null)
	{
		return ObjectHelper.IfNull(culture, CultureInfo.CurrentCulture).TextInfo.ToLower(c);
	}

	/// <summary>
	/// 将当前字符数组中每个字符转换为小写形式
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <param name="culture">转换时使用的区域信息，为空则使用当前线程的区域特性进行转换</param>
	/// <returns>转换后的当前字符数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static char[] ToLower(char[] cs, CultureInfo culture = null)
	{
		Guard.AssertNotNull(cs, "chars");
		return ToLower(cs, 0, cs.Length, culture);
	}

	/// <summary>
	/// 将当前字符数组中指定范围内的每个字符转换为小写形式
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <param name="start">开始转换的字符索引</param>
	/// <param name="count">转换的字符数量</param>
	/// <param name="culture">转换时使用的区域信息，为空则使用当前线程的区域特性进行转换</param>
	/// <returns>转换后的当前字符数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的字符索引 <paramref name="start" /> 超出了当前字符数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的字符数量 <paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的字符数量。</exception>
	public static char[] ToLower(char[] cs, int start, int count, CultureInfo culture = null)
	{
		Guard.AssertNotNull(cs, "chars");
		Guard.AssertIndexRange(start, 0, cs.Length - 1, "start");
		Guard.AssertBetween(count, 0, cs.Length - start, "count");
		culture = ObjectHelper.IfNull(culture, CultureInfo.CurrentCulture);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			cs[i] = ToLower(cs[i], culture);
		}
		return cs;
	}

	/// <summary>
	/// 将当前字符序列中每个字符转换为其小写形式
	/// </summary>
	/// <param name="cs">当前字符序列</param>
	/// <param name="culture">转换时使用的区域信息，为空则使用当前线程的区域特性进行转换</param>
	/// <returns>转换生成的新的字符序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符序列为空。</exception>
	public static IEnumerable<char> ToLower(IEnumerable<char> cs, CultureInfo culture = null)
	{
		Guard.AssertNotNull(cs, "chars");
		culture = ObjectHelper.IfNull(culture, CultureInfo.CurrentCulture);
		return cs.Select((char c) => ToLower(c, culture));
	}

	/// <summary>
	/// 将当前字符转换为由指定数量的当前字符组成的字符串
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <param name="count">生成的字符的数量</param>
	/// <returns>生成的字符串</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">生成的字符数量 <paramref name="count" /> 小于0。</exception>
	public static string ToString(char c, int count)
	{
		return BuildString(c, count);
	}

	/// <summary>
	/// 将当前字符数组转换为由字符数组指定范围内的字符组成的字符串
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <param name="start">开始转换的字符索引</param>
	/// <returns>生成的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始的转换的字符索引 <paramref name="start" /> 小于，或则大于当前字符数组的最大索引数量。</exception>
	public static string ToString(char[] cs, int start)
	{
		Guard.AssertNotNull(cs, "chars");
		return BuildString(cs, start, cs.Length - start);
	}

	/// <summary>
	/// 将当前字符数组转换为由字符数组指定范围内的字符组成的字符串
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <param name="start">开始转换的字符索引</param>
	/// <param name="count">转换的字符数量</param>
	/// <returns>生成的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始的转换的字符索引 <paramref name="start" /> 小于，或则大于当前字符数组的最大索引数量。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的字符个数小于0，或者大于当前字符数组的剩余字符个数。</exception>
	public static string ToString(char[] cs, int start, int count)
	{
		return BuildString(cs, start, count);
	}

	/// <summary>
	/// 将当前字符转换为大写形式
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <param name="culture">转换时使用的区域，为空则使用当前线程的区域特性进行转换</param>
	/// <returns>当前字符的大写形式</returns>
	public static char ToUpper(char c, CultureInfo culture = null)
	{
		return ObjectHelper.IfNull(culture, CultureInfo.CurrentCulture).TextInfo.ToUpper(c);
	}

	/// <summary>
	/// 将当前字符数组中的字符转换为大写形式
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <param name="culture">转换时使用的区域，为空则使用当前线程的区域特性进行转换</param>
	/// <returns>转换后的当前字符数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static char[] ToUpper(char[] cs, CultureInfo culture = null)
	{
		Guard.AssertNotNull(cs, "chars");
		return ToUpper(cs, 0, cs.Length, culture);
	}

	/// <summary>
	/// 将当前字符数组中指定范围内的字符转换为大写形式
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <param name="start">开始转换的字符索引</param>
	/// <param name="count">转换的字符数量</param>
	/// <param name="culture">转换时使用的区域，为空则使用当前线程的区域特性进行转换</param>
	/// <returns>转换后的当前字符数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的字符索引 <paramref name="start" /> 超出了当前字符数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的字符数量 <paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的字符数量。</exception>
	public static char[] ToUpper(char[] cs, int start, int count, CultureInfo culture = null)
	{
		Guard.AssertNotNull(cs, "chars");
		Guard.AssertIndexRange(start, 0, cs.Length - 1, "start");
		Guard.AssertBetween(count, 0, cs.Length - count, "count");
		culture = ObjectHelper.IfNull(culture, CultureInfo.CurrentCulture);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			cs[i] = ToUpper(cs[i], culture);
		}
		return cs;
	}

	/// <summary>
	/// 将当前字符序列中的字符转换为大写形式
	/// </summary>
	/// <param name="cs">当前字符序列</param>
	/// <param name="culture">转换时使用的区域信息，为空则使用当前线程的区域特性进行转换</param>
	/// <returns>转换为大写形式的字符序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符序列为空。</exception>
	public static IEnumerable<char> ToUpper(IEnumerable<char> cs, CultureInfo culture = null)
	{
		Guard.AssertNotNull(cs, "chars");
		return cs.Select((char c) => ToUpper(c, culture));
	}

	/// <summary>
	/// 从当前文本中移除与给定字符数组中字符相同的前导字符和尾部字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="trimingChars">待移除的字符数组</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者待移除的字符数组 <paramref name="trimingChars" /> 为空。</exception>
	public static string Trim(string text, char[] trimingChars, bool ignoreCase = false)
	{
		return Trim(text, trimingChars, CultureInfo.CurrentCulture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 从当前文本中移除与给定字符数组中字符相同的前导字符和尾部字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="trimingChars">待移除的字符数组</param>
	/// <param name="culture">字符比较时使用的区域信息，默认为当前线程的区域信息。</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者待移除的字符数组 <paramref name="trimingChars" /> 为空。</exception>
	public static string Trim(string text, char[] trimingChars, CultureInfo culture, bool ignoreCase = false)
	{
		return Trim(text, trimingChars, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 从当前文本中移除与给定字符数组中字符相同的前导字符和尾部字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="trimingChars">待移除的字符数组</param>
	/// <param name="culture">字符比较时使用的区域信息，默认为当前线程的区域信息。</param>
	/// <param name="options">字符比较的选项</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者待移除的字符数组 <paramref name="trimingChars" /> 为空。</exception>
	public static string Trim(string text, char[] trimingChars, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(trimingChars, "triming chars");
		int start;
		for (start = 0; start < text.Length && trimingChars.Any((char c) => IsEqualTo(c, text[start], culture, options)); start++)
		{
		}
		int end;
		for (end = text.Length - 1; end >= 0 && trimingChars.Any((char c) => IsEqualTo(c, text[end], culture, options)); end--)
		{
		}
		if (start <= end)
		{
			return text.Substring(start, end - start + 1);
		}
		return string.Empty;
	}

	/// <summary>
	/// 从当前字符串移除和指定的字符串匹配的所有前导字符串和尾部字符串。
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="trimingText">要移除的字符串，如果指定的字符串为空串，则不移除任何字符</param>
	/// <param name="ignoreCase">字符串是否区分大小写</param>
	/// <returns>处理后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者待移除的字符串 <paramref name="trimingText" /> 为空。</exception>
	public static string Trim(string text, string trimingText, bool ignoreCase = false)
	{
		return Trim(text, trimingText, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
	}

	/// <summary>
	/// 从当前文本中移除与指定字符串匹配的所有前导字符串和尾部字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="trimingText">要移除的字符串，如果指定的字符串为空串，则不移除任何字符</param>
	/// <param name="comparison">字符串比较方式</param>
	/// <returns>处理后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者待移除的字符串 <paramref name="trimingText" /> 为空。</exception>
	public static string Trim(string text, string trimingText, StringComparison comparison)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(trimingText, "triming text");
		if (trimingText.Length == 0)
		{
			return text;
		}
		int start;
		for (start = 0; start < trimingText.Length && text.IndexOf(trimingText, start, trimingText.Length, comparison) >= 0; start += trimingText.Length)
		{
		}
		int end = text.Length - 1;
		while (end >= 0 && text.LastIndexOf(trimingText, end, trimingText.Length, comparison) >= 0)
		{
			end -= trimingText.Length;
		}
		if (start <= end)
		{
			return text.Substring(start, end - start + 1);
		}
		return string.Empty;
	}

	/// <summary>
	/// 从当前文本中移除与指定字符串匹配的所有前导字符串和尾部字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="trimingText">要移除的字符串，如果指定的字符串为空串，则不移除任何字符</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>处理后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者待移除的字符串 <paramref name="trimingText" /> 为空。</exception>
	public static string Trim(string text, string trimingText, CultureInfo culture, bool ignoreCase = false)
	{
		return Trim(text, trimingText, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 从当前文本中移除与指定字符串匹配的所有前导字符串和尾部字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="trimingText">要移除的字符串，如果指定的字符串为空串，则不移除任何字符</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="options">比较字符的选项</param>
	/// <returns>处理后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者待移除的字符串 <paramref name="trimingText" /> 为空。</exception>
	public static string Trim(string text, string trimingText, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(trimingText, "triming text");
		if (trimingText.Length == 0)
		{
			return text;
		}
		int start;
		for (start = 0; start < trimingText.Length && IndexOf(text, trimingText, start, trimingText.Length, culture, options) >= 0; start += trimingText.Length)
		{
		}
		int end = text.Length - 1;
		while (end >= 0 && LastIndexOf(text, trimingText, end, trimingText.Length, culture, options) >= 0)
		{
			end -= trimingText.Length;
		}
		if (start <= end)
		{
			return text.Substring(start, end - start + 1);
		}
		return string.Empty;
	}

	/// <summary>
	/// 从当前文本中移除与给定字符数组中字符相同的前导字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="trimingChars">待移除的字符数组</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者待移除的字符数组 <paramref name="trimingChars" /> 为空。</exception>
	public static string TrimStart(string text, char[] trimingChars, bool ignoreCase = false)
	{
		return TrimStart(text, trimingChars, CultureInfo.CurrentCulture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 从当前文本中移除与给定字符数组中字符相同的前导字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="trimingChars">待移除的字符数组</param>
	/// <param name="culture">字符比较时使用的区域信息，默认为当前线程的区域信息。</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者待移除的字符数组 <paramref name="trimingChars" /> 为空。</exception>
	public static string TrimStart(string text, char[] trimingChars, CultureInfo culture, bool ignoreCase = false)
	{
		return TrimStart(text, trimingChars, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 从当前文本中移除与给定字符数组中字符相同的前导字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="trimingChars">待移除的字符数组</param>
	/// <param name="culture">字符比较时使用的区域信息，默认为当前线程的区域信息。</param>
	/// <param name="options">字符比较时的选项</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空，或者待移除的字符数组 <paramref name="trimingChars" /> 为空。</exception>
	public static string TrimStart(string text, char[] trimingChars, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(trimingChars, "triming chars");
		int start;
		for (start = 0; start < text.Length && trimingChars.Any((char c) => IsEqualTo(c, text[start], culture, options)); start++)
		{
		}
		return (start < text.Length) ? text.Substring(start) : string.Empty;
	}

	/// <summary>
	/// 从当前字符串移除和指定的字符串匹配的所有前导字符串。
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="trimingText">要移除的字符串，如果指定的字符串为空串，则不移除任何字符</param>
	/// <param name="ignoreCase">字符串是否区分大小写</param>
	/// <returns>处理后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者待移除的字符串 <paramref name="trimingText" /> 为空。</exception>
	public static string TrimStart(string text, string trimingText, bool ignoreCase = false)
	{
		return TrimStart(text, trimingText, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
	}

	/// <summary>
	/// 从当前文本中移除与指定字符串匹配的所有前导字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="trimingText">要移除的字符串，如果指定的字符串为空串，则不移除任何字符</param>
	/// <param name="comparison">字符串比较方式</param>
	/// <returns>处理后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者待移除的字符串 <paramref name="trimingText" /> 为空。</exception>
	public static string TrimStart(string text, string trimingText, StringComparison comparison)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(trimingText, "triming text");
		if (trimingText.Length == 0)
		{
			return text;
		}
		int start;
		for (start = 0; start < trimingText.Length && text.IndexOf(trimingText, start, trimingText.Length, comparison) >= 0; start += trimingText.Length)
		{
		}
		return (start < trimingText.Length) ? text.Substring(start) : string.Empty;
	}

	/// <summary>
	/// 从当前文本中移除与指定字符串匹配的所有前导字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="trimingText">要移除的字符串，如果指定的字符串为空串，则不移除任何字符</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>处理后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者待移除的字符串 <paramref name="trimingText" /> 为空。</exception>
	public static string TrimStart(string text, string trimingText, CultureInfo culture, bool ignoreCase = false)
	{
		return TrimStart(text, trimingText, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 从当前文本中移除与指定字符串匹配的所有前导字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="trimingText">要移除的字符串，如果指定的字符串为空串，则不移除任何字符</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="options">比较字符时的选项</param>
	/// <returns>处理后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者待移除的字符串 <paramref name="trimingText" /> 为空。</exception>
	public static string TrimStart(string text, string trimingText, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(trimingText, "triming text");
		if (trimingText.Length == 0)
		{
			return text;
		}
		int start;
		for (start = 0; start < trimingText.Length && IndexOf(text, trimingText, start, trimingText.Length, culture, options) >= 0; start += trimingText.Length)
		{
		}
		return (start < trimingText.Length) ? text.Substring(start) : string.Empty;
	}

	/// <summary>
	/// 从当前文本中移除与给定字符数组中字符相同的前导字符和尾部字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="trimingChars">待移除的字符数组</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者待移除的字符数组 <paramref name="trimingChars" /> 为空。</exception>
	public static string TrimEnd(string text, char[] trimingChars, bool ignoreCase = false)
	{
		return TrimEnd(text, trimingChars, CultureInfo.CurrentCulture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 从当前文本中移除与给定字符数组中字符相同的尾部字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="trimingChars">待移除的字符数组</param>
	/// <param name="culture">字符比较时使用的区域信息，默认为当前线程的区域信息。</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者待移除的字符数组 <paramref name="trimingChars" /> 为空。</exception>
	public static string TrimEnd(string text, char[] trimingChars, CultureInfo culture, bool ignoreCase = false)
	{
		return TrimEnd(text, trimingChars, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 从当前文本中移除与给定字符数组中字符相同的尾部字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="trimingChars">待移除的字符数组</param>
	/// <param name="culture">字符比较时使用的区域信息，默认为当前线程的区域信息。</param>
	/// <param name="options">比较字符时的选项</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者待移除的字符串 <paramref name="trimingChars" /> 为空。</exception>
	public static string TrimEnd(string text, char[] trimingChars, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(trimingChars, "triming chars");
		int start;
		for (start = 0; start < text.Length && trimingChars.Any((char c) => IsEqualTo(c, text[start], culture, options)); start++)
		{
		}
		return (start < text.Length) ? text.Substring(start) : string.Empty;
	}

	/// <summary>
	/// 从当前字符串移除和指定的字符串匹配的所有尾部字符串。
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="trimingText">要移除的字符串，如果指定的字符串为空串，则不移除任何字符</param>
	/// <param name="ignoreCase">字符串是否区分大小写</param>
	/// <returns>处理后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者待移除的字符串 <paramref name="trimingText" /> 为空。</exception>
	public static string TrimEnd(string text, string trimingText, bool ignoreCase = false)
	{
		return TrimEnd(text, trimingText, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
	}

	/// <summary>
	/// 从当前文本中移除与指定字符串匹配的所有尾部字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="trimingText">要移除的字符串，如果指定的字符串为空串，则不移除任何字符</param>
	/// <param name="comparison">字符串比较方式</param>
	/// <returns>处理后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者待移除的字符串 <paramref name="trimingText" /> 为空。</exception>
	public static string TrimEnd(string text, string trimingText, StringComparison comparison)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(trimingText, "triming text");
		int end = text.Length - 1;
		while (end >= 0 && text.LastIndexOf(trimingText, end, trimingText.Length, comparison) >= 0)
		{
			end -= trimingText.Length;
		}
		return (end >= 0) ? text.Substring(0, end + 1) : string.Empty;
	}

	/// <summary>
	/// 从当前文本中移除与指定字符串匹配的所有尾部字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="trimingText">要移除的字符串，如果指定的字符串为空串，则不移除任何字符</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>处理后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者待移除的字符串 <paramref name="trimingText" /> 为空。</exception>
	public static string TrimEnd(string text, string trimingText, CultureInfo culture, bool ignoreCase = false)
	{
		return TrimEnd(text, trimingText, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
	}

	/// <summary>
	/// 从当前文本中移除与指定字符串匹配的所有尾部字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="trimingText">要移除的字符串，如果指定的字符串为空串，则不移除任何字符</param>
	/// <param name="culture">比较字符时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="options">比较字符时的选项</param>
	/// <returns>处理后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者待移除的字符串 <paramref name="trimingText" /> 为空。</exception>
	public static string TrimEnd(string text, string trimingText, CultureInfo culture, CompareOptions options)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertNotNull(trimingText, "triming text");
		int end = text.Length - 1;
		while (end >= 0 && LastIndexOf(text, trimingText, end, trimingText.Length, culture, options) >= 0)
		{
			end -= trimingText.Length;
		}
		return (end >= 0) ? text.Substring(0, end + 1) : string.Empty;
	}

	/// <summary>
	/// 使用Unicode编码对当前字节数据进行解码，返回解码后的字符串
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <returns>解码后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数据为空。</exception>
	public static string UnicodeDecode(byte[] data)
	{
		return TextDecode(data, Encoding.Unicode);
	}

	/// <summary>
	/// 使用Unicode编码对当前字节数据进行解码，返回解码后的字符串
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <param name="start">开始转换的字节索引位置</param>
	/// <param name="count">转换的字节数量</param>
	/// <returns>解码后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数据为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出了当前字节数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的字节数量。</exception>
	public static string UnicodeDecode(byte[] data, int start, int count)
	{
		return TextDecode(data, start, count, Encoding.Unicode);
	}

	/// <summary>
	/// 使用Unicode编码对当前字节序列进行解码，返回解码后的字符串
	/// </summary>
	/// <param name="data">当前字节序列</param>
	/// <returns>解码后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空。</exception>
	public static string UnicodeDecode(IEnumerable<byte> data)
	{
		return TextDecode(data, Encoding.Unicode);
	}

	/// <summary>
	/// 将当前字符按Unicode编码，编码为字节数据
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>编码生成的字节数据</returns>
	public static byte[] UnicodeEncode(char c)
	{
		return TextEncode(c, Encoding.Unicode);
	}

	/// <summary>
	/// 将当前字符数组按Unicode编码，编码为字节数据
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <returns>编码生成的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static byte[] UnicodeEncode(char[] cs)
	{
		return TextEncode(cs, Encoding.Unicode);
	}

	/// <summary>
	/// 将当前字符数组按Unicode编码，编码为字节数据
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <param name="start">开始转换的字符索引位置</param>
	/// <param name="count">转换的字符数量</param>
	/// <returns>编码生成的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出了当前字符数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的字符数量。</exception>
	public static byte[] UnicodeEncode(char[] cs, int start, int count)
	{
		return TextEncode(cs, start, count, Encoding.Unicode);
	}

	/// <summary>
	/// 将当前字符序列按Unicode编码，编码为的字节数据
	/// </summary>
	/// <param name="cs">当前字符序列</param>
	/// <returns>编码生成的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static byte[] UnicodeEncode(IEnumerable<char> cs)
	{
		return TextEncode(cs, Encoding.Unicode);
	}

	/// <summary>
	/// 使用Unicode编码对当前文本进行编码，返回编码后的字节数据
	/// </summary>
	/// <param name="text">当前待编码的文本</param>
	/// <returns>编码后的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static byte[] UnicodeEncode(string text)
	{
		return TextEncode(text, Encoding.Unicode);
	}

	/// <summary>
	/// 使用Unicode编码对当前文本进行编码，返回编码后的字节数据
	/// </summary>
	/// <param name="text">当前待编码的文本</param>
	/// <param name="start">开始编码的字符索引位置</param>
	/// <param name="count">编码的字符数量</param>
	/// <returns>编码生成的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">起始索引位置 <paramref name="start" /> 超出了当前文本中字符的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">字符数量 <paramref name="count" /> 小于0，或者大于从起始索引位置 <paramref name="start" /> 起字符串中剩余的字符数量。</exception>
	public static byte[] UnicodeEncode(string text, int start, int count)
	{
		return TextEncode(text, start, count, Encoding.Unicode);
	}

	/// <summary>
	/// 将当前URL编码的字符串解码为字符串
	/// </summary>
	/// <param name="text">当前URL编码的字符串</param>
	/// <param name="encoding">编码时使用的字符编码</param>
	/// <returns>解码后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前URL编码的字符串为空。</exception>
	public static string UrlDecode(string text, Encoding encoding = null)
	{
		Guard.AssertNotNull(text, "text");
		return ObjectHelper.IsNull(encoding) ? HttpUtility.UrlDecode(text) : HttpUtility.UrlDecode(text, encoding);
	}

	/// <summary>
	/// 将当前URL编码的字符串编码为字节数组
	/// </summary>
	/// <param name="text">当前URL编码的字符串</param>
	/// <param name="encoding">编码时使用的字符编码</param>
	/// <returns>编码后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前URL编码的字符串为空。</exception>
	public static byte[] UrlDecodeToBytes(string text, Encoding encoding = null)
	{
		Guard.AssertNotNull(text, "text");
		return ObjectHelper.IsNull(encoding) ? HttpUtility.UrlDecodeToBytes(text) : HttpUtility.UrlDecodeToBytes(text, encoding);
	}

	/// <summary>
	/// 将当前字符数组编码为Url编码的字符串
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <param name="encoding">转换使用的编码，默认使用UTF-8编码</param>
	/// <returns>编码生成的字节数据</returns>
	public static string UrlEncode(char c, Encoding encoding = null)
	{
		return UrlEncode(c.ToString(), encoding);
	}

	/// <summary>
	/// 将当前字符数组编码为Url编码的字符串
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <param name="encoding">转换使用的编码，默认使用UTF-8编码</param>
	/// <returns>编码生成的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static string UrlEncode(char[] cs, Encoding encoding = null)
	{
		Guard.AssertNotNull(cs, "chars");
		return UrlEncode(new string(cs), encoding);
	}

	/// <summary>
	/// 将当前字符数组转换为Url编码的字符串
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <param name="start">开始转换的字符索引位置</param>
	/// <param name="count">转换的字符数量</param>
	/// <param name="encoding">转换使用的编码，默认使用UTF-8编码</param>
	/// <returns>编码生成的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出了当前字符数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的字符数量。</exception>
	public static string UrlEncode(char[] cs, int start, int count, Encoding encoding = null)
	{
		Guard.AssertNotNull(cs, "chars");
		Guard.AssertIndexRange(start, 0, cs.Length - 1, "start");
		Guard.AssertBetween(count, 0, cs.Length - start, "count");
		return UrlEncode(new string(cs, start, count), encoding);
	}

	/// <summary>
	/// 将当前字符序列转换为Url编码的字符串
	/// </summary>
	/// <param name="cs">当前字符序列</param>
	/// <param name="encoding">转换使用的编码，默认使用UTF-8编码</param>
	/// <returns>编码生成的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static string UrlEncode(IEnumerable<char> cs, Encoding encoding = null)
	{
		Guard.AssertNotNull(cs, "chars");
		return UrlEncode(cs.ToArray(), encoding);
	}

	/// <summary>
	/// 将当前待编码的字符串编码为Url字符串
	/// </summary>
	/// <param name="text">当前待编码的字符串</param>
	/// <param name="encoding">编码时使用的字符编码</param>
	/// <returns>编码后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前待编码的字符串为空。</exception>
	public static string UrlEncode(string text, Encoding encoding = null)
	{
		Guard.AssertNotNull(text, "text");
		return ObjectHelper.IsNull(encoding) ? HttpUtility.UrlEncode(text) : HttpUtility.UrlEncode(text, encoding);
	}

	/// <summary>
	/// 将当前字符数组编码为Url编码的字节数据
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <param name="encoding">转换使用的编码，默认使用UTF-8编码</param>
	/// <returns>编码生成的字节数据</returns>
	public static byte[] UrlEncodeToBytes(char c, Encoding encoding = null)
	{
		return UrlEncodeToBytes(c.ToString(), encoding);
	}

	/// <summary>
	/// 将当前字符数组编码为Url编码的字节数据
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <param name="encoding">转换使用的编码，默认使用UTF-8编码</param>
	/// <returns>编码生成的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static byte[] UrlEncodeToBytes(char[] cs, Encoding encoding = null)
	{
		Guard.AssertNotNull(cs, "chars");
		return UrlEncodeToBytes(new string(cs), encoding);
	}

	/// <summary>
	/// 将当前字符数组转换为Url编码的字节数据
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <param name="start">开始转换的字符索引位置</param>
	/// <param name="count">转换的字符数量</param>
	/// <param name="encoding">转换使用的编码，默认使用UTF-8编码</param>
	/// <returns>编码生成的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出了当前字符数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的字符数量。</exception>
	public static byte[] UrlEncodeToBytes(char[] cs, int start, int count, Encoding encoding = null)
	{
		Guard.AssertNotNull(cs, "chars");
		Guard.AssertIndexRange(start, 0, cs.Length - 1, "start");
		Guard.AssertBetween(count, 0, cs.Length - start, "count");
		return UrlEncodeToBytes(new string(cs, start, count), encoding);
	}

	/// <summary>
	/// 将当前字符序列编码为Url编码的字节数据
	/// </summary>
	/// <param name="cs">当前字符序列</param>
	/// <param name="encoding">字符编码</param>
	/// <returns>编码生成的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static byte[] UrlEncodeToBytes(IEnumerable<char> cs, Encoding encoding = null)
	{
		Guard.AssertNotNull(cs, "chars");
		return UrlEncodeToBytes(cs.ToArray(), encoding);
	}

	/// <summary>
	/// 将当前待编码的字符串编码为字节数组
	/// </summary>
	/// <param name="text">当前待编码的字符串</param>
	/// <param name="encoding">编码使用的字符编码</param>
	/// <returns>编码后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前待编码的字符串为空。</exception>
	public static byte[] UrlEncodeToBytes(string text, Encoding encoding = null)
	{
		Guard.AssertNotNull(text, "text");
		return ObjectHelper.IsNull(encoding) ? HttpUtility.UrlEncodeToBytes(text) : HttpUtility.UrlEncodeToBytes(text, encoding);
	}

	/// <summary>
	/// 使用UTF-8编码对当前字节数据进行解码，返回解码后的字符串
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <returns>解码后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数据为空。</exception>
	public static string Utf8Decode(byte[] data)
	{
		return TextDecode(data, Encoding.UTF8);
	}

	/// <summary>
	/// 使用UTF-8编码对当前字节数据进行解码，返回解码后的字符串
	/// </summary>
	/// <param name="data">当前字节数据</param>
	/// <param name="start">开始转换的字节索引位置</param>
	/// <param name="count">转换的字节数量</param>
	/// <returns>解码后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数据为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出了当前字节数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的字节数量。</exception>
	public static string Utf8Decode(byte[] data, int start, int count)
	{
		return TextDecode(data, start, count, Encoding.UTF8);
	}

	/// <summary>
	/// 使用UTF-8编码对当前字节序列进行解码，返回解码后的字符串
	/// </summary>
	/// <param name="data">当前字节序列</param>
	/// <returns>解码后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空。</exception>
	public static string Utf8Decode(IEnumerable<byte> data)
	{
		return TextDecode(data, Encoding.UTF8);
	}

	/// <summary>
	/// 将当前字符按UTF-8编码，编码为字节数据
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>编码生成的字节数据</returns>
	public static byte[] Utf8Encode(char c)
	{
		return TextEncode(c, Encoding.UTF8);
	}

	/// <summary>
	/// 将当前字符数组按UTF-8编码，编码为字节数据
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <returns>编码生成的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static byte[] Utf8Encode(char[] cs)
	{
		return TextEncode(cs, Encoding.UTF8);
	}

	/// <summary>
	/// 将当前字符数组按UTF8编码，编码为字节数据
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <param name="start">开始转换的字符索引位置</param>
	/// <param name="count">转换的字符数量</param>
	/// <returns>编码生成的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出了当前字符数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的字符数量。</exception>
	public static byte[] Utf8Encode(char[] cs, int start, int count)
	{
		return TextEncode(cs, start, count, Encoding.UTF8);
	}

	/// <summary>
	/// 将当前字符序列按UTF-8编码，编码为的字节数据
	/// </summary>
	/// <param name="cs">当前字符序列</param>
	/// <returns>编码生成的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static byte[] Utf8Encode(IEnumerable<char> cs)
	{
		return TextEncode(cs, Encoding.UTF8);
	}

	/// <summary>
	/// 使用UTF-8编码对当前文本进行编码，返回编码后的字节数据
	/// </summary>
	/// <param name="text">当前待编码的文本</param>
	/// <returns>编码后的字节数据</returns>
	public static byte[] Utf8Encode(string text)
	{
		return TextEncode(text, Encoding.UTF8);
	}

	/// <summary>
	/// 使用UTF-8编码对当前文本进行编码，返回编码后的字节数据
	/// </summary>
	/// <param name="text">当前待编码的文本</param>
	/// <param name="start">开始编码的字符索引位置</param>
	/// <param name="count">编码的字符数量</param>
	/// <returns>编码生成的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">起始索引位置 <paramref name="start" /> 超出了当前文本中字符的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">字符数量 <paramref name="count" /> 小于0，或者大于从起始索引位置 <paramref name="start" /> 起字符串中剩余的字符数量。</exception>
	public static byte[] Utf8Encode(string text, int start, int count)
	{
		return TextEncode(text, start, count, Encoding.UTF8);
	}

	/// <summary>
	/// 从当前字符串序列中筛选非空且不是空串的字符串，并返回这些字符串组成的新序列
	/// </summary>
	/// <param name="source">当前字符串序列</param>
	/// <returns>筛选生成的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串序列为空。</exception>
	public static IEnumerable<string> WhereNotNullAndEmpty(IEnumerable<string> source)
	{
		Guard.AssertNotNull(source, "source");
		return source.Where((string x) => IsNotNullAndEmpty(x));
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
