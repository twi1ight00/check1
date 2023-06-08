namespace ns237;

internal class Class6531 : Class6511
{
	private string string_1;

	internal Class6531(Class6672 context, string glyphWidths)
		: base(context)
	{
		string_1 = glyphWidths;
	}

	public override void vmethod_0(Class6679 writer)
	{
		writer.method_29(this);
		writer.Write(string_1);
		writer.method_30();
	}
}
