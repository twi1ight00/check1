namespace ns322;

internal class Class7363 : Class7361
{
	private Class7361 class7361_0;

	private Class7361 class7361_1;

	private Enum982 enum982_0;

	public Class7361 Left
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

	public Class7361 Right
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

	public Enum982 AssignmentOperator
	{
		get
		{
			return enum982_0;
		}
		set
		{
			enum982_0 = value;
		}
	}

	public override void vmethod_0(Interface395 visitor)
	{
		visitor.imethod_1(this);
	}
}
