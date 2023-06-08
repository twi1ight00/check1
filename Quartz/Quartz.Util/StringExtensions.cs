using System.Globalization;

namespace Quartz.Util;

/// <summary>
/// Extension methods for <see cref="T:System.String" />.
/// </summary>
public static class StringExtensions
{
	/// <summary>
	/// Allows null-safe trimming of string.
	/// </summary>
	/// <param name="s"></param>
	/// <returns></returns>
	public static string NullSafeTrim(this string s)
	{
		return s?.Trim();
	}

	/// <summary>
	/// Trims string and if resulting string is empty, null is returned.
	/// </summary>
	/// <param name="s"></param>
	/// <returns></returns>
	public static string TrimEmptyToNull(this string s)
	{
		if (s == null)
		{
			return null;
		}
		s = s.Trim();
		if (s.Length == 0)
		{
			return null;
		}
		return s;
	}

	public static bool IsNullOrWhiteSpace(this string s)
	{
		if (s != null)
		{
			return s.Trim().Length == 0;
		}
		return true;
	}

	public static string FormatInvariant(this string s, params object[] args)
	{
		return string.Format(CultureInfo.InvariantCulture, s, args);
	}
}
