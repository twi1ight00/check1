using Aspose.Cells.Charts;

namespace ns27;

internal class Class710 : Class538
{
	internal Class710()
	{
		method_2(2135);
	}

	internal void method_4(bool bool_0, DisplayUnitType displayUnitType_0)
	{
		method_0(16);
		byte_0 = new byte[16];
		byte_0[0] = 87;
		byte_0[1] = 8;
		byte_0[4] = (byte)displayUnitType_0;
		byte_0[12] = 89;
		byte_0[13] = 64;
		if (bool_0)
		{
			byte_0[14] = 3;
		}
		else
		{
			byte_0[14] = 1;
		}
	}
}
