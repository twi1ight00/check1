using System.Collections;
using x66dd9eaee57cfba4;
using x6c95d9cf46ff5f25;

namespace xc7ce8a6a920f8012;

internal class x6ba9063ea0f44561
{
	private const int x767b55565925f803 = 1024;

	private Hashtable x5d2476e5d8444e6e;

	private int[] x82653fa7be4739f8;

	private readonly xcd986872cf3bcf68 xe65db51216614d6f;

	private readonly x6b1a899052c71a60 x83cd810ab70afec3;

	public int[] xf73ef160527516c8
	{
		get
		{
			if (x82653fa7be4739f8 == null)
			{
				x5d2476e5d8444e6e = xe65db51216614d6f.GetGlyphsDataSubset();
				x82653fa7be4739f8 = new int[xe65db51216614d6f.x8f0b229fb69d4269.xd44988f225497f3a];
				for (int i = 0; i < xe65db51216614d6f.x8f0b229fb69d4269.xd44988f225497f3a; i++)
				{
					x82653fa7be4739f8[i] = xe65db51216614d6f.x8f0b229fb69d4269.xf15263674eb297bb(i);
				}
				x8f602bc298b2011c(x82653fa7be4739f8);
			}
			return x82653fa7be4739f8;
		}
	}

	public short x3f80ed349f729542 => x29e43e97a14c50f5(x83cd810ab70afec3.x3f80ed349f729542, 1024f);

	public short xc9f7bec53c29c691 => x29e43e97a14c50f5(x83cd810ab70afec3.xc9f7bec53c29c691, 1024f);

	public short x68260316ab6c4d5b => xc9f7bec53c29c691;

	public x6ba9063ea0f44561(x6b1a899052c71a60 font)
	{
		x83cd810ab70afec3 = font;
		xe65db51216614d6f = font.x78789688b9fe78d2(x4867e759695b4319: false);
	}

	public void x27872d02dfb99793(string xb41faee6912a2313)
	{
		foreach (int item in new x115139807e6482f7(xb41faee6912a2313))
		{
			xe65db51216614d6f.x3452aa488cc9006d(item);
		}
	}

	public int x5810605ff8268f75(int x3c4da2980d043c95)
	{
		int result = xf73ef160527516c8.Length - 1;
		for (int i = 0; i < xf73ef160527516c8.Length; i++)
		{
			if (xf73ef160527516c8[i].Equals(x3c4da2980d043c95))
			{
				result = i;
				break;
			}
		}
		return result;
	}

	public x5ddcd7f1136699aa x10801e6f4a897d62(int x3c4da2980d043c95)
	{
		if (x5d2476e5d8444e6e == null || x5d2476e5d8444e6e.Count == 0)
		{
			x5d2476e5d8444e6e = xe65db51216614d6f.GetGlyphsDataSubset();
		}
		x5ddcd7f1136699aa x5ddcd7f1136699aa = (x5ddcd7f1136699aa)x5d2476e5d8444e6e[xe65db51216614d6f.x3452aa488cc9006d(x3c4da2980d043c95)];
		if (x5ddcd7f1136699aa == null)
		{
			x5d2476e5d8444e6e = xe65db51216614d6f.GetGlyphsDataSubset();
			x5ddcd7f1136699aa = (x5ddcd7f1136699aa)x5d2476e5d8444e6e[xe65db51216614d6f.x3452aa488cc9006d(x3c4da2980d043c95)];
		}
		return x5ddcd7f1136699aa;
	}

	public short xa56be56d48dd0980(int x3c4da2980d043c95)
	{
		return x29e43e97a14c50f5(x83cd810ab70afec3.x1e6da4134d115607.x12f49b36ab885c48(x3c4da2980d043c95).xf58adb71a3d2dade, 1024f);
	}

	public short xa56be56d48dd0980(int x3c4da2980d043c95, float x5c021e387157a637)
	{
		return x29e43e97a14c50f5(x83cd810ab70afec3.x1e6da4134d115607.x12f49b36ab885c48(x3c4da2980d043c95).xf58adb71a3d2dade, x5c021e387157a637);
	}

	private short x29e43e97a14c50f5(int xb0d91e9ccc274d5c, float x5c021e387157a637)
	{
		return (short)x4574ea26106f0edb.x88bf16f2386d633e((float)xb0d91e9ccc274d5c * x5c021e387157a637 / (float)x83cd810ab70afec3.xa25a0348a20dc6ca);
	}

	private static void x8f602bc298b2011c(int[] xc6815cd4fdf9719d)
	{
		for (int i = 0; i < xc6815cd4fdf9719d.Length; i++)
		{
			for (int j = i; j < xc6815cd4fdf9719d.Length; j++)
			{
				if (xc6815cd4fdf9719d[j] < xc6815cd4fdf9719d[i])
				{
					int num = xc6815cd4fdf9719d[i];
					xc6815cd4fdf9719d[i] = xc6815cd4fdf9719d[j];
					xc6815cd4fdf9719d[j] = num;
				}
			}
		}
	}
}
