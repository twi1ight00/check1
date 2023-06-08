using ns284;
using ns305;

namespace ns287;

internal class Class7029 : Class6983
{
	private bool bool_1;

	private bool bool_2;

	public Class7009 Form => method_49<Class7009>();

	public bool DefaultSelected
	{
		get
		{
			return method_34("selected");
		}
		set
		{
			method_53();
			method_52("selected", value);
		}
	}

	public string Text => TextContent;

	public int Index => 0;

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

	public string Label
	{
		get
		{
			return method_45("label", string.Empty);
		}
		set
		{
			method_21("label", value);
		}
	}

	public bool Selected
	{
		get
		{
			method_53();
			return bool_2;
		}
		set
		{
			bool_2 = value;
			bool_1 = true;
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

	protected internal Class7029(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	private void method_53()
	{
		if (!bool_1)
		{
			bool_2 = DefaultSelected;
			bool_1 = true;
		}
	}

	public override void vmethod_5(Interface325 visitor)
	{
		visitor.imethod_67(this);
		method_48(visitor);
		visitor.imethod_68(this);
	}
}
