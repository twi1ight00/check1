using System;
using Aspose.Cells;
using Aspose.Cells.Charts;

namespace ns27;

internal class Class649 : Class538
{
	internal Class649(FileFormatType fileFormatType_1)
	{
		method_2(4117);
		fileFormatType_0 = fileFormatType_1;
		method_0(20);
		byte_0 = new byte[20];
		byte_0[16] = 3;
		byte_0[17] = 1;
		byte_0[18] = 31;
		byte_0[0] = 103;
		byte_0[1] = 13;
		byte_0[4] = 251;
		byte_0[5] = 5;
		byte_0[8] = 24;
		byte_0[9] = 2;
		byte_0[12] = 94;
		byte_0[13] = 2;
	}

	internal void method_4()
	{
		byte_0[16] = 7;
	}

	internal void method_5(Legend legend_0)
	{
		Array.Copy(BitConverter.GetBytes(legend_0.X), 0, byte_0, 0, 4);
		Array.Copy(BitConverter.GetBytes(legend_0.Y), 0, byte_0, 4, 4);
		int value = 0;
		if (legend_0.method_29() != 0)
		{
			value = legend_0.method_29();
		}
		else if (legend_0.IsAutoSize)
		{
			value = 532;
		}
		Array.Copy(BitConverter.GetBytes(value), 0, byte_0, 8, 4);
		value = 0;
		if (legend_0.method_26() != 0)
		{
			value = legend_0.method_26();
		}
		else if (legend_0.IsAutoSize)
		{
			value = 323;
		}
		Array.Copy(BitConverter.GetBytes(value), 0, byte_0, 12, 4);
		if (!legend_0.method_17())
		{
			byte_0[18] = 2;
			byte_0[16] = 7;
			if (legend_0.method_18())
			{
				byte_0[18] |= 4;
			}
			if (legend_0.method_20())
			{
				byte_0[18] |= 8;
			}
		}
		if (legend_0.method_45())
		{
			byte_0[18] |= 16;
		}
	}

	internal void method_6(byte byte_1)
	{
		byte_0[16] = byte_1;
		if (byte_1 == 0 || byte_1 == 2)
		{
			byte_0[18] &= 239;
		}
	}
}
