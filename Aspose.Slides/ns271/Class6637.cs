using System;
using ns218;

namespace ns271;

internal class Class6637 : Class6634
{
	internal uint uint_0;

	internal short short_0;

	internal short short_1;

	internal short short_2;

	internal ushort ushort_0;

	internal short short_3;

	internal short short_4;

	internal short short_5;

	internal short short_6;

	internal short short_7;

	internal short short_8;

	internal short short_9;

	internal short short_10;

	internal short short_11;

	internal short short_12;

	internal short short_13;

	internal ushort ushort_1;

	internal Class6637(Class5950 reader)
	{
		uint_0 = reader.method_1();
		if (uint_0 != 65536)
		{
			throw new NotSupportedException("Unsupported font head version.");
		}
		short_0 = reader.method_2();
		short_1 = reader.method_2();
		short_2 = reader.method_2();
		ushort_0 = reader.method_3();
		short_3 = reader.method_2();
		short_4 = reader.method_2();
		short_5 = reader.method_2();
		short_6 = reader.method_2();
		short_7 = reader.method_2();
		short_8 = reader.method_2();
		short_9 = reader.method_2();
		short_10 = reader.method_2();
		short_11 = reader.method_2();
		short_12 = reader.method_2();
		short_13 = reader.method_2();
		ushort_1 = reader.method_3();
	}

	internal override void Write(Class5951 writer)
	{
		writer.method_1(uint_0);
		writer.method_3(short_0);
		writer.method_3(short_1);
		writer.method_3(short_2);
		writer.method_3(ushort_0);
		writer.method_3(short_3);
		writer.method_3(short_4);
		writer.method_3(short_5);
		writer.method_3(short_6);
		writer.method_3(short_7);
		writer.method_3(short_8);
		writer.method_3(short_9);
		writer.method_3(short_10);
		writer.method_3(short_11);
		writer.method_3(short_12);
		writer.method_3(short_13);
		writer.method_3(ushort_1);
	}
}
