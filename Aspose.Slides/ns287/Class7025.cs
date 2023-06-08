using ns284;
using ns305;

namespace ns287;

internal class Class7025 : Class6983
{
	public string Content
	{
		get
		{
			return method_45("content", string.Empty);
		}
		set
		{
			method_21("content", value);
		}
	}

	public string HttpEquiv
	{
		get
		{
			return method_45("http-equiv", string.Empty);
		}
		set
		{
			method_21("http-equiv", value);
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

	public string Scheme
	{
		get
		{
			return method_45("scheme", string.Empty);
		}
		set
		{
			method_21("scheme", value);
		}
	}

	protected internal Class7025(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
	}
}
