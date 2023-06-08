using ns218;
using ns292;
using ns298;

namespace ns291;

internal class Class6862 : Class6861
{
	protected override string RootNamespace => null;

	public Class6862(Class6858 options, string filename, string title, Interface326 callback, Interface255 progressCallback)
		: base(options, filename, title, callback, progressCallback)
	{
	}

	protected override void vmethod_0()
	{
		base.WriterHelper.method_46("html", null, null, null);
	}

	protected override void vmethod_1()
	{
		base.WriterHelper.method_1(Enum931.const_24).method_5(Enum929.const_38, base.WriterHelper.Encoding.WebName).method_3();
	}
}
