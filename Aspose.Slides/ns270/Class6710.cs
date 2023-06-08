using System.Diagnostics;
using System.IO;
using System.Text;
using ns218;

namespace ns270;

internal class Class6710 : Class6709
{
	private readonly Stream stream_0;

	private readonly Class6712 class6712_0;

	internal Class6710(Stream stream, Class6712 header)
	{
		stream_0 = stream;
		class6712_0 = header;
	}

	internal void Read()
	{
		Class6709 @class = Class6706.Read(stream_0, class6712_0.int_5, class6712_0.uint_3, class6712_0.int_7);
		byte[] buffer = new byte[512];
		BinaryReader binaryReader = new BinaryReader(new MemoryStream(buffer), Encoding.Unicode);
		for (uint num = 0u; num < class6712_0.int_5; num++)
		{
			stream_0.Position = Class6720.smethod_0(@class[num], isNormalSector: true);
			stream_0.Read(buffer, 0, 512);
			binaryReader.BaseStream.Position = 0L;
			for (int i = 0; i < 128; i++)
			{
				Add(binaryReader.ReadUInt32());
			}
		}
	}

	[Conditional("DEBUG")]
	internal void method_1()
	{
		using StreamWriter streamWriter = new StreamWriter("D:\\x.log");
		for (uint num = 0u; num < base.Count; num++)
		{
			streamWriter.WriteLine($"{num} {base[num]} 0x{base[num]:X8}");
		}
	}

	internal void Write()
	{
		MemoryStream memoryStream = method_0();
		BinaryWriter binaryWriter = new BinaryWriter(stream_0, Encoding.Unicode);
		uint sectFatStart = Class6720.smethod_1(stream_0.Position, isNormalSector: true);
		int count = base.Count;
		int num = Class5964.smethod_5(count, 128);
		num = Class5964.smethod_5(count + num, 128);
		stream_0.Write(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
		for (int i = 0; i < num; i++)
		{
			binaryWriter.Write(4294967293u);
		}
		int num2 = Class5964.smethod_5(count + num, 128);
		if (num2 > 109)
		{
			int num3 = Class5964.smethod_5(num2 - 109, 127);
			for (int j = 0; j < num3; j++)
			{
				binaryWriter.Write(4294967293u);
			}
			for (int k = 0; k < num3; k++)
			{
				binaryWriter.Write(4294967292u);
			}
			num2 = Class5964.smethod_5(count + num + num3, 128);
		}
		class6712_0.int_5 = num2;
		Class6720.smethod_2(binaryWriter);
		Class6706.Write(stream_0, sectFatStart, num2, class6712_0);
	}
}
