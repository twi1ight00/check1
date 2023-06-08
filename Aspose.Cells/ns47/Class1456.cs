using System;
using System.IO;
using ns18;

namespace ns47;

internal class Class1456
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

	internal Class1456(Class1393 class1393_0)
	{
		uint_0 = class1393_0.method_2();
		if (uint_0 != 65536)
		{
			throw new NotSupportedException("Unsupported font head version.");
		}
		short_0 = class1393_0.method_3();
		short_1 = class1393_0.method_3();
		short_2 = class1393_0.method_3();
		ushort_0 = class1393_0.method_4();
		short_3 = class1393_0.method_3();
		short_4 = class1393_0.method_3();
		short_5 = class1393_0.method_3();
		short_6 = class1393_0.method_3();
		short_7 = class1393_0.method_3();
		short_8 = class1393_0.method_3();
		short_9 = class1393_0.method_3();
		short_10 = class1393_0.method_3();
		short_11 = class1393_0.method_3();
		short_12 = class1393_0.method_3();
		short_13 = class1393_0.method_3();
		ushort_1 = class1393_0.method_4();
	}

	internal void Write(Class1394 class1394_0)
	{
		class1394_0.method_2(uint_0);
		class1394_0.method_3(short_0);
		class1394_0.method_3(short_1);
		class1394_0.method_3(short_2);
		class1394_0.method_4(ushort_0);
		class1394_0.method_3(short_3);
		class1394_0.method_3(short_4);
		class1394_0.method_3(short_5);
		class1394_0.method_3(short_6);
		class1394_0.method_3(short_7);
		class1394_0.method_3(short_8);
		class1394_0.method_3(short_9);
		class1394_0.method_3(short_10);
		class1394_0.method_3(short_11);
		class1394_0.method_3(short_12);
		class1394_0.method_3(short_13);
		class1394_0.method_4(ushort_1);
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
