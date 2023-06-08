namespace ns322;

internal class Class7394 : Class7360
{
	private bool bool_0;

	private string string_1;

	private Class7361 class7361_0;

	public bool Global
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public string Identifier
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
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

	public override void vmethod_0(Interface395 visitor)
	{
		visitor.imethod_17(this);
	}
}
