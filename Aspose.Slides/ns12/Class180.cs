using System.Collections;
using System.Text.RegularExpressions;

namespace ns12;

internal sealed class Class180
{
	private const RegexOptions regexOptions_0 = RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant;

	private readonly string string_0;

	private Enum14 enum14_0;

	private readonly bool bool_0;

	private readonly Regex regex_0;

	private static readonly CaseInsensitiveComparer caseInsensitiveComparer_0 = CaseInsensitiveComparer.DefaultInvariant;

	public string FontNamePattern => string_0;

	public bool IsRegex => bool_0;

	public Enum14 Handling
	{
		get
		{
			return enum14_0;
		}
		set
		{
			enum14_0 = value;
		}
	}

	internal Class180(string pattern, bool regex, Enum14 handling)
	{
		string_0 = pattern;
		bool_0 = regex;
		if (regex)
		{
			regex_0 = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);
		}
		enum14_0 = handling;
	}

	public bool method_0(string FontName)
	{
		if (bool_0)
		{
			return regex_0.IsMatch(FontName);
		}
		return caseInsensitiveComparer_0.Compare(FontName, string_0) == 0;
	}
}
