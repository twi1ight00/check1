using System.IO;

namespace xa604c4d210ae0581;

internal class x67d187312abd4ca2
{
	internal const int xa230444f4711f2cc = 8;

	internal string x759aa16c2016a289;

	internal int x6f148b4649a10af0;

	internal int x4c7cddb8e85a71d7;

	internal int x7a274c6c184ba6ea;

	internal x67d187312abd4ca2()
	{
	}

	internal x67d187312abd4ca2(string name, BinaryReader reader)
	{
		x759aa16c2016a289 = name;
		x6f148b4649a10af0 = reader.ReadInt16();
		x4c7cddb8e85a71d7 = reader.ReadByte();
		x7a274c6c184ba6ea = reader.ReadByte();
		reader.ReadInt32();
	}

	internal void x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write((short)x6f148b4649a10af0);
		xbdfb620b7167944b.Write((byte)x4c7cddb8e85a71d7);
		xbdfb620b7167944b.Write((byte)x7a274c6c184ba6ea);
		xbdfb620b7167944b.Write(0);
	}
}
