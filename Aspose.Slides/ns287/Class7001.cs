using ns284;
using ns305;

namespace ns287;

internal class Class7001 : Class6983
{
	public string ALink
	{
		get
		{
			return method_45("alink", string.Empty);
		}
		set
		{
			method_21("alink", value);
		}
	}

	public string Background
	{
		get
		{
			return method_45("background", string.Empty);
		}
		set
		{
			method_21("background", value);
		}
	}

	public string BgColor
	{
		get
		{
			return method_45("bgcolor", string.Empty);
		}
		set
		{
			method_21("bgcolor", value);
		}
	}

	public string Link
	{
		get
		{
			return method_45("link", string.Empty);
		}
		set
		{
			method_21("link", value);
		}
	}

	public string Text
	{
		get
		{
			return method_45("text", string.Empty);
		}
		set
		{
			method_21("text", value);
		}
	}

	public string VLink
	{
		get
		{
			return method_45("vlink", string.Empty);
		}
		set
		{
			method_21("vlink", value);
		}
	}

	protected internal Class7001(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
		visitor.imethod_17(this);
		method_48(visitor);
		visitor.imethod_18(this);
	}
}
