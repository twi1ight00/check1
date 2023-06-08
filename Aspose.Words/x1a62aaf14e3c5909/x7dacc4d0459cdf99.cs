using System.IO;
using xa604c4d210ae0581;

namespace x1a62aaf14e3c5909;

internal class x7dacc4d0459cdf99 : x47d90533fe3ed43a
{
	private string x4574aea041dd835f;

	internal string xd2f68ee6f47e9dfb => x4574aea041dd835f;

	internal x7dacc4d0459cdf99(int id, int dataLength)
		: base(id, dataLength)
	{
	}

	internal x7dacc4d0459cdf99(int id, string value)
		: base(id, x93b05c1ad709a695.x10e05a5c8b6822db(value))
	{
		x4574aea041dd835f = value;
	}

	internal override void x855150d0664edd8d(BinaryReader xe134235b3526fa75)
	{
		x4574aea041dd835f = x93b05c1ad709a695.x79739b9c4ddc2495(xe134235b3526fa75, base.x3719d1992877f6f9);
	}

	internal override void xc26afd5362f5c1ec(BinaryWriter xbdfb620b7167944b)
	{
		x93b05c1ad709a695.x535736a60cc73a33(x4574aea041dd835f, xbdfb620b7167944b);
	}
}
