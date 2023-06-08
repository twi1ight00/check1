using System;
using x13f1efc79617a47b;
using x6c95d9cf46ff5f25;

namespace x4adf554d20d941a6;

internal class x5566e2d2acbd1fbe
{
	private const int x0bc9a07346bbb13b = 7168;

	internal const int x208f9740de921f55 = 1024;

	internal const int xa04581b1773fafaf = 2048;

	internal const int xec06f8fb689cae44 = 3072;

	internal const int x812847278e385ed2 = 4096;

	internal const int x8cc7e91e49baf34a = 5120;

	private const int xf3082aa5713a7a9d = 512;

	private const int x72b966766ba9708a = 512;

	private const int x3af2af0d5a3e8056 = 256;

	private const int x06b24d68fe0c3d91 = 256;

	internal const int x4d0b9d4447ba7566 = 0;

	internal const int xc8188e9a8690954c = 9216;

	internal const int xf9ad6fb78355fe13 = 9217;

	internal const int x2de7275b51719b31 = 10754;

	internal const int x52cffb079963bcb2 = 12803;

	internal const int x997fffd809d39afd = 10768;

	internal const int x006f8a496611395a = 10769;

	internal const int x33c9b087b28ae15d = 10770;

	internal const int x4cff5e3ce4b4ca73 = 10782;

	internal const int xdd0f04e981bdd97b = 9747;

	internal const int x874a532590635ec5 = 11284;

	internal const int x6693558653dc26ba = 11285;

	internal const int x6d39aeda91fde741 = 9238;

	internal const int xa105f6e68b723c97 = 11799;

	internal const int x1df972b54db8cca1 = 9752;

	internal const int xfbe7bf35cfe76bd5 = 9753;

	internal const int x22f536cff056793c = 9754;

	internal const int x9a3f17614d992c76 = 9755;

	internal const int x9a98ddc0e0e5234f = 9244;

	internal const int x95805ab47f5e2010 = 9245;

	internal const int x53111d6596d16a99 = 21639;

	internal const int x10d7a1cae426b158 = 21857;

	internal const int x1d3f5f87cda165c3 = 21857;

	internal const int x09df06d0f8a42a94 = 21858;

	internal const int x5c93feb532e73700 = 21859;

	internal const int xd5ebfa71835c99de = 21860;

	internal const int xeaee02e70b9c16b5 = 21861;

	internal const int x25af49e7b49ea0bc = 21595;

	internal const int xa19781cfbe8b4961 = 21586;

	internal const int x11db8fc7f469a2fc = 21577;

	internal const int xccf117a1326c3ece = 21536;

	internal const int xfdc1a17f479acc42 = 21537;

	internal const int xa65184d44a47025b = 21788;

	internal const int x2a68e7194376c47a = 10528;

	internal const int x4c38e800e85b21ad = 21779;

	internal const int x48cc0c3eaf9f5f05 = 21514;

	internal const int x2fa36edd09e87b74 = 21513;

	internal const int xa9993ed2e0c64574 = 25604;

	private static readonly string[] x490a8f142b6e5d91 = new string[37]
	{
		"None", "Text", "TextUnknown", "Spaces", "Tab", "EmSpace", "EnSpace", "Em14Space", "NonBreakingSpace", "EmDash",
		"EnDash", "NonBreakingHyphen", "OptionalHyphen", "ZeroWidthNonJoiner", "ZeroWidthJoiner", "LeftToRightMark", "RightToLeftMark", "NoteSeparator", "NoteConitnuationSeparator", "Story",
		"Section", "SectionNextPage", "SectionContinuous", "SectionOddPage", "SectionEvenPage", "SectionNextColumn", "Table", "Row", "Cell", "ParagraphUnknown",
		"Paragraph", "Page", "PageCom", "Column", "Line", "Wrap", "Shape"
	};

	private static readonly int[] xa6685452d46642d1 = new int[37]
	{
		0, 9217, 9216, 10754, 12803, 10768, 10769, 10770, 9747, 11284,
		11285, 9238, 11799, 9752, 9753, 9754, 9755, 9244, 9245, 21639,
		21857, 21857, 21858, 21859, 21860, 21861, 21595, 21586, 21577, 21536,
		21537, 21788, 10528, 21779, 21514, 21513, 25604
	};

	private static readonly char[] x71e4042f505c0306 = new char[2] { ' ', '\t' };

	internal static xfc6971c7d8314663 xfc6971c7d8314663(int xbcea506a33cf9111)
	{
		return (xfc6971c7d8314663)(xbcea506a33cf9111 & 0x1C00);
	}

	internal static bool xdf6487d5ff34ad70(int xbcea506a33cf9111)
	{
		if (xbcea506a33cf9111 != 10754 && xbcea506a33cf9111 != 12803)
		{
			return x43e8e99ceea8a259.xdf6487d5ff34ad70(xbcea506a33cf9111);
		}
		return false;
	}

	internal static bool xbeeb36dfc51db07d(int xbcea506a33cf9111)
	{
		return x43e8e99ceea8a259.xbeeb36dfc51db07d(xbcea506a33cf9111);
	}

	internal static bool x6634ed9c1dfbdfce(int xbcea506a33cf9111)
	{
		return x43e8e99ceea8a259.x6634ed9c1dfbdfce(xbcea506a33cf9111);
	}

	internal static bool xdd614358f99f46b3(int xbcea506a33cf9111)
	{
		return x43e8e99ceea8a259.xdd614358f99f46b3(xbcea506a33cf9111);
	}

