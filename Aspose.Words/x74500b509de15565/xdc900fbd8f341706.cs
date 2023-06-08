using System.Drawing;
using xa7850104c8d8c135;

namespace x74500b509de15565;

internal class xdc900fbd8f341706 : x8a4357ae13046a35
{
	private Region x22ec4ec5d9dae8c4;

	private Region xfb29e3becee5329b;

	public xdc900fbd8f341706(RectangleF metafileBounds)
		: base(metafileBounds)
	{
	}

	public void x74f5a1ef3906e23c()
	{
		x22ec4ec5d9dae8c4 = null;
		xbb51cf398865871a();
	}

	public void x3ba89ef66ec1bfc3(Region xa4d52e34b62b5495, x209db13a33ccc536 xace224b4e703e245)
	{
		xf0d3c9279444c480(xace224b4e703e245);
		switch (xace224b4e703e245)
		{
		case x209db13a33ccc536.x46f0ec9f7f657efb:
			x22ec4ec5d9dae8c4.Union(xa4d52e34b62b5495);
			break;
		case x209db13a33ccc536.xb56b87770d51d55a:
			x22ec4ec5d9dae8c4.Intersect(xa4d52e34b62b5495);
			break;
		case x209db13a33ccc536.x4c5ede5040bbffe5:
			x22ec4ec5d9dae8c4.Xor(xa4d52e34b62b5495);
			break;
		case x209db13a33ccc536.xb016980fad4c82af:
			x22ec4ec5d9dae8c4.Exclude(xa4d52e34b62b5495);
			break;
		case x209db13a33ccc536.x775521112ede5e6f:
			x22ec4ec5d9dae8c4 = xa4d52e34b62b5495.Clone();
			break;
		}
		xbb51cf398865871a();
	}

	private void xf0d3c9279444c480(x209db13a33ccc536 xace224b4e703e245)
	{
		if (x22ec4ec5d9dae8c4 == null)
		{
			switch (xace224b4e703e245)
			{
			case x209db13a33ccc536.xb56b87770d51d55a:
				x22ec4ec5d9dae8c4 = new Region();
				break;
			case x209db13a33ccc536.x46f0ec9f7f657efb:
			case x209db13a33ccc536.x4c5ede5040bbffe5:
			case x209db13a33ccc536.xb016980fad4c82af:
				x22ec4ec5d9dae8c4 = new Region(xa78054fab93d29c1);
				break;
			case x209db13a33ccc536.x775521112ede5e6f:
				break;
			}
		}
	}

	public void xf1d9b91c9700c401(PointF x374ea4fe62468d0f)
	{
		if (!x374ea4fe62468d0f.IsEmpty && x22ec4ec5d9dae8c4 != null)
		{
			x22ec4ec5d9dae8c4.Translate(x374ea4fe62468d0f.X, x374ea4fe62468d0f.Y);
			xbb51cf398865871a();
		}
	}

	public void x94e221b782640829()
	{
		if (xfb29e3becee5329b == null)
		{
			xfb29e3becee5329b = x22ec4ec5d9dae8c4;
		}
		else
		{
			xfb29e3becee5329b.Intersect(x22ec4ec5d9dae8c4);
		}
		x22ec4ec5d9dae8c4 = null;
	}

	public xdc900fbd8f341706 x8b61531c8ea35b85()
	{
		xdc900fbd8f341706 xdc900fbd8f341707 = new xdc900fbd8f341706(xa78054fab93d29c1);
		if (x22ec4ec5d9dae8c4 != null)
		{
			xdc900fbd8f341707.x22ec4ec5d9dae8c4 = x22ec4ec5d9dae8c4.Clone();
		}
		if (xfb29e3becee5329b != null)
		{
			xdc900fbd8f341707.xfb29e3becee5329b = xfb29e3becee5329b.Clone();
		}
		return xdc900fbd8f341707;
	}

	protected override Region GetCurrentClippingRegion()
	{
		if (xfb29e3becee5329b == null)
		{
			return x22ec4ec5d9dae8c4;
		}
		if (x22ec4ec5d9dae8c4 == null)
		{
			return xfb29e3becee5329b;
		}
		Region region = xfb29e3becee5329b.Clone();
		region.Intersect(x22ec4ec5d9dae8c4);
		return region;
	}
}
