using System.Collections;
using System.IO;
using System.Text;

namespace ns57;

internal class Class1315
{
	private readonly ArrayList arrayList_0 = new ArrayList();

	internal uint this[uint uint_0]
	{
		get
		{
			return (uint)arrayList_0[(int)uint_0];
		}
		set
		{
			arrayList_0[(int)uint_0] = value;
		}
	}

	internal int Count => arrayList_0.Count;

	internal Class1315()
	{
	}

	internal Class1315(Stream stream_0)
	{
		stream_0.Position = 0L;
		Read(stream_0, (int)stream_0.Length / 4);
	}

	internal void Read(Stream stream_0, int int_0)
	{
		BinaryReader binaryReader = new BinaryReader(stream_0, Encoding.Unicode);
		for (int i = 0; i < int_0; i++)
		{
			arrayList_0.Add(binaryReader.ReadUInt32());
		}
	}

	internal MemoryStream method_0()
	{
		MemoryStream memoryStream = new MemoryStream();
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream, Encoding.Unicode);
		for (uint num = 0u; num < arrayList_0.Count; num++)
		{
			binaryWriter.Write(this[num]);
		}
		return memoryStream;
	}

	internal void Add(uint uint_0)
	{
		arrayList_0.Add(uint_0);
	}
}
