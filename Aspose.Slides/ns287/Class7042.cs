using ns284;
using ns305;

namespace ns287;

internal class Class7042 : Class6983
{
	private bool bool_1;

	private string string_2;

	public string DefaultValue
	{
		get
		{
			return TextContent;
		}
		set
		{
			method_53();
			TextContent = value;
		}
	}

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

	public int Cols
	{
		get
		{
			return method_39("cols", 20);
		}
		set
		{
			method_42("cols", value);
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

	public bool ReadOnly
	{
		get
		{
			return method_34("readonly");
		}
		set
		{
			method_52("readonly", value);
		}
	}

	public int Rows
	{
		get
		{
			return method_39("rows", 2);
		}
		set
		{
			method_42("rows", value);
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

	public string Type => "textarea";

	public string Value
	{
		get
		{
			method_53();
			return string_2;
		}
		set
		{
			string_2 = value;
			bool_1 = true;
		}
	}

	protected internal Class7042(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	private void method_53()
	{
		if (!bool_1)
		{
			string_2 = DefaultValue;
			bool_1 = true;
		}
	}

	public void method_54()
	{
	}

	public void method_55()
	{
	}

	public void method_56()
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
		Interface325 textareaVisitor = visitor.imethod_89(this);
		visitor.imethod_90(this, textareaVisitor);
	}
}
