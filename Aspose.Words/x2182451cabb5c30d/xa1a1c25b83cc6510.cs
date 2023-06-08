using Aspose.Words;
using x28925c9b27b37a46;
using xa604c4d210ae0581;
using xf9a9481c3f63a419;

namespace x2182451cabb5c30d;

internal class xa1a1c25b83cc6510 : x3b57052406b93b82
{
	private Comment x38385539a52570bf;

	internal xa1a1c25b83cc6510(xe5e546ef5f0503b2 context)
		: base(context)
	{
	}

	internal override void x41e7a76e7e854e6e(x03f56b37a0050a82 x153c99a852375422)
	{
		x25099a8bbbd55d1c x3146d638ec = base.x1a55de3a01c1c82d.x3146d638ec378671;
		if (x3146d638ec == x25099a8bbbd55d1c.x9d15246d8a1e92f8)
		{
			x38385539a52570bf = new Comment(base.x2c8c6741422a1298, base.xffb3238a8fd59aa7.x5f35c5e3977af81d());
			x38385539a52570bf.Initial = x28fcdc775a1d069c.xe5f47478966fa764;
			x38385539a52570bf.Author = x28fcdc775a1d069c.xe728a5f2c3443632;
			base.xe1410f585439c7d4.x508bedf5d0984ae8(x38385539a52570bf);
		}
		else
		{
			base.x41e7a76e7e854e6e(x153c99a852375422);
		}
	}

	internal override void xa4085ff83f9ddeeb()
	{
		x25099a8bbbd55d1c x3146d638ec = base.x1a55de3a01c1c82d.x3146d638ec378671;
		if (x3146d638ec == x25099a8bbbd55d1c.x9d15246d8a1e92f8)
		{
			base.xe1410f585439c7d4.x0d5864f2522edf7f();
			x38385539a52570bf = null;
		}
		else
		{
			base.xa4085ff83f9ddeeb();
		}
	}

	internal override void xbd6083b329527c4e(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (base.x1a55de3a01c1c82d.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.x9de5fd49caa7bf9a:
			if (x38385539a52570bf != null)
			{
				int num2 = xca004f56614e2431.x912616ee70b2d94d(x153c99a852375422.x9f1a6a3451a38d10());
				if (num2 != int.MinValue)
				{
					((x8ad0c0863d1cd403)x38385539a52570bf).x417a0a94031e7e8b = num2;
				}
			}
			break;
		case x25099a8bbbd55d1c.x8d05838233850511:
			if (x38385539a52570bf != null)
			{
				int num = xca004f56614e2431.x912616ee70b2d94d(x153c99a852375422.x9f1a6a3451a38d10());
				if (num != int.MinValue)
				{
					x38385539a52570bf.DateTime = xed28c1e5772a17ea.x9a175459d1b055a7(num);
				}
			}
			break;
		case x25099a8bbbd55d1c.x94da615a3bd18f78:
			x28fcdc775a1d069c.xbd5e5733680bbfc8("\\atnparent");
			break;
		case x25099a8bbbd55d1c.x228cec177f7f9c6f:
			x28fcdc775a1d069c.xbd5e5733680bbfc8("\\atnicn");
			break;
		default:
			base.xbd6083b329527c4e(x153c99a852375422);
			break;
		}
	}

	internal override x77fb5b1d5c73757b x3e0bce851c12a688(xbf575e106f2f2373 x8d3f74e5f925679c)
	{
		switch (x8d3f74e5f925679c.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.x9de5fd49caa7bf9a:
		case x25099a8bbbd55d1c.x8d05838233850511:
		case x25099a8bbbd55d1c.x94da615a3bd18f78:
		case x25099a8bbbd55d1c.x228cec177f7f9c6f:
			return this;
		default:
			return base.x3e0bce851c12a688(x8d3f74e5f925679c);
		}
	}
}
