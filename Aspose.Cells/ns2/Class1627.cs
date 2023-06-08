using System;
using System.Collections;
using Aspose.Cells;
using Aspose.Cells.Tables;
using ns12;
using ns16;
using ns44;
using ns58;

namespace ns2;

internal class Class1627
{
	public static Class314 smethod_0(Worksheet worksheet_0, Cell cell_0, Style style_0, bool bool_0)
	{
		if (cell_0 == null)
		{
			return new Class314(null, null, style_0);
		}
		Class314 @class = smethod_6(worksheet_0, cell_0);
		if (@class == null)
		{
			return new Class314(null, null, style_0);
		}
		if (@class.style_0 == null)
		{
			@class.style_1 = style_0;
			return @class;
		}
		Style style = style_0;
		Style style_ = @class.style_0;
		if (bool_0)
		{
			style = new Style(worksheet_0.method_2());
			style.Copy(style_0);
		}
		smethod_2(style, style_);
		@class.style_1 = style;
		return @class;
	}

	internal static void smethod_1(Style style_0, Style style_1)
	{
		if (style_1.IsModified(StyleModifyFlag.Font) && style_1.method_19())
		{
			if (style_1.IsModified(StyleModifyFlag.FontName))
			{
				style_0.Font.method_14(style_1.Font.Name, style_1.Font.method_23());
			}
			if (style_1.IsModified(StyleModifyFlag.FontSize))
			{
				style_0.Font.Size = style_1.Font.Size;
			}
			if (style_1.IsModified(StyleModifyFlag.FontColor))
			{
				style_0.Font.InternalColor.method_19(style_1.Font.InternalColor);
				style_0.method_36(StyleModifyFlag.FontColor);
			}
			if (style_1.IsModified(StyleModifyFlag.FontItalic))
			{
				style_0.Font.IsItalic = style_1.Font.IsItalic;
			}
			if (style_1.IsModified(StyleModifyFlag.FontWeight))
			{
				style_0.Font.IsBold = style_1.Font.IsBold;
			}
			if (style_1.IsModified(StyleModifyFlag.FontUnderline))
			{
				style_0.Font.Underline = style_1.Font.Underline;
			}
			if (style_1.IsModified(StyleModifyFlag.FontScript))
			{
				style_0.Font.method_10(style_1.Font.method_9());
			}
			if (style_1.IsModified(StyleModifyFlag.FontStrike))
			{
				style_0.Font.IsStrikeout = style_1.Font.IsStrikeout;
			}
		}
		if (style_1.IsModified(StyleModifyFlag.Borders) && style_1.method_23())
		{
			if (style_1.IsModified(StyleModifyFlag.LeftBorder))
			{
				style_0.Borders[BorderType.LeftBorder].Copy(style_1.Borders[BorderType.LeftBorder]);
				style_0.method_36(StyleModifyFlag.LeftBorder);
			}
			if (style_1.IsModified(StyleModifyFlag.RightBorder))
			{
				style_0.Borders[BorderType.RightBorder].Copy(style_1.Borders[BorderType.RightBorder]);
				style_0.method_36(StyleModifyFlag.RightBorder);
			}
			if (style_1.IsModified(StyleModifyFlag.TopBorder))
			{
				style_0.Borders[BorderType.TopBorder].Copy(style_1.Borders[BorderType.TopBorder]);
				style_0.method_36(StyleModifyFlag.TopBorder);
			}
			if (style_1.IsModified(StyleModifyFlag.BottomBorder))
			{
				style_0.Borders[BorderType.BottomBorder].Copy(style_1.Borders[BorderType.BottomBorder]);
				style_0.method_36(StyleModifyFlag.BottomBorder);
			}
			if (style_1.IsModified(StyleModifyFlag.DiagonalUpBorder))
			{
				style_0.Borders[BorderType.DiagonalUp].Copy(style_1.Borders[BorderType.DiagonalUp]);
				style_0.method_36(StyleModifyFlag.DiagonalUpBorder);
			}
			if (style_1.IsModified(StyleModifyFlag.DiagonalDownBorder))
			{
				style_0.Borders[BorderType.DiagonalDown].Copy(style_1.Borders[BorderType.DiagonalDown]);
				style_0.method_36(StyleModifyFlag.DiagonalDownBorder);
			}
		}
		if (style_1.IsModified(StyleModifyFlag.CellShading) && style_1.method_25())
		{
			if (style_1.IsModified(StyleModifyFlag.Pattern))
			{
				style_0.Pattern = style_1.Pattern;
			}
			if (style_1.IsModified(StyleModifyFlag.ForegroundColor))
			{
				style_0.ForeInternalColor.method_19(style_1.ForeInternalColor);
				style_0.method_36(StyleModifyFlag.ForegroundColor);
			}
			if (style_1.IsModified(StyleModifyFlag.BackgroundColor))
			{
				if (style_0.Pattern != 0 && style_0.Pattern != BackgroundType.Solid)
				{
					style_0.BackgroundInternalColor.method_19(style_1.BackgroundInternalColor);
					style_0.method_36(StyleModifyFlag.BackgroundColor);
				}
				else
				{
					style_0.Pattern = BackgroundType.Solid;
					style_0.ForeInternalColor.method_19(style_1.BackgroundInternalColor);
					style_0.method_36(StyleModifyFlag.ForegroundColor);
				}
			}
		}
		if (style_1.IsModified(StyleModifyFlag.HorizontalAlignment) && style_1.method_21())
		{
			style_0.HorizontalAlignment = style_1.HorizontalAlignment;
		}
		if (style_1.IsModified(StyleModifyFlag.Rotation) && style_1.method_21())
		{
			style_0.RotationAngle = style_1.RotationAngle;
		}
		if (style_1.IsModified(StyleModifyFlag.Indent) && style_1.method_21())
		{
			style_0.IndentLevel = style_1.IndentLevel;
		}
		if (style_1.IsModified(StyleModifyFlag.NumberFormat) && style_1.method_17())
		{
			style_0.Custom = style_1.Custom;
			style_0.method_45(style_1.Number);
		}
	}

