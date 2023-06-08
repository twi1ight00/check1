using System;
using ns18;

namespace ns47;

internal class Class1453
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

	internal Class1453(Class1393 class1393_0)
	{
		uint_0 = class1393_0.method_2();
		if (uint_0 != 65536)
		{
			throw new NotSupportedException("Unsupported font head version.");
		}
		uint_1 = class1393_0.method_2();
		uint_2 = class1393_0.method_2();
		uint_3 = class1393_0.method_2();
		if (uint_3 != 1594834165)
		{
			throw new NotSupportedException("Unsupported font head magic number.");
		}
		ushort_0 = class1393_0.method_4();
		ushort_1 = class1393_0.method_4();
		class1393_0.method_1();
		class1393_0.method_1();
		class1393_0.method_1();
		class1393_0.method_1();
		short_0 = class1393_0.method_3();
		short_1 = class1393_0.method_3();
		short_2 = class1393_0.method_3();
		short_3 = class1393_0.method_3();
		ushort_2 = class1393_0.method_4();
		ushort_3 = class1393_0.method_4();
		short_4 = class1393_0.method_3();
		short_5 = class1393_0.method_3();
		short_6 = class1393_0.method_3();
	}
}
