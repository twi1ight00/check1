using System;
using System.Drawing;
using ns218;

namespace ns271;

internal class Class6725
{
	internal uint uint_0;

	internal uint uint_1;

	internal uint uint_2;

	internal uint uint_3;

	internal ushort ushort_0;

	internal ushort ushort_1;

	internal short short_0;

	internal short short_1;

	internal short short_2;

	internal short short_3;

	internal ushort ushort_2;

	internal ushort ushort_3;

	internal short short_4;

	internal short short_5;

	internal short short_6;

	internal FontStyle Style
	{
		get
		{
			FontStyle fontStyle = FontStyle.Regular;
			fontStyle = FontStyle.Regular | ((((uint)ushort_2 & (true ? 1u : 0u)) != 0) ? FontStyle.Bold : FontStyle.Regular);
			fontStyle |= (((ushort_2 & 2u) != 0) ? FontStyle.Italic : FontStyle.Regular);
			return fontStyle | (((ushort_2 & 4u) != 0) ? FontStyle.Underline : FontStyle.Regular);
		}
	}

	internal Class6725(Class5950 reader)
	{
		uint_0 = reader.method_1();
		if (uint_0 != 65536)
		{
			throw new NotSupportedException("Unsupported font head version.");
		}
		uint_1 = reader.method_1();
		uint_2 = reader.method_1();
		uint_3 = reader.method_1();
		if (uint_3 != 1594834165)
		{
			throw new NotSupportedException("Unsupported font head magic number.");
		}
		ushort_0 = reader.method_3();
		ushort_1 = reader.method_3();
		reader.method_0();
		reader.method_0();
		reader.method_0();
		reader.method_0();
		short_0 = reader.method_2();
		short_1 = reader.method_2();
		short_2 = reader.method_2();
		short_3 = reader.method_2();
		ushort_2 = reader.method_3();
		ushort_3 = reader.method_3();
		short_4 = reader.method_2();
		short_5 = reader.method_2();
		short_6 = reader.method_2();
	}
}
