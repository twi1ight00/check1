using System;

namespace ns67;

internal class Class3268 : Class3091
{
	private const string string_0 = "adj";

	public override Enum493 Kind => Enum493.const_7;

	public Class3268(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double z = Class3089.smethod_1(50000.0, base.Transform2D.Extents.Cx, Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx));
		double y = Class3089.smethod_0(0.0, base.AdjustValues["adj"], z);
		double z2 = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), y, 200000.0);
		double num = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), y, 100000.0);
		double x = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num);
		Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, z2);
		double num2 = Class3089.smethod_1(base.Transform2D.Extents.Cx / 3.0, y, z);
		double top = Class3089.smethod_1(base.Transform2D.Extents.Cy / 3.0, y, z);
		double right = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num2);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(0.0, base.Transform2D.Extents.Cy);
		@class.method_4(num, 0.0);
		@class.method_4(x, 0.0);
		@class.method_4(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		@class.method_8();
		@class.TextRectangle = new Class3457(num2, top, right, base.Transform2D.Extents.Cy);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj", 25000.0);
	}
}
