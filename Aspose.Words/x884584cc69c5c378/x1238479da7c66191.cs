using System;
using System.IO;
using x13f1efc79617a47b;
using xa604c4d210ae0581;

namespace x884584cc69c5c378;

internal class x1238479da7c66191
{
	private readonly x9e131021ba70185c x7a1a247785b9a739;

	private readonly x5b028e6f77aa097a x741f79831c803715;

	private readonly xde5d9c30fcf5b57a x58a8ad8a0b4c70ee;

	private readonly x6ccd3c3c85fdbe20 x1b767b6fffda46de;

	internal x5b028e6f77aa097a x4a74ca8842ca69ab => x741f79831c803715;

	internal xde5d9c30fcf5b57a x6d996d87ff4d558d => x58a8ad8a0b4c70ee;

	internal x6ccd3c3c85fdbe20 xe34a3fe7b2d83a85 => x1b767b6fffda46de;

	internal x1238479da7c66191(x9e131021ba70185c subDocType)
	{
		if (subDocType != 0 && subDocType != x9e131021ba70185c.x1ea60bde2b5d0d28)
		{
			throw new ArgumentException("subDocType");
		}
		x7a1a247785b9a739 = subDocType;
		x741f79831c803715 = new x5b028e6f77aa097a();
		x58a8ad8a0b4c70ee = new xde5d9c30fcf5b57a();
		x1b767b6fffda46de = new x6ccd3c3c85fdbe20();
	}

	internal x1238479da7c66191(x9e131021ba70185c subDocType, x8aeace2bf92692ab fib, BinaryReader tableStreamReader)
		: this(subDocType)
	{
		bool flag = x7a1a247785b9a739 == x9e131021ba70185c.xc447809891322395;
		x3fdb33c580a0bef3 xe83fbae1e983d = (flag ? fib.x955a03f821588c52.x209579bb86dad29b : fib.x955a03f821588c52.xcdf38f8645195a32);
		x741f79831c803715.x06b0e25aa6ad68a9(tableStreamReader, xe83fbae1e983d);
		x3fdb33c580a0bef3 xe83fbae1e983d2 = (flag ? fib.x955a03f821588c52.xbceae965332779b6 : fib.x955a03f821588c52.xa742cc474be6ecce);
		x58a8ad8a0b4c70ee.x06b0e25aa6ad68a9(tableStreamReader, xe83fbae1e983d2);
		x3fdb33c580a0bef3 xe83fbae1e983d3 = (flag ? fib.x955a03f821588c52.xc07dac22ac225b4a : fib.x955a03f821588c52.x429ece0e5b6c056d);
		x1b767b6fffda46de.x06b0e25aa6ad68a9(tableStreamReader, xe83fbae1e983d3);
	}

	internal void x6210059f049f0d48(x8aeace2bf92692ab xf0c8411938a86cbf, BinaryWriter xbdfb620b7167944b)
	{
		int fc = (int)xbdfb620b7167944b.BaseStream.Position;
		int lcb = x741f79831c803715.x6210059f049f0d48(xbdfb620b7167944b);
		x3fdb33c580a0bef3 x3fdb33c580a0bef = new x3fdb33c580a0bef3(fc, lcb);
		fc = (int)xbdfb620b7167944b.BaseStream.Position;
		lcb = x58a8ad8a0b4c70ee.x6210059f049f0d48(xbdfb620b7167944b);
		x3fdb33c580a0bef3 x3fdb33c580a0bef2 = new x3fdb33c580a0bef3(fc, lcb);
		fc = (int)xbdfb620b7167944b.BaseStream.Position;
		lcb = x1b767b6fffda46de.x6210059f049f0d48(xbdfb620b7167944b);
		x3fdb33c580a0bef3 x3fdb33c580a0bef3 = new x3fdb33c580a0bef3(fc, lcb);
		if (x7a1a247785b9a739 == x9e131021ba70185c.xc447809891322395)
		{
			xf0c8411938a86cbf.x955a03f821588c52.x209579bb86dad29b = x3fdb33c580a0bef;
			xf0c8411938a86cbf.x955a03f821588c52.xbceae965332779b6 = x3fdb33c580a0bef2;
			xf0c8411938a86cbf.x955a03f821588c52.xc07dac22ac225b4a = x3fdb33c580a0bef3;
		}
		else
		{
			xf0c8411938a86cbf.x955a03f821588c52.xcdf38f8645195a32 = x3fdb33c580a0bef;
			xf0c8411938a86cbf.x955a03f821588c52.xa742cc474be6ecce = x3fdb33c580a0bef2;
			xf0c8411938a86cbf.x955a03f821588c52.x429ece0e5b6c056d = x3fdb33c580a0bef3;
		}
	}

	internal xac083244a6c1aa10 x6704a7933d78741d(int x18d1054d82981887)
	{
		int num = x741f79831c803715.xd888124d3245cd86(x18d1054d82981887);
		if (num < 0)
		{
			return null;
		}
		return x741f79831c803715.get_xe6d4b1b411ed94b5(num);
	}

	internal xac083244a6c1aa10 x7b9e063fd68f71e2(int x1f6ee650d037e627)
	{
		for (int i = 0; i < x741f79831c803715.x23719734cf1f138c; i++)
		{
			xac083244a6c1aa10 xac083244a6c1aa11 = x741f79831c803715.get_xe6d4b1b411ed94b5(i);
			if (xac083244a6c1aa11.x1f6ee650d037e627 == x1f6ee650d037e627)
			{
				return xac083244a6c1aa11;
			}
		}
		throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("eddfpekfjfbggfigefpggfghppmhceeicelieecjhdjjappjochkidokhoelkamlebdmoakmmpaninhnlbpnbcgobcnommdpnblpoacaiajaampaeahbdaobnafcjplcppcdokjdopaeaphegooecpffeomfmjdgcokgknbhbkih", 1766019825)));
	}

	internal xcc3ba13909434925 xdcd8f9af39d96c9b(int x1f6ee650d037e627)
	{
		for (int i = 0; i < x58a8ad8a0b4c70ee.x23719734cf1f138c; i++)
		{
			x10b00fc1d89e308c x10b00fc1d89e308c2 = x58a8ad8a0b4c70ee.get_xe6d4b1b411ed94b5(i);
			if (x10b00fc1d89e308c2.x835e4449b464b4ff == x1f6ee650d037e627)
			{
				return new xcc3ba13909434925(x58a8ad8a0b4c70ee.xed8a0d4499d6f292(i), x58a8ad8a0b4c70ee.xed8a0d4499d6f292(i + 1), x10b00fc1d89e308c2);
			}
		}
		return null;
	}
}
