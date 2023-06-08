using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Richfit.Garnet.Common.Properties;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// <see cref="T:System.Char" /> 类型扩展方法类
///
/// 包括：
/// 1.Char类型的扩展方法
/// 2.Char类型数组或者泛型数组的扩展方法
/// </summary>
public static class CharExtensions
{
	/// <summary>
	/// 将当前字符按Ascii编码，编码为字节数据
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>编码生成的字节数据</returns>
	public static byte[] AsciiEncode(this char c)
	{
		return c.TextEncode(Encoding.ASCII);
	}

	/// <summary>
	/// 将当前字符数组按Ascii编码，编码为字节数据
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <returns>编码生成的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static byte[] AsciiEncode(this char[] cs)
	{
		return cs.TextEncode(Encoding.ASCII);
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
	public static byte[] AsciiEncode(this char[] cs, int start, int count)
	{
		return cs.TextEncode(start, count, Encoding.ASCII);
	}

	/// <summary>
	/// 将当前字符序列按Ascii编码，编码为的字节数据
	/// </summary>
	/// <param name="cs">当前字符序列</param>
	/// <returns>编码生成的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static byte[] AsciiEncode(this IEnumerable<char> cs)
	{
		return cs.TextEncode(Encoding.ASCII);
	}

	/// <summary>
	/// 创建内容为当前字符的字符串
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <param name="intern">是否对创建的字符串进行暂存</param>
	/// <returns>创建的字符串</returns>
	public static string BuildString(this char c, bool intern = false)
	{
		string s = new string(c, 1);
		return intern ? s.Intern() : s;
	}

	/// <summary>
	/// 创建内容为指定数量的当前字符的字符串
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <param name="count">当前字符的数量</param>
	/// <param name="intern">是否对创建的字符串进行暂存</param>
	/// <returns>创建的字符串</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">生成的字符数量 <paramref name="count" /> 小于0。</exception>
	public static string BuildString(this char c, int count, bool intern = false)
	{
		count.GuardGreaterThanOrEqualTo(0, "char count");
		string s = new string(c, count);
		return intern ? s.Intern() : s;
	}

	/// <summary>
	/// 创建内容为当前字符数组的字符串
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <param name="intern">是否对创建的字符串进行暂存</param>
	/// <returns>生成的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static string BuildString(this char[] cs, bool intern = false)
	{
		cs.GuardNotNull("char array");
		return cs.BuildString(0, cs.Length, intern);
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
	public static string BuildString(this char[] cs, int start, int count, bool intern = false)
	{
		cs.GuardNotNull("char array");
		start.GuardIndexRange(0, cs.Length - 1, "start");
		count.GuardBetween(0, cs.Length - start, "char count");
		int end = start + count;
		StringBuilder buff = new StringBuilder(count);
		for (int i = start; i < end; i++)
		{
			buff.Append(cs[i]);
		}
		return intern ? buff.ToString().Intern() : buff.ToString();
	}

	/// <summary>
	/// 创建内容为当前字符序列中字符的字符串
	/// </summary>
	/// <param name="cs">当前字符序列</param>
	/// <param name="intern">是否对创建的字符串进行暂存</param>
	/// <returns>生成的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符序列为空。</exception>
	public static string BuildString(this IEnumerable<char> cs, bool intern = false)
	{
		cs.GuardNotNull("char array");
		StringBuilder buff = new StringBuilder(512);
		foreach (char c in cs)
		{
			buff.Append(c);
		}
		return intern ? buff.ToString().Intern() : buff.ToString();
	}

	/// <summary>
	/// 将当前字符按字符常量的表示方式进行编码
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <param name="upperCase">编码后的字符串是否使用大写字母</param>
	/// <returns>字符常量形式的字符串表示</returns>
	public static string CharEncode(this char c, bool upperCase = false)
	{
		return "\\u" + c.GetRawBytes().HexEncode(upperCase);
	}

	/// <summary>
	/// 将当前字符数组中的字符按字符常量的表示方式进行编码
	/// </summary>
	/// <param name="chars">当前字符数组</param>
	/// <param name="upperCase">编码后的字符串是否使用大写字母</param>
	/// <returns>字符常量形式的字符串表示</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static string CharEncode(this char[] chars, bool upperCase = false)
	{
		chars.GuardNotNull("chars");
		return chars.GetRawBytes().ToHex(2, "\\u{0}", upperCase);
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
	public static string CharEncode(this char[] chars, int start, int count, bool upperCase = false)
	{
		chars.GuardNotNull("chars");
		return chars.GetRawBytes(start, count).ToHex(2, "\\u{0}", upperCase);
	}

	/// <summary>
	/// 将当前字符序列中的字符按字符常量的表示方式进行编码
	/// </summary>
	/// <param name="chars">当前字符序列</param>
	/// <param name="upperCase">编码后的字符串是否使用大写字母</param>
	/// <returns>字符常量形式的字符串表示</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static string CharEncode(this IEnumerable<char> chars, bool upperCase = false)
	{
		chars.GuardNotNull("chars");
		return chars.GetRawBytes().ToHex(2, "\\u{0}", upperCase);
	}

	/// <summary>
	/// 向当前字符数组中填充全角空格
	/// </summary>
	/// <param name="chars">当前字符数组</param>
	/// <returns>填充后的字符数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static char[] FillFullSpace(this char[] chars)
	{
		chars.GuardNotNull("chars");
		return chars.Fill('\u3000');
	}

	/// <summary>
	/// 向当前字符数组中填充空值（\0）
	/// </summary>
	/// <param name="chars">当前字符数组</param>
	/// <returns>填充后的字符数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static char[] FillNull(this char[] chars)
	{
		chars.GuardNotNull("chars");
		return chars.Fill('\0');
	}

	/// <summary>
	/// 向当前字符数组中填充空格
	/// </summary>
	/// <param name="chars">当前字符数组</param>
	/// <returns>填充后的字符数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static char[] FillSpace(this char[] chars)
	{
		chars.GuardNotNull("chars");
		return chars.Fill(' ');
	}

	/// <summary>
	/// 获取当前字符的位字节数组
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>当前字符的字节数组</returns>
	public static byte[] GetBytes(this char c)
	{
		return BitConverter.GetBytes(c);
	}

	/// <summary>
	/// 获取当前字符数组的位字节数组
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <returns>当前字符数组的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static byte[] GetBytes(this char[] cs)
	{
		cs.GuardNotNull("chars");
		return cs.GetBytes(0, cs.Length);
	}

	/// <summary>
	/// 获取当前字符数组的位字节数组
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <param name="start">开始转换的字符索引</param>
	/// <param name="count">转换的字符数量</param>
	/// <returns>当前字符数组的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的字符索引 <paramref name="start" /> 超出了当前字符数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的字符数量 <paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的字符数量。</exception>
	public static byte[] GetBytes(this char[] cs, int start, int count)
	{
		cs.GuardNotNull("chars");
		start.GuardIndexRange(0, cs.Length - 1, "start");
		count.GuardBetween(0, cs.Length - start, "count");
		List<byte> result = new List<byte>(count * 2);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			result.AddRange(cs[i].GetBytes());
		}
		return result.ToArray();
	}

	/// <summary>
	/// 获取当前字符序列的位字节数组
	/// </summary>
	/// <param name="cs">当前字符序列</param>
	/// <returns>当前字符序列的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符序列为空。</exception>
	public static byte[] GetBytes(this IEnumerable<char> cs)
	{
		cs.GuardNotNull("chars");
		return cs.SelectMany((char c) => c.GetBytes()).ToArray();
	}

	/// <summary>
	/// 获取当前字符的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>当前字符的 Big-Endian 顺序的位字节数组</returns>
	public static byte[] GetRawBytes(this char c)
	{
		byte[] bytes = BitConverter.GetBytes(c);
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(bytes);
			return bytes;
		}
		return bytes;
	}

	/// <summary>
	/// 获取当前字符数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <returns>当前字符数组的 Big-Endian 顺序的位字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static byte[] GetRawBytes(this char[] cs)
	{
		cs.GuardNotNull("chars");
		return cs.GetRawBytes(0, cs.Length);
	}

	/// <summary>
	/// 获取当前字符数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <param name="start">开始转换的字符的索引</param>
	/// <param name="count">转换的字符数量</param>
	/// <returns>当前字符数组的 Big-Endian 顺序的位字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的字符的索引 <paramref name="start" /> 超出了当前字符数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的字符数量 <paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的字符数量。</exception>
	public static byte[] GetRawBytes(this char[] cs, int start, int count)
	{
		cs.GuardNotNull("chars");
		start.GuardIndexRange(0, cs.Length - 1, "start");
		count.GuardBetween(0, cs.Length - start, "count");
		List<byte> bytes = new List<byte>(count * 2);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			bytes.AddRange(cs[i].GetRawBytes());
		}
		return bytes.ToArray();
	}

