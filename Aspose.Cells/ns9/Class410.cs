using System;
using Aspose.Cells;
using ns10;
using ns16;

namespace ns9;

internal class Class410 : Class316
{
	internal Class410()
	{
		int_0 = 47;
	}

	internal void method_6(Class1571 class1571_0)
	{
		byte_0 = new byte[16];
		if (!class1571_0.bool_0)
		{
			byte_0[0] = byte.MaxValue;
			byte_0[1] = byte.MaxValue;
		}
		else
		{
			Array.Copy(BitConverter.GetBytes(class1571_0.int_5), 0, byte_0, 0, 2);
		}
		Array.Copy(BitConverter.GetBytes(class1571_0.int_1), 0, byte_0, 2, 2);
		if (class1571_0.int_2 > 4)
		{
			Array.Copy(BitConverter.GetBytes(class1571_0.int_2 - 1), 0, byte_0, 4, 2);
		}
		else
		{
			Array.Copy(BitConverter.GetBytes(class1571_0.int_2), 0, byte_0, 4, 2);
		}
		Array.Copy(BitConverter.GetBytes(class1571_0.int_3), 0, byte_0, 6, 2);
		Array.Copy(BitConverter.GetBytes(class1571_0.int_4), 0, byte_0, 8, 2);
		int num = 0;
		Style style_ = class1571_0.style_0;
		if (class1571_0.class1525_0 != null)
		{
			byte_0[10] = (byte)class1571_0.class1525_0.int_0;
			byte_0[11] = (byte)class1571_0.class1525_0.int_1;
			num |= Class1224.smethod_9(class1571_0.class1525_0.textAlignmentType_0);
			num |= Class1224.smethod_7(class1571_0.class1525_0.textAlignmentType_1) << 3;
			if (class1571_0.class1525_0.bool_0)
			{
				num |= 0x40;
			}
			byte_0[12] = (byte)num;
			num = 0;
			if (class1571_0.class1525_0.bool_1)
			{
				num |= 1;
			}
			if (class1571_0.class1525_0.textDirectionType_0 == TextDirectionType.LeftToRight)
			{
				num |= 4;
			}
			else if (class1571_0.class1525_0.textDirectionType_0 == TextDirectionType.RightToLeft)
			{
				num |= 8;
			}
		}
		else
		{
			TextAlignmentType horizontalAlignment = style_.HorizontalAlignment;
			TextAlignmentType verticalAlignment = style_.VerticalAlignment;
			num |= Class1224.smethod_9(horizontalAlignment);
			num |= Class1224.smethod_7(verticalAlignment) << 3;
			byte_0[12] = (byte)num;
			num = 0;
			if (style_.ShrinkToFit)
			{
				num |= 1;
			}
			if (style_.TextDirection == TextDirectionType.LeftToRight)
			{
				num |= 4;
			}
			else if (style_.TextDirection == TextDirectionType.RightToLeft)
			{
				num |= 8;
			}
		}
		if (class1571_0.class1563_0 != null)
		{
			if (class1571_0.class1563_0.bool_0)
			{
				num |= 0x10;
			}
			if (class1571_0.class1563_0.bool_1)
			{
				num |= 0x20;
			}
		}
		else
		{
			num |= 0x10;
		}
		byte_0[13] = (byte)num;
		num = 0;
		if (class1571_0.bool_0)
		{
			if (class1571_0.bool_2)
			{
				num |= 1;
			}
			if (class1571_0.bool_3)
			{
				num |= 2;
			}
			if (class1571_0.bool_6)
			{
				num |= 4;
			}
			if (class1571_0.bool_7)
			{
				num |= 0x20;
			}
		}
		else
		{
			if (!class1571_0.bool_2)
			{
				num |= 1;
			}
			if (!class1571_0.bool_3)
			{
				num |= 2;
			}
			if (!class1571_0.bool_6)
			{
				num |= 4;
			}
			if (!class1571_0.bool_5)
			{
				num |= 8;
			}
			if (!class1571_0.bool_4)
			{
				num |= 0x10;
			}
			if (!class1571_0.bool_7)
			{
				num |= 0x20;
			}
		}
		byte_0[14] = (byte)num;
	}
}
