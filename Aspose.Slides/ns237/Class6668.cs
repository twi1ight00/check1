using System;
using System.IO;

namespace ns237;

internal class Class6668
{
	private int int_0;

	private int int_1;

	private byte[] byte_0;

	private byte[] byte_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private Enum886 enum886_0;

	private Enum886 enum886_1;

	public Class6668(Enum886 predictor, int colors, int columns, int bpp)
	{
		smethod_2(colors, bpp);
		int_2 = colors;
		int_3 = columns;
		int_4 = bpp;
		enum886_0 = predictor;
	}

	public MemoryStream method_0(MemoryStream source)
	{
		MemoryStream memoryStream = new MemoryStream((int)((double)source.Length + Math.Round((double)source.Length / (double)(int_2 * int_3))));
		source.Position = 0L;
		memoryStream.Position = 0L;
		int_1 = (int)((double)int_2 * Math.Round((double)int_4 / 8.0));
		int_0 = int_1 * int_3;
		byte_0 = new byte[int_0];
		byte_1 = new byte[int_0];
		for (int i = 0; i < int_1; i++)
		{
			byte_1[i] = 0;
		}
		byte[] array = new byte[int_0];
		while (source.Position < source.Length)
		{
			for (int j = 0; j < int_0; j++)
			{
				int num = source.ReadByte();
				if (num == -1)
				{
					break;
				}
				byte_0[j] = (byte)num;
			}
			enum886_1 = ((enum886_0 == Enum886.const_7) ? method_1() : enum886_0);
			for (int k = 0; k < int_0; k++)
			{
				array[k] = method_2(enum886_1, byte_0[k], k);
			}
			for (int l = 0; l < int_0; l++)
			{
				byte_1[l] = byte_0[l];
			}
			memoryStream.WriteByte(smethod_0(enum886_1));
			memoryStream.Write(array, 0, int_0);
		}
		return memoryStream;
	}

	private static byte smethod_0(Enum886 predictor)
	{
		return predictor switch
		{
			Enum886.const_2 => 0, 
			Enum886.const_3 => 1, 
			Enum886.const_4 => 2, 
			Enum886.const_5 => 3, 
			Enum886.const_6 => 4, 
			_ => throw new ArgumentException("Unsupported predictor type"), 
		};
	}

	private Enum886 method_1()
	{
		Enum886 result = Enum886.const_0;
		double num = double.PositiveInfinity;
		byte[] array = new byte[int_0];
		for (Enum886 @enum = Enum886.const_2; @enum != Enum886.const_7; @enum++)
		{
			for (int i = 0; i < int_0; i++)
			{
				array[i] = byte_0[i];
			}
			for (int j = 0; j < int_0; j++)
			{
				array[j] = method_2(@enum, array[j], j);
			}
			double num2 = 0.0;
			for (int k = 0; k < int_0; k++)
			{
				num2 += (double)(int)array[k];
			}
			num2 /= (double)int_0;
			if (num2 < num)
			{
				result = @enum;
				num = num2;
			}
		}
		return result;
	}

	private byte method_2(Enum886 curLinePredictor, int curByte, int byteOffset)
	{
		return curLinePredictor switch
		{
			Enum886.const_2 => (byte)curByte, 
			Enum886.const_3 => method_3(curByte, byteOffset), 
			Enum886.const_4 => method_4(curByte, byteOffset), 
			Enum886.const_5 => method_5(curByte, byteOffset), 
			Enum886.const_6 => method_6(curByte, byteOffset), 
			Enum886.const_0 => method_5(curByte, byteOffset), 
			_ => throw new InvalidOperationException("Please report exception."), 
		};
	}

	private byte method_3(int curByte, int byteOffset)
	{
		int num = ((byteOffset - int_1 >= 0) ? byte_0[byteOffset - int_1] : 0);
		return (byte)((curByte - num) % 256);
	}

	private byte method_4(int curByte, int byteOffset)
	{
		int num = byte_1[byteOffset];
		return (byte)((curByte - num) % 256);
	}

	private byte method_5(int curByte, int byteOffset)
	{
		int num = ((byteOffset - int_1 >= 0) ? byte_0[byteOffset - int_1] : 0);
		num = (num + byte_1[byteOffset]) / 2;
		return (byte)(Math.Floor((double)(curByte - num)) % 256.0);
	}

	private byte method_6(int curByte, int byteOffset)
	{
		int a = ((byteOffset - int_1 >= 0) ? byte_0[byteOffset - int_1] : 0);
		int c = ((byteOffset - int_1 >= 0) ? byte_1[byteOffset - int_1] : 0);
		int b = byte_1[byteOffset];
		return (byte)((curByte - smethod_1(a, b, c)) % 256);
	}

	private static int smethod_1(int a, int b, int c)
	{
		int num = a + b - c;
		int num2 = Math.Abs(num - a);
		int num3 = Math.Abs(num - b);
		int num4 = Math.Abs(num - c);
		if (num2 <= num3 && num2 <= num4)
		{
			return a;
		}
		if (num3 <= num4)
		{
			return b;
		}
		return c;
	}

	private static void smethod_2(int colors, int bpp)
	{
		if (colors <= 4 && colors >= 1)
		{
			switch (bpp)
			{
			case 1:
			case 2:
			case 4:
			case 8:
				return;
			}
			throw new ArgumentException("Invalid bpp.");
		}
		throw new ArgumentException("Invalid color.");
	}
}
