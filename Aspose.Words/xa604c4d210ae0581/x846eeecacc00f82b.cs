using System.IO;
using Aspose.Words;
using x28925c9b27b37a46;

namespace xa604c4d210ae0581;

internal class x846eeecacc00f82b : xc9072e4c3fa520ad
{
	internal const int x897b24be49f3d022 = 6;

	internal const int x108a410498dfa058 = 6;

	private readonly int xf48fcac3176efe40;

	internal static bool x492f529cee830a40;

	internal x846eeecacc00f82b()
		: base(0)
	{
	}

	internal x846eeecacc00f82b(x8aeace2bf92692ab fib, BinaryReader tableStreamReader, int sectionCount)
		: this()
	{
		xf48fcac3176efe40 = sectionCount;
		_ = x492f529cee830a40;
		x06b0e25aa6ad68a9(tableStreamReader, fib.x955a03f821588c52.xe9e3d679ffb87468);
	}

	internal override int x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		if (base.x23719734cf1f138c <= 6)
		{
			return 0;
		}
		return base.x6210059f049f0d48(xbdfb620b7167944b);
	}

	internal xa6101120b8ed585e x2eca87a66df00843(int xab1fa5fa43793205, HeaderFooterType xa685fef1a31f5d4d)
	{
		int xac3ed817bcc46df = (int)(6 + xab1fa5fa43793205 * 6 + xa685fef1a31f5d4d);
		return xaf71382e78a39b83(xac3ed817bcc46df);
	}

	internal xa6101120b8ed585e xe219bb8e6176962b(x101cddc73c4f8cc2 x4456ba69b7615914)
	{
		return xaf71382e78a39b83((int)x4456ba69b7615914);
	}

	private xa6101120b8ed585e xaf71382e78a39b83(int xac3ed817bcc46df3)
	{
		int num = base.x82b0eb36012eef83 - 1;
		if (x3692da0e08bfb9b5())
		{
			num--;
		}
		num--;
		if (xac3ed817bcc46df3 <= num)
		{
			xa6101120b8ed585e xa6101120b8ed585e2 = new xa6101120b8ed585e(xed8a0d4499d6f292(xac3ed817bcc46df3), xed8a0d4499d6f292(xac3ed817bcc46df3 + 1));
			if (xac3ed817bcc46df3 == num && !x3692da0e08bfb9b5())
			{
				xa6101120b8ed585e2.x9fd888e65466818c--;
			}
			return xa6101120b8ed585e2;
		}
		return null;
	}

	private bool x3692da0e08bfb9b5()
	{
		int num = 6 + xf48fcac3176efe40 * 6 + 1 + 1;
		return num == base.x82b0eb36012eef83;
	}
}
