using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Newtonsoft.Json.Utilities;

internal static class StringUtils
{
	internal enum SnakeCaseState
	{
		Start,
		Lower,
		Upper,
		NewWord
	}

	public const string CarriageReturnLineFeed = "\r\n";

	public const string Empty = "";

	public const char CarriageReturn = '\r';

	public const char LineFeed = '\n';

	public const char Tab = '\t';

	public static string FormatWith(this string format, IFormatProvider provider, object arg0)
	{
		return format.FormatWith(provider, new object[1] { arg0 });
	}

	public static string FormatWith(this string format, IFormatProvider provider, object arg0, object arg1)
	{
		return format.FormatWith(provider, new object[2] { arg0, arg1 });
	}

	public static string FormatWith(this string format, IFormatProvider provider, object arg0, object arg1, object arg2)
	{
		return format.FormatWith(provider, new object[3] { arg0, arg1, arg2 });
	}

	public static string FormatWith(this string format, IFormatProvider provider, object arg0, object arg1, object arg2, object arg3)
	{
		return format.FormatWith(provider, new object[4] { arg0, arg1, arg2, arg3 });
	}

	private static string FormatWith(this string format, IFormatProvider provider, params object[] args)
	{
		ValidationUtils.ArgumentNotNull(format, "format");
		return string.Format(provider, format, args);
	}

	/// <summary>
	///   Determines whether the string is all white space. Empty string will return false.
	/// </summary>
	/// <param name="s">The string to test whether it is all white space.</param>
	/// <returns>
	///   <c>true</c> if the string is all white space; otherwise, <c>false</c>.
	/// </returns>
	public static bool IsWhiteSpace(string s)
	{
		if (s == null)
		{
			throw new ArgumentNullException("s");
		}
		if (s.Length == 0)
		{
			return false;
		}
		for (int i = 0; i < s.Length; i++)
		{
			if (!char.IsWhiteSpace(s[i]))
			{
				return false;
			}
		}
		return true;
	}

	public static StringWriter CreateStringWriter(int capacity)
	{
		return new StringWriter(new StringBuilder(capacity), CultureInfo.InvariantCulture);
	}

	public static void ToCharAsUnicode(char c, char[] buffer)
	{
		buffer[0] = '\\';
		buffer[1] = 'u';
		buffer[2] = MathUtils.IntToHex(((int)c >> 12) & 0xF);
		buffer[3] = MathUtils.IntToHex(((int)c >> 8) & 0xF);
		buffer[4] = MathUtils.IntToHex(((int)c >> 4) & 0xF);
		buffer[5] = MathUtils.IntToHex(c & 0xF);
	}

	public static TSource ForgivingCaseSensitiveFind<TSource>(this IEnumerable<TSource> source, Func<TSource, string> valueSelector, string testValue)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (valueSelector == null)
		{
			throw new ArgumentNullException("valueSelector");
		}
		IEnumerable<TSource> source2 = source.Where((TSource s) => string.Equals(valueSelector(s), testValue, StringComparison.OrdinalIgnoreCase));
		if (source2.Count() <= 1)
		{
			return source2.SingleOrDefault();
		}
		return source.Where((TSource s) => string.Equals(valueSelector(s), testValue, StringComparison.Ordinal)).SingleOrDefault();
	}

	public static string ToCamelCase(string s)
	{
		if (string.IsNullOrEmpty(s) || !char.IsUpper(s[0]))
		{
			return s;
		}
		char[] array = s.ToCharArray();
		for (int i = 0; i < array.Length && (i != 1 || char.IsUpper(array[i])); i++)
		{
			bool flag = i + 1 < array.Length;
			if (i > 0 && flag && !char.IsUpper(array[i + 1]))
			{
				break;
			}
			char c = char.ToLower(array[i], CultureInfo.InvariantCulture);
			array[i] = c;
		}
		return new string(array);
	}

	public static string ToSnakeCase(string s)
	{
		if (string.IsNullOrEmpty(s))
		{
			return s;
		}
		StringBuilder stringBuilder = new StringBuilder();
		SnakeCaseState snakeCaseState = SnakeCaseState.Start;
		for (int i = 0; i < s.Length; i++)
		{
			if (s[i] == ' ')
			{
				if (snakeCaseState != 0)
				{
					snakeCaseState = SnakeCaseState.NewWord;
				}
			}
			else if (char.IsUpper(s[i]))
			{
				switch (snakeCaseState)
				{
				case SnakeCaseState.Upper:
				{
					bool flag = i + 1 < s.Length;
					if (i > 0 && flag)
					{
						char c = s[i + 1];
						if (!char.IsUpper(c) && c != '_')
						{
							stringBuilder.Append('_');
						}
					}
					break;
				}
				case SnakeCaseState.Lower:
				case SnakeCaseState.NewWord:
					stringBuilder.Append('_');
					break;
				}
				char value = char.ToLower(s[i], CultureInfo.InvariantCulture);
				stringBuilder.Append(value);
				snakeCaseState = SnakeCaseState.Upper;
			}
			else if (s[i] == '_')
			{
				stringBuilder.Append('_');
				snakeCaseState = SnakeCaseState.Start;
			}
			else
			{
				if (snakeCaseState == SnakeCaseState.NewWord)
				{
					stringBuilder.Append('_');
				}
				stringBuilder.Append(s[i]);
				snakeCaseState = SnakeCaseState.Lower;
			}
		}
		return stringBuilder.ToString();
	}

	public static bool IsHighSurrogate(char c)
	{
		return char.IsHighSurrogate(c);
	}

	public static bool IsLowSurrogate(char c)
	{
		return char.IsLowSurrogate(c);
	}

	public static bool StartsWith(this string source, char value)
	{
		if (source.Length > 0)
		{
			return source[0] == value;
		}
		return false;
	}

	public static bool EndsWith(this string source, char value)
	{
		if (source.Length > 0)
		{
			return source[source.Length - 1] == value;
		}
		return false;
	}
}
