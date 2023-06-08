using System.Collections;
using Aspose.Words;
using Aspose.Words.BuildingBlocks;
using Aspose.Words.Fields;
using Aspose.Words.Fonts;
using Aspose.Words.Markup;
using x28925c9b27b37a46;
using x53eb9320ebbb8395;
using x6c95d9cf46ff5f25;
using xe5b37aee2c2a4d4e;

namespace x909757d9fd2dd6ae;

internal class xc62574be95c1c918
{
	private static readonly Hashtable x9bea6158983963ae;

	private static readonly Hashtable x9ab984f31b39762c;

	private static readonly Hashtable xe9262ddc4a1310be;

	private static readonly Hashtable x72699d9802e89fa9;

	private static readonly Hashtable x6c5de3a2457ca7d0;

	private static readonly Hashtable x65ef1927db6b8083;

	private static readonly Hashtable x73b371e817d6608f;

	private static readonly Hashtable xdd1c5b917fe6db60;

	private static readonly Hashtable x3b80923725adcc95;

	private static readonly Hashtable x794190cd4a2911f2;

	private static readonly Hashtable xe7e8589552878651;

	private static readonly Hashtable xefc12086fba9146e;

	private static readonly Hashtable x22683027e9e0cb41;

	private static readonly Hashtable xcb5781683033819b;

	private static readonly Hashtable x319dd4af40612e63;

	private static readonly Hashtable xd955a100d2abba45;

	private static readonly Hashtable xcaaf1234ce2ce658;

	private static readonly Hashtable x0d30864f95267756;

	private static readonly Hashtable x74973c689ff24c94;

	private static readonly Hashtable x7bc9a24572f5d402;

	private static readonly Hashtable x7eaaf5bf61bd29b7;

	private static readonly Hashtable x9bc677c63cd40eab;

	private static readonly Hashtable x52fe2e3b3e643280;

	private static readonly Hashtable xc247a636e8ba04ef;

	private static readonly Hashtable xb0e492a146b7703c;

	private static readonly Hashtable x2c9d6348c4e4fb99;

	private static readonly Hashtable x18cd3e5233bca5d6;

	private static readonly Hashtable x7db7e13c9382cd9b;

	private static readonly Hashtable x07eece04bf9e2009;

	private static readonly Hashtable xc1cc946d852af211;

	private static readonly Hashtable xa564a8d018a94177;

	private static readonly Hashtable x98d3a093e5d8014f;

	private static readonly Hashtable x2089ea1c6b07a0f6;

	private static readonly Hashtable xfe676dc13f72a3d0;

	private static readonly Hashtable xcbd984a0f8b88ca9;

	private static readonly Hashtable xc6f1f9387268ddcc;

	private static readonly Hashtable x7a35f6fde9cacc6c;

	private static readonly Hashtable x36dac7801e50f147;

	private static readonly Hashtable xd854d8bffdec10a2;

	private static readonly Hashtable x877b7534493f59bb;

	private static readonly Hashtable x25e2c8dd9c536abf;

	private static readonly Hashtable xd2469845066b0fae;

	private static readonly Hashtable x214f7ea4e68dc502;

	private static readonly Hashtable x1951b2f659b38012;

	private static readonly Hashtable x6eaf1ef0b18e67bf;

	private static readonly Hashtable x1fd54e86e256e2d3;

	internal static string x7cfd9d683a359925(string xe1d3286d17e44a37)
	{
		return xe1d3286d17e44a37 switch
		{
			"application/msword" => ".doc", 
			"application/vnd.ms-excel" => ".xls", 
			"application/vnd.ms-powerpoint" => ".ppt", 
			"application/vnd.openxmlformats-officedocument.wordprocessingml.document" => ".docx", 
			"application/vnd.openxmlformats-officedocument.wordprocessingml.template" => ".dotx", 
			"application/vnd.ms-word.document.macroEnabled.12" => ".docm", 
			"application/vnd.ms-word.template.macroEnabled.12" => ".dotm", 
			"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" => ".xlsx", 
			"application/vnd.ms-excel.sheet.macroEnabled.12" => ".xlsm", 
			"application/vnd.ms-excel.sheet.binary.macroEnabled.12" => ".xlsb", 
			"application/vnd.openxmlformats-officedocument.presentationml.presentation" => ".pptx", 
			"application/vnd.ms-powerpoint.presentation.macroEnabled.12" => ".pptm", 
			"application/vnd.openxmlformats-officedocument.presentationml.slideshow" => ".ppsx", 
			"application/vnd.ms-powerpoint.slideshow.macroEnabled.12" => ".ppsm", 
			"application/vnd.openxmlformats-officedocument.presentationml.slide" => ".sldx", 
			"application/vnd.ms-powerpoint.slide.macroEnabled.12" => ".sldm", 
			_ => ".bin", 
		};
	}

