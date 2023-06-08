using System.Reflection;
using System.Text;

namespace x59d6a4fc5007b7a4;

[DefaultMember("Item")]
internal class xb20bb345580a2369
{
	private readonly xa1a7cce7c5e4a4dc xb14db7591535b378;

	private readonly StringBuilder xed4a7b1500064e12;

	private readonly int[] x81bc353a1c5da9ad;

	private int xbf03dd83dc9d3892;

	internal int x1be93eed8950d961
	{
		get
		{
			return xed4a7b1500064e12.Length;
		}
		set
		{
			xed4a7b1500064e12.Length = value;
		}
	}

	internal char xe6d4b1b411ed94b5
	{
		get
		{
			return xed4a7b1500064e12[xc0c4c459c6ccbd00];
		}
		set
		{
			xed4a7b1500064e12[xc0c4c459c6ccbd00] = value;
		}
	}

	internal xb20bb345580a2369(xa1a7cce7c5e4a4dc runString)
	{
		xb14db7591535b378 = runString;
		xed4a7b1500064e12 = new StringBuilder();
		x81bc353a1c5da9ad = new int[xb14db7591535b378.xcace819d50a03332];
		xbf03dd83dc9d3892 = 0;
	}

	internal void xef23aa45e7612fdd(int xc0c4c459c6ccbd00, char xb867a42da3ae686d, int x6c428075bb2fdc3b)
	{
		x992471075bce873e(xc0c4c459c6ccbd00, x6c428075bb2fdc3b);
		xed4a7b1500064e12.Insert(xc0c4c459c6ccbd00, xb867a42da3ae686d);
	}

	internal void x917b69030691beda(char xb867a42da3ae686d, int x6c428075bb2fdc3b)
	{
		x992471075bce873e(xed4a7b1500064e12.Length, x6c428075bb2fdc3b);
		xed4a7b1500064e12.Append(xb867a42da3ae686d);
	}

	internal void xdad5cca7f9d3dff4(int x13d4cb8d1bd20347)
	{
		for (int i = 0; i < x81bc353a1c5da9ad.Length; i++)
		{
			if (x13d4cb8d1bd20347 < x81bc353a1c5da9ad[i])
			{
				x81bc353a1c5da9ad[i]--;
			}
		}
	}

	internal void xcd5f7940e9d851bd()
	{
		xb14db7591535b378.xcd5f7940e9d851bd(xed4a7b1500064e12.ToString(), x81bc353a1c5da9ad);
	}

	private void x992471075bce873e(int xc0c4c459c6ccbd00, int x6c428075bb2fdc3b)
	{
		int num = xb14db7591535b378.x7c9168d2804254a7(x6c428075bb2fdc3b);
		x81bc353a1c5da9ad[num] = xc0c4c459c6ccbd00;
		if (num != xbf03dd83dc9d3892)
		{
			x81bc353a1c5da9ad[xbf03dd83dc9d3892] = xc0c4c459c6ccbd00;
			xbf03dd83dc9d3892 = num;
		}
	}
}
