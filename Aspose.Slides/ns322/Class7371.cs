namespace ns322;

internal class Class7371 : Class7361
{
	private Class7361 class7361_0;

	private Class7361 class7361_1;

	public Class7361 Member => class7361_0;

	public Class7361 Previous
	{
		get
		{
			return class7361_1;
		}
		set
		{
			class7361_1 = value;
		}
	}

	public override void vmethod_0(Interface395 visitor)
	{
		visitor.imethod_22(this);
	}

	public Class7371(Class7361 member, Class7361 previous)
	{
		class7361_0 = member;
		class7361_1 = previous;
	}
}
