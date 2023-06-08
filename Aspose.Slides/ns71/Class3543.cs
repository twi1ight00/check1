using System.IO;
using ns45;

namespace ns71;

internal class Class3543
{
	internal Class3543()
	{
	}

	internal Class3543(Class1106 stream)
	{
		using MemoryStream input = new MemoryStream(stream.method_8());
		using BinaryReader reader = new BinaryReader(input);
		method_0(reader);
	}

	private void method_0(BinaryReader reader)
	{
		ushort num = reader.ReadUInt16();
		if (num != 25036)
		{
			throw new Exception10();
		}
		reader.ReadUInt16();
		if (reader.ReadByte() != 0)
		{
			throw new Exception10();
		}
		reader.ReadUInt16();
		reader.ReadBytes((int)(reader.BaseStream.Length - 7L));
	}

	public void method_1(Class1106 stream)
	{
		using MemoryStream memoryStream = new MemoryStream();
		using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		binaryWriter.Write((ushort)25036);
		binaryWriter.Write(ushort.MaxValue);
		binaryWriter.Write((byte)0);
		binaryWriter.Write((ushort)0);
		stream.method_1(memoryStream.ToArray());
	}
}
