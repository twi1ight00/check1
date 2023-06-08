using System.IO;

namespace x650fee20d618512c;

internal class xa3bbbefaafbabdb0
{
	internal int x86926a67348adc78;

	internal int x38bc81c86b855f93;

	internal xa3bbbefaafbabdb0()
	{
	}

	internal xa3bbbefaafbabdb0(BinaryReader reader)
	{
		reader.ReadByte();
		reader.ReadByte();
		x86926a67348adc78 = reader.ReadUInt16();
		x38bc81c86b855f93 = reader.ReadUInt16();
		reader.ReadUInt16();
		reader.ReadInt32();
		reader.ReadInt32();
		reader.ReadInt32();
		reader.ReadInt32();
	}

	internal void x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write((byte)86);
		xbdfb620b7167944b.Write((byte)0);
		xbdfb620b7167944b.Write((ushort)x86926a67348adc78);
		xbdfb620b7167944b.Write((ushort)x38bc81c86b855f93);
		xbdfb620b7167944b.Write(ushort.MaxValue);
		xbdfb620b7167944b.Write(0);
		xbdfb620b7167944b.Write(0);
		xbdfb620b7167944b.Write(0);
		xbdfb620b7167944b.Write(0);
	}
}
