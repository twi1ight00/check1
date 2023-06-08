using System;
using System.Collections;
using System.Text;
using Aspose.Cells;
using ns10;

namespace ns27;

internal class Class542 : Class538
{
	private ArrayList arrayList_0;

	internal Class542()
	{
		method_2(2189);
	}

	internal void SetStyle(Style style_0, bool bool_0, Workbook workbook_0)
	{
		arrayList_0 = new ArrayList();
		int num = 18;
		if (style_0.method_40() != null && style_0.IsModified(StyleModifyFlag.Font))
		{
			Font font = style_0.Font;
			if (style_0.IsModified(StyleModifyFlag.FontColor))
			{
				arrayList_0.Add(method_8(5, font.InternalColor, font.ColorIndex, bool_0: false, workbook_0));
			}
			if (style_0.IsModified(StyleModifyFlag.FontName) && font.Name != null)
			{
				arrayList_0.Add(method_9(24, font.Name));
			}
			if (style_0.IsModified(StyleModifyFlag.FontWeight))
			{
				arrayList_0.Add(method_6(25, (ushort)font.Weight));
			}
			if (style_0.IsModified(StyleModifyFlag.FontUnderline))
			{
				arrayList_0.Add(method_6(26, (ushort)Class1224.smethod_5(font.Underline)));
			}
			if (style_0.IsModified(StyleModifyFlag.FontScript))
			{
				arrayList_0.Add(method_6(27, font.method_8()));
			}
			if (style_0.Font.method_0() != null)
			{
				arrayList_0.Add(method_5(37, Class1224.smethod_39(style_0.Font.method_0())));
			}
			if (style_0.IsModified(StyleModifyFlag.FontItalic))
			{
				arrayList_0.Add(method_4(28, font.IsItalic));
			}
			if (style_0.IsModified(StyleModifyFlag.FontStrike))
			{
				arrayList_0.Add(method_4(29, font.IsStrikeout));
			}
			if (style_0.IsModified(StyleModifyFlag.FontFamily))
			{
				arrayList_0.Add(method_5(35, font.method_11()));
			}
			if (style_0.IsModified(StyleModifyFlag.FontSize))
			{
				arrayList_0.Add(method_7(36, font.method_16()));
			}
		}
		if (style_0.IsModified(StyleModifyFlag.NumberFormat))
		{
			int num2 = style_0.method_44();
			arrayList_0.Add(method_9(38, style_0.Custom));
			arrayList_0.Add(method_6(41, (ushort)num2));
		}
		if (style_0.IsModified(StyleModifyFlag.Pattern) || style_0.IsModified(StyleModifyFlag.ForegroundColor) || style_0.IsModified(StyleModifyFlag.BackgroundColor))
		{
			int num3 = Class1224.smethod_12(style_0.Pattern);
			if (style_0.IsModified(StyleModifyFlag.Pattern))
			{
				arrayList_0.Add(method_5(0, (byte)num3));
			}
			if (style_0.IsModified(StyleModifyFlag.ForegroundColor))
			{
				arrayList_0.Add(method_8(1, style_0.ForeInternalColor, style_0.method_1(), bool_0: false, workbook_0));
			}
			if (style_0.IsModified(StyleModifyFlag.BackgroundColor))
			{
				arrayList_0.Add(method_8(2, style_0.BackgroundInternalColor, style_0.method_0(), bool_0: false, workbook_0));
			}
		}
		if (style_0.IsModified(StyleModifyFlag.TextDirection))
		{
			arrayList_0.Add(method_5(15, (byte)Class1224.smethod_9(style_0.HorizontalAlignment)));
			arrayList_0.Add(method_5(16, (byte)Class1224.smethod_7(style_0.VerticalAlignment)));
			int num4 = style_0.RotationAngle;
			if (num4 < 0)
			{
				num4 = 90 - num4;
			}
			arrayList_0.Add(method_5(17, (byte)num4));
			arrayList_0.Add(method_6(18, (ushort)style_0.IndentLevel));
			if (style_0.TextDirection == TextDirectionType.LeftToRight)
			{
				arrayList_0.Add(method_5(19, 1));
			}
			else if (style_0.TextDirection == TextDirectionType.RightToLeft)
			{
				arrayList_0.Add(method_5(19, 2));
			}
			arrayList_0.Add(method_4(20, style_0.IsTextWrapped));
			arrayList_0.Add(method_4(22, style_0.ShrinkToFit));
		}
		if (style_0.IsModified(StyleModifyFlag.Borders) && style_0.method_4() != null)
		{
			BorderCollection borderCollection = style_0.method_4();
			Border border_ = borderCollection[BorderType.TopBorder];
			if (style_0.IsModified(StyleModifyFlag.TopBorder))
			{
				arrayList_0.Add(method_10(6, BorderType.TopBorder, border_, style_0, bool_0: false, workbook_0));
			}
			border_ = borderCollection[BorderType.BottomBorder];
			if (style_0.IsModified(StyleModifyFlag.BottomBorder))
			{
				arrayList_0.Add(method_10(7, BorderType.BottomBorder, border_, style_0, bool_0: false, workbook_0));
			}
			border_ = borderCollection[BorderType.LeftBorder];
			if (style_0.IsModified(StyleModifyFlag.LeftBorder))
			{
				arrayList_0.Add(method_10(8, BorderType.LeftBorder, border_, style_0, bool_0: false, workbook_0));
			}
			border_ = borderCollection[BorderType.RightBorder];
			if (style_0.IsModified(StyleModifyFlag.RightBorder))
			{
				arrayList_0.Add(method_10(9, BorderType.RightBorder, border_, style_0, bool_0: false, workbook_0));
			}
			border_ = borderCollection[BorderType.DiagonalUp];
			if (style_0.IsModified(StyleModifyFlag.DiagonalUpBorder))
			{
				arrayList_0.Add(method_10(13, BorderType.DiagonalUp, border_, style_0, bool_0: false, workbook_0));
			}
			border_ = borderCollection[BorderType.DiagonalDown];
			if (style_0.IsModified(StyleModifyFlag.DiagonalDownBorder))
			{
				arrayList_0.Add(method_10(14, BorderType.DiagonalDown, border_, style_0, bool_0: false, workbook_0));
			}
		}
		if (style_0.IsModified(StyleModifyFlag.Locked))
		{
			arrayList_0.Add(method_4(43, style_0.IsLocked));
			arrayList_0.Add(method_4(44, style_0.IsFormulaHidden));
		}
		foreach (byte[] item in arrayList_0)
		{
			num += item.Length;
		}
		byte_0 = new byte[num];
		method_0((short)num);
		byte_0[0] = 141;
		byte_0[1] = 8;
		if (bool_0)
		{
			byte_0[12] |= 2;
		}
		byte_0[12] = 3;
		int num5 = 14;
		num5 = 14 + 2;
		Array.Copy(BitConverter.GetBytes(arrayList_0.Count), 0, byte_0, 16, 2);
		num5 = 16 + 2;
		foreach (byte[] item2 in arrayList_0)
		{
			Array.Copy(item2, 0, byte_0, num5, item2.Length);
			num5 += item2.Length;
		}
	}