	internal static void smethod_2(Style style_0, Style style_1)
	{
		if (style_1.IsModified(StyleModifyFlag.Font))
		{
			if (style_1.IsModified(StyleModifyFlag.FontName))
			{
				style_0.Font.method_14(style_1.Font.Name, style_1.Font.method_23());
			}
			if (style_1.IsModified(StyleModifyFlag.FontSize))
			{
				style_0.Font.Size = style_1.Font.Size;
			}
			if (style_1.IsModified(StyleModifyFlag.FontColor))
			{
				style_0.Font.InternalColor.method_19(style_1.Font.InternalColor);
				style_0.method_36(StyleModifyFlag.FontColor);
			}
			if (style_1.IsModified(StyleModifyFlag.FontItalic))
			{
				style_0.Font.IsItalic = style_1.Font.IsItalic;
			}
			if (style_1.IsModified(StyleModifyFlag.FontWeight))
			{
				style_0.Font.IsBold = style_1.Font.IsBold;
			}
			if (style_1.IsModified(StyleModifyFlag.FontUnderline))
			{
				style_0.Font.Underline = style_1.Font.Underline;
			}
			if (style_1.IsModified(StyleModifyFlag.FontScript))
			{
				style_0.Font.method_10(style_1.Font.method_9());
			}
			if (style_1.IsModified(StyleModifyFlag.FontStrike))
			{
				style_0.Font.IsStrikeout = style_1.Font.IsStrikeout;
			}
		}
		if (style_1.IsModified(StyleModifyFlag.Borders))
		{
			if (style_1.IsModified(StyleModifyFlag.LeftBorder))
			{
				style_0.Borders[BorderType.LeftBorder].Copy(style_1.Borders[BorderType.LeftBorder]);
				style_0.method_36(StyleModifyFlag.LeftBorder);
			}
			if (style_1.IsModified(StyleModifyFlag.RightBorder))
			{
				style_0.Borders[BorderType.RightBorder].Copy(style_1.Borders[BorderType.RightBorder]);
				style_0.method_36(StyleModifyFlag.RightBorder);
			}
			if (style_1.IsModified(StyleModifyFlag.TopBorder))
			{
				style_0.Borders[BorderType.TopBorder].Copy(style_1.Borders[BorderType.TopBorder]);
				style_0.method_36(StyleModifyFlag.TopBorder);
			}
			if (style_1.IsModified(StyleModifyFlag.BottomBorder))
			{
				style_0.Borders[BorderType.BottomBorder].Copy(style_1.Borders[BorderType.BottomBorder]);
				style_0.method_36(StyleModifyFlag.BottomBorder);
			}
			if (style_1.IsModified(StyleModifyFlag.DiagonalUpBorder))
			{
				style_0.Borders[BorderType.DiagonalUp].Copy(style_1.Borders[BorderType.DiagonalUp]);
				style_0.method_36(StyleModifyFlag.DiagonalUpBorder);
			}
			if (style_1.IsModified(StyleModifyFlag.DiagonalDownBorder))
			{
				style_0.Borders[BorderType.DiagonalDown].Copy(style_1.Borders[BorderType.DiagonalDown]);
				style_0.method_36(StyleModifyFlag.DiagonalDownBorder);
			}
		}
		if (style_1.IsModified(StyleModifyFlag.CellShading))
		{
			if (style_0.IsGradient)
			{
				style_0.IsGradient = false;
			}
			if (style_1.IsModified(StyleModifyFlag.Pattern))
			{
				style_0.Pattern = style_1.Pattern;
			}
			if (style_1.IsModified(StyleModifyFlag.ForegroundColor))
			{
				style_0.ForeInternalColor.method_19(style_1.ForeInternalColor);
				style_0.method_36(StyleModifyFlag.ForegroundColor);
			}
			if (style_1.IsModified(StyleModifyFlag.BackgroundColor))
			{
				if (style_0.Pattern != 0 && style_0.Pattern != BackgroundType.Solid)
				{
					style_0.BackgroundInternalColor.method_19(style_1.BackgroundInternalColor);
					style_0.method_36(StyleModifyFlag.BackgroundColor);
				}
				else
				{
					style_0.IsGradient = false;
					style_0.Pattern = BackgroundType.Solid;
					style_0.ForeInternalColor.method_19(style_1.BackgroundInternalColor);
					style_0.method_36(StyleModifyFlag.ForegroundColor);
				}
			}
		}
		if (style_1.IsGradient)
		{
			style_0.IsGradient = true;
			style_0.method_54(style_1.method_53());
			style_0.method_52(style_1.method_51());
			style_0.ForegroundColor = style_1.ForegroundColor;
			style_0.method_36(StyleModifyFlag.ForegroundColor);
			style_0.BackgroundColor = style_1.BackgroundColor;
			style_0.method_36(StyleModifyFlag.BackgroundColor);
		}
		if (style_1.IsModified(StyleModifyFlag.HorizontalAlignment))
		{
			style_0.HorizontalAlignment = style_1.HorizontalAlignment;
		}
		if (style_1.IsModified(StyleModifyFlag.Rotation))
		{
			style_0.RotationAngle = style_1.RotationAngle;
		}
		if (style_1.IsModified(StyleModifyFlag.Indent))
		{
			style_0.IndentLevel = style_1.IndentLevel;
		}
		if (style_1.IsModified(StyleModifyFlag.NumberFormat))
		{
			style_0.Custom = style_1.Custom;
			style_0.method_45(style_1.Number);
		}
	}

