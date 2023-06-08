using System;
using System.IO;
using System.Text;
using ns218;
using ns224;

namespace ns238;

internal class Class6566
{
	private const int int_0 = 8;

	private byte byte_0;

	private int int_1;

	private BinaryWriter binaryWriter_0;

	public BinaryWriter BaseWriter => binaryWriter_0;

	public Class6566(Stream output)
	{
		binaryWriter_0 = new BinaryWriter(output);
	}

	public void WriteByte(int value)
	{
		binaryWriter_0.Write((byte)value);
	}

	public void method_0(byte[] buffer)
	{
		binaryWriter_0.Write(buffer);
	}

	public void method_1(int value)
	{
		binaryWriter_0.Write((short)value);
	}

	public void method_2(int value)
	{
		binaryWriter_0.Write(value);
	}

	public void method_3(double value)
	{
		method_2(Class5955.smethod_67(value));
	}

	public void method_4(bool bit, bool closeByte)
	{
		int_1++;
		if (bit)
		{
			byte_0 |= (byte)(1 << 8 - int_1);
		}
		method_8(closeByte);
	}

	public void method_5(int value, int length, bool closeByte)
	{
		method_4(value < 0, closeByte: false);
		if (length > 1)
		{
			int value2 = (int)((value < 0) ? ((4294967295L + value + 1L) & (4294967295L >> 32 - length + 1)) : Math.Abs(value));
			method_6(value2, length - 1, closeByte);
		}
	}

	public void method_6(int value, int length, bool closeByte)
	{
		int num = length / 8 + ((length % 8 > 0) ? 1 : 0);
		int length2 = 8 + length - num * 8;
		byte[] array = new byte[4];
		Class5964.smethod_1(value, array, 0);
		int num2 = num - 1;
		for (int num3 = num2; num3 >= 0; num3--)
		{
			if (num3 == num2)
			{
				WriteByte(array[num3], length2, closeByte: false);
			}
			else
			{
				WriteByte(array[num3], 8, closeByte: false);
			}
		}
		method_8(closeByte);
	}

	public void method_7(double value, int length, bool closeByte)
	{
		if (length < 17)
		{
			throw new ArgumentException("length cannot be less than 18");
		}
		bool flag;
		if (flag = value < 0.0)
		{
			value = 2147483647.0 + value + 1.0;
		}
		int num = (int)value;
		double num2 = value - (double)num;
		int value2 = (int)(num2 * 65536.0);
		if (flag)
		{
			num -= int.MaxValue;
		}
		int length2 = length - 16;
		method_5(num, length2, closeByte: false);
		method_6(value2, 16, closeByte: false);
		method_8(closeByte);
	}

	private void WriteByte(byte value, int length, bool closeByte)
	{
		while (length > 0)
		{
			byte_0 |= (byte)(value << 8 - length >> int_1);
			int num = int_1;
			int_1 += ((length < 8 - int_1) ? length : (8 - int_1));
			length -= int_1 - num;
			method_8(closeByte: false);
		}
		method_8(closeByte);
	}

	public void Flush()
	{
		if (int_1 != 0)
		{
			if (int_1 != 8)
			{
				method_6(0, 8 - int_1 - 1, closeByte: false);
			}
			binaryWriter_0.Write(byte_0);
			byte_0 = 0;
			int_1 = 0;
		}
	}

	private void method_8(bool closeByte)
	{
		if ((closeByte && int_1 != 0) || int_1 == 8)
		{
			Flush();
		}
	}

	public void method_9(string value)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(value);
		binaryWriter_0.Write(bytes);
		binaryWriter_0.Write((byte)0);
	}

	public void method_10(Class5998 color)
	{
		binaryWriter_0.Write((byte)color.R);
		binaryWriter_0.Write((byte)color.G);
		binaryWriter_0.Write((byte)color.B);
	}

	public void method_11(Class5998 color)
	{
		method_10(color);
		binaryWriter_0.Write((byte)color.A);
	}

	public void method_12(Class5998 color)
	{
		binaryWriter_0.Write((byte)color.A);
		method_10(color);
	}

	public void method_13(int xmin, int xmax, int ymin, int ymax)
	{
		int num = smethod_0(new int[4] { xmin, xmax, ymin, ymax });
		method_6(num, 5, closeByte: false);
		method_5(xmin, num, closeByte: false);
		method_5(xmax, num, closeByte: false);
		method_5(ymin, num, closeByte: false);
		method_5(ymax, num, closeByte: true);
	}

	public void method_14(Class6002 matrixTransform)
	{
		bool flag = matrixTransform.M11 != 1f || matrixTransform.M22 != 1f;
		bool flag2 = matrixTransform.M12 != 0f || matrixTransform.M21 != 0f;
		method_4(flag, closeByte: false);
		if (flag)
		{
			method_15(matrixTransform.M11, matrixTransform.M22);
		}
		method_4(flag2, closeByte: false);
		if (flag2)
		{
			method_15(matrixTransform.M12, matrixTransform.M21);
		}
		int num = Class5964.smethod_29(matrixTransform.M31);
		int num2 = Class5964.smethod_29(matrixTransform.M32);
		int num3 = smethod_0(new int[2] { num, num2 });
		method_6(num3, 5, closeByte: false);
		method_5(num, num3, closeByte: false);
		method_5(num2, num3, closeByte: true);
	}

	private void method_15(float element1, float element2)
	{
		element1 = ((element1 < 0f) ? (element1 - 1f) : element1);
		element2 = ((element2 < 0f) ? (element2 - 1f) : element2);
		int num = (int)element1;
		int num2 = (int)element2;
		int num3 = smethod_0(new int[2] { num, num2 }) + 16;
		method_6(num3, 5, closeByte: false);
		method_7(element1, num3, closeByte: false);
		method_7(element2, num3, closeByte: false);
	}

	public void method_16(Enum878 tagType, int tagLength)
	{
		int num = 0;
		num = 0 | ((int)tagType << 6);
		num |= 0x3F;
		method_1((short)num);
		method_2(tagLength);
	}

	public static int smethod_0(int[] values)
	{
		uint[] array = new uint[values.Length];
		for (int i = 0; i < values.Length; i++)
		{
			array[i] = (uint)Math.Abs(values[i]);
		}
		return smethod_1(array) + 1;
	}

	public static int smethod_1(uint[] values)
	{
		uint num = values[0];
		for (int i = 0; i < values.Length; i++)
		{
			num = Math.Max(num, values[i]);
		}
		return ((num != 0) ? ((int)Math.Log(num, 2.0)) : 0) + 1;
	}
}
