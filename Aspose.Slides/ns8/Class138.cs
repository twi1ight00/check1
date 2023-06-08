using ns56;

namespace ns8;

internal class Class138
{
	private double double_0;

	private Class2174 class2174_0;

	public Enum332 PtType => class2174_0.PtType;

	public string ForName => class2174_0.ForName;

	public Enum329 For => class2174_0.For;

	public Enum305 Type => class2174_0.Type;

	public double Value
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	public Class138(Class2174 rule)
	{
		double_0 = rule.Val;
		if (!double.IsNaN(double_0) && !double.IsPositiveInfinity(rule.Val))
		{
			double_0 = Class102.smethod_9(double_0);
		}
		class2174_0 = rule;
	}

	public Class138 method_0()
	{
		Class2174 @class = new Class2174();
		@class.For = Enum329.const_1;
		@class.Type = class2174_0.Type;
		@class.Val = class2174_0.Val;
		@class.PtType = class2174_0.PtType;
		return new Class138(@class);
	}
}
