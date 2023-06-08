using System.Collections;
using x32a884d842a34446;
using x4dc96876c552a593;
using x6c95d9cf46ff5f25;
using x8bb6b4f09b5230a5;
using xcc8a79815d76af85;
using xf9a9481c3f63a419;

namespace x95bd05bb616368d3;

internal class x7f84d4dc848984c4 : xaaf059f0543cf507
{
	private xb513d822d3b4388b xa27c3313327885d9;

	private xeac163f5930e8db6 x6b145c91b525cad4;

	private xb513d822d3b4388b x8b9ff7d032a443a1
	{
		get
		{
			if (xa27c3313327885d9 == null)
			{
				xa27c3313327885d9 = new xb513d822d3b4388b(base.xca687bd498227c89);
			}
			return xa27c3313327885d9;
		}
	}

	private xeac163f5930e8db6 xd98a1954620007f2
	{
		get
		{
			if (x6b145c91b525cad4 == null)
			{
				x6b145c91b525cad4 = new xeac163f5930e8db6(base.xca687bd498227c89);
			}
			return x6b145c91b525cad4;
		}
	}

	public x7f84d4dc848984c4(xe9481907c579c280 serviceLocator)
		: base(serviceLocator)
	{
	}

	internal void x10a86a9a76e8d159(xc1dcd6189d01216e x97bf2eeabd4abc7b, x4694a3400bb4849a x5d73ec97767a1b0c)
	{
		x4c28ef76f151d171(x97bf2eeabd4abc7b);
		while (x7450cc1e48712286.x152cbadbfa8061b1("txPr"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "bodyPr":
				x5d73ec97767a1b0c.xac9203c0f3afd032 = new x53a4366d160ef67f();
				xd98a1954620007f2.xc446bbddf95eab07(x7450cc1e48712286, x5d73ec97767a1b0c.xac9203c0f3afd032);
				break;
			case "lstStyle":
				x5d73ec97767a1b0c.xff8022e97ad67676 = new xe97bbccdb2e0268e();
				xd98a1954620007f2.xa05b91f102829c23(x7450cc1e48712286, x5d73ec97767a1b0c.xff8022e97ad67676);
				break;
			case "p":
				x5d73ec97767a1b0c.x959bfe125105856a(xd98a1954620007f2.xaf29feffa5ac22db(x7450cc1e48712286));
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
	}

	internal void xdb3e183f8621de35(xc1dcd6189d01216e x97bf2eeabd4abc7b, xbc46977eebea4733 x82f66163e01f713f)
	{
		x4c28ef76f151d171(x97bf2eeabd4abc7b);
		while (x7450cc1e48712286.x152cbadbfa8061b1("spPr"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "blipFill":
			case "gradFill":
			case "grpFill":
			case "noFill":
			case "pattFill":
			case "solidFill":
				x82f66163e01f713f.x6a81a30bcaf20a97 = x8b9ff7d032a443a1.xfea0ad465c7d1afc.xda09af88ab899a50(x7450cc1e48712286);
				break;
			case "ln":
				x82f66163e01f713f.x93e68a44438355fd = x8b9ff7d032a443a1.xaeb5dcd7334ed5f6.xda09af88ab899a50(x7450cc1e48712286);
				break;
			case "custGeom":
			case "xfrm":
			case "prstGeom":
			case "scene3d":
			case "effectDag":
			case "effectLst":
			case "extLst":
			case "sp3d":
				x10576afa17ca4f1f();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
	}

	internal void xe0bd5a61617214a7(xc1dcd6189d01216e x97bf2eeabd4abc7b, xbc46977eebea4733 x82f66163e01f713f)
	{
		x4c28ef76f151d171(x97bf2eeabd4abc7b);
		string xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f;
		while (x7450cc1e48712286.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			string xa66385d80d4d296f2;
			if ((xa66385d80d4d296f2 = x7450cc1e48712286.xa66385d80d4d296f) != null && xa66385d80d4d296f2 == "spPr")
			{
				xdb3e183f8621de35(x7450cc1e48712286, x82f66163e01f713f);
			}
			else
			{
				xf4732ad4641eec1a();
			}
		}
	}

	internal xb7d17fc15d44a902 xc15b3b85a30a6c35(xc1dcd6189d01216e x97bf2eeabd4abc7b)
	{
		x4c28ef76f151d171(x97bf2eeabd4abc7b);
		xb7d17fc15d44a902 xb7d17fc15d44a = new xb7d17fc15d44a902();
		while (x7450cc1e48712286.x152cbadbfa8061b1("legend"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "layout":
				xb7d17fc15d44a.xb7ae55095fddecd9 = x258b75baa7766b96(x7450cc1e48712286);
				break;
			case "legendEntry":
				xb7d17fc15d44a.xd7d75c376e5ae843(x3db81aba32a8cffd());
				break;
			case "legendPos":
				xb7d17fc15d44a.x6e1ac924b90562d1 = xa74237a39984bb17.xfed17a6045542be4(x7450cc1e48712286.xd68abcd61e368af9("val", ""));
				break;
			case "overlay":
				xb7d17fc15d44a.x3f5e31045e967a38 = x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true);
				break;
			case "spPr":
				xdb3e183f8621de35(x7450cc1e48712286, xb7d17fc15d44a.xff13b489d81606b6);
				break;
			case "txPr":
				x10a86a9a76e8d159(x7450cc1e48712286, xb7d17fc15d44a.x68955bfadd010132);
				break;
			case "extLst":
				x10576afa17ca4f1f();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
		return xb7d17fc15d44a;
	}

	private xe34702c565a0b0b9 x3db81aba32a8cffd()
	{
		xe34702c565a0b0b9 xe34702c565a0b0b = new xe34702c565a0b0b9();
		while (x7450cc1e48712286.x152cbadbfa8061b1("legendEntry"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "delete":
				xe34702c565a0b0b.xddae736767606eb7 = x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true);
				break;
			case "idx":
				xe34702c565a0b0b.xd1bdf42207dd3638 = x7450cc1e48712286.xe8602379c60acf13("val", 0);
				break;
			case "txPr":
				x10a86a9a76e8d159(x7450cc1e48712286, xe34702c565a0b0b.x68955bfadd010132);
				break;
			case "extLst":
				x10576afa17ca4f1f();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
		return xe34702c565a0b0b;
	}

	internal xe15473b865b55695 xd23f31c92a73f2bf(xc1dcd6189d01216e x97bf2eeabd4abc7b)
	{
		x4c28ef76f151d171(x97bf2eeabd4abc7b);
		xe15473b865b55695 xe15473b865b = new xe15473b865b55695();
		while (x7450cc1e48712286.x152cbadbfa8061b1("pivotFmts"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f) != null && xa66385d80d4d296f == "pivotFmt")
			{
				xe15473b865b.x9a4a145ea33d9506(x720aeaf443383f8e());
			}
			else
			{
				xf4732ad4641eec1a();
			}
		}
		return xe15473b865b;
	}

	private x5d9d8b75dcfd4b2a x720aeaf443383f8e()
	{
		x5d9d8b75dcfd4b2a x5d9d8b75dcfd4b2a = new x5d9d8b75dcfd4b2a();
		while (x7450cc1e48712286.x152cbadbfa8061b1("pivotFmt"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "dLbl":
				x5d9d8b75dcfd4b2a.x1ba4be9af2569407 = xaa230f98336550e4(null);
				break;
			case "idx":
				x5d9d8b75dcfd4b2a.xd1bdf42207dd3638 = x7450cc1e48712286.xe8602379c60acf13("val", 0);
				break;
			case "marker":
				xbb7293042d07981e(x7450cc1e48712286, x5d9d8b75dcfd4b2a.x94e4690631260a6c);
				break;
			case "spPr":
				xdb3e183f8621de35(x7450cc1e48712286, x5d9d8b75dcfd4b2a.xff13b489d81606b6);
				break;
			case "txPr":
				x10a86a9a76e8d159(x7450cc1e48712286, x5d9d8b75dcfd4b2a.x68955bfadd010132);
				break;
			case "extLst":
				x10576afa17ca4f1f();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
		return x5d9d8b75dcfd4b2a;
	}

	internal x8dc475e03526d485 x74b66bef66075fa2(xc1dcd6189d01216e x97bf2eeabd4abc7b)
	{
		x4c28ef76f151d171(x97bf2eeabd4abc7b);
		x8dc475e03526d485 x8dc475e03526d = new x8dc475e03526d485();
		while (x7450cc1e48712286.x152cbadbfa8061b1("view3D"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "depthPercent":
				x8dc475e03526d.x97d96deb07a0f1ad = x7450cc1e48712286.xe8602379c60acf13("val", 100);
				break;
			case "hPercent":
				x8dc475e03526d.xd6c3d726e3325504 = x7450cc1e48712286.xe8602379c60acf13("val", 100);
				break;
			case "perspective":
				x8dc475e03526d.xc763939d67f58562 = x7450cc1e48712286.xe8602379c60acf13("val", 30);
				break;
			case "rAngAx":
				x8dc475e03526d.x99332444d64a9332 = x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true);
				break;
			case "rotX":
				x8dc475e03526d.x2f313bde5dfa58da = x7450cc1e48712286.xe8602379c60acf13("val", 0);
				break;
			case "rotY":
				x8dc475e03526d.xd5e9cb6136107a2a = x7450cc1e48712286.xe8602379c60acf13("val", 0);
				break;
			case "extLst":
				x10576afa17ca4f1f();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
		return x8dc475e03526d;
	}

	internal x4ff4ed4f880a2f4e x9c1d581cfbeb918c(xc1dcd6189d01216e x97bf2eeabd4abc7b)
	{
		x4c28ef76f151d171(x97bf2eeabd4abc7b);
		x4ff4ed4f880a2f4e x4ff4ed4f880a2f4e = new x4ff4ed4f880a2f4e();
		while (x7450cc1e48712286.x152cbadbfa8061b1("protection"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "chartObject":
				x4ff4ed4f880a2f4e.xc3aed1174d5e1b5c = x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true);
				break;
			case "data":
				x4ff4ed4f880a2f4e.x6b73aa01aa019d3a = x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true);
				break;
			case "formatting":
				x4ff4ed4f880a2f4e.x4eae8f1c9ec0d2ae = x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true);
				break;
			case "selection":
				x4ff4ed4f880a2f4e.x89c5d69cd186f9c0 = x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true);
				break;
			case "userInterface":
				x4ff4ed4f880a2f4e.x8fc48073aa17bd7e = x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true);
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
		return x4ff4ed4f880a2f4e;
	}

	internal xe7173b93ad02d837 x9eed24f8ca8d512d(xc1dcd6189d01216e x97bf2eeabd4abc7b)
	{
		x4c28ef76f151d171(x97bf2eeabd4abc7b);
		xe7173b93ad02d837 xe7173b93ad02d = new xe7173b93ad02d837();
		while (x7450cc1e48712286.x152cbadbfa8061b1("pivotSource"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "fmtId":
				xe7173b93ad02d.x11f221c54c2b65e6 = x7450cc1e48712286.xe8602379c60acf13("val", 0);
				break;
			case "name":
				xe7173b93ad02d.x759aa16c2016a289 = x7450cc1e48712286.x2a1ea9d24e62bf84();
				break;
			case "extLst":
				x10576afa17ca4f1f();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
		return xe7173b93ad02d;
	}

	internal void x060dc8c329d84d3e(xc1dcd6189d01216e x97bf2eeabd4abc7b, x9e516aa6ad78327f x7fe8f4a06a328750)
	{
		x4c28ef76f151d171(x97bf2eeabd4abc7b);
		while (x7450cc1e48712286.x152cbadbfa8061b1("upDownBars"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "downBars":
				xe0bd5a61617214a7(x7450cc1e48712286, x7fe8f4a06a328750.x075ec5dae9abb601);
				break;
			case "gapWidth":
				x7fe8f4a06a328750.x831803cdfcd433fb = x7450cc1e48712286.xe8602379c60acf13("val", 150);
				break;
			case "upBars":
				xe0bd5a61617214a7(x7450cc1e48712286, x7fe8f4a06a328750.x55d773f95f0e9853);
				break;
			case "extLst":
				x10576afa17ca4f1f();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
	}

	internal int[] xee8e28ab035ddfff(xc1dcd6189d01216e x97bf2eeabd4abc7b)
	{
		x4c28ef76f151d171(x97bf2eeabd4abc7b);
		xd8cce4761dc846ee xd8cce4761dc846ee = new xd8cce4761dc846ee();
		while (x7450cc1e48712286.x152cbadbfa8061b1("custSplit"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f) != null && xa66385d80d4d296f == "secondPiePt")
			{
				xd8cce4761dc846ee.xd6b6ed77479ef68c(x7450cc1e48712286.xe8602379c60acf13("val", 0));
			}
			else
			{
				xf4732ad4641eec1a();
			}
		}
		return xd8cce4761dc846ee.x543681a74a4a8026();
	}

	internal x805430f606c762d7 x90b6d1adbae0b8a9(xc1dcd6189d01216e x97bf2eeabd4abc7b)
	{
		x4c28ef76f151d171(x97bf2eeabd4abc7b);
		x805430f606c762d7 x805430f606c762d = new x805430f606c762d7();
		while (x7450cc1e48712286.x152cbadbfa8061b1("bandFmts"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f) != null && xa66385d80d4d296f == "bandFmt")
			{
				xcf78fcc841dfb1bd(x805430f606c762d);
			}
			else
			{
				xf4732ad4641eec1a();
			}
		}
		return x805430f606c762d;
	}

	private void xcf78fcc841dfb1bd(x805430f606c762d7 x77a058ea35f56089)
	{
		int xc0c4c459c6ccbd = 0;
		xbc46977eebea4733 x82f66163e01f713f = new xbc46977eebea4733();
		while (x7450cc1e48712286.x152cbadbfa8061b1("bandFmt"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "idx":
				xc0c4c459c6ccbd = x7450cc1e48712286.xe8602379c60acf13("val", 0);
				break;
			case "spPr":
				xdb3e183f8621de35(x7450cc1e48712286, x82f66163e01f713f);
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
		x77a058ea35f56089.x9a4a145ea33d9506(xc0c4c459c6ccbd, x82f66163e01f713f);
	}

	internal xb2e8360ba85c2d52 x38b6dacdc626b4cf(xc1dcd6189d01216e x97bf2eeabd4abc7b)
	{
		x4c28ef76f151d171(x97bf2eeabd4abc7b);
		xb2e8360ba85c2d52 xb2e8360ba85c2d = new xb2e8360ba85c2d52();
		while (x7450cc1e48712286.x152cbadbfa8061b1("dTable"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "showHorzBorder":
				xb2e8360ba85c2d.x88cfb1b4c2288488 = x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true);
				break;
			case "showKeys":
				xb2e8360ba85c2d.x42dcd6609fc9cec8 = x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true);
				break;
			case "showOutline":
				xb2e8360ba85c2d.x293fc213b2d80aca = x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true);
				break;
			case "showVertBorder":
				xb2e8360ba85c2d.xa71150d6f38375fa = x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true);
				break;
			case "spPr":
				xdb3e183f8621de35(x7450cc1e48712286, xb2e8360ba85c2d.xff13b489d81606b6);
				break;
			case "txPr":
				x10a86a9a76e8d159(x7450cc1e48712286, xb2e8360ba85c2d.x68955bfadd010132);
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
		return xb2e8360ba85c2d;
	}

	internal x6658752ba74ace0e x8ca3aa0fb7666a84(xc1dcd6189d01216e x97bf2eeabd4abc7b)
	{
		x4c28ef76f151d171(x97bf2eeabd4abc7b);
		string xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f;
		x6658752ba74ace0e x6658752ba74ace0e = new x6658752ba74ace0e();
		while (x7450cc1e48712286.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "thickness":
				x6658752ba74ace0e.xa247dce22e4a77d5 = x7450cc1e48712286.xe8602379c60acf13("val", 0);
				break;
			case "pictureOptions":
				x6658752ba74ace0e.xe8bac1dbc351535e = x22ce600774330d01(x7450cc1e48712286);
				break;
			case "spPr":
				xdb3e183f8621de35(x7450cc1e48712286, x6658752ba74ace0e.xff13b489d81606b6);
				break;
			case "extLst":
				x10576afa17ca4f1f();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
		return x6658752ba74ace0e;
	}

	internal xdd882e9431b5e6e2 xbcea82b01777a36c(xc1dcd6189d01216e x97bf2eeabd4abc7b)
	{
		x4c28ef76f151d171(x97bf2eeabd4abc7b);
		xdd882e9431b5e6e2 xdd882e9431b5e6e = new xdd882e9431b5e6e2();
		while (x7450cc1e48712286.x152cbadbfa8061b1("title"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "layout":
				xdd882e9431b5e6e.xb7ae55095fddecd9 = x258b75baa7766b96(x7450cc1e48712286);
				break;
			case "overlay":
				xdd882e9431b5e6e.x3f5e31045e967a38 = x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true);
				break;
			case "spPr":
				xdd882e9431b5e6e.xff13b489d81606b6 = new xbc46977eebea4733();
				xdb3e183f8621de35(x7450cc1e48712286, xdd882e9431b5e6e.xff13b489d81606b6);
				break;
			case "tx":
				xdd882e9431b5e6e.x470ecea91abfd1aa = xcd243b41cbaea5ef(x7450cc1e48712286);
				break;
			case "txPr":
				x10a86a9a76e8d159(x7450cc1e48712286, xdd882e9431b5e6e.x68955bfadd010132);
				break;
			case "extLst":
				x10576afa17ca4f1f();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
		return xdd882e9431b5e6e;
	}

	internal x21d9958084c0e7e8 xb701216be6c44a7c(xc1dcd6189d01216e x97bf2eeabd4abc7b)
	{
		x4c28ef76f151d171(x97bf2eeabd4abc7b);
		x21d9958084c0e7e8 x21d9958084c0e7e = new x21d9958084c0e7e8();
		while (x7450cc1e48712286.x1ac1960adc8c4c39())
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "formatCode":
				x21d9958084c0e7e.xfc954f23e7c18656 = x7450cc1e48712286.xd2f68ee6f47e9dfb;
				break;
			case "sourceLinked":
				x21d9958084c0e7e.xd5158638b0d5c9ca = x7450cc1e48712286.xc3be6b142c6aca84;
				break;
			default:
				x31b781f807fd2607();
				break;
			}
		}
		return x21d9958084c0e7e;
	}

	internal xd6ea85977727e1be x87e3c40d67cf7919(xc1dcd6189d01216e x97bf2eeabd4abc7b)
	{
		x4c28ef76f151d171(x97bf2eeabd4abc7b);
		xd6ea85977727e1be xd6ea85977727e1be = new xd6ea85977727e1be();
		while (x7450cc1e48712286.x152cbadbfa8061b1("scaling"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "logBase":
				xd6ea85977727e1be.x960080f788488d56 = x7450cc1e48712286.x075a63114fe24ce9("val", 0.0);
				break;
			case "max":
				xd6ea85977727e1be.x9f4c543928c73298 = x7450cc1e48712286.x075a63114fe24ce9("val", 0.0);
				break;
			case "min":
				xd6ea85977727e1be.xf41d956c067e2b4d = x7450cc1e48712286.x075a63114fe24ce9("val", 0.0);
				break;
			case "orientation":
				xd6ea85977727e1be.x2c5926113e101674 = xa74237a39984bb17.x283215c11a004bf9(x7450cc1e48712286.xd68abcd61e368af9("val", "minMax"));
				break;
			case "extLst":
				x10576afa17ca4f1f();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
		return xd6ea85977727e1be;
	}

	internal xda1cfad5ecff9d87 x031e0e5ffb5cf948(xc1dcd6189d01216e x97bf2eeabd4abc7b)
	{
		x4c28ef76f151d171(x97bf2eeabd4abc7b);
		xda1cfad5ecff9d87 xda1cfad5ecff9d = new xda1cfad5ecff9d87();
		while (x7450cc1e48712286.x152cbadbfa8061b1("dispUnits"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "builtInUnit":
				xda1cfad5ecff9d.x1654966dffbdc3c4 = xa74237a39984bb17.xe92ad2511c5a8dad(x7450cc1e48712286.xd68abcd61e368af9("val", "thousands"));
				break;
			case "custUnit":
				xda1cfad5ecff9d.x4aae70bf9828318c = x7450cc1e48712286.x075a63114fe24ce9("val", 0.0);
				break;
			case "dispUnitsLbl":
				xda1cfad5ecff9d.xf33dd67d2eb47a1c = x62031a38b16562a8();
				break;
			case "extLst":
				x10576afa17ca4f1f();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
		return xda1cfad5ecff9d;
	}

	private x2fbc1ab2cd13f0e2 x62031a38b16562a8()
	{
		x2fbc1ab2cd13f0e2 x2fbc1ab2cd13f0e = new x2fbc1ab2cd13f0e2();
		while (x7450cc1e48712286.x152cbadbfa8061b1("dispUnitsLbl"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "layout":
				x2fbc1ab2cd13f0e.xb7ae55095fddecd9 = x258b75baa7766b96(x7450cc1e48712286);
				break;
			case "spPr":
				xdb3e183f8621de35(x7450cc1e48712286, x2fbc1ab2cd13f0e.xff13b489d81606b6);
				break;
			case "tx":
				x2fbc1ab2cd13f0e.x470ecea91abfd1aa = xcd243b41cbaea5ef(x7450cc1e48712286);
				break;
			case "txPr":
				x10a86a9a76e8d159(x7450cc1e48712286, x2fbc1ab2cd13f0e.x68955bfadd010132);
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
		return x2fbc1ab2cd13f0e;
	}

	internal xa4d912a00c540cf0 x258b75baa7766b96(xc1dcd6189d01216e x97bf2eeabd4abc7b)
	{
		x4c28ef76f151d171(x97bf2eeabd4abc7b);
		xa4d912a00c540cf0 xa4d912a00c540cf = null;
		while (x7450cc1e48712286.x152cbadbfa8061b1("layout"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "manualLayout":
				xa4d912a00c540cf = new xa4d912a00c540cf0();
				x62d9d4ace55176d9(xa4d912a00c540cf);
				break;
			case "extLst":
				x10576afa17ca4f1f();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
		return xa4d912a00c540cf;
	}

	private void x62d9d4ace55176d9(xa4d912a00c540cf0 x2612f62f94df47de)
	{
		while (x7450cc1e48712286.x152cbadbfa8061b1("manualLayout"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "h":
				x2612f62f94df47de.xb0f146032f47c24e = x7450cc1e48712286.x075a63114fe24ce9("val", 0.0);
				break;
			case "w":
				x2612f62f94df47de.xdc1bf80853046136 = x7450cc1e48712286.x075a63114fe24ce9("val", 0.0);
				break;
			case "x":
				x2612f62f94df47de.x72d92bd1aff02e37 = x7450cc1e48712286.x075a63114fe24ce9("val", 0.0);
				break;
			case "y":
				x2612f62f94df47de.xe360b1885d8d4a41 = x7450cc1e48712286.x075a63114fe24ce9("val", 0.0);
				break;
			case "hMode":
				x2612f62f94df47de.x940b2e5d94bf3627 = xa74237a39984bb17.xdb8107f9a0fe6176(x7450cc1e48712286.xd68abcd61e368af9("val", "factor"));
				break;
			case "wMode":
				x2612f62f94df47de.x076d70d185480532 = xa74237a39984bb17.xdb8107f9a0fe6176(x7450cc1e48712286.xd68abcd61e368af9("val", "factor"));
				break;
			case "xMode":
				x2612f62f94df47de.x444021c3ac51dc7d = xa74237a39984bb17.xdb8107f9a0fe6176(x7450cc1e48712286.xd68abcd61e368af9("val", "factor"));
				break;
			case "yMode":
				x2612f62f94df47de.xc1e5c23a8b528a7b = xa74237a39984bb17.xdb8107f9a0fe6176(x7450cc1e48712286.xd68abcd61e368af9("val", "factor"));
				break;
			case "layoutTarget":
				x2612f62f94df47de.xf82c96da969931d7 = xa74237a39984bb17.x4cbd02dfaa6a462f(x7450cc1e48712286.xd68abcd61e368af9("val", "outer"));
				break;
			case "extLst":
				x10576afa17ca4f1f();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
	}

	internal xc19947e71bdbe16a xcd243b41cbaea5ef(xc1dcd6189d01216e x97bf2eeabd4abc7b)
	{
		x4c28ef76f151d171(x97bf2eeabd4abc7b);
		xc19947e71bdbe16a xc19947e71bdbe16a = new xc19947e71bdbe16a();
		while (x7450cc1e48712286.x152cbadbfa8061b1("tx"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "rich":
				xc19947e71bdbe16a.x71826a9cb7f893e0 = new x4e987a76388726b5();
				xd98a1954620007f2.x56bdb6196ee0db92(x7450cc1e48712286, xc19947e71bdbe16a.x71826a9cb7f893e0, "rich");
				break;
			case "v":
				xc19947e71bdbe16a.x08c5d9f4b0653c8d = x7450cc1e48712286.x2a1ea9d24e62bf84();
				break;
			case "strRef":
				xc19947e71bdbe16a.x7f54fb2d3a2bf08f = xe232c59fcf8375d5(x7450cc1e48712286);
				break;
			case "extLst":
				x10576afa17ca4f1f();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
		return xc19947e71bdbe16a;
	}

	internal x66db231de95e4103 xe232c59fcf8375d5(xc1dcd6189d01216e x97bf2eeabd4abc7b)
	{
		x4c28ef76f151d171(x97bf2eeabd4abc7b);
		string xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f;
		x66db231de95e4103 x66db231de95e = new x66db231de95e4103();
		while (x7450cc1e48712286.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "f":
				x66db231de95e.x40937ad35b1cf5f7 = x7450cc1e48712286.x2a1ea9d24e62bf84();
				break;
			case "strCache":
				x66db231de95e.xb730a77005d16cc1 = new xecb835beef9d8f87(xd620087af5172910.x4a498a651d07aefe, isCache: true);
				x578e9f5bc7c40a7f(x7450cc1e48712286, x66db231de95e.xb730a77005d16cc1);
				break;
			case "numCache":
				x66db231de95e.xb730a77005d16cc1 = new xecb835beef9d8f87(xd620087af5172910.xdad37f621665da16, isCache: true);
				x578e9f5bc7c40a7f(x7450cc1e48712286, x66db231de95e.xb730a77005d16cc1);
				break;
			case "extLst":
				x10576afa17ca4f1f();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
		return x66db231de95e;
	}

	internal void x578e9f5bc7c40a7f(xc1dcd6189d01216e x97bf2eeabd4abc7b, xecb835beef9d8f87 x4a3f0a05c02f235f)
	{
		x4c28ef76f151d171(x97bf2eeabd4abc7b);
		string xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f;
		while (x7450cc1e48712286.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "formatCode":
				x4a3f0a05c02f235f.xfc954f23e7c18656 = x7450cc1e48712286.x2a1ea9d24e62bf84();
				break;
			case "ptCount":
				x4a3f0a05c02f235f.x2205bab75ecf5743 = x7450cc1e48712286.xe8602379c60acf13("val", 0);
				break;
			case "pt":
				x4a3f0a05c02f235f.x2f72b9643ccd1483(x1e4c72868be245bb(x7450cc1e48712286, x4a3f0a05c02f235f.x2bd4228892f25674));
				break;
			case "extLst":
				x10576afa17ca4f1f();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
		if (x4a3f0a05c02f235f.x2bd4228892f25674 != xd620087af5172910.xdad37f621665da16)
		{
			return;
		}
		foreach (DictionaryEntry item in x4a3f0a05c02f235f.x320382c5f1993a78)
		{
			x8feaf55aff422186 x8feaf55aff = (x8feaf55aff422186)item.Value;
			if (!x0d299f323d241756.x5959bccb67bbf051(x8feaf55aff.xfc954f23e7c18656))
			{
				x8feaf55aff.xfc954f23e7c18656 = x4a3f0a05c02f235f.xfc954f23e7c18656;
			}
		}
	}

	internal x86270791cf6a92b9 x1e4c72868be245bb(xc1dcd6189d01216e x97bf2eeabd4abc7b, xd620087af5172910 xa16337f6a677a976)
	{
		x4c28ef76f151d171(x97bf2eeabd4abc7b);
		int index = 0;
		string text = null;
		string formatCode = null;
		while (x7450cc1e48712286.x1ac1960adc8c4c39())
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "idx":
				index = x7450cc1e48712286.xbba6773b8ce56a01;
				break;
			case "formatCode":
				formatCode = x7450cc1e48712286.xd2f68ee6f47e9dfb;
				break;
			default:
				x31b781f807fd2607();
				break;
			}
		}
		while (x7450cc1e48712286.x152cbadbfa8061b1("pt"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f) != null && xa66385d80d4d296f == "v")
			{
				text = x7450cc1e48712286.x2a1ea9d24e62bf84();
			}
			else
			{
				xf4732ad4641eec1a();
			}
		}
		if (xa16337f6a677a976 == xd620087af5172910.x4a498a651d07aefe)
		{
			return new xe03d2abcf7f758c8(index, text);
		}
		return new x8feaf55aff422186(index, xca004f56614e2431.xec25d08a2af152f0(text), formatCode);
	}

	internal x0c3d704ad3ea61a6 x8e81b2684ac6e6cb(xc1dcd6189d01216e x97bf2eeabd4abc7b)
	{
		x4c28ef76f151d171(x97bf2eeabd4abc7b);
		x0c3d704ad3ea61a6 x0c3d704ad3ea61a = new x0c3d704ad3ea61a6();
		while (x7450cc1e48712286.x152cbadbfa8061b1("dPt"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "bubble3D":
				x0c3d704ad3ea61a.x3c1388d994dacf98 = x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true);
				break;
			case "explosion":
				x0c3d704ad3ea61a.xebda71a9872c4199 = x7450cc1e48712286.xe8602379c60acf13("val", 0);
				break;
			case "idx":
				x0c3d704ad3ea61a.xd1bdf42207dd3638 = x7450cc1e48712286.xe8602379c60acf13("val", 0);
				break;
			case "invertIfNegative":
				x0c3d704ad3ea61a.xdf98802769bccae1 = x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true);
				break;
			case "marker":
				xbb7293042d07981e(x7450cc1e48712286, x0c3d704ad3ea61a.x94e4690631260a6c);
				break;
			case "pictureOptions":
				x0c3d704ad3ea61a.xe8bac1dbc351535e = x22ce600774330d01(x7450cc1e48712286);
				break;
			case "spPr":
				xdb3e183f8621de35(x7450cc1e48712286, x0c3d704ad3ea61a.xff13b489d81606b6);
				break;
			case "extLst":
				x10576afa17ca4f1f();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
		return x0c3d704ad3ea61a;
	}

	internal xff5cc67819def9b7 x22ce600774330d01(xc1dcd6189d01216e x97bf2eeabd4abc7b)
	{
		x4c28ef76f151d171(x97bf2eeabd4abc7b);
		xff5cc67819def9b7 xff5cc67819def9b = new xff5cc67819def9b7();
		while (x7450cc1e48712286.x152cbadbfa8061b1("pictureOptions"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "applyToEnd":
				xff5cc67819def9b.x6a7b38eb6f2fa6e0 = x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true);
				break;
			case "applyToFront":
				xff5cc67819def9b.x4af2bc59e86431bd = x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true);
				break;
			case "applyToSides":
				xff5cc67819def9b.x55cd2c5932f93e00 = x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true);
				break;
			case "pictureFormat":
				xff5cc67819def9b.x26e4066e766a12fb = xa74237a39984bb17.xb35310044b8d1c0b(x7450cc1e48712286.xd68abcd61e368af9("val", "stack"));
				break;
			case "pictureStackUnit":
				xff5cc67819def9b.x2c6fb74c67b3820d = x7450cc1e48712286.x075a63114fe24ce9("val", 0.0);
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
		return xff5cc67819def9b;
	}

	internal void xbb7293042d07981e(xc1dcd6189d01216e x97bf2eeabd4abc7b, x75e9035a551c2be0 x8f2400368d1c57d3)
	{
		x4c28ef76f151d171(x97bf2eeabd4abc7b);
		while (x7450cc1e48712286.x152cbadbfa8061b1("marker"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "size":
				x8f2400368d1c57d3.x437e3b626c0fdd43 = x7450cc1e48712286.xe8602379c60acf13("val", 5);
				break;
			case "spPr":
				xdb3e183f8621de35(x7450cc1e48712286, x8f2400368d1c57d3.xff13b489d81606b6);
				break;
			case "symbol":
				x8f2400368d1c57d3.xe59d6d35c76d70aa = xa74237a39984bb17.x9ee686254fb28415(x7450cc1e48712286.xd68abcd61e368af9("val", "none"));
				break;
			case "extLst":
				x10576afa17ca4f1f();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
	}

	internal x823fa53f2dab6113 xce0a40b060410331(xc1dcd6189d01216e x97bf2eeabd4abc7b)
	{
		x4c28ef76f151d171(x97bf2eeabd4abc7b);
		x823fa53f2dab6113 x823fa53f2dab = new x823fa53f2dab6113();
		while (x7450cc1e48712286.x152cbadbfa8061b1("dLbls"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "delete":
			case "dLblPos":
			case "extLst":
			case "numFmt":
			case "separator":
			case "showBubbleSize":
			case "showCatName":
			case "showLeaderLines":
			case "showLegendKey":
			case "showPercent":
			case "showSerName":
			case "showVal":
			case "spPr":
			case "txPr":
				x988c5d121791956c(x823fa53f2dab.xcb206619fc01443e);
				break;
			case "leaderLines":
				xe0bd5a61617214a7(x7450cc1e48712286, x823fa53f2dab.x053e2adc77e5fc15);
				break;
			case "dLbl":
				x823fa53f2dab.x2e4f0a067330469e(xaa230f98336550e4(x823fa53f2dab.xcb206619fc01443e));
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
		return x823fa53f2dab;
	}

	private xb01d463bc99ce68a xaa230f98336550e4(x1e22341de8ed5c6f x20ba1498dc0b4040)
	{
		xb01d463bc99ce68a xb01d463bc99ce68a = new xb01d463bc99ce68a(x20ba1498dc0b4040);
		while (x7450cc1e48712286.x152cbadbfa8061b1("dLbl"))
		{
			x988c5d121791956c(xb01d463bc99ce68a.xcb206619fc01443e);
		}
		return xb01d463bc99ce68a;
	}

	private void x988c5d121791956c(x1e22341de8ed5c6f xf423d643bc10c351)
	{
		switch (x7450cc1e48712286.xa66385d80d4d296f)
		{
		case "delete":
			xf423d643bc10c351.x9b050884457cf3b5(x6ebd70866a648fda.xddae736767606eb7, x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true));
			break;
		case "dLblPos":
			xf423d643bc10c351.x9b050884457cf3b5(x6ebd70866a648fda.xa3b7492a07af7973, xa74237a39984bb17.xfa293766957b2441(x7450cc1e48712286.xd68abcd61e368af9("val", "center")));
			break;
		case "idx":
			xf423d643bc10c351.x9b050884457cf3b5(x6ebd70866a648fda.x693a1249a29573a3, x7450cc1e48712286.xe8602379c60acf13("val", 0));
			break;
		case "layout":
			xf423d643bc10c351.x9b050884457cf3b5(x6ebd70866a648fda.xb7ae55095fddecd9, x258b75baa7766b96(x7450cc1e48712286));
			break;
		case "numFmt":
			xf423d643bc10c351.x9b050884457cf3b5(x6ebd70866a648fda.x681e77d00e298fba, xb701216be6c44a7c(x7450cc1e48712286));
			break;
		case "separator":
			xf423d643bc10c351.x9b050884457cf3b5(x6ebd70866a648fda.x43604484a3deae4f, x7450cc1e48712286.x2a1ea9d24e62bf84());
			break;
		case "showBubbleSize":
			xf423d643bc10c351.x9b050884457cf3b5(x6ebd70866a648fda.x773fea653806f88b, x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true));
			break;
		case "showCatName":
			xf423d643bc10c351.x9b050884457cf3b5(x6ebd70866a648fda.x4f8a205882b769df, x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true));
			break;
		case "showLegendKey":
			xf423d643bc10c351.x9b050884457cf3b5(x6ebd70866a648fda.x092d26b1ea2b8a90, x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true));
			break;
		case "showPercent":
			xf423d643bc10c351.x9b050884457cf3b5(x6ebd70866a648fda.x08ac955359d8b9ff, x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true));
			break;
		case "showSerName":
			xf423d643bc10c351.x9b050884457cf3b5(x6ebd70866a648fda.xf555ad48350132bd, x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true));
			break;
		case "showVal":
			xf423d643bc10c351.x9b050884457cf3b5(x6ebd70866a648fda.xa0f27b65acb3dff1, x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true));
			break;
		case "spPr":
		{
			xbc46977eebea4733 xbc46977eebea = new xbc46977eebea4733();
			xdb3e183f8621de35(x7450cc1e48712286, xbc46977eebea);
			xf423d643bc10c351.x9b050884457cf3b5(x6ebd70866a648fda.xff13b489d81606b6, xbc46977eebea);
			break;
		}
		case "tx":
			xf423d643bc10c351.x9b050884457cf3b5(x6ebd70866a648fda.x470ecea91abfd1aa, xcd243b41cbaea5ef(x7450cc1e48712286));
			break;
		case "txPr":
		{
			x4694a3400bb4849a x4694a3400bb4849a = new x4694a3400bb4849a();
			x10a86a9a76e8d159(x7450cc1e48712286, x4694a3400bb4849a);
			xf423d643bc10c351.x9b050884457cf3b5(x6ebd70866a648fda.x68955bfadd010132, x4694a3400bb4849a);
			break;
		}
		case "extLst":
			x10576afa17ca4f1f();
			break;
		default:
			xf4732ad4641eec1a();
			break;
		}
	}

	internal xb8d58828598599c8 xdb2946fc55600c0b(xc1dcd6189d01216e x97bf2eeabd4abc7b)
	{
		x4c28ef76f151d171(x97bf2eeabd4abc7b);
		xb8d58828598599c8 xb8d58828598599c = new xb8d58828598599c8();
		while (x7450cc1e48712286.x152cbadbfa8061b1("errBars"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "errBarType":
				xb8d58828598599c.xfec86a24d96d1b97 = xa74237a39984bb17.x8c3db24c1fdae2dc(x7450cc1e48712286.xd68abcd61e368af9("val", ""));
				break;
			case "errDir":
				xb8d58828598599c.x11276a3dae05a715 = xa74237a39984bb17.xb79d356fd722a71f(x7450cc1e48712286.xd68abcd61e368af9("val", ""));
				break;
			case "errValType":
				xb8d58828598599c.xff726cc703600396 = xa74237a39984bb17.x3a0a1c175f742191(x7450cc1e48712286.xd68abcd61e368af9("val", ""));
				break;
			case "minus":
				xdc3135b3f45b2378(x7450cc1e48712286, xb8d58828598599c.x64a4b7b5c28435a0);
				break;
			case "plus":
				xdc3135b3f45b2378(x7450cc1e48712286, xb8d58828598599c.x7599ce6fe8bedf46);
				break;
			case "noEndCap":
				xb8d58828598599c.x38047fa853a2f1d0 = x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true);
				break;
			case "spPr":
				xdb3e183f8621de35(x7450cc1e48712286, xb8d58828598599c.xff13b489d81606b6);
				break;
			case "val":
				xb8d58828598599c.x4507da4eb3174f16 = x7450cc1e48712286.x075a63114fe24ce9("val", 0.0);
				break;
			case "extLst":
				x10576afa17ca4f1f();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
		return xb8d58828598599c;
	}

	internal void xdc3135b3f45b2378(xc1dcd6189d01216e x97bf2eeabd4abc7b, x6332e4343519e4e6 xef1769c4fe6ae4ca)
	{
		x4c28ef76f151d171(x97bf2eeabd4abc7b);
		string xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f;
		while (x7450cc1e48712286.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "strLit":
				xef1769c4fe6ae4ca.x6b73aa01aa019d3a = new xecb835beef9d8f87(xd620087af5172910.x4a498a651d07aefe, isCache: false);
				x578e9f5bc7c40a7f(x7450cc1e48712286, xef1769c4fe6ae4ca.x6b73aa01aa019d3a);
				break;
			case "numLit":
				xef1769c4fe6ae4ca.x6b73aa01aa019d3a = new xecb835beef9d8f87(xd620087af5172910.xdad37f621665da16, isCache: false);
				x578e9f5bc7c40a7f(x7450cc1e48712286, xef1769c4fe6ae4ca.x6b73aa01aa019d3a);
				break;
			case "strRef":
			case "numRef":
				xef1769c4fe6ae4ca.x172fc2191a800561 = xe232c59fcf8375d5(x7450cc1e48712286);
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
	}

	internal x099ba26e12767fb4 xb26f9d8321d48e4e(xc1dcd6189d01216e x97bf2eeabd4abc7b)
	{
		x4c28ef76f151d171(x97bf2eeabd4abc7b);
		x099ba26e12767fb4 x099ba26e12767fb = new x099ba26e12767fb4();
		while (x7450cc1e48712286.x152cbadbfa8061b1("trendline"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "backward":
				x099ba26e12767fb.xe9634325258d088b = x7450cc1e48712286.x075a63114fe24ce9("val", 0.0);
				break;
			case "dispEq":
				x099ba26e12767fb.x2af3d08775a3c8ec = x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true);
				break;
			case "dispRSqr":
				x099ba26e12767fb.x534462d031711d82 = x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true);
				break;
			case "forward":
				x099ba26e12767fb.xd4a82970ba6be033 = x7450cc1e48712286.x075a63114fe24ce9("val", 0.0);
				break;
			case "intercept":
				x099ba26e12767fb.x10794c5dd5bef549 = x7450cc1e48712286.x075a63114fe24ce9("val", 0.0);
				break;
			case "name":
				x099ba26e12767fb.x759aa16c2016a289 = x7450cc1e48712286.x2a1ea9d24e62bf84();
				break;
			case "order":
				x099ba26e12767fb.x4af6b6f55aeb44a7 = x7450cc1e48712286.xe8602379c60acf13("val", 0);
				break;
			case "period":
				x099ba26e12767fb.x136412bb3a52aead = x7450cc1e48712286.xe8602379c60acf13("val", 0);
				break;
			case "spPr":
				xdb3e183f8621de35(x7450cc1e48712286, x099ba26e12767fb.xff13b489d81606b6);
				break;
			case "trendlineLbl":
				x099ba26e12767fb.xb934cd9e25c816ac = xe4d54be26428b3b8();
				break;
			case "trendlineType":
				x099ba26e12767fb.x3e14cdc6ca519fbb = xa74237a39984bb17.xa24864ec18987020(x7450cc1e48712286.xd68abcd61e368af9("val", ""));
				break;
			case "extLst":
				x10576afa17ca4f1f();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
		return x099ba26e12767fb;
	}

	private x2fef938a557c2fc6 xe4d54be26428b3b8()
	{
		x2fef938a557c2fc6 x2fef938a557c2fc = new x2fef938a557c2fc6();
		while (x7450cc1e48712286.x152cbadbfa8061b1("trendlineLbl"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "layout":
				x2fef938a557c2fc.xb7ae55095fddecd9 = x258b75baa7766b96(x7450cc1e48712286);
				break;
			case "numFmt":
				x2fef938a557c2fc.x681e77d00e298fba = xb701216be6c44a7c(x7450cc1e48712286);
				break;
			case "spPr":
				xdb3e183f8621de35(x7450cc1e48712286, x2fef938a557c2fc.xff13b489d81606b6);
				break;
			case "tx":
				x2fef938a557c2fc.x470ecea91abfd1aa = xcd243b41cbaea5ef(x7450cc1e48712286);
				break;
			case "txPr":
				x10a86a9a76e8d159(x7450cc1e48712286, x2fef938a557c2fc.x68955bfadd010132);
				break;
			case "extLst":
				x10576afa17ca4f1f();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
		return x2fef938a557c2fc;
	}
}
