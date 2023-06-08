using ns284;
using ns305;

namespace ns287;

internal class Class7024 : Class6983
{
	public bool Compact
	{
		get
		{
			return method_39("compact", @default: false);
		}
		set
		{
			method_44("compact", value);
		}
	}

	protected internal Class7024(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
		visitor.imethod_97(this);
		method_48(visitor);
		visitor.imethod_98(this);
	}
}
