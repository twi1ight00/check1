namespace ns322;

internal class Class7379 : Class7360
{
	private Class7673 class7673_0;

	public Class7673 Statements => class7673_0;

	public override void vmethod_0(Interface395 visitor)
	{
		visitor.imethod_2(this);
	}

	public Class7379()
	{
		class7673_0 = new Class7673();
	}

	public Class7379(Class7673 statements)
	{
		class7673_0 = statements;
	}
}
