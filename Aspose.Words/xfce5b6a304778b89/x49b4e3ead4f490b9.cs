using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Lists;
using x28925c9b27b37a46;
using xbe73d5820f7f4ae3;
using xd2754ae26d400653;
using xf9a9481c3f63a419;

namespace xfce5b6a304778b89;

internal class x49b4e3ead4f490b9
{
	private x49b4e3ead4f490b9()
	{
	}

	internal static void x06b0e25aa6ad68a9(xf871da68decec406 xe134235b3526fa75, bool xafd04c36a00d5bcf)
	{
		x09bf2b07acaf11a4 x09bf2b07acaf11a5 = new x09bf2b07acaf11a4();
		x09bf2b07acaf11a5.x06ca69422bbb7502 = xe134235b3526fa75.x2c8c6741422a1298.Lists.xcf5f82306ceb0bff(x902c8ac86fbaf048.x7e86ac926e2dc940);
		x80e7bc7a8daa7453(xe134235b3526fa75, x09bf2b07acaf11a5);
		xec18743873c63c69(xe134235b3526fa75, x09bf2b07acaf11a5);
		for (int i = 0; i < 9; i++)
		{
			x95973895507fea32 x95973895507fea = xe134235b3526fa75.x37eb83f4e2a8fe56.get_xe6d4b1b411ed94b5((string)x09bf2b07acaf11a5.x75560e2e0a2a206b[i], (string)null, xe134235b3526fa75.xb9e32c79bd755ad8);
			if (x95973895507fea != null && x95973895507fea is x5668c8829b7abcee)
			{
				xeedad81aaed42a76 xeedad81aaed42a = (x95973895507fea as x5668c8829b7abcee).xeedad81aaed42a76;
				if (xeedad81aaed42a != null && xeedad81aaed42a.xd44988f225497f3a > 0)
				{
					xeedad81aaed42a.xab3af626b1405ee8(x09bf2b07acaf11a5.x06ca69422bbb7502.ListLevels[i].xeedad81aaed42a76);
				}
			}
		}
		xe134235b3526fa75.x37eb83f4e2a8fe56.xd6b6ed77479ef68c(x09bf2b07acaf11a5, xe134235b3526fa75.xb9e32c79bd755ad8, xafd04c36a00d5bcf);
	}

