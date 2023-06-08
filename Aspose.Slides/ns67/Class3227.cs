namespace ns67;

internal class Class3227 : Class3091
{
	private const string string_0 = "hf";

	private const string string_1 = "vf";

	public override Enum493 Kind => Enum493.const_9;

	public Class3227(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		double x = Class3089.smethod_1(base.Transform2D.Extents.Cx / 2.0, base.AdjustValues["hf"], 100000.0);
		double x2 = Class3089.smethod_1(base.Transform2D.Extents.Cy / 2.0, base.AdjustValues["vf"], 100000.0);
		double x3 = Class3089.smethod_1(base.Transform2D.Extents.Cy / 2.0, base.AdjustValues["vf"], 100000.0);
		double num = Class3089.smethod_7(x, 1080000.0);
		double num2 = Class3089.smethod_7(x, 18360000.0);
		double z = Class3089.smethod_10(x2, 1080000.0);
		double z2 = Class3089.smethod_10(x2, 18360000.0);
		double x4 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num);
		double num3 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, 0.0, num2);
		double num4 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num2, 0.0);
		double x5 = Class3089.smethod_2(base.Transform2D.Extents.Cx / 2.0, num, 0.0);
		double num5 = Class3089.smethod_2(x3, 0.0, z);
		double num6 = Class3089.smethod_2(x3, 0.0, z2);
		double top = Class3089.smethod_1(num5, num2, num);
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(x4, num5);
		@class.method_4(base.Transform2D.Extents.Cx / 2.0, 0.0);
		@class.method_4(x5, num5);
		@class.method_4(num4, num6);
		@class.method_4(num3, num6);
		@class.method_8();
		@class.TextRectangle = new Class3457(num3, top, num4, num6);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
		values.Add("hf", 105146.0);
		values.Add("vf", 110557.0);
	}
}
