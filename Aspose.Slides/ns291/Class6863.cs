using ns218;
using ns292;
using ns298;

namespace ns291;

internal class Class6863 : Class6861
{
	internal const string string_6 = "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd";

	internal const string string_7 = "-//W3C//DTD XHTML 1.0 Transitional//EN";

	internal const string string_8 = "http://www.w3.org/1999/xhtml";

	protected override string RootNamespace => "http://www.w3.org/1999/xhtml";

	public Class6863(Class6858 options, string filename, string title, Interface326 callback, Interface255 progressCallback)
		: base(options, filename, title, callback, progressCallback)
	{
	}

	public Class6863(Class6858 options, string filename)
		: base(options, filename)
	{
	}

	protected override void vmethod_0()
	{
		base.WriterHelper.method_46("html", "-//W3C//DTD XHTML 1.0 Transitional//EN", "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd", null);
	}

	protected override void vmethod_1()
	{
		base.WriterHelper.method_1(Enum931.const_24).method_5(Enum929.const_39, "content-type").method_5(Enum929.const_40, $"text/html;charset={base.WriterHelper.Encoding.WebName}")
			.method_3();
	}
}
