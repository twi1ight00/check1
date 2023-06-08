using ns284;
using ns305;

namespace ns287;

internal class Class7027 : Class6983
{
	public bool Compact
	{
		get
		{
			return method_34("compact");
		}
		set
		{
			method_52("compact", value);
		}
	}

	public int Start
	{
		get
		{
			return method_39("start", 0);
		}
		set
		{
			method_42("start", value);
		}
	}

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

	protected internal Class7027(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
		visitor.imethod_24(this);
		method_48(visitor);
		visitor.imethod_25(this);
	}
}
