using System;

namespace ns67;

internal class Class3272 : Class3091
{
	private const string string_0 = "adj1";

	private const string string_1 = "adj2";

	public override Enum493 Kind => Enum493.const_51;

	public Class3272(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double z = Class3089.smethod_1(50000.0, base.Transform2D.Extents.Cy, Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx));
		double y = Class3089.smethod_0(0.0, base.AdjustValues["adj1"], 100000.0);
		double y2 = Class3089.smethod_0(0.0, base.AdjustValues["adj2"], z);
		double num = Class3089.smethod_1(Math.Min(base.Transform2D.Extents.Cy, base.Transform2D.Extents.Cx), y2, 100000.0);
		double num2 = Class3089.smethod_2(base.Transform2D.Extents.Cy, 0.0, num);
		double num3 = Class3089.smethod_1(base.Transform2D.Extents.Cx, y, 200000.0);
		double num4 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num3);
		double num5 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num3, 0.0);
		double num6 = Class3089.smethod_1(num4, num, base.Transform2D.Extents.Cx / 2.0);
		double top = Class3089.smethod_2(num, 0.0, num6);
		double bottom = Class3089.smethod_2(num2, num6, 0.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(0.0, num);
		@class.method_4(base.Transform2D.Extents.Cx / 2.0, 0.0);
		@class.method_4(base.Transform2D.Extents.Cx, num);
		@class.method_4(num5, num);
		@class.method_4(num5, num2);
		@class.method_4(base.Transform2D.Extents.Cx, num2);
		@class.method_4(base.Transform2D.Extents.Cx / 2.0, base.Transform2D.Extents.Cy);
		@class.method_4(0.0, num2);
		@class.method_4(num4, num2);
		@class.method_4(num4, num);
		@class.method_8();
		@class.TextRectangle = new Class3457(num4, top, num5, bottom);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj1", 50000.0);
		values.Add("adj2", 50000.0);
	}
}
