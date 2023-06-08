using System;
using Aspose.Words;
using x28925c9b27b37a46;
using x556d8f9846e43329;

namespace x639ad3f66698fe1b;

internal class x660b5ce02cc71bca
{
	private readonly x21f0d20d41203be1 x8cedcaa9a62c6e39;

	private bool x93792b68d7e97259;

	private int x6d4250364ee79c40;

	private bool xfc4a1905104cf6a9;

	internal static bool x492f529cee830a40;

	private xbfd162a6d47f59a4 xe1410f585439c7d4 => x8cedcaa9a62c6e39.xe1410f585439c7d4;

	internal x660b5ce02cc71bca(x21f0d20d41203be1 context)
	{
		x8cedcaa9a62c6e39 = context;
	}

	internal void x6210059f049f0d48(xfc72d4c9b765cad7 x873e775b892867cf)
	{
		if (x873e775b892867cf.x0f53f53f15b61ef5)
		{
			xfc72d4c9b765cad7 xfc72d4c9b765cad = (xfc72d4c9b765cad7)x873e775b892867cf.x8b61531c8ea35b85();
			xfc72d4c9b765cad.xcb395027497bc067();
			x6210059f049f0d48(xfc72d4c9b765cad, xea3007433ebbfe1c: true);
			xac55650dda4d602e(x873e775b892867cf);
		}
		else
		{
			x6210059f049f0d48(x873e775b892867cf, xea3007433ebbfe1c: true);
		}
	}

