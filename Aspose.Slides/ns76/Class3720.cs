namespace ns76;

internal class Class3720 : Class3716
{
	private Class3707 class3707_0;

	public override Class3707 ParentRule => class3707_0;

	public Class3720(Class3707 rule)
		: base(rule.ParentStyleSheet.Engine)
	{
		class3707_0 = rule;
	}
}
