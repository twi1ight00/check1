using System.IO;
using System.Text.RegularExpressions;

namespace Richfit.Garnet.Common.Text;

/// <summary>
/// 常用正则表达式集合
/// </summary>
public static class RegexPatterns
{
	private const string ChineseSymbolPattern = "[\\u2010-\\u2027\\u2030-\\u2043\\u2045-\\u2051\\u2053-\\u205E\\u207D\\u207E\\u208D\\u208E\\u2329\\u232A\\u2768-\\u2775\\u27C5\\u27C6\\u27E6-\\u27EB\\u2983-\\u2998\\u29D8-\\u29DB\\u29FC\\u29FD\\u2CF9-\\u2CFC\\u2CFE\\u2CFF\\u2E00-\\u2E17\\u2E1C\\u2E1D\\u3001-\\u3003\\u3008-\\u3011\\u3014-\\u301F\\u3030\\u303D\\u30A0\\u30FB\\u4E00-\\u9FFF\\uA874-\\uA877\\uFD3E\\uFD3F\\uFE10-\\uFE1F\\uFE30-\\uFE52\\uFE54-\\uFE61\\uFE63\\uFE68\\uFE6A\\uFE6B\\uFF01-\\uFF03\\uFF05-\\uFF0A\\uFF0C-\\uFF0F\\uFF1A\\uFF1B\\uFF1F\\uFF20\\uFF3B-\\uFF3D\\uFF3F\\uFF5B\\uFF5D\\uFF5F-\\uFF65]";

	private const string CJKCharacterPattern = "[\\p{IsCJKUnifiedIdeographsExtensionA}\\p{IsCJKUnifiedIdeographs}\\p{IsCJKCompatibilityIdeographs}]";

	private const string CJKSymbolPattern = "[\\p{IsCJKRadicalsSupplement}\\p{IsKangxiRadicals}\\p{IsIdeographicDescriptionCharacters}\\p{IsCJKSymbolsandPunctuation}\\p{IsHiragana}\\p{IsKatakana}\\p{IsBopomofo}\\p{IsBopomofoExtended}\\p{IsKatakanaPhoneticExtensions}\\p{IsEnclosedCJKLettersandMonths}\\p{IsCJKCompatibility}\\p{IsCJKUnifiedIdeographsExtensionA}\\p{IsCJKUnifiedIdeographs}\\p{IsCJKCompatibilityIdeographs}\\p{IsCJKCompatibilityForms}\\p{IsSmallFormVariants}\\p{IsHalfwidthandFullwidthForms}]";

	private const string NonChineseSymbolPattern = "[^\\u2010-\\u2027\\u2030-\\u2043\\u2045-\\u2051\\u2053-\\u205E\\u207D\\u207E\\u208D\\u208E\\u2329\\u232A\\u2768-\\u2775\\u27C5\\u27C6\\u27E6-\\u27EB\\u2983-\\u2998\\u29D8-\\u29DB\\u29FC\\u29FD\\u2CF9-\\u2CFC\\u2CFE\\u2CFF\\u2E00-\\u2E17\\u2E1C\\u2E1D\\u3001-\\u3003\\u3008-\\u3011\\u3014-\\u301F\\u3030\\u303D\\u30A0\\u30FB\\u4E00-\\u9FFF\\uA874-\\uA877\\uFD3E\\uFD3F\\uFE10-\\uFE1F\\uFE30-\\uFE52\\uFE54-\\uFE61\\uFE63\\uFE68\\uFE6A\\uFE6B\\uFF01-\\uFF03\\uFF05-\\uFF0A\\uFF0C-\\uFF0F\\uFF1A\\uFF1B\\uFF1F\\uFF20\\uFF3B-\\uFF3D\\uFF3F\\uFF5B\\uFF5D\\uFF5F-\\uFF65]";