	private void x6210059f049f0d48(xfc72d4c9b765cad7 x873e775b892867cf, bool xea3007433ebbfe1c)
	{
		if (xea3007433ebbfe1c)
		{
			xe1410f585439c7d4.x4d14ee33f46b5913("\\sectd");
		}
		x93792b68d7e97259 = false;
		x6d4250364ee79c40 = 0;
		xfc4a1905104cf6a9 = false;
		for (int i = 0; i < x873e775b892867cf.xd44988f225497f3a; i++)
		{
			int num = x873e775b892867cf.xf15263674eb297bb(i);
			object obj = x873e775b892867cf.x6d3720b962bd3112(i);
			switch (num)
			{
			case 2070:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\binfsxn", Convert.ToInt32(obj));
				break;
			case 2080:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\binsxn", Convert.ToInt32(obj));
				break;
			case 2390:
				xe1410f585439c7d4.xb8aea59edd4060ce("\\sectunlocked", (bool)obj);
				break;
			case 2030:
				xe1410f585439c7d4.x4d14ee33f46b5913(x118bad6798799e1b.x7de8c12f0a920d2b((SectionStart)obj));
				break;
			case 2380:
				x325339637712f831((x28980d9c5ec3f471)obj);
				break;
			case 2350:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\cols", (int)obj);
				break;
			case 2360:
				x93792b68d7e97259 = (bool)obj;
				break;
			case 2370:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\colsx", (int)obj);
				break;
			case 2060:
				xe1410f585439c7d4.xb8aea59edd4060ce("\\linebetcol", (bool)obj);
				break;
			case 2120:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\linemod", (int)obj);
				break;
			case 2400:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\linex", (int)obj);
				break;
			case 2180:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\linestarts", (int)obj);
				break;
			case 2110:
				xe1410f585439c7d4.x4d14ee33f46b5913(x118bad6798799e1b.x50c3826e9e58bf26((LineNumberRestartMode)obj));
				break;
			case 2260:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\pgwsxn", (int)obj);
				break;
			case 2270:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\pghsxn", (int)obj);
				break;
			case 2280:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\marglsxn", (int)obj);
				break;
			case 2290:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\margrsxn", (int)obj);
				break;
			case 2300:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\margtsxn", (int)obj);
				break;
			case 2310:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\margbsxn", (int)obj);
				break;
			case 2312:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\guttersxn", (int)obj);
				break;
			case 2210:
				xe1410f585439c7d4.xb8aea59edd4060ce("\\lndscpsxn", (Orientation)obj == Orientation.Landscape);
				break;
			case 2040:
				xe1410f585439c7d4.xb8aea59edd4060ce("\\titlepg", (bool)obj);
				break;
			case 2320:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\headery", (int)obj);
				break;
			case 2330:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\footery", (int)obj);
				break;
			case 2200:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\pgnstarts", (int)obj, 1);
				break;
			case 2050:
				xe1410f585439c7d4.xb8aea59edd4060ce("\\pgnrestart", (bool)obj);
				break;
			case 2010:
				xe1410f585439c7d4.x4d14ee33f46b5913(x118bad6798799e1b.x20ee1184246e07d2((NumberStyle)obj));
				break;
			case 2190:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\pgnhn", (int)obj);
				break;
			case 2020:
				xe1410f585439c7d4.x4d14ee33f46b5913(x118bad6798799e1b.xb2e0b0343fc39112((xbdc85485688e2cf3)obj));
				break;
			case 2340:
				xe1410f585439c7d4.x4d14ee33f46b5913(x118bad6798799e1b.x5d879cc27f1ab5c8((PageVerticalAlignment)obj));
				break;
			case 2450:
				xfc4a1905104cf6a9 = (bool)obj;
				break;
			case 2440:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\stextflow", (int)(x6d434087bc06a37d)obj);
				break;
			case 2410:
				xe1410f585439c7d4.xb8aea59edd4060ce("\\rtlgutter", (bool)obj);
				break;
			case 2140:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\pgbrdrl");
				x4bf0725a1c29dbf0.x6210059f049f0d48(x8cedcaa9a62c6e39, (Border)obj);
				break;
			case 2160:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\pgbrdrr");
				x4bf0725a1c29dbf0.x6210059f049f0d48(x8cedcaa9a62c6e39, (Border)obj);
				break;
			case 2130:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\pgbrdrt");
				x4bf0725a1c29dbf0.x6210059f049f0d48(x8cedcaa9a62c6e39, (Border)obj);
				break;
			case 2150:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\pgbrdrb");
				x4bf0725a1c29dbf0.x6210059f049f0d48(x8cedcaa9a62c6e39, (Border)obj);
				break;
			case 2220:
				xb4dc1a930853bf62((PageBorderAppliesTo)obj);
				break;
			case 2230:
				if (!(bool)obj)
				{
					x6d4250364ee79c40 |= 8;
				}
				break;
			case 2240:
				if ((PageBorderDistanceFrom)obj == PageBorderDistanceFrom.PageEdge)
				{
					x6d4250364ee79c40 |= 32;
				}
				break;
			case 2090:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\psz", (int)obj);
				break;
			case 2100:
				xe1410f585439c7d4.xb8aea59edd4060ce("\\endnhere", !(bool)obj);
				break;
			case 2430:
				xe1410f585439c7d4.x4d14ee33f46b5913(x118bad6798799e1b.xe202042d04c101f9((x704ea28be0f90278)obj));
				break;
			case 2170:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\sectlinegrid", (int)obj);
				break;
			case 2420:
				xe1410f585439c7d4.x4d14ee33f46b5913("\\sectexpand", (int)obj);
				break;
			default:
				_ = x492f529cee830a40;
				break;
			case 2250:
			case 10010:
				break;
			}
		}
		xf51c695cdb9a2d72(x873e775b892867cf);
		x7c1c7f03dc2a6836();
		xe1410f585439c7d4.x4d14ee33f46b5913("\\pgbrdropt", x6d4250364ee79c40, 0);
	}

	private void xb4dc1a930853bf62(PageBorderAppliesTo xbcea506a33cf9111)
	{
		switch (xbcea506a33cf9111)
		{
		case PageBorderAppliesTo.FirstPage:
			x6d4250364ee79c40 |= 1;
			break;
		case PageBorderAppliesTo.OtherPages:
			x6d4250364ee79c40 |= 2;
			break;
		}
	}

