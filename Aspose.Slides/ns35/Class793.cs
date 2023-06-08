using System.Drawing;
using System.Drawing.Drawing2D;

namespace ns35;

internal class Class793 : Interface33
{
	public void imethod_0(Interface32 g, Pen pen, CustomLineCap startCustomLineCap, CustomLineCap endCustomLineCap, float x, float y, float width, float height, float startAngle, float sweepAngle)
	{
		g.imethod_6(pen, x, y, width, height, startAngle, sweepAngle);
	}

	public void imethod_1(Interface32 g, Pen pen, CustomLineCap startCustomLineCap, CustomLineCap endCustomLineCap, PointF[] points, int offset, int numberOfSegments, float tension)
	{
		g.imethod_22(pen, points, offset, numberOfSegments, tension);
	}

	public void imethod_2(Interface32 g, Pen pen, CustomLineCap startCustomLineCap, CustomLineCap endCustomLineCap, float x1, float y1, float x2, float y2)
	{
		g.imethod_42(pen, x1, y1, x2, y2);
	}

	public void imethod_3(Interface32 g, Pen pen, CustomLineCap startCustomLineCap, CustomLineCap endCustomLineCap, GraphicsPath path)
	{
		g.imethod_45(pen, path);
	}

	public void imethod_4(PointF p)
	{
	}
}
