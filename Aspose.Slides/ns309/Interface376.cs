using System.Drawing;
using System.Drawing.Drawing2D;
using ns311;

namespace ns309;

internal interface Interface376
{
	Interface375 Font { get; }

	RectangleF ActualBounds { get; }

	int GlyphsLength { get; }

	GraphicsPath Outline { get; }

	RectangleF GeometricBounds { get; }

	GraphicsPath imethod_0(int index);

	GraphicsPath imethod_1(int index);

	RectangleF imethod_2(int index);

	int imethod_3(int index);

	int[] imethod_4(int start, int length, int[] result);

	PointF imethod_5(int index);

	float[] imethod_6(int start, int length, float[] result);

	Matrix imethod_7(int index);

	GraphicsPath imethod_8(int index);

	void imethod_9(int index, PointF position);

	void imethod_10(int index, Matrix trasformation);

	void imethod_11(int index, bool visible);

	bool imethod_12(int index);

	GraphicsPath imethod_13(float x, float y);

	RectangleF imethod_14(Class7127 iterator);
}
