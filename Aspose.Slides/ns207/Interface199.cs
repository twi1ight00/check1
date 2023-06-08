using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml;
using ns205;

namespace ns207;

internal interface Interface199
{
	void imethod_0(Matrix transform, SizeF size, RectangleF clipRect);

	void imethod_1(Matrix[] transforms, SizeF size, RectangleF clipRect);

	void imethod_2();

	void imethod_3(Matrix[] transforms);

	void imethod_4(Matrix transform);

	void imethod_5();

	void imethod_6(string family, string style, int weight, string variant, int size, Color color);

	void imethod_7(int x, int y, int letterSpacing, int wordSpacing, int[][] dp, string text);

	void imethod_8(Rectangle rect);

	void imethod_9(Rectangle rect, Brush fill);

	void imethod_10(Rectangle rect, Class5705 top, Class5705 bottom, Class5705 left, Class5705 right);

	void imethod_11(Point start, Point end, int width, Color color, Class5441 style);

	void imethod_12(string uri, Rectangle rect);

	void imethod_13(XmlDocument doc, Rectangle rect);
}
