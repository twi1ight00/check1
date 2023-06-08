using ns284;
using ns305;

namespace ns287;

internal class Class6998 : Class6983
{
	public string AccessKey
	{
		get
		{
			return method_45("accesskey", string.Empty);
		}
		set
		{
			method_21("accesskey", value);
		}
	}

	public string Alt
	{
		get
		{
			return method_45("alt", string.Empty);
		}
		set
		{
			method_21("alt", value);
		}
	}

	public string Coords
	{
		get
		{
			return method_45("coords", string.Empty);
		}
		set
		{
			method_21("coords", value);
		}
	}

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

	public bool NoHref
	{
		get
		{
			return method_39("nohref", @default: false);
		}
		set
		{
			method_44("nohref", value);
		}
	}

	public string Shape
	{
		get
		{
			return method_45("shape", string.Empty);
		}
		set
		{
			method_21("shape", value);
		}
	}

	public int TabIndex
	{
		get
		{
			return method_39("tabindex", 0);
		}
		set
		{
			method_42("tabindex", value);
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

	protected internal Class6998(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
		method_48(visitor);
	}
}
