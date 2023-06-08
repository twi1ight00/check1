using System;
using x4dc96876c552a593;
using x6b8130194ad714f7;
using x6c95d9cf46ff5f25;
using x8bb6b4f09b5230a5;

namespace x95bd05bb616368d3;

internal class xeac163f5930e8db6 : xaaf059f0543cf507, x4bce37a68a46eb2b
{
	private xaeaeae8d38ef57bb x827e895033b76e5e;

	private xcac04f3919526f00 xc63c1886c6cccc78;

	private xef3538cc44802939 x49ee3c26b2872b11;

	private x34b8da5e65f2d94f xbe1b3879b7d92a27;

	private xc69a7835ec81710c xb57ab17a50fa2a56;

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
	}

	public xaeaeae8d38ef57bb xd98b6fc8af69e348
	{
		get
		{
			if (x827e895033b76e5e == null)
			{
				x827e895033b76e5e = new xd13db1e4c9fb8129(base.xca687bd498227c89);
			}
			return x827e895033b76e5e;
		}
	}

	public xeac163f5930e8db6(xe9481907c579c280 serviceLocator)
		: base(serviceLocator)
	{
	}

	public x34b8da5e65f2d94f xda09af88ab899a50(xc1dcd6189d01216e xe134235b3526fa75)
	{
		x4c28ef76f151d171(xe134235b3526fa75);
		if (xe134235b3526fa75.xa66385d80d4d296f != "txSp")
		{
			return null;
		}
		xbe1b3879b7d92a27 = new x34b8da5e65f2d94f();
		while (xe134235b3526fa75.x152cbadbfa8061b1("txSp"))
		{
			switch (xe134235b3526fa75.xa66385d80d4d296f)
			{
			case "txBody":
				x56bdb6196ee0db92(x7450cc1e48712286, xbe1b3879b7d92a27.xf6bed998bac61470, "txBody");
				break;
			case "useSpRect":
				xbe1b3879b7d92a27.x5364515b89d16049 = true;
				break;
			case "xfrm":
				xbe1b3879b7d92a27.xaccac17571a8d9fa = xe3c198f6af54e264.x389fccbe88e3b864(x7450cc1e48712286);
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
		return xbe1b3879b7d92a27;
	}

	internal void x56bdb6196ee0db92(xc1dcd6189d01216e xe134235b3526fa75, x4e987a76388726b5 x65cf0b9e682764ac, string x91ef5ae2997ab6c4)
	{
		x4c28ef76f151d171(xe134235b3526fa75);
		while (x7450cc1e48712286.x152cbadbfa8061b1(x91ef5ae2997ab6c4))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "p":
				x65cf0b9e682764ac.x959bfe125105856a(xaf29feffa5ac22db(x7450cc1e48712286));
				break;
			case "lstStyle":
				xa05b91f102829c23(x7450cc1e48712286, x65cf0b9e682764ac.x7f76f83af2b39f31);
				break;
			case "bodyPr":
				xc446bbddf95eab07(x7450cc1e48712286, x65cf0b9e682764ac.x4e35c79189b28e26);
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
	}

	internal void xc446bbddf95eab07(xc1dcd6189d01216e xe134235b3526fa75, x53a4366d160ef67f xa5ea04da0b735c3b)
	{
		x4c28ef76f151d171(xe134235b3526fa75);
		while (x7450cc1e48712286.x1ac1960adc8c4c39())
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "anchor":
				xa5ea04da0b735c3b.x1452024de1251c74 = x81be9e7a4e85e0bf();
				break;
			case "anchorCtr":
				xa5ea04da0b735c3b.x4f1df857f0163527 = x7450cc1e48712286.xc3be6b142c6aca84;
				break;
			case "bIns":
				xa5ea04da0b735c3b.xa182bedf6256377d.x9bcb07e204e30218 = x7450cc1e48712286.xbba6773b8ce56a01;
				break;
			case "lIns":
				xa5ea04da0b735c3b.xa182bedf6256377d.x72d92bd1aff02e37 = x7450cc1e48712286.xbba6773b8ce56a01;
				break;
			case "tIns":
				xa5ea04da0b735c3b.xa182bedf6256377d.xe360b1885d8d4a41 = x7450cc1e48712286.xbba6773b8ce56a01;
				break;
			case "rIns":
				xa5ea04da0b735c3b.xa182bedf6256377d.x419ba17a5322627b = x7450cc1e48712286.xbba6773b8ce56a01;
				break;
			case "forceAA":
				xa5ea04da0b735c3b.x0a819c325fc5af26 = x7450cc1e48712286.xc3be6b142c6aca84;
				break;
			case "fromWordArt":
				xa5ea04da0b735c3b.xf193936e20cfafc3 = x7450cc1e48712286.xc3be6b142c6aca84;
				break;
			case "rot":
				xa5ea04da0b735c3b.xa00ce09851f40ee5 = new xd4583a58cd9d2194(x7450cc1e48712286.x0cf73f14becdef59);
				break;
			case "numCol":
				xa5ea04da0b735c3b.xe7a008202327d76d = x7450cc1e48712286.xbba6773b8ce56a01;
				break;
			case "rtlCol":
				xa5ea04da0b735c3b.xdae437eb5b492a14 = (x7450cc1e48712286.xc3be6b142c6aca84 ? x48f79856ce501d1c.x94975a4c4f1d71c4 : x48f79856ce501d1c.xf436d87de8b1757e);
				break;
			case "spcCol":
				xa5ea04da0b735c3b.x1a5b505e78ae10c9 = x7450cc1e48712286.xbba6773b8ce56a01;
				break;
			case "compatLnSpc":
				xa5ea04da0b735c3b.x16755c611313115f = x7450cc1e48712286.xc3be6b142c6aca84;
				break;
			case "spcFirstLastPara":
				xa5ea04da0b735c3b.xf478eef44f529329 = x7450cc1e48712286.xc3be6b142c6aca84;
				break;
			case "horzOverflow":
				xa5ea04da0b735c3b.x1ff59f5f3bb3ae9f = xcd67e581900d3029();
				break;
			case "upright":
				xa5ea04da0b735c3b.xd097ca4be7b5a892 = x7450cc1e48712286.xc3be6b142c6aca84;
				break;
			case "vert":
				xa5ea04da0b735c3b.x0678c9a364ddbc80 = x2edbbf07b5fbb0fe();
				break;
			case "vertOverflow":
				xa5ea04da0b735c3b.x376d6778ae71491f = xd21e1f0ef54dbc74();
				break;
			case "wrap":
				xa5ea04da0b735c3b.x06aae9773e95c1ae = xe0df463c3a131cc2();
				break;
			default:
				x31b781f807fd2607();
				break;
			}
		}
		while (x7450cc1e48712286.x152cbadbfa8061b1("bodyPr"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "extLst":
			case "flatTx":
			case "noAutofit":
			case "normAutofit":
			case "prstTxWarp":
			case "scene3d":
			case "sp3d":
			case "spAutoFit":
				x10576afa17ca4f1f();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
	}

	private x87047bb0b6c22e8c xe0df463c3a131cc2()
	{
		return x7450cc1e48712286.xd2f68ee6f47e9dfb switch
		{
			"none" => x87047bb0b6c22e8c.x4d0b9d4447ba7566, 
			"square" => x87047bb0b6c22e8c.xed2a37919fe44f03, 
			_ => x87047bb0b6c22e8c.xed2a37919fe44f03, 
		};
	}

	private x5a2dd21017862c29 xd21e1f0ef54dbc74()
	{
		return x7450cc1e48712286.xd2f68ee6f47e9dfb switch
		{
			"overflow" => x5a2dd21017862c29.x2ee548a6adbe2c27, 
			"clip" => x5a2dd21017862c29.x0e1bf8242ad10272, 
			"ellipsis" => x5a2dd21017862c29.x3c69486f5654b4ec, 
			_ => x5a2dd21017862c29.x2ee548a6adbe2c27, 
		};
	}

	private x84da24afaa5409ad x2edbbf07b5fbb0fe()
	{
		return x7450cc1e48712286.xd2f68ee6f47e9dfb switch
		{
			"horz" => x84da24afaa5409ad.x3bce7c87328df8da, 
			"vert" => x84da24afaa5409ad.x61c108cc44ef385a, 
			"vert270" => x84da24afaa5409ad.x7b4c038caa4fa423, 
			"wordArtVert" => x84da24afaa5409ad.x8273284928fd7da2, 
			"eaVert" => x84da24afaa5409ad.xc65ca7e097fe139a, 
			"mongolianVert" => x84da24afaa5409ad.x7c105d4ec689578f, 
			"wordArtVertRtl" => x84da24afaa5409ad.x69f0d75131efde4d, 
			_ => x84da24afaa5409ad.x3bce7c87328df8da, 
		};
	}

	private x0bdcd31a36b9ecf6 xcd67e581900d3029()
	{
		return x7450cc1e48712286.xd2f68ee6f47e9dfb switch
		{
			"overflow" => x0bdcd31a36b9ecf6.x2ee548a6adbe2c27, 
			"clip" => x0bdcd31a36b9ecf6.x0e1bf8242ad10272, 
			_ => x0bdcd31a36b9ecf6.x2ee548a6adbe2c27, 
		};
	}

	private x5a0fcf86fc261088 x81be9e7a4e85e0bf()
	{
		return x7450cc1e48712286.xd2f68ee6f47e9dfb switch
		{
			"t" => x5a0fcf86fc261088.xe360b1885d8d4a41, 
			"ctr" => x5a0fcf86fc261088.x58d2ccae3c5cfd08, 
			"b" => x5a0fcf86fc261088.x9bcb07e204e30218, 
			"just" => x5a0fcf86fc261088.xe590b96312e08b5b, 
			"dist" => x5a0fcf86fc261088.x18ef0deb23f38251, 
			_ => x5a0fcf86fc261088.xe360b1885d8d4a41, 
		};
	}

	internal void xa05b91f102829c23(xc1dcd6189d01216e xe134235b3526fa75, xe97bbccdb2e0268e x3fa6ecdd18b2ff6e)
	{
		x4c28ef76f151d171(xe134235b3526fa75);
		while (x7450cc1e48712286.x152cbadbfa8061b1("lstStyle"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "defPPr":
				x1421526c505f73eb(x3fa6ecdd18b2ff6e.xeac22b13126ab0d5);
				break;
			case "lvl1pPr":
				x1421526c505f73eb(x3fa6ecdd18b2ff6e.x4ce241104dd6e3f6);
				break;
			case "lvl2pPr":
				x1421526c505f73eb(x3fa6ecdd18b2ff6e.x1274e70ebb28756f);
				break;
			case "lvl3pPr":
				x1421526c505f73eb(x3fa6ecdd18b2ff6e.x3a94576465d4b6b0);
				break;
			case "lvl4pPr":
				x1421526c505f73eb(x3fa6ecdd18b2ff6e.x2df81b9dd1945599);
				break;
			case "lvl5pPr":
				x1421526c505f73eb(x3fa6ecdd18b2ff6e.x22fb0e88c30a1b66);
				break;
			case "lvl6pPr":
				x1421526c505f73eb(x3fa6ecdd18b2ff6e.x79749ed73f88324a);
				break;
			case "lvl7pPr":
				x1421526c505f73eb(x3fa6ecdd18b2ff6e.x874825f95fdc1ba2);
				break;
			case "lvl8pPr":
				x1421526c505f73eb(x3fa6ecdd18b2ff6e.xe2ce958328418a9c);
				break;
			case "lvl9pPr":
				x1421526c505f73eb(x3fa6ecdd18b2ff6e.xd18102fd4d96e689);
				break;
			default:
				x7450cc1e48712286.IgnoreElement();
				break;
			}
		}
	}

	internal xf5c6aa532fe023d4 xaf29feffa5ac22db(xc1dcd6189d01216e xe134235b3526fa75)
	{
		x4c28ef76f151d171(xe134235b3526fa75);
		xf5c6aa532fe023d4 xf5c6aa532fe023d = new xf5c6aa532fe023d4();
		while (x7450cc1e48712286.x152cbadbfa8061b1("p"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "br":
				xf5c6aa532fe023d.x4b02688aa4c0e34d(x6b4ddf0014cf6cb2());
				break;
			case "fld":
				xf5c6aa532fe023d.x4b02688aa4c0e34d(xe26fe40a64d05a8b());
				break;
			case "r":
				xf5c6aa532fe023d.x4b02688aa4c0e34d(xd58a9c7cedb8d768());
				break;
			case "m":
				xf5c6aa532fe023d.x4b02688aa4c0e34d(x38d2e860d470f8e0());
				break;
			case "pPr":
				x1421526c505f73eb(xf5c6aa532fe023d.x4e35c79189b28e26);
				break;
			case "endParaRPr":
				x10576afa17ca4f1f();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
		return xf5c6aa532fe023d;
	}

	private x46a16fcc58b77ea3 x38d2e860d470f8e0()
	{
		x46a16fcc58b77ea3 result = new x46a16fcc58b77ea3();
		x10576afa17ca4f1f();
		return result;
	}

	private x91f0f9c35f99edd9 xd58a9c7cedb8d768()
	{
		x91f0f9c35f99edd9 x91f0f9c35f99edd = new x91f0f9c35f99edd9();
		while (x7450cc1e48712286.x152cbadbfa8061b1("r"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "t":
				x91f0f9c35f99edd.xf9ad6fb78355fe13 += x7450cc1e48712286.x2a1ea9d24e62bf84();
				break;
			case "rPr":
				xa30bb01f6e813bca(x91f0f9c35f99edd.x8fb6a748ef46ad8f);
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
		return x91f0f9c35f99edd;
	}

	private void xa30bb01f6e813bca(x7423ef514d81c23e xe11545499171cc05)
	{
		string xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f;
		while (x7450cc1e48712286.x1ac1960adc8c4c39())
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "altLang":
				xe11545499171cc05.xaa058713887ef4a4 = x7450cc1e48712286.xd2f68ee6f47e9dfb;
				break;
			case "b":
				xe11545499171cc05.x4e1d3347e7864b81 = x7450cc1e48712286.xc3be6b142c6aca84;
				break;
			case "baseline":
				xe11545499171cc05.x139412b8dea2f02b = new x55c6a66cc28d5b86(x7450cc1e48712286.x0cf73f14becdef59);
				break;
			case "bmk":
				xe11545499171cc05.x33fffcc6e43a919f = x7450cc1e48712286.xd2f68ee6f47e9dfb;
				break;
			case "cap":
				xe11545499171cc05.xd491611dbf29242f = x12200ddf8e2cf13c();
				break;
			case "dirty":
				xe11545499171cc05.x6e94079169d5a06e = x7450cc1e48712286.xc3be6b142c6aca84;
				break;
			case "err":
				xe11545499171cc05.x49a6ea79be0c1c78 = x7450cc1e48712286.xc3be6b142c6aca84;
				break;
			case "i":
				xe11545499171cc05.xbb7ce6a7f4354e86 = x7450cc1e48712286.xc3be6b142c6aca84;
				break;
			case "kern":
				xe11545499171cc05.x5d307c4bc30bdc4b = new xa435fbe8ebcefc2c(x7450cc1e48712286.xbba6773b8ce56a01);
				break;
			case "kumimoji":
				xe11545499171cc05.x7a30d22f54c46b2f = x7450cc1e48712286.xc3be6b142c6aca84;
				break;
			case "lang":
				xe11545499171cc05.x448900fcb384c333 = x7450cc1e48712286.xd2f68ee6f47e9dfb;
				break;
			case "noProof":
				xe11545499171cc05.xf01bc3bed63a693e = x7450cc1e48712286.xc3be6b142c6aca84;
				break;
			case "normalizeH":
				xe11545499171cc05.x46b41d72c0fa629c = x7450cc1e48712286.xc3be6b142c6aca84;
				break;
			case "smtClean":
				xe11545499171cc05.xfcd2b9ea3607a65b = x7450cc1e48712286.xc3be6b142c6aca84;
				break;
			case "smtId":
				xe11545499171cc05.xcb4781284ba8e3a8 = x7450cc1e48712286.xbba6773b8ce56a01;
				break;
			case "spc":
				xe11545499171cc05.x9ba60a33bc3988dc = new xa435fbe8ebcefc2c(x7450cc1e48712286.xbba6773b8ce56a01);
				break;
			case "strike":
				xe11545499171cc05.x9d12b157622f55d1 = xa9a657acc68d21ed();
				break;
			case "sz":
				xe11545499171cc05.x70c328f6f2e77d76 = new xa435fbe8ebcefc2c(x7450cc1e48712286.xbba6773b8ce56a01);
				break;
			case "u":
				xe11545499171cc05.x2588d8c20c42e232 = xf481b9f58977a103();
				break;
			default:
				x31b781f807fd2607();
				break;
			}
		}
		while (x7450cc1e48712286.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "blipFill":
			case "gradFill":
			case "grpFill":
			case "noFill":
			case "pattFill":
			case "solidFill":
				xe11545499171cc05.x6a81a30bcaf20a97 = xfea0ad465c7d1afc.xda09af88ab899a50(x7450cc1e48712286);
				break;
			case "ln":
				xe11545499171cc05.x93e68a44438355fd = xaeb5dcd7334ed5f6.xda09af88ab899a50(x7450cc1e48712286);
				break;
			case "highlight":
				while (x7450cc1e48712286.x152cbadbfa8061b1("highlight"))
				{
					xe11545499171cc05.xabb599f76795ecaf = xd98b6fc8af69e348.xda09af88ab899a50(x7450cc1e48712286);
				}
				break;
			case "cs":
				xe11545499171cc05.x0b927daea4055ed9 = (x3d46f61ca55cfe4a)xdafccb198ba91439(new x3d46f61ca55cfe4a());
				break;
			case "ea":
				xe11545499171cc05.xb9e96356cc5f1bb4 = (x2afa4affd8d56086)xdafccb198ba91439(new x2afa4affd8d56086());
				break;
			case "sym":
				xe11545499171cc05.x9566a841c952dfd4 = (x816cf1ad87b4f160)xdafccb198ba91439(new x816cf1ad87b4f160());
				break;
			case "latin":
				xe11545499171cc05.x6d528e2b40b8fe2b = (xae4a616d9ee98ed5)xdafccb198ba91439(new xae4a616d9ee98ed5());
				break;
			case "rtl":
			case "uFill":
			case "uFillTx":
			case "uLn":
			case "uLnTx":
			case "effectDag":
			case "effectLst":
			case "hlinkClick":
			case "hlinkMouseOver":
			case "extLst":
				x10576afa17ca4f1f();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
	}

	private xd493fcff6eb73ce4 xf481b9f58977a103()
	{
		return x7450cc1e48712286.xd2f68ee6f47e9dfb switch
		{
			"none" => xd493fcff6eb73ce4.x4d0b9d4447ba7566, 
			"words" => xd493fcff6eb73ce4.xb2bd1dd426c2de22, 
			"sng" => xd493fcff6eb73ce4.x63374d6ffed4adeb, 
			"dbl" => xd493fcff6eb73ce4.x94c083f2813272f4, 
			"heavy" => xd493fcff6eb73ce4.x1726fe5eed9a5354, 
			"dotted" => xd493fcff6eb73ce4.x91e3321dba7c4e35, 
			"dottedHeavy" => xd493fcff6eb73ce4.x435d7c076b409abd, 
			"dash" => xd493fcff6eb73ce4.xb821aa5ca2aea378, 
			"dashHeavy" => xd493fcff6eb73ce4.x94bdc4bdee6f3400, 
			"dashLong" => xd493fcff6eb73ce4.x4afddafe3531e082, 
			"dashLongHeavy" => xd493fcff6eb73ce4.x969c60190331fad1, 
			"dotDash" => xd493fcff6eb73ce4.xd369ac0b29c87999, 
			"dotDashHeavy" => xd493fcff6eb73ce4.xdfd9e80743e8371f, 
			"dotDotDash" => xd493fcff6eb73ce4.x1c5f32bc0cb03951, 
			"dotDotDashHeavy" => xd493fcff6eb73ce4.xf8e54953a405d8a0, 
			"wavy" => xd493fcff6eb73ce4.x4e82f9fa664d942e, 
			"wavyHeavy" => xd493fcff6eb73ce4.x881905d8f877c5c5, 
			"wavyDbl" => xd493fcff6eb73ce4.x95beb88024b44bd3, 
			_ => xd493fcff6eb73ce4.x4d0b9d4447ba7566, 
		};
	}

	private x34b039801e93e11a xdafccb198ba91439(x34b039801e93e11a x26094932cf7a9139)
	{
		while (x7450cc1e48712286.x1ac1960adc8c4c39())
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "charset":
				x26094932cf7a9139.x0a882f85e9640944 = x7450cc1e48712286.xbba6773b8ce56a01;
				break;
			case "panose":
				x26094932cf7a9139.xe858907a4c00c3da = x7450cc1e48712286.xd2f68ee6f47e9dfb;
				break;
			case "pitchFamily":
				x26094932cf7a9139.xcf6d56098b1d5809 = x7450cc1e48712286.xbba6773b8ce56a01;
				break;
			case "typeface":
				x26094932cf7a9139.xeed997b9da346323 = x7450cc1e48712286.xd2f68ee6f47e9dfb;
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
		return x26094932cf7a9139;
	}

	private xaa9fe797352ec9b3 xa9a657acc68d21ed()
	{
		return x7450cc1e48712286.xd2f68ee6f47e9dfb switch
		{
			"noStrike" => xaa9fe797352ec9b3.xa0950aeff247b5e2, 
			"sngStrike" => xaa9fe797352ec9b3.x63374d6ffed4adeb, 
			"dblStrike" => xaa9fe797352ec9b3.x94c083f2813272f4, 
			_ => xaa9fe797352ec9b3.xa0950aeff247b5e2, 
		};
	}

	private x25e6349f876650d7 x12200ddf8e2cf13c()
	{
		return x7450cc1e48712286.xd2f68ee6f47e9dfb switch
		{
			"none" => x25e6349f876650d7.x4d0b9d4447ba7566, 
			"small" => x25e6349f876650d7.x6207fc6b67b3b286, 
			"all" => x25e6349f876650d7.x95c57ee794bc0aec, 
			_ => x25e6349f876650d7.x4d0b9d4447ba7566, 
		};
	}

	private x7a74f0f8d96597f1 xe26fe40a64d05a8b()
	{
		x7a74f0f8d96597f1 x7a74f0f8d96597f = new x7a74f0f8d96597f1();
		x7a74f0f8d96597f.xea1e81378298fa81 = x7450cc1e48712286.x291bb964d3760288("id", Guid.Empty);
		x7a74f0f8d96597f.x3146d638ec378671 = x7450cc1e48712286.xd68abcd61e368af9("type", string.Empty);
		while (x7450cc1e48712286.x152cbadbfa8061b1("fld"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "rPr":
				xa30bb01f6e813bca(x7a74f0f8d96597f.x8fb6a748ef46ad8f);
				break;
			case "pPr":
				x1421526c505f73eb(x7a74f0f8d96597f.xf4ee73e70183517d);
				break;
			case "t":
				x7a74f0f8d96597f.xf9ad6fb78355fe13 += x7450cc1e48712286.x2a1ea9d24e62bf84();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
		return x7a74f0f8d96597f;
	}

	private void x1421526c505f73eb(xbda35f782f90b3df xe11545499171cc05)
	{
		string xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f;
		while (x7450cc1e48712286.x1ac1960adc8c4c39())
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "algn":
				xe11545499171cc05.x9ba359ff37a3a63b = x8c3a11a898fb9df6();
				break;
			case "defTabSz":
				xe11545499171cc05.x12aff6ea7f96b2cc = x7450cc1e48712286.xbba6773b8ce56a01;
				break;
			case "eaLnBrk":
				xe11545499171cc05.xbbb35e1022ca3dfd = x7450cc1e48712286.xc3be6b142c6aca84;
				break;
			case "hangingPunct":
				xe11545499171cc05.x8d9f94e72b04c49a = x7450cc1e48712286.xc3be6b142c6aca84;
				break;
			case "fontAlgn":
				xe11545499171cc05.x41a2b0003abed345 = x36e1b3e2923ddb02();
				break;
			case "indent":
				xe11545499171cc05.x412be8036a42f59b = x7450cc1e48712286.xbba6773b8ce56a01;
				break;
			case "latinLnBrk":
				xe11545499171cc05.xd58a6ff2cdce5c2a = x7450cc1e48712286.xc3be6b142c6aca84;
				break;
			case "lvl":
				xe11545499171cc05.x504f3d4040b356d7 = x7450cc1e48712286.xbba6773b8ce56a01;
				break;
			case "marL":
				xe11545499171cc05.xc8a7b7ce5c5279ee = x7450cc1e48712286.xbba6773b8ce56a01;
				break;
			case "marR":
				xe11545499171cc05.x3fa6fa3075fd558f = x7450cc1e48712286.xbba6773b8ce56a01;
				break;
			case "rtl":
				xe11545499171cc05.x070fd11bdd2e9529 = x7450cc1e48712286.xc3be6b142c6aca84;
				break;
			default:
				x31b781f807fd2607();
				break;
			}
		}
		while (x7450cc1e48712286.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "defRPr":
				xa30bb01f6e813bca(xe11545499171cc05.xbbbfd1631e528b0a);
				break;
			case "lnSpc":
				xe11545499171cc05.x84bbacdc1fc0efd2 = x5b938cf59f9d5fd3();
				break;
			case "spcAft":
				xe11545499171cc05.xdc88f9287c50d24f = x5b938cf59f9d5fd3();
				break;
			case "spcBef":
				xe11545499171cc05.xce7d39f89d44bc2a = x5b938cf59f9d5fd3();
				break;
			case "buAutoNum":
			case "buBlip":
			case "buChar":
			case "buClr":
			case "buClrTx":
			case "buFont":
			case "buFontTx":
			case "buNone":
			case "buSzPct":
			case "buSzPts":
			case "buSzTx":
			case "tabLst":
			case "extLst":
				x10576afa17ca4f1f();
				break;
			default:
				x31b781f807fd2607();
				break;
			}
		}
	}

	private x7e58bc4f68c02a4e x5b938cf59f9d5fd3()
	{
		x7e58bc4f68c02a4e result = null;
		string xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f;
		while (x7450cc1e48712286.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "spcPct":
			{
				double value = x7450cc1e48712286.x075a63114fe24ce9("val", 100000.0);
				xab3240a79e69f8ba xab3240a79e69f8ba = new xab3240a79e69f8ba();
				xab3240a79e69f8ba.xd2f68ee6f47e9dfb = new x55c6a66cc28d5b86(value);
				result = xab3240a79e69f8ba;
				break;
			}
			case "spcPts":
			{
				int num = x7450cc1e48712286.xe8602379c60acf13("val", -1);
				if (num > 0)
				{
					x4441c4f4496ce248 x4441c4f4496ce = new x4441c4f4496ce248();
					x4441c4f4496ce.xd2f68ee6f47e9dfb = new xa435fbe8ebcefc2c(num);
					result = x4441c4f4496ce;
				}
				break;
			}
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
		return result;
	}

	private x611028efb6f69332 x36e1b3e2923ddb02()
	{
		return x7450cc1e48712286.xd2f68ee6f47e9dfb switch
		{
			"auto" => x611028efb6f69332.xf922b3021cb1a28a, 
			"t" => x611028efb6f69332.xe360b1885d8d4a41, 
			"ctr" => x611028efb6f69332.x58d2ccae3c5cfd08, 
			"b" => x611028efb6f69332.x9bcb07e204e30218, 
			"base" => x611028efb6f69332.x139412b8dea2f02b, 
			_ => x611028efb6f69332.x139412b8dea2f02b, 
		};
	}

	private x19a216c91d09a513 x8c3a11a898fb9df6()
	{
		return x7450cc1e48712286.xd2f68ee6f47e9dfb switch
		{
			"l" => x19a216c91d09a513.x72d92bd1aff02e37, 
			"ctr" => x19a216c91d09a513.x58d2ccae3c5cfd08, 
			"r" => x19a216c91d09a513.x419ba17a5322627b, 
			"just" => x19a216c91d09a513.xe590b96312e08b5b, 
			"justLow" => x19a216c91d09a513.xbcf8338386567937, 
			"dist" => x19a216c91d09a513.x18ef0deb23f38251, 
			"thaiDist" => x19a216c91d09a513.x8132d8efd150f3e7, 
			_ => x19a216c91d09a513.x72d92bd1aff02e37, 
		};
	}

	private x1c56b7c63462bb5e x6b4ddf0014cf6cb2()
	{
		x1c56b7c63462bb5e x1c56b7c63462bb5e = new x1c56b7c63462bb5e();
		while (x7450cc1e48712286.x152cbadbfa8061b1("br"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f) != null && xa66385d80d4d296f == "rPr")
			{
				xa30bb01f6e813bca(x1c56b7c63462bb5e.x8fb6a748ef46ad8f);
			}
			else
			{
				xf4732ad4641eec1a();
			}
		}
		return x1c56b7c63462bb5e;
	}
}
