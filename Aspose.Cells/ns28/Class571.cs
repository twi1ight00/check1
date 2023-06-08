using System;
using Aspose.Cells.Pivot;
using ns27;
using ns45;

namespace ns28;

internal class Class571 : Class538
{
	internal Class571(SxRng sxRng_0)
	{
		method_2(216);
		method_0(2);
		byte_0 = new byte[2];
		byte b = 0;
		if (sxRng_0.bool_0)
		{
			b = (byte)(b | 1u);
		}
		if (sxRng_0.bool_1)
		{
			b = (byte)(b | 2u);
		}
		int num = Class1156.smethod_4(sxRng_0.pivotGroupByType_0);
		b = (byte)(b | (byte)(num << 2));
		Array.Copy(sxRng_0.byte_0, byte_0, 2);
		byte_0[0] = b;
	}
}
