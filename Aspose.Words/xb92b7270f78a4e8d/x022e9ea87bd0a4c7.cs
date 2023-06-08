using System.Collections;
using System.IO;
using System.Reflection;
using System.Text;

namespace xb92b7270f78a4e8d;

[DefaultMember("Item")]
internal class x022e9ea87bd0a4c7
{
	private readonly ArrayList x82b70567a5f68f41 = new ArrayList();

	internal uint xe6d4b1b411ed94b5
	{
		get
		{
			return (uint)x82b70567a5f68f41[(int)xc0c4c459c6ccbd00];
		}
		set
		{
			x82b70567a5f68f41[(int)xc0c4c459c6ccbd00] = value;
		}
	}

	internal int xd44988f225497f3a => x82b70567a5f68f41.Count;

	internal x022e9ea87bd0a4c7()
	{
	}

	internal x022e9ea87bd0a4c7(Stream stream)
	{
		stream.Position = 0L;
		x06b0e25aa6ad68a9(stream, (int)stream.Length / 4);
	}

	internal void x06b0e25aa6ad68a9(Stream xcf18e5243f8d5fd3, int x8d54381b90e4e4be)
	{
		BinaryReader binaryReader = new BinaryReader(xcf18e5243f8d5fd3, Encoding.Unicode);
		for (int i = 0; i < x8d54381b90e4e4be; i++)
		{
			x82b70567a5f68f41.Add(binaryReader.ReadUInt32());
		}
	}

	internal MemoryStream x0fe354a7e0ea7cc1()
	{
		MemoryStream memoryStream = new MemoryStream();
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream, Encoding.Unicode);
		for (uint num = 0u; num < x82b70567a5f68f41.Count; num++)
		{
			binaryWriter.Write(this.get_xe6d4b1b411ed94b5(num));
		}
		return memoryStream;
	}

	internal void xd6b6ed77479ef68c(uint xbcea506a33cf9111)
	{
		x82b70567a5f68f41.Add(xbcea506a33cf9111);
	}
}
