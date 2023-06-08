namespace ns322;

internal class Class7383 : Class7360
{
	private Class7361 class7361_0;

	private Class7360 class7360_0;

	public Class7361 Condition => class7361_0;

	public Class7360 Statement => class7360_0;

	public override void vmethod_0(Interface395 visitor)
	{
		visitor.imethod_5(this);
	}

	public Class7383(Class7361 condition, Class7360 statement)
	{
		class7361_0 = condition;
		class7360_0 = statement;
	}
}
