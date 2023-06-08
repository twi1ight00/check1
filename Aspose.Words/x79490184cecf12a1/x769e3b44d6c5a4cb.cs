using Aspose.Words;
using Aspose.Words.Math;
using x1495530f35d79681;
using x28925c9b27b37a46;
using x2cc366c8657e2b6a;
using x6c95d9cf46ff5f25;
using x909757d9fd2dd6ae;
using xda075892eccab2ad;
using xe5b37aee2c2a4d4e;
using xf9a9481c3f63a419;

namespace x79490184cecf12a1;

internal class x769e3b44d6c5a4cb
{
	private x769e3b44d6c5a4cb()
	{
	}

	internal static void x7c1d9b763e5e5f78(xdfce7f4f687956d7 xe134235b3526fa75)
	{
		x25cf79997767c318 x25cf79997767c = new x25cf79997767c318();
		xe134235b3526fa75.x490834a62c46f14d(new OfficeMath(xe134235b3526fa75.x2c8c6741422a1298, x25cf79997767c));
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		x3bcd232d01c.x99f8cdb2827fa686();
		while (x3bcd232d01c.x152cbadbfa8061b1("oMathPara"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "oMath":
				x61eaf7514df15047(xe134235b3526fa75);
				break;
			case "oMathParaPr":
				xcb1c11be74c2ca15(x3bcd232d01c, x25cf79997767c);
				break;
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			}
		}
		xe134235b3526fa75.xf5b0b9b6ff7ac462(NodeType.OfficeMath);
	}

	internal static void x61eaf7514df15047(xdfce7f4f687956d7 xe134235b3526fa75)
	{
		x8bf9c7b60a6a86d8(xe134235b3526fa75, new xb19ef215dab9ccd8(), "oMath");
	}

