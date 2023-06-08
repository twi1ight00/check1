using ns305;

namespace ns284;

internal sealed class Class6985 : Class6983, Interface323
{
	public string Src => method_20("src");

	public string Height => method_20("height");

	public string Width => method_20("width");

	public string Alt => method_20("alt");

	public string VideoSrc => method_20("src");

	protected internal Class6985(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
		visitor.imethod_47(this);
	}
}
