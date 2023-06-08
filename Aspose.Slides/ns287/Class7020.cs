using ns284;
using ns305;

namespace ns287;

internal class Class7020 : Class6983
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

	protected internal Class7020(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
	}
}
