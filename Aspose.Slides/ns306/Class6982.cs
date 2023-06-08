using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using ns305;

namespace ns306;

internal class Class6982 : Class6981
{
	private static readonly CultureInfo cultureInfo_0 = new CultureInfo("en-US");

	public string Id
	{
		get
		{
			return method_45("id", string.Empty);
		}
		set
		{
			method_21("id", value);
		}
	}

	public string Title
	{
		get
		{
			return method_45("title", string.Empty);
		}
		set
		{
			method_21("title", value);
		}
	}

	public string Lang
	{
		get
		{
			return method_45(Class7065.string_2, string.Empty);
		}
		set
		{
			method_21(Class7065.string_2, value);
		}
	}

	public string Dir
	{
		get
		{
			return method_45(Class7065.string_3, string.Empty);
		}
		set
		{
			method_21(Class7065.string_3, value);
		}
	}

	public string ClassName
	{
		get
		{
			return method_45(Class7065.string_4, string.Empty);
		}
		set
		{
			method_21(Class7065.string_4, value);
		}
	}

	public string Style
	{
		get
		{
			return method_45(Class7065.string_5, string.Empty);
		}
		set
		{
			method_21(Class7065.string_5, value);
		}
	}

	protected internal Class6982(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	protected T method_39<T>(string name, T @default)
	{
		string text = method_20(name);
		if (text != null)
		{
			return method_41(text, @default);
		}
		return @default;
	}

	protected T method_40<T>(string name, T @default, string regex)
	{
		string text = method_20(name);
		if (text != null)
		{
			Regex regex2 = new Regex(regex);
			Match match = regex2.Match(text);
			if (match.Success)
			{
				return method_41(match.Value, @default);
			}
		}
		return @default;
	}

	private T method_41<T>(string value, T @default)
	{
		try
		{
			return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromString(null, cultureInfo_0, value);
		}
		catch
		{
			return @default;
		}
	}

	protected void method_42(string name, int value)
	{
		method_21(name, value.ToString());
	}

	protected void method_43(string name, float value)
	{
		method_21(name, value.ToString());
	}

	protected void method_44(string name, bool value)
	{
		method_21(name, value ? bool.TrueString : bool.FalseString);
	}

	protected string method_45(string name, string @default)
	{
		Class7045 @class = Attributes.method_11(name);
		if (@class != null)
		{
			string value = @class.Value;
			if (value != null)
			{
				return value;
			}
		}
		return @default;
	}

	protected Class7075 method_46(IEnumerable<string> tags)
	{
		return new Class7084(this, tags);
	}

	protected Class7075 method_47(string tag)
	{
		return new Class7084(this, tag);
	}
}
