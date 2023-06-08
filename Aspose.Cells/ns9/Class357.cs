using System;
using System.Collections;
using System.Text;
using Aspose.Cells;
using ns10;
using ns16;

namespace ns9;

internal class Class357 : Class316
{
	private ArrayList arrayList_0;

	internal Class357()
	{
		int_0 = 507;
	}

	internal void SetStyle(Style style_0, bool bool_0, Workbook workbook_0)
	{
		arrayList_0 = new ArrayList();
		int num = 6;
		if (style_0.method_40() != null && style_0.IsModified(StyleModifyFlag.Font))
		{
			Font font = style_0.Font;
			if (style_0.IsModified(StyleModifyFlag.FontColor))
			{
				arrayList_0.Add(method_12(5, font.InternalColor, font.ColorIndex, bool_0: false, workbook_0));
			}
			if (style_0.IsModified(StyleModifyFlag.FontName) && font.Name != null)
			{
				arrayList_0.Add(method_13(24, font.Name));
			}
			if (style_0.IsModified(StyleModifyFlag.FontWeight))
			{
				arrayList_0.Add(method_10(25, (ushort)font.Weight));
			}
			if (style_0.IsModified(StyleModifyFlag.FontUnderline))
			{
				arrayList_0.Add(method_10(26, (ushort)Class1224.smethod_5(font.Underline)));
			}
			if (style_0.IsModified(StyleModifyFlag.FontScript))
			{
				arrayList_0.Add(method_10(27, font.method_8()));
			}
			if (style_0.Font.method_0() != null)
			{
				arrayList_0.Add(method_9(37, Class1224.smethod_39(style_0.Font.method_0())));
			}
			if (style_0.IsModified(StyleModifyFlag.FontItalic))
			{
				arrayList_0.Add(method_8(28, font.IsItalic));
			}
			if (style_0.IsModified(StyleModifyFlag.FontStrike))
			{
				arrayList_0.Add(method_8(29, font.IsStrikeout));
			}
			if (style_0.IsModified(StyleModifyFlag.FontFamily))
			{
				arrayList_0.Add(method_9(35, font.method_11()));
			}
			if (style_0.IsModified(StyleModifyFlag.FontSize))
			{
				arrayList_0.Add(method_11(36, font.method_16()));
			}
		}
		if (style_0.IsModified(StyleModifyFlag.NumberFormat))
		{
			int num2 = style_0.method_44();
			arrayList_0.Add(method_13(38, style_0.Custom));
			arrayList_0.Add(method_10(41, (ushort)num2));
		}
		if (style_0.IsModified(StyleModifyFlag.Pattern) || style_0.IsModified(StyleModifyFlag.ForegroundColor) || style_0.IsModified(StyleModifyFlag.BackgroundColor) || style_0.IsGradient)
		{
			if (style_0.IsGradient)
			{
				Class1535 @class = Class1535.smethod_0(style_0);
				Class1528 class1528_ = @class.class1528_0;
				arrayList_0.Add(method_7(3, class1528_));
				if (class1528_.double_4 != null)
				{
					int num3 = class1528_.double_4.Length;
					for (int i = 0; i < num3; i++)
					{
						arrayList_0.Add(method_6(4, class1528_.double_4[i], class1528_.internalColor_0[i], workbook_0));
					}
				}
			}
			else
			{
				int num4 = Class1224.smethod_12(style_0.Pattern);
				if (style_0.IsModified(StyleModifyFlag.Pattern))
				{
					arrayList_0.Add(method_9(0, (byte)num4));
				}
				if (style_0.IsModified(StyleModifyFlag.ForegroundColor))
				{
					arrayList_0.Add(method_12(1, style_0.ForeInternalColor, style_0.method_1(), bool_0: false, workbook_0));
				}
				if (style_0.IsModified(StyleModifyFlag.BackgroundColor))
				{
					arrayList_0.Add(method_12(2, style_0.BackgroundInternalColor, style_0.method_0(), bool_0: false, workbook_0));
				}
			}
		}
		if (style_0.IsModified(StyleModifyFlag.TextDirection))
		{
			arrayList_0.Add(method_9(15, (byte)Class1224.smethod_9(style_0.HorizontalAlignment)));
			arrayList_0.Add(method_9(16, (byte)Class1224.smethod_7(style_0.VerticalAlignment)));
			int num5 = style_0.RotationAngle;
			if (num5 < 0)
			{
				num5 = 90 - num5;
			}
			arrayList_0.Add(method_9(17, (byte)num5));
			arrayList_0.Add(method_10(18, (ushort)style_0.IndentLevel));
			if (style_0.TextDirection == TextDirectionType.LeftToRight)
			{
				arrayList_0.Add(method_9(19, 1));
			}
			else if (style_0.TextDirection == TextDirectionType.RightToLeft)
			{
				arrayList_0.Add(method_9(19, 2));
			}
			arrayList_0.Add(method_8(20, style_0.IsTextWrapped));
			arrayList_0.Add(method_8(22, style_0.ShrinkToFit));
		}
		if (style_0.IsModified(StyleModifyFlag.Borders) && style_0.method_4() != null)
		{
			BorderCollection borderCollection = style_0.method_4();
			Border border_ = borderCollection[BorderType.TopBorder];
			if (style_0.IsModified(StyleModifyFlag.TopBorder))
			{
				arrayList_0.Add(method_14(6, BorderType.TopBorder, border_, style_0, bool_0: false, workbook_0));
			}
			border_ = borderCollection[BorderType.BottomBorder];
			if (style_0.IsModified(StyleModifyFlag.BottomBorder))
			{
				arrayList_0.Add(method_14(7, BorderType.BottomBorder, border_, style_0, bool_0: false, workbook_0));
			}
			border_ = borderCollection[BorderType.LeftBorder];
			if (style_0.IsModified(StyleModifyFlag.LeftBorder))
			{
				arrayList_0.Add(method_14(8, BorderType.LeftBorder, border_, style_0, bool_0: false, workbook_0));
			}
			border_ = borderCollection[BorderType.RightBorder];
			if (style_0.IsModified(StyleModifyFlag.RightBorder))
			{
				arrayList_0.Add(method_14(9, BorderType.RightBorder, border_, style_0, bool_0: false, workbook_0));
			}
			border_ = borderCollection[BorderType.DiagonalUp];
			if (style_0.IsModified(StyleModifyFlag.DiagonalUpBorder))
			{
				arrayList_0.Add(method_14(13, BorderType.DiagonalUp, border_, style_0, bool_0: false, workbook_0));
			}
			border_ = borderCollection[BorderType.DiagonalDown];
			if (style_0.IsModified(StyleModifyFlag.DiagonalDownBorder))
			{
				arrayList_0.Add(method_14(14, BorderType.DiagonalDown, border_, style_0, bool_0: false, workbook_0));
			}
		}
		if (style_0.IsModified(StyleModifyFlag.Locked))
		{
			arrayList_0.Add(method_8(43, style_0.IsLocked));
			arrayList_0.Add(method_8(44, style_0.IsFormulaHidden));
		}
		foreach (byte[] item in arrayList_0)
		{
			num += item.Length;
		}
		byte_0 = new byte[num];
		if (bool_0)
		{
			byte_0[0] = 64;
		}
		int num6 = 2;
		if (!style_0.method_10())
		{
			byte_0[1] = 128;
		}
		num6 += 2;
		Array.Copy(BitConverter.GetBytes(arrayList_0.Count), 0, byte_0, num6, 2);
		num6 += 2;
		foreach (byte[] item2 in arrayList_0)
		{
			Array.Copy(item2, 0, byte_0, num6, item2.Length);
			num6 += item2.Length;
		}
	}

