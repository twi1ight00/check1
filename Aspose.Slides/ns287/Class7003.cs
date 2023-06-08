using ns284;
using ns305;

namespace ns287;

internal class Class7003 : Class6983
{
	public Class7009 Form => method_49<Class7009>();

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

	public string Value
	{
		get
		{
			return method_45("value", string.Empty);
		}
		set
		{
			method_21("value", value);
		}
	}

	protected internal Class7003(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
		visitor.imethod_69(this);
	}
}