	internal static void smethod_3(Style style_0, Style style_1)
	{
		if (style_1.IsModified(StyleModifyFlag.Font))
		{
			if (style_1.IsModified(StyleModifyFlag.FontName) && !style_0.IsModified(StyleModifyFlag.FontName))
			{
				style_0.Font.method_14(style_1.Font.Name, style_1.Font.method_23());
			}
			if (style_1.IsModified(StyleModifyFlag.FontSize) && !style_0.IsModified(StyleModifyFlag.FontSize))
			{
				style_0.Font.Size = style_1.Font.Size;
			}
			if (style_1.IsModified(StyleModifyFlag.FontColor) && !style_0.IsModified(StyleModifyFlag.FontColor))
			{
				style_0.Font.InternalColor.method_19(style_1.Font.InternalColor);
				style_0.method_36(StyleModifyFlag.FontColor);
			}
			if (style_1.IsModified(StyleModifyFlag.FontItalic) && !style_0.IsModified(StyleModifyFlag.FontItalic))
			{
				style_0.Font.IsItalic = style_1.Font.IsItalic;
			}
			if (style_1.IsModified(StyleModifyFlag.FontWeight) && !style_0.IsModified(StyleModifyFlag.FontWeight))
			{
				style_0.Font.IsBold = style_1.Font.IsBold;
			}
			if (style_1.IsModified(StyleModifyFlag.FontUnderline) && !style_0.IsModified(StyleModifyFlag.FontUnderline))
			{
				style_0.Font.Underline = style_1.Font.Underline;
			}
			if (style_1.IsModified(StyleModifyFlag.FontScript) && !style_0.IsModified(StyleModifyFlag.FontScript))
			{
				style_0.Font.method_10(style_1.Font.method_9());
			}
			if (style_1.IsModified(StyleModifyFlag.FontStrike) && !style_0.IsModified(StyleModifyFlag.FontStrike))
			{
				style_0.Font.IsStrikeout = style_1.Font.IsStrikeout;
			}
		}
		if (style_1.IsModified(StyleModifyFlag.Borders))
		{
			if (style_1.IsModified(StyleModifyFlag.LeftBorder) && !style_0.IsModified(StyleModifyFlag.LeftBorder))
			{
				style_0.Borders[BorderType.LeftBorder].Copy(style_1.Borders[BorderType.LeftBorder]);
				style_0.method_36(StyleModifyFlag.LeftBorder);
			}
			if (style_1.IsModified(StyleModifyFlag.RightBorder) && !style_0.IsModified(StyleModifyFlag.RightBorder))
			{
				style_0.Borders[BorderType.RightBorder].Copy(style_1.Borders[BorderType.RightBorder]);
				style_0.method_36(StyleModifyFlag.RightBorder);
			}
			if (style_1.IsModified(StyleModifyFlag.TopBorder) && !style_0.IsModified(StyleModifyFlag.TopBorder))
			{
				style_0.Borders[BorderType.TopBorder].Copy(style_1.Borders[BorderType.TopBorder]);
				style_0.method_36(StyleModifyFlag.TopBorder);
			}
			if (style_1.IsModified(StyleModifyFlag.BottomBorder) && !style_0.IsModified(StyleModifyFlag.BottomBorder))
			{
				style_0.Borders[BorderType.BottomBorder].Copy(style_1.Borders[BorderType.BottomBorder]);
				style_0.method_36(StyleModifyFlag.BottomBorder);
			}
			if (style_1.IsModified(StyleModifyFlag.DiagonalUpBorder) && !style_0.IsModified(StyleModifyFlag.DiagonalUpBorder))
			{
				style_0.Borders[BorderType.DiagonalUp].Copy(style_1.Borders[BorderType.DiagonalUp]);
				style_0.method_36(StyleModifyFlag.DiagonalUpBorder);
			}
			if (style_1.IsModified(StyleModifyFlag.DiagonalDownBorder) && !style_0.IsModified(StyleModifyFlag.DiagonalDownBorder))
			{
				style_0.Borders[BorderType.DiagonalDown].Copy(style_1.Borders[BorderType.DiagonalDown]);
				style_0.method_36(StyleModifyFlag.DiagonalDownBorder);
			}
		}
		if (style_1.IsModified(StyleModifyFlag.CellShading))
		{
			if (style_1.IsModified(StyleModifyFlag.Pattern) && !style_0.IsModified(StyleModifyFlag.Pattern))
			{
				style_0.Pattern = style_1.Pattern;
			}
			if (style_1.IsModified(StyleModifyFlag.ForegroundColor) && !style_0.IsModified(StyleModifyFlag.ForegroundColor))
			{
				style_0.ForeInternalColor.method_19(style_1.ForeInternalColor);
				style_0.method_36(StyleModifyFlag.ForegroundColor);
			}
			if (style_1.IsModified(StyleModifyFlag.BackgroundColor))
			{
				if (style_0.Pattern != 0 && style_0.Pattern != BackgroundType.Solid)
				{
					if (!style_0.IsModified(StyleModifyFlag.BackgroundColor))
					{
						style_0.BackgroundInternalColor.method_19(style_1.BackgroundInternalColor);
						style_0.method_36(StyleModifyFlag.BackgroundColor);
					}
				}
				else if (!style_0.IsModified(StyleModifyFlag.ForegroundColor))
				{
					style_0.IsGradient = false;
					style_0.Pattern = BackgroundType.Solid;
					style_0.ForeInternalColor.method_19(style_1.BackgroundInternalColor);
					style_0.method_36(StyleModifyFlag.ForegroundColor);
				}
			}
		}
		if (style_1.IsGradient)
		{
			style_0.IsGradient = true;
			style_0.method_54(style_1.method_53());
			style_0.method_52(style_1.method_51());
			style_0.ForegroundColor = style_1.ForegroundColor;
			style_0.method_36(StyleModifyFlag.ForegroundColor);
			style_0.BackgroundColor = style_1.BackgroundColor;
			style_0.method_36(StyleModifyFlag.BackgroundColor);
		}
		if (style_1.IsModified(StyleModifyFlag.HorizontalAlignment) && !style_0.IsModified(StyleModifyFlag.HorizontalAlignment))
		{
			style_0.HorizontalAlignment = style_1.HorizontalAlignment;
		}
		if (style_1.IsModified(StyleModifyFlag.Rotation) && !style_0.IsModified(StyleModifyFlag.Rotation))
		{
			style_0.RotationAngle = style_1.RotationAngle;
		}
		if (style_1.IsModified(StyleModifyFlag.Indent) && !style_0.IsModified(StyleModifyFlag.Rotation))
		{
			style_0.IndentLevel = style_1.IndentLevel;
		}
		if (style_1.IsModified(StyleModifyFlag.NumberFormat) && !style_0.IsModified(StyleModifyFlag.NumberFormat))
		{
			style_0.Custom = style_1.Custom;
			style_0.method_45(style_1.Number);
		}
	}

