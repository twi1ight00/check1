using ns284;
using ns305;

namespace ns287;

internal class Class7030 : Class6983
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

	protected internal Class7030(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
		visitor.imethod_11(this);
		method_48(visitor);
		visitor.imethod_12(this);
	}
}
