using ns305;

namespace ns284;

internal sealed class Class6987 : Class6983, Interface323
{
	public string Height => method_20("height");

	public string Width => method_20("width");

	protected internal Class6987(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
		visitor.imethod_50(this);
	}
}
