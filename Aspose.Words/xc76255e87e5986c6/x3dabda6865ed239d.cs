using System.Collections;
using Aspose.Words.Fonts;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using x79578da6a8a3ae37;
using x8b1f7613579e78d0;
using x9e34b6f7e9185197;
using xa6cc8e39f9a280d7;
using xa769c310fbec8a5a;
using xfc5388ad7dff404f;

namespace xc76255e87e5986c6;

internal class x3dabda6865ed239d : x6ecdfaec63740001, xceb510a6fe203e32
{
	private x4f15c2ab6fab0941 x47df4de11c35f3b8;

	private string xdf90efec42105ef2;

	private x2053f56a9aea777a xf463b842bb440834;

	private x87415330d9d0754a x623afc400e737ae9;

	private x87415330d9d0754a xdbc5ddaaf085063a;

	private string xc61ff88f1f98652d;

	private Hashtable xa453b5e74b2a39eb = new Hashtable();

	private xfafa4c90da1436a5 x330d589641d10947;

	private xa2f1c3dcbd86f20a x8c34cd7cda592553;

	internal xa2f1c3dcbd86f20a x4b27d9fdab2746ba
	{
		get
		{
			return x8c34cd7cda592553;
		}
		set
		{
			x8c34cd7cda592553 = value;
		}
	}

	internal Hashtable x8c7d2c74298d462f
	{
		get
		{
			return xa453b5e74b2a39eb;
		}
		set
		{
			xa453b5e74b2a39eb = value;
		}
	}

	internal string x759aa16c2016a289
	{
		get
		{
			return xc61ff88f1f98652d;
		}
		set
		{
			xc61ff88f1f98652d = value;
		}
	}

	internal string xcab9f0a54d8bcea6
	{
		get
		{
			return xdf90efec42105ef2;
		}
		set
		{
			xdf90efec42105ef2 = value;
		}
	}

	internal x87415330d9d0754a x612ef856b9d29ffd
	{
		get
		{
			return x623afc400e737ae9;
		}
		set
		{
			x623afc400e737ae9 = value;
		}
	}

	internal x87415330d9d0754a x7dd80080464c013f
	{
		get
		{
			return xdbc5ddaaf085063a;
		}
		set
		{
			xdbc5ddaaf085063a = value;
		}
	}

	internal xfafa4c90da1436a5 xfafa4c90da1436a5
	{
		get
		{
			return x330d589641d10947;
		}
		set
		{
			x330d589641d10947 = value;
		}
	}

	internal x4f15c2ab6fab0941 x4f15c2ab6fab0941
	{
		get
		{
			if (x47df4de11c35f3b8 == null)
			{
				x47df4de11c35f3b8 = new x4f15c2ab6fab0941();
			}
			return x47df4de11c35f3b8;
		}
		set
		{
			x47df4de11c35f3b8 = value;
		}
	}

	internal x2053f56a9aea777a x2053f56a9aea777a
	{
		get
		{
			if (xf463b842bb440834 == null)
			{
				xf463b842bb440834 = new x2053f56a9aea777a();
			}
			return xf463b842bb440834;
		}
		set
		{
			xf463b842bb440834 = value;
		}
	}

	public string xaf95fb496eb25433(xd0fe745f27933c97 xa1724a07fef092c8)
	{
		x87415330d9d0754a x87415330d9d0754a2 = (((xa1724a07fef092c8 & xd0fe745f27933c97.x3ded86773fc96826) == xd0fe745f27933c97.xb12b26d90e429bbf) ? x623afc400e737ae9 : xdbc5ddaaf085063a);
		if (x87415330d9d0754a2 == null)
		{
			return null;
		}
		x448900fcb384c333 xd80e464e4e73d3e;
		FontInfo fontInfo;
		switch (xa1724a07fef092c8 & xd0fe745f27933c97.x8c5847a8078d0878)
		{
		case xd0fe745f27933c97.x175297738c8b8d1e:
		case xd0fe745f27933c97.x7478956f1fc58328:
			xd80e464e4e73d3e = x330d589641d10947.x94edc0d9bd2a8401;
			fontInfo = x87415330d9d0754a2.x94edc0d9bd2a8401;
			break;
		case xd0fe745f27933c97.xcedf9c82728ad579:
			xd80e464e4e73d3e = x330d589641d10947.xcedf9c82728ad579;
			fontInfo = x87415330d9d0754a2.xd4e922ceeed89b74;
			break;
		case xd0fe745f27933c97.x5f503f1ab9a38748:
			xd80e464e4e73d3e = x330d589641d10947.x5f503f1ab9a38748;
			fontInfo = x87415330d9d0754a2.xad8ea6954e370567;
			break;
		default:
			xd80e464e4e73d3e = x448900fcb384c333.xe6e1e754fb8e4ea0;
			fontInfo = null;
			break;
		}
		string text = x627549849fc8d0cc(xd80e464e4e73d3e);
		if (x0d299f323d241756.x5959bccb67bbf051(text))
		{
			x080b836c5a387d2e x080b836c5a387d2e2 = (x080b836c5a387d2e)x87415330d9d0754a2.xaebadb979a354f46[text];
			if (x080b836c5a387d2e2 != null && x0d299f323d241756.x5959bccb67bbf051(x080b836c5a387d2e2.x1cc7de1d2cb6cde3))
			{
				return x080b836c5a387d2e2.x1cc7de1d2cb6cde3;
			}
		}
		return fontInfo?.Name;
	}

