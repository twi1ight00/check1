using ns284;
using ns305;

namespace ns287;

internal class Class6992 : Class6983
{
	protected internal Class6992(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
		if (base.StyleDeclarationInternal.Display.Value != 0 || base.FirstChild != null)
		{
			visitor.imethod_11(this);
			method_48(visitor);
			visitor.imethod_12(this);
		}
	}
}
