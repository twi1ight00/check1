using System.Collections;

namespace x4adf554d20d941a6;

internal class xb24f38e84324adff
{
	private readonly ArrayList x4e16d8e7db7d7db1 = new ArrayList();

	internal int x78c85d0a8292b300 => x4e16d8e7db7d7db1.Count;

	internal xd9db44bb47d1be90 xfeb19f1007c0b581(int xc0c4c459c6ccbd00)
	{
		if (0 <= xc0c4c459c6ccbd00)
		{
			return (xd9db44bb47d1be90)x4e16d8e7db7d7db1[xc0c4c459c6ccbd00];
		}
		for (int i = 0; i < x4e16d8e7db7d7db1.Count; i++)
		{
			xd9db44bb47d1be90 xd9db44bb47d1be91 = (xd9db44bb47d1be90)x4e16d8e7db7d7db1[i];
			if (xc0c4c459c6ccbd00 == 0)
			{
				return xd9db44bb47d1be91;
			}
			xc0c4c459c6ccbd00 += xd9db44bb47d1be91.x6e1eb96b81362ebc;
			if (0 < xc0c4c459c6ccbd00)
			{
				break;
			}
		}
		return null;
	}

	internal void xd6b6ed77479ef68c(xd9db44bb47d1be90 xe6de5e5fa2d44af5)
	{
		x4e16d8e7db7d7db1.Add(xe6de5e5fa2d44af5);
	}
}
