using System;
using x13f1efc79617a47b;

namespace x6c95d9cf46ff5f25;

internal class x43e8e99ceea8a259
{
	public const int x0f2c41c62ea451a7 = 57344;

	public const int x9251633870d67b15 = 0;

	public const int x4a08de865c491d94 = 8192;

	public const int x3f04a2e53da3c75f = 16384;

	public const int xb1cd38291c8533cb = 24576;

	public const int xd42b0985f2bcc1b7 = 224;

	public const int x6a03d3fe894f83cd = 128;

	public const int xcdcdd168cb689d9a = 96;

	public const int xb765fe9c9294f255 = 64;

	public const int xf859c0d215157399 = 32;

	public const int x1b678bfe7d7d21cf = 0;

	public const int xf4fdacc700cb1c2d = 248;

	public const int x3551e0b9ce67c737 = 255;

	public const int x4d0b9d4447ba7566 = 0;

	public const int xc8188e9a8690954c = 8192;

	public const int xf9ad6fb78355fe13 = 8193;

	public const int x997fffd809d39afd = 8208;

	public const int x006f8a496611395a = 8209;

	public const int x33c9b087b28ae15d = 8210;

	public const int xdd0f04e981bdd97b = 8211;

	public const int x874a532590635ec5 = 8212;

	public const int x6693558653dc26ba = 8213;

	public const int x6d39aeda91fde741 = 8214;

	public const int xa105f6e68b723c97 = 8215;

	public const int x1df972b54db8cca1 = 8216;

	public const int xfbe7bf35cfe76bd5 = 8217;

	public const int x22f536cff056793c = 8218;

	public const int x9a3f17614d992c76 = 8219;

	public const int x9a98ddc0e0e5234f = 8220;

	public const int x95805ab47f5e2010 = 8221;

	public const int x4cff5e3ce4b4ca73 = 8222;

	public const int x53111d6596d16a99 = 16519;

	public const int x10d7a1cae426b158 = 16481;

	public const int x25af49e7b49ea0bc = 16475;

	public const int xa19781cfbe8b4961 = 16466;

	public const int x11db8fc7f469a2fc = 16457;

	public const int xccf117a1326c3ece = 16416;

	public const int xfdc1a17f479acc42 = 16417;

	public const int xa65184d44a47025b = 16412;

	public const int x4c38e800e85b21ad = 16403;

	public const int x48cc0c3eaf9f5f05 = 16394;

	public const int x2fa36edd09e87b74 = 16393;

	public const int x94e4690631260a6c = 24576;

	public const int x937e050c63ea1527 = 24577;

	public const int x69d28a4aeef83a6f = 24578;

	public const int xd90ac7fcbe961761 = 24579;

	public const int xa9993ed2e0c64574 = 24580;

	public const int x2c8c6741422a1298 = 16519;

	public static readonly string[] x28bd201e2c8307fd = new string[25]
	{
		"None", "TextUnknown", "Text", "EmSpace", "EnSpace", "Em14Space", "NonBreakingSpace", "EmDash", "EnDash", "NonBreakingHyphen",
		"OptionalHyphen", "ZeroWidthNonJoiner", "ZeroWidthJoiner", "Story", "Section", "Table", "Row", "Cell", "ParagraphUnknown", "Paragraph",
		"Page", "Column", "Line", "Wrap", "Shape"
	};

	public static readonly int[] x786ebf29fba95931 = new int[25]
	{
		0, 8192, 8193, 8208, 8209, 8210, 8211, 8212, 8213, 8214,
		8215, 8216, 8217, 16519, 16481, 16475, 16466, 16457, 16416, 16417,
		16412, 16403, 16394, 16393, 24580
	};

	private static readonly char[] x71e4042f505c0306 = new char[2] { ' ', '\t' };

	private x43e8e99ceea8a259()
	{
	}

	public static bool xdf6487d5ff34ad70(int xbcea506a33cf9111)
	{
		return 8192 == (xbcea506a33cf9111 & 0xE000);
	}

	public static bool xbeeb36dfc51db07d(int xbcea506a33cf9111)
	{
		if (xdf6487d5ff34ad70(xbcea506a33cf9111))
		{
			return (xbcea506a33cf9111 & 0xFF) >= 16;
		}
		return false;
	}

	public static bool x6634ed9c1dfbdfce(int xbcea506a33cf9111)
	{
		return (xbcea506a33cf9111 & 0xE000) == 16384;
	}

