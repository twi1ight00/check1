using ns284;
using ns305;

namespace ns287;

internal class Class7034 : Class6983
{
	public string Text
	{
		get
		{
			return TextContent;
		}
		set
		{
			TextContent = value;
		}
	}

	public string HtmlFor
	{
		get
		{
			return method_45("htmlfor", string.Empty);
		}
		set
		{
			method_21("htmlfor", value);
		}
	}

	public string Event
	{
		get
		{
			return method_45("event", string.Empty);
		}
		set
		{
			method_21("event", value);
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

	public bool Defer
	{
		get
		{
			return method_34("defer");
		}
		set
		{
			method_52("defer", value);
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

	public string Type
	{
		get
		{
			return method_45("type", "text/javascript");
		}
		set
		{
			method_21("type", value);
		}
	}

	protected internal Class7034(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
		visitor.imethod_62(this);
	}
}
