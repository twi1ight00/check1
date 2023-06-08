using System.IO;
using Aspose;

namespace x1a62aaf14e3c5909;

internal abstract class x47d90533fe3ed43a : xef8fbb0f103c0bb1
{
	private int x949c20c08a6e7e50;

	internal override bool x74a7f36e76358cb5 => true;

	internal override int x9a1915e0a5a745b7 => 0;

	internal int x3719d1992877f6f9
	{
		get
		{
			return x949c20c08a6e7e50;
		}
		set
		{
			x949c20c08a6e7e50 = value;
		}
	}

	protected x47d90533fe3ed43a(int id, int dataLength)
		: base(id)
	{
		x949c20c08a6e7e50 = dataLength;
	}

	[JavaThrows(true)]
	internal abstract void x855150d0664edd8d(BinaryReader xe134235b3526fa75);

	[JavaThrows(true)]
	internal abstract void xc26afd5362f5c1ec(BinaryWriter xbdfb620b7167944b);
}
