using Aspose.Words.Drawing;
using x6c95d9cf46ff5f25;

namespace x2182451cabb5c30d;

internal class x8a1f117e84a01d40 : x77fb5b1d5c73757b
{
	private ShapeBase x317be79405176667;

	private string xc14c8280921f4967;

	private string xc539d78cbe7328ff;

	internal x8a1f117e84a01d40(xe5e546ef5f0503b2 context, ShapeBase shape)
		: base(context)
	{
		x317be79405176667 = shape;
	}

	internal override void xa4085ff83f9ddeeb()
	{
		if (base.x1a55de3a01c1c82d.x3146d638ec378671 == x25099a8bbbd55d1c.x1a78cae632d91b5e)
		{
			x317be79405176667.HRef = x0d4d45882065c63e.x60ea34a7657b9f8a(xc14c8280921f4967, xc539d78cbe7328ff);
		}
	}

	internal override void xbd6083b329527c4e(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (base.x1a55de3a01c1c82d.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.xc18e4453b16da367:
			xc14c8280921f4967 = x153c99a852375422.x9f1a6a3451a38d10();
			break;
		case x25099a8bbbd55d1c.xd3a0054627c793a0:
			xc539d78cbe7328ff = x153c99a852375422.x9f1a6a3451a38d10();
			break;
		}
	}

	internal override x77fb5b1d5c73757b x3e0bce851c12a688(xbf575e106f2f2373 x8d3f74e5f925679c)
	{
		switch (x8d3f74e5f925679c.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.xd3a0054627c793a0:
		case x25099a8bbbd55d1c.xc18e4453b16da367:
		case x25099a8bbbd55d1c.x028f7d3cc561e999:
			return this;
		default:
			return null;
		}
	}
}