	private byte[] method_6(int int_1, double double_0, InternalColor internalColor_0, Workbook workbook_0)
	{
		byte[] array = new byte[22];
		Array.Copy(BitConverter.GetBytes((ushort)int_1), 0, array, 0, 2);
		array[2] = 22;
		Array.Copy(BitConverter.GetBytes(double_0), 0, array, 6, 8);
		method_4(array, 14, internalColor_0, 64, workbook_0);
		return array;
	}

	private byte[] method_7(int int_1, Class1528 class1528_0)
	{
		byte[] array = new byte[48];
		Array.Copy(BitConverter.GetBytes((ushort)int_1), 0, array, 0, 2);
		array[2] = 48;
		if (class1528_0.string_0 == "path")
		{
			Array.Copy(BitConverter.GetBytes(1), 0, array, 4, 4);
		}
		Array.Copy(BitConverter.GetBytes((double)class1528_0.int_0), 0, array, 8, 8);
		Array.Copy(BitConverter.GetBytes(class1528_0.double_0), 0, array, 16, 8);
		Array.Copy(BitConverter.GetBytes(class1528_0.double_1), 0, array, 24, 8);
		Array.Copy(BitConverter.GetBytes(class1528_0.double_2), 0, array, 32, 8);
		Array.Copy(BitConverter.GetBytes(class1528_0.double_3), 0, array, 40, 8);
		return array;
	}

