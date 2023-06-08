using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using ns2;

namespace ns14;

internal class Class518
{
	private static readonly char[] char_0 = new char[0];

	private static readonly int[] int_0 = new int[1] { smethod_0(bool_1: true, 0, '#') };

	private char[] char_1;

	private int[] int_1;

	private Enum136 enum136_0;

	private Color color_0 = Color.Empty;

	private bool bool_0;

	public char[] Value => char_1;

	public string StringValue
	{
		get
		{
			if (char_1 == null)
			{
				return "";
			}
			return new string(char_1);
		}
	}

	public Color Color => color_0;

	internal void Reset()
	{
		enum136_0 = Enum136.const_7;
		char_1 = null;
		int_1 = null;
		color_0 = Color.Empty;
		bool_0 = false;
	}

	internal void method_0(Enum136 enum136_1, string string_0)
	{
		enum136_0 = enum136_1;
		char_1 = string_0.ToCharArray();
	}

	internal void method_1(Enum136 enum136_1, char[] char_2)
	{
		enum136_0 = enum136_1;
		char_1 = char_2;
	}

	internal void method_2()
	{
		enum136_0 = Enum136.const_1;
		char_1 = char_0;
	}

	internal void method_3(char char_2)
	{
		bool_0 = true;
		method_2();
		if (char_2 == '#')
		{
			int_1 = int_0;
			return;
		}
		int_1 = new int[1] { smethod_0(bool_1: true, 0, char_2) };
	}

	[SpecialName]
	public bool method_4()
	{
		return bool_0;
	}

	[SpecialName]
	public Enum136 method_5()
	{
		return enum136_0;
	}

	public string method_6(int int_2, bool bool_1)
	{
		if (int_1 == null)
		{
			return StringValue;
		}
		if (int_2 < 0)
		{
			int_2 = 0;
		}
		int num = 0;
		for (int i = 0; i < int_1.Length; i++)
		{
			if (method_10(i))
			{
				num++;
			}
		}
		char[] array = new char[char_1.Length + ((num > 0) ? (int_1.Length - num + int_2) : int_1.Length)];
		int num2 = array.Length;
		int num3 = char_1.Length;
		bool flag = false;
		if (int_2 < 1)
		{
			num = 0;
		}
		for (int num4 = int_1.Length - 1; num4 > -1; num4--)
		{
			flag = false;
			if (method_10(num4))
			{
				if (num < 1)
				{
					continue;
				}
				num = 0;
				flag = true;
			}
			int num5 = method_11(num4);
			int num6 = num3 - num5;
			if (num6 > 0)
			{
				Array.Copy(char_1, num5, array, num2 - num6, num6);
			}
			num3 = num5;
			num2 -= num6;
			if (flag)
			{
				char c = method_13(num4);
				for (int j = 0; j < int_2; j++)
				{
					array[--num2] = c;
				}
			}
			else
			{
				array[--num2] = (bool_1 ? ' ' : method_13(num4));
			}
		}
		if (num3 > 0)
		{
			Array.Copy(char_1, 0, array, 0, num3);
		}
		return new string(array);
	}

	internal void SetColor(Color color_1)
	{
		color_0 = color_1;
	}

	internal void method_7(int[] int_2)
	{
		int_1 = int_2;
	}

	[SpecialName]
	internal int[] method_8()
	{
		return int_1;
	}

	[SpecialName]
	public int method_9()
	{
		if (int_1 != null)
		{
			return int_1.Length;
		}
		return 0;
	}

	public bool method_10(int int_2)
	{
		return (int_1[int_2] & 0x80000000u) != 0;
	}

	public int method_11(int int_2)
	{
		return (int_1[int_2] & 0x7FFF0000) >> 16;
	}

	internal void method_12(int int_2, int int_3)
	{
		int_1[int_2] &= -2147418113;
		int_1[int_2] |= int_3 << 16;
	}

	public char method_13(int int_2)
	{
		return (char)((uint)int_1[int_2] & 0xFFFFu);
	}

	internal static int smethod_0(bool bool_1, int int_2, char char_2)
	{
		int num = (bool_1 ? int.MinValue : 0);
		num |= int_2 << 16;
		return num | char_2;
	}
}
