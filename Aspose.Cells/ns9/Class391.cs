using System;
using Aspose.Cells;

namespace ns9;

internal class Class391 : Class316
{
	internal Class391()
	{
		int_0 = 170;
	}

	internal void method_6(Top10Filter top10Filter_0)
	{
		byte_0 = new byte[17];
		byte b = 0;
		if (top10Filter_0.IsTop)
		{
			b = (byte)(b | 1u);
		}
		if (top10Filter_0.IsPercent)
		{
			b = (byte)(b | 2u);
		}
		if (top10Filter_0.Criteria != null)
		{
			b = (byte)(b | 4u);
		}
		byte_0[0] = b;
		Array.Copy(BitConverter.GetBytes((double)top10Filter_0.Items), 0, byte_0, 1, 8);
		if (top10Filter_0.Criteria != null)
		{
			Array.Copy(BitConverter.GetBytes((double)top10Filter_0.Criteria), 0, byte_0, 9, 8);
		}
	}
}
