using System.Collections;
using Aspose.Words;
using xda075892eccab2ad;

namespace x28925c9b27b37a46;

internal class xd9263e6f13384bf1
{
	internal const int xe9e531d1a6725226 = 0;

	internal const int x7c30f374e3092708 = 1;

	internal const int x6ff7d61b75939ab1 = 2;

	internal const int xd35955712b077ee7 = 3;

	internal const int x35374142c5b3c56b = 4;

	internal const int x5334288b1d4efa1a = 5;

	internal const int x31bf0dcd00fbb2cb = 6;

	internal const int xd949189f0493b45f = 7;

	internal const int x174e555343507207 = 8;

	internal const int x6daccd2d707b3c34 = 9;

	internal const int xb595b82a249bbc9a = 10;

	internal const int x427fbe24f63e1056 = 11;

	internal const int x3caa2b68b5468ba9 = 12;

	internal const int x58ca3d95412cdb78 = 4095;

	internal const int x25d26846c330b189 = 4095;

	private static readonly Hashtable x60f1a8dc13d04827;

	private xd9263e6f13384bf1()
	{
	}

	private static StyleIdentifier xd78232133798ff38(string xc15bd84e01929885)
	{
		return x72a0c846678ecaf9.x3b3cea4656a2e16d(xc15bd84e01929885);
	}

	internal static void x2bb7806b0066b22a(Style x44ecfea61c937b8e, string x9038bd15f8cd74c7)
	{
		StyleIdentifier styleIdentifier = xd78232133798ff38(x9038bd15f8cd74c7);
		int x8301ab10c226b0c = x44ecfea61c937b8e.x8301ab10c226b0c2;
		int num = ((styleIdentifier != StyleIdentifier.User) ? x3311b2da513e599c(x44ecfea61c937b8e, styleIdentifier) : ((!x44ecfea61c937b8e.BuiltIn) ? (-1) : xcc80810af0571d37(x44ecfea61c937b8e)));
		if (num != -1)
		{
			x44ecfea61c937b8e.Styles.x255ed75560e42420(x44ecfea61c937b8e, x8301ab10c226b0c, num);
		}
	}

	internal static int xcc80810af0571d37(Style x44ecfea61c937b8e)
	{
		int num = -1;
		x44ecfea61c937b8e.x7ac71dcbd33d6241(StyleIdentifier.User, x6d60cf0a80bb0eb6: true);
		if (xd0cde12da7541570(x44ecfea61c937b8e.x8301ab10c226b0c2))
		{
			num = x44ecfea61c937b8e.Styles.xdc32dcfe6668100d();
			x44ecfea61c937b8e.xd01720d5ff2238cc(num, x6d60cf0a80bb0eb6: true);
		}
		return num;
	}

	internal static int x3311b2da513e599c(Style x44ecfea61c937b8e, StyleIdentifier xa3be2ccad541ab25)
	{
		x44ecfea61c937b8e.x7ac71dcbd33d6241(xa3be2ccad541ab25, x6d60cf0a80bb0eb6: true);
		int num = x778a4fac7992bc43(xa3be2ccad541ab25);
		if (num != 4095)
		{
			x44ecfea61c937b8e.xd01720d5ff2238cc(num, x6d60cf0a80bb0eb6: true);
			return num;
		}
		return -1;
	}

	internal static int x778a4fac7992bc43(StyleIdentifier xa3be2ccad541ab25)
	{
		int result = 4095;
		if (x60f1a8dc13d04827.Contains(xa3be2ccad541ab25))
		{
			result = (int)x60f1a8dc13d04827[xa3be2ccad541ab25];
		}
		return result;
	}

	internal static bool xd0cde12da7541570(int xddd12ddd8b1e4a90)
	{
		return x60f1a8dc13d04827.ContainsValue(xddd12ddd8b1e4a90);
	}

	static xd9263e6f13384bf1()
	{
		x60f1a8dc13d04827 = new Hashtable();
		x60f1a8dc13d04827.Add(StyleIdentifier.Normal, 0);
		x60f1a8dc13d04827.Add(StyleIdentifier.Heading1, 1);
		x60f1a8dc13d04827.Add(StyleIdentifier.Heading2, 2);
		x60f1a8dc13d04827.Add(StyleIdentifier.Heading3, 3);
		x60f1a8dc13d04827.Add(StyleIdentifier.Heading4, 4);
		x60f1a8dc13d04827.Add(StyleIdentifier.Heading5, 5);
		x60f1a8dc13d04827.Add(StyleIdentifier.Heading6, 6);
		x60f1a8dc13d04827.Add(StyleIdentifier.Heading7, 7);
		x60f1a8dc13d04827.Add(StyleIdentifier.Heading8, 8);
		x60f1a8dc13d04827.Add(StyleIdentifier.Heading9, 9);
		x60f1a8dc13d04827.Add(StyleIdentifier.DefaultParagraphFont, 10);
		x60f1a8dc13d04827.Add(StyleIdentifier.TableNormal, 11);
		x60f1a8dc13d04827.Add(StyleIdentifier.NoList, 12);
	}
}