	private static void x80e7bc7a8daa7453(xf871da68decec406 xe134235b3526fa75, x09bf2b07acaf11a4 x44ecfea61c937b8e)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		xca994afbcb9073a.x99f8cdb2827fa686();
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			xf871da68decec406.x8125d547dbbe8218(xca994afbcb9073a, x44ecfea61c937b8e);
		}
	}

	private static void xec18743873c63c69(xf871da68decec406 xe134235b3526fa75, x09bf2b07acaf11a4 x44ecfea61c937b8e)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		xca994afbcb9073a.x99f8cdb2827fa686();
		x44ecfea61c937b8e.x06ca69422bbb7502.ListLevels[0].StartAt = 1;
		while (xca994afbcb9073a.x152cbadbfa8061b1("list-style"))
		{
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "list-level-style-number":
			case "list-level-style-bullet":
			case "list-level-style-image":
				xfa148cbaf165dccd(xe134235b3526fa75, x44ecfea61c937b8e);
				break;
			default:
				xca994afbcb9073a.IgnoreElement();
				break;
			}
		}
	}

	private static void xfa148cbaf165dccd(xf871da68decec406 xe134235b3526fa75, x09bf2b07acaf11a4 x44ecfea61c937b8e)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		int num = xca004f56614e2431.x59884ab46dd0d856(xca994afbcb9073a.xd68abcd61e368af9("level", "1")) - 1;
		xca994afbcb9073a.x99f8cdb2827fa686();
		if (ListLevel.x775a459d4e3c3432(num))
		{
			ListLevel listLevel = x44ecfea61c937b8e.x06ca69422bbb7502.ListLevels[num];
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "list-level-style-number":
				x1407f5d6e167f2da(xe134235b3526fa75, x44ecfea61c937b8e, listLevel);
				break;
			case "list-level-style-bullet":
				xf09b7d1ca4f52c90(xe134235b3526fa75, x44ecfea61c937b8e, listLevel);
				break;
			case "list-level-style-image":
				x672b4b157ea51be2(xe134235b3526fa75, x44ecfea61c937b8e, listLevel);
				break;
			}
			if (x44ecfea61c937b8e.xeedad81aaed42a76 != null)
			{
				x44ecfea61c937b8e.xeedad81aaed42a76.xab3af626b1405ee8(listLevel.xeedad81aaed42a76);
			}
		}
	}

	private static void x1407f5d6e167f2da(xf871da68decec406 xe134235b3526fa75, x09bf2b07acaf11a4 x44ecfea61c937b8e, ListLevel xdcfcc0186c9811f1)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		xdcfcc0186c9811f1.NumberStyle = NumberStyle.None;
		string text = "";
		string text2 = "";
		int num = 1;
		int startAt = 1;
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "num-format":
				xdcfcc0186c9811f1.NumberStyle = x0eb9a864413f34de.xf82235a3d3bbad96(xca994afbcb9073a.xd2f68ee6f47e9dfb);
				break;
			case "display-levels":
				num = xca994afbcb9073a.xbba6773b8ce56a01;
				break;
			case "style-name":
				x44ecfea61c937b8e.x75560e2e0a2a206b[xdcfcc0186c9811f1.x008c23e8f687bbd3] = xbb857c9fc36f5054.x94045081801bb82d(xca994afbcb9073a.xd2f68ee6f47e9dfb);
				break;
			case "start-value":
				startAt = xca994afbcb9073a.xbba6773b8ce56a01;
				break;
			case "num-suffix":
				text = xca994afbcb9073a.xd2f68ee6f47e9dfb;
				break;
			case "num-prefix":
				text2 = xca994afbcb9073a.xd2f68ee6f47e9dfb;
				break;
			}
		}
		xdcfcc0186c9811f1.StartAt = startAt;
		xdcfcc0186c9811f1.NumberFormat += text2;
		for (int i = xdcfcc0186c9811f1.x008c23e8f687bbd3 + 1 - num; i <= xdcfcc0186c9811f1.x008c23e8f687bbd3; i++)
		{
			xdcfcc0186c9811f1.NumberFormat += (char)i;
			if (i != xdcfcc0186c9811f1.x008c23e8f687bbd3)
			{
				xdcfcc0186c9811f1.NumberFormat += '.';
			}
		}
		xdcfcc0186c9811f1.NumberFormat += text;
		while (xca994afbcb9073a.x152cbadbfa8061b1("list-level-style-number"))
		{
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "list-level-properties":
				xed71934064a5d064.x06b0e25aa6ad68a9(xe134235b3526fa75, xdcfcc0186c9811f1);
				break;
			case "text-properties":
			{
				xeedad81aaed42a76 xeedad81aaed42a = xaf0a8e2144428ff9.x06b0e25aa6ad68a9(xe134235b3526fa75, x44ecfea61c937b8e);
				if (xeedad81aaed42a.xd44988f225497f3a > 0)
				{
					xeedad81aaed42a.xab3af626b1405ee8(xdcfcc0186c9811f1.xeedad81aaed42a76);
				}
				break;
			}
			default:
				xca994afbcb9073a.IgnoreElement();
				break;
			}
		}
	}

	private static void xf09b7d1ca4f52c90(xf871da68decec406 xe134235b3526fa75, x09bf2b07acaf11a4 x44ecfea61c937b8e, ListLevel xdcfcc0186c9811f1)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		xdcfcc0186c9811f1.NumberStyle = NumberStyle.Bullet;
		string numberFormat = "";
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "style-name":
				x44ecfea61c937b8e.x75560e2e0a2a206b[xdcfcc0186c9811f1.x008c23e8f687bbd3] = xbb857c9fc36f5054.x94045081801bb82d(xca994afbcb9073a.xd2f68ee6f47e9dfb);
				break;
			case "bullet-char":
				numberFormat = xca994afbcb9073a.xd2f68ee6f47e9dfb;
				break;
			}
		}
		xdcfcc0186c9811f1.NumberFormat = numberFormat;
		while (xca994afbcb9073a.x152cbadbfa8061b1("list-level-style-bullet"))
		{
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "list-level-properties":
				xed71934064a5d064.x06b0e25aa6ad68a9(xe134235b3526fa75, xdcfcc0186c9811f1);
				break;
			case "text-properties":
			{
				xeedad81aaed42a76 xeedad81aaed42a = xaf0a8e2144428ff9.x06b0e25aa6ad68a9(xe134235b3526fa75, x44ecfea61c937b8e);
				if (xeedad81aaed42a.xd44988f225497f3a > 0)
				{
					xeedad81aaed42a.xab3af626b1405ee8(xdcfcc0186c9811f1.xeedad81aaed42a76);
				}
				break;
			}
			default:
				xca994afbcb9073a.IgnoreElement();
				break;
			}
		}
	}

	private static void x672b4b157ea51be2(xf871da68decec406 xe134235b3526fa75, x09bf2b07acaf11a4 x44ecfea61c937b8e, ListLevel xdcfcc0186c9811f1)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		xdcfcc0186c9811f1.NumberStyle = NumberStyle.Bullet;
		Shape shape = new Shape(xe134235b3526fa75.x2c8c6741422a1298, ShapeType.Image);
		shape.x0817d5cde9e19bf6(4097, WrapType.Inline);
		x0ab4ab4e1edb4c1e.x9249ee1ddf74fddd(xe134235b3526fa75, shape);
		xdcfcc0186c9811f1.NumberFormat = new string('\uf0b7', 1);
		xdcfcc0186c9811f1.x4d819daa8b29e86b = xe134235b3526fa75.x2c8c6741422a1298.Lists.x2c0e9f8fa1946281(shape);
		while (xca994afbcb9073a.x152cbadbfa8061b1("list-level-style-image"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xca994afbcb9073a.xa66385d80d4d296f) != null && xa66385d80d4d296f == "list-level-properties")
			{
				xed71934064a5d064.x06b0e25aa6ad68a9(xe134235b3526fa75, xdcfcc0186c9811f1);
			}
			else
			{
				xca994afbcb9073a.IgnoreElement();
			}
		}
	}
}
