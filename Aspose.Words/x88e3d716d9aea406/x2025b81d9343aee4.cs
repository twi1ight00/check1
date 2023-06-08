using System.IO;
using Aspose;

namespace x88e3d716d9aea406;

[JavaDelete("This is antihacking code, not yet ported to Java. Maybe in the future.")]
internal class x2025b81d9343aee4
{
	private bool x0d6acb71d4570d92;

	private byte[] x723bd7c019444336;

	private int[] x9d540397cc10776d;

	internal bool x957a9b2db4bbd52f
	{
		get
		{
			return x0d6acb71d4570d92;
		}
		set
		{
			x0d6acb71d4570d92 = value;
		}
	}

	internal byte[] x61c5830f449ea6a6 => x723bd7c019444336;

	internal int[] x5159913dbc6120fd
	{
		get
		{
			return x9d540397cc10776d;
		}
		set
		{
			x9d540397cc10776d = value;
		}
	}

	internal x2025b81d9343aee4(byte[] dummyParam)
	{
		for (int i = 0; i < dummyParam.Length; i++)
		{
			if (dummyParam[i] > 128 && dummyParam[i] < 192)
			{
				x0d6acb71d4570d92 = true;
				break;
			}
		}
		x723bd7c019444336 = dummyParam;
	}

	internal void x938a7a6f8392b250(int xd0a397c1f04ae76e, int x29c798cf917086fe, bool x5a818e5ab6be4054)
	{
		if (x723bd7c019444336.Length >= 16)
		{
			if (x723bd7c019444336[3] == xd0a397c1f04ae76e)
			{
				x723bd7c019444336[15] = (byte)x216052479859c96a(x29c798cf917086fe);
			}
			for (int i = 0; i < 10; i++)
			{
				x723bd7c019444336[i] = (byte)(x5a818e5ab6be4054 ? 3 : 54);
			}
		}
	}

	internal int x216052479859c96a(int xf0024cc94ade5c88)
	{
		return xf0024cc94ade5c88 * xf0024cc94ade5c88 + 10;
	}

	internal bool xc26e588e0a52d8e6(MemoryStream xd0a397c1f04ae76e, byte[] x6b162fc86c25af7f, int x29c798cf917086fe)
	{
		if (x29c798cf917086fe > 100)
		{
			x0d6acb71d4570d92 = !x0d6acb71d4570d92;
		}
		if (xd0a397c1f04ae76e != null && xd0a397c1f04ae76e.CanWrite)
		{
			xd0a397c1f04ae76e.Write(x6b162fc86c25af7f, 0, x6b162fc86c25af7f.Length);
		}
		x9d540397cc10776d = new int[x6b162fc86c25af7f.Length];
		for (int i = 0; i < x6b162fc86c25af7f.Length; i++)
		{
			x9d540397cc10776d[i] = x6b162fc86c25af7f[i];
		}
		if (x653127678ccafb25.x796372356a5001dc == 48)
		{
			x653127678ccafb25.x796372356a5001dc = 255;
		}
		return x6b162fc86c25af7f.Length == 65535;
	}
}
