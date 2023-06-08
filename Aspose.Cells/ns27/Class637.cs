using System;
using System.Text;
using Aspose.Cells;
using ns2;
using ns22;

namespace ns27;

internal class Class637 : Class538
{
	internal Class637()
	{
		method_2(49);
	}

	private int method_4(Font font, out bool found)
	{
		found = true;
		if (font.InternalColor.method_2())
		{
			return 32767;
		}
		return font.InternalColor.method_1(font.Sheets, 32767, out found);
	}

	[Attribute0(true)]
	internal Class1685 method_5(Font font_0, FileFormatType fileFormatType_1)
	{
		Class1685 @class = null;
		byte[] bytes = Encoding.Unicode.GetBytes(font_0.Name);
		int length = font_0.Name.Length;
		method_0((short)(16 + 2 * length));
		byte_0 = new byte[base.Length];
		byte_0[14] = (byte)length;
		byte_0[15] = 1;
		Array.Copy(bytes, 0, byte_0, 16, 2 * length);
		Array.Copy(BitConverter.GetBytes((short)font_0.method_16()), 0, byte_0, 0, 2);
		ushort num = 0;
		if (font_0.IsBold)
		{
			num = (ushort)(num | 1u);
		}
		if (font_0.IsItalic)
		{
			num = (ushort)(num | 2u);
		}
		if (font_0.IsStrikeout)
		{
			num = (ushort)(num | 8u);
		}
		Array.Copy(BitConverter.GetBytes(num), 0, byte_0, 2, 2);
		bool found = true;
		int num2 = method_4(font_0, out found);
		if (num2 == -1)
		{
			byte_0[4] = byte.MaxValue;
			byte_0[5] = 127;
		}
		else
		{
			Array.Copy(BitConverter.GetBytes((ushort)num2), 0, byte_0, 4, 2);
		}
		if (!found)
		{
			if (@class == null)
			{
				@class = new Class1685();
			}
			@class.Add(Enum235.const_13, font_0.InternalColor);
		}
		Array.Copy(BitConverter.GetBytes((short)font_0.Weight), 0, byte_0, 6, 2);
		Array.Copy(BitConverter.GetBytes(font_0.method_8()), 0, byte_0, 8, 2);
		switch (font_0.Underline)
		{
		case FontUnderlineType.Single:
			byte_0[10] = 1;
			break;
		case FontUnderlineType.Double:
			byte_0[10] = 2;
			break;
		case FontUnderlineType.Accounting:
			byte_0[10] = 33;
			break;
		case FontUnderlineType.DoubleAccounting:
			byte_0[10] = 34;
			break;
		}
		byte_0[11] = font_0.method_11();
		byte_0[12] = font_0.method_2();
		byte_0[13] = 0;
		return @class;
	}
}
