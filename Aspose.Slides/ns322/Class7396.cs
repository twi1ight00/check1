namespace ns322;

internal class Class7396 : Class7360
{
	private Class7360 class7360_0;

	private Class7361 class7361_0;

	public Class7360 Statement => class7360_0;

	public Class7361 Expression => class7361_0;

	public Class7396(Class7361 expression, Class7360 statement)
	{
		class7360_0 = statement;
		class7361_0 = expression;
	}

	public override void vmethod_0(Interface395 visitor)
	{
		visitor.imethod_14(this);
	}
}
