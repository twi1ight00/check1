using x6c95d9cf46ff5f25;

namespace x28925c9b27b37a46;

internal class xc7e4e5f194aa67cf
{
	private xc7e4e5f194aa67cf()
	{
	}

	internal static xd8cce4761dc846ee xb31c9ef12c64cea9(int xbcea506a33cf9111, int xc6c5637505dc7157)
	{
		xd8cce4761dc846ee xd8cce4761dc846ee = new xd8cce4761dc846ee(10);
		int num = x1ad5b364545f1858(xc6c5637505dc7157);
		do
		{
			xd8cce4761dc846ee.xd6b6ed77479ef68c(xbcea506a33cf9111 % num);
			xbcea506a33cf9111 /= num;
		}
		while (xbcea506a33cf9111 > 0);
		return xd8cce4761dc846ee;
	}

	private static int x1ad5b364545f1858(int xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			1 => 10, 
			3 => 1000, 
			4 => 10000, 
			_ => 0, 
		};
	}
}
