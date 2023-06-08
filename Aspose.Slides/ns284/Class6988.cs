using ns305;

namespace ns284;

internal sealed class Class6988 : Class6983, Interface324
{
	public string Align => method_20("align");

	public string TextAlign => method_20("align");

	public string VerticalAlign => "Baseline";

	protected internal Class6988(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
		visitor.imethod_26(this);
		method_48(visitor);
		visitor.imethod_27(this);
	}
}
