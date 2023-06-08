using System.Collections;
using System.Text;
using Aspose.Words;
using Aspose.Words.Lists;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;

namespace xd2754ae26d400653;

internal class xcb0a3bdf6cb11198
{
	private enum x81b8239d90d96cc4
	{
		x5c406e36406e12b5,
		xd065b32a30167202,
		x7edea2b59d2144b4,
		xa9d636b00ff486b7
	}

	private readonly Document xd1424e1a0bb4a72b;

	private readonly Hashtable x27b36b4bc9a5e40a = new Hashtable();

	internal xcb0a3bdf6cb11198(Document doc)
	{
		xd1424e1a0bb4a72b = doc;
	}

	internal void x201200bdd10d9567(Paragraph x41baca1d6c0c2e8e)
	{
		x81b8239d90d96cc4 x81b8239d90d96cc = x6d79066efaf3bebb(x41baca1d6c0c2e8e);
		if (x81b8239d90d96cc != x81b8239d90d96cc4.xa9d636b00ff486b7)
		{
			ListFormat listFormat = x41baca1d6c0c2e8e.ListFormat;
			int x71c63f7e57f7ede = listFormat.x71c63f7e57f7ede5;
			int listLevelNumber = listFormat.ListLevelNumber;
			List x8a0b266419f09a = xd1424e1a0bb4a72b.Lists.x6c3daa8c787e54bf(x71c63f7e57f7ede);
			xd269993cc48a63d2 xd269993cc48a63d3 = x9752fe6aad1293b4(x8a0b266419f09a, listLevelNumber);
			if (x81b8239d90d96cc == x81b8239d90d96cc4.xd065b32a30167202)
			{
				string[] x5d9c3ec13853f2ad = xe68132b683aea340(xd269993cc48a63d3);
				x41baca1d6c0c2e8e.xb57cb507dbb2966a(x5d9c3ec13853f2ad, xd269993cc48a63d3);
				return;
			}
		}
		x41baca1d6c0c2e8e.xd6d9cff1c02d8406();
	}

	private static x81b8239d90d96cc4 x6d79066efaf3bebb(Paragraph x41baca1d6c0c2e8e)
	{
		if (!x41baca1d6c0c2e8e.IsListItem || (x41baca1d6c0c2e8e.IsInCell && x41baca1d6c0c2e8e.xc5464084edc8e226.xf8cef531dae89ea3.x61127d98597c4898))
		{
			return x81b8239d90d96cc4.xa9d636b00ff486b7;
		}
		x81b8239d90d96cc4 x81b8239d90d96cc = x7116ca1ba0856e16(x41baca1d6c0c2e8e);
		if (x81b8239d90d96cc == x81b8239d90d96cc4.x5c406e36406e12b5)
		{
			x81b8239d90d96cc = ((!x41baca1d6c0c2e8e.IsEndOfSection || x41baca1d6c0c2e8e.IsEndOfDocument || x2b1ee3a87b36a988.x0302c7317ec57e52(x41baca1d6c0c2e8e.ParentNode)) ? x81b8239d90d96cc4.xd065b32a30167202 : x81b8239d90d96cc4.xa9d636b00ff486b7);
		}
		return x81b8239d90d96cc;
	}

	private static x81b8239d90d96cc4 x7116ca1ba0856e16(Paragraph x41baca1d6c0c2e8e)
	{
		x81b8239d90d96cc4 x81b8239d90d96cc = x81b8239d90d96cc4.x5c406e36406e12b5;
		Node node = x41baca1d6c0c2e8e.FirstChild;
		while (node != null && x81b8239d90d96cc != x81b8239d90d96cc4.xd065b32a30167202)
		{
			switch (node.NodeType)
			{
			case NodeType.Run:
			{
				string text = ((Run)node).Text;
				if (text.Length <= 0)
				{
					break;
				}
				x81b8239d90d96cc = x81b8239d90d96cc4.x7edea2b59d2144b4;
				for (int i = 0; i < text.Length; i++)
				{
					if (x81b8239d90d96cc == x81b8239d90d96cc4.xd065b32a30167202)
					{
						break;
					}
					if (text[i] != '\f')
					{
						x81b8239d90d96cc = x81b8239d90d96cc4.xd065b32a30167202;
					}
				}
				break;
			}
			default:
				x81b8239d90d96cc = x81b8239d90d96cc4.xd065b32a30167202;
				break;
			case NodeType.BookmarkStart:
			case NodeType.BookmarkEnd:
				break;
			}
			node = node.NextSibling;
		}
		return x81b8239d90d96cc;
	}

