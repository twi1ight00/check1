using System;
using System.Drawing;
using System.IO;
using Aspose.Cells;

namespace ns9;

internal class Class316
{
	protected byte[] byte_0;

	protected int int_0;

	protected Class316()
	{
	}

	internal Class316(int int_1)
	{
		int_0 = int_1;
	}

	internal Class316(int int_1, int int_2)
	{
		int_0 = int_1;
		byte_0 = BitConverter.GetBytes(int_2);
	}

	internal void method_0(Stream stream_0)
	{
		byte[] array = new byte[8];
		int int_ = 0;
		method_1(array, ref int_, int_0);
		if (byte_0 != null)
		{
			method_1(array, ref int_, byte_0.Length);
			stream_0.Write(array, 0, int_);
			stream_0.Write(byte_0, 0, byte_0.Length);
		}
		else
		{
			stream_0.Write(array, 0, int_ + 1);
		}
	}

	private void method_1(byte[] byte_1, ref int int_1, int int_2)
	{
		int num;
		while (true)
		{
			num = int_2 % 128;
			int num2 = int_2 / 128;
			if (num2 <= 0)
			{
				break;
			}
			num |= 0x80;
			byte_1[int_1++] = (byte)num;
			int_2 = num2;
		}
		byte_1[int_1++] = (byte)num;
	}

	protected void method_2(byte[] byte_1, int int_1, Color color_0)
	{
		if (!color_0.IsEmpty)
		{
			byte_0[0] = 2;
			byte_0[4] = color_0.R;
			byte_0[5] = color_0.G;
			byte_0[6] = color_0.B;
			byte_0[7] = color_0.A;
		}
	}

	internal void method_3(byte[] byte_1, int int_1, InternalColor internalColor_0, int int_2)
	{
		if (internalColor_0.method_2())
		{
			byte_0[int_1] = 1;
			Array.Copy(BitConverter.GetBytes((ushort)int_2), 0, byte_0, int_1 + 1, 2);
			return;
		}
		byte_0[int_1] = 4;
		Workbook workbook_ = new Workbook();
		int num = internalColor_0.method_7(workbook_);
		byte_0[int_1 + 4] = (byte)((num & 0xFF0000) >> 16);
		byte_0[int_1 + 5] = (byte)((num & 0xFF00) >> 8);
		byte_0[int_1 + 6] = (byte)((uint)num & 0xFFu);
		byte_0[int_1 + 7] = byte.MaxValue;
	}

	internal void method_4(byte[] byte_1, int int_1, InternalColor internalColor_0, int int_2, Workbook workbook_0)
	{
		if (internalColor_0.method_2())
		{
			byte_1[int_1] = 1;
			Array.Copy(BitConverter.GetBytes((ushort)int_2), 0, byte_1, int_1 + 1, 2);
			return;
		}
		if (internalColor_0.ColorType == ColorType.RGB)
		{
			byte_1[int_1] = (byte)(method_5(internalColor_0.ColorType) << 1);
		}
		else
		{
			byte_1[int_1] = (byte)((method_5(internalColor_0.ColorType) << 1) + 1);
		}
		byte_1[int_1 + 1] = (byte)internalColor_0.method_4();
		Array.Copy(BitConverter.GetBytes((short)(internalColor_0.Tint * 32767.0)), 0, byte_1, int_1 + 2, 2);
		int num = internalColor_0.method_7(workbook_0);
		byte_1[int_1 + 4] = (byte)((num & 0xFF0000) >> 16);
		byte_1[int_1 + 5] = (byte)((num & 0xFF00) >> 8);
		byte_1[int_1 + 6] = (byte)((uint)num & 0xFFu);
		byte_1[int_1 + 7] = byte.MaxValue;
	}

	internal byte method_5(ColorType colorType_0)
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
