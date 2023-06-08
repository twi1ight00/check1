using System.IO;

namespace xa604c4d210ae0581;

internal class xfc4c61079feab0be
{
	private readonly byte[] xbdff05f3dcc1e0bf;

	private readonly string xc61ff88f1f98652d;

	internal byte[] x19f734038b480671 => xbdff05f3dcc1e0bf;

	internal string x759aa16c2016a289 => xc61ff88f1f98652d;

	internal xfc4c61079feab0be(BinaryReader reader, int codePage)
	{
		int count = reader.ReadInt16();
		int x961016a387451f = reader.ReadInt16();
		xbdff05f3dcc1e0bf = reader.ReadBytes(count);
		xc61ff88f1f98652d = x93b05c1ad709a695.x943278277eb1810b(reader, x961016a387451f, codePage);
	}

	internal void x6210059f049f0d48(BinaryWriter xbdfb620b7167944b, int xc1690d3515e1ed6c)
	{
		xbdfb620b7167944b.Write((short)xbdff05f3dcc1e0bf.Length);
		xbdfb620b7167944b.Write((short)(xc61ff88f1f98652d.Length + 1));
		xbdfb620b7167944b.Write(xbdff05f3dcc1e0bf);
		x93b05c1ad709a695.xc5ce8fce9f54ef55(xbdfb620b7167944b, xc61ff88f1f98652d, xc1690d3515e1ed6c, xfa1f910fa3313cee: false);
	}
}