	internal static void smethod_4(Style style_0, Style style_1, Style style_2)
	{
		if (style_1.IsModified(StyleModifyFlag.Font))
		{
			if (style_1.IsModified(StyleModifyFlag.FontName) && !style_0.IsModified(StyleModifyFlag.FontName))
			{
				style_0.Font.method_14(style_1.Font.Name, style_1.Font.method_23());
			}
			if (style_1.IsModified(StyleModifyFlag.FontSize) && !style_0.IsModified(StyleModifyFlag.FontSize))
			{
				style_0.Font.Size = style_1.Font.Size;
			}
			if (style_1.IsModified(StyleModifyFlag.FontColor) && (style_0.method_40() == null || style_0.method_40().InternalColor.method_9(style_2.Font.InternalColor)))
			{
				style_0.Font.InternalColor.method_19(style_1.Font.InternalColor);
				style_0.method_36(StyleModifyFlag.FontColor);
			}
			if (style_1.IsModified(StyleModifyFlag.FontItalic) && !style_0.IsModified(StyleModifyFlag.FontItalic))
			{
				style_0.Font.IsItalic = style_1.Font.IsItalic;
			}
			if (style_1.IsModified(StyleModifyFlag.FontWeight) && !style_0.IsModified(StyleModifyFlag.FontWeight))
			{
				style_0.Font.IsBold = style_1.Font.IsBold;
			}
			if (style_1.IsModified(StyleModifyFlag.FontUnderline) && !style_0.IsModified(StyleModifyFlag.FontUnderline))
			{
				style_0.Font.Underline = style_1.Font.Underline;
			}
			if (style_1.IsModified(StyleModifyFlag.FontScript) && !style_0.IsModified(StyleModifyFlag.FontScript))
			{
				style_0.Font.method_10(style_1.Font.method_9());
			}
			if (style_1.IsModified(StyleModifyFlag.FontStrike) && !style_0.IsModified(StyleModifyFlag.FontStrike))
			{
				style_0.Font.IsStrikeout = style_1.Font.IsStrikeout;
			}
		}
		if (style_1.IsModified(StyleModifyFlag.Borders))
		{
			if (style_1.IsModified(StyleModifyFlag.LeftBorder))
			{
				style_0.Borders[BorderType.LeftBorder].Copy(style_1.Borders[BorderType.LeftBorder]);
				style_0.method_36(StyleModifyFlag.LeftBorder);
			}
			if (style_1.IsModified(StyleModifyFlag.RightBorder))
			{
				style_0.Borders[BorderType.RightBorder].Copy(style_1.Borders[BorderType.RightBorder]);
				style_0.method_36(StyleModifyFlag.RightBorder);
			}
			if (style_1.IsModified(StyleModifyFlag.TopBorder))
			{
				style_0.Borders[BorderType.TopBorder].Copy(style_1.Borders[BorderType.TopBorder]);
				style_0.method_36(StyleModifyFlag.TopBorder);
			}
			if (style_1.IsModified(StyleModifyFlag.BottomBorder))
			{
				style_0.Borders[BorderType.BottomBorder].Copy(style_1.Borders[BorderType.BottomBorder]);
				style_0.method_36(StyleModifyFlag.BottomBorder);
			}
			if (style_1.IsModified(StyleModifyFlag.DiagonalUpBorder))
			{
				style_0.Borders[BorderType.DiagonalUp].Copy(style_1.Borders[BorderType.DiagonalUp]);
				style_0.method_36(StyleModifyFlag.DiagonalUpBorder);
			}
			if (style_1.IsModified(StyleModifyFlag.DiagonalDownBorder))
			{
				style_0.Borders[BorderType.DiagonalDown].Copy(style_1.Borders[BorderType.DiagonalDown]);
				style_0.method_36(StyleModifyFlag.DiagonalDownBorder);
			}
		}
		if (style_1.IsModified(StyleModifyFlag.CellShading))
		{
			if (style_1.IsModified(StyleModifyFlag.Pattern))
			{
				style_0.Pattern = style_1.Pattern;
			}
			if (style_1.IsModified(StyleModifyFlag.ForegroundColor) && !style_0.IsModified(StyleModifyFlag.ForegroundColor))
			{
				style_0.ForeInternalColor.method_19(style_1.ForeInternalColor);
				style_0.method_36(StyleModifyFlag.ForegroundColor);
			}
			if (style_1.IsModified(StyleModifyFlag.BackgroundColor))
			{
				if (style_0.Pattern != 0 && style_0.Pattern != BackgroundType.Solid)
				{
					style_0.BackgroundInternalColor.method_19(style_1.BackgroundInternalColor);
					style_0.method_36(StyleModifyFlag.BackgroundColor);
				}
				else
				{
					style_0.IsGradient = false;
					style_0.Pattern = BackgroundType.Solid;
					style_0.ForeInternalColor.method_19(style_1.BackgroundInternalColor);
					style_0.method_36(StyleModifyFlag.ForegroundColor);
				}
			}
		}
		if (style_1.IsGradient)
		{
			style_0.IsGradient = true;
			style_0.method_54(style_1.method_53());
			style_0.method_52(style_1.method_51());
			style_0.ForegroundColor = style_1.ForegroundColor;
			style_0.method_36(StyleModifyFlag.ForegroundColor);
			style_0.BackgroundColor = style_1.BackgroundColor;
			style_0.method_36(StyleModifyFlag.BackgroundColor);
		}
		if (style_1.IsModified(StyleModifyFlag.HorizontalAlignment))
		{
			style_0.HorizontalAlignment = style_1.HorizontalAlignment;
		}
		if (style_1.IsModified(StyleModifyFlag.Rotation))
		{
			style_0.RotationAngle = style_1.RotationAngle;
		}
		if (style_1.IsModified(StyleModifyFlag.Indent))
		{
			style_0.IndentLevel = style_1.IndentLevel;
		}
		if (style_1.IsModified(StyleModifyFlag.NumberFormat))
		{
			style_0.Custom = style_1.Custom;
			style_0.method_45(style_1.Number);
		}
	}

