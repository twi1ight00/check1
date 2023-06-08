using System.Drawing;
using System.Runtime.CompilerServices;
using Aspose.Cells;
using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;
using ns22;

namespace ns27;

internal class Class594 : Class538
{
	private Palette palette_0;

	private bool bool_0;

	private Area area_0;

	internal Area Area => area_0;

	internal Class594(FileFormatType fileFormatType_1, Palette palette_1)
	{
		palette_0 = palette_1;
		method_2(4106);
		fileFormatType_0 = fileFormatType_1;
		method_0(16);
		byte_0 = new byte[16];
		byte_0[0] = byte.MaxValue;
		byte_0[1] = byte.MaxValue;
		byte_0[2] = byte.MaxValue;
		byte_0[8] = 1;
		byte_0[10] = 1;
		byte_0[12] = 78;
		byte_0[14] = 77;
	}

	[SpecialName]
	internal void method_4(Area area_1)
	{
		area_0 = area_1;
		method_6();
	}

	[SpecialName]
	internal bool method_5()
	{
		return bool_0;
	}

	private void method_6()
	{
		bool flag = area_0.Formatting == FormattingType.None;
		Color color_ = area_0.ForegroundColor;
		Color backgroundColor = area_0.BackgroundColor;
		if (Class1178.smethod_0(color_) && !Class1178.smethod_0(backgroundColor))
		{
			color_ = Color.White;
		}
		if (!flag && !Class1178.smethod_0(color_))
		{
			int num = palette_0.method_2(color_);
			if (num != -1)
			{
				byte_0[0] = color_.R;
				byte_0[1] = color_.G;
				byte_0[2] = color_.B;
				byte_0[12] = (byte)num;
				byte_0[10] &= 254;
				if (num < 9)
				{
					bool_0 = true;
				}
			}
			else
			{
				bool_0 = true;
				num = palette_0.method_4(color_.R, color_.G, color_.B);
				if (num != -1)
				{
					byte_0[0] = color_.R;
					byte_0[1] = color_.G;
					byte_0[2] = color_.B;
					byte_0[12] = (byte)num;
					byte_0[10] &= 254;
				}
				else
				{
					byte_0[0] = byte.MaxValue;
					byte_0[1] = byte.MaxValue;
					byte_0[2] = byte.MaxValue;
					byte_0[12] = 78;
				}
			}
		}
		else
		{
			byte_0[0] = byte.MaxValue;
			byte_0[1] = byte.MaxValue;
			byte_0[2] = byte.MaxValue;
			byte_0[12] = 78;
		}
		if (!flag && !Class1178.smethod_0(backgroundColor))
		{
			int num = palette_0.method_2(backgroundColor);
			if (num != -1)
			{
				byte_0[4] = backgroundColor.R;
				byte_0[5] = backgroundColor.G;
				byte_0[6] = backgroundColor.B;
				byte_0[14] = (byte)num;
				byte_0[10] &= 254;
			}
			else
			{
				bool_0 = true;
				byte_0[4] = 0;
				byte_0[5] = 0;
				byte_0[6] = 0;
				byte_0[14] = 77;
			}
		}
		else
		{
			byte_0[4] = 0;
			byte_0[5] = 0;
			byte_0[6] = 0;
			byte_0[14] = 77;
		}
		switch (area_0.Formatting)
		{
		case FormattingType.Automatic:
			byte_0[10] = 1;
			break;
		case FormattingType.None:
			byte_0[8] = 0;
			byte_0[10] = 0;
			break;
		case FormattingType.Custom:
			byte_0[8] |= 1;
			byte_0[10] = 0;
			break;
		}
		if (area_0.method_5() != null && area_0.FillFormat.SetType == FormatSetType.IsPatternSet)
		{
			method_7();
		}
		if (area_0.InvertIfNegative)
		{
			byte_0[10] |= 2;
		}
	}

	internal void method_7()
	{
		if (area_0.method_5() != null && area_0.FillFormat.SetType == FormatSetType.IsPatternSet)
		{
			switch (area_0.FillFormat.Pattern)
			{
			case FillPattern.Gray5:
			case FillPattern.Gray10:
				byte_0[8] = 18;
				break;
			case FillPattern.Gray50:
				byte_0[8] = 2;
				break;
			case FillPattern.Gray60:
			case FillPattern.Gray70:
			case FillPattern.Gray75:
			case FillPattern.Gray80:
			case FillPattern.Gray90:
				byte_0[8] = 3;
				break;
			case FillPattern.Gray25:
				byte_0[8] = 4;
				break;
			case FillPattern.DarkDownwardDiagonal:
			case FillPattern.WideDownwardDiagonal:
				byte_0[8] = 7;
				break;
			case FillPattern.DarkUpwardDiagonal:
			case FillPattern.WideUpwardDiagonal:
				byte_0[8] = 8;
				break;
			case FillPattern.DarkVertical:
				byte_0[8] = 6;
				break;
			case FillPattern.DarkHorizontal:
				byte_0[8] = 5;
				break;
			case FillPattern.LightVertical:
			case FillPattern.NarrowVertical:
			case FillPattern.DashedVertical:
				byte_0[8] = 12;
				break;
			case FillPattern.LightHorizontal:
			case FillPattern.NarrowHorizontal:
			case FillPattern.DashedHorizontal:
				byte_0[8] = 11;
				break;
			case FillPattern.Gray30:
			case FillPattern.Gray40:
			case FillPattern.LargeConfetti:
				byte_0[8] = 16;
				break;
			case FillPattern.LightUpwardDiagonal:
			case FillPattern.DashedUpwardDiagonal:
			case FillPattern.Weave:
			case FillPattern.Divot:
				byte_0[8] = 14;
				break;
			case FillPattern.Gray20:
			case FillPattern.SmallConfetti:
			case FillPattern.DottedDiamond:
				byte_0[8] = 17;
				break;
			case FillPattern.Trellis:
				byte_0[8] = 10;
				break;
			case FillPattern.HorizontalBrick:
			case FillPattern.SmallGrid:
			case FillPattern.LargeGrid:
				byte_0[8] = 15;
				break;
			case FillPattern.LightDownwardDiagonal:
			case FillPattern.DashedDownwardDiagonal:
			case FillPattern.ZigZag:
			case FillPattern.Wave:
			case FillPattern.DiagonalBrick:
			case FillPattern.DottedGrid:
			case FillPattern.Shingle:
			case FillPattern.OutlinedDiamond:
				byte_0[8] = 13;
				break;
			case FillPattern.Plaid:
			case FillPattern.Sphere:
			case FillPattern.SmallCheckerBoard:
			case FillPattern.LargeCheckerBoard:
			case FillPattern.SolidDiamond:
				byte_0[8] = 9;
				break;
			}
		}
	}
}
