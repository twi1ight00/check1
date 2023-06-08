using System;

namespace ns52;

internal class Class1704
{
	internal byte byte_0;

	internal byte byte_1;

	internal byte[] byte_2;

	internal short short_0;

	internal int int_0;

	internal byte byte_3;

	internal byte byte_4;

	internal byte byte_5;

	internal Class1704()
	{
		byte_0 = 5;
		byte_1 = 5;
		short_0 = 255;
		int_0 = 1;
		byte_3 = 0;
		byte_4 = 0;
		byte_5 = 0;
	}

	internal void Copy(Class1704 class1704_0)
	{
		byte_0 = class1704_0.byte_0;
		byte_1 = class1704_0.byte_1;
		short_0 = class1704_0.short_0;
		int_0 = 0;
		byte_3 = class1704_0.byte_3;
		byte_4 = class1704_0.byte_4;
		byte_5 = class1704_0.byte_5;
		byte_2 = new byte[16];
		Array.Copy(class1704_0.byte_2, 0, byte_2, 0, 16);
	}
}
