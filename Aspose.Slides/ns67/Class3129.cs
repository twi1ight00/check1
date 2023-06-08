namespace ns67;

internal class Class3129 : Class3091
{
	public override Enum493 Kind => Enum493.const_186;

	public Class3129(Class3448 xfrm)
		: base(xfrm)
	{
	}

	public override Class3279 vmethod_1()
	{
		Class3279 @class = new Class3279(base.Transform2D);
		@class.method_2(10.0, 10.0, Enum492.const_0, extrusionOk: false, stroke: false);
		@class.method_3(0.0, 0.0);
		@class.method_4(0.0, 10.0);
		@class.method_4(10.0, 10.0);
		@class.method_4(10.0, 0.0);
		@class.method_8();
		@class.method_2(10.0, 10.0, Enum492.const_5, extrusionOk: false, stroke: true);
		@class.method_3(5.0, 0.0);
		@class.method_4(5.0, 10.0);
		@class.method_3(0.0, 5.0);
		@class.method_4(10.0, 5.0);
		return @class;
	}

	protected override void vmethod_0(Interface51 values)
	{
	}
}
