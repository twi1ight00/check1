namespace ns322;

internal class Class7369 : Class7361, Interface400
{
	private Class7361 class7361_0;

	public Class7361 Index
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

	public override string ToString()
	{
		return "[" + Index.ToString() + "]";
	}

	public override void vmethod_0(Interface395 visitor)
	{
		visitor.imethod_24(this);
	}

	public Class7369(Class7361 index)
	{
		Index = index;
	}
}
