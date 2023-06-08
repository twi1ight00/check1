using System;
using System.Xml;
using x32a884d842a34446;
using x6c95d9cf46ff5f25;
using x8bb6b4f09b5230a5;
using xad5c68c1ad3b0224;
using xcc8a79815d76af85;
using xf9a9481c3f63a419;

namespace x95bd05bb616368d3;

internal class xcfcf83824997a909 : xaaf059f0543cf507
{
	private xa1cdf97882aaef9a x431c094bb556b3c0;

	private x7f84d4dc848984c4 xbf75d3b5a3503112;

	private x0edd714981d78f57 x4e372ced87b587d6;

	private xd4e66257276c6905 xa0db25b371643a4d;

	private x7f84d4dc848984c4 xa838333cf20f52ea
	{
		get
		{
			if (xbf75d3b5a3503112 == null)
			{
				xbf75d3b5a3503112 = new x7f84d4dc848984c4(base.xca687bd498227c89);
			}
			return xbf75d3b5a3503112;
		}
	}

	private x0edd714981d78f57 xedc591e2115d300f
	{
		get
		{
			if (x4e372ced87b587d6 == null)
			{
				x4e372ced87b587d6 = new x0edd714981d78f57(base.xca687bd498227c89);
			}
			return x4e372ced87b587d6;
		}
	}

	private xa1cdf97882aaef9a xddd9b4b4973d5cc2
	{
		get
		{
			if (x431c094bb556b3c0 == null)
			{
				x431c094bb556b3c0 = new xa1cdf97882aaef9a(base.xca687bd498227c89);
			}
			return x431c094bb556b3c0;
		}
	}

	public xcfcf83824997a909(xe9481907c579c280 serviceLocator)
		: base(serviceLocator)
	{
	}

