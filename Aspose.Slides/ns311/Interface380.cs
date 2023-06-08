using System.Drawing;
using System.Drawing.Drawing2D;
using ns309;

namespace ns311;

internal interface Interface380
{
	PointF Top { get; }

	float[] GlyphLevels { get; }

	RectangleF Bounds { get; }

	RectangleF GeometricBounds { get; }

	GraphicsPath Outline { get; }

	PointF TextPathLevel { get; }

	PointF Offset { get; set; }

	Class7117 GlyphPath { get; }

	int GlyphCount { get; }

	Class7114 imethod_0(int index);

	GraphicsPath imethod_1(int type);

	void imethod_2(float scaleX, float scaleY, bool space);

	bool imethod_3(int index);

	float imethod_4(int index);

	GraphicsPath imethod_5(int start, int end);

	int imethod_6(int index);

	int imethod_7(int start, int end);
}