	private byte[] method_8(int int_1, bool bool_0)
	{
		return method_9(int_1, (byte)(bool_0 ? 1u : 0u));
	}

	private byte[] method_9(int int_1, byte byte_1)
	{
		byte[] array = new byte[5];
		Array.Copy(BitConverter.GetBytes((ushort)int_1), 0, array, 0, 2);
		array[2] = 5;
		array[4] = byte_1;
		return array;
	}

	private byte[] method_10(int int_1, ushort ushort_0)
	{
		byte[] array = new byte[6];
		Array.Copy(BitConverter.GetBytes((ushort)int_1), 0, array, 0, 2);
		array[2] = 6;
		Array.Copy(BitConverter.GetBytes(ushort_0), 0, array, 4, 2);
		return array;
	}

	private byte[] method_11(int int_1, int int_2)
	{
		byte[] array = new byte[8];
		Array.Copy(BitConverter.GetBytes((ushort)int_1), 0, array, 0, 2);
		array[2] = 8;
		Array.Copy(BitConverter.GetBytes(int_2), 0, array, 4, 4);
		return array;
	}

	private byte[] method_12(int int_1, InternalColor internalColor_0, int int_2, bool bool_0, Workbook workbook_0)
	{
		byte_0 = new byte[12];
		Array.Copy(BitConverter.GetBytes((ushort)int_1), 0, byte_0, 0, 2);
		byte_0[2] = 12;
		if (bool_0)
		{
			byte_0[4] = 4;
			return byte_0;
		}
		method_4(byte_0, 4, internalColor_0, 64, workbook_0);
		return byte_0;
	}

	private byte[] method_13(int int_1, string string_0)
	{
		byte[] array = new byte[6 + string_0.Length * 2];
		Array.Copy(BitConverter.GetBytes((ushort)int_1), 0, array, 0, 2);
		Array.Copy(BitConverter.GetBytes((ushort)array.Length), 0, array, 2, 2);
		Array.Copy(BitConverter.GetBytes((ushort)string_0.Length), 0, array, 4, 2);
		byte[] bytes = Encoding.Unicode.GetBytes(string_0);
		Array.Copy(bytes, 0, array, 6, bytes.Length);
		return array;
	}

	private byte[] method_14(int int_1, BorderType borderType_0, Border border_0, Style style_0, bool bool_0, Workbook workbook_0)
	{
		byte_0 = new byte[14];
		Array.Copy(BitConverter.GetBytes((ushort)int_1), 0, byte_0, 0, 2);
		byte_0[2] = 14;
		if (bool_0)
		{
			byte_0[4] = 4;
		}
		else
		{
			method_4(byte_0, 4, border_0.InternalColor, 64, workbook_0);
		}
		int num = Class1224.smethod_11(border_0.LineStyle);
		Array.Copy(BitConverter.GetBytes((ushort)num), 0, byte_0, 12, 2);
		return byte_0;
	}
}
