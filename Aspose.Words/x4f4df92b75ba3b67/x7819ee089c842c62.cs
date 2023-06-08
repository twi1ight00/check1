using System.Collections;
using x386b5b86a97fd9d5;
using x6c95d9cf46ff5f25;

namespace x4f4df92b75ba3b67;

internal class x7819ee089c842c62 : x6abbea4951acbffd
{
	private const byte x8f9b35e4af98532a = 63;

	private const int xc690afde32d30454 = 63;

	private static Hashtable x241c694dcc03984b;

	private static Hashtable x55080f2afed1a745;

	internal static int x5daf4fa8d3eca37d => 32;

	internal static int x2c954a87e3cd6144 => 255;

	public override void WriteEncodingToFontDictionary(x4f40d990d5bf81a6 writer)
	{
		writer.xa4dc0ad8886e23a2("/Encoding", "/WinAnsiEncoding");
	}

	public override void WriteText(string text, xcd769e39c0788209 writer)
	{
		writer.x6210059f049f0d48("(");
		byte[] array = x616408f81e1cc0f1(text);
		for (int i = 0; i < array.Length; i++)
		{
			writer.x66c39d9ce45dda34(array[i]);
		}
		writer.x6210059f049f0d48(")");
	}

	internal static bool xc3b52d8fb3995dd1(int x079b6eca7602c404)
	{
		return x241c694dcc03984b.ContainsKey(x079b6eca7602c404);
	}

	internal static bool xc3b52d8fb3995dd1(byte x44c9d0f39e1eb435)
	{
		return x55080f2afed1a745.ContainsKey(x44c9d0f39e1eb435);
	}

	internal static bool xc15c34808d3f62ec(string x89cea7a4494c05c1)
	{
		if (x89cea7a4494c05c1 == null)
		{
			return false;
		}
		foreach (int item in new x115139807e6482f7(x89cea7a4494c05c1))
		{
			if (!xc3b52d8fb3995dd1(item))
			{
				return false;
			}
		}
		return true;
	}

	internal static byte x616408f81e1cc0f1(int x079b6eca7602c404)
	{
		if (!x241c694dcc03984b.ContainsKey(x079b6eca7602c404))
		{
			return 63;
		}
		return (byte)x241c694dcc03984b[x079b6eca7602c404];
	}

	internal static byte[] x616408f81e1cc0f1(string x89cea7a4494c05c1)
	{
		xd7ef508326dd909d xd7ef508326dd909d = new xd7ef508326dd909d();
		foreach (int item in new x115139807e6482f7(x89cea7a4494c05c1))
		{
			xd7ef508326dd909d.xd6b6ed77479ef68c(x616408f81e1cc0f1(item));
		}
		return xd7ef508326dd909d.x543681a74a4a8026();
	}

	internal static int x3bc87e84cb72b3d7(byte x44c9d0f39e1eb435)
	{
		if (!x55080f2afed1a745.ContainsKey(x44c9d0f39e1eb435))
		{
			return 63;
		}
		return (int)x55080f2afed1a745[x44c9d0f39e1eb435];
	}

	static x7819ee089c842c62()
	{
		x61422e1ee0607420();
	}

	private static void x61422e1ee0607420()
	{
		x241c694dcc03984b = new Hashtable();
		x55080f2afed1a745 = new Hashtable();
		for (int i = 32; i <= 126; i++)
		{
			x9ecf43c58aa5a677(i, (byte)i);
		}
		for (int j = 161; j <= 255; j++)
		{
			if (j != 173)
			{
				x9ecf43c58aa5a677(j, (byte)j);
			}
		}
		x9ecf43c58aa5a677(8364, 128);
		x9ecf43c58aa5a677(8218, 130);
		x9ecf43c58aa5a677(402, 131);
		x9ecf43c58aa5a677(8222, 132);
		x9ecf43c58aa5a677(8230, 133);
		x9ecf43c58aa5a677(8224, 134);
		x9ecf43c58aa5a677(8225, 135);
		x9ecf43c58aa5a677(710, 136);
		x9ecf43c58aa5a677(8240, 137);
		x9ecf43c58aa5a677(352, 138);
		x9ecf43c58aa5a677(8249, 139);
		x9ecf43c58aa5a677(338, 140);
		x9ecf43c58aa5a677(381, 142);
		x9ecf43c58aa5a677(8216, 145);
		x9ecf43c58aa5a677(8217, 146);
		x9ecf43c58aa5a677(8220, 147);
		x9ecf43c58aa5a677(8221, 148);
		x9ecf43c58aa5a677(8226, 149);
		x9ecf43c58aa5a677(8211, 150);
		x9ecf43c58aa5a677(8212, 151);
		x9ecf43c58aa5a677(732, 152);
		x9ecf43c58aa5a677(8482, 153);
		x9ecf43c58aa5a677(353, 154);
		x9ecf43c58aa5a677(8250, 155);
		x9ecf43c58aa5a677(339, 156);
		x9ecf43c58aa5a677(382, 158);
		x9ecf43c58aa5a677(376, 159);
	}

	private static void x9ecf43c58aa5a677(int x8dcb0a33c47803dd, byte x44c9d0f39e1eb435)
	{
		x241c694dcc03984b.Add(x8dcb0a33c47803dd, x44c9d0f39e1eb435);
		x55080f2afed1a745.Add(x44c9d0f39e1eb435, x8dcb0a33c47803dd);
	}
}
