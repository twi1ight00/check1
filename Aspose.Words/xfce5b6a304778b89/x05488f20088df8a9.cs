using System.Collections;
using Aspose.Words;
using Aspose.Words.Drawing;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xbe73d5820f7f4ae3;
using xf9a9481c3f63a419;

namespace xfce5b6a304778b89;

internal class x05488f20088df8a9
{
	private static readonly double x491b492ea542a8e4 = xbb857c9fc36f5054.x6a2cd7b6d4dbe0bb(31.0);

	private x05488f20088df8a9()
	{
	}

	internal static void x06b0e25aa6ad68a9(xf871da68decec406 xe134235b3526fa75, xb77bc1b681ac1354 xbebb1e76c50d8a5d)
	{
		xfc72d4c9b765cad7 xfc72d4c9b765cad = new xfc72d4c9b765cad7();
		xb117510b51ee9853(xe134235b3526fa75, xbebb1e76c50d8a5d, xfc72d4c9b765cad);
		x4189ee18bf070d29(xfc72d4c9b765cad, xbebb1e76c50d8a5d);
		x34b87eacb79fff82(xe134235b3526fa75, xfc72d4c9b765cad);
		if (xfc72d4c9b765cad.xd44988f225497f3a > 0)
		{
			xbebb1e76c50d8a5d.xfc72d4c9b765cad7 = xfc72d4c9b765cad;
		}
	}