	internal static bool xe371fdef7ad898c9(int xbcea506a33cf9111)
	{
		return x43e8e99ceea8a259.xe371fdef7ad898c9(xbcea506a33cf9111);
	}

	internal static bool xd707791130626739(int xbcea506a33cf9111)
	{
		return x43e8e99ceea8a259.xd707791130626739(xbcea506a33cf9111);
	}

	internal static bool x7e8d028aa606b4d3(int xbcea506a33cf9111)
	{
		return x43e8e99ceea8a259.x7e8d028aa606b4d3(xbcea506a33cf9111);
	}

	internal static bool xdad2092d647dc9d8(int xbcea506a33cf9111)
	{
		return x43e8e99ceea8a259.xdad2092d647dc9d8(xbcea506a33cf9111);
	}

	internal static bool xff7735def89bf56b(int xbcea506a33cf9111)
	{
		return x43e8e99ceea8a259.xff7735def89bf56b(xbcea506a33cf9111);
	}

	internal static bool x80b95148e8799434(int xbcea506a33cf9111)
	{
		if (!x6634ed9c1dfbdfce(xbcea506a33cf9111))
		{
			return false;
		}
		return 256 == (xbcea506a33cf9111 & 0x100);
	}

	internal static bool x74f5d3c8c1c169b6(int xbcea506a33cf9111)
	{
		return x43e8e99ceea8a259.x74f5d3c8c1c169b6(xbcea506a33cf9111);
	}

	internal static bool x8197188ddb6f93d3(int xbcea506a33cf9111)
	{
		return x43e8e99ceea8a259.x8197188ddb6f93d3(xbcea506a33cf9111);
	}

	internal static bool x1f181a8f918a6604(int xbcea506a33cf9111)
	{
		return x43e8e99ceea8a259.x1f181a8f918a6604(xbcea506a33cf9111);
	}

	internal static bool x136f1ea510f02333(int xbcea506a33cf9111)
	{
		return x43e8e99ceea8a259.x136f1ea510f02333(xbcea506a33cf9111);
	}

	internal static bool x4215e7520479ea58(int xbcea506a33cf9111)
	{
		return x43e8e99ceea8a259.x4215e7520479ea58(xbcea506a33cf9111);
	}

	internal static bool x32874f91c454ea5e(int xbcea506a33cf9111)
	{
		if (!x7e15ddb01df552ee(xbcea506a33cf9111))
		{
			return xbcea506a33cf9111 == 21779;
		}
		return true;
	}

	internal static bool x7e15ddb01df552ee(int xbcea506a33cf9111)
	{
		if (!x74f5d3c8c1c169b6(xbcea506a33cf9111))
		{
			return xbcea506a33cf9111 == 21788;
		}
		return true;
	}

	internal static bool x20072aabf75d4ae4(int xbcea506a33cf9111)
	{
		if (9216 != xbcea506a33cf9111)
		{
			return 21536 == xbcea506a33cf9111;
		}
		return true;
	}

	internal static bool x550c3129b5fc7fcc(int xbcea506a33cf9111)
	{
		switch (xbcea506a33cf9111)
		{
		case 9216:
		case 9217:
		case 9238:
		case 11284:
		case 11285:
		case 25604:
			return true;
		default:
			return false;
		}
	}

	public static int x5797ad825a33ed60(int xbcea506a33cf9111)
	{
		if ((xbcea506a33cf9111 & 0xE0) == 96)
		{
			xbcea506a33cf9111 = 21857;
		}
		else if (10754 == xbcea506a33cf9111 || 12803 == xbcea506a33cf9111)
		{
			xbcea506a33cf9111 = 9217;
		}
		return xbcea506a33cf9111;
	}

	public static int xdc8d79d0ff934c7c(int xbcea506a33cf9111)
	{
		return xbcea506a33cf9111;
	}

	public static string ToString(int value)
	{
		int num = Array.IndexOf(xa6685452d46642d1, value);
		if (0 > num)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("pekdbhbeghieofpegggfagnfifegbblgegchmejhefaikfhiheoippejcemjiedkiekkdpaldcilndpllcgmfdnmibenkdlnoccoacjogopo", 1876441606)));
		}
		return x490a8f142b6e5d91[num];
	}

	public static int xb0c325557cbfd6d3(string xbcea506a33cf9111)
	{
		xbcea506a33cf9111 = xbcea506a33cf9111.ToLower().Trim(x71e4042f505c0306);
		for (int i = 0; i < x490a8f142b6e5d91.Length; i++)
		{
			if (x490a8f142b6e5d91[i].ToLower() == xbcea506a33cf9111)
			{
				return xa6685452d46642d1[i];
			}
		}
		return xdc8d79d0ff934c7c(x43e8e99ceea8a259.xb0c325557cbfd6d3(xbcea506a33cf9111));
	}

	public static int xdc8d79d0ff934c7c(string xbcea506a33cf9111)
	{
		return xb0c325557cbfd6d3(xbcea506a33cf9111);
	}

	internal static bool x68e7234ad49c6d4d(string xbcea506a33cf9111)
	{
		if (x43e8e99ceea8a259.x8792a57782be0fb0(xbcea506a33cf9111))
		{
			return true;
		}
		xbcea506a33cf9111 = xbcea506a33cf9111.ToLower().Trim(x71e4042f505c0306);
		for (int i = 0; i < x490a8f142b6e5d91.Length; i++)
		{
			if (x490a8f142b6e5d91[i].ToLower() == xbcea506a33cf9111)
			{
				return true;
			}
		}
		return false;
	}
}
