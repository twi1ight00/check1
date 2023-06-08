using x6b8130194ad714f7;
using x6c95d9cf46ff5f25;
using x8bb6b4f09b5230a5;
using xa769c310fbec8a5a;

namespace x95bd05bb616368d3;

internal class xf97638a04f95de0d : xaaf059f0543cf507, xef3538cc44802939
{
	private xcac04f3919526f00 xc63c1886c6cccc78;

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

	public xf97638a04f95de0d(xe9481907c579c280 serviceLocator)
		: base(serviceLocator)
	{
	}

	public x064e11d707aed84f xda09af88ab899a50(xc1dcd6189d01216e xe134235b3526fa75)
	{
		if (xe134235b3526fa75.xa66385d80d4d296f != "ln")
		{
			return null;
		}
		x4c28ef76f151d171(xe134235b3526fa75);
		x064e11d707aed84f x064e11d707aed84f = new x064e11d707aed84f();
		x4407ca4302a525f6(x064e11d707aed84f);
		x8323ef0f52b666f6(x064e11d707aed84f);
		return x064e11d707aed84f;
	}

	private void x8323ef0f52b666f6(x064e11d707aed84f x129acb641f789a63)
	{
		while (x7450cc1e48712286.x152cbadbfa8061b1("ln"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "gradFill":
			case "pattFill":
			case "noFill":
			case "solidFill":
				x129acb641f789a63.x6a81a30bcaf20a97 = xfea0ad465c7d1afc.xda09af88ab899a50(x7450cc1e48712286);
				break;
			case "prstDash":
				x129acb641f789a63.x35078e8db43b001f = x953d600361e7ce26();
				break;
			case "custDash":
				x129acb641f789a63.x35078e8db43b001f = x7ea9c0737e0c97a9();
				break;
			case "headEnd":
				x129acb641f789a63.xc9fdc51bd242ab7e = new xbc57111897b18f47();
				xa5812c5169224908(x129acb641f789a63.xc9fdc51bd242ab7e);
				break;
			case "tailEnd":
				x129acb641f789a63.xa8e5d0ec145121c8 = new xf589374d0be88b7e();
				xa5812c5169224908(x129acb641f789a63.xa8e5d0ec145121c8);
				break;
			case "bevel":
			case "extLst":
			case "miter":
			case "round":
				x10576afa17ca4f1f();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
	}

	private void xa5812c5169224908(x48f737a219279f8c x4bf563902d3c8700)
	{
		x4bf563902d3c8700.x1be93eed8950d961 = x4af8e027030da707("len");
		x4bf563902d3c8700.x3146d638ec378671 = xd45457cf7e22f469();
		x4bf563902d3c8700.xdc1bf80853046136 = x4af8e027030da707("w");
	}

	private x97a37e9b9fdfef4f x4af8e027030da707(string x0fe8f603defa7708)
	{
		return x7450cc1e48712286.xd68abcd61e368af9(x0fe8f603defa7708, string.Empty) switch
		{
			"sm" => x97a37e9b9fdfef4f.x6207fc6b67b3b286, 
			"med" => x97a37e9b9fdfef4f.xc854e48424d4c882, 
			"lg" => x97a37e9b9fdfef4f.x30eebce3989fc2ba, 
			_ => x97a37e9b9fdfef4f.x6207fc6b67b3b286, 
		};
	}

	private x9dc5f51c709ef7a1 xd45457cf7e22f469()
	{
		return x7450cc1e48712286.xd68abcd61e368af9("type", string.Empty) switch
		{
			"none" => x9dc5f51c709ef7a1.x4d0b9d4447ba7566, 
			"triangle" => x9dc5f51c709ef7a1.x154a90a487ca2cb4, 
			"stealth" => x9dc5f51c709ef7a1.x2fd79cf9c61b7c9b, 
			"diamond" => x9dc5f51c709ef7a1.x02c85a8205c3f73b, 
			"oval" => x9dc5f51c709ef7a1.x3602848af32bd30f, 
			"arrow" => x9dc5f51c709ef7a1.x8022aa025229a1e5, 
			_ => x9dc5f51c709ef7a1.x4d0b9d4447ba7566, 
		};
	}

	private xa127f6c5c99ca9d4 x953d600361e7ce26()
	{
		x72234568f2993bba x72234568f2993bba = new x72234568f2993bba();
		switch (x7450cc1e48712286.xd68abcd61e368af9("val", string.Empty))
		{
		case "solid":
			x72234568f2993bba.x86d76ee96fa83686 = x8e20f24908b63efd.xb8751dec55f64252;
			break;
		case "dot":
			x72234568f2993bba.x86d76ee96fa83686 = x8e20f24908b63efd.x3cb6807e93737c2d;
			break;
		case "dash":
			x72234568f2993bba.x86d76ee96fa83686 = x8e20f24908b63efd.x35078e8db43b001f;
			break;
		case "lgDash":
			x72234568f2993bba.x86d76ee96fa83686 = x8e20f24908b63efd.xb724154bfaf220a7;
			break;
		case "dashDot":
			x72234568f2993bba.x86d76ee96fa83686 = x8e20f24908b63efd.x41084163454410db;
			break;
		case "lgDashDot":
			x72234568f2993bba.x86d76ee96fa83686 = x8e20f24908b63efd.xf24b332dc105a24e;
			break;
		case "lgDashDotDot":
			x72234568f2993bba.x86d76ee96fa83686 = x8e20f24908b63efd.xa6ae62095f92d6dc;
			break;
		case "sysDash":
			x72234568f2993bba.x86d76ee96fa83686 = x8e20f24908b63efd.x455a4ef0872765fc;
			break;
		case "sysDot":
			x72234568f2993bba.x86d76ee96fa83686 = x8e20f24908b63efd.x7df72ec7b05118a6;
			break;
		case "sysDashDot":
			x72234568f2993bba.x86d76ee96fa83686 = x8e20f24908b63efd.x6476cf042953dd24;
			break;
		case "sysDashDotDot":
			x72234568f2993bba.x86d76ee96fa83686 = x8e20f24908b63efd.x343f4269e84bd2af;
			break;
		}
		return x72234568f2993bba;
	}

	private xa127f6c5c99ca9d4 x7ea9c0737e0c97a9()
	{
		x3a76ad9432ad5577 x3a76ad9432ad = new x3a76ad9432ad5577();
		while (x7450cc1e48712286.x152cbadbfa8061b1("custDash"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f) != null && xa66385d80d4d296f == "ds")
			{
				x3a76ad9432ad.x4552ecfd28b9edc4.Add(x6d1d8256a7c48b1b());
			}
			else
			{
				xf4732ad4641eec1a();
			}
		}
		return x3a76ad9432ad;
	}

	private x4030b55fa9fd15b4 x6d1d8256a7c48b1b()
	{
		x4030b55fa9fd15b4 x4030b55fa9fd15b = new x4030b55fa9fd15b4();
		x4030b55fa9fd15b.xd99fe9821a70dc62 = new x55c6a66cc28d5b86(x7450cc1e48712286.x075a63114fe24ce9("d", 0.0));
		x4030b55fa9fd15b.xf8bdeedf86eea03b = new x55c6a66cc28d5b86(x7450cc1e48712286.x075a63114fe24ce9("sp", 0.0));
		return x4030b55fa9fd15b;
	}

	private void x4407ca4302a525f6(x064e11d707aed84f x129acb641f789a63)
	{
		x129acb641f789a63.xdc1bf80853046136 = xeb2114f080b881e4();
		x129acb641f789a63.x0f91c275a41355f8 = x67878080d098c332();
		x129acb641f789a63.xc178619d06ec481b = xea173123c656b5ba();
		x129acb641f789a63.x4d627450ee76e1ac = x980ea4639851264e();
	}

	private xcf2fe980acb3bf78 x980ea4639851264e()
	{
		return x7450cc1e48712286.xd68abcd61e368af9("algn", string.Empty) switch
		{
			"ctr" => xcf2fe980acb3bf78.xc1d71aceeda48828, 
			"in" => xcf2fe980acb3bf78.x22b9fd76d0291a7d, 
			_ => xcf2fe980acb3bf78.xc1d71aceeda48828, 
		};
	}

	private xb70e93871f38b24c xea173123c656b5ba()
	{
		return x7450cc1e48712286.xd68abcd61e368af9("cap", string.Empty) switch
		{
			"rnd" => xb70e93871f38b24c.x8168cd75fdee54e0, 
			"sq" => xb70e93871f38b24c.xa4399d7641f08688, 
			"flat" => xb70e93871f38b24c.xb036e9f5325eb99f, 
			_ => xb70e93871f38b24c.xb036e9f5325eb99f, 
		};
	}

	private x1d9eff2b003a1a1b x67878080d098c332()
	{
		return x7450cc1e48712286.xd68abcd61e368af9("cmpd", string.Empty) switch
		{
			"sng" => x1d9eff2b003a1a1b.x6c91ff700098ae78, 
			"dbl" => x1d9eff2b003a1a1b.x318d8e0c95dd806f, 
			"thickThin" => x1d9eff2b003a1a1b.xeed2af758d645623, 
			"thinThick" => x1d9eff2b003a1a1b.xef84abac71c755f7, 
			"tri" => x1d9eff2b003a1a1b.x1e50f9248368bd10, 
			_ => x1d9eff2b003a1a1b.x6c91ff700098ae78, 
		};
	}

	private double xeb2114f080b881e4()
	{
		return x7450cc1e48712286.x075a63114fe24ce9("w", 0.0);
	}
}
