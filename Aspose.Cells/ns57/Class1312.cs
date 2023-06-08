using System;
using System.IO;
using System.Text;

namespace ns57;

internal class Class1312
{
	private Class1312()
	{
	}

	internal static Class1315 Read(Stream stream_0, int int_0, uint uint_0, int int_1)
	{
		MemoryStream memoryStream = new MemoryStream();
		byte[] array = new byte[512];
		stream_0.Position = 76L;
		int count = Math.Min(int_0, 109) * 4;
		stream_0.Read(array, 0, count);
		memoryStream.Write(array, 0, count);
		uint uint_ = uint_0;
		for (int i = 0; i < int_1; i++)
		{
			stream_0.Position = Class1327.smethod_0(uint_, bool_0: true);
			stream_0.Read(array, 0, 512);
			memoryStream.Write(array, 0, 508);
			uint_ = (uint)(array[508] | (array[508 + 1] << 8) | (array[508 + 2] << 16) | (array[508 + 3] << 24));
		}
		return new Class1315(memoryStream);
	}

	internal static void Write(Stream stream_0, uint uint_0, int int_0, Class1318 class1318_0)
	{
		uint num = uint_0;
		BinaryWriter binaryWriter = new BinaryWriter(stream_0, Encoding.Unicode);
		long position = stream_0.Position;
		stream_0.Position = 76L;
		int num2 = Math.Min(int_0, 109);
		for (int i = 0; i < num2; i++)
		{
			binaryWriter.Write(num);
			num++;
		}
		Class1327.smethod_2(binaryWriter);
		stream_0.Position = position;
		int num3 = int_0 - num2;
		if (num3 > 0)
		{
			class1318_0.uint_3 = Class1327.smethod_1(stream_0.Position, bool_0: true);
			class1318_0.int_3 = 0;
			while (num3 > 0)
			{
				int num4 = Math.Min(num3, 127);
				for (int j = 0; j < num4; j++)
				{
					binaryWriter.Write(num);
					num++;
				}
				Class1327.smethod_2(binaryWriter);
				num3 -= num4;
				class1318_0.int_3++;
				stream_0.Position -= 4L;
				if (num3 > 0)
				{
					uint value = Class1327.smethod_1(stream_0.Position, bool_0: true) + 1;
					binaryWriter.Write(value);
				}
				else
				{
					binaryWriter.Write(4294967294u);
				}
			}
		}
		else
		{
			class1318_0.uint_3 = 4294967294u;
			class1318_0.int_3 = 0;
		}
	}
}
