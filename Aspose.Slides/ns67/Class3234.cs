using System;

namespace ns67;

internal class Class3234 : Class3091
{
	private const string string_0 = "adj1";

	private const string string_1 = "adj2";

	private const string string_2 = "adj3";

	public override Enum493 Kind => Enum493.const_54;

	public Class3234(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double num = Class3089.smethod_0(0.0, base.AdjustValues["adj2"], 50000.0);
		double z = Class3089.smethod_1(num, 2.0, 1.0);
		double y = Class3089.smethod_0(0.0, base.AdjustValues["adj1"], z);
		double x = Class3089.smethod_2(100000.0, 0.0, z);
		double z2 = Class3089.smethod_1(x, 1.0, 2.0);
		double y2 = Class3089.smethod_0(0.0, base.AdjustValues["adj3"], z2);
		double num2 = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), y2, 100000.0);
		double num3 = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), num, 100000.0);
		double x2 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num3);
		double x3 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num3, 0.0);
		double num4 = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), y, 200000.0);
		double x4 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num4);
		double x5 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num4, 0.0);
		double x6 = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num2);
		double y3 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num3);
		double y4 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num3, 0.0);
		double num5 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, 0.0, num4);
		double num6 = Class3089.smethod_2(base.Transform2D.Extents.Cy / 2.0, num4, 0.0);
		double y5 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num2);
		double num7 = Class3089.smethod_1(num4, num2, num3);
		double right = Class3089.smethod_2(base.Transform2D.Extents.Cx, 0.0, num7);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(0.0, base.Transform2D.Extents.Cy / 2.0);
		@class.method_4(num2, y3);
		@class.method_4(num2, num5);
		@class.method_4(x4, num5);
		@class.method_4(x4, num2);
		@class.method_4(x2, num2);
		@class.method_4(base.Transform2D.Extents.Cx / 2.0, 0.0);
		@class.method_4(x3, num2);
		@class.method_4(x5, num2);
		@class.method_4(x5, num5);
		@class.method_4(x6, num5);
		@class.method_4(x6, y3);
		@class.method_4(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy / 2.0);
		@class.method_4(x6, y4);
		@class.method_4(x6, num6);
		@class.method_4(x5, num6);
		@class.method_4(x5, y5);
		@class.method_4(x3, y5);
		@class.method_4(base.Transform2D.Extents.Cx / 2.0, base.Transform2D.Extents.Cy);
		@class.method_4(x2, y5);
		@class.method_4(x4, y5);
		@class.method_4(x4, num6);
		@class.method_4(num2, num6);
		@class.method_4(num2, y4);
		@class.method_8();
		@class.TextRectangle = new Class3457(num7, num5, right, num6);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj1", 22500.0);
		values.Add("adj2", 22500.0);
		values.Add("adj3", 22500.0);
	}
}
