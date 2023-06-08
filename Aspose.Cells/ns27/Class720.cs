using System;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using ns2;
using ns22;

namespace ns27;

internal class Class720 : Class538
{
	internal Class720()
	{
		method_2(224);
		method_0(20);
		byte_0 = new byte[20];
		Reset();
	}

	internal void Reset()
	{
		Array.Clear(byte_0, 0, byte_0.Length);
		byte_0[4] = 245;
		byte_0[5] = byte.MaxValue;
		byte_0[6] = 32;
		byte_0[9] = 248;
		byte_0[18] = 192;
		byte_0[19] = 32;
	}

	internal void method_4(ushort ushort_0)
	{
		if (ushort_0 != 0)
		{
			Array.Copy(BitConverter.GetBytes(ushort_0), 0, byte_0, 0, 2);
		}
	}

	internal int method_5(Style style, out bool found)
	{
		found = true;
		if (style.Pattern == BackgroundType.None)
		{
			return 64;
		}
		if (style.Pattern == BackgroundType.Solid)
		{
			return style.ForeInternalColor.method_1(style.method_5(), 65, out found);
		}
		return style.ForeInternalColor.method_1(style.method_5(), 64, out found);
	}

	internal int method_6(Style style, out bool found)
	{
		found = true;
		return style.Pattern switch
		{
			BackgroundType.None => 65, 
			BackgroundType.Solid => 64, 
			_ => style.BackgroundInternalColor.method_1(style.method_5(), 65, out found), 
		};
	}

	internal int method_7(Style style, InternalColor color, out bool found)
	{
		found = true;
		return color.method_1(style.method_5(), 64, out found);
	}

	internal Class1685 SetStyle(Style style_0, int int_0)
	{
		Class1685 @class = new Class1685();
		if (style_0.method_10())
		{
			byte_0[9] = style_0.method_15();
		}
		else
		{
			byte_0[9] = (byte)((uint)(~style_0.method_15()) & 0xFCu);
		}
		if (style_0.method_10())
		{
			byte_0[4] = 1;
			byte_0[5] = 0;
			if (style_0.method_12() != 0)
			{
				ushort num = (ushort)((style_0.method_12() << 4) + 1);
				if (num != 65521)
				{
					Array.Copy(BitConverter.GetBytes(num), 0, byte_0, 4, 2);
				}
			}
		}
		else
		{
			byte_0[4] = 245;
			byte_0[5] = byte.MaxValue;
		}
		bool found = false;
		if (style_0.IsGradient)
		{
			byte_0[17] = (byte)4;
			int num2 = method_5(style_0, out found);
			if (!found)
			{
				@class.Add(Enum235.const_4, style_0.ForeInternalColor);
			}
			byte_0[18] &= 128;
			byte_0[18] |= (byte)num2;
			GradientFill gradientFill = new GradientFill(null, null);
			gradientFill.method_5(GradientColorType.TwoColors, style_0.ForeInternalColor, 0.0, style_0.BackgroundInternalColor, style_0.method_51(), style_0.method_53());
			@class.Add(Enum235.const_6, gradientFill);
		}
		else
		{
			if (!Class1178.smethod_0(style_0.BackgroundColor) && style_0.Pattern != 0)
			{
				int num3 = method_6(style_0, out found);
				if (!found)
				{
					@class.Add(Enum235.const_5, style_0.BackgroundInternalColor);
				}
				if (num3 != -1)
				{
					int pattern = (int)style_0.Pattern;
					pattern <<= 2;
					byte_0[17] = (byte)pattern;
					pattern = num3 & 1;
					if (pattern == 1)
					{
						byte_0[18] |= 128;
					}
					else
					{
						byte_0[18] &= 127;
					}
					pattern = num3 >> 1;
					byte_0[19] = (byte)pattern;
				}
			}
			if (style_0.Pattern != 0)
			{
				int pattern2 = (int)style_0.Pattern;
				pattern2 <<= 2;
				byte_0[17] = (byte)pattern2;
				int num4 = method_5(style_0, out found);
				if (!found)
				{
					@class.Add(Enum235.const_4, style_0.ForeInternalColor);
				}
				byte_0[18] &= 128;
				byte_0[18] |= (byte)num4;
			}
		}
		if (style_0.method_49())
		{
			byte_0[19] |= 64;
		}
		method_8(style_0, @class);
		method_9(style_0);
		method_10(style_0);
		method_11(style_0);
		if (style_0.TextDirection != 0)
		{
			if (style_0.TextDirection == TextDirectionType.LeftToRight)
			{
				byte_0[8] |= 64;
			}
			else
			{
				byte_0[8] |= 128;
			}
		}
		if (style_0.method_44() != -1)
		{
			Array.Copy(BitConverter.GetBytes((ushort)style_0.method_44()), 0, byte_0, 2, 2);
		}
		if (style_0.IsTextWrapped)
		{
			byte_0[6] |= 8;
		}
		if (style_0.RotationAngle >= 0)
		{
			byte_0[7] = (byte)style_0.RotationAngle;
		}
		else
		{
			byte_0[7] = (byte)(90 - style_0.RotationAngle);
		}
		if (!style_0.IsLocked)
		{
			byte_0[4] &= 254;
		}
		if (style_0.IsFormulaHidden)
		{
			byte_0[4] |= 2;
		}
		if (style_0.method_47())
		{
			byte_0[4] |= 8;
		}
		if (style_0.ShrinkToFit)
		{
			byte_0[8] |= 16;
		}
		if (style_0.IndentLevel != 0)
		{
			byte_0[8] &= 240;
			if (style_0.IndentLevel > 15)
			{
				byte_0[8] |= 15;
				@class.Add(Enum235.const_15, (short)style_0.IndentLevel);
			}
			else
			{
				byte_0[8] |= (byte)style_0.IndentLevel;
			}
		}
		byte_0[17] |= 2;
		return @class;
	}

