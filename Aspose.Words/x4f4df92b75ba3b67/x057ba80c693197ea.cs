using System.Collections;
using x386b5b86a97fd9d5;
using x6c95d9cf46ff5f25;

namespace x4f4df92b75ba3b67;

internal class x057ba80c693197ea : x6abbea4951acbffd
{
	private const byte x3a50ca3d210eeb0d = 63;

	internal static readonly Hashtable x2b2aa56edc38456a;

	public override void WriteEncodingToFontDictionary(x4f40d990d5bf81a6 writer)
	{
	}

	public override void WriteText(string text, xcd769e39c0788209 writer)
	{
		writer.x94d9025f53df9132(xa8b9c2cfa706a303(text));
	}

	private static byte xa8b9c2cfa706a303(int x079b6eca7602c404)
	{
		if (!x2b2aa56edc38456a.ContainsKey(x079b6eca7602c404))
		{
			return 63;
		}
		return (byte)x2b2aa56edc38456a[x079b6eca7602c404];
	}

	private static byte[] xa8b9c2cfa706a303(string x89cea7a4494c05c1)
	{
		xd7ef508326dd909d xd7ef508326dd909d = new xd7ef508326dd909d();
		foreach (int item in new x115139807e6482f7(x89cea7a4494c05c1))
		{
			xd7ef508326dd909d.xd6b6ed77479ef68c(xa8b9c2cfa706a303(item));
		}
		return xd7ef508326dd909d.x543681a74a4a8026();
	}

	static x057ba80c693197ea()
	{
		x2b2aa56edc38456a = new Hashtable();
		for (int i = 32; i <= 126; i++)
		{
			x2b2aa56edc38456a.Add(i, (byte)i);
			x2b2aa56edc38456a.Add(i + 61440, (byte)i);
		}
		for (int j = 161; j <= 254; j++)
		{
			if (j != 240)
			{
				x2b2aa56edc38456a.Add(j, (byte)j);
				x2b2aa56edc38456a.Add(j + 61440, (byte)j);
			}
		}
	}
}
