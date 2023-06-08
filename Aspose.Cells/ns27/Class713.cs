using System;
using Aspose.Cells;
using Aspose.Cells.Charts;
using ns2;
using ns22;

namespace ns27;

internal class Class713 : Class538
{
	internal Class713(FileFormatType fileFormatType_1)
	{
		method_2(4133);
		fileFormatType_0 = fileFormatType_1;
		method_0(32);
		byte_0 = new byte[base.Length];
		byte_0[0] = 2;
		byte_0[1] = 2;
		byte_0[2] = 1;
		byte_0[8] = 214;
		byte_0[9] = byte.MaxValue;
		byte_0[10] = byte.MaxValue;
		byte_0[11] = byte.MaxValue;
		byte_0[12] = 186;
		byte_0[13] = byte.MaxValue;
		byte_0[14] = byte.MaxValue;
		byte_0[15] = byte.MaxValue;
		byte_0[24] = 177;
		byte_0[26] = 77;
		byte_0[28] = 80;
		byte_0[29] = 26;
	}

	internal void method_4(DataLabels dataLabels_0)
	{
		byte_0[28] |= 128;
		byte_0[29] |= 58;
		method_6(dataLabels_0);
		object obj = dataLabels_0.method_60();
		if (obj is Trendline)
		{
			byte_0[25] = 64;
			return;
		}
		if (obj is Series)
		{
			byte_0[24] |= 16;
		}
		byte_0[25] &= 7;
		if (dataLabels_0.ShowPercentage)
		{
			byte_0[25] |= 16;
		}
		if (dataLabels_0.ShowValue)
		{
			byte_0[24] |= 4;
		}
		if (ChartCollection.smethod_16(dataLabels_0.Chart.Type))
		{
			if (dataLabels_0.ShowSeriesName)
			{
				byte_0[25] |= 64;
			}
		}
		else if (dataLabels_0.ShowCategoryName)
		{
			byte_0[25] |= 64;
		}
		if (dataLabels_0.ShowBubbleSize)
		{
			byte_0[25] |= 32;
		}
		if (dataLabels_0.ShowPercentage && dataLabels_0.ShowCategoryName)
		{
			byte_0[25] |= 8;
		}
		if (dataLabels_0.method_62())
		{
			if (dataLabels_0.ShowPercentage)
			{
				byte_0[25] &= 19;
				byte_0[24] &= 251;
			}
			else if (dataLabels_0.ShowBubbleSize)
			{
				if (dataLabels_0.ShowValue)
				{
					byte_0[25] &= 15;
				}
				else if (dataLabels_0.ShowCategoryName)
				{
					byte_0[25] &= 79;
				}
				else
				{
					byte_0[25] &= 47;
				}
			}
			else if (dataLabels_0.ShowValue)
			{
				byte_0[25] &= 15;
			}
		}
		if (dataLabels_0.ShowLegendKey)
		{
			byte_0[24] |= 2;
		}
		if (!dataLabels_0.bool_15)
		{
			switch (dataLabels_0.Position)
			{
			case LabelPositionType.Center:
				byte_0[28] |= 3;
				break;
			case LabelPositionType.InsideBase:
				byte_0[28] |= 4;
				break;
			case LabelPositionType.InsideEnd:
				byte_0[28] |= 2;
				break;
			case LabelPositionType.OutsideEnd:
				byte_0[28] |= 1;
				break;
			case LabelPositionType.Above:
				byte_0[28] |= 5;
				break;
			case LabelPositionType.Below:
				byte_0[28] |= 6;
				break;
			case LabelPositionType.Left:
				byte_0[28] |= 7;
				break;
			case LabelPositionType.Right:
				byte_0[28] |= 8;
				break;
			case LabelPositionType.BestFit:
				byte_0[28] |= 9;
				break;
			case LabelPositionType.Moved:
				byte_0[28] |= 10;
				break;
			}
		}
	}

	internal void method_5(Font font_0)
	{
		if (font_0 != null && !Class1178.smethod_0(font_0.Color) && font_0.ColorIndex >= 0 && font_0.ColorIndex != 32767 && font_0.ColorIndex != 32759)
		{
			byte_0[24] &= 254;
			int value = font_0.Color.B * 65536 + font_0.Color.G * 256 + font_0.Color.R;
			Array.Copy(BitConverter.GetBytes(value), 0, byte_0, 4, 4);
			Array.Copy(BitConverter.GetBytes((ushort)font_0.ColorIndex), 0, byte_0, 26, 2);
		}
	}

