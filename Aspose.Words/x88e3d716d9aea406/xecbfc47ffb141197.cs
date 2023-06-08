using Aspose;

namespace x88e3d716d9aea406;

[JavaDelete("This is antihacking code, not yet ported to Java. Maybe in the future.")]
internal class xecbfc47ffb141197
{
	private xc2daff3d6b415a63 x7e8e5356836ddc1c;

	internal xc2daff3d6b415a63 xbd64cceba7435748
	{
		get
		{
			return x7e8e5356836ddc1c;
		}
		set
		{
			x7e8e5356836ddc1c = value;
		}
	}

	internal xecbfc47ffb141197(xc2daff3d6b415a63 comparator2)
	{
		x7e8e5356836ddc1c = comparator2;
	}

	internal int[] x45c3b2969fd3bc0e(uint xd0a397c1f04ae76e, uint x29c798cf917086fe)
	{
		int[] array = new int[x7e8e5356836ddc1c.xc945ba8006f88a6a.Length];
		array[0] = (int)(xd0a397c1f04ae76e + x29c798cf917086fe);
		if (x7e8e5356836ddc1c.xc945ba8006f88a6a.Length > 0 && x7e8e5356836ddc1c.xc945ba8006f88a6a.CanRead)
		{
			int num = (int)x7e8e5356836ddc1c.xc945ba8006f88a6a.Length / 2 + 1;
			byte[] array2 = x7e8e5356836ddc1c.xc945ba8006f88a6a.ToArray();
			for (int i = 0; i < num; i++)
			{
				if (array2[i] != (byte)x7e8e5356836ddc1c.x23db847ad278ab22.x5159913dbc6120fd[i])
				{
					x653127678ccafb25.xd3d1e0b7118994e1 = 150;
				}
				array[i] = array2[i];
			}
			x653127678ccafb25.x77b8bf49a239e90d = false;
		}
		return array;
	}
}
