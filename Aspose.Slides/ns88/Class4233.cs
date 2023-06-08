using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using ns76;
using ns83;

namespace ns88;

internal abstract class Class4233 : Interface99
{
	private class Class4234 : Class4233
	{
		private string string_24;

		public Class4234(Interface99 previous, string value)
			: base(36, previous)
		{
			string_24 = value;
		}

		public override string imethod_5()
		{
			return string_24;
		}

		public override string ToString()
		{
			return imethod_5();
		}
	}

	private class Class4235 : Class4233
	{
		private string string_24;

		public Class4235(Interface99 previous, string value)
			: base(24, previous)
		{
			string_24 = value;
		}

		public override string imethod_5()
		{
			return string_24;
		}

		public override string ToString()
		{
			return "uri(" + imethod_5() + ")";
		}
	}

	private class Class4236 : Class4233
	{
		private int int_0;

		public Class4236(Interface99 previous, int value)
			: base(13, previous)
		{
			int_0 = value;
		}

		public override int imethod_0()
		{
			return int_0;
		}

		public override float imethod_1()
		{
			return int_0;
		}

		public override string ToString()
		{
			return imethod_0().ToString();
		}
	}

	[DebuggerDisplay("{GetStringValue()}")]
	private class Class4237 : Class4233
	{
		private string string_24;

		public Class4237(short luType, Interface99 previous)
			: base(luType, previous)
		{
		}

		public Class4237(short luType, string text, Interface99 previous)
			: base(luType, previous)
		{
			string_24 = text;
		}

		public override string imethod_5()
		{
			if (string_24 != null)
			{
				return string_24;
			}
			return base.imethod_5();
		}
	}

	private class Class4238 : Class4233
	{
		private float float_0;

		public Class4238(short luType, float value, Interface99 previous)
			: base(luType, previous)
		{
			float_0 = value;
		}

		public override float imethod_1()
		{
			return float_0;
		}

		public override string ToString()
		{
			return imethod_1().ToString();
		}
	}

	private class Class4239 : Class4233
	{
		private float float_0;

		private string string_24;

		public Class4239(Interface99 previous, float value, string dimension)
			: base(42, previous)
		{
			float_0 = value;
			string_24 = dimension;
		}

		public override float imethod_1()
		{
			return float_0;
		}

		public override string imethod_2()
		{
			return string_24;
		}
	}

	private class Class4240 : Class4233
	{
		private string string_24;

		private Interface99 interface99_2;

		public Class4240(Interface99 previous, string funcName, Interface99 @params)
			: base(41, previous)
		{
			string_24 = funcName;
			interface99_2 = @params;
		}

		public override string imethod_3()
		{
			return string_24;
		}

		public override Interface99 imethod_4()
		{
			return interface99_2;
		}
	}

	private class Class4241 : Class4233
	{
		private Interface99 interface99_2;

		public Class4241(Interface99 previous, short functionType, Interface99 @params)
			: base(functionType, previous)
		{
			interface99_2 = @params;
		}

		public override Interface99 imethod_4()
		{
			return interface99_2;
		}

		public override string imethod_3()
		{
			return base.LexicalUnitType switch
			{
				38 => "rect", 
				25 => "counter", 
				26 => "counters", 
				27 => "rgb", 
				_ => base.imethod_3(), 
			};
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(imethod_3());
			stringBuilder.Append("()");
			return stringBuilder.ToString();
		}
	}

	private class Class4242 : Class4233
	{
		private string string_24;

		public Class4242(Interface99 previous, string value)
			: base(35, previous)
		{
			string_24 = value;
		}

		public override string imethod_5()
		{
			return string_24;
		}

		public override string ToString()
		{
			return imethod_5();
		}
	}

	public const short short_0 = -1;

	public const short short_1 = 0;

	public const short short_2 = 1;

	public const short short_3 = 2;

	public const short short_4 = 3;

	public const short short_5 = 4;

	public const short short_6 = 5;

	public const short short_7 = 6;

	public const short short_8 = 7;

	public const short short_9 = 8;

	public const short short_10 = 9;

	public const short short_11 = 10;

	public const short short_12 = 11;

	public const short short_13 = 12;

	public const short short_14 = 13;

	public const short short_15 = 14;

	public const short short_16 = 15;

	public const short short_17 = 16;

	public const short short_18 = 17;

	public const short short_19 = 18;

	public const short short_20 = 19;

	public const short short_21 = 20;

	public const short short_22 = 21;

	public const short short_23 = 22;

	public const short short_24 = 23;

	public const short short_25 = 24;

	public const short short_26 = 25;

	public const short short_27 = 26;

	public const short short_28 = 27;

	public const short short_29 = 28;

	public const short short_30 = 29;

	public const short short_31 = 30;

	public const short short_32 = 31;

	public const short short_33 = 32;

	public const short short_34 = 33;

	public const short short_35 = 34;

	public const short short_36 = 35;

	public const short short_37 = 36;

	public const short short_38 = 37;

	public const short short_39 = 38;

	public const short short_40 = 39;

