using System.IO;

namespace ns237;

internal class Stream5 : Stream1
{
	private const int int_0 = 5021;

	private const int int_1 = 256;

	private const int int_2 = 257;

	private const int int_3 = -1;

	private const int int_4 = 12;

	private MemoryStream memoryStream_0;

	private readonly int[] int_5;

	private readonly int[] int_6;

	private readonly byte[] byte_0;

	private int int_7;

	private int int_8;

	private int int_9;

	private Class6668 class6668_0;

	public Stream5(Stream outputStream)
		: base(outputStream)
	{
		int_5 = new int[5021];
		int_6 = new int[5021];
		byte_0 = new byte[5021];
	}

	public Stream5(Stream outputStream, Enum886 predictor, int colors, int columns, int bpp)
		: this(outputStream)
	{
		if (predictor != Enum886.const_0)
		{
			class6668_0 = new Class6668(predictor, colors, columns, bpp);
		}
		else
		{
			class6668_0 = null;
		}
	}

	public override void Write(byte[] srcBuffer, int srcOffset, int srcCount)
	{
		if (class6668_0 != null)
		{
			memoryStream_0 = class6668_0.method_0(new MemoryStream(srcBuffer, srcOffset, srcCount));
			memoryStream_0.Position = 0L;
		}
		else
		{
			memoryStream_0 = new MemoryStream(srcBuffer, srcOffset, srcCount);
		}
		method_0();
		method_1();
		method_5();
	}

	private void method_0()
	{
		int_7 = 0;
		int_8 = 128;
		int_9 = 9;
	}

	private void method_1()
	{
		for (int i = 0; i < int_5.Length; i++)
		{
			int_5[i] = -1;
		}
	}

	private void method_2()
	{
		if (int_8 != 128)
		{
			stream_0.WriteByte((byte)int_7);
		}
	}

	private void method_3(bool bit)
	{
		if (bit)
		{
			int_7 |= int_8;
		}
		int_8 >>= 1;
		if (int_8 == 0)
		{
			stream_0.WriteByte((byte)int_7);
			int_7 = 0;
			int_8 = 128;
		}
	}

	private void method_4(int code)
	{
		for (int num = 1 << int_9 - 1; num != 0; num >>= 1)
		{
			method_3((num & code) != 0);
		}
	}

	private void method_5()
	{
		int num = 258;
		int num2 = memoryStream_0.ReadByte();
		if (num2 == -1)
		{
			num2 = 257;
		}
		method_4(256);
		int num3;
		while ((num3 = memoryStream_0.ReadByte()) != -1)
		{
			int num4 = method_6(num2, num3);
			if (num == 1 << int_9)
			{
				if (int_9 < 12)
				{
					int_9++;
				}
				else
				{
					num = 258;
					method_1();
					method_4(256);
					int_9 = 9;
				}
			}
			if (int_5[num4] != -1)
			{
				num2 = int_5[num4];
				continue;
			}
			int_5[num4] = num++;
			int_6[num4] = num2;
			byte_0[num4] = (byte)num3;
			method_4(num2);
			num2 = num3;
		}
		method_4(num2);
		method_4(257);
		method_2();
	}

	private int method_6(int prefixCode, int character)
	{
		int num = (character << int_9 - 8) ^ prefixCode;
		int num2 = ((num == 0) ? 1 : (5021 - num));
		while (int_5[num] != -1 && (int_6[num] != prefixCode || byte_0[num] != (byte)character))
		{
			num -= num2;
			if (num < 0)
			{
				num += 5021;
			}
		}
		return num;
	}
}
