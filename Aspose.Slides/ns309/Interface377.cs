using System.Drawing;
using System.Drawing.Drawing2D;
using ns315;

namespace ns309;

internal interface Interface377
{
	RectangleF Bounds { get; }

	RectangleF PrimitiveBounds { get; }

	Matrix Transform { get; set; }

	Matrix ReverseTransform { get; }

	Matrix ParentTransform { get; }

	RectangleF GeometryBounds { get; }

	bool Visible { get; set; }

	Class7135 Clip { get; set; }

	RectangleF imethod_0(Matrix transformation);

	RectangleF imethod_1(Matrix transformation);

	RectangleF imethod_2(Matrix transformation);

	bool imethod_3(PointF point);

	bool imethod_4(RectangleF rectangle);
}
