using System;
using Aspose.Words.Drawing;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;

namespace Aspose.Words.Lists;

public class ListLevel
{
	private const int x019dac817f124830 = 30;

	internal const int xdb2f00ce573da4b5 = 0;

	internal const int xf05b837b3be12961 = 9;

	internal int x4a1340b0df048976 = 4095;

	internal bool x83b68d5fabfc1faa;

	internal bool xf9be1d0b8b44c7e8;

	internal bool x969abf858b3fe7e8;

	internal bool x91bd46873c858a0c;

	internal int x42bf8be828fc1b33;

	internal int x5cf63f659ff5ee9f;

	private DocumentBase xd1424e1a0bb4a72b;

	private readonly int xc0b69493b569b5e2;

	private int x48a3cd56f55f3816 = 1;

	private NumberStyle xb787a022f2ac29f1;

	private string xc05f9976504b9b97 = "";

	private ListLevelAlignment xbe63ce924b03850f;

	private bool x3f576b738cd4c8cc;

	private int xbf02207f927b6d46;

	private ListTrailingCharacter x31b31bd0647f1c55;

	private x1a78664fa10a3755 x4379ee33a06c4648 = new x1a78664fa10a3755();

	private xeedad81aaed42a76 xd0c44e5ae0011daa = new xeedad81aaed42a76();

	private int x05a787b7d6f3f716 = -1;

	private Font x83cd810ab70afec3;

	public int StartAt
	{
		get
		{
			return x48a3cd56f55f3816;
		}
		set
		{
			if (!x643ea6380a7dda67(value))
			{
				throw new ArgumentOutOfRangeException("value");
			}
			x48a3cd56f55f3816 = value;
		}
	}

	public NumberStyle NumberStyle
	{
		get
		{
			return xb787a022f2ac29f1;
		}
		set
		{
			xb787a022f2ac29f1 = value;
		}
	}

	internal x000f21cbda739311 xfb064a7505df1564
	{
		get
		{
			switch (NumberStyle)
			{
			case NumberStyle.Kanji:
			case NumberStyle.KanjiDigit:
			case NumberStyle.AiueoHalfWidth:
			case NumberStyle.IrohaHalfWidth:
			case NumberStyle.KanjiTraditional:
			case NumberStyle.KanjiTraditional2:
			case NumberStyle.NumberInCircle:
			case NumberStyle.Aiueo:
			case NumberStyle.Iroha:
				return x000f21cbda739311.x7c8c2d13fa5b79fa;
			case NumberStyle.Hebrew1:
			case NumberStyle.Hebrew2:
				return x000f21cbda739311.xd4e922ceeed89b74;
			default:
				return x000f21cbda739311.x175297738c8b8d1e;
			}
		}
	}

	public string NumberFormat
	{
		get
		{
			return xc05f9976504b9b97;
		}
		set
		{
			if (!xed41d88c7868b0c8(value))
			{
				throw new ArgumentException("value");
			}
			xc05f9976504b9b97 = value;
		}
	}

	public ListLevelAlignment Alignment
	{
		get
		{
			return xbe63ce924b03850f;
		}
		set
		{
			xbe63ce924b03850f = value;
		}
	}

	public bool IsLegal
	{
		get
		{
			return x3f576b738cd4c8cc;
		}
		set
		{
			x3f576b738cd4c8cc = value;
		}
	}

	public int RestartAfterLevel
	{
		get
		{
			return xbf02207f927b6d46;
		}
		set
		{
			if (!xf74c7e04c971f114(value))
			{
				throw new ArgumentOutOfRangeException("value");
			}
			xbf02207f927b6d46 = value;
		}
	}

	public ListTrailingCharacter TrailingCharacter
	{
		get
		{
			return x31b31bd0647f1c55;
		}
		set
		{
			x31b31bd0647f1c55 = value;
		}
	}

	public Font Font
	{
		get
		{
			if (x83cd810ab70afec3 == null)
			{
				x83cd810ab70afec3 = new Font(xd0c44e5ae0011daa, xd1424e1a0bb4a72b.Styles);
			}
			return x83cd810ab70afec3;
		}
	}

