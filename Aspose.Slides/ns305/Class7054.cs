using System;

namespace ns305;

internal class Class7054 : Class6976
{
	private string string_0;

	private string string_1;

	private string string_2;

	public string PublicId => string_1;

	public string SystemId => string_2;

	public override string NodeName => string_0;

	public override Enum969 NodeType => Enum969.const_11;

	internal Class7054(string name, string publicId, string systemId, Class7046 doc)
		: base(doc)
	{
		string_0 = doc.NameTable.Add(name);
		string_1 = publicId;
		string_2 = systemId;
	}

	public override Class6976 vmethod_2(bool deep)
	{
		throw new NotImplementedException();
	}
}
