namespace ns67;

internal class Class3183 : Class3091
{
	public override Enum493 Kind => Enum493.const_143;

	public Class3183(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(5.0, 5.0, Enum492.const_0, extrusionOk: false, stroke: true);
		@class.method_3(0.0, 1.0);
		@class.method_4(1.0, 0.0);
		@class.method_4(5.0, 0.0);
		@class.method_4(5.0, 5.0);
		@class.method_4(0.0, 5.0);
		@class.method_8();
		@class.TextRectangle = new Class3457(0.0, base.Transform2D.Extents.Cy / 5.0, base.Transform2D.Extents.Cx, base.Transform2D.Extents.Cy);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
	}
}
