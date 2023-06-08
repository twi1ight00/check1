using System;
using System.Collections;
using System.Text;
using ns183;
using ns210;

namespace ns184;

internal class Class5729 : Interface240, Interface241
{
	private char char_0;

	public static int int_0 = 800;

	public static int int_1 = 700;

	public static int int_2 = 400;

	public static int int_3 = 200;

	public static string string_0 = "normal";

	public static string string_1 = "italic";

	public static string string_2 = "oblique";

	public static string string_3 = "inclined";

	public static int int_4 = 0;

	public static int int_5 = 131;

	public static int int_6 = 97;

	public static Class5732 class5732_0 = new Class5732("any", string_0, int_2, int_6, int_4);

	private string string_4;

	private Class5732 class5732_1;

	private int int_7;

	private int int_8;

	private Interface161 interface161_0;

	public Class5729(string key, Class5732 triplet, Interface161 met, int fontSize, int fontVariant)
	{
		string_4 = key;
		class5732_1 = triplet;
		interface161_0 = met;
		int_7 = fontSize;
		int_8 = fontVariant;
	}

	public Interface161 method_0()
	{
		return interface161_0;
	}

	public int method_1()
	{
		return interface161_0.imethod_6(int_7) / 1000;
	}

	public int method_2()
	{
		return interface161_0.imethod_7(int_7) / 1000;
	}

	public int method_3()
	{
		return interface161_0.imethod_8(int_7) / 1000;
	}

	public string method_4()
	{
		return string_4;
	}

	public Class5732 method_5()
	{
		return class5732_1;
	}

	public int method_6()
	{
		return int_7;
	}

	public int method_7()
	{
		return int_8;
	}

	public int method_8()
	{
		return interface161_0.imethod_9(int_7) / 1000;
	}

	public bool method_9()
	{
		return interface161_0.imethod_12();
	}

	public Hashtable method_10()
	{
		if (interface161_0.imethod_12())
		{
			return interface161_0.imethod_13();
		}
		return new Hashtable();
	}

	public int method_11(char ch1, char ch2)
	{
		Hashtable hashtable = (Hashtable)method_10()[(int)ch1];
		if (hashtable != null && hashtable.Contains((int)ch2))
		{
			int num = (int)hashtable[(int)ch2];
			return num * method_6() / 1000;
		}
		return 0;
	}

	public int method_12(int ch1, int ch2)
	{
		if (ch1 > 65536)
		{
			return 0;
		}
		if (ch1 >= 55296 && ch1 <= 57344)
		{
			return 0;
		}
		if (ch2 > 65536)
		{
			return 0;
		}
		if (ch2 >= 55296 && ch2 <= 57344)
		{
			return 0;
		}
		return method_11((char)ch1, (char)ch2);
	}

	public int method_13(int charnum)
	{
		return (int)((float)interface161_0.imethod_10(charnum, int_7) / 1000f);
	}

	public char method_14(char c)
	{
		if (interface161_0 is Class4986)
		{
			return ((Class4986)interface161_0).vmethod_1(c);
		}
		char c2 = Class5681.smethod_0("WinAnsiEncoding").imethod_1(c);
		c = ((c2 == char_0) ? Class4986.char_0 : c2);
		return c;
	}

	public bool method_15(char c)
	{
		if (interface161_0 is Class4986)
		{
			return ((Class4986)interface161_0).vmethod_2(c);
		}
		return Class5681.smethod_0("WinAnsiEncoding").imethod_1(c) > '\0';
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append('{');
		stringBuilder.Append(string_4);
		stringBuilder.Append(',');
		stringBuilder.Append(int_7);
		stringBuilder.Append('}');
		return stringBuilder.ToString();
	}

	public int method_16(char c)
	{
		int num;
		if (c != '\n' && c != '\r' && c != '\t' && c != '\u00a0')
		{
			if (method_15(c))
			{
				int charnum = method_14(c);
				num = method_13(charnum);
			}
			else
			{
				num = -1;
			}
			if (num <= 0)
			{
				int num2 = method_6();
				int num3 = num2 / 2;
				num = c switch
				{
					' ' => num2, 
					'\u2000' => num3, 
					'\u2001' => num2, 
					'\u2002' => num2 / 2, 
					'\u2003' => method_6(), 
					'\u2004' => num2 / 3, 
					'\u2005' => num2 / 4, 
					'\u2006' => num2 / 6, 
					'\u2007' => method_16('0'), 
					'\u2008' => method_16('.'), 
					'\u2009' => num2 / 5, 
					'\u200a' => num2 / 10, 
					'\u200b' => 0, 
					'\u202f' => method_16(' ') / 2, 
					'\u2060' => 0, 
					'\u3000' => method_16(' ') * 2, 
					'\ufeff' => 0, 
					_ => method_13(method_14(c)), 
				};
			}
		}
		else
		{
			num = method_16(' ');
		}
		return num;
	}

	public int method_17(int c)
	{
		if (c < 65536)
		{
			return method_16((char)c);
		}
		return -1;
	}

	public int method_18(string word)
	{
		if (word == null)
		{
			return 0;
		}
		int length = word.Length;
		int num = 0;
		char[] array = word.ToCharArray(0, length);
		for (int i = 0; i < length; i++)
		{
			num += method_16(array[i]);
		}
		return num;
	}

	public bool imethod_0()
	{
		if (interface161_0 is Interface240)
		{
			Interface240 @interface = (Interface240)interface161_0;
			return @interface.imethod_0();
		}
		return false;
	}

	public Interface238 imethod_1(Interface238 cs, string script, string language)
	{
		if (!(interface161_0 is Interface240))
		{
			throw new NotSupportedException();
		}
		Interface240 @interface = (Interface240)interface161_0;
		return @interface.imethod_1(cs, script, language);
	}

	public Interface238 imethod_2(Interface238 cs, int[][] gpa, string script, string language)
	{
		if (!(interface161_0 is Interface240))
		{
			throw new NotSupportedException();
		}
		Interface240 @interface = (Interface240)interface161_0;
		return @interface.imethod_2(cs, gpa, script, language);
	}

	public bool imethod_3()
	{
		if (interface161_0 is Interface241)
		{
			Interface241 @interface = (Interface241)interface161_0;
			return @interface.imethod_3();
		}
		return false;
	}

	public int[][] imethod_4(Interface238 cs, string script, string language, int fontSize)
	{
		if (!(interface161_0 is Interface241))
		{
			throw new NotSupportedException();
		}
		Interface241 @interface = (Interface241)interface161_0;
		return @interface.imethod_4(cs, script, language, fontSize);
	}

	public int[][] imethod_5(Interface238 cs, string script, string language)
	{
		return imethod_4(cs, script, language, int_7);
	}
}
