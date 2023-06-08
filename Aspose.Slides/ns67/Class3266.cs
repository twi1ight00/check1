using System;

namespace ns67;

internal class Class3266 : Class3091
{
	private const string string_0 = "adj1";

	private const string string_1 = "adj2";

	public override Enum493 Kind => Enum493.const_71;

	public Class3266(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double y = Class3089.smethod_0(1.0, base.AdjustValues["adj1"], 75000.0);
		double z = Class3089.smethod_1(70000.0, base.Transform2D.Extents.Cx, Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx));
		double y2 = Class3089.smethod_0(0.0, base.AdjustValues["adj2"], z);
		double num = Class3089.smethod_1(base.Transform2D.Extents.Cy, y, 100000.0);
		double z2 = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), y2, 100000.0);
		double x = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, z2);
		double num2 = Class3089.smethod_2(0.0, Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx) / 8.0, 0.0);
		double y3 = Class3089.smethod_1(5400000.0, 1.0, 14.0);
		double num3 = Class3089.smethod_11(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx) / 8.0, y3);
		double x2 = Class3089.smethod_2(x, 0.0, num3);
		double y4 = Class3089.smethod_11(num, y3);
		double num4 = Class3089.smethod_2(num2, num, 0.0);
		double x3 = Class3089.smethod_2(x, y4, 0.0);
		double x4 = Class3089.smethod_2(x3, num3, 0.0);
		double num5 = Class3089.smethod_2(num4, Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx) / 8.0, 0.0);
		double x5 = Class3089.smethod_2(num5, 0.0, 0.0);
		double y5 = Class3089.smethod_1(x5, 1.0, 2.0);
		double z3 = Class3089.smethod_1(base.Transform2D.Extents.Cy, 1.0, 20.0);
		double y6 = Class3089.smethod_2(0.0, y5, z3);
		double y7 = Class3089.smethod_1(base.Transform2D.Extents.Cy / 6.0, 1.0, 1.0);
		double y8 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 6.0, y7, 0.0);
		double x6 = base.Transform2D.Extents.Cx / 6.0;
		double y9 = Class3089.smethod_1(base.Transform2D.Extents.Cy / 6.0, 1.0, 2.0);
		double y10 = Class3089.smethod_2(num4, y9, 0.0);
		double x7 = base.Transform2D.Extents.Cx / 4.0;
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(0.0, base.Transform2D.Extents.Cy);
		@class.method_7(new Struct159(x6, y8), new Struct159(x, num2));
		@class.method_4(x2, 0.0);
		@class.method_4(base.Transform2D.Extents.Cx, y6);
		@class.method_4(x4, num5);
		@class.method_4(x3, num4);
		@class.method_7(new Struct159(x7, y10), new Struct159(0.0, base.Transform2D.Extents.Cy));
		@class.method_8();
		@class.TextRectangle = new Class3457(0.0, 0.0, base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj1", 25000.0);
		values.Add("adj2", 16667.0);
	}
}