	private xd269993cc48a63d2 x9752fe6aad1293b4(List x8a0b266419f09a55, int xdcfcc0186c9811f1)
	{
		xd269993cc48a63d2 xd269993cc48a63d3 = (xd269993cc48a63d2)x27b36b4bc9a5e40a[x8a0b266419f09a55.x1eac770549050632];
		if (xd269993cc48a63d3 == null)
		{
			xd269993cc48a63d3 = new xd269993cc48a63d2(x8a0b266419f09a55);
			x27b36b4bc9a5e40a[x8a0b266419f09a55.x1eac770549050632] = xd269993cc48a63d3;
		}
		xd269993cc48a63d3.xd83d8153333670e0(x8a0b266419f09a55, xdcfcc0186c9811f1);
		return xd269993cc48a63d3;
	}

	private static string[] xe68132b683aea340(xd269993cc48a63d2 x01b557925841ae51)
	{
		int x12e53f22096e;
		return xdcbfb9d26064915f(x01b557925841ae51, x01b557925841ae51.x1b66e22d28c087af(), out x12e53f22096e);
	}

	internal static string xf81712d779b52fd1(xd269993cc48a63d2 x01b557925841ae51)
	{
		return xf81712d779b52fd1(x01b557925841ae51, 0);
	}

	internal static string xf81712d779b52fd1(xd269993cc48a63d2 x01b557925841ae51, int xdfe8537f2d14401b)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = x01b557925841ae51.x51e5bb947db89a97 + 1;
		for (int num2 = x01b557925841ae51.x51e5bb947db89a97; num2 >= xdfe8537f2d14401b; num2--)
		{
			if (num2 < num)
			{
				ListLevel x0fe7a8514e20eb = x01b557925841ae51.x1b66e22d28c087af(num2);
				stringBuilder.Insert(0, xe6e07c48961e3dfb(x01b557925841ae51, x0fe7a8514e20eb, out var x12e53f22096e));
				if (x12e53f22096e < num)
				{
					num = x12e53f22096e;
				}
			}
		}
		return stringBuilder.ToString();
	}

	private static string xe6e07c48961e3dfb(xd269993cc48a63d2 x01b557925841ae51, ListLevel x0fe7a8514e20eb94, out int x12e53f22096e1555)
	{
		return xcd4bd3abd72ff2da.xecc24694278df524(xdcbfb9d26064915f(x01b557925841ae51, x0fe7a8514e20eb94, out x12e53f22096e1555));
	}

	private static string[] xdcbfb9d26064915f(xd269993cc48a63d2 x01b557925841ae51, ListLevel x0fe7a8514e20eb94, out int x12e53f22096e1555)
	{
		ArrayList arrayList = new ArrayList();
		x12e53f22096e1555 = x0fe7a8514e20eb94.x008c23e8f687bbd3;
		for (int i = 0; i < x0fe7a8514e20eb94.NumberFormat.Length; i++)
		{
			char c = x0fe7a8514e20eb94.NumberFormat[i];
			if (ListLevel.x775a459d4e3c3432(c))
			{
				string text = x35c32c297f63525d(x01b557925841ae51, x0fe7a8514e20eb94, c);
				if (text.Length > 0)
				{
					arrayList.Add(text);
				}
				if (x12e53f22096e1555 > c)
				{
					x12e53f22096e1555 = c;
				}
			}
			else
			{
				arrayList.Add(c.ToString());
			}
		}
		return (string[])arrayList.ToArray(typeof(string));
	}

	private static string x35c32c297f63525d(xd269993cc48a63d2 x01b557925841ae51, ListLevel xa6cf1109903d02af, int xde874d7c38b62e68)
	{
		int xbcea506a33cf = x01b557925841ae51.x043aafba68f5c559(xde874d7c38b62e68);
		ListLevel listLevel = x01b557925841ae51.x1b66e22d28c087af(xde874d7c38b62e68);
		NumberStyle numberStyle = listLevel.NumberStyle;
		if (xa6cf1109903d02af.IsLegal && numberStyle != NumberStyle.LeadingZero && numberStyle != NumberStyle.Bullet && numberStyle != NumberStyle.None)
		{
			numberStyle = NumberStyle.Arabic;
		}
		if (numberStyle != NumberStyle.Bullet)
		{
			return x00b47748a95c9437.x19fa8583862b446b(xbcea506a33cf, numberStyle, x3b747bc7816d8768: true);
		}
		return listLevel.NumberFormat;
	}
}
