using ns56;

namespace ns8;

internal class Class107 : Class103
{
	private bool bool_0;

	private double double_0;

	private double double_1;

	private bool bool_1;

	private bool bool_2;

	public bool IsAlongPath => bool_0;

	public double StartAngle => double_0;

	public double SpanAngle => double_1;

	public bool IsStartElementTransition => bool_1;

	public bool IsFirstInCenter => bool_2;

	public Class107(Class2146 algorithm)
	{
		double_1 = 360.0;
		base.HorizontalAlignment = Enum120.const_2;
		base.VerticalAlignment = Enum121.const_2;
		Class2177[] paramList = algorithm.ParamList;
		foreach (Class2177 @class in paramList)
		{
			if (@class.Type == Enum304.const_37)
			{
				bool_0 = @class.Val == "alongPath";
			}
			if (@class.Type == Enum304.const_45)
			{
				double_0 = Class103.smethod_4(@class.Val, 0.0) % 360.0;
			}
			if (@class.Type == Enum304.const_43)
			{
				double_1 = Class103.smethod_4(@class.Val, 0.0) % 360.0;
			}
			if (@class.Type == Enum304.const_47)
			{
				bool_1 = @class.Val == "trans";
			}
			if (@class.Type == Enum304.const_12)
			{
				bool_2 = @class.Val == "fNode";
			}
			if (@class.Type == Enum304.const_54)
			{
				base.VerticalAlignment = Class103.smethod_2(@class.Val);
			}
			if (@class.Type == Enum304.const_21)
			{
				base.HorizontalAlignment = Class103.smethod_1(@class.Val);
			}
		}
	}
}
