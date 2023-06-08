using System;
using System.IO;

namespace x1a62aaf14e3c5909;

internal class xb9d557c2e4fd83cd : x47d90533fe3ed43a
{
	private byte[] x8b3c90b227a823ee;

	private static Guid xca1b58f6626af168 = new Guid("{937c1a34-151d-4610-9ca6-a8cc9bdb5d83}");

	internal byte[] xded2c9c41054f4dd => x8b3c90b227a823ee;

	internal xb9d557c2e4fd83cd(int id, int dataLength)
		: base(id, dataLength)
	{
	}

	internal xb9d557c2e4fd83cd(int id, byte[] inkData)
		: base(id, inkData.Length + 20)
	{
		x8b3c90b227a823ee = inkData;
	}

	internal override void x855150d0664edd8d(BinaryReader xe134235b3526fa75)
	{
		new Guid(xe134235b3526fa75.ReadBytes(16));
		int count = xe134235b3526fa75.ReadInt32();
		x8b3c90b227a823ee = xe134235b3526fa75.ReadBytes(count);
	}

	internal override void xc26afd5362f5c1ec(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write(xca1b58f6626af168.ToByteArray());
		xbdfb620b7167944b.Write(x8b3c90b227a823ee.Length);
		xbdfb620b7167944b.Write(x8b3c90b227a823ee);
	}
}
