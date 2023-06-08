using System.Collections;
using System.Drawing.Drawing2D;
using x0a3ff9616df4cd36;
using x6b8130194ad714f7;
using x6c95d9cf46ff5f25;
using x8b1f7613579e78d0;
using x8bb6b4f09b5230a5;

namespace x95bd05bb616368d3;

internal class x53230d9c3453c662 : xaaf059f0543cf507, xcac04f3919526f00
{
	private xaeaeae8d38ef57bb x827e895033b76e5e;

	private xe84bd94b5d81933a x536bbb2735481b86;

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
		set
		{
			x827e895033b76e5e = value;
		}
	}

	internal xe84bd94b5d81933a xb210ec9504f4f006
	{
		get
		{
			if (x536bbb2735481b86 == null)
			{
				x536bbb2735481b86 = new x6ffdac909b261358(base.xca687bd498227c89);
			}
			return x536bbb2735481b86;
		}
		set
		{
			x536bbb2735481b86 = value;
		}
	}

	public x53230d9c3453c662(xe9481907c579c280 serviceLocator)
		: base(serviceLocator)
	{
	}

	public x48d7478d49393961 xda09af88ab899a50(xc1dcd6189d01216e xe134235b3526fa75)
	{
		x4c28ef76f151d171(xe134235b3526fa75);
		switch (xe134235b3526fa75.xa66385d80d4d296f)
		{
		case "blipFill":
			return x48669f9ff482fccd();
		case "gradFill":
			return x65b7758b8c5f11ec();
		case "grpFill":
			return x9d4838c1bceac36b();
		case "noFill":
			return xe0015ad7c8d1889d();
		case "pattFill":
			return x15df8edc4e8eb98d();
		case "solidFill":
			return x57ee4f86a80a3fdc();
		default:
			xf4732ad4641eec1a();
			return null;
		}
	}

	private x5769e10b2cd725ea x57ee4f86a80a3fdc()
	{
		x5769e10b2cd725ea x5769e10b2cd725ea = new x5769e10b2cd725ea();
		x5769e10b2cd725ea.x9b41425268471380 = xd98b6fc8af69e348.x07d1b52af8293592(x7450cc1e48712286);
		return x5769e10b2cd725ea;
	}

	private x2428dc5376b9008e x15df8edc4e8eb98d()
	{
		x2428dc5376b9008e x2428dc5376b9008e = new x2428dc5376b9008e();
		x2428dc5376b9008e.x2a59303840dae913 = x9d33c8505fc2bd8a();
		while (x7450cc1e48712286.x152cbadbfa8061b1("pattFill"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "bgClr":
				x2428dc5376b9008e.x83729c7ebf48ae24 = xd98b6fc8af69e348.x07d1b52af8293592(x7450cc1e48712286);
				break;
			case "fgClr":
				x2428dc5376b9008e.x8fdbd80e8da6b0e6 = xd98b6fc8af69e348.x07d1b52af8293592(x7450cc1e48712286);
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
		return x2428dc5376b9008e;
	}

	private xcffce73ccb792506 xe0015ad7c8d1889d()
	{
		return new xcffce73ccb792506();
	}

	private x87c4c4fc74c6df41 x9d4838c1bceac36b()
	{
		return new x87c4c4fc74c6df41();
	}

	private x33ed2713f0bb8cae x65b7758b8c5f11ec()
	{
		x33ed2713f0bb8cae x33ed2713f0bb8cae = new x33ed2713f0bb8cae();
		x33ed2713f0bb8cae.x29461430415ce5f3 = x3684797450db1a6e();
		x33ed2713f0bb8cae.x3012fceed1fc4fbf = x7450cc1e48712286.x9c1302ecb6c4f3a2("rotWithShape", xc6e85c82d0d89508: false);
		while (x7450cc1e48712286.x152cbadbfa8061b1("gradFill"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "gsLst":
				x33ed2713f0bb8cae.xba3e7a0e3e0e3ebc = xd1196f47d1b172eb();
				break;
			case "lin":
				x33ed2713f0bb8cae.xfa366f41892e9371 = x29ebafc5e037606b();
				break;
			case "path":
				x33ed2713f0bb8cae.xfa366f41892e9371 = x6ed02df07526f47c();
				break;
			case "tileRect":
				x33ed2713f0bb8cae.xe6ea8e6898268fd2 = xce3c09cde0e46be7();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
		return x33ed2713f0bb8cae;
	}

	private x50b6cdb932694b79 x6ed02df07526f47c()
	{
		x50b6cdb932694b79 x50b6cdb932694b = new x50b6cdb932694b79();
		x50b6cdb932694b.x632b457a1248cdb1 = xbb4de6cdadf368ca();
		while (x7450cc1e48712286.x152cbadbfa8061b1("path"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f) != null && xa66385d80d4d296f == "fillToRect")
			{
				x50b6cdb932694b.x0d779425940e20c1 = xce3c09cde0e46be7();
			}
			else
			{
				xf4732ad4641eec1a();
			}
		}
		return x50b6cdb932694b;
	}

	private x60eea316590e7fe7 xce3c09cde0e46be7()
	{
		x60eea316590e7fe7 x60eea316590e7fe = new x60eea316590e7fe7();
		x60eea316590e7fe.xd0fade446b8d532a = new x55c6a66cc28d5b86(x7450cc1e48712286.x075a63114fe24ce9("b", 0.0));
		x60eea316590e7fe.xcdb214dfc38b1be3 = new x55c6a66cc28d5b86(x7450cc1e48712286.x075a63114fe24ce9("t", 0.0));
		x60eea316590e7fe.xc24e3e091abd3197 = new x55c6a66cc28d5b86(x7450cc1e48712286.x075a63114fe24ce9("l", 0.0));
		x60eea316590e7fe.xb50d6cb9d3b61d4d = new x55c6a66cc28d5b86(x7450cc1e48712286.x075a63114fe24ce9("r", 0.0));
		return x60eea316590e7fe;
	}

	private x4e8a02a4da77131a xbb4de6cdadf368ca()
	{
		return x7450cc1e48712286.xd68abcd61e368af9("path", string.Empty) switch
		{
			"shape" => x4e8a02a4da77131a.xa9993ed2e0c64574, 
			"circle" => x4e8a02a4da77131a.x4053bf44f19ab1e2, 
			"rect" => x4e8a02a4da77131a.x404d528fe2f10961, 
			_ => x4e8a02a4da77131a.xa9993ed2e0c64574, 
		};
	}

	private xb13ce62097f50cdd x29ebafc5e037606b()
	{
		xb13ce62097f50cdd xb13ce62097f50cdd = new xb13ce62097f50cdd();
		xb13ce62097f50cdd.x6b1fe03343d9a6a4 = new xd4583a58cd9d2194(x7450cc1e48712286.x075a63114fe24ce9("ang", 0.0));
		xb13ce62097f50cdd.xbeaac435f753b9e3 = x7450cc1e48712286.x9c1302ecb6c4f3a2("scaled", xc6e85c82d0d89508: false);
		return xb13ce62097f50cdd;
	}

	private ArrayList xd1196f47d1b172eb()
	{
		ArrayList arrayList = new ArrayList();
		while (x7450cc1e48712286.x152cbadbfa8061b1("gsLst"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f) != null && xa66385d80d4d296f == "gs")
			{
				arrayList.Add(x0b7c701164852303());
			}
			else
			{
				xf4732ad4641eec1a();
			}
		}
		return arrayList;
	}

	private x33ec819de630e85d x0b7c701164852303()
	{
		x33ec819de630e85d x33ec819de630e85d = new x33ec819de630e85d();
		x33ec819de630e85d.xbe1e23e7d5b43370 = new x55c6a66cc28d5b86(x7450cc1e48712286.x075a63114fe24ce9("pos", 0.0));
		x33ec819de630e85d.x9b41425268471380 = xd98b6fc8af69e348.x07d1b52af8293592(x7450cc1e48712286);
		return x33ec819de630e85d;
	}

	private x89f9bde24c211d60 x3684797450db1a6e()
	{
		return x7450cc1e48712286.xd68abcd61e368af9("flip", string.Empty) switch
		{
			"none" => x89f9bde24c211d60.x4d0b9d4447ba7566, 
			"x" => x89f9bde24c211d60.x3bce7c87328df8da, 
			"y" => x89f9bde24c211d60.x61c108cc44ef385a, 
			"xy" => x89f9bde24c211d60.x79cd51c998aa495c, 
			_ => x89f9bde24c211d60.x4d0b9d4447ba7566, 
		};
	}

	private xb8c0a122dcc2f776 x48669f9ff482fccd()
	{
		xb8c0a122dcc2f776 xb8c0a122dcc2f = new xb8c0a122dcc2f776();
		xb8c0a122dcc2f.xf6a4131d6347f6d5 = (uint)x7450cc1e48712286.xe8602379c60acf13("dpi", 0);
		xb8c0a122dcc2f.x3012fceed1fc4fbf = x7450cc1e48712286.x9c1302ecb6c4f3a2("rotWithShape", xc6e85c82d0d89508: false);
		while (x7450cc1e48712286.x152cbadbfa8061b1("blipFill"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "blip":
				xb8c0a122dcc2f.x90c6e45466e5b849 = xaa3605e01d42e852();
				break;
			case "srcRect":
				xb8c0a122dcc2f.x38f7d62de9bd2349 = xce3c09cde0e46be7();
				break;
			case "stretch":
				xb8c0a122dcc2f.x5817d0e429334953 = x1e743ebff6a845f7();
				break;
			case "tile":
				xb8c0a122dcc2f.x5817d0e429334953 = xf32b1ccaa7430705();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
		return xb8c0a122dcc2f;
	}

	private xac413592182b07a5 xf32b1ccaa7430705()
	{
		xac413592182b07a5 xac413592182b07a = new xac413592182b07a5();
		xac413592182b07a.x9ba359ff37a3a63b = x2c8c2af72259b91d();
		xac413592182b07a.x29461430415ce5f3 = x3684797450db1a6e();
		xac413592182b07a.x9ef4ea518c1e89de = new x55c6a66cc28d5b86(x7450cc1e48712286.x075a63114fe24ce9("sx", 1.0));
		xac413592182b07a.x53b5497e1889efbc = new x55c6a66cc28d5b86(x7450cc1e48712286.x075a63114fe24ce9("sy", 1.0));
		xac413592182b07a.x3e6aca679d27dd62 = x7450cc1e48712286.x075a63114fe24ce9("tx", 0.0);
		xac413592182b07a.xccc150ee96ca9fe4 = x7450cc1e48712286.x075a63114fe24ce9("ty", 0.0);
		return xac413592182b07a;
	}

	private x78cc79ebd76ad5d0 x2c8c2af72259b91d()
	{
		return x7450cc1e48712286.xd68abcd61e368af9("algn", string.Empty) switch
		{
			"tl" => x78cc79ebd76ad5d0.xc3ae914e60da748f, 
			"t" => x78cc79ebd76ad5d0.xe360b1885d8d4a41, 
			"tr" => x78cc79ebd76ad5d0.x46c964a11610fa46, 
			"l" => x78cc79ebd76ad5d0.x72d92bd1aff02e37, 
			"ctr" => x78cc79ebd76ad5d0.x58d2ccae3c5cfd08, 
			"r" => x78cc79ebd76ad5d0.x419ba17a5322627b, 
			"bl" => x78cc79ebd76ad5d0.x2ec8395d97ae50dc, 
			"b" => x78cc79ebd76ad5d0.x9bcb07e204e30218, 
			"br" => x78cc79ebd76ad5d0.xbedfa137d9910ba4, 
			_ => x78cc79ebd76ad5d0.xc3ae914e60da748f, 
		};
	}

	private x3a60f72bd240f5dc x1e743ebff6a845f7()
	{
		x3a60f72bd240f5dc x3a60f72bd240f5dc = new x3a60f72bd240f5dc();
		while (x7450cc1e48712286.x152cbadbfa8061b1("stretch"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f) != null && xa66385d80d4d296f == "fillRect")
			{
				x3a60f72bd240f5dc.x7cfc143904bcbd0a = xce3c09cde0e46be7();
			}
			else
			{
				xf4732ad4641eec1a();
			}
		}
		return x3a60f72bd240f5dc;
	}

	private x241ec192a9b04589 xaa3605e01d42e852()
	{
		x241ec192a9b04589 x241ec192a9b = new x241ec192a9b04589();
		x241ec192a9b.x39a5a0699f625f92 = x3a01de3ba4fca084();
		x241ec192a9b.x04360fd10c29777d = x7450cc1e48712286.xd68abcd61e368af9("embed", string.Empty);
		x241ec192a9b.xc1ac8b0c3628adf0 = x7450cc1e48712286.xd68abcd61e368af9("link", string.Empty);
		x241ec192a9b.x819589f292a61f6b = xddf94d5ce07b3bd3();
		return x241ec192a9b;
	}

	private ArrayList xddf94d5ce07b3bd3()
	{
		ArrayList arrayList = new ArrayList();
		string xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f;
		while (x7450cc1e48712286.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			x506b258dd39c6252 x506b258dd39c = xb210ec9504f4f006.xda09af88ab899a50(x7450cc1e48712286);
			if (x506b258dd39c != null)
			{
				arrayList.Add(x506b258dd39c);
			}
		}
		return arrayList;
	}

	private x6b0a622599ef58fb x3a01de3ba4fca084()
	{
		return x7450cc1e48712286.xd68abcd61e368af9("cstate", string.Empty) switch
		{
			"email" => x6b0a622599ef58fb.xdc30cee9941e0dbd, 
			"screen" => x6b0a622599ef58fb.x9f7568c4b80a093e, 
			"print" => x6b0a622599ef58fb.xe89eb9484e91ad4e, 
			"hqprint" => x6b0a622599ef58fb.x4acdbdd529ca2e0e, 
			"none" => x6b0a622599ef58fb.x4d0b9d4447ba7566, 
			_ => x6b0a622599ef58fb.xdc30cee9941e0dbd, 
		};
	}

	private HatchStyle x9d33c8505fc2bd8a()
	{
		return x7450cc1e48712286.xd68abcd61e368af9("prst", string.Empty) switch
		{
			"pct5" => HatchStyle.Percent05, 
			"pct10" => HatchStyle.Percent10, 
			"pct20" => HatchStyle.Percent20, 
			"pct25" => HatchStyle.Percent25, 
			"pct30" => HatchStyle.Percent30, 
			"pct40" => HatchStyle.Percent40, 
			"pct50" => HatchStyle.Percent50, 
			"pct60" => HatchStyle.Percent60, 
			"pct70" => HatchStyle.Percent70, 
			"pct75" => HatchStyle.Percent75, 
			"pct80" => HatchStyle.Percent80, 
			"pct90" => HatchStyle.Percent90, 
			"horz" => HatchStyle.Horizontal, 
			"vert" => HatchStyle.Vertical, 
			"ltHorz" => HatchStyle.LightHorizontal, 
			"ltVert" => HatchStyle.LightVertical, 
			"dkHorz" => HatchStyle.DarkHorizontal, 
			"dkVert" => HatchStyle.DarkVertical, 
			"narHorz" => HatchStyle.NarrowHorizontal, 
			"narVert" => HatchStyle.NarrowVertical, 
			"dashHorz" => HatchStyle.DashedHorizontal, 
			"dashVert" => HatchStyle.DashedVertical, 
			"cross" => HatchStyle.Cross, 
			"dnDiag" => HatchStyle.BackwardDiagonal, 
			"upDiag" => HatchStyle.ForwardDiagonal, 
			"ltDnDiag" => HatchStyle.LightDownwardDiagonal, 
			"ltUpDiag" => HatchStyle.LightUpwardDiagonal, 
			"dkDnDiag" => HatchStyle.DarkDownwardDiagonal, 
			"dkUpDiag" => HatchStyle.DarkUpwardDiagonal, 
			"wdDnDiag" => HatchStyle.WideDownwardDiagonal, 
			"wdUpDiag" => HatchStyle.WideUpwardDiagonal, 
			"dashDnDiag" => HatchStyle.DashedDownwardDiagonal, 
			"dashUpDiag" => HatchStyle.DashedUpwardDiagonal, 
			"diagCross" => HatchStyle.DiagonalCross, 
			"smCheck" => HatchStyle.SmallCheckerBoard, 
			"lgCheck" => HatchStyle.LargeCheckerBoard, 
			"smGrid" => HatchStyle.SmallGrid, 
			"lgGrid" => HatchStyle.Cross, 
			"dotGrid" => HatchStyle.DottedGrid, 
			"smConfetti" => HatchStyle.SmallConfetti, 
			"lgConfetti" => HatchStyle.LargeConfetti, 
			"horzBrick" => HatchStyle.HorizontalBrick, 
			"diagBrick" => HatchStyle.DiagonalBrick, 
			"solidDmnd" => HatchStyle.SolidDiamond, 
			"openDmnd" => HatchStyle.OutlinedDiamond, 
			"dotDmnd" => HatchStyle.DottedDiamond, 
			"plaid" => HatchStyle.Plaid, 
			"sphere" => HatchStyle.Sphere, 
			"weave" => HatchStyle.Weave, 
			"divot" => HatchStyle.Divot, 
			"shingle" => HatchStyle.Shingle, 
			"wave" => HatchStyle.Wave, 
			"trellis" => HatchStyle.Trellis, 
			"zigZag" => HatchStyle.ZigZag, 
			_ => HatchStyle.Horizontal, 
		};
	}
}
