namespace ns67;

internal class Class3142 : Class3091
{
	private const string string_0 = "adj1";

	private const string string_1 = "adj2";

	public override Enum493 Kind => Enum493.const_102;

	public Class3142(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double num = Class3089.smethod_1(base.Transform2D.Extents.Cx, base.AdjustValues["adj1"], 100000.0);
		double x = Class3089.smethod_3(0.0, num, 2.0);
		double num2 = Class3089.smethod_3(base.Transform2D.Extents.Cx, num, 2.0);
		double x2 = Class3089.smethod_3(num, num2, 2.0);
		double x3 = Class3089.smethod_3(num2, base.Transform2D.Extents.Cx, 2.0);
		double y = Class3089.smethod_1(base.Transform2D.Extents.Cy, base.AdjustValues["adj2"], 100000.0);
		double num3 = Class3089.smethod_3(0.0, y, 2.0);
		double y2 = Class3089.smethod_3(0.0, num3, 2.0);
		double y3 = Class3089.smethod_3(num3, y, 2.0);
		double y4 = Class3089.smethod_3(base.Transform2D.Extents.Cy, y, 2.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_5, extrusionOk: false, stroke: true);
		@class.method_3(0.0, 0.0);
		@class.method_6(new Struct159(x, 0.0), new Struct159(num, y2), new Struct159(num, num3));
		@class.method_6(new Struct159(num, y3), new Struct159(x2, y), new Struct159(num2, y));
		@class.method_6(new Struct159(x3, y), new Struct159(base.Transform2D.Extents.Cx, y4), new Struct159(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy));
		@class.TextRectangle = new Class3457(0.0, 0.0, base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj1", 50000.0);
		values.Add("adj2", 50000.0);
	}
}
