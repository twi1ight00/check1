using ns305;
using ns73;

namespace ns74;

internal class Class3689 : Class3681
{
	private string string_0;

	public override string CSSText
	{
		get
		{
			return string_0;
		}
		set
		{
			throw new Exception73(Enum968.const_14);
		}
	}

	public Class3689(string value)
		: this(value, 19)
	{
		string_0 = value;
	}

	public Class3689(string value, short unitType)
		: base(unitType)
	{
		string_0 = value;
	}

	public static Class3689 smethod_0(string value)
	{
		return new Class3689(value);
	}

	public static Class3689 smethod_1(string value)
	{
		return new Class3689(value, 21);
	}

	public override string vmethod_3()
	{
		return string_0;
	}

	protected override bool Equals(Class3679 obj)
	{
		Class3689 @class = obj as Class3689;
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
			return string_0.Equals(@class.string_0);
		}
		return false;
	}
}