	public static bool xdd614358f99f46b3(int xbcea506a33cf9111)
	{
		if (x6634ed9c1dfbdfce(xbcea506a33cf9111))
		{
			return (xbcea506a33cf9111 & 0xE0) == 0;
		}
		return false;
	}

	public static bool xe371fdef7ad898c9(int xbcea506a33cf9111)
	{
		if (x6634ed9c1dfbdfce(xbcea506a33cf9111))
		{
			return (xbcea506a33cf9111 & 0xE0) == 128;
		}
		return false;
	}

	public static bool xd707791130626739(int xbcea506a33cf9111)
	{
		if (x6634ed9c1dfbdfce(xbcea506a33cf9111))
		{
			return (xbcea506a33cf9111 & 0xE0) == 96;
		}
		return false;
	}

	public static bool x7e8d028aa606b4d3(int xbcea506a33cf9111)
	{
		if (x6634ed9c1dfbdfce(xbcea506a33cf9111))
		{
			return (xbcea506a33cf9111 & 0xE0) == 64;
		}
		return false;
	}

	public static bool xdad2092d647dc9d8(int xbcea506a33cf9111)
	{
		if (x6634ed9c1dfbdfce(xbcea506a33cf9111))
		{
			return (xbcea506a33cf9111 & 0xE0) == 32;
		}
		return false;
	}

	public static bool xff7735def89bf56b(int xbcea506a33cf9111)
	{
		return x8075abf5be3eed99(xbcea506a33cf9111) < x8075abf5be3eed99(16417);
	}

	public static bool x74f5d3c8c1c169b6(int xbcea506a33cf9111)
	{
		return x8075abf5be3eed99(xbcea506a33cf9111) >= x8075abf5be3eed99(16481);
	}

	public static bool x8197188ddb6f93d3(int xbcea506a33cf9111)
	{
		return x8075abf5be3eed99(xbcea506a33cf9111) >= x8075abf5be3eed99(16417);
	}

	public static bool x1f181a8f918a6604(int xbcea506a33cf9111)
	{
		return x8075abf5be3eed99(xbcea506a33cf9111) >= x8075abf5be3eed99(16457);
	}

	public static bool x136f1ea510f02333(int xbcea506a33cf9111)
	{
		return x8075abf5be3eed99(xbcea506a33cf9111) >= x8075abf5be3eed99(16466);
	}

	public static bool x4215e7520479ea58(int xbcea506a33cf9111)
	{
		return x8075abf5be3eed99(xbcea506a33cf9111) >= x8075abf5be3eed99(16475);
	}

	public static int x8075abf5be3eed99(int xbcea506a33cf9111)
	{
		if (!x6634ed9c1dfbdfce(xbcea506a33cf9111))
		{
			return 0;
		}
		return xbcea506a33cf9111 & 0xF8;
	}

	public static bool x8792a57782be0fb0(string xbcea506a33cf9111)
	{
		xbcea506a33cf9111 = xbcea506a33cf9111.ToLower().Trim(x71e4042f505c0306);
		for (int i = 0; i < x28bd201e2c8307fd.Length; i++)
		{
			if (x28bd201e2c8307fd[i].ToLower() == xbcea506a33cf9111)
			{
				return true;
			}
		}
		return false;
	}

	public static string ToString(int value)
	{
		for (int i = 0; i < x786ebf29fba95931.Length; i++)
		{
			if (x786ebf29fba95931[i] == value)
			{
				return x28bd201e2c8307fd[i];
			}
		}
		throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ahkncjbohjiophpohigpbinpjheacdlaficbngjbfhaclhhcigocacfddgmdjgdejgkeebbfdeifdgpfjfggmdngofehcflheecikaji", 812898855)));
	}

	public static int xb0c325557cbfd6d3(string xbcea506a33cf9111)
	{
		xbcea506a33cf9111 = xbcea506a33cf9111.ToLower().Trim(x71e4042f505c0306);
		for (int i = 0; i < x28bd201e2c8307fd.Length; i++)
		{
			if (x28bd201e2c8307fd[i].ToLower() == xbcea506a33cf9111)
			{
				return x786ebf29fba95931[i];
			}
		}
		throw new ArgumentException("Value " + xbcea506a33cf9111 + " cannot be converted to RunType.");
	}
}
