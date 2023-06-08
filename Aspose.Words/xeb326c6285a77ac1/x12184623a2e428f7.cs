using System.Drawing;
using x1c8faa688b1f0b0c;

namespace xeb326c6285a77ac1;

internal class x12184623a2e428f7 : x87fba3f79fbaf7ab
{
	private x1ca435fe7d1dbc75 x361eac9a0ff32a3d;

	private x1ca435fe7d1dbc75 x66cd9622bea96696;

	private x1ca435fe7d1dbc75 x1eb0f2079082dc31;

	internal x1ca435fe7d1dbc75 xc7cf0e43653f9c41
	{
		get
		{
			return x361eac9a0ff32a3d;
		}
		set
		{
			x361eac9a0ff32a3d = value;
		}
	}

	internal x1ca435fe7d1dbc75 xf52fe1c3cad11afd
	{
		get
		{
			return x66cd9622bea96696;
		}
		set
		{
			x66cd9622bea96696 = value;
		}
	}

	internal x1ca435fe7d1dbc75 x2271dea312f4a835
	{
		get
		{
			return x1eb0f2079082dc31;
		}
		set
		{
			x1eb0f2079082dc31 = value;
		}
	}

	internal x12184623a2e428f7(x1ca435fe7d1dbc75[] pathPoints)
	{
		if (pathPoints.Length > 0)
		{
			xc7cf0e43653f9c41 = ((pathPoints[0] != null) ? pathPoints[0] : new x1ca435fe7d1dbc75());
		}
		if (pathPoints.Length > 1)
		{
			xf52fe1c3cad11afd = ((pathPoints[1] != null) ? pathPoints[1] : new x1ca435fe7d1dbc75());
		}
		if (pathPoints.Length > 2)
		{
			x2271dea312f4a835 = ((pathPoints[2] != null) ? pathPoints[2] : new x1ca435fe7d1dbc75());
		}
	}

	public void xe406325e56f74b46(x9118c2b63bc20309 x0f7b23d1c393aed9, x1cab6af0a41b70e2 x6ac16bf6efd00832)
	{
		PointF cubP = x0f7b23d1c393aed9.x704d4080dede6a41(xc7cf0e43653f9c41);
		PointF cubP2 = x0f7b23d1c393aed9.x704d4080dede6a41(xf52fe1c3cad11afd);
		PointF pointF = x0f7b23d1c393aed9.x704d4080dede6a41(x2271dea312f4a835);
		x519b1bd0625473ff xda5bf54deb817e = new x519b1bd0625473ff(x0f7b23d1c393aed9.x06d6c4b9ca4d75f0, cubP, cubP2, pointF);
		x6ac16bf6efd00832.xd6b6ed77479ef68c(xda5bf54deb817e);
		x0f7b23d1c393aed9.x06d6c4b9ca4d75f0 = pointF;
	}
}
