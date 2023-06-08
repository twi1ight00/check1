using x28925c9b27b37a46;

namespace x639ad3f66698fe1b;

internal class x148fd2848896e29d
{
	private enum x4ba807ad2b7ae0ca
	{
		x236cb0a4295bc034,
		x67c6f9b4f8c01fd0,
		xbc9b1d54494b8b37,
		xdf631c7ea6b0e23f,
		xcd39be49a4b4cc90,
		x46ec932e37b26f68,
		x917acaedc6884717
	}

	private x9cb1edcd9725c81e x700b37a2d2434021;

	private x000f21cbda739311 x602a158b07289d09;

	private readonly x21f0d20d41203be1 x8cedcaa9a62c6e39;

	private readonly xbfd162a6d47f59a4 x800085dd555f7711;

	internal x000f21cbda739311 x7a10833b0359b21e => x602a158b07289d09;

	internal x148fd2848896e29d(x21f0d20d41203be1 context)
	{
		x74f5a1ef3906e23c();
		x8cedcaa9a62c6e39 = context;
		x800085dd555f7711 = context.xe1410f585439c7d4;
	}

	internal void x6210059f049f0d48(x9cb1edcd9725c81e xb2e122499d93a089)
	{
		x74f5a1ef3906e23c();
		x700b37a2d2434021 = xb2e122499d93a089;
		switch (x87a663b35b104047())
		{
		case x4ba807ad2b7ae0ca.x67c6f9b4f8c01fd0:
			x800085dd555f7711.x4d14ee33f46b5913("\\loch");
			break;
		case x4ba807ad2b7ae0ca.xbc9b1d54494b8b37:
			x800085dd555f7711.x4d14ee33f46b5913("\\hich");
			break;
		case x4ba807ad2b7ae0ca.xdf631c7ea6b0e23f:
			x800085dd555f7711.x4d14ee33f46b5913("\\dbch");
			break;
		case x4ba807ad2b7ae0ca.xcd39be49a4b4cc90:
			x708e4a6a31bf1910("\\hich", x700b37a2d2434021.xd08cbc518cf39317, "\\dbch", x700b37a2d2434021.x31ece097bda75a20, "\\loch");
			break;
		case x4ba807ad2b7ae0ca.x46ec932e37b26f68:
			x708e4a6a31bf1910("\\loch", x700b37a2d2434021.x51cf23ce6e71b84c, "\\dbch", x700b37a2d2434021.x31ece097bda75a20, "\\hich");
			break;
		case x4ba807ad2b7ae0ca.x917acaedc6884717:
			x708e4a6a31bf1910("\\loch", x700b37a2d2434021.x51cf23ce6e71b84c, "\\hich", x700b37a2d2434021.xd08cbc518cf39317, "\\dbch");
			break;
		case x4ba807ad2b7ae0ca.x236cb0a4295bc034:
			break;
		}
	}

	internal void x74f5a1ef3906e23c()
	{
		x602a158b07289d09 = x000f21cbda739311.x22a0fbb9469b35e1;
	}

	private void x708e4a6a31bf1910(string x31f4fac3d37335ee, string xd7a4ec3db029556c, string xe99b3e96c9f85ec1, string x80763eaa7831e7d0, string x85d6823b3122f9bb)
	{
		x800085dd555f7711.x4d14ee33f46b5913(x31f4fac3d37335ee);
		x4155bdfa7862bbeb.x1bc2bcdcd4e18aad(x8cedcaa9a62c6e39, x30187f754ccc677c: true, xd7a4ec3db029556c);
		x800085dd555f7711.x4d14ee33f46b5913(xe99b3e96c9f85ec1);
		x4155bdfa7862bbeb.x1bc2bcdcd4e18aad(x8cedcaa9a62c6e39, x30187f754ccc677c: true, x80763eaa7831e7d0);
		x800085dd555f7711.x4d14ee33f46b5913(x85d6823b3122f9bb);
	}

	private x4ba807ad2b7ae0ca x87a663b35b104047()
	{
		if (x700b37a2d2434021.xaf983f33c1f4f82f)
		{
			x602a158b07289d09 = x000f21cbda739311.xd4e922ceeed89b74;
			return x4ba807ad2b7ae0ca.x236cb0a4295bc034;
		}
		if (x700b37a2d2434021.x51cf23ce6e71b84c == x700b37a2d2434021.xd08cbc518cf39317 && (x700b37a2d2434021.x31ece097bda75a20 == null || x700b37a2d2434021.x31ece097bda75a20 == "Times New Roman"))
		{
			x602a158b07289d09 = x000f21cbda739311.x22a0fbb9469b35e1;
			return x4ba807ad2b7ae0ca.x236cb0a4295bc034;
		}
		if (x700b37a2d2434021.x51cf23ce6e71b84c == null && x700b37a2d2434021.xd08cbc518cf39317 == null)
		{
			x602a158b07289d09 = x000f21cbda739311.x7c8c2d13fa5b79fa;
			return x4ba807ad2b7ae0ca.xdf631c7ea6b0e23f;
		}
		if (x700b37a2d2434021.x51cf23ce6e71b84c == null && x700b37a2d2434021.x31ece097bda75a20 == null)
		{
			x602a158b07289d09 = x000f21cbda739311.x22a0fbb9469b35e1;
			return x4ba807ad2b7ae0ca.xbc9b1d54494b8b37;
		}
		if (x700b37a2d2434021.xd08cbc518cf39317 == null && x700b37a2d2434021.x31ece097bda75a20 == null)
		{
			x602a158b07289d09 = x000f21cbda739311.x175297738c8b8d1e;
			return x4ba807ad2b7ae0ca.x67c6f9b4f8c01fd0;
		}
		if (x700b37a2d2434021.x405f93d712e7bd65 == x000f21cbda739311.x7c8c2d13fa5b79fa)
		{
			x602a158b07289d09 = x000f21cbda739311.x7c8c2d13fa5b79fa;
			return x4ba807ad2b7ae0ca.x917acaedc6884717;
		}
		if (x700b37a2d2434021.x405f93d712e7bd65 != x000f21cbda739311.xd4e922ceeed89b74 && x700b37a2d2434021.xd08cbc518cf39317 == null)
		{
			x602a158b07289d09 = x000f21cbda739311.x175297738c8b8d1e;
			return x4ba807ad2b7ae0ca.xcd39be49a4b4cc90;
		}
		x602a158b07289d09 = x000f21cbda739311.x22a0fbb9469b35e1;
		return x4ba807ad2b7ae0ca.x46ec932e37b26f68;
	}
}
