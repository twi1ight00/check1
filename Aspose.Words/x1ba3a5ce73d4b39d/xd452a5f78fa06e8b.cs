using System;
using System.IO;
using Aspose.Words;
using x13f1efc79617a47b;
using xa604c4d210ae0581;

namespace x1ba3a5ce73d4b39d;

internal class xd452a5f78fa06e8b
{
	private readonly FootnoteType xf263b01e2956834c;

	private readonly x6426483e3bbb9344 x0a18a6cfb4c1b981;

	private readonly x8278e339e4553200 x468ef3c14ea011cd;

	internal FootnoteType x3146d638ec378671 => xf263b01e2956834c;

	internal x6426483e3bbb9344 xdf0c8cea9b2d73a3 => x0a18a6cfb4c1b981;

	internal x8278e339e4553200 x0747bb83818026da => x468ef3c14ea011cd;

	internal xd452a5f78fa06e8b(FootnoteType type)
	{
		xf263b01e2956834c = type;
		x0a18a6cfb4c1b981 = new x6426483e3bbb9344();
		x468ef3c14ea011cd = new x8278e339e4553200();
	}

	internal xd452a5f78fa06e8b(FootnoteType type, x8aeace2bf92692ab fib, BinaryReader tableStreamReader)
		: this(type)
	{
		bool flag = type == FootnoteType.Footnote;
		x0a18a6cfb4c1b981.x06b0e25aa6ad68a9(tableStreamReader, flag ? fib.x955a03f821588c52.xbc23df9670516d2e : fib.x955a03f821588c52.x02f3cb4307d8c78e);
		x468ef3c14ea011cd.x06b0e25aa6ad68a9(tableStreamReader, flag ? fib.x955a03f821588c52.x80353a43e2d86d63 : fib.x955a03f821588c52.xfa60923d1655508b);
	}

	internal void x6210059f049f0d48(x8aeace2bf92692ab xf0c8411938a86cbf, BinaryWriter xfd86a6b02a8cb849)
	{
		int fc = (int)xfd86a6b02a8cb849.BaseStream.Position;
		int lcb = x0a18a6cfb4c1b981.x6210059f049f0d48(xfd86a6b02a8cb849);
		x3fdb33c580a0bef3 x3fdb33c580a0bef = new x3fdb33c580a0bef3(fc, lcb);
		fc = (int)xfd86a6b02a8cb849.BaseStream.Position;
		lcb = x468ef3c14ea011cd.x6210059f049f0d48(xfd86a6b02a8cb849);
		x3fdb33c580a0bef3 x3fdb33c580a0bef2 = new x3fdb33c580a0bef3(fc, lcb);
		switch (xf263b01e2956834c)
		{
		case FootnoteType.Footnote:
			xf0c8411938a86cbf.x955a03f821588c52.xbc23df9670516d2e = x3fdb33c580a0bef;
			xf0c8411938a86cbf.x955a03f821588c52.x80353a43e2d86d63 = x3fdb33c580a0bef2;
			break;
		case FootnoteType.Endnote:
			xf0c8411938a86cbf.x955a03f821588c52.x02f3cb4307d8c78e = x3fdb33c580a0bef;
			xf0c8411938a86cbf.x955a03f821588c52.xfa60923d1655508b = x3fdb33c580a0bef2;
			break;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("iplfoadgiakgiabhgaihlaphppfiokmibpdjhpkjepbkgpiknopkloglnonllnemdjlmeocngojnknaommhocjoo", 327965603)));
		}
	}

	internal x52ed50cf5d3a8cc6 xc7a616051c4c1712(int x18d1054d82981887)
	{
		int num = x0a18a6cfb4c1b981.xd888124d3245cd86(x18d1054d82981887);
		if (num < 0)
		{
			return null;
		}
		return new x52ed50cf5d3a8cc6(x468ef3c14ea011cd.xed8a0d4499d6f292(num), x468ef3c14ea011cd.xed8a0d4499d6f292(num + 1), x0a18a6cfb4c1b981.get_xe6d4b1b411ed94b5(num).xa72bf798a679c0aa);
	}

	internal void x3027cf4169823691(int x18d1054d82981887, bool x2b420b6d36637389)
	{
		x001b3b414f984276 x001b3b414f984277 = new x001b3b414f984276();
		x001b3b414f984277.xa72bf798a679c0aa = x2b420b6d36637389;
		x0a18a6cfb4c1b981.xd6b6ed77479ef68c(x18d1054d82981887, x001b3b414f984277);
	}

	internal void x0c36c422d27fe185(int x18d1054d82981887)
	{
		x468ef3c14ea011cd.xd6b6ed77479ef68c(x18d1054d82981887, null);
	}

	internal void x6cb4d2d9258334b4(int x18d1054d82981887)
	{
		x468ef3c14ea011cd.xd6b6ed77479ef68c(x18d1054d82981887);
	}

	internal static x9e131021ba70185c xa339e023ec82f1e3(FootnoteType x43163d22e8cd5a71)
	{
		if (x43163d22e8cd5a71 != 0)
		{
			return x9e131021ba70185c.xd90ac7fcbe961761;
		}
		return x9e131021ba70185c.x69d28a4aeef83a6f;
	}
}
