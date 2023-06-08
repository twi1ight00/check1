using System.IO;

namespace ns18;

internal class Stream16 : Stream14
{
	private MemoryStream memoryStream_0;

	private Struct90[] struct90_0;

	private int int_0;

	private byte byte_0;

	private int int_1;

	public Stream16(Stream stream_1)
		: base(stream_1)
	{
		stream_0 = stream_1;
		struct90_0 = new Struct90[5021];
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		memoryStream_0 = new MemoryStream(buffer, offset, count);
		method_0();
		method_1();
		method_5();
	}

	private void method_0()
	{
		int_0 = 0;
		byte_0 = 128;
		int_1 = 9;
	}

	private void method_1()
	{
		for (int i = 0; i < struct90_0.Length; i++)
		{
			struct90_0[i].method_0(-1);
		}
	}

	private void method_2()
	{
		if (byte_0 != 128)
		{
			stream_0.WriteByte((byte)int_0);
		}
	}

	private void method_3(bool bool_0)
	{
		if (bool_0)
		{
			int_0 |= byte_0;
		}
		byte_0 >>= 1;
		if (byte_0 == 0)
		{
			stream_0.WriteByte((byte)int_0);
			int_0 = 0;
			byte_0 = 128;
		}
	}

	private void method_4(int int_2)
	{
		for (int num = 1 << int_1 - 1; num != 0; num >>= 1)
		{
			method_3((num & int_2) != 0);
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
			if (num == 1 << int_1)
			{
				if (int_1 < 12)
				{
					int_1++;
				}
				else
				{
					num = 258;
					method_1();
					method_4(256);
					int_1 = 9;
				}
			}
			if (struct90_0[num4].Code != -1)
			{
				num2 = struct90_0[num4].Code;
				continue;
			}
			struct90_0[num4].method_0(num++);
			struct90_0[num4].method_2(num2);
			struct90_0[num4].method_4((byte)num3);
			method_4(num2);
			num2 = num3;
		}
		method_4(num2);
		method_4(257);
		method_2();
	}

	private int method_6(int int_2, int int_3)
	{
		int num = (int_3 << int_1 - 8) ^ int_2;
		int num2 = ((num == 0) ? 1 : (5021 - num));
		while (true)
		{
			Struct90 @struct = struct90_0[num];
			if (@struct.Code == -1 || (@struct.method_1() == int_2 && @struct.method_3() == (byte)int_3))
			{
				break;
			}
			num -= num2;
			if (num < 0)
			{
				num += 5021;
			}
		}
		return num;
	}
}
