using ns284;
using ns305;

namespace ns287;

internal class Class7039 : Class6983
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

	public string Ch
	{
		get
		{
			return method_45("char", string.Empty);
		}
		set
		{
			method_21("char", value);
		}
	}

	public string ChOff
	{
		get
		{
			return method_45("charoff", string.Empty);
		}
		set
		{
			method_21("charoff", value);
		}
	}

	public int Span
	{
		get
		{
			return method_39("abbr", 1);
		}
		set
		{
			method_42("abbr", value);
		}
	}

	public string VAlign
	{
		get
		{
			return method_45("valign", string.Empty);
		}
		set
		{
			method_21("valign", value);
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

	protected internal Class7039(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
		visitor.imethod_42(this);
		method_48(visitor);
		visitor.imethod_43(this);
	}
}
