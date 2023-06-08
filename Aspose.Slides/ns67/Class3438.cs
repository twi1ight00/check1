namespace ns67;

internal sealed class Class3438 : Class3437
{
	private readonly Class3342 class3342_0;

	public Class3342 DashStopList => class3342_0;

	public Class3438()
	{
		class3342_0 = new Class3342();
	}

	public override Class3437 vmethod_0()
	{
		return new Class3438(class3342_0.method_0());
	}

	private Class3438(Class3342 dashStopList)
	{
		class3342_0 = dashStopList;
	}
}
