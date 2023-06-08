using System;
using Aspose.Cells;
using ns2;
using ns27;

namespace ns28;

internal class Class553 : Class538
{
	private Style style_0;

	private uint uint_0;

	private ushort ushort_0 = 32774;

	internal Class553(Style style_1)
	{
		method_2(244);
		style_0 = style_1;
		if (style_1 != null)
		{
			method_4();
		}
	}

	private void method_4()
	{
		int num = 6;
		if (style_0.IsModified(StyleModifyFlag.NumberFormat))
		{
			string custom = style_0.Custom;
			if (custom != null && custom.Length > 0)
			{
				ushort_0 |= 1;
				num += 4 + Class1677.smethod_29(custom);
			}
			else
			{
				num += 2;
			}
			uint_0 |= 33554432u;
		}
		if (style_0.IsModified(StyleModifyFlag.Font))
		{
			uint_0 |= 67108864u;
			num += 118;
		}
		if (style_0.IsModified(StyleModifyFlag.AlignmentSettings))
		{
			uint_0 |= 134217728u;
			num += 8;
		}
		if (style_0.IsModified(StyleModifyFlag.Borders))
		{
			uint_0 |= 268435456u;
			num += 8;
		}
		if (style_0.IsModified(StyleModifyFlag.CellShading))
		{
			uint_0 |= 536870912u;
			num += 4;
		}
		if (style_0.IsModified(StyleModifyFlag.Locked))
		{
			uint_0 |= 1073741824u;
			num += 2;
		}
		method_0((short)num);
		byte_0 = new byte[base.Length];
		method_5();
	}

