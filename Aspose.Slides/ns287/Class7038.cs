using ns284;
using ns305;

namespace ns287;

internal class Class7038 : Class6983
{
	public int CellIndex
	{
		get
		{
			Class7040 @class = method_49<Class7040>();
			if (@class != null)
			{
				return method_51(@class.Cells);
			}
			return -1;
		}
	}

	public string Abbr
	{
		get
		{
			return method_45("abbr", string.Empty);
		}
		set
		{
			method_21("abbr", value);
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

	public string Axis
	{
		get
		{
			return method_45("axis", string.Empty);
		}
		set
		{
			method_21("axis", value);
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

	public int ColSpan
	{
		get
		{
			return method_39("colspan", 1);
		}
		set
		{
			method_42("colspan", value);
		}
	}

	public string Headers
	{
		get
		{
			return method_45("headers", string.Empty);
		}
		set
		{
			method_21("headers", value);
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

	public bool NoWrap
	{
		get
		{
			return method_34("nowrap");
		}
		set
		{
			method_52("nowrap", value);
		}
	}

	public int RowSpan
	{
		get
		{
			return method_39("rowspan", 1);
		}
		set
		{
			method_42("rowspan", value);
		}
	}

	public string Scope
	{
		get
		{
			return method_45("scope", string.Empty);
		}
		set
		{
			method_21("scope", value);
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

	protected internal Class7038(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
		if (base.TagName == "TH")
		{
			visitor.imethod_34(this);
			method_48(visitor);
			visitor.imethod_35(this);
		}
		else
		{
			visitor.imethod_32(this);
			method_48(visitor);
			visitor.imethod_33(this);
		}
	}
}
