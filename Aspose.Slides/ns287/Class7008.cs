using ns284;
using ns305;

namespace ns287;

internal class Class7008 : Class6983
{
	public string Color
	{
		get
		{
			return method_45("color", string.Empty);
		}
		set
		{
			method_21("color", value);
		}
	}

	public string Face
	{
		get
		{
			return method_45("face", string.Empty);
		}
		set
		{
			method_21("face", value);
		}
	}

	public string Size
	{
		get
		{
			return method_45("size", "3");
		}
		set
		{
			method_21("size", value);
		}
	}

	protected internal Class7008(Class7096 name, Class7046 doc)
		: base(name, doc)
	{
	}

	public override void vmethod_5(Interface325 visitor)
	{
		visitor.imethod_3(this);
		method_48(visitor);
		visitor.imethod_4(this);
	}
}
