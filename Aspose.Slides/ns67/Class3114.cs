namespace ns67;

internal class Class3114 : Class3091
{
	private const string string_0 = "adj1";

	public override Enum493 Kind => Enum493.const_97;

	public Class3114(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double x = Class3089.smethod_1(base.Transform2D.Extents.Cx, base.AdjustValues["adj1"], 100000.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_5, extrusionOk: false, stroke: true);
		@class.method_3(0.0, 0.0);
		@class.method_4(x, 0.0);
		@class.method_4(x, base.Transform2D.Extents.Cy);
		@class.method_4(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		@class.TextRectangle = new Class3457(0.0, 0.0, base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj1", 50000.0);
	}
}
