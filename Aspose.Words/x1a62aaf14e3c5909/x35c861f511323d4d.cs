using System.IO;

namespace x1a62aaf14e3c5909;

internal class x35c861f511323d4d : x47d90533fe3ed43a
{
	private byte[] x73f065a6b420cfe1;

	internal byte[] xc98e6be6ffd823ac => x73f065a6b420cfe1;

	internal x35c861f511323d4d(int id, int dataLength)
		: base(id, dataLength)
	{
	}

	internal x35c861f511323d4d(int id, byte[] data)
		: base(id, data.Length)
	{
		x73f065a6b420cfe1 = data;
	}

	internal override void x855150d0664edd8d(BinaryReader xe134235b3526fa75)
	{
		x73f065a6b420cfe1 = xe134235b3526fa75.ReadBytes(base.x3719d1992877f6f9);
	}

	internal override void xc26afd5362f5c1ec(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write(x73f065a6b420cfe1);
	}
}
