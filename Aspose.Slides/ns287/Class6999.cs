using ns284;
using ns305;

namespace ns287;

internal class Class6999 : Class6983
{
	public string Href
	{
		get
		{
			return method_45("href", string.Empty);
		}
		set
		{
			method_21("href", value);
		}
	}

	public string Target
	{
		get
		{
			return method_45("target", string.Empty);
		}
		set
		{
			method_21("target", value);
		}
	}

	protected internal Class6999(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
		visitor.imethod_101(this);
	}
}
