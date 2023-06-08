using System;
using x452f379ec5921195;
using xda075892eccab2ad;
using xf9a9481c3f63a419;

namespace x1495530f35d79681;

internal class x8834ab836c23d666
{
	private static readonly char[] x23c5219c446d57cc = new char[2] { '*', '%' };

	private x8834ab836c23d666()
	{
	}

	internal static void x06b0e25aa6ad68a9(xdfce7f4f687956d7 xe134235b3526fa75, x227665e444fb500a xa347a4c92b7a2672, bool x5fbb1a9c98604ef5)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("frameset"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "framesetSplitbar":
				xf7ea8c66bf072520(xe134235b3526fa75, xa347a4c92b7a2672);
				break;
			case "frameLayout":
				xa347a4c92b7a2672.x5a5e07e9fa12451a = x72a0c846678ecaf9.xbb21b4da4a6e1630(x3bcd232d01c.xbbfc54380705e01e());
				break;
			case "sz":
				xd00cd1d291ec764c(xa347a4c92b7a2672, x3bcd232d01c.xbbfc54380705e01e());
				break;
			case "title":
				xa347a4c92b7a2672.x238bf167ccfdd282 = x3bcd232d01c.xbbfc54380705e01e();
				break;
			case "frame":
			{
				x227665e444fb500a x5319ac6190db58c = new x227665e444fb500a();
				xa347a4c92b7a2672.xf2453c298c5de6f5.xd6b6ed77479ef68c(x5319ac6190db58c);
				x93af5f67ab423de6(xe134235b3526fa75, x5319ac6190db58c, x5fbb1a9c98604ef5);
				break;
			}
			case "frameset":
			{
				x227665e444fb500a x227665e444fb500a = new x227665e444fb500a();
				xa347a4c92b7a2672.xf2453c298c5de6f5.xd6b6ed77479ef68c(x227665e444fb500a);
				x06b0e25aa6ad68a9(xe134235b3526fa75, x227665e444fb500a, x5fbb1a9c98604ef5);
				break;
			}
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			}
		}
	}

	private static void xf7ea8c66bf072520(xdfce7f4f687956d7 xe134235b3526fa75, x227665e444fb500a x5319ac6190db58c3)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("framesetSplitbar"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "flatBorders":
			case "noBorder":
				if (x3bcd232d01c.xe04906126da94dd1())
				{
					x5319ac6190db58c3.x3650f9b73dc5111b = x72a0c846678ecaf9.x80665af7f89d2124(x3bcd232d01c.xa66385d80d4d296f);
				}
				break;
			case "color":
				x5319ac6190db58c3.xab068b018026a18d = xc1b08afa36bf580c.x5e71f16a78faf353(x3bcd232d01c.xbbfc54380705e01e());
				break;
			case "w":
				x5319ac6190db58c3.x1da3d4a0edfe0291 = x3bcd232d01c.xb8ac33c25776194c();
				break;
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			}
		}
	}

	private static void x93af5f67ab423de6(xdfce7f4f687956d7 xe134235b3526fa75, x227665e444fb500a x5319ac6190db58c3, bool x5fbb1a9c98604ef5)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("frame"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "title":
				x5319ac6190db58c3.x238bf167ccfdd282 = x3bcd232d01c.xbbfc54380705e01e();
				break;
			case "name":
				x5319ac6190db58c3.x759aa16c2016a289 = x3bcd232d01c.xbbfc54380705e01e();
				break;
			case "sourceFileName":
				x5319ac6190db58c3.xa39af5a82860a9a3 = (x5fbb1a9c98604ef5 ? xe134235b3526fa75.x052a6c2e603b1662(x3bcd232d01c.xd68abcd61e368af9("id", null)) : x3bcd232d01c.xbbfc54380705e01e());
				break;
			case "scrollbar":
				xe05fd8a17461f7db(x5319ac6190db58c3, x3bcd232d01c.xbbfc54380705e01e());
				break;
			case "noResizeAllowed":
				x5319ac6190db58c3.x9e0b65219bafea05 = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "linkedToFile":
				x5319ac6190db58c3.x1891c445b78b044b = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "sz":
				xd00cd1d291ec764c(x5319ac6190db58c3, x3bcd232d01c.xbbfc54380705e01e());
				break;
			case "marH":
				x5319ac6190db58c3.x5982cde1fd0610eb = x3bcd232d01c.xb8ac33c25776194c();
				break;
			case "marV":
				x5319ac6190db58c3.x5e520cbf43b1907e = x3bcd232d01c.xb8ac33c25776194c();
				break;
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			case "longDesc":
				break;
			}
		}
	}

	private static void xe05fd8a17461f7db(x227665e444fb500a x5319ac6190db58c3, string xbcea506a33cf9111)
	{
		switch (xbcea506a33cf9111)
		{
		case "on":
			x5319ac6190db58c3.x7c464f3c4155e7bb = x11d526cb3a620392.xbdc78d778d82071f;
			break;
		case "off":
			x5319ac6190db58c3.x7c464f3c4155e7bb = x11d526cb3a620392.xa0950aeff247b5e2;
			break;
		case "auto":
			x5319ac6190db58c3.x7c464f3c4155e7bb = x11d526cb3a620392.x2bca50d746ec73b2;
			break;
		default:
			throw new InvalidOperationException($"Invalid scroll type value {xbcea506a33cf9111}.");
		}
	}

	private static void xd00cd1d291ec764c(x227665e444fb500a x5319ac6190db58c3, string xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111.EndsWith("%"))
		{
			x5319ac6190db58c3.x92c54fd3d3742544 = xd656a4828bafb8a2.x2f7951fa0946af7e;
		}
		else if (xbcea506a33cf9111.EndsWith("*"))
		{
			x5319ac6190db58c3.x92c54fd3d3742544 = xd656a4828bafb8a2.x7d5889b1d338a9a9;
		}
		else
		{
			x5319ac6190db58c3.x92c54fd3d3742544 = xd656a4828bafb8a2.xc0e774c5d19a55c8;
		}
		xbcea506a33cf9111 = xbcea506a33cf9111.Trim(x23c5219c446d57cc);
		x5319ac6190db58c3.xb305c2eaafa86574 = xca004f56614e2431.x912616ee70b2d94d(xbcea506a33cf9111);
	}
}
