namespace ns67;

internal sealed class Class3358 : Class3344
{
	private readonly Class3328 class3328_0 = new Class3328();

	public Class3328 Container => class3328_0;

	public Class3358()
	{
	}

	public override Class3344 vmethod_0()
	{
		return new Class3358(this);
	}

	public Class3358(Class3358 src)
	{
		class3328_0 = (Class3328)src.class3328_0.vmethod_0();
	}
}
