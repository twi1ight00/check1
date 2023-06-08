namespace ns322;

internal class Class7389 : Class7360
{
	private Class7361 class7361_0;

	private Class7360 class7360_0;

	private Class7360 class7360_1;

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

	public Class7360 Then
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

	public Class7360 Else
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
		visitor.imethod_11(this);
	}
}
