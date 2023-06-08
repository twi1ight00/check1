using System.IO;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace x4f4df92b75ba3b67;

internal class x4f40d990d5bf81a6 : xcd769e39c0788209
{
	private readonly x09ce2c02826e31a6 x112ff45413dcf7de;

	public int x0ac04543e6572f02 => x112ff45413dcf7de.xd44988f225497f3a;

	public x4f40d990d5bf81a6(Stream stream)
		: base(stream)
	{
		x112ff45413dcf7de = new x09ce2c02826e31a6();
		x112ff45413dcf7de.xd6b6ed77479ef68c(0, 0);
	}

	public void x7a67b9beb30292d6(x264ba3b7aca691be xa59bff7708de3a18)
	{
		x112ff45413dcf7de.xd6b6ed77479ef68c(xa59bff7708de3a18.xea1e81378298fa81, (int)base.x9e418ad9a56d1cf5.Position);
		x25d0efbd7848eeb3("{0} 0 obj", xca004f56614e2431.xc8ba948e0d631490(xa59bff7708de3a18.xea1e81378298fa81));
	}

	public void x5155d7b9dab28280()
	{
		x25d0efbd7848eeb3();
		x25d0efbd7848eeb3("endobj");
	}

	public int xc5ae6b313da3b21f()
	{
		int result = (int)base.x9e418ad9a56d1cf5.Position;
		x25d0efbd7848eeb3("xref");
		x25d0efbd7848eeb3("0 {0}", xca004f56614e2431.xc8ba948e0d631490(x112ff45413dcf7de.xd44988f225497f3a));
		x25d0efbd7848eeb3("0000000000 65535 f");
		for (int i = 1; i < x112ff45413dcf7de.xd44988f225497f3a; i++)
		{
			x25d0efbd7848eeb3("{0} 00000 n", xca004f56614e2431.xc2db0f7f91c78fc3((int)x112ff45413dcf7de.x6d3720b962bd3112(i)));
		}
		return result;
	}
}
