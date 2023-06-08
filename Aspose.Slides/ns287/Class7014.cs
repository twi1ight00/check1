using ns284;
using ns305;

namespace ns287;

internal class Class7014 : Class6983
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

	public bool NoShade
	{
		get
		{
			return method_34("noshade");
		}
		set
		{
			method_52("noshade", value);
		}
	}

	public string Size
	{
		get
		{
			return method_45("size", string.Empty);
		}
		set
		{
			method_21("size", value);
		}
	}

	public string Width
	{
		get
		{
			return method_45("width", string.Empty);
		}
		set
		{
			method_21("width", value);
		}
	}

	protected internal Class7014(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
		visitor.imethod_13(this);
	}
}
