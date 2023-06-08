using System;
using System.ComponentModel;
using System.Diagnostics;
using Aspose.Words.Lists;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;

namespace Aspose.Words;

public class Style : xf5ecf429e74b1c04, xac4d96a62eaba39e
{
	internal const int xe9bf0a15c22cac0c = 99;

	internal bool x4848603eaf370e03;

	internal bool xcbf95a2bd7b4de24;

	internal bool x698badc7f383579c;

	private int x4fc5fed87021d99c = 4095;

	private StyleIdentifier x4246004ab2c877f4 = StyleIdentifier.Nil;

	private StyleIdentifier x60e218947b7f3292 = StyleIdentifier.Nil;

	private StyleType xf263b01e2956834c;

	private int x0858b814c43fa1b9 = 4095;

	private int x59970005aadbe03d = 4095;

	private bool xeeaa05290619d75b;

	private bool x134d52bd2a1e49cd;

	private bool x6e75d86e07e07fee;

	private bool x7255a5813e71e9fc;

	private bool x16c01d3465569fed;

	private bool x4176e2f70fa05c1d;

	private int xb27bacee944055a0;

	private bool x13fef4e814ebd03d;

	private bool xaf4a6e7c9086b11d;

	private bool x46fd33425ff09ffa;

	private bool x4d5686d9270e6622;

	private int x6c9707de3fd8e38f = 4095;

	private int x04b0264cad2c87d5;

	private string xc61ff88f1f98652d;

	private x1a78664fa10a3755 x4379ee33a06c4648 = new x1a78664fa10a3755();

	private xeedad81aaed42a76 xd0c44e5ae0011daa = new xeedad81aaed42a76();

	private StyleCollection x18c770831ef0bf38;

	private Font x154caea24cfa721a;

	private ParagraphFormat x8509a7eae96be56b;

	private ListFormat xe05491d392a44018;

	public string Name
	{
		get
		{
			return xc61ff88f1f98652d;
		}
		set
		{
			if (!x0d299f323d241756.x5959bccb67bbf051(value))
			{
				throw new ArgumentException("Style name can not be empty.");
			}
			Style style = x18c770831ef0bf38.xe931c242f6b9055f(value, x988fcf605f8efa7e: false);
			if (style != null)
			{
				xd01720d5ff2238cc(style.x8301ab10c226b0c2, x6d60cf0a80bb0eb6: true);
			}
			xd9263e6f13384bf1.x2bb7806b0066b22a(this, value);
			x2b8399f052630a13(value, x6d60cf0a80bb0eb6: true);
		}
	}

	public StyleIdentifier StyleIdentifier => x4246004ab2c877f4;

	internal StyleIdentifier x28c6c3680e11266a => x60e218947b7f3292;

	public bool IsHeading
	{
		get
		{
			if (StyleIdentifier >= StyleIdentifier.Heading1)
			{
				return StyleIdentifier <= StyleIdentifier.Heading9;
			}
			return false;
		}
	}

	public StyleType Type => xf263b01e2956834c;

	public DocumentBase Document
	{
		get
		{
			if (x18c770831ef0bf38 == null)
			{
				return null;
			}
			return x18c770831ef0bf38.Document;
		}
	}

