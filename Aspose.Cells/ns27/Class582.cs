using System;
using Aspose.Cells;

namespace ns27;

internal class Class582 : Class538
{
	internal Class582()
	{
		method_2(2169);
	}

	internal void method_4(FormatConditionCollection formatConditionCollection_0, int int_0, int int_1)
	{
		int rangeCount = formatConditionCollection_0.RangeCount;
		method_0((short)(26 + rangeCount * 8));
		byte_0 = new byte[base.Length];
		byte_0[0] = 121;
		byte_0[1] = 8;
		byte_0[2] = 1;
		int num = 12;
		Array.Copy(BitConverter.GetBytes((short)int_0), 0, byte_0, 12, 2);
		num = 12 + 2;
		Array.Copy(BitConverter.GetBytes((short)((int_1 << 1) | (formatConditionCollection_0.bool_0 ? 1 : 0))), 0, byte_0, num, 2);
		num += 10;
		Array.Copy(BitConverter.GetBytes((ushort)rangeCount), 0, byte_0, num, 2);
		num += 2;
		int num2 = 65535;
		int num3 = 255;
		int num4 = 0;
		int num5 = 0;
		byte[] byte_ = byte_0;
		for (int i = 0; i < rangeCount; i++)
		{
			CellArea cellArea_ = (CellArea)formatConditionCollection_0.arrayList_1[i];
			if (cellArea_.StartRow < num2)
			{
				num2 = cellArea_.StartRow;
			}
			if (cellArea_.StartColumn < num3)
			{
				num3 = cellArea_.StartColumn;
			}
			if (cellArea_.EndRow > num4)
			{
				num4 = cellArea_.EndRow;
			}
			if (cellArea_.EndColumn > num5)
			{
				num5 = cellArea_.EndColumn;
			}
			num += smethod_0(byte_, num, cellArea_);
		}
		Array.Copy(BitConverter.GetBytes((ushort)num2), 0, byte_0, 4, 2);
		Array.Copy(BitConverter.GetBytes((ushort)num4), 0, byte_0, 6, 2);
		Array.Copy(BitConverter.GetBytes((ushort)num3), 0, byte_0, 8, 2);
		Array.Copy(BitConverter.GetBytes((ushort)num5), 0, byte_0, 10, 2);
		Array.Copy(byte_0, 4, byte_0, 16, 8);
	}

	internal static int smethod_0(byte[] byte_1, int int_0, CellArea cellArea_0)
	{
		Array.Copy(BitConverter.GetBytes((ushort)cellArea_0.StartRow), 0, byte_1, int_0, 2);
		Array.Copy(BitConverter.GetBytes((ushort)cellArea_0.EndRow), 0, byte_1, int_0 + 2, 2);
		Array.Copy(BitConverter.GetBytes((ushort)cellArea_0.StartColumn), 0, byte_1, int_0 + 4, 2);
		Array.Copy(BitConverter.GetBytes((ushort)cellArea_0.EndColumn), 0, byte_1, int_0 + 6, 2);
		return 8;
	}
}
