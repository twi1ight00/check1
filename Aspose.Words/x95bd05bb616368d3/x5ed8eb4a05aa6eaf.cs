using x6b8130194ad714f7;
using x6c95d9cf46ff5f25;
using x8784bdb393e53e65;
using x8bb6b4f09b5230a5;

namespace x95bd05bb616368d3;

internal class x5ed8eb4a05aa6eaf : xaaf059f0543cf507, xc69a7835ec81710c
{
	public x5ed8eb4a05aa6eaf(xe9481907c579c280 serviceLocator)
		: base(serviceLocator)
	{
	}

	public x734f6a4f5af93ce5 xe24239b1bf03ef13(xc1dcd6189d01216e xe134235b3526fa75)
	{
		if (xe134235b3526fa75.xa66385d80d4d296f != "xfrm")
		{
			return null;
		}
		x7450cc1e48712286 = xe134235b3526fa75;
		x734f6a4f5af93ce5 x734f6a4f5af93ce = new x734f6a4f5af93ce5();
		x910d60b42453abe8(x734f6a4f5af93ce);
		return x734f6a4f5af93ce;
	}

	public x78e18bdf9a108059 x389fccbe88e3b864(xc1dcd6189d01216e xe134235b3526fa75)
	{
		if (xe134235b3526fa75.xa66385d80d4d296f != "xfrm")
		{
			return null;
		}
		x7450cc1e48712286 = xe134235b3526fa75;
		x78e18bdf9a108059 x78e18bdf9a = new x78e18bdf9a108059();
		x732ae6d43ecdf2a1(x78e18bdf9a);
		return x78e18bdf9a;
	}

	private void x910d60b42453abe8(x734f6a4f5af93ce5 x678241938de24d81)
	{
		x4407ca4302a525f6(x678241938de24d81);
		while (x7450cc1e48712286.x152cbadbfa8061b1("xfrm"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "ext":
				xee45f939a34c2ba6(x678241938de24d81);
				break;
			case "off":
				xdb4be985035fc8e8(x678241938de24d81);
				break;
			case "chExt":
				x678241938de24d81.xa4b584449f2f99a5 = x7450cc1e48712286.x075a63114fe24ce9("cx", 0.0);
				x678241938de24d81.x33b0ce0cc41139fc = x7450cc1e48712286.x075a63114fe24ce9("cy", 0.0);
				break;
			case "chOff":
				x678241938de24d81.xe1376456f5ae028e = x7450cc1e48712286.x075a63114fe24ce9("x", 0.0);
				x678241938de24d81.x0e806ec110cd1956 = x7450cc1e48712286.x075a63114fe24ce9("y", 0.0);
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
	}

	private void x732ae6d43ecdf2a1(x78e18bdf9a108059 x678241938de24d81)
	{
		x4407ca4302a525f6(x678241938de24d81);
		while (x7450cc1e48712286.x152cbadbfa8061b1("xfrm"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "ext":
				xee45f939a34c2ba6(x678241938de24d81);
				break;
			case "off":
				xdb4be985035fc8e8(x678241938de24d81);
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
	}

	private void x4407ca4302a525f6(x78e18bdf9a108059 x678241938de24d81)
	{
		x678241938de24d81.x1a31c5dbe3231791 = x7450cc1e48712286.x9c1302ecb6c4f3a2("flipH", xc6e85c82d0d89508: false);
		x678241938de24d81.xaf2abb0b85eac4e2 = x7450cc1e48712286.x9c1302ecb6c4f3a2("flipV", xc6e85c82d0d89508: false);
		x678241938de24d81.xa00ce09851f40ee5 = xd4583a58cd9d2194.x2f498af763c53ba4(x7450cc1e48712286.x075a63114fe24ce9("rot", 0.0));
	}

	private void xdb4be985035fc8e8(x78e18bdf9a108059 x678241938de24d81)
	{
		x678241938de24d81.x8df91a2f90079e88 = x7450cc1e48712286.x075a63114fe24ce9("x", 0.0);
		x678241938de24d81.xc821290d7ecc08bf = x7450cc1e48712286.x075a63114fe24ce9("y", 0.0);
	}

	private void xee45f939a34c2ba6(x78e18bdf9a108059 x678241938de24d81)
	{
		x678241938de24d81.xdc1bf80853046136 = x7450cc1e48712286.x075a63114fe24ce9("cx", 0.0);
		x678241938de24d81.x1be93eed8950d961 = x7450cc1e48712286.x075a63114fe24ce9("cy", 0.0);
	}
}
