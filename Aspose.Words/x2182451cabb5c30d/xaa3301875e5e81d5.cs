using x5794c252ba25e723;

namespace x2182451cabb5c30d;

internal class xaa3301875e5e81d5 : x77fb5b1d5c73757b
{
	private bool xa712861cc5de2e69;

	private int xa17f73d24166eefb;

	private int xf6c8c33296baa742;

	private int x79e09c7b913151c2;

	internal xaa3301875e5e81d5(xe5e546ef5f0503b2 context)
		: base(context)
	{
	}

	internal override void x41e7a76e7e854e6e(x03f56b37a0050a82 x153c99a852375422)
	{
		xa712861cc5de2e69 = true;
	}

	internal override void xa2d8e36cb99ac0f4(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x153c99a852375422.x1dafd189c5465293())
		{
		case "\\red":
			xa17f73d24166eefb = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\green":
			xf6c8c33296baa742 = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\blue":
			x79e09c7b913151c2 = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		}
		xa712861cc5de2e69 = false;
	}

	internal override void xbd6083b329527c4e(x03f56b37a0050a82 x153c99a852375422)
	{
		if (x153c99a852375422.x01175ba8d76995be)
		{
			x26d9ecb4bdf0456d x6c50a99faab7d = (xa712861cc5de2e69 ? x26d9ecb4bdf0456d.x45260ad4b94166f2 : new x26d9ecb4bdf0456d(xa17f73d24166eefb, xf6c8c33296baa742, x79e09c7b913151c2));
			x28fcdc775a1d069c.x88bf28725f671e38.xd6b6ed77479ef68c(x6c50a99faab7d);
			x4b756d4dbdd1f113();
		}
	}

	private void x4b756d4dbdd1f113()
	{
		xa712861cc5de2e69 = true;
		xa17f73d24166eefb = 0;
		xf6c8c33296baa742 = 0;
		x79e09c7b913151c2 = 0;
	}
}
