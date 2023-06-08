using ns284;
using ns305;

namespace ns287;

internal class Class7026 : Class6983
{
	public string Cite
	{
		get
		{
			return method_45("cite", string.Empty);
		}
		set
		{
			method_21("cite", value);
		}
	}

	public string DateTime
	{
		get
		{
			return method_45("datetime", string.Empty);
		}
		set
		{
			method_21("datetime", value);
		}
	}

	protected internal Class7026(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
		visitor.imethod_3(this);
		method_48(visitor);
		visitor.imethod_4(this);
	}
}
