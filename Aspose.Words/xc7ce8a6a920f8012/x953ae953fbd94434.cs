using System.Drawing;
using x1c8faa688b1f0b0c;

namespace xc7ce8a6a920f8012;

internal class x953ae953fbd94434 : xf51865b83a7a0b3b
{
	private PointF x8f255acdc702317a;

	private PointF xccc798bae5d2e59e;

	private PointF xa3417f8a1e3ef4bd;

	private bool x0cc0742ff72dc31b;

	private bool x80cfd8ca8b1c2e31;

	private bool x3c061d2457b28308 = true;

	private x953ae953fbd94434()
	{
	}

	public static bool x3afb13b6c8441cd1(xab391c46ff9a0a38 xe125219852864557)
	{
		x953ae953fbd94434 x953ae953fbd94435 = new x953ae953fbd94434();
		xe125219852864557.Accept(x953ae953fbd94435);
		if (!x953ae953fbd94435.x3c061d2457b28308)
		{
			return xe125219852864557.x424546082eb650ba;
		}
		return true;
	}

	public override void VisitPathStart(xab391c46ff9a0a38 path)
	{
		x0cc0742ff72dc31b = true;
	}

	public override void VisitPathFigureStart(x1cab6af0a41b70e2 pathFigure)
	{
		x80cfd8ca8b1c2e31 = true;
	}

	public override void VisitPolyLineSegment(x60c040f35bb272aa segment)
	{
		if (segment.x4d7474e8f1849803.Count > 0)
		{
			if (x0cc0742ff72dc31b)
			{
				x8f255acdc702317a = (PointF)segment.x4d7474e8f1849803[0];
				xccc798bae5d2e59e = x8f255acdc702317a;
			}
			if (x80cfd8ca8b1c2e31 && !x0cc0742ff72dc31b)
			{
				xccc798bae5d2e59e = (PointF)segment.x4d7474e8f1849803[0];
				x3c061d2457b28308 &= xa3417f8a1e3ef4bd.Equals(xccc798bae5d2e59e);
			}
			x0cc0742ff72dc31b = false;
			x80cfd8ca8b1c2e31 = false;
			xa3417f8a1e3ef4bd = (PointF)segment.x4d7474e8f1849803[segment.x4d7474e8f1849803.Count - 1];
		}
	}

	public override void VisitBezierSegment(x519b1bd0625473ff segment)
	{
		if (x0cc0742ff72dc31b)
		{
			x8f255acdc702317a = segment.x56b911bdb6515aed.xaf4e0fbe61814cf5;
			xccc798bae5d2e59e = x8f255acdc702317a;
		}
		if (x80cfd8ca8b1c2e31 && !x0cc0742ff72dc31b)
		{
			xccc798bae5d2e59e = segment.x56b911bdb6515aed.xaf4e0fbe61814cf5;
			x3c061d2457b28308 &= xa3417f8a1e3ef4bd.Equals(xccc798bae5d2e59e);
		}
		x0cc0742ff72dc31b = false;
		x80cfd8ca8b1c2e31 = false;
		xa3417f8a1e3ef4bd = segment.x56b911bdb6515aed.x2271dea312f4a835;
	}

	public override void VisitPathFigureEnd(x1cab6af0a41b70e2 pathFigure)
	{
		if (pathFigure.x5e6c52cb3256cc85)
		{
			xa3417f8a1e3ef4bd = xccc798bae5d2e59e;
		}
	}

	public override void VisitPathEnd(xab391c46ff9a0a38 path)
	{
		x3c061d2457b28308 &= xa3417f8a1e3ef4bd.Equals(x8f255acdc702317a);
	}
}