	private static string x627549849fc8d0cc(x448900fcb384c333 xd80e464e4e73d3e6)
	{
		return (int)(xd80e464e4e73d3e6 & (x448900fcb384c333)255) switch
		{
			17 => "Jpan", 
			18 => "Hang", 
			4 => "Hans", 
			1 => "Arab", 
			13 => "Hebr", 
			30 => "Thai", 
			115 => "Ethi", 
			69 => "Beng", 
			71 => "Gujr", 
			83 => "Khmr", 
			75 => "Knda", 
			70 => "Guru", 
			93 => "Cans", 
			92 => "Cher", 
			120 => "Yiii", 
			81 => "Tibt", 
			101 => "Thaa", 
			89 => "Deva", 
			74 => "Telu", 
			73 => "Taml", 
			90 => "Syrc", 
			72 => "Orya", 
			76 => "Mlym", 
			84 => "Laoo", 
			91 => "Sing", 
			80 => "Mong", 
			42 => "Viet", 
			_ => null, 
		};
	}

	internal x3dabda6865ed239d x8b61531c8ea35b85()
	{
		return (x3dabda6865ed239d)MemberwiseClone();
	}

	private void x1062362549bc01ce(x4c1e058c67948d6a x7a65590f8086d4cf, int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		switch (xba08ce632055a1d9)
		{
		case 530:
			xbb8c171da926db36(x7a65590f8086d4cf, (xd0fe745f27933c97)xbcea506a33cf9111, 230);
			break;
		case 560:
			xbb8c171da926db36(x7a65590f8086d4cf, (xd0fe745f27933c97)xbcea506a33cf9111, 270);
			break;
		case 550:
			xbb8c171da926db36(x7a65590f8086d4cf, (xd0fe745f27933c97)xbcea506a33cf9111, 235);
			break;
		case 540:
			xbb8c171da926db36(x7a65590f8086d4cf, (xd0fe745f27933c97)xbcea506a33cf9111, 240);
			break;
		default:
			((x09ce2c02826e31a6)x7a65590f8086d4cf).set_xe6d4b1b411ed94b5(xba08ce632055a1d9, xbcea506a33cf9111);
			break;
		}
	}

	void xceb510a6fe203e32.x0acd3c2012ea2ee8(x4c1e058c67948d6a x7a65590f8086d4cf, int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x1062362549bc01ce
		this.x1062362549bc01ce(x7a65590f8086d4cf, xba08ce632055a1d9, xbcea506a33cf9111);
	}

	private void xbb8c171da926db36(x4c1e058c67948d6a x4ac4562403543b7a, xd0fe745f27933c97 xa1724a07fef092c8, int x5808f39cd747561d)
	{
		string xbcea506a33cf = xaf95fb496eb25433(xa1724a07fef092c8);
		if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf))
		{
			x4ac4562403543b7a.xae20093bed1e48a8(x5808f39cd747561d, xbcea506a33cf);
		}
	}

	private xd7e8497b32a408b8 xbd7bbe33160c7ec9(x19119439284aead2 x6c50a99faab7d741)
	{
		return x4f15c2ab6fab0941.xef50a938c8b9c7fd(x6c50a99faab7d741).x8b61531c8ea35b85();
	}

	xd7e8497b32a408b8 x6ecdfaec63740001.xa7e254e6f0870f2a(x19119439284aead2 x6c50a99faab7d741)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xbd7bbe33160c7ec9
		return this.xbd7bbe33160c7ec9(x6c50a99faab7d741);
	}

	private x48d7478d49393961 xd43b2eb1d5519940(int xc0c4c459c6ccbd00)
	{
		return x2053f56a9aea777a.xc9e90b46232365f3(xc0c4c459c6ccbd00).Clone();
	}

	x48d7478d49393961 x6ecdfaec63740001.xc9e90b46232365f3(int xc0c4c459c6ccbd00)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xd43b2eb1d5519940
		return this.xd43b2eb1d5519940(xc0c4c459c6ccbd00);
	}

	private x48d7478d49393961 x4f2646f82b3a47d6(int xc0c4c459c6ccbd00)
	{
		return x2053f56a9aea777a.x0cf64e0fb1cb423b(xc0c4c459c6ccbd00).Clone();
	}

	x48d7478d49393961 x6ecdfaec63740001.x0cf64e0fb1cb423b(int xc0c4c459c6ccbd00)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x4f2646f82b3a47d6
		return this.x4f2646f82b3a47d6(xc0c4c459c6ccbd00);
	}

	private x064e11d707aed84f xda55922a985ae3b1(int xc0c4c459c6ccbd00)
	{
		return (x064e11d707aed84f)x2053f56a9aea777a.xb29c732ce60a626d(xc0c4c459c6ccbd00).x8b61531c8ea35b85();
	}

	x064e11d707aed84f x6ecdfaec63740001.xb29c732ce60a626d(int xc0c4c459c6ccbd00)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xda55922a985ae3b1
		return this.xda55922a985ae3b1(xc0c4c459c6ccbd00);
	}
}
