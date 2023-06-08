using System.Drawing;
using x1c8faa688b1f0b0c;

namespace xeb326c6285a77ac1;

internal class x4e3724aefd4e199f : x87fba3f79fbaf7ab
{
	private x1ca435fe7d1dbc75 x779a6174a9539acc;

	private x1ca435fe7d1dbc75 x1eb0f2079082dc31;

	internal x1ca435fe7d1dbc75 x2f997a78d547d657
	{
		get
		{
			return x779a6174a9539acc;
		}
		set
		{
			x779a6174a9539acc = value;
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

	internal x4e3724aefd4e199f(x1ca435fe7d1dbc75[] pathPoints)
	{
		if (pathPoints.Length > 0)
		{
			x2f997a78d547d657 = ((pathPoints[0] != null) ? pathPoints[0] : new x1ca435fe7d1dbc75());
		}
		if (pathPoints.Length > 1)
		{
			x2271dea312f4a835 = ((pathPoints[1] != null) ? pathPoints[1] : new x1ca435fe7d1dbc75());
		}
	}

	public void xe406325e56f74b46(x9118c2b63bc20309 x0f7b23d1c393aed9, x1cab6af0a41b70e2 x6ac16bf6efd00832)
	{
		PointF quadP = x0f7b23d1c393aed9.x704d4080dede6a41(x2f997a78d547d657);
		PointF pointF = x0f7b23d1c393aed9.x704d4080dede6a41(x2271dea312f4a835);
		x519b1bd0625473ff xda5bf54deb817e = new x519b1bd0625473ff(x0f7b23d1c393aed9.x06d6c4b9ca4d75f0, quadP, pointF);
		x6ac16bf6efd00832.xd6b6ed77479ef68c(xda5bf54deb817e);
		x0f7b23d1c393aed9.x06d6c4b9ca4d75f0 = pointF;
	}
}
