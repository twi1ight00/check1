using System;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace ns18;

internal class Class1411 : Interface46
{
	private uint uint_0;

	private FontStyle fontStyle_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private string string_0;

	internal Class1411()
	{
		int_0 = 0;
		int_1 = 0;
		int_2 = 0;
		fontStyle_0 = FontStyle.Regular;
		bool_0 = false;
		bool_1 = false;
		bool_2 = false;
		string_0 = "Microsoft Sans Serif";
	}

	internal void method_0(Class1429 class1429_0)
	{
		int_0 = class1429_0.ReadInt16();
		class1429_0.ReadInt16();
		int_1 = class1429_0.ReadInt16();
		class1429_0.ReadInt16();
		int_2 = class1429_0.ReadInt16();
		bool_0 = class1429_0.ReadBoolean();
		bool_1 = class1429_0.ReadBoolean();
		class1429_0.ReadBoolean();
		class1429_0.ReadByte();
		class1429_0.ReadByte();
		class1429_0.ReadByte();
		class1429_0.ReadByte();
		class1429_0.ReadByte();
		string_0 = class1429_0.method_1(32).Trim();
	}

	internal void method_1(Class1420 class1420_0)
	{
		uint_0 = class1420_0.ReadUInt32();
		int_0 = class1420_0.ReadInt32();
		class1420_0.ReadInt32();
		int_1 = class1420_0.ReadInt32();
		class1420_0.ReadInt32();
		int_2 = class1420_0.ReadInt32();
		bool_0 = class1420_0.ReadBoolean();
		bool_1 = class1420_0.ReadBoolean();
		bool_2 = class1420_0.ReadBoolean();
		class1420_0.ReadByte();
		class1420_0.ReadByte();
		class1420_0.ReadByte();
		class1420_0.ReadByte();
		class1420_0.ReadByte();
		string text = class1420_0.method_2(32).Trim();
		char[] trimChars = new char[1];
		string_0 = text.TrimEnd(trimChars);
	}

	internal Class1396 method_2()
	{
		return Class1396.smethod_1(string_0, method_4(), method_3());
	}

	internal FontStyle method_3()
	{
		if (fontStyle_0 != 0)
		{
			return fontStyle_0;
		}
		if (int_2 >= 700)
		{
			fontStyle_0 |= FontStyle.Bold;
		}
		if (bool_0)
		{
			fontStyle_0 |= FontStyle.Italic;
		}
		if (bool_1)
		{
			fontStyle_0 |= FontStyle.Underline;
		}
		if (bool_2)
		{
			fontStyle_0 |= FontStyle.Strikeout;
		}
		return fontStyle_0;
	}

	private float method_4()
	{
		if (int_0 != 0)
		{
			return Math.Abs(int_0);
		}
		return 12f;
	}

	[SpecialName]
	Enum203 Interface46.get_Type()
	{
		return Enum203.const_6;
	}

	[SpecialName]
	public uint imethod_0()
	{
		return uint_0;
	}

	[SpecialName]
	public void imethod_1(uint uint_1)
	{
		uint_0 = uint_1;
	}

	[SpecialName]
	internal float method_5()
	{
		return (float)int_1 / 10f;
	}

	[SpecialName]
	internal void method_6(string string_1)
	{
		string_0 = string_1;
	}
}