	internal static void smethod_5(Style style_0, Style style_1, Class1686 class1686_0, TableStyleElementType tableStyleElementType_0, Hashtable hashtable_0)
	{
		if (style_1.IsModified(StyleModifyFlag.Font))
		{
			if (style_1.IsModified(StyleModifyFlag.FontName))
			{
				style_0.Font.method_14(style_1.Font.Name, style_1.Font.method_23());
			}
			if (style_1.IsModified(StyleModifyFlag.FontSize))
			{
				style_0.Font.Size = style_1.Font.Size;
			}
			if (style_1.IsModified(StyleModifyFlag.FontColor))
			{
				style_0.Font.InternalColor.method_19(style_1.Font.InternalColor);
				style_0.method_36(StyleModifyFlag.FontColor);
			}
			if (style_1.IsModified(StyleModifyFlag.FontItalic))
			{
				style_0.Font.IsItalic = style_1.Font.IsItalic;
			}
			if (style_1.IsModified(StyleModifyFlag.FontWeight))
			{
				style_0.Font.IsBold = style_1.Font.IsBold;
			}
			if (style_1.IsModified(StyleModifyFlag.FontUnderline))
			{
				style_0.Font.Underline = style_1.Font.Underline;
			}
			if (style_1.IsModified(StyleModifyFlag.FontScript))
			{
				style_0.Font.method_10(style_1.Font.method_9());
			}
			if (style_1.IsModified(StyleModifyFlag.FontStrike))
			{
				style_0.Font.IsStrikeout = style_1.Font.IsStrikeout;
			}
		}
		if (style_1.IsModified(StyleModifyFlag.Borders))
		{
			if (style_1.IsModified(StyleModifyFlag.LeftBorder) && class1686_0.bool_2)
			{
				style_0.Borders[BorderType.LeftBorder].Copy(style_1.Borders[BorderType.LeftBorder]);
				hashtable_0[BorderType.LeftBorder] = (int)tableStyleElementType_0;
				style_0.method_36(StyleModifyFlag.LeftBorder);
			}
			if (style_1.IsModified(StyleModifyFlag.RightBorder) && class1686_0.bool_3)
			{
				style_0.Borders[BorderType.RightBorder].Copy(style_1.Borders[BorderType.RightBorder]);
				hashtable_0[BorderType.RightBorder] = (int)tableStyleElementType_0;
				style_0.method_36(StyleModifyFlag.RightBorder);
			}
			if (style_1.IsModified(StyleModifyFlag.TopBorder) && class1686_0.bool_0)
			{
				style_0.Borders[BorderType.TopBorder].Copy(style_1.Borders[BorderType.TopBorder]);
				hashtable_0[BorderType.TopBorder] = (int)tableStyleElementType_0;
				style_0.method_36(StyleModifyFlag.TopBorder);
			}
			if (style_1.IsModified(StyleModifyFlag.BottomBorder) && class1686_0.bool_1)
			{
				style_0.Borders[BorderType.BottomBorder].Copy(style_1.Borders[BorderType.BottomBorder]);
				hashtable_0[BorderType.BottomBorder] = (int)tableStyleElementType_0;
				style_0.method_36(StyleModifyFlag.BottomBorder);
			}
			if (style_1.Borders.method_0() != null)
			{
				if (class1686_0.bool_4 && !class1686_0.bool_0)
				{
					style_0.Borders[BorderType.TopBorder].Copy(style_1.Borders.method_0());
					hashtable_0[BorderType.TopBorder] = (int)tableStyleElementType_0;
					style_0.method_36(StyleModifyFlag.TopBorder);
				}
				if (class1686_0.bool_5 && !class1686_0.bool_1)
				{
					style_0.Borders[BorderType.BottomBorder].Copy(style_1.Borders.method_0());
					hashtable_0[BorderType.BottomBorder] = (int)tableStyleElementType_0;
					style_0.method_36(StyleModifyFlag.BottomBorder);
				}
			}
			if (style_1.Borders.method_2() != null)
			{
				if (class1686_0.bool_6 && !class1686_0.bool_2)
				{
					style_0.Borders[BorderType.LeftBorder].Copy(style_1.Borders.method_2());
					hashtable_0[BorderType.LeftBorder] = (int)tableStyleElementType_0;
					style_0.method_36(StyleModifyFlag.LeftBorder);
				}
				if (class1686_0.bool_7 && !class1686_0.bool_3)
				{
					style_0.Borders[BorderType.RightBorder].Copy(style_1.Borders.method_2());
					hashtable_0[BorderType.RightBorder] = (int)tableStyleElementType_0;
					style_0.method_36(StyleModifyFlag.RightBorder);
				}
			}
		}
		if (!style_1.IsModified(StyleModifyFlag.CellShading))
		{
			return;
		}
		if (style_1.IsModified(StyleModifyFlag.Pattern))
		{
			style_0.Pattern = style_1.Pattern;
		}
		if (style_1.IsModified(StyleModifyFlag.ForegroundColor))
		{
			style_0.ForeInternalColor.method_19(style_1.ForeInternalColor);
			style_0.method_36(StyleModifyFlag.ForegroundColor);
		}
		if (style_1.IsModified(StyleModifyFlag.BackgroundColor))
		{
			if (style_0.Pattern != 0 && style_0.Pattern != BackgroundType.Solid)
			{
				style_0.BackgroundInternalColor.method_19(style_1.BackgroundInternalColor);
				style_0.method_36(StyleModifyFlag.BackgroundColor);
			}
			else
			{
				style_0.Pattern = BackgroundType.Solid;
				style_0.ForeInternalColor.method_19(style_1.BackgroundInternalColor);
				style_0.method_36(StyleModifyFlag.ForegroundColor);
			}
		}
	}

