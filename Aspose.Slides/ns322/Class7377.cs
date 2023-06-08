namespace ns322;

internal class Class7377 : Class7361
{
	private Class7361 class7361_0;

	private Enum986 enum986_0;

	public Class7361 Expression => class7361_0;

	public Enum986 Type => enum986_0;

	public override void vmethod_0(Interface395 visitor)
	{
		visitor.imethod_32(this);
	}

	public Class7377(Enum986 type, Class7361 expression)
	{
		enum986_0 = type;
		class7361_0 = expression;
	}
}