	/// <summary>
	/// 匹配一个中国手机电话号码模式字符串的正则对象
	/// (?:13\d|14\d|15\d|18\d)[ -]?\d{4}[ -]?\d{4}
	/// </summary>
	/// <remarks>中国手机电话号码；11位，不包括国际区号，支持13x/14x/15x/18x号段。</remarks>
	/// <example>
	/// 13012345678
	/// 130 1234 5678
	/// 130-1234-5678
	/// </example>
	public static readonly Regex ChinaMobilePhoneCode = new Regex("(?:13\\d|14\\d|15\\d|18\\d)[ -]?\\d{4}[ -]?\\d{4}", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个带国际区号的中国手机电话号码模式字符串的正则对象
	/// (?:(\+86)[ ]?)?((?:13\d|14\d|15\d|18\d)[ -]?\d{4}[ -]?\d{4})
	/// </summary>
	/// <remarks>中国手机电话号码；11位，包括国际区号+86，支持13x/14x/15x/18x号段</remarks>
	/// <example>
	/// +86 13012345678
	/// +86 130 1234 5678
	/// +86 130-1234-5678
	/// </example>
	public static readonly Regex ChinaMobilePhoneCodeWithIndex = new Regex("(?:(\\+86)[ ]?)?((?:13\\d|14\\d|15\\d|18\\d)[ -]?\\d{4}[ -]?\\d{4})", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个中国固定电话号码模式字符串的正则对象
	/// (?:(?:(\d{3,5})[ -]?)|(?:\((\d{3,5})\)[ ]?))?(\d{7,8})
	/// </summary>
	/// <example>
	/// 010 123456789
	/// 010-123456789
	/// (010)123456789
	/// (010) 123456789
	/// </example>
	public static readonly Regex ChinaPhoneCode = new Regex("(?:(?:(\\d{3,5})[ -]?)|(?:\\((\\d{3,5})\\)[ ]?))?(\\d{7,8})", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个中国邮政编码模式字符串的正则对象
	/// \d{6}
	/// </summary>
	/// <example>
	/// 100007
	/// </example>
	public static readonly Regex ChinaPostalCode = new Regex("\\d{6}", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个布尔型数值字符串模式的正则对象
	/// \b(T|true|F|false|Y|yes|N|no)\b
	/// </summary>
	public static readonly Regex Boolean = new Regex("\\b(T|true|F|false|Y|yes|N|no)\\b", RegexOptions.IgnoreCase | RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个布尔型数值真值字符串模式的正则对象
	/// \b(T|true|Y|yes)\b
	/// </summary>
	public static readonly Regex BooleanTrue = new Regex("\\b(T|true|Y|yes)\\b", RegexOptions.IgnoreCase | RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个布尔型数值假值字符串模式的正则对象
	/// \b(F|false|N|no)\b
	/// </summary>
	public static readonly Regex BooleanFalse = new Regex("\\b(F|false|N|no)\\b", RegexOptions.IgnoreCase | RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个Guid字符串模式字符串的正则对象
	/// 0-9a-fA-F]{32}|[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}|\{[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}\}|\([0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}\)|\{0[xX][0-9a-fA-F]{8},0[xX][0-9a-fA-F]{4},0[xX][0-9a-fA-F]{4},\{0[xX][0-9a-fA-F]{2},0[xX][0-9a-fA-F]{2},0[xX][0-9a-fA-F]{2},0[xX][0-9a-fA-F]{2},0[xX][0-9a-fA-F]{2},0[xX][0-9a-fA-F]{2},0[xX][0-9a-fA-F]{2},0[xX][0-9a-fA-F]{2}\}\}
	/// </summary>
	public static readonly Regex Guid = new Regex("[0-9a-fA-F]{32}|[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}|\\{[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}\\}|\\([0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}\\)|\\{0[xX][0-9a-fA-F]{8},0[xX][0-9a-fA-F]{4},0[xX][0-9a-fA-F]{4},\\{0[xX][0-9a-fA-F]{2},0[xX][0-9a-fA-F]{2},0[xX][0-9a-fA-F]{2},0[xX][0-9a-fA-F]{2},0[xX][0-9a-fA-F]{2},0[xX][0-9a-fA-F]{2},0[xX][0-9a-fA-F]{2},0[xX][0-9a-fA-F]{2}\\}\\}", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个'N'格式的Guid字符串模式字符串的正则对象
	/// [0-9a-fA-F]{32}
	/// </summary>
	/// <example>ABcd1234567890123456789012345678</example>
	public static readonly Regex GuidN = new Regex("[0-9a-fA-F]{32}", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个'D'格式的Guid字符串模式字符串的正则对象
	/// ([0-9a-fA-F]{8})-([0-9a-fA-F]{4})-([0-9a-fA-F]{4})-([0-9a-fA-F]{4})-([0-9a-fA-F]{12})
	/// </summary>
	/// <example>ABcd1234-Aa12-Aa12-Aa12-ABcd12345678</example>
	public static readonly Regex GuidD = new Regex("([0-9a-fA-F]{8})-([0-9a-fA-F]{4})-([0-9a-fA-F]{4})-([0-9a-fA-F]{4})-([0-9a-fA-F]{12})", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个'B'格式的Guid字符串模式字符串的正则对象
	/// \{([0-9a-fA-F]{8})-([0-9a-fA-F]{4})-([0-9a-fA-F]{4})-([0-9a-fA-F]{4})-([0-9a-fA-F]{12})\}
	/// </summary>
	/// <example>{ABcd1234-Aa12-Aa12-Aa12-ABcd12345678}</example>
	public static readonly Regex GuidB = new Regex("\\{([0-9a-fA-F]{8})-([0-9a-fA-F]{4})-([0-9a-fA-F]{4})-([0-9a-fA-F]{4})-([0-9a-fA-F]{12})\\}", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个'P'格式的Guid字符串模式字符串的正则对象
	/// \(([0-9a-fA-F]{8})-([0-9a-fA-F]{4})-([0-9a-fA-F]{4})-([0-9a-fA-F]{4})-([0-9a-fA-F]{12})\)
	/// </summary>
	/// <example>(ABcd1234-Aa12-Aa12-Aa12-ABcd12345678)</example>
	public static readonly Regex GuidP = new Regex("\\(([0-9a-fA-F]{8})-([0-9a-fA-F]{4})-([0-9a-fA-F]{4})-([0-9a-fA-F]{4})-([0-9a-fA-F]{12})\\)", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个'X'格式的Guid字符串模式字符串的正则对象
	/// \{0[xX]([0-9a-fA-F]{8}),0[xX]([0-9a-fA-F]{4}),0[xX]([0-9a-fA-F]{4}),\{0[xX]([0-9a-fA-F]{2}),0[xX]([0-9a-fA-F]{2}),0[xX]([0-9a-fA-F]{2}),0[xX]([0-9a-fA-F]{2}),0[xX]([0-9a-fA-F]{2}),0[xX]([0-9a-fA-F]{2}),0[xX]([0-9a-fA-F]{2}),0[xX]([0-9a-fA-F]{2})\}\}
	/// </summary>
	/// <example>{0xABcd1234,0xAa12,0xAa12,{0xA1,0xA1,0xA1,0xA1,0xb2,0xb2,0xb2,0xb2}}</example>
	public static readonly Regex GuidX = new Regex("\\{0[xX]([0-9a-fA-F]{8}),0[xX]([0-9a-fA-F]{4}),0[xX]([0-9a-fA-F]{4}),\\{0[xX]([0-9a-fA-F]{2}),0[xX]([0-9a-fA-F]{2}),0[xX]([0-9a-fA-F]{2}),0[xX]([0-9a-fA-F]{2}),0[xX]([0-9a-fA-F]{2}),0[xX]([0-9a-fA-F]{2}),0[xX]([0-9a-fA-F]{2}),0[xX]([0-9a-fA-F]{2})\\}\\}", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个支持正负号的定点数模式字符串的正则对象
	/// [+-]?(\d+)(?:\.(\d+))?
	/// </summary>
	/// <example>
	/// 999
	/// +999
	/// -999
	/// 999.999
	/// +999.999
	/// -999.999
	/// 0.999
	/// +0.999
	/// -0.999
	/// </example>
	public static readonly Regex FixedPointNumber = new Regex("[+-]?(\\d+)(?:\\.(\\d+))?", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个支持正负号的整数模式字符串的正则对象
	/// [+-]?(\d+)
	/// </summary>
	/// <example>
	/// 999
	/// +999
	/// -999
	/// </example>
	public static readonly Regex Integer = new Regex("[+-]?(\\d+)", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个科学计数法的字符串模式字符串的正则对象
	/// (([+-])?(\d*)(?:\.(\d+))?)[Ee]([+-]?\d+)?
	/// </summary>
	/// <example>
	/// 0E0
	/// 0.123E100
	/// +0.123E+100
	/// -0.123E-100
	/// .0E0
	/// .123E-100
	/// </example>
	public static readonly Regex ExponentialNumber = new Regex("(([+-])?(\\d*)(?:\\.(\\d+))?)[Ee]([+-]?\\d+)?", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个十六进制字符值前缀字符串模式字符串的正则对象
	/// ^\s*(0[xX]|&amp;[hH]|\\[uU]|\\[xX])
	/// </summary>
	public static readonly Regex HexCharPrefix = new Regex("^\\s*(0[xX]|&[hH]|\\\\[uU]|\\\\[xX])", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个十六进制数值前缀字符串模式字符串的正则对象
	/// ^\s*(0[xX]|&amp;[hH])
	/// </summary>
	public static readonly Regex HexNumberPrefix = new Regex("^\\s*(0[xX]|&[hH])", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个十六进制数值字符串模式字符串的正则对象
	/// (0[xX]|&amp;[hH])?([a-fA-F0-9]+)
	/// </summary>
	/// <example><![CDATA[
	/// 0x01Ff
	/// 0X01ff
	/// &h01Ff
	/// &H01Ff
	/// 01ff
	/// ]]></example>
	public static readonly Regex HexNumber = new Regex("(0[xX]|&[hH])?([a-fA-F0-9]+)", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个Html标记模式字符串的正则对象
	/// &lt;[^&gt;]*&gt;
	/// </summary>
	public static readonly Regex HtmlTag = new Regex("<[^>]*>", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个电子邮件模式字符串的正则对象
	/// (?:[0-9a-zA-Z]+[-._+&amp;])*[0-9a-zA-Z]+@(?:[-0-9a-zA-Z]+\.)+[a-zA-Z]{2,6}
	/// </summary>
	public static readonly Regex Email = new Regex("(?:[0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@(?:[-0-9a-zA-Z]+\\.)+[a-zA-Z]{2,6}", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个Url地址模式字符串的正则对象
	/// (ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_=]*)?
	/// </summary>
	public static readonly Regex Url = new Regex("(ht|f)tp(s?)\\:\\/\\/[0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*(:(0-9)*)*(\\/?)([a-zA-Z0-9\\-\\.\\?\\,\\'\\/\\\\\\+&%\\$#_=]*)?", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个Url地址协议模式字符串的正则对象
	/// (\w+://)(?:/*)(.*)
	/// </summary>
	/// <remarks>
	/// 包含两个捕获组
	/// 1：协议前缀
	/// 2：Url剩余部分
	/// </remarks>
	public static readonly Regex UrlProtocol = new Regex("(\\w+://)(?:/*)(.*)", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个JSON的基本模式字符串的正则对象
	/// \s*\[.*\]\s*|\s*\{.*\}\s*
	/// </summary>
	public static readonly Regex Json = new Regex("\\s*\\[.*\\]\\s*|\\s*\\{.*\\}\\s*", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个JSON数组模式模式字符串的正则对象
	/// \s*\[.*\]\s*
	/// </summary>
	public static readonly Regex JsonArray = new Regex("\\s*\\[.*\\]\\s*", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个JSON对象模式模式字符串的正则对象
	/// \s*\{.*\}\s*
	/// </summary>
	public static readonly Regex JsonObject = new Regex("\\s*\\{.*\\}\\s*", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个ASCII字符模式字符串的正则对象
	/// \p{IsBasicLatin}
	/// </summary>
	public static readonly Regex Ascii = new Regex("\\p{IsBasicLatin}", RegexOptions.Compiled);

	/// <summary>
	/// 匹配零个或者多个ASCII字符模式字符串的正则对象
	/// \p{IsBasicLatin}*
	/// </summary>
	public static readonly Regex AsciiAny = new Regex("\\p{IsBasicLatin}*", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个或者多个ASCII字符模式字符串的正则对象
	/// \p{IsBasicLatin}+
	/// </summary>
	public static readonly Regex AsciiMore = new Regex("\\p{IsBasicLatin}+", RegexOptions.Compiled);

	/// <summary>
	/// 匹配零个或者一个ASCII字符模式字符串的正则对象
	/// \p{IsBasicLatin}?
	/// </summary>
	public static readonly Regex AsciiOne = new Regex("\\p{IsBasicLatin}?", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个大小写英文字母模式字符串的正则对象
	/// [a-zA-Z]
	/// </summary>
	public static readonly Regex Alpha = new Regex("[a-zA-Z]", RegexOptions.Compiled);

	/// <summary>
	/// 匹配零个或者多个大小写英文字母模式字符串的正则对象
	/// [a-zA-Z]*
	/// </summary>
	public static readonly Regex AlphaAny = new Regex("[a-zA-Z]*", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个或者多个大小写英文字母模式字符串的正则对象
	/// [a-zA-Z]+
	/// </summary>
	public static readonly Regex AlphaMore = new Regex("[a-zA-Z]+", RegexOptions.Compiled);

	/// <summary>
	/// 匹配零个或者一个大小写英文字母模式字符串的正则对象
	/// [a-zA-Z]?
	/// </summary>
	public static readonly Regex AlphaOne = new Regex("[a-zA-Z]?", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个大写英文字母模式字符串的正则对象
	/// [A-Z]
	/// </summary>
	public static readonly Regex AlphaUpperCase = new Regex("[A-Z]", RegexOptions.Compiled);

	/// <summary>
	/// 匹配零个或者多个大写英文字母模式字符串的正则对象
	/// [A-Z]*
	/// </summary>
	public static readonly Regex AlphaUpperCaseAny = new Regex("[A-Z]*", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个或者多个大写英文字母模式字符串的正则对象
	/// [A-Z]+
	/// </summary>
	public static readonly Regex AlphaUpperCaseMore = new Regex("[A-Z]+", RegexOptions.Compiled);

	/// <summary>
	/// 匹配零个或者一个大写英文字母模式字符串的正则对象
	/// [A-Z]?
	/// </summary>
	public static readonly Regex AlphaUpperCaseOne = new Regex("[A-Z]?", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个小写英文字母模式字符串的正则对象
	/// [a-z]
	/// </summary>
	public static readonly Regex AlphaLowerCase = new Regex("[a-z]", RegexOptions.Compiled);

	/// <summary>
	/// 匹配零个或者多个小写英文字母模式字符串的正则对象
	/// [a-z]*
	/// </summary>
	public static readonly Regex AlphaLowerCaseAny = new Regex("[a-z]*", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个或者多个小写英文字母模式字符串的正则对象
	/// [a-z]+
	/// </summary>
	public static readonly Regex AlphaLowerCaseMore = new Regex("[a-z]+", RegexOptions.Compiled);

	/// <summary>
	/// 匹配零个或者一个小写英文字母模式字符串的正则对象
	/// [a-z]?
	/// </summary>
	public static readonly Regex AlphaLowerCaseOne = new Regex("[a-z]?", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个大小写英文字母和数字模式字符串的正则对象
	/// [a-zA-Z0-9]
	/// </summary>
	public static readonly Regex AlphaDigit = new Regex("[a-zA-Z0-9]", RegexOptions.Compiled);

	/// <summary>
	/// 匹配零个或者多个大小写英文字母和数字模式字符串的正则对象
	/// [a-zA-Z0-9]*
	/// </summary>
	public static readonly Regex AlphaDigitAny = new Regex("[a-zA-Z0-9]*", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个或者多个大小写英文字母和数字模式字符串的正则对象
	/// [a-zA-Z0-9]+
	/// </summary>
	public static readonly Regex AlphaDigitMore = new Regex("[a-zA-Z0-9]+", RegexOptions.Compiled);

	/// <summary>
	/// 匹配零个或者一个大小写英文字母和数字模式字符串的正则对象
	/// [a-zA-Z0-9]?
	/// </summary>
	public static readonly Regex AlphaDigitOne = new Regex("[a-zA-Z0-9]?", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个大小写英文字母、数字和空格模式字符串的正则对象
	/// [a-zA-Z0-9\u0020]
	/// </summary>
	public static readonly Regex AlphaDigitSpace = new Regex("[a-zA-Z0-9\\u0020]", RegexOptions.Compiled);

	/// <summary>
	/// 匹配零个或者多个大小写英文字母、数字和空格模式字符串的正则对象
	/// [a-zA-Z0-9\u0020]*
	/// </summary>
	public static readonly Regex AlphaDigitSpaceAny = new Regex("[a-zA-Z0-9\\u0020]*", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个或者多个大小写英文字母、数字和空格模式字符串的正则对象
	/// [a-zA-Z0-9\u0020]+
	/// </summary>
	public static readonly Regex AlphaDigitSpaceMore = new Regex("[a-zA-Z0-9\\u0020]+", RegexOptions.Compiled);

	/// <summary>
	/// 匹配零个或者一个大小写英文字母、数字和空格模式字符串的正则对象
	/// [a-zA-Z0-9\u0020]?
	/// </summary>
	public static readonly Regex AlphaDigitSpaceOne = new Regex("[a-zA-Z0-9\\u0020]?", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个大小写英文字母、数字和空白字符模式字符串的正则对象
	/// [a-zA-Z0-9\s]
	/// </summary>
	public static readonly Regex AlphaDigitWhiteSpace = new Regex("[a-zA-Z0-9\\s]", RegexOptions.Compiled);

	/// <summary>
	/// 匹配零个或者多个大小写英文字母、数字和空白字符模式字符串的正则对象
	/// [a-zA-Z0-9\s]*
	/// </summary>
	public static readonly Regex AlphaDigitWhiteSpaceAny = new Regex("[a-zA-Z0-9\\s]*", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个或者多个大小写英文字母、数字和空白字符模式字符串的正则对象
	/// [a-zA-Z0-9\s]+
	/// </summary>
	public static readonly Regex AlphaDigitWhiteSpaceMore = new Regex("[a-zA-Z0-9\\s]+", RegexOptions.Compiled);

	/// <summary>
	/// 匹配零个或者一个大小写英文字母、数字和空白字符模式字符串的正则对象
	/// [a-zA-Z0-9\s]?
	/// </summary>
	public static readonly Regex AlphaDigitWhiteSpaceOne = new Regex("[a-zA-Z0-9\\s]?", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个大小写英文字母、数字、空格、中划线模式字符串的正则对象
	/// [a-zA-Z0-9\u0020\-]
	/// </summary>
	public static readonly Regex AlphaDigitSpaceDash = new Regex("[a-zA-Z0-9\\u0020\\-]", RegexOptions.Compiled);

	/// <summary>
	/// 匹配零个或者多个大小写英文字母、数字、空格、中划线模式字符串的正则对象
	/// [a-zA-Z0-9\u0020\-]*
	/// </summary>
	public static readonly Regex AlphaDigitSpaceDashAny = new Regex("[a-zA-Z0-9\\u0020\\-]*", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个或者多个大小写英文字母、数字、空格、中划线模式字符串的正则对象
	/// [a-zA-Z0-9\u0020\-]+
	/// </summary>
	public static readonly Regex AlphaDigitSpaceDashMore = new Regex("[a-zA-Z0-9\\u0020\\-]+", RegexOptions.Compiled);

	/// <summary>
	/// 匹配零个或者一个大小写英文字母、数字、空格、中划线模式字符串的正则对象
	/// [a-zA-Z0-9\u0020\-]?
	/// </summary>
	public static readonly Regex AlphaDigitSpaceDashOne = new Regex("[a-zA-Z0-9\\u0020\\-]?", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个大小写英文字母、数字、空格、中划线模式字符串的正则对象
	/// [a-zA-Z0-9\u0020\-_]
	/// </summary>
	public static readonly Regex AlphaDigitSpaceDashUnderscore = new Regex("[a-zA-Z0-9\\u0020\\-_]", RegexOptions.Compiled);

	/// <summary>
	/// 匹配零个或者多个大小写英文字母、数字、空格、中划线模式字符串的正则对象
	/// [a-zA-Z0-9\u0020\-_]*
	/// </summary>
	public static readonly Regex AlphaDigitSpaceDashUnderscoreAny = new Regex("[a-zA-Z0-9\\u0020\\-_]*", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个或者多个大小写英文字母、数字、空格、中划线模式字符串的正则对象
	/// [a-zA-Z0-9\u0020\-_]+
	/// </summary>
	public static readonly Regex AlphaDigitSpaceDashUnderscoreMore = new Regex("[a-zA-Z0-9\\u0020\\-_]+", RegexOptions.Compiled);

	/// <summary>
	/// 匹配零个或者一个大小写英文字母、数字、空格、中划线模式字符串的正则对象
	/// [a-zA-Z0-9\u0020\-_]?
	/// </summary>
	public static readonly Regex AlphaDigitSpaceDashUnderscoreOne = new Regex("[a-zA-Z0-9\\u0020\\-_]?", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个大小写英文字母、数字、句点、空格、中划线和下划线模式字符串的正则对象
	/// [a-zA-Z0-9\.\u0020\-_]
	/// </summary>
	public static readonly Regex AlphaDigitSpaceDotDashUnderscore = new Regex("[a-zA-Z0-9\\.\\u0020\\-_]", RegexOptions.Compiled);

	/// <summary>
	/// 匹配零个或者多个大小写英文字母、数字、句点、空格、中划线和下划线模式字符串的正则对象
	/// [a-zA-Z0-9\.\u0020\-_]*
	/// </summary>
	public static readonly Regex AlphaDigitSpaceDotDashUnderscoreAny = new Regex("[a-zA-Z0-9\\.\\u0020\\-_]*", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个或者多个大小写英文字母、数字、句点、空格、中划线和下划线模式字符串的正则对象
	/// [a-zA-Z0-9\.\u0020\-_]+
	/// </summary>
	public static readonly Regex AlphaDigitSpaceDotDashUnderscoreMore = new Regex("[a-zA-Z0-9\\.\\u0020\\-_]+", RegexOptions.Compiled);

	/// <summary>
	/// 匹配零个或者一个大小写英文字母、数字、句点、空格、中划线和下划线模式字符串的正则对象
	/// [a-zA-Z0-9\.\u0020\-_]?
	/// </summary>
	public static readonly Regex AlphaDigitSpaceDotDashUnderscoreOne = new Regex("[a-zA-Z0-9\\.\\u0020\\-_]?", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个中文字符模式字符串的正则对象
	/// [\u4E00-\u9FFF]
	/// </summary>
	public static readonly Regex ChineseCharacter = new Regex("[\\u4E00-\\u9FFF]", RegexOptions.Compiled);

	/// <summary>
	/// 匹配零个或者多个中文字符模式字符串的正则对象
	/// [\u4E00-\u9FFF]*
	/// </summary>
	public static readonly Regex ChineseCharacterAny = new Regex("[\\u4E00-\\u9FFF]*", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个或者多个中文字符模式字符串的正则对象
	/// [\u4E00-\u9FFF]+
	/// </summary>
	public static readonly Regex ChineseCharacterMore = new Regex("[\\u4E00-\\u9FFF]+", RegexOptions.Compiled);

	/// <summary>
	/// 匹配零个或者一个中文字符模式字符串的正则对象
	/// [\u4E00-\u9FFF]?
	/// </summary>
	public static readonly Regex ChineseCharacterOne = new Regex("[\\u4E00-\\u9FFF]?", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个中文字符和符号模式字符串的正则对象
	/// </summary>
	public static readonly Regex ChineseSymbol = new Regex("[\\u2010-\\u2027\\u2030-\\u2043\\u2045-\\u2051\\u2053-\\u205E\\u207D\\u207E\\u208D\\u208E\\u2329\\u232A\\u2768-\\u2775\\u27C5\\u27C6\\u27E6-\\u27EB\\u2983-\\u2998\\u29D8-\\u29DB\\u29FC\\u29FD\\u2CF9-\\u2CFC\\u2CFE\\u2CFF\\u2E00-\\u2E17\\u2E1C\\u2E1D\\u3001-\\u3003\\u3008-\\u3011\\u3014-\\u301F\\u3030\\u303D\\u30A0\\u30FB\\u4E00-\\u9FFF\\uA874-\\uA877\\uFD3E\\uFD3F\\uFE10-\\uFE1F\\uFE30-\\uFE52\\uFE54-\\uFE61\\uFE63\\uFE68\\uFE6A\\uFE6B\\uFF01-\\uFF03\\uFF05-\\uFF0A\\uFF0C-\\uFF0F\\uFF1A\\uFF1B\\uFF1F\\uFF20\\uFF3B-\\uFF3D\\uFF3F\\uFF5B\\uFF5D\\uFF5F-\\uFF65]", RegexOptions.Compiled);

	/// <summary>
	/// 匹配零个或者多个中文字符和符号模式字符串的正则对象
	/// </summary>
	public static readonly Regex ChineseSymbolAny = new Regex("[\\u2010-\\u2027\\u2030-\\u2043\\u2045-\\u2051\\u2053-\\u205E\\u207D\\u207E\\u208D\\u208E\\u2329\\u232A\\u2768-\\u2775\\u27C5\\u27C6\\u27E6-\\u27EB\\u2983-\\u2998\\u29D8-\\u29DB\\u29FC\\u29FD\\u2CF9-\\u2CFC\\u2CFE\\u2CFF\\u2E00-\\u2E17\\u2E1C\\u2E1D\\u3001-\\u3003\\u3008-\\u3011\\u3014-\\u301F\\u3030\\u303D\\u30A0\\u30FB\\u4E00-\\u9FFF\\uA874-\\uA877\\uFD3E\\uFD3F\\uFE10-\\uFE1F\\uFE30-\\uFE52\\uFE54-\\uFE61\\uFE63\\uFE68\\uFE6A\\uFE6B\\uFF01-\\uFF03\\uFF05-\\uFF0A\\uFF0C-\\uFF0F\\uFF1A\\uFF1B\\uFF1F\\uFF20\\uFF3B-\\uFF3D\\uFF3F\\uFF5B\\uFF5D\\uFF5F-\\uFF65]*", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个或者多个中文字符和符号模式字符串的正则对象
	/// </summary>
	public static readonly Regex ChineseSymbolMore = new Regex("[\\u2010-\\u2027\\u2030-\\u2043\\u2045-\\u2051\\u2053-\\u205E\\u207D\\u207E\\u208D\\u208E\\u2329\\u232A\\u2768-\\u2775\\u27C5\\u27C6\\u27E6-\\u27EB\\u2983-\\u2998\\u29D8-\\u29DB\\u29FC\\u29FD\\u2CF9-\\u2CFC\\u2CFE\\u2CFF\\u2E00-\\u2E17\\u2E1C\\u2E1D\\u3001-\\u3003\\u3008-\\u3011\\u3014-\\u301F\\u3030\\u303D\\u30A0\\u30FB\\u4E00-\\u9FFF\\uA874-\\uA877\\uFD3E\\uFD3F\\uFE10-\\uFE1F\\uFE30-\\uFE52\\uFE54-\\uFE61\\uFE63\\uFE68\\uFE6A\\uFE6B\\uFF01-\\uFF03\\uFF05-\\uFF0A\\uFF0C-\\uFF0F\\uFF1A\\uFF1B\\uFF1F\\uFF20\\uFF3B-\\uFF3D\\uFF3F\\uFF5B\\uFF5D\\uFF5F-\\uFF65]+", RegexOptions.Compiled);

	/// <summary>
	/// 匹配零个或者一个中文字符和符号模式字符串的正则对象
	/// </summary>
	public static readonly Regex ChineseSymbolOne = new Regex("[\\u2010-\\u2027\\u2030-\\u2043\\u2045-\\u2051\\u2053-\\u205E\\u207D\\u207E\\u208D\\u208E\\u2329\\u232A\\u2768-\\u2775\\u27C5\\u27C6\\u27E6-\\u27EB\\u2983-\\u2998\\u29D8-\\u29DB\\u29FC\\u29FD\\u2CF9-\\u2CFC\\u2CFE\\u2CFF\\u2E00-\\u2E17\\u2E1C\\u2E1D\\u3001-\\u3003\\u3008-\\u3011\\u3014-\\u301F\\u3030\\u303D\\u30A0\\u30FB\\u4E00-\\u9FFF\\uA874-\\uA877\\uFD3E\\uFD3F\\uFE10-\\uFE1F\\uFE30-\\uFE52\\uFE54-\\uFE61\\uFE63\\uFE68\\uFE6A\\uFE6B\\uFF01-\\uFF03\\uFF05-\\uFF0A\\uFF0C-\\uFF0F\\uFF1A\\uFF1B\\uFF1F\\uFF20\\uFF3B-\\uFF3D\\uFF3F\\uFF5B\\uFF5D\\uFF5F-\\uFF65]?", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个CJK字符模式字符串的正则对象
	/// [\p{IsCJKUnifiedIdeographsExtensionA}\p{IsCJKUnifiedIdeographs}\p{IsCJKCompatibilityIdeographs}]
	/// </summary>
	public static readonly Regex CJKCharacter = new Regex("[\\p{IsCJKUnifiedIdeographsExtensionA}\\p{IsCJKUnifiedIdeographs}\\p{IsCJKCompatibilityIdeographs}]", RegexOptions.Compiled);

	/// <summary>
	/// 匹配零个或者多个CJK字符模式字符串的正则对象
	/// [\p{IsCJKUnifiedIdeographsExtensionA}\p{IsCJKUnifiedIdeographs}\p{IsCJKCompatibilityIdeographs}]*
	/// </summary>
	public static readonly Regex CJKCharacterAny = new Regex("[\\p{IsCJKUnifiedIdeographsExtensionA}\\p{IsCJKUnifiedIdeographs}\\p{IsCJKCompatibilityIdeographs}]*", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个或者多个CJK字符模式字符串的正则对象
	/// [\p{IsCJKUnifiedIdeographsExtensionA}\p{IsCJKUnifiedIdeographs}\p{IsCJKCompatibilityIdeographs}]+
	/// </summary>
	public static readonly Regex CJKCharacterMore = new Regex("[\\p{IsCJKUnifiedIdeographsExtensionA}\\p{IsCJKUnifiedIdeographs}\\p{IsCJKCompatibilityIdeographs}]+", RegexOptions.Compiled);

	/// <summary>
	/// 匹配零个或者一个CJK字符模式字符串的正则对象
	/// [\p{IsCJKUnifiedIdeographsExtensionA}\p{IsCJKUnifiedIdeographs}\p{IsCJKCompatibilityIdeographs}]?
	/// </summary>
	public static readonly Regex CJKCharacterOne = new Regex("[\\p{IsCJKUnifiedIdeographsExtensionA}\\p{IsCJKUnifiedIdeographs}\\p{IsCJKCompatibilityIdeographs}]?", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个CJK字符和符号模式字符串的正则对象
	/// [\p{IsCJKRadicalsSupplement}\p{IsKangxiRadicals}\p{IsIdeographicDescriptionCharacters}\p{IsCJKSymbolsandPunctuation}\p{IsHiragana}\p{IsKatakana}\p{IsBopomofo}\p{IsBopomofoExtended}\p{IsKatakanaPhoneticExtensions}\p{IsEnclosedCJKLettersandMonths}\p{IsCJKCompatibility}\p{IsCJKUnifiedIdeographsExtensionA}\p{IsCJKUnifiedIdeographs}\p{IsCJKCompatibilityIdeographs}\p{IsCJKCompatibilityForms}\p{IsSmallFormVariants}\p{IsHalfwidthandFullwidthForms}]
	/// </summary>
	public static readonly Regex CJKSymbol = new Regex("[\\p{IsCJKRadicalsSupplement}\\p{IsKangxiRadicals}\\p{IsIdeographicDescriptionCharacters}\\p{IsCJKSymbolsandPunctuation}\\p{IsHiragana}\\p{IsKatakana}\\p{IsBopomofo}\\p{IsBopomofoExtended}\\p{IsKatakanaPhoneticExtensions}\\p{IsEnclosedCJKLettersandMonths}\\p{IsCJKCompatibility}\\p{IsCJKUnifiedIdeographsExtensionA}\\p{IsCJKUnifiedIdeographs}\\p{IsCJKCompatibilityIdeographs}\\p{IsCJKCompatibilityForms}\\p{IsSmallFormVariants}\\p{IsHalfwidthandFullwidthForms}]", RegexOptions.Compiled);

	/// <summary>
	/// 匹配零个或者多个CJK字符和符号模式字符串的正则对象
	/// [\p{IsCJKRadicalsSupplement}\p{IsKangxiRadicals}\p{IsIdeographicDescriptionCharacters}\p{IsCJKSymbolsandPunctuation}\p{IsHiragana}\p{IsKatakana}\p{IsBopomofo}\p{IsBopomofoExtended}\p{IsKatakanaPhoneticExtensions}\p{IsEnclosedCJKLettersandMonths}\p{IsCJKCompatibility}\p{IsCJKUnifiedIdeographsExtensionA}\p{IsCJKUnifiedIdeographs}\p{IsCJKCompatibilityIdeographs}\p{IsCJKCompatibilityForms}\p{IsSmallFormVariants}\p{IsHalfwidthandFullwidthForms}]*
	/// </summary>
	public static readonly Regex CJKSymbolAny = new Regex("[\\p{IsCJKRadicalsSupplement}\\p{IsKangxiRadicals}\\p{IsIdeographicDescriptionCharacters}\\p{IsCJKSymbolsandPunctuation}\\p{IsHiragana}\\p{IsKatakana}\\p{IsBopomofo}\\p{IsBopomofoExtended}\\p{IsKatakanaPhoneticExtensions}\\p{IsEnclosedCJKLettersandMonths}\\p{IsCJKCompatibility}\\p{IsCJKUnifiedIdeographsExtensionA}\\p{IsCJKUnifiedIdeographs}\\p{IsCJKCompatibilityIdeographs}\\p{IsCJKCompatibilityForms}\\p{IsSmallFormVariants}\\p{IsHalfwidthandFullwidthForms}]*", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个或者多个CJK字符和符号模式字符串的正则对象
	/// [\p{IsCJKRadicalsSupplement}\p{IsKangxiRadicals}\p{IsIdeographicDescriptionCharacters}\p{IsCJKSymbolsandPunctuation}\p{IsHiragana}\p{IsKatakana}\p{IsBopomofo}\p{IsBopomofoExtended}\p{IsKatakanaPhoneticExtensions}\p{IsEnclosedCJKLettersandMonths}\p{IsCJKCompatibility}\p{IsCJKUnifiedIdeographsExtensionA}\p{IsCJKUnifiedIdeographs}\p{IsCJKCompatibilityIdeographs}\p{IsCJKCompatibilityForms}\p{IsSmallFormVariants}\p{IsHalfwidthandFullwidthForms}]+
	/// </summary>
	public static readonly Regex CJKSymbolMore = new Regex("[\\p{IsCJKRadicalsSupplement}\\p{IsKangxiRadicals}\\p{IsIdeographicDescriptionCharacters}\\p{IsCJKSymbolsandPunctuation}\\p{IsHiragana}\\p{IsKatakana}\\p{IsBopomofo}\\p{IsBopomofoExtended}\\p{IsKatakanaPhoneticExtensions}\\p{IsEnclosedCJKLettersandMonths}\\p{IsCJKCompatibility}\\p{IsCJKUnifiedIdeographsExtensionA}\\p{IsCJKUnifiedIdeographs}\\p{IsCJKCompatibilityIdeographs}\\p{IsCJKCompatibilityForms}\\p{IsSmallFormVariants}\\p{IsHalfwidthandFullwidthForms}]+", RegexOptions.Compiled);

	/// <summary>
	/// 匹配零个或者一个CJK字符和符号模式字符串的正则对象
	/// [\p{IsCJKRadicalsSupplement}\p{IsKangxiRadicals}\p{IsIdeographicDescriptionCharacters}\p{IsCJKSymbolsandPunctuation}\p{IsHiragana}\p{IsKatakana}\p{IsBopomofo}\p{IsBopomofoExtended}\p{IsKatakanaPhoneticExtensions}\p{IsEnclosedCJKLettersandMonths}\p{IsCJKCompatibility}\p{IsCJKUnifiedIdeographsExtensionA}\p{IsCJKUnifiedIdeographs}\p{IsCJKCompatibilityIdeographs}\p{IsCJKCompatibilityForms}\p{IsSmallFormVariants}\p{IsHalfwidthandFullwidthForms}]?
	/// </summary>
	public static readonly Regex CJKSymbolOne = new Regex("[\\p{IsCJKRadicalsSupplement}\\p{IsKangxiRadicals}\\p{IsIdeographicDescriptionCharacters}\\p{IsCJKSymbolsandPunctuation}\\p{IsHiragana}\\p{IsKatakana}\\p{IsBopomofo}\\p{IsBopomofoExtended}\\p{IsKatakanaPhoneticExtensions}\\p{IsEnclosedCJKLettersandMonths}\\p{IsCJKCompatibility}\\p{IsCJKUnifiedIdeographsExtensionA}\\p{IsCJKUnifiedIdeographs}\\p{IsCJKCompatibilityIdeographs}\\p{IsCJKCompatibilityForms}\\p{IsSmallFormVariants}\\p{IsHalfwidthandFullwidthForms}]?", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个阿拉伯数字模式字符串的正则对象
	/// [0-9]
	/// </summary>
	public static readonly Regex Digit = new Regex("[0-9]", RegexOptions.Compiled);

	/// <summary>
	/// 匹配零个或者多个阿拉伯数字模式字符串的正则对象
	/// [0-9]*
	/// </summary>
	public static readonly Regex DigitAny = new Regex("[0-9]*", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个或者多个阿拉伯数字模式字符串的正则对象
	/// [0-9]+
	/// </summary>
	public static readonly Regex DigitMore = new Regex("[0-9]+", RegexOptions.Compiled);

	/// <summary>
	/// 匹配零个或者一个阿拉伯数字模式字符串的正则对象
	/// [0-9]?
	/// </summary>
	public static readonly Regex DigitOne = new Regex("[0-9]?", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个非ASCII字符模式字符串的正则对象
	/// \P{IsBasicLatin}
	/// </summary>
	public static readonly Regex NonAscii = new Regex("\\P{IsBasicLatin}", RegexOptions.Compiled);

	/// <summary>
	/// 匹配零个或者多个非ASCII字符模式字符串的正则对象
	/// \P{IsBasicLatin}*
	/// </summary>
	public static readonly Regex NonAsciiAny = new Regex("\\P{IsBasicLatin}*", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个或者多个非ASCII字符模式字符串的正则对象
	/// \P{IsBasicLatin}+
	/// </summary>
	public static readonly Regex NonAsciiMore = new Regex("\\P{IsBasicLatin}+", RegexOptions.Compiled);

	/// <summary>
	/// 匹配零个或者一个非ASCII字符模式字符串的正则对象
	/// \P{IsBasicLatin}?
	/// </summary>
	public static readonly Regex NonAsciiOne = new Regex("\\P{IsBasicLatin}?", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个非中文字符模式字符串的正则对象
	/// [^\u4E00-\u9FFF]
	/// </summary>
	public static readonly Regex NonChineseCharacter = new Regex("[^\\u4E00-\\u9FFF]", RegexOptions.Compiled);

	/// <summary>
	/// 匹配零个或者多个非中文字符模式字符串的正则对象
	/// [^\u4E00-\u9FFF]*
	/// </summary>
	public static readonly Regex NonChineseCharacterAny = new Regex("[^\\u4E00-\\u9FFF]*", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个或者多个非中文字符模式字符串的正则对象
	/// [^\u4E00-\u9FFF]+
	/// </summary>
	public static readonly Regex NonChineseCharacterMore = new Regex("[^\\u4E00-\\u9FFF]+", RegexOptions.Compiled);

	/// <summary>
	/// 匹配零个或者一个非中文字符模式字符串的正则对象
	/// [^\u4E00-\u9FFF]?
	/// </summary>
	public static readonly Regex NonChineseCharacterOne = new Regex("[^\\u4E00-\\u9FFF]?", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个非中文字符模式字符串的正则对象
	/// </summary>
	public static readonly Regex NonChineseSymbol = new Regex("[^\\u2010-\\u2027\\u2030-\\u2043\\u2045-\\u2051\\u2053-\\u205E\\u207D\\u207E\\u208D\\u208E\\u2329\\u232A\\u2768-\\u2775\\u27C5\\u27C6\\u27E6-\\u27EB\\u2983-\\u2998\\u29D8-\\u29DB\\u29FC\\u29FD\\u2CF9-\\u2CFC\\u2CFE\\u2CFF\\u2E00-\\u2E17\\u2E1C\\u2E1D\\u3001-\\u3003\\u3008-\\u3011\\u3014-\\u301F\\u3030\\u303D\\u30A0\\u30FB\\u4E00-\\u9FFF\\uA874-\\uA877\\uFD3E\\uFD3F\\uFE10-\\uFE1F\\uFE30-\\uFE52\\uFE54-\\uFE61\\uFE63\\uFE68\\uFE6A\\uFE6B\\uFF01-\\uFF03\\uFF05-\\uFF0A\\uFF0C-\\uFF0F\\uFF1A\\uFF1B\\uFF1F\\uFF20\\uFF3B-\\uFF3D\\uFF3F\\uFF5B\\uFF5D\\uFF5F-\\uFF65]", RegexOptions.Compiled);

	/// <summary>
	/// 匹配零个或者多个非中文字符模式字符串的正则对象
	/// </summary>
	public static readonly Regex NonChineseSymbolAny = new Regex("[^\\u2010-\\u2027\\u2030-\\u2043\\u2045-\\u2051\\u2053-\\u205E\\u207D\\u207E\\u208D\\u208E\\u2329\\u232A\\u2768-\\u2775\\u27C5\\u27C6\\u27E6-\\u27EB\\u2983-\\u2998\\u29D8-\\u29DB\\u29FC\\u29FD\\u2CF9-\\u2CFC\\u2CFE\\u2CFF\\u2E00-\\u2E17\\u2E1C\\u2E1D\\u3001-\\u3003\\u3008-\\u3011\\u3014-\\u301F\\u3030\\u303D\\u30A0\\u30FB\\u4E00-\\u9FFF\\uA874-\\uA877\\uFD3E\\uFD3F\\uFE10-\\uFE1F\\uFE30-\\uFE52\\uFE54-\\uFE61\\uFE63\\uFE68\\uFE6A\\uFE6B\\uFF01-\\uFF03\\uFF05-\\uFF0A\\uFF0C-\\uFF0F\\uFF1A\\uFF1B\\uFF1F\\uFF20\\uFF3B-\\uFF3D\\uFF3F\\uFF5B\\uFF5D\\uFF5F-\\uFF65]*", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个或者多个非中文字符模式字符串的正则对象
	/// </summary>
	public static readonly Regex NonChineseSymbolMore = new Regex("[^\\u2010-\\u2027\\u2030-\\u2043\\u2045-\\u2051\\u2053-\\u205E\\u207D\\u207E\\u208D\\u208E\\u2329\\u232A\\u2768-\\u2775\\u27C5\\u27C6\\u27E6-\\u27EB\\u2983-\\u2998\\u29D8-\\u29DB\\u29FC\\u29FD\\u2CF9-\\u2CFC\\u2CFE\\u2CFF\\u2E00-\\u2E17\\u2E1C\\u2E1D\\u3001-\\u3003\\u3008-\\u3011\\u3014-\\u301F\\u3030\\u303D\\u30A0\\u30FB\\u4E00-\\u9FFF\\uA874-\\uA877\\uFD3E\\uFD3F\\uFE10-\\uFE1F\\uFE30-\\uFE52\\uFE54-\\uFE61\\uFE63\\uFE68\\uFE6A\\uFE6B\\uFF01-\\uFF03\\uFF05-\\uFF0A\\uFF0C-\\uFF0F\\uFF1A\\uFF1B\\uFF1F\\uFF20\\uFF3B-\\uFF3D\\uFF3F\\uFF5B\\uFF5D\\uFF5F-\\uFF65]+", RegexOptions.Compiled);

	/// <summary>
	/// 匹配零个或者一个非中文字符模式字符串的正则对象
	/// </summary>
	public static readonly Regex NonChineseSymbolOne = new Regex("[^\\u2010-\\u2027\\u2030-\\u2043\\u2045-\\u2051\\u2053-\\u205E\\u207D\\u207E\\u208D\\u208E\\u2329\\u232A\\u2768-\\u2775\\u27C5\\u27C6\\u27E6-\\u27EB\\u2983-\\u2998\\u29D8-\\u29DB\\u29FC\\u29FD\\u2CF9-\\u2CFC\\u2CFE\\u2CFF\\u2E00-\\u2E17\\u2E1C\\u2E1D\\u3001-\\u3003\\u3008-\\u3011\\u3014-\\u301F\\u3030\\u303D\\u30A0\\u30FB\\u4E00-\\u9FFF\\uA874-\\uA877\\uFD3E\\uFD3F\\uFE10-\\uFE1F\\uFE30-\\uFE52\\uFE54-\\uFE61\\uFE63\\uFE68\\uFE6A\\uFE6B\\uFF01-\\uFF03\\uFF05-\\uFF0A\\uFF0C-\\uFF0F\\uFF1A\\uFF1B\\uFF1F\\uFF20\\uFF3B-\\uFF3D\\uFF3F\\uFF5B\\uFF5D\\uFF5F-\\uFF65]?", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个空白字符模式字符串的正则对象
	/// \s
	/// </summary>
	public static readonly Regex WhiteSpace = new Regex("\\s", RegexOptions.Compiled);

	/// <summary>
	/// 匹配零个或者多个空白字符模式字符串的正则对象
	/// \s*
	/// </summary>
	public static readonly Regex WhiteSpaceAny = new Regex("\\s*", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个或者多个空白字符模式字符串的正则对象
	/// \s+
	/// </summary>
	public static readonly Regex WhiteSpaceMore = new Regex("\\s+", RegexOptions.Compiled);

	/// <summary>
	/// 匹配零个或者一个空白字符模式字符串的正则对象
	/// \s?
	/// </summary>
	public static readonly Regex WhiteSpaceOne = new Regex("\\s?", RegexOptions.Compiled);

	private static readonly string InvalidFileNameCharsPattern = "[" + Regex.Escape(new string(Path.GetInvalidFileNameChars())) + "]+";

	/// <summary>
	/// 匹配一个文件名中不允许使用的字符模式字符串的正则对象
	/// </summary>
	/// <remarks>不能使用的字符列表通过 <see cref="M:System.IO.Path.GetInvalidFileNameChars" /> 方法获取。</remarks>
	public static readonly Regex InvalidFileNameChars = new Regex(InvalidFileNameCharsPattern, RegexOptions.Compiled);

	private static readonly string InvalidPathCharsPattern = "[" + Regex.Escape(new string(Path.GetInvalidPathChars())) + "]+";

	/// <summary>
	/// 匹配一个路径中不允许使用的字符模式字符串的正则对象
	/// </summary>
	/// <remarks>不能使用的字符列表通过 <see cref="M:System.IO.Path.GetInvalidPathChars" /> 方法获取。</remarks>
	public static readonly Regex InvalidPathChars = new Regex(InvalidPathCharsPattern, RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个包含卷标的Windows或者Mac格式路径模式字符串的正则对象
	/// (\w+:)(.*)
	/// </summary>
	/// <remarks>
	/// 包含两个捕获组
	/// 1：卷标名称，包含冒号
	/// 2：除去卷标后的路径
	/// </remarks>
	public static readonly Regex PathVolume = new Regex("(\\w+:)(.*)", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个DOS或者Unix样式的路径分隔符模式字符串的正则对象
	/// [/\\]+
	/// </summary>
	/// <remarks>DOS或者Unix样式的路径分隔符，匹配一个或者多个路径分隔符</remarks>
	public static readonly Regex PathSpliter = new Regex("[/\\\\]+", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个路径的根模式字符串的正则对象
	/// ^([a-zA-Z]:[\\/]+|[\\/]+)
	/// </summary>
	public static readonly Regex PathRoot = new Regex("^([a-zA-Z]:[\\\\/]+|[\\\\/]+)", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个SqlServer参数标记模式字符串的正则对象
	/// (@)([pP](\d+))
	/// </summary>
	public static readonly Regex SqlServerParameterToken = new Regex("(@)([pP](\\d+))", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个Oracle参数标记模式字符串的正则对象
	/// (:)([pP](\d+))
	/// </summary>
	public static readonly Regex OracleParameterToken = new Regex("(:)([pP](\\d+))", RegexOptions.Compiled);

	/// <summary>
	/// 匹配一个字符串格式化标记模式字符串的正则对象
	/// \{(\d+)\}
	/// </summary>
	public static readonly Regex StringFormatToken = new Regex("\\{(\\d+)\\}", RegexOptions.Compiled);
}
