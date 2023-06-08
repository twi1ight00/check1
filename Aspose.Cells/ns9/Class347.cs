using System;
using Aspose.Cells;

namespace ns9;

internal class Class347 : Class316
{
	internal Class347()
	{
		int_0 = 168;
	}

	internal void method_6(ColorFilter colorFilter_0)
	{
		byte_0 = new byte[8];
		Array.Copy(BitConverter.GetBytes(colorFilter_0.method_1()), 0, byte_0, 0, 4);
		if (colorFilter_0.FilterByFillColor)
		{
			byte_0[4] = 1;
		}
	}
}
