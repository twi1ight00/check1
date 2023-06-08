using System;
using System.IO;
using System.Text;

namespace ns270;

internal static class Class6706
{
	internal static Class6709 Read(Stream stream, int difatEntries, uint sectDifStart, int difatSectors)
	{
		MemoryStream memoryStream = new MemoryStream();
		byte[] array = new byte[512];
		stream.Position = 76L;
		int count = Math.Min(difatEntries, 109) * 4;
		stream.Read(array, 0, count);
		memoryStream.Write(array, 0, count);
		uint sect = sectDifStart;
		for (int i = 0; i < difatSectors; i++)
		{
			stream.Position = Class6720.smethod_0(sect, isNormalSector: true);
			stream.Read(array, 0, 512);
			memoryStream.Write(array, 0, 508);
			sect = (uint)(array[508] | (array[509] << 8) | (array[510] << 16) | (array[511] << 24));
		}
		return new Class6709(memoryStream);
	}

	internal static void Write(Stream stream, uint sectFatStart, int difatEntries, Class6712 header)
	{
		uint num = sectFatStart;
		BinaryWriter binaryWriter = new BinaryWriter(stream, Encoding.Unicode);
		long position = stream.Position;
		stream.Position = 76L;
		int num2 = Math.Min(difatEntries, 109);
		for (int i = 0; i < num2; i++)
		{
			binaryWriter.Write(num);
			num++;
		}
		Class6720.smethod_2(binaryWriter);
		stream.Position = position;
		int num3 = difatEntries - num2;
		if (num3 > 0)
		{
			header.uint_3 = Class6720.smethod_1(stream.Position, isNormalSector: true);
			header.int_7 = 0;
			while (num3 > 0)
			{
				int num4 = Math.Min(num3, 127);
				for (int j = 0; j < num4; j++)
				{
					binaryWriter.Write(num);
					num++;
				}
				Class6720.smethod_2(binaryWriter);
				num3 -= num4;
				header.int_7++;
				stream.Position -= 4L;
				if (num3 > 0)
				{
					uint value = Class6720.smethod_1(stream.Position, isNormalSector: true) + 1;
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
			header.uint_3 = 4294967294u;
			header.int_7 = 0;
		}
	}
}