	private byte[] method_4(int int_0, bool bool_0)
	{
		return method_5(int_0, (byte)(bool_0 ? 1u : 0u));
	}

	private byte[] method_5(int int_0, byte byte_1)
	{
		byte[] array = new byte[5];
		Array.Copy(BitConverter.GetBytes((ushort)int_0), 0, array, 0, 2);
		array[2] = 5;
		array[4] = byte_1;
		return array;
	}

	private byte[] method_6(int int_0, ushort ushort_0)
	{
		byte[] array = new byte[6];
		Array.Copy(BitConverter.GetBytes((ushort)int_0), 0, array, 0, 2);
		array[2] = 6;
		Array.Copy(BitConverter.GetBytes(ushort_0), 0, array, 4, 2);
		return array;
	}

	private byte[] method_7(int int_0, int int_1)
	{
		byte[] array = new byte[8];
		Array.Copy(BitConverter.GetBytes((ushort)int_0), 0, array, 0, 2);
		array[2] = 8;
		Array.Copy(BitConverter.GetBytes(int_1), 0, array, 4, 4);
		return array;
	}

	private byte[] method_8(int int_0, InternalColor internalColor_0, int int_1, bool bool_0, Workbook workbook_0)
	{
		byte_0 = new byte[12];
		Array.Copy(BitConverter.GetBytes((ushort)int_0), 0, byte_0, 0, 2);
		byte_0[2] = 12;
		if (bool_0)
		{
			byte_0[4] = 4;
			return byte_0;
		}
		method_11(byte_0, 4, internalColor_0, 64, workbook_0);
		return byte_0;
	}

