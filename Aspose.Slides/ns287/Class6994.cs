using ns284;
using ns305;

namespace ns287;

internal class Class6994 : Class6983
{
	private Class7047 class7047_0;

	public Class7009 Form => method_49<Class7009>();

	public string Code
	{
		get
		{
			return method_45("code", string.Empty);
		}
		set
		{
			method_21("code", value);
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

	public string Archive
	{
		get
		{
			return method_45("archive", string.Empty);
		}
		set
		{
			method_21("archive", value);
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

	public string CodeBase
	{
		get
		{
			return method_45("codebase", string.Empty);
		}
		set
		{
			method_21("codebase", value);
		}
	}

	public string CodeType
	{
		get
		{
			return method_45("codetype", string.Empty);
		}
		set
		{
			method_21("codetype", value);
		}
	}

	public string ClassId
	{
		get
		{
			return method_45("classid", string.Empty);
		}
		set
		{
			method_21("classid", value);
		}
	}

	public string Data
	{
		get
		{
			return method_45("data", string.Empty);
		}
		set
		{
			method_21("data", value);
		}
	}

	public bool Declare
	{
		get
		{
			return method_34("declare");
		}
		set
		{
			method_52("declare", value);
		}
	}

	public string Height
	{
		get
		{
			return method_45("height", string.Empty);
		}
		set
		{
			method_21("height", value);
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

	public string Standby
	{
		get
		{
			return method_45("standby", string.Empty);
		}
		set
		{
			method_21("standby", value);
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

	public Class7047 ContentDocument
	{
		get
		{
			return class7047_0;
		}
		set
		{
			class7047_0 = value;
		}
	}

	protected internal Class6994(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
		if (!visitor.imethod_52(this))
		{
			method_48(visitor);
		}
		visitor.imethod_53(this);
	}
}