	private void method_8(Style style_0, Class1685 class1685_0)
	{
		int num = -1;
		bool found = false;
		InternalColor internalColor = style_0.Borders[BorderType.LeftBorder].InternalColor;
		if (style_0.Borders[BorderType.LeftBorder].LineStyle != 0)
		{
			num = method_7(style_0, internalColor, out found);
			if (!found)
			{
				class1685_0.Add(Enum235.const_9, internalColor);
			}
			byte_0[12] |= (byte)num;
		}
		internalColor = style_0.Borders[BorderType.RightBorder].InternalColor;
		if (style_0.Borders[BorderType.RightBorder].LineStyle != 0)
		{
			num = method_7(style_0, internalColor, out found);
			if (!found)
			{
				class1685_0.Add(Enum235.const_10, internalColor);
			}
			int num2 = num & 1;
			num >>= 1;
			if (num2 == 0)
			{
				byte_0[12] &= 127;
			}
			else
			{
				byte_0[12] |= 128;
			}
			byte_0[13] |= (byte)num;
		}
		internalColor = style_0.Borders[BorderType.TopBorder].InternalColor;
		if (style_0.Borders[BorderType.TopBorder].LineStyle != 0)
		{
			num = method_7(style_0, internalColor, out found);
			if (!found)
			{
				class1685_0.Add(Enum235.const_7, internalColor);
			}
			byte_0[14] |= (byte)num;
		}
		internalColor = style_0.Borders[BorderType.BottomBorder].InternalColor;
		if (style_0.Borders[BorderType.BottomBorder].LineStyle != 0)
		{
			num = method_7(style_0, internalColor, out found);
			if (!found)
			{
				class1685_0.Add(Enum235.const_8, internalColor);
			}
			if ((num & 1) == 0)
			{
				byte_0[14] &= 127;
			}
			else
			{
				byte_0[14] |= 128;
			}
			num >>= 1;
			byte_0[15] |= (byte)num;
		}
		internalColor = style_0.Borders.method_7();
		if (style_0.Borders.DiagonalStyle != 0)
		{
			num = method_7(style_0, internalColor, out found);
			if (!found)
			{
				class1685_0.Add(Enum235.const_11, internalColor);
			}
			int num2 = num & 3;
			if (num2 != 0)
			{
				byte_0[15] |= (byte)(num2 << 6);
			}
			num2 = num & 0xFFFC;
			byte_0[16] |= (byte)(num2 >> 2);
		}
	}

	private void method_9(Style style_0)
	{
		BorderCollection borders = style_0.Borders;
		CellBorderType lineStyle = borders[BorderType.LeftBorder].LineStyle;
		if (lineStyle != 0)
		{
			byte_0[10] |= (byte)lineStyle;
		}
		lineStyle = borders[BorderType.RightBorder].LineStyle;
		if (lineStyle != 0)
		{
			byte_0[10] |= (byte)((byte)lineStyle << 4);
		}
		lineStyle = borders[BorderType.TopBorder].LineStyle;
		if (lineStyle != 0)
		{
			byte_0[11] |= (byte)lineStyle;
		}
		lineStyle = borders[BorderType.BottomBorder].LineStyle;
		if (lineStyle != 0)
		{
			byte_0[11] |= (byte)((byte)lineStyle << 4);
		}
		lineStyle = style_0.Borders.DiagonalStyle;
		if (lineStyle != 0)
		{
			int num = (byte)lineStyle << 5;
			byte_0[16] |= (byte)num;
			if ((num & 0x100) == 0)
			{
				byte_0[17] &= 254;
			}
			else
			{
				byte_0[17] |= 1;
			}
			byte_0[13] |= (byte)(style_0.Borders.method_8() << 6);
		}
	}

	private void method_10(Style style_0)
	{
		switch (style_0.HorizontalAlignment)
		{
		case TextAlignmentType.Center:
			byte_0[6] &= 248;
			byte_0[6] |= 2;
			break;
		case TextAlignmentType.CenterAcross:
			byte_0[6] &= 248;
			byte_0[6] |= 6;
			break;
		case TextAlignmentType.Distributed:
			byte_0[6] &= 248;
			byte_0[6] |= 7;
			break;
		case TextAlignmentType.Fill:
			byte_0[6] &= 248;
			byte_0[6] |= 4;
			break;
		case TextAlignmentType.General:
			byte_0[6] &= 248;
			break;
		case TextAlignmentType.Justify:
			byte_0[6] &= 248;
			byte_0[6] |= 5;
			break;
		case TextAlignmentType.Left:
			byte_0[6] &= 248;
			byte_0[6] |= 1;
			break;
		case TextAlignmentType.Right:
			byte_0[6] &= 248;
			byte_0[6] |= 3;
			break;
		}
	}

	private void method_11(Style style_0)
	{
		switch (style_0.VerticalAlignment)
		{
		case TextAlignmentType.Top:
			byte_0[6] &= 143;
			break;
		case TextAlignmentType.Bottom:
			byte_0[6] &= 143;
			byte_0[6] |= 32;
			break;
		case TextAlignmentType.Center:
			byte_0[6] &= 143;
			byte_0[6] |= 16;
			break;
		case TextAlignmentType.Distributed:
			byte_0[6] &= 143;
			byte_0[6] |= 64;
			break;
		case TextAlignmentType.Justify:
			byte_0[6] &= 143;
			byte_0[6] |= 48;
			break;
		}
	}
}