	internal void method_6(DataLabels dataLabels_0)
	{
		byte_0[24] = 145;
		switch (dataLabels_0.TextHorizontalAlignment)
		{
		case TextAlignmentType.Center:
			byte_0[0] = 2;
			break;
		case TextAlignmentType.Distributed:
			byte_0[0] = 7;
			break;
		case TextAlignmentType.Justify:
			byte_0[0] = 4;
			break;
		case TextAlignmentType.Left:
			byte_0[0] = 1;
			break;
		case TextAlignmentType.Right:
			byte_0[0] = 3;
			break;
		}
		switch (dataLabels_0.TextVerticalAlignment)
		{
		case TextAlignmentType.Top:
			byte_0[1] = 1;
			break;
		case TextAlignmentType.Bottom:
			byte_0[1] = 3;
			break;
		case TextAlignmentType.Center:
			byte_0[1] = 2;
			break;
		case TextAlignmentType.Distributed:
			byte_0[1] = 7;
			break;
		case TextAlignmentType.Justify:
			byte_0[1] = 4;
			break;
		}
		if (dataLabels_0.method_41() != null && !(dataLabels_0.method_41() == ""))
		{
			byte_0[24] &= 239;
		}
		else if (dataLabels_0.IsDeleted)
		{
			byte_0[24] |= 64;
		}
		else if (dataLabels_0.IsAutoText)
		{
			byte_0[24] |= 16;
		}
		method_9(dataLabels_0);
		if (dataLabels_0.RotationAngle >= 0)
		{
			byte_0[30] = (byte)dataLabels_0.RotationAngle;
		}
		else
		{
			byte_0[30] = (byte)(90 - dataLabels_0.RotationAngle);
		}
		byte_0[28] = 48;
		byte_0[29] = 16;
		switch (dataLabels_0.TextDirection)
		{
		case TextDirectionType.LeftToRight:
			byte_0[29] |= 64;
			break;
		case TextDirectionType.RightToLeft:
			byte_0[29] |= 128;
			break;
		case TextDirectionType.Context:
			break;
		}
	}

	internal void method_7(Title title_0)
	{
		byte_0[24] = 145;
		if (title_0.method_32() != null)
		{
			Class1694 @class = title_0.method_32();
			Array.Copy(BitConverter.GetBytes(@class.int_0), 0, byte_0, 8, 4);
			Array.Copy(BitConverter.GetBytes(@class.int_1), 0, byte_0, 12, 4);
			Array.Copy(BitConverter.GetBytes(@class.int_2), 0, byte_0, 16, 4);
			Array.Copy(BitConverter.GetBytes(@class.int_3), 0, byte_0, 20, 4);
		}
		else
		{
			Array.Copy(BitConverter.GetBytes(title_0.X), 0, byte_0, 8, 4);
			Array.Copy(BitConverter.GetBytes(title_0.Y), 0, byte_0, 12, 4);
			Array.Copy(BitConverter.GetBytes(title_0.Width), 0, byte_0, 16, 4);
			Array.Copy(BitConverter.GetBytes(title_0.Height), 0, byte_0, 20, 4);
		}
		switch (title_0.TextHorizontalAlignment)
		{
		case TextAlignmentType.Center:
			byte_0[0] = 2;
			break;
		case TextAlignmentType.Distributed:
			byte_0[0] = 7;
			break;
		case TextAlignmentType.Justify:
			byte_0[0] = 4;
			break;
		case TextAlignmentType.Left:
			byte_0[0] = 1;
			break;
		case TextAlignmentType.Right:
			byte_0[0] = 3;
			break;
		}
		switch (title_0.TextVerticalAlignment)
		{
		case TextAlignmentType.Top:
			byte_0[1] = 1;
			break;
		case TextAlignmentType.Bottom:
			byte_0[1] = 3;
			break;
		case TextAlignmentType.Center:
			byte_0[1] = 2;
			break;
		case TextAlignmentType.Distributed:
			byte_0[1] = 7;
			break;
		case TextAlignmentType.Justify:
			byte_0[1] = 4;
			break;
		}
		method_9(title_0);
		if (title_0.Text != null && !(title_0.Text == ""))
		{
			byte_0[24] &= 239;
		}
		else if (title_0.IsDeleted)
		{
			byte_0[24] |= 64;
		}
		else if (title_0.IsAutoText)
		{
			byte_0[24] |= 16;
		}
		if (title_0.RotationAngle >= 0)
		{
			byte_0[30] = (byte)title_0.RotationAngle;
		}
		else
		{
			byte_0[30] = (byte)(90 - title_0.RotationAngle);
		}
		byte_0[28] = 48;
		if (!title_0.method_17() || !title_0.IsAutoSize)
		{
			byte_0[28] |= 10;
		}
		byte_0[29] = 16;
		switch (title_0.TextDirection)
		{
		case TextDirectionType.LeftToRight:
			byte_0[29] |= 64;
			break;
		case TextDirectionType.RightToLeft:
			byte_0[29] |= 128;
			break;
		case TextDirectionType.Context:
			break;
		}
	}

