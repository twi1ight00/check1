using ns305;
using ns73;
using ns76;

namespace ns74;

internal class Class3684 : Class3681
{
	private float float_0;

	private string string_0;

	public override string CSSText
	{
		get
		{
			return float_0.ToString(Class3726.cultureInfo_0) + string_0;
		}
		set
		{
			throw new Exception73(Enum968.const_14);
		}
	}

	public Class3684(float value, string unit)
		: base(18)
	{
		float_0 = value;
		string_0 = unit;
	}

	public override float vmethod_1(short unitType)
	{
		return float_0;
	}

	protected override bool Equals(Class3679 obj)
	{
		Class3684 @class = obj as Class3684;
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
