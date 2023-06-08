using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ns322;

internal class Class7417 : Class7400
{
	private Interface401 interface401_0;

	private Interface396 interface396_0;

	private static char[] char_0 = new char[11]
	{
		';', ',', '/', '?', ':', '@', '&', '=', '+', '$',
		'#'
	};

	private static char[] char_1 = new char[11]
	{
		'-', '_', '.', '!', '~', '*', '\'', '(', ')', '[',
		']'
	};

	public Interface396 Visitor => interface396_0;

	public Class7397 method_4(Class7397[] arguments)
	{
		if ("String" != arguments[0]._Class)
		{
			return arguments[0];
		}
		Class7380 @class;
		try
		{
			@class = Class7685.smethod_0(arguments[0].ToString());
		}
		catch (Exception ex)
		{
			throw new Exception88(interface401_0.SyntaxErrorClass.method_4(ex.Message));
		}
		try
		{
			@class.vmethod_0((Interface395)Visitor);
		}
		catch (Exception ex2)
		{
			throw new Exception88(interface401_0.EvalErrorClass.method_4(ex2.Message));
		}
		return Visitor.Result;
	}

	public Class7397 method_5(Class7397[] arguments)
	{
		if (arguments.Length >= 1 && arguments[0] != Class7437.class7437_0)
		{
			string text = arguments[0].ToString().Trim();
			int num = 1;
			int num2 = 10;
			if (string.IsNullOrEmpty(text))
			{
				return (interface401_0 as Class7431)["NaN"];
			}
			if (text.StartsWith("-"))
			{
				text = text.Substring(1);
				num = -1;
			}
			else if (text.StartsWith("+"))
			{
				text = text.Substring(1);
			}
			if (arguments.Length >= 2 && arguments[1] != Class7437.class7437_0 && !0.Equals(arguments[1]))
			{
				num2 = Convert.ToInt32(arguments[1].Value);
			}
			if (num2 == 0)
			{
				num2 = 10;
			}
			else if (num2 < 2 || num2 > 36)
			{
				return (interface401_0 as Class7431)["NaN"];
			}
			if (text.ToLower().StartsWith("0x"))
			{
				num2 = 16;
			}
			try
			{
				if (num2 == 10)
				{
					if (double.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
					{
						return interface401_0.NumberClass.method_4((double)num * Math.Floor(result));
					}
					return (interface401_0 as Class7431)["NaN"];
				}
				return interface401_0.NumberClass.method_4(num * Convert.ToInt32(text, num2));
			}
			catch
			{
				return (interface401_0 as Class7431)["NaN"];
			}
		}
		return Class7437.class7437_0;
	}

	public Class7397 method_6(Class7397[] arguments)
	{
		if (arguments.Length >= 1 && arguments[0] != Class7437.class7437_0)
		{
			string input = arguments[0].ToString().Trim();
			Regex regex = new Regex("^[\\+\\-\\d\\.e]*", RegexOptions.IgnoreCase);
			Match match = regex.Match(input);
			if (match.Success && double.TryParse(match.Value, NumberStyles.Float, new CultureInfo("en-US"), out var result))
			{
				return interface401_0.NumberClass.method_4(result);
			}
			return (interface401_0 as Class7431)["NaN"];
		}
		return Class7437.class7437_0;
	}

	public Class7397 method_7(Class7397[] arguments)
	{
		if (arguments.Length >= 1 && arguments[0] != Class7437.class7437_0)
		{
			return interface401_0.BooleanClass.method_4(double.NaN.Equals(arguments[0].vmethod_3()));
		}
		return interface401_0.BooleanClass.method_4(value: false);
	}

	public Class7397 method_8(Class7397[] arguments)
	{
		if (arguments.Length >= 1 && arguments[0] != Class7437.class7437_0)
		{
			Class7397 @class = arguments[0];
			return interface401_0.BooleanClass.method_4(@class != interface401_0.NumberClass["NaN"] && @class != interface401_0.NumberClass["POSITIVE_INFINITY"] && @class != interface401_0.NumberClass["NEGATIVE_INFINITY"]);
		}
		return interface401_0.BooleanClass.False;
	}

	public Class7397 method_9(Class7397[] arguments)
	{
		if (arguments.Length >= 1 && arguments[0] != Class7437.class7437_0)
		{
			return interface401_0.StringClass.method_5(Uri.UnescapeDataString(arguments[0].ToString().Replace("+", " ")));
		}
		return interface401_0.StringClass.method_4();
	}

	public Class7397 method_10(Class7397[] arguments)
	{
		if (arguments.Length >= 1 && arguments[0] != Class7437.class7437_0)
		{
			return interface401_0.StringClass.method_5(Uri.UnescapeDataString(arguments[0].ToString().Replace("+", " ")));
		}
		return interface401_0.StringClass.method_4();
	}

	public Class7397 method_11(Class7397[] arguments)
	{
		if (arguments.Length >= 1 && arguments[0] != Class7437.class7437_0)
		{
			string text = Uri.EscapeDataString(arguments[0].ToString());
			char[] array = char_1;
			for (int i = 0; i < array.Length; i++)
			{
				char c = array[i];
				text = text.Replace(Uri.EscapeDataString(c.ToString()), c.ToString());
			}
			return interface401_0.StringClass.method_5(text);
		}
		return interface401_0.StringClass.method_4();
	}

	public Class7397 method_12(Class7397[] arguments)
	{
		if (arguments.Length >= 1 && arguments[0] != Class7437.class7437_0)
		{
			string text = Uri.EscapeDataString(arguments[0].ToString());
			char[] array = char_0;
			for (int i = 0; i < array.Length; i++)
			{
				char c = array[i];
				text = text.Replace(Uri.EscapeDataString(c.ToString()), c.ToString());
			}
			char[] array2 = char_1;
			for (int j = 0; j < array2.Length; j++)
			{
				char c2 = array2[j];
				text = text.Replace(Uri.EscapeDataString(c2.ToString()), c2.ToString());
			}
			return interface401_0.StringClass.method_5(text);
		}
		return interface401_0.StringClass.method_4();
	}

	public Class7397 method_13(Class7398 target)
	{
		return interface401_0.NumberClass.method_4(target.Length);
	}

	public Class7397 method_14(Class7397 target, Class7397[] parameters)
	{
		int num = (int)parameters[0].vmethod_3();
		if (num < 0 || double.IsNaN(num) || double.IsInfinity(num))
		{
			throw new Exception88(interface401_0.RangeErrorClass.method_4("invalid length"));
		}
		Class7398 @class = (Class7398)target;
		@class.Length = num;
		return parameters[0];
	}

	public static Class7397 smethod_0()
	{
		return Class7437.class7437_0;
	}

	public override Class7397 vmethod_25(Interface396 visitor, Class7398 that, Class7397[] parameters)
	{
		Class7397 result;
		if (string_21 == "eval")
		{
			result = method_4(parameters);
		}
		else if (string_21 == "parseInt")
		{
			result = method_5(parameters);
		}
		else if (string_21 == "parseFloat")
		{
			result = method_6(parameters);
		}
		else if (string_21 == "isNaN")
		{
			result = method_7(parameters);
		}
		else if (string_21 == "isFinite")
		{
			result = method_8(parameters);
		}
		else if (string_21 == "decodeURI")
		{
			result = method_9(parameters);
		}
		else if (string_21 == "encodeURI")
		{
			result = method_12(parameters);
		}
		else if (string_21 == "decodeURIComponent")
		{
			result = method_10(parameters);
		}
		else if (string_21 == "encodeURIComponent")
		{
			result = method_11(parameters);
		}
		else if (string_21 == "get_length")
		{
			result = method_13(that);
		}
		else if (string_21 == "set_length")
		{
			result = method_14(that, parameters);
		}
		else
		{
			if (!(string_21 == "prototype"))
			{
				throw new Exception89("unknown global function");
			}
			result = smethod_0();
		}
		visitor.imethod_36(result);
		return result;
	}

	public override string ToString()
	{
		return $"function {base.Name}";
	}

	public Class7417(Interface401 global, Interface396 visitor, string name, Class7399 prototype)
		: base(prototype)
	{
		string_21 = name;
		interface401_0 = global;
		interface396_0 = visitor;
	}
}
