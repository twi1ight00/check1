using ns284;
using ns305;

namespace ns287;

internal class Class7017 : Class6983
{
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

	public string Border
	{
		get
		{
			return method_45("border", string.Empty);
		}
		set
		{
			method_21("border", value);
		}
	}

	public float Height
	{
		get
		{
			return method_40("height", 0f, "\\d+(.\\d+)?");
		}
		set
		{
			method_43("height", value);
		}
	}

	public int Hspace
	{
		get
		{
			return method_39("hspace", 0);
		}
		set
		{
			method_42("hspace", value);
		}
	}

	public bool IsMap
	{
		get
		{
			return method_34("ismap");
		}
		set
		{
			method_52("ismap", value);
		}
	}

	public string LongDesc
	{
		get
		{
			return method_45("longdesc", string.Empty);
		}
		set
		{
			method_21("longdesc", value);
		}
	}

	public string Src
	{
		get
		{
			return method_45("src", string.Empty);
		}
		set
		{
			method_21("src", value);
		}
	}

	public string UseMap
	{
		get
		{
			return method_45("usemap", string.Empty);
		}
		set
		{
			method_21("usemap", value);
		}
	}

	public int Vspace
	{
		get
		{
			return method_39("vspace", 0);
		}
		set
		{
			method_42("vspace", value);
		}
	}

	public float Width
	{
		get
		{
			return method_40("width", 0f, "\\d+(.\\d+)?");
		}
		set
		{
			method_43("width", value);
		}
	}

	protected internal Class7017(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
		visitor.imethod_46(this);
	}
}
