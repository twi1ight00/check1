using System;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xbe73d5820f7f4ae3;

namespace xfce5b6a304778b89;

internal class x9a2eac782997cc2e
{
	private x9a2eac782997cc2e()
	{
	}

	internal static void x06b0e25aa6ad68a9(xf871da68decec406 xe134235b3526fa75, bool xafd04c36a00d5bcf)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		string xa66385d80d4d296f = xca994afbcb9073a.xa66385d80d4d296f;
		x39cd0691137f3b40 x39cd0691137f3b = x9bf852191f3358d2(xca994afbcb9073a.xd68abcd61e368af9("family", null));
		x80e7bc7a8daa7453(xe134235b3526fa75, x39cd0691137f3b);
		while (xca994afbcb9073a.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "text-properties":
				if (x39cd0691137f3b is x5668c8829b7abcee)
				{
					x5668c8829b7abcee x5668c8829b7abcee2 = (x5668c8829b7abcee)x39cd0691137f3b;
					xeedad81aaed42a76 xeedad81aaed42a = xaf0a8e2144428ff9.x06b0e25aa6ad68a9(xe134235b3526fa75, (x5668c8829b7abcee)x39cd0691137f3b);
					if (xeedad81aaed42a.xd44988f225497f3a > 0)
					{
						x5668c8829b7abcee2.xeedad81aaed42a76 = xeedad81aaed42a;
					}
				}
				break;
			case "paragraph-properties":
				if (x39cd0691137f3b is x38c672d671ef22c7)
				{
					xf861f01045960da2.x06b0e25aa6ad68a9(xe134235b3526fa75, (x38c672d671ef22c7)x39cd0691137f3b);
				}
				break;
			case "section-properties":
				if (x39cd0691137f3b is xa02b88720ae12353)
				{
					x766fbaefce090d5a.x06b0e25aa6ad68a9(xe134235b3526fa75, (xa02b88720ae12353)x39cd0691137f3b);
				}
				break;
			case "table-properties":
				if (x39cd0691137f3b is xc559a3dd8354bcaa)
				{
					xb60a69db39b2be7e.x11dc6d08cde44f37(xe134235b3526fa75, (xc559a3dd8354bcaa)x39cd0691137f3b);
				}
				break;
			case "table-column-properties":
				if (x39cd0691137f3b is x68feb341faa622d7)
				{
					xb60a69db39b2be7e.x0bf12215bc6d5482(xe134235b3526fa75, (x68feb341faa622d7)x39cd0691137f3b);
				}
				break;
			case "table-row-properties":
				if (x39cd0691137f3b is xac09988577d41b0c)
				{
					xb60a69db39b2be7e.xfb4dc46aca01801d(xe134235b3526fa75, (xac09988577d41b0c)x39cd0691137f3b);
				}
				break;
			case "table-cell-properties":
				if (x39cd0691137f3b is xb40eb2b6a428e174)
				{
					xb60a69db39b2be7e.xa78413eb43f85369(xe134235b3526fa75, (xb40eb2b6a428e174)x39cd0691137f3b);
				}
				break;
			case "graphic-properties":
				if (x39cd0691137f3b is x1ba13e535f55aa54)
				{
					xd55b70bad23cdcb2.x06b0e25aa6ad68a9(xe134235b3526fa75, (x1ba13e535f55aa54)x39cd0691137f3b);
				}
				break;
			case "ruby-properties":
				if (x39cd0691137f3b is x2ed682dd336ae0a6)
				{
					xdb22c511f1385b67.x06b0e25aa6ad68a9(xe134235b3526fa75, (x2ed682dd336ae0a6)x39cd0691137f3b);
				}
				break;
			case "drawing-page-properties":
				if (x39cd0691137f3b is x614273b8c8636c74)
				{
					x0b231ce468f9a1d6.x06b0e25aa6ad68a9(xe134235b3526fa75, (x614273b8c8636c74)x39cd0691137f3b);
				}
				break;
			case "chart-properties":
				if (x39cd0691137f3b is x73266b8b1f72760e)
				{
					xcdbc077c6b10b178.x06b0e25aa6ad68a9(xe134235b3526fa75, (x73266b8b1f72760e)x39cd0691137f3b);
				}
				break;
			default:
				xca994afbcb9073a.IgnoreElement();
				break;
			}
		}
		xe134235b3526fa75.x37eb83f4e2a8fe56.xd6b6ed77479ef68c(x39cd0691137f3b, xe134235b3526fa75.xb9e32c79bd755ad8, xafd04c36a00d5bcf);
	}

	private static x39cd0691137f3b40 x9bf852191f3358d2(string x690ee913dde10e08)
	{
		return x690ee913dde10e08 switch
		{
			"text" => new x5668c8829b7abcee(), 
			"paragraph" => new x38c672d671ef22c7(), 
			"section" => new xa02b88720ae12353(), 
			"ruby" => new x2ed682dd336ae0a6(), 
			"table" => new xc559a3dd8354bcaa(), 
			"table-column" => new x68feb341faa622d7(), 
			"table-row" => new xac09988577d41b0c(), 
			"table-cell" => new xb40eb2b6a428e174(), 
			"graphic" => new x1ba13e535f55aa54(), 
			"presentation" => new x1ba13e535f55aa54(), 
			"drawing-page" => new x614273b8c8636c74(), 
			"chart" => new x73266b8b1f72760e(), 
			_ => throw new InvalidOperationException(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("bkabhlhbblobblfcpkmcelddikkdhfbehkiefkpehkgfhjnfniegfelgiichaijhjiaicihicioimifjadmjeddkfikkhdblbiilicplmcgm", 1671172172)), x690ee913dde10e08)), 
		};
	}

	private static void x80e7bc7a8daa7453(xf871da68decec406 xe134235b3526fa75, x39cd0691137f3b40 x44ecfea61c937b8e)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		xca994afbcb9073a.x99f8cdb2827fa686();
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			if (xf871da68decec406.x8125d547dbbe8218(xca994afbcb9073a, x44ecfea61c937b8e))
			{
				continue;
			}
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "family":
				x44ecfea61c937b8e.x4ccc2e5631b8ba9c = xca994afbcb9073a.xd2f68ee6f47e9dfb;
				break;
			case "master-page-name":
				x44ecfea61c937b8e.x80fcdfee081ea552 = xbb857c9fc36f5054.x94045081801bb82d(xca994afbcb9073a.xd2f68ee6f47e9dfb);
				break;
			case "default-outline-level":
				if (x44ecfea61c937b8e is x38c672d671ef22c7 && x0d299f323d241756.x5959bccb67bbf051(xca994afbcb9073a.xd2f68ee6f47e9dfb))
				{
					((x38c672d671ef22c7)x44ecfea61c937b8e).x82921d664ca236b8 = xca994afbcb9073a.xbba6773b8ce56a01 - 1;
				}
				break;
			case "parent-style-name":
				x44ecfea61c937b8e.x6901ea11a338ff2b = xbb857c9fc36f5054.x94045081801bb82d(xca994afbcb9073a.xd2f68ee6f47e9dfb);
				break;
			}
		}
	}
}