	public string BaseStyleName
	{
		get
		{
			Style style = xea729b8c7bbb5bb0();
			if (style == null)
			{
				return "";
			}
			return style.Name;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (xf263b01e2956834c != StyleType.Character && xf263b01e2956834c != StyleType.Paragraph)
			{
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ccciddjibdajidhjconjpcfkocmkicdlgcklibbmccimbcpmdcgnhmmnnaeoebloolbpkajpgaaabahalaoapkebnolbfpcccpjccpadhphdcoodonfehjmekndfaokfaobgliiglmpgnmghdmnhbneinllimlcjkmjjilakcmhkngoklkflflmlikdmbgkmokbnmjinkkpngjgojjnobkepnilpjjcaoijadeabdjhbbjobdjfcdimcjhddeikdmdbe", 1990689230)));
			}
			if (x4246004ab2c877f4 == StyleIdentifier.Normal || x4246004ab2c877f4 == StyleIdentifier.DefaultParagraphFont)
			{
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("cfikdgpknfglfbnlefemeglmffcnffjnkfaoabhojeoolefpkplpkedaiekakebbkdibadpbldgcfomcabedocldoccegcjehbafpbhfannfoafgibmgladhemjhfoaidaiibapijpfjkanjopdkdalkmkbljnilhoplfpgmbonmeoenmolnincoeojojnapoihpblophnfadnmagndbphkbplbcklicempcbmgdplndbmeekglejkcfjkjfbgagakhgmjoglkfhkjmhgjdipekiljbjhjijgepjeigkoinkgjelkdllkicmiijmkiankhhnahongdfo", 107522046)));
			}
			if (value == "")
			{
				x0858b814c43fa1b9 = 4095;
				return;
			}
			Style style = x18c770831ef0bf38.xfee6a7b399450516(value);
			x74ad41e8c12b8116(style, x9199ed88324d69ff: true);
			x0858b814c43fa1b9 = style.x8301ab10c226b0c2;
		}
	}

	public string NextParagraphStyleName
	{
		get
		{
			Style style = x72896b10f838c181();
			if (style == null)
			{
				return "";
			}
			return style.Name;
		}
		set
		{
			if (xf263b01e2956834c != StyleType.Paragraph)
			{
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("kggolhnojhepailpkccahhjaghabahhbogobagfckgmcjgddlgkdpabeffiemfpegagfeenfmeegjelgjechoejhjdaifdhioonikdfjgdmjbddkldkkpnalccilicplicgmdnmmacenoalnmbcoiajolaapdbhpppnplafaaamaflcbfakbdabcfaicfpoclofdgpmdokde", 1075897878)));
			}
			x0d299f323d241756.x48501aec8e48c869(value, "value");
			Style style = x18c770831ef0bf38.xfee6a7b399450516(value);
			x59970005aadbe03d = style.x8301ab10c226b0c2;
		}
	}

	public bool BuiltIn => x4246004ab2c877f4 != StyleIdentifier.User;

	public Font Font
	{
		get
		{
			if (xf263b01e2956834c == StyleType.List)
			{
				return null;
			}
			if (x154caea24cfa721a == null)
			{
				x154caea24cfa721a = new Font(this, x18c770831ef0bf38);
			}
			return x154caea24cfa721a;
		}
	}

	public ParagraphFormat ParagraphFormat
	{
		get
		{
			if (xf263b01e2956834c == StyleType.Character || xf263b01e2956834c == StyleType.List)
			{
				return null;
			}
			if (x8509a7eae96be56b == null)
			{
				x8509a7eae96be56b = new ParagraphFormat(this, Styles);
			}
			return x8509a7eae96be56b;
		}
	}

	public List List
	{
		get
		{
			if (xf263b01e2956834c != StyleType.List)
			{
				return null;
			}
			if (Document == null)
			{
				return null;
			}
			return Document.Lists.x6c3daa8c787e54bf(x4379ee33a06c4648.x71c63f7e57f7ede5);
		}
	}

	public ListFormat ListFormat
	{
		get
		{
			if (xf263b01e2956834c != StyleType.Paragraph)
			{
				return null;
			}
			if (Document == null)
			{
				return null;
			}
			if (xe05491d392a44018 == null)
			{
				xe05491d392a44018 = new ListFormat(this, Document.Lists);
			}
			return xe05491d392a44018;
		}
	}

	internal int x8301ab10c226b0c2 => x4fc5fed87021d99c;

	internal int xe709b224f455b863
	{
		get
		{
			return x0858b814c43fa1b9;
		}
		set
		{
			x0858b814c43fa1b9 = value;
			xea50013a31472e8a();
		}
	}

	internal int xfb77c9ea054ac31c
	{
		get
		{
			return x59970005aadbe03d;
		}
		set
		{
			x59970005aadbe03d = value;
		}
	}

	internal int x4cf1854ef833220f
	{
		get
		{
			return x6c9707de3fd8e38f;
		}
		set
		{
			x6c9707de3fd8e38f = value;
			xea50013a31472e8a();
		}
	}

	internal int xe12a6bc6d222e782
	{
		get
		{
			return x04b0264cad2c87d5;
		}
		set
		{
			x04b0264cad2c87d5 = value;
		}
	}

	internal bool x913ff5916b187824
	{
		get
		{
			return xeeaa05290619d75b;
		}
		set
		{
			xeeaa05290619d75b = value;
		}
	}

	internal bool x96e55b5d052d1279
	{
		get
		{
			return x134d52bd2a1e49cd;
		}
		set
		{
			x134d52bd2a1e49cd = value;
		}
	}

	internal bool x45101ac87546632f
	{
		get
		{
			return x6e75d86e07e07fee;
		}
		set
		{
			x6e75d86e07e07fee = value;
		}
	}

	internal bool x2d8aaa05bddcf40c
	{
		get
		{
			return x7255a5813e71e9fc;
		}
		set
		{
			x7255a5813e71e9fc = value;
		}
	}

	internal bool x5356a3af7e7ecdfa
	{
		get
		{
			return x16c01d3465569fed;
		}
		set
		{
			x16c01d3465569fed = value;
		}
	}

	internal bool xebe0f6c7e6f4ae3a
	{
		get
		{
			return x4176e2f70fa05c1d;
		}
		set
		{
			x4176e2f70fa05c1d = value;
		}
	}

	internal int x9eb07da9aa5bbf9e
	{
		get
		{
			return xb27bacee944055a0;
		}
		set
		{
			xb27bacee944055a0 = value;
		}
	}

	internal bool xde61abbe9514a1ee
	{
		get
		{
			return x13fef4e814ebd03d;
		}
		set
		{
			x13fef4e814ebd03d = value;
		}
	}

	internal bool x3bbb21ee843f081c
	{
		get
		{
			return xaf4a6e7c9086b11d;
		}
		set
		{
			xaf4a6e7c9086b11d = value;
		}
	}

	internal bool xdf3672ec434b4524
	{
		get
		{
			return x46fd33425ff09ffa;
		}
		set
		{
			x46fd33425ff09ffa = value;
		}
	}

	internal bool x5463d55288b12514
	{
		get
		{
			return x4d5686d9270e6622;
		}
		set
		{
			x4d5686d9270e6622 = value;
		}
	}

	internal bool x114c8a4fcd139550
	{
		get
		{
			if (Type == StyleType.Paragraph)
			{
				return xe709b224f455b863 == 4095;
			}
			return false;
		}
	}

	public StyleCollection Styles => x18c770831ef0bf38;

	internal x1a78664fa10a3755 x1a78664fa10a3755
	{
		get
		{
			return x4379ee33a06c4648;
		}
		set
		{
			x4379ee33a06c4648 = value;
		}
	}

	internal xeedad81aaed42a76 xeedad81aaed42a76
	{
		get
		{
			return xd0c44e5ae0011daa;
		}
		set
		{
			xd0c44e5ae0011daa = value;
		}
	}

	internal bool xcb78713836fcc98a
	{
		get
		{
			if (!xeedad81aaed42a76.x0f53f53f15b61ef5)
			{
				return x1a78664fa10a3755.x0f53f53f15b61ef5;
			}
			return true;
		}
	}

	int xac4d96a62eaba39e.x91bf5a97a0401465 => x4379ee33a06c4648.xd44988f225497f3a;

	int xf5ecf429e74b1c04.x5b8c6010012a5955 => xd0c44e5ae0011daa.xd44988f225497f3a;

	internal static Style xebcf83b00134300b(StyleType x4320c3ef9926c38d)
	{
		switch (x4320c3ef9926c38d)
		{
		case StyleType.Paragraph:
		case StyleType.Character:
		case StyleType.List:
			return new Style(x4320c3ef9926c38d);
		case StyleType.Table:
			return new TableStyle();
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("epfbkanbeaecealccacdhajdlppdkkgekpneipefkplfkocgaojgijahjohhloohpnfibnmihjdj", 1644434847)));
		}
	}

	internal static Style xebcf83b00134300b(StyleType x4320c3ef9926c38d, int xddd12ddd8b1e4a90, StyleIdentifier xa3be2ccad541ab25, string xc15bd84e01929885)
	{
		Style style = xebcf83b00134300b(x4320c3ef9926c38d);
		style.x4fc5fed87021d99c = xddd12ddd8b1e4a90;
		style.x4246004ab2c877f4 = xa3be2ccad541ab25;
		style.xc61ff88f1f98652d = xc15bd84e01929885;
		style.x59970005aadbe03d = xddd12ddd8b1e4a90;
		return style;
	}

	protected Style(StyleType styleType)
	{
		xf263b01e2956834c = styleType;
	}

	internal void x2b8399f052630a13(string xbcea506a33cf9111, bool x6d60cf0a80bb0eb6)
	{
		if (x6d60cf0a80bb0eb6)
		{
			x18c770831ef0bf38.xe757cf2edd1c4b6a(this, xc61ff88f1f98652d, xbcea506a33cf9111);
		}
		xc61ff88f1f98652d = xbcea506a33cf9111;
	}

	internal void x2b8399f052630a13(string xbcea506a33cf9111)
	{
		x2b8399f052630a13(xbcea506a33cf9111, x6d60cf0a80bb0eb6: false);
	}

	internal virtual Style x8b61531c8ea35b85()
	{
		Style style = (Style)MemberwiseClone();
		x1a78664fa10a3755 x1a78664fa10a = (x1a78664fa10a3755)x4379ee33a06c4648.x8b61531c8ea35b85();
		style.x4379ee33a06c4648 = x1a78664fa10a;
		xeedad81aaed42a76 xeedad81aaed42a = (xeedad81aaed42a76)xd0c44e5ae0011daa.x8b61531c8ea35b85();
		style.xd0c44e5ae0011daa = xeedad81aaed42a;
		style.x18c770831ef0bf38 = null;
		style.x154caea24cfa721a = null;
		style.x8509a7eae96be56b = null;
		style.xe05491d392a44018 = null;
		style.x60e218947b7f3292 = x4246004ab2c877f4;
		return style;
	}

	internal void x17151e7d3bf9d07d(StyleCollection x3fa6ecdd18b2ff6e)
	{
		x18c770831ef0bf38 = x3fa6ecdd18b2ff6e;
	}

	internal void xfce32590a83c73b0(StyleType x4320c3ef9926c38d)
	{
		xf263b01e2956834c = x4320c3ef9926c38d;
	}

	internal void xd01720d5ff2238cc(int xddd12ddd8b1e4a90)
	{
		xd01720d5ff2238cc(xddd12ddd8b1e4a90, x6d60cf0a80bb0eb6: false);
	}

	internal void xd01720d5ff2238cc(int xddd12ddd8b1e4a90, bool x6d60cf0a80bb0eb6)
	{
		if (x6d60cf0a80bb0eb6)
		{
			x18c770831ef0bf38.x30a673601c168f37(this, x8301ab10c226b0c2, xddd12ddd8b1e4a90);
		}
		x4fc5fed87021d99c = xddd12ddd8b1e4a90;
		xea50013a31472e8a();
		switch (xf263b01e2956834c)
		{
		case StyleType.Paragraph:
		case StyleType.List:
			x4379ee33a06c4648.x8301ab10c226b0c2 = xddd12ddd8b1e4a90;
			break;
		case StyleType.Character:
			xd0c44e5ae0011daa.x8301ab10c226b0c2 = xddd12ddd8b1e4a90;
			break;
		case StyleType.Table:
			break;
		}
	}

	internal void x7ac71dcbd33d6241(StyleIdentifier xa3be2ccad541ab25)
	{
		x7ac71dcbd33d6241(xa3be2ccad541ab25, x6d60cf0a80bb0eb6: false);
	}

	internal void x7ac71dcbd33d6241(StyleIdentifier xa3be2ccad541ab25, bool x6d60cf0a80bb0eb6)
	{
		if (x6d60cf0a80bb0eb6)
		{
			x18c770831ef0bf38.xcac14b89627cf9dc(this, StyleIdentifier, xa3be2ccad541ab25);
		}
		x4246004ab2c877f4 = xa3be2ccad541ab25;
	}

	internal Style xea729b8c7bbb5bb0()
	{
		xea50013a31472e8a();
		if (x0858b814c43fa1b9 == 4095)
		{
			return null;
		}
		return x18c770831ef0bf38.xf194004582627ed5(x0858b814c43fa1b9, 4095);
	}

	internal Style x72896b10f838c181()
	{
		if (x59970005aadbe03d == 4095)
		{
			return null;
		}
		return x18c770831ef0bf38.xf194004582627ed5(x59970005aadbe03d, x4fc5fed87021d99c);
	}

	internal Style xe617ec963a7004e3()
	{
		xea50013a31472e8a();
		if (x6c9707de3fd8e38f == 4095)
		{
			return null;
		}
		return x18c770831ef0bf38.xf194004582627ed5(x6c9707de3fd8e38f, 4095);
	}

	internal virtual bool x4a6c2b56be2364cf()
	{
		if (x4379ee33a06c4648.xd44988f225497f3a > 0)
		{
			return true;
		}
		if (xd0c44e5ae0011daa.xd44988f225497f3a > 0)
		{
			return true;
		}
		return false;
	}

	private void xea50013a31472e8a()
	{
		if (x0858b814c43fa1b9 == x4fc5fed87021d99c)
		{
			x0858b814c43fa1b9 = 4095;
		}
		if (x6c9707de3fd8e38f == x4fc5fed87021d99c)
		{
			x6c9707de3fd8e38f = 4095;
		}
	}

	internal void xb5c8f7c15000a29f()
	{
		if (x0858b814c43fa1b9 != 4095 && x18c770831ef0bf38.x1976fb6958cf7237(x0858b814c43fa1b9, x988fcf605f8efa7e: true) == null)
		{
			x0858b814c43fa1b9 = 4095;
		}
	}

	internal void x8b31be6b0ff92506()
	{
		if (!x74ad41e8c12b8116(xea729b8c7bbb5bb0(), x9199ed88324d69ff: false))
		{
			x0858b814c43fa1b9 = 4095;
		}
	}

	private bool x74ad41e8c12b8116(Style x36e1f2c31870cf57, bool x9199ed88324d69ff)
	{
		while (x36e1f2c31870cf57 != null)
		{
			if (x36e1f2c31870cf57.xf263b01e2956834c != xf263b01e2956834c)
			{
				if (x9199ed88324d69ff)
				{
					throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("cmcdnnjdhoaeeohecooeeoffnimfmmdgimkghnbhgmihohphmlgiihniimejgmljimckiljkokalgghlclolokfmnfmmljdnhfknhkbofkiohkpohjgpninpfeeabjlaficbmdjbnhacphhcjhocghfdchmdmhdemgkechbffhifobpfpgggbhngfgehhflhnbci", 1058026111)));
				}
				return false;
			}
			if (x36e1f2c31870cf57.x4fc5fed87021d99c == x4fc5fed87021d99c)
			{
				if (x9199ed88324d69ff)
				{
					throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("jjefkklfikcgpkjgjfahfkhhdkohfjfipjmilidjljkjnibkajikmipkldglpinlohemohlmlhcnmcjnmgaoihhoigoobgfpbhmppfdahbkaffbbbbibbfpbefgckfncieedhfldlecendjeleafgpgffeoffdfgddmgpcdhjdkhjcbipciibcpiacgjinmjhbekhblkdccldcjloaamlahmbbomamenabmnoadoabkoaabpgphpbappjlfa", 880038981)));
				}
				return false;
			}
			x36e1f2c31870cf57 = x36e1f2c31870cf57.xea729b8c7bbb5bb0();
		}
		return true;
	}

	internal void x7dbbdff0e18dae2c(x1a78664fa10a3755 xb3e285984f5ad9d1, xd9bc7f7e70d71e14 xebf45bdcaa1fd1e1)
	{
		xea729b8c7bbb5bb0()?.x7dbbdff0e18dae2c(xb3e285984f5ad9d1, xebf45bdcaa1fd1e1);
		object obj = x4379ee33a06c4648.xf7866f89640a29a3(1120);
		object obj2 = x4379ee33a06c4648.xf7866f89640a29a3(1110);
		xb3e285984f5ad9d1.xc6dffc0c16c55f7a(1120, obj);
		xb3e285984f5ad9d1.xc6dffc0c16c55f7a(1110, obj2);
		if (obj != null || obj2 != null)
		{
			int x71c63f7e57f7ede = xb3e285984f5ad9d1.x71c63f7e57f7ede5;
			if (x71c63f7e57f7ede != 0)
			{
				List list = Document.Lists.xceb66bfa0e6b60c7(x71c63f7e57f7ede);
				ListLevel listLevel = list.x1fc16b41653eb571(xb3e285984f5ad9d1.xf13a626e550cef8f);
				listLevel.x1a78664fa10a3755.xab3af626b1405ee8(xb3e285984f5ad9d1);
			}
			else
			{
				xb3e285984f5ad9d1.x1b019dd27f0dce72();
			}
		}
		x4379ee33a06c4648.xab3af626b1405ee8(xb3e285984f5ad9d1);
		if ((xebf45bdcaa1fd1e1 & xd9bc7f7e70d71e14.x3968babb3b57e478) != 0)
		{
			xb3e285984f5ad9d1.x3968babb3b57e478();
		}
	}

	internal x1a78664fa10a3755 x2e12c5f9278ae233(xd9bc7f7e70d71e14 xebf45bdcaa1fd1e1)
	{
		x1a78664fa10a3755 x1a78664fa10a = new x1a78664fa10a3755();
		x7dbbdff0e18dae2c(x1a78664fa10a, xebf45bdcaa1fd1e1);
		return x1a78664fa10a;
	}

	internal void x5f851b1938defe5f(xeedad81aaed42a76 x4ac4562403543b7a, xecac24b19ed3a2b7 xebf45bdcaa1fd1e1)
	{
		xea729b8c7bbb5bb0()?.x5f851b1938defe5f(x4ac4562403543b7a, xebf45bdcaa1fd1e1);
		bool flag = (xebf45bdcaa1fd1e1 & xecac24b19ed3a2b7.x87415330d9d0754a) != 0;
		xd0c44e5ae0011daa.xab3af626b1405ee8(x4ac4562403543b7a, flag ? Document.x9bb3f6e28fa55f34() : null);
	}

	internal xeedad81aaed42a76 x856218fd0771d379(xecac24b19ed3a2b7 xebf45bdcaa1fd1e1)
	{
		xeedad81aaed42a76 xeedad81aaed42a = new xeedad81aaed42a76();
		x5f851b1938defe5f(xeedad81aaed42a, xebf45bdcaa1fd1e1);
		return xeedad81aaed42a;
	}

	internal object x61d8cd76508e76c3(int xba08ce632055a1d9, bool x9ee6c2f047893ddc)
	{
		object obj = xd0c44e5ae0011daa.xf7866f89640a29a3(xba08ce632055a1d9);
		if (obj != null)
		{
			if (obj is x9b28b1f7f0cc963f)
			{
				return ((x9b28b1f7f0cc963f)obj).xa1d77f2e7738b62c(this, xba08ce632055a1d9);
			}
			return obj;
		}
		return xa6855fb448244f15(xba08ce632055a1d9, x9ee6c2f047893ddc);
	}

	private object xa6855fb448244f15(int xba08ce632055a1d9, bool x9ee6c2f047893ddc)
	{
		Style style = xea729b8c7bbb5bb0();
		if (style != null)
		{
			return style.x61d8cd76508e76c3(xba08ce632055a1d9, x9ee6c2f047893ddc);
		}
		if (x9ee6c2f047893ddc)
		{
			return x18c770831ef0bf38.x27096df7ca0cfe2e.xfe91eeeafcb3026a(xba08ce632055a1d9);
		}
		return null;
	}

	private void x95cfb6ef0e888214(int xc0c4c459c6ccbd00, out int xba08ce632055a1d9, out object xbcea506a33cf9111)
	{
		xba08ce632055a1d9 = x4379ee33a06c4648.xf15263674eb297bb(xc0c4c459c6ccbd00);
		xbcea506a33cf9111 = x4379ee33a06c4648.x6d3720b962bd3112(xc0c4c459c6ccbd00);
	}

	void xac4d96a62eaba39e.xee440186ba45615a(int xc0c4c459c6ccbd00, out int xba08ce632055a1d9, out object xbcea506a33cf9111)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x95cfb6ef0e888214
		this.x95cfb6ef0e888214(xc0c4c459c6ccbd00, out xba08ce632055a1d9, out xbcea506a33cf9111);
	}

	private void xc6355ea81dc1c54b(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		x4379ee33a06c4648.xae20093bed1e48a8(xba08ce632055a1d9, xbcea506a33cf9111);
	}

	void xac4d96a62eaba39e.xb6157b6da9895c0d(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xc6355ea81dc1c54b
		this.xc6355ea81dc1c54b(xba08ce632055a1d9, xbcea506a33cf9111);
	}

	private void x3ba5b0445ff0a9f8(int xba08ce632055a1d9)
	{
		x4379ee33a06c4648.x52b190e626f65140(xba08ce632055a1d9);
	}

	void xac4d96a62eaba39e.xb55a99e2e1381d7f(int xba08ce632055a1d9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x3ba5b0445ff0a9f8
		this.x3ba5b0445ff0a9f8(xba08ce632055a1d9);
	}

	private void xad212b340baad773()
	{
		x4379ee33a06c4648.ClearAttrs();
	}

	void xac4d96a62eaba39e.x6aea418c3f016cbd()
	{
		//ILSpy generated this explicit interface implementation from .override directive in xad212b340baad773
		this.xad212b340baad773();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public object x51ae400150847113(int xba08ce632055a1d9)
	{
		object obj = xd085e5852dc496c7(xba08ce632055a1d9);
		if (obj != null)
		{
			return obj;
		}
		Style style = xea729b8c7bbb5bb0();
		if (style == null)
		{
			return x18c770831ef0bf38.xf4eb04b8b9073eeb.xc3cc338a59c5293b(xba08ce632055a1d9);
		}
		return style.xc3cc338a59c5293b(xba08ce632055a1d9);
	}

	internal object xd085e5852dc496c7(int xba08ce632055a1d9)
	{
		int x71c63f7e57f7ede = x4379ee33a06c4648.x71c63f7e57f7ede5;
		if (x71c63f7e57f7ede != 0)
		{
			List list = Document.Lists.xceb66bfa0e6b60c7(x71c63f7e57f7ede);
			ListLevel listLevel = list.x1fc16b41653eb571(x4379ee33a06c4648.xf13a626e550cef8f);
			return listLevel.x1a78664fa10a3755.xf7866f89640a29a3(xba08ce632055a1d9);
		}
		return null;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public object xb86fdbeadec3b75c(int xba08ce632055a1d9)
	{
		return x4379ee33a06c4648.xf7866f89640a29a3(xba08ce632055a1d9);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public object xc3cc338a59c5293b(int xba08ce632055a1d9)
	{
		object obj = xb86fdbeadec3b75c(xba08ce632055a1d9);
		if (obj == null)
		{
			return x51ae400150847113(xba08ce632055a1d9);
		}
		return obj;
	}

	private object x93e461c176ca1e50(int xba08ce632055a1d9)
	{
		return xd0c44e5ae0011daa.xf7866f89640a29a3(xba08ce632055a1d9);
	}

	object xf5ecf429e74b1c04.x9bd0b4c41657450b(int xba08ce632055a1d9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x93e461c176ca1e50
		return this.x93e461c176ca1e50(xba08ce632055a1d9);
	}

	private void x9939815f86bdcfc3(int xc0c4c459c6ccbd00, out int xba08ce632055a1d9, out object xbcea506a33cf9111)
	{
		xba08ce632055a1d9 = xd0c44e5ae0011daa.xf15263674eb297bb(xc0c4c459c6ccbd00);
		xbcea506a33cf9111 = xd0c44e5ae0011daa.x6d3720b962bd3112(xc0c4c459c6ccbd00);
	}

	void xf5ecf429e74b1c04.x16b3a875e7cc38ed(int xc0c4c459c6ccbd00, out int xba08ce632055a1d9, out object xbcea506a33cf9111)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x9939815f86bdcfc3
		this.x9939815f86bdcfc3(xc0c4c459c6ccbd00, out xba08ce632055a1d9, out xbcea506a33cf9111);
	}

	private object xa49e661f5cc91e49(int xba08ce632055a1d9)
	{
		return xa6855fb448244f15(xba08ce632055a1d9, x9ee6c2f047893ddc: true);
	}

	object xf5ecf429e74b1c04.x2685f947206319cf(int xba08ce632055a1d9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xa49e661f5cc91e49
		return this.xa49e661f5cc91e49(xba08ce632055a1d9);
	}

	private void x09376e92b9e1f394(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		xd0c44e5ae0011daa.xae20093bed1e48a8(xba08ce632055a1d9, xbcea506a33cf9111);
	}

	void xf5ecf429e74b1c04.xd00aa8389522ce53(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x09376e92b9e1f394
		this.x09376e92b9e1f394(xba08ce632055a1d9, xbcea506a33cf9111);
	}

	private void x69045f836de92891()
	{
		xd0c44e5ae0011daa.ClearAttrs();
	}

	void xf5ecf429e74b1c04.xe80983f2918b2568()
	{
		//ILSpy generated this explicit interface implementation from .override directive in x69045f836de92891
		this.x69045f836de92891();
	}

	[Conditional("ASPOSE_EDITOR")]
	internal static void xcbdf0bfb4ca95676(params object[] xcd31b50c43a96e21)
	{
	}

	[Conditional("ASPOSE_EDITOR")]
	internal void x0f1c14ed23045dd1(params object[] xcd31b50c43a96e21)
	{
	}
}
