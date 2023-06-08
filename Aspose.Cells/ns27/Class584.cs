using System;
using Aspose.Cells;

namespace ns27;

internal class Class584 : Class538
{
	internal Class584()
	{
		method_2(2187);
	}

	internal void method_4(Worksheet worksheet_0)
	{
		method_0(16);
		byte_0 = new byte[base.Length];
		byte_0[0] = 139;
		byte_0[1] = 8;
		if (worksheet_0.method_39() != null)
		{
			Array.Copy(BitConverter.GetBytes((ushort)worksheet_0.method_39()[2]), 0, byte_0, 12, 2);
		}
		else
		{
			byte_0[12] = 100;
		}
		byte_0[14] = 64;
		if (worksheet_0.ViewType == ViewType.PageLayoutView)
		{
			byte_0[14] |= 1;
		}
		if (worksheet_0.IsRulerVisible)
		{
			byte_0[14] |= 2;
		}
	}
}
