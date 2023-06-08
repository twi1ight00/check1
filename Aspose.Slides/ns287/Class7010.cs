using ns284;
using ns305;

namespace ns287;

internal class Class7010 : Class6983
{
	private Class7047 class7047_0;

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

	public bool NoResize
	{
		get
		{
			return method_34("noresize");
		}
		set
		{
			method_52("noresize", value);
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

	protected internal Class7010(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
		visitor.imethod_55(this);
	}
}
