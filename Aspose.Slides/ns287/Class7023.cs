using ns284;
using ns305;

namespace ns287;

internal class Class7023 : Class6983
{
	public Class7078 Areas => new Class7081(method_26("AREA"));

	public string Name
	{
		get
		{
			return method_45("name", string.Empty);
		}
		set
		{
			method_21("name", value);
		}
	}

	protected internal Class7023(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
		method_48(visitor);
	}
}