	private byte[] method_9(int int_0, string string_0)
	{
		byte[] array = new byte[6 + string_0.Length * 2];
		Array.Copy(BitConverter.GetBytes((ushort)int_0), 0, array, 0, 2);
		Array.Copy(BitConverter.GetBytes((ushort)array.Length), 0, array, 2, 2);
		Array.Copy(BitConverter.GetBytes((ushort)string_0.Length), 0, array, 4, 2);
		byte[] bytes = Encoding.Unicode.GetBytes(string_0);
		Array.Copy(bytes, 0, array, 6, bytes.Length);
		return array;
	}

	private byte[] method_10(int int_0, BorderType borderType_0, Border border_0, Style style_0, bool bool_0, Workbook workbook_0)
	{
		byte_0 = new byte[14];
		Array.Copy(BitConverter.GetBytes((ushort)int_0), 0, byte_0, 0, 2);
		byte_0[2] = 14;
		if (bool_0)
		{
			byte_0[4] = 4;
		}
		else
		{
			method_11(byte_0, 4, border_0.InternalColor, 64, workbook_0);
		}
		int num = Class1224.smethod_11(border_0.LineStyle);
		Array.Copy(BitConverter.GetBytes((ushort)num), 0, byte_0, 12, 2);
		return byte_0;
	}

	internal void method_11(byte[] byte_1, int int_0, InternalColor internalColor_0, int int_1, Workbook workbook_0)
	{
		if (internalColor_0.method_2())
		{
			byte_0[int_0] = 1;
			Array.Copy(BitConverter.GetBytes((ushort)int_1), 0, byte_0, int_0 + 1, 2);
			return;
		}
		if (internalColor_0.ColorType == ColorType.RGB)
		{
			byte_0[int_0] = (byte)(method_12(internalColor_0.ColorType) << 1);
		}
		else
		{
			byte_0[int_0] = (byte)((method_12(internalColor_0.ColorType) << 1) + 1);
		}
		byte_0[int_0 + 1] = (byte)internalColor_0.method_4();
		Array.Copy(BitConverter.GetBytes((short)(internalColor_0.Tint * 32767.0)), 0, byte_0, int_0 + 2, 2);
		int num = internalColor_0.method_7(workbook_0);
		byte_0[int_0 + 4] = (byte)((num & 0xFF0000) >> 16);
		byte_0[int_0 + 5] = (byte)((num & 0xFF00) >> 8);
		byte_0[int_0 + 6] = (byte)((uint)num & 0xFFu);
		byte_0[int_0 + 7] = byte.MaxValue;
	}

	internal byte method_12(ColorType colorType_0)
	{
		return colorType_0 switch
		{
			ColorType.Automatic => 0, 
			ColorType.AutomaticIndex => 4, 
			ColorType.RGB => 2, 
			ColorType.IndexedColor => 1, 
			ColorType.Theme => 3, 
			_ => 4, 
		};
	}
}
