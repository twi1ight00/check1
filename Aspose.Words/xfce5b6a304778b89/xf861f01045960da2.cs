using Aspose.Words;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xbe73d5820f7f4ae3;

namespace xfce5b6a304778b89;

internal class xf861f01045960da2
{
	private xf861f01045960da2()
	{
	}

	internal static void x06b0e25aa6ad68a9(xf871da68decec406 xe134235b3526fa75, x38c672d671ef22c7 x44ecfea61c937b8e)
	{
		x1a78664fa10a3755 x1a78664fa10a = new x1a78664fa10a3755();
		x1f692f0e35452447(xe134235b3526fa75, x44ecfea61c937b8e, x1a78664fa10a);
		xb81f13999eaf4d04(xe134235b3526fa75, x44ecfea61c937b8e, x1a78664fa10a);
		if (x1a78664fa10a.xd44988f225497f3a > 0)
		{
			if (x44ecfea61c937b8e.x1a78664fa10a3755 == null)
			{
				x44ecfea61c937b8e.x1a78664fa10a3755 = x1a78664fa10a;
			}
			else
			{
				x1a78664fa10a.xab3af626b1405ee8(x44ecfea61c937b8e.x1a78664fa10a3755);
			}
		}
	}

	private static void x1f692f0e35452447(xf871da68decec406 xe134235b3526fa75, x38c672d671ef22c7 x44ecfea61c937b8e, x1a78664fa10a3755 x062aae8c9613eeaa)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		bool xc92c7e4aeaca654f = false;
		int num = 0;
		int num2 = 0;
		string text = null;
		string text2 = null;
		bool x4d21032b3ed = false;
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			if (xf871da68decec406.x1d481f2ddf720611(xca994afbcb9073a, x44ecfea61c937b8e, x062aae8c9613eeaa) || xf871da68decec406.xb0473d4afe16cb4d(xca994afbcb9073a, x44ecfea61c937b8e.xb09bf7248f4ba6cb) || xf871da68decec406.xe486365cb08165a7(xca994afbcb9073a, x44ecfea61c937b8e.xb70a9d14469748bf) || xf871da68decec406.xb8a5c0590fac08ae(xca994afbcb9073a, x44ecfea61c937b8e.x6e5a54a5c6ac3f42))
			{
				continue;
			}
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "page-number":
				if (xca994afbcb9073a.xd2f68ee6f47e9dfb != "auto")
				{
					x44ecfea61c937b8e.x7155dda3b72cd3e5 = xca994afbcb9073a.xd2f68ee6f47e9dfb;
				}
				break;
			case "text-align-last":
				text = xca994afbcb9073a.xd2f68ee6f47e9dfb;
				break;
			case "line-number":
				x44ecfea61c937b8e.x845183cdf0fdbeec = xca994afbcb9073a.xbba6773b8ce56a01;
				break;
			case "number-lines":
				if (xca994afbcb9073a.xd2f68ee6f47e9dfb == "true")
				{
					x062aae8c9613eeaa.x8dae0782887a2391 = false;
				}
				break;
			case "master-page-name":
				if (!x0d299f323d241756.x5959bccb67bbf051(x44ecfea61c937b8e.x80fcdfee081ea552))
				{
					x44ecfea61c937b8e.x80fcdfee081ea552 = xbb857c9fc36f5054.x94045081801bb82d(xca994afbcb9073a.xd2f68ee6f47e9dfb);
				}
				break;
			case "text-align":
				text2 = xca994afbcb9073a.xd2f68ee6f47e9dfb;
				break;
			case "writing-mode":
				x4d21032b3ed = xca994afbcb9073a.xd2f68ee6f47e9dfb == "rl-tb";
				if (xca994afbcb9073a.xd2f68ee6f47e9dfb == "rl-tb" || xca994afbcb9073a.xd2f68ee6f47e9dfb == "rl")
				{
					x062aae8c9613eeaa.xb6157b6da9895c0d(1560, true);
				}
				if (xca994afbcb9073a.xd2f68ee6f47e9dfb == "lr-tb" || xca994afbcb9073a.xd2f68ee6f47e9dfb == "lr")
				{
					x062aae8c9613eeaa.xb6157b6da9895c0d(1560, false);
				}
				break;
			case "text-indent":
				x062aae8c9613eeaa.xc7d7e186f0ace1e0 = xbb857c9fc36f5054.x30490843b282206a(xca994afbcb9073a.xd2f68ee6f47e9dfb);
				break;
			case "line-height":
				if (xca994afbcb9073a.xd2f68ee6f47e9dfb != "normal")
				{
					x062aae8c9613eeaa.x84bbacdc1fc0efd2 = xbb857c9fc36f5054.x1afdf740c9c6af9e(xca994afbcb9073a.xd2f68ee6f47e9dfb);
					x062aae8c9613eeaa.x6ecc1a11cfc2c359 = ((!xca994afbcb9073a.xd2f68ee6f47e9dfb.EndsWith("%")) ? LineSpacingRule.Exactly : LineSpacingRule.Multiple);
				}
				break;
			case "line-height-at-least":
				x062aae8c9613eeaa.x6ecc1a11cfc2c359 = LineSpacingRule.AtLeast;
				x062aae8c9613eeaa.x84bbacdc1fc0efd2 = xbb857c9fc36f5054.x30490843b282206a(xca994afbcb9073a.xd2f68ee6f47e9dfb);
				break;
			case "keep-together":
				if (xca994afbcb9073a.xd2f68ee6f47e9dfb == "always")
				{
					x062aae8c9613eeaa.xb6157b6da9895c0d(1040, true);
				}
				break;
			case "keep-with-next":
				if (xca994afbcb9073a.xd2f68ee6f47e9dfb == "always")
				{
					x062aae8c9613eeaa.xb6157b6da9895c0d(1050, true);
				}
				break;
			case "background-color":
				if (xca994afbcb9073a.xd2f68ee6f47e9dfb != "transparent")
				{
					x062aae8c9613eeaa.xb6157b6da9895c0d(1460, xbb857c9fc36f5054.x56cdf34322e60e51(xca994afbcb9073a.xd2f68ee6f47e9dfb, (Shading)x062aae8c9613eeaa.xb86fdbeadec3b75c(1460)));
				}
				break;
			case "text-autospace":
				x062aae8c9613eeaa.xb6157b6da9895c0d(1240, xca994afbcb9073a.xd2f68ee6f47e9dfb == "ideograph-alpha");
				break;
			case "punctuation-wrap":
				if (xca994afbcb9073a.xd2f68ee6f47e9dfb == "simple")
				{
					x062aae8c9613eeaa.xb6157b6da9895c0d(1090, false);
				}
				break;
			case "vertical-align":
			{
				x8fdc64e3f5579ea8 x8fdc64e3f5579ea = x0eb9a864413f34de.x6b9ad249ade432f6(xca994afbcb9073a.xd2f68ee6f47e9dfb);
				if (x8fdc64e3f5579ea != x8fdc64e3f5579ea8.x139412b8dea2f02b)
				{
					x062aae8c9613eeaa.xb6157b6da9895c0d(1510, x8fdc64e3f5579ea);
				}
				break;
			}
			case "snap-to-layout-grid":
				if (xca994afbcb9073a.xd2f68ee6f47e9dfb == "true")
				{
					x062aae8c9613eeaa.xb6157b6da9895c0d(1260, true);
				}
				break;
			case "hyphenation-ladder-count":
				if (xca994afbcb9073a.xd2f68ee6f47e9dfb == "no-limit")
				{
					x062aae8c9613eeaa.xb6157b6da9895c0d(1410, true);
				}
				break;
			case "tab-stop-distance":
				if (x44ecfea61c937b8e.x759aa16c2016a289 == null)
				{
					xe134235b3526fa75.x2c8c6741422a1298.xdade2366eaa6f915.xd72f9bc5cc53fc1c = xbb857c9fc36f5054.x30490843b282206a(xca994afbcb9073a.xd2f68ee6f47e9dfb);
				}
				break;
			case "shadow":
				xc92c7e4aeaca654f = xbb857c9fc36f5054.x0214605434693fc1(xca994afbcb9073a.xd2f68ee6f47e9dfb);
				break;
			case "widows":
				num = xca994afbcb9073a.xbba6773b8ce56a01;
				break;
			case "orphans":
				num2 = xca994afbcb9073a.xbba6773b8ce56a01;
				break;
			}
		}
		if (text2 != null)
		{
			x062aae8c9613eeaa.x9ba359ff37a3a63b = x0eb9a864413f34de.x7105f40ee7ec74ce(text2, x4d21032b3ed);
		}
		bool flag = num == 2 && num2 == 2;
		if (x44ecfea61c937b8e.x759aa16c2016a289 == null || x44ecfea61c937b8e.x759aa16c2016a289 == "Standard")
		{
			if (num < 2 || num2 < 2)
			{
				xe134235b3526fa75.x2c8c6741422a1298.xdade2366eaa6f915.xa7e6dbdb484bb52e = false;
			}
			else if (flag)
			{
				xe134235b3526fa75.x2c8c6741422a1298.xdade2366eaa6f915.xa7e6dbdb484bb52e = true;
			}
		}
		else if (flag)
		{
			x062aae8c9613eeaa.xb6157b6da9895c0d(1470, true);
		}
		if (text == "justify")
		{
			x062aae8c9613eeaa.xb6157b6da9895c0d(1020, ParagraphAlignment.Distributed);
		}
		x4189ee18bf070d29(x062aae8c9613eeaa, x44ecfea61c937b8e, xc92c7e4aeaca654f);
	}

	private static void x4189ee18bf070d29(x1a78664fa10a3755 x062aae8c9613eeaa, x38c672d671ef22c7 x44ecfea61c937b8e, bool xc92c7e4aeaca654f)
	{
		x6a3b9cbff75fd927 xb70a9d14469748bf = x44ecfea61c937b8e.xb70a9d14469748bf;
		x1ba0adbe4f846c39 x6e5a54a5c6ac3f = x44ecfea61c937b8e.x6e5a54a5c6ac3f42;
		xaf975f26d67e34e8 xb09bf7248f4ba6cb = x44ecfea61c937b8e.xb09bf7248f4ba6cb;
		if (xb70a9d14469748bf.xa8c2637cc4888928 != null || x6e5a54a5c6ac3f.x41c7a253dffab96d != 0.0)
		{
			x062aae8c9613eeaa.xb6157b6da9895c0d(1350, x9f6bbfd6a9013899(xb70a9d14469748bf.xa8c2637cc4888928, x6e5a54a5c6ac3f.x41c7a253dffab96d, xc92c7e4aeaca654f));
		}
		if (xb09bf7248f4ba6cb.x71043d5524bf9d58.x33ec425398367777)
		{
			x062aae8c9613eeaa.xb6157b6da9895c0d(1200, xbb857c9fc36f5054.x286c839093f58b61(xb09bf7248f4ba6cb.x71043d5524bf9d58.x83551eb97a16bb65));
		}
		if (xb70a9d14469748bf.x79d902473861f242 != null || x6e5a54a5c6ac3f.xf2f0e85a6d5b32fb != 0.0)
		{
			x062aae8c9613eeaa.xb6157b6da9895c0d(1370, x9f6bbfd6a9013899(xb70a9d14469748bf.x79d902473861f242, x6e5a54a5c6ac3f.xf2f0e85a6d5b32fb, xc92c7e4aeaca654f));
		}
		if (xb09bf7248f4ba6cb.x71043d5524bf9d58.x1148d335a6671b0c)
		{
			x062aae8c9613eeaa.xb6157b6da9895c0d(1220, xbb857c9fc36f5054.x286c839093f58b61(xb09bf7248f4ba6cb.x71043d5524bf9d58.xa671de6a1e9bcaae));
		}
		if (xb70a9d14469748bf.xaea087ab32102492 != null || x6e5a54a5c6ac3f.x1fce31db7994633f != 0.0)
		{
			x062aae8c9613eeaa.xb6157b6da9895c0d(1360, x9f6bbfd6a9013899(xb70a9d14469748bf.xaea087ab32102492, x6e5a54a5c6ac3f.x1fce31db7994633f, xc92c7e4aeaca654f));
		}
		if (xb09bf7248f4ba6cb.xa3e94d39710969ea.x5bd10369f179217c)
		{
			x062aae8c9613eeaa.xb6157b6da9895c0d(1160, xbb857c9fc36f5054.x286c839093f58b61(xb09bf7248f4ba6cb.xa3e94d39710969ea.xc334118c782d9421));
		}
		if (xb70a9d14469748bf.xd7a21e27974f626c != null || x6e5a54a5c6ac3f.x5035ade17b9c6f87 != 0.0)
		{
			x062aae8c9613eeaa.xb6157b6da9895c0d(1380, x9f6bbfd6a9013899(xb70a9d14469748bf.xd7a21e27974f626c, x6e5a54a5c6ac3f.x5035ade17b9c6f87, xc92c7e4aeaca654f));
		}
		if (xb09bf7248f4ba6cb.xa3e94d39710969ea.x87d950866dbc19f7)
		{
			x062aae8c9613eeaa.xb6157b6da9895c0d(1150, xbb857c9fc36f5054.x286c839093f58b61(xb09bf7248f4ba6cb.xa3e94d39710969ea.xc6c700120c59c6b8));
		}
	}

	private static Border x9f6bbfd6a9013899(x533663bbcdc757a9 x895c40fd497ba465, double xcaf2e4729806e32b, bool xc92c7e4aeaca654f)
	{
		Border border = x533663bbcdc757a9.x95dfc63190e8c019(x895c40fd497ba465, xcaf2e4729806e32b, 0);
		border.Shadow = xc92c7e4aeaca654f;
		return border;
	}

	private static void xb81f13999eaf4d04(xf871da68decec406 xe134235b3526fa75, x38c672d671ef22c7 xd9acf751daefc6d6, x1a78664fa10a3755 x062aae8c9613eeaa)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x152cbadbfa8061b1("paragraph-properties"))
		{
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "tab-stops":
				x062aae8c9613eeaa.xb6157b6da9895c0d(1140, xc9a129cc169d543d(xe134235b3526fa75, xd9acf751daefc6d6.xb09bf7248f4ba6cb.xa3e94d39710969ea.xc334118c782d9421));
				break;
			case "drop-cap":
				xa9e04146e1ff89fb(xe134235b3526fa75, x062aae8c9613eeaa, xd9acf751daefc6d6);
				break;
			case "background-image":
				x7611f07ac775dd18(xe134235b3526fa75, xd9acf751daefc6d6);
				break;
			default:
				xca994afbcb9073a.IgnoreElement();
				break;
			}
		}
	}

	private static TabStopCollection xc9a129cc169d543d(xf871da68decec406 xe134235b3526fa75, double xc790aa4ad151a9a1)
	{
		TabStopCollection tabStopCollection = new TabStopCollection();
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x152cbadbfa8061b1("tab-stops"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xca994afbcb9073a.xa66385d80d4d296f) != null && xa66385d80d4d296f == "tab-stop")
			{
				tabStopCollection.Add(xe3e0602fe0f995aa(xe134235b3526fa75, xc790aa4ad151a9a1));
			}
			else
			{
				xca994afbcb9073a.IgnoreElement();
			}
		}
		return tabStopCollection;
	}

	private static TabStop xe3e0602fe0f995aa(xf871da68decec406 xe134235b3526fa75, double xc790aa4ad151a9a1)
	{
		TabStop tabStop = new TabStop();
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		string text = "";
		string text2 = "";
		string x43163d22e8cd5a = "";
		string x01d1693fa395ce = "";
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "type":
				x43163d22e8cd5a = xca994afbcb9073a.xd2f68ee6f47e9dfb;
				break;
			case "leader-style":
				text = xca994afbcb9073a.xd2f68ee6f47e9dfb;
				break;
			case "leader-text":
				text2 = xca994afbcb9073a.xd2f68ee6f47e9dfb;
				break;
			case "char":
				x01d1693fa395ce = xca994afbcb9073a.xd2f68ee6f47e9dfb;
				break;
			case "position":
				tabStop.PositionTwips = xbb857c9fc36f5054.x30490843b282206a(xca994afbcb9073a.xd2f68ee6f47e9dfb) + xbb857c9fc36f5054.x286c839093f58b61(xc790aa4ad151a9a1);
				break;
			}
		}
		if (x0d299f323d241756.x5959bccb67bbf051(text) || x0d299f323d241756.x5959bccb67bbf051(text2))
		{
			tabStop.Leader = x0eb9a864413f34de.xe171049fef4b8423(text, text2);
		}
		tabStop.Alignment = x0eb9a864413f34de.x5d40204c804ea9f9(x43163d22e8cd5a, x01d1693fa395ce);
		return tabStop;
	}

	private static void xa9e04146e1ff89fb(xf871da68decec406 xe134235b3526fa75, x1a78664fa10a3755 x062aae8c9613eeaa, x38c672d671ef22c7 x22bcf3014dcb2e7d)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "lines":
				x062aae8c9613eeaa.x125987cd9f983993 = xca994afbcb9073a.xbba6773b8ce56a01;
				break;
			case "distance":
				x062aae8c9613eeaa.xb6157b6da9895c0d(1500, xbb857c9fc36f5054.x30490843b282206a(xca994afbcb9073a.xd2f68ee6f47e9dfb));
				break;
			case "length":
				if (xca994afbcb9073a.xd2f68ee6f47e9dfb == "word")
				{
					x22bcf3014dcb2e7d.x1f57ac233e4af6b3 = true;
				}
				else
				{
					x22bcf3014dcb2e7d.x8bd988af0c57af6d = xca994afbcb9073a.xbba6773b8ce56a01;
				}
				break;
			}
		}
	}

	private static void x7611f07ac775dd18(xf871da68decec406 xe134235b3526fa75, x38c672d671ef22c7 x44ecfea61c937b8e)
	{
	}
}
