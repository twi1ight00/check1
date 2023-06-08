using System;
using ns56;

namespace ns8;

internal class Class105 : Class103
{
	private double double_0;

	public double AspectRatio => double_0;

	public Class105(Class2146 algorithm)
	{
		double_0 = 0.0;
		base.HorizontalAlignment = Enum120.const_2;
		base.VerticalAlignment = Enum121.const_2;
		Class2177[] paramList = algorithm.ParamList;
		foreach (Class2177 @class in paramList)
		{
			if (@class.Type == Enum304.const_1)
			{
				double_0 = Math.Abs(Class103.smethod_4(@class.Val, 0.0));
			}
			else if (@class.Type == Enum304.const_21)
			{
				base.HorizontalAlignment = Class103.smethod_1(@class.Val);
			}
			else if (@class.Type == Enum304.const_54)
			{
				base.VerticalAlignment = Class103.smethod_2(@class.Val);
			}
		}
	}
}
