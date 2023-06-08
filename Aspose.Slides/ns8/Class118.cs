using System.Collections.Generic;
using ns56;

namespace ns8;

internal class Class118 : Class116
{
	private double double_0;

	public Enum329 ForRel => RuleElementData.For;

	public string ForName => RuleElementData.ForName;

	public Enum305 Type => RuleElementData.Type;

	public double Factor => RuleElementData.Fact;

	public double Value => double_0;

	private Class2174 RuleElementData => (Class2174)base.DataNode;

	public Class118(Class2174 rule)
	{
		double_0 = rule.Val;
		if (!double.IsNaN(double_0) && !double.IsInfinity(double_0) && rule.Type != Enum305.const_24 && rule.Type != 0)
		{
			double_0 = Class102.smethod_9(double_0);
		}
	}

	public List<Class837> method_5(Class837 root)
	{
		return root.method_36(RuleElementData.For, RuleElementData.ForName, RuleElementData.PtType);
	}
}
