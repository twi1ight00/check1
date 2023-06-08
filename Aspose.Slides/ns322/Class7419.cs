using System;
using System.Globalization;

namespace ns322;

internal class Class7419 : Class7400
{
	private Interface401 interface401_0;

	private static char[] char_0 = new char[36]
	{
		'0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
		'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
		'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
		'U', 'V', 'W', 'X', 'Y', 'Z'
	};

	public Class7397 method_4(Class7397 target, Class7397[] parameters)
	{
		if (target == this["NaN"])
		{
			return interface401_0.StringClass.method_5("NaN");
		}
		if (target == this["NEGATIVE_INFINITY"])
		{
			return interface401_0.StringClass.method_5("-Infinity");
		}
		if (target == this["POSITIVE_INFINITY"])
		{
			return interface401_0.StringClass.method_5("Infinity");
		}
		int num = 10;
		if (parameters.Length > 0 && parameters[0] != Class7437.class7437_0)
		{
			num = (int)parameters[0].vmethod_3();
		}
		long num2 = (long)target.vmethod_3();
		if (num == 10)
		{
			return interface401_0.StringClass.method_5(target.vmethod_3().ToString(CultureInfo.InvariantCulture).ToLower());
		}
		long num3 = Math.Abs(num2);
		int num4 = 0;
		char[] array = new char[63];
		for (num4 = 0; num4 <= 64; num4++)
		{
			if (num3 == 0L)
			{
				break;
			}
			array[array.Length - num4 - 1] = char_0[num3 % num];
			num3 /= num;
		}
		if (num2 < 0L)
		{
			array[array.Length - num4++ - 1] = '-';
		}
		return interface401_0.StringClass.method_5(new string(array, array.Length - num4, num4).ToLower());
	}

	public Class7397 method_5(Class7397 target, Class7397[] parameters)
	{
		return method_4(target, new Class7397[0]);
	}

	public Class7397 method_6(Class7397 target, Class7397[] parameters)
	{
		int num = 0;
		if (parameters.Length > 0)
		{
			num = Convert.ToInt32(parameters[0].vmethod_3());
		}
		if (num <= 20 && num >= 0)
		{
			if (target == interface401_0.NaN)
			{
				return interface401_0.StringClass.method_5(target.ToString());
			}
			return interface401_0.StringClass.method_5(target.vmethod_3().ToString("f" + num, CultureInfo.InvariantCulture));
		}
		throw new Exception88(interface401_0.SyntaxErrorClass.method_4("Fraction Digits must be greater than 0 and lesser than 20"));
	}

	public Class7397 method_7(Class7397 target, Class7397[] parameters)
	{
		if (!double.IsInfinity(target.vmethod_3()) && !double.IsNaN(target.vmethod_3()))
		{
			int num = 16;
			if (parameters.Length > 0)
			{
				num = Convert.ToInt32(parameters[0].vmethod_3());
			}
			if (num <= 20 && num >= 0)
			{
				string text = "#." + new string('0', num) + "e+0";
				return interface401_0.StringClass.method_5(target.vmethod_3().ToString(text, CultureInfo.InvariantCulture));
			}
			throw new Exception88(interface401_0.SyntaxErrorClass.method_4("Fraction Digits must be greater than 0 and lesser than 20"));
		}
		return method_4(target, new Class7397[0]);
	}

	public Class7397 method_8(Class7397 target, Class7397[] parameters)
	{
		if (!double.IsInfinity(target.vmethod_3()) && !double.IsNaN(target.vmethod_3()))
		{
			if (parameters.Length == 0)
			{
				throw new Exception88(interface401_0.SyntaxErrorClass.method_4("precision missing"));
			}
			if (parameters[0] == Class7437.class7437_0)
			{
				return method_4(target, new Class7397[0]);
			}
			int num = 0;
			if (parameters.Length > 0)
			{
				num = Convert.ToInt32(parameters[0].vmethod_3());
			}
			if (num >= 1 && num <= 21)
			{
				string text = target.vmethod_3().ToString("e23", CultureInfo.InvariantCulture);
				int num2 = text.IndexOfAny(new char[2] { '.', 'e' });
				num2 = ((num2 == -1) ? text.Length : num2);
				num -= num2;
				num = ((num < 1) ? 1 : num);
				return interface401_0.StringClass.method_5(target.vmethod_3().ToString("e" + num, CultureInfo.InvariantCulture));
			}
			throw new Exception88(interface401_0.RangeErrorClass.method_4("precision must be between 1 and 21"));
		}
		return method_4(target, new Class7397[0]);
	}

	public override Class7397 vmethod_25(Interface396 visitor, Class7398 that, Class7397[] parameters)
	{
		Class7397 result;
		if (string_21 == "toString")
		{
			result = method_4(that, parameters);
		}
		else if (string_21 == "toLocaleString")
		{
			result = method_5(that, parameters);
		}
		else if (string_21 == "toFixed")
		{
			result = method_6(that, parameters);
		}
		else if (string_21 == "toExponential")
		{
			result = method_7(that, parameters);
		}
		else
		{
			if (!(string_21 == "toPrecision"))
			{
				throw new Exception89("unknown error function");
			}
			result = method_8(that, parameters);
		}
		visitor.imethod_36(result);
		return result;
	}

	public override string ToString()
	{
		return $"function {base.Name}";
	}

	public Class7419(Interface401 global, string name, Class7399 prototype)
		: base(prototype)
	{
		string_21 = name;
		interface401_0 = global;
	}
}
