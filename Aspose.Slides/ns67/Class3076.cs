using System;
using System.Text;

namespace ns67;

internal sealed class Class3076 : Class3075
{
	public Class3076(Class3402 bullet, Class3391 color, Class3394 size, Class3398 typeface, Class3406 characterProperties, Class3455 textBodyExtents)
		: base(bullet, color, size, typeface, characterProperties)
	{
		Class3406 properties = method_3();
		Class3080 @class = new Class3080(properties, textBodyExtents);
		string text = method_8();
		string text2 = text;
		foreach (char ch in text2)
		{
			@class.method_5(ch);
		}
		method_1(@class);
	}

	public override Class3455 vmethod_0()
	{
		Class3072[] array = method_0();
		return array[0].vmethod_0();
	}

	private string method_7(int num)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int num2 = num; num2 > 0; num2 /= 26)
		{
			stringBuilder.Insert(0, (char)(65 + (num2 % 26 - 1)));
		}
		return stringBuilder.ToString();
	}

	private string method_8()
	{
		Class3402 @class = (Class3402)base.Bullet;
		int value = @class.StartNumberingAt.Value;
		return @class.BulletAutonumberingType switch
		{
			Enum469.const_29 => $"({smethod_1(value)})".ToLower(), 
			Enum469.const_30 => $"{smethod_1(value)})".ToLower(), 
			Enum469.const_31 => $"{smethod_1(value)}.".ToLower(), 
			Enum469.const_32 => $"({smethod_1(value)})", 
			Enum469.const_33 => $"{smethod_1(value)})", 
			Enum469.const_34 => $"{smethod_1(value)}.", 
			Enum469.const_0 => $"({method_7(value).ToLower()})", 
			Enum469.const_1 => $"{method_7(value).ToLower()})", 
			Enum469.const_2 => $"{method_7(value).ToLower()}.", 
			Enum469.const_3 => $"({method_7(value).ToLower()})", 
			Enum469.const_4 => $"{method_7(value).ToLower()})", 
			Enum469.const_5 => $"{method_7(value).ToLower()}.", 
			Enum469.const_10 => $"({value})", 
			Enum469.const_11 => $"{value})", 
			Enum469.const_12 => $"{value}.", 
			_ => throw new ArgumentNullException(), 
		};
	}

	private static string smethod_1(int num)
	{
		if (-9999 < num && num < 9999)
		{
			if (num == 0)
			{
				return "NUL";
			}
			StringBuilder stringBuilder = new StringBuilder(10);
			if (num < 0)
			{
				stringBuilder.Append('-');
				num *= -1;
			}
			string[,] array = new string[4, 10]
			{
				{ "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" },
				{ "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" },
				{ "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" },
				{ "", "M", "MM", "MMM", "M(V)", "(V)", "(V)M", "(V)MM", "(V)MMM", "M(X)" }
			};
			int num2 = 1000;
			int num3 = 3;
			while (num2 > 0)
			{
				int num4 = num / num2;
				stringBuilder.Append(array[num3, num4]);
				num -= num4 * num2;
				num2 /= 10;
				num3--;
			}
			return stringBuilder.ToString();
		}
		throw new ArgumentOutOfRangeException("num");
	}
}
