using ns284;
using ns305;

namespace ns287;

internal class Class7032 : Class6983
{
	public int Width
	{
		get
		{
			return method_39("width", 0);
		}
		set
		{
			method_42("width", value);
		}
	}

	protected internal Class7032(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
		visitor.imethod_2(this);
		method_48(visitor);
		visitor.imethod_4(this);
	}
}