	/// <summary>
	/// 获取当前字符序列的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="cs">当前字符序列</param>
	/// <returns>当前字符序列的 Big-Endian 顺序的位字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符序列为空。</exception>
	public static byte[] GetRawBytes(this IEnumerable<char> cs)
	{
		cs.GuardNotNull("chars");
		return cs.SelectMany((char x) => x.GetRawBytes()).ToArray();
	}

	/// <summary>
	/// 将当前字符按GB2312编码（代码页936），编码为字节数据
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>编码生成的字节数据</returns>
	public static byte[] GB2312Encode(this char c)
	{
		return c.TextEncode(Encoding.GetEncoding(936));
	}

	/// <summary>
	/// 将当前字符数组按GB2312编码（代码页936），编码为字节数据
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <returns>编码生成的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static byte[] GB2312Encode(this char[] cs)
	{
		return cs.TextEncode(Encoding.GetEncoding(936));
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
	public static byte[] GB2312Encode(this char[] cs, int start, int count)
	{
		return cs.TextEncode(start, count, Encoding.GetEncoding(936));
	}

	/// <summary>
	/// 将当前字符序列按GB2312编码（代码页936），编码为的字节数据
	/// </summary>
	/// <param name="cs">当前字符序列</param>
	/// <returns>编码生成的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static byte[] GB2312Encode(this IEnumerable<char> cs)
	{
		return cs.TextEncode(Encoding.GetEncoding(936));
	}

	/// <summary>
	/// 获取当前字符所在的标识组
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>当前字符所在的标识组</returns>
	public static UnicodeCategory GetUnicodeCategory(this char c)
	{
		return char.GetUnicodeCategory(c);
	}

	/// <summary>
	/// 检测当前字符是否是Ascii字符
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果是Ascii字符返回true，否则返回false</returns>
	public static bool IsAscii(this char c)
	{
		return c <= '\u007f';
	}

	/// <summary>
	/// 检测当前字符是否是中文文字，不包括中文标点符号
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果当前字符是中文字符（不包括中文符号）返回true，否则返回false</returns>
	public static bool IsChineseCharacter(this char c)
	{
		return ((int)c).Between(19968, 40869);
	}

	/// <summary>
	/// 检测当前字符是否属于中文标点
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果当前字符是中文字符返回true，否则返回false</returns>
	public static bool IsChinesePunctuation(this char c)
	{
		int[] array = new int[31]
		{
			8317, 8318, 8333, 8334, 9001, 9002, 10181, 10182, 10748, 10749,
			11518, 11519, 11804, 11805, 12336, 12349, 12448, 12539, 64830, 64831,
			65123, 65128, 65130, 65131, 65306, 65307, 65311, 65312, 65343, 65371,
			65373
		};
		return ObjectExtensions.In(c, array) || ((int)c).Between(8208, 8231) || ((int)c).Between(8240, 8259) || ((int)c).Between(8261, 8273) || ((int)c).Between(8275, 8286) || ((int)c).Between(10088, 10101) || ((int)c).Between(10214, 10219) || ((int)c).Between(10627, 10648) || ((int)c).Between(10712, 10715) || ((int)c).Between(11513, 11516) || ((int)c).Between(11776, 11799) || ((int)c).Between(12289, 12291) || ((int)c).Between(12296, 12305) || ((int)c).Between(12308, 12319) || ((int)c).Between(43124, 43127) || ((int)c).Between(65040, 65049) || ((int)c).Between(65072, 65106) || ((int)c).Between(65108, 65121) || ((int)c).Between(65281, 65283) || ((int)c).Between(65285, 65290) || ((int)c).Between(65292, 65295) || ((int)c).Between(65339, 65341) || ((int)c).Between(65375, 65381);
	}

	/// <summary>
	/// 检测当前字符是否是CJK字符
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果当前字符是CJK字符返回true，否则返回false</returns>
	public static bool IsCJK(this char c)
	{
		return ((int)c).Between(11904, 65533);
	}

	/// <summary>
	/// 检测当前字符是否属于控制字符
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果当前字符是控制字符返回true，否则返回false</returns>
	/// <seealso cref="M:System.Char.IsControl(System.Char)" />
	public static bool IsControl(this char c)
	{
		return char.IsControl(c);
	}

	/// <summary>
	/// 检测当前字符是否属于十进制数字
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果当前字符是十进制数字返回true， 否则返回false</returns>
	/// <seealso cref="M:System.Char.IsDigit(System.Char)" />
	public static bool IsDigit(this char c)
	{
		return char.IsDigit(c);
	}

	/// <summary>
	/// 检查当前字符是否是英文字符（包括全角英文字符）
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果当前字符是英文字母则为true,否则为false</returns>
	public static bool IsEnglishLetter(this char c)
	{
		return ((int)c).Between(65, 90) || ((int)c).Between(97, 122) || ((int)c).Between(65313, 65338) || ((int)c).Between(65345, 65370);
	}

	/// <summary>
	/// 判断当前字符与指定的字符是否相等
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <param name="value">待比较的指定字符</param>
	/// <param name="ignoreCase">字符比较是否区分大小写</param>
	/// <returns>如果当前字符与指定字符相等则返回true，否则返回false。</returns>
	public static bool IsEqualTo(this char c, char value, bool ignoreCase)
	{
		return c.IsEqualTo(value, CultureInfo.CurrentCulture, ignoreCase);
	}

	/// <summary>
	/// 判断当前字符与指定的字符是否相等
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <param name="value">待比较的指定字符</param>
	/// <param name="comparison">字符比较设置</param>
	/// <returns>如果当前字符与指定字符相等则返回true，否则返回false。</returns>
	public static bool IsEqualTo(this char c, char value, StringComparison comparison)
	{
		return comparison switch
		{
			StringComparison.CurrentCulture => c.IsEqualTo(value, CultureInfo.CurrentCulture, ignoreCase: false), 
			StringComparison.CurrentCultureIgnoreCase => c.IsEqualTo(value, CultureInfo.CurrentCulture, ignoreCase: true), 
			StringComparison.InvariantCulture => c.IsEqualTo(value, CultureInfo.InvariantCulture, ignoreCase: false), 
			StringComparison.InvariantCultureIgnoreCase => c.IsEqualTo(value, CultureInfo.InvariantCulture, ignoreCase: true), 
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
	public static bool IsEqualTo(this char c, char value, CultureInfo culture, bool ignoreCase)
	{
		culture = culture.IfNull(CultureInfo.CurrentCulture);
		return ignoreCase ? c.ToUpper(culture).Equals(value.ToUpper(culture)) : c.Equals(value);
	}

	/// <summary>
	/// 判断当前字符与指定字符是否相等
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <param name="value">比较的指定字符</param>
	/// <param name="culture">字符比较时使用的区域信息；如果为空，则使用当前线程的区域信息。</param>
	/// <param name="options">字符比较选项</param>
	/// <returns>如果当前字符与指定字符相等则返回true，否则返回false。</returns>
	public static bool IsEqualTo(this char c, char value, CultureInfo culture, CompareOptions options)
	{
		return c.IsEqualTo(value, culture, options.HasFlag(CompareOptions.IgnoreCase));
	}

	/// <summary>
	/// 检测当前字符是否属于全角字符（全宽度字符）
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>以宋体字体显示当前字符时，字符宽度为全宽度（双字节），则返回true，否则返回false。对于非CJK字符集的语言字符（如阿拉伯语、泰语、梵语等），返回false。</returns>
	public static bool IsFullWidth(this char c)
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
		return ObjectExtensions.In(c, array) || ((int)c).Between(913, 937) || ((int)c).Between(945, 969) || ((int)c).Between(1040, 1105) || ((int)c).Between(4352, 4607) || ((int)c).Between(8352, 8364) || ((int)c).Between(8544, 8595) || ((int)c).Between(8598, 8601) || ((int)c).Between(9152, 9164) || ((int)c).Between(9312, 9547) || ((int)c).Between(9552, 9588) || ((int)c).Between(9601, 9615) || ((int)c).Between(9619, 9633) || ((int)c).Between(9728, 9784) || ((int)c).Between(9789, 9823) || ((int)c).Between(9985, 10239) || ((int)c).Between(11904, 12350) || ((int)c).Between(12352, 12687) || ((int)c).Between(12704, 19903) || ((int)c).Between(19936, 40959) || ((int)c).Between(43360, 43391) || ((int)c).Between(44032, 55295) || ((int)c).Between(63744, 64255) || ((int)c).Between(65040, 65055) || ((int)c).Between(65072, 65135) || ((int)c).Between(65281, 65376) || ((int)c).Between(65504, 65511);
	}

	/// <summary>
	/// 检测当前字符是否属于半角字符（半宽度字符）
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果当前字符是半角字符返回true，否则返回false</returns>
	public static bool IsHalfWidth(this char c)
	{
		return !c.IsFullWidth();
	}

	/// <summary>
	/// 检测当前字符是否属于高代理项
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果字符是高代理项返回true， 否则返回false</returns>
	public static bool IsHighSurrogate(this char c)
	{
		return char.IsHighSurrogate(c);
	}

	/// <summary>
	/// 检测当前字符是否是CJK象形字符
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果当前字符是CJK象形字符返回true，否则返回false</returns>
	public static bool IsIdeograph(this char c)
	{
		return ((int)c).Between(13312, 19893) || ((int)c).Between(19968, 40869) || ((int)c).Between(40870, 40891) || ((int)c).Between(63744, 64045) || ((int)c).Between(64048, 64106) || ((int)c).Between(64112, 64217);
	}

	/// <summary>
	/// 检测当前字符是否属于日文假名
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果当前字符属于日文假名返回true，否则返回false</returns>
	public static bool IsJapaneseKana(this char c)
	{
		return ((int)c).Between(12352, 12447) || ((int)c).Between(12448, 12543) || ((int)c).Between(12784, 12799) || ((int)c).Between(65382, 65439);
	}

	/// <summary>
	/// 检测当前字符是否属于字母类别
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果当前字符属于字母类别返回true，否则返回false</returns>
	/// <seealso cref="M:System.Char.IsLetter(System.Char)" />
	public static bool IsLetter(this char c)
	{
		return char.IsLetter(c);
	}

	/// <summary>
	/// 检测当前字符是否属于字母类别或者十进制数字
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果字符属于字母类别或者十进制数字返回true，否则返回false</returns>
	/// <seealso cref="M:System.Char.IsLetterOrDigit(System.Char)" />
	public static bool IsLetterOrDigit(this char c)
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
	public static bool IsLetterOrNumber(this char c)
	{
		return char.IsLetter(c) || char.IsNumber(c);
	}

	/// <summary>
	/// 检测当前字符是否属于小写字母类别
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果当前字符属于小写字母类别返回true，否则返回false</returns>
	/// <seealso cref="M:System.Char.IsLower(System.Char)" />
	public static bool IsLower(this char c)
	{
		return char.IsLower(c);
	}

	/// <summary>
	/// 检测当前字符是否为低代理项
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果当前字符属于小写字母类别返回true，否则返回false</returns>
	/// <seealso cref="M:System.Char.IsLowSurrogate(System.Char)" />
	public static bool IsLowSurrogate(this char c)
	{
		return char.IsLowSurrogate(c);
	}

	/// <summary>
	/// 检测当前字符是否属于数字字符
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果当前字符属于数字字符返回true，否则返回false</returns>
	/// <seealso cref="M:System.Char.IsNumber(System.Char)" />
	public static bool IsNumber(this char c)
	{
		return char.IsNumber(c);
	}

	/// <summary>
	/// 检测当前字符是否属于标点符号
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果字符属于标点符号返回true，否则返回false</returns>
	/// <seealso cref="M:System.Char.IsPunctuation(System.Char)" />
	public static bool IsPunctuation(this char c)
	{
		return char.IsPunctuation(c);
	}

	/// <summary>
	/// 检测当前字符是否属于分隔符
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果当前字符属于分隔符返回true，否则返回false</returns>
	public static bool IsSeparator(this char c)
	{
		return char.IsSeparator(c);
	}

	/// <summary>
	/// 检测当前字符是否属于代理项
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果当前字符属于代理项返回true，否则返回false</returns>
	public static bool IsSurrogate(this char c)
	{
		return char.IsSurrogate(c);
	}

	/// <summary>
	/// 检测当前字符和指定的字符是否形成代理项对
	/// </summary>
	/// <param name="hc">高代理项字符</param>
	/// <param name="lc">低代理项字符</param>
	/// <returns>如果两个字符形成代理项对返回true，否则返回false</returns>
	public static bool IsSurrogatePair(this char hc, char lc)
	{
		return char.IsSurrogatePair(hc, lc);
	}

	/// <summary>
	/// 检测当前字符是否属于符号字符类别
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果当前字符属于符号字符返回true，否则返回false</returns>
	public static bool IsSymbol(this char c)
	{
		return char.IsSymbol(c);
	}

	/// <summary>
	/// 检测当前字符是否是Unicode字符
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果是Unicode字符返回true,否则返回false</returns>
	/// <remarks>Unicode字符是不能直接转换为Ascii编码，必须转换为UTF-8等编码。</remarks>
	public static bool IsUnicode(this char c)
	{
		return !c.IsAscii();
	}

	/// <summary>
	/// 检测当前字符是否属于大写字母类别
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果当前字符属于符号字符返回true，否则返回false</returns>
	public static bool IsUpper(this char c)
	{
		return char.IsUpper(c);
	}

	/// <summary>
	/// 检测当前字符是否属于空白类别
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>如果当前字符属于空白类别返回true，否则返回false</returns>
	public static bool IsWhiteSpace(this char c)
	{
		return char.IsWhiteSpace(c);
	}

	/// <summary>
	/// 获取当前字符所表示的16进制的数值
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>当前字符表示的16进制数值</returns>
	/// <exception cref="T:System.ArgumentException">当前字符不是16进制数值字符。</exception>
	public static int ParseHex(this char c)
	{
		if ('A' <= c && c <= 'Z')
		{
			return c - 65 + 10;
		}
		if ('a' <= c && c <= 'z')
		{
			return c - 97 + 10;
		}
		if ('0' <= c && c <= '9')
		{
			return c - 48;
		}
		throw new ArgumentException(Literals.MSG_CharNotHexSymbol_1.FormatValue(c));
	}

	/// <summary>
	/// 获取当前字符所表示的数值
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>该字符表示数值</returns>
	/// <see cref="M:System.Char.GetNumericValue(System.Char)" />
	public static double ParseNumeric(this char c)
	{
		return char.GetNumericValue(c);
	}

	/// <summary>
	/// 获取当前字符数组中字符所表示的数值的数组
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <returns>字符所表示的数值的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	/// <seealso cref="M:System.Char.GetNumericValue(System.Char)" />
	public static double[] ParseNumeric(this char[] cs)
	{
		cs.GuardNotNull("chars");
		return cs.ParseNumeric(0, cs.Length);
	}

	/// <summary>
	/// 获取当前字符数组中指定范围内的字符所表示的数值的数组
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <param name="start">开始转换的字符索引</param>
	/// <param name="count">转换的字符数量</param>
	/// <returns>字符所表示的数值的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的字符索引 <paramref name="start" /> 超出了当前字符数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的字符数量 <paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的字符数量。</exception>
	/// <seealso cref="M:System.Char.GetNumericValue(System.Char)" />
	public static double[] ParseNumeric(this char[] cs, int start, int count)
	{
		cs.GuardNotNull("chars");
		start.GuardIndexRange(0, cs.Length - 1, "start");
		count.GuardBetween(0, cs.Length - start, "count");
		double[] result = new double[count];
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			result[i - start] = cs[i].ParseNumeric();
		}
		return result;
	}

	/// <summary>
	/// 获取当前字符序列中字符表示的数值的数组
	/// </summary>
	/// <param name="cs">当前字符序列</param>
	/// <returns>字符表示的数值的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	/// <seealso cref="M:System.Char.GetNumericValue(System.Char)" />
	public static IEnumerable<double> ParseNumeric(IEnumerable<char> cs)
	{
		cs.GuardNotNull("chars");
		return cs.Select((char c) => c.ParseNumeric());
	}

	/// <summary>
	/// 将当前字符按 <paramref name="encoding" /> 指定的编码，编码为字节数据
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <param name="encoding">转换使用的编码，默认使用 <see cref="P:System.Text.Encoding.UTF8" /> 编码</param>
	/// <returns>编码生成的字节数据</returns>
	public static byte[] TextEncode(this char c, Encoding encoding = null)
	{
		return encoding.IfNull(Encoding.UTF8).GetBytes(new char[1] { c });
	}

	/// <summary>
	/// 将当前字符数组按 <paramref name="encoding" /> 指定的编码，编码为字节数据
	/// </summary>
	/// <param name="chars">当前字符数组</param>
	/// <param name="encoding">转换使用的编码，默认使用 <see cref="P:System.Text.Encoding.UTF8" /> 编码</param>
	/// <returns>编码生成的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static byte[] TextEncode(this char[] chars, Encoding encoding = null)
	{
		chars.GuardNotNull("chars");
		return encoding.IfNull(Encoding.UTF8).GetBytes(chars);
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
	public static byte[] TextEncode(this char[] chars, int start, int count, Encoding encoding = null)
	{
		chars.GuardNotNull("chars");
		start.GuardIndexRange(0, chars.Length - 1, "start");
		count.GuardBetween(0, chars.Length - start, "count");
		return encoding.IfNull(Encoding.UTF8).GetBytes(chars, start, count);
	}

	/// <summary>
	/// 将当前字符序列按 <paramref name="encoding" /> 指定编码，编码为字节数据
	/// </summary>
	/// <param name="chars">当前字符序列</param>
	/// <param name="encoding">转换使用的编码，默认使用 <see cref="P:System.Text.Encoding.UTF8" /> 编码</param>
	/// <returns>编码生成的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空。</exception>
	public static byte[] TextEncode(this IEnumerable<char> chars, Encoding encoding = null)
	{
		chars.GuardNotNull("chars");
		encoding = encoding.IfNull(Encoding.UTF8);
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
	/// 将当前 <see cref="T:System.Char" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(this char value, bool upperCase = false)
	{
		return value.GetRawBytes().ToHex(upperCase);
	}

	/// <summary>
	/// 将当前 <see cref="T:System.Char" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="prefix">字符串前缀</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(this char value, string prefix, bool upperCase = false)
	{
		return value.GetRawBytes().ToHex(prefix, upperCase);
	}

	/// <summary>
	/// 将当前字符转换为小写形式
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <param name="culture">转换时使用的区域，为空则使用当前线程的区域特性进行转换</param>
	/// <returns>当前字符的小写形式</returns>
	public static char ToLower(this char c, CultureInfo culture = null)
	{
		return culture.IfNull(CultureInfo.CurrentCulture).TextInfo.ToLower(c);
	}

	/// <summary>
	/// 将当前字符数组中每个字符转换为小写形式
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <param name="culture">转换时使用的区域信息，为空则使用当前线程的区域特性进行转换</param>
	/// <returns>转换后的当前字符数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static char[] ToLower(this char[] cs, CultureInfo culture = null)
	{
		cs.GuardNotNull("chars");
		return cs.ToLower(0, cs.Length, culture);
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
	public static char[] ToLower(this char[] cs, int start, int count, CultureInfo culture = null)
	{
		cs.GuardNotNull("chars");
		start.GuardIndexRange(0, cs.Length - 1, "start");
		count.GuardBetween(0, cs.Length - start, "count");
		culture = culture.IfNull(CultureInfo.CurrentCulture);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			cs[i] = cs[i].ToLower(culture);
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
	public static IEnumerable<char> ToLower(this IEnumerable<char> cs, CultureInfo culture = null)
	{
		cs.GuardNotNull("chars");
		culture = culture.IfNull(CultureInfo.CurrentCulture);
		return cs.Select((char c) => c.ToLower(culture));
	}

	/// <summary>
	/// 将当前字符转换为由指定数量的当前字符组成的字符串
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <param name="count">生成的字符的数量</param>
	/// <returns>生成的字符串</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">生成的字符数量 <paramref name="count" /> 小于0。</exception>
	public static string ToString(this char c, int count)
	{
		return c.BuildString(count);
	}

	/// <summary>
	/// 将当前字符数组转换为由字符数组指定范围内的字符组成的字符串
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <param name="start">开始转换的字符索引</param>
	/// <returns>生成的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始的转换的字符索引 <paramref name="start" /> 小于，或则大于当前字符数组的最大索引数量。</exception>
	public static string ToString(this char[] cs, int start)
	{
		cs.GuardNotNull("chars");
		return cs.BuildString(start, cs.Length - start);
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
	public static string ToString(this char[] cs, int start, int count)
	{
		return cs.BuildString(start, count);
	}

	/// <summary>
	/// 将当前字符转换为大写形式
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <param name="culture">转换时使用的区域，为空则使用当前线程的区域特性进行转换</param>
	/// <returns>当前字符的大写形式</returns>
	public static char ToUpper(this char c, CultureInfo culture = null)
	{
		return culture.IfNull(CultureInfo.CurrentCulture).TextInfo.ToUpper(c);
	}

	/// <summary>
	/// 将当前字符数组中的字符转换为大写形式
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <param name="culture">转换时使用的区域，为空则使用当前线程的区域特性进行转换</param>
	/// <returns>转换后的当前字符数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static char[] ToUpper(this char[] cs, CultureInfo culture = null)
	{
		cs.GuardNotNull("chars");
		return cs.ToUpper(0, cs.Length, culture);
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
	public static char[] ToUpper(this char[] cs, int start, int count, CultureInfo culture = null)
	{
		cs.GuardNotNull("chars");
		start.GuardIndexRange(0, cs.Length - 1, "start");
		count.GuardBetween(0, cs.Length - count, "count");
		culture = culture.IfNull(CultureInfo.CurrentCulture);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			cs[i] = cs[i].ToUpper(culture);
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
	public static IEnumerable<char> ToUpper(this IEnumerable<char> cs, CultureInfo culture = null)
	{
		cs.GuardNotNull("chars");
		return cs.Select((char c) => c.ToUpper(culture));
	}

	/// <summary>
	/// 将当前字符按Unicode编码，编码为字节数据
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>编码生成的字节数据</returns>
	public static byte[] UnicodeEncode(this char c)
	{
		return c.TextEncode(Encoding.Unicode);
	}

	/// <summary>
	/// 将当前字符数组按Unicode编码，编码为字节数据
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <returns>编码生成的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static byte[] UnicodeEncode(this char[] cs)
	{
		return cs.TextEncode(Encoding.Unicode);
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
	public static byte[] UnicodeEncode(this char[] cs, int start, int count)
	{
		return cs.TextEncode(start, count, Encoding.Unicode);
	}

	/// <summary>
	/// 将当前字符序列按Unicode编码，编码为的字节数据
	/// </summary>
	/// <param name="cs">当前字符序列</param>
	/// <returns>编码生成的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static byte[] UnicodeEncode(this IEnumerable<char> cs)
	{
		return cs.TextEncode(Encoding.Unicode);
	}

	/// <summary>
	/// 将当前字符数组编码为Url编码的字符串
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <param name="encoding">转换使用的编码，默认使用UTF-8编码</param>
	/// <returns>编码生成的字节数据</returns>
	public static string UrlEncode(this char c, Encoding encoding = null)
	{
		return c.ToString().UrlEncode(encoding);
	}

	/// <summary>
	/// 将当前字符数组编码为Url编码的字符串
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <param name="encoding">转换使用的编码，默认使用UTF-8编码</param>
	/// <returns>编码生成的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static string UrlEncode(this char[] cs, Encoding encoding = null)
	{
		cs.GuardNotNull("chars");
		return new string(cs).UrlEncode(encoding);
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
	public static string UrlEncode(this char[] cs, int start, int count, Encoding encoding = null)
	{
		cs.GuardNotNull("chars");
		start.GuardIndexRange(0, cs.Length - 1, "start");
		count.GuardBetween(0, cs.Length - start, "count");
		return new string(cs, start, count).UrlEncode(encoding);
	}

	/// <summary>
	/// 将当前字符序列转换为Url编码的字符串
	/// </summary>
	/// <param name="cs">当前字符序列</param>
	/// <param name="encoding">转换使用的编码，默认使用UTF-8编码</param>
	/// <returns>编码生成的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static string UrlEncode(this IEnumerable<char> cs, Encoding encoding = null)
	{
		cs.GuardNotNull("chars");
		return cs.ToArray().UrlEncode(encoding);
	}

	/// <summary>
	/// 将当前字符数组编码为Url编码的字节数据
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <param name="encoding">转换使用的编码，默认使用UTF-8编码</param>
	/// <returns>编码生成的字节数据</returns>
	public static byte[] UrlEncodeToBytes(this char c, Encoding encoding = null)
	{
		return c.ToString().UrlEncodeToBytes(encoding);
	}

	/// <summary>
	/// 将当前字符数组编码为Url编码的字节数据
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <param name="encoding">转换使用的编码，默认使用UTF-8编码</param>
	/// <returns>编码生成的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static byte[] UrlEncodeToBytes(this char[] cs, Encoding encoding = null)
	{
		cs.GuardNotNull("chars");
		return new string(cs).UrlEncodeToBytes(encoding);
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
	public static byte[] UrlEncodeToBytes(this char[] cs, int start, int count, Encoding encoding = null)
	{
		cs.GuardNotNull("chars");
		start.GuardIndexRange(0, cs.Length - 1, "start");
		count.GuardBetween(0, cs.Length - start, "count");
		return new string(cs, start, count).UrlEncodeToBytes(encoding);
	}

	/// <summary>
	/// 将当前字符序列编码为Url编码的字节数据
	/// </summary>
	/// <param name="cs">当前字符序列</param>
	/// <param name="encoding">字符编码</param>
	/// <returns>编码生成的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static byte[] UrlEncodeToBytes(this IEnumerable<char> cs, Encoding encoding = null)
	{
		cs.GuardNotNull("chars");
		return cs.ToArray().UrlEncodeToBytes(encoding);
	}

	/// <summary>
	/// 将当前字符按UTF-8编码，编码为字节数据
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>编码生成的字节数据</returns>
	public static byte[] Utf8Encode(this char c)
	{
		return c.TextEncode(Encoding.UTF8);
	}

	/// <summary>
	/// 将当前字符数组按UTF-8编码，编码为字节数据
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <returns>编码生成的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static byte[] Utf8Encode(this char[] cs)
	{
		return cs.TextEncode(Encoding.UTF8);
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
	public static byte[] Utf8Encode(this char[] cs, int start, int count)
	{
		return cs.TextEncode(start, count, Encoding.UTF8);
	}

	/// <summary>
	/// 将当前字符序列按UTF-8编码，编码为的字节数据
	/// </summary>
	/// <param name="cs">当前字符序列</param>
	/// <returns>编码生成的字节数据</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static byte[] Utf8Encode(this IEnumerable<char> cs)
	{
		return cs.TextEncode(Encoding.UTF8);
	}
}
