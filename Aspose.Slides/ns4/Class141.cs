using System.Collections.Generic;
using Aspose.Slides;
using ns224;

namespace ns4;

internal class Class141
{
	internal Class142 class142_0;

	internal Class63 class63_0;

	internal Class66 class66_0;

	internal Class66 class66_1;

	internal bool bool_0;

	internal bool bool_1;

	internal bool bool_2;

	internal bool bool_3;

	private List<Class145> list_0 = new List<Class145>();

	private bool[] bool_4 = new bool[3] { true, true, true };

	internal List<Class145> OverwrittenBy => list_0;

	internal Class141(Cell sourceCell, Class6002 UserToDevice, Class145 supportWrapper)
	{
		if (((FillFormat)sourceCell.FillFormat).fillType_0 != FillType.NotDefined)
		{
			class63_0 = new Class63(supportWrapper.method_1(UserToDevice), sourceCell.FillFormat);
			bool_4[0] = false;
		}
		if (sourceCell.BorderDiagonalDown.FillFormat.FillType != FillType.NotDefined)
		{
			class66_0 = new Class66(supportWrapper.method_1(UserToDevice), (LineFormat)sourceCell.BorderDiagonalDown);
			bool_4[1] = false;
		}
		if (sourceCell.BorderDiagonalUp.FillFormat.FillType != FillType.NotDefined)
		{
			class66_1 = new Class66(supportWrapper.method_1(UserToDevice), (LineFormat)sourceCell.BorderDiagonalUp);
			bool_4[2] = false;
		}
	}

	internal void method_0(Class145 sourceStyle)
	{
		Class142 cellTextStyle = sourceStyle.CellTextStyle;
		if (sourceStyle != null)
		{
			class142_0 = cellTextStyle;
		}
		if (bool_4[0])
		{
			Class63 cellFillFormat = sourceStyle.CellFillFormat;
			if (cellFillFormat != null)
			{
				class63_0 = cellFillFormat;
			}
		}
		if (bool_4[1])
		{
			Class66 tL2BRBorder = sourceStyle.TL2BRBorder;
			if (tL2BRBorder != null)
			{
				class66_0 = tL2BRBorder;
			}
		}
		if (bool_4[2])
		{
			Class66 tR2BLBorder = sourceStyle.TR2BLBorder;
			if (tR2BLBorder != null)
			{
				class66_1 = tR2BLBorder;
			}
		}
		list_0.Add(sourceStyle);
		switch (sourceStyle.ParamType)
		{
		case Enum9.const_5:
			bool_1 = true;
			break;
		case Enum9.const_6:
			bool_0 = true;
			break;
		case Enum9.const_7:
			bool_3 = true;
			break;
		case Enum9.const_8:
			bool_2 = true;
			break;
		}
	}
}
