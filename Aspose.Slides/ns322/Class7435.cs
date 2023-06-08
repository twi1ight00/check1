using System.Text.RegularExpressions;

namespace ns322;

internal class Class7435 : Class7399
{
	private string string_21;

	private RegexOptions regexOptions_0;

	public bool IsGlobal => this["global"].vmethod_2();

	public bool IsIgnoreCase => (regexOptions_0 & RegexOptions.IgnoreCase) == RegexOptions.IgnoreCase;

	public bool IsMultiline => (regexOptions_0 & RegexOptions.Multiline) == RegexOptions.Multiline;

	public string Pattern => string_21;

	public Regex Regex => new Regex(string_21, regexOptions_0);

	public RegexOptions Options => regexOptions_0;

	public override object Value => null;

	public override string _Class => "RegExp";

	public override string vmethod_6()
	{
		return "/" + string_21.ToString() + "/";
	}

	public override string ToString()
	{
		return "/" + string_21.ToString() + "/" + (IsGlobal ? "g" : string.Empty) + (IsIgnoreCase ? "i" : string.Empty) + (IsMultiline ? "m" : string.Empty);
	}

	public Class7435(string pattern, bool g, bool i, bool m, Class7399 prototype)
		: base(prototype)
	{
		regexOptions_0 = RegexOptions.ECMAScript;
		if (m)
		{
			regexOptions_0 |= RegexOptions.Multiline;
		}
		if (i)
		{
			regexOptions_0 |= RegexOptions.IgnoreCase;
		}
		string_21 = pattern;
	}
}
