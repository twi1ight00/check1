using System;
using Aspose.Cells;

namespace ns27;

internal class Class719 : Class538
{
	internal Class719(FileFormatType fileFormatType_1)
	{
		method_2(574);
		fileFormatType_0 = fileFormatType_1;
		method_0(18);
		byte_0 = new byte[18];
	}

	private void method_4(int int_0)
	{
		if (int_0 > 65535)
		{
			int_0 = 65535;
		}
		Array.Copy(BitConverter.GetBytes((ushort)int_0), 0, byte_0, 2, 2);
	}

	private void method_5(int int_0)
	{
		byte_0[4] = (byte)int_0;
	}

	internal void method_6(Worksheet worksheet_0)
	{
		Array.Copy(BitConverter.GetBytes(worksheet_0.method_9()), 0, byte_0, 0, 2);
		if (worksheet_0.IsPageBreakPreview)
		{
			byte_0[1] |= 8;
		}
		method_4(worksheet_0.FirstVisibleRow);
		method_5(worksheet_0.FirstVisibleColumn);
		int num = worksheet_0.method_44();
		if (num == -1)
		{
			byte_0[6] = 64;
		}
		else
		{
			byte_0[6] = (byte)num;
		}
		Array.Copy(BitConverter.GetBytes(worksheet_0.method_39()[1]), 0, byte_0, 10, 2);
		Array.Copy(BitConverter.GetBytes(worksheet_0.method_39()[0]), 0, byte_0, 12, 2);
	}
}
