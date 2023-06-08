using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using ns76;
using ns82;
using ns83;

namespace ns1;

internal class Class4094 : Class4093
{
	private const char char_0 = '\\';

	private const string string_1 = "\\";

	private static readonly Regex regex_0 = new Regex("\\\\([\\n\\r\\f0-9a-fA-F]{1,6})\\s*");

	private string string_2;

	private Class4077.Class4081 class4081_0;

	public string UnescapedText
	{
		get
		{
			if (string_2 == null && Text != null)
			{
				string text = Text;
				if (text.IndexOf('\\') != -1)
				{
					text = regex_0.Replace(text, smethod_6);
				}
				if (text.IndexOf('\\') != -1)
				{
					text = text.Replace("\\", string.Empty);
				}
				string_2 = text;
			}
			return string_2;
		}
	}

	public Class4094(Interface110 input, int type, int channel, int start, int stop)
		: base(input, type, channel, start, stop)
	{
	}

	public Class4094(int type, Class4077.Class4081 state)
		: base(type)
	{
		class4081_0 = new Class4077.Class4081(state);
	}

	public Class4094(int type, Class4077.Class4081 state, int start, int stop)
		: base(type)
	{
		class4081_0 = new Class4077.Class4081(state);
		int_5 = start;
		int_6 = stop;
	}

	public Class4094 method_0(Class4077.Class4081 state)
	{
		class4081_0 = state;
		return this;
	}

	public Class4077.Class4081 method_1()
	{
		return class4081_0;
	}

	public static string smethod_0(Interface105 node)
	{
		string unescapedText = ((Class4094)((Class4363)node).Token).UnescapedText;
		return unescapedText.Substring(1, unescapedText.Length - 1);
	}

	public static string smethod_1(string uri)
	{
		string text = uri.Substring(4, uri.Length - 1);
		if (text.Length > 0 && (text[0] == '\'' || text[0] == '"'))
		{
			text = text.Substring(1, text.Length - 1);
		}
		return text;
	}

	public static string smethod_2(Interface105 node)
	{
		string unescapedText = ((Class4094)((Class4363)node).Token).UnescapedText;
		return unescapedText.Substring(1, unescapedText.Length - 1);
	}

	public static string smethod_3(Interface105 node)
	{
		return ((Class4094)((Class4363)node).Token).UnescapedText.Substring(1);
	}

	public static string smethod_4(Interface105 node)
	{
		return ((Class4094)((Class4363)node).Token).UnescapedText.Substring(1);
	}

	public static string smethod_5(Interface105 node)
	{
		return ((Class4094)((Class4363)node).Token).UnescapedText;
	}

	private static string smethod_6(Match match)
	{
		if (int.TryParse(match.Value.Substring(1), NumberStyles.HexNumber, Class3726.cultureInfo_0, out var result))
		{
			return new string((char)result, 1);
		}
		return string.Empty;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("/").Append(class4081_0).Append("/")
			.Append(base.ToString());
		return stringBuilder.ToString();
	}
}