	internal static void ApplyStyle(Style style_0, Style style_1, Class1686 class1686_0, int int_0, Hashtable hashtable_0)
	{
		if (style_1.IsModified(StyleModifyFlag.Font))
		{
			if (style_1.IsModified(StyleModifyFlag.FontName))
			{
				style_0.Font.method_14(style_1.Font.Name, style_1.Font.method_23());
			}
			if (style_1.IsModified(StyleModifyFlag.FontSize))
			{
				style_0.Font.Size = style_1.Font.Size;
			}
			if (style_1.IsModified(StyleModifyFlag.FontColor))
			{
				style_0.Font.InternalColor.method_19(style_1.Font.InternalColor);
				style_0.method_36(StyleModifyFlag.FontColor);
			}
			if (style_1.IsModified(StyleModifyFlag.FontItalic))
			{
				style_0.Font.IsItalic = style_1.Font.IsItalic;
			}
			if (style_1.IsModified(StyleModifyFlag.FontWeight))
			{
				style_0.Font.IsBold = style_1.Font.IsBold;
			}
			if (style_1.IsModified(StyleModifyFlag.FontUnderline))
			{
				style_0.Font.Underline = style_1.Font.Underline;
			}
			if (style_1.IsModified(StyleModifyFlag.FontScript))
			{
				style_0.Font.method_10(style_1.Font.method_9());
			}
			if (style_1.IsModified(StyleModifyFlag.FontStrike))
			{
				style_0.Font.IsStrikeout = style_1.Font.IsStrikeout;
			}
		}
		if (style_1.IsModified(StyleModifyFlag.Borders))
		{
			if (style_1.IsModified(StyleModifyFlag.LeftBorder) && class1686_0.bool_2)
			{
				style_0.Borders[BorderType.LeftBorder].Copy(style_1.Borders[BorderType.LeftBorder]);
				hashtable_0[BorderType.LeftBorder] = int_0;
				style_0.method_36(StyleModifyFlag.LeftBorder);
			}
			if (style_1.IsModified(StyleModifyFlag.RightBorder) && class1686_0.bool_3)
			{
				style_0.Borders[BorderType.RightBorder].Copy(style_1.Borders[BorderType.RightBorder]);
				hashtable_0[BorderType.RightBorder] = int_0;
				style_0.method_36(StyleModifyFlag.RightBorder);
			}
			if (style_1.IsModified(StyleModifyFlag.TopBorder) && class1686_0.bool_0)
			{
				style_0.Borders[BorderType.TopBorder].Copy(style_1.Borders[BorderType.TopBorder]);
				hashtable_0[BorderType.TopBorder] = int_0;
				style_0.method_36(StyleModifyFlag.TopBorder);
			}
			if (style_1.IsModified(StyleModifyFlag.BottomBorder) && class1686_0.bool_1)
			{
				style_0.Borders[BorderType.BottomBorder].Copy(style_1.Borders[BorderType.BottomBorder]);
				hashtable_0[BorderType.BottomBorder] = int_0;
				style_0.method_36(StyleModifyFlag.BottomBorder);
			}
			if (style_1.Borders.method_0() != null)
			{
				if (class1686_0.bool_4 && !class1686_0.bool_0)
				{
					style_0.Borders[BorderType.TopBorder].Copy(style_1.Borders.method_0());
					hashtable_0[BorderType.TopBorder] = int_0;
					style_0.method_36(StyleModifyFlag.TopBorder);
				}
				if (class1686_0.bool_5 && !class1686_0.bool_1)
				{
					style_0.Borders[BorderType.BottomBorder].Copy(style_1.Borders.method_0());
					hashtable_0[BorderType.BottomBorder] = int_0;
					style_0.method_36(StyleModifyFlag.BottomBorder);
				}
			}
			if (style_1.Borders.method_2() != null)
			{
				if (class1686_0.bool_6 && !class1686_0.bool_2)
				{
					style_0.Borders[BorderType.LeftBorder].Copy(style_1.Borders.method_2());
					hashtable_0[BorderType.LeftBorder] = int_0;
					style_0.method_36(StyleModifyFlag.LeftBorder);
				}
				if (class1686_0.bool_7 && !class1686_0.bool_3)
				{
					style_0.Borders[BorderType.RightBorder].Copy(style_1.Borders.method_2());
					hashtable_0[BorderType.RightBorder] = int_0;
					style_0.method_36(StyleModifyFlag.RightBorder);
				}
			}
		}
		if (style_1.IsModified(StyleModifyFlag.CellShading))
		{
			if (style_1.IsModified(StyleModifyFlag.Pattern))
			{
				style_0.Pattern = style_1.Pattern;
			}
			if (style_1.IsModified(StyleModifyFlag.ForegroundColor))
			{
				style_0.ForeInternalColor.method_19(style_1.ForeInternalColor);
				style_0.method_36(StyleModifyFlag.ForegroundColor);
			}
			if (style_1.IsModified(StyleModifyFlag.BackgroundColor))
			{
				if (style_0.Pattern != 0 && style_0.Pattern != BackgroundType.Solid)
				{
					style_0.BackgroundInternalColor.method_19(style_1.BackgroundInternalColor);
					style_0.method_36(StyleModifyFlag.BackgroundColor);
				}
				else
				{
					style_0.Pattern = BackgroundType.Solid;
					style_0.ForeInternalColor.method_19(style_1.BackgroundInternalColor);
					style_0.method_36(StyleModifyFlag.ForegroundColor);
				}
			}
		}
		if (style_1.IsModified(StyleModifyFlag.HorizontalAlignment))
		{
			style_0.HorizontalAlignment = style_1.HorizontalAlignment;
		}
		if (style_1.IsModified(StyleModifyFlag.Rotation))
		{
			style_0.RotationAngle = style_1.RotationAngle;
		}
		if (style_1.IsModified(StyleModifyFlag.Indent))
		{
			style_0.IndentLevel = style_1.IndentLevel;
		}
	}

