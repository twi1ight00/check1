using ns284;
using ns305;

namespace ns287;

internal class Class7016 : Class6983
{
	private Class7047 class7047_0;

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

	public string FrameBorder
	{
		get
		{
			return method_45("frameborder", string.Empty);
		}
		set
		{
			method_21("frameborder", value);
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

	public string MarginHeight
	{
		get
		{
			return method_45("marginheight", string.Empty);
		}
		set
		{
			method_21("marginheight", value);
		}
	}

	public string MarginWidth
	{
		get
		{
			return method_45("marginwidth", string.Empty);
		}
		set
		{
			method_21("marginwidth", value);
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

	public string Scrolling
	{
		get
		{
			return method_45("scrolling", string.Empty);
		}
		set
		{
			method_21("scrolling", value);
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

	protected internal Class7016(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
		visitor.imethod_54(this);
	}
}
