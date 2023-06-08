namespace ns305;

internal class Class7052 : Class6976
{
	private string string_0;

	public override string NodeName => string_0;

	public override string LocalName => string_0;

	public override Enum969 NodeType => Enum969.const_4;

	internal Class7052(string name, Class7046 doc)
		: base(doc)
	{
		string_0 = base.OwnerDocument.NameTable.Add(name);
	}

	public override Class6976 vmethod_2(bool deep)
	{
		return base.OwnerDocument.method_28(string_0);
	}
}