	public double TabPosition
	{
		get
		{
			if (x4379ee33a06c4648.x8df6f6ca274123b0 != null && x4379ee33a06c4648.x8df6f6ca274123b0.Count > 0)
			{
				return x4379ee33a06c4648.x8df6f6ca274123b0[0].Position;
			}
			return 0.0;
		}
		set
		{
			if (x4379ee33a06c4648.x8df6f6ca274123b0 == null)
			{
				x4379ee33a06c4648.x8df6f6ca274123b0 = new TabStopCollection();
			}
			x4379ee33a06c4648.x8df6f6ca274123b0.Clear();
			x4379ee33a06c4648.x8df6f6ca274123b0.Add(value, TabAlignment.List, TabLeader.None);
		}
	}

	public double NumberPosition
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2(x4379ee33a06c4648.xc0741c7ff92cf1aa + x4379ee33a06c4648.xc7d7e186f0ace1e0);
		}
		set
		{
			x4379ee33a06c4648.xc7d7e186f0ace1e0 = x4574ea26106f0edb.x88bf16f2386d633e(value) - x4379ee33a06c4648.xc0741c7ff92cf1aa;
		}
	}

	public double TextPosition
	{
		get
		{
			return x4574ea26106f0edb.x0e1fdb362561ddb2(x4379ee33a06c4648.xc0741c7ff92cf1aa);
		}
		set
		{
			double numberPosition = NumberPosition;
			x4379ee33a06c4648.xc0741c7ff92cf1aa = x4574ea26106f0edb.x88bf16f2386d633e(value);
			NumberPosition = numberPosition;
		}
	}

	public Style LinkedStyle
	{
		get
		{
			if (x4a1340b0df048976 == 4095)
			{
				return null;
			}
			return xd1424e1a0bb4a72b.Styles.x1976fb6958cf7237(x4a1340b0df048976, x988fcf605f8efa7e: true);
		}
		set
		{
			if (value == null)
			{
				x4a1340b0df048976 = 4095;
				return;
			}
			if (value.Type != StyleType.Paragraph)
			{
				throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("aaeobblolacpdmipdbaabbhadboadafbjplbblcclpjcaabdlphdjpodckfebomebodfjjkfhnbgdjigaopgomghmnnhimeilmlidncjpljjlmakamhkfhokfmfldmmlfmdmflkmlkbnbhin", 1402987436)));
			}
			if (value.Document != xd1424e1a0bb4a72b)
			{
				throw new ArgumentException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("lngkmonkgoelojlloocmmojmooanonhnenonmifognmolndpgnkpenbanhiamlpamlgbamnbamecmllcclcdigjdjlaeblhepfoealffbkmfpjdggkkgafbhbjihjjphkigijjnioiejdiljjickmijkdeal", 1771808391)));
			}
			x4a1340b0df048976 = value.x8301ab10c226b0c2;
		}
	}

	internal x1a78664fa10a3755 x1a78664fa10a3755 => x4379ee33a06c4648;

	internal xeedad81aaed42a76 xeedad81aaed42a76 => xd0c44e5ae0011daa;

	internal int x4d819daa8b29e86b
	{
		get
		{
			return x05a787b7d6f3f716;
		}
		set
		{
			x05a787b7d6f3f716 = value;
		}
	}

	internal bool x44b52529222cea8a => xc9c754014952f758 != null;

	internal Shape xc9c754014952f758
	{
		get
		{
			if (x05a787b7d6f3f716 >= 0 && x05a787b7d6f3f716 < xd1424e1a0bb4a72b.Lists.xe10f375b4290d48f)
			{
				return xd1424e1a0bb4a72b.Lists.x4916e8670feefe58(x05a787b7d6f3f716);
			}
			return null;
		}
	}

	internal int x008c23e8f687bbd3 => xc0b69493b569b5e2;

	internal bool xfbad6d0650721048 => xbf02207f927b6d46 != xc0b69493b569b5e2 - 1;

	internal ListLevel(DocumentBase document, int levelNumber)
	{
		xd1424e1a0bb4a72b = document;
		xc0b69493b569b5e2 = x0d41ea80cfb16612(levelNumber);
		xbf02207f927b6d46 = levelNumber - 1;
	}

	internal ListLevel x8b61531c8ea35b85(DocumentBase x1f83c4681a4a3676)
	{
		ListLevel listLevel = (ListLevel)MemberwiseClone();
		listLevel.xd1424e1a0bb4a72b = x1f83c4681a4a3676;
		listLevel.x4379ee33a06c4648 = (x1a78664fa10a3755)x4379ee33a06c4648.x8b61531c8ea35b85();
		listLevel.xd0c44e5ae0011daa = (xeedad81aaed42a76)xd0c44e5ae0011daa.x8b61531c8ea35b85();
		listLevel.x83cd810ab70afec3 = null;
		return listLevel;
	}

	internal void xd62f9a1bfab2aceb(int xbcea506a33cf9111)
	{
		if (x643ea6380a7dda67(xbcea506a33cf9111))
		{
			x48a3cd56f55f3816 = xbcea506a33cf9111;
		}
	}

	private static bool x643ea6380a7dda67(int xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 >= 0)
		{
			return xbcea506a33cf9111 <= 32767;
		}
		return false;
	}

	internal void xb90138cd78a1ba8e(int xbcea506a33cf9111)
	{
		if (xf74c7e04c971f114(xbcea506a33cf9111))
		{
			xbf02207f927b6d46 = xbcea506a33cf9111;
		}
	}

	private static bool xf74c7e04c971f114(int xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 < -1)
		{
			return xbcea506a33cf9111 < 9;
		}
		return true;
	}

	internal void xcf5f81ead54b5e79(string xbcea506a33cf9111)
	{
		if (xed41d88c7868b0c8(xbcea506a33cf9111))
		{
			xc05f9976504b9b97 = xbcea506a33cf9111;
		}
	}

	internal static bool xed41d88c7868b0c8(string xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 != null && xbcea506a33cf9111.Length <= 30)
		{
			return xbcea506a33cf9111.IndexOf('\uffff') < 0;
		}
		return false;
	}

	internal static bool x775a459d4e3c3432(int xb53acfe332ad6e91)
	{
		if (xb53acfe332ad6e91 >= 0)
		{
			return xb53acfe332ad6e91 < 9;
		}
		return false;
	}

	internal static int x0d41ea80cfb16612(int xb53acfe332ad6e91)
	{
		if (!x775a459d4e3c3432(xb53acfe332ad6e91))
		{
			return 0;
		}
		return xb53acfe332ad6e91;
	}

	internal static bool x1f45bf73937dd66f(ListLevel x3763849ab45f2492, ListLevel xd505507cf33ae543)
	{
		if (x3763849ab45f2492.xf9be1d0b8b44c7e8 == xd505507cf33ae543.xf9be1d0b8b44c7e8 && x3763849ab45f2492.NumberStyle == xd505507cf33ae543.NumberStyle && x3763849ab45f2492.NumberFormat == xd505507cf33ae543.NumberFormat && x3763849ab45f2492.xeedad81aaed42a76.x51cf23ce6e71b84c == xd505507cf33ae543.xeedad81aaed42a76.x51cf23ce6e71b84c && x3763849ab45f2492.xeedad81aaed42a76.xd08cbc518cf39317 == xd505507cf33ae543.xeedad81aaed42a76.xd08cbc518cf39317 && x3763849ab45f2492.x5cf63f659ff5ee9f == xd505507cf33ae543.x5cf63f659ff5ee9f && x3763849ab45f2492.x42bf8be828fc1b33 == xd505507cf33ae543.x42bf8be828fc1b33 && x3763849ab45f2492.x969abf858b3fe7e8 == xd505507cf33ae543.x969abf858b3fe7e8 && x3763849ab45f2492.StartAt == xd505507cf33ae543.StartAt)
		{
			return x3763849ab45f2492.xeedad81aaed42a76.x9b41425268471380 == xd505507cf33ae543.xeedad81aaed42a76.x9b41425268471380;
		}
		return false;
	}
}
