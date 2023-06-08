using Aspose.Words.Lists;
using xbe73d5820f7f4ae3;

namespace xfce5b6a304778b89;

internal class xed71934064a5d064
{
	private xed71934064a5d064()
	{
	}

	internal static void x06b0e25aa6ad68a9(xf871da68decec406 xe134235b3526fa75, ListLevel xdcfcc0186c9811f1)
	{
		if (x50298fd577676488(xe134235b3526fa75, xdcfcc0186c9811f1))
		{
			x48538eafad545f4e(xe134235b3526fa75, xdcfcc0186c9811f1);
		}
	}

	private static bool x50298fd577676488(xf871da68decec406 xe134235b3526fa75, ListLevel xdcfcc0186c9811f1)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		bool result = false;
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "space-before":
				num = xbb857c9fc36f5054.x30490843b282206a(xca994afbcb9073a.xd2f68ee6f47e9dfb);
				break;
			case "min-label-width":
				num2 = xbb857c9fc36f5054.x30490843b282206a(xca994afbcb9073a.xd2f68ee6f47e9dfb);
				break;
			case "min-label-distance":
				num3 = xbb857c9fc36f5054.x30490843b282206a(xca994afbcb9073a.xd2f68ee6f47e9dfb);
				break;
			case "text-align":
				xdcfcc0186c9811f1.Alignment = x0eb9a864413f34de.x7c024e58d824fd53(xca994afbcb9073a.xd2f68ee6f47e9dfb);
				break;
			case "width":
				if (xdcfcc0186c9811f1.x44b52529222cea8a)
				{
					xdcfcc0186c9811f1.xc9c754014952f758.xf7125312c7ee115c.xae20093bed1e48a8(4131, xbb857c9fc36f5054.xc42baa2576960ea5(xca994afbcb9073a.xd2f68ee6f47e9dfb));
				}
				break;
			case "height":
				if (xdcfcc0186c9811f1.x44b52529222cea8a)
				{
					xdcfcc0186c9811f1.xc9c754014952f758.xf7125312c7ee115c.xae20093bed1e48a8(4132, xbb857c9fc36f5054.xc42baa2576960ea5(xca994afbcb9073a.xd2f68ee6f47e9dfb));
				}
				break;
			case "list-level-position-and-space-mode":
				result = true;
				break;
			}
		}
		if (xdcfcc0186c9811f1.Alignment == ListLevelAlignment.Right)
		{
			if (num2 != 0)
			{
				xdcfcc0186c9811f1.x1a78664fa10a3755.xc0741c7ff92cf1aa = num2;
			}
			xdcfcc0186c9811f1.x1a78664fa10a3755.xc7d7e186f0ace1e0 = num2 - num3 - xdcfcc0186c9811f1.x1a78664fa10a3755.xc0741c7ff92cf1aa;
		}
		else
		{
			if (num2 + num != 0)
			{
				xdcfcc0186c9811f1.x1a78664fa10a3755.xc0741c7ff92cf1aa = num2 + num;
			}
			xdcfcc0186c9811f1.x1a78664fa10a3755.xc7d7e186f0ace1e0 = num - xdcfcc0186c9811f1.x1a78664fa10a3755.xc0741c7ff92cf1aa;
		}
		return result;
	}

	private static void x48538eafad545f4e(xf871da68decec406 xe134235b3526fa75, ListLevel xdcfcc0186c9811f1)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x152cbadbfa8061b1("list-level-properties"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xca994afbcb9073a.xa66385d80d4d296f) != null && xa66385d80d4d296f == "list-level-label-alignment")
			{
				x05d3c91a675c76a9(xe134235b3526fa75, xdcfcc0186c9811f1);
			}
			else
			{
				xca994afbcb9073a.IgnoreElement();
			}
		}
	}

	private static void x05d3c91a675c76a9(xf871da68decec406 xe134235b3526fa75, ListLevel xdcfcc0186c9811f1)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "list-tab-stop-position":
				xdcfcc0186c9811f1.TabPosition = xbb857c9fc36f5054.xc42baa2576960ea5(xca994afbcb9073a.xd2f68ee6f47e9dfb);
				break;
			case "text-indent":
				xdcfcc0186c9811f1.x1a78664fa10a3755.xc7d7e186f0ace1e0 = xbb857c9fc36f5054.x30490843b282206a(xca994afbcb9073a.xd2f68ee6f47e9dfb);
				break;
			case "margin-left":
				xdcfcc0186c9811f1.x1a78664fa10a3755.xc0741c7ff92cf1aa = xbb857c9fc36f5054.x30490843b282206a(xca994afbcb9073a.xd2f68ee6f47e9dfb);
				break;
			}
		}
	}
}
