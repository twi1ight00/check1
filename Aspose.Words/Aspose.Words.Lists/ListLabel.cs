using System;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xd2754ae26d400653;

namespace Aspose.Words.Lists;

public class ListLabel : xf5ecf429e74b1c04
{
	private readonly Paragraph x40cd00a5707ca004;

	private readonly ListFormat xf7f3c633f29a1938;

	private Font x83cd810ab70afec3;

	private string[] x064906791865e1ff;

	private xd269993cc48a63d2 x9c3288d0d851d36a;

	private static readonly int[] x52e26752ffc36aa0 = new int[4] { 230, 235, 240, 270 };

	private static readonly int[] x761d3097f8856e3f = new int[5] { 30, 40, 80, 140, 300 };

	internal xd269993cc48a63d2 x4ededf5feccc72f8 => x9c3288d0d851d36a;

	public Font Font
	{
		get
		{
			if (x83cd810ab70afec3 == null)
			{
				x83cd810ab70afec3 = new Font(this, x40cd00a5707ca004.Document.Styles);
			}
			return x83cd810ab70afec3;
		}
	}

	internal bool x5959bccb67bbf051 => xcd4bd3abd72ff2da.x57a8965bf85f0d71(x064906791865e1ff);

	internal string[] x86e38944139b26ce => x064906791865e1ff;

	public string LabelString => xcd4bd3abd72ff2da.xecc24694278df524(x86e38944139b26ce);

	public int LabelValue
	{
		get
		{
			if (x9c3288d0d851d36a != null)
			{
				return x9c3288d0d851d36a.x043aafba68f5c559();
			}
			return 0;
		}
	}

	internal ListTrailingCharacter xd8359a0ce34a3ba5
	{
		get
		{
			if (x9c3288d0d851d36a != null)
			{
				return x9c3288d0d851d36a.x1b66e22d28c087af().TrailingCharacter;
			}
			return ListTrailingCharacter.Nothing;
		}
	}

	int xf5ecf429e74b1c04.x5b8c6010012a5955 => xf7f3c633f29a1938.ListLevel?.xeedad81aaed42a76.xd44988f225497f3a ?? 0;

	internal ListLabel(Paragraph para)
	{
		x40cd00a5707ca004 = para;
		xf7f3c633f29a1938 = para.ListFormat;
	}

	internal void xc609abb1cfc9c20d(string[] x9d7bb0f9581f2bb1, xd269993cc48a63d2 x107ef6939bdd9979)
	{
		x064906791865e1ff = x9d7bb0f9581f2bb1;
		x9c3288d0d851d36a = x107ef6939bdd9979;
	}

	internal static bool xc0242e835a99b224(ListLevel xdcfcc0186c9811f1, xeedad81aaed42a76 xe429e76576802d76)
	{
		if (!xc0242e835a99b224(xdcfcc0186c9811f1))
		{
			return xe429e76576802d76.xa7ee97ddde231678(x761d3097f8856e3f);
		}
		return true;
	}

	internal static bool xc0242e835a99b224(ListLevel xdcfcc0186c9811f1)
	{
		if (xa9f4bbe6c3c45958(xdcfcc0186c9811f1))
		{
			return xdcfcc0186c9811f1.xeedad81aaed42a76.xa7ee97ddde231678(x52e26752ffc36aa0);
		}
		return true;
	}

	private static bool xa9f4bbe6c3c45958(ListLevel xdcfcc0186c9811f1)
	{
		string text = (string)xdcfcc0186c9811f1.xeedad81aaed42a76.x9bd0b4c41657450b(230);
		string numberFormat = xdcfcc0186c9811f1.NumberFormat;
		if (numberFormat.Length != 1)
		{
			return text == null;
		}
		return x0d299f323d241756.x90637a473b1ceaaa(x67af7bcbfd57c02b.x7bf00b1e5eb813c8(numberFormat[0]), text);
	}

	private object x93e461c176ca1e50(int xba08ce632055a1d9)
	{
		return xf7f3c633f29a1938.ListLevel?.xeedad81aaed42a76.x9bd0b4c41657450b(xba08ce632055a1d9);
	}

	object xf5ecf429e74b1c04.x9bd0b4c41657450b(int xba08ce632055a1d9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x93e461c176ca1e50
		return this.x93e461c176ca1e50(xba08ce632055a1d9);
	}

	private void x9939815f86bdcfc3(int xc0c4c459c6ccbd00, out int xba08ce632055a1d9, out object xbcea506a33cf9111)
	{
		ListLevel listLevel = xf7f3c633f29a1938.ListLevel;
		if (listLevel != null)
		{
			listLevel.xeedad81aaed42a76.x16b3a875e7cc38ed(xc0c4c459c6ccbd00, out xba08ce632055a1d9, out xbcea506a33cf9111);
			return;
		}
		xba08ce632055a1d9 = 0;
		xbcea506a33cf9111 = null;
	}

