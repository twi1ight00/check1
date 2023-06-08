using System.Drawing;
using ns218;

namespace ns271;

internal class Class6726
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

	internal Class6726(Class5950 reader)
	{
		ushort_0 = reader.method_3();
		short_0 = reader.method_2();
		ushort_1 = reader.method_3();
		ushort_2 = reader.method_3();
		ushort_3 = reader.method_3();
		short_1 = reader.method_2();
		short_2 = reader.method_2();
		short_3 = reader.method_2();
		short_4 = reader.method_2();
		short_5 = reader.method_2();
		short_6 = reader.method_2();
		short_7 = reader.method_2();
		short_8 = reader.method_2();
		short_9 = reader.method_2();
		short_10 = reader.method_2();
		short_11 = reader.method_2();
		byte_0 = reader.method_8(10);
		uint_0 = reader.method_1();
		if (ushort_0 > 0)
		{
			uint_1 = reader.method_1();
			uint_2 = reader.method_1();
			uint_3 = reader.method_1();
		}
		byte_1 = reader.method_8(4);
		ushort_4 = reader.method_3();
		ushort_5 = reader.method_3();
		ushort_6 = reader.method_3();
		short_12 = reader.method_2();
		short_13 = reader.method_2();
		short_14 = reader.method_2();
		ushort_7 = reader.method_3();
		ushort_8 = reader.method_3();
		if (ushort_0 > 0)
		{
			uint_4 = reader.method_1();
			uint_5 = reader.method_1();
			if (ushort_0 > 1)
			{
				short_15 = reader.method_2();
				short_16 = reader.method_2();
				ushort_9 = reader.method_3();
				ushort_10 = reader.method_3();
				ushort_11 = reader.method_3();
			}
		}
	}
}
