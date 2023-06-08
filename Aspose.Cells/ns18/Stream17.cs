using System;
using System.IO;

namespace ns18;

internal class Stream17 : Stream14
{
	private enum Enum206
	{
		const_0,
		const_1,
		const_2,
		const_3
	}

	internal Stream17(Stream stream_1)
		: base(stream_1)
	{
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		int num = 0;
		byte[] array = new byte[128];
		byte b = 0;
		byte b2 = 0;
		byte b3 = 0;
		Enum206 @enum = Enum206.const_0;
		for (int i = 0; i < count; i++)
		{
			num = offset + i;
			if (@enum != 0)
			{
				b2 = buffer[num];
				b3 = buffer[num - 1];
			}
			switch (@enum)
			{
			case Enum206.const_0:
				@enum = Enum206.const_1;
				break;
			case Enum206.const_1:
				if (b2 == b3)
				{
					@enum = Enum206.const_3;
					b = 2;
				}
				else
				{
					@enum = Enum206.const_2;
					array[0] = b3;
					b = 1;
				}
				break;
			case Enum206.const_2:
				if (b2 == b3)
				{
					method_0(array, b);
					@enum = Enum206.const_3;
					b = 2;
					break;
				}
				array[b] = b3;
				if ((b = (byte)(b + 1)) == 128)
				{
					method_0(array, b);
					@enum = Enum206.const_1;
				}
				break;
			case Enum206.const_3:
				if (b2 != b3)
				{
					method_1(b3, b);
					@enum = Enum206.const_1;
				}
				else if ((b = (byte)(b + 1)) == 128)
				{
					method_1(b2, b);
					@enum = Enum206.const_1;
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
		case Enum206.const_2:
			array[b] = b2;
			method_0(array, b + 1);
			break;
		case Enum206.const_3:
			method_1(b2, b + 1);
			break;
		}
		stream_0.WriteByte(128);
	}

	private void method_0(byte[] byte_0, int int_0)
	{
		stream_0.WriteByte((byte)(int_0 - 1));
		stream_0.Write(byte_0, 0, int_0);
	}

	private void method_1(byte byte_0, int int_0)
	{
		stream_0.WriteByte((byte)(257 - int_0));
		stream_0.WriteByte(byte_0);
	}
}
