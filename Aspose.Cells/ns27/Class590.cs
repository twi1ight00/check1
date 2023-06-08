using System;
using Aspose.Cells.Drawing;

namespace ns27;

internal class Class590 : Class538
{
	internal Class590(PicFormatOption picFormatOption_0)
	{
		method_2(4156);
		method_0(14);
		byte_0 = new byte[base.Length];
		switch (picFormatOption_0.Type)
		{
		case FillPictureType.Stretch:
			byte_0[0] = 1;
			break;
		case FillPictureType.Stack:
			byte_0[0] = 2;
			break;
		case FillPictureType.StackAndScale:
			byte_0[0] = 3;
			break;
		}
		Array.Copy(BitConverter.GetBytes(picFormatOption_0.ushort_1), 0, byte_0, 2, 2);
		Array.Copy(BitConverter.GetBytes(picFormatOption_0.method_0()), 0, byte_0, 4, 2);
		Array.Copy(BitConverter.GetBytes(picFormatOption_0.Scale), 0, byte_0, 6, 8);
	}
}