	private void x7c1c7f03dc2a6836()
	{
		if (!x8cedcaa9a62c6e39.xf57de0fd37d5e97d.ExportCompactSize)
		{
			xe1410f585439c7d4.x4d14ee33f46b5913(xfc4a1905104cf6a9 ? "\\rtlsect" : "\\ltrsect");
		}
	}

	private void x325339637712f831(x28980d9c5ec3f471 x26c511b92db96554)
	{
		if (!x93792b68d7e97259)
		{
			for (int i = 0; i < x26c511b92db96554.xd44988f225497f3a; i++)
			{
				xe1410f585439c7d4.x4d14ee33f46b5913("\\colno", i + 1);
				xe1410f585439c7d4.x4d14ee33f46b5913("\\colw", x26c511b92db96554.get_xe6d4b1b411ed94b5(i).x7219de950d4b708a);
				xe1410f585439c7d4.x4d14ee33f46b5913("\\colsr", x26c511b92db96554.get_xe6d4b1b411ed94b5(i).xbe8b68828bd16a4b);
			}
		}
	}

	private void xf51c695cdb9a2d72(xfc72d4c9b765cad7 x873e775b892867cf)
	{
		xe1410f585439c7d4.x4d14ee33f46b5913(x118bad6798799e1b.x49eccaac36142c02(x873e775b892867cf.xf7866f89640a29a3(2500)));
		object obj = x873e775b892867cf.xf7866f89640a29a3(2520);
		if (obj != null)
		{
			xe1410f585439c7d4.x4d14ee33f46b5913("\\sftnstart", (int)obj, 1);
		}
		object obj2 = x873e775b892867cf.xf7866f89640a29a3(2620);
		if (obj2 != null)
		{
			xe1410f585439c7d4.x4d14ee33f46b5913("\\saftnstart", (int)obj2, 1);
		}
		xe1410f585439c7d4.x4d14ee33f46b5913(x118bad6798799e1b.x4aaa5648deef1e9e(x873e775b892867cf.xf7866f89640a29a3(2510)));
		xe1410f585439c7d4.x4d14ee33f46b5913(x118bad6798799e1b.xf03abdfbfbdea9ea(x873e775b892867cf.xf7866f89640a29a3(2610)));
		xe1410f585439c7d4.x4d14ee33f46b5913(x118bad6798799e1b.xdfbc249b2a6fe449(x873e775b892867cf.xf7866f89640a29a3(2530)));
		xe1410f585439c7d4.x4d14ee33f46b5913(x118bad6798799e1b.x0d0ea57e5b7237de(x873e775b892867cf.xf7866f89640a29a3(2630)));
	}

	private void xac55650dda4d602e(xfc72d4c9b765cad7 x873e775b892867cf)
	{
		x5fb16e270c21db2e x5fb16e270c21db2e = x873e775b892867cf.x5fb16e270c21db2e;
		xbfd162a6d47f59a4 xbfd162a6d47f59a5 = x8cedcaa9a62c6e39.xe1410f585439c7d4;
		xbfd162a6d47f59a5.x4d14ee33f46b5913("\\srauth", x8cedcaa9a62c6e39.x2086e697b5620586.xd6b6ed77479ef68c(x5fb16e270c21db2e.xb063bbfcfeade526));
		xbfd162a6d47f59a5.x4d14ee33f46b5913("\\srdate", xa0d3611565b2a1f2.x7c734cfcbb14646a(x5fb16e270c21db2e.x242851e6278ed355));
		xe1410f585439c7d4.x25d0efbd7848eeb3();
		xbfd162a6d47f59a5.xee60bff2900a72f2("\\*\\oldsprops");
		x6210059f049f0d48(x873e775b892867cf, xea3007433ebbfe1c: false);
		xbfd162a6d47f59a5.xc8a13a52db0580ae();
	}
}
