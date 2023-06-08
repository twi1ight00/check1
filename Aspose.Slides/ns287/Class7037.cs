using ns284;
using ns305;

namespace ns287;

internal class Class7037 : Class6983
{
	public string Align
	{
		get
		{
			return method_45("align", "top");
		}
		set
		{
			method_21("align", value);
		}
	}

	protected internal Class7037(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
		visitor.imethod_44(this);
		method_48(visitor);
		visitor.imethod_45(this);
	}
}
