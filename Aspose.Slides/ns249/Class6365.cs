using System.Drawing;
using ns218;
using ns224;

namespace ns249;

internal class Class6365
{
	public static Class6002 smethod_0(Class6360 brushRenderingContext)
	{
		Class6002 @class = new Class6002();
		@class.method_12((float)Class5963.smethod_1(brushRenderingContext.ShapeRotationAngle));
		return @class;
	}

	public static Class6002 smethod_1(Class6360 brushRenderingContext, PointF centerPoint)
	{
		Class6002 @class = new Class6002();
		@class.method_14((float)Class5963.smethod_1(brushRenderingContext.ShapeRotationAngle), centerPoint);
		return @class;
	}
}
