using System;

namespace ns67;

internal class Class3264 : Class3091
{
	private const string string_0 = "adj1";

	private const string string_1 = "adj2";

	public override Enum493 Kind => Enum493.const_47;

	public Class3264(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double z = Class3089.smethod_1(84375.0, base.Transform2D.Extents.Cx, Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx));
		double y = Class3089.smethod_0(0.0, base.AdjustValues["adj1"], 100000.0);
		double y2 = Class3089.smethod_0(0.0, base.AdjustValues["adj2"], z);
		double num = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), 5.0, 32.0);
		double num2 = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), y2, 100000.0);
		double x = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num2);
		double num3 = Class3089.smethod_1(base.Transform2D.Extents.Cy, y, 200000.0);
		double num4 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num3);
		double num5 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num3, 0.0);
		double z2 = Class3089.smethod_1(num3, num2, base.Transform2D.Extents.Cy / 2.0);
		double right = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, z2);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(0.0, num4);
		@class.method_4(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx) / 32.0, num4);
		@class.method_4(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx) / 32.0, num5);
		@class.method_4(0.0, num5);
		@class.method_8();
		@class.method_3(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx) / 16.0, num4);
		@class.method_4(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx) / 8.0, num4);
		@class.method_4(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx) / 8.0, num5);
		@class.method_4(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx) / 16.0, num5);
		@class.method_8();
		@class.method_3(num, num4);
		@class.method_4(x, num4);
		@class.method_4(x, 0.0);
		@class.method_4(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy / 2.0);
		@class.method_4(x, base.Transform2D.Extents.Cy);
		@class.method_4(x, num5);
		@class.method_4(num, num5);
		@class.method_8();
		@class.TextRectangle = new Class3457(num, num4, right, num5);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj1", 50000.0);
		values.Add("adj2", 50000.0);
	}
}
