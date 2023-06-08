namespace ns322;

internal class Class7387 : Class7360, Interface398
{
	private Class7360 class7360_0;

	private Class7360 class7360_1;

	private Class7360 class7360_2;

	private Class7360 class7360_3;

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

	public Class7360 ConditionExpression
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

	public Class7360 IncrementExpression
	{
		get
		{
			return class7360_2;
		}
		set
		{
			class7360_2 = value;
		}
	}

	public Class7360 Statement
	{
		get
		{
			return class7360_3;
		}
		set
		{
			class7360_3 = value;
		}
	}

	public override void vmethod_0(Interface395 visitor)
	{
		visitor.imethod_9(this);
	}
}
