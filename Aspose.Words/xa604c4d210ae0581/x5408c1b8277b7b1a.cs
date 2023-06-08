using System;
using System.IO;

namespace xa604c4d210ae0581;

internal class x5408c1b8277b7b1a
{
	private readonly bool x1c6e30058e1b8104;

	private readonly bool xf98bb0715c6be60f;

	private readonly bool x73c27b0584904030;

	private readonly x539fe7739418b501 x01fd0624f1a1b02e;

	private readonly int xa1c4a0b2d37e97f8;

	private readonly x6fd8a59c6babef68 x6a9ce0e1eb145a21;

	private string x177b08d7ac823446;

	private string xd52b25f7f77979ad;

	private string xdf6b6b5096b274b9;

	private string xf7bbe199f47f234d;

	private readonly xd067f6d172c224ab x82b70567a5f68f41 = new xd067f6d172c224ab();

	internal bool xe3f6dc6f6937de10 => x1c6e30058e1b8104;

	internal bool xf6cbccf296a4c13a => xf98bb0715c6be60f;

	internal bool xe0ca45e95ad23a07 => x73c27b0584904030;

	internal string x191dcb88c409b8dd
	{
		get
		{
			return x177b08d7ac823446;
		}
		set
		{
			x177b08d7ac823446 = xab086ea62cde6f3a(value);
		}
	}

	internal string xd397bb1e465ce45e
	{
		get
		{
			return xd52b25f7f77979ad;
		}
		set
		{
			xd52b25f7f77979ad = xab086ea62cde6f3a(value);
		}
	}

	internal string x658c509a55e4e71a
	{
		get
		{
			return xdf6b6b5096b274b9;
		}
		set
		{
			xdf6b6b5096b274b9 = xab086ea62cde6f3a(value);
		}
	}

	internal string x238bf167ccfdd282
	{
		get
		{
			return xf7bbe199f47f234d;
		}
		set
		{
			xf7bbe199f47f234d = xab086ea62cde6f3a(value);
		}
	}

	internal x539fe7739418b501 xce2145cd91f3c96b => x01fd0624f1a1b02e;

	internal x6fd8a59c6babef68 x4af6b6f55aeb44a7 => x6a9ce0e1eb145a21;

	internal int x82d8ee523538b548 => xa1c4a0b2d37e97f8;

	internal xd067f6d172c224ab xe0d5f9fb50308841 => x82b70567a5f68f41;

	internal x5408c1b8277b7b1a(x8aeace2bf92692ab fib, BinaryReader reader, int codePage)
	{
		if (fib.x955a03f821588c52.x5408c1b8277b7b1a.x04c290dc4d04369c != 0)
		{
			long position = reader.BaseStream.Position;
			reader.BaseStream.Position = fib.x955a03f821588c52.x5408c1b8277b7b1a.xe53f0e68147463d1;
			x1c6e30058e1b8104 = reader.ReadInt16() != 0;
			xf98bb0715c6be60f = reader.ReadInt16() != 0;
			x73c27b0584904030 = reader.ReadInt16() != 0;
			reader.ReadInt16();
			x01fd0624f1a1b02e = (x539fe7739418b501)reader.ReadInt16();
			xa1c4a0b2d37e97f8 = reader.ReadInt16();
			x6a9ce0e1eb145a21 = (x6fd8a59c6babef68)reader.ReadInt16();
			int num = reader.ReadInt16();
			x177b08d7ac823446 = x93b05c1ad709a695.x943278277eb1810b(reader, codePage);
			xd52b25f7f77979ad = x93b05c1ad709a695.x943278277eb1810b(reader, codePage);
			xdf6b6b5096b274b9 = x93b05c1ad709a695.x943278277eb1810b(reader, codePage);
			xf7bbe199f47f234d = x93b05c1ad709a695.x943278277eb1810b(reader, codePage);
			for (int i = 0; i < num; i++)
			{
				x82b70567a5f68f41.xd6b6ed77479ef68c(new xfc4c61079feab0be(reader, codePage));
			}
			reader.BaseStream.Position = position;
		}
	}

	internal int x6210059f049f0d48(BinaryWriter xbdfb620b7167944b, int xc1690d3515e1ed6c)
	{
		long position = xbdfb620b7167944b.BaseStream.Position;
		xbdfb620b7167944b.Write((short)(x1c6e30058e1b8104 ? 1 : 0));
		xbdfb620b7167944b.Write((short)(xf98bb0715c6be60f ? 1 : 0));
		xbdfb620b7167944b.Write((short)(x73c27b0584904030 ? 1 : 0));
		xbdfb620b7167944b.Write((short)0);
		xbdfb620b7167944b.Write((short)x01fd0624f1a1b02e);
		xbdfb620b7167944b.Write((short)xa1c4a0b2d37e97f8);
		xbdfb620b7167944b.Write((short)x6a9ce0e1eb145a21);
		xbdfb620b7167944b.Write((short)xe0d5f9fb50308841.xd44988f225497f3a);
		x93b05c1ad709a695.xc5ce8fce9f54ef55(xbdfb620b7167944b, x177b08d7ac823446, xc1690d3515e1ed6c, xfa1f910fa3313cee: true);
		x93b05c1ad709a695.xc5ce8fce9f54ef55(xbdfb620b7167944b, xd52b25f7f77979ad, xc1690d3515e1ed6c, xfa1f910fa3313cee: true);
		x93b05c1ad709a695.xc5ce8fce9f54ef55(xbdfb620b7167944b, xdf6b6b5096b274b9, xc1690d3515e1ed6c, xfa1f910fa3313cee: true);
		x93b05c1ad709a695.xc5ce8fce9f54ef55(xbdfb620b7167944b, xf7bbe199f47f234d, xc1690d3515e1ed6c, xfa1f910fa3313cee: true);
		for (int i = 0; i < xe0d5f9fb50308841.xd44988f225497f3a; i++)
		{
			xe0d5f9fb50308841.get_xe6d4b1b411ed94b5(i).x6210059f049f0d48(xbdfb620b7167944b, xc1690d3515e1ed6c);
		}
		return (int)(xbdfb620b7167944b.BaseStream.Position - position);
	}

	private static string xab086ea62cde6f3a(string xb41faee6912a2313)
	{
		if (xb41faee6912a2313.Length > 255)
		{
			throw new InvalidOperationException("Text length should be less than 256.");
		}
		return xb41faee6912a2313;
	}
}
