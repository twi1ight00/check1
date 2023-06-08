using System;
using System.Collections;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using ns2;

namespace ns27;

internal class Class715 : Class538
{
	internal Class715()
	{
		method_2(438);
		method_0(18);
		byte_0 = new byte[18];
		byte_0[1] = 2;
	}

	internal ArrayList method_4(Shape shape_0, Class1737 class1737_0, int int_0, ushort ushort_0)
	{
		bool flag = false;
		if (shape_0.method_58() != null)
		{
			switch (shape_0.MsoDrawingType)
			{
			case MsoDrawingType.Line:
			case MsoDrawingType.Rectangle:
			case MsoDrawingType.Oval:
			case MsoDrawingType.Arc:
			case MsoDrawingType.TextBox:
			case MsoDrawingType.Polygon:
			case MsoDrawingType.CellsDrawing:
				flag = true;
				break;
			}
		}
		if (flag)
		{
			int num = 6 + shape_0.method_58().Length;
			bool flag2;
			if (flag2 = num % 2 != 0)
			{
				num++;
			}
			method_0((short)(base.Length + (short)num));
			byte_0 = new byte[base.Length];
			Array.Copy(BitConverter.GetBytes((ushort)num), 0, byte_0, 16, 2);
			Array.Copy(BitConverter.GetBytes((ushort)shape_0.method_58().Length), 0, byte_0, 18, 2);
			Array.Copy(BitConverter.GetBytes(174200844), 0, byte_0, 20, 4);
			Array.Copy(shape_0.method_58(), 0, byte_0, 24, shape_0.method_58().Length);
			if (flag2)
			{
				byte_0[byte_0.Length - 1] = shape_0.method_58()[3];
			}
		}
		switch (class1737_0.TextHorizontalAlignment)
		{
		case TextAlignmentType.Center:
			byte_0[0] |= 4;
			break;
		case TextAlignmentType.Distributed:
			byte_0[0] |= 14;
			break;
		default:
			byte_0[0] |= 2;
			break;
		case TextAlignmentType.Justify:
			byte_0[0] |= 8;
			break;
		case TextAlignmentType.Left:
			byte_0[0] |= 2;
			break;
		case TextAlignmentType.Right:
			byte_0[0] |= 6;
			break;
		}
		switch (class1737_0.TextVerticalAlignment)
		{
		case TextAlignmentType.Top:
			byte_0[0] |= 16;
			break;
		case TextAlignmentType.Bottom:
			byte_0[0] |= 48;
			break;
		case TextAlignmentType.Center:
			byte_0[0] |= 32;
			break;
		case TextAlignmentType.Distributed:
			byte_0[0] |= 112;
			break;
		default:
			byte_0[0] |= 16;
			break;
		case TextAlignmentType.Justify:
			byte_0[0] |= 64;
			break;
		}
		switch (class1737_0.TextOrientationType)
		{
		case TextOrientationType.ClockWise:
			byte_0[2] = 3;
			break;
		case TextOrientationType.CounterClockWise:
			byte_0[2] = 2;
			break;
		case TextOrientationType.TopToBottom:
			byte_0[2] = 1;
			break;
		}
		if (!class1737_0.method_6())
		{
			byte_0[1] = 0;
		}
		if (ushort_0 == 0)
		{
			Array.Copy(BitConverter.GetBytes(ushort_0), 0, byte_0, 10, 2);
			Array.Copy(BitConverter.GetBytes(0), 0, byte_0, 12, 2);
			Array.Copy(BitConverter.GetBytes(int_0), 0, byte_0, 14, 2);
			return null;
		}
		ArrayList arrayList = new ArrayList();
		if (class1737_0.method_12() != null && class1737_0.method_12().Count != 0)
		{
			class1737_0.method_12().Sort(new Class1189());
			int num2 = 0;
			Struct85 @struct;
			foreach (FontSetting item in class1737_0.method_12())
			{
				if (item.StartIndex < num2)
				{
					if (item.StartIndex + item.Length <= num2)
					{
						continue;
					}
					@struct = default(Struct85);
					@struct.int_0 = num2;
					@struct.int_1 = int_0;
					arrayList.Add(@struct);
				}
				else
				{
					if (item.StartIndex > num2)
					{
						@struct = default(Struct85);
						@struct.int_0 = num2;
						@struct.int_1 = int_0;
						arrayList.Add(@struct);
					}
					@struct = default(Struct85);
					@struct.int_0 = item.StartIndex;
					if (item.method_2() == null)
					{
						@struct.int_1 = int_0;
					}
					else
					{
						@struct.int_1 = item.Font.method_21();
					}
					arrayList.Add(@struct);
				}
				num2 = item.StartIndex + item.Length;
			}
			if (num2 < ushort_0)
			{
				@struct = default(Struct85);
				@struct.int_0 = num2;
				@struct.int_1 = int_0;
				arrayList.Add(@struct);
			}
			@struct = default(Struct85);
			@struct.int_0 = ushort_0;
			@struct.int_1 = int_0;
			arrayList.Add(@struct);
		}
		else
		{
			Struct85 @struct = default(Struct85);
			@struct.int_0 = 0;
			@struct.int_1 = int_0;
			arrayList.Add(@struct);
			@struct = default(Struct85);
			@struct.int_0 = ushort_0;
			@struct.int_1 = int_0;
			arrayList.Add(@struct);
		}
		Array.Copy(BitConverter.GetBytes(ushort_0), 0, byte_0, 10, 2);
		Array.Copy(BitConverter.GetBytes(arrayList.Count * 8), 0, byte_0, 12, 2);
		return arrayList;
	}
}