	internal void method_8(Axis axis_0, DisplayUnitLabel displayUnitLabel_0)
	{
		byte_0[24] = 145;
		switch (displayUnitLabel_0.TextHorizontalAlignment)
		{
		case TextAlignmentType.Center:
			byte_0[0] = 2;
			break;
		case TextAlignmentType.Distributed:
			byte_0[0] = 7;
			break;
		case TextAlignmentType.Justify:
			byte_0[0] = 4;
			break;
		case TextAlignmentType.Left:
			byte_0[0] = 1;
			break;
		case TextAlignmentType.Right:
			byte_0[0] = 3;
			break;
		}
		switch (displayUnitLabel_0.TextVerticalAlignment)
		{
		case TextAlignmentType.Top:
			byte_0[1] = 1;
			break;
		case TextAlignmentType.Bottom:
			byte_0[1] = 3;
			break;
		case TextAlignmentType.Center:
			byte_0[1] = 2;
			break;
		case TextAlignmentType.Distributed:
			byte_0[1] = 7;
			break;
		case TextAlignmentType.Justify:
			byte_0[1] = 4;
			break;
		}
		if (axis_0.IsDisplayUnitLabelShown)
		{
			if (displayUnitLabel_0.Text != null && displayUnitLabel_0.Text != "")
			{
				byte_0[24] &= 239;
			}
		}
		else
		{
			byte_0[24] |= 64;
		}
		method_9(displayUnitLabel_0);
		if (displayUnitLabel_0.RotationAngle >= 0)
		{
			byte_0[30] = (byte)displayUnitLabel_0.RotationAngle;
		}
		else
		{
			byte_0[30] = (byte)(90 - displayUnitLabel_0.RotationAngle);
		}
		byte_0[28] = 48;
		if (!displayUnitLabel_0.method_17() || !displayUnitLabel_0.IsAutoSize)
		{
			byte_0[28] |= 10;
		}
		byte_0[29] = 16;
		switch (displayUnitLabel_0.TextDirection)
		{
		case TextDirectionType.LeftToRight:
			byte_0[29] |= 64;
			break;
		case TextDirectionType.RightToLeft:
			byte_0[29] |= 128;
			break;
		case TextDirectionType.Context:
			break;
		}
	}

	internal int[] method_9(ChartFrame chartFrame_0)
	{
		method_5(chartFrame_0.method_12());
		method_10(chartFrame_0.BackgroundMode);
		int[] array = new int[5];
		if (byte_0[2] == 1)
		{
			array[0] = 525;
		}
		else
		{
			array[0] = 269;
		}
		array[1] = byte_0[30];
		array[2] = byte_0[0];
		array[3] = byte_0[1];
		array[4] = (byte)((byte_0[29] & 0xF0) >> 4);
		return array;
	}

	internal void method_10(BackgroundMode backgroundMode_0)
	{
		switch (backgroundMode_0)
		{
		case BackgroundMode.Opaque:
			byte_0[24] &= 127;
			byte_0[2] = 2;
			break;
		case BackgroundMode.Transparent:
			byte_0[24] &= 127;
			break;
		}
	}
}
