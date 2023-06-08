using System;

namespace ns67;

internal class Class3128 : Class3091
{
	private const string string_0 = "adj";

	public override Enum493 Kind => Enum493.const_73;

	public Class3128(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double z = Class3089.smethod_1(50000.0, base.Transform2D.Extents.Cy, Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx));
		double y = Class3089.smethod_0(0.0, base.AdjustValues["adj"], z);
		double num = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), y, 200000.0);
		double top = Class3089.smethod_2(num, num, 0.0);
		double num2 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: false);
		@class.method_3(0.0, num);
		@class.method_5(num, base.Transform2D.Extents.Cx / 2.0, 10800000.0, -10800000.0);
		@class.method_4(base.Transform2D.Extents.Cx, num2);
		@class.method_5(num, base.Transform2D.Extents.Cx / 2.0, 0.0, 10800000.0);
		@class.method_8();
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_3, extrusionOk: false, stroke: false);
		@class.method_3(0.0, num);
		@class.method_5(num, base.Transform2D.Extents.Cx / 2.0, 10800000.0, 10800000.0);
		@class.method_5(num, base.Transform2D.Extents.Cx / 2.0, 0.0, 10800000.0);
		@class.method_8();
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_5, extrusionOk: false, stroke: true);
		@class.method_3(base.Transform2D.Extents.Cx, num);
		@class.method_5(num, base.Transform2D.Extents.Cx / 2.0, 0.0, 10800000.0);
		@class.method_5(num, base.Transform2D.Extents.Cx / 2.0, 10800000.0, 10800000.0);
		@class.method_4(base.Transform2D.Extents.Cx, num2);
		@class.method_5(num, base.Transform2D.Extents.Cx / 2.0, 0.0, 10800000.0);
		@class.method_4(0.0, num);
		@class.TextRectangle = new Class3457(0.0, top, base.Transform2D.Extents.Cx, num2);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj", 25000.0);
	}
}
