using System.IO;
using System.Text;

namespace ns57;

internal class Class1316 : Class1315
{
	private readonly Stream stream_0;

	private readonly Class1318 class1318_0;

	internal Class1316(Stream stream_1, Class1318 class1318_1)
	{
		stream_0 = stream_1;
		class1318_0 = class1318_1;
	}

	internal void Read()
	{
		Class1315 @class = Class1312.Read(stream_0, class1318_0.int_1, class1318_0.uint_3, class1318_0.int_3);
		byte[] buffer = new byte[512];
		BinaryReader binaryReader = new BinaryReader(new MemoryStream(buffer), Encoding.Unicode);
		for (uint num = 0u; num < class1318_0.int_1; num++)
		{
			stream_0.Position = Class1327.smethod_0(@class[num], bool_0: true);
			stream_0.Read(buffer, 0, 512);
			binaryReader.BaseStream.Position = 0L;
			for (int i = 0; i < 128; i++)
			{
				Add(binaryReader.ReadUInt32());
			}
		}
	}

	internal void Write()
	{
		MemoryStream memoryStream = method_0();
		BinaryWriter binaryWriter = new BinaryWriter(stream_0, Encoding.Unicode);
		uint uint_ = Class1327.smethod_1(stream_0.Position, bool_0: true);
		int count = base.Count;
		int num = Class1321.smethod_0(count, 128);
		num = Class1321.smethod_0(count + num, 128);
		stream_0.Write(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
		for (int i = 0; i < num; i++)
		{
			binaryWriter.Write(4294967293u);
		}
		int num2 = Class1321.smethod_0(count + num, 128);
		if (num2 > 109)
		{
			int num3 = Class1321.smethod_0(num2 - 109, 127);
			for (int j = 0; j < num3; j++)
			{
				binaryWriter.Write(4294967293u);
			}
			for (int k = 0; k < num3; k++)
			{
				binaryWriter.Write(4294967292u);
			}
			num2 = Class1321.smethod_0(count + num + num3, 128);
		}
		class1318_0.int_1 = num2;
		Class1327.smethod_2(binaryWriter);
		Class1312.Write(stream_0, uint_, num2, class1318_0);
	}
}
