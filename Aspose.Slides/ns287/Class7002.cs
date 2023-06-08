using ns284;
using ns305;

namespace ns287;

internal class Class7002 : Class6983
{
	public string Clear
	{
		get
		{
			return method_45("clear", string.Empty);
		}
		set
		{
			method_21("clear", value);
		}
	}

	protected internal Class7002(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
		visitor.imethod_14(this);
	}
}
