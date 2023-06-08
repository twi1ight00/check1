using System;
using System.IO;

namespace ns237;

internal class Stream6 : Stream1
{
	private enum Enum887
	{
		const_0,
		const_1,
		const_2,
		const_3
	}

	private const int int_0 = 128;

	private const int int_1 = 129;

	internal Stream6(Stream outputStream)
		: base(outputStream)
	{
	}

	public override void Write(byte[] srcBuffer, int srcOffset, int srcCount)
	{
		byte[] array = new byte[128];
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		Enum887 @enum = Enum887.const_0;
		for (int i = 0; i < srcCount; i++)
		{
			int num4 = srcOffset + i;
			if (@enum != 0)
			{
				num2 = srcBuffer[num4];
				num3 = srcBuffer[num4 - 1];
			}
			switch (@enum)
			{
			case Enum887.const_0:
				@enum = Enum887.const_1;
				num = 0;
				break;
			case Enum887.const_1:
				if (num2 == num3)
				{
					@enum = Enum887.const_3;
					num = 2;
				}
				else
				{
					@enum = Enum887.const_2;
					array[0] = (byte)num3;
					num = 1;
				}
				break;
			case Enum887.const_2:
				if (num2 == num3)
				{
					method_0(array, num);
					@enum = Enum887.const_3;
					num = 2;
					break;
				}
				array[num] = (byte)num3;
				num++;
				if (num == 128)
				{
					method_0(array, num);
					@enum = Enum887.const_1;
					num = 0;
				}
				break;
			case Enum887.const_3:
				if (num2 != num3)
				{
					method_1(num3, num);
					@enum = Enum887.const_1;
					num = 0;
					break;
				}
				num++;
				if (num == 128)
				{
					method_1(num2, num);
					@enum = Enum887.const_0;
				}
				break;
			default:
				throw new InvalidOperationException("Unknown RLE state.");
			}
		}
		switch (@enum)
		{
		default:
			throw new InvalidOperationException("Unknown RLE state.");
		case Enum887.const_1:
		case Enum887.const_2:
			array[num] = (byte)num2;
			num++;
			method_0(array, num);
			break;
		case Enum887.const_3:
			method_1(num2, num);
			break;
		}
		stream_0.WriteByte(129);
	}

	private void method_0(byte[] runBuffer, int runLength)
	{
		stream_0.WriteByte((byte)(runLength - 1));
		stream_0.Write(runBuffer, 0, runLength);
	}

	private void method_1(int byteToRepeat, int count)
	{
		stream_0.WriteByte((byte)(257 - count));
		stream_0.WriteByte((byte)byteToRepeat);
	}
}
