using Aspose.Words;
using x28925c9b27b37a46;
using xf989f31a236ff98c;

namespace xce0136f05681c5e9;

internal class xaafc79486ac2fb8d : xaa47e6d0b035aea6
{
	private const string x5831f68f25d2c0c4 = "\u00a0\u00a0\u00a0\u00a0\u00a0\u00a0\u00a0\u00a0\u00a0\u00a0\u00a0\u00a0\u00a0 ";

	private int x5900a8325d3ebbc1;

	private readonly x4eefe5e664198999 x12954a224495d3c0;

	private readonly xe2ff3c3cd396cfd9 x18ddd758cd8495e3;

	private readonly x934b8a992f1985f7 xb9e6b034b22e403e;

	internal int x7e50cb8382af4dda => x5900a8325d3ebbc1;

	internal xaafc79486ac2fb8d(x4eefe5e664198999 spanWriter, xe2ff3c3cd396cfd9 writerCommon, x934b8a992f1985f7 tableWriter)
	{
		x12954a224495d3c0 = spanWriter;
		x18ddd758cd8495e3 = writerCommon;
		xb9e6b034b22e403e = tableWriter;
	}

	public void x4fb8d507f4b3c96e(Font x26094932cf7a9139, string xb41faee6912a2313, x000f21cbda739311 xcb075c7088c3b520)
	{
		x12954a224495d3c0.x7e87e53a0ba2f770(x26094932cf7a9139, xb41faee6912a2313, xcb075c7088c3b520, x07532f30a274f493: true, xf544375d86767c28: true);
	}

	public void xa2b89eef4b059bae(Font x26094932cf7a9139)
	{
		x12954a224495d3c0.x4f6533d333848d34(x26094932cf7a9139, xf544375d86767c28: false);
	}

	public void x284f8021a6d47363(Font x26094932cf7a9139)
	{
		x18ddd758cd8495e3.xe1410f585439c7d4.xd52401bdf5aacef6("<br />");
	}

	public void x6597dd39dd2fe401(Font x26094932cf7a9139)
	{
		if (!xb9e6b034b22e403e.xf7499ae99c6308ad)
		{
			if (x5900a8325d3ebbc1 > 0)
			{
				x5900a8325d3ebbc1--;
			}
			else
			{
				x18ddd758cd8495e3.xe1410f585439c7d4.xd52401bdf5aacef6("<br style=\"page-break-before:always; clear:both\" />");
			}
		}
	}

	public void x52597787a113eeb0(Font x26094932cf7a9139)
	{
		if (!xb9e6b034b22e403e.xf7499ae99c6308ad)
		{
			if (x5900a8325d3ebbc1 > 0)
			{
				x5900a8325d3ebbc1--;
			}
			else
			{
				x18ddd758cd8495e3.xe1410f585439c7d4.xd52401bdf5aacef6("<br style=\"mso-column-break-before:always; clear:both\" />");
			}
		}
	}

	public void x3d5e17ecf5a24632(Font x26094932cf7a9139)
	{
		x12954a224495d3c0.x7e87e53a0ba2f770(x26094932cf7a9139, "\u00a0\u00a0\u00a0\u00a0\u00a0\u00a0\u00a0\u00a0\u00a0\u00a0\u00a0\u00a0\u00a0 ", x000f21cbda739311.x175297738c8b8d1e, x07532f30a274f493: false, xf544375d86767c28: true);
	}

	public void x036788cf7c188d59(Font x26094932cf7a9139)
	{
		x12954a224495d3c0.x4f6533d333848d34(x26094932cf7a9139, xf544375d86767c28: true);
	}

	public void x85c770ad4ef06982(Font x26094932cf7a9139)
	{
		x12954a224495d3c0.x7e87e53a0ba2f770(x26094932cf7a9139, "&#x2011;", x000f21cbda739311.x175297738c8b8d1e, x07532f30a274f493: false, xf544375d86767c28: true);
	}

	public void xf376b77c1a1556bf(Font x26094932cf7a9139)
	{
		x12954a224495d3c0.x7e87e53a0ba2f770(x26094932cf7a9139, "&#xad;", x000f21cbda739311.x175297738c8b8d1e, x07532f30a274f493: false, xf544375d86767c28: true);
	}

	public void x920950f507ecd136(Font x26094932cf7a9139, bool xe68b7760102eb0fd)
	{
		x12954a224495d3c0.x7e87e53a0ba2f770(x26094932cf7a9139, xe68b7760102eb0fd ? "&#x200f;" : "&#x200e;", x000f21cbda739311.x175297738c8b8d1e, x07532f30a274f493: false, xf544375d86767c28: true);
	}

	internal void x7f14e8973965e158()
	{
		x5900a8325d3ebbc1++;
	}
}
