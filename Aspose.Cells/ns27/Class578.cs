using System;
using Aspose.Cells;

namespace ns27;

internal class Class578 : Class538
{
	private Style style_0;

	private uint uint_0;

	private ushort ushort_0;

	private int int_0;

	internal Class578(Style style_1)
	{
		style_0 = style_1;
		method_0(6);
		method_4();
		Write();
	}

	private void method_4()
	{
		uint_0 = 4194303u;
		bool flag = false;
		if (style_0 != null)
		{
			style_0.method_17();
			if (style_0.method_19())
			{
				flag = true;
				method_5();
				method_0((short)(base.Length + 118));
			}
			style_0.method_21();
			if (style_0.method_23())
			{
				flag = true;
				method_6();
				method_0((short)(base.Length + 8));
			}
			if (style_0.method_25())
			{
				flag = true;
				method_7();
				method_0((short)(base.Length + 4));
			}
			style_0.method_27();
		}
		if (!flag)
		{
			uint_0 = 0u;
		}
	}

	private void method_5()
	{
		uint_0 |= 67108864u;
	}

	private void method_6()
	{
		uint_0 |= 268435456u;
		if (style_0.IsModified(StyleModifyFlag.LeftBorder))
		{
			uint_0 &= 4294966271u;
		}
		if (style_0.IsModified(StyleModifyFlag.RightBorder))
		{
			uint_0 &= 4294965247u;
		}
		if (style_0.IsModified(StyleModifyFlag.TopBorder))
		{
			uint_0 &= 4294963199u;
		}
		if (style_0.IsModified(StyleModifyFlag.BottomBorder))
		{
			uint_0 &= 4294959103u;
		}
	}

	private void method_7()
	{
		uint_0 |= 536870912u;
		if (style_0.IsModified(StyleModifyFlag.Pattern))
		{
			uint_0 &= 4294901759u;
		}
		if (style_0.IsModified(StyleModifyFlag.ForegroundColor))
		{
			uint_0 &= 4294836223u;
		}
		if (style_0.IsModified(StyleModifyFlag.BackgroundColor))
		{
			uint_0 &= 4294705151u;
		}
	}

	private void Write()
	{
		byte_0 = new byte[base.Length];
		Array.Copy(BitConverter.GetBytes(uint_0), 0, byte_0, 0, 4);
		Array.Copy(BitConverter.GetBytes(ushort_0), 0, byte_0, 4, 2);
		if (style_0 != null && uint_0 != 0)
		{
			int_0 = 6;
			style_0.method_17();
			if (style_0.method_19())
			{
				method_8();
			}
			style_0.method_21();
			if (style_0.method_23())
			{
				method_9();
			}
			if (style_0.method_25())
			{
				method_10();
			}
			style_0.method_27();
		}
	}

