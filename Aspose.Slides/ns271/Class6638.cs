using System;
using ns218;

namespace ns271;

internal class Class6638 : Class6634
{
	internal uint uint_0;

	internal ushort ushort_0;

	internal ushort ushort_1;

	internal ushort ushort_2;

	internal ushort ushort_3;

	internal ushort ushort_4;

	internal ushort ushort_5;

	internal ushort ushort_6;

	internal ushort ushort_7;

	internal ushort ushort_8;

	internal ushort ushort_9;

	internal ushort ushort_10;

	internal ushort ushort_11;

	internal ushort ushort_12;

	internal ushort ushort_13;

	internal Class6638(Class5950 reader)
	{
		uint_0 = reader.method_1();
		ushort_0 = reader.method_3();
		if (uint_0 != 20480)
		{
			if (uint_0 != 65536)
			{
				throw new NotSupportedException("Unsupported maximum profile version.");
			}
			ushort_1 = reader.method_3();
			ushort_2 = reader.method_3();
			ushort_3 = reader.method_3();
			ushort_4 = reader.method_3();
			ushort_5 = reader.method_3();
			ushort_6 = reader.method_3();
			ushort_7 = reader.method_3();
			ushort_8 = reader.method_3();
			ushort_9 = reader.method_3();
			ushort_10 = reader.method_3();
			ushort_11 = reader.method_3();
			ushort_12 = reader.method_3();
			ushort_13 = reader.method_3();
		}
	}

	internal override void Write(Class5951 writer)
	{
		writer.method_1(uint_0);
		writer.method_3(ushort_0);
		if (uint_0 != 20480)
		{
			writer.method_3(ushort_1);
			writer.method_3(ushort_2);
			writer.method_3(ushort_3);
			writer.method_3(ushort_4);
			writer.method_3(ushort_5);
			writer.method_3(ushort_6);
			writer.method_3(ushort_7);
			writer.method_3(ushort_8);
			writer.method_3(ushort_9);
			writer.method_3(ushort_10);
			writer.method_3(ushort_11);
			writer.method_3(ushort_12);
			writer.method_3(ushort_13);
		}
	}
}
