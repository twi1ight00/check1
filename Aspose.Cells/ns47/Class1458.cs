using System;
using System.IO;
using ns18;

namespace ns47;

internal class Class1458
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

	internal Class1458(Class1393 class1393_0)
	{
		uint_0 = class1393_0.method_2();
		ushort_0 = class1393_0.method_4();
		if (uint_0 != 20480)
		{
			if (uint_0 != 65536)
			{
				throw new NotSupportedException("Unsupported maximum profile version.");
			}
			ushort_1 = class1393_0.method_4();
			ushort_2 = class1393_0.method_4();
			ushort_3 = class1393_0.method_4();
			ushort_4 = class1393_0.method_4();
			ushort_5 = class1393_0.method_4();
			ushort_6 = class1393_0.method_4();
			ushort_7 = class1393_0.method_4();
			ushort_8 = class1393_0.method_4();
			ushort_9 = class1393_0.method_4();
			ushort_10 = class1393_0.method_4();
			ushort_11 = class1393_0.method_4();
			ushort_12 = class1393_0.method_4();
			ushort_13 = class1393_0.method_4();
		}
	}

	internal void Write(Class1394 class1394_0)
	{
		class1394_0.method_2(uint_0);
		class1394_0.method_4(ushort_0);
		if (uint_0 != 20480)
		{
			class1394_0.method_4(ushort_1);
			class1394_0.method_4(ushort_2);
			class1394_0.method_4(ushort_3);
			class1394_0.method_4(ushort_4);
			class1394_0.method_4(ushort_5);
			class1394_0.method_4(ushort_6);
			class1394_0.method_4(ushort_7);
			class1394_0.method_4(ushort_8);
			class1394_0.method_4(ushort_9);
			class1394_0.method_4(ushort_10);
			class1394_0.method_4(ushort_11);
			class1394_0.method_4(ushort_12);
			class1394_0.method_4(ushort_13);
		}
	}

	internal MemoryStream method_0()
	{
		MemoryStream memoryStream = new MemoryStream();
		Class1394 @class = new Class1394(memoryStream);
		Write(@class);
		@class.Flush();
		return memoryStream;
	}
}