	private void method_8()
	{
		for (int i = 0; i < 64; i++)
		{
			byte_0[int_0 + i] = 0;
		}
		if (style_0.IsModified(StyleModifyFlag.FontSize))
		{
			Array.Copy(BitConverter.GetBytes(style_0.Font.Size * 20), 0, byte_0, int_0 + 64, 4);
		}
		else
		{
			byte_0[int_0 + 64] = byte.MaxValue;
			byte_0[int_0 + 65] = byte.MaxValue;
			byte_0[int_0 + 66] = byte.MaxValue;
			byte_0[int_0 + 67] = byte.MaxValue;
		}
		byte_0[int_0 + 68] |= (byte)(style_0.Font.IsItalic ? 2 : 0);
		byte_0[int_0 + 68] |= (byte)(style_0.Font.IsStrikeout ? 128 : 0);
		if (style_0.IsModified(StyleModifyFlag.FontWeight))
		{
			int num = (style_0.Font.IsBold ? 700 : 400);
			Array.Copy(BitConverter.GetBytes((short)num), 0, byte_0, int_0 + 72, 2);
		}
		else
		{
			byte_0[int_0 + 72] = byte.MaxValue;
			byte_0[int_0 + 73] = byte.MaxValue;
		}
		short value = -1;
		if (style_0.IsModified(StyleModifyFlag.FontScript))
		{
			if (style_0.Font.IsSubscript)
			{
				value = 2;
			}
			else if (style_0.Font.IsSuperscript)
			{
				value = 1;
			}
		}
		Array.Copy(BitConverter.GetBytes(value), 0, byte_0, int_0 + 74, 2);
		byte b = byte.MaxValue;
		if (style_0.IsModified(StyleModifyFlag.FontUnderline))
		{
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
		}
		byte_0[int_0 + 76] = b;
		for (int j = 0; j < 3; j++)
		{
			byte_0[int_0 + 77 + j] = 0;
		}
		int value2 = -1;
		if (style_0.IsModified(StyleModifyFlag.FontColor))
		{
			value2 = style_0.method_7(style_0.Font.InternalColor, 32767);
		}
		Array.Copy(BitConverter.GetBytes(value2), 0, byte_0, int_0 + 80, 4);
		for (int k = 0; k < 4; k++)
		{
			byte_0[int_0 + 84 + k] = 0;
		}
		int num2 = ((style_0.IsModified(StyleModifyFlag.FontWeight) || style_0.IsModified(StyleModifyFlag.FontItalic)) ? 152 : 154);
		if (style_0.IsModified(StyleModifyFlag.FontStrike))
		{
			num2 &= -129;
		}
		Array.Copy(BitConverter.GetBytes(num2), 0, byte_0, int_0 + 88, 4);
		Array.Copy(BitConverter.GetBytes((!style_0.IsModified(StyleModifyFlag.FontScript)) ? 1 : 0), 0, byte_0, int_0 + 92, 4);
		Array.Copy(BitConverter.GetBytes((!style_0.IsModified(StyleModifyFlag.FontUnderline)) ? 1 : 0), 0, byte_0, int_0 + 96, 4);
		if (!style_0.IsModified(StyleModifyFlag.FontWeight))
		{
			byte_0[int_0 + 100] = 1;
			byte_0[int_0 + 101] = 0;
			byte_0[int_0 + 102] = 0;
			byte_0[int_0 + 103] = 0;
		}
		else
		{
			byte_0[int_0 + 100] = 0;
			byte_0[int_0 + 101] = 0;
			byte_0[int_0 + 102] = 0;
			byte_0[int_0 + 103] = 0;
		}
		for (int l = 0; l < 12; l++)
		{
			byte_0[int_0 + 104 + l] = 0;
		}
		Array.Copy(BitConverter.GetBytes((short)1), 0, byte_0, int_0 + 116, 2);
		int_0 += 118;
	}

	private void method_9()
	{
		int num = 0;
		int num2 = 0;
		int num3 = 64;
		if (style_0.IsModified(StyleModifyFlag.LeftBorder))
		{
			num |= (int)style_0.Borders[BorderType.LeftBorder].LineStyle;
			num3 = style_0.method_7(style_0.Borders[BorderType.LeftBorder].InternalColor, 64);
			num2 |= num3;
		}
		if (style_0.IsModified(StyleModifyFlag.RightBorder))
		{
			num |= (int)style_0.Borders[BorderType.RightBorder].LineStyle << 4;
			num3 = style_0.method_7(style_0.Borders[BorderType.RightBorder].InternalColor, 64);
			num2 |= num3 << 7;
		}
		if (style_0.IsModified(StyleModifyFlag.TopBorder))
		{
			num |= (int)style_0.Borders[BorderType.TopBorder].LineStyle << 8;
			num3 = style_0.method_7(style_0.Borders[BorderType.TopBorder].InternalColor, 64);
			num2 |= num3 << 16;
		}
		if (style_0.IsModified(StyleModifyFlag.BottomBorder))
		{
			num |= (int)style_0.Borders[BorderType.BottomBorder].LineStyle << 12;
			num3 = style_0.method_7(style_0.Borders[BorderType.BottomBorder].InternalColor, 64);
			num2 |= num3 << 23;
		}
		Array.Copy(BitConverter.GetBytes((short)num), 0, byte_0, int_0, 2);
		Array.Copy(BitConverter.GetBytes(num2), 0, byte_0, int_0 + 2, 4);
		byte_0[int_0 + 6] = 0;
		byte_0[int_0 + 7] = 0;
		int_0 += 8;
	}

	private void method_10()
	{
		int num = 0;
		int num2 = 0;
		if (style_0.IsModified(StyleModifyFlag.Pattern))
		{
			num |= (int)style_0.Pattern << 10;
		}
		Array.Copy(BitConverter.GetBytes((short)num), 0, byte_0, int_0, 2);
		bool found = false;
		int num3 = style_0.ForeInternalColor.method_1(style_0.method_5(), 64, out found);
		num2 |= num3;
		bool found2 = false;
		int num4 = style_0.BackgroundInternalColor.method_1(style_0.method_5(), 65, out found2);
		num2 |= num4 << 7;
		Array.Copy(BitConverter.GetBytes((short)num2), 0, byte_0, int_0 + 2, 2);
		int_0 += 4;
	}
}
