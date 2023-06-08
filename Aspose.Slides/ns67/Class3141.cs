namespace ns67;

internal class Class3141 : Class3091
{
	private const string string_0 = "adj1";

	public override Enum493 Kind => Enum493.const_101;

	public Class3141(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double num = Class3089.smethod_1(base.Transform2D.Extents.Cx, base.AdjustValues["adj1"], 100000.0);
		double x = Class3089.smethod_3(0.0, num, 2.0);
		double x2 = Class3089.smethod_3(base.Transform2D.Extents.Cx, num, 2.0);
		double y = Class3089.smethod_1(base.Transform2D.Extents.Cy, 3.0, 4.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_5, extrusionOk: false, stroke: true);
		@class.method_3(0.0, 0.0);
		@class.method_6(new Struct159(x, 0.0), new Struct159(num, base.Transform2D.Extents.Cy / 4.0), new Struct159(num, base.Transform2D.Extents.Cy / 2.0));
		@class.method_6(new Struct159(num, y), new Struct159(x2, base.Transform2D.Extents.Cy), new Struct159(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy));
		@class.TextRectangle = new Class3457(0.0, 0.0, base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj1", 50000.0);
	}
}