	void xf5ecf429e74b1c04.x16b3a875e7cc38ed(int xc0c4c459c6ccbd00, out int xba08ce632055a1d9, out object xbcea506a33cf9111)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x9939815f86bdcfc3
		this.x9939815f86bdcfc3(xc0c4c459c6ccbd00, out xba08ce632055a1d9, out xbcea506a33cf9111);
	}

	private object xa49e661f5cc91e49(int xba08ce632055a1d9)
	{
		if (xba08ce632055a1d9 != 140 && xba08ce632055a1d9 != 80 && xba08ce632055a1d9 != 300)
		{
			bool flag = false;
			if (xba08ce632055a1d9 == 60 || xba08ce632055a1d9 == 70)
			{
				ListLevel listLevel = xf7f3c633f29a1938.ListLevel;
				flag = listLevel != null && listLevel.NumberStyle == NumberStyle.Bullet;
			}
			if (!flag)
			{
				object obj = x40cd00a5707ca004.x9bd0b4c41657450b(xba08ce632055a1d9);
				if (obj != null)
				{
					return xbfb481ef38a88c1f(obj, xba08ce632055a1d9);
				}
			}
		}
		if (x40cd00a5707ca004.xfcffbd79482d97c7.Font != null && xba08ce632055a1d9 != 140)
		{
			return x40cd00a5707ca004.xfcffbd79482d97c7.Font.xfe91eeeafcb3026a(xba08ce632055a1d9);
		}
		Style style = x40cd00a5707ca004.Document.Styles[x40cd00a5707ca004.xfcffbd79482d97c7.BaseStyleName];
		if (style != null && style.Font != null)
		{
			return style.Font.xfe91eeeafcb3026a(xba08ce632055a1d9);
		}
		return x40cd00a5707ca004.Document.Styles[StyleIdentifier.Normal].Font.xfe91eeeafcb3026a(xba08ce632055a1d9);
	}

	object xf5ecf429e74b1c04.x2685f947206319cf(int xba08ce632055a1d9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xa49e661f5cc91e49
		return this.xa49e661f5cc91e49(xba08ce632055a1d9);
	}

	internal xeedad81aaed42a76 x856218fd0771d379()
	{
		xeedad81aaed42a76 xeedad81aaed42a = x40cd00a5707ca004.x3a7e67268c1cb407(xecac24b19ed3a2b7.x2be08ba736aa04f0);
		xeedad81aaed42a.x52b190e626f65140(140);
		xeedad81aaed42a.x52b190e626f65140(130);
		ListLevel listLevel = xf7f3c633f29a1938.ListLevel;
		if (listLevel != null && listLevel.NumberStyle == NumberStyle.Bullet)
		{
			xeedad81aaed42a.x52b190e626f65140(70);
			xeedad81aaed42a.x52b190e626f65140(60);
		}
		listLevel?.xeedad81aaed42a76.xab3af626b1405ee8(xeedad81aaed42a);
		return xeedad81aaed42a;
	}

	private void x09376e92b9e1f394(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		ListLevel listLevel = xf7f3c633f29a1938.ListLevel;
		if (listLevel != null)
		{
			listLevel.xeedad81aaed42a76.xd00aa8389522ce53(xba08ce632055a1d9, xbcea506a33cf9111);
		}
		else
		{
			x7d385e9911a2de9f();
		}
	}

	void xf5ecf429e74b1c04.xd00aa8389522ce53(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x09376e92b9e1f394
		this.x09376e92b9e1f394(xba08ce632055a1d9, xbcea506a33cf9111);
	}

	private void x69045f836de92891()
	{
		ListLevel listLevel = xf7f3c633f29a1938.ListLevel;
		if (listLevel != null)
		{
			listLevel.xeedad81aaed42a76.xe80983f2918b2568();
		}
		else
		{
			x7d385e9911a2de9f();
		}
	}

	void xf5ecf429e74b1c04.xe80983f2918b2568()
	{
		//ILSpy generated this explicit interface implementation from .override directive in x69045f836de92891
		this.x69045f836de92891();
	}

	private static void x7d385e9911a2de9f()
	{
		throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("dinpojeaiklafkcbdkjbfkacoehcoiocajfdgimdajdegikebibfjdifkhpfmhggcingchehnglhlhciecjicgajchhjpgojkgfkofmkefdlegklagbmoeimjfpmdagnpennleeokpkoidcpepipndaahdhaodoamdfbfolbocdcackcobbdobidccpdbofeanmenpdflalfjbcgfajgiaahabhhmpnhiafinpliclcjdpjjlpakoohkjpokbpflhkmlbpdmkjkmjnbnjninnnpnnngojnnopmepfilpgncaomjamhabklhbghobplfcjlmcamddolkdfhbe", 1874591040)));
	}

	private object xbfb481ef38a88c1f(object xbcea506a33cf9111, int xba08ce632055a1d9)
	{
		if (xbcea506a33cf9111 is x9b28b1f7f0cc963f)
		{
			return ((x9b28b1f7f0cc963f)xbcea506a33cf9111).xd0c62c194ffc67e6(x40cd00a5707ca004.xfcffbd79482d97c7.Font, xba08ce632055a1d9);
		}
		return xbcea506a33cf9111;
	}
}
