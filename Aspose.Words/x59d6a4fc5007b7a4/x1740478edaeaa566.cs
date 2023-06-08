using System.Drawing;
using Aspose.Words;

namespace x59d6a4fc5007b7a4;

internal class x1740478edaeaa566
{
	private readonly BorderCollection xac8df3ffedaa82be;

	private RectangleF x09fc35ddf14910dc = RectangleF.Empty;

	private bool x049096dddb3d66df;

	internal Border x92e7e5f35452590d => xac8df3ffedaa82be.Left;

	internal Border x0924cade9dc2d296 => xac8df3ffedaa82be.Right;

	internal Border x9d329a00f2c534a8 => xac8df3ffedaa82be.Top;

	internal Border x3903fbc9023c861c => xac8df3ffedaa82be.Bottom;

	internal RectangleF x007986b943c7e3cf
	{
		get
		{
			return x09fc35ddf14910dc;
		}
		set
		{
			x09fc35ddf14910dc = value;
		}
	}

	internal bool xca170eff54278d9b
	{
		get
		{
			return x049096dddb3d66df;
		}
		set
		{
			x049096dddb3d66df = value;
		}
	}

	internal bool xa853df7acdb217c8 => xac8df3ffedaa82be.xa853df7acdb217c8;

	internal x1740478edaeaa566(BorderCollection borders)
	{
		xac8df3ffedaa82be = borders;
	}
}