	public const short short_41 = 40;

	public const short short_42 = 41;

	public const short short_43 = 42;

	public const short short_44 = 43;

	public const short short_45 = 44;

	public const short short_46 = 45;

	public const short short_47 = 46;

	public const string string_0 = "cm";

	public const string string_1 = "deg";

	public const string string_2 = "em";

	public const string string_3 = "ex";

	public const string string_4 = "grad";

	public const string string_5 = "Hz";

	public const string string_6 = "in";

	public const string string_7 = "kHz";

	public const string string_8 = "mm";

	public const string string_9 = "ms";

	public const string string_10 = "%";

	public const string string_11 = "pc";

	public const string string_12 = "px";

	public const string string_13 = "pt";

	public const string string_14 = "rad";

	public const string string_15 = "";

	public const string string_16 = "s";

	public const string string_17 = "dpi";

	public const string string_18 = "dpcm";

	public const string string_19 = "dppx";

	public const string string_20 = "rgb";

	public const string string_21 = "rect";

	public const string string_22 = "counter";

	public const string string_23 = "counters";

	private Interface99 interface99_0;

	private Interface99 interface99_1;

	private short short_48;

	private static Regex regex_0 = new Regex("\\\\[\\(\\)\\t\\n\\f\\r '\\\"]");

	public short LexicalUnitType => short_48;

	public Interface99 First
	{
		get
		{
			Interface99 @interface = this;
			while (@interface.PreviousLexicalUnit != null)
			{
				@interface = @interface.PreviousLexicalUnit;
			}
			return @interface;
		}
	}

	public Interface99 NextLexicalUnit => interface99_1;

	public Interface99 PreviousLexicalUnit => interface99_0;

	protected Class4233(short luType, Interface99 previous)
	{
		interface99_0 = previous;
		short_48 = luType;
		if (previous != null)
		{
			((Class4233)previous).interface99_1 = this;
		}
	}

	public virtual int imethod_0()
	{
		throw new InvalidOperationException();
	}

	public virtual float imethod_1()
	{
		throw new InvalidOperationException();
	}

	public virtual string imethod_2()
	{
		return short_48 switch
		{
			14 => "", 
			15 => "em", 
			16 => "ex", 
			17 => "px", 
			18 => "in", 
			19 => "cm", 
			20 => "mm", 
			21 => "pt", 
			22 => "pc", 
			23 => "%", 
			28 => "deg", 
			29 => "grad", 
			30 => "rad", 
			31 => "ms", 
			32 => "s", 
			33 => "Hz", 
			34 => "kHz", 
			_ => throw new InvalidOperationException($"Lexical unit type '{short_48}' is unknown"), 
		};
	}

	public virtual string imethod_3()
	{
		throw new InvalidOperationException();
	}

	public virtual Interface99 imethod_4()
	{
		throw new InvalidOperationException();
	}

	public virtual string imethod_5()
	{
		throw new InvalidOperationException();
	}

	public static Interface99 smethod_0(Interface99 previous, string value)
	{
		int num = 0;
		int num2 = value.Length;
		int num3 = num2 - 1;
		bool flag = false;
		if (value[0] == '\'' || value[0] == '"')
		{
			num = 1;
			flag = true;
		}
		if (value[num3] == '\'' || value[num3] == '"')
		{
			num2 = num3 - num;
			flag = true;
		}
		if (flag)
		{
			return new Class4234(previous, value.Substring(num, num2));
		}
		return new Class4234(previous, value);
	}

	public static Interface99 smethod_1(Interface99 previous, string value)
	{
		return new Class4242(previous, value);
	}

	public static Interface99 smethod_2(Interface99 previous, int value)
	{
		return new Class4236(previous, value);
	}

	public static Interface99 smethod_3(Interface99 previous, short luType)
	{
		return new Class4237(luType, previous);
	}

	public static Interface99 smethod_4(Interface99 previous, short luType, string text)
	{
		return new Class4237(luType, text, previous);
	}

	public static Interface99 smethod_5(Interface99 previous, short luType, float value)
	{
		return new Class4238(luType, value, previous);
	}

	public static Interface99 smethod_6(Interface99 previous, float value, string dimension)
	{
		return new Class4239(previous, value, dimension);
	}

	public static Interface99 smethod_7(Interface99 previous, string functionName, Interface99 @params)
	{
		return new Class4240(previous, functionName, @params);
	}

	public static Interface99 smethod_8(Interface99 previous, short functionType, Interface99 @params)
	{
		return new Class4241(previous, functionType, @params);
	}

