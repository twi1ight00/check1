using System;

namespace ns305;

internal class Class7051 : Class6976
{
	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private string string_4;

	private string string_5;

	private string string_6;

	public string PublicId => string_2;

	public string SystemId => string_3;

	public string NotationName => string_1;

	public string InputEncoding => string_4;

	public string XmlEncoding => string_5;

	public string XmlVersion => string_6;

	public override string NodeName => string_0;

	public override string LocalName => string_0;

	public override Enum969 NodeType => Enum969.const_5;

	internal Class7051(string name, string publicId, string systemId, string notationName, string inputEncoding, string xmlEncoding, string xmlVersion, Class7046 doc)
		: base(doc)
	{
		string_0 = doc.NameTable.Add(name);
		string_2 = publicId;
		string_3 = systemId;
		string_1 = notationName;
		string_4 = inputEncoding;
		string_5 = xmlEncoding;
		string_6 = xmlVersion;
	}

	public override Class6976 vmethod_2(bool deep)
	{
		throw new InvalidOperationException();
	}
}
