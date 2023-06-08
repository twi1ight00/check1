using System.Drawing;
using x1c8faa688b1f0b0c;

namespace xc7ce8a6a920f8012;

internal class x0739cbb3a510f53f : xf51865b83a7a0b3b
{
	private float xbacf01351a7abde7;

	private float xc83c3dc19dabc3fa;

	private float x7fd2c9eaff9eeb64;

	private float x28424f25b3a830a6;

	private x0739cbb3a510f53f()
	{
	}

	public static RectangleF xcdb96af2d82cc369(xab391c46ff9a0a38 xe125219852864557)
	{
		x0739cbb3a510f53f x0739cbb3a510f53f2 = new x0739cbb3a510f53f();
		xe125219852864557.Accept(x0739cbb3a510f53f2);
		return new RectangleF(x0739cbb3a510f53f2.xbacf01351a7abde7, x0739cbb3a510f53f2.xc83c3dc19dabc3fa, x0739cbb3a510f53f2.x7fd2c9eaff9eeb64 - x0739cbb3a510f53f2.xbacf01351a7abde7, x0739cbb3a510f53f2.x28424f25b3a830a6 - x0739cbb3a510f53f2.xc83c3dc19dabc3fa);
	}

	public override void VisitPolyLineSegment(x60c040f35bb272aa segment)
	{
		for (int i = 0; i < segment.x4d7474e8f1849803.Count; i++)
		{
			PointF x2f7096dac971d6ec = (PointF)segment.x4d7474e8f1849803[i];
			xc1f4be9d9b609019(x2f7096dac971d6ec);
		}
	}

	public override void VisitBezierSegment(x519b1bd0625473ff segment)
	{
		xc1f4be9d9b609019(segment.x56b911bdb6515aed.xaf4e0fbe61814cf5);
		xc1f4be9d9b609019(segment.x56b911bdb6515aed.xc7cf0e43653f9c41);
		xc1f4be9d9b609019(segment.x56b911bdb6515aed.xf52fe1c3cad11afd);
		xc1f4be9d9b609019(segment.x56b911bdb6515aed.x2271dea312f4a835);
	}

	private void xc1f4be9d9b609019(PointF x2f7096dac971d6ec)
	{
		if (x2f7096dac971d6ec.X > x7fd2c9eaff9eeb64)
		{
			x7fd2c9eaff9eeb64 = x2f7096dac971d6ec.X;
		}
		if (x2f7096dac971d6ec.Y > x28424f25b3a830a6)
		{
			x28424f25b3a830a6 = x2f7096dac971d6ec.Y;
		}
		if (x2f7096dac971d6ec.X < xbacf01351a7abde7)
		{
			xbacf01351a7abde7 = x2f7096dac971d6ec.X;
		}
		if (x2f7096dac971d6ec.Y < xc83c3dc19dabc3fa)
		{
			xc83c3dc19dabc3fa = x2f7096dac971d6ec.Y;
		}
	}
}
