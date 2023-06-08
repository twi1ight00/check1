using System.Drawing;
using ns221;
using ns224;
using ns235;
using ns251;
using ns256;

namespace ns259;

internal interface Interface296
{
	PointF CurrentPoint { get; set; }

	Interface288 GuideValueProvider { get; }

	double ShapeWidth { get; }

	double ShapeHeight { get; }

	bool IsPictureRenderingMode { get; set; }

	PointF imethod_0(Class6410 point);

	double imethod_1(Class6403 coordinate, bool isXCoordinate);

	void imethod_2(double pathWidth, double pathHeight);

	[Attribute7(true)]
	Class6003 imethod_3();

	[Attribute7(true)]
	Class5990 imethod_4(Interface275 modifier, Class6217 path);
}
