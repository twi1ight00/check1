using ns284;
using ns305;
using ns84;

namespace ns287;

internal class Class7021 : Class6983
{
	public string Type
	{
		get
		{
			return method_45("type", string.Empty);
		}
		set
		{
			method_21("type", value);
		}
	}

	public int Value
	{
		get
		{
			return method_39("value", 0);
		}
		set
		{
			method_42("value", value);
		}
	}

	protected internal Class7021(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
		if ((base.ParentElement != null && base.StyleDeclarationInternal.Display.Value != Enum630.const_2 && base.ParentElement.StyleDeclarationInternal.Display.Value != Enum630.const_1) || base.StyleDeclarationInternal.Float != Enum627.const_2)
		{
			visitor.imethod_3(this);
			method_48(visitor);
			visitor.imethod_4(this);
		}
		else
		{
			visitor.imethod_22(this);
			method_48(visitor);
			visitor.imethod_23(this);
		}
	}
}
