using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose;
using x1c8faa688b1f0b0c;

namespace x85732faf56f7825d;

[JavaManual("Manual by design.")]
internal class x5250236f9cf73045 : xf51865b83a7a0b3b
{
	private GraphicsPath xcd901d280bf50f26;

	public GraphicsPath x588bacbaa0ed1589 => xcd901d280bf50f26;

	public override void VisitPathStart(xab391c46ff9a0a38 path)
	{
		xcd901d280bf50f26 = new GraphicsPath(path.x4eada1f74f43bddb);
	}

	public override void VisitPathFigureStart(x1cab6af0a41b70e2 pathFigure)
	{
		xcd901d280bf50f26.StartFigure();
	}

	public override void VisitPathFigureEnd(x1cab6af0a41b70e2 pathFigure)
	{
		if (pathFigure.x5e6c52cb3256cc85)
		{
			xcd901d280bf50f26.CloseFigure();
		}
	}

	public override void VisitPolyLineSegment(x60c040f35bb272aa segment)
	{
		PointF[] points = segment.x4d7474e8f1849803.ToArray(typeof(PointF)) as PointF[];
		xcd901d280bf50f26.AddLines(points);
	}

	public override void VisitBezierSegment(x519b1bd0625473ff segment)
	{
		xcd901d280bf50f26.AddBezier(segment.x56b911bdb6515aed.xaf4e0fbe61814cf5, segment.x56b911bdb6515aed.xc7cf0e43653f9c41, segment.x56b911bdb6515aed.xf52fe1c3cad11afd, segment.x56b911bdb6515aed.x2271dea312f4a835);
	}
}
