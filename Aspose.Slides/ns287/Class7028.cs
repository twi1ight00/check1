using ns284;
using ns305;

namespace ns287;

internal class Class7028 : Class6983
{
	public bool Disabled
	{
		get
		{
			return method_34("disabled");
		}
		set
		{
			method_52("disabled", value);
		}
	}

	public string Label
	{
		get
		{
			return method_45("label", string.Empty);
		}
		set
		{
			method_21("label", value);
		}
	}

	protected internal Class7028(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
		method_48(visitor);
	}
}
