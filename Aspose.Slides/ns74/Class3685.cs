using ns305;
using ns73;
using ns76;

namespace ns74;

internal class Class3685 : Class3681
{
	private float float_0;

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
			return float_0.ToString(Class3726.cultureInfo_0) + string_0[short_35 - 1];
		}
		set
		{
			throw new Exception73(Enum968.const_14);
		}
	}

	public Class3685(float value, short type)
		: base(type)
	{
		float_0 = value;
		short_35 = type;
	}

	public static Class3685 smethod_0(float value, short type)
	{
		return new Class3685(value, type);
	}

	public override float vmethod_1(short unitType)
	{
		return float_0;
	}

	protected override bool Equals(Class3679 obj)
	{
		Class3685 @class = obj as Class3685;
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
			return float_0.Equals(@class.float_0);
		}
		return false;
	}
}
