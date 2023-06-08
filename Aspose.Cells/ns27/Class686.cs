using System;
using Aspose.Cells;

namespace ns27;

internal class Class686 : Class538
{
	public Class686(int int_0, InternalColor internalColor_0)
	{
		method_2(2146);
		if (internalColor_0.ColorType == ColorType.Theme)
		{
			method_0(40);
			byte_0 = new byte[40];
			byte_0[12] = 40;
			byte_0[20] = (byte)int_0;
		}
		else
		{
			method_0(20);
			byte_0 = new byte[20];
			byte_0[12] = 20;
		}
		byte_0[0] = 98;
		byte_0[1] = 8;
		Array.Copy(BitConverter.GetBytes(int_0), 0, byte_0, 16, 4);
		if (internalColor_0.ColorType == ColorType.Theme)
		{
			Class579.smethod_6(internalColor_0, byte_0, 24);
		}
	}
}
