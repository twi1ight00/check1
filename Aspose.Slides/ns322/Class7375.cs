namespace ns322;

internal class Class7375 : Class7361
{
	private string string_1;

	private string string_2;

	public string Regexp
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

	public string Options
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	public override void vmethod_0(Interface395 visitor)
	{
		visitor.imethod_34(this);
	}

	public Class7375(string regexp)
	{
		Regexp = regexp;
	}

	public Class7375(string regexp, string options)
		: this(regexp)
	{
		Options = options;
	}
}
