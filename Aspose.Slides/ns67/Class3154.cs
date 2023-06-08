using System;

namespace ns67;

internal class Class3154 : Class3091
{
	private const string string_0 = "adj1";

	private const string string_1 = "adj2";

	private const string string_2 = "adj3";

	private const string string_3 = "adj4";

	public override Enum493 Kind => Enum493.const_58;

	public Class3154(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double z = Class3089.smethod_1(50000.0, base.Transform2D.Extents.Cx, Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx));
		double num = Class3089.smethod_0(0.0, base.AdjustValues["adj2"], z);
		double z2 = Class3089.smethod_1(num, 2.0, 1.0);
		double y = Class3089.smethod_0(0.0, base.AdjustValues["adj1"], z2);
		double z3 = Class3089.smethod_1(100000.0, base.Transform2D.Extents.Cy, Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx));
		double num2 = Class3089.smethod_0(0.0, base.AdjustValues["adj3"], z3);
		double z4 = Class3089.smethod_1(num2, Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), base.Transform2D.Extents.Cy);
		double z5 = Class3089.smethod_2(100000.0, 0.0, z4);
		double y2 = Class3089.smethod_0(0.0, base.AdjustValues["adj4"], z5);
		double num3 = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), num, 100000.0);
		double num4 = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), y, 200000.0);
		double x = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num3);
		double x2 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num4);
		double x3 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num4, 0.0);
		double x4 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num3, 0.0);
		double z6 = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), num2, 100000.0);
		double y3 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, z6);
		double num5 = Class3089.smethod_1(base.Transform2D.Extents.Cy, y2, 100000.0);
		Class3089.smethod_1(num5, 1.0, 2.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(0.0, 0.0);
		@class.method_4(base.Transform2D.Extents.Cx, 0.0);
		@class.method_4(base.Transform2D.Extents.Cx, num5);
		@class.method_4(x3, num5);
		@class.method_4(x3, y3);
		@class.method_4(x4, y3);
		@class.method_4(base.Transform2D.Extents.Cx / 2.0, base.Transform2D.Extents.Cy);
		@class.method_4(x, y3);
		@class.method_4(x2, y3);
		@class.method_4(x2, num5);
		@class.method_4(0.0, num5);
		@class.method_8();
		@class.TextRectangle = new Class3457(0.0, 0.0, base.Transform2D.Extents.Cx, num5);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj1", 25000.0);
		values.Add("adj2", 25000.0);
		values.Add("adj3", 25000.0);
		values.Add("adj4", 64977.0);
	}
}
