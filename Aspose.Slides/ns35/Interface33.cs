using System.Drawing;
using System.Drawing.Drawing2D;

namespace ns35;

internal interface Interface33
{
	void imethod_0(Interface32 g, Pen pen, CustomLineCap startCustomLineCap, CustomLineCap endCustomLineCap, float x, float y, float width, float height, float startAngle, float sweepAngle);

	void imethod_1(Interface32 g, Pen pen, CustomLineCap startCustomLineCap, CustomLineCap endCustomLineCap, PointF[] points, int offset, int numberOfSegments, float tension);

	void imethod_2(Interface32 g, Pen pen, CustomLineCap startCustomLineCap, CustomLineCap endCustomLineCap, float x1, float y1, float x2, float y2);

	void imethod_3(Interface32 g, Pen pen, CustomLineCap startCustomLineCap, CustomLineCap endCustomLineCap, GraphicsPath path);

	void imethod_4(PointF p);
}