	internal xd4e66257276c6905 x6326991a5dd21743(xc1dcd6189d01216e x97bf2eeabd4abc7b)
	{
		if (x97bf2eeabd4abc7b.xa66385d80d4d296f != "chart")
		{
			return null;
		}
		string text = null;
		while (x97bf2eeabd4abc7b.x1ac1960adc8c4c39())
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x97bf2eeabd4abc7b.xa66385d80d4d296f) != null && xa66385d80d4d296f == "id")
			{
				text = x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb;
			}
		}
		if (!x0d299f323d241756.x5959bccb67bbf051(text))
		{
			return null;
		}
		xd4e66257276c6905 result = null;
		XmlDocument xmlDocument = base.xca687bd498227c89.xe9e9c556ec0c3e33.x7e9143f4af321ab1(text);
		if (xmlDocument != null)
		{
			xc1dcd6189d01216e x97bf2eeabd4abc7b2 = new xc1dcd6189d01216e(xd165c26d81eb4a1e.x0c9679d333729bc5(xmlDocument), null);
			result = xda09af88ab899a50(x97bf2eeabd4abc7b2);
		}
		return result;
	}

	internal xd4e66257276c6905 xda09af88ab899a50(xc1dcd6189d01216e x97bf2eeabd4abc7b)
	{
		x4c28ef76f151d171(x97bf2eeabd4abc7b);
		x19b908c0d4dae4fc();
		if (xa0db25b371643a4d == null)
		{
			throw new NullReferenceException("No chart defined in the plot area.");
		}
		return xa0db25b371643a4d;
	}

	private void x19b908c0d4dae4fc()
	{
		xa0db25b371643a4d = new xd4e66257276c6905();
		while (x7450cc1e48712286.x152cbadbfa8061b1("chartSpace"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "chart":
				xa0db25b371643a4d.x317eef27d88d4cf9 = xc81c8953e711a958();
				break;
			case "date1904":
				xa0db25b371643a4d.xcb380cb55fa000ee = x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true);
				break;
			case "externalData":
				xa0db25b371643a4d.xcd69b22e9bd2730d = x7450cc1e48712286.xd68abcd61e368af9("id", "");
				break;
			case "lang":
				xa0db25b371643a4d.x8e720b4f276ab89d = x7450cc1e48712286.xd68abcd61e368af9("val", "");
				break;
			case "pivotSource":
				xa0db25b371643a4d.xc059785ea37454aa = xa838333cf20f52ea.x9eed24f8ca8d512d(x7450cc1e48712286);
				break;
			case "protection":
				xa0db25b371643a4d.x14c3f5426fc2c1fc = xa838333cf20f52ea.x9c1d581cfbeb918c(x7450cc1e48712286);
				break;
			case "roundedCorners":
				xa0db25b371643a4d.xb2a22256f7eba14a = x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true);
				break;
			case "spPr":
				xa838333cf20f52ea.xdb3e183f8621de35(x7450cc1e48712286, xa0db25b371643a4d.xff13b489d81606b6);
				break;
			case "style":
				xa0db25b371643a4d.xfe2178c1f916f36c = x7450cc1e48712286.xe8602379c60acf13("val", 0);
				break;
			case "txPr":
				xa838333cf20f52ea.x10a86a9a76e8d159(x7450cc1e48712286, xa0db25b371643a4d.x68955bfadd010132);
				break;
			case "userShapes":
				xa0db25b371643a4d.x51c3e56314230f85 = x7450cc1e48712286.xd68abcd61e368af9("id", "");
				break;
			case "clrMapOvr":
			case "printSettings":
			case "extLst":
				x10576afa17ca4f1f();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
	}

	private xfe1068a58387cabb xc81c8953e711a958()
	{
		xfe1068a58387cabb xfe1068a58387cabb = new xfe1068a58387cabb();
		while (x7450cc1e48712286.x152cbadbfa8061b1("chart"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "autoTitleDeleted":
				xfe1068a58387cabb.x1b975dd453f6e91d = x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true);
				break;
			case "backWall":
				xfe1068a58387cabb.x3e4c2c8a210f5504 = xa838333cf20f52ea.x8ca3aa0fb7666a84(x7450cc1e48712286);
				break;
			case "dispBlanksAs":
				xfe1068a58387cabb.xf65fccb3377b2ac2 = xa74237a39984bb17.x5afd4eededea1f4e(x7450cc1e48712286.xd68abcd61e368af9("val", ""));
				break;
			case "floor":
				xfe1068a58387cabb.x647980b7bc85885a = xa838333cf20f52ea.x8ca3aa0fb7666a84(x7450cc1e48712286);
				break;
			case "legend":
				xfe1068a58387cabb.xdd76c95ca663244c = xa838333cf20f52ea.xc15b3b85a30a6c35(x7450cc1e48712286);
				break;
			case "pivotFmts":
				xfe1068a58387cabb.xd61fa34bbcb40b0e = xa838333cf20f52ea.xd23f31c92a73f2bf(x7450cc1e48712286);
				break;
			case "plotArea":
				xfe1068a58387cabb.x665038dfa8849161 = x8ed201557fd4cbb6();
				break;
			case "plotVisOnly":
				xfe1068a58387cabb.xe3ec6b03f6e476c7 = x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true);
				break;
			case "showDLblsOverMax":
				xfe1068a58387cabb.xaf6dd409649d2921 = x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true);
				break;
			case "sideWall":
				xfe1068a58387cabb.xa7fdc3c4878b1c16 = xa838333cf20f52ea.x8ca3aa0fb7666a84(x7450cc1e48712286);
				break;
			case "title":
				xfe1068a58387cabb.x238bf167ccfdd282 = xa838333cf20f52ea.xbcea82b01777a36c(x7450cc1e48712286);
				break;
			case "view3D":
				xfe1068a58387cabb.x1af064a2b1738e0a = xa838333cf20f52ea.x74b66bef66075fa2(x7450cc1e48712286);
				break;
			case "extLst":
				x10576afa17ca4f1f();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
		return xfe1068a58387cabb;
	}

	private x6128243c276d529b x8ed201557fd4cbb6()
	{
		x6128243c276d529b x6128243c276d529b = new x6128243c276d529b();
		while (x7450cc1e48712286.x152cbadbfa8061b1("plotArea"))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "areaChart":
			case "area3DChart":
			case "lineChart":
			case "line3DChart":
			case "stockChart":
			case "radarChart":
			case "scatterChart":
			case "pieChart":
			case "pie3DChart":
			case "doughnutChart":
			case "barChart":
			case "bar3DChart":
			case "ofPieChart":
			case "surfaceChart":
			case "surface3DChart":
			case "bubbleChart":
				x6128243c276d529b.x7326b83dea8a55f8(x702eaf77e069dadf());
				break;
			case "valAx":
			case "catAx":
			case "dateAx":
			case "serAx":
				x6128243c276d529b.x18e36e2c1b210e57(xddd9b4b4973d5cc2.xda09af88ab899a50(x7450cc1e48712286));
				break;
			case "layout":
				x6128243c276d529b.xb7ae55095fddecd9 = xa838333cf20f52ea.x258b75baa7766b96(x7450cc1e48712286);
				break;
			case "dTable":
				x6128243c276d529b.x1d122b11a35a0e78 = xa838333cf20f52ea.x38b6dacdc626b4cf(x7450cc1e48712286);
				break;
			case "spPr":
				xa838333cf20f52ea.xdb3e183f8621de35(x7450cc1e48712286, x6128243c276d529b.xff13b489d81606b6);
				break;
			case "extLst":
				x10576afa17ca4f1f();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
		return x6128243c276d529b;
	}

	private x958ddf7e6db1ce94 x702eaf77e069dadf()
	{
		string xa66385d80d4d296f = x7450cc1e48712286.xa66385d80d4d296f;
		x8f04e4e6e23bd1f5 xbde1c5dae4a = x4faf873fda897c38(xa66385d80d4d296f);
		x958ddf7e6db1ce94 x958ddf7e6db1ce = x17541ef08c27cf21.xf032ebc9617d24aa(xbde1c5dae4a);
		while (x7450cc1e48712286.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			switch (x7450cc1e48712286.xa66385d80d4d296f)
			{
			case "axId":
				x958ddf7e6db1ce.x8e438b1f360b9045(x7450cc1e48712286.xe8602379c60acf13("val", 0));
				break;
			case "dLbls":
				x958ddf7e6db1ce.x1c0c32c5e4d010d3.x9b050884457cf3b5(x2c127adefb5db3a3.xcc203ebd00328bf9, xa838333cf20f52ea.xce0a40b060410331(x7450cc1e48712286));
				break;
			case "dropLines":
				xa838333cf20f52ea.xe0bd5a61617214a7(x7450cc1e48712286, (xbc46977eebea4733)x958ddf7e6db1ce.x1c0c32c5e4d010d3.x4ff37084a5d7d57f(x2c127adefb5db3a3.x31c669cffab87c82));
				break;
			case "ser":
				x958ddf7e6db1ce.xc869533ad93d98d3.Add(xedc591e2115d300f.xda09af88ab899a50(x7450cc1e48712286));
				break;
			case "varyColors":
				x958ddf7e6db1ce.x1c0c32c5e4d010d3.x9b050884457cf3b5(x2c127adefb5db3a3.x62819e9fb2110ddc, x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true));
				break;
			case "grouping":
				x958ddf7e6db1ce.x1c0c32c5e4d010d3.x9b050884457cf3b5(x2c127adefb5db3a3.x1c0d56aa74903bbc, xa74237a39984bb17.xf0496069131f78ea(x7450cc1e48712286.xd68abcd61e368af9("val", "")));
				break;
			case "gapDepth":
				x958ddf7e6db1ce.x1c0c32c5e4d010d3.x9b050884457cf3b5(x2c127adefb5db3a3.x4f22f67c3a2a2291, x7450cc1e48712286.xe8602379c60acf13("val", 150));
				break;
			case "barDir":
				x958ddf7e6db1ce.x1c0c32c5e4d010d3.x9b050884457cf3b5(x2c127adefb5db3a3.x24ff467b392c1a38, xa74237a39984bb17.xea9720f4cbe9f93d(x7450cc1e48712286.xd68abcd61e368af9("val", "")));
				break;
			case "gapWidth":
				x958ddf7e6db1ce.x1c0c32c5e4d010d3.x9b050884457cf3b5(x2c127adefb5db3a3.x831803cdfcd433fb, x7450cc1e48712286.xe8602379c60acf13("val", 150));
				break;
			case "shape":
				x958ddf7e6db1ce.x1c0c32c5e4d010d3.x9b050884457cf3b5(x2c127adefb5db3a3.xa9993ed2e0c64574, xa74237a39984bb17.xac067504bb4df455(x7450cc1e48712286.xd68abcd61e368af9("val", "")));
				break;
			case "overlap":
				x958ddf7e6db1ce.x1c0c32c5e4d010d3.x9b050884457cf3b5(x2c127adefb5db3a3.x64fbe51d5b1a2101, x7450cc1e48712286.xe8602379c60acf13("val", 0));
				break;
			case "serLines":
				xa838333cf20f52ea.xe0bd5a61617214a7(x7450cc1e48712286, (xbc46977eebea4733)x958ddf7e6db1ce.x1c0c32c5e4d010d3.x4ff37084a5d7d57f(x2c127adefb5db3a3.x1d14078afead3939));
				break;
			case "bubble3D":
				x958ddf7e6db1ce.x1c0c32c5e4d010d3.x9b050884457cf3b5(x2c127adefb5db3a3.x3c1388d994dacf98, x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true));
				break;
			case "bubbleScale":
				x958ddf7e6db1ce.x1c0c32c5e4d010d3.x9b050884457cf3b5(x2c127adefb5db3a3.xc4cfbad937290bb1, x7450cc1e48712286.xe8602379c60acf13("val", 0));
				break;
			case "showNegBubbles":
				x958ddf7e6db1ce.x1c0c32c5e4d010d3.x9b050884457cf3b5(x2c127adefb5db3a3.x6eb0d2123bd826c2, x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true));
				break;
			case "sizeRepresents":
				x958ddf7e6db1ce.x1c0c32c5e4d010d3.x9b050884457cf3b5(x2c127adefb5db3a3.x73e16be67dff80ab, xa74237a39984bb17.x2f818a85abd0add2(x7450cc1e48712286.xd68abcd61e368af9("val", "")));
				break;
			case "firstSliceAng":
				x958ddf7e6db1ce.x1c0c32c5e4d010d3.x9b050884457cf3b5(x2c127adefb5db3a3.x297e14bc7c061d46, x7450cc1e48712286.xe8602379c60acf13("val", 0));
				break;
			case "holeSize":
				x958ddf7e6db1ce.x1c0c32c5e4d010d3.x9b050884457cf3b5(x2c127adefb5db3a3.xd66c446deaa4e705, x7450cc1e48712286.xe8602379c60acf13("val", 10));
				break;
			case "hiLowLines":
				xa838333cf20f52ea.xe0bd5a61617214a7(x7450cc1e48712286, (xbc46977eebea4733)x958ddf7e6db1ce.x1c0c32c5e4d010d3.x4ff37084a5d7d57f(x2c127adefb5db3a3.x93c1b4f8ca3c6608));
				break;
			case "marker":
				x958ddf7e6db1ce.x1c0c32c5e4d010d3.x9b050884457cf3b5(x2c127adefb5db3a3.x138f3e7bd8930522, x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true));
				break;
			case "smooth":
				x958ddf7e6db1ce.x1c0c32c5e4d010d3.x9b050884457cf3b5(x2c127adefb5db3a3.x22925f509223ea15, x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true));
				break;
			case "upDownBars":
				xa838333cf20f52ea.x060dc8c329d84d3e(x7450cc1e48712286, (x9e516aa6ad78327f)x958ddf7e6db1ce.x1c0c32c5e4d010d3.x4ff37084a5d7d57f(x2c127adefb5db3a3.x6afb9736bfd31348));
				break;
			case "custSplit":
				x958ddf7e6db1ce.x1c0c32c5e4d010d3.x9b050884457cf3b5(x2c127adefb5db3a3.x51913d1ca000a17c, xa838333cf20f52ea.xee8e28ab035ddfff(x7450cc1e48712286));
				break;
			case "ofPieType":
				x958ddf7e6db1ce.x1c0c32c5e4d010d3.x9b050884457cf3b5(x2c127adefb5db3a3.xca7daa32761c533a, xa74237a39984bb17.x904286553e780ed4(x7450cc1e48712286.xd68abcd61e368af9("val", "")));
				break;
			case "secondPieSize":
				x958ddf7e6db1ce.x1c0c32c5e4d010d3.x9b050884457cf3b5(x2c127adefb5db3a3.x4d883cbc8156f773, x7450cc1e48712286.xe8602379c60acf13("val", 75));
				break;
			case "splitPos":
				x958ddf7e6db1ce.x1c0c32c5e4d010d3.x9b050884457cf3b5(x2c127adefb5db3a3.xaaf37e072a068e79, x7450cc1e48712286.x075a63114fe24ce9("val", 0.0));
				break;
			case "splitType":
				x958ddf7e6db1ce.x1c0c32c5e4d010d3.x9b050884457cf3b5(x2c127adefb5db3a3.xabd66677efe36eb6, xa74237a39984bb17.x8c95067b216d07c9(x7450cc1e48712286.xd68abcd61e368af9("val", "")));
				break;
			case "radarStyle":
				x958ddf7e6db1ce.x1c0c32c5e4d010d3.x9b050884457cf3b5(x2c127adefb5db3a3.xc08adeedaa9916be, xa74237a39984bb17.x420adc9042acb4c1(x7450cc1e48712286.xd68abcd61e368af9("val", "")));
				break;
			case "scatterStyle":
				x958ddf7e6db1ce.x1c0c32c5e4d010d3.x9b050884457cf3b5(x2c127adefb5db3a3.x7e0b0092fe472ee7, xa74237a39984bb17.xbba0682d1a90c6ea(x7450cc1e48712286.xd68abcd61e368af9("val", "")));
				break;
			case "bandFmts":
				x958ddf7e6db1ce.x1c0c32c5e4d010d3.x9b050884457cf3b5(x2c127adefb5db3a3.xb7a27d079d767cf7, xa838333cf20f52ea.x90b6d1adbae0b8a9(x7450cc1e48712286));
				break;
			case "wireframe":
				x958ddf7e6db1ce.x1c0c32c5e4d010d3.x9b050884457cf3b5(x2c127adefb5db3a3.x1d03f9dbb48b31c4, x7450cc1e48712286.x9c1302ecb6c4f3a2("val", xc6e85c82d0d89508: true));
				break;
			case "extLst":
				x10576afa17ca4f1f();
				break;
			default:
				xf4732ad4641eec1a();
				break;
			}
		}
		return x958ddf7e6db1ce;
	}

	private static x8f04e4e6e23bd1f5 x4faf873fda897c38(string x91ef5ae2997ab6c4)
	{
		return x91ef5ae2997ab6c4 switch
		{
			"area3DChart" => x8f04e4e6e23bd1f5.xd61f6e4c8465a742, 
			"areaChart" => x8f04e4e6e23bd1f5.xc21f4ba514f3ca9d, 
			"bar3DChart" => x8f04e4e6e23bd1f5.x55a6d2a0bbf9b804, 
			"barChart" => x8f04e4e6e23bd1f5.x867a2b24afc052f0, 
			"bubbleChart" => x8f04e4e6e23bd1f5.x7acc253039ba3e06, 
			"doughnutChart" => x8f04e4e6e23bd1f5.xa6f6d1f412552b3c, 
			"line3DChart" => x8f04e4e6e23bd1f5.x6cd6caab5cff0e7a, 
			"lineChart" => x8f04e4e6e23bd1f5.x75082347bbe6fbb0, 
			"ofPieChart" => x8f04e4e6e23bd1f5.x7f2337a449126a2c, 
			"pie3DChart" => x8f04e4e6e23bd1f5.xded692fc42667c96, 
			"pieChart" => x8f04e4e6e23bd1f5.x75429f64cf7991d9, 
			"radarChart" => x8f04e4e6e23bd1f5.x43c013ec50029a74, 
			"scatterChart" => x8f04e4e6e23bd1f5.x44d15a8a22280ccd, 
			"stockChart" => x8f04e4e6e23bd1f5.x7306581764452c33, 
			"surface3DChart" => x8f04e4e6e23bd1f5.x62aeced188a90c9c, 
			"surfaceChart" => x8f04e4e6e23bd1f5.x015777fbc8c5a403, 
			_ => throw new ArgumentException("Unexpected tag name"), 
		};
	}
}
