namespace ns67;

internal class Class3096 : Class3091
{
	private const string string_0 = "adj1";

	private const string string_1 = "adj2";

	private const string string_2 = "adj3";

	private const string string_3 = "adj4";

	public override Enum493 Kind => Enum493.const_107;

	public Class3096(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double y = Class3089.smethod_1(base.Transform2D.Extents.Cy, base.AdjustValues["adj1"], 100000.0);
		double x = Class3089.smethod_1(base.Transform2D.Extents.Cx, base.AdjustValues["adj2"], 100000.0);
		double y2 = Class3089.smethod_1(base.Transform2D.Extents.Cy, base.AdjustValues["adj3"], 100000.0);
		double x2 = Class3089.smethod_1(base.Transform2D.Extents.Cx, base.AdjustValues["adj4"], 100000.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: false);
		@class.method_3(0.0, 0.0);
		@class.method_4(base.Transform2D.Extents.Cx, 0.0);
		@class.method_4(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		@class.method_4(0.0, base.Transform2D.Extents.Cy);
		@class.method_8();
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_5, extrusionOk: false, stroke: true);
		@class.method_3(x, 0.0);
		@class.method_4(x, base.Transform2D.Extents.Cy);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_5, extrusionOk: false, stroke: true);
		@class.method_3(x, y);
		@class.method_4(x2, y2);
		@class.TextRectangle = new Class3457(0.0, 0.0, base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("adj1", 18750.0);
		values.Add("adj2", -8333.0);
		values.Add("adj3", 112500.0);
		values.Add("adj4", -38333.0);
	}
}