	private void method_5()
	{
		int int_ = 6;
		if (style_0.IsModified(StyleModifyFlag.NumberFormat))
		{
			string custom = style_0.Custom;
			if (custom != null && custom.Length > 0)
			{
				int_ += 2;
				int num = Class937.smethod_5(byte_0, ref int_, custom);
				Array.Copy(BitConverter.GetBytes((short)(num + 2)), 0, byte_0, 6, 2);
			}
			else
			{
				byte_0[int_++] = 0;
				byte_0[int_++] = (byte)style_0.Number;
			}
		}
		if (style_0.IsModified(StyleModifyFlag.Font))
		{
			for (int i = 0; i < 64; i++)
			{
				byte_0[int_ + i] = 0;
			}
			if (style_0.IsModified(StyleModifyFlag.FontName))
			{
				int num2 = Class937.smethod_4(byte_0, int_ + 1, style_0.Font.Name);
				byte_0[int_] = (byte)num2;
			}
			if (style_0.IsModified(StyleModifyFlag.FontSize))
			{
				Array.Copy(BitConverter.GetBytes(style_0.Font.Size * 20), 0, byte_0, int_ + 64, 4);
			}
			else
			{
				Array.Copy(BitConverter.GetBytes(-1), 0, byte_0, int_ + 64, 4);
			}
			if (style_0.IsModified(StyleModifyFlag.FontItalic))
			{
				if (style_0.Font.IsItalic)
				{
					byte_0[int_ + 68] |= 2;
				}
			}
			else
			{
				byte_0[int_ + 88] |= 2;
			}
			if (style_0.IsModified(StyleModifyFlag.FontWeight))
			{
				Array.Copy(BitConverter.GetBytes((ushort)style_0.Font.Weight), 0, byte_0, int_ + 72, 2);
			}
			else
			{
				Array.Copy(BitConverter.GetBytes(1), 0, byte_0, int_ + 100, 4);
			}
			if (style_0.IsModified(StyleModifyFlag.FontStrike))
			{
				if (style_0.Font.IsStrikeout)
				{
					byte_0[int_ + 68] |= 128;
				}
			}
			else
			{
				byte_0[int_ + 88] |= 128;
			}
			if (style_0.IsModified(StyleModifyFlag.FontScript))
			{
				short value = 1;
				if (style_0.Font.IsSubscript)
				{
					value = 2;
				}
				Array.Copy(BitConverter.GetBytes(value), 0, byte_0, int_ + 74, 2);
			}
			else
			{
				Array.Copy(BitConverter.GetBytes(1), 0, byte_0, int_ + 92, 4);
			}
			if (style_0.IsModified(StyleModifyFlag.FontUnderline))
			{
				byte b = 0;
				switch (style_0.Font.Underline)
				{
				case FontUnderlineType.Single:
					b = 1;
					break;
				case FontUnderlineType.Double:
					b = 2;
					break;
				case FontUnderlineType.Accounting:
					b = 33;
					break;
				case FontUnderlineType.DoubleAccounting:
					b = 34;
					break;
				}
				byte_0[int_ + 76] = b;
			}
			else
			{
				Array.Copy(BitConverter.GetBytes(1), 0, byte_0, int_ + 96, 4);
			}
			int value2 = -1;
			if (style_0.IsModified(StyleModifyFlag.FontColor))
			{
				value2 = style_0.method_7(style_0.Font.InternalColor, 32767);
			}
			Array.Copy(BitConverter.GetBytes(value2), 0, byte_0, int_ + 80, 4);
			Array.Copy(BitConverter.GetBytes((short)1), 0, byte_0, int_ + 116, 2);
			int_ += 118;
		}
		if (style_0.IsModified(StyleModifyFlag.AlignmentSettings))
		{
			if (style_0.IsModified(StyleModifyFlag.HorizontalAlignment))
			{
				byte_0[int_] |= (byte)Class1673.smethod_11(style_0.HorizontalAlignment, bool_0: false);
			}
			else
			{
				uint_0 |= 1u;
			}
			if (style_0.IsModified(StyleModifyFlag.VerticalAlignment))
			{
				byte_0[int_] |= (byte)(Class1673.smethod_11(style_0.VerticalAlignment, bool_0: true) << 4);
			}
			else
			{
				uint_0 |= 2u;
			}
			if (style_0.IsModified(StyleModifyFlag.WrapText))
			{
				if (style_0.IsTextWrapped)
				{
					byte_0[int_] |= 8;
				}
			}
			else
			{
				uint_0 |= 4u;
			}
			if (style_0.IsModified(StyleModifyFlag.Rotation))
			{
				byte_0[int_ + 1] = (byte)style_0.RotationAngle;
			}
			else
			{
				uint_0 |= 8u;
			}
			uint_0 |= 16u;
			if (style_0.IsModified(StyleModifyFlag.Indent))
			{
				if (style_0.IndentLevel <= 15)
				{
					byte_0[int_ + 2] |= (byte)style_0.IndentLevel;
					byte_0[int_ + 4] = byte.MaxValue;
				}
				else
				{
					byte_0[int_ + 4] = (byte)style_0.IndentLevel;
				}
			}
			else
			{
				uint_0 |= 32u;
			}
			if (style_0.IsModified(StyleModifyFlag.ShrinkToFit))
			{
				if (style_0.ShrinkToFit)
				{
					byte_0[int_ + 2] |= 16;
				}
			}
			else
			{
				uint_0 |= 64u;
			}
			uint_0 |= 128u;
			if (style_0.IsModified(StyleModifyFlag.TextDirection))
			{
				byte b2 = 0;
				switch (style_0.TextDirection)
				{
				case TextDirectionType.LeftToRight:
					b2 = 1;
					break;
				case TextDirectionType.RightToLeft:
					b2 = 2;
					break;
				}
				byte_0[int_ + 2] |= (byte)(b2 << 6);
			}
			else
			{
				uint_0 |= 2147483648u;
			}
			int_ += 8;
		}
		if (style_0.IsModified(StyleModifyFlag.Borders))
		{
			if (style_0.Borders.Outline)
			{
				ushort_0 |= 4;
			}
			ushort num3 = 0;
			ushort num4 = 0;
			uint num5 = 0u;
			int num6 = 64;
			if (style_0.IsModified(StyleModifyFlag.LeftBorder))
			{
				num3 = (ushort)(num3 | (ushort)style_0.Borders[BorderType.LeftBorder].LineStyle);
				num6 = style_0.method_7(style_0.Borders[BorderType.LeftBorder].InternalColor, 64);
				num4 = (ushort)(num4 | (ushort)num6);
			}
			else
			{
				uint_0 |= 1024u;
			}
			if (style_0.IsModified(StyleModifyFlag.RightBorder))
			{
				num3 = (ushort)(num3 | (ushort)((int)style_0.Borders[BorderType.RightBorder].LineStyle << 4));
				num6 = style_0.method_7(style_0.Borders[BorderType.RightBorder].InternalColor, 64);
				num4 = (ushort)(num4 | (ushort)(num6 << 7));
			}
			else
			{
				uint_0 |= 2048u;
			}
			if (style_0.IsModified(StyleModifyFlag.TopBorder))
			{
				num3 = (ushort)(num3 | (ushort)((int)style_0.Borders[BorderType.TopBorder].LineStyle << 8));
				num6 = style_0.method_7(style_0.Borders[BorderType.TopBorder].InternalColor, 64);
				num5 |= (uint)num6;
			}
			else
			{
				uint_0 |= 4096u;
			}
			if (style_0.IsModified(StyleModifyFlag.BottomBorder))
			{
				num3 = (ushort)(num3 | (ushort)((int)style_0.Borders[BorderType.BottomBorder].LineStyle << 12));
				num6 = style_0.method_7(style_0.Borders[BorderType.BottomBorder].InternalColor, 64);
				num5 |= (uint)(num6 << 7);
			}
			else
			{
				uint_0 |= 8192u;
			}
			if (style_0.IsModified(StyleModifyFlag.DiagonalDownBorder))
			{
				num4 = (ushort)(num4 | 0x4000u);
				num5 |= (uint)((int)style_0.Borders[BorderType.DiagonalDown].LineStyle << 21);
				num6 = style_0.method_7(style_0.Borders[BorderType.DiagonalDown].InternalColor, 64);
				num5 |= (uint)(num6 << 14);
			}
			else
			{
				uint_0 |= 16384u;
			}
			if (style_0.IsModified(StyleModifyFlag.DiagonalUpBorder))
			{
				num4 = (ushort)(num4 | 0x8000u);
				num5 |= (uint)((int)style_0.Borders[BorderType.DiagonalUp].LineStyle << 21);
				num6 = style_0.method_7(style_0.Borders[BorderType.DiagonalUp].InternalColor, 64);
				num5 |= (uint)(num6 << 14);
			}
			else
			{
				uint_0 |= 32768u;
			}
			Array.Copy(BitConverter.GetBytes(num3), 0, byte_0, int_, 2);
			Array.Copy(BitConverter.GetBytes(num4), 0, byte_0, int_ + 2, 2);
			Array.Copy(BitConverter.GetBytes(num5), 0, byte_0, int_ + 4, 4);
			int_ += 8;
		}
		if (style_0.IsModified(StyleModifyFlag.CellShading))
		{
			int num7 = 0;
			int num8 = 0;
			if (style_0.IsModified(StyleModifyFlag.Pattern))
			{
				num7 |= (int)style_0.Pattern << 10;
			}
			else
			{
				uint_0 |= 65536u;
			}
			Array.Copy(BitConverter.GetBytes((short)num7), 0, byte_0, int_, 2);
			int num9 = 64;
			if (style_0.IsModified(StyleModifyFlag.ForegroundColor))
			{
				num9 = style_0.method_7(style_0.ForeInternalColor, 64);
				num8 |= num9;
			}
			else
			{
				uint_0 |= 131072u;
			}
			if (style_0.IsModified(StyleModifyFlag.BackgroundColor))
			{
				num9 = style_0.method_7(style_0.BackgroundInternalColor, 65);
				num8 |= num9 << 7;
			}
			else
			{
				uint_0 |= 262144u;
			}
			Array.Copy(BitConverter.GetBytes((short)num8), 0, byte_0, int_ + 2, 2);
			int_ += 4;
		}
		if (style_0.method_27())
		{
			if (style_0.IsModified(StyleModifyFlag.Locked))
			{
				if (style_0.IsLocked)
				{
					byte_0[int_] |= 1;
				}
			}
			else
			{
				uint_0 |= 256u;
			}
			if (style_0.IsModified(StyleModifyFlag.HideFormula))
			{
				if (style_0.IsFormulaHidden)
				{
					byte_0[int_] |= 2;
				}
			}
			else
			{
				uint_0 |= 512u;
			}
			int_ += 2;
		}
		Array.Copy(BitConverter.GetBytes(uint_0), 0, byte_0, 0, 4);
		Array.Copy(BitConverter.GetBytes(ushort_0), 0, byte_0, 4, 2);
	}
}
