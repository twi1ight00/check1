using System;
using System.Drawing;
using Aspose.Cells;
using Aspose.Cells.Charts;
using ns22;

namespace ns27;

internal class Class653 : Class538
{
	private Palette palette_0;

	internal Class653(FileFormatType fileFormatType_1, Palette palette_1)
	{
		method_2(4105);
		fileFormatType_0 = fileFormatType_1;
		palette_0 = palette_1;
		method_0(20);
		byte_0 = new byte[20];
		byte_0[10] = 1;
		byte_0[12] = 77;
		byte_0[14] = 77;
		byte_0[16] = 60;
	}

	internal void method_4(Marker marker_0, int int_0)
	{
		if (marker_0.MarkerStyle == ChartMarkerType.Automatic)
		{
			return;
		}
		byte_0[10] &= 254;
		switch (marker_0.MarkerForegroundColorSetType)
		{
		case FormattingType.Automatic:
			byte_0[12] = (byte)((32 + int_0) % 56);
			break;
		case FormattingType.None:
			byte_0[10] |= 32;
			break;
		case FormattingType.Custom:
			if (!Class1178.smethod_0(marker_0.MarkerForegroundColor))
			{
				int int_ = palette_0.method_2(marker_0.MarkerForegroundColor);
				method_5(marker_0.MarkerForegroundColor, int_);
			}
			break;
		}
		switch (marker_0.MarkerBackgroundColorSetType)
		{
		case FormattingType.Automatic:
			byte_0[14] = (byte)((32 + int_0) % 56);
			break;
		case FormattingType.None:
			byte_0[10] |= 16;
			break;
		case FormattingType.Custom:
			if (!Class1178.smethod_0(marker_0.MarkerBackgroundColor))
			{
				int int_ = palette_0.method_2(marker_0.MarkerBackgroundColor);
				method_6(marker_0.MarkerBackgroundColor, int_);
			}
			break;
		}
		method_8(marker_0.MarkerStyle);
		method_7(marker_0.MarkerSize);
	}

	private void method_5(Color color_0, int int_0)
	{
		if (int_0 == -1)
		{
			int_0 = palette_0.method_4(color_0.R, color_0.G, color_0.B);
		}
		byte_0[0] = color_0.R;
		byte_0[1] = color_0.G;
		byte_0[2] = color_0.B;
		byte_0[12] = (byte)int_0;
	}

	private void method_6(Color color_0, int int_0)
	{
		if (int_0 == -1)
		{
			int_0 = palette_0.method_4(color_0.R, color_0.G, color_0.B);
		}
		byte_0[4] = color_0.R;
		byte_0[5] = color_0.G;
		byte_0[6] = color_0.B;
		byte_0[14] = (byte)int_0;
	}

	private void method_7(int int_0)
	{
		Array.Copy(BitConverter.GetBytes(int_0 * 20), 0, byte_0, 16, 2);
	}

	private void method_8(ChartMarkerType chartMarkerType_0)
	{
		switch (chartMarkerType_0)
		{
		case ChartMarkerType.Circle:
			byte_0[8] = 8;
			break;
		case ChartMarkerType.Dash:
			byte_0[8] = 7;
			break;
		case ChartMarkerType.Automatic:
		case ChartMarkerType.Diamond:
			byte_0[8] = 2;
			break;
		case ChartMarkerType.Dot:
			byte_0[8] = 6;
			break;
		case ChartMarkerType.None:
			byte_0[8] = 0;
			break;
		case ChartMarkerType.SquarePlus:
			byte_0[8] = 9;
			break;
		case ChartMarkerType.Square:
			byte_0[8] = 1;
			break;
		case ChartMarkerType.SquareStar:
			byte_0[8] = 5;
			break;
		case ChartMarkerType.Triangle:
			byte_0[8] = 3;
			break;
		case ChartMarkerType.SquareX:
			byte_0[8] = 4;
			break;
		}
	}
}
