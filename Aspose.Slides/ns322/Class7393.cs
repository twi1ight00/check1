namespace ns322;

internal class Class7393 : Class7360
{
	private Class7360 class7360_0;

	private Class7679 class7679_0;

	private Class7445 class7445_0;

	public Class7360 Statement
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

	public Class7679 Finally
	{
		get
		{
			return class7679_0;
		}
		set
		{
			class7679_0 = value;
		}
	}

	public Class7445 Catch
	{
		get
		{
			return class7445_0;
		}
		set
		{
			class7445_0 = value;
		}
	}

	public override void vmethod_0(Interface395 visitor)
	{
		visitor.imethod_16(this);
	}
}
