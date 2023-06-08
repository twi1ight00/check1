namespace ns322;

internal class Class7367 : Class7361, Interface400
{
	private string string_1;

	public string Text => string_1;

	public override string ToString()
	{
		return Text;
	}

	public override void vmethod_0(Interface395 visitor)
	{
		visitor.imethod_27(this);
	}

	public Class7367(string text)
	{
		string_1 = text;
	}
}
