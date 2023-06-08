using System.Drawing;
using ns18;

namespace ns47;

internal class Class1454
{
	internal ushort ushort_0;

	internal short short_0;

	internal ushort ushort_1;

	internal ushort ushort_2;

	internal ushort ushort_3;

	internal short short_1;

	internal short short_2;

	internal short short_3;

	internal short short_4;

	internal short short_5;

	internal short short_6;

	internal short short_7;

	internal short short_8;

	internal short short_9;

	internal short short_10;

	internal short short_11;

	internal byte[] byte_0;

	internal uint uint_0;

	internal uint uint_1;

	internal uint uint_2;

	internal uint uint_3;

	internal byte[] byte_1;

	internal ushort ushort_4;

	internal ushort ushort_5;

	internal ushort ushort_6;

	internal short short_12;

	internal short short_13;

	internal short short_14;

	internal ushort ushort_7;

	internal ushort ushort_8;

	internal uint uint_4;

	internal uint uint_5;

	internal short short_15;

	internal short short_16;

	internal ushort ushort_9;

	internal ushort ushort_10;

	internal ushort ushort_11;

	internal FontStyle Style
	{
		get
		{
			FontStyle fontStyle = FontStyle.Regular;
			fontStyle = FontStyle.Regular | ((((uint)ushort_4 & (true ? 1u : 0u)) != 0) ? FontStyle.Italic : FontStyle.Regular);
			fontStyle |= (((ushort_4 & 2u) != 0) ? FontStyle.Underline : FontStyle.Regular);
			fontStyle |= (((ushort_4 & 0x10u) != 0) ? FontStyle.Strikeout : FontStyle.Regular);
			return fontStyle | (((ushort_4 & 0x20u) != 0) ? FontStyle.Bold : FontStyle.Regular);
		}
	}

	internal Class1454(Class1393 class1393_0)
	{
		ushort_0 = class1393_0.method_4();
		short_0 = class1393_0.method_3();
		ushort_1 = class1393_0.method_4();
		ushort_2 = class1393_0.method_4();
		ushort_3 = class1393_0.method_4();
		short_1 = class1393_0.method_3();
		short_2 = class1393_0.method_3();
		short_3 = class1393_0.method_3();
		short_4 = class1393_0.method_3();
		short_5 = class1393_0.method_3();
		short_6 = class1393_0.method_3();
		short_7 = class1393_0.method_3();
		short_8 = class1393_0.method_3();
		short_9 = class1393_0.method_3();
		short_10 = class1393_0.method_3();
		short_11 = class1393_0.method_3();
		byte_0 = class1393_0.method_5(10);
		uint_0 = class1393_0.method_2();
		uint_1 = class1393_0.method_2();
		uint_2 = class1393_0.method_2();
		uint_3 = class1393_0.method_2();
		byte_1 = class1393_0.method_5(4);
		ushort_4 = class1393_0.method_4();
		ushort_5 = class1393_0.method_4();
		ushort_6 = class1393_0.method_4();
		short_12 = class1393_0.method_3();
		short_13 = class1393_0.method_3();
		short_14 = class1393_0.method_3();
		ushort_7 = class1393_0.method_4();
		ushort_8 = class1393_0.method_4();
		try
		{
			uint_4 = class1393_0.method_2();
			uint_5 = class1393_0.method_2();
			short_15 = class1393_0.method_3();
			short_16 = class1393_0.method_3();
			ushort_9 = class1393_0.method_4();
			ushort_10 = class1393_0.method_4();
			ushort_11 = class1393_0.method_4();
		}
		catch
		{
		}
	}
}
