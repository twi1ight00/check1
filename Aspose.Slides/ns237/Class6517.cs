using ns221;

namespace ns237;

internal class Class6517 : Class6515
{
	private readonly string string_1;

	internal override string FontFileDictionaryEntryName => "/FontFile3";

	internal Class6517(Class6672 context, string subtype)
		: base(context)
	{
		string_1 = subtype;
	}

	[Attribute7(true)]
	internal override void vmethod_2(Class6679 writer)
	{
		writer.method_8("/Subtype", string_1);
	}
}
