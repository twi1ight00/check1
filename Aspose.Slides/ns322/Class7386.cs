namespace ns322;

internal class Class7386 : Class7360, Interface398
{
	private Class7360 class7360_0;

	private Class7361 class7361_0;

	private Class7360 class7360_1;

	public Class7360 InitialisationStatement
	{
		get
		{
			return class7360_0;
		}
		set
		{
			class7360_0 = value;
		}
	}

	public Class7361 Expression
	{
		get
		{
			return class7361_0;
		}
		set
		{
			class7361_0 = value;
		}
	}

	public Class7360 Statement
	{
		get
		{
			return class7360_1;
		}
		set
		{
			class7360_1 = value;
		}
	}

	public override void vmethod_0(Interface395 visitor)
	{
		visitor.imethod_8(this);
	}
}
