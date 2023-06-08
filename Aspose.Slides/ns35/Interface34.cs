using System.Drawing;
using System.Drawing.Drawing2D;

namespace ns35;

internal interface Interface34
{
	GraphicsUnit PageUnit { get; set; }

	Matrix Transform { get; set; }

	RectangleF imethod_0(Region region);

	bool imethod_1(Region region);

	float imethod_2(Font font);

	Region[] imethod_3(string text, Font font, RectangleF layoutRect, StringFormat stringFormat);

	SizeF imethod_4(string text, Font font);

	SizeF imethod_5(string text, Font font, SizeF layoutArea);

	SizeF imethod_6(string text, Font font, int width);

	SizeF imethod_7(string text, Font font, PointF origin, StringFormat stringFormat);

	SizeF imethod_8(string text, Font font, SizeF layoutArea, StringFormat stringFormat);

	SizeF imethod_9(string text, Font font, int width, StringFormat format);

	SizeF imethod_10(string text, Font font, SizeF layoutArea, StringFormat stringFormat, out int charactersFitted, out int linesFilled);

	void Dispose();

	float imethod_11(Font font);

	float imethod_12(Font font);
}
