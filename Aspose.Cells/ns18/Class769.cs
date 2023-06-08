using System;
using System.IO;
using ns2;

namespace ns18;

internal class Class769 : Class767
{
	private byte[] byte_1;

	private Stream stream_1;

	private int int_1;

	public Class769(byte[] byte_2, Stream stream_2)
	{
		byte_1 = byte_2;
		stream_1 = stream_2;
	}

	public override void vmethod_0(Stream stream_2)
	{
		byte_0[0] = 137;
		byte_0[1] = 80;
		byte_0[2] = 78;
		byte_0[3] = 71;
		byte_0[4] = 13;
		byte_0[5] = 10;
		byte_0[6] = 26;
		byte_0[7] = 10;
		stream_1.Write(byte_0, 0, byte_0.Length);
		base.vmethod_0(stream_2);
		switch (int_1)
		{
		case 0:
			method_4("gIFx");
			int_1++;
			method_4("gIFg");
			int_1++;
			method_5();
			int_1++;
			break;
		case 1:
			method_4("gIFg");
			int_1++;
			method_5();
			int_1++;
			break;
		case 2:
			method_5();
			int_1++;
			break;
		}
	}

	protected override bool vmethod_1()
	{
		if (int_1 > 2)
		{
			method_3();
			return true;
		}
		if (byte_0[4] == 73 && byte_0[5] == 72 && byte_0[6] == 68 && byte_0[7] == 82)
		{
			method_3();
			method_4("gIFx");
			int_1++;
		}
		else if (byte_0[4] == 98 && byte_0[5] == 75 && byte_0[6] == 71 && byte_0[7] == 68)
		{
			method_3();
			switch (int_1)
			{
			case 0:
				method_4("gIFx");
				int_1++;
				method_4("gIFg");
				int_1++;
				break;
			case 1:
				method_4("gIFg");
				int_1++;
				break;
			}
		}
		else if (byte_0[4] == 99 && byte_0[5] == 77 && byte_0[6] == 80 && byte_0[7] == 80)
		{
			switch (int_1)
			{
			case 0:
				method_4("gIFx");
				int_1++;
				method_4("gIFg");
				int_1++;
				break;
			case 1:
				method_4("gIFg");
				int_1++;
				break;
			}
			method_3();
		}
		else if (byte_0[4] == 73 && byte_0[5] == 68 && byte_0[6] == 65 && byte_0[7] == 84)
		{
			switch (int_1)
			{
			case 0:
				method_4("gIFx");
				int_1++;
				method_4("gIFg");
				int_1++;
				method_3();
				method_5();
				int_1++;
				break;
			case 1:
				method_4("gIFg");
				int_1++;
				method_3();
				method_5();
				int_1++;
				break;
			case 2:
				method_3();
				method_5();
				int_1++;
				break;
			}
		}
		else
		{
			method_3();
		}
		return true;
	}

	private void method_3()
	{
		stream_1.Write(byte_0, 0, byte_0.Length);
		int num = method_0() + 4;
		byte[] array = new byte[num];
		while (true)
		{
			if (num > 0)
			{
				int num2 = stream_0.Read(array, array.Length - num, num);
				if (num2 > 0)
				{
					num -= num2;
					continue;
				}
				break;
			}
			stream_1.Write(array, 0, array.Length);
			break;
		}
	}

	private void method_4(string string_0)
	{
		byte[] array;
		switch (string_0)
		{
		default:
			return;
		case "gIFg":
			array = new byte[16]
			{
				0, 0, 0, 4, 103, 73, 70, 103, 2, 0,
				0, 14, 209, 61, 225, 193
			};
			break;
		case "gIFx":
			array = new byte[26]
			{
				0, 0, 0, 14, 103, 73, 70, 120, 78, 69,
				84, 83, 67, 65, 80, 69, 50, 46, 48, 1,
				0, 0, 36, 78, 152, 80
			};
			break;
		}
		stream_1.Write(array, 0, array.Length);
	}

	private void method_5()
	{
		Class1735 @class = new Class1735();
		method_6(byte_1.Length + 11, stream_1);
		byte[] array = new byte[15]
		{
			109, 115, 79, 71, 77, 83, 79, 70, 70, 73,
			67, 69, 57, 46, 48
		};
		stream_1.Write(array, 0, array.Length);
		@class.Update(array);
		stream_1.Write(byte_1, 0, byte_1.Length);
		@class.Update(byte_1);
		method_6((int)@class.Value, stream_1);
	}

	private void method_6(int int_2, Stream stream_2)
	{
		byte[] bytes = BitConverter.GetBytes(int_2);
		for (int num = 3; num > -1; num--)
		{
			stream_2.WriteByte(bytes[num]);
		}
	}
}
