using ns305;
using ns73;
using ns76;

namespace ns74;

internal class Class3682 : Class3681
{
	private int int_0;

	private short short_35;

	protected static readonly string[] string_0 = new string[18]
	{
		string.Empty,
		"%",
		"em",
		"ex",
		"px",
		"cm",
		"mm",
		"in",
		"pt",
		"pc",
		"deg",
		"rad",
		"grad",
		"ms",
		"s",
		"Hz",
		"kHz",
		string.Empty
	};

	public override string CSSText
	{
		get
		{
			return int_0.ToString(Class3726.cultureInfo_0) + string_0[short_35 - 1];
		}
		set
		{
			throw new Exception73(Enum968.const_14);
		}
	}

	public Class3682(int value, short type)
		: base(type)
	{
		int_0 = value;
		short_35 = type;
	}

	public static Class3682 smethod_0(int value, short type)
	{
		return new Class3682(value, type);
	}

	public override float vmethod_1(short unitType)
	{
		return int_0;
	}

	protected override bool Equals(Class3679 obj)
	{
		Class3682 @class = obj as Class3682;
		if (object.ReferenceEquals(null, @class))
		{
			return false;
		}
		if (object.ReferenceEquals(this, @class))
		{
			return true;
		}
		if (base.CSSValueType.Equals(@class.CSSValueType))
		{
			return int_0.Equals(@class.int_0);
		}
		return false;
	}
}
