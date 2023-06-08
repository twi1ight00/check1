using System;
using Aspose.Cells;
using Aspose.Cells.Charts;
using ns22;

namespace ns27;

internal class Class714 : Class538
{
	internal Class714(FileFormatType fileFormatType_1)
	{
		method_2(4126);
		fileFormatType_0 = fileFormatType_1;
		method_0(30);
		byte_0 = new byte[30];
		byte_0[26] = 77;
		byte_0[24] = 35;
		byte_0[0] = 1;
		byte_0[2] = 1;
		byte_0[3] = 1;
	}

	internal void method_4(Axis axis_0)
	{
		switch (axis_0.MajorTickMark)
		{
		case TickMarkType.Cross:
			byte_0[0] = 3;
			break;
		case TickMarkType.Inside:
			byte_0[0] = 1;
			break;
		case TickMarkType.None:
			byte_0[0] = 0;
			break;
		case TickMarkType.Outside:
			byte_0[0] = 2;
			break;
		}
		switch (axis_0.MinorTickMark)
		{
		case TickMarkType.Cross:
			byte_0[1] = 3;
			break;
		case TickMarkType.Inside:
			byte_0[1] = 1;
			break;
		case TickMarkType.None:
			byte_0[1] = 0;
			break;
		case TickMarkType.Outside:
			byte_0[1] = 2;
			break;
		}
		switch (axis_0.TickLabelPosition)
		{
		case TickLabelPositionType.High:
			byte_0[2] = 2;
			break;
		case TickLabelPositionType.Low:
			byte_0[2] = 1;
			break;
		case TickLabelPositionType.NextToAxis:
			byte_0[2] = 3;
			break;
		case TickLabelPositionType.None:
			byte_0[2] = 0;
			break;
		}
		TickLabels tickLabels = axis_0.method_14();
		if (tickLabels == null)
		{
			return;
		}
		Font font = tickLabels.method_0();
		if (font != null && font.ColorIndex >= 0 && font.ColorIndex != 32767 && font.ColorIndex != 32759 && !Class1178.smethod_0(font.Color))
		{
			Array.Copy(BitConverter.GetBytes((ushort)font.ColorIndex), 0, byte_0, 26, 2);
			byte_0[3] = 1;
			byte_0[4] = font.Color.R;
			byte_0[5] = font.Color.G;
			byte_0[6] = font.Color.B;
			byte_0[24] &= 254;
		}
		if ((tickLabels.RotationAngle >= -90 && tickLabels.RotationAngle <= 90) || tickLabels.RotationAngle == 255)
		{
			if (tickLabels.RotationAngle < 0)
			{
				byte_0[28] = (byte)(90 - tickLabels.RotationAngle);
			}
			else
			{
				byte_0[28] = (byte)tickLabels.RotationAngle;
			}
		}
		switch (tickLabels.RotationAngle)
		{
		case 0:
			byte_0[24] &= 243;
			if (!tickLabels.method_5())
			{
				byte_0[24] &= 223;
			}
			break;
		case -90:
			byte_0[24] |= 12;
			byte_0[24] &= 223;
			break;
		default:
			byte_0[24] &= 243;
			byte_0[24] &= 223;
			break;
		case 255:
			byte_0[24] |= 4;
			byte_0[24] &= 223;
			break;
		case 90:
			byte_0[24] |= 8;
			byte_0[24] &= 223;
			break;
		}
		switch (tickLabels.TextDirection)
		{
		case TextDirectionType.LeftToRight:
			byte_0[25] |= 64;
			break;
		case TextDirectionType.RightToLeft:
			byte_0[25] |= 128;
			break;
		}
		switch (tickLabels.BackgroundMode)
		{
		case BackgroundMode.Opaque:
			byte_0[24] &= 253;
			byte_0[3] = 2;
			break;
		case BackgroundMode.Transparent:
			byte_0[24] &= 253;
			byte_0[3] = 1;
			break;
		}
	}
}
