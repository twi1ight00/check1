namespace ns67;

internal class Class3200 : Class3091
{
	public override Enum493 Kind => Enum493.const_80;

	public Class3200(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		Class3089.smethod_1(base.Transform2D.Extents.Cx, 9722.0, 21600.0);
		double left = Class3089.smethod_1(base.Transform2D.Extents.Cx, 5372.0, 21600.0);
		Class3089.smethod_1(base.Transform2D.Extents.Cx, 11612.0, 21600.0);
		double right = Class3089.smethod_1(base.Transform2D.Extents.Cx, 14640.0, 21600.0);
		Class3089.smethod_1(base.Transform2D.Extents.Cy, 1887.0, 21600.0);
		double top = Class3089.smethod_1(base.Transform2D.Extents.Cy, 6382.0, 21600.0);
		Class3089.smethod_1(base.Transform2D.Extents.Cy, 12877.0, 21600.0);
		Class3089.smethod_1(base.Transform2D.Extents.Cy, 19712.0, 21600.0);
		Class3089.smethod_1(base.Transform2D.Extents.Cy, 18842.0, 21600.0);
		double bottom = Class3089.smethod_1(base.Transform2D.Extents.Cy, 15935.0, 21600.0);
		Class3089.smethod_1(base.Transform2D.Extents.Cy, 6645.0, 21600.0);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(21600.0, 21600.0, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(11462.0, 4342.0);
		@class.method_4(14790.0, 0.0);
		@class.method_4(14525.0, 5777.0);
		@class.method_4(18007.0, 3172.0);
		@class.method_4(16380.0, 6532.0);
		@class.method_4(21600.0, 6645.0);
		@class.method_4(16985.0, 9402.0);
		@class.method_4(18270.0, 11290.0);
		@class.method_4(16380.0, 12310.0);
		@class.method_4(18877.0, 15632.0);
		@class.method_4(14640.0, 14350.0);
		@class.method_4(14942.0, 17370.0);
		@class.method_4(12180.0, 15935.0);
		@class.method_4(11612.0, 18842.0);
		@class.method_4(9872.0, 17370.0);
		@class.method_4(8700.0, 19712.0);
		@class.method_4(7527.0, 18125.0);
		@class.method_4(4917.0, 21600.0);
		@class.method_4(4805.0, 18240.0);
		@class.method_4(1285.0, 17825.0);
		@class.method_4(3330.0, 15370.0);
		@class.method_4(0.0, 12877.0);
		@class.method_4(3935.0, 11592.0);
		@class.method_4(1172.0, 8270.0);
		@class.method_4(5372.0, 7817.0);
		@class.method_4(4502.0, 3625.0);
		@class.method_4(8550.0, 6382.0);
		@class.method_4(9722.0, 1887.0);
		@class.method_8();
		@class.TextRectangle = new Class3457(left, top, right, bottom);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
	}
}
