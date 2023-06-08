using ns284;
using ns305;

namespace ns287;

internal class Class6995 : Class6983
{
	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private string string_2;

	public string DefaultValue
	{
		get
		{
			return method_45("value", string.Empty);
		}
		set
		{
			method_53();
			method_21("value", value);
		}
	}

	public bool DefaultChecked
	{
		get
		{
			return method_34("checked");
		}
		set
		{
			method_54();
			method_52("checked", value);
		}
	}

	public Class7009 Form => method_49<Class7009>();

	public string Accept
	{
		get
		{
			return method_45("accept", string.Empty);
		}
		set
		{
			method_21("accept", value);
		}
	}

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

	public string Alt
	{
		get
		{
			return method_45("alt", string.Empty);
		}
		set
		{
			method_21("alt", value);
		}
	}

	public bool Checked
	{
		get
		{
			method_54();
			return bool_3;
		}
		set
		{
			bool_3 = value;
			bool_1 = true;
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

	public int MaxLength
	{
		get
		{
			return method_39("maxlength", short.MaxValue);
		}
		set
		{
			method_42("maxlength", value);
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

	public int Size
	{
		get
		{
			return method_39("size", 20);
		}
		set
		{
			method_42("size", value);
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
			bool_2 = true;
		}
	}

	protected internal Class6995(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	private void method_53()
	{
		if (!bool_2)
		{
			string_2 = DefaultValue;
			bool_2 = true;
		}
	}

	private void method_54()
	{
		if (!bool_1)
		{
			bool_3 = DefaultChecked;
			bool_1 = true;
		}
	}

	public void method_55()
	{
	}

	public void method_56()
	{
	}

	public void method_57()
	{
	}

	public void method_58()
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
		switch (Type.ToLower())
		{
		case "checkbox":
			visitor.imethod_71(this);
			break;
		case "button":
		case "file":
			visitor.imethod_70(this);
			break;
		case "color":
			visitor.imethod_86(this);
			break;
		case "date":
			visitor.imethod_80(this);
			break;
		case "datetime":
			visitor.imethod_79(this);
			break;
		case "datetime-local":
			visitor.imethod_84(this);
			break;
		case "email":
			visitor.imethod_76(this);
			break;
		case "month":
			visitor.imethod_81(this);
			break;
		case "number":
			visitor.imethod_85(this);
			break;
		case "password":
			visitor.imethod_87(this);
			break;
		case "radio":
			visitor.imethod_88(this);
			break;
		case "range":
			visitor.imethod_72(this);
			break;
		case "reset":
			visitor.imethod_70(this);
			break;
		case "search":
			visitor.imethod_74(this);
			break;
		case "submit":
			visitor.imethod_70(this);
			break;
		case "tel":
			visitor.imethod_73(this);
			break;
		case "text":
			visitor.imethod_87(this);
			break;
		case "time":
			visitor.imethod_83(this);
			break;
		case "url":
			visitor.imethod_75(this);
			break;
		case "week":
			visitor.imethod_82(this);
			break;
		case "hidden":
		case "image":
			break;
		}
	}
}