	internal static FormatConditionCollection GetFormatConditions(Worksheet worksheet_0, Cell cell_0)
	{
		if (cell_0 == null)
		{
			return null;
		}
		ConditionalFormattingCollection conditionalFormattings = worksheet_0.ConditionalFormattings;
		for (int i = 0; i < conditionalFormattings.Count; i++)
		{
			FormatConditionCollection formatConditionCollection = conditionalFormattings[i];
			for (int j = 0; j < formatConditionCollection.arrayList_1.Count; j++)
			{
				CellArea cellArea = (CellArea)formatConditionCollection.arrayList_1[j];
				if (cellArea.StartRow <= cell_0.Row && cellArea.EndRow >= cell_0.Row && cellArea.StartColumn <= cell_0.Column && cellArea.EndColumn >= cell_0.Column)
				{
					return formatConditionCollection;
				}
			}
		}
		return null;
	}

	internal static ArrayList Sort(ArrayList arrayList_0)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			FormatCondition formatCondition = (FormatCondition)arrayList_0[i];
			bool flag = false;
			for (int j = 0; j < arrayList.Count; j++)
			{
				FormatCondition formatCondition2 = (FormatCondition)arrayList[j];
				if (formatCondition2.Priority > formatCondition.Priority)
				{
					arrayList.Insert(j, formatCondition);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				arrayList.Add(formatCondition);
			}
		}
		return arrayList;
	}

	private static Class314 smethod_6(Worksheet worksheet_0, Cell cell_0)
	{
		if (cell_0 == null)
		{
			return null;
		}
		ConditionalFormattingCollection conditionalFormattings = worksheet_0.ConditionalFormattings;
		Class1658 @class = worksheet_0.method_2().method_43();
		@class.method_1(bool_0: true);
		Style style = null;
		Class984 class2 = null;
		ArrayList arrayList = new ArrayList();
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < conditionalFormattings.Count; i++)
		{
			FormatConditionCollection formatConditionCollection = conditionalFormattings[i];
			for (int j = 0; j < formatConditionCollection.arrayList_1.Count; j++)
			{
				CellArea cellArea = (CellArea)formatConditionCollection.arrayList_1[j];
				if (cellArea.StartRow <= cell_0.Row && cellArea.EndRow >= cell_0.Row && cellArea.StartColumn <= cell_0.Column && cellArea.EndColumn >= cell_0.Column)
				{
					arrayList.AddRange(formatConditionCollection.method_0());
					break;
				}
			}
		}
		if (arrayList.Count > 0)
		{
			ArrayList arrayList2 = Sort(arrayList);
			for (int k = 0; k < arrayList2.Count; k++)
			{
				FormatCondition formatCondition = (FormatCondition)arrayList2[k];
				FormatConditionCollection formatConditionCollection_ = formatCondition.formatConditionCollection_0;
				CellArea cellarea = default(CellArea);
				for (int l = 0; l < formatConditionCollection_.arrayList_1.Count; l++)
				{
					cellarea = (CellArea)formatConditionCollection_.arrayList_1[l];
					if (cellarea.StartRow <= cell_0.Row && cellarea.EndRow >= cell_0.Row && cellarea.StartColumn <= cell_0.Column && cellarea.EndColumn >= cell_0.Column)
					{
						break;
					}
				}
				bool isTrue = false;
				object obj = smethod_10(worksheet_0, cell_0, formatCondition, @class, cellarea, out isTrue);
				if (obj != null || !formatCondition.StopIfTrue || !isTrue)
				{
					if (obj == null)
					{
						continue;
					}
					bool flag;
					if (flag = obj is Style)
					{
						if (style == null)
						{
							style = new Style(worksheet_0.method_2());
						}
						smethod_3(style, (Style)obj);
					}
					if (!formatCondition.StopIfTrue)
					{
						if (flag)
						{
							continue;
						}
						class2 = (Class984)obj;
						if ((style == null || !style.IsModified(StyleModifyFlag.CellShading) || !(class2 is Class985)) && class2 != null)
						{
							if (class2 is Class985 && !hashtable.Contains("ColorScaledStyle"))
							{
								hashtable["ColorScaledStyle"] = class2;
							}
							else if (class2 is Class986 && !hashtable.Contains("DataBarStyle"))
							{
								hashtable["DataBarStyle"] = class2;
							}
							else if (class2 is Class987 && !hashtable.Contains("IconSetStyle"))
							{
								hashtable["IconSetStyle"] = class2;
							}
						}
						continue;
					}
					if (flag)
					{
						return new Class314(style, null, null);
					}
					if (!hashtable.ContainsKey(obj.ToString()))
					{
						hashtable[obj.ToString()] = obj;
					}
					return new Class314(null, hashtable, null);
				}
				return null;
			}
		}
		return new Class314(style, hashtable, null);
	}

	private static object smethod_7(Cell cell_0)
	{
		object obj = cell_0.Value;
		if (obj != null)
		{
			switch (Type.GetTypeCode(obj.GetType()))
			{
			case TypeCode.String:
				if (Class1677.smethod_18((string)obj))
				{
					return Class1618.smethod_85((string)obj);
				}
				break;
			case TypeCode.Int32:
				obj = (double)(int)obj;
				break;
			}
		}
		return obj;
	}

	private static bool smethod_8(string string_0, object object_0, object object_1, Cell cell_0, bool bool_0)
	{
		object obj = smethod_7(cell_0);
		object obj2 = Class1662.Compare(object_0, object_1, "<=", bool_0);
		if (obj2 == null)
		{
			return false;
		}
		if (!(obj2 is bool))
		{
			return false;
		}
		if (!(bool)obj2)
		{
			object obj3 = object_0;
			object_0 = object_1;
			object_1 = obj3;
		}
		object obj4 = Class1662.Compare(object_0, obj, "<=", bool_0);
		object obj5 = Class1662.Compare(obj, object_1, "<=", bool_0);
		if (obj4 != null && obj5 != null)
		{
			if (obj4 is bool && obj5 is bool)
			{
				switch (string_0)
				{
				case "NotBetween":
					if ((bool)obj4 && (bool)obj5)
					{
						return false;
					}
					return true;
				case "Between":
					if ((bool)obj4 && (bool)obj5)
					{
						return true;
					}
					return false;
				default:
					return false;
				}
			}
			return false;
		}
		return false;
	}

	private static bool smethod_9(string string_0, object object_0, Cell cell_0, bool bool_0)
	{
		object obj = null;
		object object_ = smethod_7(cell_0);
		obj = Class1662.Compare(object_, object_0, string_0, bool_0);
		if (obj == null)
		{
			return false;
		}
		if (obj is bool)
		{
			return (bool)obj;
		}
		return false;
	}

	private static object smethod_10(Worksheet worksheet, Cell cell, FormatCondition fc, Class1658 calc, CellArea cellarea, out bool isTrue)
	{
		fc.method_11();
		isTrue = false;
		switch (fc.formatConditionType_0)
		{
		default:
		{
			if (fc.method_0() == null)
			{
				return null;
			}
			Class1661 @class = worksheet.method_2().Formula.method_11(cell, fc.method_0(), -1);
			object obj = null;
			if (@class != null)
			{
				obj = calc.method_2(@class, cell);
				if (obj != null)
				{
					obj = Class1660.smethod_18(obj, worksheet.method_2().Workbook.Settings.Date1904);
					if (obj != null && obj is bool)
					{
						isTrue = (bool)obj;
					}
				}
			}
			if (obj != null && obj is bool && (bool)obj)
			{
				return fc.style_0;
			}
			return null;
		}
		case FormatConditionType.CellValue:
		case FormatConditionType.ColorScale:
		case FormatConditionType.DataBar:
		case FormatConditionType.IconSet:
			if (fc.Type == FormatConditionType.IconSet && fc.IconSet != null)
			{
				return new Class987(fc.IconSet, calc, cell, cellarea);
			}
			if (fc.Type == FormatConditionType.DataBar && fc.DataBar != null)
			{
				return new Class986(fc.DataBar, calc, cell, cellarea);
			}
			if (fc.Type == FormatConditionType.ColorScale && fc.ColorScale != null)
			{
				return new Class985(fc.ColorScale, calc, cell, cellarea);
			}
			if (fc.Operator != OperatorType.None && fc.method_0() != null)
			{
				string string_ = "=";
				bool flag = true;
				switch (fc.Operator)
				{
				case OperatorType.Between:
					string_ = "Between";
					flag = false;
					break;
				case OperatorType.Equal:
					flag = true;
					break;
				case OperatorType.GreaterThan:
					string_ = ">";
					flag = true;
					break;
				case OperatorType.GreaterOrEqual:
					string_ = ">=";
					flag = true;
					break;
				case OperatorType.LessThan:
					string_ = "<";
					flag = true;
					break;
				case OperatorType.LessOrEqual:
					string_ = "<=";
					flag = true;
					break;
				default:
					return false;
				case OperatorType.NotBetween:
					string_ = "NotBetween";
					flag = false;
					break;
				case OperatorType.NotEqual:
					string_ = "<>";
					flag = true;
					break;
				}
				if (flag)
				{
					Class1661 class1661_ = worksheet.method_2().Formula.method_11(cell, fc.method_0(), -1);
					object object_ = calc.method_2(class1661_, cell);
					if (smethod_9(string_, object_, cell, worksheet.method_2().Workbook.Settings.Date1904))
					{
						return fc.style_0;
					}
				}
				else
				{
					Class1661 class1661_2 = worksheet.method_2().Formula.method_11(cell, fc.method_0(), -1);
					object object_2 = calc.method_2(class1661_2, cell);
					Class1661 class1661_3 = worksheet.method_2().Formula.method_11(cell, fc.method_4(), -1);
					object object_3 = calc.method_2(class1661_3, cell);
					if (smethod_8(string_, object_2, object_3, cell, worksheet.method_2().Workbook.Settings.Date1904))
					{
						return fc.style_0;
					}
				}
				return null;
			}
			return null;
		}
	}
}
