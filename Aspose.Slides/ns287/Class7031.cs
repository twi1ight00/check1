using ns284;
using ns305;

namespace ns287;

internal class Class7031 : Class6983
{
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

	public string ValueType
	{
		get
		{
			return method_45("valuetype", string.Empty);
		}
		set
		{
			method_21("valuetype", value);
		}
	}

	protected internal Class7031(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
	}
}
