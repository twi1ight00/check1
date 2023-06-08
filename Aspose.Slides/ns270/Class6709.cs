using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ns270;

internal class Class6709
{
	private readonly List<uint> list_0 = new List<uint>();

	internal uint this[uint index]
	{
		get
		{
			return list_0[(int)index];
		}
		set
		{
			list_0[(int)index] = value;
		}
	}

	internal int Count => list_0.Count;

	internal Class6709()
	{
	}

	internal Class6709(Stream stream)
	{
		stream.Position = 0L;
		Read(stream, (int)stream.Length / 4);
	}

	internal void Read(Stream stream, int entries)
	{
		BinaryReader binaryReader = new BinaryReader(stream, Encoding.Unicode);
		for (int i = 0; i < entries; i++)
		{
			list_0.Add(binaryReader.ReadUInt32());
		}
	}

	internal MemoryStream method_0()
	{
		MemoryStream memoryStream = new MemoryStream();
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream, Encoding.Unicode);
		for (uint num = 0u; num < list_0.Count; num++)
		{
			binaryWriter.Write(this[num]);
		}
		return memoryStream;
	}

	internal void Add(uint value)
	{
		list_0.Add(value);
	}
}
