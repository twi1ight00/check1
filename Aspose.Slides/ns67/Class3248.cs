using System;

namespace ns67;

internal class Class3248 : Class3091
{
	private const string string_0 = "adj";

	public override Enum493 Kind => Enum493.const_30;

	public Class3248(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double y = Class3089.smethod_0(0.0, base.AdjustValues["adj"], 50000.0);
		double num = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), y, 100000.0);
		double x = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num);
		double top = Class3089.smethod_1(num, 1.0, 2.0);
		double right = Class3089.smethod_3(x, base.Transform2D.Extents.Cx, 2.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(0.0, 0.0);
		@class.method_4(x, 0.0);
		@class.method_4(base.Transform2D.Extents.Cx, num);
		@class.method_4(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		@class.method_4(0.0, base.Transform2D.Extents.Cy);
		@class.method_8();
		@class.TextRectangle = new Class3457(0.0, top, right, base.Transform2D.Extents.Cy);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj", 16667.0);
	}
}
