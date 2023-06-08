using System;
using System.Text.RegularExpressions;
using ns305;

namespace ns81;

internal class Class4035 : Class4029
{
	public Class4035()
		: base("invalid")
	{
	}

	public override bool imethod_0(Class6981 e, string pseudoElement)
	{
		if (!"input".Equals(e.TagName, StringComparison.OrdinalIgnoreCase))
		{
			return false;
		}
		if (!e.method_34("pattern"))
		{
			return false;
		}
		string text = e.method_20("pattern");
		if (string.IsNullOrEmpty(text))
		{
			return false;
		}
		if (!e.method_34("value"))
		{
			return false;
		}
		string text2 = e.method_20("value");
		if (string.IsNullOrEmpty(text2))
		{
			return false;
		}
		try
		{
			Regex regex = new Regex(text);
			return !regex.Match(text2).Success;
		}
		catch
		{
			return false;
		}
	}
}
