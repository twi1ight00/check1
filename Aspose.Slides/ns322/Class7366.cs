namespace ns322;

internal class Class7366 : Class7361, Interface399
{
	private Class7676 class7676_0;

	private Class7360 class7360_0;

	private string string_1;

	public Class7676 Parameters => class7676_0;

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

	public string Name
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

	public override void vmethod_0(Interface395 visitor)
	{
		visitor.imethod_21(this);
	}

	public Class7366()
	{
		class7676_0 = new Class7676();
	}
}
