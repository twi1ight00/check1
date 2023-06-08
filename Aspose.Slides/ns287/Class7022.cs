using ns284;
using ns305;

namespace ns287;

internal class Class7022 : Class6983
{
	public bool Disabled
	{
		get
		{
			return method_34("disabled");
		}
		set
		{
			method_52("disabled", value);
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

	public string Href
	{
		get
		{
			string text = method_45("href", string.Empty);
			if (text != null && text.IndexOf("&amp;") != -1)
			{
				text = text.Replace("&amp;", "&");
			}
			return text;
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

	public string Media
	{
		get
		{
			return method_45("media", string.Empty);
		}
		set
		{
			method_21("media", value);
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

	protected internal Class7022(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
	}
}
