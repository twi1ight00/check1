using ns284;
using ns305;

namespace ns287;

internal class Class6996 : Class6983
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

	public string Charset
	{
		get
		{
			return method_45("charset", string.Empty);
		}
		set
		{
			method_21("charset", value);
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

	public string Hreflang
	{
		get
		{
			return method_45("hreflang", string.Empty);
		}
		set
		{
			method_21("hreflang", value);
		}
	}

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

	public string Rel
	{
		get
		{
			return method_45("rel", string.Empty);
		}
		set
		{
			method_21("rel", value);
		}
	}

	public string Rev
	{
		get
		{
			return method_45("rev", string.Empty);
		}
		set
		{
			method_21("rev", value);
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

	public string Type
	{
		get
		{
			return method_45("type", string.Empty);
		}
		set
		{
			method_21("type", value);
		}
	}

	protected internal Class6996(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public void method_53()
	{
	}

	public void method_54()
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
		visitor.imethod_58(this);
		method_48(visitor);
		visitor.imethod_60(this);
	}
}