	internal static void xd155891a1e04d676(xf871da68decec406 xe134235b3526fa75, xfc72d4c9b765cad7 x873e775b892867cf)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		x873e775b892867cf.xa79be739e56e9dde = 0;
		x873e775b892867cf.xbd7bb54d8760ed0a = new x28980d9c5ec3f471();
		x873e775b892867cf.x49ddd5238a18b5b1 = false;
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "column-count":
				x873e775b892867cf.x6e1eb96b81362ebc = xca994afbcb9073a.xbba6773b8ce56a01;
				break;
			case "column-gap":
				x873e775b892867cf.xa79be739e56e9dde = xbb857c9fc36f5054.x30490843b282206a(xca994afbcb9073a.xd2f68ee6f47e9dfb);
				x873e775b892867cf.x49ddd5238a18b5b1 = true;
				break;
			}
		}
		ArrayList arrayList = new ArrayList();
		int num = 0;
		int x316dac18ee4d85c = 0;
		while (xca994afbcb9073a.x152cbadbfa8061b1("columns"))
		{
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "column":
			{
				TextColumn textColumn = x1eca8405f9520ac8(xe134235b3526fa75, x873e775b892867cf, arrayList, ref x316dac18ee4d85c);
				x873e775b892867cf.xbd7bb54d8760ed0a.xd6b6ed77479ef68c(textColumn);
				num += textColumn.x7219de950d4b708a;
				break;
			}
			case "column-sep":
				x873e775b892867cf.xa7b942134f68467f = true;
				xd32554aeff8beac1(xe134235b3526fa75);
				break;
			default:
				xca994afbcb9073a.IgnoreElement();
				break;
			}
		}
		if (x873e775b892867cf.xbd7bb54d8760ed0a.xd44988f225497f3a > 0)
		{
			x873e775b892867cf.xbd7bb54d8760ed0a.get_xe6d4b1b411ed94b5(x873e775b892867cf.xbd7bb54d8760ed0a.xd44988f225497f3a - 1).xbe8b68828bd16a4b -= x316dac18ee4d85c;
		}
		double num2 = num / (x873e775b892867cf.x3114e27f80122981 - x873e775b892867cf.xc8a7b7ce5c5279ee - x873e775b892867cf.x3fa6fa3075fd558f);
		num2 = ((num2 > 0.0) ? num2 : 1.0);
		for (int i = 0; i < x873e775b892867cf.xbd7bb54d8760ed0a.xd44988f225497f3a; i++)
		{
			TextColumn textColumn2 = x873e775b892867cf.xbd7bb54d8760ed0a.get_xe6d4b1b411ed94b5(i);
			int num3 = (int)((double)textColumn2.x7219de950d4b708a / num2);
			int num4 = 0;
			if (i < x873e775b892867cf.xbd7bb54d8760ed0a.xd44988f225497f3a - 1)
			{
				num4 = textColumn2.xbe8b68828bd16a4b - (int)arrayList[i + 1];
			}
			textColumn2.x7219de950d4b708a = num3 - (int)arrayList[i] - num4;
		}
	}

	private static TextColumn x1eca8405f9520ac8(xf871da68decec406 xe134235b3526fa75, xfc72d4c9b765cad7 x873e775b892867cf, ArrayList x4c5a7fa40068885f, ref int x316dac18ee4d85c0)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		TextColumn textColumn = new TextColumn();
		int num = 0;
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "rel-width":
				textColumn.x7219de950d4b708a = xca004f56614e2431.x59884ab46dd0d856(xca994afbcb9073a.xd2f68ee6f47e9dfb.Replace("*", ""));
				break;
			case "start-indent":
				num = xbb857c9fc36f5054.x30490843b282206a(xca994afbcb9073a.xd2f68ee6f47e9dfb);
				if (x873e775b892867cf.xbd7bb54d8760ed0a.xd44988f225497f3a > 0)
				{
					x873e775b892867cf.xbd7bb54d8760ed0a.get_xe6d4b1b411ed94b5(x873e775b892867cf.xbd7bb54d8760ed0a.xd44988f225497f3a - 1).xbe8b68828bd16a4b += num;
				}
				break;
			case "end-indent":
				x316dac18ee4d85c0 = xbb857c9fc36f5054.x30490843b282206a(xca994afbcb9073a.xd2f68ee6f47e9dfb);
				textColumn.xbe8b68828bd16a4b += xbb857c9fc36f5054.x30490843b282206a(xca994afbcb9073a.xd2f68ee6f47e9dfb);
				break;
			}
		}
		x4c5a7fa40068885f.Add(num);
		return textColumn;
	}

	private static void xd32554aeff8beac1(xf871da68decec406 xe134235b3526fa75)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			string xa66385d80d4d296f = xca994afbcb9073a.xa66385d80d4d296f;
			switch (xa66385d80d4d296f)
			{
			case null:
			case "style":
			case "width":
			case "height":
			case "vertical-align":
				continue;
			}
			_ = xa66385d80d4d296f == "color";
		}
	}

	private static void x34b87eacb79fff82(xf871da68decec406 xe134235b3526fa75, xfc72d4c9b765cad7 x873e775b892867cf)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x152cbadbfa8061b1("page-layout-properties"))
		{
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "columns":
				xd155891a1e04d676(xe134235b3526fa75, x873e775b892867cf);
				break;
			case "background-image":
			{
				Shape shape = new Shape(xe134235b3526fa75.x2c8c6741422a1298, ShapeType.Image);
				x0ab4ab4e1edb4c1e.x9249ee1ddf74fddd(xe134235b3526fa75, shape);
				if (shape.ImageData.x169baa05e57bf312)
				{
					xe134235b3526fa75.x2c8c6741422a1298.xffc75a489655380b(shape);
					xe134235b3526fa75.x2c8c6741422a1298.ViewOptions.DisplayBackgroundShape = true;
				}
				break;
			}
			default:
				xca994afbcb9073a.IgnoreElement();
				break;
			}
		}
	}

	private static void xb117510b51ee9853(xf871da68decec406 xe134235b3526fa75, xb77bc1b681ac1354 xbebb1e76c50d8a5d, xfc72d4c9b765cad7 x873e775b892867cf)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			if (xf871da68decec406.xe486365cb08165a7(xca994afbcb9073a, xbebb1e76c50d8a5d.xb70a9d14469748bf) || xf871da68decec406.xb0473d4afe16cb4d(xca994afbcb9073a, xbebb1e76c50d8a5d.xb09bf7248f4ba6cb) || xf871da68decec406.xb8a5c0590fac08ae(xca994afbcb9073a, xbebb1e76c50d8a5d.x6e5a54a5c6ac3f42))
			{
				continue;
			}
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "num-format":
				if (xca994afbcb9073a.xd2f68ee6f47e9dfb != "1")
				{
					x873e775b892867cf.x6090553824279e24 = x0eb9a864413f34de.xf82235a3d3bbad96(xca994afbcb9073a.xd2f68ee6f47e9dfb);
				}
				break;
			case "page-width":
				x873e775b892867cf.xa2dc0badd30e7585(2260, xbb857c9fc36f5054.x30490843b282206a(xca994afbcb9073a.xd2f68ee6f47e9dfb));
				break;
			case "page-height":
				x873e775b892867cf.xa2dc0badd30e7585(2270, xbb857c9fc36f5054.x30490843b282206a(xca994afbcb9073a.xd2f68ee6f47e9dfb));
				break;
			case "print-orientation":
				x873e775b892867cf.xa2dc0badd30e7585(2210, x0eb9a864413f34de.xb1914e9373851c18(xca994afbcb9073a.xd2f68ee6f47e9dfb));
				break;
			case "writing-mode":
				x28dea0c453e4c048(x873e775b892867cf, xca994afbcb9073a.xd2f68ee6f47e9dfb);
				break;
			case "shadow":
				xbebb1e76c50d8a5d.x0214605434693fc1 = xbb857c9fc36f5054.x0214605434693fc1(xca994afbcb9073a.xd2f68ee6f47e9dfb);
				break;
			case "background-color":
				xe134235b3526fa75.x2c8c6741422a1298.PageColor = xbb857c9fc36f5054.xd9a94ec83011098f(xca994afbcb9073a.xd2f68ee6f47e9dfb).xc7656a130b2889c7();
				break;
			}
		}
		x3b4e2cec591fc3bf x3b4e2cec591fc3bf = xe134235b3526fa75.x3b4e2cec591fc3bf;
		if (x3b4e2cec591fc3bf != null && x3b4e2cec591fc3bf.x7ff22c593daf1cc1 == "true")
		{
			x873e775b892867cf.xae20093bed1e48a8(2120, 1);
			if (x0d299f323d241756.x5959bccb67bbf051(x3b4e2cec591fc3bf.xee1b82aba4986eda))
			{
				x873e775b892867cf.xae20093bed1e48a8(2120, xca004f56614e2431.x59884ab46dd0d856(x3b4e2cec591fc3bf.xee1b82aba4986eda));
			}
			if (x0d299f323d241756.x5959bccb67bbf051(x3b4e2cec591fc3bf.xf1d9b91c9700c401))
			{
				x873e775b892867cf.xae20093bed1e48a8(2400, xbb857c9fc36f5054.x30490843b282206a(x3b4e2cec591fc3bf.xf1d9b91c9700c401));
			}
			if (x3b4e2cec591fc3bf.x63a3fe1ee14f2452 == "true")
			{
				x873e775b892867cf.xae20093bed1e48a8(2110, LineNumberRestartMode.RestartPage);
			}
		}
	}

	private static void x28dea0c453e4c048(xfc72d4c9b765cad7 x873e775b892867cf, string xfb2f638453e8a6a5)
	{
		switch (xfb2f638453e8a6a5)
		{
		case "tb-rl":
		case "tb":
		case "tb-lr":
			x873e775b892867cf.xa2dc0badd30e7585(2440, x6d434087bc06a37d.x61c108cc44ef385a);
			break;
		}
		if (xfb2f638453e8a6a5 == "rl-tb" || xfb2f638453e8a6a5 == "rl")
		{
			x873e775b892867cf.xa2dc0badd30e7585(2440, x6d434087bc06a37d.x048554b0a8122c07);
			x873e775b892867cf.xa2dc0badd30e7585(2450, true);
		}
		if (xfb2f638453e8a6a5 == "lr-tb" || xfb2f638453e8a6a5 == "lr")
		{
			x873e775b892867cf.xa2dc0badd30e7585(2450, false);
		}
	}

	private static void x4189ee18bf070d29(xfc72d4c9b765cad7 x873e775b892867cf, xb77bc1b681ac1354 xbebb1e76c50d8a5d)
	{
		x6a3b9cbff75fd927 xb70a9d14469748bf = xbebb1e76c50d8a5d.xb70a9d14469748bf;
		x1ba0adbe4f846c39 x6e5a54a5c6ac3f = xbebb1e76c50d8a5d.x6e5a54a5c6ac3f42;
		xaf975f26d67e34e8 xb09bf7248f4ba6cb = xbebb1e76c50d8a5d.xb09bf7248f4ba6cb;
		if (x7e7782b21b2e73d0(x6e5a54a5c6ac3f, xb09bf7248f4ba6cb))
		{
			x873e775b892867cf.x5ce93b65ae6f48bb = PageBorderDistanceFrom.PageEdge;
		}
		x2cf1761602871e10(x873e775b892867cf, xbebb1e76c50d8a5d, 2130, 2300, xb70a9d14469748bf.xa8c2637cc4888928, x6e5a54a5c6ac3f.x41c7a253dffab96d, xb09bf7248f4ba6cb.x71043d5524bf9d58.x83551eb97a16bb65, xb09bf7248f4ba6cb.x71043d5524bf9d58.x33ec425398367777);
		x2cf1761602871e10(x873e775b892867cf, xbebb1e76c50d8a5d, 2150, 2310, xb70a9d14469748bf.x79d902473861f242, x6e5a54a5c6ac3f.xf2f0e85a6d5b32fb, xb09bf7248f4ba6cb.x71043d5524bf9d58.xa671de6a1e9bcaae, xb09bf7248f4ba6cb.x71043d5524bf9d58.x1148d335a6671b0c);
		x2cf1761602871e10(x873e775b892867cf, xbebb1e76c50d8a5d, 2140, 2280, xb70a9d14469748bf.xaea087ab32102492, x6e5a54a5c6ac3f.x1fce31db7994633f, xb09bf7248f4ba6cb.xa3e94d39710969ea.xc334118c782d9421, xb09bf7248f4ba6cb.xa3e94d39710969ea.x5bd10369f179217c);
		x2cf1761602871e10(x873e775b892867cf, xbebb1e76c50d8a5d, 2160, 2290, xb70a9d14469748bf.xd7a21e27974f626c, x6e5a54a5c6ac3f.x5035ade17b9c6f87, xb09bf7248f4ba6cb.xa3e94d39710969ea.xc6c700120c59c6b8, xb09bf7248f4ba6cb.xa3e94d39710969ea.x87d950866dbc19f7);
	}

	private static void x2cf1761602871e10(xfc72d4c9b765cad7 x873e775b892867cf, xb77bc1b681ac1354 xbebb1e76c50d8a5d, int x2b4bceeb0893721a, int xfc3a0184a87a77e9, x533663bbcdc757a9 x895c40fd497ba465, double x31033071d2f3713b, double xd83614898d3657c4, bool x704b917d2a989ebd)
	{
		double num = x31033071d2f3713b;
		double num2 = xd83614898d3657c4;
		Border border = new Border();
		if (x895c40fd497ba465 != null)
		{
			border.LineStyle = x895c40fd497ba465.x3d0571719b5893b4;
			border.x63b1a7c31a962459 = x895c40fd497ba465.x9b41425268471380;
			border.xab266ea415f07c09 = xbb857c9fc36f5054.xb6d2cca5c1ea6936(border, x895c40fd497ba465.xeae235558dc44397);
		}
		if (x31033071d2f3713b > x491b492ea542a8e4 || x873e775b892867cf.x5ce93b65ae6f48bb == PageBorderDistanceFrom.PageEdge)
		{
			if (num2 <= x491b492ea542a8e4 && x704b917d2a989ebd)
			{
				num = num2;
				num2 = x31033071d2f3713b;
				x873e775b892867cf.x5ce93b65ae6f48bb = PageBorderDistanceFrom.PageEdge;
			}
			else
			{
				num = x491b492ea542a8e4;
			}
		}
		border.DistanceFromText = x15e971129fd80714.x43fcc3f62534530b(xbb857c9fc36f5054.x7ee6ab51d3d84831(num));
		border.Shadow = xbebb1e76c50d8a5d.x0214605434693fc1;
		x873e775b892867cf.xae20093bed1e48a8(x2b4bceeb0893721a, border);
		if (x704b917d2a989ebd)
		{
			x873e775b892867cf.xa2dc0badd30e7585(xfc3a0184a87a77e9, xbb857c9fc36f5054.x286c839093f58b61(num2 + num) + ((x895c40fd497ba465 != null) ? x4574ea26106f0edb.x78d3dddae0ed1b0d(border.xab266ea415f07c09) : 0));
		}
	}

	private static bool x7e7782b21b2e73d0(x1ba0adbe4f846c39 x6e5ae614ae422322, xaf975f26d67e34e8 xef9bc48270a0c987)
	{
		if (!x1d59ae227742ef12(x6e5ae614ae422322.x41c7a253dffab96d, xef9bc48270a0c987.x71043d5524bf9d58.x83551eb97a16bb65, xef9bc48270a0c987.x71043d5524bf9d58.x33ec425398367777) && !x1d59ae227742ef12(x6e5ae614ae422322.xf2f0e85a6d5b32fb, xef9bc48270a0c987.x71043d5524bf9d58.xa671de6a1e9bcaae, xef9bc48270a0c987.x71043d5524bf9d58.x1148d335a6671b0c) && !x1d59ae227742ef12(x6e5ae614ae422322.x1fce31db7994633f, xef9bc48270a0c987.xa3e94d39710969ea.xc334118c782d9421, xef9bc48270a0c987.xa3e94d39710969ea.x5bd10369f179217c))
		{
			return x1d59ae227742ef12(x6e5ae614ae422322.x5035ade17b9c6f87, xef9bc48270a0c987.xa3e94d39710969ea.xc6c700120c59c6b8, xef9bc48270a0c987.xa3e94d39710969ea.x87d950866dbc19f7);
		}
		return true;
	}

	private static bool x1d59ae227742ef12(double x31033071d2f3713b, double xd83614898d3657c4, bool x704b917d2a989ebd)
	{
		if (x31033071d2f3713b > x491b492ea542a8e4 && xd83614898d3657c4 <= x491b492ea542a8e4)
		{
			return x704b917d2a989ebd;
		}
		return false;
	}
}
