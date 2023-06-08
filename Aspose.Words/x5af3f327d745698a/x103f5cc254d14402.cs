using System.IO;

namespace x5af3f327d745698a;

internal class x103f5cc254d14402 : x59772113b8075329
{
	private const int x17ceccc51989cbaf = 8;

	private readonly int xd74c65b8d28b1740;

	private readonly int x8918dc7c534575e5;

	private readonly byte[] x2dd7e105643038ba;

	internal int xdc1bf80853046136 => xd74c65b8d28b1740;

	internal int xb0f146032f47c24e => x8918dc7c534575e5;

	internal byte[] xf7963feb1292e0d1 => x2dd7e105643038ba;

	internal x103f5cc254d14402(BinaryReader reader)
	{
		xd74c65b8d28b1740 = reader.ReadInt32();
		x8918dc7c534575e5 = reader.ReadInt32();
		int num = reader.ReadInt32();
		x2dd7e105643038ba = reader.ReadBytes(num - 8);
	}

	internal x103f5cc254d14402(byte[] metafileData)
	{
		x2dd7e105643038ba = metafileData;
	}

	internal override void x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write(1281);
		xbdfb620b7167944b.Write(5);
		x9ac0da7388ceac43.x41d7feb042ee43f7(xbdfb620b7167944b, "METAFILEPICT");
		xbdfb620b7167944b.Write(0);
		xbdfb620b7167944b.Write(0);
		xbdfb620b7167944b.Write(x2dd7e105643038ba.Length + 8);
		xbdfb620b7167944b.Write(0);
		xbdfb620b7167944b.Write(0);
		xbdfb620b7167944b.Write(x2dd7e105643038ba);
	}
}
