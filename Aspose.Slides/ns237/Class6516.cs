namespace ns237;

internal class Class6516 : Class6515
{
	private Class6513 class6513_1;

	internal override string FontFileDictionaryEntryName => "/FontFile2";

	internal Class6516(Class6672 context)
		: base(context)
	{
	}

	public override void vmethod_0(Class6679 writer)
	{
		class6513_1 = new Class6513(base.Context);
		class6513_1.Length = (int)base.BaseStream.Length;
		base.vmethod_0(writer);
		class6513_1.vmethod_0(writer);
	}

	internal override void vmethod_2(Class6679 writer)
	{
		writer.method_8("/Length1", class6513_1.IndirectReference);
	}
}
