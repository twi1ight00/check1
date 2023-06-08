using System.Collections;
using System.Drawing;
using x4adf554d20d941a6;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace x59d6a4fc5007b7a4;

internal class xbe34d29d368fc922 : xb850ecb8335a2e09
{
	private const float x64a05dca04bc46f1 = 0.92f;

	private x26d9ecb4bdf0456d xed7ab6c2712e17d9 = new x26d9ecb4bdf0456d(255, 255, 0, 0);

	private x26d9ecb4bdf0456d xfd2ce88fa11a1590;

	private x26d9ecb4bdf0456d x673d591644543f05;

	internal override RectangleF x0e1bf8242ad10272
	{
		get
		{
			x4574ea26106f0edb.xc96d70553223ee04(xe66ac07cc471e42e.x51d60f077c5fc6e0);
			return new RectangleF(0f, 0f, xdc1bf80853046136, xb0f146032f47c24e);
		}
	}

	internal x26d9ecb4bdf0456d xf83c69bb98e96a69 => x673d591644543f05;

	internal x26d9ecb4bdf0456d x7dd793a62d047456
	{
		get
		{
			return xfd2ce88fa11a1590;
		}
		set
		{
			xfd2ce88fa11a1590 = value;
			x01f74f175f4a1d3d x01f74f175f4a1d3d = new x01f74f175f4a1d3d(xfd2ce88fa11a1590);
			x01f74f175f4a1d3d.x7140fff2ddcc94a1 *= 2.0;
			if (x01f74f175f4a1d3d.x7140fff2ddcc94a1 > 0.9200000166893005)
			{
				x01f74f175f4a1d3d.x7140fff2ddcc94a1 = 0.9200000166893005;
			}
			x673d591644543f05 = x01f74f175f4a1d3d.x1659cb35054965d4();
		}
	}

	internal xbe34d29d368fc922(xe66ac07cc471e42e part)
		: base(part)
	{
		x7dd793a62d047456 = xed7ab6c2712e17d9;
	}

	internal override void x7012609bcdb39574(x3adba2572f6b9747 x672ff13faf031f3d)
	{
		x672ff13faf031f3d.xdfc9ad174ecab9eb(this);
		x398b3bd0acd94b61 x8b8a0a04b3aeaf3a = ((xe66ac07cc471e42e)x9fb0e9c0b1bdc4b3).x8b8a0a04b3aeaf3a;
		while (x8b8a0a04b3aeaf3a != null)
		{
			xb850ecb8335a2e09 xb850ecb8335a2e10 = ((x8b8a0a04b3aeaf3a.x954503abc583f675 == x954503abc583f675.x48cc0c3eaf9f5f05) ? ((xb850ecb8335a2e09)new xbf5b03855bcdbdae(x8b8a0a04b3aeaf3a)) : ((xb850ecb8335a2e09)new xa68c54b19fa2b58c(x8b8a0a04b3aeaf3a)));
			xb850ecb8335a2e10.x7012609bcdb39574(x672ff13faf031f3d);
			x8b8a0a04b3aeaf3a = xb850ecb8335a2e10.xf54a8003057d59ef;
		}
		x672ff13faf031f3d.x3bd3c50d2c5e3ad7(this);
	}

	internal ArrayList xe655e88796bdba2a()
	{
		ArrayList arrayList = new ArrayList();
		xfb0c927634a887df xfb0c927634a887df = (xfb0c927634a887df)((x12f4230247e4ca42)x9fb0e9c0b1bdc4b3.x332a8eedb847940d).x465c7a263669f01c;
		x56410a8dd70087c5 x56410a8dd70087c = xfb0c927634a887df.x9a05d8dab0f0619f;
		if (x56410a8dd70087c == null)
		{
			arrayList.Add(x4574ea26106f0edb.xc96d70553223ee04(new Rectangle(xfb0c927634a887df.x588d7683a6d1fbd5().X, xfb0c927634a887df.xc255c495fd9232ca.x588d7683a6d1fbd5().Y, xfb0c927634a887df.xdc1bf80853046136, xfb0c927634a887df.xc255c495fd9232ca.xb0f146032f47c24e)));
			return arrayList;
		}
		if (x56410a8dd70087c.x776fd7c2f7270172() != xfb0c927634a887df.x776fd7c2f7270172())
		{
			x56410a8dd70087c = xfb0c927634a887df.x776fd7c2f7270172().xb78c16d5f2d4f2f7.x37aedaff9d1efb6e().x0eafd527bd1e778e;
		}
		x56410a8dd70087c5 x70ff891026cb = xfb0c927634a887df.x70ff891026cb8704;
		for (xf6937c72cebe4ad1 xf6937c72cebe4ad = x56410a8dd70087c.x5a7799e1836857e3; xf6937c72cebe4ad != null; xf6937c72cebe4ad = xf6937c72cebe4ad.x4eca8015611fb7a9())
		{
			if (xf6937c72cebe4ad.x2be2727bb322530e.x5566e2d2acbd1fbe != 21586 && xf6937c72cebe4ad.x2be2727bb322530e.x5566e2d2acbd1fbe != 21595)
			{
				x56410a8dd70087c5 x56410a8dd70087c2 = ((xf6937c72cebe4ad == x56410a8dd70087c.xc255c495fd9232ca) ? x56410a8dd70087c : xf6937c72cebe4ad.x0eafd527bd1e778e);
				x56410a8dd70087c5 x56410a8dd70087c3 = ((xf6937c72cebe4ad == x70ff891026cb.xc255c495fd9232ca) ? x70ff891026cb : xf6937c72cebe4ad.x2be2727bb322530e);
				arrayList.Add(x4574ea26106f0edb.xc96d70553223ee04(new Rectangle(x56410a8dd70087c2.x588d7683a6d1fbd5().X, x56410a8dd70087c2.xc255c495fd9232ca.x588d7683a6d1fbd5().Y, x56410a8dd70087c3.x419ba17a5322627b - x56410a8dd70087c2.x8df91a2f90079e88, x56410a8dd70087c2.xc255c495fd9232ca.xb0f146032f47c24e)));
			}
			if (xf6937c72cebe4ad == x70ff891026cb.xc255c495fd9232ca)
			{
				break;
			}
		}
		return arrayList;
	}
}
