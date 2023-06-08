using x8bb6b4f09b5230a5;
using x996431aaaaf00543;

namespace x95bd05bb616368d3;

internal class xc3771fe1bb35895f : xaaf059f0543cf507
{
	private xb513d822d3b4388b x978001e980687119;

	private x4c5a30c65d58a9ce xcebda2d0a9c44940;

	private xccdea6f716a1a438 x8da16fea2f0fa635;

	private x4bce37a68a46eb2b x6b145c91b525cad4;

	public xccdea6f716a1a438 x300a99b1d3d422e9
	{
		get
		{
			if (x8da16fea2f0fa635 == null)
			{
				x8da16fea2f0fa635 = new x805646bc40fc37bc(base.xca687bd498227c89);
			}
			return x8da16fea2f0fa635;
		}
		set
		{
			x8da16fea2f0fa635 = value;
		}
	}

	public x4c5a30c65d58a9ce xfcb785f5597af437
	{
		get
		{
			if (xcebda2d0a9c44940 == null)
			{
				xcebda2d0a9c44940 = new xb90920c8e2771a6c(base.xca687bd498227c89);
			}
			return xcebda2d0a9c44940;
		}
		set
		{
			xcebda2d0a9c44940 = value;
		}
	}

	public xb513d822d3b4388b x8b9ff7d032a443a1
	{
		get
		{
			if (x978001e980687119 == null)
			{
				x978001e980687119 = new xb513d822d3b4388b(base.xca687bd498227c89);
			}
			return x978001e980687119;
		}
		set
		{
			x978001e980687119 = value;
		}
	}

	public x4bce37a68a46eb2b xd98a1954620007f2
	{
		get
		{
			if (x6b145c91b525cad4 == null)
			{
				x6b145c91b525cad4 = new xeac163f5930e8db6(base.xca687bd498227c89);
			}
			return x6b145c91b525cad4;
		}
		set
		{
			x6b145c91b525cad4 = value;
		}
	}

	public xc3771fe1bb35895f(xe9481907c579c280 serviceLocator)
		: base(serviceLocator)
	{
	}

	internal x4fe0a6d4f9a98c91 x46fa9da8bbd8388c(x69d6218f270f1b49 xe134235b3526fa75)
	{
		if (xe134235b3526fa75.xa66385d80d4d296f != "lockedCanvas")
		{
			return null;
		}
		x4c28ef76f151d171(xe134235b3526fa75);
		x4fe0a6d4f9a98c91 x4fe0a6d4f9a98c = new x4fe0a6d4f9a98c91();
		xb55cc47e6a2fe783(x4fe0a6d4f9a98c);
		return x4fe0a6d4f9a98c;
	}

	internal x8c5606ae2b3ea1d0 x9c778fe777c70e5a(x69d6218f270f1b49 xe134235b3526fa75)
	{
		if (xe134235b3526fa75.xa66385d80d4d296f != "grpSp")
		{
			return null;
		}
		x4c28ef76f151d171(xe134235b3526fa75);
		x8c5606ae2b3ea1d0 x8c5606ae2b3ea1d = new x8c5606ae2b3ea1d0();
		xb55cc47e6a2fe783(x8c5606ae2b3ea1d);
		return x8c5606ae2b3ea1d;
	}

	private void xb55cc47e6a2fe783(xd862c7732c558295 x24bdd89f46df5794)
	{
		string xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f;
		while (x7450cc1e48712286.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "grpSpPr":
				x8b9ff7d032a443a1.x74ab9a3e14cc7605(x7450cc1e48712286, x24bdd89f46df5794);
				break;
			case "sp":
				xfe4f7dca36c0076c(x24bdd89f46df5794);
				break;
			case "cxnSp":
				xfe4f7dca36c0076c(x24bdd89f46df5794);
				break;
			case "grpSp":
				xebd2c89e8589560e(x24bdd89f46df5794);
				break;
			case "pic":
				xdd1351c8666408d9(x24bdd89f46df5794);
				break;
			case "txSp":
				if (x24bdd89f46df5794 != null && x24bdd89f46df5794 is x8c5606ae2b3ea1d0)
				{
					((x8c5606ae2b3ea1d0)x24bdd89f46df5794).x97c4cdb7669669f2 = xd98a1954620007f2.xda09af88ab899a50(x7450cc1e48712286);
				}
				break;
			case "extLst":
			case "graphicFrame":
			case "nvGrpSpPr":
				x10576afa17ca4f1f();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
	}

	private void xdd1351c8666408d9(xd862c7732c558295 x24bdd89f46df5794)
	{
		xf4c807956df6c3b9 xda5bf54deb817e = xfcb785f5597af437.xda09af88ab899a50(x7450cc1e48712286);
		x24bdd89f46df5794.x07a948cd08942074(xda5bf54deb817e);
	}

	private void xebd2c89e8589560e(xd862c7732c558295 xda5bf54deb817e37)
	{
		x8c5606ae2b3ea1d0 x8c5606ae2b3ea1d = new x8c5606ae2b3ea1d0();
		xb55cc47e6a2fe783(x8c5606ae2b3ea1d);
		xda5bf54deb817e37.x07a948cd08942074(x8c5606ae2b3ea1d);
	}

	private void xfe4f7dca36c0076c(xd862c7732c558295 xda5bf54deb817e37)
	{
		x9345853531733647 xda5bf54deb817e38 = x300a99b1d3d422e9.xda09af88ab899a50(x7450cc1e48712286);
		xda5bf54deb817e37.x07a948cd08942074(xda5bf54deb817e38);
	}
}