	private static void xcb1c11be74c2ca15(x3c85359e1389ad43 x97bf2eeabd4abc7b, x25cf79997767c318 xa37392d20be9c0cb)
	{
		while (x97bf2eeabd4abc7b.x152cbadbfa8061b1("oMathParaPr"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x97bf2eeabd4abc7b.xa66385d80d4d296f) != null && xa66385d80d4d296f == "jc")
			{
				xa37392d20be9c0cb.x3b35c3f6e109fb3e = xc62574be95c1c918.x644cb83fa42445a4(x97bf2eeabd4abc7b.xbbfc54380705e01e());
			}
			else
			{
				x97bf2eeabd4abc7b.IgnoreElement();
			}
		}
	}

	private static void x9a72407c84936f74(xdfce7f4f687956d7 xe134235b3526fa75)
	{
		x8bf9c7b60a6a86d8(xe134235b3526fa75, new xb4dde217cd172a7b(x3e68720d12325f49.x1745ba6c6d5efbc4), "e");
	}

	private static void x8bf9c7b60a6a86d8(xdfce7f4f687956d7 xe134235b3526fa75, x52642f91ccdeeb35 x76fcdbdac5bd908d, string x91ef5ae2997ab6c4)
	{
		x8bf9c7b60a6a86d8(xe134235b3526fa75, x76fcdbdac5bd908d, x91ef5ae2997ab6c4, x94baaa78473395e4: true);
	}

	private static void x8bf9c7b60a6a86d8(xdfce7f4f687956d7 xe134235b3526fa75, x52642f91ccdeeb35 x76fcdbdac5bd908d, string x91ef5ae2997ab6c4, bool x94baaa78473395e4)
	{
		xeedad81aaed42a76 xeedad81aaed42a = new xeedad81aaed42a76();
		if (x94baaa78473395e4)
		{
			xe134235b3526fa75.x490834a62c46f14d(new OfficeMath(xe134235b3526fa75.x2c8c6741422a1298, x76fcdbdac5bd908d, xeedad81aaed42a));
		}
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1(x91ef5ae2997ab6c4))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "acc":
				x077a303ee79665d9(xe134235b3526fa75, new x38058b386e92a0ef(), "acc");
				continue;
			case "bar":
				x077a303ee79665d9(xe134235b3526fa75, new xc7b86a71e45628c2(), "bar");
				continue;
			case "borderBox":
				x077a303ee79665d9(xe134235b3526fa75, new xfef3245bedba6f2c(), "borderBox");
				continue;
			case "box":
				x077a303ee79665d9(xe134235b3526fa75, new xf338a8521eba3175(), "box");
				continue;
			case "d":
				x077a303ee79665d9(xe134235b3526fa75, new x8f75f1da124d37a8(), "d");
				continue;
			case "eqArr":
				x077a303ee79665d9(xe134235b3526fa75, new xad19b25167c52eb8(), "eqArr");
				continue;
			case "f":
				xe5eed08aa1433a50(xe134235b3526fa75);
				continue;
			case "func":
				x770edc2a139c2756(xe134235b3526fa75);
				continue;
			case "groupChr":
				x077a303ee79665d9(xe134235b3526fa75, new xe0ab87872ac16292(), "groupChr");
				continue;
			case "limLow":
				x3f02947c75467cd4(xe134235b3526fa75, new x359908170766b2c1(), "limLow");
				continue;
			case "limUpp":
				x3f02947c75467cd4(xe134235b3526fa75, new x8ca605f254677e14(), "limUpp");
				continue;
			case "m":
				x8c1dae79b4f085c4(xe134235b3526fa75);
				continue;
			case "nary":
				xa3d386e260f16e67(xe134235b3526fa75);
				continue;
			case "oMath":
			case "oMathPara":
				x8bf9c7b60a6a86d8(xe134235b3526fa75, x76fcdbdac5bd908d, x91ef5ae2997ab6c4, x94baaa78473395e4: false);
				continue;
			case "phant":
				x077a303ee79665d9(xe134235b3526fa75, new x2a5175731d41f1b1(), "phant");
				continue;
			case "rad":
				x946a0a6c151c37f5(xe134235b3526fa75);
				continue;
			case "sPre":
				x29107775a6d75cf2(xe134235b3526fa75, new xd909b0707303c682(), "sPre");
				continue;
			case "sSub":
				x29107775a6d75cf2(xe134235b3526fa75, new xa57d244669b77e3f(), "sSub");
				continue;
			case "sSubSup":
				x29107775a6d75cf2(xe134235b3526fa75, new xfd62ce7f2b6769d5(), "sSubSup");
				continue;
			case "sSup":
				x29107775a6d75cf2(xe134235b3526fa75, new x0f6a978b568fff5b(), "sSup");
				continue;
			case "argPr":
				xc72a8acb971a82d6(xe134235b3526fa75, x76fcdbdac5bd908d);
				continue;
			case "ctrlPr":
				x4295e20c5600d7e2(xe134235b3526fa75, xeedad81aaed42a);
				continue;
			}
			if (xe134235b3526fa75.x325f1926b78ae5cd)
			{
				x5ab4843b5e9c9f8d.x152cbadbfa8061b1(xe134235b3526fa75);
			}
			else
			{
				x64e4e16f4da15749.x152cbadbfa8061b1(xe134235b3526fa75);
			}
		}
		if (x94baaa78473395e4)
		{
			xe134235b3526fa75.xf5b0b9b6ff7ac462(NodeType.OfficeMath);
		}
	}

	private static void x077a303ee79665d9(xdfce7f4f687956d7 xe134235b3526fa75, x52642f91ccdeeb35 xa59bff7708de3a18, string x91ef5ae2997ab6c4)
	{
		xeedad81aaed42a76 xeedad81aaed42a = new xeedad81aaed42a76();
		xe134235b3526fa75.x490834a62c46f14d(new OfficeMath(xe134235b3526fa75.x2c8c6741422a1298, xa59bff7708de3a18, xeedad81aaed42a));
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1(x91ef5ae2997ab6c4))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f) != null && xa66385d80d4d296f == "e")
			{
				x9a72407c84936f74(xe134235b3526fa75);
			}
			else
			{
				x24be5646b0c72b8d(xe134235b3526fa75, xa59bff7708de3a18, xeedad81aaed42a);
			}
		}
		xe134235b3526fa75.xf5b0b9b6ff7ac462(NodeType.OfficeMath);
	}

	private static void x24be5646b0c72b8d(xdfce7f4f687956d7 xe134235b3526fa75, x52642f91ccdeeb35 xa59bff7708de3a18, xeedad81aaed42a76 x4f8c20b21405e2cc)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		if (xa59bff7708de3a18.x3e68720d12325f49 == x3e68720d12325f49.x9b63794dfed849a8 && x3bcd232d01c.xa66385d80d4d296f == "accPr")
		{
			x2ad2394b6c3c0189(xe134235b3526fa75, (x38058b386e92a0ef)xa59bff7708de3a18, x4f8c20b21405e2cc);
		}
		else if (xa59bff7708de3a18.x3e68720d12325f49 == x3e68720d12325f49.xced856c17df679c5 && x3bcd232d01c.xa66385d80d4d296f == "barPr")
		{
			x80f369bfd15e877c(xe134235b3526fa75, (xc7b86a71e45628c2)xa59bff7708de3a18, x4f8c20b21405e2cc);
		}
		else if (xa59bff7708de3a18.x3e68720d12325f49 == x3e68720d12325f49.x78451b450fb7d099 && x3bcd232d01c.xa66385d80d4d296f == "borderBoxPr")
		{
			x4c439efca67566da(xe134235b3526fa75, (xfef3245bedba6f2c)xa59bff7708de3a18, x4f8c20b21405e2cc);
		}
		else if (xa59bff7708de3a18.x3e68720d12325f49 == x3e68720d12325f49.x2ae4473a93ca9b64 && x3bcd232d01c.xa66385d80d4d296f == "boxPr")
		{
			x037e4c97650bfd74(xe134235b3526fa75, (xf338a8521eba3175)xa59bff7708de3a18, x4f8c20b21405e2cc);
		}
		else if (xa59bff7708de3a18.x3e68720d12325f49 == x3e68720d12325f49.x0dbbcf3105452f20 && x3bcd232d01c.xa66385d80d4d296f == "dPr")
		{
			x082318eaebfce7cc(xe134235b3526fa75, (x8f75f1da124d37a8)xa59bff7708de3a18, x4f8c20b21405e2cc);
		}
		else if (xa59bff7708de3a18.x3e68720d12325f49 == x3e68720d12325f49.xd4e45a1fccac675d && x3bcd232d01c.xa66385d80d4d296f == "eqArrPr")
		{
			x9679836f266f419e(xe134235b3526fa75, (xad19b25167c52eb8)xa59bff7708de3a18, x4f8c20b21405e2cc);
		}
		else if (xa59bff7708de3a18.x3e68720d12325f49 == x3e68720d12325f49.x2709f18576762ece && x3bcd232d01c.xa66385d80d4d296f == "groupChrPr")
		{
			x9785eb4cdbfe9bb6(xe134235b3526fa75, (xe0ab87872ac16292)xa59bff7708de3a18, x4f8c20b21405e2cc);
		}
		else if (xa59bff7708de3a18.x3e68720d12325f49 == x3e68720d12325f49.x82ca8304b1b498f4 && x3bcd232d01c.xa66385d80d4d296f == "phantPr")
		{
			x4145dd1be0886eeb(xe134235b3526fa75, (x2a5175731d41f1b1)xa59bff7708de3a18, x4f8c20b21405e2cc);
		}
		else
		{
			x3bcd232d01c.IgnoreElement();
		}
	}

	private static void xe5eed08aa1433a50(xdfce7f4f687956d7 xe134235b3526fa75)
	{
		x77c73b53c376655e x77c73b53c376655e = new x77c73b53c376655e();
		xeedad81aaed42a76 xeedad81aaed42a = new xeedad81aaed42a76();
		xe134235b3526fa75.x490834a62c46f14d(new OfficeMath(xe134235b3526fa75.x2c8c6741422a1298, x77c73b53c376655e, xeedad81aaed42a));
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("f"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "fPr":
				xaae20adb212185a8(xe134235b3526fa75, x77c73b53c376655e, xeedad81aaed42a);
				break;
			case "den":
				x8bf9c7b60a6a86d8(xe134235b3526fa75, new xb4dde217cd172a7b(x3e68720d12325f49.x194cb0ccf5358fec), "den");
				break;
			case "num":
				x8bf9c7b60a6a86d8(xe134235b3526fa75, new xb4dde217cd172a7b(x3e68720d12325f49.x5ec114ef0df8072b), "num");
				break;
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			}
		}
		xe134235b3526fa75.xf5b0b9b6ff7ac462(NodeType.OfficeMath);
	}

	private static void xaae20adb212185a8(xdfce7f4f687956d7 xe134235b3526fa75, x77c73b53c376655e x0078185e1040c523, xeedad81aaed42a76 x4f8c20b21405e2cc)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("fPr"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "type":
				x0078185e1040c523.x4001c46e1a6e7522 = xc62574be95c1c918.xabd3359cac621e01(x3bcd232d01c.xbbfc54380705e01e());
				break;
			case "ctrlPr":
				x4295e20c5600d7e2(xe134235b3526fa75, x4f8c20b21405e2cc);
				break;
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			}
		}
	}

	private static void x770edc2a139c2756(xdfce7f4f687956d7 xe134235b3526fa75)
	{
		x11ccc6fd9c50b5e4 mathObject = new x11ccc6fd9c50b5e4();
		xeedad81aaed42a76 xeedad81aaed42a = new xeedad81aaed42a76();
		xe134235b3526fa75.x490834a62c46f14d(new OfficeMath(xe134235b3526fa75.x2c8c6741422a1298, mathObject, xeedad81aaed42a));
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("func"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "funcPr":
				xef3c721a02b38cbd(xe134235b3526fa75, xeedad81aaed42a, "funcPr");
				break;
			case "fName":
				x8bf9c7b60a6a86d8(xe134235b3526fa75, new xb4dde217cd172a7b(x3e68720d12325f49.x8c55fc884c93cb9f), "fName");
				break;
			case "e":
				x9a72407c84936f74(xe134235b3526fa75);
				break;
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			}
		}
		xe134235b3526fa75.xf5b0b9b6ff7ac462(NodeType.OfficeMath);
	}

	private static void x3f02947c75467cd4(xdfce7f4f687956d7 xe134235b3526fa75, x52642f91ccdeeb35 xa59bff7708de3a18, string x845ff59501549724)
	{
		xeedad81aaed42a76 xeedad81aaed42a = new xeedad81aaed42a76();
		xe134235b3526fa75.x490834a62c46f14d(new OfficeMath(xe134235b3526fa75.x2c8c6741422a1298, xa59bff7708de3a18, xeedad81aaed42a));
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1(x845ff59501549724))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "lim":
				x8bf9c7b60a6a86d8(xe134235b3526fa75, new xb4dde217cd172a7b(x3e68720d12325f49.x25d26846c330b189), "lim");
				break;
			case "e":
				x9a72407c84936f74(xe134235b3526fa75);
				break;
			case "limUppPr":
				xef3c721a02b38cbd(xe134235b3526fa75, xeedad81aaed42a, "limUppPr");
				break;
			case "limLowPr":
				xef3c721a02b38cbd(xe134235b3526fa75, xeedad81aaed42a, "limLowPr");
				break;
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			}
		}
		xe134235b3526fa75.xf5b0b9b6ff7ac462(NodeType.OfficeMath);
	}

	private static void x8c1dae79b4f085c4(xdfce7f4f687956d7 xe134235b3526fa75)
	{
		xa097a2be55e6fe20 xa097a2be55e6fe = new xa097a2be55e6fe20();
		xeedad81aaed42a76 xeedad81aaed42a = new xeedad81aaed42a76();
		xe134235b3526fa75.x490834a62c46f14d(new OfficeMath(xe134235b3526fa75.x2c8c6741422a1298, xa097a2be55e6fe, xeedad81aaed42a));
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("m"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "mr":
				xa8779daf4a86e10e(xe134235b3526fa75);
				break;
			case "mPr":
				xe303ed84d73d63d2(xe134235b3526fa75, xa097a2be55e6fe, xeedad81aaed42a);
				break;
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			}
		}
		xe134235b3526fa75.xf5b0b9b6ff7ac462(NodeType.OfficeMath);
	}

	private static void xa8779daf4a86e10e(xdfce7f4f687956d7 xe134235b3526fa75)
	{
		xe134235b3526fa75.x490834a62c46f14d(new OfficeMath(xe134235b3526fa75.x2c8c6741422a1298, new xb7914f4847d72942()));
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("mr"))
		{
			if (x3bcd232d01c.xa66385d80d4d296f == "e")
			{
				x9a72407c84936f74(xe134235b3526fa75);
			}
			else
			{
				x3bcd232d01c.IgnoreElement();
			}
		}
		xe134235b3526fa75.xf5b0b9b6ff7ac462(NodeType.OfficeMath);
	}

	private static void xe303ed84d73d63d2(xdfce7f4f687956d7 xe134235b3526fa75, xa097a2be55e6fe20 x6088325dec1baa2a, xeedad81aaed42a76 x4f8c20b21405e2cc)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("mPr"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "baseJc":
				x6088325dec1baa2a.x233310de5ce401a5 = x4d2c349b7da19e15(x3bcd232d01c);
				break;
			case "cGp":
				x6088325dec1baa2a.x042eb39cc7d00f5c = x3bcd232d01c.xb8ac33c25776194c();
				break;
			case "cGpRule":
				x6088325dec1baa2a.xad645df76d47a6b8 = x776302d216c4513b(x3bcd232d01c);
				break;
			case "cSp":
				x6088325dec1baa2a.x1f59e65bdad06006 = x3bcd232d01c.xb8ac33c25776194c();
				break;
			case "mcs":
				x44964ead7cdc8dbc(xe134235b3526fa75, x6088325dec1baa2a.xe9e7cd52b91094f9);
				break;
			case "plcHide":
				x6088325dec1baa2a.x1cf0124cf79a79b8 = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "rSp":
				x6088325dec1baa2a.x5c2893a9ae3a9fc2 = x3bcd232d01c.xb8ac33c25776194c();
				break;
			case "rSpRule":
				x6088325dec1baa2a.x8359894e750846dc = x776302d216c4513b(x3bcd232d01c);
				break;
			case "ctrlPr":
				x4295e20c5600d7e2(xe134235b3526fa75, x4f8c20b21405e2cc);
				break;
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			}
		}
	}

	private static void x44964ead7cdc8dbc(xdfce7f4f687956d7 xe134235b3526fa75, xdfc575fc9bd34ec5 x26c511b92db96554)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("mcs"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f) != null && xa66385d80d4d296f == "mc")
			{
				x3b18408160da5c25(xe134235b3526fa75, x26c511b92db96554);
			}
			else
			{
				x3bcd232d01c.IgnoreElement();
			}
		}
	}

	private static void x3b18408160da5c25(xdfce7f4f687956d7 xe134235b3526fa75, xdfc575fc9bd34ec5 x26c511b92db96554)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("mc"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f) != null && xa66385d80d4d296f == "mcPr")
			{
				x725318027327358f(xe134235b3526fa75, x26c511b92db96554);
			}
			else
			{
				x3bcd232d01c.IgnoreElement();
			}
		}
	}

	private static void x725318027327358f(xdfce7f4f687956d7 xe134235b3526fa75, xdfc575fc9bd34ec5 x26c511b92db96554)
	{
		int x10f4d88af727adbc = 1;
		x9d761ee3eb0e5b6d x9d761ee3eb0e5b6d = new x9d761ee3eb0e5b6d();
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("mcPr"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "count":
				x10f4d88af727adbc = xaf982a4910099df8(x3bcd232d01c);
				break;
			case "mcJc":
				x9d761ee3eb0e5b6d.xab67cb9464a3325b = x72a0c846678ecaf9.x15b3d0aaa5b4546f(x3bcd232d01c.xbbfc54380705e01e());
				break;
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			}
		}
		x26c511b92db96554.xd6b6ed77479ef68c(x9d761ee3eb0e5b6d, x10f4d88af727adbc);
	}

	private static void xa3d386e260f16e67(xdfce7f4f687956d7 xe134235b3526fa75)
	{
		x6dd1552d6eb89e4e x6dd1552d6eb89e4e = new x6dd1552d6eb89e4e();
		xeedad81aaed42a76 xeedad81aaed42a = new xeedad81aaed42a76();
		xe134235b3526fa75.x490834a62c46f14d(new OfficeMath(xe134235b3526fa75.x2c8c6741422a1298, x6dd1552d6eb89e4e, xeedad81aaed42a));
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("nary"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "e":
				x9a72407c84936f74(xe134235b3526fa75);
				break;
			case "naryPr":
				x1251ffbdb0de649d(xe134235b3526fa75, x6dd1552d6eb89e4e, xeedad81aaed42a);
				break;
			case "sub":
				x8bf9c7b60a6a86d8(xe134235b3526fa75, new xb4dde217cd172a7b(x3e68720d12325f49.x06b102f48629e32f), "sub");
				break;
			case "sup":
				x8bf9c7b60a6a86d8(xe134235b3526fa75, new xb4dde217cd172a7b(x3e68720d12325f49.x16984029356c96b7), "sup");
				break;
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			}
		}
		xe134235b3526fa75.xf5b0b9b6ff7ac462(NodeType.OfficeMath);
	}

	private static void x1251ffbdb0de649d(xdfce7f4f687956d7 xe134235b3526fa75, x6dd1552d6eb89e4e x168070fa1ef31d59, xeedad81aaed42a76 x4f8c20b21405e2cc)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("naryPr"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "chr":
				x168070fa1ef31d59.x067d56aec20cdd99 = xb079f24d79abc35e(x3bcd232d01c);
				break;
			case "grow":
				x168070fa1ef31d59.xe316f972e75b51de = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "limLoc":
				x168070fa1ef31d59.xe3e2b72900be18d6 = xc62574be95c1c918.xbc8913cc2c4a85ed(x3bcd232d01c.xbbfc54380705e01e());
				break;
			case "subHide":
				x168070fa1ef31d59.x42d0b8bb3dc018f1 = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "supHide":
				x168070fa1ef31d59.x6e65f77ea9696a75 = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "ctrlPr":
				x4295e20c5600d7e2(xe134235b3526fa75, x4f8c20b21405e2cc);
				break;
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			}
		}
	}

	private static void x946a0a6c151c37f5(xdfce7f4f687956d7 xe134235b3526fa75)
	{
		x099cae110a815841 x099cae110a = new x099cae110a815841();
		xeedad81aaed42a76 xeedad81aaed42a = new xeedad81aaed42a76();
		xe134235b3526fa75.x490834a62c46f14d(new OfficeMath(xe134235b3526fa75.x2c8c6741422a1298, x099cae110a, xeedad81aaed42a));
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("rad"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "e":
				x9a72407c84936f74(xe134235b3526fa75);
				break;
			case "deg":
				x8bf9c7b60a6a86d8(xe134235b3526fa75, new xb4dde217cd172a7b(x3e68720d12325f49.x2b691ff28e877ea4), "deg");
				break;
			case "radPr":
				x423d5743d65589e6(xe134235b3526fa75, x099cae110a, xeedad81aaed42a);
				break;
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			}
		}
		xe134235b3526fa75.xf5b0b9b6ff7ac462(NodeType.OfficeMath);
	}

	private static void x423d5743d65589e6(xdfce7f4f687956d7 xe134235b3526fa75, x099cae110a815841 x091aa39e17062971, xeedad81aaed42a76 x4f8c20b21405e2cc)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("radPr"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "degHide":
				x091aa39e17062971.xf9b3d1f631a6acf7 = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "ctrlPr":
				x4295e20c5600d7e2(xe134235b3526fa75, x4f8c20b21405e2cc);
				break;
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			}
		}
	}

	private static void x29107775a6d75cf2(xdfce7f4f687956d7 xe134235b3526fa75, x52642f91ccdeeb35 xa59bff7708de3a18, string x845ff59501549724)
	{
		xeedad81aaed42a76 xeedad81aaed42a = new xeedad81aaed42a76();
		xe134235b3526fa75.x490834a62c46f14d(new OfficeMath(xe134235b3526fa75.x2c8c6741422a1298, xa59bff7708de3a18, xeedad81aaed42a));
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1(x845ff59501549724))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "e":
				x9a72407c84936f74(xe134235b3526fa75);
				break;
			case "sup":
				if (xa59bff7708de3a18.x3e68720d12325f49 == x3e68720d12325f49.x1b1f4712a1a0c38c)
				{
					x3bcd232d01c.IgnoreElement();
				}
				else
				{
					x8bf9c7b60a6a86d8(xe134235b3526fa75, new xb4dde217cd172a7b(x3e68720d12325f49.x16984029356c96b7), "sup");
				}
				break;
			case "sub":
				if (xa59bff7708de3a18.x3e68720d12325f49 == x3e68720d12325f49.xe8789867140a072a)
				{
					x3bcd232d01c.IgnoreElement();
				}
				else
				{
					x8bf9c7b60a6a86d8(xe134235b3526fa75, new xb4dde217cd172a7b(x3e68720d12325f49.x06b102f48629e32f), "sub");
				}
				break;
			case "sPrePr":
				xef3c721a02b38cbd(xe134235b3526fa75, xeedad81aaed42a, "sPrePr");
				break;
			case "sSubPr":
				xef3c721a02b38cbd(xe134235b3526fa75, xeedad81aaed42a, "sSubPr");
				break;
			case "sSubSupPr":
				if (xa59bff7708de3a18.x3e68720d12325f49 == x3e68720d12325f49.xf2da195ae719a2a1)
				{
					x052e416f3b0fdab7(xe134235b3526fa75, (xfd62ce7f2b6769d5)xa59bff7708de3a18, xeedad81aaed42a);
				}
				else
				{
					x3bcd232d01c.IgnoreElement();
				}
				break;
			case "sSupPr":
				xef3c721a02b38cbd(xe134235b3526fa75, xeedad81aaed42a, "sSupPr");
				break;
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			}
		}
		xe134235b3526fa75.xf5b0b9b6ff7ac462(NodeType.OfficeMath);
	}

	private static void x052e416f3b0fdab7(xdfce7f4f687956d7 xe134235b3526fa75, xfd62ce7f2b6769d5 x692e72d323fc8d00, xeedad81aaed42a76 x4f8c20b21405e2cc)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("sSubSupPr"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "alnScr":
				x692e72d323fc8d00.x20117d07e1b6d632 = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "ctrlPr":
				x4295e20c5600d7e2(xe134235b3526fa75, x4f8c20b21405e2cc);
				break;
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			}
		}
	}

	private static void xc72a8acb971a82d6(xdfce7f4f687956d7 xe134235b3526fa75, x52642f91ccdeeb35 x76fcdbdac5bd908d)
	{
		int num = 0;
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("argPr"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f) != null && xa66385d80d4d296f == "argSz")
			{
				num = x3bcd232d01c.xb8ac33c25776194c();
			}
			else
			{
				x3bcd232d01c.IgnoreElement();
			}
		}
		if (num != 0 && x76fcdbdac5bd908d is xb4dde217cd172a7b)
		{
			((xb4dde217cd172a7b)x76fcdbdac5bd908d).x31f7427e3db1c1a8 = num;
		}
	}

	private static void xef3c721a02b38cbd(xdfce7f4f687956d7 xe134235b3526fa75, xeedad81aaed42a76 x4f8c20b21405e2cc, string x1b15470250e0458d)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1(x1b15470250e0458d))
		{
			if (x3bcd232d01c.xa66385d80d4d296f == "ctrlPr")
			{
				x4295e20c5600d7e2(xe134235b3526fa75, x4f8c20b21405e2cc);
			}
			else
			{
				x3bcd232d01c.IgnoreElement();
			}
		}
	}

	private static void x2ad2394b6c3c0189(xdfce7f4f687956d7 xe134235b3526fa75, x38058b386e92a0ef x69e7f686c701834e, xeedad81aaed42a76 x4f8c20b21405e2cc)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("accPr"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "chr":
				x69e7f686c701834e.x067d56aec20cdd99 = xb079f24d79abc35e(x3bcd232d01c);
				break;
			case "ctrlPr":
				x4295e20c5600d7e2(xe134235b3526fa75, x4f8c20b21405e2cc);
				break;
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			}
		}
	}

	private static void x80f369bfd15e877c(xdfce7f4f687956d7 xe134235b3526fa75, xc7b86a71e45628c2 x2ee8392f53a01b93, xeedad81aaed42a76 x4f8c20b21405e2cc)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("barPr"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "pos":
				x2ee8392f53a01b93.xbe1e23e7d5b43370 = xed9242817cb8c3d9(x3bcd232d01c);
				break;
			case "ctrlPr":
				x4295e20c5600d7e2(xe134235b3526fa75, x4f8c20b21405e2cc);
				break;
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			}
		}
	}

	private static void x4c439efca67566da(xdfce7f4f687956d7 xe134235b3526fa75, xfef3245bedba6f2c x06b4849f65f5a9e4, xeedad81aaed42a76 x4f8c20b21405e2cc)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("borderBoxPr"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "hideBot":
				x06b4849f65f5a9e4.x795d756c45cddeec = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "hideLeft":
				x06b4849f65f5a9e4.x224b187f1627f61c = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "hideRight":
				x06b4849f65f5a9e4.x0d399e53ae7a180a = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "hideTop":
				x06b4849f65f5a9e4.x1d72c9e455edb0c1 = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "strikeBLTR":
				x06b4849f65f5a9e4.xb6be2923de366a38 = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "strikeH":
				x06b4849f65f5a9e4.xe14c67c2d42b0d99 = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "strikeTLBR":
				x06b4849f65f5a9e4.xde23098f9048aad1 = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "strikeV":
				x06b4849f65f5a9e4.x21086958d43019dd = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "ctrlPr":
				x4295e20c5600d7e2(xe134235b3526fa75, x4f8c20b21405e2cc);
				break;
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			}
		}
	}

	private static void x037e4c97650bfd74(xdfce7f4f687956d7 xe134235b3526fa75, xf338a8521eba3175 xbbb567823982f390, xeedad81aaed42a76 x4f8c20b21405e2cc)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("boxPr"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "aln":
				xbbb567823982f390.x0c7cf16220cbe742 = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "brk":
				xbbb567823982f390.xc6ff30169310daba = xc19594ce8c9b5fe1(x3bcd232d01c);
				break;
			case "diff":
				xbbb567823982f390.xdc802487ace35154 = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "noBreak":
				xbbb567823982f390.xbb2ffb58311526cb = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "opEmu":
				xbbb567823982f390.x3b01b9ee79bdfdf1 = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "ctrlPr":
				x4295e20c5600d7e2(xe134235b3526fa75, x4f8c20b21405e2cc);
				break;
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			}
		}
	}

	private static void x082318eaebfce7cc(xdfce7f4f687956d7 xe134235b3526fa75, x8f75f1da124d37a8 x4c3e8680a15658ef, xeedad81aaed42a76 x4f8c20b21405e2cc)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("dPr"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "begChr":
				x4c3e8680a15658ef.x074be147c1a0278b = xb079f24d79abc35e(x3bcd232d01c);
				break;
			case "endChr":
				x4c3e8680a15658ef.x8af0582bac09cece = xb079f24d79abc35e(x3bcd232d01c);
				break;
			case "grow":
				x4c3e8680a15658ef.xe316f972e75b51de = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "sepChr":
				x4c3e8680a15658ef.x49b37abfabd470d8 = xb079f24d79abc35e(x3bcd232d01c);
				break;
			case "shp":
				x4c3e8680a15658ef.x5cc484d417fb4934 = xc62574be95c1c918.xdeaa127216cb1437(x3bcd232d01c.xbbfc54380705e01e());
				break;
			case "ctrlPr":
				x4295e20c5600d7e2(xe134235b3526fa75, x4f8c20b21405e2cc);
				break;
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			}
		}
	}

	private static void x9679836f266f419e(xdfce7f4f687956d7 xe134235b3526fa75, xad19b25167c52eb8 x9d5750eb2d6373bc, xeedad81aaed42a76 x4f8c20b21405e2cc)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("eqArrPr"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "baseJc":
				x9d5750eb2d6373bc.x233310de5ce401a5 = x4d2c349b7da19e15(x3bcd232d01c);
				break;
			case "maxDist":
				x9d5750eb2d6373bc.xd4a1602c6ff2213e = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "objDist":
				x9d5750eb2d6373bc.x4e7022c12aac33fc = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "rSp":
				x9d5750eb2d6373bc.x5c2893a9ae3a9fc2 = x3bcd232d01c.xb8ac33c25776194c();
				break;
			case "rSpRule":
				x9d5750eb2d6373bc.x8359894e750846dc = x776302d216c4513b(x3bcd232d01c);
				break;
			case "ctrlPr":
				x4295e20c5600d7e2(xe134235b3526fa75, x4f8c20b21405e2cc);
				break;
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			}
		}
	}

	private static void x9785eb4cdbfe9bb6(xdfce7f4f687956d7 xe134235b3526fa75, xe0ab87872ac16292 xf5467570841aab00, xeedad81aaed42a76 x4f8c20b21405e2cc)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("groupChrPr"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "chr":
				xf5467570841aab00.x067d56aec20cdd99 = xb079f24d79abc35e(x3bcd232d01c);
				break;
			case "pos":
				xf5467570841aab00.xbe1e23e7d5b43370 = xed9242817cb8c3d9(x3bcd232d01c);
				break;
			case "vertJc":
				xf5467570841aab00.x60d255f9948e4b2e = xc62574be95c1c918.x8e7c6209ce53566e(x3bcd232d01c.xbbfc54380705e01e());
				break;
			case "ctrlPr":
				x4295e20c5600d7e2(xe134235b3526fa75, x4f8c20b21405e2cc);
				break;
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			}
		}
	}

	private static void x4145dd1be0886eeb(xdfce7f4f687956d7 xe134235b3526fa75, x2a5175731d41f1b1 x9c744cfd18267b8f, xeedad81aaed42a76 x4f8c20b21405e2cc)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("phantPr"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "show":
				x9c744cfd18267b8f.x6f068d44e0e83706 = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "transp":
				x9c744cfd18267b8f.x009cb1da90c5afd0 = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "zeroAsc":
				x9c744cfd18267b8f.xb0e0759ff352b2e5 = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "zeroDesc":
				x9c744cfd18267b8f.x1c938670e5e4b483 = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "zeroWid":
				x9c744cfd18267b8f.x4dc21387c15e58e7 = x3bcd232d01c.xe04906126da94dd1();
				break;
			case "ctrlPr":
				x4295e20c5600d7e2(xe134235b3526fa75, x4f8c20b21405e2cc);
				break;
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			}
		}
	}

	private static void x4295e20c5600d7e2(xdfce7f4f687956d7 xe134235b3526fa75, xeedad81aaed42a76 x4f8c20b21405e2cc)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("ctrlPr"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "del":
				x993aabbdc0e02955.x2e2f0d991c11c6e2(xe134235b3526fa75, x4f8c20b21405e2cc, x811bf90f0d6a2c18: true);
				break;
			case "ins":
				x993aabbdc0e02955.x2e2f0d991c11c6e2(xe134235b3526fa75, x4f8c20b21405e2cc, x811bf90f0d6a2c18: false);
				break;
			case "rPr":
				x419d718f5b3e63d8.x06b0e25aa6ad68a9(xe134235b3526fa75, x4f8c20b21405e2cc);
				break;
			default:
				x3bcd232d01c.IgnoreElement();
				break;
			}
		}
	}

	internal static x488a5f49abd86bb8 xc19594ce8c9b5fe1(x3c85359e1389ad43 xe134235b3526fa75)
	{
		x488a5f49abd86bb8 x488a5f49abd86bb = new x488a5f49abd86bb8();
		string text = xe134235b3526fa75.xd68abcd61e368af9("alnAt", null);
		x488a5f49abd86bb.x9ba359ff37a3a63b = (x0d299f323d241756.x5959bccb67bbf051(text) ? xca004f56614e2431.x59884ab46dd0d856(text) : 0);
		return x488a5f49abd86bb;
	}

	internal static int xaf982a4910099df8(x3c85359e1389ad43 xe134235b3526fa75)
	{
		int num = xe134235b3526fa75.xb8ac33c25776194c();
		if (num >= 1)
		{
			if (num <= 255)
			{
				return num;
			}
			return 255;
		}
		return 1;
	}

	internal static xce8b2ce767b2485c xed9242817cb8c3d9(x3c85359e1389ad43 x97bf2eeabd4abc7b)
	{
		return xc62574be95c1c918.xc2015ac1099ed470(x97bf2eeabd4abc7b.xbbfc54380705e01e());
	}

	internal static x77581da1860d0f9e x776302d216c4513b(x3c85359e1389ad43 x97bf2eeabd4abc7b)
	{
		int num = x97bf2eeabd4abc7b.xb8ac33c25776194c();
		if (num >= 0)
		{
			if (num <= 4)
			{
				return (x77581da1860d0f9e)num;
			}
			return x77581da1860d0f9e.x91043c6e17767336;
		}
		return x77581da1860d0f9e.x63374d6ffed4adeb;
	}

	internal static xb474f98b96852a6e x4d2c349b7da19e15(x3c85359e1389ad43 x97bf2eeabd4abc7b)
	{
		return xc62574be95c1c918.xd054f4cfeace1391(x97bf2eeabd4abc7b.xbbfc54380705e01e());
	}

	private static char xb079f24d79abc35e(x3c85359e1389ad43 xe134235b3526fa75)
	{
		string text = xe134235b3526fa75.xbbfc54380705e01e();
		if (text.Length <= 0)
		{
			return '\0';
		}
		return text[0];
	}
}
