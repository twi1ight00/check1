using System;
using System.Collections;
using System.IO;
using Aspose.Foundation.sfntly.typography.font.sfntly.table.truetype;
using ns226;
using ns227;
using ns231;

namespace ns232;

internal class Class6123
{
	private readonly bool bool_0;

	private readonly StreamWriter streamWriter_0;

	private readonly StreamWriter streamWriter_1;

	private readonly StreamWriter streamWriter_2;

	public Class6123(bool doPush)
	{
		bool_0 = doPush;
		streamWriter_0 = new StreamWriter(new MemoryStream());
		streamWriter_0.AutoFlush = true;
		streamWriter_1 = new StreamWriter(new MemoryStream());
		streamWriter_1.AutoFlush = true;
		streamWriter_2 = new StreamWriter(new MemoryStream());
		streamWriter_2.AutoFlush = true;
	}

	public Class6123()
		: this(doPush: true)
	{
	}

	public void method_0(Class6020 sourceFont)
	{
		Class6040 @class = (Class6040)sourceFont.method_6(Class6116.int_12);
		int num = @class.method_13();
		Class6030 class2 = (Class6030)sourceFont.method_6(Class6116.int_11);
		for (int i = 0; i < num; i++)
		{
			int offset = @class.method_14(i);
			int length = @class.method_15(i);
			Glyph glyph = class2.method_12(offset, length);
			method_1(glyph);
		}
	}

	private void method_1(Glyph glyph)
	{
		try
		{
			if (glyph != null && glyph.method_2() != 0)
			{
				if (glyph is Class6053)
				{
					method_3((Class6053)glyph);
				}
				else if (glyph is Class6052)
				{
					method_4((Class6052)glyph);
				}
			}
			else
			{
				method_5(0);
			}
		}
		catch (IOException innerException)
		{
			throw new Exception("unexpected IOException writing glyph data", innerException);
		}
	}

	private void method_2(Glyph glyph)
	{
		if (bool_0)
		{
			method_7(glyph);
			return;
		}
		int num = glyph.vmethod_1();
		smethod_0(streamWriter_0, 0);
		smethod_0(streamWriter_0, num);
		if (num > 0)
		{
			glyph.vmethod_2().CopyTo(streamWriter_2);
		}
	}

	private void method_3(Class6053 glyph)
	{
		int num = glyph.method_8();
		method_5(num);
		for (int i = 0; i < num; i++)
		{
			smethod_0(streamWriter_0, glyph.method_18(i) - ((i == 0) ? 1 : 0));
		}
		StreamWriter streamWriter = new StreamWriter(new MemoryStream());
		streamWriter.AutoFlush = true;
		int num2 = 0;
		int num3 = 0;
		for (int j = 0; j < num; j++)
		{
			int num4 = glyph.method_18(j);
			for (int k = 0; k < num4; k++)
			{
				int num5 = glyph.method_19(j, k);
				int num6 = glyph.method_20(j, k);
				int x = num5 - num2;
				int y = num6 - num3;
				method_6(streamWriter, glyph.method_21(j, k), x, y);
				num2 = num5;
				num3 = num6;
			}
		}
		byte[] array = ((MemoryStream)streamWriter.BaseStream).ToArray();
		streamWriter_0.BaseStream.Write(array, 0, array.Length);
		if (num > 0)
		{
			method_2(glyph);
		}
	}

	private void method_4(Class6052 glyph)
	{
		bool flag = false;
		method_5(-1);
		method_5(glyph.method_9());
		method_5(glyph.method_11());
		method_5(glyph.method_10());
		method_5(glyph.method_12());
		for (int i = 0; i < glyph.method_16(); i++)
		{
			int num = glyph.method_15(i);
			method_5(num);
			flag = (num & Class6052.int_10) != 0;
			method_5(glyph.method_17(i));
			if ((num & Class6052.int_2) == 0)
			{
				streamWriter_0.BaseStream.WriteByte((byte)glyph.method_18(i));
				streamWriter_0.BaseStream.WriteByte((byte)glyph.method_19(i));
			}
			else
			{
				method_5(glyph.method_18(i));
				method_5(glyph.method_19(i));
			}
			if (glyph.method_20(i) != 0)
			{
				try
				{
					byte[] array = glyph.method_21(i);
					streamWriter_0.BaseStream.Write(array, 0, array.Length);
				}
				catch (IOException)
				{
				}
			}
		}
		if (flag)
		{
			method_2(glyph);
		}
	}

	private void method_5(int value)
	{
		streamWriter_0.BaseStream.WriteByte((byte)(value >> 8));
		streamWriter_0.BaseStream.WriteByte((byte)((uint)value & 0xFFu));
	}

	private static void smethod_0(StreamWriter os, int value)
	{
		if (value < 0)
		{
			throw new InvalidOperationException();
		}
		if (value < 253)
		{
			os.BaseStream.WriteByte((byte)value);
		}
		else if (value < 506)
		{
			os.BaseStream.WriteByte(byte.MaxValue);
			os.BaseStream.WriteByte((byte)(value - 253));
		}
		else if (value < 762)
		{
			os.BaseStream.WriteByte(254);
			os.BaseStream.WriteByte((byte)(value - 506));
		}
		else
		{
			os.BaseStream.WriteByte(253);
			os.BaseStream.WriteByte((byte)(value >> 8));
			os.BaseStream.WriteByte((byte)((uint)value & 0xFFu));
		}
	}

