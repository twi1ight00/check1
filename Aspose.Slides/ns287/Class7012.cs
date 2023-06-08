using ns284;
using ns305;

namespace ns287;

internal class Class7012 : Class6983
{
	public string Profile
	{
		get
		{
			return method_45("profile", string.Empty);
		}
		set
		{
			method_21("profile", value);
		}
	}

	protected internal Class7012(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
		method_48(visitor);
	}
}
