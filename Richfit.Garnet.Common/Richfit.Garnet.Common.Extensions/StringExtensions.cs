using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Richfit.Garnet.Common.IO;
using Richfit.Garnet.Common.Properties;
using Richfit.Garnet.Common.Reflection;
using Richfit.Garnet.Common.Text;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// <see cref="T:System.String" /> 类型的扩展方法
/// </summary>
public static class StringExtensions
{
	/// <summary>
	/// 全局的自定义Json转换器
	/// </summary>
	private static JsonConverter[] jsonConverters = null;

	/// <summary>
	/// 使用ASCII编码对当前文本进行编码，返回编码后的字节数据
	/// </summary>
	/// <param name="text">当前待编码的文本</param>
	/// <returns>编码后的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static byte[] AsciiEncode(this string text)
	{
		return text.TextEncode(Encoding.ASCII);
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
	public static byte[] AsciiEncode(this string text, int start, int count)
	{
		return text.TextEncode(start, count, Encoding.ASCII);
	}

	/// <summary>
	/// 将当前Base64编码的字符串解码为字节数组
	/// </summary>
	/// <param name="base64">当前Base64编码的字符串</param>
	/// <returns>解码后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前Base64编码的字符串为空。</exception>
	public static byte[] Base64Decode(this string base64)
	{
		base64.GuardNotNull("base64 text");
		return Convert.FromBase64String(base64);
	}

	/// <summary>
	/// 将当前Base64编码的字符串解码，并按指定编码转换为文本
	/// </summary>
	/// <param name="base64">当前Base64编码的字符串</param>
	/// <param name="encoding">转换文本所使用的编码；如果设置为空，则默认为UTF-8编码</param>
	/// <returns>转换后文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前Base64编码的字符串为空。</exception>
	public static string Base64Decode(this string base64, Encoding encoding)
	{
		base64.GuardNotNull("base64 text");
		return encoding.IfNull(Encoding.UTF8).GetString(Convert.FromBase64String(base64));
	}

	/// <summary>
	/// 将当前文本按照指定的文本编码编码为字节数组，并编码为Base64字符串。
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="encoding">转换文本所使用的编码；如果设置为空，则默认为UTF-8编码</param>
	/// <returns>转换后的Base64编码的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static string Base64Encode(this string text, Encoding encoding = null)
	{
		text.GuardNotNull("text");
		return Convert.ToBase64String(encoding.IfNull(Encoding.UTF8).GetBytes(text));
	}

	/// <summary>
	/// 组合基础路径和当前路径
	/// </summary>
	/// <param name="path">当前路径</param>
	/// <param name="basePaths">基础路径</param>
	/// <returns>基础路径拼接上主路径后的规范化路径</returns>
	/// <exception cref="T:System.ArgumentNullException">当前路径为空；或者基础路径 <paramref name="basePaths" /> 为空。</exception>
	public static string BuildPath(this string path, params string[] basePaths)
	{
		path.GuardNotNull("path");
		basePaths.GuardNotNull("base paths");
		return Path.Combine(basePaths.Append(path).ToArray()).NormalizePath();
	}

	/// <summary>
	/// 将当前文本的第一个字母字符转换为大写
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="culture">转字符的大小写时使用的区域信息，默认使用当前线程的区域信息。</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static string Capitalize(this string text, CultureInfo culture = null)
	{
		text.GuardNotNull("text");
		if (text.Length == 0)
		{
			return text;
		}
		StringBuilder buff = new StringBuilder(text);
		int index = 0;
		while (index < buff.Length && !buff[index++].IsLetter())
		{
		}
		if (index < buff.Length)
		{
			buff[index] = buff[index].ToUpper(culture);
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
	public static string Capitalize(this string text, Regex pattern, CultureInfo culture = null)
	{
		text.GuardNotNull("text");
		pattern.GuardNotNull("pattern");
		StringBuilder buff = new StringBuilder(text);
		MatchCollection mc = pattern.Matches(text);
		int index = 0;
		foreach (Match i in mc)
		{
			index = i.Index;
			while (index < i.Index + i.Length && !buff[index++].IsLetter())
			{
			}
			if (index < i.Index + i.Length)
			{
				buff[index] = buff[index].ToUpper(culture);
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
	public static string CapitalizeParagraph(this string text, CultureInfo culture = null)
	{
		text.GuardNotNull("text");
		return text.Capitalize("[^\\r\\n\\p{Zp}]+[\\r\\n\\p{Zp}]?".ToRegex(), culture);
	}

	/// <summary>
	/// 将当前文本中的每一个段落的首字母转换为大写
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="separators">段落的分隔符数组</param>
	/// <param name="culture">转换字符大小写时使用的区域信息，默认为当前线程使用的区域信息。</param>
	/// <returns>转换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者词语分隔符数组 <paramref name="separators" /> 为空。</exception>
	public static string CapitalizeParagraph(this string text, char[] separators, CultureInfo culture = null)
	{
		text.GuardNotNull("text");
		separators.GuardNotNull("separators");
		string pattern = "[^{0}]+[{0}]?".FormatValue(separators.BuildString().RegexEscape());
		return text.Capitalize(pattern.ToRegex(), culture);
	}

	/// <summary>
	/// 将当前文本中的每一个句子的首字母转换为大写
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="culture">转换字符大小写时使用的区域信息，默认为当前线程使用的区域信息。</param>
	/// <returns>转换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <remarks>每个句子由如下字符进行分割：".", "?", "!", ";", "。", "？", "！", "；"。</remarks>
	public static string CapitalizeSentence(this string text, CultureInfo culture = null)
	{
		return text.CapitalizeSentence(new char[8] { '.', '?', ';', '!', '。', '？', '！', '；' }, culture);
	}

	/// <summary>
	/// 将当前文本中的每一个句子的首字母转换为大写
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="separators">句子的分隔符数组</param>
	/// <param name="culture">转换字符大小写时使用的区域信息，默认为当前线程使用的区域信息。</param>
	/// <returns>转换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者句子的分隔符数组 <paramref name="separators" /> 为空。</exception>
	public static string CapitalizeSentence(this string text, char[] separators, CultureInfo culture = null)
	{
		text.GuardNotNull("text");
		separators.GuardNotNull("separators");
		string pattern = "[^{0}]+[{0}]?".FormatValue(separators.BuildString().RegexEscape());
		return text.Capitalize(pattern.ToRegex(), culture);
	}

	/// <summary>
	/// 将当前文本中的每一个词语的首字母转换为大写
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="culture">转换字符大小写时使用的区域信息，默认为当前线程使用的区域信息。</param>
	/// <returns>转换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <remarks>默认以空白字符或者标点符号分隔单词。</remarks>
	public static string CapitalizeWord(this string text, CultureInfo culture = null)
	{
		text.GuardNotNull("text");
		return text.Capitalize("\\w+[\\s\\p{P}]".ToRegex(), culture);
	}

	/// <summary>
	/// 将当前文本中的每一个词语的首字母转换为大写
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="separators">词语的分隔符数组</param>
	/// <param name="culture">转换字符大小写时使用的区域信息，默认为当前线程使用的区域信息。</param>
	/// <returns>转换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者词语分隔符数组 <paramref name="separators" /> 为空。</exception>
	public static string CapitalizeWord(this string text, char[] separators, CultureInfo culture = null)
	{
		text.GuardNotNull("text");
		separators.GuardNotNull("separators");
		string pattern = "\\w+[{0}]".FormatValue(separators.BuildString().RegexEscape());
		return text.Capitalize(pattern.ToRegex(), culture);
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
	public static string Center(this string s, int width, char padding = ' ')
	{
		s.GuardNotNull("s");
		width.GuardGreaterThanOrEqualTo(0, "width");
		if (width <= s.Length)
		{
			return s;
		}
		StringBuilder buff = new StringBuilder(s.Length.Max(width));
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
	public static string Center(this string s, int width, string padding)
	{
		s.GuardNotNull("s");
		width.GuardGreaterThanOrEqualTo(0, "width");
		padding.GuardNotNull("padding");
		if (width <= s.Length || padding.Length == 0)
		{
			return s;
		}
		StringBuilder buff = new StringBuilder(s.Length.Max(width));
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
	/// 将以"\u"开头的字符十六进制字符串表示解码为文本
	/// </summary>
	/// <param name="text">当前字符的十六进制表示</param>
	/// <returns>解码后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static string CharDecode(this string text)
	{
		text.GuardNotNull("text");
		string[] parts = text.Split("\\u");
		List<char> chars = new List<char>();
		if (parts.Length > 1)
		{
			for (int i = 1; i < parts.Length; i++)
			{
				chars.Add((char)short.Parse(parts[i], NumberStyles.HexNumber));
			}
		}
		return chars.BuildString();
	}

	/// <summary>
	/// 将当前文本区域中的字符编码为字符十六进制字符串的表示
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="upperCase">十六进制字符串是否使用大写字母</param>
	/// <returns>当前文本区域中字符的十六进制字符串表示</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static string CharEncode(this string text, bool upperCase = false)
	{
		text.GuardNotNull("text");
		return text.GetRawBytes().ToHex(2, "\\u{0}", upperCase);
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
	public static string CharEncode(this string text, int start, int count, bool upperCase = false)
	{
		text.GuardNotNull("text");
		return text.GetRawBytes(start, count).ToHex(2, "\\u{0}", upperCase);
	}

	/// <summary>
	/// 将当前文本从一种编码转换为另一种编码
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="from">字符串使用的源编码,默认为ASCII</param>
	/// <param name="to">字符串转换的目标编码,默认为UTF-8</param>
	/// <returns>转换后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static string ChangeEncoding(this string text, Encoding from = null, Encoding to = null)
	{
		text.GuardNotNull("text");
		from = from.IfNull(Encoding.ASCII);
		to = to.IfNull(Encoding.UTF8);
		return to.GetString(from.GetBytes(text).ChangeEncoding(from, to));
	}

	/// <summary>
	/// 更改当前文件的扩展名
	/// </summary>
	/// <param name="file">当前文件名称，可以包含路径</param>
	/// <param name="extension">修改的扩展名，可以包含或者不包含句点；如果为空或者空串则移除扩展名</param>
	/// <returns>处理后的文件名称</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件名称为空。</exception>
	public static string ChangeFileExtension(this string file, string extension)
	{
		file.GuardNotNull("file");
		return Path.ChangeExtension(file, extension);
	}

	/// <summary>
	/// 使用区域敏感排序规则比较当前字符串和目标字符串
	/// </summary>
	/// <param name="source">当前字符串</param>
	/// <param name="target">比较的目标字符串</param>
	/// <param name="ignoreCase">字符串比较是否忽略大小写</param>
	/// <returns>如果当前字符串大于目标字符串返回大于0的值；当前字符串等于目标字符串返回0；当前字符串小于目标字符串返回小于0的值；如果当前字符串和目标字符串都为空，则返回0。</returns>
	public static int CompareCultural(this string source, string target, bool ignoreCase = false)
	{
		return source.CompareCultural(target, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
	}

	/// <summary>
	/// 使用区域敏感排序规则比较当前字符串和目标字符串
	/// </summary>
	/// <param name="source">当前字符串</param>
	/// <param name="target">比较的目标字符串</param>
	/// <param name="comparison">字符串比较规则</param>
	/// <returns>如果当前字符串大于目标字符串返回大于0的值；当前字符串等于目标字符串返回0；当前字符串小于目标字符串返回小于0的值；如果当前字符串和目标字符串都为空，则返回0。</returns>
	public static int CompareCultural(this string source, string target, StringComparison comparison)
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
	public static int CompareCultural(this string source, string target, CultureInfo culture, bool ignoreCase = false)
	{
		return (!object.ReferenceEquals(source, target)) ? string.Compare(source, target, ignoreCase, culture.IfNull(CultureInfo.CurrentCulture)) : 0;
	}

	/// <summary>
	/// 使用区域敏感排序规则比较当前字符串和目标字符串
	/// </summary>
	/// <param name="source">当前字符串</param>
	/// <param name="target">比较的目标字符串</param>
	/// <param name="culture">比较时使用的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="options">比较时使用的选项</param>
	/// <returns>如果当前字符串大于目标字符串返回大于0的值；当前字符串等于目标字符串返回0；当前字符串小于目标字符串返回小于0的值；如果当前字符串和目标字符串都为空，则返回0。</returns>
	public static int CompareCultural(this string source, string target, CultureInfo culture, CompareOptions options)
	{
		return (!object.ReferenceEquals(source, target)) ? string.Compare(source, target, culture.IfNull(CultureInfo.CurrentCulture), options) : 0;
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
	public static int CompareCultural(this string source, int sourceStart, string target, int targetStart, int count, bool ignoreCase = false)
	{
		return source.CompareCultural(sourceStart, target, targetStart, count, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
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
	public static int CompareCultural(this string source, int sourceStart, string target, int targetStart, int count, StringComparison comparison)
	{
		sourceStart.GuardGreaterThanOrEqualTo(0, "source start");
		targetStart.GuardGreaterThanOrEqualTo(0, "target start");
		count.GuardGreaterThanOrEqualTo(0, "count");
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
	public static int CompareCultural(this string source, int sourceStart, string target, int targetStart, int count, CultureInfo culture, bool ignoreCase = false)
	{
		return source.CompareCultural(sourceStart, target, targetStart, count, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static int CompareCultural(this string source, int sourceStart, string target, int targetStart, int count, CultureInfo culture, CompareOptions options)
	{
		sourceStart.GuardGreaterThanOrEqualTo(0, "source start");
		targetStart.GuardGreaterThanOrEqualTo(0, "target start");
		count.GuardGreaterThanOrEqualTo(0, "count");
		return (!object.ReferenceEquals(source, target)) ? string.Compare(source, sourceStart, target, targetStart, count, culture.IfNull(CultureInfo.CurrentCulture), options) : 0;
	}

	/// <summary>
	/// 使用固定区域排序规则比较当前字符串和目标字符串
	/// </summary>
	/// <param name="source">当前字符串</param>
	/// <param name="target">比较的目标字符串</param>
	/// <param name="ignoreCase">比较是否忽略大小写</param>
	/// <returns>如果当前字符串大于目标字符串返回大于0的值；当前字符串等于目标字符串返回0；当前字符串小于目标字符串返回小于0的值；如果当前字符串和目标字符串都为空，则返回0。</returns>
	public static int CompareInvariant(this string source, string target, bool ignoreCase = false)
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
	public static int CompareInvariant(this string source, string target, CompareOptions options)
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
	public static int CompareInvariant(this string source, int sourceStart, string target, int targetStart, int count, bool ignoreCase = false)
	{
		sourceStart.GuardGreaterThanOrEqualTo(0, "source start");
		targetStart.GuardGreaterThanOrEqualTo(0, "target start");
		count.GuardGreaterThanOrEqualTo(0, "count");
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
	public static int CompareInvariant(this string source, int sourceStart, string target, int targetStart, int count, CompareOptions options)
	{
		sourceStart.GuardGreaterThanOrEqualTo(0, "source start");
		targetStart.GuardGreaterThanOrEqualTo(0, "target start");
		count.GuardGreaterThanOrEqualTo(0, "count");
		return (!object.ReferenceEquals(source, target)) ? string.Compare(source, sourceStart, target, targetStart, count, CultureInfo.InvariantCulture, options) : 0;
	}

	/// <summary>
	/// 使用序号排序规则比较当前字符串和目标字符串
	/// </summary>
	/// <param name="source">当前字符串</param>
	/// <param name="target">比较的目标字符串</param>
	/// <param name="ignoreCase">比较是否忽略大小写</param>
	/// <returns>如果当前字符串大于目标字符串返回大于0的值；当前字符串等于目标字符串返回0；当前字符串小于目标字符串返回小于0的值；如果当前字符串和目标字符串都为空，则返回0。</returns>
	public static int CompareOrdinal(this string source, string target, bool ignoreCase = false)
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
	public static int CompareOrdinal(this string source, int sourceStart, string target, int targetStart, int count, bool ignoreCase = false)
	{
		sourceStart.GuardGreaterThanOrEqualTo(0, "source start");
		targetStart.GuardGreaterThanOrEqualTo(0, "target start");
		count.GuardGreaterThanOrEqualTo(0, "count");
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
	/// 将文本按指定文本编码进行编码并压缩为字节数组
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="encoding">文本编码格式，默认为UTF-8</param>
	/// <param name="type">压缩类型</param>
	/// <returns>编码压缩后的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static byte[] Compress(this string text, Encoding encoding = null, CompressionType type = CompressionType.Deflate)
	{
		text.GuardNotNull("data");
		return text.TextEncode(encoding).Compress(type);
	}

	/// <summary>
	/// 将当前字符串和对象数组中各个对象的字符串表示形式串联在一起
	/// </summary>
	/// <typeparam name="T">串联的对象序列元素类型</typeparam>
	/// <param name="s">当前字符串</param>
	/// <param name="values">对象数组</param>
	/// <returns>串联后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者对象数组 <paramref name="values" /> 为空。</exception>
	public static string Concat<T>(this string s, params T[] values)
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
	public static string Concat<T>(this string s, IEnumerable<T> values, string splitter = "")
	{
		return s.Concat(values, (T x) => x.ToString(), splitter);
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
	public static string Concat<T>(this string s, IEnumerable<T> values, Func<T, string> formatting, string splitter = "")
	{
		s.GuardNotNull("s");
		values.GuardNotNull("values");
		formatting.GuardNotNull("formatter");
		splitter = splitter.IfNull(string.Empty);
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
	public static bool Contains(this string text, char c, bool ignoreCase = false)
	{
		return text.Contains(c, CultureInfo.CurrentCulture, ignoreCase);
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
	public static bool Contains(this string text, char c, CultureInfo culture, bool ignoreCase = false)
	{
		return text.Contains(c, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static bool Contains(this string text, char c, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("s");
		return culture.IfNull(CultureInfo.CurrentCulture).CompareInfo.IndexOf(text, c, options) >= 0;
	}

	/// <summary>
	/// 检测当前文本中是否包含指定的字符串
	/// </summary>
	/// <param name="text">当前的文本</param>
	/// <param name="value">检测的字符串</param>
	/// <param name="ignoreCase">字符串比较是否区分大小写</param>
	/// <returns>如果检测当前文本中包含指定的字符串返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者待检测的字符串 <paramref name="value" /> 为空。</exception>
	public static bool Contains(this string text, string value, bool ignoreCase)
	{
		text.GuardNotNull("s");
		value.GuardNotNull("value");
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
	public static bool Contains(this string text, string value, StringComparison comparison)
	{
		text.GuardNotNull("s");
		value.GuardNotNull("value");
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
	public static bool Contains(this string text, string value, CultureInfo culture, bool ignoreCase = false)
	{
		return text.Contains(value, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static bool Contains(this string text, string value, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("s");
		value.GuardNotNull("value");
		return culture.IfNull(CultureInfo.CurrentCulture).CompareInfo.IndexOf(text, value, options) >= 0;
	}

	/// <summary>
	/// 检测当前文本是否包含全部指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="cs">待检测的字符数组</param>
	/// <returns>如果当前文本中包含指定的全部字符返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者待检测的字符数组 <paramref name="cs" /> 为空。</exception>
	public static bool ContainsAll(this string text, params char[] cs)
	{
		return text.ContainsAll(cs, ignoreCase: false);
	}

	/// <summary>
	/// 检测当前文本是否包含全部指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="cs">检测的字符串数组</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果当前文本包含指定的全部字符返回true，否则返回flase。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者检测的字符数组 <paramref name="cs" /> 为空。</exception>
	public static bool ContainsAll(this string text, char[] cs, bool ignoreCase)
	{
		return text.ContainsAll(cs, CultureInfo.CurrentCulture, ignoreCase);
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
	public static bool ContainsAll(this string text, char[] cs, CultureInfo culture, bool ignoreCase = false)
	{
		return text.ContainsAll(cs, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static bool ContainsAll(this string text, char[] cs, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		cs.GuardNotNull("chars");
		return cs.All((char c) => text.Contains(c, culture, options));
	}

	/// <summary>
	/// 检测当前文本是否包含任意指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="cs">待检测的字符数组</param>
	/// <returns>如果当前文本中包含指定的任意字符返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者待检测的字符数组 <paramref name="cs" /> 为空。</exception>
	public static bool ContainsAny(this string text, params char[] cs)
	{
		return text.ContainsAny(cs, ignoreCase: false);
	}

	/// <summary>
	/// 检测当前文本是否包含任意指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="cs">检测的字符数组</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果当前文本中包含任意指定的字符返回true，或者返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者检测的字符数组 <paramref name="cs" /> 为空。</exception>
	public static bool ContainsAny(this string text, char[] cs, bool ignoreCase)
	{
		return text.ContainsAny(cs, CultureInfo.CurrentCulture, ignoreCase);
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
	public static bool ContainsAny(this string text, char[] cs, CultureInfo culture, bool ignoreCase = false)
	{
		return text.ContainsAny(cs, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static bool ContainsAny(this string text, char[] cs, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		cs.GuardNotNull("chars");
		return cs.Any((char c) => text.Contains(c, culture, options));
	}

	/// <summary>
	/// 判断当前文本中是否包含字符串复合格式化标记
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <returns>如果当前文本中包含字符串复合格式化标记返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static bool ContainsFormatToken(this string text)
	{
		text.GuardNotNull("text");
		return RegexPatterns.StringFormatToken.IsMatch(text);
	}

	/// <summary>
	/// 判断当前文本中是否包含HTML标记
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <returns>如果当前文本包含HTML标记返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static bool ContainsHtmlTag(this string text)
	{
		text.GuardNotNull("text");
		return RegexPatterns.HtmlTag.IsMatch(text);
	}

	/// <summary>
	/// 判断当前文本中是否包含Unicode的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <returns>如果当前文本包含Unicode字符返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static bool ContainsUnicode(this string text)
	{
		text.GuardNotNull("text");
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
	public static int CountChar(this string text, char c, bool ignoreCase = false)
	{
		text.GuardNotNull("text");
		return text.CountChar(c, 0, text.Length, ignoreCase);
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
	public static int CountChar(this string text, char c, CultureInfo culture, bool ignoreCase = false)
	{
		text.GuardNotNull("text");
		return text.CountChar(c, 0, text.Length, culture, ignoreCase);
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
	public static int CountChar(this string text, char c, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		return text.CountChar(c, 0, text.Length, culture, options);
	}

	/// <summary>
	/// 统计当前文本中符合条件的字符数量
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="predicate">字符筛选条件</param>
	/// <returns>符合筛选条件的字符个数</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者字符筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static int CountChar(this string text, Func<char, bool> predicate)
	{
		text.GuardNotNull("text");
		return text.CountChar(predicate, 0, text.Length);
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
	public static int CountChar(this string text, char c, int start, int count, bool ignoreCase = false)
	{
		return text.CountChar((char x) => c.IsEqualTo(x, CultureInfo.CurrentCulture, ignoreCase), start, count);
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
	public static int CountChar(this string text, char c, int start, int count, CultureInfo culture, bool ignoreCase = false)
	{
		return text.CountChar((char x) => c.IsEqualTo(x, culture, ignoreCase), start, count);
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
	public static int CountChar(this string text, char c, int start, int count, CultureInfo culture, CompareOptions options)
	{
		return text.CountChar((char x) => c.IsEqualTo(x, culture, options), start, count);
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
	public static int CountChar(this string text, Func<char, bool> predicate, int start, int count)
	{
		text.GuardNotNull("text");
		predicate.GuardNotNull("predicate");
		start.GuardIndexRange(0, text.Length - 1, "start");
		count.GuardBetween(0, text.Length - start, "count");
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
	public static int CountRegex(this string text, string pattern, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return text.CountRegex(pattern.ToRegex(options));
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
	public static int CountRegex(this string text, string pattern, int start, int count, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return text.CountRegex(pattern.ToRegex(options), start, count);
	}

	/// <summary>
	/// 统计当前文本中正则模式的匹配次数
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">用于匹配的正则模式</param>
	/// <returns>正则模式匹配计数</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者用于匹配的正则模式 <paramref name="pattern" /> 为空。</exception>
	public static int CountRegex(this string text, Regex pattern)
	{
		return pattern.GetMatches(text).Length;
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
	public static int CountRegex(this string text, Regex pattern, int start, int count)
	{
		return pattern.GetMatches(text, start, count).Length;
	}

	/// <summary>
	/// 反序列化当前字符串，重新创建当前字符串表示的 <see cref="T:System.TimeZoneInfo" /> 对象
	/// </summary>
	/// <param name="serializedTimeZoneInfo">当前 <see cref="T:System.TimeZoneInfo" /> 对象的序列化字符串</param>
	/// <returns>反序列化生成的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static TimeZoneInfo DeserializeTimeZoneInfo(this string serializedTimeZoneInfo)
	{
		serializedTimeZoneInfo.GuardNotNullAndEmpty("serialized TimeZoneInfo");
		return TimeZoneInfo.FromSerializedString(serializedTimeZoneInfo);
	}

	/// <summary>
	/// 检测当前目录路径指示的目录是否存在
	/// </summary>
	/// <param name="directory">当前目录路径</param>
	/// <returns>如果目录存在返回true，否则返回false</returns>
	public static bool DirectoryExists(this string directory)
	{
		directory.GuardNotNull("directory");
		return Directory.Exists(directory);
	}

	/// <summary>
	/// 使用区域敏感排序规则比较当前字符串和目标字符串的相等性
	/// </summary>
	/// <param name="source">当前字符串</param>
	/// <param name="target">比较的目标字符串</param>
	/// <param name="ignoreCase">比较是否忽略大小写</param>
	/// <returns>如果两个字符串相同返回true,否则返回false。</returns>
	public static bool EqualCultural(this string source, string target, bool ignoreCase = false)
	{
		return source.CompareCultural(target, ignoreCase) == 0;
	}

	/// <summary>
	/// 使用区域敏感排序规则比较当前字符串和目标字符串的相等性
	/// </summary>
	/// <param name="source">当前字符串</param>
	/// <param name="target">比较的目标字符串</param>
	/// <param name="comparison">字符串比较规则</param>
	/// <returns>如果两个字符串相同返回true,否则返回false。</returns>
	public static bool EqualCultural(this string source, string target, StringComparison comparison)
	{
		return source.CompareCultural(target, comparison) == 0;
	}

	/// <summary>
	/// 使用区域敏感排序规则比较当前字符串和目标字符串的相等性
	/// </summary>
	/// <param name="source">当前字符串</param>
	/// <param name="target">比较的目标字符串</param>
	/// <param name="culture">用于比较的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="ignoreCase">比较是否忽略大小写</param>
	/// <returns>如果两个字符串相同返回true,否则返回false。</returns>
	public static bool EqualCultural(this string source, string target, CultureInfo culture, bool ignoreCase = false)
	{
		return source.CompareCultural(target, culture, ignoreCase) == 0;
	}

	/// <summary>
	/// 使用区域敏感排序规则比较当前字符串和目标字符串的相等性
	/// </summary>
	/// <param name="source">当前字符串</param>
	/// <param name="target">比较的目标字符串</param>
	/// <param name="culture">用于比较的区域信息，如果为空则使用当前线程的区域信息</param>
	/// <param name="options">字符串比较选项</param>
	/// <returns>如果两个字符串相同返回true,否则返回false。</returns>
	public static bool EqualCultural(this string source, string target, CultureInfo culture, CompareOptions options)
	{
		return source.CompareCultural(target, culture, options) == 0;
	}

	/// <summary>
	/// 使用固定区域排序规则比较当前字符串和目标字符串的相等性
	/// </summary>
	/// <param name="source">当前字符串</param>
	/// <param name="target">比较的目标字符串</param>
	/// <param name="ignoreCase">比较是否忽略大小写</param>
	/// <returns>如果两个字符串相同返回true,否则返回false。</returns>
	public static bool EqualInvariant(this string source, string target, bool ignoreCase = false)
	{
		return source.CompareInvariant(target, ignoreCase) == 0;
	}

	/// <summary>
	/// 使用固定区域排序规则比较当前字符串和目标字符串的相等性
	/// </summary>
	/// <param name="source">当前字符串</param>
	/// <param name="target">比较的目标字符串</param>
	/// <param name="options">字符串比较选项</param>
	/// <returns>如果两个字符串相同返回true,否则返回false。</returns>
	public static bool EqualInvariant(this string source, string target, CompareOptions options)
	{
		return source.CompareInvariant(target, options) == 0;
	}

	/// <summary>
	/// 使用序号排序规则比较当前字符串和目标字符串的相等性
	/// </summary>
	/// <param name="source">当前字符串</param>
	/// <param name="target">比较的目标字符串</param>
	/// <param name="ignoreCase">比较是否忽略大小写</param>
	/// <returns>如果两个字符串相同返回true,否则返回false。</returns>
	public static bool EqualOrdinal(this string source, string target, bool ignoreCase = false)
	{
		return source.CompareOrdinal(target, ignoreCase) == 0;
	}

	/// <summary>
	/// 将当前文本中的制表符用指定数量的空格替换后返回，如果指定的空格数量等于0则移除制表符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="tabSize">制表符的大小，默认一个制表符转换为4个空格，制表符大小应大于等于0</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">制表符转换的空格数量 <paramref name="tabSize" /> 小于0。</exception>
	public static string ExpandTabs(this string text, int tabSize = 4)
	{
		text.GuardNotNull("text");
		tabSize.GuardGreaterThanOrEqualTo(0, "tab size");
		return text.Replace("\t", (tabSize > 0) ? new string(' ', tabSize) : null);
	}

	/// <summary>
	/// 检测当前文件路径指示的文件是否存在
	/// </summary>
	/// <param name="file">当前文件路径</param>
	/// <returns>如果指示的文件存在返回true，否则返回false</returns>
	public static bool FileExists(this string file)
	{
		file.GuardNotNull("file");
		return File.Exists(file);
	}

	/// <summary>
	/// 在当前文本中查找字符串出现的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="value">待查找的字符串</param>
	/// <param name="ignoreCase">字符串是否区分大小写</param>
	/// <returns>指定的字符串在当前文本中出现的索引位置，如果没有找到匹配的字符串，返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的文本为空；或者查找的字符串为空。</exception>
	public static int Find(this string text, string value, bool ignoreCase = false)
	{
		text.GuardNotNull("text");
		return text.Find(value, 0, text.Length, 1, ignoreCase);
	}

	/// <summary>
	/// 在当前文本中查找字符串出现的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="value">待查找的字符串</param>
	/// <param name="comparison">文本比较参数</param>
	/// <returns>指定的字符串在当前文本中出现的索引位置，如果没有找到匹配的字符串，返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的文本为空；或者查找的字符串为空。</exception>
	public static int Find(this string text, string value, StringComparison comparison)
	{
		text.GuardNotNull("text");
		return text.Find(value, 0, text.Length, 1, comparison);
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
	public static int Find(this string text, string value, CultureInfo culture, bool ignoreCase = false)
	{
		text.GuardNotNull("text");
		return text.Find(value, 0, text.Length, 1, culture, ignoreCase);
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
	public static int Find(this string text, string value, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		return text.Find(value, 0, text.Length, 1, culture, options);
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
	public static int Find(this string text, string value, int times, bool ignoreCase = false)
	{
		text.GuardNotNull("text");
		return text.Find(value, 0, text.Length, times, ignoreCase);
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
	public static int Find(this string text, string value, int times, StringComparison comparison)
	{
		text.GuardNotNull("text");
		return text.Find(value, 0, text.Length, times, comparison);
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
	public static int Find(this string text, string value, int times, CultureInfo culture, bool ignoreCase = false)
	{
		text.GuardNotNull("text");
		return text.Find(value, 0, text.Length, times, culture, ignoreCase);
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
	public static int Find(this string text, string value, int times, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		return text.Find(value, 0, text.Length, times, culture, options);
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
	public static int Find(this string text, string value, int start, int count, bool ignoreCase = false)
	{
		return text.Find(value, start, count, 1, ignoreCase);
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
	public static int Find(this string text, string value, int start, int count, StringComparison comparison)
	{
		return text.Find(value, start, count, 1, comparison);
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
	public static int Find(this string text, string value, int start, int count, CultureInfo culture, bool ignoreCase = false)
	{
		return text.Find(value, start, count, 1, culture, ignoreCase);
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
	public static int Find(this string text, string value, int start, int count, CultureInfo culture, CompareOptions options)
	{
		return text.Find(value, start, count, 1, culture, options);
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
	public static int Find(this string text, string value, int start, int count, int times, bool ignoreCase = false)
	{
		return text.Find(value, start, count, times, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
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
	public static int Find(this string text, string value, int start, int count, int times, StringComparison comparison)
	{
		text.GuardNotNull("text");
		value.GuardNotNull("value");
		start.GuardBetween(0, text.Length - 1, "start");
		count.GuardBetween(0, text.Length - start, "count");
		times.GuardGreaterThanOrEqualTo(1, "times");
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
	public static int Find(this string text, string value, int start, int count, int times, CultureInfo culture, bool ignoreCase = false)
	{
		return text.Find(value, start, count, times, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static int Find(this string text, string value, int start, int count, int times, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		value.GuardNotNull("value");
		start.GuardBetween(0, text.Length - 1, "start");
		count.GuardBetween(0, text.Length - start, "count");
		times.GuardGreaterThanOrEqualTo(1, "times");
		int end = start + count;
		int found = 0;
		int index = 0;
		while ((index = text.IndexOf(value, start, count, culture, options)) >= 0)
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
	public static int FindLast(this string text, string value, bool ignoreCase = false)
	{
		text.GuardNotNull("text");
		return text.FindLast(value, text.Length - 1, text.Length, 1, ignoreCase);
	}

	/// <summary>
	/// 在当前文本中逆向查找字符串的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="value">待查找的字符串</param>
	/// <param name="comparison">文本比较参数</param>
	/// <returns>指定的字符串在当前文本中出现的索引位置，如果没有找到匹配的字符串，返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的文本为空；或者查找的字符串为空。</exception>
	public static int FindLast(this string text, string value, StringComparison comparison)
	{
		text.GuardNotNull("text");
		return text.FindLast(value, text.Length - 1, text.Length, 1, comparison);
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
	public static int FindLast(this string text, string value, CultureInfo culture, bool ignoreCase = false)
	{
		text.GuardNotNull("text");
		return text.FindLast(value, text.Length - 1, text.Length, 1, culture, ignoreCase);
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
	public static int FindLast(this string text, string value, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		return text.FindLast(value, text.Length - 1, text.Length, 1, culture, options);
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
	public static int FindLast(this string text, string value, int times, bool ignoreCase = false)
	{
		text.GuardNotNull("text");
		return text.FindLast(value, text.Length - 1, text.Length, times, ignoreCase);
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
	public static int FindLast(this string text, string value, int times, StringComparison comparison)
	{
		text.GuardNotNull("text");
		return text.FindLast(value, text.Length - 1, text.Length, times, comparison);
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
	public static int FindLast(this string text, string value, int times, CultureInfo culture, bool ignoreCase = false)
	{
		text.GuardNotNull("text");
		return text.FindLast(value, text.Length - 1, text.Length, times, culture, ignoreCase);
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
	public static int FindLast(this string text, string value, int times, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		return text.FindLast(value, text.Length - 1, text.Length, times, culture, options);
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
	public static int FindLast(this string text, string value, int start, int count, bool ignoreCase = false)
	{
		return text.FindLast(value, start, count, 1, ignoreCase);
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
	public static int FindLast(this string text, string value, int start, int count, StringComparison comparison)
	{
		return text.FindLast(value, start, count, 1, comparison);
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
	public static int FindLast(this string text, string value, int start, int count, CultureInfo culture, bool ignoreCase = false)
	{
		return text.FindLast(value, start, count, 1, culture, ignoreCase);
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
	public static int FindLast(this string text, string value, int start, int count, CultureInfo culture, CompareOptions options)
	{
		return text.FindLast(value, start, count, 1, culture, options);
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
	public static int FindLast(this string text, string value, int start, int count, int times, bool ignoreCase = false)
	{
		return text.FindLast(value, start, count, times, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
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
	public static int FindLast(this string text, string value, int start, int count, int times, StringComparison comparison)
	{
		text.GuardNotNull("text");
		value.GuardNotNull("value");
		start.GuardBetween(0, text.Length - 1, "start");
		count.GuardBetween(0, start + 1, "count");
		times.GuardGreaterThanOrEqualTo(1, "times");
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
	public static int FindLast(this string text, string value, int start, int count, int times, CultureInfo culture, bool ignoreCase = false)
	{
		return text.FindLast(value, start, count, times, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static int FindLast(this string text, string value, int start, int count, int times, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		value.GuardNotNull("value");
		start.GuardBetween(0, text.Length - 1, "start");
		count.GuardBetween(0, start + 1, "count");
		times.GuardGreaterThanOrEqualTo(1, "times");
		int end = start - count;
		int found = 0;
		int index = 0;
		while ((index = text.LastIndexOf(value, start, count, culture, options)) >= 0)
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
	public static int FindChar(this string text, char c, bool ignoreCase = false)
	{
		return text.FindChar((char x) => x.IsEqualTo(c, CultureInfo.CurrentCulture, ignoreCase));
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
	public static int FindChar(this string text, char c, CultureInfo culture, bool ignoreCase = false)
	{
		return text.FindChar((char x) => x.IsEqualTo(c, culture, ignoreCase));
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
	public static int FindChar(this string text, char c, CultureInfo culture, CompareOptions options)
	{
		return text.FindChar((char x) => x.IsEqualTo(c, culture, options));
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
	public static int FindChar(this string text, char c, int times, bool ignoreCase = false)
	{
		return text.FindChar((char x) => x.IsEqualTo(c, CultureInfo.CurrentCulture, ignoreCase), times);
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
	public static int FindChar(this string text, char c, int times, CultureInfo culture, bool ignoreCase = false)
	{
		return text.FindChar((char x) => x.IsEqualTo(c, culture, ignoreCase), times);
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
	public static int FindChar(this string text, char c, int times, CultureInfo culture, CompareOptions options)
	{
		return text.FindChar((char x) => x.IsEqualTo(c, culture, options), times);
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
	public static int FindChar(this string text, char c, int start, int count, int times, bool ignoreCase = false)
	{
		return text.FindChar((char x) => x.IsEqualTo(c, CultureInfo.CurrentCulture, ignoreCase), start, count, times);
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
	public static int FindChar(this string text, char c, int start, int count, int times, CultureInfo culture, bool ignoreCase = false)
	{
		return text.FindChar((char x) => x.IsEqualTo(c, culture, ignoreCase), start, count, times);
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
	public static int FindChar(this string text, char c, int start, int count, int times, CultureInfo culture, CompareOptions options)
	{
		return text.FindChar((char x) => x.IsEqualTo(c, culture, options), start, count, times);
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
	public static int FindChar(this string text, Func<char, bool> predicate, int times = 1)
	{
		text.GuardNotNull("text");
		return text.FindChar(predicate, 0, text.Length, times);
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
	public static int FindChar(this string text, Func<char, bool> predicate, int start, int count, int times = 1)
	{
		text.GuardNotNull("text");
		predicate.GuardNotNull("predicate");
		start.GuardBetween(0, text.Length - 1, "start");
		count.GuardBetween(0, text.Length - start, "count");
		times.GuardGreaterThanOrEqualTo(1, "times");
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
	public static int FindLastChar(this string text, char c, bool ignoreCase = false)
	{
		return text.FindChar((char x) => x.IsEqualTo(c, CultureInfo.CurrentCulture, ignoreCase));
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
	public static int FindLastChar(this string text, char c, CultureInfo culture, bool ignoreCase = false)
	{
		return text.FindChar((char x) => x.IsEqualTo(c, culture, ignoreCase));
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
	public static int FindLastChar(this string text, char c, CultureInfo culture, CompareOptions options)
	{
		return text.FindChar((char x) => x.IsEqualTo(c, culture, options));
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
	public static int FindLastChar(this string text, char c, int times, bool ignoreCase = false)
	{
		return text.FindChar((char x) => x.IsEqualTo(c, CultureInfo.CurrentCulture, ignoreCase), times);
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
	public static int FindLastChar(this string text, char c, int times, CultureInfo culture, bool ignoreCase = false)
	{
		return text.FindChar((char x) => x.IsEqualTo(c, culture, ignoreCase), times);
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
	public static int FindLastChar(this string text, char c, int times, CultureInfo culture, CompareOptions options)
	{
		return text.FindChar((char x) => x.IsEqualTo(c, culture, options), times);
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
	public static int FindLastChar(this string text, char c, int start, int count, int times, bool ignoreCase = false)
	{
		return text.FindChar((char x) => x.IsEqualTo(c, CultureInfo.CurrentCulture, ignoreCase), start, count, times);
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
	public static int FindLastChar(this string text, char c, int start, int count, int times, CultureInfo culture, bool ignoreCase = false)
	{
		return text.FindChar((char x) => x.IsEqualTo(c, culture, ignoreCase), start, count, times);
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
	public static int FindLastChar(this string text, char c, int start, int count, int times, CultureInfo culture, CompareOptions options)
	{
		return text.FindChar((char x) => x.IsEqualTo(c, culture, options), start, count, times);
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
	public static int FindLastChar(this string text, Func<char, bool> predicate, int times = 1)
	{
		text.GuardNotNull("text");
		return text.FindLastChar(predicate, text.Length - 1, text.Length, times);
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
	public static int FindLastChar(this string text, Func<char, bool> predicate, int start, int count, int times = 1)
	{
		text.GuardNotNull("text");
		predicate.GuardNotNull("predicate");
		start.GuardBetween(0, text.Length - 1, "start");
		count.GuardBetween(0, start + 1, "count");
		times.GuardGreaterThanOrEqualTo(1, "times");
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
	public static int FindRegex(this string text, string pattern, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return text.FindRegex(pattern.ToRegex(options.EnsureLeftToRightOption()));
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
	public static int FindRegex(this string text, string pattern, int times, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return text.FindRegex(pattern.ToRegex(options.EnsureLeftToRightOption()), times);
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
	public static int FindRegex(this string text, string pattern, int start, int count, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return text.FindRegex(pattern.ToRegex(options.EnsureLeftToRightOption()), start, count);
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
	public static int FindRegex(this string text, string pattern, int start, int count, int times, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return text.FindRegex(pattern.ToRegex(options.EnsureLeftToRightOption()), start, count, times);
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
	public static int FindRegex(this string text, Regex pattern, int times = 1)
	{
		Match match = pattern.GetMatch(text, times);
		return match.IsNull() ? (-1) : match.Index;
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
	public static int FindRegex(this string text, Regex pattern, int start, int count, int times = 1)
	{
		Match match = pattern.GetMatch(text, start, count, times);
		return match.IsNull() ? (-1) : match.Index;
	}

	/// <summary>
	/// 在当前文本中逆向查找与指定模式匹配的字符串的位置
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">查找的正则模式</param>
	/// <param name="options">正则模式匹配参数</param>
	/// <returns>查找到的匹配文本的索引，未找到返回-1</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者查找的正则模式 <paramref name="pattern" /> 为空。</exception>
	public static int FindLastRegex(this string text, string pattern, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return text.FindLastRegex(pattern.ToRegex(options.EnsureRightToLeftOption()));
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
	public static int FindLastRegex(this string text, string pattern, int times, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return text.FindLastRegex(pattern.ToRegex(options.EnsureRightToLeftOption()), times);
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
	public static int FindLastRegex(this string text, string pattern, int start, int count, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return text.FindLastRegex(pattern.ToRegex(options.EnsureRightToLeftOption()), start, count);
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
	public static int FindLastRegex(this string text, string pattern, int start, int count, int times, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return text.FindLastRegex(pattern.ToRegex(options.EnsureRightToLeftOption()), start, count, times);
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
	public static int FindLastRegex(this string text, Regex pattern, int times = 1)
	{
		Match match = pattern.GetLastMatch(text, times);
		return match.IsNull() ? (-1) : match.Index;
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
	public static int FindLastRegex(this string text, Regex pattern, int start, int count, int times = 1)
	{
		Match match = pattern.GetLastMatch(text, start, count, times);
		return match.IsNull() ? (-1) : match.Index;
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
	public static string FormatString(this string s, string format, char digitChar = '#', char alphaChar = '@', char escapeChar = '\\')
	{
		s.GuardNotNull("s");
		format.GuardNotNull("format");
		format.Guard(delegate
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
	public static string FormatValue(this string format, params object[] args)
	{
		format.GuardNotNull("format");
		args.GuardNotNull("formatting arguments");
		for (int i = 0; i < args.Length; i++)
		{
			if (args[i].IsNull())
			{
				args[i] = string.Empty;
			}
		}
		return string.Format(format, args);
	}

	/// <summary>
	/// 使用GB2312编码（代码页936）对当前文本进行编码，返回编码后的字节数据
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <returns>编码生成的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static byte[] GB2312Encode(this string text)
	{
		return text.TextEncode(Encoding.GetEncoding(936));
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
	public static byte[] GB2312Encode(this string text, int start, int count)
	{
		return text.TextEncode(start, count, Encoding.GetEncoding(936));
	}

	/// <summary>
	/// 获取当前路径字符串相对应的绝对路径
	/// 1. 当前路径不以盘符、'\'开头的认为是相对路径，使用AppDomain.BaseDirectory目录做为基础
	/// 2. 以'~'开头的认为是相对路径，首先尝试使用HttpServerUtility.MapPath进行转换
	/// 3. 以'&gt;'开头的认为是相对路径，使用Environment.CurrentDirectory做为基础进行转换
	/// </summary>
	/// <param name="path">当前路径字符串</param>
	/// <returns>当前路径字符串相对应的绝对路径</returns>
	/// <exception cref="T:System.ArgumentNullException">当前路径字符串为空。</exception>
	public static string GetAbsolutePath(this string path)
	{
		path.GuardNotNull("path");
		if (path.IsRelativePath())
		{
			switch (path[0])
			{
			case '>':
				return path.TrimStart('>').BuildPath(Environment.CurrentDirectory);
			case '~':
				if (HttpContext.Current != null && HttpContext.Current.Server != null)
				{
					return HttpContext.Current.Server.MapPath(path);
				}
				return path.TrimStart('~').BuildPath(AppDomain.CurrentDomain.BaseDirectory);
			default:
				return path.BuildPath(AppDomain.CurrentDomain.BaseDirectory);
			}
		}
		return Path.GetFullPath(path);
	}

	/// <summary>
	/// 获取当前程序集文件中程序集的名称
	/// </summary>
	/// <param name="assemblyFile">当前程序集文件</param>
	/// <returns>当前程序集文件中程序集的名称</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前程序集文件不存在。</exception>
	public static AssemblyName GetAssemblyName(this string assemblyFile)
	{
		assemblyFile.GuardNotNull("assembly file").GuardFileExistence();
		return AssemblyName.GetAssemblyName(assemblyFile);
	}

	/// <summary>
	/// 获取当前程序集文件中程序集的完整名称
	/// </summary>
	/// <param name="assemblyFile">当前程序集文件</param>
	/// <returns>当前程序集文件中程序集的完整名称</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前程序集文件不存在。</exception>
	public static string GetAssemblyFullName(this string assemblyFile)
	{
		assemblyFile.GuardNotNull("assembly file").GuardFileExistence();
		return AssemblyName.GetAssemblyName(assemblyFile).FullName;
	}

	/// <summary>
	/// 获取当前程序集文件中程序集的版本信息
	/// </summary>
	/// <param name="assemblyFile">当前程序集文件</param>
	/// <returns>获取的程序集版本信息,如果无法获取则返回null</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前程序集文件不存在。</exception>
	public static Version GetAssemblyVersion(this string assemblyFile)
	{
		assemblyFile.GuardNotNull("assembly file").GuardFileExistence();
		return AssemblyName.GetAssemblyName(assemblyFile).Version;
	}

	/// <summary>
	/// 获取当前程序集文件中程序集的完整版本信息字符串
	/// </summary>
	/// <param name="assemblyFile">当前程序集文件</param>
	/// <returns>获取的程序集版本号,如果无法获取则返回null</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前程序集文件不存在。</exception>
	public static string GetAssemblyFullVersion(this string assemblyFile)
	{
		assemblyFile.GuardNotNull("assembly file").GuardFileExistence();
		return AssemblyName.GetAssemblyName(assemblyFile).Version.ToString(4);
	}

	/// <summary>
	/// 获取当前程序集文件中程序集的简单版本信息字符串
	/// </summary>
	/// <param name="assemblyFile">当前程序集文件</param>
	/// <returns>获取的程序集版本号,如果无法获取则返回null</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集文件为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前程序集文件不存在。</exception>
	public static string GetAssemblyShortVersion(this string assemblyFile)
	{
		assemblyFile.GuardNotNull("assembly file").GuardFileExistence();
		return AssemblyName.GetAssemblyName(assemblyFile).Version.ToString(2);
	}

	/// <summary>
	/// 获取当前文本区域中字符的位字节数组
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <returns>当前文本区域中的字符的位字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static byte[] GetBytes(this string text)
	{
		text.GuardNotNull("text");
		return text.GetBytes(0, text.Length);
	}

	/// <summary>
	/// 获取当前文本区域中字符的位字节数组
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="start">区域的起始位置</param>
	/// <param name="count">区域中的字符数量</param>
	/// <returns>当前文本区域中的字符的位字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的字符索引 <paramref name="start" /> 超出了当前字符数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的字符数量 <paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的字符数量。</exception>
	public static byte[] GetBytes(this string text, int start, int count)
	{
		text.GuardNotNull("text");
		start.GuardIndexRange(0, text.Length - 1, "start");
		count.GuardBetween(0, text.Length - start, "count");
		List<byte> result = new List<byte>(count * 2);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			result.AddRange(text[i].GetBytes());
		}
		return result.ToArray();
	}

	/// <summary>
	/// 获取当前文本区域中字符的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <returns>当前文本区域中的字符的位字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static byte[] GetRawBytes(this string text)
	{
		text.GuardNotNull("text");
		return text.GetRawBytes(0, text.Length);
	}

	/// <summary>
	/// 获取当前文本区域中字符的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="start">区域的起始位置</param>
	/// <param name="count">区域中的字符数量</param>
	/// <returns>当前文本区域中的字符的位字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的字符索引 <paramref name="start" /> 超出了当前字符数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的字符数量 <paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的字符数量。</exception>
	public static byte[] GetRawBytes(this string text, int start, int count)
	{
		text.GuardNotNull("text");
		start.GuardIndexRange(0, text.Length - 1, "start");
		count.GuardBetween(0, text.Length - start, "count");
		List<byte> result = new List<byte>(count * 2);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			result.AddRange(text[i].GetRawBytes());
		}
		return result.ToArray();
	}

	/// <summary>
	/// 获取当前路径字符串中的目录的信息对象
	/// </summary>
	/// <param name="path">当前路径字符串</param>
	/// <returns>返回当前路径字符串中的目录的信息对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前路径字符串为空。</exception>
	/// <remarks>本方法返回当前路径字符串中最后一个路径分隔符之前的目录信息对象。</remarks>
	public static DirectoryInfo GetDirectory(this string path)
	{
		return new DirectoryInfo(path.GetDirectoryName());
	}

	/// <summary>
	/// 获取当前路径字符串中的目录路径
	/// </summary>
	/// <param name="path">当前路径字符串</param>
	/// <returns>返回当前路径字符串中的目录路径</returns>
	/// <exception cref="T:System.ArgumentNullException">当前路径字符串为空。</exception>
	/// <remarks>本方法返回当前路径字符串中最后一个路径分隔符之前的目录路径。</remarks>
	public static string GetDirectoryName(this string path)
	{
		path.GuardNotNull("path");
		return (path.Length == 0) ? string.Empty : Path.GetDirectoryName(path);
	}

	/// <summary>
	/// 获取当前路径字符串中包含的扩展名，获取的扩展名不包含句点。
	/// </summary>
	/// <param name="path">当前路径字符串</param>
	/// <returns>当前路径字符串中包含的扩展名；如果没有扩展名返回空串。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前路径字符串为空。</exception>
	public static string GetExtension(this string path)
	{
		path.GuardNotNull("path");
		string extension = Path.GetExtension(path);
		return extension.IfNull(string.Empty).Trim('.');
	}

	/// <summary>
	/// 获取当前路径字符串中的文件名称，包括扩展名
	/// </summary>
	/// <param name="path">当前路径字符串</param>
	/// <returns>当前路径字符串中包含的文件名</returns>
	/// <exception cref="T:System.ArgumentNullException">当前路径字符串为空。</exception>
	public static string GetFileName(this string path)
	{
		path.GuardNotNull("path");
		return Path.GetFileName(path);
	}

	/// <summary>
	/// 获取当前路径字符串中的文件名称，不包含扩展名
	/// </summary>
	/// <param name="path">当前路径字符串</param>
	/// <returns>当前路径字符串中包含的文件名，不包含扩展名</returns>
	/// <exception cref="T:System.ArgumentNullException">当前路径字符串为空。</exception>
	public static string GetFileNameWithoutExtension(this string path)
	{
		path.GuardNotNull("path");
		return Path.GetFileNameWithoutExtension(path);
	}

	/// <summary>
	/// 获取当前路径字符串的完整路径（绝对路径）
	/// </summary>
	/// <param name="path">当前路径字符串</param>
	/// <returns>当前路径字符串的完整路径（绝对路径）</returns>
	/// <exception cref="T:System.ArgumentNullException">当前路径字符串为空。</exception>
	public static string GetFullPath(this string path)
	{
		path.GuardNotNull("path");
		return Path.GetFullPath(path);
	}

	/// <summary>
	/// 获取在当前文本中与给定正则模式匹配的匹配项目
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">匹配的正则模式</param>
	/// <param name="options">正则模式参数</param>
	/// <returns>匹配项目数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者匹配的正则模式 <paramref name="pattern" /> 为空。</exception>
	public static Match[] GetMatches(this string text, string pattern, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return pattern.ToRegex(options.EnsureLeftToRightOption()).GetMatches(text);
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
	public static Match[] GetMatches(this string text, string pattern, int start, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return pattern.ToRegex(options.EnsureLeftToRightOption()).GetMatches(text, start);
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
	public static Match[] GetMatches(this string text, string pattern, int start, int count, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return pattern.ToRegex(options.EnsureLeftToRightOption()).GetMatches(text, start, count);
	}

	/// <summary>
	/// 获取在当前文本中与给定正则模式匹配的匹配项目
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">匹配的正则模式</param>
	/// <returns>匹配项目数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者匹配的正则模式 <paramref name="pattern" /> 为空。</exception>
	public static Match[] GetMatches(this string text, Regex pattern)
	{
		return pattern.GetMatches(text);
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
	public static Match[] GetMatches(this string text, Regex pattern, int start)
	{
		return pattern.GetMatches(text, start);
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
	public static Match[] GetMatches(this string text, Regex pattern, int start, int count)
	{
		return pattern.GetMatches(text, start, count);
	}

	/// <summary>
	/// 获取在当前文本中与指定的正则模式匹配的满足条件的匹配项目
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">匹配的正则模式</param>
	/// <param name="predicate">匹配项目筛选方法</param>
	/// <returns>筛选后的匹配数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者匹配的正则模式 <paramref name="pattern" /> 为空；或者匹配筛选方法 <paramref name="predicate" /> 为空。</exception>
	public static Match[] GetMatches(this string text, Regex pattern, Func<Match, bool> predicate)
	{
		return pattern.GetMatches(text, predicate);
	}

	/// <summary>
	/// 获取在当前文本中与指定的正则模式匹配的满足条件的匹配项目
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">匹配的正则模式</param>
	/// <param name="predicate">匹配项目筛选方法</param>
	/// <returns>筛选后的匹配数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者匹配的正则模式 <paramref name="pattern" /> 为空；或者匹配筛选方法 <paramref name="predicate" /> 为空。</exception>
	public static Match[] GetMatches(this string text, Regex pattern, Func<Match, int, bool> predicate)
	{
		return pattern.GetMatches(text, predicate);
	}

	/// <summary>
	/// 逆向获取在当前文本中与给定正则模式匹配的匹配项目
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">匹配的正则模式</param>
	/// <param name="options">正则模式参数</param>
	/// <returns>匹配项目数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者匹配的正则模式 <paramref name="pattern" /> 为空。</exception>
	public static Match[] GetLastMatches(this string text, string pattern, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return pattern.ToRegex(options.EnsureRightToLeftOption()).GetMatches(text);
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
	public static Match[] GetLastMatches(this string text, string pattern, int start, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return pattern.ToRegex(options.EnsureRightToLeftOption()).GetMatches(text, start);
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
	public static Match[] GetLastMatches(this string text, string pattern, int start, int count, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return pattern.ToRegex(options.EnsureRightToLeftOption()).GetMatches(text, start, count);
	}

	/// <summary>
	/// 逆向获取在当前文本中与给定正则模式匹配的匹配项目
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">匹配的正则模式</param>
	/// <returns>匹配项目数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者匹配的正则模式 <paramref name="pattern" /> 为空。</exception>
	public static Match[] GetLastMatches(this string text, Regex pattern)
	{
		return pattern.GetLastMatches(text);
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
	public static Match[] GetLastMatches(this string text, Regex pattern, int start)
	{
		return pattern.GetLastMatches(text, start);
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
	public static Match[] GetLastMatches(this string text, Regex pattern, int start, int count)
	{
		return pattern.GetLastMatches(text, start, count);
	}

	/// <summary>
	/// 逆向获取在当前文本中与指定的正则模式匹配的满足条件的匹配项目
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">匹配的正则模式</param>
	/// <param name="predicate">匹配项目筛选方法</param>
	/// <returns>筛选后的匹配数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者匹配的正则模式 <paramref name="pattern" /> 为空；或者匹配筛选方法 <paramref name="predicate" /> 为空。</exception>
	public static Match[] GetLastMatches(this string text, Regex pattern, Func<Match, bool> predicate)
	{
		return pattern.GetLastMatches(text, predicate);
	}

	/// <summary>
	/// 逆向获取在当前文本中与指定的正则模式匹配的满足条件的匹配项目
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">匹配的正则模式</param>
	/// <param name="predicate">匹配项目筛选方法</param>
	/// <returns>筛选后的匹配数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者匹配的正则模式 <paramref name="pattern" /> 为空；或者匹配筛选方法 <paramref name="predicate" /> 为空。</exception>
	public static Match[] GetLastMatches(this string text, Regex pattern, Func<Match, int, bool> predicate)
	{
		return pattern.GetLastMatches(text, predicate);
	}

	/// <summary>
	/// 获取当前路径字符串的最末级的路径名称
	/// </summary>
	/// <param name="path">当前路径字符串</param>
	/// <returns>当前路径字符串中最末级的路径名称</returns>
	/// <exception cref="T:System.ArgumentNullException">当前路径字符串为空。</exception>
	public static string GetPathName(this string path)
	{
		path.GuardNotNull("path");
		return path.Split(new char[1] { Path.DirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries)[^1];
	}

	/// <summary>
	/// 获取当前路径字符串的根路径
	/// </summary>
	/// <param name="path">当前路径字符串</param>
	/// <returns>当前路径字符串的根路径</returns>
	/// <exception cref="T:System.ArgumentNullException">当前路径字符串为空。</exception>
	public static string GetPathRoot(this string path)
	{
		path.GuardNotNull("path");
		return (path.Length == 0) ? string.Empty : Path.GetPathRoot(path);
	}

	/// <summary>
	/// 获取当前路径字符串的卷标名称；只处理Windows和Mac系统的卷标包含冒号的路径，其他系统或者不包含卷标的路径，返回空串
	/// </summary>
	/// <param name="path">当前路径字符串</param>
	/// <returns>指定路径中包含的卷标名称，如果路径不包含卷标返回空串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前路径字符串为空。</exception>
	public static string GetPathVolumeName(this string path)
	{
		path.GuardNotNull("path");
		Match i = RegexPatterns.PathVolume.Match(path);
		if (!i.Success || i.Index > 0)
		{
			return string.Empty;
		}
		if (i.Groups.Count > 0)
		{
			return i.Groups[1].Value;
		}
		return string.Empty;
	}

	/// <summary>
	/// 将当前路径字符串转换为基于给定的基础目录的相对路径
	/// </summary>
	/// <param name="path">当前路径字符串</param>
	/// <param name="basePath">基础路径字符串</param>
	/// <returns>相对于基础路径的相对路径；如果当前路径不是绝对路径则返回当前路径本身；或者如果当前路径不是基于给定的基础路径的，则返回当前路径本身。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前路径字符串为空；或者基础路径字符串 <paramref name="basePath" /> 为空。</exception>
	public static string GetRelativePath(this string path, string basePath)
	{
		path.GuardNotNull("path");
		basePath.GuardNotNull("base path");
		if (path.IsAbsolutePath())
		{
			return path.TrimStart(basePath);
		}
		return path;
	}

	/// <summary>
	/// 获取当前URL字符串中的协议前缀字符串
	/// </summary>
	/// <param name="url">当前URL字符串</param>
	/// <returns>当前URL字符串中包含的协议前缀，如果不包含返回空串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前URL字符串为空。</exception>
	public static string GetUrlProtocol(this string url)
	{
		url.GuardNotNull("url");
		Match i = RegexPatterns.UrlProtocol.Match(url);
		if (!i.Success || i.Index > 0)
		{
			return string.Empty;
		}
		if (i.Groups.Count > 0)
		{
			return i.Groups[1].Value;
		}
		return string.Empty;
	}

	/// <summary>
	/// 检测当前目录是否存在，如果不存在则抛出 <see cref="T:System.IO.DirectoryNotFoundException" /> 异常。
	/// </summary>
	/// <param name="directory">当前目录路径</param>
	/// <param name="message">错误消息</param>
	/// <returns>如果当前目录路径指定的目录存在则返回该路径</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录路径为空。</exception>
	/// <exception cref="T:System.IO.DirectoryNotFoundException">当前目录路径指定的目录不存在。</exception>
	public static string GuardDirectoryExistence(this string directory, string message = null)
	{
		directory.GuardNotNull("directory");
		directory.Guard(Directory.Exists(directory), () => new DirectoryNotFoundException(message.IfNull(Literals.MSG_DirectoryNotFound_1.FormatValue(directory))));
		return directory;
	}

	/// <summary>
	/// 检测当前目录是否存在，如果不存在则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <param name="directory">当前目录路径</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果当前目录路径指定的目录存在则返回该路径</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前目录路径指定的目录不存在则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static string GuardDirectoryExistence(this string directory, Func<Exception> exceptionCreator)
	{
		directory.GuardNotNull("directory");
		directory.Guard(Directory.Exists(directory), exceptionCreator);
		return directory;
	}

	/// <summary>
	/// 检测当前目录是否存在，如果不存在则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <param name="directory">当前目录路径</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">创建异常时的参数</param>
	/// <returns>如果当前目录路径指定的目录存在则返回该路径</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前目录路径指定的目录不存在则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static string GuardDirectoryExistence(this string directory, Type exceptionType, params object[] args)
	{
		directory.GuardNotNull("directory");
		directory.Guard(Directory.Exists(directory), exceptionType, args);
		return directory;
	}

	/// <summary>
	/// 检测当前文件是否存在，如果文件不存在则抛出 <see cref="T:System.IO.FileNotFoundException" /> 异常。
	/// </summary>
	/// <param name="file">当前文件路径</param>
	/// <param name="message">错误消息</param>
	/// <returns>如果当前文件路径指定的文件存在则返回该路径</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件路径为空。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前文件路径指定的文件不存在。</exception>
	public static string GuardFileExistence(this string file, string message = null)
	{
		file.GuardNotNull("file");
		file.Guard(File.Exists(file), () => new FileNotFoundException(message.IfNull(Literals.MSG_FileNotFoundException_1.FormatValue(file)), file));
		return file;
	}

	/// <summary>
	/// 检测当前文件是否存在，如果文件不存在则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <param name="file">当前文件路径</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果当前文件路径指定的文件存在则返回该路径</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前文件路径指定的文件不存在则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static string GuardFileExistence(this string file, Func<Exception> exceptionCreator)
	{
		file.GuardNotNull("file");
		file.Guard(File.Exists(file), exceptionCreator);
		return file;
	}

	/// <summary>
	/// 检测当前文件是否存在，如果文件不存在则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <param name="file">当前文件路径</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">创建异常时的参数</param>
	/// <returns>如果当前文件路径指定的文件存在则返回该路径</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前文件路径指定的文件不存在则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static string GuardFileExistence(this string file, Type exceptionType, params object[] args)
	{
		file.GuardNotNull("file");
		file.Guard(File.Exists(file), exceptionType, args);
		return file;
	}

	/// <summary>
	/// 检测当前字符串是否为空或者空串，如果为空或者空串，则抛出 <see cref="T:System.ArgumentNullException" /> 异常。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="name">参数名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空或者空串。</exception>
	public static string GuardNotNullAndEmpty(this string s, string name = null, string message = null)
	{
		s.Guard(s.IsNotNullAndEmpty(), () => new ArgumentNullException(name.IfNull("s"), message.IfNull(Literals.MSG_StringNullOrEmpty)));
		return s;
	}

	/// <summary>
	/// 检测当前字符串是否为空或者空串，如果为空或者空串，则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前字符串为空或者空串，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static string GuardNotNullAndEmpty(this string s, Func<Exception> exceptionCreator)
	{
		s.Guard(s.IsNotNullAndEmpty(), exceptionCreator);
		return s;
	}

	/// <summary>
	/// 检测当前字符串是否为空或者空串，如果为空或者空串，则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前字符串为空或者空串，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static string GuardNotNullAndEmpty(this string s, Type exceptionType, params object[] args)
	{
		s.Guard(s.IsNotNullAndEmpty(), exceptionType, args);
		return s;
	}

	/// <summary>
	/// 检测当前字符串是否为空、空串或者全部为空白字符，如果为空、空串或者全部为空白字符，则抛出 <see cref="T:System.ArgumentNullException" /> 异常
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="name">参数名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空、空串或者全部为空白字符。</exception>
	public static string GuardNotNullAndWhiteSpace(this string s, string name = null, string message = null)
	{
		s.Guard(s.IsNotNullAndWhiteSpace(), () => new ArgumentNullException(name.IfNull("s"), message.IfNull(Literals.MSG_StringNullOrWhiteSpace)));
		return s;
	}

	/// <summary>
	/// 检测当前字符串是否为空、空串或者全部为空白字符，如果为空、空串或者全部为空白字符，则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前字符串为空、空串或者全部为空白字符，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static string GuardNotNullAndWhiteSpace(this string s, Func<Exception> exceptionCreator)
	{
		s.Guard(s.IsNotNullAndWhiteSpace(), exceptionCreator);
		return s;
	}

	/// <summary>
	/// 检测当前字符串是否为空、空串或者全部为空白字符，如果为空、空串或者全部为空白字符，则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前字符串为空、空串或者全部为空白字符，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static string GuardNotNullAndWhiteSpace(this string s, Type exceptionType, params object[] args)
	{
		s.Guard(s.IsNotNullAndWhiteSpace(), exceptionType, args);
		return s;
	}

	/// <summary>
	/// 检测当前字符串长度是否是指定值；如果当前字符串的长度不等于指定长度则抛出 <see cref="T:System.ArgumentException" /> 异常。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="length">字符串的目标长度</param>
	/// <param name="name">参数名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">指定的字符串长度 <paramref name="length" /> 小于0。</exception>
	/// <exception cref="T:System.ArgumentException">当前字符串的长度不等于指定长度 <paramref name="length" />。</exception>
	public static string GuardLength(this string s, long length, string name = null, string message = null)
	{
		s.GuardNotNull("s");
		length.GuardGreaterThanOrEqualTo(0L, "length");
		s.Guard(s.Length == length, message.IfNull("s"), name.IfNull(Literals.MSG_StringLengthError_1.FormatValue(length)));
		return s;
	}

	/// <summary>
	/// 检测当前字符串长度是否是指定值；如果当前字符串的长度不等于指定长度则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="length">字符串的目标长度</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前字符串的长度不等于指定长度 <paramref name="length" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static string GuardLength(this string s, long length, Func<Exception> exceptionCreator)
	{
		s.GuardNotNull("s");
		s.Guard(s.Length == length, exceptionCreator);
		return s;
	}

	/// <summary>
	/// 检测当前字符串长度是否是指定值；如果当前字符串的长度不等于指定长度则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="length">字符串的目标长度</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前字符串的长度不等于指定长度 <paramref name="length" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static string GuardLength(this string s, long length, Type exceptionType, params object[] args)
	{
		s.GuardNotNull("s");
		s.Guard(s.Length == length, exceptionType, args);
		return s;
	}

	/// <summary>
	/// 检测当前路径字符串是否包含扩展名
	/// </summary>
	/// <param name="path">当前路径字符串</param>
	/// <returns>如果包含扩展名返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前路径字符串为空。</exception>
	public static bool HasFileExtension(this string path)
	{
		path.GuardNotNull("path");
		return Path.HasExtension(path);
	}

	/// <summary>
	/// 计算当前文本的哈希值
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="encoding">将文本转换为字节使用的编码，默认是UTF-8</param>
	/// <param name="algorithm">用的哈希算法，默认为SHA1</param>
	/// <returns>字符串的哈希值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static byte[] Hash(this string text, Encoding encoding = null, HashAlgorithm algorithm = null)
	{
		text.GuardNotNull("text");
		return text.TextEncode(encoding.IfNull(Encoding.UTF8)).Hash(algorithm);
	}

	/// <summary>
	/// 将当前十六进制字符串转换为字节数组
	/// </summary>
	/// <param name="hex">当前字节的十六进制字符串</param>
	/// <returns>转换生成的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节的16进制字符串为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前字符串的长度不是2的整倍数；或者包含非十六进制数值字符。</exception>
	public static byte[] HexDecode(this string hex)
	{
		hex.GuardNotNull("hex text");
		hex.Guard(hex.Length % 2 == 0, "hex", Literals.MSG_HexStringLengthError);
		List<byte> buff = new List<byte>(hex.Length / 2);
		for (int i = 0; i < hex.Length; i += 2)
		{
			buff.Add((byte)((hex[i].ParseHex() << 4) + hex[i + 1].ParseHex()));
		}
		return buff.ToArray();
	}

	/// <summary>
	/// 将当前HTML编码的文本解码为普通文本
	/// </summary>
	/// <param name="html">当前HTML编码的文本</param>
	/// <returns>解码后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前HTML文本为空。</exception>
	public static string HtmlDecode(this string html)
	{
		html.GuardNotNull("html-encoded text");
		return HttpUtility.HtmlDecode(html);
	}

	/// <summary>
	/// 将当前文本转换为HTML编码的文本
	/// </summary>
	/// <param name="text">当前待编码的文本</param>
	/// <returns>编码后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前待编码的文本为空。</exception>
	public static string HtmlEncode(this string text)
	{
		text.GuardNotNull("text");
		return HttpUtility.HtmlEncode(text);
	}

	/// <summary>
	/// 如果当前字符串为空或者空串，返回指定替代字符串，否则返回当前字符串
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="value">用于替换的字符串</param>
	/// <returns>当前字符串或者替换的字符串</returns>
	public static string IfNullOrEmpty(this string s, string value)
	{
		return string.IsNullOrEmpty(s) ? value : s;
	}

	/// <summary>
	/// 如果当前字符串为空或者空串返回 <paramref name="evaluator" /> 生成的字符串，否则返回当前字符串。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="evaluator">用于生成替代字符串的方法</param>
	/// <returns>当前字符串或者生成的替代字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">替代字符串生成方法 <paramref name="evaluator" /> 为空。</exception>
	public static string IfNullOrEmptyThen(this string s, Func<string> evaluator)
	{
		evaluator.GuardNotNull("evaluator");
		return string.IsNullOrEmpty(s) ? evaluator() : s;
	}

	/// <summary>
	/// 如果当前字符串为空或者空串，执行指定的处理方法 <paramref name="action" />。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="action">处理方法</param>
	/// <exception cref="T:System.ArgumentNullException">替代处理方法 <paramref name="action" /> 为空。</exception>
	public static void IfNullOrEmptyThen(this string s, Action action)
	{
		action.GuardNotNull("action");
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
	public static string IfNotNullAndEmpty(this string s, string value)
	{
		return (!string.IsNullOrEmpty(s)) ? value : s;
	}

	/// <summary>
	/// 如果当前字符串不是空或者空串，返回 <paramref name="evaluator" /> 生成的替代字符串，否则返回当前字符串。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="evaluator">替代字符串生成方法</param>
	/// <returns>当前字符串或者生成的替换字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">替代字符串的生成方法 <paramref name="evaluator" /> 为空。</exception>
	public static string IfNotNullAndEmptyThen(this string s, Func<string> evaluator)
	{
		evaluator.GuardNotNull("evaluator");
		return (!string.IsNullOrEmpty(s)) ? evaluator() : s;
	}

	/// <summary>
	/// 如果当前字符串不是空或者空串，执行指定的处理 <paramref name="action" />。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="action">处理方法</param>
	/// <returns>处理结果</returns>
	/// <exception cref="T:System.ArgumentNullException">处理方法 <paramref name="action" /> 为空。</exception>
	public static void IfNotNullAndEmptyThen(this string s, Action action)
	{
		action.GuardNotNull("action");
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
	public static string IfNullOrWhiteSpace(this string s, string value)
	{
		return string.IsNullOrWhiteSpace(s) ? value : s;
	}

	/// <summary>
	/// 如果当前字符串为空、空串或者只包含空白字符，返回 <paramref name="evaluator" /> 生成的替代字符串，否则返回当前字符串。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="evaluator">替代字符串生成方法</param>
	/// <returns>当前字符串或者生成的替代字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">替代值生成方法 <paramref name="evaluator" /> 为空。</exception>
	public static string IfNullOrWhiteSpaceThen(this string s, Func<string> evaluator)
	{
		evaluator.GuardNotNull("evaluator");
		return string.IsNullOrWhiteSpace(s) ? evaluator() : s;
	}

	/// <summary>
	/// 如果当前字符串为空、空串或者只包含空白字符，执行指定的处理 <paramref name="action" />。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="action">处理方法</param>
	/// <exception cref="T:System.ArgumentNullException">处理方法 <paramref name="action" /> 为空。</exception>
	public static void IfNullOrWhiteSpaceThen(this string s, Action action)
	{
		action.GuardNotNull("action");
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
	public static string IfNotNullAndWhiteSpace(this string s, string value)
	{
		return (!string.IsNullOrWhiteSpace(s)) ? value : s;
	}

	/// <summary>
	/// 如果当前字符串不是空、空串或者只包含空白字符返回 <paramref name="evaluator" /> 生成的替代字符串，否则返回当前字符串
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="evaluator">替代字符串生成方法</param>
	/// <returns>当前字符串或者生成的替代字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">替代字符串生成方法 <paramref name="evaluator" /> 为空。</exception>
	public static string IfNotNullAndWhiteSpace(this string s, Func<string> evaluator)
	{
		evaluator.GuardNotNull("evaluator");
		return (!string.IsNullOrWhiteSpace(s)) ? evaluator() : s;
	}

	/// <summary>
	/// 如果当前字符串不是空、空串或者只包含空白字符，执行指定的处理 <paramref name="action" />
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="action">处理方法</param>
	/// <exception cref="T:System.ArgumentNullException">处理方法 <paramref name="action" /> 为空。</exception>
	public static void IfNotNullAndWhiteSpace(this string s, Action action)
	{
		action.GuardNotNull("action");
		if (!string.IsNullOrWhiteSpace(s))
		{
			action();
		}
	}

	/// <summary>
	/// 在当前文本的区域中查找指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="c">查找的字符</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>如果找到指定的字符返回其索引，否则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static int IndexOf(this string text, char c, bool ignoreCase = false)
	{
		text.GuardNotNull("text");
		return text.IndexOf(c, 0, text.Length, ignoreCase);
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
	public static int IndexOf(this string text, char c, CultureInfo culture, bool ignoreCase = false)
	{
		text.GuardNotNull("text");
		return text.IndexOf(c, 0, text.Length, culture, ignoreCase);
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
	public static int IndexOf(this string text, char c, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		return text.IndexOf(c, 0, text.Length, culture, options);
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
	public static int IndexOf(this string text, char c, int start, bool ignoreCase = false)
	{
		return text.IndexOf(c, start, CultureInfo.CurrentCulture, ignoreCase);
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
	public static int IndexOf(this string text, char c, int start, CultureInfo culture, bool ignoreCase = false)
	{
		return text.IndexOf(c, start, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static int IndexOf(this string text, char c, int start, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		start.GuardIndexRange(0, text.Length - 1, "start");
		return culture.IfNull(CultureInfo.CurrentCulture).CompareInfo.IndexOf(text, c, start, options);
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
	public static int IndexOf(this string text, char c, int start, int count, bool ignoreCase = false)
	{
		return text.IndexOf(c, start, count, CultureInfo.CurrentCulture, ignoreCase);
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
	public static int IndexOf(this string text, char c, int start, int count, CultureInfo culture, bool ignoreCase = false)
	{
		return text.IndexOf(c, start, count, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static int IndexOf(this string text, char c, int start, int count, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		start.GuardIndexRange(0, text.Length - 1, "start");
		count.GuardBetween(0, text.Length - start, "count");
		return culture.IfNull(CultureInfo.CurrentCulture).CompareInfo.IndexOf(text, c, start, count, options);
	}

	/// <summary>
	/// 在当前文本的区域中查找指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="s">查找的字符串</param>
	/// <param name="ignoreCase">比较字符是否区分大小写</param>
	/// <returns>如果找到指定的字符串返回其索引，否则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者查找的字符串为空。</exception>
	public static int IndexOf(this string text, string s, bool ignoreCase = false)
	{
		text.GuardNotNull("text");
		return text.IndexOf(s, 0, text.Length, ignoreCase);
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
	public static int IndexOf(this string text, string s, CultureInfo culture, bool ignoreCase = false)
	{
		text.GuardNotNull("text");
		return text.IndexOf(s, 0, text.Length, culture, ignoreCase);
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
	public static int IndexOf(this string text, string s, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		return text.IndexOf(s, 0, text.Length, culture, options);
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
	public static int IndexOf(this string text, string s, int start, bool ignoreCase = false)
	{
		return text.IndexOf(s, start, CultureInfo.CurrentCulture, ignoreCase);
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
	public static int IndexOf(this string text, string s, int start, CultureInfo culture, bool ignoreCase = false)
	{
		return text.IndexOf(s, start, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static int IndexOf(this string text, string s, int start, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		s.GuardNotNull("s");
		start.GuardIndexRange(0, text.Length - 1, "start");
		return culture.IfNull(CultureInfo.CurrentCulture).CompareInfo.IndexOf(text, s, start, options);
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
	public static int IndexOf(this string text, string s, int start, int count, bool ignoreCase = false)
	{
		return text.IndexOf(s, start, count, CultureInfo.CurrentCulture, ignoreCase);
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
	public static int IndexOf(this string text, string s, int start, int count, CultureInfo culture, bool ignoreCase = false)
	{
		return text.IndexOf(s, start, count, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static int IndexOf(this string text, string s, int start, int count, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		s.GuardNotNull("s");
		start.GuardIndexRange(0, text.Length - 1, "start");
		count.GuardBetween(0, text.Length - start, "count");
		return culture.IfNull(CultureInfo.CurrentCulture).CompareInfo.IndexOf(text, s, start, count, options);
	}

	/// <summary>
	/// 检索系统对当前字符串的暂存引用；如果系统没有暂存当前字符串，则暂存后返回暂存的字符串。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <returns>系统暂存的与当前字符串值相同的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static string Intern(this string s)
	{
		s.GuardNotNull("s");
		return string.Intern(s);
	}

	/// <summary>
	/// 判断当前字符串是否符合Guid的字符串格式
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <returns>如果当前字符串符合Guid的格式返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static bool IsGuid(this string s)
	{
		s.GuardNotNull("s");
		return RegexPatterns.Guid.IsWholeMatch(s);
	}

	/// <summary>
	/// 判断当前字符串是否符合JSON样式
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <returns>如果当前字符串符合JSON的样式返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static bool IsJson(this string s)
	{
		s.GuardNotNull("s");
		return RegexPatterns.Json.IsWholeMatch(s);
	}

	/// <summary>
	/// 判断当前字符串是否符合JSON数组样式
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <returns>如果当前字符串符合JSON数组的样式返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static bool IsJsonArray(this string s)
	{
		s.GuardNotNull("s");
		return RegexPatterns.JsonArray.IsWholeMatch(s);
	}

	/// <summary>
	/// 判断当前字符串是否符合JSON对象样式
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <returns>如果当前字符串符合JSON数组的样式返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static bool IsJsonObject(this string s)
	{
		s.GuardNotNull("s");
		return RegexPatterns.JsonObject.IsWholeMatch(s);
	}

	/// <summary>
	/// 检测当前字符串是否已经被系统暂存
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <returns>如果当前字符串已经被暂存返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static bool IsInterned(this string s)
	{
		s.GuardNotNull("s");
		return string.IsInterned(s).IsNotNull();
	}

	/// <summary>
	/// 判断当前文本是否与指定的正则模式匹配
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">匹配的模式</param>
	/// <param name="options">正则模式选项</param>
	/// <returns>如果匹配返回true,否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者匹配的正则模式 <paramref name="pattern" /> 为空。</exception>
	public static bool IsMatch(this string text, string pattern, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return text.IsMatch(pattern.ToRegex(options));
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
	public static bool IsMatch(this string text, string pattern, bool wholeMatching, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return text.IsMatch(pattern.ToRegex(options), wholeMatching);
	}

	/// <summary>
	/// 判断当前文本是否与指定的正则模式匹配
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">匹配的模式</param>
	/// <param name="wholeMatching">是否进行完整匹配，默认为false。</param>
	/// <returns>如果匹配返回true,否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者匹配的正则模式 <paramref name="pattern" /> 为空。</exception>
	public static bool IsMatch(this string text, Regex pattern, bool wholeMatching = false)
	{
		text.GuardNotNull("text");
		pattern.GuardNotNull("pattern");
		return wholeMatching ? pattern.IsWholeMatch(text) : pattern.IsMatch(text);
	}

	/// <summary>
	/// 判断当前字符串是否为空或者空串
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <returns>如果当前字符串为空或者空串返回true,否则false</returns>
	public static bool IsNullOrEmpty(this string s)
	{
		return string.IsNullOrEmpty(s);
	}

	/// <summary>
	/// 判断当前字符串是否不为空或者空串
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <returns>如果当前字符串不是空或者空串返回true，否则返回false</returns>
	public static bool IsNotNullAndEmpty(this string s)
	{
		return !string.IsNullOrEmpty(s);
	}

	/// <summary>
	/// 判断当前字符串是否为空、空串或者空白字符
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <returns>如果当前字符串为空、空串或者空白字符返回true,否则false</returns>
	public static bool IsNullOrWhiteSpace(this string s)
	{
		return string.IsNullOrWhiteSpace(s);
	}

	/// <summary>
	/// 判断当前字符串是否不是空、空串或者空白字符
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <returns>如果当前字符串不是空、空串或者空白字符返回true，否则返回false</returns>
	public static bool IsNotNullAndWhiteSpace(this string s)
	{
		return !string.IsNullOrWhiteSpace(s);
	}

	/// <summary>
	/// 判断当前路径字符串是否表示绝对路径
	/// </summary>
	/// <param name="path">当前路径字符串</param>
	/// <returns>如果当前路径字符串表示绝对路径返回true，相对路径返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前路径字符串为空。</exception>
	public static bool IsAbsolutePath(this string path)
	{
		path.GuardNotNull("path");
		return RegexPatterns.PathRoot.IsMatch(path);
	}

	/// <summary>
	/// 检测当前路径字符串是否包含根路径
	/// </summary>
	/// <param name="path">当前路径字符串</param>
	/// <returns>如果当前路径字符串包含根路径返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前路径字符串为空。</exception>
	public static bool IsPathRooted(this string path)
	{
		path.GuardNotNull("path");
		return Path.IsPathRooted(path);
	}

	/// <summary>
	/// 判断当前路径字符串是否表示相对路径
	/// </summary>
	/// <param name="path">当前路径字符串</param>
	/// <returns>如果当前路径字符串表示相对路径返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前路径字符串为空。</exception>
	public static bool IsRelativePath(this string path)
	{
		return !path.IsAbsolutePath();
	}

	/// <summary>
	/// 判断当前文本是否是Unicode字符串（只包含Unicode字符）
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <returns>如果当前文本全部字符都是Unicode字符返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static bool IsUnicode(this string text)
	{
		text.GuardNotNull("text");
		return text.AsciiEncode().AsciiDecode().EqualOrdinal(text);
	}

	/// <summary>
	/// 检测当前文件名字符串是否是有效的文件名
	/// </summary>
	/// <param name="fileName">当前文件名字符串</param>
	/// <returns>如果当前字符串时有效的文件名返回true；否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件名字符串为空。</exception>
	public static bool IsValidFileName(this string fileName)
	{
		fileName.GuardNotNull("file name");
		return fileName.IndexOfAny(Path.GetInvalidFileNameChars()) < 0;
	}

	/// <summary>
	/// 检测当前文件路径字符串（包括路径和文件名）是否有效
	/// </summary>
	/// <param name="filePath">当前文件路径字符串</param>
	/// <returns>如果当前文件路径字符串是否有效返回true；否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件路径字符串为空。</exception>
	public static bool IsValidFilePath(this string filePath)
	{
		filePath.GuardNotNull("file path");
		return filePath.IndexOfAny(Path.GetInvalidFileNameChars().Union(Path.GetInvalidPathChars()).ToArray()) < 0;
	}

	/// <summary>
	/// 检测当前路径字符串是否有效
	/// </summary>
	/// <param name="path">当前路径字符串</param>
	/// <returns>如果当前路径字符串是否有效返回true；否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前路径字符串为空。</exception>
	public static bool IsValidPath(this string path)
	{
		path.GuardNotNull("path");
		return path.IndexOfAny(Path.GetInvalidPathChars()) < 0;
	}

	/// <summary>
	/// 判断当前字符串是否存在于给定的字符串列表中；字符串区分大小写。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="values">用于比较的字符串列表</param>
	/// <returns>如果当前字符串存在于列表中返回true，否则返回false。</returns>
	public static bool In(this string s, params string[] values)
	{
		return s.In(values, StringComparison.CurrentCulture);
	}

	/// <summary>
	/// 判断当前字符串是否存在于给定的字符串列表中
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="values">用于比较的字符串列表</param>
	/// <param name="ignoreCase">字符串比较是否区分大小写</param>
	/// <returns>如果当前字符串存在于列表中返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者比较字符串列表为空。</exception>
	public static bool In(this string s, IEnumerable<string> values, bool ignoreCase)
	{
		return s.In(values, ignoreCase ? StringComparer.CurrentCultureIgnoreCase : StringComparer.CurrentCulture);
	}

	/// <summary>
	/// 判断当前字符串是否存在于给定的字符串列表中
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="values">用于比较的字符串列表</param>
	/// <param name="comparison">字符串比较方式</param>
	/// <returns>如果当前字符串存在于列表中返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者比较字符串列表为空。</exception>
	public static bool In(this string s, IEnumerable<string> values, StringComparison comparison)
	{
		s.GuardNotNull("s");
		values.GuardNotNull("values");
		return values.Any((string x) => string.Equals(x, s, comparison));
	}

	/// <summary>
	/// 获取自定的Json转换器
	/// </summary>
	/// <returns>自定义的Json转换器数组</returns>
	private static JsonConverter[] GetPredefinedJsonConverters()
	{
		if (jsonConverters.IsNull())
		{
			jsonConverters = new JsonConverter[1]
			{
				new IsoDateTimeConverter
				{
					DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fff"
				}
			};
			return jsonConverters;
		}
		return jsonConverters;
	}

	/// <summary>
	/// 将当前JSON表达式反序列化为对象
	/// </summary>
	/// <param name="json">当前JSON表达式</param>
	/// <param name="type">反序列化的目标对象类型</param>
	/// <param name="converters">可选的JSON转换器；如果指定了JSON转换，则将忽略所有内置的JSON转换器。</param>
	/// <returns>反序列化生成的目标类型对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前JSON表达式为空；或者目标对象类型为空。</exception>
	public static object JsonDeserialize(this string json, Type type, params JsonConverter[] converters)
	{
		json.GuardNotNull("json");
		type.GuardNotNull("type");
		if (converters.IsNull() || converters.Length == 0)
		{
			converters = GetPredefinedJsonConverters();
		}
		return JsonConvert.DeserializeObject(json, type, converters);
	}

	/// <summary>
	/// 将当前JSON表达式反序列化为对象
	/// </summary>
	/// <typeparam name="T">反序列化的目标对象类型</typeparam>
	/// <param name="json">当前JSON表达式</param>
	/// <param name="converters">可选的JSON转换器；如果指定了JSON转换，则将忽略所有内置的JSON转换器。</param>
	/// <returns>反序列化生成的目标类型对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前JSON表达式为空。</exception>
	public static T JsonDeserialize<T>(this string json, params JsonConverter[] converters)
	{
		json.GuardNotNull("json");
		if (converters.IsNull() || converters.Length == 0)
		{
			converters = GetPredefinedJsonConverters();
		}
		return JsonConvert.DeserializeObject<T>(json, converters);
	}

	/// <summary>
	/// 将当前JSON表达式反序列化为对象数组
	/// </summary>
	/// <param name="json">当前JSON表达式</param>
	/// <param name="converting">JSON标记到对象的转换方法</param>
	/// <returns>反序列化生成的对象数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前JSON表达式为空；或者JSON标记到对象的转换方法 <paramref name="converting" /> 为空。</exception>
	public static object[] JsonDeserializeToArray(this string json, Func<JToken, object> converting)
	{
		json.GuardNotNull("json");
		converting.GuardNotNull("converting");
		object obj = JsonConvert.DeserializeObject(json);
		if (obj is JArray)
		{
			List<object> list = new List<object>();
			foreach (JToken token in (JArray)obj)
			{
				list.Add(converting(token));
			}
			return list.ToArray();
		}
		if (obj is JObject)
		{
			return new object[1] { converting((JObject)obj) };
		}
		return new object[0];
	}

	/// <summary>
	/// 将当前JSON表达式反序列化为对象数组
	/// </summary>
	/// <typeparam name="T">反序列化的数组元素类型</typeparam>
	/// <param name="json">当前JSON表达式</param>
	/// <param name="converting">JSON标记到对象的转换方法</param>
	/// <returns>反序列化生成的对象数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前JSON表达式为空；或者JSON标记到对象的转换方法 <paramref name="converting" /> 为空。</exception>
	public static T[] JsonDeserializeToArray<T>(this string json, Func<JToken, T> converting)
	{
		json.GuardNotNull("json");
		converting.GuardNotNull("converting");
		object obj = JsonConvert.DeserializeObject(json);
		if (obj is JArray)
		{
			List<T> list = new List<T>();
			foreach (JToken token in (JArray)obj)
			{
				list.Add(converting(token));
			}
			return list.ToArray();
		}
		if (obj is JObject)
		{
			return new T[1] { converting((JObject)obj) };
		}
		throw new JsonException(Literals.MSG_JsonUnrecognized);
	}

	/// <summary>
	/// 将当前JSON表达式反序列化为对象列表
	/// </summary>
	/// <typeparam name="T">反序列化的列表元素类型</typeparam>
	/// <param name="json">当前JSON表达式</param>
	/// <param name="converters">可选的JSON转换器；如果指定了JSON转换，则将忽略所有内置的JSON转换器。</param>
	/// <returns>反序列化生成的对象列表</returns>
	/// <exception cref="T:System.ArgumentNullException">当前JSON表达式为空。</exception>
	public static List<T> JsonDeserializeToList<T>(this string json, params JsonConverter[] converters)
	{
		json.GuardNotNull("json");
		if (converters.IsNull() || converters.Length == 0)
		{
			converters = GetPredefinedJsonConverters();
		}
		if (json.IsJsonArray())
		{
			return JsonConvert.DeserializeObject<List<T>>(json, converters);
		}
		if (json.IsJsonObject())
		{
			List<T> list = new List<T>();
			list.Add(JsonConvert.DeserializeObject<T>(json, converters));
			return list;
		}
		throw new JsonException(Literals.MSG_JsonUnrecognized);
	}

	/// <summary>
	/// 保留当前文本中所有的字母（大写和小写的英文字母）
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <returns>被保留的当前文本中所有的字母字符的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static string KeepAlpha(this string text)
	{
		return text.KeepRegex(RegexPatterns.AlphaMore);
	}

	/// <summary>
	/// 保留当前文本中所有的字母和数字（大写和小写的英文字母、数字）
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <returns>当前文本中所有的字母和数字字符的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static string KeepAlphaDigit(this string text)
	{
		return text.KeepRegex(RegexPatterns.AlphaDigitMore);
	}

	/// <summary>
	/// 保留当前文本中所有指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="chars">需要保留的字符数组</param>
	/// <returns>当前文本中保留的字符组成的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者保留的字符数组 <paramref name="chars" /> 为空。</exception>
	public static string KeepChar(this string text, params char[] chars)
	{
		return text.KeepChar(chars, CultureInfo.CurrentCulture);
	}

	/// <summary>
	/// 保留当前文本中所有指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="chars">需要保留的字符数组</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>当前文本中保留的字符组成的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者保留的字符数组 <paramref name="chars" /> 为空。</exception>
	public static string KeepChar(this string text, char[] chars, bool ignoreCase = false)
	{
		return text.KeepChar(chars, CultureInfo.CurrentCulture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static string KeepChar(this string text, char[] chars, CultureInfo culture, bool ignoreCase = false)
	{
		return text.KeepChar(chars, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static string KeepChar(this string text, char[] chars, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		chars.GuardNotNull("chars");
		StringBuilder buff = new StringBuilder();
		foreach (char c in text)
		{
			Func<char, bool> predicate = (char x) => x.IsEqualTo(c, culture, options);
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
	public static string KeepChar(this string text, Func<char, bool> predicate)
	{
		predicate.GuardNotNull("predicate");
		return text.KeepChar((char c, int i) => predicate(c));
	}

	/// <summary>
	/// 保留当前文本中满足条件的字符；如果没有指定字符的检测条件,则不返回任何字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="predicate">当前文本中字符的检测条件</param>
	/// <returns>当前文本中所有满足条件的字符</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者字符筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static string KeepChar(this string text, Func<char, int, bool> predicate)
	{
		text.GuardNotNull("text");
		predicate.GuardNotNull("predicate");
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
	public static string KeepLastChar(this string text, params char[] chars)
	{
		return text.KeepLastChar(chars, CultureInfo.CurrentCulture);
	}

	/// <summary>
	/// 逆向检测并保留当前文本中所有指定的字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="chars">需要保留的字符数组</param>
	/// <param name="ignoreCase">比较字符时是否区分大小写</param>
	/// <returns>当前文本中保留的字符组成的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者保留的字符数组 <paramref name="chars" /> 为空。</exception>
	public static string KeepLastChar(this string text, char[] chars, bool ignoreCase = false)
	{
		return text.KeepLastChar(chars, CultureInfo.CurrentCulture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static string KeepLastChar(this string text, char[] chars, CultureInfo culture, bool ignoreCase = false)
	{
		return text.KeepLastChar(chars, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static string KeepLastChar(this string text, char[] chars, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		chars.GuardNotNull("chars");
		StringBuilder buff = new StringBuilder();
		int i;
		for (i = text.Length - 1; i >= 0; i--)
		{
			if (chars.Any((char x) => x.IsEqualTo(text[i], culture, options)))
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
	public static string KeepLastChar(this string text, Func<char, bool> predicate)
	{
		predicate.GuardNotNull("predicate");
		return text.KeepLastChar((char c, int i) => predicate(c));
	}

	/// <summary>
	/// 逆向检测并保留当前文本中满足条件的字符；如果没有指定字符的检测条件,则不返回任何字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="predicate">字符检测条件</param>
	/// <returns>当前文本中所有满足条件的字符组成的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者字符筛选条件 <paramref name="predicate" /> 为空。</exception>
	public static string KeepLastChar(this string text, Func<char, int, bool> predicate)
	{
		text.GuardNotNull("text");
		predicate.GuardNotNull("predicate");
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
	public static string KeepChineseCharacter(this string text)
	{
		return text.KeepRegex(RegexPatterns.ChineseCharacterMore);
	}

	/// <summary>
	/// 保留当前文本中的中文字符和符号
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <returns>当前文本中的中文字符组成的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static string KeepChineseSymbol(this string text)
	{
		return text.KeepRegex(RegexPatterns.ChineseSymbolMore);
	}

	/// <summary>
	/// 保留当期文本中的数字
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <returns>当前文本中数组组成的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static string KeepDigit(this string text)
	{
		return text.KeepRegex(RegexPatterns.DigitMore);
	}

	/// <summary>
	/// 保留当前文本中的具有“+XXX.XXX”数值；只保留第一个具有浮点数值形式的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <returns>输入文本中第一个具有浮点数值形式的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static string KeepFixedPointNumber(this string text)
	{
		return text.KeepRegex(RegexPatterns.FixedPointNumber, 1);
	}

	/// <summary>
	/// 保留当前文本的区域中与指定模式匹配的文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="pattern">需要保留的文本的正则表达式</param>
	/// <param name="options">正则表达式参数</param>
	/// <returns>被保留的符合指定模式的文本组成的字符串。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者保留文本的正则模式 <paramref name="pattern" /> 为空</exception>
	public static string KeepRegex(this string text, string pattern, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return text.KeepRegex(pattern.ToRegex(options));
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
	public static string KeepRegex(this string text, string pattern, int times, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return text.KeepRegex(pattern.ToRegex(options), times);
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
	public static string KeepRegex(this string text, string pattern, int start, int count, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return text.KeepRegex(pattern.ToRegex(options), start, count);
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
	public static string KeepRegex(this string text, string pattern, int start, int count, int times, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return text.KeepRegex(pattern.ToRegex(options), start, count, times);
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
	public static string KeepRegex(this string text, Regex pattern, int times = -1)
	{
		text.GuardNotNull("text");
		return text.KeepRegex(pattern, 0, text.Length, times);
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
	public static string KeepRegex(this string text, Regex pattern, int start, int count, int times = -1)
	{
		text.GuardNotNull("text");
		pattern.GuardNotNull("pattern");
		times.GuardGreaterThanOrEqualTo(-1, "times");
		StringBuilder buff = new StringBuilder();
		int found = 0;
		Match[] matches = pattern.GetMatches(text, start, count);
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
	public static string KeepLastRegex(this string text, string pattern, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return text.KeepLastRegex(pattern.ToRegex(options));
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
	public static string KeepLastRegex(this string text, string pattern, int times, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return text.KeepLastRegex(pattern.ToRegex(options), times);
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
	public static string KeepLastRegex(this string text, string pattern, int start, int count, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return text.KeepLastRegex(pattern.ToRegex(options), start, count);
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
	public static string KeepLastRegex(this string text, string pattern, int start, int count, int times, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return text.KeepLastRegex(pattern.ToRegex(options), start, count, times);
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
	public static string KeepLastRegex(this string text, Regex pattern, int times = -1)
	{
		text.GuardNotNull("text");
		return text.KeepLastRegex(pattern, text.Length - 1, text.Length, times);
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
	public static string KeepLastRegex(this string text, Regex pattern, int start, int count, int times = -1)
	{
		text.GuardNotNull("text");
		pattern.GuardNotNull("pattern");
		times.GuardGreaterThanOrEqualTo(-1, "times");
		StringBuilder buff = new StringBuilder();
		int found = 0;
		Match[] array = pattern.GetLastMatches(text, start, count).Reverse();
		foreach (Match i in array)
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
	public static int LastIndexOf(this string text, char c, bool ignoreCase = false)
	{
		text.GuardNotNull("text");
		return text.LastIndexOf(c, 0, text.Length, ignoreCase);
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
	public static int LastIndexOf(this string text, char c, CultureInfo culture, bool ignoreCase = false)
	{
		text.GuardNotNull("text");
		return text.LastIndexOf(c, 0, text.Length, culture, ignoreCase);
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
	public static int LastIndexOf(this string text, char c, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		return text.LastIndexOf(c, 0, text.Length, culture, options);
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
	public static int LastIndexOf(this string text, char c, int start, bool ignoreCase = false)
	{
		return text.LastIndexOf(c, start, CultureInfo.CurrentCulture, ignoreCase);
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
	public static int LastIndexOf(this string text, char c, int start, CultureInfo culture, bool ignoreCase = false)
	{
		return text.LastIndexOf(c, start, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static int LastIndexOf(this string text, char c, int start, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		start.GuardIndexRange(0, text.Length - 1, "start");
		return culture.IfNull(CultureInfo.CurrentCulture).CompareInfo.LastIndexOf(text, c, start, options);
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
	public static int LastIndexOf(this string text, char c, int start, int count, bool ignoreCase = false)
	{
		return text.LastIndexOf(c, start, count, CultureInfo.CurrentCulture, ignoreCase);
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
	public static int LastIndexOf(this string text, char c, int start, int count, CultureInfo culture, bool ignoreCase = false)
	{
		return text.LastIndexOf(c, start, count, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static int LastIndexOf(this string text, char c, int start, int count, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		start.GuardIndexRange(0, text.Length - 1, "start");
		count.GuardBetween(0, text.Length - start, "count");
		return culture.IfNull(CultureInfo.CurrentCulture).CompareInfo.LastIndexOf(text, c, start, count, options);
	}

	/// <summary>
	/// 在当前文本的区域中逆向查找指定的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="s">查找的字符串</param>
	/// <param name="ignoreCase">比较字符是否区分大小写</param>
	/// <returns>如果找到指定的字符串返回其索引，否则返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者查找的字符串为空。</exception>
	public static int LastIndexOf(this string text, string s, bool ignoreCase = false)
	{
		text.GuardNotNull("text");
		return text.LastIndexOf(s, 0, text.Length, ignoreCase);
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
	public static int LastIndexOf(this string text, string s, CultureInfo culture, bool ignoreCase = false)
	{
		text.GuardNotNull("text");
		return text.LastIndexOf(s, 0, text.Length, culture, ignoreCase);
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
	public static int LastIndexOf(this string text, string s, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		return text.LastIndexOf(s, 0, text.Length, culture, options);
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
	public static int LastIndexOf(this string text, string s, int start, bool ignoreCase = false)
	{
		return text.LastIndexOf(s, start, CultureInfo.CurrentCulture, ignoreCase);
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
	public static int LastIndexOf(this string text, string s, int start, CultureInfo culture, bool ignoreCase = false)
	{
		return text.LastIndexOf(s, start, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static int LastIndexOf(this string text, string s, int start, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		s.GuardNotNull("s");
		start.GuardIndexRange(0, text.Length - 1, "start");
		return culture.IfNull(CultureInfo.CurrentCulture).CompareInfo.LastIndexOf(text, s, start, options);
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
	public static int LastIndexOf(this string text, string s, int start, int count, bool ignoreCase = false)
	{
		return text.LastIndexOf(s, start, count, CultureInfo.CurrentCulture, ignoreCase);
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
	public static int LastIndexOf(this string text, string s, int start, int count, CultureInfo culture, bool ignoreCase = false)
	{
		return text.LastIndexOf(s, start, count, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static int LastIndexOf(this string text, string s, int start, int count, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		s.GuardNotNull("s");
		start.GuardIndexRange(0, text.Length - 1, "start");
		count.GuardBetween(0, text.Length - start, "count");
		return culture.IfNull(CultureInfo.CurrentCulture).CompareInfo.LastIndexOf(text, s, start, count, options);
	}

	/// <summary>
	/// 获取当前文本左侧指定长度的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="count">从左侧获取的字符数量</param>
	/// <returns>截取的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">获取的字符数量 <paramref name="count" /> 小于0，或者大于当前文本的字符数量。</exception>
	public static string Left(this string text, int count)
	{
		text.GuardNotNull("text");
		count.GuardBetween(0, text.Length, "count");
		return text.Substring(0, count);
	}

	/// <summary>
	/// 加载当前名称的程序集到当前应用程序域
	/// </summary>
	/// <param name="assemblyName">当前程序集名称</param>
	/// <returns>加载的程序集</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集名称为空或者空串。</exception>
	public static Assembly LoadAssembly(this string assemblyName)
	{
		assemblyName.GuardNotNullAndEmpty("assembly name");
		return Assembly.Load(assemblyName);
	}

	/// <summary>
	/// 加载当前文件中的程序集到当前应用程序域
	/// </summary>
	/// <param name="assemblyFile">当前程序集文件</param>
	/// <returns>加载的程序集</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集文件为空或者空串。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前程序集文件不存在。</exception>
	public static Assembly LoadAssemblyFrom(this string assemblyFile)
	{
		assemblyFile.GuardNotNull("assembly file").GuardFileExistence();
		return Assembly.LoadFrom(assemblyFile);
	}

	/// <summary>
	/// 加载当前文件中的程序集到当前应用程序域
	/// </summary>
	/// <param name="assemblyFile">当前程序集文件</param>
	/// <returns>加载的程序集</returns>
	/// <exception cref="T:System.ArgumentNullException">当前程序集文件为空或者空串。</exception>
	/// <exception cref="T:System.IO.FileNotFoundException">当前程序集文件不存在。</exception>
	public static Assembly LoadAssemblyFromFile(this string assemblyFile)
	{
		assemblyFile.GuardNotNull("assembly file").GuardFileExistence();
		return Assembly.LoadFile(assemblyFile);
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
	public static string MaskLeft(this string text, int count, char mask = '*')
	{
		text.GuardNotNull("text");
		count.GuardBetween(0, text.Length, "count");
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
	public static string MaskRight(this string text, int count, char mask = '*')
	{
		text.GuardNotNull("text");
		count.GuardBetween(0, text.Length, "count");
		StringBuilder buff = new StringBuilder(text.Length);
		buff.Append(text.Substring(0, text.Length - count));
		for (int i = 0; i < count; i++)
		{
			buff.Append(mask);
		}
		return buff.ToString();
	}

	/// <summary>
	/// 规范化当前文件名称，非法文件名字符使用默认字符替代
	/// </summary>
	/// <param name="fileName">当前文件名称</param>
	/// <param name="defaultChar">用以替换非法字符的默认字符</param>
	/// <returns>规范化的文件名称</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件名称为空。</exception>
	/// <remarks>本方法仅用于规范化文件名称，如果要规范化文件全名（文件路径和文件名称），应使用 <see cref="M:Richfit.Garnet.Common.Extensions.StringExtensions.NormalizeFilePath(System.String,System.Char)" /> 方法。</remarks>
	public static string NormalizeFileName(this string fileName, char defaultChar = '_')
	{
		fileName.GuardNotNull("filename");
		return RegexPatterns.InvalidFileNameChars.Replace(fileName, defaultChar.ToString());
	}

	/// <summary>
	/// 规范化当前文件路径（包含文件路径和文件名称），非法字符使用默认字符替代
	/// </summary>
	/// <param name="filePath">当前文件路径</param>
	/// <param name="defaultChar">用以替换非法字符的默认字符</param>
	/// <returns>规范化的文件路径</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文件名称为空。</exception>
	public static string NormalizeFilePath(this string filePath, char defaultChar = '_')
	{
		filePath.GuardNotNull("filename");
		string fileName = Path.GetFileName(filePath);
		if (fileName.Length >= 0)
		{
			return filePath.Substring(0, filePath.Length - fileName.Length).NormalizePath(defaultChar) + fileName.NormalizeFileName(defaultChar);
		}
		return filePath.NormalizePath(defaultChar);
	}

	/// <summary>
	/// 规范化当前路径，非法路径字符使用默认字符替代
	/// </summary>
	/// <param name="path">当前路径</param>
	/// <param name="defaultChar">用以替换非法字符的默认字符</param>
	/// <returns>规范化的路径</returns>
	/// <exception cref="T:System.ArgumentNullException">当前路径为空。</exception>
	/// <remarks>本方法仅用于规范化路径，如果要处理包含文件名的路径，应使用 <see cref="M:Richfit.Garnet.Common.Extensions.StringExtensions.NormalizeFilePath(System.String,System.Char)" /> 方法。</remarks>
	public static string NormalizePath(this string path, char defaultChar = '_')
	{
		path.GuardNotNull("path");
		return RegexPatterns.InvalidPathChars.Replace(path, defaultChar.ToString());
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Boolean" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static bool ParseBoolean(this string s)
	{
		s.GuardNotNull("s");
		s = s.Trim();
		if (RegexPatterns.BooleanTrue.IsWholeMatch(s))
		{
			return true;
		}
		if (RegexPatterns.BooleanFalse.IsWholeMatch(s))
		{
			return false;
		}
		return bool.Parse(s);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Byte" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static byte ParseByte(this string s, IFormatProvider provider = null)
	{
		return s.ParseByte(NumberStyles.Integer | NumberStyles.AllowHexSpecifier, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Byte" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static byte ParseByte(this string s, NumberStyles style, IFormatProvider provider = null)
	{
		s.GuardNotNull("s");
		if (style.HasFlag(NumberStyles.AllowHexSpecifier))
		{
			s = RegexPatterns.HexNumberPrefix.Replace(s, string.Empty);
		}
		return byte.Parse(s, style, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Byte" />[] 型数值。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <returns>解析出的字符数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static byte[] ParseByteArray(this string s)
	{
		return s.HexDecode();
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Char" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	/// <remarks>本方法支持将"0x"、"&amp;h"、"\x"或者"\u"开头的十六进制数值解析为 <see cref="T:System.Char" /> 型数值。</remarks>
	public static char ParseChar(this string s)
	{
		s.GuardNotNull("s");
		s = RegexPatterns.HexCharPrefix.Replace(s, string.Empty);
		return char.Parse(s);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串表示的区域信息
	/// </summary>
	/// <param name="s">当前区域名称</param>
	/// <param name="alt">区域性名称</param>
	/// <returns>当前区域名称相应的区域性对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前区域名称为空。</exception>
	public static CultureInfo ParseCulture(this string s, string alt = null)
	{
		s.GuardNotNull("culture name");
		return alt.IsNull() ? CultureInfo.GetCultureInfo(s) : CultureInfo.GetCultureInfo(s, alt);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的日期。
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的日期</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static DateTime ParseDateTime(this string s, IFormatProvider provider = null)
	{
		s.GuardNotNull("s");
		return DateTime.Parse(s, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的日期。
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="style">日期字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的日期</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static DateTime ParseDateTime(this string s, DateTimeStyles style, IFormatProvider provider = null)
	{
		s.GuardNotNull("s");
		return DateTime.Parse(s, provider, style);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的日期。
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="format">分析时使用的日期格式说明符</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的日期</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者日期格式说明符 <paramref name="format" /> 为空。</exception>
	public static DateTime ParseDateTime(this string s, string format, IFormatProvider provider = null)
	{
		s.GuardNotNull("s");
		return DateTime.ParseExact(s, format, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的日期。
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="formats">分析时使用的日期格式说明符数组</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的日期</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者日期格式说明符 <paramref name="formats" /> 为空。</exception>
	public static DateTime ParseDateTime(this string s, string[] formats, IFormatProvider provider = null)
	{
		s.GuardNotNull("s");
		return DateTime.ParseExact(s, formats, provider, DateTimeStyles.None);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的日期。
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="format">分析时使用的日期格式说明符</param>
	/// <param name="style">日期字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的日期</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者日期格式说明符 <paramref name="format" /> 为空。</exception>
	public static DateTime ParseDateTime(this string s, string format, DateTimeStyles style, IFormatProvider provider = null)
	{
		s.GuardNotNull("s");
		return DateTime.ParseExact(s, format, provider, style);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的日期。
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="formats">分析时使用的日期格式说明符数组</param>
	/// <param name="style">日期字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的日期</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者日期格式说明符 <paramref name="formats" /> 为空。</exception>
	public static DateTime ParseDateTime(this string s, string[] formats, DateTimeStyles style, IFormatProvider provider = null)
	{
		s.GuardNotNull("s");
		return DateTime.ParseExact(s, formats, provider, style);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的日期。
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的日期</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static DateTimeOffset ParseDateTimeOffset(this string s, IFormatProvider provider = null)
	{
		s.GuardNotNull("s");
		return DateTimeOffset.Parse(s, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的日期。
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="style">日期字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的日期</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static DateTimeOffset ParseDateTimeOffset(this string s, DateTimeStyles style, IFormatProvider provider = null)
	{
		s.GuardNotNull("s");
		return DateTimeOffset.Parse(s, provider, style);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的日期。
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="format">分析时使用的日期格式说明符</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的日期</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者日期格式说明符 <paramref name="format" /> 为空。</exception>
	public static DateTimeOffset ParseDateTimeOffset(this string s, string format, IFormatProvider provider = null)
	{
		s.GuardNotNull("s");
		return DateTimeOffset.ParseExact(s, format, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的日期。
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="formats">分析时使用的日期格式说明符</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的日期</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者日期格式说明符 <paramref name="formats" /> 为空。</exception>
	public static DateTimeOffset ParseDateTimeOffset(this string s, string[] formats, IFormatProvider provider = null)
	{
		s.GuardNotNull("s");
		return DateTimeOffset.ParseExact(s, formats, provider, DateTimeStyles.None);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的日期。
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="format">分析时使用的日期格式说明符</param>
	/// <param name="style">日期字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的日期</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者日期格式说明符 <paramref name="format" /> 为空。</exception>
	public static DateTimeOffset ParseDateTimeOffset(this string s, string format, DateTimeStyles style, IFormatProvider provider = null)
	{
		s.GuardNotNull("s");
		return DateTimeOffset.ParseExact(s, format, provider, style);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的日期。
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="formats">分析时使用的日期格式说明符数组</param>
	/// <param name="style">日期字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的日期</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者日期格式说明符 <paramref name="formats" /> 为空。</exception>
	public static DateTimeOffset ParseDateTimeOffset(this string s, string[] formats, DateTimeStyles style, IFormatProvider provider = null)
	{
		s.GuardNotNull("s");
		return DateTimeOffset.ParseExact(s, formats, provider, style);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Decimal" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static decimal ParseDecimal(this string s, IFormatProvider provider = null)
	{
		s.GuardNotNull("s");
		return decimal.Parse(s, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Decimal" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static decimal ParseDecimal(this string s, NumberStyles style, IFormatProvider provider = null)
	{
		s.GuardNotNull("s");
		return decimal.Parse(s, style, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Double" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static double ParseDouble(this string s, IFormatProvider provider = null)
	{
		s.GuardNotNull("s");
		return double.Parse(s, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Double" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static double ParseDouble(this string s, NumberStyles style, IFormatProvider provider = null)
	{
		s.GuardNotNull("s");
		return double.Parse(s, style, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的枚举。
	/// </summary>
	/// <param name="s">当前枚举字符串</param>
	/// <param name="enumType">解析的枚举类型</param>
	/// <param name="ignoreCase">是否区分枚举名称的大小写</param>
	/// <returns>解析出的枚举</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者枚举类型 <paramref name="enumType" /> 为空。</exception>
	public static object ParseEnum(this string s, Type enumType, bool ignoreCase = false)
	{
		s.GuardNotNull("s");
		enumType.GuardNotNull("enum type");
		return Enum.Parse(enumType, s, ignoreCase);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的枚举。
	/// </summary>
	/// <typeparam name="T">解析的枚举类型</typeparam>
	/// <param name="s">当前枚举字符串</param>
	/// <param name="ignoreCase">是否区分枚举名称的大小写</param>
	/// <returns>解析出的枚举</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static T ParseEnum<T>(this string s, bool ignoreCase = false)
	{
		return (T)s.ParseEnum(typeof(T), ignoreCase);
	}

	/// <summary>
	/// 分析当前字符串所表示的数值；该数值应是用科学计数法表示的。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <returns>将字符串所表示的数值分解为4个部分：符号（1/-1)、整数部分数值、小数部分数值和指数部分数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前字符串不是可识别的科学计数法表达式</exception>
	public static int[] ParseExponential(this string s)
	{
		s.GuardNotNull("s");
		Match i = RegexPatterns.ExponentialNumber.Match(s);
		i.Guard(i.Success && i.Groups.Count == 6, "s");
		return new int[4]
		{
			(!(i.Groups[2].Value == "-")) ? 1 : (-1),
			(i.Groups[3].Value.Length != 0) ? i.Groups[3].Value.ParseInt32() : 0,
			(i.Groups[4].Value.Length != 0) ? i.Groups[4].Value.TrimEnd('0').ParseInt32() : 0,
			(i.Groups[5].Value.Length != 0) ? i.Groups[5].Value.ParseInt32() : 0
		};
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Single" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static float ParseFloat(this string s, IFormatProvider provider = null)
	{
		return s.ParseSingle(provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Single" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static float ParseFloat(this string s, NumberStyles style, IFormatProvider provider = null)
	{
		return s.ParseSingle(style, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Guid" /> 类型数值。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="format">Guid字符串的格式</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	/// <remarks>
	/// <paramref name="format" /> 指定待解析的Guid字符串的格式，包括：
	/// N:00000000000000000000000000000000
	/// D:00000000-0000-0000-0000-000000000000
	/// B:{00000000-0000-0000-0000-000000000000}
	/// P:(00000000-0000-0000-0000-000000000000)
	/// X:{0x00000000,0x0000,0x0000,{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00}}
	/// 如果设置为空，则自动检测Guid字符串格式。
	/// </remarks>
	public static Guid ParseGuid(this string s, string format = null)
	{
		s.GuardNotNull("s");
		return format.IsNull() ? Guid.Parse(s) : Guid.ParseExact(s, format);
	}

	/// <summary>
	/// 分析当前字符串，将字符串所表示的十六进制值转换为 <see cref="T:System.Int32" /> 类型数值
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static int ParseHex(this string s)
	{
		return s.ParseInt32(NumberStyles.HexNumber, CultureInfo.InvariantCulture);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Int32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static int ParseInt(this string s, IFormatProvider provider = null)
	{
		return s.ParseInt32(provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Int32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static int ParseInt(this string s, NumberStyles style, IFormatProvider provider = null)
	{
		return s.ParseInt32(style, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Int16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static short ParseInt16(this string s, IFormatProvider provider = null)
	{
		return s.ParseInt16(NumberStyles.Integer | NumberStyles.AllowHexSpecifier, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Int16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static short ParseInt16(this string s, NumberStyles style, IFormatProvider provider = null)
	{
		s.GuardNotNull("s");
		if (style.HasFlag(NumberStyles.AllowHexSpecifier))
		{
			s = RegexPatterns.HexNumberPrefix.Replace(s, string.Empty);
		}
		return short.Parse(s, style, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Int32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static int ParseInt32(this string s, IFormatProvider provider = null)
	{
		return s.ParseInt32(NumberStyles.Integer | NumberStyles.AllowHexSpecifier, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Int32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static int ParseInt32(this string s, NumberStyles style, IFormatProvider provider = null)
	{
		s.GuardNotNull("s");
		if (style.HasFlag(NumberStyles.AllowHexSpecifier))
		{
			s = RegexPatterns.HexNumberPrefix.Replace(s, string.Empty);
		}
		return int.Parse(s, style, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Int64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static long ParseInt64(this string s, IFormatProvider provider = null)
	{
		return s.ParseInt64(NumberStyles.Integer | NumberStyles.AllowHexSpecifier, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Int64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static long ParseInt64(this string s, NumberStyles style, IFormatProvider provider = null)
	{
		s.GuardNotNull("s");
		if (style.HasFlag(NumberStyles.AllowHexSpecifier))
		{
			s = RegexPatterns.HexNumberPrefix.Replace(s, string.Empty);
		}
		return long.Parse(s, style, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.IntPtr" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static IntPtr ParseIntPtr(this string s, IFormatProvider provider = null)
	{
		return s.ParseIntPtr(NumberStyles.Integer | NumberStyles.AllowHexSpecifier, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.IntPtr" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static IntPtr ParseIntPtr(this string s, NumberStyles style, IFormatProvider provider = null)
	{
		s.GuardNotNull("s");
		return IntPtr.Size switch
		{
			4 => (IntPtr)s.ParseInt32(style, provider), 
			8 => (IntPtr)s.ParseInt64(style, provider), 
			_ => throw new NotSupportedException(Literals.MSG_InvalidCast_2.FormatValue(s, typeof(IntPtr).FullName)), 
		};
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Int64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static long ParseLong(this string s, IFormatProvider provider = null)
	{
		return s.ParseInt64(provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Int64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static long ParseLong(this string s, NumberStyles style, IFormatProvider provider = null)
	{
		return s.ParseInt64(style, provider);
	}

	/// <summary>
	/// 分析当前字符串，将字符串所表示的十六进制值转换为 <see cref="T:System.Int64" /> 类型数值
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static long ParseLongHex(this string s)
	{
		return s.ParseInt64(NumberStyles.HexNumber, CultureInfo.InvariantCulture);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.SByte" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static sbyte ParseSByte(this string s, IFormatProvider provider = null)
	{
		return s.ParseSByte(NumberStyles.Integer | NumberStyles.AllowHexSpecifier, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.SByte" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static sbyte ParseSByte(this string s, NumberStyles style, IFormatProvider provider = null)
	{
		s.GuardNotNull("s");
		if (style.HasFlag(NumberStyles.AllowHexSpecifier))
		{
			s = RegexPatterns.HexNumberPrefix.Replace(s, string.Empty);
		}
		return sbyte.Parse(s, style, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Int16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static short ParseShort(this string s, IFormatProvider provider = null)
	{
		return s.ParseInt16(provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Int16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static short ParseShort(this string s, NumberStyles style, IFormatProvider provider = null)
	{
		return s.ParseInt16(style, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Single" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static float ParseSingle(this string s, IFormatProvider provider = null)
	{
		s.GuardNotNull("s");
		return float.Parse(s, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Single" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static float ParseSingle(this string s, NumberStyles style, IFormatProvider provider = null)
	{
		s.GuardNotNull("s");
		return float.Parse(s, style, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.TimeSpan" /> 类型数值。
	/// </summary>
	/// <param name="s">当前时间间隔字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的时间间隔</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static TimeSpan ParseTimeSpan(this string s, IFormatProvider provider = null)
	{
		s.GuardNotNull("s");
		return TimeSpan.Parse(s, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.TimeSpan" /> 类型数值。
	/// </summary>
	/// <param name="s">当前时间间隔字符串</param>
	/// <param name="style">时间间隔字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的时间间隔</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static TimeSpan ParseTimeSpan(this string s, TimeSpanStyles style, IFormatProvider provider = null)
	{
		s.GuardNotNull("s");
		return TimeSpan.ParseExact(s, "G", provider, style);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.TimeSpan" /> 类型数值。
	/// </summary>
	/// <param name="s">当前时间间隔字符串</param>
	/// <param name="format">分析时使用的时间间隔格式说明符</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的时间间隔</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者时间间隔格式说明符 <paramref name="format" /> 为空。</exception>
	public static TimeSpan ParseTimeSpan(this string s, string format, IFormatProvider provider = null)
	{
		s.GuardNotNull("s");
		return TimeSpan.ParseExact(s, format, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.TimeSpan" /> 类型数值。
	/// </summary>
	/// <param name="s">当前时间间隔字符串</param>
	/// <param name="formats">分析时使用的时间间隔格式说明符数组</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的时间间隔</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者时间间隔格式说明符 <paramref name="formats" /> 为空。</exception>
	public static TimeSpan ParseTimeSpan(this string s, string[] formats, IFormatProvider provider = null)
	{
		s.GuardNotNull("s");
		return TimeSpan.ParseExact(s, formats, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.TimeSpan" /> 类型数值。
	/// </summary>
	/// <param name="s">当前时间间隔字符串</param>
	/// <param name="format">分析时使用的时间间隔格式说明符</param>
	/// <param name="style">时间间隔字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的时间间隔</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者时间间隔格式说明符 <paramref name="format" /> 为空。</exception>
	public static TimeSpan ParseTimeSpan(this string s, string format, TimeSpanStyles style, IFormatProvider provider = null)
	{
		s.GuardNotNull("s");
		return TimeSpan.ParseExact(s, format, provider, style);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.TimeSpan" /> 类型数值。
	/// </summary>
	/// <param name="s">当前时间间隔字符串</param>
	/// <param name="formats">分析时使用的时间间隔格式说明符数组</param>
	/// <param name="style">时间间隔字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的时间间隔</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者时间间隔格式说明符 <paramref name="formats" /> 为空。</exception>
	public static TimeSpan ParseTimeSpan(this string s, string[] formats, TimeSpanStyles style, IFormatProvider provider = null)
	{
		s.GuardNotNull("s");
		return TimeSpan.ParseExact(s, formats, provider, style);
	}

	/// <summary>
	/// 分析当前字符串，将字符串所表示的十六进制值转换为 <see cref="T:System.UInt32" /> 类型数值
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static uint ParseUHex(this string s)
	{
		return s.ParseUInt32(NumberStyles.HexNumber, CultureInfo.InvariantCulture);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.UInt32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static uint ParseUInt(this string s, IFormatProvider provider = null)
	{
		return s.ParseUInt32(provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.UInt32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static uint ParseUInt(this string s, NumberStyles style, IFormatProvider provider = null)
	{
		return s.ParseUInt32(style, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.UInt16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static ushort ParseUInt16(this string s, IFormatProvider provider = null)
	{
		return s.ParseUInt16(NumberStyles.Integer | NumberStyles.AllowHexSpecifier, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.UInt16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static ushort ParseUInt16(this string s, NumberStyles style, IFormatProvider provider = null)
	{
		s.GuardNotNull("s");
		if (style.HasFlag(NumberStyles.AllowHexSpecifier))
		{
			s = RegexPatterns.HexNumberPrefix.Replace(s, string.Empty);
		}
		return ushort.Parse(s, style, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.UInt32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static uint ParseUInt32(this string s, IFormatProvider provider = null)
	{
		return s.ParseUInt32(NumberStyles.Integer | NumberStyles.AllowHexSpecifier, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.UInt32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static uint ParseUInt32(this string s, NumberStyles style, IFormatProvider provider = null)
	{
		s.GuardNotNull("s");
		if (style.HasFlag(NumberStyles.AllowHexSpecifier))
		{
			s = RegexPatterns.HexNumberPrefix.Replace(s, string.Empty);
		}
		return uint.Parse(s, style, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.UInt64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static ulong ParseUInt64(this string s, IFormatProvider provider = null)
	{
		return s.ParseUInt64(NumberStyles.Integer | NumberStyles.AllowHexSpecifier, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.UInt64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static ulong ParseUInt64(this string s, NumberStyles style, IFormatProvider provider = null)
	{
		s.GuardNotNull("s");
		if (style.HasFlag(NumberStyles.AllowHexSpecifier))
		{
			s = RegexPatterns.HexNumberPrefix.Replace(s, string.Empty);
		}
		return ulong.Parse(s, style, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.UIntPtr" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static UIntPtr ParseUIntPtr(this string s, IFormatProvider provider = null)
	{
		return s.ParseUIntPtr(NumberStyles.Integer | NumberStyles.AllowHexSpecifier, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.UIntPtr" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static UIntPtr ParseUIntPtr(this string s, NumberStyles style, IFormatProvider provider = null)
	{
		s.GuardNotNull("s");
		return UIntPtr.Size switch
		{
			4 => (UIntPtr)s.ParseUInt32(style, provider), 
			8 => (UIntPtr)s.ParseUInt64(style, provider), 
			_ => throw new NotSupportedException(Literals.MSG_InvalidCast_2.FormatValue(s, typeof(UIntPtr).FullName)), 
		};
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.UInt64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static ulong ParseULong(this string s, IFormatProvider provider = null)
	{
		return s.ParseUInt64(provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.UInt64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static ulong ParseULong(this string s, NumberStyles style, IFormatProvider provider = null)
	{
		return s.ParseUInt64(style, provider);
	}

	/// <summary>
	/// 分析当前字符串，将字符串所表示的十六进制值转换为 <see cref="T:System.UInt64" /> 类型数值
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static ulong ParseULongHex(this string s)
	{
		return s.ParseUInt64(NumberStyles.HexNumber, CultureInfo.InvariantCulture);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.UInt16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static ushort ParseUShort(this string s, IFormatProvider provider = null)
	{
		return s.ParseUInt16(provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.UInt16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static ushort ParseUShort(this string s, NumberStyles style, IFormatProvider provider = null)
	{
		return s.ParseUInt16(style, provider);
	}

	/// <summary>
	/// 转义当前字符串中所有的正则特殊字符
	/// </summary>
	/// <param name="pattern">当前字符串</param>
	/// <returns>处理后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static string RegexEscape(this string pattern)
	{
		pattern.GuardNotNull("pattern");
		return Regex.Escape(pattern);
	}

	/// <summary>
	/// 取消转义当前字符串中所有的正则特殊字符。
	/// </summary>
	/// <param name="pattern">当前字符串</param>
	/// <returns>处理后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static string RegexUnescape(this string pattern)
	{
		pattern.GuardNotNull("s");
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
	public static string Remove(this string text, string target, bool ignoreCase = false)
	{
		return text.Replace(target, null, -1, ignoreCase);
	}

	/// <summary>
	/// 在当前文本内移除出现指定次数以内的目标文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标文本</param>
	/// <param name="comparison">字符串比较方式</param>
	/// <returns>移除后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者移除的目标字符串 <paramref name="target" /> 为空。</exception>
	public static string Remove(this string text, string target, StringComparison comparison)
	{
		return text.Replace(target, null, -1, comparison);
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
	public static string Remove(this string text, string target, CultureInfo culture, bool ignoreCase = false)
	{
		return text.Replace(target, null, -1, culture, ignoreCase);
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
	public static string Remove(this string text, string target, CultureInfo culture, CompareOptions options)
	{
		return text.Replace(target, null, -1, culture, options);
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
	public static string Remove(this string text, string target, int times, bool ignoreCase = false)
	{
		return text.Replace(target, null, times, ignoreCase);
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
	public static string Remove(this string text, string target, int times, StringComparison comparison)
	{
		return text.Replace(target, null, times, comparison);
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
	public static string Remove(this string text, string target, int times, CultureInfo culture, bool ignoreCase = false)
	{
		return text.Replace(target, null, times, culture, ignoreCase);
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
	public static string Remove(this string text, string target, int times, CultureInfo culture, CompareOptions options)
	{
		return text.Replace(target, null, times, culture, options);
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
	public static string Remove(this string text, string target, int start, int count, int times, bool ignoreCase = false)
	{
		return text.Replace(target, null, start, count, times, ignoreCase);
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
	public static string Remove(this string text, string target, int start, int count, int times, StringComparison comparison)
	{
		return text.Replace(target, null, start, count, times, comparison);
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
	public static string Remove(this string text, string target, int start, int count, int times, CultureInfo culture, bool ignoreCase = false)
	{
		return text.Replace(target, null, start, count, times, culture, ignoreCase);
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
	public static string Remove(this string text, string target, int start, int count, int times, CultureInfo culture, CompareOptions options)
	{
		return text.Replace(target, null, start, count, times, culture, options);
	}

	/// <summary>
	/// 在当前文本内逆向移除出现的目标文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标文本</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>移除后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者移除的目标字符串 <paramref name="target" /> 为空。</exception>
	public static string RemoveLast(this string text, string target, bool ignoreCase = false)
	{
		return text.ReplaceLast(target, null, -1, ignoreCase);
	}

	/// <summary>
	/// 在当前文本内逆向移除出现的目标文本
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标文本</param>
	/// <param name="comparison">字符串比较方式</param>
	/// <returns>移除后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者移除的目标字符串 <paramref name="target" /> 为空。</exception>
	public static string RemoveLast(this string text, string target, StringComparison comparison)
	{
		return text.ReplaceLast(target, null, -1, comparison);
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
	public static string RemoveLast(this string text, string target, CultureInfo culture, bool ignoreCase = false)
	{
		return text.ReplaceLast(target, null, -1, culture, ignoreCase);
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
	public static string RemoveLast(this string text, string target, CultureInfo culture, CompareOptions options)
	{
		return text.ReplaceLast(target, null, -1, culture, options);
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
	public static string RemoveLast(this string text, string target, int times, bool ignoreCase = false)
	{
		return text.ReplaceLast(target, null, times, ignoreCase);
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
	public static string RemoveLast(this string text, string target, int times, StringComparison comparison)
	{
		return text.ReplaceLast(target, null, times, comparison);
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
	public static string RemoveLast(this string text, string target, int times, CultureInfo culture, bool ignoreCase = false)
	{
		return text.ReplaceLast(target, null, times, culture, ignoreCase);
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
	public static string RemoveLast(this string text, string target, int times, CultureInfo culture, CompareOptions options)
	{
		return text.ReplaceLast(target, null, times, culture, options);
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
	public static string RemoveLast(this string text, string target, int start, int count, int times, bool ignoreCase = false)
	{
		return text.ReplaceLast(target, null, start, count, times, ignoreCase);
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
	public static string RemoveLast(this string text, string target, int start, int count, int times, StringComparison comparison)
	{
		return text.ReplaceLast(target, null, start, count, times, comparison);
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
	public static string RemoveLast(this string text, string target, int start, int count, int times, CultureInfo culture, bool ignoreCase = false)
	{
		return text.ReplaceLast(target, null, start, count, times, culture, ignoreCase);
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
	public static string RemoveLast(this string text, string target, int start, int count, int times, CultureInfo culture, CompareOptions options)
	{
		return text.ReplaceLast(target, null, start, count, times, culture, options);
	}

	/// <summary>
	/// 移除当前文本区域中的目标字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="target">移除的目标字符</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static string RemoveChar(this string text, char target, bool ignoreCase = false)
	{
		return text.RemoveChar(target, -1, ignoreCase);
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
	public static string RemoveChar(this string text, char target, CultureInfo culture, bool ignoreCase = false)
	{
		return text.RemoveChar(target, -1, culture, ignoreCase);
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
	public static string RemoveChar(this string text, char target, CultureInfo culture, CompareOptions options)
	{
		return text.RemoveChar(target, -1, culture, options);
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
	public static string RemoveChar(this string text, char target, int times, bool ignoreCase = false)
	{
		text.GuardNotNull("text");
		return text.RemoveChar(target, 0, text.Length, times, ignoreCase);
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
	public static string RemoveChar(this string text, char target, int times, CultureInfo culture, bool ignoreCase = false)
	{
		text.GuardNotNull("text");
		return text.RemoveChar(target, 0, text.Length, times, culture, ignoreCase);
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
	public static string RemoveChar(this string text, char target, int times, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		return text.RemoveChar(target, 0, text.Length, times, culture, options);
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
	public static string RemoveChar(this string text, char target, int start, int count, int times, bool ignoreCase = false)
	{
		return text.RemoveChar(new char[1] { target }, start, count, times, CultureInfo.CurrentCulture, ignoreCase);
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
	public static string RemoveChar(this string text, char target, int start, int count, int times, CultureInfo culture, bool ignoreCase = false)
	{
		return text.RemoveChar(new char[1] { target }, start, count, times, culture, ignoreCase);
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
	public static string RemoveChar(this string text, char target, int start, int count, int times, CultureInfo culture, CompareOptions options)
	{
		return text.RemoveChar(new char[1] { target }, start, count, times, culture, options);
	}

	/// <summary>
	/// 移除当前文本区域中的目标字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="targets">移除的目标字符数组</param>
	/// <param name="ignoreCase">字符比较是否区分大小写</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；移除的目标字符数组 <paramref name="targets" /> 为空。</exception>
	public static string RemoveChar(this string text, char[] targets, bool ignoreCase = false)
	{
		return text.RemoveChar(targets, -1, ignoreCase);
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
	public static string RemoveChar(this string text, char[] targets, CultureInfo culture, bool ignoreCase = false)
	{
		return text.RemoveChar(targets, -1, culture, ignoreCase);
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
	public static string RemoveChar(this string text, char[] targets, CultureInfo culture, CompareOptions options)
	{
		return text.RemoveChar(targets, -1, culture, options);
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
	public static string RemoveChar(this string text, char[] targets, int times, bool ignoreCase = false)
	{
		text.GuardNotNull("text");
		return text.RemoveChar(targets, 0, text.Length, times, ignoreCase);
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
	public static string RemoveChar(this string text, char[] targets, int times, CultureInfo culture, bool ignoreCase = false)
	{
		text.GuardNotNull("text");
		return text.RemoveChar(targets, 0, text.Length, times, culture, ignoreCase);
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
	public static string RemoveChar(this string text, char[] targets, int times, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		return text.RemoveChar(targets, 0, text.Length, times, culture, options);
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
	public static string RemoveChar(this string text, char[] targets, int start, int count, int times, bool ignoreCase = false)
	{
		return text.RemoveChar(targets, start, count, times, CultureInfo.CurrentCulture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static string RemoveChar(this string text, char[] targets, int start, int count, int times, CultureInfo culture, bool ignoreCase = false)
	{
		return text.RemoveChar(targets, start, count, times, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static string RemoveChar(this string text, char[] targets, int start, int count, int times, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		targets.GuardNotNull("targets");
		return text.RemoveChar((char x, int i) => targets.Any((char c) => x.IsEqualTo(c, culture, options)), start, count, times);
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
	public static string RemoveChar(this string text, Func<char, bool> predicate, int times = -1)
	{
		text.GuardNotNull("text");
		predicate.GuardNotNull("predicate");
		return text.RemoveChar((char x, int i) => predicate(x), 0, text.Length, times);
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
	public static string RemoveChar(this string text, Func<char, bool> predicate, int start, int count, int times = -1)
	{
		predicate.GuardNotNull("predicate");
		return text.RemoveChar((char x, int i) => predicate(x), start, count, times);
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
	public static string RemoveChar(this string text, Func<char, int, bool> predicate, int times = -1)
	{
		text.GuardNotNull("text");
		predicate.GuardNotNull("predicate");
		return text.RemoveChar(predicate, 0, text.Length, times);
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
	public static string RemoveChar(this string text, Func<char, int, bool> predicate, int start, int count, int times = -1)
	{
		text.GuardNotNull("text");
		predicate.GuardNotNull("predicate");
		start.GuardIndexRange(0, text.Length - 1, "start");
		count.GuardBetween(0, text.Length - start, "count");
		times.GuardGreaterThanOrEqualTo(-1, "times");
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
	public static string RemoveLastChar(this string text, char target, bool ignoreCase = false)
	{
		return text.RemoveLastChar(new char[1] { target }, -1, CultureInfo.CurrentCulture, ignoreCase);
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
	public static string RemoveLastChar(this string text, char target, CultureInfo culture, bool ignoreCase = false)
	{
		return text.RemoveLastChar(new char[1] { target }, -1, culture, ignoreCase);
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
	public static string RemoveLastChar(this string text, char target, CultureInfo culture, CompareOptions options)
	{
		return text.RemoveLastChar(new char[1] { target }, -1, culture, options);
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
	public static string RemoveLastChar(this string text, char target, int times, bool ignoreCase = false)
	{
		return text.RemoveLastChar(new char[1] { target }, times, CultureInfo.CurrentCulture, ignoreCase);
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
	public static string RemoveLastChar(this string text, char target, int times, CultureInfo culture, bool ignoreCase = false)
	{
		return text.RemoveLastChar(new char[1] { target }, times, culture, ignoreCase);
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
	public static string RemoveLastChar(this string text, char target, int times, CultureInfo culture, CompareOptions options)
	{
		return text.RemoveLastChar(new char[1] { target }, times, culture, options);
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
	public static string RemoveLastChar(this string text, char target, int start, int count, int times, bool ignoreCase = false)
	{
		return text.RemoveLastChar(new char[1] { target }, start, count, times, CultureInfo.CurrentCulture, ignoreCase);
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
	public static string RemoveLastChar(this string text, char target, int start, int count, int times, CultureInfo culture, bool ignoreCase = false)
	{
		return text.RemoveLastChar(new char[1] { target }, start, count, times, culture, ignoreCase);
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
	public static string RemoveLastChar(this string text, char target, int start, int count, int times, CultureInfo culture, CompareOptions options)
	{
		return text.RemoveLastChar(new char[1] { target }, start, count, times, culture, options);
	}

	/// <summary>
	/// 逆向移除当前文本中的目标字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="targets">移除的目标字符数组</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；移除的目标字符数组 <paramref name="targets" /> 为空。</exception>
	public static string RemoveLastChar(this string text, char[] targets, bool ignoreCase = false)
	{
		return text.RemoveLastChar(targets, CultureInfo.CurrentCulture, ignoreCase);
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
	public static string RemoveLastChar(this string text, char[] targets, CultureInfo culture, bool ignoreCase = false)
	{
		return text.RemoveLastChar(targets, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static string RemoveLastChar(this string text, char[] targets, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		targets.GuardNotNull("targets");
		return text.RemoveLastChar((char x, int i) => targets.Any((char c) => x.IsEqualTo(c, culture, options)), 0, text.Length);
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
	public static string RemoveLastChar(this string text, char[] targets, int times, bool ignoreCase = false)
	{
		return text.RemoveLastChar(targets, times, CultureInfo.CurrentCulture, ignoreCase);
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
	public static string RemoveLastChar(this string text, char[] targets, int times, CultureInfo culture, bool ignoreCase = false)
	{
		return text.RemoveLastChar(targets, times, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static string RemoveLastChar(this string text, char[] targets, int times, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		targets.GuardNotNull("targets");
		return text.RemoveLastChar((char x, int i) => targets.Any((char c) => x.IsEqualTo(c, culture, options)), 0, text.Length, times);
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
	public static string RemoveLastChar(this string text, char[] targets, int start, int count, int times, bool ignoreCase = false)
	{
		return text.RemoveLastChar(targets, start, count, times, CultureInfo.CurrentCulture, ignoreCase);
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
	public static string RemoveLastChar(this string text, char[] targets, int start, int count, int times, CultureInfo culture, bool ignoreCase = false)
	{
		return text.RemoveLastChar(targets, start, count, times, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static string RemoveLastChar(this string text, char[] targets, int start, int count, int times, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		targets.GuardNotNull("targets");
		return text.RemoveLastChar((char x, int i) => targets.Any((char c) => x.IsEqualTo(c, culture, options)), start, count, times);
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
	public static string RemoveLastChar(this string text, Func<char, bool> predicate, int times = -1)
	{
		text.GuardNotNull("text");
		predicate.GuardNotNull("predicate");
		return text.RemoveLastChar((char x, int i) => predicate(x), text.Length - 1, text.Length, times);
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
	public static string RemoveLastChar(this string text, Func<char, bool> predicate, int start, int count, int times = -1)
	{
		predicate.GuardNotNull("predicate");
		return text.RemoveLastChar((char x, int i) => predicate(x), start, count, times);
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
	public static string RemoveLastChar(this string text, Func<char, int, bool> predicate, int times = -1)
	{
		text.GuardNotNull("text");
		predicate.GuardNotNull("predicate");
		return text.RemoveLastChar(predicate, text.Length - 1, text.Length, times);
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
	public static string RemoveLastChar(this string text, Func<char, int, bool> predicate, int start, int count, int times = -1)
	{
		text.GuardNotNull("text");
		predicate.GuardNotNull("predicate");
		start.GuardIndexRange(0, text.Length - 1, "start");
		count.GuardBetween(0, start + 1, "count");
		times.GuardGreaterThanOrEqualTo(-1, "times");
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
	public static string RemoveHtmlTags(this string html)
	{
		html.GuardNotNull("html");
		return RegexPatterns.HtmlTag.Remove(html);
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
	public static string RemoveRegex(this string text, Regex pattern, int times = -1)
	{
		return pattern.Remove(text, times);
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
	public static string RemoveRegex(this string text, Regex pattern, int start, int count, int times = -1)
	{
		return pattern.Remove(text, start, count, times);
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
	public static string RemoveLastRegex(this string text, Regex pattern, int times = -1)
	{
		return pattern.RemoveLast(text, times);
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
	public static string RemoveLastRegex(this string text, Regex pattern, int start, int count, int times = -1)
	{
		return pattern.RemoveLast(text, start, count, times);
	}

	/// <summary>
	/// 移除当前文本中指定数量的空白字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <returns>移除所有空白的字符</returns>
	/// <param name="times">空白字符匹配的次数（移除的数量）</param>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">执行匹配替换的次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveWhiteSpace(this string text, int times = -1)
	{
		return RegexPatterns.WhiteSpaceMore.Remove(text, times);
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
	public static string RemoveWhiteSpace(this string text, int start, int count, int times = -1)
	{
		return RegexPatterns.WhiteSpaceMore.Remove(text, start, count, times);
	}

	/// <summary>
	/// 逆向移除当前文本中指定数量的空白字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <returns>移除所有空白的字符</returns>
	/// <param name="times">空白字符匹配的次数（移除的数量）</param>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">执行匹配替换的次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string RemoveLastWhiteSpace(this string text, int times = -1)
	{
		return RegexPatterns.WhiteSpaceMore.RemoveLast(text, times);
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
	public static string RemoveLastWhiteSpace(this string text, int start, int count, int times = -1)
	{
		return RegexPatterns.WhiteSpaceMore.RemoveLast(text, start, count, times);
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
	public static string Replace(this string text, string target, string replacement, bool ignoreCase = false)
	{
		return text.Replace(target, replacement, -1, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
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
	public static string Replace(this string text, string target, string replacement, StringComparison comparison)
	{
		text.GuardNotNull("text");
		return text.Replace(target, replacement, 0, text.Length, -1, comparison);
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
	public static string Replace(this string text, string target, string replacement, CultureInfo culture, bool ignoreCase = false)
	{
		return text.Replace(target, replacement, -1, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static string Replace(this string text, string target, string replacement, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		return text.Replace(target, replacement, 0, text.Length, -1, culture, options);
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
	public static string Replace(this string text, string target, string replacement, int times, bool ignoreCase = false)
	{
		return text.Replace(target, replacement, times, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
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
	public static string Replace(this string text, string target, string replacement, int times, StringComparison comparison)
	{
		text.GuardNotNull("text");
		return text.Replace(target, replacement, 0, text.Length, times, comparison);
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
	public static string Replace(this string text, string target, string replacement, int times, CultureInfo culture, bool ignoreCase = false)
	{
		return text.Replace(target, replacement, times, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static string Replace(this string text, string target, string replacement, int times, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		return text.Replace(target, replacement, 0, text.Length, times, culture, options);
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
	public static string Replace(this string text, string target, string replacement, int start, int count, int times, bool ignoreCase = false)
	{
		return text.Replace(target, replacement, start, count, times, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
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
	public static string Replace(this string text, string target, string replacement, int start, int count, int times, StringComparison comparison)
	{
		text.GuardNotNull("text");
		target.GuardNotNull("target");
		start.GuardIndexRange(0, text.Length - 1, "start");
		count.GuardBetween(0, text.Length - start, "count");
		times.GuardGreaterThanOrEqualTo(-1, "times");
		replacement = replacement.IfNull(string.Empty);
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
	public static string Replace(this string text, string target, string replacement, int start, int count, int times, CultureInfo culture, bool ignoreCase = false)
	{
		return text.Replace(target, replacement, start, count, times, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static string Replace(this string text, string target, string replacement, int start, int count, int times, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		target.GuardNotNull("target");
		start.GuardIndexRange(0, text.Length - 1, "start");
		count.GuardBetween(0, text.Length - start, "count");
		times.GuardGreaterThanOrEqualTo(-1, "times");
		replacement = replacement.IfNull(string.Empty);
		StringBuilder buff = new StringBuilder();
		buff.Append(text.Substring(0, start));
		int end = start + count;
		int matched = 0;
		int index = start;
		while (start < end && (index = text.IndexOf(target, start, end - start, culture, options)) >= 0 && (times == -1 || ++matched <= times))
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
	public static string ReplaceLast(this string text, string target, string replacement, bool ignoreCase = false)
	{
		return text.ReplaceLast(target, replacement, -1, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
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
	public static string ReplaceLast(this string text, string target, string replacement, StringComparison comparison)
	{
		text.GuardNotNull("text");
		return text.ReplaceLast(target, replacement, 0, text.Length, -1, comparison);
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
	public static string ReplaceLast(this string text, string target, string replacement, CultureInfo culture, bool ignoreCase = false)
	{
		return text.ReplaceLast(target, replacement, -1, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static string ReplaceLast(this string text, string target, string replacement, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		return text.ReplaceLast(target, replacement, 0, text.Length, -1, culture, options);
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
	public static string ReplaceLast(this string text, string target, string replacement, int times, bool ignoreCase = false)
	{
		return text.ReplaceLast(target, replacement, times, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
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
	public static string ReplaceLast(this string text, string target, string replacement, int times, StringComparison comparison)
	{
		text.GuardNotNull("text");
		return text.ReplaceLast(target, replacement, 0, text.Length, times, comparison);
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
	public static string ReplaceLast(this string text, string target, string replacement, int times, CultureInfo culture, bool ignoreCase = false)
	{
		return text.ReplaceLast(target, replacement, times, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static string ReplaceLast(this string text, string target, string replacement, int times, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		return text.ReplaceLast(target, replacement, 0, text.Length, times, culture, options);
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
	public static string ReplaceLast(this string text, string target, string replacement, int start, int count, int times, bool ignoreCase = false)
	{
		return text.ReplaceLast(target, replacement, start, count, times, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
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
	public static string ReplaceLast(this string text, string target, string replacement, int start, int count, int times, StringComparison comparison)
	{
		text.GuardNotNull("text");
		target.GuardNotNull("target");
		start.GuardIndexRange(0, text.Length - 1, "start");
		count.GuardBetween(0, start + 1, "count");
		times.GuardGreaterThanOrEqualTo(-1, "times");
		replacement = replacement.IfNull(string.Empty);
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
	public static string ReplaceLast(this string text, string target, string replacement, int start, int count, int times, CultureInfo culture, bool ignoreCase = false)
	{
		return text.ReplaceLast(target, replacement, start, count, times, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static string ReplaceLast(this string text, string target, string replacement, int start, int count, int times, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		target.GuardNotNull("target");
		start.GuardIndexRange(0, text.Length - 1, "start");
		count.GuardBetween(0, start + 1, "count");
		times.GuardGreaterThanOrEqualTo(-1, "times");
		replacement = replacement.IfNull(string.Empty);
		StringBuilder buff = new StringBuilder();
		int end = start - count;
		if (end >= 0)
		{
			buff.Append(text.Substring(0, end + 1));
		}
		List<string> list = new List<string>();
		int matched = 0;
		int index = 0;
		while (start > end && (index = text.LastIndexOf(target, start, start - end, culture, options)) >= 0 && (times == -1 || ++matched <= times))
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
	public static string ReplaceChar(this string text, char target, char replacement, bool ignoreCase = false)
	{
		return text.ReplaceChar(target, replacement, -1, ignoreCase);
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
	public static string ReplaceChar(this string text, char target, char replacement, CultureInfo culture, bool ignoreCase = false)
	{
		return text.ReplaceChar(target, replacement, -1, culture, ignoreCase);
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
	public static string ReplaceChar(this string text, char target, char replacement, CultureInfo culture, CompareOptions options)
	{
		return text.ReplaceChar(target, replacement, -1, culture, options);
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
	public static string ReplaceChar(this string text, char target, char replacement, int times, bool ignoreCase = false)
	{
		text.GuardNotNull("text");
		return text.ReplaceChar(target, replacement, 0, text.Length, times, ignoreCase);
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
	public static string ReplaceChar(this string text, char target, char replacement, int times, CultureInfo culture, bool ignoreCase = false)
	{
		text.GuardNotNull("text");
		return text.ReplaceChar(target, replacement, 0, text.Length, times, culture, ignoreCase);
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
	public static string ReplaceChar(this string text, char target, char replacement, int times, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		return text.ReplaceChar(target, replacement, 0, text.Length, times, culture, options);
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
	public static string ReplaceChar(this string text, char target, char replacement, int start, int count, int times, bool ignoreCase = false)
	{
		text.GuardNotNull("text");
		return text.ReplaceChar((char c, int i) => c.IsEqualTo(target, CultureInfo.CurrentCulture, ignoreCase), (char c, int i) => replacement, start, count, times);
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
	public static string ReplaceChar(this string text, char target, char replacement, int start, int count, int times, CultureInfo culture, bool ignoreCase = false)
	{
		text.GuardNotNull("text");
		return text.ReplaceChar((char c, int i) => c.IsEqualTo(target, culture, ignoreCase), (char c, int i) => replacement, start, count, times);
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
	public static string ReplaceChar(this string text, char target, char replacement, int start, int count, int times, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		return text.ReplaceChar((char c, int i) => c.IsEqualTo(target, culture, options), (char c, int i) => replacement, start, count, times);
	}

	/// <summary>
	/// 替换当前文本的替换区域中满足条件的字符替换为计算表达式的值
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="predicate">字符筛选条件</param>
	/// <param name="evaluator">字符生成方法</param>
	/// <param name="times">移除字符的次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者字符筛选条件 <paramref name="predicate" /> 为空；或者字符生成方法 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceChar(this string text, Func<char, bool> predicate, Func<char, char> evaluator, int times = -1)
	{
		text.GuardNotNull("text");
		predicate.GuardNotNull("predicate");
		evaluator.GuardNotNull("evaluator");
		return text.ReplaceChar((char x, int i) => predicate(x), (char x, int i) => evaluator(x), 0, text.Length, times);
	}

	/// <summary>
	/// 替换当前文本的替换区域中满足条件的字符替换为计算表达式的值
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="predicate">字符筛选条件</param>
	/// <param name="evaluator">字符生成方法</param>
	/// <param name="start">区域的起始位置</param>
	/// <param name="count">区域中的字符数量</param>
	/// <param name="times">移除字符的次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者字符筛选条件 <paramref name="predicate" /> 为空；或者字符生成方法 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始剩余的字符数量；移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceChar(this string text, Func<char, bool> predicate, Func<char, char> evaluator, int start, int count, int times = -1)
	{
		predicate.GuardNotNull("predicate");
		evaluator.GuardNotNull("evaluator");
		return text.ReplaceChar((char x, int i) => predicate(x), (char x, int i) => evaluator(x), start, count, times);
	}

	/// <summary>
	/// 替换当前文本的替换区域中满足条件的字符替换为计算表达式的值
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="predicate">字符筛选条件</param>
	/// <param name="evaluator">字符生成方法</param>
	/// <param name="times">移除字符的次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者字符筛选条件 <paramref name="predicate" /> 为空；或者字符生成方法 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceChar(this string text, Func<char, int, bool> predicate, Func<char, int, char> evaluator, int times = -1)
	{
		text.GuardNotNull("text");
		return text.ReplaceChar(predicate, evaluator, 0, text.Length, times);
	}

	/// <summary>
	/// 替换当前文本的替换区域中满足条件的字符替换为计算表达式的值
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="predicate">字符筛选条件</param>
	/// <param name="evaluator">字符生成方法</param>
	/// <param name="start">区域的起始位置</param>
	/// <param name="count">区域中的字符数量</param>
	/// <param name="times">移除字符的次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者字符筛选条件 <paramref name="predicate" /> 为空；或者字符生成方法 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始剩余的字符数量；移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceChar(this string text, Func<char, int, bool> predicate, Func<char, int, char> evaluator, int start, int count, int times = -1)
	{
		text.GuardNotNull("text");
		predicate.GuardNotNull("predicate");
		evaluator.GuardNotNull("evaluator");
		start.GuardIndexRange(0, text.Length - 1, "start");
		count.GuardBetween(0, text.Length - start, "count");
		times.GuardGreaterThanOrEqualTo(-1, "times");
		StringBuilder buff = new StringBuilder(text.Length);
		buff.Append(text.Substring(0, start));
		int end = start + count;
		int matched = 0;
		for (int i = start; i < end; i++)
		{
			if (predicate(text[i], i) && (times == -1 || ++matched <= times))
			{
				buff.Append(evaluator(text[i], i));
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
	public static string ReplaceLastChar(this string text, char target, char replacement, bool ignoreCase = false)
	{
		return text.ReplaceLastChar(target, replacement, -1, ignoreCase);
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
	public static string ReplaceLastChar(this string text, char target, char replacement, CultureInfo culture, bool ignoreCase = false)
	{
		return text.ReplaceLastChar(target, replacement, -1, culture, ignoreCase);
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
	public static string ReplaceLastChar(this string text, char target, char replacement, CultureInfo culture, CompareOptions options)
	{
		return text.ReplaceLastChar(target, replacement, -1, culture, options);
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
	public static string ReplaceLastChar(this string text, char target, char replacement, int times, bool ignoreCase = false)
	{
		text.GuardNotNull("text");
		return text.ReplaceLastChar(target, replacement, 0, text.Length, times, ignoreCase);
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
	public static string ReplaceLastChar(this string text, char target, char replacement, int times, CultureInfo culture, bool ignoreCase = false)
	{
		text.GuardNotNull("text");
		return text.ReplaceLastChar(target, replacement, 0, text.Length, times, culture, ignoreCase);
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
	public static string ReplaceLastChar(this string text, char target, char replacement, int times, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		return text.ReplaceLastChar(target, replacement, 0, text.Length, times, culture, options);
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
	public static string ReplaceLastChar(this string text, char target, char replacement, int start, int count, int times, bool ignoreCase = false)
	{
		text.GuardNotNull("text");
		return text.ReplaceLastChar((char c, int i) => c.IsEqualTo(replacement, CultureInfo.CurrentCulture, ignoreCase), (char c, int i) => replacement, start, count, times);
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
	public static string ReplaceLastChar(this string text, char target, char replacement, int start, int count, int times, CultureInfo culture, bool ignoreCase = false)
	{
		text.GuardNotNull("text");
		return text.ReplaceLastChar((char c, int i) => c.IsEqualTo(replacement, culture, ignoreCase), (char c, int i) => replacement, start, count, times);
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
	public static string ReplaceLastChar(this string text, char target, char replacement, int start, int count, int times, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		return text.ReplaceLastChar((char c, int i) => c.IsEqualTo(replacement, culture, options), (char c, int i) => replacement, start, count, times);
	}

	/// <summary>
	/// 逆向替换当前文本的替换区域中满足条件的字符替换为计算表达式的值
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="predicate">字符筛选条件</param>
	/// <param name="evaluator">字符生成方法</param>
	/// <param name="times">移除字符的次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者字符筛选条件 <paramref name="predicate" /> 为空；或者字符生成方法 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceLastChar(this string text, Func<char, bool> predicate, Func<char, char> evaluator, int times = -1)
	{
		text.GuardNotNull("text");
		predicate.GuardNotNull("predicate");
		evaluator.GuardNotNull("evaluator");
		return text.ReplaceLastChar((char x, int i) => predicate(x), (char x, int i) => evaluator(x), text.Length - 1, text.Length, times);
	}

	/// <summary>
	/// 逆向替换当前文本的替换区域中满足条件的字符替换为计算表达式的值
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="predicate">字符筛选条件</param>
	/// <param name="evaluator">字符生成方法</param>
	/// <param name="start">区域的起始位置</param>
	/// <param name="count">区域中的字符数量</param>
	/// <param name="times">移除字符的次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者字符筛选条件 <paramref name="predicate" /> 为空；或者字符生成方法 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始剩余的字符数量；移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceLastChar(this string text, Func<char, bool> predicate, Func<char, char> evaluator, int start, int count, int times = -1)
	{
		predicate.GuardNotNull("predicate");
		evaluator.GuardNotNull("evaluator");
		return text.ReplaceLastChar((char x, int i) => predicate(x), (char x, int i) => evaluator(x), start, count, times);
	}

	/// <summary>
	/// 逆向替换当前文本的替换区域中满足条件的字符替换为计算表达式的值
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="predicate">字符筛选条件</param>
	/// <param name="evaluator">字符生成方法</param>
	/// <param name="times">移除字符的次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者字符筛选条件 <paramref name="predicate" /> 为空；或者字符生成方法 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceLastChar(this string text, Func<char, int, bool> predicate, Func<char, int, char> evaluator, int times = -1)
	{
		text.GuardNotNull("text");
		return text.ReplaceLastChar(predicate, evaluator, text.Length - 1, text.Length, times);
	}

	/// <summary>
	/// 逆向替换当前文本的替换区域中满足条件的字符替换为计算表达式的值
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="predicate">字符筛选条件</param>
	/// <param name="evaluator">字符生成方法</param>
	/// <param name="start">区域的起始位置</param>
	/// <param name="count">区域中的字符数量</param>
	/// <param name="times">移除字符的次数</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者字符筛选条件 <paramref name="predicate" /> 为空；或者字符生成方法 <paramref name="evaluator" /> 为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">区域起始位置 <paramref name="start" /> 小于0，或者大于当前文本字符的最大索引。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">区域内字符的数量 <paramref name="count" /> 小于0，或者大于当前文本从区域起始位置开始剩余的字符数量；移除次数 <paramref name="times" /> 小于0且不等于-1。</exception>
	public static string ReplaceLastChar(this string text, Func<char, int, bool> predicate, Func<char, int, char> evaluator, int start, int count, int times = -1)
	{
		text.GuardNotNull("text");
		predicate.GuardNotNull("predicate");
		evaluator.GuardNotNull("evaluator");
		start.GuardIndexRange(0, text.Length - 1, "start");
		count.GuardBetween(0, start + 1, "count");
		times.GuardGreaterThanOrEqualTo(-1, "times");
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
				chars.Add(evaluator(text[i], i));
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
	public static string ReplaceRegex(this string text, string pattern, string replacement, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return pattern.ToRegex(options.EnsureLeftToRightOption()).ReplaceText(text, replacement);
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
	public static string ReplaceRegex(this string text, string pattern, string replacement, int times, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return pattern.ToRegex(options.EnsureLeftToRightOption()).ReplaceText(text, replacement, times);
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
	public static string ReplaceRegex(this string text, string pattern, string replacement, int start, int count, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return pattern.ToRegex(options.EnsureLeftToRightOption()).ReplaceText(text, replacement, start, count);
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
	public static string ReplaceRegex(this string text, string pattern, string replacement, int start, int count, int times, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return pattern.ToRegex(options.EnsureLeftToRightOption()).ReplaceText(text, replacement, start, count, times);
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
	public static string ReplaceRegex(this string text, string pattern, Func<Match, string> evaluation, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return pattern.ToRegex(options.EnsureLeftToRightOption()).ReplaceText(text, evaluation);
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
	public static string ReplaceRegex(this string text, string pattern, Func<Match, string> evaluation, int times, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return pattern.ToRegex(options.EnsureLeftToRightOption()).ReplaceText(text, evaluation, times);
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
	public static string ReplaceRegex(this string text, string pattern, Func<Match, string> evaluation, int start, int count, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return pattern.ToRegex(options.EnsureLeftToRightOption()).ReplaceText(text, evaluation, start, count);
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
	public static string ReplaceRegex(this string text, string pattern, Func<Match, string> evaluation, int start, int count, int times, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return pattern.ToRegex(options.EnsureLeftToRightOption()).ReplaceText(text, evaluation, start, count, times);
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
	public static string ReplaceRegex(this string text, Regex pattern, string replacement, int times = -1)
	{
		return pattern.ReplaceText(text, replacement, times);
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
	public static string ReplaceRegex(this string text, Regex pattern, string replacement, int start, int count, int times = -1)
	{
		return pattern.ReplaceText(text, replacement, start, count, times);
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
	public static string ReplaceRegex(this string text, Regex pattern, Func<Match, string> evaluation, int times = -1)
	{
		return pattern.ReplaceText(text, evaluation, times);
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
	public static string ReplaceRegex(this string text, Regex pattern, Func<Match, string> evaluation, int start, int count, int times = -1)
	{
		return pattern.ReplaceText(text, evaluation, start, count, times);
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
	public static string ReplaceLastRegex(this string text, string pattern, string replacement, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return pattern.ToRegex(options.EnsureLeftToRightOption()).ReplaceLastText(text, replacement);
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
	public static string ReplaceLastRegex(this string text, string pattern, string replacement, int times, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return pattern.ToRegex(options.EnsureLeftToRightOption()).ReplaceLastText(text, replacement, times);
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
	public static string ReplaceLastRegex(this string text, string pattern, string replacement, int start, int count, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return pattern.ToRegex(options.EnsureLeftToRightOption()).ReplaceLastText(text, replacement, start, count);
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
	public static string ReplaceLastRegex(this string text, string pattern, string replacement, int start, int count, int times, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return pattern.ToRegex(options.EnsureLeftToRightOption()).ReplaceLastText(text, replacement, start, count, times);
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
	public static string ReplaceLastRegex(this string text, string pattern, Func<Match, string> evaluation, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return pattern.ToRegex(options.EnsureLeftToRightOption()).ReplaceLastText(text, evaluation);
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
	public static string ReplaceLastRegex(this string text, string pattern, Func<Match, string> evaluation, int times, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return pattern.ToRegex(options.EnsureLeftToRightOption()).ReplaceLastText(text, evaluation, times);
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
	public static string ReplaceLastRegex(this string text, string pattern, Func<Match, string> evaluation, int start, int count, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return pattern.ToRegex(options.EnsureLeftToRightOption()).ReplaceLastText(text, evaluation, start, count);
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
	public static string ReplaceLastRegex(this string text, string pattern, Func<Match, string> evaluation, int start, int count, int times, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return pattern.ToRegex(options.EnsureLeftToRightOption()).ReplaceLastText(text, evaluation, start, count, times);
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
	public static string ReplaceLastRegex(this string text, Regex pattern, string replacement, int times = -1)
	{
		return pattern.ReplaceLastText(text, replacement, times);
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
	public static string ReplaceLastRegex(this string text, Regex pattern, string replacement, int start, int count, int times = -1)
	{
		return pattern.ReplaceLastText(text, replacement, start, count, times);
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
	public static string ReplaceLastRegex(this string text, Regex pattern, Func<Match, string> evaluation, int times = -1)
	{
		return pattern.ReplaceLastText(text, evaluation, times);
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
	public static string ReplaceLastRegex(this string text, Regex pattern, Func<Match, string> evaluation, int start, int count, int times = -1)
	{
		return pattern.ReplaceLastText(text, evaluation, start, count, times);
	}

	/// <summary>
	/// 饭庄当前文本中的字符顺序并返回反转后的新的文本
	/// </summary>
	/// <param name="text">当前本文</param>
	/// <returns>字符顺序反转后的文本</returns>
	public static string Reverse(this string text)
	{
		text.GuardNotNull("text");
		StringBuilder buff = new StringBuilder(text.Length);
		for (int i = 0; i < text.Length; i++)
		{
			buff.Append(text[i]);
		}
		return buff.ToString();
	}

	/// <summary>
	/// 根据容器中的定义解析当前类型名称，返回解析出的类型
	/// </summary>
	/// <param name="typeName">当前类型名称</param>
	/// <param name="throwError">如果无法解析类型名称是否抛出异常，默认为false</param>
	/// <returns>如果成功解析类型名称则返回类型对象，否则根据 <paramref name="throwError" /> 的设置返回空或者抛出异常。如果当前没有容器配置则返回空。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型名称为空。</exception>
	/// <exception cref="T:System.InvalidOperationException">当 <paramref name="throwError" /> 设置为true时，当前类型名称无法解析。</exception>
	public static Type ResolveContainerType(this string typeName, bool throwError = false)
	{
		typeName.GuardNotNull("type name");
		ITypeResolver resolver = TypeResolver.GetResolver<UnityTypeResolver>();
		return resolver.IsNull() ? null : resolver.ResolveType(typeName, throwError);
	}

	/// <summary>
	/// 将当前类型名称解析为其所表示的类型；类型名称区分大小写。
	/// </summary>
	/// <param name="typeName">当前类型名称</param>
	/// <returns>解析成功返回类型对象，解析失败返回空。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型名称为空。</exception>
	public static Type ResolveType(this string typeName)
	{
		typeName.GuardNotNull("type name");
		return TypeResolver.Resolve(typeName);
	}

	/// <summary>
	/// 将当前类型名称解析为其所表示的类型
	/// </summary>
	/// <param name="typeName">当前类型名称</param>
	/// <param name="throwError">如果转换失败是否抛出异常</param>
	/// <param name="ignoreCase">解析类型名称时是否区分大小写，默认为区分大小写（false）</param>
	/// <returns>解析成功返回类型对象，解析失败时根据 <paramref name="throwError" /> 的设置。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前类型名称为空。</exception>
	public static Type ResolveType(this string typeName, bool throwError, bool ignoreCase = false)
	{
		typeName.GuardNotNull("type name");
		return TypeResolver.Resolve(typeName, throwError, ignoreCase);
	}

	/// <summary>
	/// 获取当前文本右侧指定长度的字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="count">右侧截取的字符数量</param>
	/// <returns>右侧截取的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">截取的字符数量 <paramref name="count" /> 小于0，或者大于当前文本中字符的数量。</exception>
	public static string Right(this string text, int count)
	{
		text.GuardNotNull("text");
		count.GuardBetween(0, text.Length, "count");
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
	public static string[] Split(this string text, int length)
	{
		text.GuardNotNull("text");
		length.GuardBetween(1, text.Length, "length");
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
	public static string[] Split(this string text, char separator, bool removeEmptyEntries = false)
	{
		return text.Split(new char[1] { separator }, removeEmptyEntries);
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
	public static string[] Split(this string text, char separator, int count, bool removeEmptyEntries = false)
	{
		return text.Split(new char[1] { separator }, count, removeEmptyEntries);
	}

	/// <summary>
	/// 将当前文本按照指定的分隔字符分解为字符串数组
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="separators">分隔字符数组</param>
	/// <param name="removeEmptyEntries">是否不包括含有空字符串的数组元素</param>
	/// <returns>分解后的字符串数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者分隔符数组 <paramref name="separators" /> 为空。</exception>
	public static string[] Split(this string text, char[] separators, bool removeEmptyEntries)
	{
		text.GuardNotNull("text");
		separators.GuardNotNull("separators");
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
	public static string[] Split(this string text, char[] separators, int count, bool removeEmptyEntries)
	{
		text.GuardNotNull("text");
		separators.GuardNotNull("separators");
		count.GuardGreaterThanOrEqualTo(0, "count");
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
	public static string[] Split(this string text, string separator, bool removeEmptyEntries = false)
	{
		return text.Split(new string[1] { separator }, removeEmptyEntries);
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
	public static string[] Split(this string text, string separator, int count, bool removeEmptyEntries = false)
	{
		return text.Split(new string[1] { separator }, count, removeEmptyEntries);
	}

	/// <summary>
	/// 将当前文本按指定的分隔字符串分解为字符串数组
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="separators">分隔字符串数组</param>
	/// <param name="removeEmptyEntries">是否不包括含有空字符串的数组元素</param>
	/// <returns>分解后的字符串数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者分隔字符串数组 <paramref name="separators" /> 为空。</exception>
	public static string[] Split(this string text, string[] separators, bool removeEmptyEntries)
	{
		text.GuardNotNull("text");
		separators.GuardNotNull("separators");
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
	public static string[] Split(this string text, string[] separators, int count, bool removeEmptyEntries)
	{
		text.GuardNotNull("text");
		separators.GuardNotNull("separators");
		count.GuardGreaterThanOrEqualTo(0, "count");
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
	public static string[] SplitRegex(this string text, string pattern, bool removeEmptyEntries = false, bool keepSpliter = false, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return text.SplitRegex(pattern.ToRegex(options), removeEmptyEntries, keepSpliter);
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
	public static string[] SplitRegex(this string text, string pattern, int count, bool removeEmptyEntries = false, bool keepSpliter = false, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		count.GuardGreaterThanOrEqualTo(0, "count");
		return text.SplitRegex(pattern.ToRegex(options), count, removeEmptyEntries, keepSpliter);
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
	public static string[] SplitRegex(this string text, Regex pattern, bool removeEmptyEntries = false, bool keepSpliter = false)
	{
		return text.SplitRegex(pattern, (Match m, int i) => true, removeEmptyEntries, keepSpliter);
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
	public static string[] SplitRegex(this string text, Regex pattern, int count, bool removeEmptyEntries = false, bool keepSpliter = false)
	{
		count.GuardGreaterThanOrEqualTo(0, "count");
		int matched = 0;
		return text.SplitRegex(pattern, (Match m, int i) => ++matched <= count, removeEmptyEntries, keepSpliter);
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
	public static string[] SplitRegex(this string text, Regex pattern, Func<Match, bool> predicate, bool removeEmptyEntries = false, bool keepSpliter = false)
	{
		predicate.GuardNotNull("predicate");
		return text.SplitRegex(pattern, (Match m, int i) => predicate(m), removeEmptyEntries, keepSpliter);
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
	public static string[] SplitRegex(this string text, Regex pattern, Func<Match, int, bool> predicate, bool removeEmptyEntries = false, bool keepSpliter = false)
	{
		text.GuardNotNull("text");
		pattern.GuardNotNull("pattern");
		predicate.GuardNotNull("predicate");
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
	/// 根据指定的文本编码将当前文本编码为字节数组
	/// </summary>
	/// <param name="text">当前待编码的文本</param>
	/// <param name="encoding">编码文本所使用的编码，默认为UTF-8</param>
	/// <returns>编码后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static byte[] TextEncode(this string text, Encoding encoding = null)
	{
		text.GuardNotNull("text");
		encoding = encoding.IfNull(Encoding.UTF8);
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
	public static byte[] TextEncode(this string text, int start, int count, Encoding encoding = null)
	{
		text.GuardNotNull("text");
		start.GuardIndexRange(0, text.Length - 1, "start");
		count.GuardBetween(0, text.Length - start, "count");
		encoding = encoding.IfNull(Encoding.UTF8);
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
	/// 从当前文本中移除与给定字符数组中字符相同的前导字符和尾部字符
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="trimingChars">待移除的字符数组</param>
	/// <param name="ignoreCase">字符比较时是否区分大小写</param>
	/// <returns>处理后的文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者待移除的字符数组 <paramref name="trimingChars" /> 为空。</exception>
	public static string Trim(this string text, char[] trimingChars, bool ignoreCase = false)
	{
		return text.Trim(trimingChars, CultureInfo.CurrentCulture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static string Trim(this string text, char[] trimingChars, CultureInfo culture, bool ignoreCase = false)
	{
		return text.Trim(trimingChars, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static string Trim(this string text, char[] trimingChars, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		trimingChars.GuardNotNull("triming chars");
		int start;
		for (start = 0; start < text.Length && trimingChars.Any((char c) => c.IsEqualTo(text[start], culture, options)); start++)
		{
		}
		int end;
		for (end = text.Length - 1; end >= 0 && trimingChars.Any((char c) => c.IsEqualTo(text[end], culture, options)); end--)
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
	public static string Trim(this string text, string trimingText, bool ignoreCase = false)
	{
		return text.Trim(trimingText, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
	}

	/// <summary>
	/// 从当前文本中移除与指定字符串匹配的所有前导字符串和尾部字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="trimingText">要移除的字符串，如果指定的字符串为空串，则不移除任何字符</param>
	/// <param name="comparison">字符串比较方式</param>
	/// <returns>处理后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者待移除的字符串 <paramref name="trimingText" /> 为空。</exception>
	public static string Trim(this string text, string trimingText, StringComparison comparison)
	{
		text.GuardNotNull("text");
		trimingText.GuardNotNull("triming text");
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
	public static string Trim(this string text, string trimingText, CultureInfo culture, bool ignoreCase = false)
	{
		return text.Trim(trimingText, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static string Trim(this string text, string trimingText, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		trimingText.GuardNotNull("triming text");
		if (trimingText.Length == 0)
		{
			return text;
		}
		int start;
		for (start = 0; start < trimingText.Length && text.IndexOf(trimingText, start, trimingText.Length, culture, options) >= 0; start += trimingText.Length)
		{
		}
		int end = text.Length - 1;
		while (end >= 0 && text.LastIndexOf(trimingText, end, trimingText.Length, culture, options) >= 0)
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
	public static string TrimStart(this string text, char[] trimingChars, bool ignoreCase = false)
	{
		return text.TrimStart(trimingChars, CultureInfo.CurrentCulture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static string TrimStart(this string text, char[] trimingChars, CultureInfo culture, bool ignoreCase = false)
	{
		return text.TrimStart(trimingChars, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static string TrimStart(this string text, char[] trimingChars, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		trimingChars.GuardNotNull("triming chars");
		int start;
		for (start = 0; start < text.Length && trimingChars.Any((char c) => c.IsEqualTo(text[start], culture, options)); start++)
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
	public static string TrimStart(this string text, string trimingText, bool ignoreCase = false)
	{
		return text.TrimStart(trimingText, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
	}

	/// <summary>
	/// 从当前文本中移除与指定字符串匹配的所有前导字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="trimingText">要移除的字符串，如果指定的字符串为空串，则不移除任何字符</param>
	/// <param name="comparison">字符串比较方式</param>
	/// <returns>处理后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者待移除的字符串 <paramref name="trimingText" /> 为空。</exception>
	public static string TrimStart(this string text, string trimingText, StringComparison comparison)
	{
		text.GuardNotNull("text");
		trimingText.GuardNotNull("triming text");
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
	public static string TrimStart(this string text, string trimingText, CultureInfo culture, bool ignoreCase = false)
	{
		return text.TrimStart(trimingText, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static string TrimStart(this string text, string trimingText, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		trimingText.GuardNotNull("triming text");
		if (trimingText.Length == 0)
		{
			return text;
		}
		int start;
		for (start = 0; start < trimingText.Length && text.IndexOf(trimingText, start, trimingText.Length, culture, options) >= 0; start += trimingText.Length)
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
	public static string TrimEnd(this string text, char[] trimingChars, bool ignoreCase = false)
	{
		return text.TrimEnd(trimingChars, CultureInfo.CurrentCulture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static string TrimEnd(this string text, char[] trimingChars, CultureInfo culture, bool ignoreCase = false)
	{
		return text.TrimEnd(trimingChars, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static string TrimEnd(this string text, char[] trimingChars, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		trimingChars.GuardNotNull("triming chars");
		int start;
		for (start = 0; start < text.Length && trimingChars.Any((char c) => c.IsEqualTo(text[start], culture, options)); start++)
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
	public static string TrimEnd(this string text, string trimingText, bool ignoreCase = false)
	{
		return text.TrimEnd(trimingText, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
	}

	/// <summary>
	/// 从当前文本中移除与指定字符串匹配的所有尾部字符串
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="trimingText">要移除的字符串，如果指定的字符串为空串，则不移除任何字符</param>
	/// <param name="comparison">字符串比较方式</param>
	/// <returns>处理后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空；或者待移除的字符串 <paramref name="trimingText" /> 为空。</exception>
	public static string TrimEnd(this string text, string trimingText, StringComparison comparison)
	{
		text.GuardNotNull("text");
		trimingText.GuardNotNull("triming text");
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
	public static string TrimEnd(this string text, string trimingText, CultureInfo culture, bool ignoreCase = false)
	{
		return text.TrimEnd(trimingText, culture, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
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
	public static string TrimEnd(this string text, string trimingText, CultureInfo culture, CompareOptions options)
	{
		text.GuardNotNull("text");
		trimingText.GuardNotNull("triming text");
		int end = text.Length - 1;
		while (end >= 0 && text.LastIndexOf(trimingText, end, trimingText.Length, culture, options) >= 0)
		{
			end -= trimingText.Length;
		}
		return (end >= 0) ? text.Substring(0, end + 1) : string.Empty;
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Boolean" /> 型数值
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false。</returns>
	public static bool TryParseBoolean(this string s, out bool value)
	{
		value = false;
		if (s.IsNull())
		{
			return false;
		}
		s = s.Trim();
		if (RegexPatterns.BooleanTrue.IsWholeMatch(s))
		{
			return true;
		}
		if (RegexPatterns.BooleanFalse.IsWholeMatch(s))
		{
			return false;
		}
		return bool.TryParse(s, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Byte" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseByte(this string s, out byte value)
	{
		return s.TryParseByte(null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Byte" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseByte(this string s, NumberStyles style, out byte value)
	{
		return s.TryParseByte(style, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Byte" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseByte(this string s, IFormatProvider provider, out byte value)
	{
		return s.TryParseByte(NumberStyles.Integer | NumberStyles.AllowHexSpecifier, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Byte" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseByte(this string s, NumberStyles style, IFormatProvider provider, out byte value)
	{
		value = 0;
		if (s.IsNull())
		{
			return false;
		}
		if (style.HasFlag(NumberStyles.AllowHexSpecifier))
		{
			s = RegexPatterns.HexNumberPrefix.Replace(s, string.Empty);
		}
		return byte.TryParse(s, style, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Byte" />[] 型数值。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseByteArray(this string s, out byte[] value)
	{
		value = null;
		return s.Try((string x) => x.HexDecode(), out value).IsNull();
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Char" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	/// <remarks>本方法支持将"0x"、"&amp;h"、"\x"或者"\u"开头的十六进制数值解析为 <see cref="T:System.Char" /> 型数值。</remarks>
	public static bool TryParseChar(this string s, out char value)
	{
		value = '\0';
		if (s.IsNull())
		{
			return false;
		}
		s = RegexPatterns.HexCharPrefix.Replace(s, string.Empty);
		return char.TryParse(s, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串表示的区域信息
	/// </summary>
	/// <param name="s">当前区域名称</param>
	/// <param name="culture">输出参数，返回当前字符串表示的区域信息</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseCulture(this string s, out CultureInfo culture)
	{
		return s.Try((string x) => CultureInfo.GetCultureInfo(x), out culture).IsNull();
	}

	/// <summary>
	/// 尝试分析当前字符串表示的区域信息
	/// </summary>
	/// <param name="s">当前区域名称</param>
	/// <param name="alt">区域性名称</param>
	/// <param name="culture">输出参数，返回当前字符串表示的区域信息</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseCulture(this string s, string alt, out CultureInfo culture)
	{
		return s.Try((string x) => CultureInfo.GetCultureInfo(x, alt), out culture).IsNull();
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期。
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTime(this string s, out DateTime value)
	{
		return DateTime.TryParse(s, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="style">日期字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTime(this string s, DateTimeStyles style, out DateTime value)
	{
		return DateTime.TryParse(s, null, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期。
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTime(this string s, IFormatProvider provider, out DateTime value)
	{
		return DateTime.TryParse(s, provider, DateTimeStyles.None, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="style">日期字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTime(this string s, DateTimeStyles style, IFormatProvider provider, out DateTime value)
	{
		return DateTime.TryParse(s, provider, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="format">分析时使用的日期格式说明符</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTime(this string s, string format, out DateTime value)
	{
		return DateTime.TryParseExact(s, format, null, DateTimeStyles.None, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="format">分析时使用的日期格式说明符</param>
	/// <param name="style">日期字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTime(this string s, string format, DateTimeStyles style, out DateTime value)
	{
		return DateTime.TryParseExact(s, format, null, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="format">分析时使用的日期格式说明符</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTime(this string s, string format, IFormatProvider provider, out DateTime value)
	{
		return DateTime.TryParseExact(s, format, provider, DateTimeStyles.None, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="format">分析时使用的日期格式说明符</param>
	/// <param name="style">日期字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTime(this string s, string format, DateTimeStyles style, IFormatProvider provider, out DateTime value)
	{
		return DateTime.TryParseExact(s, format, provider, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="formats">分析时使用的日期格式说明符</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTime(this string s, string[] formats, out DateTime value)
	{
		return DateTime.TryParseExact(s, formats, null, DateTimeStyles.None, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="formats">分析时使用的日期格式说明符</param>
	/// <param name="style">日期字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTime(this string s, string[] formats, DateTimeStyles style, out DateTime value)
	{
		return DateTime.TryParseExact(s, formats, null, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="formats">分析时使用的日期格式说明符</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTime(this string s, string[] formats, IFormatProvider provider, out DateTime value)
	{
		return DateTime.TryParseExact(s, formats, provider, DateTimeStyles.None, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="formats">分析时使用的日期格式说明符</param>
	/// <param name="style">日期字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTime(this string s, string[] formats, DateTimeStyles style, IFormatProvider provider, out DateTime value)
	{
		return DateTime.TryParseExact(s, formats, provider, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期。
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTimeOffset(this string s, out DateTimeOffset value)
	{
		return DateTimeOffset.TryParse(s, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="style">日期字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTimeOffset(this string s, DateTimeStyles style, out DateTimeOffset value)
	{
		return DateTimeOffset.TryParse(s, null, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期。
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTimeOffset(this string s, IFormatProvider provider, out DateTimeOffset value)
	{
		return DateTimeOffset.TryParse(s, provider, DateTimeStyles.None, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="style">日期字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTimeOffset(this string s, DateTimeStyles style, IFormatProvider provider, out DateTimeOffset value)
	{
		return DateTimeOffset.TryParse(s, provider, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="format">分析时使用的日期格式说明符</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTimeOffset(this string s, string format, out DateTimeOffset value)
	{
		return DateTimeOffset.TryParseExact(s, format, null, DateTimeStyles.None, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="format">分析时使用的日期格式说明符</param>
	/// <param name="style">日期字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTimeOffset(this string s, string format, DateTimeStyles style, out DateTimeOffset value)
	{
		return DateTimeOffset.TryParseExact(s, format, null, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="format">分析时使用的日期格式说明符</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTimeOffset(this string s, string format, IFormatProvider provider, out DateTimeOffset value)
	{
		return DateTimeOffset.TryParseExact(s, format, provider, DateTimeStyles.None, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="format">分析时使用的日期格式说明符</param>
	/// <param name="style">日期字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTimeOffset(this string s, string format, DateTimeStyles style, IFormatProvider provider, out DateTimeOffset value)
	{
		return DateTimeOffset.TryParseExact(s, format, provider, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="formats">分析时使用的日期格式说明符</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTimeOffset(this string s, string[] formats, out DateTimeOffset value)
	{
		return DateTimeOffset.TryParseExact(s, formats, null, DateTimeStyles.None, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="formats">分析时使用的日期格式说明符</param>
	/// <param name="style">日期字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTimeOffset(this string s, string[] formats, DateTimeStyles style, out DateTimeOffset value)
	{
		return DateTimeOffset.TryParseExact(s, formats, null, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="formats">分析时使用的日期格式说明符</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTimeOffset(this string s, string[] formats, IFormatProvider provider, out DateTimeOffset value)
	{
		return DateTimeOffset.TryParseExact(s, formats, provider, DateTimeStyles.None, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="formats">分析时使用的日期格式说明符</param>
	/// <param name="style">日期字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTimeOffset(this string s, string[] formats, DateTimeStyles style, IFormatProvider provider, out DateTimeOffset value)
	{
		return DateTimeOffset.TryParseExact(s, formats, provider, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Decimal" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDecimal(this string s, out decimal value)
	{
		return s.TryParseDecimal(null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Decimal" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDecimal(this string s, NumberStyles style, out decimal value)
	{
		return s.TryParseDecimal(style, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Decimal" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDecimal(this string s, IFormatProvider provider, out decimal value)
	{
		return s.TryParseDecimal(NumberStyles.Number, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Decimal" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDecimal(this string s, NumberStyles style, IFormatProvider provider, out decimal value)
	{
		return decimal.TryParse(s, style, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Double" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDouble(this string s, out double value)
	{
		return s.TryParseDouble(null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Double" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDouble(this string s, NumberStyles style, out double value)
	{
		return s.TryParseDouble(style, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Double" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDouble(this string s, IFormatProvider provider, out double value)
	{
		return s.TryParseDouble(NumberStyles.Float | NumberStyles.AllowThousands, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Double" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDouble(this string s, NumberStyles style, IFormatProvider provider, out double value)
	{
		return double.TryParse(s, style, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的枚举。
	/// </summary>
	/// <typeparam name="T">解析的枚举类型</typeparam>
	/// <param name="s">当前枚举字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseEnum<T>(this string s, out T value) where T : struct
	{
		return Enum.TryParse<T>(s, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的枚举。
	/// </summary>
	/// <typeparam name="T">解析的枚举类型</typeparam>
	/// <param name="s">当前枚举字符串</param>
	/// <param name="ignoreCase">是否区分枚举名称的大小写</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseEnum<T>(this string s, bool ignoreCase, out T value) where T : struct
	{
		return Enum.TryParse<T>(s, ignoreCase, out value);
	}

	/// <summary>
	/// 分析当前字符串所表示的数值；该数值应是用科学计数法表示的。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseExponential(this string s, out int[] value)
	{
		value = null;
		if (s.IsNull())
		{
			return false;
		}
		Match i = RegexPatterns.ExponentialNumber.Match(s);
		if (i.Groups.Count != 6)
		{
			return false;
		}
		value = new int[4]
		{
			(!(i.Groups[2].Value == "-")) ? 1 : (-1),
			(i.Groups[3].Value.Length != 0) ? i.Groups[3].Value.ParseInt32() : 0,
			(i.Groups[4].Value.Length != 0) ? i.Groups[4].Value.TrimEnd('0').ParseInt32() : 0,
			(i.Groups[5].Value.Length != 0) ? i.Groups[5].Value.ParseInt32() : 0
		};
		return true;
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Single" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseFloat(this string s, out float value)
	{
		return s.TryParseSingle(out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Single" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseFloat(this string s, NumberStyles style, out float value)
	{
		return s.TryParseSingle(style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Single" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseFloat(this string s, IFormatProvider provider, out float value)
	{
		return s.TryParseSingle(provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Single" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseFloat(this string s, NumberStyles style, IFormatProvider provider, out float value)
	{
		return s.TryParseSingle(style, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Guid" /> 类型数值。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	/// <remarks>
	/// N:00000000000000000000000000000000
	/// D:00000000-0000-0000-0000-000000000000
	/// B:{00000000-0000-0000-0000-000000000000}
	/// P:(00000000-0000-0000-0000-000000000000)
	/// X:{0x00000000,0x0000,0x0000,{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00}}
	/// 如果设置为空，则自动检测Guid字符串格式。
	/// </remarks>
	public static bool TryParseGuid(this string s, out Guid value)
	{
		return Guid.TryParse(s, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Guid" /> 类型数值。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="format">Guid字符串的格式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	/// <remarks>
	/// <paramref name="format" /> 指定待解析的Guid字符串的格式，包括：
	/// N:00000000000000000000000000000000
	/// D:00000000-0000-0000-0000-000000000000
	/// B:{00000000-0000-0000-0000-000000000000}
	/// P:(00000000-0000-0000-0000-000000000000)
	/// X:{0x00000000,0x0000,0x0000,{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00}}
	/// 如果设置为空，则自动检测Guid字符串格式。
	/// </remarks>
	public static bool TryParseGuid(this string s, string format, out Guid value)
	{
		return Guid.TryParseExact(s, format, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的十六进制 <see cref="T:System.Int32" /> 类型数值
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseHex(this string s, out int value)
	{
		return s.TryParseInt32(NumberStyles.HexNumber, CultureInfo.InvariantCulture, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseInt(this string s, out int value)
	{
		return s.TryParseInt32(out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseInt(this string s, NumberStyles style, out int value)
	{
		return s.TryParseInt32(style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseInt(this string s, IFormatProvider provider, out int value)
	{
		return s.TryParseInt32(provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseInt(this string s, NumberStyles style, IFormatProvider provider, out int value)
	{
		return s.TryParseInt32(style, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseInt16(this string s, out short value)
	{
		return s.TryParseInt16(null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseInt16(this string s, NumberStyles style, out short value)
	{
		return s.TryParseInt16(style, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseInt16(this string s, IFormatProvider provider, out short value)
	{
		return s.TryParseInt16(NumberStyles.Integer | NumberStyles.AllowHexSpecifier, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseInt16(this string s, NumberStyles style, IFormatProvider provider, out short value)
	{
		value = 0;
		if (s.IsNull())
		{
			return false;
		}
		if (style.HasFlag(NumberStyles.AllowHexSpecifier))
		{
			s = RegexPatterns.HexNumberPrefix.Replace(s, string.Empty);
		}
		return short.TryParse(s, style, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseInt32(this string s, out int value)
	{
		return s.TryParseInt32(null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseInt32(this string s, NumberStyles style, out int value)
	{
		return s.TryParseInt32(style, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseInt32(this string s, IFormatProvider provider, out int value)
	{
		return s.TryParseInt32(NumberStyles.Integer | NumberStyles.AllowHexSpecifier, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseInt32(this string s, NumberStyles style, IFormatProvider provider, out int value)
	{
		value = 0;
		if (s.IsNull())
		{
			return false;
		}
		if (style.HasFlag(NumberStyles.AllowHexSpecifier))
		{
			s = RegexPatterns.HexNumberPrefix.Replace(s, string.Empty);
		}
		return int.TryParse(s, style, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	/// <remarks>本方法支持将"0x"或者"&amp;h"开头的十六进制数值解析为 <see cref="T:System.Int64" /> 型数值。</remarks>
	public static bool TryParseInt64(this string s, out long value)
	{
		return s.TryParseInt64(null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseInt64(this string s, NumberStyles style, out long value)
	{
		return s.TryParseInt64(style, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseInt64(this string s, IFormatProvider provider, out long value)
	{
		return s.TryParseInt64(NumberStyles.Integer | NumberStyles.AllowHexSpecifier, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseInt64(this string s, NumberStyles style, IFormatProvider provider, out long value)
	{
		value = 0L;
		if (s.IsNull())
		{
			return false;
		}
		if (style.HasFlag(NumberStyles.AllowHexSpecifier))
		{
			s = RegexPatterns.HexNumberPrefix.Replace(s, string.Empty);
		}
		return long.TryParse(s, style, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.IntPtr" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	/// <remarks>本方法支持将"0x"或者"&amp;h"开头的十六进制数值解析为 <see cref="T:System.IntPtr" /> 型数值。</remarks>
	public static bool TryParseIntPtr(this string s, out IntPtr value)
	{
		return s.TryParseIntPtr(null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.IntPtr" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseIntPtr(this string s, NumberStyles style, out IntPtr value)
	{
		return s.TryParseIntPtr(style, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.IntPtr" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseIntPtr(this string s, IFormatProvider provider, out IntPtr value)
	{
		return s.TryParseIntPtr(NumberStyles.Integer | NumberStyles.AllowHexSpecifier, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.IntPtr" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseIntPtr(this string s, NumberStyles style, IFormatProvider provider, out IntPtr value)
	{
		value = IntPtr.Zero;
		switch (IntPtr.Size)
		{
		case 4:
		{
			if (s.TryParseInt32(style, provider, out var intResult))
			{
				value = (IntPtr)intResult;
				return true;
			}
			break;
		}
		case 8:
		{
			if (s.TryParseInt64(style, provider, out var longResult))
			{
				value = (IntPtr)longResult;
				return true;
			}
			break;
		}
		default:
			throw new NotSupportedException(Literals.MSG_InvalidCast_2.FormatValue(s, typeof(IntPtr).FullName));
		}
		return false;
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	/// <remarks>本方法支持将"0x"或者"&amp;h"开头的十六进制数值解析为 <see cref="T:System.Int64" /> 型数值。</remarks>
	public static bool TryParseLong(this string s, out long value)
	{
		return s.TryParseInt64(out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseLong(this string s, NumberStyles style, out long value)
	{
		return s.TryParseInt64(style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseLong(this string s, IFormatProvider provider, out long value)
	{
		return s.TryParseInt64(provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseLong(this string s, NumberStyles style, IFormatProvider provider, out long value)
	{
		return s.TryParseInt64(style, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的十六进制 <see cref="T:System.Int64" /> 类型数值
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseLongHex(this string s, out long value)
	{
		return s.TryParseInt64(NumberStyles.HexNumber, CultureInfo.InvariantCulture, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.SByte" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseSByte(this string s, out sbyte value)
	{
		return s.TryParseSByte(null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.SByte" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseSByte(this string s, NumberStyles style, out sbyte value)
	{
		return s.TryParseSByte(style, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.SByte" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseSByte(this string s, IFormatProvider provider, out sbyte value)
	{
		return s.TryParseSByte(NumberStyles.Integer | NumberStyles.AllowHexSpecifier, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.SByte" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseSByte(this string s, NumberStyles style, IFormatProvider provider, out sbyte value)
	{
		value = 0;
		if (s.IsNull())
		{
			return false;
		}
		if (style.HasFlag(NumberStyles.AllowHexSpecifier))
		{
			s = RegexPatterns.HexNumberPrefix.Replace(s, string.Empty);
		}
		return sbyte.TryParse(s, style, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseShort(this string s, out short value)
	{
		return s.TryParseInt16(out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseShort(this string s, NumberStyles style, out short value)
	{
		return s.TryParseInt16(style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseShort(this string s, IFormatProvider provider, out short value)
	{
		return s.TryParseInt16(provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseShort(this string s, NumberStyles style, IFormatProvider provider, out short value)
	{
		return s.TryParseInt16(style, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Single" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseSingle(this string s, out float value)
	{
		return s.TryParseSingle(null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Single" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseSingle(this string s, NumberStyles style, out float value)
	{
		return s.TryParseSingle(style, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Single" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseSingle(this string s, IFormatProvider provider, out float value)
	{
		return s.TryParseSingle(NumberStyles.Float | NumberStyles.AllowThousands, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Single" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseSingle(this string s, NumberStyles style, IFormatProvider provider, out float value)
	{
		return float.TryParse(s, style, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.TimeSpan" /> 类型数值。
	/// </summary>
	/// <param name="s">当前时间间隔字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseTimeSpan(this string s, out TimeSpan value)
	{
		return TimeSpan.TryParse(s, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.TimeSpan" /> 类型数值。
	/// </summary>
	/// <param name="s">当前时间间隔字符串</param>
	/// <param name="style">时间间隔字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseTimeSpan(this string s, TimeSpanStyles style, out TimeSpan value)
	{
		return TimeSpan.TryParseExact(s, "G", null, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.TimeSpan" /> 类型数值。
	/// </summary>
	/// <param name="s">当前时间间隔字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseTimeSpan(this string s, IFormatProvider provider, out TimeSpan value)
	{
		return TimeSpan.TryParse(s, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.TimeSpan" /> 类型数值。
	/// </summary>
	/// <param name="s">当前时间间隔字符串</param>
	/// <param name="style">时间间隔字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseTimeSpan(this string s, TimeSpanStyles style, IFormatProvider provider, out TimeSpan value)
	{
		return TimeSpan.TryParseExact(s, "G", provider, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.TimeSpan" /> 类型数值。
	/// </summary>
	/// <param name="s">当前时间间隔字符串</param>
	/// <param name="format">分析时使用的时间间隔格式说明符</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseTimeSpan(this string s, string format, out TimeSpan value)
	{
		return TimeSpan.TryParseExact(s, format, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.TimeSpan" /> 类型数值。
	/// </summary>
	/// <param name="s">当前时间间隔字符串</param>
	/// <param name="format">分析时使用的时间间隔格式说明符</param>
	/// <param name="style">时间间隔字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseTimeSpan(this string s, string format, TimeSpanStyles style, out TimeSpan value)
	{
		return TimeSpan.TryParseExact(s, format, null, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.TimeSpan" /> 类型数值。
	/// </summary>
	/// <param name="s">当前时间间隔字符串</param>
	/// <param name="format">分析时使用的时间间隔格式说明符</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseTimeSpan(this string s, string format, IFormatProvider provider, out TimeSpan value)
	{
		return TimeSpan.TryParseExact(s, format, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.TimeSpan" /> 类型数值。
	/// </summary>
	/// <param name="s">当前时间间隔字符串</param>
	/// <param name="format">分析时使用的时间间隔格式说明符</param>
	/// <param name="style">时间间隔字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseTimeSpan(this string s, string format, TimeSpanStyles style, IFormatProvider provider, out TimeSpan value)
	{
		return TimeSpan.TryParseExact(s, format, provider, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.TimeSpan" /> 类型数值。
	/// </summary>
	/// <param name="s">当前时间间隔字符串</param>
	/// <param name="formats">分析时使用的时间间隔格式说明符数组</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseTimeSpan(this string s, string[] formats, out TimeSpan value)
	{
		return TimeSpan.TryParseExact(s, formats, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.TimeSpan" /> 类型数值。
	/// </summary>
	/// <param name="s">当前时间间隔字符串</param>
	/// <param name="formats">分析时使用的时间间隔格式说明符数组</param>
	/// <param name="style">时间间隔字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseTimeSpan(this string s, string[] formats, TimeSpanStyles style, out TimeSpan value)
	{
		return TimeSpan.TryParseExact(s, formats, null, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.TimeSpan" /> 类型数值。
	/// </summary>
	/// <param name="s">当前时间间隔字符串</param>
	/// <param name="formats">分析时使用的时间间隔格式说明符数组</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseTimeSpan(this string s, string[] formats, IFormatProvider provider, out TimeSpan value)
	{
		return TimeSpan.TryParseExact(s, formats, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.TimeSpan" /> 类型数值。
	/// </summary>
	/// <param name="s">当前时间间隔字符串</param>
	/// <param name="formats">分析时使用的时间间隔格式说明符数组</param>
	/// <param name="style">时间间隔字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseTimeSpan(this string s, string[] formats, TimeSpanStyles style, IFormatProvider provider, out TimeSpan value)
	{
		return TimeSpan.TryParseExact(s, formats, provider, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的十六进制值的 <see cref="T:System.UInt32" /> 类型数值
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUHex(this string s, out uint value)
	{
		return s.TryParseUInt32(NumberStyles.HexNumber, CultureInfo.InvariantCulture, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUInt(this string s, out uint value)
	{
		return s.TryParseUInt32(out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUInt(this string s, NumberStyles style, out uint value)
	{
		return s.TryParseUInt32(style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUInt(this string s, IFormatProvider provider, out uint value)
	{
		return s.TryParseUInt32(provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUInt(this string s, NumberStyles style, IFormatProvider provider, out uint value)
	{
		return s.TryParseUInt32(style, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUInt16(this string s, out ushort value)
	{
		return s.TryParseUInt16(null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUInt16(this string s, NumberStyles style, out ushort value)
	{
		return s.TryParseUInt16(style, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUInt16(this string s, IFormatProvider provider, out ushort value)
	{
		return s.TryParseUInt16(NumberStyles.Integer | NumberStyles.AllowHexSpecifier, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUInt16(this string s, NumberStyles style, IFormatProvider provider, out ushort value)
	{
		value = 0;
		if (s.IsNull())
		{
			return false;
		}
		if (style.HasFlag(NumberStyles.AllowHexSpecifier))
		{
			s = RegexPatterns.HexNumberPrefix.Replace(s, string.Empty);
		}
		return ushort.TryParse(s, style, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUInt32(this string s, out uint value)
	{
		return s.TryParseUInt32(null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUInt32(this string s, NumberStyles style, out uint value)
	{
		return s.TryParseUInt32(style, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUInt32(this string s, IFormatProvider provider, out uint value)
	{
		return s.TryParseUInt32(NumberStyles.Integer | NumberStyles.AllowHexSpecifier, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUInt32(this string s, NumberStyles style, IFormatProvider provider, out uint value)
	{
		value = 0u;
		if (s.IsNull())
		{
			return false;
		}
		if (style.HasFlag(NumberStyles.AllowHexSpecifier))
		{
			s = RegexPatterns.HexNumberPrefix.Replace(s, string.Empty);
		}
		return uint.TryParse(s, style, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUInt64(this string s, out ulong value)
	{
		return s.TryParseUInt64(null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUInt64(this string s, NumberStyles style, out ulong value)
	{
		return s.TryParseUInt64(style, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUInt64(this string s, IFormatProvider provider, out ulong value)
	{
		return s.TryParseUInt64(NumberStyles.Integer | NumberStyles.AllowHexSpecifier, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUInt64(this string s, NumberStyles style, IFormatProvider provider, out ulong value)
	{
		value = 0uL;
		if (s.IsNull())
		{
			return false;
		}
		if (style.HasFlag(NumberStyles.AllowHexSpecifier))
		{
			s = RegexPatterns.HexNumberPrefix.Replace(s, string.Empty);
		}
		return ulong.TryParse(s, style, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UIntPtr" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUIntPtr(this string s, out UIntPtr value)
	{
		return s.TryParseUIntPtr(null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UIntPtr" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUIntPtr(this string s, NumberStyles style, out UIntPtr value)
	{
		return s.TryParseUIntPtr(style, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UIntPtr" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUIntPtr(this string s, IFormatProvider provider, out UIntPtr value)
	{
		return s.TryParseUIntPtr(NumberStyles.Integer | NumberStyles.AllowHexSpecifier, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UIntPtr" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUIntPtr(this string s, NumberStyles style, IFormatProvider provider, out UIntPtr value)
	{
		value = UIntPtr.Zero;
		switch (UIntPtr.Size)
		{
		case 4:
		{
			if (s.TryParseInt32(style, provider, out var intResult))
			{
				value = (UIntPtr)(ulong)intResult;
				return true;
			}
			break;
		}
		case 8:
		{
			if (s.TryParseInt64(style, provider, out var longResult))
			{
				value = (UIntPtr)(ulong)longResult;
				return true;
			}
			break;
		}
		default:
			throw new NotSupportedException(Literals.MSG_InvalidCast_2.FormatValue(s, typeof(UIntPtr).FullName));
		}
		return false;
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseULong(this string s, out ulong value)
	{
		return s.TryParseUInt64(out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseULong(this string s, NumberStyles style, out ulong value)
	{
		return s.TryParseUInt64(style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseULong(this string s, IFormatProvider provider, out ulong value)
	{
		return s.TryParseUInt64(provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseULong(this string s, NumberStyles style, IFormatProvider provider, out ulong value)
	{
		return s.TryParseUInt64(style, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的十六进制值的 <see cref="T:System.UInt64" /> 类型数值
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseULongHex(this string s, out ulong value)
	{
		return s.TryParseUInt64(NumberStyles.HexNumber, CultureInfo.InvariantCulture, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUShort(this string s, out ushort value)
	{
		return s.TryParseUInt16(out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUShort(this string s, NumberStyles style, out ushort value)
	{
		return s.TryParseUInt16(style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUShort(this string s, IFormatProvider provider, out ushort value)
	{
		return s.TryParseUInt16(provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUShort(this string s, NumberStyles style, IFormatProvider provider, out ushort value)
	{
		return s.TryParseUInt16(style, provider, out value);
	}

	/// <summary>
	/// 将当前区域名称转换为所表示的区域信息对象
	/// </summary>
	/// <param name="name">当前区域名称</param>
	/// <param name="alt">区域性名称</param>
	/// <returns>当前区域名称相应的区域性对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前区域名称为空。</exception>
	public static CultureInfo ToCultureInfo(this string name, string alt = null)
	{
		name.GuardNotNull("culture name");
		return alt.IsNull() ? CultureInfo.GetCultureInfo(name) : CultureInfo.GetCultureInfo(name, alt);
	}

	/// <summary>
	/// 将当前目录路径转换为目录信息对象
	/// </summary>
	/// <param name="directory">当前目录路径</param>
	/// <returns>当前目录的目录信息对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录路径为空。</exception>
	/// <remarks>本方法获取当前目录路径表示目录信息对象</remarks>
	public static DirectoryInfo ToDirecotryInfo(this string directory)
	{
		directory.GuardNotNull("directory");
		return new DirectoryInfo(directory);
	}

	/// <summary>
	/// 将当前文件路径转换为所指示的文件对象，不检测文件是否实际存在是否存在
	/// </summary>
	/// <param name="file">当前文件路径</param>
	/// <returns>当前文件路径指示的文件对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录路径为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前目录路径无效。</exception>
	public static FileInfo ToFileInfo(this string file)
	{
		file.GuardNotNull("file");
		return new FileInfo(file);
	}

	/// <summary>
	/// 将当前正则模式字符串转换为正则表达式对象
	/// </summary>
	/// <param name="pattern">当前正则模式字符串</param>
	/// <param name="options">正则表达式选项</param>
	/// <returns>正则表达式字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前正则模式字符串为空。</exception>
	public static Regex ToRegex(this string pattern, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return RegexManager.GetOrAdd(pattern, options);
	}

	/// <summary>
	/// 将当前正则模式字符串转换为正则表达式对象
	/// </summary>
	/// <param name="pattern">当前正则模式字符串</param>
	/// <param name="escape">当前正则模式字符串中的字符是否需要进行转义，作为普通字符处理</param>
	/// <param name="options">正则表达式选项</param>
	/// <returns>正则表达式字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前正则模式字符串为空。</exception>
	public static Regex ToRegex(this string pattern, bool escape, RegexOptions options = RegexOptions.None)
	{
		pattern.GuardNotNull("pattern");
		return RegexManager.GetOrAdd(escape ? pattern.RegexEscape() : pattern, options);
	}

	/// <summary>
	/// 将字符串转换为其所表示的统一资源标识符 (URI) 的对象
	/// </summary>
	/// <param name="s">待转换的字符串</param>
	/// <returns>转换后的URI对象</returns>
	public static Uri ToUri(this string s)
	{
		s.GuardNotNull();
		return new Uri(s);
	}

	/// <summary>
	/// 使用Unicode编码对当前文本进行编码，返回编码后的字节数据
	/// </summary>
	/// <param name="text">当前待编码的文本</param>
	/// <returns>编码后的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static byte[] UnicodeEncode(this string text)
	{
		return text.TextEncode(Encoding.Unicode);
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
	public static byte[] UnicodeEncode(this string text, int start, int count)
	{
		return text.TextEncode(start, count, Encoding.Unicode);
	}

	/// <summary>
	/// 将当前URL编码的字符串解码为字符串
	/// </summary>
	/// <param name="text">当前URL编码的字符串</param>
	/// <param name="encoding">编码时使用的字符编码</param>
	/// <returns>解码后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前URL编码的字符串为空。</exception>
	public static string UrlDecode(this string text, Encoding encoding = null)
	{
		text.GuardNotNull("text");
		return encoding.IsNull() ? HttpUtility.UrlDecode(text) : HttpUtility.UrlDecode(text, encoding);
	}

	/// <summary>
	/// 将当前URL编码的字符串编码为字节数组
	/// </summary>
	/// <param name="text">当前URL编码的字符串</param>
	/// <param name="encoding">编码时使用的字符编码</param>
	/// <returns>编码后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前URL编码的字符串为空。</exception>
	public static byte[] UrlDecodeToBytes(this string text, Encoding encoding = null)
	{
		text.GuardNotNull("text");
		return encoding.IsNull() ? HttpUtility.UrlDecodeToBytes(text) : HttpUtility.UrlDecodeToBytes(text, encoding);
	}

	/// <summary>
	/// 将当前待编码的字符串编码为Url字符串
	/// </summary>
	/// <param name="text">当前待编码的字符串</param>
	/// <param name="encoding">编码时使用的字符编码</param>
	/// <returns>编码后的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前待编码的字符串为空。</exception>
	public static string UrlEncode(this string text, Encoding encoding = null)
	{
		text.GuardNotNull("text");
		return encoding.IsNull() ? HttpUtility.UrlEncode(text) : HttpUtility.UrlEncode(text, encoding);
	}

	/// <summary>
	/// 将当前待编码的字符串编码为字节数组
	/// </summary>
	/// <param name="text">当前待编码的字符串</param>
	/// <param name="encoding">编码使用的字符编码</param>
	/// <returns>编码后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前待编码的字符串为空。</exception>
	public static byte[] UrlEncodeToBytes(this string text, Encoding encoding = null)
	{
		text.GuardNotNull("text");
		return encoding.IsNull() ? HttpUtility.UrlEncodeToBytes(text) : HttpUtility.UrlEncodeToBytes(text, encoding);
	}

	/// <summary>
	/// 使用UTF-8编码对当前文本进行编码，返回编码后的字节数据
	/// </summary>
	/// <param name="text">当前待编码的文本</param>
	/// <returns>编码后的字节数据</returns>
	public static byte[] Utf8Encode(this string text)
	{
		return text.TextEncode(Encoding.UTF8);
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
	public static byte[] Utf8Encode(this string text, int start, int count)
	{
		return text.TextEncode(start, count, Encoding.UTF8);
	}

	/// <summary>
	/// 从当前字符串序列中筛选非空且不是空串的字符串，并返回这些字符串组成的新序列
	/// </summary>
	/// <param name="source">当前字符串序列</param>
	/// <returns>筛选生成的新序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串序列为空。</exception>
	public static IEnumerable<string> WhereNotNullAndEmpty(this IEnumerable<string> source)
	{
		source.GuardNotNull("source");
		return source.Where((string x) => x.IsNotNullAndEmpty());
	}

	/// <summary>
	/// 将当前XML文本反序列化为指定类型的对象
	/// </summary>
	/// <param name="xml">当前XML文本</param>
	/// <param name="type">反序列化的目标类型</param>
	/// <returns>反序列化生成的目标类型的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前XML文本为空；或者目标类型 <paramref name="type" /> 为空。</exception>
	public static object XmlDeserialize(this string xml, Type type)
	{
		xml.GuardNotNull("xml");
		type.GuardNotNull("type");
		using StringReader reader = new StringReader(xml);
		XmlSerializer serializer = new XmlSerializer(type);
		return serializer.Deserialize(reader);
	}

	/// <summary>
	/// 将当前XML文本反序列化为指定类型的对象
	/// </summary>
	/// <param name="xml">当前XML文本</param>
	/// <param name="type">反序列化的目标类型</param>
	/// <param name="defaultValue">无法反序列化时返回的默认值</param>
	/// <returns>反序列化生成的目标类型的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前XML文本为空；或者目标类型 <paramref name="type" /> 为空。</exception>
	public static object XmlDeserialize(this string xml, Type type, object defaultValue)
	{
		xml.GuardNotNull("xml");
		type.GuardNotNull("type");
		try
		{
			return xml.XmlDeserialize(type);
		}
		catch
		{
			return defaultValue;
		}
	}

	/// <summary>
	/// 将当前XML文本反序列化为指定类型的对象
	/// </summary>
	/// <typeparam name="T">反序列化的目标类型</typeparam>
	/// <param name="xml">当前XML文本</param>
	/// <returns>反序列化生成的目标类型的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前XML文本为空。</exception>
	public static T XmlDeserialize<T>(this string xml)
	{
		xml.GuardNotNull("xml");
		return (T)xml.XmlDeserialize(typeof(T));
	}

	/// <summary>
	/// 将当前XML文本反序列化为指定类型的对象
	/// </summary>
	/// <typeparam name="T">反序列化的目标类型</typeparam>
	/// <param name="xml">当前XML文本</param>
	/// <param name="defaultValue">无法反序列化时返回的默认值</param>
	/// <returns>反序列化生成的目标类型的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前XML文本为空。</exception>
	public static T XmlDeserialize<T>(this string xml, T defaultValue)
	{
		xml.GuardNotNull("xml");
		return (T)xml.XmlDeserialize(typeof(T), defaultValue);
	}
}