	internal static TextFormFieldType x464d9e00675f590f(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			"calculated" => TextFormFieldType.Calculated, 
			"currentDate" => TextFormFieldType.CurrentDate, 
			"currentTime" => TextFormFieldType.CurrentTime, 
			"date" => TextFormFieldType.Date, 
			"number" => TextFormFieldType.Number, 
			"" => TextFormFieldType.Regular, 
			"regular" => TextFormFieldType.Regular, 
			_ => TextFormFieldType.Regular, 
		};
	}

	internal static string xef04f7c4a90f2a51(TextFormFieldType xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			TextFormFieldType.Calculated => "calculated", 
			TextFormFieldType.CurrentDate => "currentDate", 
			TextFormFieldType.CurrentTime => "currentTime", 
			TextFormFieldType.Date => "date", 
			TextFormFieldType.Number => "number", 
			TextFormFieldType.Regular => "", 
			_ => "", 
		};
	}

	internal static NumberStyle x5dabea7b873aecb0(string xbcea506a33cf9111)
	{
		return (NumberStyle)x682712679dbc585a.xce92de628aa023cf(x9bea6158983963ae, xbcea506a33cf9111, NumberStyle.Arabic);
	}

	internal static string x235742abf07b06ea(object xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x9ab984f31b39762c, xbcea506a33cf9111, "");
	}

	internal static FontFamily x4d3ddb635556b2b1(string xbcea506a33cf9111)
	{
		return (FontFamily)x682712679dbc585a.xce92de628aa023cf(xe9262ddc4a1310be, xbcea506a33cf9111, FontFamily.Auto);
	}

	internal static string x1bdd36ffc1b64f6c(FontFamily xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x72699d9802e89fa9, xbcea506a33cf9111, "");
	}

	internal static x6d434087bc06a37d x2abb13ef43ef56e7(string xbcea506a33cf9111)
	{
		switch (xbcea506a33cf9111)
		{
		case "tb":
		case "lrTb":
			return x6d434087bc06a37d.x3bce7c87328df8da;
		case "rbV":
		case "lrTbV":
			return x6d434087bc06a37d.x8a6ef9bc29c10a50;
		case "rl":
		case "tbRl":
			return x6d434087bc06a37d.x61c108cc44ef385a;
		default:
			return x6d434087bc06a37d.x3bce7c87328df8da;
		}
	}

	internal static string xfcf5289e205091d4(x6d434087bc06a37d xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			x6d434087bc06a37d.x3bce7c87328df8da => "lrTb", 
			x6d434087bc06a37d.x8a6ef9bc29c10a50 => "lrTbV", 
			x6d434087bc06a37d.x61c108cc44ef385a => "tbRl", 
			_ => "lrTb", 
		};
	}

	internal static LineStyle xf5a81b2292447eb3(string xbcea506a33cf9111)
	{
		return (LineStyle)x682712679dbc585a.xce92de628aa023cf(x6c5de3a2457ca7d0, xbcea506a33cf9111, LineStyle.None);
	}

	internal static string x95c1627f7e5c3be9(LineStyle xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x65ef1927db6b8083, xbcea506a33cf9111, "none");
	}

	internal static StyleType xfefa9c1896e1f470(string xbcea506a33cf9111)
	{
		return (StyleType)x682712679dbc585a.xce92de628aa023cf(x73b371e817d6608f, xbcea506a33cf9111, StyleType.Paragraph);
	}

	internal static string xdcf2ecdfdd04b46c(StyleType xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(xdd1c5b917fe6db60, xbcea506a33cf9111, "paragraph");
	}

	internal static x101cddc73c4f8cc2 xa08f827e6da598ab(string xbcea506a33cf9111, bool x26f77e2004716cc6)
	{
		Hashtable x12fedb3de1c57ea = (x26f77e2004716cc6 ? xe7e8589552878651 : x3b80923725adcc95);
		return (x101cddc73c4f8cc2)x682712679dbc585a.xce92de628aa023cf(x12fedb3de1c57ea, xbcea506a33cf9111, x101cddc73c4f8cc2.xe9e531d1a6725226);
	}

	internal static string xfdc927dd4cdefa18(x101cddc73c4f8cc2 xbcea506a33cf9111, bool x26f77e2004716cc6)
	{
		Hashtable x12fedb3de1c57ea = (x26f77e2004716cc6 ? xefc12086fba9146e : x794190cd4a2911f2);
		return (string)x682712679dbc585a.xce92de628aa023cf(x12fedb3de1c57ea, xbcea506a33cf9111, "");
	}

	internal static string xe43d1430fdb4a8b1(BuildingBlockBehavior xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(xcb5781683033819b, xbcea506a33cf9111, "");
	}

	internal static BuildingBlockBehavior x08d936e1b1347121(string xbcea506a33cf9111)
	{
		return (BuildingBlockBehavior)x682712679dbc585a.xce92de628aa023cf(x22683027e9e0cb41, xbcea506a33cf9111, BuildingBlockBehavior.Content);
	}

	internal static string xe043c7f7b071a6c5(BuildingBlockGallery xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(xd955a100d2abba45, xbcea506a33cf9111, "any");
	}

	internal static BuildingBlockGallery x30fcb59e0254e3ff(string xbcea506a33cf9111)
	{
		return (BuildingBlockGallery)x682712679dbc585a.xce92de628aa023cf(x319dd4af40612e63, xbcea506a33cf9111, BuildingBlockGallery.All);
	}

	internal static string x291f2518c2c27e2d(BuildingBlockType xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x0d30864f95267756, xbcea506a33cf9111, "");
	}

	internal static BuildingBlockType xb9a5defd5903fcdd(string xbcea506a33cf9111)
	{
		return (BuildingBlockType)x682712679dbc585a.xce92de628aa023cf(xcaaf1234ce2ce658, xbcea506a33cf9111, BuildingBlockType.None);
	}

	internal static string xb171fd851955b5db(SdtCalendarType xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x7bc9a24572f5d402, xbcea506a33cf9111, "");
	}

	internal static SdtCalendarType x5a1cbe2e27ce9bf7(string xbcea506a33cf9111)
	{
		return (SdtCalendarType)x682712679dbc585a.xce92de628aa023cf(x74973c689ff24c94, xbcea506a33cf9111, SdtCalendarType.None);
	}

	internal static string x23c31cfdbc6aba34(xed92c0eace754ea8 xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x9bc677c63cd40eab, xbcea506a33cf9111, "");
	}

	internal static xed92c0eace754ea8 xf955a7b0097396a2(string xbcea506a33cf9111)
	{
		return (xed92c0eace754ea8)x682712679dbc585a.xce92de628aa023cf(x7eaaf5bf61bd29b7, xbcea506a33cf9111, xed92c0eace754ea8.x3f5233cee263582a);
	}

	internal static SdtDateStorageFormat x8a8775f0dde3331a(string xbcea506a33cf9111)
	{
		return (SdtDateStorageFormat)x682712679dbc585a.xce92de628aa023cf(x52fe2e3b3e643280, xbcea506a33cf9111, SdtDateStorageFormat.DateTime);
	}

	internal static string x0f5d755dbfc52c1a(SdtDateStorageFormat xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(xc247a636e8ba04ef, xbcea506a33cf9111, "dateTime");
	}

	internal static string xa7e272700c945114(x2cdbcd6273a149f1 xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x2c9d6348c4e4fb99, xbcea506a33cf9111, "");
	}

	internal static x2cdbcd6273a149f1 x644cb83fa42445a4(string xbcea506a33cf9111)
	{
		return (x2cdbcd6273a149f1)x682712679dbc585a.xce92de628aa023cf(xb0e492a146b7703c, xbcea506a33cf9111, x2cdbcd6273a149f1.xfa862982140742a7);
	}

	internal static string xba14298a7c2a7f1b(x1380d412169e361b xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x7db7e13c9382cd9b, xbcea506a33cf9111, "");
	}

	internal static x1380d412169e361b x141ad7bf025159d2(string xbcea506a33cf9111)
	{
		return (x1380d412169e361b)x682712679dbc585a.xce92de628aa023cf(x18cd3e5233bca5d6, xbcea506a33cf9111, x1380d412169e361b.x4316791d2bbd0ab1);
	}

	internal static string xbebb28e8a2da0157(x65251a26aa8f6af1 xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(xc1cc946d852af211, xbcea506a33cf9111, "");
	}

	internal static x65251a26aa8f6af1 xab4d594e6fa0441f(string xbcea506a33cf9111)
	{
		return (x65251a26aa8f6af1)x682712679dbc585a.xce92de628aa023cf(x07eece04bf9e2009, xbcea506a33cf9111, x65251a26aa8f6af1.x00d0ae795109fe11);
	}

	internal static string x0574577548819b81(xce8b2ce767b2485c xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x98d3a093e5d8014f, xbcea506a33cf9111, "");
	}

	internal static xce8b2ce767b2485c xc2015ac1099ed470(string xbcea506a33cf9111)
	{
		return (xce8b2ce767b2485c)x682712679dbc585a.xce92de628aa023cf(xa564a8d018a94177, xbcea506a33cf9111, xce8b2ce767b2485c.x9bcb07e204e30218);
	}

	internal static string xc9d44d10518bd113(x6813eed7028d8bfc xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(xfe676dc13f72a3d0, xbcea506a33cf9111, "");
	}

	internal static x6813eed7028d8bfc xdeaa127216cb1437(string xbcea506a33cf9111)
	{
		return (x6813eed7028d8bfc)x682712679dbc585a.xce92de628aa023cf(x2089ea1c6b07a0f6, xbcea506a33cf9111, x6813eed7028d8bfc.xf2957594ee857616);
	}

	internal static string xb2f0d200b777cf67(xb474f98b96852a6e xbcea506a33cf9111, bool xff4e1c4bbf73fe19)
	{
		switch (xbcea506a33cf9111)
		{
		case xb474f98b96852a6e.xe360b1885d8d4a41:
			return "top";
		case xb474f98b96852a6e.x9bcb07e204e30218:
			if (!xff4e1c4bbf73fe19)
			{
				return "bot";
			}
			return "bottom";
		default:
			return "center";
		}
	}

	internal static xb474f98b96852a6e xd054f4cfeace1391(string xbcea506a33cf9111)
	{
		switch (xbcea506a33cf9111)
		{
		case "top":
			return xb474f98b96852a6e.xe360b1885d8d4a41;
		case "bottom":
		case "bot":
			return xb474f98b96852a6e.x9bcb07e204e30218;
		case "center":
			return xb474f98b96852a6e.x58d2ccae3c5cfd08;
		default:
			return xb474f98b96852a6e.x58d2ccae3c5cfd08;
		}
	}

	internal static string xbaab7661db0cbc08(x63bdb8b878b040d9 xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(xc6f1f9387268ddcc, xbcea506a33cf9111, "");
	}

	internal static x63bdb8b878b040d9 x8e7c6209ce53566e(string xbcea506a33cf9111)
	{
		return (x63bdb8b878b040d9)x682712679dbc585a.xce92de628aa023cf(xcbd984a0f8b88ca9, xbcea506a33cf9111, x63bdb8b878b040d9.x9bcb07e204e30218);
	}

	internal static string x429ade1c0a496e94(x890a027c82a36a95 xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x36dac7801e50f147, xbcea506a33cf9111, "");
	}

	internal static x890a027c82a36a95 xabd3359cac621e01(string xbcea506a33cf9111)
	{
		return (x890a027c82a36a95)x682712679dbc585a.xce92de628aa023cf(x7a35f6fde9cacc6c, xbcea506a33cf9111, x890a027c82a36a95.xced856c17df679c5);
	}

	internal static string x156dafc5cd71c96a(xf47bac63068c8fd6 xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x877b7534493f59bb, xbcea506a33cf9111, "");
	}

	internal static xf47bac63068c8fd6 xbc8913cc2c4a85ed(string xbcea506a33cf9111)
	{
		return (xf47bac63068c8fd6)x682712679dbc585a.xce92de628aa023cf(xd854d8bffdec10a2, xbcea506a33cf9111, xf47bac63068c8fd6.x8e321c5b5aaa4dd5);
	}

	internal static string xce59b63420cae7bb(x55477ca1c0c8419f xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(xd2469845066b0fae, xbcea506a33cf9111, "");
	}

	internal static x55477ca1c0c8419f xbbc60c8915068464(string xbcea506a33cf9111)
	{
		return (x55477ca1c0c8419f)x682712679dbc585a.xce92de628aa023cf(x25e2c8dd9c536abf, xbcea506a33cf9111, x55477ca1c0c8419f.x72d92bd1aff02e37);
	}

	internal static string x2f778a9929d07da5(x84d41ac121232475 xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x1fd54e86e256e2d3, xbcea506a33cf9111, "");
	}

	internal static x84d41ac121232475 x2197c2548108522a(string xbcea506a33cf9111)
	{
		return (x84d41ac121232475)x682712679dbc585a.xce92de628aa023cf(x6eaf1ef0b18e67bf, xbcea506a33cf9111, x84d41ac121232475.x4d0b9d4447ba7566);
	}

	internal static string x4abd682bab5e3bd1(x932d11b236987c0e xbcea506a33cf9111)
	{
		return (string)x682712679dbc585a.xce92de628aa023cf(x1951b2f659b38012, xbcea506a33cf9111, "");
	}

	internal static x932d11b236987c0e x9529b42fbc8f7272(string xbcea506a33cf9111)
	{
		return (x932d11b236987c0e)x682712679dbc585a.xce92de628aa023cf(x214f7ea4e68dc502, xbcea506a33cf9111, x932d11b236987c0e.x941a43d4a5637fd0);
	}

	static xc62574be95c1c918()
	{
		x9bea6158983963ae = new Hashtable();
		x9ab984f31b39762c = new Hashtable();
		xe9262ddc4a1310be = new Hashtable();
		x72699d9802e89fa9 = new Hashtable();
		x6c5de3a2457ca7d0 = new Hashtable();
		x65ef1927db6b8083 = new Hashtable();
		x73b371e817d6608f = new Hashtable();
		xdd1c5b917fe6db60 = new Hashtable();
		x3b80923725adcc95 = new Hashtable();
		x794190cd4a2911f2 = new Hashtable();
		xe7e8589552878651 = new Hashtable();
		xefc12086fba9146e = new Hashtable();
		x22683027e9e0cb41 = new Hashtable();
		xcb5781683033819b = new Hashtable();
		x319dd4af40612e63 = new Hashtable();
		xd955a100d2abba45 = new Hashtable();
		xcaaf1234ce2ce658 = new Hashtable();
		x0d30864f95267756 = new Hashtable();
		x74973c689ff24c94 = new Hashtable();
		x7bc9a24572f5d402 = new Hashtable();
		x7eaaf5bf61bd29b7 = new Hashtable();
		x9bc677c63cd40eab = new Hashtable();
		x52fe2e3b3e643280 = new Hashtable();
		xc247a636e8ba04ef = new Hashtable();
		xb0e492a146b7703c = new Hashtable();
		x2c9d6348c4e4fb99 = new Hashtable();
		x18cd3e5233bca5d6 = new Hashtable();
		x7db7e13c9382cd9b = new Hashtable();
		x07eece04bf9e2009 = new Hashtable();
		xc1cc946d852af211 = new Hashtable();
		xa564a8d018a94177 = new Hashtable();
		x98d3a093e5d8014f = new Hashtable();
		x2089ea1c6b07a0f6 = new Hashtable();
		xfe676dc13f72a3d0 = new Hashtable();
		xcbd984a0f8b88ca9 = new Hashtable();
		xc6f1f9387268ddcc = new Hashtable();
		x7a35f6fde9cacc6c = new Hashtable();
		x36dac7801e50f147 = new Hashtable();
		xd854d8bffdec10a2 = new Hashtable();
		x877b7534493f59bb = new Hashtable();
		x25e2c8dd9c536abf = new Hashtable();
		xd2469845066b0fae = new Hashtable();
		x214f7ea4e68dc502 = new Hashtable();
		x1951b2f659b38012 = new Hashtable();
		x6eaf1ef0b18e67bf = new Hashtable();
		x1fd54e86e256e2d3 = new Hashtable();
		x682712679dbc585a.x70fa1602ceccddee(new object[396]
		{
			"none",
			LineStyle.None,
			"single",
			LineStyle.Single,
			"thick",
			LineStyle.Thick,
			"double",
			LineStyle.Double,
			"dotted",
			LineStyle.Dot,
			"dashed",
			LineStyle.DashLargeGap,
			"dotDash",
			LineStyle.DotDash,
			"dotDotDash",
			LineStyle.DotDotDash,
			"triple",
			LineStyle.Triple,
			"thinThickSmallGap",
			LineStyle.ThinThickSmallGap,
			"thickThinSmallGap",
			LineStyle.ThickThinSmallGap,
			"thinThickThinSmallGap",
			LineStyle.ThinThickThinSmallGap,
			"thinThickMediumGap",
			LineStyle.ThinThickMediumGap,
			"thickThinMediumGap",
			LineStyle.ThickThinMediumGap,
			"thinThickThinMediumGap",
			LineStyle.ThinThickThinMediumGap,
			"thinThickLargeGap",
			LineStyle.ThinThickLargeGap,
			"thickThinLargeGap",
			LineStyle.ThickThinLargeGap,
			"thinThickThinLargeGap",
			LineStyle.ThinThickThinLargeGap,
			"wave",
			LineStyle.Wave,
			"doubleWave",
			LineStyle.DoubleWave,
			"dashSmallGap",
			LineStyle.DashSmallGap,
			"dashDotStroked",
			LineStyle.DashDotStroker,
			"threeDEmboss",
			LineStyle.Emboss3D,
			"threeDEngrave",
			LineStyle.Engrave3D,
			"outset",
			LineStyle.Outset,
			"inset",
			LineStyle.Inset,
			"apples",
			(LineStyle)64,
			"archedScallops",
			(LineStyle)65,
			"babyPacifier",
			(LineStyle)66,
			"babyRattle",
			(LineStyle)67,
			"balloons3Colors",
			(LineStyle)68,
			"balloonsHotAir",
			(LineStyle)69,
			"basicBlackDashes",
			(LineStyle)70,
			"basicBlackDots",
			(LineStyle)71,
			"basicBlackSquares",
			(LineStyle)72,
			"basicThinLines",
			(LineStyle)73,
			"basicWhiteDashes",
			(LineStyle)74,
			"basicWhiteDots",
			(LineStyle)75,
			"basicWhiteSquares",
			(LineStyle)76,
			"basicWideInline",
			(LineStyle)77,
			"basicWideMidline",
			(LineStyle)78,
			"basicWideOutline",
			(LineStyle)79,
			"bats",
			(LineStyle)80,
			"birds",
			(LineStyle)81,
			"birdsFlight",
			(LineStyle)82,
			"cabins",
			(LineStyle)83,
			"cakeSlice",
			(LineStyle)84,
			"candyCorn",
			(LineStyle)85,
			"celticKnotwork",
			(LineStyle)86,
			"certificateBanner",
			(LineStyle)87,
			"chainLink",
			(LineStyle)88,
			"champagneBottle",
			(LineStyle)89,
			"checkedBarBlack",
			(LineStyle)90,
			"checkedBarColor",
			(LineStyle)91,
			"checkered",
			(LineStyle)92,
			"christmasTree",
			(LineStyle)93,
			"circlesLines",
			(LineStyle)94,
			"circlesRectangles",
			(LineStyle)95,
			"classicalWave",
			(LineStyle)96,
			"clocks",
			(LineStyle)97,
			"compass",
			(LineStyle)98,
			"confetti",
			(LineStyle)99,
			"confettiGrays",
			(LineStyle)100,
			"confettiOutline",
			(LineStyle)101,
			"confettiStreamers",
			(LineStyle)102,
			"confettiWhite",
			(LineStyle)103,
			"cornerTriangles",
			(LineStyle)104,
			"couponCutoutDashes",
			(LineStyle)105,
			"couponCutoutDots",
			(LineStyle)106,
			"crazyMaze",
			(LineStyle)107,
			"creaturesButterfly",
			(LineStyle)108,
			"creaturesFish",
			(LineStyle)109,
			"creaturesInsects",
			(LineStyle)110,
			"creaturesLadyBug",
			(LineStyle)111,
			"crossStitch",
			(LineStyle)112,
			"cup",
			(LineStyle)113,
			"decoArch",
			(LineStyle)114,
			"decoArchColor",
			(LineStyle)115,
			"decoBlocks",
			(LineStyle)116,
			"diamondsGray",
			(LineStyle)117,
			"doubleD",
			(LineStyle)118,
			"doubleDiamonds",
			(LineStyle)119,
			"earth1",
			(LineStyle)120,
			"earth2",
			(LineStyle)121,
			"eclipsingSquares1",
			(LineStyle)122,
			"eclipsingSquares2",
			(LineStyle)123,
			"eggsBlack",
			(LineStyle)124,
			"fans",
			(LineStyle)125,
			"film",
			(LineStyle)126,
			"firecrackers",
			(LineStyle)127,
			"flowersBlockPrint",
			(LineStyle)128,
			"flowersDaisies",
			(LineStyle)129,
			"flowersModern1",
			(LineStyle)130,
			"flowersModern2",
			(LineStyle)131,
			"flowersPansy",
			(LineStyle)132,
			"flowersRedRose",
			(LineStyle)133,
			"flowersRoses",
			(LineStyle)134,
			"flowersTeacup",
			(LineStyle)135,
			"flowersTiny",
			(LineStyle)136,
			"gems",
			(LineStyle)137,
			"gingerbreadMan",
			(LineStyle)138,
			"gradient",
			(LineStyle)139,
			"handmade1",
			(LineStyle)140,
			"handmade2",
			(LineStyle)141,
			"heartBalloon",
			(LineStyle)142,
			"heartGray",
			(LineStyle)143,
			"hearts",
			(LineStyle)144,
			"heebieJeebies",
			(LineStyle)145,
			"holly",
			(LineStyle)146,
			"houseFunky",
			(LineStyle)147,
			"hypnotic",
			(LineStyle)148,
			"iceCreamCones",
			(LineStyle)149,
			"lightBulb",
			(LineStyle)150,
			"lightning1",
			(LineStyle)151,
			"lightning2",
			(LineStyle)152,
			"mapPins",
			(LineStyle)153,
			"mapleLeaf",
			(LineStyle)154,
			"mapleMuffins",
			(LineStyle)155,
			"marquee",
			(LineStyle)156,
			"marqueeToothed",
			(LineStyle)157,
			"moons",
			(LineStyle)158,
			"mosaic",
			(LineStyle)159,
			"musicNotes",
			(LineStyle)160,
			"northwest",
			(LineStyle)161,
			"ovals",
			(LineStyle)162,
			"packages",
			(LineStyle)163,
			"palmsBlack",
			(LineStyle)164,
			"palmsColor",
			(LineStyle)165,
			"paperClips",
			(LineStyle)166,
			"papyrus",
			(LineStyle)167,
			"partyFavor",
			(LineStyle)168,
			"partyGlass",
			(LineStyle)169,
			"pencils",
			(LineStyle)170,
			"people",
			(LineStyle)171,
			"peopleWaving",
			(LineStyle)172,
			"peopleHats",
			(LineStyle)173,
			"poinsettias",
			(LineStyle)174,
			"postageStamp",
			(LineStyle)175,
			"pumpkin1",
			(LineStyle)176,
			"pushPinNote1",
			(LineStyle)178,
			"pushPinNote2",
			(LineStyle)177,
			"pyramids",
			(LineStyle)179,
			"pyramidsAbove",
			(LineStyle)180,
			"quadrants",
			(LineStyle)181,
			"rings",
			(LineStyle)182,
			"safari",
			(LineStyle)183,
			"sawtooth",
			(LineStyle)184,
			"sawtoothGray",
			(LineStyle)185,
			"scaredCat",
			(LineStyle)186,
			"seattle",
			(LineStyle)187,
			"shadowedSquares",
			(LineStyle)188,
			"sharksTeeth",
			(LineStyle)189,
			"shorebirdTracks",
			(LineStyle)190,
			"skyrocket",
			(LineStyle)191,
			"snowflakeFancy",
			(LineStyle)192,
			"snowflakes",
			(LineStyle)193,
			"sombrero",
			(LineStyle)194,
			"southwest",
			(LineStyle)195,
			"stars",
			(LineStyle)196,
			"starsTop",
			(LineStyle)197,
			"stars3d",
			(LineStyle)198,
			"starsBlack",
			(LineStyle)199,
			"starsShadowed",
			(LineStyle)200,
			"sun",
			(LineStyle)201,
			"swirligig",
			(LineStyle)202,
			"tornPaper",
			(LineStyle)203,
			"tornPaperBlack",
			(LineStyle)204,
			"trees",
			(LineStyle)205,
			"triangleParty",
			(LineStyle)206,
			"triangles",
			(LineStyle)207,
			"tribal1",
			(LineStyle)208,
			"tribal2",
			(LineStyle)209,
			"tribal3",
			(LineStyle)210,
			"tribal4",
			(LineStyle)211,
			"tribal5",
			(LineStyle)212,
			"tribal6",
			(LineStyle)213,
			"twistedLines1",
			(LineStyle)214,
			"twistedLines2",
			(LineStyle)215,
			"vine",
			(LineStyle)216,
			"waveline",
			(LineStyle)217,
			"weavingAngles",
			(LineStyle)218,
			"weavingBraid",
			(LineStyle)219,
			"weavingRibbon",
			(LineStyle)220,
			"weavingStrips",
			(LineStyle)221,
			"whiteFlowers",
			(LineStyle)222,
			"woodwork",
			(LineStyle)223,
			"xIllusions",
			(LineStyle)224,
			"zanyTriangles",
			(LineStyle)225,
			"zigZag",
			(LineStyle)226,
			"zigZagStitch",
			(LineStyle)227,
			"earth3",
			(LineStyle)228,
			"triangle1",
			(LineStyle)229,
			"triangle2",
			(LineStyle)230,
			"triangleCircle1",
			(LineStyle)231,
			"triangleCircle2",
			(LineStyle)232,
			"shapes1",
			(LineStyle)233,
			"shapes2",
			(LineStyle)234,
			"custom",
			(LineStyle)235
		}, x6c5de3a2457ca7d0, x65ef1927db6b8083);
		x682712679dbc585a.x70fa1602ceccddee(new object[120]
		{
			"decimal",
			NumberStyle.Arabic,
			"upperRoman",
			NumberStyle.UppercaseRoman,
			"lowerRoman",
			NumberStyle.LowercaseRoman,
			"upperLetter",
			NumberStyle.UppercaseLetter,
			"lowerLetter",
			NumberStyle.LowercaseLetter,
			"ordinal",
			NumberStyle.Ordinal,
			"cardinalText",
			NumberStyle.Number,
			"ordinalText",
			NumberStyle.OrdinalText,
			"hex",
			NumberStyle.Hex,
			"chicago",
			NumberStyle.ChicagoManual,
			"ideographDigital",
			NumberStyle.Kanji,
			"japaneseCounting",
			NumberStyle.KanjiDigit,
			"aiueo",
			NumberStyle.AiueoHalfWidth,
			"iroha",
			NumberStyle.IrohaHalfWidth,
			"decimalFullWidth",
			NumberStyle.ArabicFullWidth,
			"decimalHalfWidth",
			NumberStyle.ArabicHalfWidth,
			"japaneseLegal",
			NumberStyle.KanjiTraditional,
			"japaneseDigitalTenThousand",
			NumberStyle.KanjiTraditional2,
			"decimalEnclosedCircle",
			NumberStyle.NumberInCircle,
			"decimalFullWidth2",
			NumberStyle.DecimalFullWidth,
			"aiueoFullWidth",
			NumberStyle.Aiueo,
			"irohaFullWidth",
			NumberStyle.Iroha,
			"decimalZero",
			NumberStyle.LeadingZero,
			"bullet",
			NumberStyle.Bullet,
			"ganada",
			NumberStyle.Ganada,
			"chosung",
			NumberStyle.Chosung,
			"decimalEnclosedFullstop",
			NumberStyle.GB1,
			"decimalEnclosedParen",
			NumberStyle.GB2,
			"decimalEnclosedCircleChinese",
			NumberStyle.GB3,
			"ideographEnclosedCircle",
			NumberStyle.GB4,
			"ideographTraditional",
			NumberStyle.Zodiac1,
			"ideographZodiac",
			NumberStyle.Zodiac2,
			"ideographZodiacTraditional",
			NumberStyle.Zodiac3,
			"taiwaneseCounting",
			NumberStyle.TradChinNum1,
			"ideographLegalTraditional",
			NumberStyle.TradChinNum2,
			"taiwaneseCountingThousand",
			NumberStyle.TradChinNum3,
			"taiwaneseDigital",
			NumberStyle.TradChinNum4,
			"chineseCounting",
			NumberStyle.SimpChinNum1,
			"chineseLegalSimplified",
			NumberStyle.SimpChinNum2,
			"chineseCountingThousand",
			NumberStyle.SimpChinNum3,
			"koreanDigital",
			NumberStyle.HanjaRead,
			"koreanCounting",
			NumberStyle.HanjaReadDigit,
			"koreanLegal",
			NumberStyle.Hangul,
			"koreanDigital2",
			NumberStyle.Hanja,
			"vietnameseCounting",
			NumberStyle.VietCardinalText,
			"russianLower",
			NumberStyle.LowercaseRussian,
			"russianUpper",
			NumberStyle.UppercaseRussian,
			"none",
			NumberStyle.None,
			"numberInDash",
			NumberStyle.NumberInDash,
			"hebrew1",
			NumberStyle.Hebrew1,
			"hebrew2",
			NumberStyle.Hebrew2,
			"arabicAlpha",
			NumberStyle.Arabic1,
			"arabicAbjad",
			NumberStyle.Arabic2,
			"hindiVowels",
			NumberStyle.HindiLetter1,
			"hindiConsonants",
			NumberStyle.HindiLetter2,
			"hindiNumbers",
			NumberStyle.HindiArabic,
			"hindiCounting",
			NumberStyle.HindiCardinalText,
			"thaiLetters",
			NumberStyle.ThaiLetter,
			"thaiNumbers",
			NumberStyle.ThaiArabic,
			"thaiCounting",
			NumberStyle.ThaiCardinalText
		}, x9bea6158983963ae, x9ab984f31b39762c);
		x682712679dbc585a.x70fa1602ceccddee(new object[8]
		{
			"paragraph",
			StyleType.Paragraph,
			"character",
			StyleType.Character,
			"table",
			StyleType.Table,
			"numbering",
			StyleType.List
		}, x73b371e817d6608f, xdd1c5b917fe6db60);
		x682712679dbc585a.x70fa1602ceccddee(new object[12]
		{
			"auto",
			FontFamily.Auto,
			"decorative",
			FontFamily.Decorative,
			"modern",
			FontFamily.Modern,
			"roman",
			FontFamily.Roman,
			"script",
			FontFamily.Script,
			"swiss",
			FontFamily.Swiss
		}, xe9262ddc4a1310be, x72699d9802e89fa9);
		x682712679dbc585a.x70fa1602ceccddee(new object[8]
		{
			"normal",
			x101cddc73c4f8cc2.xe9e531d1a6725226,
			"separator",
			x101cddc73c4f8cc2.xa1e2a8ed32a026dd,
			"continuationSeparator",
			x101cddc73c4f8cc2.xeab6532eb0797a6e,
			"continuationNotice",
			x101cddc73c4f8cc2.x1e0d716fba95db43
		}, x3b80923725adcc95, x794190cd4a2911f2);
		x682712679dbc585a.x70fa1602ceccddee(new object[8]
		{
			"normal",
			x101cddc73c4f8cc2.xe9e531d1a6725226,
			"separator",
			x101cddc73c4f8cc2.x0affbe34bb1f8b8b,
			"continuationSeparator",
			x101cddc73c4f8cc2.x354a2c7b596483f1,
			"continuationNotice",
			x101cddc73c4f8cc2.x281934d7c2c96a88
		}, xe7e8589552878651, xefc12086fba9146e);
		x682712679dbc585a.x70fa1602ceccddee(new object[6]
		{
			"content",
			BuildingBlockBehavior.Content,
			"p",
			BuildingBlockBehavior.Paragraph,
			"pg",
			BuildingBlockBehavior.Page
		}, x22683027e9e0cb41, xcb5781683033819b);
		x682712679dbc585a.x70fa1602ceccddee(new object[76]
		{
			"any",
			BuildingBlockGallery.All,
			"autoTxt",
			BuildingBlockGallery.AutoText,
			"bib",
			BuildingBlockGallery.Bibliography,
			"coverPg",
			BuildingBlockGallery.CoverPage,
			"custAutoTxt",
			BuildingBlockGallery.CustomAutoText,
			"custBib",
			BuildingBlockGallery.CustomBibliography,
			"custCoverPg",
			BuildingBlockGallery.CustomCoverPage,
			"custEq",
			BuildingBlockGallery.CustomEquations,
			"custFtrs",
			BuildingBlockGallery.CustomFooters,
			"custHdrs",
			BuildingBlockGallery.CustomHeaders,
			"custom1",
			BuildingBlockGallery.Custom1,
			"custom2",
			BuildingBlockGallery.Custom2,
			"custom3",
			BuildingBlockGallery.Custom3,
			"custom4",
			BuildingBlockGallery.Custom4,
			"custom5",
			BuildingBlockGallery.Custom5,
			"custPgNum",
			BuildingBlockGallery.CustomPageNumber,
			"custPgNumB",
			BuildingBlockGallery.CustomPageNumberAtBottom,
			"custPgNumMargins",
			BuildingBlockGallery.CustomPageNumberAtMargin,
			"custPgNumT",
			BuildingBlockGallery.CustomPageNumberAtTop,
			"custQuickParts",
			BuildingBlockGallery.CustomQuickParts,
			"custTblOfContents",
			BuildingBlockGallery.CustomTableOfContents,
			"custTbls",
			BuildingBlockGallery.CustomTables,
			"custTxtBox",
			BuildingBlockGallery.CustomTextBox,
			"custWatermarks",
			BuildingBlockGallery.CustomWatermarks,
			"default",
			BuildingBlockGallery.NoGallery,
			"docParts",
			BuildingBlockGallery.QuickParts,
			"eq",
			BuildingBlockGallery.Equations,
			"ftrs",
			BuildingBlockGallery.Footers,
			"hdrs",
			BuildingBlockGallery.Headers,
			"pgNum",
			BuildingBlockGallery.PageNumber,
			"pgNumB",
			BuildingBlockGallery.PageNumberAtBottom,
			"pgNumMargins",
			BuildingBlockGallery.PageNumberAtMargin,
			"pgNumT",
			BuildingBlockGallery.PageNumberAtTop,
			"placeholder",
			BuildingBlockGallery.StructuredDocumentTagPlaceholderText,
			"tblOfContents",
			BuildingBlockGallery.TableOfContents,
			"tbls",
			BuildingBlockGallery.Tables,
			"txtBox",
			BuildingBlockGallery.TextBox,
			"watermarks",
			BuildingBlockGallery.Watermarks
		}, x319dd4af40612e63, xd955a100d2abba45);
		x682712679dbc585a.x70fa1602ceccddee(new object[14]
		{
			"autoExp",
			BuildingBlockType.AutomaticallyReplaceNameWithContent,
			"bbPlcHdr",
			BuildingBlockType.StructuredDocumentTagPlaceholderText,
			"formFld",
			BuildingBlockType.FormFieldHelpText,
			"none",
			BuildingBlockType.None,
			"normal",
			BuildingBlockType.Normal,
			"speller",
			BuildingBlockType.AutoCorrect,
			"toolbar",
			BuildingBlockType.AutoText
		}, xcaaf1234ce2ce658, x0d30864f95267756);
		x682712679dbc585a.x70fa1602ceccddee(new object[28]
		{
			"gregorian",
			SdtCalendarType.Default,
			"gregorianArabic",
			SdtCalendarType.GregorianArabic,
			"gregorianMeFrench",
			SdtCalendarType.GregorianMeFrench,
			"gregorianUs",
			SdtCalendarType.GregorianUs,
			"gregorianXlitEnglish",
			SdtCalendarType.GregorianXlitEnglish,
			"gregorianXlitFrench",
			SdtCalendarType.GregorianXlitFrench,
			"hebrew",
			SdtCalendarType.Hebrew,
			"hijri",
			SdtCalendarType.Hijri,
			"japan",
			SdtCalendarType.Japan,
			"korea",
			SdtCalendarType.Korea,
			"none",
			SdtCalendarType.None,
			"saka",
			SdtCalendarType.Saka,
			"taiwan",
			SdtCalendarType.Taiwan,
			"thai",
			SdtCalendarType.Thai
		}, x74973c689ff24c94, x7bc9a24572f5d402);
		x682712679dbc585a.x70fa1602ceccddee(new object[8]
		{
			"contentLocked",
			xed92c0eace754ea8.x33eef8a5371b8ebb,
			"sdtContentLocked",
			xed92c0eace754ea8.xc2ab81b8dd700ffa,
			"sdtLocked",
			xed92c0eace754ea8.x7ac4b04ce84a953d,
			"unlocked",
			xed92c0eace754ea8.x3f5233cee263582a
		}, x7eaaf5bf61bd29b7, x9bc677c63cd40eab);
		x682712679dbc585a.x70fa1602ceccddee(new object[6]
		{
			"date",
			SdtDateStorageFormat.Date,
			"dateTime",
			SdtDateStorageFormat.DateTime,
			"text",
			SdtDateStorageFormat.Text
		}, x52fe2e3b3e643280, xc247a636e8ba04ef);
		x682712679dbc585a.x70fa1602ceccddee(new object[8]
		{
			"center",
			x2cdbcd6273a149f1.x58d2ccae3c5cfd08,
			"centerGroup",
			x2cdbcd6273a149f1.xfa862982140742a7,
			"left",
			x2cdbcd6273a149f1.x72d92bd1aff02e37,
			"right",
			x2cdbcd6273a149f1.x419ba17a5322627b
		}, xb0e492a146b7703c, x2c9d6348c4e4fb99);
		x682712679dbc585a.x70fa1602ceccddee(new object[12]
		{
			"double-struck",
			x1380d412169e361b.x6caf2ed80f7f7cad,
			"fraktur",
			x1380d412169e361b.xf54ded90c5976d3f,
			"monospace",
			x1380d412169e361b.x57334313ed681c9e,
			"roman",
			x1380d412169e361b.x4316791d2bbd0ab1,
			"sans-serif",
			x1380d412169e361b.x0bd07d871b3e44a4,
			"script",
			x1380d412169e361b.x838b2dfd1391264c
		}, x18cd3e5233bca5d6, x7db7e13c9382cd9b);
		x682712679dbc585a.x70fa1602ceccddee(new object[8]
		{
			"p",
			x65251a26aa8f6af1.x4910eaed3e6c4632,
			"b",
			x65251a26aa8f6af1.x4e1d3347e7864b81,
			"i",
			x65251a26aa8f6af1.x00d0ae795109fe11,
			"bi",
			x65251a26aa8f6af1.x39fa99c7686bd7dd
		}, x07eece04bf9e2009, xc1cc946d852af211);
		x682712679dbc585a.x70fa1602ceccddee(new object[4]
		{
			"top",
			xce8b2ce767b2485c.xe360b1885d8d4a41,
			"bot",
			xce8b2ce767b2485c.x9bcb07e204e30218
		}, xa564a8d018a94177, x98d3a093e5d8014f);
		x682712679dbc585a.x70fa1602ceccddee(new object[4]
		{
			"centered",
			x6813eed7028d8bfc.xf2957594ee857616,
			"match",
			x6813eed7028d8bfc.x99cb021702583392
		}, x2089ea1c6b07a0f6, xfe676dc13f72a3d0);
		x682712679dbc585a.x70fa1602ceccddee(new object[4]
		{
			"top",
			x63bdb8b878b040d9.xe360b1885d8d4a41,
			"bot",
			x63bdb8b878b040d9.x9bcb07e204e30218
		}, xcbd984a0f8b88ca9, xc6f1f9387268ddcc);
		x682712679dbc585a.x70fa1602ceccddee(new object[8]
		{
			"bar",
			x890a027c82a36a95.xced856c17df679c5,
			"lin",
			x890a027c82a36a95.x38d4db9419f3b510,
			"noBar",
			x890a027c82a36a95.xa1886b914486c170,
			"skw",
			x890a027c82a36a95.x7ccdf8314e1f1193
		}, x7a35f6fde9cacc6c, x36dac7801e50f147);
		x682712679dbc585a.x70fa1602ceccddee(new object[4]
		{
			"subSup",
			xf47bac63068c8fd6.x44da4836b2a87e96,
			"undOvr",
			xf47bac63068c8fd6.x8e321c5b5aaa4dd5
		}, xd854d8bffdec10a2, x877b7534493f59bb);
		x682712679dbc585a.x70fa1602ceccddee(new object[6]
		{
			"center",
			x55477ca1c0c8419f.x58d2ccae3c5cfd08,
			"left",
			x55477ca1c0c8419f.x72d92bd1aff02e37,
			"right",
			x55477ca1c0c8419f.x419ba17a5322627b
		}, x25e2c8dd9c536abf, xd2469845066b0fae);
		x682712679dbc585a.x70fa1602ceccddee(new object[10]
		{
			"dot",
			x84d41ac121232475.x3cb6807e93737c2d,
			"hyphen",
			x84d41ac121232475.x8e836880cbe4ad3d,
			"middleDot",
			x84d41ac121232475.xf15c6e29f02316fc,
			"none",
			x84d41ac121232475.x4d0b9d4447ba7566,
			"underscore",
			x84d41ac121232475.x05249333ba886290
		}, x6eaf1ef0b18e67bf, x1fd54e86e256e2d3);
		x682712679dbc585a.x70fa1602ceccddee(new object[4]
		{
			"indent",
			x932d11b236987c0e.x941a43d4a5637fd0,
			"margin",
			x932d11b236987c0e.x6545d1f2c1b77773
		}, x214f7ea4e68dc502, x1951b2f659b38012);
	}
}
