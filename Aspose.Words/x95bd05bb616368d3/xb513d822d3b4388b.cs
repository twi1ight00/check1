using x6c95d9cf46ff5f25;
using x8bb6b4f09b5230a5;
using x996431aaaaf00543;

namespace x95bd05bb616368d3;

internal class xb513d822d3b4388b : xaaf059f0543cf507, x121b48fb33ec4002
{
	private xcac04f3919526f00 xc63c1886c6cccc78;

	private x838c5cd8f4489ee9 x21303a57e5610cbc;

	private xef3538cc44802939 x49ee3c26b2872b11;

	private xc69a7835ec81710c xb57ab17a50fa2a56;

	internal x838c5cd8f4489ee9 x7245114eac8b48a1
	{
		get
		{
			if (x21303a57e5610cbc == null)
			{
				x21303a57e5610cbc = new x8a5b455e53b31d53(base.xca687bd498227c89);
			}
			return x21303a57e5610cbc;
		}
		set
		{
			x21303a57e5610cbc = value;
		}
	}

	public xcac04f3919526f00 xfea0ad465c7d1afc
	{
		get
		{
			if (xc63c1886c6cccc78 == null)
			{
				xc63c1886c6cccc78 = new x53230d9c3453c662(base.xca687bd498227c89);
			}
			return xc63c1886c6cccc78;
		}
		set
		{
			xc63c1886c6cccc78 = value;
		}
	}

	public xc69a7835ec81710c xe3c198f6af54e264
	{
		get
		{
			if (xb57ab17a50fa2a56 == null)
			{
				xb57ab17a50fa2a56 = new x5ed8eb4a05aa6eaf(base.xca687bd498227c89);
			}
			return xb57ab17a50fa2a56;
		}
		set
		{
			xb57ab17a50fa2a56 = value;
		}
	}

	public xef3538cc44802939 xaeb5dcd7334ed5f6
	{
		get
		{
			if (x49ee3c26b2872b11 == null)
			{
				x49ee3c26b2872b11 = new xf97638a04f95de0d(base.xca687bd498227c89);
			}
			return x49ee3c26b2872b11;
		}
		set
		{
			x49ee3c26b2872b11 = value;
		}
	}

	public xb513d822d3b4388b(xe9481907c579c280 serviceLocator)
		: base(serviceLocator)
	{
	}

	public void x74ab9a3e14cc7605(xc1dcd6189d01216e xe134235b3526fa75, xd862c7732c558295 xda5bf54deb817e37)
	{
		x4c28ef76f151d171(xe134235b3526fa75);
		while (x7450cc1e48712286.x152cbadbfa8061b1("grpSpPr"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "xfrm":
				xda5bf54deb817e37.x625c1e7700dd35e9(xe3c198f6af54e264.xe24239b1bf03ef13(x7450cc1e48712286));
				break;
			case "blipFill":
			case "gradFill":
			case "grpFill":
			case "noFill":
			case "pattFill":
			case "solidFill":
				xda5bf54deb817e37.x6a81a30bcaf20a97 = xfea0ad465c7d1afc.xda09af88ab899a50(x7450cc1e48712286);
				break;
			case "effectDag":
			case "effectLst":
			case "extLst":
			case "scene3d":
				x10576afa17ca4f1f();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
	}

	public void x0b4a2dc14730c8a4(xc1dcd6189d01216e xe134235b3526fa75, x162d67570d6be3e3 x5770cdefd8931aa9)
	{
		x4c28ef76f151d171(xe134235b3526fa75);
		while (x7450cc1e48712286.x152cbadbfa8061b1("spPr"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "custGeom":
				x5770cdefd8931aa9.x5d1f5ab5850c22b5 = x7245114eac8b48a1.xda09af88ab899a50(x7450cc1e48712286);
				break;
			case "xfrm":
				x5770cdefd8931aa9.x625c1e7700dd35e9(xe3c198f6af54e264.x389fccbe88e3b864(x7450cc1e48712286));
				break;
			case "prstGeom":
				x5770cdefd8931aa9.x5d1f5ab5850c22b5 = x7245114eac8b48a1.xda09af88ab899a50(x7450cc1e48712286);
				break;
			case "blipFill":
			case "gradFill":
			case "grpFill":
			case "noFill":
			case "pattFill":
			case "solidFill":
				x5770cdefd8931aa9.x6a81a30bcaf20a97 = xfea0ad465c7d1afc.xda09af88ab899a50(x7450cc1e48712286);
				break;
			case "ln":
				x5770cdefd8931aa9.x93e68a44438355fd = xaeb5dcd7334ed5f6.xda09af88ab899a50(x7450cc1e48712286);
				break;
			case "effectDag":
			case "effectLst":
			case "extLst":
			case "scene3d":
			case "sp3d":
				x10576afa17ca4f1f();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
	}
}
