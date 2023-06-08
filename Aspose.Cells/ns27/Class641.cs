using Aspose.Cells.Charts;

namespace ns27;

internal class Class641 : Class538
{
	internal Class641(byte byte_1)
	{
		method_2(4146);
		method_0(4);
		byte_0 = new byte[4];
		byte_0[2] = byte_1;
	}

	internal void method_4(ChartFrame chartFrame_0)
	{
		if (chartFrame_0.Shadow)
		{
			byte_0[0] |= 4;
		}
	}
}