	private static void smethod_1(StreamWriter os, int value)
	{
		int num = Math.Abs(value);
		if (value < 0)
		{
			os.BaseStream.WriteByte(250);
		}
		if (num < 250)
		{
			os.BaseStream.WriteByte((byte)num);
		}
		else if (num < 500)
		{
			os.BaseStream.WriteByte(byte.MaxValue);
			os.BaseStream.WriteByte((byte)(num - 250));
		}
		else if (num < 756)
		{
			os.BaseStream.WriteByte(254);
			os.BaseStream.WriteByte((byte)(num - 500));
		}
		else
		{
			os.BaseStream.WriteByte(253);
			os.BaseStream.WriteByte((byte)(num >> 8));
			os.BaseStream.WriteByte((byte)((uint)num & 0xFFu));
		}
	}

	private void method_6(StreamWriter os, bool onCurve, int x, int y)
	{
		int num = Math.Abs(x);
		int num2 = Math.Abs(y);
		int num3 = ((!onCurve) ? 128 : 0);
		int num4 = ((x >= 0) ? 1 : 0);
		int num5 = ((y >= 0) ? 1 : 0);
		int num6 = num4 + 2 * num5;
		if (x == 0 && num2 < 1280)
		{
			streamWriter_0.BaseStream.WriteByte((byte)(num3 + ((num2 & 0xF00) >> 7) + num5));
			os.BaseStream.WriteByte((byte)((uint)num2 & 0xFFu));
		}
		else if (y == 0 && num < 1280)
		{
			streamWriter_0.BaseStream.WriteByte((byte)(num3 + 10 + ((num & 0xF00) >> 7) + num4));
			os.BaseStream.WriteByte((byte)((uint)num & 0xFFu));
		}
		else if (num < 65 && num2 < 65)
		{
			streamWriter_0.BaseStream.WriteByte((byte)(num3 + 20 + ((num - 1) & 0x30) + (((num2 - 1) & 0x30) >> 2) + num6));
			os.BaseStream.WriteByte((byte)((uint)(((num - 1) & 0xF) << 4) | ((uint)(num2 - 1) & 0xFu)));
		}
		else if (num < 769 && num2 < 769)
		{
			streamWriter_0.BaseStream.WriteByte((byte)(num3 + 84 + 12 * (((num - 1) & 0x300) >> 8) + (((num2 - 1) & 0x300) >> 6) + num6));
			os.BaseStream.WriteByte((byte)((uint)(num - 1) & 0xFFu));
			os.BaseStream.WriteByte((byte)((uint)(num2 - 1) & 0xFFu));
		}
		else if (num < 4096 && num2 < 4096)
		{
			streamWriter_0.BaseStream.WriteByte((byte)(num3 + 120 + num6));
			os.BaseStream.WriteByte((byte)(num >> 4));
			os.BaseStream.WriteByte((byte)(((num & 0xF) << 4) | (num2 >> 8)));
			os.BaseStream.WriteByte((byte)((uint)num2 & 0xFFu));
		}
		else
		{
			streamWriter_0.BaseStream.WriteByte((byte)(num3 + 124 + num6));
			os.BaseStream.WriteByte((byte)(num >> 8));
			os.BaseStream.WriteByte((byte)((uint)num & 0xFFu));
			os.BaseStream.WriteByte((byte)(num2 >> 8));
			os.BaseStream.WriteByte((byte)((uint)num2 & 0xFFu));
		}
	}

	private void method_7(Glyph glyph)
	{
		int num = glyph.vmethod_1();
		Class6016 @class = glyph.vmethod_2();
		int num2 = 0;
		ArrayList arrayList = new ArrayList();
		while (num2 + 1 < num)
		{
			int num3 = num2;
			int num4 = @class.method_13(num3++);
			int num5 = 0;
			int num6 = 0;
			if (num4 != 64 && num4 != 65)
			{
				if (num4 < 176 || num4 >= 192)
				{
					break;
				}
				num5 = 1 + (num4 & 7);
				num6 = ((num4 & 8) >> 3) + 1;
			}
			else
			{
				num5 = @class.method_13(num3++);
				num6 = (num4 & 1) + 1;
			}
			if (num2 + num6 * num5 > num)
			{
				break;
			}
			for (int i = 0; i < num5; i++)
			{
				if (num6 == 1)
				{
					arrayList.Add(@class.method_13(num3));
				}
				else
				{
					arrayList.Add(@class.method_17(num3));
				}
				num3 += num6;
			}
			num2 = num3;
		}
		int count = arrayList.Count;
		int num7 = num - num2;
		smethod_0(streamWriter_0, count);
		smethod_0(streamWriter_0, num7);
		smethod_2(streamWriter_1, arrayList);
		if (num7 > 0)
		{
			((Class6016)@class.vmethod_1(num2)).CopyTo(streamWriter_2);
		}
	}

	private static void smethod_2(StreamWriter os, ArrayList data)
	{
		int count = data.Count;
		int num = 0;
		for (int i = 0; i < count; i++)
		{
			if ((num & 1) == 0)
			{
				int num2 = (int)data[i];
				if (num == 0 && i >= 2 && i + 2 < count && num2 == (int)data[i - 2] && num2 == (int)data[i + 2])
				{
					if (i + 4 < count && num2 == (int)data[i + 4])
					{
						os.BaseStream.WriteByte(252);
						num = 20;
					}
					else
					{
						os.BaseStream.WriteByte(251);
						num = 4;
					}
				}
				else
				{
					smethod_1(os, (int)data[i]);
				}
			}
			num >>= 1;
		}
	}

	public byte[] method_8()
	{
		return ((MemoryStream)streamWriter_0.BaseStream).ToArray();
	}

	public byte[] method_9()
	{
		return ((MemoryStream)streamWriter_1.BaseStream).ToArray();
	}

	public byte[] method_10()
	{
		return ((MemoryStream)streamWriter_2.BaseStream).ToArray();
	}
}
