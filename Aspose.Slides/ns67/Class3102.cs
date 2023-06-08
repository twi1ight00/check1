using System;

namespace ns67;

internal class Class3102 : Class3091
{
	public override Enum493 Kind => Enum493.const_169;

	public Class3102(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double num = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), 3.0, 8.0);
		double num2 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num);
		double y = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num, 0.0);
		double num3 = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), 9.0, 32.0);
		double x = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num3);
		double x2 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num3, 0.0);
		double num4 = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), 3.0, 16.0);
		double x3 = Class3089.smethod_2(x2, 0.0, num4);
		double y2 = Class3089.smethod_2(num2, num4, 0.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: false);
		@class.method_3(0.0, 0.0);
		@class.method_4(base.Transform2D.Extents.Cx, 0.0);
		@class.method_4(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		@class.method_4(0.0, base.Transform2D.Extents.Cy);
		@class.method_8();
		@class.method_3(x, num2);
		@class.method_4(x3, num2);
		@class.method_4(x2, y2);
		@class.method_4(x2, y);
		@class.method_4(x, y);
		@class.method_8();
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_2, extrusionOk: false, stroke: false);
		@class.method_3(x, num2);
		@class.method_4(x3, num2);
		@class.method_4(x3, y2);
		@class.method_4(x2, y2);
		@class.method_4(x2, y);
		@class.method_4(x, y);
		@class.method_8();
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_1, extrusionOk: false, stroke: false);
		@class.method_3(x3, num2);
		@class.method_4(x3, y2);
		@class.method_4(x2, y2);
		@class.method_8();
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_5, extrusionOk: false, stroke: true);
		@class.method_3(x, num2);
		@class.method_4(x3, num2);
		@class.method_4(x2, y2);
		@class.method_4(x2, y);
		@class.method_4(x, y);
		@class.method_8();
		@class.method_3(x2, y2);
		@class.method_4(x3, y2);
		@class.method_4(x3, num2);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_5, extrusionOk: false, stroke: true);
		@class.method_3(0.0, 0.0);
		@class.method_4(base.Transform2D.Extents.Cx, 0.0);
		@class.method_4(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		@class.method_4(0.0, base.Transform2D.Extents.Cy);
		@class.method_8();
		@class.TextRectangle = new Class3457(0.0, 0.0, base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
	}
}
