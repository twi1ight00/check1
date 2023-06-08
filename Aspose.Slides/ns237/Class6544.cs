using ns221;

namespace ns237;

internal class Class6544 : Class6511
{
	public Class6544(Class6672 context)
		: base(context)
	{
	}

	public override void vmethod_0(Class6679 writer)
	{
		writer.method_28(method_0());
		writer.method_29(this);
		writer.method_6();
		Class5956 info = class6672_0.Info;
		writer.method_13("/Title", info.Title);
		writer.method_13("/Author", info.Author);
		writer.method_13("/Subject", info.Subject);
		writer.method_13("/Keywords", info.Keywords);
		writer.method_13("/Creator", info.Creator);
		writer.method_13("/Producer", info.GeneratorName);
		writer.method_17("/CreationDate", info.CreationDate);
		writer.method_17("/ModDate", info.ModifiedDate);
		writer.method_7();
		writer.method_30();
	}
}