	public static Interface99 smethod_9(Interface99 previous, Interface105 node)
	{
		Interface99 @interface = null;
		string text = node.Text;
		switch (text.Length - 1)
		{
		default:
			throw Class4246.smethod_6(node);
		case 6:
		{
			char c4 = char.ToLower(text[1]);
			char c5 = char.ToLower(text[2]);
			char c6 = char.ToLower(text[3]);
			char c7 = char.ToLower(text[4]);
			char c8 = char.ToLower(text[5]);
			char c9 = char.ToLower(text[6]);
			if (Class4246.smethod_0(c4) && Class4246.smethod_0(c5) && Class4246.smethod_0(c6) && Class4246.smethod_0(c7) && Class4246.smethod_0(c8) && Class4246.smethod_0(c9))
			{
				int value = (Class4246.smethod_1(c4) << 4) | Class4246.smethod_1(c5);
				int value2 = (Class4246.smethod_1(c6) << 4) | Class4246.smethod_1(c7);
				int value3 = (Class4246.smethod_1(c8) << 4) | Class4246.smethod_1(c9);
				@interface = smethod_2(null, value);
				@interface = smethod_2(@interface, value2);
				@interface = smethod_2(@interface, value3);
				break;
			}
			throw Class4246.smethod_6(node);
		}
		case 3:
		{
			char c = char.ToLower(text[1]);
			char c2 = char.ToLower(text[2]);
			char c3 = char.ToLower(text[3]);
			if (Class4246.smethod_0(c) && Class4246.smethod_0(c2) && Class4246.smethod_0(c3))
			{
				int num = Class4246.smethod_1(c);
				num |= num << 4;
				int num2 = Class4246.smethod_1(c2);
				num2 |= num2 << 4;
				int num3 = Class4246.smethod_1(c3);
				num3 |= num3 << 4;
				@interface = smethod_2(null, num);
				@interface = smethod_2(@interface, num2);
				@interface = smethod_2(@interface, num3);
				break;
			}
			throw Class4246.smethod_6(node);
		}
		}
		return smethod_8(previous, 27, @interface.First);
	}

	public static Interface99 smethod_10(Interface99 previous, Interface105 dimension)
	{
		Class4251 @class = Class4251.smethod_0(dimension);
		short num = 1;
		int num2 = @class.method_3();
		switch (num2)
		{
		case 1:
			num = 1;
			num2 = @class.method_3();
			break;
		case 2:
			num = -1;
			num2 = @class.method_3();
			break;
		}
		switch (num2)
		{
		case 42:
			return new Class4239(previous, 0f, @class.method_2());
		case 13:
		{
			long result = 0L;
			if (long.TryParse(@class.method_2(), out result))
			{
				result *= num;
				if (result < -2147483647L)
				{
					return new Class4236(previous, -2147483647);
				}
				if (result > 2147483647L)
				{
					return new Class4236(previous, int.MaxValue);
				}
			}
			return new Class4236(previous, (int)result);
		}
		default:
		{
			float value = float.Parse(@class.method_2(), Class3726.cultureInfo_0) * (float)num;
			return new Class4238((short)num2, value, previous);
		}
		}
	}

	public static Interface99 smethod_11(Interface99 previous, Interface105 node)
	{
		int num = node.Text.IndexOf('(');
		num++;
		string text = node.Text.Substring(num, node.Text.Length - 1 - num);
		text = text.Trim('\'', '"', '\t', '\n', '\f', '\r', ' ');
		string[] array = text.Split('%');
		StringBuilder stringBuilder = new StringBuilder(array[0]);
		for (int i = 1; i < array.Length; i++)
		{
			if (array[i].Length >= 2)
			{
				string s = array[i].Substring(0, 2);
				if (int.TryParse(s, NumberStyles.HexNumber, Class3726.cultureInfo_0, out var result))
				{
					stringBuilder.AppendFormat("{0}{1}", (char)result, array[i].Substring(2));
				}
				else
				{
					stringBuilder.AppendFormat("%{0}", array[i]);
				}
			}
			else
			{
				stringBuilder.AppendFormat("%{0}", array[i]);
			}
		}
		text = stringBuilder.ToString();
		if (text.IndexOf('\\') != -1)
		{
			text = regex_0.Replace(text, smethod_12);
		}
		return new Class4235(previous, text);
	}

	private static string smethod_12(Match match)
	{
		return match.ToString().Substring(1);
	}

	public static IList<Interface99> smethod_13(Interface99 lu)
	{
		List<Interface99> list = new List<Interface99>();
		do
		{
			Class4233 @class = (Class4233)lu;
			Interface99 nextLexicalUnit = lu.NextLexicalUnit;
			if (@class.interface99_0 != null)
			{
				((Class4233)@class.interface99_0).interface99_1 = null;
				@class.interface99_0 = null;
			}
			if (@class.interface99_1 != null)
			{
				((Class4233)@class.interface99_1).interface99_0 = null;
				@class.interface99_1 = null;
			}
			list.Add(lu);
			lu = nextLexicalUnit;
		}
		while (lu != null);
		return list;
	}

	public static Interface99 smethod_14(IList<Interface99> lunits)
	{
		IEnumerator<Interface99> enumerator = lunits.GetEnumerator();
		enumerator.MoveNext();
		Class4233 @class = (Class4233)enumerator.Current;
		while (enumerator.MoveNext())
		{
			Class4233 class2 = (Class4233)enumerator.Current;
			class2.interface99_0 = @class;
			@class.interface99_1 = class2;
			@class = class2;
		}
		return @class;
	}
}
