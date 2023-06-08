using System;
using System.IO;

namespace ns4;

internal class Class1162
{
	internal class Exception3 : Exception
	{
		public Exception3()
			: base("buffer underrun")
		{
		}
	}

	private Class1162()
	{
	}

	public static short smethod_0(byte[] data, int offset)
	{
		return (short)smethod_29(data, offset, 2);
	}

	public static int smethod_1(byte[] data, int offset)
	{
		short num = (short)smethod_29(data, offset, 2);
		return (ushort)num;
	}

	public static short[] smethod_2(byte[] data, int offset, int size)
	{
		short[] array = new short[size];
		for (int i = 0; i < size; i++)
		{
			array[i] = smethod_0(data, offset + 2 + i * 2);
		}
		return array;
	}

	public static short[] smethod_3(byte[] data, int offset)
	{
		int size = (short)smethod_29(data, offset, 2);
		return smethod_2(data, offset, size);
	}

	public static short smethod_4(byte[] data)
	{
		return smethod_0(data, 0);
	}

	public static int smethod_5(byte[] data)
	{
		return smethod_1(data, 0);
	}

	public static int smethod_6(byte[] data, int offset)
	{
		return (int)smethod_29(data, offset, 4);
	}

	public static int smethod_7(byte[] data)
	{
		return smethod_6(data, 0);
	}

	public static long smethod_8(byte[] data, int offset)
	{
		return smethod_29(data, offset, 4);
	}

	public static long smethod_9(byte[] data)
	{
		return smethod_8(data, 0);
	}

	public static long smethod_10(byte[] data, int offset)
	{
		return smethod_29(data, offset, 8);
	}

	public static long smethod_11(byte[] data)
	{
		return smethod_10(data, 0);
	}

	public static void smethod_12(byte[] data, int offset, short value)
	{
		smethod_30(data, offset, value, 2);
	}

	public static void smethod_13(byte[] data, int offset, int value)
	{
		smethod_30(data, offset, value, 2);
	}

	public static void smethod_14(byte[] data, int offset, short[] value)
	{
		smethod_30(data, offset, value.Length, 2);
		for (int i = 0; i < value.Length; i++)
		{
			smethod_30(data, offset + 2 + i * 2, value[i], 2);
		}
	}

	public static void smethod_15(byte[] data, short value)
	{
		smethod_12(data, 0, value);
	}

	public static void smethod_16(byte[] data, int offset, int value)
	{
		smethod_30(data, offset, value, 4);
	}

	public static void smethod_17(byte[] data, int value)
	{
		smethod_16(data, 0, value);
	}

	public static void smethod_18(byte[] data, long value)
	{
		smethod_19(data, 0, value);
	}

	public static void smethod_19(byte[] data, int offset, long value)
	{
		smethod_30(data, offset, value, 4);
	}

	public static void smethod_20(byte[] data, int offset, long value)
	{
		smethod_30(data, offset, value, 8);
	}

	public static void smethod_21(byte[] data, long value)
	{
		smethod_20(data, 0, value);
	}

	public static short smethod_22(Stream stream)
	{
		return smethod_4(smethod_28(stream, 2));
	}

	public static void smethod_23(Stream stream, short value)
	{
		byte[] array = new byte[2];
		smethod_12(array, 0, value);
		stream.Write(array, 0, array.Length);
	}

	public static int smethod_24(Stream stream)
	{
		return smethod_7(smethod_28(stream, 4));
	}

	public static void smethod_25(Stream stream, int value)
	{
		byte[] array = new byte[4];
		smethod_16(array, 0, value);
		stream.Write(array, 0, array.Length);
	}

	public static long smethod_26(Stream stream)
	{
		return smethod_11(smethod_28(stream, 8));
	}

	public static void smethod_27(Stream stream, long value)
	{
		byte[] array = new byte[8];
		smethod_20(array, 0, value);
		stream.Write(array, 0, array.Length);
	}

	public static byte[] smethod_28(Stream stream, int size)
	{
		byte[] array = new byte[size];
		int num = stream.Read(array, 0, array.Length);
		if (num == -1)
		{
			Array.Clear(array, 0, size);
		}
		else if (num != size)
		{
			throw new Exception3();
		}
		return array;
	}

	private static long smethod_29(byte[] data, int offset, int size)
	{
		long num = 0L;
		for (int num2 = offset + size - 1; num2 >= offset; num2--)
		{
			num <<= 8;
			num |= (byte)(0xFF & data[num2]);
		}
		return num;
	}

	private static void smethod_30(byte[] data, int offset, long value, int size)
	{
		int num = size + offset;
		long num2 = value;
		for (int i = offset; i < num; i++)
		{
			data[i] = (byte)((ulong)num2 & 0xFFuL);
			num2 >>= 8;
		}
	}

	public static int smethod_31(byte b)
	{
		if ((b & 0x80u) != 0)
		{
			return (b & 0x7F) + 128;
		}
		return b;
	}

	public static int smethod_32(byte[] data, int offset)
	{
		return (int)smethod_29(data, offset, 1);
	}

	public static int smethod_33(byte[] data)
	{
		return smethod_32(data, 0);
	}

	public static byte[] smethod_34(byte[] data, int offset, int size)
	{
		byte[] array = new byte[size];
		Array.Copy(data, offset, array, 0, size);
		return array;
	}

	public static double smethod_35(uint fp)
	{
		double num = (double)(fp & 0xFFFFu) / 65535.0;
		ushort num2 = (ushort)(fp >> 16);
		if ((num2 & 0x8000u) != 0)
		{
			double num3 = num2 - 65536;
			return num3 + num;
		}
		return num + (double)(int)num2;
	}

	public static uint smethod_36(double d)
	{
		double num = Math.Floor(d);
		uint num3;
		if (d < 0.0)
		{
			short num2 = (short)num;
			num3 = (uint)(65536 + num2 << 16);
			return num3 | ((uint)((1.0 - Math.Abs(d) + (Math.Abs(num) - 1.0)) * 65536.0) & 0xFFFFu);
		}
		num3 = (uint)num << 16;
		return num3 | ((uint)((d - num) * 65536.0) & 0xFFFFu);
	}
}
