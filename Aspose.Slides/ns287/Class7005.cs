using ns284;
using ns305;
using ns84;

namespace ns287;

internal class Class7005 : Class6983
{
	public string Align
	{
		get
		{
			return method_45("align", string.Empty);
		}
		set
		{
			method_21("align", value);
		}
	}

	protected internal Class7005(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
		if (base.StyleDeclarationInternal.Display.Value != Enum630.const_21)
		{
			visitor.imethod_11(this);
			method_48(visitor);
			visitor.imethod_12(this);
		}
	}
}
