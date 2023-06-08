using System;

namespace ns67;

internal class Class3226 : Class3091
{
	private const string string_0 = "adj";

	public override Enum493 Kind => Enum493.const_6;

	public Class3226(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double z = Class3089.smethod_1(100000.0, base.Transform2D.Extents.Cx, Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx));
		double y = Class3089.smethod_0(0.0, base.AdjustValues["adj"], z);
		double z2 = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), y, 200000.0);
		double num = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), y, 100000.0);
		Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, z2);
		double x = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num);
		double z3 = Class3089.smethod_1(x, 1.0, 2.0);
		Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, z3);
		double num2 = Class3089.smethod_1(base.Transform2D.Extents.Cx / 2.0, y, z);
		double y2 = Class3089.smethod_1(5.0, y, z);
		double x2 = Class3089.smethod_3(1.0, y2, 12.0);
		num2 = Class3089.smethod_1(x2, base.Transform2D.Extents.Cx, 1.0);
		double num3 = Class3089.smethod_1(x2, base.Transform2D.Extents.Cy, 1.0);
		double right = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num2);
		double bottom = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num3);
		double y3 = Class3089.smethod_1(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx / 2.0, num);
		double z4 = Class3089.smethod_0(0.0, y3, base.Transform2D.Extents.Cy);
		Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, z4);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(0.0, base.Transform2D.Extents.Cy);
		@class.method_4(num, 0.0);
		@class.method_4(base.Transform2D.Extents.Cx, 0.0);
		@class.method_4(x, base.Transform2D.Extents.Cy);
		@class.method_8();
		@class.TextRectangle = new Class3457(num2, num3, right, bottom);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj", 25000.0);
	}
}
